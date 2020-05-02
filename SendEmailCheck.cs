using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Data.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace CSAS
{

    public class SendEmailCheck
    {

                private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;

        List<EmailAddress> firstReminderAddresses = new List<EmailAddress>();
        List<EmailAddress> secondReminderAddresses = new List<EmailAddress>();

        bool SendToMe = false;
        public async void AutomatedEmailSending(User user)
        {
            try
            {
                EmailClient eClient = new EmailClient();
                if (string.IsNullOrEmpty(user.ApiKey))
                {
                    return;
                }
                SendGridClient client = new SendGridClient(eClient.SetEnvironmentVar(user));


                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var activity = con.GetTable<Activity>().Where(chck => chck.IdUser == user.Id);              

                    /// Zoskupenie aktivit na zaklade mena aktivity a datumu odovzdania. aby sa mohli odosielat presne emaily, a iba tam, kde, 
                    /// bolo oznacene odosielanie emailovych  upozorneni.
                    var selectActivity = from act in activity
                                         where act.IdUser == user.Id && act.EmailSendingActive == true
                                         group act by new { act.Deadline, act.ActivityName };

                    if (selectActivity == null)
                    {
                        return;
                    }

                    ///Prehladavanie kazdej skupiny
                    foreach (var group in selectActivity)
                    {
                        // Prehladavanie jednotlivych aktivit v skupine, aby sme zistili ci ma student dostat upozornenie
                        foreach (var act in group)
                        {

                            
                            var days = ((act.Deadline.Subtract(DateTime.Now).TotalDays));

                            switch (act.EmailSendingActive)
                            {
                                /// Odosielanie prvych upozorneni ak do odovzdania zostavaju 3 alebo 2 dni
                                case true when days <= 3 && days > 1 && act.SendFirst == true && act.Hodnotene == false:
                                    {
                                        firstReminderAddresses.Add(MailHelper.StringToEmailAddress(act.Student.Email));
                                        Activity currAct = con.GetTable<Activity>().Where(x => x.Id == act.Id).FirstOrDefault();
                                        currAct.SendFirst = false;
                                        con.SubmitChanges(ConflictMode.ContinueOnConflict);
                                        break;
                                    }
                                /// Zbieranie emailovych adries na odoslanie druhych upozorneni ak do odovzdania zostavaju 1 alebo 0 dni

                                case true when days >= 0 && days < 1 && act.SendSecond == true && act.Hodnotene == false:
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


                            if(act.SendMe ==true && act.Hodnotene==false && days <=0)
                            {
                                Activity currAct = con.GetTable<Activity>().Where(x => x.Id == act.Id).FirstOrDefault();
                                currAct.SendMe = false;
                                SendToMe = true;
                            }
                        }

                        /// Ziskanie emailu, ktory ma byt odoslany pre konkretnu aktivitu
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


                    if(SendToMe==true)
                    {
                        var msg = MailHelper.CreateSingleEmail(MailHelper.StringToEmailAddress(user.Email), MailHelper.StringToEmailAddress(user.Email)
                            , "Aktivita pripravená na hodnotenie", "Uplynul dátum odovzdania niektorej z aktivít.<br/>", "Uplynul dátum odovzdania niektorej z aktivít.<br/>");
                        var result = await client.SendEmailAsync(msg);

                    }

                }
            }            
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                return;
            }   
        }     



        private async Task<Response> SendEmails(EmailTemplate emailTemplate, int numberOfDays,List<EmailAddress> emailAddresses, User user, DateTime date)
        {
            try
            { 
                EmailClient eClient = new EmailClient();
                SendGridClient client = new SendGridClient(eClient.SetEnvironmentVar(user));
                List<SendGrid.Helpers.Mail.Attachment> attachmentList = new List<SendGrid.Helpers.Mail.Attachment>();
                EmailAttachments emailAttachments = new EmailAttachments();
                EmailBody body = new EmailBody()
                {
                    /// HtmlContent je celkovo obsah emailu, <br/> je nutne pridat kvoli tomu, aby email obsahoval nove riadky. Na konci je priadnie 
                    /// emailoveho podpisu.
                    HtmlContent = emailTemplate.EmailContent.Replace("\u00A0", "<br/>") +"<br/> <br/> " + user.Signature.Replace("\u00A0", "<br/>"),
                    Subject = emailTemplate.EmailSubject,
                    To = emailAddresses
                };

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var attachments = con.GetTable<Attachment>().Where(x => x.IdUser == user.Id && x.IdEmailTemplate == emailTemplate.Id);
                    
                    foreach (var files in  attachments)
                    {
                        /// Zistovanie, ci subor, ktoreho cestu budeme brat z DB vobec existuje
                        if(File.Exists(files.FilePath))
                        {
                            var bytes = File.ReadAllBytes(files.FilePath);
                            var file = Convert.ToBase64String(bytes);
                            // Ziskanie typu suboru, aby mohol byt uploadnuty
                            var type = emailAttachments.GetMIMEType(files.FilePath);

                            /// Pridanie prilohy,
                            SendGrid.Helpers.Mail.Attachment attachment = new SendGrid.Helpers.Mail.Attachment()
                            {
                                Content = file,
                                Filename = (string)files.FileName,
                                Type = type
                            };
                            attachmentList.Add(attachment);
                        } else
                        {
                            continue;
                        }
                    }

                }

                /// Vytvorenie emailu pre viacero prijemcov
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(user.Email), body.To, body.Subject, body.HtmlContent, body.HtmlContent);

                // Dates je premenna, ktora urcuje o kolko dni skor ma byt odoslana sprava
                var dates = date.AddDays(-numberOfDays);
                // Prevod z datumu do Unix sekund ( Sendgrid takto akceptuje parameter SendAt
                var unixDate = new DateTimeOffset(dates.Year, dates.Month, dates.Day, dates.Hour, dates.Minute, dates.Second, TimeSpan.Zero).ToUnixTimeSeconds();
                /// Minus jedna hodina kvoli casovemu posunu Web API
                msg.SetSendAt((int)unixDate - 3600);
                if (attachmentList.Count >= 1)
                {
                    // Pridanie priloh do tela emailu
                    msg.AddAttachments(attachmentList);
                }

                // asynchronne odoslanie poziadavky na web api
                var result = await client.SendEmailAsync(msg);

                attachmentList.Clear();
                emailAddresses.Clear();
                return result;
            }
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

    }
}
