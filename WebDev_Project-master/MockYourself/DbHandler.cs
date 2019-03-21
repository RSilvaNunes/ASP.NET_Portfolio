using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MockYourself
{
    public class DbHandler
    {
        //get connection string in web.config
        static string cs = ConfigurationManager.ConnectionStrings["webSiteConn"].ConnectionString;
       
        SqlCommand cmd;

        /*
         * Generic method to query database
         */
        public SqlCommand Query(String queryString)
        {
            SqlConnection sqlConnection = new SqlConnection(cs);
            //use connection
            using (sqlConnection)
            {
                //prepare and execute sql command
                cmd = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                //iterator
                return cmd;
            }

            
        }

        /*
         * Insert into database
         */
        public void Execute(String queryString)
        {
            SqlConnection sqlConnection = new SqlConnection(cs);
            //use connection
            using (sqlConnection)
            {
                //prepare and execute sql command
                cmd = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();               
            }
        }

    }
}