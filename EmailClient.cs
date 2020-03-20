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

    /// <summary>
    /// BcTestovanie1
    /// Testovanie1
    /// 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
    /// </summary>

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
        public string Message { get; set; }
       // public string Result { get; set; }
    }



   

    public class EmailClient
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void ToJsonEmail(EmailSettings settings)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;


            using (StreamWriter sw = new StreamWriter(@"\emailsetting.json"))
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
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            var users = con.GetTable<User>();
            var x = from user in users where user.Id == 1 select (string)user.ApiKey;


            var key = x.FirstOrDefault();

            if (Environment.GetEnvironmentVariable("SENDGRID_API_KEY") == null || Environment.GetEnvironmentVariable("SENDGRID_API_KEY") != key)
            {
                Environment.SetEnvironmentVariable("SENDGRID_API_KEY", key);
            }

            return key;

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

        public async void SendMessageToAllNow(EmailBody email)
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