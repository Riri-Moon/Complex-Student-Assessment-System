using System;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections;
using System.Linq;
using System.Threading;

namespace CSAS
{
    public partial class Choose_Group : MaterialSkin.Controls.MaterialForm
    {

        public StudentSkupina Selected { get; set; }
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public User loggedUser = new User();
      
        public Choose_Group()
        {
            InitializeComponent();

            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            DataContext con = new DataContext(conn_str);
            con.Connection.Open();

            Skupiny_Grid.RowHeadersVisible = false;
            Skupiny_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Skupiny_Grid.MultiSelect = false;
            Skupiny_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //// CHANGE TO GET ACTUAL USER
            Skupiny_Grid.DataSource = con.GetTable<StudentSkupina>()?.Where(x => x.Id_User == 1);
            Skupiny_Grid.Columns["ID"].Visible = false;
            Skupiny_Grid.Columns["Id_User"].Visible = false;
            Skupiny_Grid.Columns["User"].Visible = false;
            ////// THIS ONE TOO
            loggedUser = con.GetTable<User>().Where(x => x.Id == 1).FirstOrDefault();
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void Remove_button_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Are you sure you want to remove study group ?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }


        private void Started()
        {
            Selected = (StudentSkupina)Skupiny_Grid.CurrentRow.DataBoundItem;
            this.Hide();

            Main_Window main_ = new Main_Window(Selected, loggedUser);
            main_.Closed += (s, args) => this.Close();

            main_.Show();
        }


        private void Choose_Group_Load(object sender, EventArgs e)
        {

        }

        private void Select_Button_Click_1(object sender, EventArgs e)
        {
            Started();
        }


        private void Remove_Button_Click_1(object sender, EventArgs e)
        {

        }

        private void Exit_Button_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
