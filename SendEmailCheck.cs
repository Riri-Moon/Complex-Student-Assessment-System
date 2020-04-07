using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Data.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CSAS
{

    public class SendEmailCheck
    {

        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        List<EmailAddress> firstReminderAddresses = new List<EmailAddress>();
        List<EmailAddress> secondReminderAddresses = new List<EmailAddress>();

        public async void AutomatedEmailSending(User user)
        {
            try
            {
                EmailClient eClient = new EmailClient();       
                SendGridClient client = new SendGridClient(eClient.SetEnvironmentVar());


                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var activity = con.GetTable<Activity>().Where(chck => chck.IdUser == user.Id);
                    /// Pridane && emailsendingactive==true
                    var selectActivity = from act in activity
                                         where act.IdUser == user.Id && act.EmailSendingActive == true
                                         group act by new { act.Deadline, act.ActivityName };

                    if (selectActivity == null)
                    {
                        return;
                    }

                    foreach (var group in selectActivity)
                    {
                        foreach (var act in group)
                        {

                            // Deadline - 31/3 - 30/3 = 1 dni
                            var days = ((act.Deadline.Subtract(DateTime.Now).TotalDays));

                            switch (act.EmailSendingActive)
                            {
                                /// Odosielanie prvych upozorneni ak do odovzdania zostavaju 3 alebo 2 dni
                                case true when days <= 3 && days > 1 && act.SendFirst==true && act.Hodnotene==false:
                                    {
                                        firstReminderAddresses.Add(MailHelper.StringToEmailAddress(act.Student.Email));
                                        Activity currAct = con.GetTable<Activity>().Where(x => x.Id == act.Id).FirstOrDefault();
                                        currAct.SendFirst = false;
                                        con.SubmitChanges(ConflictMode.ContinueOnConflict);
                                        break;
                                    }
                                /// Zbieranie emailovych adries na odoslanie druhych upozorneni ak do odovzdania zostavaju 1 alebo 0 dni

                                case true when days >= 0 && days < 1 && act.SendSecond==true && act.Hodnotene==false:
                                    {
                                        secondReminderAddresses.Add(MailHelper.StringToEmailAddress(act.Student.Email));
                                        Activity currAct = con.GetTable<Activity>().Where(x => x.Id == act.Id).FirstOrDefault();
                                        currAct.SendSecond = false;
                                        currAct.EmailSendingActive = false;
                                        con.SubmitChanges(ConflictMode.ContinueOnConflict);
                                        break;
                                    }


                                default:
                                    continue;

                            }
                        }

                        if (firstReminderAddresses.Count>=1)
                        {
                            var emailToSend = group.Select(x => x.IdFirstRem);
                            var template = con.GetTable<EmailTemplate>().Where(x => x.IdUser == user.Id && x.Id == emailToSend.FirstOrDefault()).FirstOrDefault();
                            await SendEmails(template, 3, firstReminderAddresses, user, group.Key.Deadline);
                        }
                        if(secondReminderAddresses.Count>=1)
                        {
                            var emailToSend = group.Select(x => x.IdSecRem);
                            var template = con.GetTable<EmailTemplate>().Where(x => x.IdUser == user.Id && x.Id == emailToSend.FirstOrDefault()).FirstOrDefault();
                            await SendEmails(template, 1, secondReminderAddresses, user, group.Key.Deadline);
                        }
                      
                    }
                }
            }
            
            catch(Exception)
            {
                return;
            }   
        }     



        private async Task<Response> SendEmails(EmailTemplate emailTemplate, int numberOfDays,List<EmailAddress> emailAddresses, User user, DateTime date)
        {
            try
            {

                EmailClient eClient = new EmailClient();
                SendGridClient client = new SendGridClient(eClient.SetEnvironmentVar());
                List<SendGrid.Helpers.Mail.Attachment> attachmentList = new List<SendGrid.Helpers.Mail.Attachment>();
                EmailAttachments emailAttachments = new EmailAttachments();
                EmailBody body = new EmailBody()
                {
                    HtmlContent = emailTemplate.EmailContent.Replace("\u00A0", "<br/>"),// +"<br/> <br/> " + user.Signature
                    PlainTextContent = emailTemplate.EmailContent,
                    Subject = emailTemplate.EmailSubject,
                    To = emailAddresses
                };

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var attachments = con.GetTable<Attachment>().Where(x => x.IdUser == user.Id && x.IdEmailTemplate == emailTemplate.Id);
                    
                    foreach (var files in  attachments)
                    {

                        if(File.Exists(files.FilePath))
                        {
                            var bytes = File.ReadAllBytes(files.FilePath);
                            var file = Convert.ToBase64String(bytes);
                            var type = emailAttachments.GetMIMEType(files.FilePath);

                            SendGrid.Helpers.Mail.Attachment attachment = new SendGrid.Helpers.Mail.Attachment()
                            {
                                Content = file,
                                Filename = (string)files.FileName,
                                Type = type
                            };
                            attachmentList.Add(attachment);
                        } else
                        {

                            // Tu pridat log ak nebude file existovat
                            continue;
                        }
                    }

                }
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(user.Email), body.To, body.Subject, body.HtmlContent, body.HtmlContent);

                var dates = date.AddDays(-numberOfDays);
                var unixDate = new DateTimeOffset(dates.Year, dates.Month, dates.Day, dates.Hour, dates.Minute, dates.Second, TimeSpan.Zero).ToUnixTimeSeconds();
                msg.SetSendAt((int)unixDate - 3600);
                if (attachmentList.Count >= 1)
                {
                    msg.AddAttachments(attachmentList);
                }
                var result = await client.SendEmailAsync(msg);

                attachmentList.Clear();
                emailAddresses.Clear();
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

    }
}
