using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Drawing;
using MaterialSkin.Controls;
using System.Configuration;

namespace CSAS
{
    public partial class Main_Window : MaterialForm
    {

                private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        protected bool isCollapsed_4 = true;
        protected bool isCollapsed_3 = true;
        protected bool isCollapsed_2 = true;
        protected bool isCollapsed = true;
        public StudentSkupina studentSkupina = new StudentSkupina();
        protected static User currentUser = new User();
        private int currentRow = 0;


        public Main_Window(StudentSkupina skupina, User user)
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            try
            {
                InitializeComponent();
                currentUser = user;
                studentSkupina = skupina;

                SendEmailCheck emailCheck = new SendEmailCheck();
                emailCheck.AutomatedEmailSending(currentUser);

                var aTimer = new System.Timers.Timer(60 * 60 * 1000); 
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Start();

                GetTable();
                OnLoadStudent();
                CreateBlockedExtensionFile();
            }
            catch (Exception ex)
            {

                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        //https://stackoverflow.com/questions/3718380/winforms-double-buffering
        // Okno sa zobrazí až vtedy, keď všetky komponenty sú vykreslené.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        // Pravidelné spúšťanie kontroly toho, či má byť odoslané upozornenie študentom
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

        // Vytvorenie zoznamu blokovaných extensions súborov
        private void CreateBlockedExtensionFile()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/BlockedExtensions.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    EmailAttachments attachments = new EmailAttachments();
                    foreach (var line in attachments.blockedExtensions)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }


