using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MockYourself
{
    public partial class CourseDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get course id from querystring
            String courseId = Request.QueryString["id"];
            
            //use connection
            using (SqlConnection conn = new SqlConnection())
            {
                // Setting up connection
                conn.ConnectionString = ApplicationServices.CONNECTION_STRING;
                conn.Open();

                //Query to execute
                SqlCommand cmd = new SqlCommand("SELECT * FROM my_courses where courseID='" + courseId + "'", conn);
                //Get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                //Iterate through query results
                while (rdr.Read())
                {
                    //Get column values from recordset      
                    lblCourseName.Text = rdr.GetString(1);
                    lblCourseDescription.Text = rdr.GetString(2);
                    lblCoursePrice.Text = "CAD$ " + rdr.GetDecimal(3).ToString();

                    btnAddToCart.Attributes["course-id"] = courseId;
                    btnAddToCart.Attributes["course-price"] = rdr.GetDecimal(3).ToString();
                }

                rdr.Close();

                string sql = "select i.COURSEID from MY_CART c, MY_CARTITEM i where i.courseid='"+ courseId + "' and " +
                    "c.CUSTOMERID = '" + ApplicationServices.loggedUserID + "' and c.STATUS = 'A' and c.CARTID = i.CARTID ";
                cmd = new SqlCommand(sql, conn);
                SqlDataReader courseCart = cmd.ExecuteReader();
                List<string> userCartCourses = new List<string>();
                while (courseCart.Read())
                {
                    btnAddToCart.Text = "Remove from cart";
                    btnAddToCart.CssClass = "btn btn-default remove-from-cart";
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (ApplicationServices.userAuthenticated)
            {
                Response.Write("<script>window.location = 'Cart.aspx'</script>");
            }
            else
            {
                Response.Write("<script>window.location = 'Sign-In.aspx'</script>");
            } 
        }
               

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (ApplicationServices.userAuthenticated)
            {
                Button btnClicked = (sender as Button);
                string courseId = btnClicked.Attributes["course-id"];
                decimal coursePrice = Convert.ToDecimal(btnClicked.Attributes["course-price"]);
                string operation = btnClicked.Text;

                string cartId = "(select cartid from my_cart where customerid='" +
                    ApplicationServices.loggedUserID + "' and status='A')";

                using (SqlConnection conn = new SqlConnection())
                {
                    // Setting up connection
                    conn.ConnectionString = ApplicationServices.CONNECTION_STRING;
                    conn.Open();

                    string sql;

                    if (operation.Equals("Add to cart"))
                    {
                        btnClicked.Text = "Remove from cart";
                        btnClicked.CssClass = "btn btn-default remove-from-cart";
                        sql = "INSERT INTO my_cartitem (courseid,cartid,paideach,quantity) values " +
                            "('" + courseId + "'," + cartId + "," + coursePrice + "*1.14,1)";
                    }
                    else
                    {
                        btnClicked.Text = "Add to cart";
                        btnClicked.CssClass = "btn btn-default add-to-cart";
                        sql = "DELETE FROM my_cartitem WHERE cartid=" + cartId + " and courseid='" + courseId + "'";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                Response.Write("<script>window.location = 'Sign-In.aspx'</script>");
            }
        }
    }
}