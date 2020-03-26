using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAS
{
    public partial class EmailTemplateForm : MaterialSkin.Controls.MaterialForm
    {
        User currentUser;
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public EmailTemplateForm(User user)
        {

            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
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

                    TempGridView.MultiSelect = false;
                    TempGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    TempGridView.RowHeadersVisible = false;
                    TempGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void EmailTemplateForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateEmailTempBtn_Click(object sender, EventArgs e)
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

                    con.SubmitChanges();

                }


                
                GetEmailTemps(currentUser);
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        /// <summary>
        /// Load email template       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
               
                    var loadTemplate = con.GetTable<EmailTemplate>().Where(x => x.IdUser == currentUser.Id && x.Id == (int)TempGridView.CurrentRow.Cells[2].Value);

                    foreach (var mail in loadTemplate)
                    {
                    ContentTextBox.Text = string.Empty;
                    SubjectTextbox.Text = string.Empty;
                    NameOfTempTextBox.Text = string.Empty;
                    NameOfTempTextBox.Text = mail.EmailTemplateName;
                    ContentTextBox.Text = mail.EmailContent;
                    SubjectTextbox.Text = mail.EmailSubject;
                    }

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            NameOfTempTextBox.Text = null;
            SubjectTextbox.Text = null;
            ContentTextBox.Text = null;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
