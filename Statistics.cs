using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Image = iText.Layout.Element.Image;

namespace CSAS
{
    public partial class Statistics : MaterialSkin.Controls.MaterialForm
    {
        private string conn_str = ConfigurationManager.ConnectionStrings["CSAS.Properties.Settings.masterConnectionString"].ConnectionString;
        User currentUser;
        StudentSkupina currentGroup;

        Dictionary<DateTime, string> activityDict = new Dictionary<DateTime, string>();
        public Statistics(User user, StudentSkupina skupina)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            currentUser = user;
            currentGroup = skupina;


            LoadPieCombo();

            comboBox1.SelectedIndex = 1;
            comboBox4.SelectedIndex = 0;
        }

        private void LoadPieCombo()
        {
            comboBox1.Items.Add("Úspešnosť podľa aktivity");
            comboBox1.Items.Add("Celková úspešnosť");
            comboBox1.Items.Add("Známky");

            comboBox4.Items.Add("Skupinová docházka - Prednášky");
            comboBox4.Items.Add("Skupinová docházka - Cvičenia");
            comboBox4.Items.Add("Dochádzka študenta - Prednášky");
            comboBox4.Items.Add("Dochádzka študenta - Cvičenia");

            foreach (var activity in GetActivities().Select(x => new { x.ActivityName }).Distinct())
            {
                comboBox2.Items.Add(activity.ActivityName);
            }

        }

