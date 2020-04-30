using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace CSAS
{
    public partial class ExportForm : MaterialSkin.Controls.MaterialForm
    {
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        StudentSkupina group;
        BackgroundWorker m_oWorker;
        User currentUser;
        Dictionary<string, int> studDict = new Dictionary<string, int>();
        Dictionary<string, DateTime> actDict = new Dictionary<string, DateTime>();
        /// <summary>
        /// Global variables for backgroundworker export
        /// </summary>
        IQueryable<Activity> globalActivities;
        IQueryable<Student> globalStudents;
        IQueryable<FinalGrade> globalFinalGrades;
        IQueryable<AttendanceStud> globalAttendances;
        DateTime globalDate;
        string globalActivityName;
        string globalFilter;
        string globalGroupId;
        string globalPath;
        string globalStatus;
        string globalType;

        public ExportForm(StudentSkupina skupina, User user)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);
            group = skupina;
            currentUser = user;

            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            ActivityFilter.Items.Add("Všetky");
            ActivityFilter.Items.Add("Aktivita");
            ActivityFilter.SelectedIndex = 0;
            StudentFilter.Items.Add("Všetko");
            StudentFilter.Items.Add("Krúžok");
            StudentFilter.Items.Add("Študent");
            StudentFilter.SelectedIndex = 0;

            materialCheckedListBox1.Items.Add("Isic", true);
            materialCheckedListBox1.Items.Add("Meno", true);
            materialCheckedListBox1.Items.Add("Priezvisko", true);
            materialCheckedListBox1.Items.Add("Email", true);
            materialCheckedListBox1.Items.Add("Email Ucm", false);
            materialCheckedListBox1.Items.Add("Ročník", true);
            materialCheckedListBox1.Items.Add("Forma", false);
            materialCheckedListBox1.Items.Add("Krúžok", true);
            materialCheckedListBox1.Items.Add("Študíjny program", false);

            materialCheckedListBox2.Items.Add("Názov aktivity", true);
            materialCheckedListBox2.Items.Add("Id aktivity", false);
            materialCheckedListBox2.Items.Add("Dátum odovzdania", true);
            materialCheckedListBox2.Items.Add("Maximum bodov", true);
            materialCheckedListBox2.Items.Add("Získané body", true);
            materialCheckedListBox2.Items.Add("Komentár - aktivita", true);

            materialCheckedListBox3.Items.Add("Názov úlohy", true);
            materialCheckedListBox3.Items.Add("Maximálne Bodov", true);
            materialCheckedListBox3.Items.Add("Získaných bodov", true);
            materialCheckedListBox3.Items.Add("Id študent", false);
            materialCheckedListBox3.Items.Add("Id aktivita", false);
            materialCheckedListBox3.Items.Add("Komentár - úloha", true);

            materialCheckedListBox4.Items.Add("Maximum bodov za semester", true);
            materialCheckedListBox4.Items.Add("Získal bodov", true);
            materialCheckedListBox4.Items.Add("Vymeškaných prednášok", true);
            materialCheckedListBox4.Items.Add("Vymeškaných cvičení", true);
            materialCheckedListBox4.Items.Add("Aktivita prednáška", true);
            materialCheckedListBox4.Items.Add("Aktivita cvičenie", true);
            materialCheckedListBox4.Items.Add("Známka", true);

            materialCheckedListBox5.Items.Add("Dátum", true);
            materialCheckedListBox5.Items.Add("Status", true);
            materialCheckedListBox5.Items.Add("Typ", true);
            materialCheckedListBox5.Items.Add("Komentár", true);

            FilterAttendance.Items.Add("Všetko");
            FilterAttendance.Items.Add("Typ");
            FilterAttendance.Items.Add("Status");
            FilterAttendance.Items.Add("Dátum");
            FilterAttendance.SelectedIndex = 0;


            OnCheckedChanged(materialCheckedListBox1, Event);
            OnCheckedChanged(materialCheckedListBox2, Event);
            OnCheckedChanged(materialCheckedListBox3, Event);

            ExportCombo.Items.Add("Aktivita");
            ExportCombo.Items.Add("Dochádzka");
            ExportCombo.Items.Add("Finálne hodnotenie");
            ExportCombo.SelectedIndex = 0;

        }



        private void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("V procese exportu nastala chyba", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                ExportVisible(false);
                return;
            }
            else
            {
                var file = new SaveFileDialog();
                file.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                file.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                file.AddExtension = true;
                file.DefaultExt = ".xlsx";
                DialogResult result = file.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var table = (DataTable)e.Result;
                    XLWorkbook workbook = new XLWorkbook();
                    var sheet = workbook.AddWorksheet(table, "Export");
                    sheet.Columns().AdjustToContents();
                    workbook.SaveAs(file.FileName);
                    MessageBox.Show(file.FileName);
                }
            }
            ExportVisible(false);
        }


        private void TotalAttendanceExcelExport(object sender, DoWorkEventArgs e)
        {
            DataTable table = new DataTable();

            //Counters for columns 
            int studentColumnsCount = 0;
            int attendanceColumnsCount = 0;
            int generalCount = 0;

            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var students = globalStudents;
                var attendances = globalAttendances;

                if (students == null)
                {
                    MessageBox.Show("Nenašiel sa žiaden študent");
                    e.Cancel = true;
                    return;
                }
                if (attendances == null)
                {
                    MessageBox.Show("Nenašiel sa žiaden záznam o dochádzke");
                    e.Cancel = true;
                    return;
                }

                //Adding  Student columns
                foreach (var item in materialCheckedListBox1.Items)
                {
                    if (item.Checked)
                    {
                        table.Columns.Add(item.Text);
                        studentColumnsCount++;
                    }
                }

                /// Adding activity columns
                foreach (var item in materialCheckedListBox5.Items)
                {
                    if (item.Checked)
                    {
                        table.Columns.Add(item.Text);
                        attendanceColumnsCount++;
                    }
                }

                //Progress reporting
                int studCount = 0;
                int progress = 0;
                int progressPerPerson = 100 / students.Count();

                foreach (var stud in students)
                {

                    if (m_oWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        m_oWorker.ReportProgress(0);
                        return;
                    }

                    studCount++;
                    progress += (int)progressPerPerson;
                    m_oWorker.ReportProgress(progress);
                    var row = table.NewRow();
                    ///Student rows
                    generalCount = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        if (generalCount < studentColumnsCount)
                        {
                            generalCount++;
                            dbNames.TryGetValue(column.ColumnName, out string val);
                            PropertyInfo item = typeof(Student).GetProperty(val);
                            var st = students.Where(x => x.Id == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();
                            row[column.ColumnName] = st;
                        }
                        else
                        {
                            break;
                        }
                    }
                    table.Rows.Add(row);

                    //Activity rows
                    if (attendanceColumnsCount > 0)
                    {
                        foreach (var attendance in attendances.Where(x => x.IDStudent == stud.Id))
                        {
                           row= table.NewRow();

                            generalCount = 0;
                            foreach (DataColumn col in table.Columns)
                            {
                                if (generalCount >= studentColumnsCount)
                                {
                                    if (generalCount < (studentColumnsCount + attendanceColumnsCount))
                                    {
                                        generalCount++;
                                        dbNames.TryGetValue(col.ColumnName, out string val);
                                        PropertyInfo item = typeof(AttendanceStud).GetProperty(val);
                                        string attendanceToExcel = attendances.Where(x => x.IdAttendance == attendance.IdAttendance && x.IDStudent == stud.Id).
                                            Select(activ => activ != null ? item.GetValue(activ).ToString() : "").DefaultIfEmpty().FirstOrDefault();
                                        row[col.ColumnName] = attendanceToExcel;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    generalCount++;
                                    continue;
                                }
                            }
                            table.Rows.Add(row);

                        }
                    }
                }
                e.Result = table;
            }
        }

        private void TotalAttendancePdfExport(object sender, DoWorkEventArgs e)
        {
            var stream = new FileStream(globalPath, FileMode.Create);
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);

            PdfFont roboto = PdfFontFactory.CreateFont(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Roboto-Light.ttf", PdfEncodings.IDENTITY_H);
            PdfFont robotoHeader = PdfFontFactory.CreateFont(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Roboto-Bold.ttf", PdfEncodings.IDENTITY_H);

            Document doc = null;
            var ct = 0;
            ct += materialCheckedListBox1.Items.Where(x => x.Checked == true).Count();
            ct += materialCheckedListBox5.Items.Where(x => x.Checked == true).Count();

            if (ct <= 9 && ct > 0)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A4.Rotate());
                doc = new Document(pdf, PageSize.A4.Rotate());
            }
            else if (ct > 9 && ct <= 13)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A3.Rotate());
                doc = new Document(pdf, PageSize.A3.Rotate());
            }
            else if (ct > 13)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A2.Rotate());
                doc = new Document(pdf, PageSize.A2.Rotate());
            }
            else
            {
                MessageBox.Show("Aspoň 1 stĺpec musí byť vybratý.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int studentColumnsCount = 0;
                int attendancesColumnsCount = 0;
                int generalCount = 0;

                var studDict = new Dictionary<int, string>();
                var attDict = new Dictionary<int, string>();

                Table table = new Table(ct);

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var students = globalStudents;
                    var attendances = globalAttendances;

                    if (students.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden študent");
                        e.Cancel = true;
                        return;
                    }
                    if (attendances.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden záznam o dochádzke");
                        e.Cancel = true;
                        return;
                    }

                    //Adding  Student columns
                    foreach (var item in materialCheckedListBox1.Items)
                    {
                        if (item.Checked)
                        {
                            Cell cell = new Cell().Add((new Paragraph().Add(item.Text.ToString()))).SetFont(robotoHeader);
                            table.AddHeaderCell(cell);
                            studDict.Add(studentColumnsCount, item.Text);
                            studentColumnsCount++;
                        }
                    }
                    /// Adding activity columns
                        foreach (var item in materialCheckedListBox5.Items)
                        {
                            if (item.Checked)
                            {
                                Cell cell = new Cell().Add((new Paragraph(item.Text.ToString()).SetFont(robotoHeader)));
                                table.AddHeaderCell(cell);
                                attDict.Add(attendancesColumnsCount, item.Text);
                                attendancesColumnsCount++;
                            }
                        }

                    table.StartNewRow();
                    int studCount = 0;
                    int progress = 0;
                    int progressPerPerson = 100 / students.Count();
                    foreach (var stud in students)
                    {

                        if (m_oWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            m_oWorker.ReportProgress(0);
                            return;
                        }

                        studCount++;
                        progress += (int)progressPerPerson;
                        m_oWorker.ReportProgress(progress);

                        generalCount = 0;
                        for (int i = 0; i < (studentColumnsCount + attendancesColumnsCount); i++)
                        {
                            if (generalCount < studentColumnsCount)
                            {
                                generalCount++;

                                var name = studDict.TryGetValue(i, out string value);
                                dbNames.TryGetValue(value, out string val);
                                PropertyInfo item = typeof(Student).GetProperty(val);
                                var st = students.Where(x => x.Id == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();

                                Cell cell = new Cell().Add(new Paragraph(st).SetFont(roboto));
                                table.AddCell(cell);
                            }
                            else
                            {
                                Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                table.AddCell(cell);
                            }
                        }
                        if (attendancesColumnsCount > 0)
                        {
                            foreach (var attendance in attendances.Where(x => x.IDStudent == stud.Id))
                            {

                                generalCount = 0;
                                table.StartNewRow();
                                for (int i = 0; i <= (studentColumnsCount + attendancesColumnsCount) - 1; i++)
                                {
                                    if (generalCount >= studentColumnsCount)
                                    {
                                        if (generalCount < (studentColumnsCount + attendancesColumnsCount))
                                        {
                                            generalCount++;
                                            var name = attDict.TryGetValue(i - studentColumnsCount, out string value);
                                            dbNames.TryGetValue(value, out string val);
                                            PropertyInfo item = typeof(AttendanceStud).GetProperty(val);
                                            string attToPdf = attendances.Where(x => x.IdAttendance == attendance.IdAttendance && x.IDStudent == stud.Id).
                                                Select(activ => activ != null ? item.GetValue(activ).ToString() : "").DefaultIfEmpty().FirstOrDefault();
                                            Cell cell = new Cell().Add(new Paragraph(attToPdf).SetFont(roboto));
                                            table.AddCell(cell);
                                        }
                                        else
                                        {
                                            Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                            table.AddCell(cell);
                                        }
                                    }
                                    else
                                    {
                                        Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                        table.AddCell(cell);
                                        generalCount++;
                                    }
                                }

                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                doc.Add(table);
                doc.Close();
                m_oWorker.ReportProgress(100);
            }
            catch (Exception ex)
            {
                doc.Close();
                e.Cancel = true;
                MessageBox.Show(ex.ToString());
            }
        }

        private IQueryable<AttendanceStud> GetAttendances()
        {
            IQueryable<AttendanceStud> attendances = null;
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
                switch (FilterAttendance.SelectedIndex) {
                case 0:
                    if (StudentFilter.SelectedIndex == 0)
                    {
                        attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id);
                    }
                    else if (StudentFilter.SelectedIndex == 1)
                    {
                        if (FilterStudent.SelectedItem != null)
                        {
                            globalGroupId = string.Empty;
                            globalGroupId = (string)FilterStudent.SelectedItem;
                             attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IdGroup == globalGroupId);
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 2)
                    {
                        if (FilterStudent.SelectedItem != null)
                        {
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IDStudent == studId);
                        }
                    }
                    break;
                case 1:
                    if (StudentFilter.SelectedIndex == 0)
                    {
                        if (SubFilterAttendance.SelectedItem != null)
                        {
                            globalType = string.Empty;
                            globalType = (string)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.Type == globalType);

                        }
                    }
                    else if (StudentFilter.SelectedIndex == 1)
                    {
                        if (FilterStudent.SelectedItem != null && SubFilterAttendance.SelectedItem != null)
                        {
                            globalGroupId = string.Empty;
                            globalGroupId = (string)FilterStudent.SelectedItem;
                            globalType = string.Empty;
                            globalType = (string)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IdGroup == globalGroupId && x.Type==globalType);
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 2)
                    {
                        if (FilterStudent.SelectedItem != null && SubFilterAttendance.SelectedItem != null)
                        {
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            globalType = string.Empty;
                            globalType = (string)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IDStudent == studId && x.Type==globalType);
                        }
                    }
                    break;
                case 2:
                    if (StudentFilter.SelectedIndex == 0)
                    {
                        if (SubFilterAttendance.SelectedItem != null)
                        {
                            globalStatus = string.Empty;
                            globalStatus = (string)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.Status == globalStatus);

                        }
                    }
                    else if (StudentFilter.SelectedIndex == 1)
                    {
                        if (FilterStudent.SelectedItem != null && SubFilterAttendance.SelectedItem != null)
                        {
                            globalGroupId = string.Empty;
                            globalGroupId = (string)FilterStudent.SelectedItem;
                            globalStatus = string.Empty;
                            globalStatus = (string)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IdGroup == globalGroupId && x.Status == globalStatus);
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 2)
                    {
                        if (FilterStudent.SelectedItem != null && SubFilterAttendance.SelectedItem != null)
                        {
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            globalStatus = string.Empty;
                            globalStatus = (string)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IDStudent == studId && x.Status == globalStatus);
                        }
                    }
                    break;
                case 3:
                    if (StudentFilter.SelectedIndex == 0)
                    {
                        if (SubFilterAttendance.SelectedItem != null)
                        {
                            globalDate = (DateTime)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.Date == globalDate);

                        }
                    }
                    else if (StudentFilter.SelectedIndex == 1)
                    {
                        if (FilterStudent.SelectedItem != null && SubFilterAttendance.SelectedItem != null)
                        {
                            globalGroupId = string.Empty;
                            globalGroupId = (string)FilterStudent.SelectedItem;
                            globalDate = (DateTime)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IdGroup == globalGroupId && x.Date == globalDate);
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 2)
                    {
                        if (FilterStudent.SelectedItem != null && SubFilterAttendance.SelectedItem != null)
                        {
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            globalDate = (DateTime)SubFilterAttendance.SelectedItem;
                            attendances = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IDStudent == studId && x.Date == globalDate);
                        }
                    }
                    break;
                default:
                    break;
                    
            };


            
            return attendances;
            
        }

        private void FinalGradePdfExport(object sender, DoWorkEventArgs e)
        {
            var stream = new FileStream(globalPath, FileMode.Create);
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);

            PdfFont roboto = PdfFontFactory.CreateFont(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Roboto-Light.ttf", PdfEncodings.IDENTITY_H);
            PdfFont robotoHeader = PdfFontFactory.CreateFont(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Roboto-Bold.ttf", PdfEncodings.IDENTITY_H);
            int ct = 0;
            ct += materialCheckedListBox1.Items.Where(x => x.Checked == true).Count();
            ct += materialCheckedListBox4.Items.Where(x => x.Checked == true).Count();
            Document doc = null;

            if (ct <= 9 && ct > 0)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A4.Rotate());
                doc = new Document(pdf, PageSize.A4.Rotate());
            }
            else if (ct > 9 && ct <= 13)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A3.Rotate());
                doc = new Document(pdf, PageSize.A3.Rotate());
            }
            else if (ct > 13)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A2.Rotate());
                doc = new Document(pdf, PageSize.A2.Rotate());
            }
            else
            {
                MessageBox.Show("Aspoň 1 stĺpec musí byť vybratý.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int studentColumnsCount = 0;
                int finalGradeColumnsCount = 0;
                int generalCount = 0;
                var studDict = new Dictionary<int, string>();
                var gradeDict = new Dictionary<int, string>();



                Table table = new Table(ct);

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var students = globalStudents;
                    var finalGrades = globalFinalGrades;

                    if (students.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden študent");
                        e.Cancel = true;
                        return;
                    }
                    if (finalGrades.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden záznam hodnotení");
                        e.Cancel = true;
                        return;
                    }
                    //Adding  Student columns
                    foreach (var item in materialCheckedListBox1.Items)
                    {
                        if (item.Checked)
                        {
                            Cell cell = new Cell().Add((new Paragraph().Add(item.Text.ToString()))).SetFont(robotoHeader);
                            table.AddHeaderCell(cell);
                            studDict.Add(studentColumnsCount, item.Text);
                            studentColumnsCount++;
                        }
                    }
                    /// Adding activity columns
                    foreach (var item in materialCheckedListBox4.Items)
                    {
                        if (item.Checked)
                        {
                            Cell cell = new Cell().Add((new Paragraph(item.Text.ToString()).SetFont(robotoHeader)));
                            gradeDict.Add(finalGradeColumnsCount, item.Text);

                            table.AddHeaderCell(cell);
                            finalGradeColumnsCount++;
                        }
                    }

                    table.StartNewRow();
                    int studCount = 0;
                    int progress = 0;
                    int progressPerPerson = 100 / students.Count();
                    foreach (var stud in students)
                    {

                        if (m_oWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            m_oWorker.ReportProgress(0);
                            doc.Flush();
                            doc.Close();
                            return;
                        }


                        studCount++;
                        progress += (int)progressPerPerson;
                        m_oWorker.ReportProgress(progress);

                        generalCount = 0;
                        for (int i = 0; i < (studentColumnsCount); i++)
                        {
                            var name = studDict.TryGetValue(i, out string value);
                            dbNames.TryGetValue(value, out string val);
                            generalCount++;
                            PropertyInfo item = typeof(Student).GetProperty(val);
                            var st = students.Where(x => x.Id == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();
                            Cell cell = new Cell().Add(new Paragraph(st).SetFont(roboto));
                            table.AddCell(cell);

                        }

                        for (int i=0;i< finalGradeColumnsCount;i++)
                        {
                            var name = gradeDict.TryGetValue(i, out string value);
                            dbNames.TryGetValue(value, out string val);

                            PropertyInfo item = typeof(FinalGrade).GetProperty(val);
                            var finalGrade = finalGrades.Where(x => x.IdStudent == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();
                           
                            Cell cell = new Cell().Add(new Paragraph(finalGrade));
                            table.AddCell(cell);
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
                m_oWorker.ReportProgress(100);
            }
            catch (Exception ex)
            {
                doc.Close();
                doc.Flush();
                e.Cancel = true;
                MessageBox.Show(ex.ToString());
            }
        }
            
        private void FinalGradeExcelExport(object sender, DoWorkEventArgs e)
        {                      
                DataTable table = new DataTable();
                //Counters for columns 
                int studentColumnsCount = 0;
                int FinalGradeColumnsCount = 0;
                int generalCount = 0;

            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var students = globalStudents;
                var finalGrades = globalFinalGrades;
                if (students == null)
                {
                    MessageBox.Show("Nenašiel sa žiaden študent");
                    e.Cancel = true;
                    return;
                }
                if (finalGrades == null)
                {
                    MessageBox.Show("Nenašiel sa žiaden záznam hodnotení");
                    e.Cancel = true;
                    return;
                }

                //Adding  Student columns
                foreach (var item in materialCheckedListBox1.Items)
                {
                    if (item.Checked)
                    {
                        table.Columns.Add(item.Text);
                        studentColumnsCount++;
                    }

                }
                // Adding final grade columns
                foreach (var item in materialCheckedListBox4.Items)
                {
                    if (item.Checked)
                    {
                        table.Columns.Add(item.Text);
                        FinalGradeColumnsCount++;
                    }
                }

                if (FinalGradeColumnsCount == 0)
                {
                    MessageBox.Show("Je nutné vybrať aspoň jeden stĺpec.");
                    return;
                }
                //Progress reporting
                int studCount = 0;
                int progress = 0;
                int progressPerPerson = 100 / students.Count();

                foreach (var stud in students)
                {
                    if (m_oWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        m_oWorker.ReportProgress(0);
                        return;
                    }
                    studCount++;
                    progress += (int)progressPerPerson;
                    m_oWorker.ReportProgress(progress);
                    var row = table.NewRow();
                    ///Student rows
                    generalCount = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        // General count suggests which columns are for student and which are for final grade
                        if (generalCount < studentColumnsCount)
                        {
                            generalCount++;
                            dbNames.TryGetValue(column.ColumnName, out string val);
                            PropertyInfo item = typeof(Student).GetProperty(val);
                            var st = students.Where(x => x.Id == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();
                            row[column.ColumnName] = st;
                        }
                        else
                        {
                            dbNames.TryGetValue(column.ColumnName, out string val);
                            PropertyInfo item = typeof(FinalGrade).GetProperty(val);
                            var fGrade = finalGrades.Where(x => x.IdStudent == stud.Id).Select(grade => (string)item.GetValue(grade).ToString()).FirstOrDefault();
                            row[column.ColumnName] = fGrade;
                        }
                    }
                    table.Rows.Add(row);
                }
                // Send table back to the backgroundworker, so we can 
                e.Result = table;
            }            
        }

            private void ExportVisible(bool visible)
        {

            lblStatus.Enabled = visible;
            lblStatus.Visible = visible;
            progressBar1.Visible = visible;
            progressBar1.Enabled = visible;
            cancelExport.Enabled = visible;
            cancelExport.Visible = visible;
        }

        private void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = "Spracovávam......" + progressBar1.Value.ToString() + "%";
        }

        private void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable table = new DataTable();

                //Counters for columns 
                int studentColumnsCount = 0;
                int activityColumnsCount = 0;
                int taskColumnsCount = 0;
                int generalCount = 0;

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var students = globalStudents; 
                    var activities = globalActivities;
                    var tasks = con.GetTable<Task>();

                    if (students.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden študent");
                        e.Cancel = true;
                        return;
                    }
                    if (activities.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden záznam o aktivitách");
                        e.Cancel = true;
                        return;
                    }

                    //Adding  Student columns
                    foreach (var item in materialCheckedListBox1.Items)
                    {
                        if (item.Checked)
                        {
                            table.Columns.Add(item.Text);
                            studentColumnsCount++;
                        }
                    }

                    /// Adding activity columns
                    if (materialCheckedListBox2.Enabled)
                        foreach (var item in materialCheckedListBox2.Items)
                        {
                            if (item.Checked)
                            {
                                table.Columns.Add(item.Text);
                                activityColumnsCount++;
                            }
                        }
                    //Task columns
                    if (materialCheckedListBox3.Enabled)
                        foreach (var item in materialCheckedListBox3.Items)
                        {
                            if (item.Checked)
                            {
                                table.Columns.Add(item.Text);
                                taskColumnsCount++;
                            }
                        }

                    int? activityId = null;

                    //Progress reporting
                    int studCount = 0;
                    int progress = 0;
                    int progressPerPerson = 100 / students.Count();

                    foreach (var stud in students)
                    {

                        if (m_oWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            m_oWorker.ReportProgress(0);
                            return;
                        }

                        studCount++;
                        progress += (int)progressPerPerson;
                        m_oWorker.ReportProgress(progress);
                        var row = table.NewRow();
                        ///Student rows
                        generalCount = 0;
                        foreach (DataColumn column in table.Columns)
                        {
                            if (generalCount < studentColumnsCount)
                            {
                                generalCount++;
                                dbNames.TryGetValue(column.ColumnName, out string val);
                                PropertyInfo item = typeof(Student).GetProperty(val);
                                var st = students.Where(x => x.Id == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();
                                row[column.ColumnName] = st;
                            }
                            else
                            {
                                break;
                            }
                        }

                        //Activity rows
                        if (activityColumnsCount > 0)
                        {
                           Activity act= activities.Where(x => x.IdStudent == stud.Id).DefaultIfEmpty().FirstOrDefault();

                            if (act == null)
                            {
                                activityId = null;
                            }
                            else
                            {
                                activityId = act.Id;
                            }
                            foreach (var activity in activities.Where(x => x.IdStudent == stud.Id))
                            {
                                if(activityId==null)
                                {
                                    table.Rows.Add(row);
                                    continue;
                                }
                                if (activityId != activity.Id)
                                {
                                    row = table.NewRow();
                                    activityId = activity.Id;
                                }
                                else
                                {
                                    activityId = activity.Id;
                                }

                                generalCount = 0;
                                foreach (DataColumn col in table.Columns)
                                {
                                    if (generalCount >= studentColumnsCount)
                                    {
                                        if (generalCount < (studentColumnsCount + activityColumnsCount))
                                        {
                                            generalCount++;
                                            dbNames.TryGetValue(col.ColumnName, out string val);
                                            PropertyInfo item = typeof(Activity).GetProperty(val);
                                            string activityToExcel = activities.Where(x => x.Id == activity.Id && x.IdStudent == stud.Id).
                                                Select(activ => activ != null ? item.GetValue(activ).ToString() : "").DefaultIfEmpty().FirstOrDefault();
                                            row[col.ColumnName] = activityToExcel;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        generalCount++;
                                        continue;
                                    }
                                }

                                if (taskColumnsCount > 0)
                                {
                                    var tsk = tasks.Where(x => x.IdActivity == activityId);
                                    foreach (var task in  tsk)//tasks.Where(x => x.IdActivity == activity.Id))
                                    {

                                        generalCount = 0;
                                        foreach (DataColumn col in table.Columns)
                                        {
                                            try
                                            {
                                                if (generalCount >= (activityColumnsCount + studentColumnsCount))
                                                {

                                                    generalCount++;
                                                    dbNames.TryGetValue(col.ColumnName, out string val);
                                                    PropertyInfo item = typeof(Task).GetProperty(val);
                                                    string activityToExcel = tasks.Where(x => x.Id == task.Id).
                                                        Select(activ => activ != null ? item.GetValue(activ).ToString() : "").DefaultIfEmpty().FirstOrDefault();
                                                    row[col.ColumnName] = activityToExcel;

                                                }
                                                else
                                                {
                                                    generalCount++;
                                                    continue;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString());
                                                continue;
                                            }
                                        }
                                        table.Rows.Add(row);
                                        row = table.NewRow();
                                    }
                                }
                                else
                                {
                                    table.Rows.Add(row);
                                }
                            }
                        }
                        else
                        {
                            table.Rows.Add(row);
                        }
                    }
                }

                e.Result = table;
                m_oWorker.ReportProgress(100);

            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError(ex);
                MessageBox.Show(ex.ToString());
                e.Cancel = true;
            }
        }

        private int TotalCount()
        {
            int count = 0;
            foreach (var it in materialCheckedListBox1.Items)
            {
                if (it.Checked && materialCheckedListBox1.Enabled)
                {
                    count++;
                }
            }
            foreach (var it in materialCheckedListBox2.Items)
            {
                if (it.Checked && materialCheckedListBox2.Enabled)
                {
                    count++;
                }
            }
            foreach (var it in materialCheckedListBox3.Items)
            {
                if (it.Checked && materialCheckedListBox3.Enabled)
                {
                    count++;
                }
            }
            return count;
        }

        public void GetStudentActivityPdf(object sender, DoWorkEventArgs e)
        {

            materialCheckedListBox2.Items.Where(x => x.Text == "Id aktivity").FirstOrDefault().Checked = false;
            materialCheckedListBox3.Items.Where(x => x.Text == "Id študent").FirstOrDefault().Checked = false;
            materialCheckedListBox3.Items.Where(x => x.Text == "Id aktivita").FirstOrDefault().Checked = false;
            var stream = new FileStream(globalPath, FileMode.Create);
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);

            PdfFont roboto = PdfFontFactory.CreateFont(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Roboto-Light.ttf", PdfEncodings.IDENTITY_H);
            PdfFont robotoHeader = PdfFontFactory.CreateFont(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Roboto-Bold.ttf", PdfEncodings.IDENTITY_H);

            Document doc = null;
            var ct = TotalCount();

            if (ct <= 9 && ct > 0)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A4.Rotate());
                doc = new Document(pdf, PageSize.A4.Rotate());
            }
            else if (ct > 9 && ct <= 13)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A3.Rotate());
                doc = new Document(pdf, PageSize.A3.Rotate());
            }
            else if (ct > 13)
            {
                pdf.AddNewPage(iText.Kernel.Geom.PageSize.A2.Rotate());
                doc = new Document(pdf, PageSize.A2.Rotate());
            }
            else
            {
                MessageBox.Show("Aspoň 1 stĺpec musí byť vybratý.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int studentColumnsCount = 0;
                int activityColumnsCount = 0;
                int taskColumnsCount = 0;
                int generalCount = 0;

                var studDict = new Dictionary<int, string>();
                var actDict = new Dictionary<int, string>();
                var taskDict = new Dictionary<int, string>();

                Table table = new Table(ct);

                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var students = globalStudents;
                    var activities = globalActivities;
                    var tasks = con.GetTable<Task>();

                    if (students.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden študent");
                        e.Cancel = true;
                        return;
                    }
                    if (activities.Count() <= 0)
                    {
                        MessageBox.Show("Nenašiel sa žiaden záznam o aktivitách");
                        e.Cancel = true;
                        return;
                    }

                    //Adding  Student columns
                    foreach (var item in materialCheckedListBox1.Items)
                    {
                        if (item.Checked)
                        {
                            Cell cell = new Cell().Add((new Paragraph().Add(item.Text.ToString()))).SetFont(robotoHeader);
                            table.AddHeaderCell(cell);
                            studDict.Add(studentColumnsCount, item.Text);
                            studentColumnsCount++;
                        }
                    }
                    /// Adding activity columns
                    if (materialCheckedListBox2.Enabled)
                        foreach (var item in materialCheckedListBox2.Items)
                        {
                            if (item.Checked)
                            {
                                Cell cell = new Cell().Add((new Paragraph(item.Text.ToString()).SetFont(robotoHeader)));
                                table.AddHeaderCell(cell);
                                actDict.Add(activityColumnsCount, item.Text);
                                activityColumnsCount++;
                            }
                        }

                    if (materialCheckedListBox3.Enabled)
                        foreach (var item in materialCheckedListBox3.Items)
                        {
                            if (item.Checked)
                            {
                                Cell cell = new Cell().Add((new Paragraph(item.Text.ToString()).SetFont(robotoHeader)));

                                table.AddHeaderCell(cell);
                                taskDict.Add(taskColumnsCount, item.Text);
                                taskColumnsCount++;
                            }
                        }
                    table.StartNewRow();
                    int studCount = 0;
                    int progress = 0;
                    int progressPerPerson = 100 / students.Count();
                    foreach (var stud in students)
                    {

                        if (m_oWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            m_oWorker.ReportProgress(0);
                            return;
                        }

                        studCount++;
                        progress += (int)progressPerPerson;
                        m_oWorker.ReportProgress(progress);

                        generalCount = 0;
                        for (int i = 0; i < (studentColumnsCount + activityColumnsCount + taskColumnsCount); i++)
                        {
                            if (generalCount < studentColumnsCount)
                            {
                                generalCount++;

                                var name = studDict.TryGetValue(i, out string value);
                                dbNames.TryGetValue(value, out string val);
                                PropertyInfo item = typeof(Student).GetProperty(val);
                                var st = students.Where(x => x.Id == stud.Id).Select(stu => (string)item.GetValue(stu).ToString()).FirstOrDefault();

                                Cell cell = new Cell().Add(new Paragraph(st).SetFont(roboto));
                                table.AddCell(cell);
                            }
                            else
                            {
                                Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                table.AddCell(cell);
                            }
                        }
                        if (activityColumnsCount > 0)
                        {
                            foreach (var activity in activities.Where(x => x.IdStudent == stud.Id))
                            {

                                generalCount = 0;
                                table.StartNewRow();
                                for (int i = 0; i <= (studentColumnsCount + activityColumnsCount + taskColumnsCount) - 1; i++)
                                {
                                    if (generalCount >= studentColumnsCount)
                                    {
                                        if (generalCount < (studentColumnsCount + activityColumnsCount))
                                        {
                                            generalCount++;
                                            var name = actDict.TryGetValue(i - studentColumnsCount, out string value);
                                            dbNames.TryGetValue(value, out string val);
                                            PropertyInfo item = typeof(Activity).GetProperty(val);
                                            string activityToExcel = activities.Where(x => x.Id == activity.Id && x.IdStudent == stud.Id).
                                                Select(activ => activ != null ? item.GetValue(activ).ToString() : "").DefaultIfEmpty().FirstOrDefault();
                                            Cell cell = new Cell().Add(new Paragraph(activityToExcel).SetFont(roboto));
                                            table.AddCell(cell);
                                        }
                                        else
                                        {
                                            Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                            table.AddCell(cell);
                                        }
                                    }
                                    else
                                    {
                                        Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                        table.AddCell(cell);
                                        generalCount++;
                                    }
                                }
                                if (taskColumnsCount > 0)
                                {
                                    foreach (var task in tasks.Where(x => x.IdActivity == activity.Id))
                                    {
                                        generalCount = 0;
                                        for (int i = 0; i <= (studentColumnsCount + activityColumnsCount + taskColumnsCount); i++)
                                        {
                                            try
                                            {
                                                if (generalCount >= (activityColumnsCount + studentColumnsCount))
                                                {

                                                    generalCount++;
                                                    var name = taskDict.TryGetValue(i - (studentColumnsCount + activityColumnsCount), out string value);
                                                    dbNames.TryGetValue(value, out string val);
                                                    PropertyInfo item = typeof(Task).GetProperty(val);
                                                    string activityToExcel = tasks.Where(x => x.Id == task.Id).
                                                        Select(activ => activ != null ? item.GetValue(activ).ToString() : "").DefaultIfEmpty().FirstOrDefault();
                                                    Cell cell = new Cell().Add(new Paragraph(activityToExcel).SetFont(roboto));
                                                    table.AddCell(cell);
                                                }
                                                else
                                                {
                                                    Cell cell = new Cell().Add(new Paragraph(string.Empty));
                                                    table.AddCell(cell);
                                                    generalCount++;
                                                    continue;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
                m_oWorker.ReportProgress(100);
            }
            catch (Exception ex)
            {
                doc.Close();
                e.Cancel = true;
                MessageBox.Show(ex.ToString());
            }
        }

        private readonly Dictionary<string, string> dbNames = new Dictionary<string, string>()
        {
            ///Student translations
            {"Meno","Meno"},
            {"Priezvisko","Priezvisko"},
            {"Email Ucm","Email_UCM"},
            {"Email","Email"},
            {"Isic","ISIC"},
            {"Ročník","Rocnik"},
            {"Forma","Forma"},
            {"Krúžok","IdGroupForAttendance"},
            {"Študíjny program","Stud_program"},
            /// Activity Translations
            {"Názov aktivity","ActivityName"},
            {"Dátum odovzdania","Deadline"},
            {"Maximum bodov","MaxPoints"},
            {"Získané body","Hodnotenie"},
            {"Komentár - aktivita","Comment"},
            {"Id aktivity","Id"},
            ///Task Translations
            {"Názov úlohy","TaskName"},
            {"Maximálne Bodov","Points"},
            {"Id študent","IdStudent"},
            {"Id aktivita","IdActivity"},
            {"Získaných bodov","Hodnotenie"},
            {"Komentár - úloha","Comment"},

            //Attendance Translations
            {"Dátum","Date"},
            {"Typ","Type"},
            {"Status","Status"},
            {"Komentár","Comment"},
            //FinalGrade Translations
            {"Maximum bodov za semester","MaxPts"},
            {"Získal bodov","GotPoints"},
            {"Vymeškaných prednášok","MissedLectures"},
            {"Vymeškaných cvičení","MissedSeminars"},
            {"Aktivita prednáška","ActivityLectPoints"},
            {"Aktivita cvičenie","ActivitySemPoints"},
            {"Známka","Grade"},

        };

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                m_oWorker = new BackgroundWorker();
                m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                        (m_oWorker_ProgressChanged);
                m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                        (m_oWorker_RunWorkerCompleted);
                m_oWorker.WorkerReportsProgress = true;
                m_oWorker.WorkerSupportsCancellation = true;
                globalStudents = GetStudents();
                if(globalStudents == null || globalStudents.Count() <= 0)
                {
                    MessageBox.Show("Nenašiel sa žiaden študent");
                    return;
                }

                switch (ExportCombo.SelectedIndex)
                {
                    case 0:
                        globalActivities = null;
                        globalActivities = GetActivities();
                        if (globalActivities == null || globalActivities.Count() <=0)
                        {
                            MessageBox.Show("Nenašla sa žiadna aktivita");
                            return;
                        }

                        m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
                        break;
                    case 1:
                        globalAttendances = null;
                        globalAttendances = GetAttendances();
                        if (globalAttendances == null || globalAttendances.Count() <= 0)
                        {
                            MessageBox.Show("Nenašla sa žiadna dochádzka");
                            return;
                        }
                        m_oWorker.DoWork += new DoWorkEventHandler(TotalAttendanceExcelExport);
                        break;
                    case 2:
                        globalFinalGrades = null;
                        globalFinalGrades = GetFinalGrades();
                        if (globalFinalGrades == null || globalFinalGrades.Count() <= 0)
                        {
                            MessageBox.Show("Nenašlo sa žiadne finálne hodnotenie");
                            return;
                        }
                        m_oWorker.DoWork += new DoWorkEventHandler(FinalGradeExcelExport);
                        break;
                }

                ExportVisible(true);
                m_oWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void Event(object sender, EventArgs e)
        {
            if (materialCheckedListBox1.Items.Where(x => x.Checked).Count() <= 0)
            {
                materialCheckedListBox2.Enabled = false;
                materialCheckedListBox3.Enabled = false;
                materialCheckedListBox4.Enabled = false;
                materialCheckedListBox5.Enabled = false;

            }
            else if (materialCheckedListBox1.Items.Where(x => x.Checked).Count() > 0)
            {
                materialCheckedListBox2.Enabled = true;               
            }
            if (materialCheckedListBox2.Items.Where(x => x.Checked).Count() <= 0 || !materialCheckedListBox2.Enabled)
            {
                materialCheckedListBox3.Enabled = false;
            }
            else
            {
                materialCheckedListBox3.Enabled = true;
            }

        }

        private void OnCheckedChanged(MaterialSkin.Controls.MaterialCheckedListBox CheckedListBox, EventHandler Event)
        {
            foreach (var materialCheckbox in CheckedListBox.Items)
            {
                materialCheckbox.CheckedChanged += Event;
            }
        }

        private void WorkPdfCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("V procese exportu nastala chyba", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                ExportVisible(false);
                return;
            }
            else
            {
                MessageBox.Show("Export do Pdf úspešne dokončený.");
            }
            ExportVisible(false);
        }

        private void cancelExport_Click(object sender, EventArgs e)
        {
            if (m_oWorker.IsBusy)
            {
                m_oWorker.CancelAsync();
            }
        }

        private void ExportToPdfBtn_Click(object sender, EventArgs e)
        {
            try
            {
                globalStudents = GetStudents();
                if (globalStudents == null || globalStudents.Count() <=0)
                {
                    MessageBox.Show("Nenašiel sa žiaden študent");
                    return;
                }

                SaveFileDialog file = new SaveFileDialog();
                file.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                file.Filter = "Pdf Files|*.pdf;";
                file.AddExtension = true;
                file.DefaultExt = ".pdf";
                DialogResult result = file.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    globalPath = string.Empty;
                    globalPath = file.FileName;
                }
              
                m_oWorker = new BackgroundWorker();
                m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
                m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkPdfCompleted);
                m_oWorker.WorkerReportsProgress = true;
                m_oWorker.WorkerSupportsCancellation = true;

                switch (ExportCombo.SelectedIndex)
                {
                    case 0:
                        globalActivities = null;
                        globalActivities = GetActivities();
                        if (globalActivities == null || globalActivities.Count() <= 0)
                        {
                            MessageBox.Show("Nenašla sa žiadna aktivita");
                            return;
                        }
                        m_oWorker.DoWork += new DoWorkEventHandler(GetStudentActivityPdf);

                        break;
                    case 1:
                        globalAttendances = null;
                        globalAttendances = GetAttendances();
                        if (globalAttendances == null || globalAttendances.Count() <= 0)
                        {
                            MessageBox.Show("Nenašla sa žiadna dochádzka");
                            return;
                        }
                        m_oWorker.DoWork += new DoWorkEventHandler(TotalAttendancePdfExport);
                        break;
                    case 2:
                        globalFinalGrades = null;
                        globalFinalGrades = GetFinalGrades();
                        if (globalFinalGrades == null || globalFinalGrades.Count() <= 0)
                        {
                            MessageBox.Show("Nenašlo sa žiadne finálne hodnotenie");
                            return;
                        }
                        m_oWorker.DoWork += new DoWorkEventHandler(FinalGradePdfExport);
                        break;
                }

                ExportVisible(true);
                m_oWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Logger logger = new Logger();
                logger.LogError(ex);
            }
        }

        private void LoadActivityBoxes()
        {
            if (ActivityFilter.SelectedIndex == 0)
            {
                SubActivityFilter.Enabled = false;
                SubActivityFilter.Visible = false;
                DeadlineBox.Enabled = false;
                DeadlineBox.Visible = false;
            }
            else
            {
                if (ActivityFilter.SelectedIndex == 1 && StudentFilter.SelectedIndex == 0)
                {
                    using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                    {
                        SubActivityFilter.Items.Clear();
                        var activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id).Select(x => new { x.ActivityName }).Distinct();
                        foreach (var activity in activities)
                        {
                            SubActivityFilter.Items.Add(activity.ActivityName);
                        }
                    }
                }
                else if (ActivityFilter.SelectedIndex == 1 && StudentFilter.SelectedIndex == 1)
                {
                    if (FilterStudent.SelectedItem != null)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            SubActivityFilter.Items.Clear();
                            var activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.Student.IdGroupForAttendance == (string)FilterStudent.SelectedItem)
                                .Select(x => new { x.ActivityName }).Distinct();
                            foreach (var activity in activities)
                            {
                                SubActivityFilter.Items.Add(activity.ActivityName);
                            }
                        }
                    }
                }
                else if (ActivityFilter.SelectedIndex == 1 && StudentFilter.SelectedIndex == 2)
                {
                    if (FilterStudent.SelectedItem != null)
                    {
                        using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                        {
                            SubActivityFilter.Items.Clear();
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            var activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.IdStudent == studId)
                                .Select(x => new { x.ActivityName }).Distinct();
                            foreach (var activity in activities)
                            {
                                SubActivityFilter.Items.Add(activity.ActivityName);
                            }
                        }
                    }
                }


                SubActivityFilter.Enabled = true;
                SubActivityFilter.Visible = true;
                DeadlineBox.Enabled = true;
                DeadlineBox.Visible = true;
            }
        }

        private void LoadComboBoxesStudent()
        {
            if (StudentFilter.SelectedIndex == 0)
            {
                FilterStudent.Enabled = false;
                FilterStudent.Visible = false;
            }
            else if (StudentFilter.SelectedIndex == 1)
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    FilterStudent.Items.Clear();
                    var studentGroups = con.GetTable<Student>().Where(x => x.ID_stud_skupina == group.Id).Select(y => y.IdGroupForAttendance);
                    foreach (var kr in studentGroups.Distinct())
                    {
                        FilterStudent.Items.Add(kr);
                    }
                    FilterStudent.Enabled = true;
                    FilterStudent.Visible = true;
                }
            }
            else if (StudentFilter.SelectedIndex == 2)
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    FilterStudent.Items.Clear();
                    studDict.Clear();

                    var students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == group.Id);
                    foreach (var stud in students)
                    {
                        studDict.Add(stud.Meno + " " + stud.Priezvisko, stud.Id);
                        FilterStudent.Items.Add(stud.Meno + " " + stud.Priezvisko);
                    }
                    FilterStudent.Enabled = true;
                    FilterStudent.Visible = true;
                }
            }
        }

        private void LoadDeadlineBox()
        {
            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                if (ActivityFilter.SelectedIndex == 1 && SubActivityFilter.SelectedItem != null)
                {
                    if (StudentFilter.SelectedIndex == 0)
                    {
                        DeadlineBox.Items.Clear();
                        foreach (var activity in con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.ActivityName == (string)SubActivityFilter.SelectedItem).Select(x => new { x.Deadline }).Distinct())
                        {
                            DeadlineBox.Items.Add(activity.Deadline);
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 1)
                    {
                        if (FilterStudent.SelectedItem != null)
                        {
                            DeadlineBox.Items.Clear();
                            foreach (var activity in con.GetTable<Activity>()
                                .Where(x => x.IdSkupina == group.Id && x.ActivityName == (string)SubActivityFilter.SelectedItem && x.Student.IdGroupForAttendance == (string)FilterStudent.SelectedItem)
                                .Select(x => new { x.Deadline }).Distinct())
                            {
                                DeadlineBox.Items.Add(activity.Deadline);
                            }
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 2)
                    {
                        DeadlineBox.Items.Clear();
                        if (FilterStudent.SelectedItem != null)
                        {
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            foreach (var activity in con.GetTable<Activity>()
                                .Where(x => x.IdSkupina == group.Id && x.ActivityName == (string)SubActivityFilter.SelectedItem && x.IdStudent == studId)
                            .Select(x => new { x.Deadline }).Distinct())
                            {
                                DeadlineBox.Items.Add(activity.Deadline);
                            }
                        }
                    }

                    DeadlineBox.SelectedIndex = 0;
                }
            }
        }

        private IQueryable<Student> GetStudents()
        {
            IQueryable<Student> students = null;
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            if (StudentFilter.SelectedIndex == 0)
            {
                students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == group.Id);
            }
            else if (StudentFilter.SelectedIndex == 1)
            {
                if (FilterStudent.SelectedItem != null)
                {
                    globalGroupId = string.Empty;
                    globalGroupId = (string)FilterStudent.SelectedItem;
                    students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == group.Id && x.IdGroupForAttendance == globalGroupId);
                }
                else
                {
                    MessageBox.Show("Nie je vybratá žiadna skupina");
                    return null;
                }
            }
            else if (StudentFilter.SelectedIndex == 2)
            {
                if (FilterStudent.SelectedItem != null)
                {
                    studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                    students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == group.Id && x.Id == studId);
                }
                else
                {
                    MessageBox.Show("Nie je vybratý žiaden študent");
                    return null;
                }
            }
            return students;
        }


        private IQueryable<FinalGrade> GetFinalGrades()
        {
            IQueryable<FinalGrade> FinalGrades = null; ;
            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            if (StudentFilter.SelectedIndex == 0)
            {
                FinalGrades = con.GetTable<FinalGrade>().Where(x => x.IdSkupina == group.Id);
            }
            else if (StudentFilter.SelectedIndex == 1)
            {
                if (FilterStudent.SelectedItem != null)
                {
                    globalGroupId = string.Empty;
                    globalGroupId = (string)FilterStudent.SelectedItem;
                    FinalGrades = con.GetTable<FinalGrade>().Where(x => x.IdSkupina == group.Id && x.Student.IdGroupForAttendance == globalGroupId);
                }
            }
            else if (StudentFilter.SelectedIndex == 2)
            {
                if (FilterStudent.SelectedItem != null)
                {
                    studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                    FinalGrades = con.GetTable<FinalGrade>().Where(x => x.IdSkupina == group.Id && x.IdStudent == studId);
                }                
            }
            return FinalGrades;
        }


        private IQueryable<Activity> GetActivities()
        {
            IQueryable<Activity> activities = null;
            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            if(StudentFilter.SelectedIndex == 0 && ActivityFilter.SelectedIndex==0)
            {
                activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id);
            }
            else if (StudentFilter.SelectedIndex == 1 && ActivityFilter.SelectedIndex == 0)
            {
                if (FilterStudent.SelectedItem != null)
                {
                    globalFilter = string.Empty;
                    globalFilter = (string)FilterStudent.SelectedItem;

                    activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.Student.IdGroupForAttendance== globalFilter );
                }
            }
            else if (StudentFilter.SelectedIndex == 0 && ActivityFilter.SelectedIndex == 1)
            {
                if (SubActivityFilter.SelectedItem!=null && DeadlineBox.SelectedItem!=null)
                {
                    globalActivityName = string.Empty;
                    globalActivityName = (string)SubActivityFilter.SelectedItem;
                    globalDate = (DateTime)DeadlineBox.SelectedItem;

                    activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.ActivityName== globalActivityName
                    && x.Deadline==globalDate);
                }
            }
            else if (StudentFilter.SelectedIndex == 1  && ActivityFilter.SelectedIndex == 1)
            {
                if (SubActivityFilter.SelectedItem != null && DeadlineBox.SelectedItem != null && FilterStudent.SelectedItem!=null)
                {
                    globalFilter = string.Empty;
                    globalFilter = (string)FilterStudent.SelectedItem;

                    globalActivityName = string.Empty;
                    globalActivityName = (string)SubActivityFilter.SelectedItem;

                    globalDate = (DateTime)DeadlineBox.SelectedItem;

                    activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.Student.IdGroupForAttendance==globalFilter && x.ActivityName == globalActivityName
                    && x.Deadline == globalDate);
                }
            }
            else if (StudentFilter.SelectedIndex == 2 && ActivityFilter.SelectedIndex == 0)
            {
                if ( FilterStudent.SelectedItem != null)
                {
                    studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                    activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.IdStudent == studId);
                }
            }
            else if (StudentFilter.SelectedIndex == 2 && ActivityFilter.SelectedIndex == 1)
            {
                if (SubActivityFilter.SelectedItem != null && DeadlineBox.SelectedItem != null && FilterStudent.SelectedItem != null)
                {
                    studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                    globalActivityName = string.Empty;
                    globalActivityName = (string)SubActivityFilter.SelectedItem;

                    globalDate = (DateTime)DeadlineBox.SelectedItem;

                    activities = con.GetTable<Activity>().Where(x => x.IdSkupina == group.Id && x.IdStudent == studId && x.ActivityName == globalActivityName
                    && x.Deadline == globalDate);
                }
            }



            return activities;
        }

        private void StudentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboBoxesStudent();
        }

        private void ActivityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadActivityBoxes();
        }

        private void FilterStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadActivityBoxes();
            LoadDeadlineBox();
        }

        private void SubActivityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeadlineBox();
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {

        }

        private void FilterAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            SubFilterAttendance.Items.Clear();
            switch (FilterAttendance.SelectedIndex)
            {
                case 0:
                    SubFilterAttendance.Enabled = false;
                    SubFilterAttendance.Visible = false;
                    break;
                case 1:
                    SubFilterAttendance.Enabled = true;
                    SubFilterAttendance.Visible = true;

                    SubFilterAttendance.Items.Add("Prednáška");
                    SubFilterAttendance.Items.Add("Cvičenie");
                    SubFilterAttendance.SelectedIndex = 0;
                    break;
                case 2:
                    SubFilterAttendance.Enabled = true;
                    SubFilterAttendance.Visible = true;

                    SubFilterAttendance.Items.Add("Prítomný");
                    SubFilterAttendance.Items.Add("Neprítomný");
                    SubFilterAttendance.Items.Add("Ospravedlnené");
                    SubFilterAttendance.Items.Add("Zrušené");
                    SubFilterAttendance.SelectedIndex = 0;
                    break;
                case 3:
                    SubFilterAttendance.Enabled = true;
                    SubFilterAttendance.Visible = true;

                    if (StudentFilter.SelectedIndex == 0)
                    {
                        var att = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id).Select(x => x.Date).Distinct();
                        foreach(var x in att)
                        {
                            SubFilterAttendance.Items.Add(x);
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 1)
                    {
                        if (FilterStudent.SelectedItem != null)
                        {
                            globalGroupId = string.Empty;
                            globalGroupId = (string)FilterStudent.SelectedItem;
                            var att = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IdGroup == globalGroupId).Select(x => x.Date).Distinct();
                            foreach (var x in att)
                            {
                                SubFilterAttendance.Items.Add(x);
                            }
                        }
                    }
                    else if (StudentFilter.SelectedIndex == 2)
                    {
                        if (FilterStudent.SelectedItem != null)
                        {
                            studDict.TryGetValue((string)FilterStudent.SelectedItem, out int studId);
                            var att = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == group.Id && x.IDStudent== studId).Select(x => x.Date).Distinct();
                            foreach (var x in att)
                            {
                                SubFilterAttendance.Items.Add(x);
                            }
                        }
                    }

                    if (SubFilterAttendance.Items.Count > 0)
                    {
                        SubFilterAttendance.SelectedIndex = 0;
                    }
                    break;
            }
        }
    }

}
    
