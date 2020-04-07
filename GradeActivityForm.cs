﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CSAS
{
    public partial class GradeActivityForm : MaterialSkin.Controls.MaterialForm
    {
        int count = 0;
        StudentSkupina currGroup;
        Student currStud;
        Activity currActivity;
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        Dictionary<string, int> tasksDictionary = new Dictionary<string, int>();

        public GradeActivityForm(StudentSkupina grp, Student stud, Activity activ)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            currGroup = grp;
            currStud = stud;
            currActivity = activ;
            NewActivityTab(currActivity);
            NewTaskTab(currActivity, currStud);
            var width = MaterialTabCOntrol.Controls.Count * 50;
            Drawer.Size = new Size(250, width);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void GradeActivityForm_Load(object sender, EventArgs e)
        {
          

        }


        private void NewActivityTab(Activity activity)
        {
            TabPage page = new TabPage
            {
                Text = activity.ActivityName,
                Name = activity.ActivityName,
                BackColor = Color.White
            };
            List<Control> controls = new List<Control>();
            RichTextBox comment = new RichTextBox
            {
                Size = new Size(300, 190),
                Location = new Point(30, 125)
            };

            MaterialLabel label0 = new MaterialLabel
            {
                Name = "TaskNameLabel" ,
                Location = new Point(26, 15),
                AutoSize = true,
                Text = "Názov: "+ activity.ActivityName.ToString()
            };


            MaterialLabel label = new MaterialLabel
            {
                Name = "TotalPtsLabel" ,
                Location = new Point(26, 40),
                AutoSize = true,
                Text = "Maximum bodov: " + activity.MaxPoints.ToString()
            };


            MaterialLabel label3 = new MaterialLabel
            {
                Name = "StudentPtsLabel" ,
                Location = new Point(26, 70),
                AutoSize = true,
                Text = "Získané: " + activity.Hodnotenie.ToString(),
            };
          
            MaterialLabel label5 = new MaterialLabel
            {
                Name = "CommentLabel" ,
                AutoSize = true,
                Location = new Point(26, 105),
                Text = "Komentár ku aktivite: ",
            };
            MaterialButton button = new MaterialButton()
            {
                Location = new Point(230, 330),
                Text = "Hodnotiť aktivitu",


            };
            button.Click += GradeActivityBtnClick;
            MaterialButton button2 = new MaterialButton()
            {
                Location = new Point(10, 330),
                Text = "Späť"
            };
            button2.Click += BackBtn;

            MaterialTabCOntrol.Controls.Add(page);
            controls.Add(label0);
            controls.Add(comment);
            controls.Add(button);
            controls.Add(button2);
            controls.Add(label);
            controls.Add(label3);
            controls.Add(label5);
            page.Controls.AddRange(controls.ToArray());


        }
        private void NewTaskTab(Activity activity, Student stud)
        {
            try {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    var tasks = con.GetTable<Task>().Where(x => x.IdActivity == activity.Id && x.IdStudent == stud.Id);

                    foreach (var task in tasks)
                    {
                        TabPage page1 = new TabPage
                        {
                            Name = task.TaskName,
                            Text = task.TaskName,
                            BackColor = Color.White,
                            UseVisualStyleBackColor = true,

                        };

                        RichTextBox comment = new RichTextBox
                        {
                            Name = "comment" ,
                            Size = new Size(300, 190),
                            Location = new Point(30, 125)
                        };

                        MaterialLabel label0 = new MaterialLabel
                        {
                            Name = "NameOfTaskLabel" + count,
                            Location = new Point(26, 15),
                            AutoSize = true,
                            Text = "Názov: " + task.TaskName.ToString()
                        };
                        tasksDictionary.Add(task.TaskName.ToString(), task.Id);


                        MaterialLabel label = new MaterialLabel
                        {
                            Name = "TotalPtsLabel" + count,
                            Location = new Point(26, 40),
                            AutoSize = true,
                            Text = "Maximum bodov: " + task.Points.ToString()

                        };

                        MaterialLabel label2 = new MaterialLabel
                        {
                            Name = "PtsLabel" + count,
                            Location = new Point(26, 70),
                            AutoSize = true,
                            Text = "Získané: ",
                        };

                        MaterialTextBox textField = new MaterialTextBox()
                        {
                            Name = "GradeTextBox",
                            Location = new Point(100, 65),
                            Size = new Size(70, 23),
                            MaxLength = 4,
                            Text = task.Hodnotenie.ToString(),

                        };

                        MaterialLabel label3 = new MaterialLabel
                        {
                            Name = "CommentLabel" + count,
                            Location = new Point(26, 105),

                            AutoSize = true,
                            Text = "Komentár ku úlohe: "
                        };

                        MaterialButton button = new MaterialButton()
                        {
                            Name = "GradeBtn",
                            Location = new Point(250, 330),
                            Text = "Hodnotiť úlohu",


                        };
                        button.Click += GradeTaskBtnClick;
           

                        MaterialButton button2 = new MaterialButton()
                        {
                            Name="BackBtn",
                            Location = new Point(10, 330),
                            Text = "Späť"
                        };

                        button2.Click += BackBtn;
                        MaterialTabCOntrol.Controls.Add(page1);
                        page1.Controls.Add(label0);
                        page1.Controls.Add(comment);
                        page1.Controls.Add(label);
                        page1.Controls.Add(label2);
                        page1.Controls.Add(textField);
                        page1.Controls.Add(label3);
                        page1.Controls.Add(button);
                        page1.Controls.Add(button2);

                    }
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GradeActivityBtnClick(object sender, EventArgs e)
        {

            try
            {
                if (this.MaterialTabCOntrol.SelectedTab.Name == currActivity.ActivityName)
                {
                    var labl = (Label)MaterialTabCOntrol.SelectedTab.Controls.Find("StudentPtsLabel", false).FirstOrDefault();

                    using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                    {

                        var act = con.GetTable<Task>().Where(x => x.IdActivity == currActivity.Id && x.IdStudent == currStud.Id);
                        double? gradeTotal = 0;
                        foreach (var tsk in act)
                        {
                            if (tsk.Hodnotenie != null)
                            {
                                gradeTotal += tsk.Hodnotenie;
                            }
                        }

                        var insert = con.Activities.Where(x => x.IdSkupina == currGroup.Id && x.Id == currActivity.Id && x.IdStudent == currStud.Id).FirstOrDefault();

                        if (gradeTotal.Value <= insert.MaxPoints)
                        {
                            ///ERROR 280 Line
                            insert.Hodnotene = true;
                            insert.Hodnotenie = gradeTotal;
                            insert.EmailSendingActive = false;
                            insert.SendFirst = false;
                            insert.SendSecond = false;
                        }

                        con.SubmitChanges();
                        MessageBox.Show("Aktivita ohodnotená");

                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void GradeTaskBtnClick(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    string taskTab = string.Empty;
                   
                        taskTab = MaterialTabCOntrol.SelectedTab.Name;

                    tasksDictionary.TryGetValue(taskTab, out int Id);


                    Task task1 = con.Tasks.Where(x => x.IdActivity == currActivity.Id && x.Id == Id && x.IdStudent==currStud.Id).FirstOrDefault();


                    var textBox = MaterialTabCOntrol.SelectedTab.Controls.Find("GradeTextBox", false).FirstOrDefault();
                    if (textBox!=null && !string.IsNullOrEmpty(textBox.Text))
                    {
                        double.TryParse(textBox.Text, out double grade);
                        if (grade <= task1.Points)
                        {
                            task1.Hodnotenie = grade;
                        }
                        else
                        {
                            MessageBox.Show("Hodnotenie nemôže byť väčšie ako maximum bodov. Pred pridaním hodnotenia opravte hodnotu");
                            return;
                        }
                       
                    }
                    else
                    {
                        MaterialMessageBox.Show("Hodnotenie nemôže byť prázdne", "Chyba", MessageBoxButtons.OK);
                        return;
                    }
                    var commentBox = MaterialTabCOntrol.SelectedTab.Controls.Find("comment", false).FirstOrDefault();

                   
                        task1.Comment = textBox.Text;
                 
                    con.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
            

        

        private void BackBtn(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void MaterialTabCOntrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void MaterialTabCOntrol_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MaterialTabCOntrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.MaterialTabCOntrol.SelectedTab.Name == currActivity.ActivityName)
            {
                var labl = (Label)MaterialTabCOntrol.SelectedTab.Controls.Find("StudentPtsLabel", false).FirstOrDefault();

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    var act = con.GetTable<Task>().Where(x => x.IdActivity == currActivity.Id && x.IdStudent == currStud.Id);
                    double? gradeTotal = 0;
                    foreach(var tsk in act)
                    {
                        if (tsk.Hodnotenie != null)
                        {
                            gradeTotal += tsk.Hodnotenie;
                        }
                    }

                    // var insert to act con.Activities.Where(x => x.Id == currActivity.Id && x.IdStudent == currStud.Id).FirstOrDefault()

                    MaterialTabCOntrol.SelectedTab.Controls.Find("StudentPtsLabel", false).FirstOrDefault().Text = "Získané: " + gradeTotal.ToString();
                 //   labl.Text =

                }
            }
            else
            {
                return;
            }

        }

        private void GradeActivityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (con.GetTable<Activity>().Where(x => x.Id == currActivity.Id && x.IdStudent == currStud.Id).FirstOrDefault().Hodnotene == false)
                    {
                        DialogResult dialogResult = MessageBox.Show("Aktivita nebola ohodnotená, chcete naozaj skončiť ?", "Skončiť bez hodnotenia? ", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }

                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
    
}



    