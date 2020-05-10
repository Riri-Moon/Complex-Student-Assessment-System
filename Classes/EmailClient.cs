using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CSAS
{


    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string EmailAddress { get; set; }
    }


    public class EmailBody
    {
        public string Subject { get; set; }
        public List<EmailAddress> To { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }

    public class EmailClient
    {
        private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;

        // Change user to get from login
        public string SetEnvironmentVar(User currentUser)
        {
            try
            {
                StudentDBDataContext con = new StudentDBDataContext(conn_str);
                var users = con.GetTable<User>();
                var apikey = from user in users where user.Id == currentUser.Id select (string)user.ApiKey;

                if (apikey.Count() <= 0)
                {

                    System.Windows.Forms.MessageBox.Show("Je nutné pridať ApiKey v nastaveniach používateľa");
                    return null;
                }
                var key = apikey.FirstOrDefault();

                if (Environment.GetEnvironmentVariable("SENDGRID_API_KEY") == null ||
                    Environment.GetEnvironmentVariable("SENDGRID_API_KEY") != key)
                {
                    Environment.SetEnvironmentVariable("SENDGRID_API_KEY", key);
                }

                return key;
            }
            catch (InvalidDataException)
            {
                System.Windows.Forms.MessageBox.Show("Nie je nastavený kľúč");
                return null;
            }
        }

        public void SetEnvironmentVar(string Apikey)
        {
            try
            {
                if (string.IsNullOrEmpty(Apikey))
                {
                    System.Windows.Forms.MessageBox.Show("Nastala chyba, prosím kontaktujte poverenú osobu");
                    return;
                }

                if (Environment.GetEnvironmentVariable("SENDGRID_API_KEY") == null ||
                    Environment.GetEnvironmentVariable("SENDGRID_API_KEY") != Apikey)
                {
                    Environment.SetEnvironmentVariable("SENDGRID_API_KEY", Apikey);
                }
            }
            catch (InvalidDataException)
            {
                System.Windows.Forms.MessageBox.Show("Nastala chyba, prosím kontaktujte poverenú osobu");
                return;
            }

        }


    }
}