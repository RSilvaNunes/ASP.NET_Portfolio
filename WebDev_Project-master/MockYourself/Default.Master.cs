using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace MockYourself
{
    public partial class Default1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<string> pageNames = new List<string>() ;
            pageNames.Add("Courses");

            if (ApplicationServices.userAuthenticated)
                pageNames.Add("Cart");

            pageNames.Add("Contact");

            //Page names list.
            //To change the order of the links in the menu, just change their order in this array.
            if (!ApplicationServices.userAuthenticated)
                pageNames.Add("Sign-In");
            else
                pageNames.Add("Sign-Out");

            //Create a new menu list
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            //Give a proper id
            ul.ID = "headerBarMenuUL";
            //Add bootstrap classes to ul
            ul.Attributes["class"] = "nav navbar-nav navbar-right";           
            //Iterate through pagenames in array
            foreach (var item in pageNames)
            {
                //Create a new links obj
                HyperLink link = new HyperLink();
                //Give it a proper ID 
                link.ID = "headerBarLink" + item;
                //Setup the URL, text and css class
                link.NavigateUrl = "~/" + item +".aspx";
                link.Text = item;
                link.CssClass = "headerBarLink";

                //Create the li obj
                HtmlGenericControl li = new HtmlGenericControl("li");
                //Add link to li
                li.Controls.Add(link);
                //Add li to ul
                ul.Controls.Add(li);
            }

            //Add ul to menu bar container.
            headerBarLinkContainer.Controls.Add(ul);
        }
    }
}