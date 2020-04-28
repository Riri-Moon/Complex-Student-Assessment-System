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
    public partial class CreateNewGroupForm : MaterialSkin.Controls.MaterialForm
    {
        User currentUser;
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public CreateNewGroupForm(User user)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            FormCombo.Items.Add("Denná");
            FormCombo.Items.Add("Externá");

            FormCombo.SelectedIndex = 0;
            currentUser = user;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(GroupNameBox.Text) && GroupNameBox.Text.Length > 3)
                {
                    using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                    {
                        var existingGroups = con.GetTable<StudentSkupina>().Where(x => x.Nazov == GroupNameBox.Text && x.Id_User==currentUser.Id);
                        if(existingGroups.Count()>0)
                        {
                            MessageBox.Show("Skupina s týmto názvom už existuje, prosím zvoľte iný názov skupiny","Upozornenie",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                        var newGroup = new StudentSkupina()
                        {
                            Id_User = currentUser.Id,
                            Nazov = GroupNameBox.Text,
                            Forma = (string)FormCombo.SelectedItem
                        };

                        con.StudentSkupinas.InsertOnSubmit(newGroup);
                        con.SubmitChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Názov skupiny musí obsahovať viac ako 3 znaky");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