        // Získanie študentov používateľa pre vybranú skupinu
        private void GetTable()
        {
            try
            {

                using (var con = new StudentDBDataContext(conn_str))
                {
                    var students = con.GetTable<Student>()?.Where(studs => studs.ID_stud_skupina == studentSkupina.Id && studs.Forma == studentSkupina.Forma).
                  Select(x => new
                  {
                      x.Id,
                      x.Meno,
                      x.Priezvisko,
                      x.Email,
                      Email2 = x.Email_UCM,
                      x.ISIC,
                      Ročník = x.Rocnik,
                      x.Forma,
                      Krúžok = x.IdGroupForAttendance,
                      x.ID_Kruzok,
                      Body = x.FinalGrades.Where(y => y.IdStudent == x.Id).Select(z => z.GotPoints).FirstOrDefault(),
                      Známka = x.FinalGrades.Where(y => y.IdStudent == x.Id).Select(z => z.Grade).FirstOrDefault()

                  });

                    if(Student_Grid.SelectedRows.Count>0)
                    currentRow = Student_Grid.CurrentRow.Index;
                    
                    Student_Grid.RowHeadersVisible = false;
                    Student_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Student_Grid.MultiSelect = false;
                    Student_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Student_Grid.DataSource = students.OrderBy(x => x.Priezvisko);
                    Student_Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

                    Student_Grid.Columns["Id"].Visible = false;               
                    Student_Grid.Columns["ID_Kruzok"].Visible = false;

                    // Vytvorenie celkovej dochádzky pre študentov, v prípade ak ešte nebola vytvorená
                    foreach (var stud in students)
                    {
                        var exists = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == stud.Id).FirstOrDefault();
                        
                        if (exists == null)
                        {
                            TotalAttendance totalAttendance = new TotalAttendance() { IdStudent = stud.Id };
                            con.TotalAttendances.InsertOnSubmit(totalAttendance);                           
                        }
                        else
                        {
                            continue;
                        }
                    }
                    con.SubmitChanges();
                    OnLoadStudent();
                }
            }
            catch (DataException ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        


        // Zvýrazňovanie údajov, ktoré chýbajú
        private void OnLoadStudent()
        {
            try
            {
                
                if (Student_Grid != null)
                {
                    foreach (DataGridViewRow row in Student_Grid.Rows)
                    {
                        if (string.IsNullOrEmpty((string)row.Cells[5].Value) || (string)row.Cells[5].Value == null)
                        {
                            row.Cells[5].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            row.Cells[5].Style.BackColor = Color.White;
                        }
                        if (!row.Cells[8].Value.ToString().Equals(row.Cells[9].Value.ToString()))
                        {
                            row.Cells[8].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            row.Cells[8].Style.BackColor = Color.White;

                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
            }

        }

        // Získanie vytvorených aktivít pre konkrétneho študenta
        private void GetActivities()
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    
                    if (Student_Grid.SelectedRows.Count > 0 )
                    {
                        var selectedStudent = (int)Student_Grid.CurrentRow.Cells[0].Value;
                        var acts = con.GetTable<Activity>().Where(x => x.IdUser == currentUser.Id);

                        var dataSource = from studAct in acts
                                         where studAct.IdStudent == selectedStudent
                                         select new
                                         {
                                             Názov = studAct.ActivityName,
                                             Maximum = studAct.MaxPoints,
                                             studAct.Hodnotenie,
                                             studAct.Id,
                                             Odovzdanie = studAct.Deadline
                                         };
                        Activity_Grid.RowHeadersVisible = false;
                        Activity_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Activity_Grid.DataSource = dataSource;
                        Activity_Grid.Columns["Id"].Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }    


        // Otvorenie okna pre import študentov z excelu
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
                Logger newLog = new Logger();
                newLog.LogError(ex);
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

        // Otvorenie okna, kde používateľ môže odosielať emaily.
        private void OdoslatEmailBtnMainMenu_Click(object sender, EventArgs e)
        {
            var openSendMail = new EmailSendingForm(currentUser,studentSkupina);
            openSendMail.ShowDialog();
        }
       
        private void Ext_Btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete skončiť?", "Ukončiť", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                  Environment.Exit(1);          
            }
        }

        // Otvorenie okna s dochádzkou
        private void Attendance_Button_Click(object sender, EventArgs e)
        {
            var att = new Dochádzka(studentSkupina);
            att.FormClosed += IsClosed;
            att.ShowDialog();
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

        // Nastavenia používateľa
        private void Email_client_btn_Click_1(object sender, EventArgs e)
        {
            var emailClient = new Email_Client(currentUser,studentSkupina);
            emailClient.FormClosed += IsClosed;
            emailClient.ShowDialog();
        }
        private void Stat_Btn_Click(object sender, EventArgs e)
        {
            var stat = new Statistics(currentUser,studentSkupina);
            stat.FormClosed += IsClosed;
            stat.ShowDialog();
        }



        private void Main_Window_Load(object sender, EventArgs e)
        {
            OnLoadStudent();

        }

        private void Create_Templ_Click(object sender, EventArgs e)
        {
            var template = new CreateTemplate(currentUser);
            template.ShowDialog();
        }

        private void Create_Act_Btn_Click(object sender, EventArgs e)
        {
            var createActivity = new CreateActivity(currentUser,studentSkupina);
            createActivity.FormClosed += IsClosed;
            createActivity.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createEmailTemplate = new EmailTemplateForm(currentUser);
            createEmailTemplate.ShowDialog();
        }

        private void Student_Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (Student_Grid.SelectedRows.Count >= 1)
            {
                GetActivities();
            }
        }
        // Manuálne pridanie študenta
        private void Add_Stud_Button_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm(currentUser, studentSkupina);
            addStudentForm.FormClosed += IsClosed;
            addStudentForm.ShowDialog();
        }

        //Kontextové menu, na hodnotenie/odstránenie aktivity
        private void Activity_Grid_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            DataGridViewRow dataGridViewRow1 = Activity_Grid.Rows[e.RowIndex];
            e.ContextMenuStrip = materialContextMenuStrip1;            
        }

        // Otvorenie okna, v ktorom je možné pridávať hodnotenie ku konkrétnej aktivite
        private void hodnotiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;

