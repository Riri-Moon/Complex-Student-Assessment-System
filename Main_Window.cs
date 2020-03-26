using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace CSAS
{
    public partial class Main_Window : MaterialSkin.Controls.MaterialForm
    {

        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected bool isCollapsed_4 = true;
        protected bool isCollapsed_3 = true;
        protected bool isCollapsed_2 = true;
        protected bool isCollapsed = true;
        public StudentSkupina studentSkupina = new StudentSkupina();
        protected static User currentUser = new User();



        public Main_Window(StudentSkupina skupina, User user)
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            try
            {
                InitializeComponent();
                currentUser = user;
                studentSkupina = skupina;
                //SendEmailCheck emailCheck = new SendEmailCheck();
                /// emailCheck.AutomatedEmailSending(currentUser);

                //var aTimer = new System.Timers.Timer(60 * 60 * 1000); 
                // aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                //aTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                SendEmailCheck emailCheck = new SendEmailCheck();
                emailCheck.AutomatedEmailSending(currentUser);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void GetTable()
        {
            try
            {

                using (DataContext con = new DataContext(conn_str))
                {


                    con.Connection.Open();
                    Student_Grid.RowHeadersVisible = false;
                    Student_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Student_Grid.MultiSelect = false;
                    Student_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Student_Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    Student_Grid.DataSource = con.GetTable<Student>()?.Where(studs => studs.ID_stud_skupina == studentSkupina.Id && studs.Forma == studentSkupina.Forma).OrderBy(x => x.ID_Kruzok);
                    Student_Grid.Columns["ID"].Visible = false;
                    Student_Grid.Columns["Id_Stud_skupina"].Visible = false;
                    Student_Grid.Columns["Stud_Program"].Visible = false;


                }
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GetActivities()
        {

            try
            {

                using (DataContext con = new DataContext(conn_str))
                {

                    var selectedStudent = (int)Student_Grid.CurrentRow.Cells[0].Value;
                    var acts = con.GetTable<Activity>().Where(x => x.IdUser == currentUser.Id );

                    var dataSource = from studAct in acts where studAct.IdStudent == selectedStudent select new { studAct.ActivityName, studAct.MaxPoints, studAct.Hodnotenie, studAct.Id };
                    Activity_Grid.RowHeadersVisible = false;
                    Activity_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


                    Activity_Grid.DataSource = dataSource;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    





        private void Import_Btn_Click(object sender, EventArgs e)
        {
            Import_Cl import = new Import_Cl();

            try
            {
                import.Querys(studentSkupina);
                GetTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Stud_G_Button_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                Stud_G_Button.Image = Properties.Resources.icons8_windows_10_32;
                Study_Panel.Size = Study_Panel.MaximumSize;

                isCollapsed = false;

            }
            else
            {
                Stud_G_Button.Image = Properties.Resources.icons8_expand_arrow_32;
                Study_Panel.Size = Study_Panel.MinimumSize;
                isCollapsed = true;

            }
        }
        private void OdoslatEmailBtnMainMenu_Click(object sender, EventArgs e)
        {
            var openSendMail = new EmailSendingForm(currentUser,studentSkupina);
            openSendMail.Show();
        }
        private void Student_Button_Click(object sender, EventArgs e)
        {            
            if (isCollapsed_2)
            {
                Student_Button.Image = Properties.Resources.icons8_windows_10_32;
                Student_Panel.Size = Student_Panel.MaximumSize;

                isCollapsed_2 = false;

            }
            else
            {
                Student_Button.Image = Properties.Resources.icons8_expand_arrow_32;
                Student_Panel.Size = Student_Panel.MinimumSize;
                isCollapsed_2 = true;

            }
        }
        private void Ext_Btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Attendance_Button_Click(object sender, EventArgs e)
        {
            var att = new Dochádzka(studentSkupina);
            att.Show();
        }
        private void Activity_Button_Click(object sender, EventArgs e)
        {
            if (isCollapsed_3)
            {
                Activity_Button.Image = Properties.Resources.icons8_windows_10_32;
                Activity_panel.Size = Activity_panel.MaximumSize;
                isCollapsed_3 = false;
            }
            else
            {
                Activity_Button.Image = Properties.Resources.icons8_expand_arrow_32;
                Activity_panel.Size = Activity_panel.MinimumSize;
                isCollapsed_3 = true;
            }
        }
        private void Gear_Button_Click(object sender, EventArgs e)
        {
            if (isCollapsed_4)
            {
                Gear_Button.Image = Properties.Resources.icons8_windows_10_32;
                Settings_Panel.Size = Settings_Panel.MaximumSize;
                isCollapsed_4 = false;
            }
            else
            {
                Gear_Button.Image = Properties.Resources.icons8_expand_arrow_32;
                Settings_Panel.Size = Settings_Panel.MinimumSize;
                isCollapsed_4 = true;

            }
        }
        private void Email_client_btn_Click_1(object sender, EventArgs e)
        {
            var email_c = new Email_Client(currentUser);
            email_c.Show();
        }
        private void Stat_Btn_Click(object sender, EventArgs e)
        {
            var stat = new Statistics();
            stat.Show();
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {
            GetTable();

        }

        private void Create_Templ_Click(object sender, EventArgs e)
        {
            var template = new CreateTemplate(currentUser);
            template.Show();
        }

        private void Create_Act_Btn_Click(object sender, EventArgs e)
        {
            var createActivity = new CreateActivity(currentUser,studentSkupina);
            createActivity.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createEmailTemplate = new EmailTemplateForm(currentUser);
            createEmailTemplate.Show();
        }

        private void Student_Grid_SelectionChanged(object sender, EventArgs e)
        {
            if(Student_Grid.SelectedRows.Count>=1) 
            GetActivities();
        }
    }


}
