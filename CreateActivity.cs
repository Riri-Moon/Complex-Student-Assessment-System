using Microsoft.VisualBasic;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CSAS
{
    public partial class CreateActivity : MaterialSkin.Controls.MaterialForm
    {
        User currUser;
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        StudentSkupina studentSkup;
        public CreateActivity(User currentUser, StudentSkupina skup)
        {
            InitializeComponent();
            studentSkup = skup;
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            currUser = currentUser;
            GetTableActivity();
            groupCmbo.SelectedIndex = 0;

        }

        private bool IsSendingChecked()
        {
            if (SendingEmailCheck.Checked == true)
            {
                if (!string.IsNullOrEmpty(currUser.ApiKey))
                {
                    MessageBox.Show("ApiKey nemôže byť prázdny");
                    return false;
                }
                return true;
            }
            else return false;
        }

        private bool SendMe()
        {
            if (SendMeBox.Checked == true)
            {
                return true;
            }
            else return false;
        }
        private void CreateActBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {


                    //GetActivityTemp
                    var selectedActivity = (int)ActivityGridView.CurrentRow.Cells["Id"].Value;
                    var actTempl = con.GetTable<ActivityTemplate>().Where(x => x.Id == selectedActivity && x.IdUser == currUser.Id).FirstOrDefault();
                    ///Whether, and what reminders should be send 
                    var first = false;
                    var second = false;
                    if (actTempl.FirstRem.HasValue)
                    {
                        first = true;
                    }
                    if (actTempl.SecondRem.HasValue)
                    {
                        second = true;
                    }

                    IQueryable<Student> studs;

                    if (groupCmbo.Text == "Všetky")
                    {
                        studs = con.GetTable<Student>().Where(x => x.ID_stud_skupina == studentSkup.Id);
                    }

                    else
                    {
                        studs = con.GetTable<Student>().Where(x => x.ID_stud_skupina == studentSkup.Id && x.ID_Kruzok == groupCmbo.Text);
                    }

                    if(studs.Count() <=0)
                    {
                        MessageBox.Show("Skupina neobsahuje žiadnych študentov. Nie je možné vytvoriť aktivitu.");
                        return;

                    }

                    List<EmailAddress> studentsAddresses = new List<EmailAddress>();
                    Activity activityForEmailSending = null;



                    foreach (var student in studs)
                    {

                        Activity activity = new Activity()
                        {
                            ActivityName = actTempl.ActivityName,
                            IdFirstRem = actTempl.FirstRem,
                            IdSecRem = actTempl.SecondRem,
                            MaxPoints = actTempl.MaxPoints,
                            Deadline = GetDate(),
                            EmailSendingActive = IsSendingChecked(),
                            IdSkupina = studentSkup.Id,
                            IdUser = this.currUser.Id,
                            Hodnotene = false,
                            SendFirst = first,
                            SendSecond = second,
                            IdStudent = student.Id,
                            SendMe = SendMe(),

                        };

                        studentsAddresses.Add(MailHelper.StringToEmailAddress(student.Email));
                        con.Activities.InsertOnSubmit(activity);
                        con.SubmitChanges();
                        activityForEmailSending = activity;
                        //get students


                        //GetTasks
                        var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == actTempl.Id);
                        foreach (var tsk in tasks)
                        {
                            Task task = new Task()
                            {
                                IdActivity = activity.Id,
                                TaskName = tsk.TaskName,
                                Points = tsk.MaxPts,
                                IdStudent = student.Id,
                                Comment= string.Empty


                            };
                            con.Tasks.InsertOnSubmit(task);
                        }

                        con.SubmitChanges();

                    }
                    MessageBox.Show($"Aktivita {actTempl.ActivityName} bola úspešne vytvorená");


                    if (ActCreatedCheckBox.Checked == true)
                    {
                        var link = Interaction.InputBox("Dodatočná správa", "Ak si neželáte zaslať dodatočné informácie o úlohe, nechajte prázdne", "Viac informácií nájdete na: ", -1, -1);

                        SendActivityCreated(studentsAddresses, activityForEmailSending,link);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return;
            }

        }



        private void SendActivityCreated(List<EmailAddress> mails, Activity activity, string link)
        {
            EmailClient client = new EmailClient();
            string content = string.Empty;
            SendGrid.SendGridClient gridClient;
            if (!string.IsNullOrEmpty(link))
            {
                 gridClient = new SendGrid.SendGridClient(client.SetEnvironmentVar(currUser));
                 content = $"Milí študenti, <br/> dňa {DateTime.Now.Date.ToLocalTime()} Vám bola vytvorená aktivita {activity.ActivityName}," +
                    $" <br/> ktorú je potrebné odovzdať do {activity.Deadline.ToLocalTime()} <br/> {link}";
            }
            else
            {
                 gridClient = new SendGrid.SendGridClient(client.SetEnvironmentVar(currUser));
                 content = $"Milí študenti, <br/> dňa {DateTime.Now.Date.ToLocalTime()} Vám bola vytvorená aktivita {activity.ActivityName}," +
                    $" <br/> ktorú je potrebné odovzdať do {activity.Deadline.ToLocalTime()}";
            }

            EmailBody body = new EmailBody()
            {
                HtmlContent = content,
                PlainTextContent = content,
                To = mails,
                Subject = "Nová aktivita"
            };

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(currUser.Email), body.To, body.Subject, body.HtmlContent, body.HtmlContent);
            gridClient.SendEmailAsync(msg);

            Logger logger = new Logger();
            logger.LogEmail(DateTime.Now, body.To, body.Subject, body.HtmlContent, null);
                
        }

        private void GetTableTasks()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var selectedActivity = (int)ActivityGridView.CurrentRow.Cells["Id"].Value;
                    var acts = con.GetTable<ActivityTemplate>().Where(x => x.IdUser == currUser.Id && x.Id == selectedActivity).FirstOrDefault();
                    var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == acts.Id);
                    TaskGrid.DataSource = tasks;

                    TaskGrid.Columns["IdActivityTemplate"].Visible = false;
                    TaskGrid.Columns["Id"].Visible = false;
                    TaskGrid.Columns["ActivityTemplate"].Visible = false;


                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return;
            }
        }


        private IQueryable GetTableActivity()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var templ = con.GetTable<ActivityTemplate>();

                    var dataTemp = from act in templ where act.IdUser == currUser.Id select new { act.ActivityName, act.MaxPoints, act.Id };
                    ActivityGridView.DataSource = dataTemp;
                    ActivityGridView.RowHeadersVisible = false;
                    ActivityGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ActivityGridView.Columns["Id"].Visible = false;

                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "HH:mm";
                    dateTimePicker2.ShowUpDown = true;

                    var studs = con.GetTable<Student>();
                    var kruzok = from stud in studs where stud.ID_stud_skupina == this.studentSkup.Id select (string)stud.ID_Kruzok;
                    kruzok.ToList<string>();
                    groupCmbo.Items.Add("Všetky");
                    foreach (var kruz in kruzok.Distinct())
                    {
                        groupCmbo.Items.Add(kruz);
                    }
                    return dataTemp;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return null;
            }
        }


        private DateTime GetDate()
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay);
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SendingEmailCheck_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            GetTableTasks();
        }

        private void ActivityGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ActivityGridView.SelectedRows.Count >= 1)
                GetTableTasks();

        }

        private void ActCreatedCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TaskGrid_SelectionChanged(object sender, EventArgs e)
        {
            this.TaskGrid.CurrentRow.Selected = false;
        }
    }
}