                using (var con = new StudentDBDataContext(conn_str))
                {
                    var stud = con.GetTable<Student>().Where(x => x.ID_stud_skupina == studentSkupina.Id && x.Id == (int)Student_Grid.CurrentRow.Cells[0].Value).FirstOrDefault();
                    var act = con.GetTable<Activity>().Where(x => x.IdStudent == stud.Id && x.Id == (int)Activity_Grid.CurrentRow.Cells[3].Value).FirstOrDefault();

                    var gradeForm = new GradeActivityForm(studentSkupina, stud, act);
                    gradeForm.FormClosed += IsClosed;
                    gradeForm.ShowDialog();
                }
                this.UseWaitCursor = false;
            }
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Aktivita bola vymazaná, nie je možné ju ohodnotiť");
            }
        }

        // Obnovenie údajov v datagridoch.
        private void IsClosed(object sender, EventArgs e)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    //Refresh 
                    currentUser = con.Users.Where(x => x.Id == currentUser.Id).FirstOrDefault();
                }
                GetTable();
                //Vratenie vyberu na povodne miesto
                if (Student_Grid.Rows.Count > 0)
                {
                    Student_Grid.ClearSelection();
                    Student_Grid.Rows[currentRow].Selected = true;
                    Student_Grid.CurrentCell = Student_Grid[1, currentRow];

                    Student_Grid.Focus();
                }
                Activity_Grid.DataSource = null;

                GetActivities();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Main_Window_Shown(object sender, EventArgs e)
        {         
        }

        // Otvorenie okna na pridanie aktivity pre jednotlivca nie skupinu.
        private void button2_Click(object sender, EventArgs e)
        {
            var singleActivity = new IndividualActivity(currentUser, studentSkupina);
            singleActivity.FormClosed += IsClosed;
            singleActivity.ShowDialog();
        }


        // Zmazanie vsetkych dat skupiny / Tyka sa to len studentov
    

            // Kontextové menu pre študenta, pridanie bodov za aktivitu na cvičení.
        private void bodyZaAktivituCvičenieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                
                PointsForActivity(currentUser.PointsForActSem);              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Uistite sa, že v nastaveniach je priradená šablóna pre body za aktivitu.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }
        // Kontextové menu pre študenta, pridanie bodov za aktivitu na prednáške.

        private void bodyZaAktivituPrednáškaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PointsForActivity(currentUser.PointsForActLec);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uistite sa, že v nastaveniach je priradená šablóna pre body za aktivitu.","Upozornenie",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }
       /// <summary>
       /// Vytvorenie aktivity, body za aktivitu
       /// </summary>
       /// <param name="id"></param>
        private void PointsForActivity(int? id)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var actTempl = con.GetTable<ActivityTemplate>().Where(x => x.Id == id).FirstOrDefault();
                    Activity activity = new Activity()
                    {
                        ActivityName = actTempl.ActivityName,
                        IdFirstRem = null,
                        IdSecRem = null,
                        MaxPoints = actTempl.MaxPoints,
                        Deadline = DateTime.Now,
                        EmailSendingActive = false,
                        IdSkupina = studentSkupina.Id,
                        IdUser = currentUser.Id,
                        Hodnotene = true,
                        SendFirst = false,
                        SendSecond = false,
                        IdStudent = (int)Student_Grid.CurrentRow.Cells[0].Value,
                        Hodnotenie = actTempl.MaxPoints,
                        Comment = string.Empty,
                        SendMe = false,

                    };
                    con.Activities.InsertOnSubmit(activity);
                    con.SubmitChanges();

                    var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == actTempl.Id);
                    foreach (var tsk in tasks)
                    {
                        Task task = new Task()
                        {
                            IdActivity = activity.Id,
                            TaskName = tsk.TaskName,
                            Points = tsk.MaxPts,
                            IdStudent = activity.IdStudent,
                            Hodnotenie = tsk.MaxPts,
                            Comment = string.Empty,                            


                        };
                        con.Tasks.InsertOnSubmit(task);
                    }

                    con.SubmitChanges();
                }
                GetActivities();
            }
            catch (ArgumentNullException ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }


        private void Student_Grid_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            DataGridViewRow dataGridViewRow1 = Student_Grid.Rows[e.RowIndex];
            e.ContextMenuStrip = materialContextMenuStrip2;
        }

        private void FinalGradeBtn_Click(object sender, EventArgs e)
        {
            var final = new FinalGradeForm(currentUser, studentSkupina);
            final.FormClosed += IsClosed;
            final.ShowDialog();
        }


        // Otvorenie inej skupiny v rámci skupín používateľa
        private void Open_Btn_Click(object sender, EventArgs e)
        {
            var choose = new Choose_Group(currentUser);
           DialogResult result = choose.ShowDialog();
            if(result == DialogResult.Yes)
            {
                studentSkupina = choose.GetGroup();
            }
            Student_Grid.DataSource = null;
            Activity_Grid.DataSource = null;
            GetTable();
            GetActivities();
        }


        //Otvorenie okna na export údajov do PDF a Excelu
        private void Export_Btn_Click(object sender, EventArgs e)
        {
            var export = new ExportForm(studentSkupina, currentUser);
            export.Show();
        }


        // Odhlásenie z aplikácie
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["LoginForm"].Show();
        }

        private void odstrániťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Naozaj chcete odstrániť aktivitu ?", "Odstrániť aktivitu",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.UseWaitCursor = true;

                    using (var con = new StudentDBDataContext(conn_str))
                    {
                        var stud = con.GetTable<Student>().Where(x => x.ID_stud_skupina == studentSkupina.Id && x.Id == (int)Student_Grid.CurrentRow.Cells[0].Value).FirstOrDefault();
                        var act = con.GetTable<Activity>().Where(x => x.IdStudent == stud.Id && x.Id == (int)Activity_Grid.CurrentRow.Cells[3].Value).FirstOrDefault();

                        var tasks = con.GetTable<Task>().Where(x => x.IdStudent == (int)Student_Grid.CurrentRow.Cells[0].Value && x.IdActivity == act.Id);
                        con.Tasks.DeleteAllOnSubmit(tasks);
                        con.SubmitChanges();

                        con.Activities.DeleteOnSubmit(act);
                        con.SubmitChanges();
                    }
                    this.UseWaitCursor = false;
                }
                GetActivities();
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }

        private void odstrániťToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Naozaj chcete odstrániť študenta?", "Odstrániť študenta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.UseWaitCursor = true;

                    using (var con = new StudentDBDataContext(conn_str))
                    {
                        var studentId = (int)Student_Grid.CurrentRow.Cells[0].Value;

                        var stud = con.GetTable<Student>().First(x => x.Id == studentId);

                        var totalAttendance = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == studentId).FirstOrDefault();
                        con.TotalAttendances.DeleteOnSubmit(totalAttendance);
                        con.SubmitChanges();

                        var attendance = con.GetTable<AttendanceStud>().Where(x => x.IDStudent == studentId);
                        if (attendance.Count() > 0)
                        {
                            con.AttendanceStuds.DeleteAllOnSubmit(attendance);
                            con.SubmitChanges();
                        }

                        var tasks = con.GetTable<Task>().Where(x => x.IdStudent == studentId);
                        if (tasks.Count() > 0)
                        {
                            con.Tasks.DeleteAllOnSubmit(tasks);
                            con.SubmitChanges();

                            var activity = con.GetTable<Activity>().Where(x => x.IdStudent == studentId);
                            con.Activities.DeleteAllOnSubmit(activity);
                            con.SubmitChanges();
                        }
                        var finalGrade = con.GetTable<FinalGrade>().Where(x => x.IdStudent == studentId);
                        if (finalGrade.Count() > 0)
                        {
                            con.FinalGrades.DeleteAllOnSubmit(finalGrade);
                            con.SubmitChanges();
                        }

                        con.Students.DeleteOnSubmit(stud);
                        con.SubmitChanges();
                    }
                    this.UseWaitCursor = false;
                }
                GetTable();
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }
    }
}
