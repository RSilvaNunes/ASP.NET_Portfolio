using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MockYourself
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Loading country list
            FeedCountries(dropCountryList);
            
            // Loading reason list
            FeedReason(dropReasonList);

            //Click event on submit button
            submitButton.Click += new EventHandler(this.RegisterContact);

            //Click event on clear button
            clearButton.Click += new EventHandler(this.ClearAll);
        }

        // METHOD: Registering contact
        protected void RegisterContact(Object sender, EventArgs e)
        {
            bool validFirstName = ValidName(txtFirstName, firstNameWarning);
            bool validLastName = ValidName(txtLastName, lastNameWarning);
            bool validEmail = ValidEmail(txtEmail, emailWarning);
            bool validMessage = ValidMessage(txtMessage, messageWarning);

            if (validFirstName &&
                validLastName &&
                validEmail &&
                validMessage)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ApplicationServices.CONNECTION_STRING;

                    conn.Open();

                    SqlCommand pkCommand = new SqlCommand("SELECT NEXT VALUE FOR my_contacts_contactid_seq;", conn);

                    decimal pk;

                    using (SqlDataReader pkReader = pkCommand.ExecuteReader())
                    {
                        if (pkReader.Read())
                            pk = Convert.ToDecimal(pkReader.GetValue(0));
                        else
                            return;
                    }

                    string contactQuery = string.Format($"INSERT INTO MY_CONTACTS VALUES " +
                            $"({pk}, " +
                            $"'{txtFirstName.Text}', " +
                            $"'{txtLastName.Text}', " +
                            $"'{txtEmail.Text}', " +
                            $"'{dropCountryList.SelectedItem}', " +
                            $"'{dropReasonList.SelectedItem}');");

                    SqlCommand contactCommand = new SqlCommand(contactQuery, conn);
                    contactCommand.ExecuteNonQuery();

                    Response.Write("<script>window.alert('Email sent. Our team will contact you soon.');" +
                        "window.location='Default.aspx';</script>");

                    //Response.Redirect("Default.aspx");
                }
            }
        }

        // METHOD: Validating name
        protected bool ValidName(TextBox textboxName, Label nameWarning)
        {
            nameWarning.Text = "";

            bool isValid = false;

            string[] nameChars = (textboxName.Text).Split();

            Regex numberValidator = new Regex(@"^[0-9]");

            for (int i = 0; i < nameChars.Length; i++)
            {
                if (!numberValidator.IsMatch(nameChars[i].ToString()) && textboxName.Text.Length > 1)
                {
                    isValid = true;
                }
            }

            if (!isValid)
                nameWarning.Text = "Invalid name input.";

            return isValid;
        }

        // METHOD: Validating E-Mail
        protected bool ValidEmail(TextBox textboxEmail, Label emailWarning)
        {
            emailWarning.Text = "";

            bool isValid = false;

            if (textboxEmail.Text.Contains("@") && textboxEmail.Text.Contains("."))
            {
                isValid = true;
            }
            else
            {
                emailWarning.Text = "Invalid e-mail address.";
            }

            return isValid;
        }


        // METHOD: Validating country
        protected bool ValidCountry(DropDownList countryList, Label countryWarning)
        {
            countryWarning.Text = "";

            bool isValid = false;

            if (countryList.SelectedIndex > 0)
                isValid = true;
            else
                countryWarning.Text = "Please select a country.";

            return isValid;
        }

        // METHOD: Feeding country list
        protected void FeedCountries(DropDownList list)
        {
            list.Items.Clear();

            string[] countries = {"", "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla",
            "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas",
            "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia",
            "Bosnia and Herzegowina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam",
            "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands",
            "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia",
            "Comoros", "Congo", "Congo, the Democratic Republic of the", "Cook Islands", "Costa Rica", "Cote d'Ivoire",
            "Croatia (Hrvatska)", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic",
            "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia",
            "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "France Metropolitan", "French Guiana",
            "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar",
            "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti",
            "Heard and Mc Donald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong", "Hungary", "Iceland", "India",
            "Indonesia", "Iran (Islamic Republic of)", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan",
            "Kazakhstan", "Kenya", "Kiribati", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait",
            "Kyrgyzstan", "Lao, People's Democratic Republic", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya",
            "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia, The Former Yugoslav Republic of", "Madagascar",
            "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius",
            "Mayotte", "Mexico", "Micronesia, Federated States of", "Moldova, Republic of", "Monaco", "Mongolia", "Montserrat",
            "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles",
            "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands",
            "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn",
            "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda",
            "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino",
            "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Seychelles", "Sierra Leone", "Singapore",
            "Slovakia (Slovak Republic)", "Slovenia", "Solomon Islands", "Somalia", "South Africa",
            "South Georgia and the South Sandwich Islands", "Spain", "Sri Lanka", "St. Helena", "St. Pierre and Miquelon",
            "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic",
            "Taiwan, Province of China", "Tajikistan", "Tanzania, United Republic of", "Thailand", "Togo", "Tokelau", "Tonga",
            "Trinidad and Tobago", "Tunisia", "Türkiye", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine",
            "United Arab Emirates", "United Kingdom", "United States", "United States Minor Outlying Islands", "Uruguay",
            "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Virgin Islands (British)", "Virgin Islands (U.S.)",
            "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Yugoslavia", "Zambia", "Zimbabwe"};

            foreach (string country in countries)
                list.Items.Add(new ListItem(country));
        }

        //Feeding reason list
        protected void FeedReason(DropDownList list)
        {
            list.Items.Clear();

            string[] reasons = {"","Customer Support", "Suggestion", "Sales Inquiry", "General Contact"};

            foreach (string reason in reasons)
                list.Items.Add(new ListItem(reason));
        }
        // METHOD: Validating reason
        protected bool ValidReason(DropDownList reasonList, Label reasonWarning)
        {
            reasonWarning.Text = "";

            bool isValid = false;

            if (reasonList.SelectedIndex > 0)
                isValid = true;
            else
                reasonWarning.Text = "Please select a reason.";

            return isValid;
        }

        // METHOD: Validating message text
        protected bool ValidMessage(TextBox textboxMessage, Label messageWarning)
        {
            messageWarning.Text = "";

            bool isValid = false;

            if (textboxMessage.Text == null || textboxMessage.Text == "")
            {                
                messageWarning.Text = "Please type a message.";
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        // METHOD: Clearing textboxes
        protected void ClearAll(Object sender, EventArgs e)
        {
            // Clearing text boxes
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            dropCountryList.SelectedIndex = 0;
            dropReasonList.SelectedIndex = 0;
            txtMessage.Text = "";

            // Clearing warnings
            firstNameWarning.Text = "";
            lastNameWarning.Text = "";
            emailWarning.Text = "";
            countryWarning.Text = "";
            reasonWarning.Text = "";
            messageWarning.Text = "";

            // Setting focus
            txtFirstName.Focus();
        }
    }
}