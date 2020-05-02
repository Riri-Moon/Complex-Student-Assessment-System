using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using AutocompleteMenuNS;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Configuration;

namespace CSAS
{
    public partial class Dochádzka : MaterialSkin.Controls.MaterialForm
    {
        StudentSkupina StudentSkup { get; set; }
        public Student DeleteStud { get; set; }
        //        private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        Dictionary<string, int> studentsManual = new Dictionary<string, int>();
        public Dochádzka(StudentSkupina studentSkupina)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            StudentSkup = studentSkupina;

            //Pritomnost
            comboBox2.Items.Add("Prítomný");
            comboBox2.Items.Add("Neprítomný");
            comboBox2.Items.Add("Ospravedlnené");
            comboBox2.Items.Add("Zrušené");

            //Filter combobox
            comboBox4.Items.Add("Posledný deň");
            comboBox4.Items.Add("Všetka dochádzka");
            comboBox4.Items.Add("Dátum");
            comboBox4.Items.Add("Status");
            comboBox4.Items.Add("Krúžok");
            comboBox4.Items.Add("Študent");

            //
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.SelectedItem = comboBox4.Items[0];

            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var students = con.GetTable<Student>();
                var groups = con.GetTable<StudentSkupina>().Where(x => x.Id == StudentSkup.Id);
                var skup = from student in students where student.ID_stud_skupina == StudentSkup.Id select new { student.Meno, student.Priezvisko, student.Id };
                var kruzok = from stud in students where stud.ID_stud_skupina == StudentSkup.Id select (string)stud.ID_Kruzok;

                foreach (var stud in students.Where(x => x.ID_stud_skupina == StudentSkup.Id))
                {
                    comboBox3.Items.Add(RWS(stud.Meno) + " " + RWS(stud.Priezvisko));
                    studentsManual.Add(RWS(stud.Meno) + " " + RWS(stud.Priezvisko), stud.Id);
                }

                //Pridanie kruzkov do comboboxu
                var studs = con.GetTable<Student>();
                kruzok.ToList<string>();
                comboBox1.Items.Add("Všetky");
                foreach (var kruz in kruzok.Distinct())
                {
                    comboBox1.Items.Add(kruz);
                }

            }
            comboBox1.SelectedItem = comboBox1.Items[0];

