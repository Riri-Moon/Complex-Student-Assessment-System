using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/// <summary>
/// TODO: Try to optimaze this code ( Try to remove excessive variables like contolspoints and count ..
/// </summary>
namespace CSAS
{
    public partial class CreateTemplate : MaterialSkin.Controls.MaterialForm
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        User currUser;

        int count = 0;
        int countBtn = 1;

        int countAdd = 0;
        int countBtnAdd = 1;
        List<Control> controlsPoints = new List<Control>();
        List<Control> controlsNames = new List<Control>();
        List<Control> Labels = new List<Control>();
        List<Control> controlPointsForEdit = new List<Control>();
        List<Control> controlNamesForEdit = new List<Control>();
        Control lastName = new Control();
        Control lastPts = new Control();

        public CreateTemplate(User currentuser)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            currUser = currentuser;
            GetTableTemp();
        }


        private IQueryable GetTableTemp()
        {
            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var templ = con.GetTable<ActivityTemplate>();

                var dataTemp = from act in templ where act.IdUser == currUser.Id select new { act.ActivityName, act.MaxPoints, act.Id };
                AllActTempGrid.DataSource = dataTemp;
                AllActTempGrid.RowHeadersVisible = false;
                AllActTempGrid.AllowUserToAddRows = false;
                AllActTempGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                AllActTempGrid.AllowUserToDeleteRows = false;
                AllActTempGrid.AllowUserToResizeColumns = false;
                AllActTempGrid.ReadOnly = true;
                AllActTempGrid.Columns["Id"].Visible = false;

                return dataTemp;

            }
        }






        /// <summary>
        /// Vytvaranie novych taskov dynamicky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTaskBtn_Click(object sender, EventArgs e)
        {

            if (countAdd >= 20)
            {
                MessageBox.Show("Nie je možné vytvoriť viac ako 20 úloh", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.AddTaskBtn.Location = new Point(25, 40 + (30 * countBtnAdd));
            this.DeleteTaskBtn.Location = new Point(500, 40 + (30 * countBtnAdd++));

            MaterialLabel label = new MaterialLabel
            {
                Name = "DynamicLabel" + countAdd++,
                Location = new Point(21, 19 + (30 * countAdd)),
                Text = "Názov úlohy:"
            };
            Labels.Add(label);
            this.panel1.Controls.Add(label);

            MaterialLabel labelPoints = new MaterialLabel
            {
                Name = "DynamicLabelPoints" + countAdd,
                Location = new Point(420, 19 + (30 * countAdd)),
                Text = "Max bodov:"
            };
            this.panel1.Controls.Add(labelPoints);
            Labels.Add(labelPoints);

            MaterialSingleLineTextField taskName = new MaterialSingleLineTextField()
            {
                Name = "DynName" + countAdd,
                Location = new Point(134, 19 + (30 * countAdd)),
                Size = new System.Drawing.Size(223, 23)

            };
            this.panel1.Controls.Add(taskName);

            MaterialSingleLineTextField taskPoints = new MaterialSingleLineTextField()
            {
                Name = "DynPoints" + countAdd,
                Location = new Point(604, 19 + (30 * countAdd)),
                Size = new System.Drawing.Size(43, 23)

            };
            controlNamesForEdit.Add(taskName);
            controlPointsForEdit.Add(taskPoints);
            controlsNames.Add(taskName);
            controlsPoints.Add(taskPoints);

            /// Pridavanie max bodov za task do max bodov za aktivitu
            taskPoints.TextChanged += TextBox_TextChanged;
            this.panel1.Controls.Add(taskPoints);

        }


        protected void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            float xy = 0;
            try
            {


                //Changed from controlsPoints
                foreach (var contr in controlPointsForEdit)
                {
                    if (contr.Text != string.Empty)
                    {   
                        xy += (float)Math.Round(float.Parse(contr.Text.Replace(",", ".")), 2);

                   //     MaxPtsLabel.Text = xy.ToString();
                    }

                }
                MaxPtsLabel.Text = xy.ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Zly format cisla", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        private void CreateTemplateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    var checkExisting = con.ActivityTemplates.Where(x => x.ActivityName == ActNameTxtBox.Text).Count();

                    if (checkExisting != 0)
                    {
                        MessageBox.Show("Aktivita s týmto menom už existuje", "Chyba");
                        return;
                    }

                    var ActTemp = new ActivityTemplate()
                    {
                        IdUser = currUser.Id,
                        MaxPoints = Math.Round(float.Parse(MaxPtsLabel.Text), 2),
                        ActivityName = ActNameTxtBox.Text
                    };

                    if (ActTemp.MaxPoints != 0 && !string.IsNullOrWhiteSpace(ActTemp.MaxPoints.ToString()) && ActTemp.ActivityName != string.Empty)
                    {
                        con.ActivityTemplates.InsertOnSubmit(ActTemp);
                        con.SubmitChanges();
                    }
                    else
                    {
                        MessageBox.Show("Názov aktivity ani maximálny počet bodov nemôžu byť prázdne", "Chyba", MessageBoxButtons.OK);
                        return;
                    }
                    /// Wrong numbers // Change ctrlpoints to ctrlptsfedit and anmes too
                    foreach (var x in controlNamesForEdit.Zip(controlPointsForEdit, (names, points) => new { controlNamesForEdit = names, controlPointsForEdit = points }))
                    {


                        float isParsable;
                        var toParse = x.controlPointsForEdit.Text;
                        bool success = Single.TryParse(toParse, out isParsable);
                        if (!success)
                        {
                            MessageBox.Show("Niektoré pole nie je vyplnené", "Chyba", MessageBoxButtons.OK);
                            var getAct = con.ActivityTemplates.Where(p => p.ActivityName == ActTemp.ActivityName);
                            var deleteTask = con.TaskTemplates.Where(p => p.IdActivityTemplate == getAct.FirstOrDefault().Id);
                            con.SubmitChanges();
                            if (deleteTask.Count() > 0)
                            {
                                foreach (var task in deleteTask)
                                {
                                    con.TaskTemplates.DeleteOnSubmit(task);
                                }
                            }
                            con.ActivityTemplates.DeleteOnSubmit(getAct.FirstOrDefault());
                            con.SubmitChanges();
                            return;
                        }



                        var TaskTemp = new TaskTemplate()
                        {

                            IdActivityTemplate = ActTemp.Id,
                            MaxPts = Math.Round(isParsable, 2),
                            TaskName = x.controlNamesForEdit.Text
                        };

                        if (!string.IsNullOrWhiteSpace(TaskTemp.TaskName) && TaskTemp.MaxPts != 0 && TaskTemp?.MaxPts != null)
                        {
                            con.TaskTemplates.InsertOnSubmit(TaskTemp);
                        }
                        else
                        {
                            MessageBox.Show("Niektoré pole nie je vyplnené, alebo je zle vyplnené", "Chyba", MessageBoxButtons.OK);
                            con.ActivityTemplates.DeleteOnSubmit(ActTemp);
                            con.SubmitChanges();
                            return;
                        }

                    }

                    con.SubmitChanges();
                    MessageBox.Show("Šablóna bola úspešne vytvorená", "Dáta úspešne zapísané", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    ActNameTxtBox.Text = null;
                    MaxPtsLabel.Text = 0.ToString();
                    controlsPoints[0].Text = 0.ToString();
                    foreach (var x in controlsNames.Zip(controlsPoints, (names, points) => new { controlsNames = names, controlsPoints = points }))
                    {

                        x.controlsNames.Text = null;
                        x.controlsPoints.Text = null;
                    }
                    MaxPtsLabel.Text = 0.ToString();
                    GetTableTemp();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Odstranenie vsetkych taskov a nasledne samotnej activity
        /// </summary>

        private void RemoveActTempBtn_Click(object sender, EventArgs e)
        {

            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    var selectedTaskTemp = con.TaskTemplates.Where(a => a.IdActivityTemplate == (int)AllActTempGrid.CurrentRow.Cells[2].Value);
                    var selectedAct = con.ActivityTemplates.Where(a => a.Id == (int)AllActTempGrid.CurrentRow.Cells[2].Value);

                    foreach (var x in selectedTaskTemp)
                    {
                        con.TaskTemplates.DeleteOnSubmit(x);
                    }

                    con.ActivityTemplates.DeleteOnSubmit(selectedAct.FirstOrDefault());
                    con.SubmitChanges();
                }
                    

                GetTableTemp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void EditActTempBtn_Click(object sender, EventArgs e)
          {
            try
            {
                countAdd = 0;
                countBtnAdd = 1;

                this.AddTaskBtn.Visible = false;
                this.DeleteTaskBtn.Visible = false;
                ///Try if after click on Edit it will keep coount of everything and nothing else is differernt

                var labelCounts = Labels.Count - 1;
                //Odstranenie controls aby sa neopakovali pri editovani
                foreach (var x in controlNamesForEdit.Zip(controlPointsForEdit, (names, points) => new { controlPointsForEdit = points, controlNamesForEdit = names }))
                {
                    if (Labels.Count > 0)
                    {
                        foreach (var y in Labels)
                        {
                            panel1.Controls.Remove(y);
                            ///TUTO TO NECLEARUJE LABELS
                        }
                        Labels.Clear();
                    }

                    panel1.Controls.Remove(x.controlNamesForEdit);
                    panel1.Controls.Remove(x.controlPointsForEdit);

                }
                controlPointsForEdit.Clear();
                controlNamesForEdit.Clear();

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var selectedTaskTemp = con.TaskTemplates.Where(a => a.IdActivityTemplate == (int)AllActTempGrid.CurrentRow.Cells[2].Value);
                    var selectedAct = con.ActivityTemplates.Where(a => a.Id == (int)AllActTempGrid.CurrentRow.Cells[2].Value);

                    foreach (var x in selectedAct)
                    {
                        ActNameTxtBox.Text = x.ActivityName;
                        MaxPtsLabel.Text = x.MaxPoints.ToString();

                    }

                    foreach (var x in selectedTaskTemp)
                    {
                        if (count >= 20)
                        {
                            MessageBox.Show("Nie je možné vytvoriť viac ako 20 úloh", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        this.AddTaskBtn.Location = new Point(25, 40 + (30 * countBtn));
                        this.DeleteTaskBtn.Location = new Point(500, 40 + (30 * countBtn++));
                        countBtnAdd++;

                        MaterialLabel label = new MaterialLabel
                        {
                            Name = "DynamicLabel" + count++,
                            Location = new Point(21, 19 + (30 * count)),
                            Text = "Názov úlohy:"
                        };
                        countAdd++;


                        Labels.Add(label);
                        this.panel1.Controls.Add(label);

                        MaterialLabel labelPoints = new MaterialLabel
                        {
                            Name = "DynamicLabelPoints" + count,
                            Location = new Point(420, 19 + (30 * count)),
                            Text = "Max bodov:"
                        };

                        Labels.Add(labelPoints);
                        this.panel1.Controls.Add(labelPoints);

                        MaterialSingleLineTextField taskName = new MaterialSingleLineTextField()
                        {
                            Name = "DynName" + count,
                            Location = new Point(134, 19 + (30 * count)),
                            Size = new System.Drawing.Size(223, 23),
                            Text = x.TaskName

                        };
                        this.panel1.Controls.Add(taskName);

                        MaterialSingleLineTextField taskPoints = new MaterialSingleLineTextField()
                        {
                            Name = "DynPoints" + count,
                            Location = new Point(604, 19 + (30 * count)),
                            Size = new System.Drawing.Size(43, 23),
                            Text = x.MaxPts.ToString()

                        };

                        controlNamesForEdit.Add(taskName);
                        controlPointsForEdit.Add(taskPoints);
 

                        /// Pridavanie max bodov za task do max bodov za aktivitu
                        taskPoints.TextChanged += TextBox_TextChanged;
                        this.panel1.Controls.Add(taskPoints);

                    }
                    this.AddTaskBtn.Visible = true;
                    this.DeleteTaskBtn.Visible = true;


                    count = 0;
                    countBtn = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void EditAddTemp(object sender, EventArgs e)
        {

        }

        private void DeleteTaskBtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                var index = controlNamesForEdit.Count - 1;

                lastName = controlNamesForEdit.ElementAt(index);
                lastPts = controlPointsForEdit.ElementAt(index);

                /// Indexy buttons v panel
                var indexAddBtn = this.panel1.Controls.IndexOfKey("AddTaskBtn");
                var indexDeleteBtn = this.panel1.Controls.IndexOfKey("DeleteTaskBtn");

                controlNamesForEdit.Remove(lastName);
                controlPointsForEdit.Remove(lastPts);
                controlsNames.Remove(lastName);
                controlsPoints.Remove(lastPts);


                if (Labels.Count >= 1)
                {
                    var labelCount = Labels.Count - 1;
                    Labels.RemoveAt(labelCount);
                    Labels.RemoveAt(labelCount - 1);
                }

                for (int i = 0; i < 4; i++)
                {
                    var count = this.panel1.Controls.Count - 1;

                    if (count != indexAddBtn && count - 1 != indexDeleteBtn)
                    {
                        this.panel1.Controls.RemoveAt(count);                       
                    }
                    else
                    {
                        MessageBox.Show("Všetky úlohy sú odstránené","Žiadna úloha");
                        return;
                    }

                }
                
                //Znovu prerata vsetky point textboxy 
                TextBox_TextChanged(sender, e);              

                /// Zmena lokacie buttons o 30 za kazdu odstranenu ulohu
                var addY = this.AddTaskBtn.Location.Y;
                var addX = this.AddTaskBtn.Location.X;
                this.AddTaskBtn.Location = new Point(addX, addY - (30));

                addY = this.DeleteTaskBtn.Location.Y;
                addX = this.DeleteTaskBtn.Location.X;
                this.DeleteTaskBtn.Location = new Point(addX, addY - (30)); 

                //Znizenie Countu kvoli, aby ak sa prida dalsie okno, tak ho pridalo hned za posledne a nie dalej
                if (countAdd != 0 && countBtnAdd != 1)
                {
                    countAdd--;
                    countBtnAdd--;
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Už nie je čo odstrániť");
            }
        }
    }
}

