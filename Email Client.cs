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
    public partial class Email_Client : MaterialSkin.Controls.MaterialForm
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        User activeUser = new User();
        public Email_Client(User currentUser)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            activeUser = currentUser;
        }

        private void cancel_email_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_email_Click(object sender, EventArgs e)
        {
            EmailSettings emailSettings = new EmailSettings()
            {
                ApiKey = textBox1.Text,
                EmailAddress = textBox2.Text

            };


            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            User user = con.Users.FirstOrDefault(x => x.Id == activeUser.Id);
            if(string.IsNullOrEmpty(textBox1.Text))
            {

                user.ApiKey = user.ApiKey;

            }
            else
            {
                user.ApiKey = textBox1.Text;

            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                user.Email = textBox2.Text;
            }
            else
            {
                user.Email = user.Email;


            }
            con.SubmitChanges();

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Exit_email_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void CreateEmailTemplateContext_Click(object sender, EventArgs e)
        {
        }
    }
}