            Filter();
        }

        /// Funkcia na odstranenie medzier z textu
        private string RWS(string text)
        {
            text = text.Replace(" ", string.Empty);
            return text;
        }

        private void Attendance_Load(object sender, EventArgs e)
        {

        }

        private void Back_Att_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Filter()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {                  

                    var attendance = con.GetTable<AttendanceStud>();
                    var students = con.GetTable<Student>();
                    con.Connection.Open();
                    var AttList = from att in attendance
                                  from stud in students
                                  where att.IDSkupina == StudentSkup.Id
                                  where stud.Id == att.IDStudent
                                  select new { stud.Meno, stud.Priezvisko, att.Date, att.Status, att.Type, att.IdAttendance, stud.ID_Kruzok, stud.Id };


                    var lastDate = AttList.Where(t => t.Type == CheckType()).OrderByDescending(x => x.Date).Select(x => x.Date);

                    switch (comboBox4.SelectedItem)
                    {                      
                        case "Posledný deň":
                            attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.Date == lastDate.FirstOrDefault());
                            comboBox5.Enabled = false;
                            break;

                        case "Všetka dochádzka":
                            attGrid.DataSource = AttList.Where(t => t.Type == CheckType()).OrderByDescending(x => x.Date);
                            comboBox5.Enabled = false;
                            break;

                        case "Dátum":
                            comboBox5.Items.Clear();
                            comboBox5.ResetText();

                            foreach (var date in lastDate.Distinct())
                            {
                                if (date != null)
                                {
                                    comboBox5.Items.Add(date);
                                }
                            }
                            comboBox5.Enabled = true;
                            break;

                        case "Status":
                            var statuses = AttList.Where(t => t.Type == CheckType()).Select(x => x.Status);
                            comboBox5.ResetText();
                            comboBox5.Items.Clear();

                            foreach (var stat in statuses.Distinct())
                            {
                                if (stat != null)
                                {
                                    comboBox5.Items.Add(stat);
                                }
                            }
                            comboBox5.Enabled = true;
                            break;

                        case "Krúžok":
                            var groups = AttList.Where(t => t.Type == CheckType()).Select(x => x.ID_Kruzok);
                            comboBox5.ResetText();
                            comboBox5.Items.Clear();

                            foreach (var grp in groups.Distinct())
                            {
                                if (grp != null)
                                {
                                    comboBox5.Items.Add(grp);
                                }
                            }
                            comboBox5.Enabled = true;
                            break;

                        case "Študent":
                            var studs = AttList.Where(t => t.Type == CheckType()).Select(x => x.Meno + " " + x.Priezvisko);
                            comboBox5.ResetText();
                            comboBox5.Items.Clear();

                            foreach (var std in studs.Distinct())
                            {
                                if (std != null)
                                {
                                    comboBox5.Items.Add(std);
                                }
                            }
                            comboBox5.Enabled = true;
                            break;

                    }
                    attGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    attGrid.Columns["Id"].Visible = false;
                    attGrid.Columns["IdAttendance"].Visible = false;
                    attGrid.MultiSelect = true;
                }
            }
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterBy()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    var attendance = con.GetTable<AttendanceStud>();
                    var students = con.GetTable<Student>();
                    con.Connection.Open();
                    var AttList = from att in attendance
                                  from stud in students
                                  where att.IDSkupina == StudentSkup.Id
                                  where stud.Id == att.IDStudent
                                  select new { stud.Meno, stud.Priezvisko, att.Date, att.Status, att.Type, att.IdAttendance, stud.ID_Kruzok, stud.Id };


                    var lastDate = AttList.Where(t => t.Type == CheckType()).OrderByDescending(x => x.Date).Select(x => x.Date);
                    var statuses = AttList.Where(t => t.Type == CheckType()).Select(x => x.Status);
                    var groups = AttList.Where(t => t.Type == CheckType()).Select(x => x.ID_Kruzok);
                    var studs = AttList.Where(t => t.Type == CheckType()).Select(x => x.Meno + " " + x.Priezvisko);

                    switch (comboBox4.SelectedItem)
                    {
                        case "Posledný deň":
                            attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.Date == lastDate.FirstOrDefault());
                            comboBox5.Enabled = false;
                            break;

                        case "Všetka dochádzka":
                            attGrid.DataSource = AttList.Where(t => t.Type == CheckType()).OrderByDescending(x => x.Date);
                            comboBox5.Enabled = false;
                            break;

                        case "Dátum":

                            if (comboBox5.SelectedItem != null)
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.Date == (DateTime)comboBox5.SelectedItem);
                            }
                            else
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType());
                            }
                            comboBox5.Enabled = true;
                            break;

                        case "Status":
                           
                            if (!string.IsNullOrEmpty((string)comboBox5.SelectedItem))
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.Status == (string)comboBox5.SelectedItem);
                            }
                            else
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.Status == string.Empty);
                            }
                            comboBox5.Enabled = true;
                            break;

                        case "Krúžok":
                          
                            if (!string.IsNullOrEmpty((string)comboBox5.SelectedItem))
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.ID_Kruzok == (string)comboBox5.SelectedItem);
                            }
                            else
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType());
                            }
                            comboBox5.Enabled = true;
                            break;

                        case "Študent":
                            
                            if (!string.IsNullOrEmpty((string)comboBox5.SelectedItem))
                            {
                                attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.Meno + " " + t.Priezvisko == (string)comboBox5.SelectedItem);
                            }
                            comboBox5.Enabled = true;
                            break;

                        default:
                            attGrid.DataSource = AttList.Where(t => t.Type == CheckType());
                            break;
                    }
                    attGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    attGrid.Columns["IdAttendance"].Visible = false;
                    attGrid.Columns["Id"].Visible = false;
                    //attGrid.Columns["Comment"].Visible = false;
                    attGrid.MultiSelect = true;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Odstranit ak nebude potrebne
        /// </summary>
        private void GetAttendance()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    var attendance = con.GetTable<AttendanceStud>();
                    var students = con.GetTable<Student>();
                    con.Connection.Open();
                    var AttList = from att in attendance
                                  from stud in students
                                  where att.IDSkupina == StudentSkup.Id
                                  where stud.Id == att.IDStudent
                                  select new { stud.Meno, stud.Priezvisko, att.Date, att.Status, att.Type, att.IdAttendance, stud.ID_Kruzok, stud.Id };
                    attGrid.DataSource = AttList.Where(t => t.Type == CheckType()).OrderByDescending(x => x.Date.Day);


                    if ((string)comboBox1.Text == "Všetky")
                    {
                        AttList.Where(t => t.Type == CheckType());
                    }
                    else
                    {
                        attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.ID_Kruzok == comboBox1.Text).OrderByDescending(x => x.Date.Day);
                    }
                    attGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    attGrid.Columns["IdAttendance"].Visible = false;
                    attGrid.Columns["Id"].Visible = false;
                    attGrid.MultiSelect = true;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {            
            FilterBy();
            ResetLabels();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    IQueryable<Student> student;
                  
                    Nullable<int> idStud;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        var studentId = con.GetTable<Student>().Where(x => x.Forma == StudentSkup.Forma && x.ID_stud_skupina ==StudentSkup.Id);
                        student = studentId;
                        if(student.Count() <=0)
                        {
                            MessageBox.Show("Nenašiel sa žiaden študent");
                            return;
                        }
                    }
                    else
                    {
                        var studentId = con.GetTable<Student>().Where(x => x.Forma == StudentSkup.Forma && x.ID_stud_skupina==StudentSkup.Id &&x.ID_Kruzok == (string)comboBox1.SelectedItem);
                        student = studentId;
                        if (student.Count() <= 0)
                        {
                            MessageBox.Show("Nenašiel sa žiaden študent");
                            return;
                        }
                    }

                    foreach (var x in student)
                    {
                        var insert = new AttendanceStud
                        {
                            IDSkupina = this.StudentSkup.Id,
                            Type = CheckType(),
                            Date = dateTimePicker1.Value,
                            IDStudent = x.Id,
                            IdGroup = x.ID_Kruzok,
                            Comment = string.Empty
                        };
                        var attend = con.GetTable<AttendanceStud>();
                        var AttList = from AttendanceStud in attend
                                      where insert.IDSkupina == AttendanceStud.IDSkupina && AttendanceStud.Date == insert.Date && AttendanceStud.Type == insert.Type && AttendanceStud.IDStudent == insert.IDStudent
                                      select new { AttendanceStud.Type, AttendanceStud.Date };

                        if (AttList.Count() == 0)
                        {
                            con.AttendanceStuds.InsertOnSubmit(insert);
                            con.SubmitChanges(ConflictMode.FailOnFirstConflict);
                        }
                        //GetAttendance();
                        Filter();
                        if ((int?)attGrid.CurrentRow.Cells[7].Value != null)
                        {
                            idStud = (int?)attGrid.CurrentRow.Cells[7].Value;
                            if (idStud != null)
                            {
                                PresenceCounter(idStud.GetValueOrDefault());
                            }
                        }                        
                    }
                    ResetLabels();
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove selected student's attendance
        /// </summary>


        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    var attend = con.GetTable<AttendanceStud>();
                    var stud = con.GetTable<Student>();

                    var selected = con.AttendanceStuds.Where(a => a.IDSkupina ==StudentSkup.Id && a.IdAttendance == (int)attGrid.CurrentRow.Cells[5].Value && a.Type == CheckType());
                    var totalAttendance = con.GetTable<TotalAttendance>().Where(x =>x.IdStudent == (int)attGrid.CurrentRow.Cells[7].Value).FirstOrDefault();

                    Nullable<int> idStud = selected.FirstOrDefault().IDStudent;

                    foreach (var x in selected)
                    {
                        var date = GetLatestDate((int)attGrid.CurrentRow.Cells[7].Value);

                        switch (x.Status)
                        {
                            case "Neprítomný":
                                if (x.Type == "Cvičenie" && !x.IsReplacable)
                                {
                                    if (date != null)
                                    {
                                        var attDate = con.AttendanceStuds.Where(a => a.IDSkupina==StudentSkup.Id && a.IDStudent == (int)attGrid.CurrentRow.Cells[7].Value && a.Date == date && a.Type == "Cvičenie" && a.Status == "Nahradené").FirstOrDefault();
                                        if (attDate != null)
                                        {
                                            attDate.IsReplacable = true;
                                        }
                                    }
                                }
                                break;

                            case "Nahradené":
                                date = GetClosestAbsentDate((int)attGrid.CurrentRow.Cells[7].Value, x);
                                if (!x.IsReplacable)
                                {
                                    var id = (int)attGrid.CurrentRow.Cells[7].Value;
                                    var attDate = con.AttendanceStuds.Where(a => a.IDSkupina==StudentSkup.Id && a.IDStudent == id && a.Date == date && a.Type == "Cvičenie" && a.Status == "Neprítomný").FirstOrDefault();

                                    if (attDate != null)
                                    {
                                        attDate.IsReplacable = true;
                                    }
                                }
                                break;

                            default: break;
                        }
                        if ((int?)attGrid.CurrentRow.Cells[7].Value != null)
                        {
                            idStud = (int?)attGrid.CurrentRow.Cells[7].Value;
                        }
                            con.AttendanceStuds.DeleteOnSubmit(x);


                    };
                    con.SubmitChanges();
                    Filter();
                    if (idStud != null)
                    {
                        PresenceCounter(idStud.GetValueOrDefault());
                    }
                    ResetLabels();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Nenašiel sa žiaden záznam.", "Prázdna tabuľka");
            }
        }
        /// <summary>
        /// Check what type of attendance is selected and based on this data will be shown
        /// </summary>
        /// <returns></returns>
        private string CheckType()
        {
            if (radioButton1.Checked)
            {
                if (comboBox2.Items.Contains("Nahradené"))
                {
                    comboBox2.Items.Remove("Nahradené");
                    Filter();
                }
                return "Prednáška";
            }
            else if (radioButton2.Checked)
            {
                if (!comboBox2.Items.Contains("Nahradené"))
                {
                    comboBox2.Items.Add("Nahradené");
                    Filter();
                }
                return "Cvičenie";
            }
            return null;
        }

        //Najdenie najblizsieho datumu kde studen chybal na cviceni
        private Nullable<DateTime> GetClosestAbsentDate(int studentId, AttendanceStud attend)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    var attendance = con.AttendanceStuds.Where(a => a.IDSkupina==StudentSkup.Id && a.IDStudent == studentId && a.Type == "Cvičenie" && a.Status == "Neprítomný");

                    var date = attendance.Select(x => x.Date).OrderByDescending(x => x.Date);
                    if (date.Count() > 0)
                    {
                        if (DateInsideOneWeek(date.FirstOrDefault(), attend.Date))
                        {
                            var closestDate = date.FirstOrDefault();
                            return closestDate;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Nullable<DateTime> GetLatestDate(int studentId)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    var attendance = con.AttendanceStuds.Where(a => a.IDSkupina==StudentSkup.Id && a.IDStudent == studentId && a.Type == "Cvičenie");

                    var date = attendance.Select(x => x.Date).OrderByDescending(x => x.Date);
                    if (date.Count() > 1)
                    {
                        if (DateInsideOneWeek(date.FirstOrDefault(), date.Skip(1).FirstOrDefault()))
                        {
                            var closestDate = date.Skip(1).FirstOrDefault();
                            return closestDate;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);

                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        int globalRowIndex = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    var type = CheckType();

                    if(attGrid.Rows.Count<=0)
                    {
                        MessageBox.Show("Nie je vytvorený žiaden záznam");
                        return;
                    }

                    if (attGrid.SelectedRows.Count<=0)
                    {
                        MessageBox.Show("Nie je vybraný žiaden záznam.");
                        return;
                    }
                    foreach (DataGridViewRow selected in attGrid.SelectedRows)
                    {
                        AttendanceStud attendance = con.AttendanceStuds.Where(a => a.IDSkupina == StudentSkup.Id && a.IdAttendance == (int)selected.Cells[5].Value).FirstOrDefault();
                        var totalAttendance = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == (int)selected.Cells[7].Value).FirstOrDefault();
                        if (attendance == null)
                        {
                            MessageBox.Show("Nie je vybraný žiaden záznam.");
                            return;
                        }
                        if (totalAttendance == null)
                        {
                            MessageBox.Show("Nenašiel sa záznam o celkovej dochádzke, ak máte pridaných študentov, skúste reštartovať aplikáciu","Chyba",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        attendance.Status = comboBox2.SelectedItem.ToString();
                        AttendanceStud attDate;
                        var date = GetLatestDate((int)selected.Cells[7].Value);
                        switch (comboBox2.SelectedItem.ToString())
                        {
                            case "Neprítomný":

                                if (attendance.Type == "Cvičenie" && date == null)
                                {
                                    attendance.IsReplacable = true;
                                }
                                else if (attendance.Type == "Cvičenie" && date != null)
                                {
                                    attDate = con.AttendanceStuds.Where(a => a.IDSkupina == StudentSkup.Id && a.IDStudent == (int)selected.Cells[7].Value && a.Date == date && a.Type == "Cvičenie").FirstOrDefault();

                                    if (attDate.Status == "Nahradené" && attDate.IsReplacable)
                                    {
                                        attDate.IsReplacable = false;
                                        attendance.IsReplacable = false;
                                    }
                                    else
                                    {
                                        attendance.IsReplacable = true;
                                    }
                                }
                                break;

                            case "Nahradené":
                                date = GetLatestDate((int)selected.Cells[7].Value);
                                attDate = con.AttendanceStuds.Where(a =>a.IDSkupina == StudentSkup.Id && a.IDStudent == (int)selected.Cells[7].Value && a.Date == date && a.Type == "Cvičenie").FirstOrDefault();

                                if (attDate != null)
                                {
                                    if (CheckType() == "Cvičenie" && attDate.IsReplacable == true && RWS(attDate.Status) == "Neprítomný" || attDate.Status == "Ospravedlnené")
                                    {
                                        attDate.IsReplacable = false;
                                        attendance.IsReplacable = false;
                                    }
                                    else
                                    {
                                        attendance.IsReplacable = true;

                                    }
                                }
                                else if (attendance.Type == "Cvičenie")
                                {
                                    attendance.IsReplacable = true;
                                }
                                con.SubmitChanges();
                                break;

                            case "Zrušené":
                                attendance.IsReplacable = false;
                                break;
                            case "Ospravedlnené":

                                if (attendance.Type == "Cvičenie" && date == null)
                                {
                                    attendance.IsReplacable = true;
                                }
                                else if (attendance.Type == "Cvičenie" && date != null)
                                {
                                    attDate = con.AttendanceStuds.Where(a =>a.IDSkupina == StudentSkup.Id && a.IDStudent == (int)selected.Cells[7].Value && a.Date == date && a.Type == "Cvičenie").FirstOrDefault();

                                    if (attDate.Status == "Nahradené" && attDate.IsReplacable)
                                    {
                                        attDate.IsReplacable = false;
                                        attendance.IsReplacable = false;
                                    }
                                    else
                                    {
                                        attendance.IsReplacable = true;
                                    }
                                }
                                break;

                            default: break;
                        }
                        globalRowIndex = selected.Index;                       
                        con.SubmitChanges();
                        PresenceCounter((int)selected.Cells[7].Value);
                        ResetLabels();

                      
                    }

                    if (comboBox5.Text != string.Empty)
                    {
                        var value = comboBox5.SelectedItem;
                        FilterBy();
                        comboBox5.SelectedItem = value;
                    }
                    else
                    {
                        Filter();
                    }
                                        
                    this.attGrid.ClearSelection();
                    this.attGrid.CurrentCell.Selected = false;

                    try
                    {
                        this.attGrid.Rows[globalRowIndex + 1].Selected = true;
                        this.attGrid.Focus();
                    }
                    catch (Exception)
                    {
                    }
                    if (comboBox2.Text == "Zrušené")
                    {
                        IQueryable<AttendanceStud> attCancelled;
                        var cancelledComment = Interaction.InputBox("Uveďte dôvod zrušenia výučby", "Dôvod zrušenia", "Zrušená hodina", -1, -1);
                        


                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                attCancelled = con.AttendanceStuds.Where(a =>a.IDSkupina == StudentSkup.Id &&  a.Type == CheckType() && a.Date == (DateTime)attGrid.CurrentRow.Cells[2].Value);
                                break;

                            default:
                                attCancelled = con.AttendanceStuds
                              .Where(a => a.IDSkupina == StudentSkup.Id && a.Type == CheckType() && a.Date == (DateTime)attGrid.CurrentRow.Cells[2].Value && a.Student.ID_Kruzok == comboBox1.Text);
                                break;
                        }
                        foreach (var x in attCancelled)
                        {
                            x.Status = comboBox2.Text;
                            x.Comment = cancelledComment;
                            con.SubmitChanges();
                        }
                        Filter();
                    }
                    ResetLabels();
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool DateInsideOneWeek(DateTime date1, DateTime date2)
        {
            DayOfWeek firstDayOfWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime startDateOfWeek = date1.Date;
            while (startDateOfWeek.DayOfWeek != firstDayOfWeek)
            { startDateOfWeek = startDateOfWeek.AddDays(-1d); }
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6d);
            return date2 >= startDateOfWeek && date2 <= endDateOfWeek;
        }

        private void AddManualAttendanceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)comboBox3.SelectedValue != string.Empty)
                {
                    using (var con = new StudentDBDataContext(conn_str))
                    {
                        var student = studentsManual.TryGetValue(comboBox3.Text, out int value);
                        var std = con.GetTable<Student>().Where(x => x.Id == value).FirstOrDefault();
                        if(std ==null)
                        {
                            MessageBox.Show("Nie je vybraný žiaden študent");
                            return;
                        }
                        var insert = new AttendanceStud
                        {
                            IDSkupina = this.StudentSkup.Id,
                            Type = CheckType(),
                            Date = dateTimePicker1.Value,
                            IDStudent = value,
                            IdGroup = std.ID_Kruzok,
                            Comment = string.Empty
                        };
                        var attend = con.GetTable<AttendanceStud>();
                        var AttList = from AttendanceStud in attend
                                      where insert.IDSkupina == AttendanceStud.IDSkupina && AttendanceStud.Date == insert.Date && AttendanceStud.Type == insert.Type && AttendanceStud.IDStudent == insert.IDStudent
                                      select new { AttendanceStud.Type, AttendanceStud.Date };

                        if (AttList.Count() == 0)
                        {
                            con.AttendanceStuds.InsertOnSubmit(insert);
                            con.SubmitChanges(ConflictMode.FailOnFirstConflict);
                        }
                        Filter();
                        ResetLabels();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void attGrid_SelectionChanged(object sender, EventArgs e)
        {           
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    if (attGrid.SelectedRows.Count != 0)
                    {
                        PresenceCounter((int)attGrid.CurrentRow.Cells[7].Value);
                        ResetLabels();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                //return;
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.","Chyba",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// zobrazenie labels zobrazene v Attendance s aktualnymi hodnotami
        /// </summary>
        private void ResetLabels()
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    if (attGrid.SelectedRows.Count > 0)
                    {
                        var labels = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == (int)attGrid.CurrentRow.Cells[7].Value).FirstOrDefault();
                        if (CheckType() == "Prednáška")
                        {
                            NameOfStudLabel.Text = labels.Student.Meno + " " + labels.Student.Priezvisko;
                            TotalLabel.Text = labels.TotalLecture.ToString();
                            TotalPresentLabel.Text = labels.TotalPresentLecture.ToString();
                            TotalAbsentLabel.Text = labels.TotalAbsentLecture.ToString();
                        }
                        else
                        {
                            NameOfStudLabel.Text = labels.Student.Meno + " " + labels.Student.Priezvisko;
                            TotalLabel.Text = labels.TotalSeminar.ToString();
                            TotalPresentLabel.Text = labels.TotalPresentSeminar.ToString();
                            TotalAbsentLabel.Text = labels.TotalAbsentSeminar.ToString();
                        }
                    }
                    else if (CheckType() == "Prednáška")
                    {
                        NameOfStudLabel.Text = string.Empty;
                        TotalLabel.Text = 0.ToString();
                        TotalPresentLabel.Text = 0.ToString();
                        TotalAbsentLabel.Text = 0.ToString();
                    }
                    else
                    {
                        NameOfStudLabel.Text = string.Empty;
                        TotalLabel.Text = 0.ToString();
                        TotalPresentLabel.Text = 0.ToString();
                        TotalAbsentLabel.Text = 0.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PresenceCounter(int studentId)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    var getAttendance = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == StudentSkup.Id && x.IDStudent == studentId);

                    var stud = con.GetTable<Student>().Where(f => f.Id == studentId).FirstOrDefault();
                    var z = con.GetTable<TotalAttendance>().Where(x => x.IdStudent == studentId).FirstOrDefault();
                    List<DateTime> dateList = new List<DateTime>();

                    z.TotalAbsentLecture = 0;
                    z.TotalPresentLecture = 0;
                    z.TotalExcusedLecture = 0;

                    z.TotalPresentSeminar = 0;
                    z.TotalExcusedSeminar = 0;
                    z.TotalAbsentSeminar = 0;

                    con.SubmitChanges();
                    
                    z.TotalLecture = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == StudentSkup.Id && x.IdGroup == stud.ID_Kruzok && x.Type == "Prednáška").Select(x => x.Date).Distinct().Count();
                    var xxx = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == StudentSkup.Id && x.IdGroup == stud.ID_Kruzok && x.Type == "Cvičenie");

                    foreach( var o in xxx)
                    {
                        if (o.Status!= "Nahradené")
                        {
                            dateList.Add(o.Date);
                        }
                    }
                    if (dateList.Count > 0)
                    {
                        z.TotalSeminar = dateList.Distinct().Count();
                    }
                       // z.TotalSeminar// = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == StudentSkup.Id && x.IdGroup == stud.ID_Kruzok && x.Type == "Cvičenie").Select(x => x.Date).Distinct().Count();
                    
                    foreach (var att in getAttendance)
                    {
                        if (att.Status == "Prítomný" && att.Type == "Prednáška")
                        {
                            z.TotalPresentLecture += 1;
                        }
                        if (att.Status == "Prítomný" && att.Type == "Cvičenie")
                        {
                            z.TotalPresentSeminar += 1;
                        }
                        if (att.Status == "Neprítomný" && att.Type == "Prednáška")
                        {
                            z.TotalAbsentLecture += 1;
                        }
                        if (att.Status == "Neprítomný" && att.Type == "Cvičenie" && att.IsReplacable)
                        {
                            z.TotalAbsentSeminar += 1;
                        }
                        if (att.Status == "Neprítomný" && att.Type == "Cvičenie" && !att.IsReplacable)
                        {
                            continue;
                        }
                        if (att.Status == "Nahradené" && att.Type == "Cvičenie" && att.IsReplacable)
                        {
                            z.TotalPresentSeminar += 1;
                        }
                        if (att.Status == "Nahradené" && att.Type == "Cvičenie" && !att.IsReplacable)
                        {
                            if (z.TotalAbsentSeminar > 0)
                            {
                                z.TotalAbsentSeminar -= 1;
                            }
                  /// Ak je last day nepritomny a !IsReplacable
                            z.TotalPresentSeminar += 1;
                        }
                        if (att.Status == "Ospravedlnené" && att.Type == "Cvičenie")// && !att.IsReplacable)
                        {
                            z.TotalExcusedSeminar += 1;
                            z.TotalAbsentSeminar += 1;
                        }
                        if (att.Status == "Ospravedlnené" && att.Type == "Prednáška")
                        {
                            z.TotalExcusedLecture += 1;
                            z.TotalAbsentLecture += 1;
                        }
                        if (att.Status == "Zrušené" && att.Type == "Prednáška")
                        {
                            if (z.TotalLecture > 0)
                                z.TotalLecture -= 1;
                        }
                        if (att.Status == "Zrušené" && att.Type == "Cvičenie")
                        {
                            if (z.TotalSeminar > 0)
                                z.TotalSeminar -= 1;
                        }
                        con.SubmitChanges();
                        ResetLabels();
                    }
                    con.SubmitChanges();
                    ResetLabels();
                }
            }
            catch(Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show("Nastala chyba, viac informácii nájdete v logoch.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_attendance_Click(object sender, EventArgs e)
        {

        }

        private void NameOfStudLabel_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
            ResetLabels();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterBy();
            ResetLabels();
        }
    }
}