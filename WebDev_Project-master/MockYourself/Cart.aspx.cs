using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MockYourself
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationServices.userAuthenticated)
                lblMessage.Text = "Please find below the details for your order.";
            else
            {
                lblMessage.Text = "Please sign-in in order to add items to your cart!";
                btnPurchase.Visible = false;
                btnCancel.Visible = false;
            }

            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            decimal id = ApplicationServices.loggedUserID;
            SqlConnection conn;
            SqlCommand command, command2;
            SqlDataReader reader;
            
            string connectionString = ApplicationServices.CONNECTION_STRING;
                                                                                                               
            conn = new SqlConnection(connectionString);
            
            string query = string.Format($"SELECT MY_COURSES.COURSENAME AS[Course Name], MY_CARTITEM.PAIDEACH AS[Price] FROM MY_COURSES INNER JOIN MY_CARTITEM ON MY_COURSES.COURSEID = MY_CARTITEM.COURSEID WHERE MY_CARTITEM.CARTID = (SELECT MY_CART.CARTID FROM MY_CART INNER JOIN MY_CUSTOMER ON MY_CART.CUSTOMERID = MY_CUSTOMER.CUSTOMERID WHERE MY_CUSTOMER.CUSTOMERID = {id} AND MY_CART.STATUS = 'A');");
            
            command = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                grid.DataSource = reader;
                grid.DataBind();
                reader.Close();

            }
            finally
            {
                conn.Close();
            }

            //display total price
            //string queryLabel = string.Format($"SELECT SUM(MY_CARTITEM.QUANTITY * MY_CARTITEM.PAIDEACH) FROM MY_CARTITEM INNER JOIN MY_COURSES ON MY_CARTITEM.COURSEID = MY_COURSES.COURSEID WHERE MY_CARTITEM.CARTID = (SELECT MY_CART.CARTID FROM MY_CART INNER JOIN MY_CUSTOMER ON MY_CART.CUSTOMERID = MY_CUSTOMER.CUSTOMERID WHERE MY_CUSTOMER.CUSTOMERID = 2)");

            // **************** IN FINAL VERSION OF DOC REPLACE WITH THIS STRING TO DISPLAY COURSES FOR ACTIVE USER
            string queryLabel = string.Format($"SELECT SUM(MY_CARTITEM.QUANTITY * MY_CARTITEM.PAIDEACH) FROM MY_CARTITEM INNER JOIN MY_COURSES ON MY_CARTITEM.COURSEID = MY_COURSES.COURSEID WHERE MY_CARTITEM.CARTID = (SELECT MY_CART.CARTID FROM MY_CART INNER JOIN MY_CUSTOMER ON MY_CART.CUSTOMERID = MY_CUSTOMER.CUSTOMERID WHERE MY_CUSTOMER.CUSTOMERID = {id} AND MY_CART.STATUS = 'A');");


            command2 = new SqlCommand(queryLabel, conn);
            try
            {
                conn.Open();
                object reader2 = command2.ExecuteScalar();

                if (reader2.ToString() == "")
                {
                    lblTotal.Visible = false;
                    lblMessage.Text = "No new items in cart.";
                    btnPurchase.Visible = false;
                    btnCancel.Visible = false;
                }
                else
                {
                    lblTotal.Text = string.Format("Cart Total: {0:C2}", reader2.ToString());
                    lblTotal.Visible = true;
                    btnPurchase.Visible = true;
                    btnCancel.Visible = true;
                }
            }
            finally
            {
                conn.Close();
            }
        }        

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            decimal cartID = 0;
            decimal lastKey = 0;

            using (SqlConnection connection = new SqlConnection(ApplicationServices.CONNECTION_STRING))
            {
                connection.Open();

                // Getting logged user's current cart's ID
                string queryGetCartID = $"select cartID from my_cart where customerID={ApplicationServices.loggedUserID} and status = 'A';";
                SqlCommand command = new SqlCommand(queryGetCartID, connection);
                SqlDataReader data = command.ExecuteReader();

                if (data.Read())
                    cartID = data.GetDecimal(0);

                data.Close();

                command = new SqlCommand("select top 1 cartID from my_cart order by cartID desc;", connection);

                SqlDataReader keyData = command.ExecuteReader();

                if (keyData.Read())
                    lastKey = keyData.GetDecimal(0);

                keyData.Close();

                // Updating cart status and creating a new one for the user
                string updateQuery = $"update my_cart set status = 'C' where cartid = {cartID}; " +
                    $"update my_cart set payment = (select sum(paideach) from my_cartitem where cartid = {cartID}) where cartid = {cartID}; " +
                    $"insert into my_cart(cartID, customerID, status, payment) values({lastKey + 1}, {ApplicationServices.loggedUserID}, 'A', null); ";

                command = new SqlCommand(updateQuery, connection);

                command.ExecuteNonQuery();
            }

            //shows confirmation window
            Response.Write("<script>alert('Thank you for the purchase. Payment processed successfully!'); window.location.href = 'Default.aspx';</script>");
        }

        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
    }
}