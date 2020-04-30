using System.Windows.Forms;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CSAS
{
    public class Import_Cl
    {
        public const string conn = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly string query = string.Format("Select [Meno],[Priezvisko],[Študijný program],[Krúžok],[Prerušené štúdium],[Číslo karty],[Ročník],[E-mail pridelený],[E-mail osobný] FROM[{0}] ", "Export table$A6:AK");
        public Import_Cl()
        {

        }

        bool warnUser = false;
        List<int> notAddedStuds = new List<int>();
        bool didntHappened = false;
        StudentSkupina group;
        public void Querys(StudentSkupina skupina)
        {
            try
            {
                group = skupina;
                var path = SelectPath();
                if (path != "Cancel")
                {
                    string constr = ExcelConnection(path);
                    var excelCon = new OleDbConnection(constr);

                    OleDbCommand Ecom = new OleDbCommand(query, excelCon);
                    excelCon.Open();

                    DataSet excelDataSet = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, excelCon);
                    adapter.Fill(excelDataSet);
                    excelCon.Close();

                    DataTable excelDataTable = excelDataSet.Tables[0];
                    for (int i = excelDataTable.Rows.Count - 1; i >= 0; i--)
                    {
                        if ( (string)excelDataTable.Rows[i].ItemArray[5] == "A")
                        {
                            didntHappened = true;

                            notAddedStuds.Add(i+7);
                            excelDataTable.Rows[i].Delete();

                        }

                    }
                    excelDataTable.AcceptChanges();



                    using (var con = new StudentDBDataContext(conn))
                    {

                        for (int i = 0; i <= excelDataTable.Rows.Count - 1; i++)
                        {
                           var form= (string)excelDataTable.Rows[i].ItemArray[2];
                            if (form.ElementAt(form.Length-3) =='D' && !skupina.Forma.Contains("Denná") || form.ElementAt(form.Length - 3) == 'E' && !skupina.Forma.Contains("Externá"))
                            {
                                didntHappened = false;
                                warnUser = true;
                                continue;
                            }



                            string isic = null;
                            if (!string.IsNullOrEmpty((string)excelDataTable.Rows[i].ItemArray[5]))
                            {
                                 isic = excelDataTable.Rows[i].ItemArray[5].ToString().Remove(0, 5);
                            }
                  

                            Student students = new Student
                            {
                                Meno = excelDataTable.Rows[i].ItemArray[0].ToString(),
                                Priezvisko = excelDataTable.Rows[i].ItemArray[1].ToString(),
                                Stud_program = excelDataTable.Rows[i].ItemArray[2].ToString(),
                                ID_stud_skupina = skupina.Id,
                                ID_Kruzok = excelDataTable.Rows[i].ItemArray[3].ToString(),
                                IdGroupForAttendance= excelDataTable.Rows[i].ItemArray[3].ToString(),
                                Email = excelDataTable.Rows[i].ItemArray[8].ToString(),
                                Email_UCM = excelDataTable.Rows[i].ItemArray[7].ToString(),
                                Rocnik = Convert.ToInt32(excelDataTable.Rows[i].ItemArray[6]),
                                ISIC =   isic, 
                                Forma = skupina.Forma


                            };

                            if (!Exists(students))
                            {
                                con.Students.InsertOnSubmit(students);
                                con.SubmitChanges();
                            }
                            else
                            {
                                continue;
                            }

                        };

                        if (warnUser == true )
                        {
                            MessageBox.Show("Nie je možné pridávať študentov externej formy do skupiny určenej pre denných študentov.","Upozornenie");
                        }

                        if (notAddedStuds.Count >= 1 && didntHappened == true)
                        {

                            string warning = $"Študenti z tabuľky na pozíciach"+ " "+ string.Join(string.Empty,notAddedStuds.ToArray()) +" "+ "neboli pridaný";
                            MessageBox.Show(warning);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()) ;
                // MessageBox.Show("Vybrali ste nesprávny súbor alebo štruktúra súboru je chybná","Chyba pri načítaní súboru",MessageBoxButtons.OK);
            }
        }



        private string ExcelConnection(string fileName)
        {
            return "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + fileName + ";" + " Extended Properties =\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
        }


        private string SelectPath()
        {
            try
            {
                OpenFileDialog path = new OpenFileDialog
                {
                    Filter = "Excel|*.xls;*.xlsx;"
                };

                DialogResult result = path.ShowDialog();
                if (result == DialogResult.OK)

                {
                    return path.FileName.ToString();
                }
                else
                {
                    return DialogResult.Cancel.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You have selected incorrect file");
                return null;
            }
        }


        private bool Exists(Student student)
        {
            try
            {
                var con = new StudentDBDataContext(conn);

                var ifExists = con.GetTable<Student>();

                var existingIsic = ifExists.Where(x => x.ID_stud_skupina==group.Id && x.ISIC == student.ISIC);

                if (existingIsic.Count() ==0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw new DataException();
            }
        }
    }

}
