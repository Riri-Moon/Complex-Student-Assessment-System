using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

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
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        User currUser;
        public void ToJsonEmail(EmailSettings settings)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;


            StreamWriter sw = new StreamWriter(@"\emailsetting.json");
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }
        }
     
        // Change user to get from login
        public string SetEnvironmentVar(User currentUser)
        {
            try
            {
                StudentDBDataContext con = new StudentDBDataContext(conn_str);
                var users = con.GetTable<User>();
                var apikey = from user in users where user.Id == currentUser.Id select (string)user.ApiKey;

                if(apikey.Count() <= 0) {

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
            catch(InvalidDataException)
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