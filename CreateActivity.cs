using Microsoft.VisualBasic;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CSAS
{
    public partial class CreateActivity : MaterialSkin.Controls.MaterialForm
    {
        User currUser;
        private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        StudentSkupina studentSkup;
        bool apiKeyEmpty = false;
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
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.ShowUpDown = true;

            GetTableActivity();
            groupCmbo.SelectedIndex = 0;
        }

        //Kontrola ci sa maju pre vybranu aktivitu odosielat upozornenia
        private bool IsSendingChecked()
        {
            if (SendingEmailCheck.Checked == true)
            {
                if (string.IsNullOrEmpty(currUser.ApiKey))
                {
                    apiKeyEmpty = true;
                    return false;
                }
                return true;
            }
            else return false;
        }

        //Kontrola ci sa maju pouzivatelovi odosielat upozornenia o uplynuti datumu odovzdania
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
                    if (ActivityGridView.Rows.Count <= 0)
                    {
                        MessageBox.Show("Nie je vytvorená žiadna šablóna aktivity", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Ziskanie sablony aktivity
                    var selectedActivity = (int)ActivityGridView.CurrentRow.Cells["Id"].Value;
                    var actTempl = con.GetTable<ActivityTemplate>().Where(x => x.Id == selectedActivity && x.IdUser == currUser.Id).FirstOrDefault();
                    //Ziskavanie udajov o tom, ci, a ktore upozornenia maju byt odosielane
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

                    if (studs.Count() <= 0)
                    {
                        MessageBox.Show("Skupina neobsahuje žiadnych študentov. Nie je možné vytvoriť aktivitu.");
                        return;

                    }

                    List<EmailAddress> studentsAddresses = new List<EmailAddress>();
                    Activity activityForEmailSending = null;

                    if (SendMe())
                    {
                        if (apiKeyEmpty)
                        {
                            MessageBox.Show("ApiKey nemôže byť prázdny, aktivita bude vytvorená ale nebudú odoslané emaily", "ApiKey prázdny", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    /// Vytvorenie novej aktivity na zaklade sablony aktivity pre kazdeho studenta z studs 
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
                            Comment = string.Empty,
                            SendMe = SendMe(),
                        };

                        studentsAddresses.Add(MailHelper.StringToEmailAddress(student.Email));
                        con.Activities.InsertOnSubmit(activity);
                        con.SubmitChanges();
                        activityForEmailSending = activity;

                        //Vyrvorenie novych uloh ku kazdej aktivite z vybranej sablony
                        var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == actTempl.Id);
                        foreach (var tsk in tasks)
                        {
                            Task task = new Task()
                            {
                                IdActivity = activity.Id,
                                TaskName = tsk.TaskName,
                                Points = tsk.MaxPts,
                                IdStudent = student.Id,
                                Comment = string.Empty
                            };
                            con.Tasks.InsertOnSubmit(task);
                        }
                        con.SubmitChanges();
                    }
                    MessageBox.Show($"Aktivita {actTempl.ActivityName} bola úspešne vytvorená");

                    if (ActCreatedCheckBox.Checked == true && !string.IsNullOrEmpty(currUser.ApiKey))
                    {
                        var link = Interaction.InputBox("Ak si neželáte zaslať dodatočné informácie o úlohe, nechajte prázdne", "Dodatočná správa", "Viac informácií nájdete na: ", -1, -1);
                        SendActivityCreated(studentsAddresses, activityForEmailSending, link);
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

        // Odosielanie emailu o tom, ze bola vytvorena aktivita
        private void SendActivityCreated(List<EmailAddress> mails, Activity activity, string link)
        {
            try
            {
                //Kontrola ci je mozne odoslat email
                if (string.IsNullOrEmpty(currUser.ApiKey))
                {
                    return;
                }

                EmailClient client = new EmailClient();
                string content = string.Empty;
                SendGrid.SendGridClient gridClient;
                if (!string.IsNullOrEmpty(link))
                {
                    gridClient = new SendGrid.SendGridClient(client.SetEnvironmentVar(currUser));
                    content = $"Milí študenti, <br/> dňa {DateTime.Now.Date + DateTime.Now.TimeOfDay} Vám bola vytvorená aktivita {activity.ActivityName}," +
                       $" <br/> ktorú je potrebné odovzdať do {activity.Deadline} <br/> {link}";
                }
                else
                {
                    gridClient = new SendGrid.SendGridClient(client.SetEnvironmentVar(currUser));
                    content = $"Milí študenti, <br/> dňa {DateTime.Now.Date + DateTime.Now.TimeOfDay} Vám bola vytvorená aktivita {activity.ActivityName}," +
                       $" <br/> ktorú je potrebné odovzdať do {activity.Deadline}";
                }

                EmailBody body = new EmailBody()
                {
                    HtmlContent = content,
                    PlainTextContent = content,
                    To = mails,
                    Subject = "Nová aktivita"
                };
                //Vytvorenie obsahu emailu, ktorym oznamujeme studentom, ze im bolo vytvorene hodnotenie a jeho nasledne odoslanie

                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(currUser.Email), body.To, body.Subject, body.HtmlContent, body.HtmlContent);
                gridClient.SendEmailAsync(msg);

                Logger logger = new Logger();
                logger.LogEmail(DateTime.Now, body.To, body.Subject, body.HtmlContent, null);
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
                MessageBox.Show("Pri odosielaní emailu nastal problém.");
            }
        }

        //Nacitanie uloh aktivity do datagridview
        private void GetTableTasks()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (ActivityGridView.Rows.Count > 0)
                    {
                        var selectedActivity = (int)ActivityGridView.CurrentRow.Cells["Id"].Value;
                        var acts = con.GetTable<ActivityTemplate>().Where(x => x.IdUser == currUser.Id && x.Id == selectedActivity).FirstOrDefault();
                        var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == acts.Id);
                        TaskGrid.DataSource = tasks;

                        TaskGrid.Columns["TaskName"].HeaderText = "Názov úlohy";
                        TaskGrid.Columns["MaxPts"].HeaderText = "Maximum";

                        TaskGrid.Columns["TaskName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        TaskGrid.Columns["IdActivityTemplate"].Visible = false;
                        TaskGrid.Columns["Id"].Visible = false;
                        TaskGrid.Columns["ActivityTemplate"].Visible = false;
                        TaskGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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


        private IQueryable GetTableActivity()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var templ = con.GetTable<ActivityTemplate>();

                    var dataTemp = from act in templ where act.IdUser == currUser.Id select new { Názov = act.ActivityName, Maximum = act.MaxPoints, act.Id };
                    ActivityGridView.DataSource = dataTemp;
                    ActivityGridView.RowHeadersVisible = false;
                    ActivityGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ActivityGridView.Columns["Id"].Visible = false;
                    ActivityGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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

        //Vratenie datumu z datepicker control
        private DateTime GetDate()
        {
            dateTimePicker2.Value = dateTimePicker2.Value.AddSeconds(dateTimePicker2.Value.Second * -1);
            return dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                GetTableTasks();
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }

        private void ActivityGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ActivityGridView.SelectedRows.Count >= 1)
                    GetTableTasks();
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }

        private void TaskGrid_SelectionChanged(object sender, EventArgs e)
        {
            this.TaskGrid.CurrentRow.Selected = false;
        }
    }
}
