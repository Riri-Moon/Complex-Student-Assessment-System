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
    public partial class FinalGradeForm : MaterialSkin.Controls.MaterialForm
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        User currentUser;
        StudentSkupina group;

        public FinalGradeForm(User user, StudentSkupina skup)
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            InitializeComponent();

            currentUser = user;
            group = skup;

            CreateFinalGradeOnStart();
            LoadGrid(skup);
        }

        private bool OnlyAllowedValues(string text)
        {
            List<string> allowedValues = new List<string>();
            allowedValues.Add("A");
            allowedValues.Add("B");
            allowedValues.Add("C");
            allowedValues.Add("D");
            allowedValues.Add("E");
            allowedValues.Add("Fx");

            int count = 0;
            foreach (var value in allowedValues)
            {
                if (text == value)
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void GradeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    if(!Validator())
                    {
                        return;
                    }

                    FinalGrade grade = con.FinalGrades.Where(x => x.IdSkupina == group.Id && x.IdStudent == (int)StudentGrid.CurrentRow.Cells[0].Value).FirstOrDefault();
                    float.TryParse(MaxPtsBox.Text, out float maxPoints);
                    float.TryParse(SemPtsBox.Text, out float semPts);
                    float.TryParse(LecPtsBox.Text, out float lecPts);     

                    int.TryParse(MissedLecBox.Text, out int missedLec);
                    int.TryParse(MissedSemBox.Text, out int missedSem);

                    float.TryParse(TotalPtsBox.Text, out float totalPts);

                    grade.ActivitySemPoints = semPts;
                    grade.ActivityLectPoints = lecPts;

                    grade.MissedLectures = missedLec;
                    grade.MissedSeminars = missedSem;

                    grade.MaxPts = maxPoints;
                    grade.GotPoints = totalPts;

                    grade.Grade = FinalGradeBox.Text;

                    con.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }


        private void CreateFinalGradeOnStart()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var allStudents = con.GetTable<Student>().Where(x => x.ID_stud_skupina == group.Id);
                    var allFinalGrades = con.GetTable<FinalGrade>().Where(x => x.IdSkupina == group.Id);
                    bool isAdded = false;

                    if (allStudents.Count() <=0 || allStudents==null)
                    {
                        return;
                    }
                    foreach (var student in allStudents)
                    {
                        var exists = allFinalGrades.Where(x => x.IdSkupina == group.Id && x.IdStudent==student.Id);

                        if (exists.Count() > 0)
                        {
                            continue;
                        }

                        FinalGrade finalGrade = new FinalGrade()
                        {
                            IdSkupina = group.Id,
                            IdStudent = student.Id,
                        };
                        con.FinalGrades.InsertOnSubmit(finalGrade);
                        isAdded = true;
                    }
                    if (isAdded)
                    {
                        con.SubmitChanges();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }



        private void LoadTextBoxes()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    double maxPoints = 0;
                    double? acquiredPoints = 0;
                    double? bonusSem = 0;
                    double? bonusLec = 0;
                    if(StudentGrid.Rows.Count <=0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden študent.");
                        return;
                    }

                    var selectedStudentId = (int)StudentGrid.CurrentRow.Cells[0].Value;

                    if (materialRadioButton1.Checked)
                    {

                        var bonusPtsSeminarTemp = con.GetTable<ActivityTemplate>().Where(x => x.Id == currentUser.PointsForActSem).FirstOrDefault();
                        var bonusPtsLectureTemp = con.GetTable<ActivityTemplate>().Where(x => x.Id == currentUser.PointsForActLec).FirstOrDefault();

                        var bonusPtsSeminar = con.GetTable<Activity>().Where(x => x.ActivityName == bonusPtsSeminarTemp.ActivityName && x.IdSkupina == group.Id && x.IdStudent == selectedStudentId);
                        var bonusPtsLecture = con.GetTable<Activity>().Where(x => x.ActivityName == bonusPtsLectureTemp.ActivityName && x.IdSkupina == group.Id && x.IdStudent == selectedStudentId);

                        var totalAttendance = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == selectedStudentId).FirstOrDefault();


                        var allActivities = con.GetTable<Activity>().Where(x => x.ActivityName != bonusPtsSeminarTemp.ActivityName && x.ActivityName != bonusPtsLectureTemp.ActivityName
                        && x.IdStudent == selectedStudentId);

                        foreach (var activity in allActivities)
                        {
                            maxPoints += activity.MaxPoints;
                            acquiredPoints += activity.Hodnotenie;
                        }

                        foreach (var seminar in bonusPtsSeminar)
                        {
                            if (seminar.Hodnotenie == null)
                            {
                                bonusSem += 0;
                            }
                            else
                            {
                                bonusSem += seminar.Hodnotenie;
                            }
                        }

                        foreach (var lecture in bonusPtsLecture)
                        {
                            if (lecture.Hodnotenie == null)
                            {
                                bonusLec += 0;
                            }
                            else
                            {
                                bonusLec += lecture.Hodnotenie;
                            }
                        }

                        double? totalPoints = acquiredPoints + bonusSem + bonusLec;

                        MaxPtsBox.Text = maxPoints.ToString();
                        SemPtsBox.Text = bonusSem.ToString();
                        LecPtsBox.Text = bonusLec.ToString();
                        TotalPtsBox.Text = totalPoints.ToString();
                        MissedLecBox.Text = totalAttendance.TotalAbsentLecture.ToString();
                        MissedSemBox.Text = totalAttendance.TotalAbsentSeminar.ToString();

                        string grade;
                        if (totalPoints >= currentUser.AGrade)
                        {
                            grade = "A";
                        }
                        else if (totalPoints >= currentUser.BGrade)
                        {
                            grade = "B";
                        }
                        else if (totalPoints >= currentUser.CGrade)
                        {
                            grade = "C";

                        }
                        else if (totalPoints >= currentUser.DGrade)
                        {
                            grade = "D";

                        }
                        else if (totalPoints >= currentUser.EGrade)
                        {
                            grade = "E";
                        }
                        else
                        {
                            grade = "Fx";
                        }
                        FinalGradeBox.Text = grade;
                    }
                    else
                    {
                        var finalGrade = con.GetTable<FinalGrade>().Where(x => x.IdSkupina == group.Id && x.IdStudent == selectedStudentId).FirstOrDefault();

                        MaxPtsBox.Text = finalGrade.MaxPts.ToString();
                        SemPtsBox.Text = finalGrade.ActivitySemPoints.ToString();
                        LecPtsBox.Text = finalGrade.ActivityLectPoints.ToString();
                        TotalPtsBox.Text = finalGrade.GotPoints.ToString();
                        FinalGradeBox.Text = finalGrade.Grade;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }


        private void LoadGrid(StudentSkupina skupina)
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == skupina.Id).Select(y => new { y.Id, y.Meno, y.Priezvisko, y.ISIC });
                    if (students.Count() > 0)
                    {
                        StudentGrid.DataSource = students;
                        StudentGrid.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger newLog = new Logger();
                newLog.LogError(ex);
            }
        }

        private void StudentGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (StudentGrid.SelectedRows.Count > 0)
            {
                LoadTextBoxes();
            }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (StudentGrid.SelectedRows.Count > 0)
            {
                LoadTextBoxes();
            }
        }



        private bool Validator()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (StudentGrid.Rows.Count <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden študent.");
                        return false;
                    }

                    FinalGrade grade = con.FinalGrades.Where(x => x.IdSkupina == group.Id && x.IdStudent == (int)StudentGrid.CurrentRow.Cells[0].Value).FirstOrDefault();

                    var notGradedActivity = con.GetTable<Activity>().Where(x => x.IdStudent == (int)StudentGrid.CurrentRow.Cells[0].Value && x.Hodnotene == false);

                    if (notGradedActivity.Count() > 0)
                    {
                        DialogResult result = MessageBox.Show("Niektorá aktivita nebola ohodnotená, chcete napriek tomu pokračovať?", "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    if (!float.TryParse(MaxPtsBox.Text, out float maxPoints))
                    {
                        MessageBox.Show("Pole musí obsahovať len čísla");
                        MaxPtsBox.Select();
                        return false;
                    }
                    if (!float.TryParse(SemPtsBox.Text, out float semPts))
                    {
                        MessageBox.Show("Pole musí obsahovať len čísla");
                        SemPtsBox.Select();
                        return false;
                    }
                    if (!float.TryParse(LecPtsBox.Text, out float lecPts))
                    {
                        MessageBox.Show("Pole musí obsahovať len čísla");
                        LecPtsBox.Select();
                        return false;
                    }
                    if (!int.TryParse(MissedLecBox.Text, out int missedLec))
                    {
                        MessageBox.Show("Pole musí obsahovať len čísla");
                        MissedLecBox.Select();
                        return false;
                    }
                    if (!int.TryParse(MissedSemBox.Text, out int missedSem))
                    {
                        MessageBox.Show("Pole musí obsahovať len čísla");
                        SemPtsBox.Select();
                        return false;
                    }
                    if (!float.TryParse(TotalPtsBox.Text, out float totalPts))
                    {
                        MessageBox.Show("Pole musí obsahovať len čísla");
                        TotalPtsBox.Select();
                        return false;
                    }
                    if (totalPts > maxPoints)
                    {
                        DialogResult result = MessageBox.Show("Počet získaných bodov je väčší ako maximum, chcete pokračovať ?", "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result != DialogResult.Yes)
                        {
                            return false;
                        }
                    }
                    if (!OnlyAllowedValues(FinalGradeBox.Text))
                    {
                        MessageBox.Show("Povolené hodnoty pre známku sú: A, B, C, D, E, Fx", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger newLog = new Logger();
                newLog.LogError(ex);
                return false;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
            
}
