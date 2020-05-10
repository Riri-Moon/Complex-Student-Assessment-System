using AutocompleteMenuNS;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CSAS
{
    public partial class EmailSendingForm : MaterialSkin.Controls.MaterialForm
    {

        User currentUser = new User();
        StudentSkupina currentGroup = new StudentSkupina();
        AutoCompleteStringCollection suggestionList = new AutoCompleteStringCollection();
        List<EmailAddress> emailAddList = new List<EmailAddress>();
        private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        List<SendGrid.Helpers.Mail.Attachment> attachmentList = new List<SendGrid.Helpers.Mail.Attachment>();

        public EmailSendingForm(User user, StudentSkupina skupina)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
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
            text = text.Replace(" ", string.Empty);

            return text;
        }



        private async void OdoslatBtnSendForm_Click(object sender, EventArgs e)
        {
            try
            {
                Logger logger = new Logger();
                EmailClient eClient = new EmailClient();
                if (string.IsNullOrEmpty(currentUser.ApiKey))
                {
                    MessageBox.Show("ApiKey nemôže byť prázdny.");
                    return;
                }
                SendGridClient client = new SendGridClient(eClient.SetEnvironmentVar(currentUser));
                EmailBody body = new EmailBody()
                {
                    HtmlContent = richTextBox1.Text.Replace("\u00A0", "<br/>") + "<br/> <br/> " + currentUser.Signature.Replace("\u00A0", "<br/>"),
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
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(currentUser.Email), body.To, body.Subject, body.HtmlContent, body.HtmlContent);
                if (attachmentList.Count >= 1)
                {
                    msg.AddAttachments(attachmentList);
                }
                var result = await client.SendEmailAsync(msg);

                if (result.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    logger.LogEmail(DateTime.Now, body.To, body.Subject, body.HtmlContent, attachmentList);
                    attachmentList.Clear();
                    MessageBox.Show("Email bol úspešne prijatý", "Status");
                }
                else
                {
                    MessageBox.Show("Email nebol úspešne odoslaný\n " + "Status emailu: " + result.StatusCode.ToString(), "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                ToTextBox.Text = "";
                subjectTextBox.Text = "";
                richTextBox1.Text = "";
                AttachmentsGrid.DataSource = null;
                emailAddList.Clear();

            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
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

        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                EmailAttachments emailAttachments = new EmailAttachments();
                var attach = emailAttachments.BrowseForFile();
                var notAddedList = new List<string>();
                if (attach != (null, null))
                {
                    foreach (var files in attach.Item1.Zip(attach.Item2, (paths, names) => (paths, names)))
                    {
                        var bytes = File.ReadAllBytes(files.paths);
                        var file = Convert.ToBase64String(bytes);
                        var type = emailAttachments.GetMIMEType(files.paths);
                        if (type == null)
                        {
                            notAddedList.Add(files.names);
                            continue;
                        }
                        SendGrid.Helpers.Mail.Attachment attachment = new SendGrid.Helpers.Mail.Attachment()
                        {
                            Content = file,
                            Filename = files.names,
                            Type = type
                        };
                        attachmentList.Add(attachment);
                    }
                    if (attachmentList.Count >= 1)
                    {
                        AttachmentsGrid.DataSource = null;
                        AttachmentsGrid.DataSource = attachmentList;
                        AttachmentsGrid.Columns["Content"].Visible = false;
                        AttachmentsGrid.Columns["Type"].Visible = false;
                        AttachmentsGrid.Columns["ContentId"].Visible = false;
                        AttachmentsGrid.Columns["Disposition"].Visible = false;
                    }
                    if (notAddedList.Count >= 1)
                    {
                        string list = null;

                        foreach (var x in notAddedList)
                        {
                            list += x + " ";
                        }
                        var msg = $"Súbor/y {list} nebol pridaný, lebo tento typ súboru nie je možné odoslať emailom. Pre informácie o tom, ktoré " +
                        "súbory nie je možné odoslať otvorte BlockedExtensions.txt";
                        MessageBox.Show(msg);
                    }
                    AttachmentsGrid.ClearSelection();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AttachmentsGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void AttachmentsGrid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && attachmentList.Count >= 1)
                {
                    var currentAttachment = (string)AttachmentsGrid.CurrentCell.Value;
                    var attachment = attachmentList.Where(x => x.Filename == currentAttachment).FirstOrDefault();
                    attachmentList.Remove(attachment);

                    if (attachmentList.Count >= 1)
                    {
                        AttachmentsGrid.DataSource = attachmentList;
                    }
                    else
                    {
                        AttachmentsGrid.DataSource = null;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        //Insert non printable character in order to replace it later with <br/>
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.AppendText("\u00A0");
            }
        }

    }
}

