using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAS
{
    class Logger
    {
        public void LogEmail(DateTime dateTime, List<EmailAddress> To, string Subject, string Message, List<SendGrid.Helpers.Mail.Attachment> attachments)
        {
           var dirName = Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\EmailLogs"));
            DeleteOlderFiles(dirName.FullName);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\EmailLogs\" +dateTime.Date.ToShortDateString().Replace("/","_")+"_EmailLogs.txt");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Dátum: " + dateTime.ToString());
                sw.WriteLine("Komu: ");
                if (To.Count > 0)
                {
                    foreach (var to in To)
                    {
                        sw.WriteLine(to.Email + ", ");
                    }
                    sw.WriteLine("Subjekt: " + Subject);
                    sw.WriteLine("Správa: " + Message.Replace("<br/>", ""));
                    sw.WriteLine("Prílohy: ");
                    if (attachments != null)
                    {
                        foreach (var attachment in attachments)
                        {
                            sw.WriteLine(attachment.Filename);
                        }
                        sw.WriteLine(Environment.NewLine);
                    }
                }
            }
        }


        public void LogError(Exception ex)
        {
            var dirName = Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\ErrorLogs"));
            DeleteOlderFiles(dirName.FullName);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\ErrorLogs\" + DateTime.Now.Date.ToShortDateString().Replace("/", "_") + "_ErrorLogs.txt");
            using (StreamWriter sw = File.AppendText(path))
            {
                var frame = new StackTrace(ex, true);
                sw.WriteLine("Správa: " + ex.Message);
                sw.WriteLine("Data: " + ex.Data);
                sw.WriteLine("Zdroj: " + ex.Source);
                sw.WriteLine("Metóda: " + ex.TargetSite);
                sw.WriteLine("Riadok: " + frame.GetFrame(0).GetFileLineNumber());
                sw.WriteLine("StackTrace: " + ex.StackTrace);
                sw.WriteLine(sw.NewLine);
            }
        }

        private void DeleteOlderFiles(string dirName)
        {
            string[] files = Directory.GetFiles(dirName);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddMonths(-1))
                    fi.Delete();
            }
        }

    }
}
