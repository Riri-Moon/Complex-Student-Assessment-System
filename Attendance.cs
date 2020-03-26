using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;


/// <summary>
/// TODO: Ak mam zvolenu skupinu a vytvorim pre nu attendance tak to vytvori pre vsetkych!
/// </summary>
namespace CSAS
{
    public partial class Dochádzka : MaterialSkin.Controls.MaterialForm
    {
        StudentSkupina StudentSkup { get; set; }
        public Student DeleteStud { get; set; }
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Dochádzka(StudentSkupina studentSkupina)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            StudentSkup = studentSkupina;

            comboBox2.Items.Add("Prítomný");
            comboBox2.Items.Add("Neprítomný");
            comboBox2.Items.Add("Ospravedlnené");
            comboBox2.Items.Add("Zrušené");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var studs = con.GetTable<Student>();
                var kruzok = from stud in studs where stud.ID_stud_skupina == this.StudentSkup.Id select (string)stud.ID_Kruzok;
                kruzok.ToList<string>();
                comboBox1.Items.Add("Všetky");
                foreach (var kruz in kruzok.Distinct())
                {

                    comboBox1.Items.Add(kruz);
                }

            }

            comboBox1.SelectedItem = comboBox1.Items[0];
            GetAttendance();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {

        }

        private void Back_Att_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                                  select new { stud.Meno, att.Date, att.Status, att.Type, att.IdAttendance, stud.ID_Kruzok };

                    
                    if ((string)comboBox1.Text == "Všetky")
                    {
                        attGrid.DataSource = AttList.Where(t => t.Type == CheckType()).OrderByDescending(x => x.Date.Day);
                    }
                    else
                    {
                        attGrid.DataSource = AttList.Where(t => t.Type == CheckType() && t.ID_Kruzok == comboBox1.Text).OrderByDescending(x => x.Date.Day);
                    }
                    //attGrid.Columns["Type"].Visible = false;
                    attGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Get attendance table based on radiobutton in Attendance
        /// </summary>
//
      private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            GetAttendance();
        }
                
        /// <summary>
        /// Create attendance date 
        /// </summary>


        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {
                    IQueryable<Student> student;

                    if(comboBox1.SelectedIndex==0)
                    {
                        var studentId = con.GetTable<Student>().Where(x => x.Forma == StudentSkup.Forma);
                        student = studentId;
                    }
                    else
                    {
                        var studentId = con.GetTable<Student>().Where(x => x.Forma == StudentSkup.Forma && x.ID_Kruzok == (string)comboBox1.SelectedItem);
                        student = studentId;
                    }

                    foreach (var x in student)
                    {
                        var insert = new AttendanceStud
                        {
                            IDSkupina = this.StudentSkup.Id,
                            Type = CheckType(),
                            Date = dateTimePicker1.Value,
                            IDStudent = x.Id
                        };
                        var attend = con.GetTable<AttendanceStud>();
                        var AttList = from AttendanceStud in attend
                                      where AttendanceStud.Date == insert.Date && AttendanceStud.Type == insert.Type && AttendanceStud.IDStudent == insert.IDStudent
                                      select new { AttendanceStud.Type, AttendanceStud.Date };
                       
                        if (AttList.Count() == 0)
                        {

                            con.AttendanceStuds.InsertOnSubmit(insert);
                            con.SubmitChanges(ConflictMode.FailOnFirstConflict);
                        }
                        GetAttendance();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                    var selected = con.AttendanceStuds.Where(a => a.IdAttendance == (int)attGrid.CurrentRow.Cells[4].Value);

                    foreach (var x in selected)
                    {
                        con.AttendanceStuds.DeleteOnSubmit(x);
                    };
                    con.SubmitChanges();
                    GetAttendance();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nenašiel sa žiaden záznam.","Prázdna tabuľka");
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
                return "Prednáška";
            }
            else if (radioButton2.Checked)
            {
                return "Cvičenie";
            }
            return null;
        }

        /// <summary>
        /// Confirming student's attendance and moving one line below
        /// </summary>

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new StudentDBDataContext(conn_str))
                {


                    var type = CheckType();
                    AttendanceStud attendance = con.AttendanceStuds.Where(a => a.IdAttendance == (int)attGrid.CurrentRow.Cells[4].Value).FirstOrDefault();
                    var row = attGrid.CurrentRow.Index;
                    var cell = attGrid.CurrentCell.ColumnIndex;
                    attendance.Status = comboBox2.SelectedItem.ToString();
                    con.SubmitChanges();
                    GetAttendance();
                    this.attGrid.ClearSelection();
                    this.attGrid.CurrentCell.Selected = false;
                    this.attGrid.Rows[row + 1].Selected = true;
                    this.attGrid.Focus();

                    attGrid.CurrentCell = attGrid[cell, row + 1];

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
