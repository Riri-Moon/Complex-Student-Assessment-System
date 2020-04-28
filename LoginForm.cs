using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAS
{
    public partial class LoginForm : MaterialSkin.Controls.MaterialForm
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public LoginForm()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgottenPass = new ForgetPasswordForm();
            forgottenPass.ShowDialog();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var registerForm = new RegistrationForm();
            registerForm.ShowDialog();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Naozaj chcete ukončiť aplikáciu ?","Ukončiť aplikáciu",MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public User LoggedUser { get; set; }
        private User Login()
        {
            var userDict = new Dictionary<string, int?>();
            if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrEmpty(FirstPssBox.Text) || string.IsNullOrWhiteSpace(FirstPssBox.Text))  
            {
                MessageBox.Show("Meno ani heslo nemôžu byť prázdne");
                return null;
            }
            else
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    IQueryable<User> user = con.GetTable<User>().Where(x => x.Meno == NameBox.Text);
                    foreach(var us in user)
                    {
                        userDict.Add(us.Meno, us.Id);
                    }
                    var userId = userDict.Where(x => x.Key.Equals(NameBox.Text, StringComparison.CurrentCulture)).Select(x=>x.Value).FirstOrDefault();
                    if (userId == null)
                    {
                        MessageBox.Show("Nesprávne meno alebo heslo");
                        return null;
                    }
                    else
                    {
                        User currUser = con.GetTable<User>().SingleOrDefault(x => x.Id==userId.Value);

                        var pss = SHA512(FirstPssBox.Text);

                        if (currUser.Heslo.Length == pss.Length)
                        {

                            for (int i = 0; i < currUser.Heslo.Length; i++)
                            {
                                if (currUser.Heslo[i] != pss[i])
                                {
                                    MessageBox.Show("Nesprávne heslo");
                                    FirstPssBox.Text = string.Empty;
                                    return null;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nesprávne heslo");
                            FirstPssBox.Text = string.Empty;
                            return null;
                        }
                        return currUser;
                    }
                }
            }
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
              var user = Login();

            if (user == null)
            {
                return;
            }
            else
            {
                this.Hide();

                var group = new Choose_Group(user);
               // group.FormClosed += (s, args) =>Environment.Exit(1);
                group.Show();
                user = null;
                FirstPssBox.Text = string.Empty;
                LoggedUser = null;
            }
        }
        public static string SHA512(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
