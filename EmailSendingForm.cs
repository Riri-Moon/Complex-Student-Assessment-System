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
            var groups = con.GetTable<StudentSkupina>().Where(x => x.Id == skupina.Id);
            var skup = from student in students where student.ID_stud_skupina == currentGroup.Id select new { student.Meno, student.Email, student.Priezvisko, student.Email_UCM };
            var columnWidth = new int[] { 100, 120 };
            autocompleteMenu1.MaximumSize = new System.Drawing.Size(250, 200);
            foreach (var student in skup)
                {
            
                autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { RWS(student.Meno) + " " + RWS(student.Priezvisko), RWS(student.Email) }, RWS(student.Email)) { ColumnWidth = columnWidth });
                autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "", RWS(student.Email_UCM) }, RWS(student.Email_UCM)) { ColumnWidth = columnWidth });                
            }

            var kruzok = from stud in students where stud.ID_stud_skupina == skupina.Id select (string)stud.ID_Kruzok;
            kruzok.ToList<string>();

            foreach (var kruz in kruzok.Distinct())
            {

                GroupComboEmail.Items.Add(kruz);
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
                    if (SelectAllBtnPrimaryEmail.Checked == true && SelectAllSecondaryEmail.Checked == false && GroupCheckBtn.Checked == false)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            emailAddList.Clear();
                            var students = con.GetTable<Student>();
                            var skup = from student in students where student.ID_stud_skupina == currentGroup.Id select student.Email;

                            foreach (var mail in skup)
                            {
                                emailAddList.Add(MailHelper.StringToEmailAddress(RWS(mail)));
                            }
                        }
                    }
                    else if (SelectAllBtnPrimaryEmail.Checked == false && SelectAllSecondaryEmail.Checked == true && GroupCheckBtn.Checked == false)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            emailAddList.Clear();
                            var students = con.GetTable<Student>();
                            var skup = from student in students where student.ID_stud_skupina == currentGroup.Id select student.Email_UCM;

                            foreach (var mail in skup)
                            {
                                emailAddList.Add(MailHelper.StringToEmailAddress(RWS(mail)));
                            }
                        }
                    }
                    else if (SelectAllBtnPrimaryEmail.Checked == false && SelectAllSecondaryEmail.Checked == false && GroupCheckBtn.Checked == true)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            emailAddList.Clear();
                            var students = con.GetTable<Student>();
                            var skup = from student in students
                                       where student.ID_stud_skupina == currentGroup.Id && student.ID_Kruzok == GroupComboEmail.Text
                                       select student.Email;

                            foreach (var mail in skup)
                            {/// Nastavene na osobny email
                                emailAddList.Add(MailHelper.StringToEmailAddress(RWS(mail)));
                            }
                        }
                    }
                    else
                    {
                        emailAddList.Clear();
                        ToTextBox.Text.Replace(" ", string.Empty);
                        var splitted = ToTextBox.Text.Split(',');
                        splitted.ToList();


                        foreach (var mail in splitted)
                        {
                            emailAddList.Add(MailHelper.StringToEmailAddress(RWS(mail)));
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
            GroupComboEmail.Enabled = false;

        }

        private void SelectAllBtnPrimaryEmail_CheckedChanged(object sender, EventArgs e)
        {
            ToTextBox.Enabled = false;
            GroupComboEmail.Enabled = false;

        }

        private void SelectManually_CheckedChanged(object sender, EventArgs e)
        {
            ToTextBox.Enabled = true;
            GroupComboEmail.Enabled = false;

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
        }
 
        private void GroupCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            GroupComboEmail.Enabled = true;
            ToTextBox.Enabled = false;

        }
    }
}
