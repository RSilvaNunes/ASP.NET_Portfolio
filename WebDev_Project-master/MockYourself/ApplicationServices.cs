using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockYourself
{
    public static class ApplicationServices
    {
        // Connection string
        public static string CONNECTION_STRING = @"Server=GRUDINHOSHP\SQLEXPRESS;" +
                        "Database=MockYourself;" +
                        "Trusted_Connection=true";

        // Keeping track of unsuccessful login attempts
        public static int loginAttempts = 0;

        // Keeping track of authentication status
        public static bool userAuthenticated = false;

        // Keeping track of who the logged user is
        public static decimal loggedUserID = -1;
    }
}