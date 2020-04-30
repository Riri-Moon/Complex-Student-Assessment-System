using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAS
{
    public partial class ForgetPasswordForm : MaterialSkin.Controls.MaterialForm
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ForgetPasswordForm()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("Meno nemôže byť prázdne", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private User ValidateEmail()
        {
            if(!ValidateName())
            {
                return null;
            }
            if (string.IsNullOrEmpty(EmailBox.Text) || string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                MessageBox.Show("Email nemôže byť prázdny", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            else
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var userDict = new Dictionary<string, int?>();

                    IQueryable<User> user = con.GetTable<User>().Where(x => x.Meno == NameBox.Text && x.Email==EmailBox.Text);
                    // SQL nie je CaseSensitive tak musíme iným spôsobom validovať správnosť údajov
                    foreach (var us in user)
                    {
                        userDict.Add(us.Meno, us.Id);
                    }
                    var userId = userDict.Where(x => x.Key.Equals(NameBox.Text, StringComparison.CurrentCulture)).Select(x => x.Value).FirstOrDefault();
                    if (userId == null)
                    {
                        MessageBox.Show("Nesprávne meno alebo email");
                        return null;
                    }
                    else
                    {
                        return con.GetTable<User>().FirstOrDefault(x => x.Id == userId);
                    }
                }
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
                //Do Hexadecimal
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }


        private User UserValidation()
        {
            var userDict = new Dictionary<string, int?>();
            if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrEmpty(OldPssBox.Text) || string.IsNullOrWhiteSpace(OldPssBox.Text))
            {
                MessageBox.Show("Meno ani heslo nemôžu byť prázdne");
                return null;
            }
            else
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    IQueryable<User> user = con.GetTable<User>().Where(x => x.Meno == NameBox.Text);
                    // SQL nie je CaseSensitive tak musíme iným spôsobom validovať správnosť údajov
                    foreach (var us in user)
                    {
                        userDict.Add(us.Meno, us.Id);
                    }
                    var userId = userDict.Where(x => x.Key.Equals(NameBox.Text, StringComparison.CurrentCulture)).Select(x => x.Value).FirstOrDefault();
                    if (userId == null)
                    {
                        MessageBox.Show("Nesprávne meno alebo heslo");
                        return null;
                    }
                    else
                    {
                        User currUser = con.GetTable<User>().SingleOrDefault(x => x.Id == userId.Value);

                        var pss = SHA512(OldPssBox.Text);

                        //Porovnávanie hashu z databázy s hashom od používateľa
                        if (currUser.Heslo.Length == pss.Length)
                        {

                            for (int i = 0; i < currUser.Heslo.Length; i++)
                            {
                                if (currUser.Heslo[i] != pss[i])
                                {
                                    MessageBox.Show("Nesprávne heslo");
                                    OldPssBox.Text = string.Empty;
                                    return null;
                                }
                            }

                            return currUser;
                        }
                        else
                        {
                            MessageBox.Show("Nesprávne heslo");
                            OldPssBox.Text = string.Empty;
                            return null;
                        }
                    }
                }
            }
        }
      
        private void ChangePassword(User user,string NewPassword)
        {
            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var ChangePssUser = con.Users.FirstOrDefault(x => x.Id == user.Id);
                ChangePssUser.Heslo = SHA512(NewPassword);
                con.SubmitChanges();

                FirstPssBox.Text = string.Empty;
                SecondPssBox.Text = string.Empty;
                OldPssBox.Text = string.Empty;
                NameBox.Text = string.Empty;
                EmailBox.Text = string.Empty;
            }
        }
        
        private void ChangePssBtn_Click(object sender, EventArgs e)
        {
            var user = UserValidation();

            if(user==null)
            {
                return;
            }
             else if (FirstPssBox.Text != SecondPssBox.Text)
            {
                MessageBox.Show("Heslá sa nezhodujú");
                OldPssBox.Text = string.Empty;
            }
            else
            {
                ChangePassword(user,FirstPssBox.Text);
                MessageBox.Show("Heslo úspešne zmenené");
            }

        }


        string EncryptString(string key, string plainInput)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainInput);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private async void SendNewPassBtn_Click(object sender, EventArgs e)
        {
            var user = ValidateEmail();
            if (user != null)
            {
                var eClient = new EmailClient();
                string AKey = DecryptString(ConfigurationManager.AppSettings["Key"], ConfigurationManager.AppSettings["Api"]);
                eClient.SetEnvironmentVar(AKey);
                SendGridClient client = new SendGridClient(AKey);

                GeneratePassword generatePassword = new GeneratePassword();
                var newPassword = generatePassword.GeneratedPassword;
                ChangePassword(user,newPassword);

                string From = "HelperCSAS@ucm.sk";
                string Message = $"Bola vyžiadaná zmena hesla. <br/> Vaše nové heslo je {newPassword} <br/> Odporúčame toto heslo zmeniť hneď ako to bude možné";
                string To = user.Email;
                string Subject = "Zmena hesla";


                var msg = MailHelper.CreateSingleEmail(MailHelper.StringToEmailAddress(From), MailHelper.StringToEmailAddress(To), Subject, Message, Message);
                var result = await client.SendEmailAsync(msg);

                MessageBox.Show("Nové heslo Vám bolo odoslané na email, ak Vám heslo neprišlo, prosím skontrolujte si SPAM alebo AUTOMATICKÉ","Nové heslo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else return;
        }
    }


}