        private void LoadBarCharts()
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            switch (comboBox4.SelectedIndex)
            {
                case 0:
                    GroupAttendanceLecture();
                    break;
                case 1:
                    GroupAttendanceSeminar();
                    break;
                case 2:
                    StudentAttendanceLecture();
                    break;
                case 3:
                    StudentAttendanceSeminar();
                    break;
            }
        }
        private void LoadPieChart()
        {
            if (comboBox1.SelectedIndex != 0)
            {
                comboBox2.Visible = false;
                comboBox2.Enabled = false;

                comboBox3.Visible = false;
                comboBox3.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Visible = true;
                comboBox2.Enabled = true;

                comboBox3.Visible = true;
                comboBox3.Enabled = true;
            }

            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                    {
                        ActivitySuccessfullnessByActivity((string)comboBox2.SelectedItem, (DateTime)comboBox3.SelectedItem);
                    }
                    break;
                case 1:
                    ActivitySuccessfullness();
                    break;
                case 2:
                    TotalGrades();
                    break;



            }


        }

        protected void ActivitySuccessfullnessByActivity(string name, DateTime deadline)
        {
            try
            {
                var activities = GetActivities().GroupBy(x => x.Student.ID_Kruzok).Where(p => p.Select(o => o.ActivityName == name).FirstOrDefault() && p.Select(m => m.Deadline == deadline).FirstOrDefault());

                var n = GetActivities().Where(l => l.ActivityName == name && l.Deadline == deadline).GroupBy(u => u.Student.ID_Kruzok);

                pieChart1.Series = new SeriesCollection();
                pieChart1.InnerRadius = 40;
                pieChart1.LegendLocation = LegendLocation.Right;

                foreach (var activity in n)
                {
                    var maxPoints = activity.Sum(x => x.MaxPoints);
                    var acquiredPoints = activity.Sum(x => x.Hodnotenie);
                    var students = GetStudents().Where(x => x.ID_Kruzok == activity.Key).Count();
                    int multiplier = 1000;

                    double? success = (double?)Math.Round(acquiredPoints / (maxPoints * students) * multiplier, 2);

                    pieChart1.Series.Add(

                        new PieSeries
                        {
                            Title = activity.Key,
                            Values = new ChartValues<double> { success.Value },
                            DataLabels = true
                        }
                        );
                }

                var r = n.Sum(p => p.Select(o => o.Hodnotenie).FirstOrDefault()) / (n.Select(t => t.Select(q => q.IdStudent)).Count());
                AvgLabel.Text = r.ToString();

                label4.Text = "Maximum dosiahnutých:";
                label2.Text = "Minimum dosiahnutých: ";
                var max = n.SelectMany(x => x.Select(y => y.Hodnotenie)).OrderByDescending(c => c).FirstOrDefault();
                var min = n.SelectMany(x => x.Select(y => y.Hodnotenie)).OrderBy(c => c).FirstOrDefault();
                AvgActivity.Text = max.ToString();
                ActCountLabel.Text = min.ToString();
                AvgActivity.Visible = true;
                label4.Visible = true;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        protected void ActivitySuccessfullness()
        {
            var activities = GetActivities().GroupBy(x => x.Student.ID_Kruzok);

            pieChart1.Series = new SeriesCollection();
            pieChart1.InnerRadius = 40;
            pieChart1.LegendLocation = LegendLocation.Right;

            foreach (var activity in activities)
            {
                var maxPoints = activity.Sum(x => x.MaxPoints);
                var acquiredPoints = activity.Sum(x => x.Hodnotenie);
                var students = GetStudents().Where(x => x.ID_Kruzok == activity.Key).Count();
                int multiplier = 1000;

                double? success = (double?)Math.Round(acquiredPoints / (maxPoints * students) * multiplier, 2);

                pieChart1.Series.Add(

                    new PieSeries
                    {
                        Title = activity.Key,
                        Values = new ChartValues<double> { success.Value },
                        DataLabels = true
                    }
                    );
            }
            label4.Visible = false;
            label2.Text = "Počet aktivít: ";

            var ActivitiesCount = GetActivities();
            var countStudents = GetStudents().Count;
            var Max = ActivitiesCount.Sum(x => x.MaxPoints);
            var Graded = ActivitiesCount.Sum(x => x.Hodnotenie);

            ActCountLabel.Text = ActivitiesCount.Select(x => new { x.ActivityName, x.Deadline }).Distinct().Count().ToString();
            AvgActivity.Visible = false;//.Text = (Graded / ActivitiesCount.Distinct().Count()).ToString();
            AvgLabel.Text = (Graded / countStudents).ToString();





        }

        protected void TotalGrades()
        {

            ChartValues<int> valuesA = new ChartValues<int>();
            ChartValues<int> valuesB = new ChartValues<int>();
            ChartValues<int> valuesC = new ChartValues<int>();
            ChartValues<int> valuesD = new ChartValues<int>();
            ChartValues<int> valuesE = new ChartValues<int>();
            ChartValues<int> valuesFx = new ChartValues<int>();

            var finalGrade = GetFinalGrades();

            valuesA.Add(finalGrade.Where(x => x.Grade == "A").Sum(y => y.Grade.Count()));
            valuesB.Add(finalGrade.Where(x => x.Grade == "B").Sum(y => y.Grade.Count()));
            valuesC.Add(finalGrade.Where(x => x.Grade == "C").Sum(y => y.Grade.Count()));
            valuesD.Add(finalGrade.Where(x => x.Grade == "D").Sum(y => y.Grade.Count()));
            valuesE.Add(finalGrade.Where(x => x.Grade == "E").Sum(y => y.Grade.Count()));
            valuesFx.Add(finalGrade.Where(x => x.Grade == "Fx").Sum(y => y.Grade.Count()));





            pieChart1.InnerRadius = 40;
            pieChart1.LegendLocation = LegendLocation.Right;

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "A",
                    Values = valuesA,
                    PushOut = 15,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "B",
                    Values = valuesB,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "C",
                    Values = valuesC,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "D",
                    Values = valuesD,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "E",
                    Values = valuesE,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Fx",
                    PushOut = 10,
                    Values = valuesFx,
                    DataLabels = true
                }
            };
        }



        #region BarChartsAttendance
        protected void StudentAttendanceSeminar()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            var students = GetStudents();
            ChartValues<int> values = new ChartValues<int>();
            List<String> lables = new List<string>();

            ChartValues<int> presentSem = new ChartValues<int>();
            ChartValues<int> absentSem = new ChartValues<int>();

            foreach (var item in GetTotalAttendances())
            {
                presentSem.Add(item.TotalPresentSeminar);
                absentSem.Add(item.TotalAbsentSeminar);
                lables.Add(item.Student.Meno + "\n" + item.Student.Priezvisko);
            }

            cartesianChart1.Series = new SeriesCollection
            {

                new ColumnSeries
                {
                    Title = "Prítomný",
                    Values = presentSem,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green
                },
                new ColumnSeries
                {
                    Title = "Neprítomný",
                    Values = absentSem,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red
                }
            };

            //x axis labels
            Separator sep = new Separator();
            sep.Step = 1;
            cartesianChart1.LegendLocation = LegendLocation.Right;
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = lables,
                LabelsRotation = 45,
                Unit = 0.7,
                Separator = sep,
                ShowLabels = true
            });
            //y axis label
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Dochádzka - Cvičenie",
                LabelFormatter = value => value.ToString()
            });
        }
        protected void StudentAttendanceLecture()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            var students = GetStudents();
            ChartValues<int> values = new ChartValues<int>();
            List<String> lables = new List<string>();

            ChartValues<int> val3 = new ChartValues<int>();
            ChartValues<int> val4 = new ChartValues<int>();


            foreach (var item in GetTotalAttendances())
            {
                val3.Add(item.TotalPresentLecture);
                val4.Add(item.TotalAbsentLecture);
                lables.Add(item.Student.Meno + " " + item.Student.Priezvisko);
            }

            cartesianChart1.Series = new SeriesCollection
            {

                new ColumnSeries
                {
                    Title = "Prítomný",
                    Values = val3,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green
                },
                new ColumnSeries
                {
                    Title = "Neprítomný",
                    Values = val4,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red
                }
            };


            //x axis labels
            cartesianChart1.LegendLocation = LegendLocation.Right;
            Separator sep = new Separator();
            sep.Step = 0.7;
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Študent",
                Labels = lables,
                LabelsRotation = 45,
                Separator = sep,
                Unit = 1,
            });
            //y axis label
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Dochádzka - Prednáška",
                LabelFormatter = value => value.ToString()
            });
        }
        protected void GroupAttendanceLecture()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            var students = GetStudents();
            ChartValues<int> values = new ChartValues<int>();
            List<String> lables = new List<string>();

            var totAtt = GetTotalAttendances();

            Dictionary<string, int> totalPresentLecture = new Dictionary<string, int>();
            Dictionary<string, int> totalAbsentLecture = new Dictionary<string, int>();


            foreach (var tot in totAtt.GroupBy(x => x.Student.ID_Kruzok))
            {
                totalPresentLecture.Add(tot.Key, tot.Sum(x => x.TotalPresentLecture));
            }
            foreach (var tot in totAtt.GroupBy(x => x.Student.ID_Kruzok))
            {
                totalAbsentLecture.Add(tot.Key, tot.Sum(x => x.TotalAbsentLecture));
            }

            foreach (var item in totalPresentLecture)
            {
                values.Add(item.Value);
                lables.Add(item.Key);
            }
            ChartValues<int> val2 = new ChartValues<int>();

            foreach (var item in totalAbsentLecture)
            {
                val2.Add(item.Value);
            }
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Prítomný",
                    Values = values,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green
                },
                new ColumnSeries
                {
                    Title = "Neprítomný",
                    Values = val2,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red
                }
            };
            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            //x axis labels
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Skupina",
                Labels = lables,
                ShowLabels = true,
                Unit = 0.05
            });
            //y axis label
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Dochádzka - Prednáška",
                LabelFormatter = value => value.ToString()
            });

        }
        protected void GroupAttendanceSeminar()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);

            var students = GetStudents();
            ChartValues<int> values = new ChartValues<int>();
            List<String> lables = new List<string>();

            var totAtt = GetTotalAttendances();

            Dictionary<string, int> totalPresentSeminar = new Dictionary<string, int>();
            Dictionary<string, int> totalAbsentSeminar = new Dictionary<string, int>();


            foreach (var tot in totAtt.GroupBy(x => x.Student.ID_Kruzok))
            {
                totalPresentSeminar.Add(tot.Key, tot.Sum(x => x.TotalPresentSeminar));
            }
            foreach (var tot in totAtt.GroupBy(x => x.Student.ID_Kruzok))
            {
                totalAbsentSeminar.Add(tot.Key, tot.Sum(x => x.TotalAbsentSeminar));
            }

            foreach (var item in totalPresentSeminar)
            {
                values.Add(item.Value);
                lables.Add(item.Key);
            }
            ChartValues<int> val2 = new ChartValues<int>();

            foreach (var item in totalAbsentSeminar)
            {
                val2.Add(item.Value);
            }
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Prítomný",
                    Values = values,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green
                },
                new ColumnSeries
                {
                    Title = "Neprítomný",
                    Values = val2,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red
                }
            };

            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            //x axis labels
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Skupina",
                Labels = lables,
                ShowLabels = true,
                Unit = 0.1
            });
            //y axis label
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Dochádzka - Cvičenie",
                LabelFormatter = value => value.ToString()
            });
        }
        #endregion

        protected List<Student> GetStudents()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            var students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == currentGroup.Id).ToList();
            return students;
        }

        protected List<AttendanceStud> GetAttendances()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            var attendance = con.GetTable<AttendanceStud>().Where(x => x.IDSkupina == currentGroup.Id).ToList();
            return attendance;
        }

        protected List<TotalAttendance> GetTotalAttendances()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            var totalAttendance = con.GetTable<TotalAttendance>().Where(x => x.Student.ID_stud_skupina == currentGroup.Id).ToList();
            return totalAttendance;
        }

        protected List<FinalGrade> GetFinalGrades()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            var finalGrades = con.GetTable<FinalGrade>().Where(x => x.IdSkupina == currentGroup.Id).ToList();
            return finalGrades;

        }

        protected List<Activity> GetActivities()
        {
            StudentDBDataContext con = new StudentDBDataContext(conn_str);
            var activity = con.GetTable<Activity>().Where(x => x.IdSkupina == currentGroup.Id).ToList();

            return activity;

        }
        private void materialLabel1_Click_1(object sender, EventArgs e)
        {
        }

        protected void Statistics_Load(object sender, EventArgs e)
        {
            LoadBarCharts();
            LoadPieChart();
        }

        protected void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            LoadPieChart();
            foreach (var activity in GetActivities().Where(x => x.ActivityName == (string)comboBox2.SelectedItem).Select(x => new { x.Deadline }).Distinct())
            {
                comboBox3.Items.Add(activity.Deadline);
            }
        }

        protected void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPieChart();
        }

        protected void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPieChart();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBarCharts();
        }


        private void PrintToPdf(List<MemoryStream> memoryStreams)
        {
            try
            {
                var file = File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\ChartExport.pdf");
                PdfWriter writer = new PdfWriter(file);
                PdfDocument pdf = new PdfDocument(writer);
                pdf.AddNewPage();
                Document document = new Document(pdf);

                foreach (var str in memoryStreams)
                {
                    ImageData data = ImageDataFactory.Create(str.ToArray());
                    Image img = new Image(data);
                    document.Add(img);
                }


                document.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }


        private MemoryStream ToImage(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            // bmp.Save(AppDomain.CurrentDomain.BaseDirectory + @"\img.png", ImageFormat.Png);
            var stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);

            return stream;
        }

        List<MemoryStream> memoryStreams = new List<MemoryStream>();



        private void materialFlatButton3_Click(object sender, EventArgs e)
        {

            try
            {
                PrintToPdf(memoryStreams);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool StreamEquals(Stream a, Stream b)
        {
            if (a == b)
            {
                return true;
            }
            if (a == null || b == null)
            {
                throw new ArgumentNullException(a == null ? "a" : "b");
            }
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                int aByte = a.ReadByte();
                int bByte = b.ReadByte();
                if (aByte.CompareTo(bByte) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var str = ToImage(cartesianChart1);
            var piestr = ToImage(pieChart1);
            var newList = new List<MemoryStream>();


            bool pieEx = false;
            bool cartEx = false;
            newList.AddRange(memoryStreams);
            if (newList.Count > 0)
            {
                foreach (var stream in newList)
                {
                    if (StreamEquals(str, stream))
                    {
                        cartEx = true;
                    }
                    if (StreamEquals(piestr, stream))
                    {
                        pieEx = true;
                    }
                }
            }
            else
            {
                memoryStreams.Add(str);
                memoryStreams.Add(piestr);
                return;
            }

            if (cartEx == false)
            {
                memoryStreams.Add(str);
            }
            if (pieEx == false)
            {
                memoryStreams.Add(piestr);
            }

        }
    }
}
