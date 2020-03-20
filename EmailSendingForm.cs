using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AutocompleteMenuNS;


namespace CSAS
{
    public partial class EmailSendingForm : MaterialSkin.Controls.MaterialForm
    {

        User currentUser = new User();
        StudentSkupina currentGroup = new StudentSkupina();
        AutoCompleteStringCollection suggestionList = new AutoCompleteStringCollection();
        List<EmailAddress> emailAddList = new List<EmailAddress>();
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public EmailSendingForm(User user, StudentSkupina skupina)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            currentUser = user;
            currentGroup = skupina;
            StudentDBDataContext con = new StudentDBDataContext(conn_str);


            var students = con.GetTable<Student>();

            var skup = from student in students where student.ID_stud_skupina == currentGroup.Id select new { student.Meno, student.Email, student.Priezvisko, student.Email_UCM };
            var columnWidth = new int[] { 100, 120 };
            autocompleteMenu1.MaximumSize = new System.Drawing.Size(250, 200);
            foreach (var student in skup)
                {
            
                autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { RWS(student.Meno) + " " + RWS(student.Priezvisko), RWS(student.Email) }, RWS(student.Email)) { ColumnWidth = columnWidth });
                autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "", RWS(student.Email_UCM) }, RWS(student.Email_UCM)) { ColumnWidth = columnWidth });
            }
            autocompleteMenu1.Enabled = true;
            autocompleteMenu1.AllowsTabKey = true;
            
        }


        //remove white space in text
       private string RWS(string text)
        {
            text= text.Replace(" ", string.Empty);

            return text;
        }



        private async void OdoslatBtnSendForm_Click(object sender, EventArgs e)
        {
            try
            {
                EmailClient eClient = new EmailClient();
                SendGridClient client = new SendGridClient(eClient.SetEnvironmentVar());
                EmailBody body = new EmailBody()
                {
                    HtmlContent = richTextBox1.Text,
                    PlainTextContent = richTextBox1.Text,
                    Subject = subjectTextBox.Text,
                    To = emailAddList
                };


                if (body.Subject != string.Empty && body.PlainTextContent != string.Empty && emailAddList != null)
                {


                    if (SelectAllBtnPrimaryEmail.Checked == true && SelectAllSecondaryEmail.Checked == false)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            var students = con.GetTable<Student>();
                            var skup = from student in students where student.ID_stud_skupina == currentGroup.Id select new { student.Email, student.Email_UCM };

                            foreach (var mail in skup)
                            {
                                emailAddList.Add(MailHelper.StringToEmailAddress(RWS(mail.Email)));
                            }
                        }
                    }
                    else if (SelectAllBtnPrimaryEmail.Checked == false && SelectAllSecondaryEmail.Checked == true)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            var students = con.GetTable<Student>();
                            var skup = from student in students where student.ID_stud_skupina == currentGroup.Id select new { student.Email, student.Email_UCM };

                            foreach (var mail in skup)
                            {
                                emailAddList.Add(MailHelper.StringToEmailAddress(RWS(mail.Email_UCM)));
                            }
                        }
                    }

                    else
                    {
                        ToTextBox.Text.Replace(" ", string.Empty);
                        var splitted = ToTextBox.Text.Split(',');
                        splitted.ToList();


                        foreach (var mail in splitted)
                        {
                            emailAddList.Add(MailHelper.StringToEmailAddress(mail));
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Niektorá časť nie je vyplnená. Prosím skontrolujte správu, ktorú chcete odoslať a uistite sa subjekt alebo správa nie sú prázdne", "Prázdne polia");
                    return;
                }

                int timestamp = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(currentUser.Email), body.To, body.Subject, body.PlainTextContent, body.HtmlContent);
                /// Nastavenie kedy sa EMAIL odosle
                msg.SetSendAt(timestamp);

                var result = await client.SendEmailAsync(msg);

                if (result.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    MessageBox.Show("Email bol úspešne odoslaný", "Status");
                }
                else
                {
                    MessageBox.Show(result.StatusCode.ToString());
                }


                ToTextBox.Text = "";
                subjectTextBox.Text = "";
                richTextBox1.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                                   

        }

        private void SelectAllSecondaryEmail_CheckedChanged(object sender, EventArgs e)
        {
            ToTextBox.Enabled = false;
        }

        private void SelectAllBtnPrimaryEmail_CheckedChanged(object sender, EventArgs e)
        {
            ToTextBox.Enabled = false;
        }

        private void SelectManually_CheckedChanged(object sender, EventArgs e)
        {
            ToTextBox.Enabled = true;
        }
    }
}
