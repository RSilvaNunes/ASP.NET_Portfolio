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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //get form values 
            string courseName = txtCourseName.Text;
            decimal coursePrice = Convert.ToDecimal(txtCoursePrice.Text);
            string courseDescr = txtCourseDescr.InnerText;

            //verify form values


            //insert into database

            //get connection string in web.config
            string cs = ConfigurationManager.ConnectionStrings["webSiteConn"].ConnectionString;

            //use connection
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
               
                //prepare and execute sql command
                SqlCommand cmd = new SqlCommand(
                    "insert into Courses (name,description,price) values ('" +
                    courseName + "','" + courseDescr + "'," + coursePrice
                    + ")", cn);

                cmd.ExecuteNonQuery();               
            }
        }
    }
}