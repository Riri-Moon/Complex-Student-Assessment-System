﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CSAS
{
    public partial class EmailTemplateForm : MaterialSkin.Controls.MaterialForm
    {
        User currentUser;
        private readonly string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        List<Attachment> attachmentList = new List<Attachment>();
        bool editMode = false;
        public EmailTemplateForm(User user)
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            InitializeComponent();
            currentUser = user;
            GetEmailTemps(user);
        }

        private void GetEmailTemps(User user)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var allTemps = con.GetTable<EmailTemplate>();
                    var userTemps = from temp in allTemps where temp.IdUser == currentUser.Id select new { temp.EmailTemplateName, temp.EmailContent, temp.Id, temp.EmailSubject };

                    TempGridView.DataSource = userTemps;
                    TempGridView.Columns["EmailContent"].Visible = false;
                    TempGridView.Columns["Id"].Visible = false;
                    TempGridView.Columns["EmailSubject"].Visible = false;
                    TempGridView.Columns["EmailTemplateName"].HeaderText = "Názov emailovej šablóny";
                    TempGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    TempGridView.MultiSelect = false;
                    TempGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    TempGridView.RowHeadersVisible = false;
                    TempGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateEmailTempBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var exists = con.GetTable<EmailTemplate>().Where(x => x.EmailTemplateName == NameOfTempTextBox.Text && x.IdUser == currentUser.Id);

                    if (exists.Count().Equals(0))
                    {
                        if (!string.IsNullOrEmpty(SubjectTextbox.Text) && !string.IsNullOrEmpty(ContentTextBox.Text) && !string.IsNullOrEmpty(NameOfTempTextBox.Text))
                        {
                            var newTemp = new EmailTemplate()
                            {
                                EmailTemplateName = NameOfTempTextBox.Text,
                                EmailSubject = SubjectTextbox.Text,
                                EmailContent = ContentTextBox.Text,
                                IdUser = currentUser.Id
                            };

                            con.EmailTemplates.InsertOnSubmit(newTemp);
                            con.SubmitChanges();
                            SaveAttachmentsToDB(newTemp);
                        }
                        else
                        {
                            MessageBox.Show("Subjekt alebo správa nie sú vyplnené, pred uložením je potrebné vyplniť tieto polia", "Prázdne polia");
                            return;
                        }

                    }
                    else
                    {
                        var exisEmail = con.EmailTemplates.Where(x => x.IdUser == currentUser.Id && x.Id == (int)TempGridView.CurrentRow.Cells[2].Value);
                        exisEmail.FirstOrDefault().EmailSubject = SubjectTextbox.Text;
                        exisEmail.FirstOrDefault().EmailContent = ContentTextBox.Text;
                        SaveAttachmentsToDB(exisEmail.FirstOrDefault());

                        con.SubmitChanges();
                    }
                    GetEmailTemps(currentUser);
                    AttachmentsGrid.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }

        /// <summary>
        /// Load email template       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (TempGridView.Rows.Count <= 0)
                    {
                        MessageBox.Show("Nie je vytvorená žiadna emailová šablóna");
                        return;
                    }
                    var loadTemplate = con.GetTable<EmailTemplate>().Where(x => x.IdUser == currentUser.Id && x.Id == (int)TempGridView.CurrentRow.Cells[2].Value);

                    foreach (var mail in loadTemplate)
                    {
                        AttachmentsGrid.DataSource = null;

                        ContentTextBox.Text = string.Empty;
                        SubjectTextbox.Text = string.Empty;
                        NameOfTempTextBox.Text = string.Empty;
                        NameOfTempTextBox.Text = mail.EmailTemplateName;
                        ContentTextBox.Text = mail.EmailContent;
                        SubjectTextbox.Text = mail.EmailSubject;
                        AttachmentsGrid.DataSource = mail.Attachments;
                    }

                    AttachmentsGrid.Columns["FilePath"].Visible = false;
                    AttachmentsGrid.Columns["IdUSer"].Visible = false;
                    AttachmentsGrid.Columns["IdEmailTemplate"].Visible = false;
                    AttachmentsGrid.Columns["Id"].Visible = false;
                    AttachmentsGrid.Columns["EmailTemplate"].Visible = false;
                    AttachmentsGrid.Columns["User"].Visible = false;

                    AttachmentsGrid.ClearSelection();
                    editMode = true;
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }
        /// <summary>
        /// Delete email template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    DialogResult response = MessageBox.Show("Naozaj chcete odstrániť šablónu ?", "Upozornenie", MessageBoxButtons.YesNo);
                    if (response == DialogResult.Yes)
                    {
                        con.Attachments.DeleteAllOnSubmit(con.GetTable<Attachment>().Where(x => x.IdEmailTemplate == (int)TempGridView.CurrentRow.Cells[2].Value));

                        con.EmailTemplates.DeleteOnSubmit(con.GetTable<EmailTemplate>().
                            Where(x => x.IdUser == currentUser.Id && x.Id == (int)TempGridView.CurrentRow.Cells[2].Value).FirstOrDefault());
                        con.SubmitChanges();
                    }
                    else
                    {
                        return;
                    }
                }
                GetEmailTemps(currentUser);
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return;
            }
        }



        public void SaveAttachmentsToDB(EmailTemplate template)
        {
            try
            {
                if (attachmentList != null)
                {
                    using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                    {
                        if (editMode)
                        {
                            foreach (DataGridViewRow x in AttachmentsGrid.Rows)
                            {
                                var attachment = con.GetTable<Attachment>().Where(id => id.Id == (int)x.Cells[0].Value).FirstOrDefault();
                                Attachment atta = new Attachment()
                                {
                                    FileName = attachment.FileName,
                                    FilePath = attachment.FilePath,
                                    IdEmailTemplate = template.Id,
                                    IdUser = currentUser.Id
                                };
                                if (!AttachmentExists(atta, template))
                                    con.Attachments.InsertOnSubmit(atta);
                            }
                        }
                        else
                        {
                            foreach (var path in attachmentList)
                            {
                                Attachment attachment = new Attachment()
                                {
                                    IdEmailTemplate = template.Id,
                                    IdUser = currentUser.Id,
                                    FileName = path.FileName,
                                    FilePath = path.FilePath,
                                };

                                if (!AttachmentExists(attachment, template))
                                {
                                    con.Attachments.InsertOnSubmit(attachment);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        con.SubmitChanges();

                        AttachmentsGrid.DataSource = con.GetTable<Attachment>().Where(x => x.IdEmailTemplate == template.Id && x.IdUser == currentUser.Id);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            NameOfTempTextBox.Text = null;
            SubjectTextbox.Text = null;
            ContentTextBox.Text = null;
            AttachmentsGrid.DataSource = null;
            attachmentList.Clear();
            editMode = false;
        }

        //private void materialFlatButton1_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void AddEmailTemplateAttachmentsBtn_Click(object sender, EventArgs e)
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
                        var type = emailAttachments.GetMIMEType(files.paths);
                        if (type == null)
                        {
                            notAddedList.Add(files.names);
                            continue;
                        }

                        Attachment attachment = new Attachment()
                        {
                            FilePath = files.paths,
                            FileName = files.names,
                            IdUser = currentUser.Id,
                        };

                        if (editMode)
                        {
                            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                            {
                                var att = attachment;
                                att.IdEmailTemplate = (int)TempGridView.CurrentRow.Cells[2].Value;
                                var emailTemp = con.GetTable<EmailTemplate>().First(x => x.Id == (int)TempGridView.CurrentRow.Cells[2].Value);
                                if (!AttachmentExists(att, emailTemp))
                                {
                                    con.Attachments.InsertOnSubmit(att);
                                    con.SubmitChanges();

                                    AttachmentsGrid.DataSource = null;
                                    AttachmentsGrid.DataSource = con.GetTable<Attachment>().Where(x => x.IdEmailTemplate == (int)TempGridView.CurrentRow.Cells[2].Value);
                                    AttachmentsGrid.Columns["FilePath"].Visible = false;
                                    AttachmentsGrid.Columns["IdUSer"].Visible = false;
                                    AttachmentsGrid.Columns["IdEmailTemplate"].Visible = false;
                                    AttachmentsGrid.Columns["Id"].Visible = false;
                                    AttachmentsGrid.Columns["EmailTemplate"].Visible = false;
                                    AttachmentsGrid.Columns["User"].Visible = false;

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
                                }
                                return;
                            }
                        }
                        else if (!attachmentList.Contains(attachment))
                        {
                            attachmentList.Add(attachment);
                        }
                    }
                    if (attachmentList.Count >= 1)
                    {
                        AttachmentsGrid.DataSource = null;
                        AttachmentsGrid.DataSource = attachmentList;
                        AttachmentsGrid.Columns["FilePath"].Visible = false;
                        AttachmentsGrid.Columns["IdUSer"].Visible = false;
                        AttachmentsGrid.Columns["IdEmailTemplate"].Visible = false;
                        AttachmentsGrid.Columns["Id"].Visible = false;
                        AttachmentsGrid.Columns["EmailTemplate"].Visible = false;
                        AttachmentsGrid.Columns["User"].Visible = false;

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
                }
                else
                {
                    return;
                }
                AttachmentsGrid.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private bool AttachmentExists(Attachment attachment, EmailTemplate template)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var exists = con.GetTable<Attachment>().Where(x => x.IdEmailTemplate == template.Id && x.FileName == attachment.FileName);

                    if (exists.Count() <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return true;
            }
        }

        private void AttachmentsGrid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        var currentAttachment = (int)AttachmentsGrid.CurrentRow.Cells[0].Value;
                        var allAttachments = con.GetTable<Attachment>().Where(x => x.IdUser == currentUser.Id && x.Id == currentAttachment);
                        if (allAttachments.Count() >= 1)
                        {
                            con.Attachments.DeleteOnSubmit(allAttachments.FirstOrDefault());
                            con.SubmitChanges();
                            RefreshAtt();
                        }
                        else
                        {
                            var attachment = attachmentList.Where(x => x.Id == currentAttachment).FirstOrDefault();
                            attachmentList.Remove(attachment);

                            if (attachmentList.Count >= 1)
                            {
                                AttachmentsGrid.DataSource = null;
                                AttachmentsGrid.DataSource = attachmentList;
                                AttachmentsGrid.Columns["FilePath"].Visible = false;
                                AttachmentsGrid.Columns["IdUSer"].Visible = false;
                                AttachmentsGrid.Columns["IdEmailTemplate"].Visible = false;
                                AttachmentsGrid.Columns["Id"].Visible = false;
                                AttachmentsGrid.Columns["EmailTemplate"].Visible = false;
                                AttachmentsGrid.Columns["User"].Visible = false;
                            }
                            else
                            {
                                AttachmentsGrid.DataSource = null;
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                    AttachmentsGrid.ClearSelection();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pre odstránenie prílohy musíte kliknúť na prílohu, ktorá má byť odstránená", "Nie je vybratá príloha");
            }
        }

        private void RefreshAtt()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var loadTemplate = con.GetTable<EmailTemplate>().Where(x => x.IdUser == currentUser.Id && x.Id == (int)TempGridView.CurrentRow.Cells[2].Value);

                    foreach (var mail in loadTemplate)
                    {
                        AttachmentsGrid.DataSource = null;
                        AttachmentsGrid.DataSource = mail.Attachments;
                    }

                    AttachmentsGrid.Columns["FilePath"].Visible = false;
                    AttachmentsGrid.Columns["IdUSer"].Visible = false;
                    AttachmentsGrid.Columns["IdEmailTemplate"].Visible = false;
                    AttachmentsGrid.Columns["Id"].Visible = false;
                    AttachmentsGrid.Columns["EmailTemplate"].Visible = false;
                    AttachmentsGrid.Columns["User"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenAttachmentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (AttachmentsGrid.Rows.Count <= 0)
                    {
                        MessageBox.Show("Nie je pridaná žiadna príloha");
                        return;
                    }
                    if (AttachmentsGrid.SelectedRows.Count == 1)
                    {
                        var currentAttachment = (int)AttachmentsGrid.CurrentRow.Cells[0].Value;

                        var attachment = con.GetTable<Attachment>().Where(x => x.Id == currentAttachment);
                        if (attachment.Count() <= 0)
                        {
                            if (File.Exists((string)AttachmentsGrid.CurrentRow.Cells[1].Value))
                            {
                                System.Diagnostics.Process.Start((string)AttachmentsGrid.CurrentRow.Cells[1].Value);
                            }
                            return;
                        }
                        if (File.Exists(attachment.First().FilePath))
                        {
                            System.Diagnostics.Process.Start(attachment.First().FilePath);
                        }
                        else
                        {
                            MessageBox.Show($"Nie je možné nájsť súbor. Prosím skontrolujte, či súbor {attachment.First().FilePath} existuje.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Je nutné najprv vybrať prílohu");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Uistite sa,že súbor nie je používaný žiadnou aplikáciou");
            }
        }
    }
}
