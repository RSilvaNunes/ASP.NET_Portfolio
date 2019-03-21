using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MockYourself
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //use connection
            using (SqlConnection conn = new SqlConnection())
            {
                // Setting up connection
                conn.ConnectionString = ApplicationServices.CONNECTION_STRING;
                conn.Open();

                //Query to execute
                SqlCommand cmd = new SqlCommand("SELECT * FROM my_courses", conn);
                //Get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                SqlDataReader courseCart;

                List<List<string>> courseList = new List<List<string>>();

                while (rdr.Read())
                {
                    List<string> course = new List<string>();
                    course.Add(rdr.GetDecimal(0).ToString());
                    course.Add(rdr.GetString(1));
                    course.Add(rdr.GetString(2).Truncate(150)+"...");
                    course.Add(rdr.GetDecimal(3).ToString());
                    course.Add(rdr.GetString(4));
                    courseList.Add(course);
                }

                rdr.Close();

                string sql = "select i.COURSEID from MY_CART c, MY_CARTITEM i where "+
                "c.CUSTOMERID = '"+ApplicationServices.loggedUserID+"' and c.STATUS = 'A' and c.CARTID = i.CARTID ";
                cmd = new SqlCommand(sql, conn);
                courseCart = cmd.ExecuteReader();
                List<string> userCartCourses = new List<string>();
                while(courseCart.Read()){
                    userCartCourses.Add(courseCart.GetDecimal(0).ToString());
                }

                courseCart.Close();

                //Iterate through query results
                foreach (List<string> course in courseList)
                {
                    //Get column values from string
                    string courseId = course[0];
                    string courseName = course[1];
                    string courseDescr = course[2];
                    string coursePrice = course[3];
                    string courseIcon = course[4];

                    //Creates course main container controller
                    HtmlGenericControl container = new HtmlGenericControl("div");
                    //Adds proper css class
                    container.Attributes["class"] = "col-md-6";

                    //Creates box panel controller
                    HtmlGenericControl panel = new HtmlGenericControl("div");
                    //Adds proper css class
                    panel.Attributes["class"] = "panel panel-default";

                    //Creates panel heading controller
                    HtmlGenericControl panelHeading = new HtmlGenericControl("div");
                    //Adds proper css class
                    panelHeading.Attributes["class"] = "panel-heading";

                    //Creates course main container controller
                    HtmlGenericControl heading = new HtmlGenericControl("h4");

                    //Creates icon controller if an icon is defined for the current item
                    if (!courseIcon.Equals("") && courseIcon != null)
                    {
                        HtmlGenericControl icon = new HtmlGenericControl("i");
                        //Adds proper css class
                        icon.Attributes["class"] = "fa fa-fw fa-" + courseIcon;
                        //adds icon to course heading
                        heading.Controls.Add(icon);
                    }

                    //Adds course name to heading
                    heading.Controls.Add(new LiteralControl(courseName));


                    //adds panel to panelheading
                    panelHeading.Controls.Add(heading);

                    //Creates description panel controller
                    HtmlGenericControl panelBody = new HtmlGenericControl("div");
                    //Adds proper css class
                    panelBody.Attributes["class"] = "panel-body";

                    //Creates description panel controller
                    HtmlGenericControl description = new HtmlGenericControl("p");
                    description.Controls.Add(new LiteralControl(courseDescr));

                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "~/CourseDetails.aspx?id=" + courseId;
                    link.Text = "Learn More";
                    link.CssClass = "btn btn-default";

                    Button btnAddToCart = new Button();
                    btnAddToCart.Click += toggleCart;
                    btnAddToCart.Text = "Add to cart";
                    btnAddToCart.CssClass = "btn btn-default add-to-cart";
                    btnAddToCart.Attributes["course-id"] = courseId;
                    btnAddToCart.Attributes["course-price"] = coursePrice;

                    foreach (string s in userCartCourses)
                    {
                        if (s == courseId)
                        {
                            btnAddToCart.Text = "Remove from cart";
                            btnAddToCart.CssClass = "btn btn-default remove-from-cart";
                        }
                    }

                    HtmlGenericControl separator = new HtmlGenericControl("br");
                    HtmlGenericControl priceTag = new HtmlGenericControl("div");

                    priceTag.Attributes["class"] = "priceTag";
                    priceTag.Controls.Add(new LiteralControl("CAD$ " + coursePrice.ToString()));                   

                    //Put everythig together
                    panelBody.Controls.Add(description);
                    panelBody.Controls.Add(priceTag);
                    panelBody.Controls.Add(separator);
                    panelBody.Controls.Add(btnAddToCart);
                    panelBody.Controls.Add(link);

                    panel.Controls.Add(panelHeading);
                    panel.Controls.Add(panelBody);
                    container.Controls.Add(panel);

                    CourseBoxes.Controls.Add(container);
                }
            }           
        }
        private void toggleCart(object sender, System.EventArgs e)
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
                        sql = "INSERT INTO my_cartitem (courseid,cartid,paideach,quantity) values "+
                            "('"+courseId+"',"+ cartId + ","+coursePrice+"*1.14,1)";                        
                    }
                    else
                    {
                        btnClicked.Text = "Add to cart";
                        btnClicked.CssClass = "btn btn-default add-to-cart";
                        sql = "DELETE FROM my_cartitem WHERE cartid="+cartId+" and courseid='"+courseId+"'";
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