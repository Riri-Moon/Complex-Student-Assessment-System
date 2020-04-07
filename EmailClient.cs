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

        public EmailSettings FromJsonEmail()
        {
            JsonSerializer streamReader = new JsonSerializer();
            var jsonString = File.ReadAllText(@"\emailsetting.json");
            var emailsetting = JsonConvert.DeserializeObject<EmailSettings>(jsonString);
            return emailsetting;
        }






        // Change user to get from login
        public string SetEnvironmentVar()
        {
            try
            {
                StudentDBDataContext con = new StudentDBDataContext(conn_str);
                var users = con.GetTable<User>();
                var apikey = from user in users where user.Id == 1 select (string)user.ApiKey;


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

        List<EmailAddress> emailAdresses = new List<EmailAddress>();
        EmailAddress x = new EmailAddress();
        EmailBody body = new EmailBody();

        //object json = JsonConvert.DeserializeObject(data);
        //public async Task<Response> SendMessageToAllNow(EmailBody email)
        //{x

        //    var key = SetEnvironmentVar();
        //    var client = new SendGridClient(key);
        //    await client.RequestAsync(SendGridClient.Method.POST, urlPath: "/templates/", requestBody: data);
        //   // var msg = MailHelper.CreateSingleEmailToMultipleRecipients(email.From, email.To, email.Subject, email.PlainTextContent, email.HtmlContent);


        //   // var result = await client.SendEmailAsync(msg);

        //    //return result;

        //}

        public  void SendMessageToAllNow(EmailBody email)
        {

     

           // var key = SetEnvironmentVar();
           // var client = new SendGridClient(key);

          //  await client.RequestAsync(SendGridClient.Method.POST, urlPath: "/templates/", requestBody: data);
            // var msg = MailHelper.CreateSingleEmailToMultipleRecipients(email.From, email.To, email.Subject, email.PlainTextContent, email.HtmlContent);


            // var result = await client.SendEmailAsync(msg);

            //return result;

        }
    }
}