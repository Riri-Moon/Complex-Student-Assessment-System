using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace CSAS
{
    public partial class Email_Client : MaterialForm
    {
                private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        User currentUser = new User();
        StudentSkupina group;
        Dictionary<string, int> activityId = new Dictionary<string, int>();


        public Email_Client(User activeUser,StudentSkupina skup)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            currentUser = activeUser;
            group = skup;

            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var user = con.GetTable<User>().Where(x => x.Id == currentUser.Id).FirstOrDefault();
                var actTempLec = con.GetTable<ActivityTemplate>().Where(x => x.Id == user.PointsForActLec).FirstOrDefault();
                var actTempSem = con.GetTable<ActivityTemplate>().Where(x => x.Id == user.PointsForActSem).FirstOrDefault();

                ABox.Text = user.AGrade.ToString();
                BBox.Text = user.BGrade.ToString();
                CBox.Text = user.CGrade.ToString();
                DBox.Text = user.DGrade.ToString();
                EBox.Text = user.EGrade.ToString();
                textBox2.Text = user.Email;
                materialMultiLineTextBox1.Text = user.Signature;
                LoadComboBoxes(activeUser);

                if (actTempSem != null && comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedItem = actTempSem.ActivityName;
                }
                if (actTempLec != null && comboBox1.Items.Count > 0)
                {
                    comboBox2.SelectedItem = actTempLec.ActivityName;
                }

            }


        }

        private void LoadComboBoxes(User user)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    
                    var activities = con.GetTable<ActivityTemplate>().Where(x => x.IdUser == currentUser.Id);

                    if (activities.Count() > 0)
                    {
                        foreach (var activity in activities)
                        {
                            comboBox1.Items.Add(activity.ActivityName);
                            comboBox2.Items.Add(activity.ActivityName);
                            activityId.Add(activity.ActivityName, activity.Id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
            }


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

            User user = con.Users.FirstOrDefault(x => x.Id == currentUser.Id);
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
                user.Email = user.Email;
            }
            else
            {
                user.Email = textBox2.Text;
            }

            if (comboBox1.SelectedItem != null)
            {
                activityId.TryGetValue((string)comboBox1.SelectedItem, out int id);
                user.PointsForActSem = id;
            }

            if (comboBox2.SelectedItem != null)
            {
                activityId.TryGetValue((string)comboBox2.SelectedItem, out int id);
                user.PointsForActLec = id;
            }



            float.TryParse(ABox.Text, out float aGrade);
            float.TryParse(BBox.Text, out float bGrade);
            float.TryParse(CBox.Text, out float cGrade);
            float.TryParse(DBox.Text, out float dGrade);
            float.TryParse(EBox.Text, out float eGrade);

            user.AGrade = aGrade;
            user.BGrade = bGrade;
            user.CGrade = cGrade;
            user.DGrade = dGrade;
            user.EGrade = eGrade;

            user.Signature = materialMultiLineTextBox1.Text;


            con.SubmitChanges();

            ABox.Text = user.AGrade.ToString();
            BBox.Text = user.BGrade.ToString();
            CBox.Text = user.CGrade.ToString();
            DBox.Text = user.DGrade.ToString();
            EBox.Text = user.EGrade.ToString();

            materialMultiLineTextBox1.Text = user.Signature;


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

        private void materialMultiLineTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                materialMultiLineTextBox1.AppendText("\u00A0");
            }
        }

        private void ABox_Enter(object sender, EventArgs e)
        {
            MaterialTextBox TB = (MaterialTextBox)sender;
            {
                int VisibleTime = 1000; 

                ToolTip tt = new ToolTip();
                tt.Show("Spodná hranica hodnotenia, vrátane.", TB, 25, -20, VisibleTime);
            }
        }

        private void BBox_Enter(object sender, EventArgs e)
        {
            MaterialTextBox TB = (MaterialTextBox)sender;
            {
                int VisibleTime = 1000;  

                ToolTip tt = new ToolTip();
                tt.Show("Spodná hranica hodnotenia, vrátane.", TB, 25, -20, VisibleTime);
            }
        }

        private void CBox_Enter(object sender, EventArgs e)
        {
            MaterialTextBox TB = (MaterialTextBox)sender;
            {
                int VisibleTime = 1000; 

                ToolTip tt = new ToolTip();
                tt.Show("Spodná hranica hodnotenia, vrátane.", TB, 25, -20, VisibleTime);
            }
        }

        private void DBox_Enter(object sender, EventArgs e)
        {
            MaterialTextBox TB = (MaterialTextBox)sender;
            {
                int VisibleTime = 1000; 

                ToolTip tt = new ToolTip();
                tt.Show("Spodná hranica hodnotenia, vrátane.", TB, 25, -20, VisibleTime);
            }
        }

        private void EBox_Enter(object sender, EventArgs e)
        {            
            MaterialTextBox TB = (MaterialTextBox)sender;
            {
                int VisibleTime = 1000; 

                ToolTip tt = new ToolTip();
                tt.Show("Spodná hranica hodnotenia, vrátane.", TB, 25, -20, VisibleTime);
            }
        }

        private void Email_Client_Load(object sender, EventArgs e)
        {

        }

        private void DeleteAllGroupDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Naozaj chcete odstrániť všetky údaje študentov vybranej skupiny? Zmeny nebude možné zvrátiť a dáta budú navždy vymazané.", "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult finalResult = MessageBox.Show("Ste si istý, že chcete odstrániť všetky údaje skupiny?", "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (finalResult == DialogResult.Yes)
                    {
                        DeleteWholeGroupData(currentUser, group);
                    }
                    else
                    {
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
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }
        private void DeleteWholeGroupData(User currentUser, StudentSkupina currentGroup)
        {
            try
            {
                UseWaitCursor = true;
                using (var con = new StudentDBDataContext(conn_str))
                {
                    var students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == currentGroup.Id);

                    foreach (var student in students)
                    {
                        var totalAttendance = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == student.Id).FirstOrDefault();
                        con.TotalAttendances.DeleteOnSubmit(totalAttendance);
                        con.SubmitChanges();

                        var attendance = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id);
                        con.AttendanceStuds.DeleteAllOnSubmit(attendance);
                        con.SubmitChanges();

                        var tasks = con.GetTable<Task>().Where(x => x.IdStudent == student.Id);
                        con.Tasks.DeleteAllOnSubmit(tasks);
                        con.SubmitChanges();

                        var activity = con.GetTable<Activity>().Where(x => x.IdStudent == student.Id);
                        con.Activities.DeleteAllOnSubmit(activity);
                        con.SubmitChanges();

                        var studentId = student.Id;




                        var finalGrade = con.GetTable<FinalGrade>().Where(x => x.IdStudent == studentId);
                        con.FinalGrades.DeleteAllOnSubmit(finalGrade);
                        con.SubmitChanges();

                        con.Students.DeleteOnSubmit(student);
                        con.SubmitChanges();
                    }
                }

                UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger logger = new Logger();
                logger.LogError(ex);
            }

        }

    }
}
