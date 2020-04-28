using System;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections;
using System.Linq;
using System.Threading;
using System.ComponentModel;

namespace CSAS
{
    public partial class Choose_Group : MaterialSkin.Controls.MaterialForm
    {

        public StudentSkupina Selected { get; set; }
        private const string conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public User loggedUser = new User();

        BackgroundWorker _worker = new BackgroundWorker();
        SynchronizationContext _syncContext;

        public Choose_Group(User user)
        {
            InitializeComponent();


            _syncContext = SynchronizationContext.Current;
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;

            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Blue400,
               MaterialSkin.TextShade.WHITE);

            DataContext con = new DataContext(conn_str);
            con.Connection.Open();
            loggedUser = user;

            Skupiny_Grid.RowHeadersVisible = false;
            Skupiny_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Skupiny_Grid.MultiSelect = false;
            Skupiny_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Skupiny_Grid.DataSource = con.GetTable<StudentSkupina>()?.Where(x => x.Id_User == loggedUser.Id);
            Skupiny_Grid.Columns["ID"].Visible = false;
            Skupiny_Grid.Columns["Id_User"].Visible = false;
            Skupiny_Grid.Columns["User"].Visible = false;
            skinManager.AddFormToManage(this);

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
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }


        }
    
        private void Remove_button_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Are you sure you want to remove study group ?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }


        public void Started()
        {
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += new DoWorkEventHandler(HandleDoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HandleWorkerCompleted);
            _worker.ProgressChanged += new ProgressChangedEventHandler(HandleProgressChanged);
            _worker.RunWorkerAsync();
            
        }

        public void HandleDoWork(object sender, DoWorkEventArgs e)
        {

            BeginInvoke(new Action(() => {
            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                Selected = (StudentSkupina)Skupiny_Grid.CurrentRow.DataBoundItem;
                Main_Window main_ = new Main_Window(Selected, loggedUser);
                    main_.FormClosed += (s, args) => this.Close();
                    main_.Show();
            }
            }));
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_worker.WorkerSupportsCancellation)
            {
                _worker.CancelAsync();
            }
        }

        public StudentSkupina GetGroup()
        {
            Selected = (StudentSkupina)Skupiny_Grid.CurrentRow.DataBoundItem;

            return Selected;
        }
        public void HandleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
        }

        public void HandleProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // DO Progress Bar Updates Here
            SendOrPostCallback callback = new SendOrPostCallback((o) =>
            {
            });
            _syncContext.Send(callback, null);
        }

        private void Choose_Group_Load(object sender, EventArgs e)
        {

        }

        public void Select_Button_Click_1(object sender, EventArgs e)
        {
           // this.Hide();
            Started();
        }


        private void Remove_Button_Click_1(object sender, EventArgs e)
        {

        }

        private void Exit_Button_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete skončiť?","Ukončiť",MessageBoxButtons.YesNo,MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            var newgrp = new CreateNewGroupForm(loggedUser);
            DialogResult result = newgrp.ShowDialog();
            if(result== DialogResult.OK)
            {
                DataContext con = new DataContext(conn_str);
                con.Connection.Open();

                Skupiny_Grid.RowHeadersVisible = false;
                Skupiny_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Skupiny_Grid.MultiSelect = false;
                Skupiny_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //// CHANGE TO GET ACTUAL USER
                Skupiny_Grid.DataSource = con.GetTable<StudentSkupina>()?.Where(x => x.Id_User == loggedUser.Id);
                Skupiny_Grid.Columns["ID"].Visible = false;
                Skupiny_Grid.Columns["Id_User"].Visible = false;
                Skupiny_Grid.Columns["User"].Visible = false;
            }
            
        }
    }
}
