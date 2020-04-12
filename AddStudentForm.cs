using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAS
{
    public partial class AddStudentForm : MaterialSkin.Controls.MaterialForm
    {
        User currUser;
        StudentSkupina skup;
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        Dictionary<string, int> students = new Dictionary<string, int>();

        public AddStudentForm(User user, StudentSkupina skupina)
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
                MaterialSkin.TextShade.WHITE);

            currUser = user;
            skup = skupina;

            using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
            {
                var students = con.GetTable<Student>().Where(x => x.ID_stud_skupina == skup.Id);
                var kruzok = from stud in students where stud.ID_stud_skupina == skup.Id select (string)stud.IdGroupForAttendance;


                kruzok.ToList<string>();
                foreach (var kruz in kruzok.Distinct())
                {
                    if (!GroupAttCombo.Items.Contains(kruz))
                    {
                        GroupAttCombo.Items.Add(kruz);
                        GroupCombo.Items.Add(kruz);
                    }
                }
            }
            RadioCheck();

        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void AddStudRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioCheck();
        }

        private void RadioCheck()
        {
            if (AddStudRadio.Checked)
            {
                SaveBtn.Text = "Vytvoriť";
                StudentsCombo.Enabled = false;
                LoadStudentBtn.Enabled = false;
            }
            else if (EditStudRadio.Checked)
            {
                SaveBtn.Text = "Uložiť";
                StudentsCombo.Enabled = true;
                LoadStudentBtn.Enabled = true;

                try
                {
                    using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                    {
                        var studs = con.GetTable<Student>().Where(x => x.ID_stud_skupina == skup.Id);
                        foreach (var stud in studs)
                        {
                            if (!StudentsCombo.Items.Contains(stud.Meno + " " + stud.Priezvisko))
                            {
                                StudentsCombo.Items.Add(stud.Meno + " " + stud.Priezvisko);
                                students.Add(stud.Meno + " " + stud.Priezvisko, stud.Id);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }


        private bool IsicValidator()
        {
            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    var studs = con.GetTable<Student>().Where(x => x.ID_stud_skupina == skup.Id);
                    if (studs != null)
                    {
                        foreach (var stud in studs)
                        {
                            if ( !string.IsNullOrEmpty(IsicBox.Text) && !string.IsNullOrWhiteSpace(IsicBox.Text) && IsicBox.Text == stud.ISIC)
                            {
                                MessageBox.Show("Študent s týmto Isic-om už existuje");
                                return false;
                            }
                            else continue;

                        }
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private bool StudentBoxesValidator()
        {
            if (!OnlyLetters(this.NameBox.Text, 2, 30))
            {
                MessageBox.Show("Meno nemôže mať viac ako 30 znakov a menej ako 2 nemôže obsahovať špeciálne znaky ani čísla", "Chyba");
                NameBox.SelectAll();
                NameBox.Focus();
                return false;
            }
            else if (!OnlyLetters(this.SurnameBox.Text, 2, 35))
            {
                MessageBox.Show("Priezvisko nemôže mať viac ako 35 znakov a menej ako 2 nemôže obsahovať špeciálne znaky ani čísla", "Chyba");
                SurnameBox.SelectAll();
                SurnameBox.Focus();
                return false;
            }
            else if (!ContainsSpecialCharacters(this.EmailBox.Text, 7, 55))
            {
                MessageBox.Show("Uistite sa, že email obsahuje @ a dĺžka nepresiahla 55 znakov.", "Chyba");
                EmailBox.SelectAll();
                EmailBox.Focus();
                return false;
            }
            else if (!string.IsNullOrEmpty(EmailUcmBox.Text) || !string.IsNullOrWhiteSpace(EmailUcmBox.Text))
            {
                if (!ContainsSpecialCharacters(this.EmailUcmBox.Text, 7, 55))
                {
                    MessageBox.Show("Uistite sa, že email obsahuje @ a dĺžka nepresiahla 55 znakov.", "Chyba");
                    EmailUcmBox.SelectAll();
                    EmailUcmBox.Focus();
                    return false;
                }
            }
            else if (!string.IsNullOrWhiteSpace(this.IsicBox.Text) || !string.IsNullOrEmpty(this.IsicBox.Text)) {
                if (!OnlyNumericCharacters(this.IsicBox.Text, 17, 17))
                {
                    MessageBox.Show("Uistite sa, že ISIC obsahuje iba čísla a dĺžka nepresiahla 17 znakov.", "Chyba");

                    return false;
                }
            }
            if(!OnlyNumericCharacters(this.GradeBox.Text,1,3))
            {
                MessageBox.Show("Uistite sa, že ročník obsahuje čísla a dĺžka nepresiahla 3 znaky.", "Chyba");
                return false;
            }

            return true;
        }

        public bool OnlyLetters( string inputString, int minLen, int maxLen)
        {
            if (inputString.Length < minLen || inputString.Length > maxLen) return false;
            foreach(var x in inputString)
            {
                if(!char.IsLetter(x))
                {
                    return false;
                }

            }
            return true;
        }
        public bool OnlyNumericCharacters(string inputString, int minLen, int maxLen)
        {
            if (inputString.Length < minLen || inputString.Length > maxLen) return false;
            foreach (var x in inputString)
            {
                if (!char.IsNumber(x))
                {
                    return false;
                }

            }
            return true;

        }

        public  bool OnlyAlphaNumericCharacters(string inputString, int minLen, int maxLen)
        {

            if (inputString.Length < minLen || inputString.Length > maxLen) return false;
            foreach (var x in inputString)
            {
                if (!char.IsLetterOrDigit(x))
                {
                    return false;
                }

            }
            return true;
        }

        public bool ContainsSpecialCharacters(string inputString, int minLen, int maxLen)
        {
            if (inputString.Length < minLen || inputString.Length > maxLen) return false;
            if (!inputString.Contains("@") || !inputString.Contains(".")) return false;
            return true;
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {
                    if (AddStudRadio.Checked )
                    {
                        int.TryParse(GradeBox.Text, out int rocnik);
                        Student newStudent = new Student()
                        {
                            Meno = NameBox.Text,
                            Priezvisko = SurnameBox.Text,
                            Email = EmailBox.Text,
                            Email_UCM = EmailUcmBox.Text,
                            ISIC = IsicBox.Text,
                            ID_stud_skupina = skup.Id,/// change studprogram
                            Stud_program = skup.Nazov,

                            Forma = skup.Forma,
                            Rocnik = rocnik
                        };
                        if (GroupCombo.SelectedItem != null && GroupAttCombo.SelectedItem != null)
                        {
                            newStudent.IdGroupForAttendance = (string)GroupAttCombo.SelectedItem;
                            newStudent.ID_Kruzok = (string)GroupCombo.SelectedItem;
                        }
                        else
                        {
                            newStudent.IdGroupForAttendance = GroupAttCombo.Text;
                            newStudent.ID_Kruzok = GroupCombo.Text;
                        }
                        if (StudentBoxesValidator() && IsicValidator())
                        {
                            con.Students.InsertOnSubmit(newStudent);
                            con.SubmitChanges();
                            MessageBox.Show("Študent bol úspešne pridaný/upravený");
                        }
                        else
                        {
                            return;
                        }
                        
                    }
                    else
                    {
                        if ((string)StudentsCombo.SelectedValue != string.Empty  && StudentBoxesValidator())
                        {

                            var student = students.TryGetValue(StudentsCombo.Text, out int value);
                            Student editStudent = con.GetTable<Student>().Where(x => x.Id == value && x.ID_stud_skupina == skup.Id).FirstOrDefault();
                            int.TryParse(GradeBox.Text, out int rocnik);

                            editStudent.Meno = NameBox.Text;
                            editStudent.Priezvisko = SurnameBox.Text;
                            editStudent.Email = EmailBox.Text;
                            editStudent.Email_UCM = EmailUcmBox.Text;
                            editStudent.ISIC = IsicBox.Text;
                            editStudent.ID_stud_skupina = skup.Id;/// change studprogram
                            editStudent.Stud_program = editStudent.Stud_program;
                            editStudent.IdGroupForAttendance = (string)GroupAttCombo.SelectedItem;
                            editStudent.ID_Kruzok = (string)GroupCombo.SelectedItem;
                            editStudent.Forma = skup.Forma;
                            editStudent.Rocnik = rocnik;

                            con.SubmitChanges();
                            MessageBox.Show("Študent bol úspešne pridaný/upravený");
                        }
                        else
                        {
                            return;
                        }
                        

                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        public event Action GetTable;

        

        private void LoadStudentBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                using (StudentDBDataContext con = new StudentDBDataContext(conn_str))
                {

                    if ((string)StudentsCombo.SelectedValue != string.Empty)
                    {

                       students.TryGetValue(StudentsCombo.Text, out int value);
                        var currentStudent = con.GetTable<Student>().Where(x => x.Id == value && x.ID_stud_skupina == skup.Id).FirstOrDefault();

                        NameBox.Text = currentStudent.Meno;
                        SurnameBox.Text = currentStudent.Priezvisko;
                        EmailBox.Text = currentStudent.Email;
                        EmailUcmBox.Text = currentStudent.Email_UCM;
                        IsicBox.Text = currentStudent.ISIC;
                        GroupCombo.Items.Add(currentStudent.ID_Kruzok);
                        GroupAttCombo.Items.Add(currentStudent.IdGroupForAttendance);
                        GradeBox.Text = currentStudent.Rocnik.ToString();
                        GroupCombo.SelectedItem = currentStudent.ID_Kruzok;
                        GroupAttCombo.SelectedItem = currentStudent.IdGroupForAttendance;
                    }
                    else
                    {
                        MessageBox.Show("Je nutné vybrať študenta, ktorého chcete upraviť","Chyba");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger newLog = new Logger();
                newLog.LogError(ex);
                MessageBox.Show(ex.ToString()); 
            }
        }

        private void AddStudentForm_Leave(object sender, EventArgs e)
        {
            GetTable();
        }

        private void GroupCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

