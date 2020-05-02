using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;

namespace CSAS
{
    public partial class RegistrationForm : MaterialSkin.Controls.MaterialForm
    {
        private string conn_str = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentDatabase.mdf;Integrated Security=True";

        public RegistrationForm()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
        }
        
        private bool BoxValidation()
        {
            int upperCount = 0;
            if(NameBox.Text.Length<8 || NameBox.Text.Length >15)
            {
                MessageBox.Show("Meno nemôže mať menej než 8 znakov a viac ako 15");
                return false;
            }
            string name = NameBox.Text;
            foreach(var c in name)
            {
                if(char.IsUpper(c))
                {
                    upperCount++;
                }
            }            
            if(upperCount<=0)
            {
                MessageBox.Show("Meno musí obsahovať aspoň jedno veľké písmeno");
                return false;
            }

            if (!ContainsSpecialCharacters(this.EmailBox.Text, 7, 55))
            {
                MessageBox.Show("Uistite sa, že email obsahuje @ a dĺžka nepresiahla 55 znakov.", "Chyba");
                EmailBox.SelectAll();
                EmailBox.Focus();
                return false;
            }

            if(FirstPssBox.Text.Length<8 || FirstPssBox.Text.Length >30)
            {
                MessageBox.Show("Heslo musí obsahovať minimálne 8 znakov a maximálne 30 znakov");
                return false;
            }

            string pss = FirstPssBox.Text;
            int numCount = 0;
            int uppCount = 0;
            foreach(var x in pss)
            {
                if(char.IsUpper(x))
                {
                    uppCount++;
                }
                if(char.IsNumber(x))
                {
                    numCount++;
                }
            }

            if(numCount <=0 || uppCount <=0)
            {
                MessageBox.Show("Heslo musí obsahovať aspoň jedno veľké písmeno a jedno číslo");
                return false;
            }
            string secPss = SecondPssBox.Text;
            if(pss != secPss)
            {
                MessageBox.Show("Heslá sa nezhodujú");
                return false;
            }
            return true;
        }

        private bool ContainsSpecialCharacters(string inputString, int minLen, int maxLen)
        {
            if (inputString.Length < minLen || inputString.Length > maxLen) return false;
            if (!inputString.Contains("@") || !inputString.Contains(".")) return false;
            return true;
        }

        private bool Validation()
        {
            try
            {
                if(!BoxValidation())
                {
                    return false;
                }

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    
                    var exists = con.GetTable<User>().Where(x => x.Email == EmailBox.Text || x.Meno == NameBox.Text).Count();

                    if(exists>0)
                    {
                        MessageBox.Show("Používateľ s týmto menom alebo emailom už existuje");
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
                Logger logger = new Logger();
                logger.LogError(ex);
                MessageBox.Show("Počas registrácie nastala chyba","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CreateUser()
        {
            try
            {
                if (Validation())
                {
                    using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                    {
                        User user = new User();
                        user.Meno = NameBox.Text;
                        user.Email = EmailBox.Text;
                        user.Heslo = SHA512(FirstPssBox.Text);

                        con.Users.InsertOnSubmit(user);
                        con.SubmitChanges();

                        MessageBox.Show("Registrácia bola úspešná");
                        return true;
                    }
                }
                else return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
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
        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CreateUser())
                {

                    this.Hide();
                    return;
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
