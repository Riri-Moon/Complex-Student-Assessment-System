using MaterialSkin.Controls;
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
    public partial class IndividualActivity : MaterialForm
    {

        User currUser;
        StudentSkupina skupina;
        private readonly string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        Dictionary<string, int> studentsId = new Dictionary<string, int>();
        public IndividualActivity(User user, StudentSkupina skup)
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            InitializeComponent();


            currUser = user;
            skupina = skup;
            GetTableActivity();
        }

        private IQueryable GetTableActivity()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var templ = con.GetTable<ActivityTemplate>();

                    var dataTemp = from act in templ where act.IdUser == currUser.Id select new { Názov = act.ActivityName, Bodov = act.MaxPoints, act.Id };
                    ActivityGridView.DataSource = dataTemp;
                    ActivityGridView.RowHeadersVisible = false;
                    ActivityGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ActivityGridView.Columns["Id"].Visible = false;
                    ActivityGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "HH:mm";
                    dateTimePicker2.ShowUpDown = true;

                    var studs = con.GetTable<Student>().Where(x => x.ID_stud_skupina == skupina.Id);

                    foreach (var student in studs.Distinct())
                    {
                        studentCombo.Items.Add(student.Meno + " " + student.Priezvisko);
                        studentsId.Add(student.Meno + " " + student.Priezvisko, student.Id);
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

        private void GetTableTasks()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (ActivityGridView.SelectedRows.Count > 0)
                    {
                        var selectedActivity = (int)ActivityGridView.CurrentRow.Cells["Id"].Value;
                        var acts = con.GetTable<ActivityTemplate>().Where(x => x.IdUser == currUser.Id && x.Id == selectedActivity).FirstOrDefault();
                        var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == acts.Id).Select(x => new
                        {
                            x.ActivityTemplate,
                            x.Id,
                            x.IdActivityTemplate,
                            Maximum = x.MaxPts,
                            Názov = x.TaskName
                        });
                        TaskGrid.DataSource = tasks;

                        TaskGrid.Columns["IdActivityTemplate"].Visible = false;
                        TaskGrid.Columns["Id"].Visible = false;
                        TaskGrid.Columns["ActivityTemplate"].Visible = false;
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

        private bool IsSendingChecked()
        {
            if (SendingEmailCheck.Checked == true)
            {
                if (string.IsNullOrEmpty(currUser.ApiKey))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private async void SendActivityCreated(List<EmailAddress> mails, Activity activity, string link)
        {
            EmailClient client = new EmailClient();
            string content = string.Empty;

            SendGrid.SendGridClient gridClient;
            if (!string.IsNullOrEmpty(link))
            {
                gridClient = new SendGrid.SendGridClient(client.SetEnvironmentVar(currUser));
                content = $"Dobrý deň {activity.Student.Meno}, <br/> dňa {DateTime.Now.Date + DateTime.Now.TimeOfDay} Vám bola vytvorená aktivita {activity.ActivityName}," +
                   $" <br/> ktorú je potrebné odovzdať do {activity.Deadline} <br/> {link}";
            }
            else
            {
                gridClient = new SendGrid.SendGridClient(client.SetEnvironmentVar(currUser));
                content = $"Dobrý deň {activity.Student.Meno}, <br/> dňa {DateTime.Now.Date + DateTime.Now.TimeOfDay} Vám bola vytvorená aktivita {activity.ActivityName}," +
                   $" <br/> ktorú je potrebné odovzdať do {activity.Deadline}";
            }

            EmailBody body = new EmailBody()
            {
                HtmlContent = content,
                PlainTextContent = content,
                To = mails,
                Subject = "Nová aktivita"
            };

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(MailHelper.StringToEmailAddress(currUser.Email), body.To, body.Subject, body.HtmlContent, body.HtmlContent);

            var response = await gridClient.SendEmailAsync(msg);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Logger logger = new Logger();
                logger.LogEmail(DateTime.Now, body.To, body.Subject, body.HtmlContent, null);
            }
        }

        private DateTime GetDate()
        {
            dateTimePicker2.Value = dateTimePicker2.Value.AddSeconds(dateTimePicker2.Value.Second * -1);
            return dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
        }

        private void ActivityGridView_SelectionChanged(object sender, EventArgs e)
        {
            GetTableTasks();
        }

        private void CreateActBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
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

                    if (studentCombo.SelectedItem == null)
                    {
                        MessageBox.Show("Najprv musíte vybrať študenta", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    studentsId.TryGetValue((string)studentCombo.SelectedItem, out int id);

                    Student student = con.GetTable<Student>().Where(x => x.ID_stud_skupina == skupina.Id && x.Id == id).FirstOrDefault();

                    List<EmailAddress> studentAddress = new List<EmailAddress>();
                    Activity activityForEmailSending = null;

                    Activity activity = new Activity()
                    {
                        ActivityName = actTempl.ActivityName,
                        IdFirstRem = actTempl.FirstRem,
                        IdSecRem = actTempl.SecondRem,
                        MaxPoints = actTempl.MaxPoints,
                        Deadline = GetDate(),
                        EmailSendingActive = IsSendingChecked(),
                        IdSkupina = skupina.Id,
                        IdUser = this.currUser.Id,
                        Hodnotenie = 0,
                        Hodnotene = false,
                        SendFirst = first,
                        SendSecond = second,
                        IdStudent = student.Id,
                        Comment = string.Empty,
                        SendMe = SendMe(),

                    };

                    studentAddress.Add(MailHelper.StringToEmailAddress(student.Email));
                    con.Activities.InsertOnSubmit(activity);
                    con.SubmitChanges();

                    activityForEmailSending = activity;
                    //GetTasks
                    var tasks = con.GetTable<TaskTemplate>().Where(x => x.IdActivityTemplate == actTempl.Id);
                    foreach (var tsk in tasks)
                    {
                        Task task = new Task()
                        {
                            IdActivity = activity.Id,
                            TaskName = tsk.TaskName,
                            Points = tsk.MaxPts,
                            Hodnotenie = 0,
                            IdStudent = student.Id,
                            Comment = string.Empty

                        };
                        con.Tasks.InsertOnSubmit(task);
                    }
                    con.SubmitChanges();

                    if (ActCreatedCheckBox.Checked == true && currUser.ApiKey != string.Empty)
                    {
                        var link = Interaction.InputBox("Ak si neželáte zaslať dodatočné informácie o úlohe, nechajte prázdne", "Dodatočná správa", "Viac informácií nájdete na: ", -1, -1);
                        SendActivityCreated(studentAddress, activityForEmailSending, link);
                    }
                    else if (currUser.ApiKey == string.Empty)
                    {
                        MessageBox.Show("ApiKey je prázdny, aktivita bude vytvorená ale žiaden email nebude odoslaný pokým nebude pridaný ApiKey");
                    }

                    MessageBox.Show($"Aktivita {actTempl.ActivityName} bola úspešne vytvorená");
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

        private bool SendMe()
        {
            if (SendMeBox.Checked == true)
            {
                return true;
            }
            else return false;
        }

        private void TaskGrid_SelectionChanged(object sender, EventArgs e)
        {
            this.TaskGrid.CurrentRow.Selected = false;
        }
    }



}
