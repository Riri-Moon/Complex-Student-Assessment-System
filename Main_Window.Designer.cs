namespace CSAS
{
    partial class Main_Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Activity_Grid = new System.Windows.Forms.DataGridView();
            this.Student_Grid = new System.Windows.Forms.DataGridView();
            this.Study_Panel = new System.Windows.Forms.Panel();
            this.Stud_G_Button = new System.Windows.Forms.Button();
            this.Import_Btn = new System.Windows.Forms.Button();
            this.Stat_Btn = new System.Windows.Forms.Button();
            this.Open_Btn = new System.Windows.Forms.Button();
            this.Export_Btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Attendance_Button = new System.Windows.Forms.Button();
            this.Activity_panel = new System.Windows.Forms.Panel();
            this.Create_Templ = new System.Windows.Forms.Button();
            this.Create_Act_Btn = new System.Windows.Forms.Button();
            this.Activity_Button = new System.Windows.Forms.Button();
            this.Student_Panel = new System.Windows.Forms.Panel();
            this.Add_Stud_Button = new System.Windows.Forms.Button();
            this.Student_Button = new System.Windows.Forms.Button();
            this.Settings_Panel = new System.Windows.Forms.Panel();
            this.Archive_Btn = new System.Windows.Forms.Button();
            this.Delete_all_data_btn = new System.Windows.Forms.Button();
            this.Email_client_btn = new System.Windows.Forms.Button();
            this.Gear_Button = new System.Windows.Forms.Button();
            this.OdoslatEmailBtnMainMenu = new System.Windows.Forms.Button();
            this.Ext_Btn = new System.Windows.Forms.Button();
            this.ProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Activity_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student_Grid)).BeginInit();
            this.Study_Panel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Activity_panel.SuspendLayout();
            this.Student_Panel.SuspendLayout();
            this.Settings_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Activity_Grid
            // 
            this.Activity_Grid.AllowUserToAddRows = false;
            this.Activity_Grid.AllowUserToOrderColumns = true;
            this.Activity_Grid.BackgroundColor = System.Drawing.Color.White;
            this.Activity_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Activity_Grid.Location = new System.Drawing.Point(895, 175);
            this.Activity_Grid.Name = "Activity_Grid";
            this.Activity_Grid.Size = new System.Drawing.Size(403, 468);
            this.Activity_Grid.TabIndex = 0;
            // 
            // Student_Grid
            // 
            this.Student_Grid.AllowUserToAddRows = false;
            this.Student_Grid.AllowUserToDeleteRows = false;
            this.Student_Grid.AllowUserToResizeColumns = false;
            this.Student_Grid.AllowUserToResizeRows = false;
            this.Student_Grid.BackgroundColor = System.Drawing.Color.White;
            this.Student_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Student_Grid.Location = new System.Drawing.Point(190, 175);
            this.Student_Grid.MultiSelect = false;
            this.Student_Grid.Name = "Student_Grid";
            this.Student_Grid.Size = new System.Drawing.Size(689, 468);
            this.Student_Grid.TabIndex = 1;
            // 
            // Study_Panel
            // 
            this.Study_Panel.AllowDrop = true;
            this.Study_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Study_Panel.Controls.Add(this.Stud_G_Button);
            this.Study_Panel.Controls.Add(this.Import_Btn);
            this.Study_Panel.Controls.Add(this.Stat_Btn);
            this.Study_Panel.Controls.Add(this.Open_Btn);
            this.Study_Panel.Controls.Add(this.Export_Btn);
            this.Study_Panel.Location = new System.Drawing.Point(3, 3);
            this.Study_Panel.MaximumSize = new System.Drawing.Size(175, 168);
            this.Study_Panel.MinimumSize = new System.Drawing.Size(175, 48);
            this.Study_Panel.Name = "Study_Panel";
            this.Study_Panel.Size = new System.Drawing.Size(175, 168);
            this.Study_Panel.TabIndex = 4;
            // 
            // Stud_G_Button
            // 
            this.Stud_G_Button.AutoEllipsis = true;
            this.Stud_G_Button.BackColor = System.Drawing.Color.Transparent;
            this.Stud_G_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Stud_G_Button.FlatAppearance.BorderSize = 0;
            this.Stud_G_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stud_G_Button.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Stud_G_Button.Image = global::CSAS.Properties.Resources.icons8_expand_arrow_32;
            this.Stud_G_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Stud_G_Button.Location = new System.Drawing.Point(-3, -3);
            this.Stud_G_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Stud_G_Button.Name = "Stud_G_Button";
            this.Stud_G_Button.Size = new System.Drawing.Size(182, 51);
            this.Stud_G_Button.TabIndex = 1;
            this.Stud_G_Button.Text = "Študijná skupina";
            this.Stud_G_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Stud_G_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Stud_G_Button.UseVisualStyleBackColor = false;
            this.Stud_G_Button.Click += new System.EventHandler(this.Stud_G_Button_Click);
            // 
            // Import_Btn
            // 
            this.Import_Btn.AutoEllipsis = true;
            this.Import_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Import_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Import_Btn.FlatAppearance.BorderSize = 0;
            this.Import_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Import_Btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Import_Btn.Location = new System.Drawing.Point(0, 108);
            this.Import_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Import_Btn.Name = "Import_Btn";
            this.Import_Btn.Size = new System.Drawing.Size(175, 30);
            this.Import_Btn.TabIndex = 6;
            this.Import_Btn.Text = "Import";
            this.Import_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Import_Btn.UseVisualStyleBackColor = false;
            this.Import_Btn.Click += new System.EventHandler(this.Import_Btn_Click);
            // 
            // Stat_Btn
            // 
            this.Stat_Btn.AutoEllipsis = true;
            this.Stat_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Stat_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Stat_Btn.FlatAppearance.BorderSize = 0;
            this.Stat_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stat_Btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Stat_Btn.Location = new System.Drawing.Point(0, 138);
            this.Stat_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Stat_Btn.Name = "Stat_Btn";
            this.Stat_Btn.Size = new System.Drawing.Size(175, 30);
            this.Stat_Btn.TabIndex = 7;
            this.Stat_Btn.Text = "Štatistika";
            this.Stat_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Stat_Btn.UseVisualStyleBackColor = false;
            this.Stat_Btn.Click += new System.EventHandler(this.Stat_Btn_Click);
            // 
            // Open_Btn
            // 
            this.Open_Btn.AutoEllipsis = true;
            this.Open_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Open_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Open_Btn.FlatAppearance.BorderSize = 0;
            this.Open_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open_Btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Open_Btn.Location = new System.Drawing.Point(0, 48);
            this.Open_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Open_Btn.Name = "Open_Btn";
            this.Open_Btn.Size = new System.Drawing.Size(175, 30);
            this.Open_Btn.TabIndex = 4;
            this.Open_Btn.Text = "Otvoriť";
            this.Open_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Open_Btn.UseVisualStyleBackColor = false;
            // 
            // Export_Btn
            // 
            this.Export_Btn.AutoEllipsis = true;
            this.Export_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Export_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Export_Btn.FlatAppearance.BorderSize = 0;
            this.Export_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export_Btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Export_Btn.Location = new System.Drawing.Point(0, 78);
            this.Export_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Export_Btn.Name = "Export_Btn";
            this.Export_Btn.Size = new System.Drawing.Size(175, 30);
            this.Export_Btn.TabIndex = 5;
            this.Export_Btn.Text = "Export";
            this.Export_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Export_Btn.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.Study_Panel);
            this.flowLayoutPanel1.Controls.Add(this.Attendance_Button);
            this.flowLayoutPanel1.Controls.Add(this.Activity_panel);
            this.flowLayoutPanel1.Controls.Add(this.Student_Panel);
            this.flowLayoutPanel1.Controls.Add(this.Settings_Panel);
            this.flowLayoutPanel1.Controls.Add(this.OdoslatEmailBtnMainMenu);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 64);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(182, 703);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // Attendance_Button
            // 
            this.Attendance_Button.BackColor = System.Drawing.Color.Transparent;
            this.Attendance_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Attendance_Button.FlatAppearance.BorderSize = 0;
            this.Attendance_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attendance_Button.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Attendance_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Attendance_Button.Location = new System.Drawing.Point(3, 177);
            this.Attendance_Button.MaximumSize = new System.Drawing.Size(179, 48);
            this.Attendance_Button.MinimumSize = new System.Drawing.Size(179, 48);
            this.Attendance_Button.Name = "Attendance_Button";
            this.Attendance_Button.Size = new System.Drawing.Size(179, 48);
            this.Attendance_Button.TabIndex = 2;
            this.Attendance_Button.Text = "Dochádzka";
            this.Attendance_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Attendance_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Attendance_Button.UseVisualStyleBackColor = false;
            this.Attendance_Button.Click += new System.EventHandler(this.Attendance_Button_Click);
            // 
            // Activity_panel
            // 
            this.Activity_panel.BackColor = System.Drawing.Color.Transparent;
            this.Activity_panel.Controls.Add(this.Create_Templ);
            this.Activity_panel.Controls.Add(this.Create_Act_Btn);
            this.Activity_panel.Controls.Add(this.Activity_Button);
            this.Activity_panel.Location = new System.Drawing.Point(3, 231);
            this.Activity_panel.MaximumSize = new System.Drawing.Size(177, 122);
            this.Activity_panel.MinimumSize = new System.Drawing.Size(177, 48);
            this.Activity_panel.Name = "Activity_panel";
            this.Activity_panel.Size = new System.Drawing.Size(177, 117);
            this.Activity_panel.TabIndex = 11;
            // 
            // Create_Templ
            // 
            this.Create_Templ.BackColor = System.Drawing.Color.Transparent;
            this.Create_Templ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Create_Templ.FlatAppearance.BorderSize = 0;
            this.Create_Templ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Templ.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Create_Templ.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create_Templ.Location = new System.Drawing.Point(0, 87);
            this.Create_Templ.Name = "Create_Templ";
            this.Create_Templ.Size = new System.Drawing.Size(179, 30);
            this.Create_Templ.TabIndex = 8;
            this.Create_Templ.Text = "Vytvoriť šablónu";
            this.Create_Templ.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Create_Templ.UseVisualStyleBackColor = false;
            this.Create_Templ.Click += new System.EventHandler(this.Create_Templ_Click);
            // 
            // Create_Act_Btn
            // 
            this.Create_Act_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Create_Act_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Create_Act_Btn.FlatAppearance.BorderSize = 0;
            this.Create_Act_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Act_Btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Create_Act_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create_Act_Btn.Location = new System.Drawing.Point(-1, 51);
            this.Create_Act_Btn.Name = "Create_Act_Btn";
            this.Create_Act_Btn.Size = new System.Drawing.Size(179, 30);
            this.Create_Act_Btn.TabIndex = 6;
            this.Create_Act_Btn.Text = "Vytvoriť aktivitu";
            this.Create_Act_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Create_Act_Btn.UseVisualStyleBackColor = false;
            // 
            // Activity_Button
            // 
            this.Activity_Button.BackColor = System.Drawing.Color.Transparent;
            this.Activity_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Activity_Button.FlatAppearance.BorderSize = 0;
            this.Activity_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Activity_Button.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Activity_Button.Image = global::CSAS.Properties.Resources.icons8_expand_arrow_32;
            this.Activity_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Activity_Button.Location = new System.Drawing.Point(0, 0);
            this.Activity_Button.MinimumSize = new System.Drawing.Size(179, 48);
            this.Activity_Button.Name = "Activity_Button";
            this.Activity_Button.Size = new System.Drawing.Size(179, 48);
            this.Activity_Button.TabIndex = 3;
            this.Activity_Button.Text = "Aktivita";
            this.Activity_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Activity_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Activity_Button.UseVisualStyleBackColor = false;
            this.Activity_Button.Click += new System.EventHandler(this.Activity_Button_Click);
            // 
            // Student_Panel
            // 
            this.Student_Panel.AllowDrop = true;
            this.Student_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Student_Panel.Controls.Add(this.Add_Stud_Button);
            this.Student_Panel.Controls.Add(this.Student_Button);
            this.Student_Panel.Location = new System.Drawing.Point(3, 354);
            this.Student_Panel.MaximumSize = new System.Drawing.Size(176, 78);
            this.Student_Panel.MinimumSize = new System.Drawing.Size(176, 48);
            this.Student_Panel.Name = "Student_Panel";
            this.Student_Panel.Size = new System.Drawing.Size(176, 78);
            this.Student_Panel.TabIndex = 8;
            // 
            // Add_Stud_Button
            // 
            this.Add_Stud_Button.BackColor = System.Drawing.Color.Transparent;
            this.Add_Stud_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Add_Stud_Button.FlatAppearance.BorderSize = 0;
            this.Add_Stud_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Stud_Button.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Add_Stud_Button.Location = new System.Drawing.Point(0, 48);
            this.Add_Stud_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Add_Stud_Button.Name = "Add_Stud_Button";
            this.Add_Stud_Button.Size = new System.Drawing.Size(175, 30);
            this.Add_Stud_Button.TabIndex = 5;
            this.Add_Stud_Button.Text = "New Student";
            this.Add_Stud_Button.UseVisualStyleBackColor = false;
            // 
            // Student_Button
            // 
            this.Student_Button.AutoEllipsis = true;
            this.Student_Button.BackColor = System.Drawing.Color.Transparent;
            this.Student_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Student_Button.FlatAppearance.BorderSize = 0;
            this.Student_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Student_Button.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Student_Button.Image = global::CSAS.Properties.Resources.icons8_expand_arrow_32;
            this.Student_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Student_Button.Location = new System.Drawing.Point(0, 0);
            this.Student_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Student_Button.MinimumSize = new System.Drawing.Size(179, 48);
            this.Student_Button.Name = "Student_Button";
            this.Student_Button.Size = new System.Drawing.Size(179, 48);
            this.Student_Button.TabIndex = 4;
            this.Student_Button.Text = "Študent";
            this.Student_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Student_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Student_Button.UseVisualStyleBackColor = false;
            this.Student_Button.Click += new System.EventHandler(this.Student_Button_Click);
            // 
            // Settings_Panel
            // 
            this.Settings_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Panel.Controls.Add(this.Archive_Btn);
            this.Settings_Panel.Controls.Add(this.Delete_all_data_btn);
            this.Settings_Panel.Controls.Add(this.Email_client_btn);
            this.Settings_Panel.Controls.Add(this.Gear_Button);
            this.Settings_Panel.Location = new System.Drawing.Point(3, 438);
            this.Settings_Panel.MaximumSize = new System.Drawing.Size(179, 153);
            this.Settings_Panel.MinimumSize = new System.Drawing.Size(179, 48);
            this.Settings_Panel.Name = "Settings_Panel";
            this.Settings_Panel.Size = new System.Drawing.Size(179, 153);
            this.Settings_Panel.TabIndex = 12;
            // 
            // Archive_Btn
            // 
            this.Archive_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Archive_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Archive_Btn.FlatAppearance.BorderSize = 0;
            this.Archive_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Archive_Btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Archive_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Archive_Btn.Location = new System.Drawing.Point(0, 120);
            this.Archive_Btn.Name = "Archive_Btn";
            this.Archive_Btn.Size = new System.Drawing.Size(179, 30);
            this.Archive_Btn.TabIndex = 9;
            this.Archive_Btn.Text = "Archive";
            this.Archive_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Archive_Btn.UseVisualStyleBackColor = false;
            // 
            // Delete_all_data_btn
            // 
            this.Delete_all_data_btn.BackColor = System.Drawing.Color.Transparent;
            this.Delete_all_data_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Delete_all_data_btn.FlatAppearance.BorderSize = 0;
            this.Delete_all_data_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_all_data_btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Delete_all_data_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete_all_data_btn.Location = new System.Drawing.Point(0, 88);
            this.Delete_all_data_btn.Name = "Delete_all_data_btn";
            this.Delete_all_data_btn.Size = new System.Drawing.Size(179, 30);
            this.Delete_all_data_btn.TabIndex = 8;
            this.Delete_all_data_btn.Text = "Delete All Data";
            this.Delete_all_data_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Delete_all_data_btn.UseVisualStyleBackColor = false;
            // 
            // Email_client_btn
            // 
            this.Email_client_btn.BackColor = System.Drawing.Color.Transparent;
            this.Email_client_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Email_client_btn.FlatAppearance.BorderSize = 0;
            this.Email_client_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Email_client_btn.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Email_client_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Email_client_btn.Location = new System.Drawing.Point(2, 52);
            this.Email_client_btn.Name = "Email_client_btn";
            this.Email_client_btn.Size = new System.Drawing.Size(179, 30);
            this.Email_client_btn.TabIndex = 7;
            this.Email_client_btn.Text = "Email Client";
            this.Email_client_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Email_client_btn.UseVisualStyleBackColor = false;
            this.Email_client_btn.Click += new System.EventHandler(this.Email_client_btn_Click_1);
            // 
            // Gear_Button
            // 
            this.Gear_Button.BackColor = System.Drawing.Color.Transparent;
            this.Gear_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Gear_Button.FlatAppearance.BorderSize = 0;
            this.Gear_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gear_Button.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Gear_Button.Image = global::CSAS.Properties.Resources.icons8_expand_arrow_32;
            this.Gear_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Gear_Button.Location = new System.Drawing.Point(-1, 0);
            this.Gear_Button.MinimumSize = new System.Drawing.Size(179, 48);
            this.Gear_Button.Name = "Gear_Button";
            this.Gear_Button.Size = new System.Drawing.Size(179, 48);
            this.Gear_Button.TabIndex = 5;
            this.Gear_Button.Text = "Nastavenia";
            this.Gear_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gear_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Gear_Button.UseVisualStyleBackColor = false;
            this.Gear_Button.Click += new System.EventHandler(this.Gear_Button_Click);
            // 
            // OdoslatEmailBtnMainMenu
            // 
            this.OdoslatEmailBtnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.OdoslatEmailBtnMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OdoslatEmailBtnMainMenu.FlatAppearance.BorderSize = 0;
            this.OdoslatEmailBtnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OdoslatEmailBtnMainMenu.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.OdoslatEmailBtnMainMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OdoslatEmailBtnMainMenu.Location = new System.Drawing.Point(3, 597);
            this.OdoslatEmailBtnMainMenu.MaximumSize = new System.Drawing.Size(179, 48);
            this.OdoslatEmailBtnMainMenu.MinimumSize = new System.Drawing.Size(179, 48);
            this.OdoslatEmailBtnMainMenu.Name = "OdoslatEmailBtnMainMenu";
            this.OdoslatEmailBtnMainMenu.Size = new System.Drawing.Size(179, 48);
            this.OdoslatEmailBtnMainMenu.TabIndex = 13;
            this.OdoslatEmailBtnMainMenu.Text = "Odoslať email";
            this.OdoslatEmailBtnMainMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OdoslatEmailBtnMainMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.OdoslatEmailBtnMainMenu.UseVisualStyleBackColor = false;
            this.OdoslatEmailBtnMainMenu.Click += new System.EventHandler(this.OdoslatEmailBtnMainMenu_Click);
            // 
            // Ext_Btn
            // 
            this.Ext_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Ext_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Ext_Btn.FlatAppearance.BorderSize = 0;
            this.Ext_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ext_Btn.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Ext_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Ext_Btn.Location = new System.Drawing.Point(3, 773);
            this.Ext_Btn.Name = "Ext_Btn";
            this.Ext_Btn.Size = new System.Drawing.Size(179, 53);
            this.Ext_Btn.TabIndex = 10;
            this.Ext_Btn.Text = "Exit";
            this.Ext_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Ext_Btn.UseVisualStyleBackColor = false;
            this.Ext_Btn.Click += new System.EventHandler(this.Ext_Btn_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Depth = 0;
            this.ProgressBar1.Location = new System.Drawing.Point(190, 175);
            this.ProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(689, 5);
            this.ProgressBar1.TabIndex = 11;
            // 
            // Main_Window
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1341, 836);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Student_Grid);
            this.Controls.Add(this.Activity_Grid);
            this.Controls.Add(this.Ext_Btn);
            this.Name = "Main_Window";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Activity_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student_Grid)).EndInit();
            this.Study_Panel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Activity_panel.ResumeLayout(false);
            this.Student_Panel.ResumeLayout(false);
            this.Settings_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Activity_Grid;
        private System.Windows.Forms.DataGridView Student_Grid;
        private System.Windows.Forms.Button Student_Button;
        private System.Windows.Forms.Button Activity_Button;
        private System.Windows.Forms.Panel Study_Panel;
        private System.Windows.Forms.Button Import_Btn;
        private System.Windows.Forms.Button Stat_Btn;
        private System.Windows.Forms.Button Open_Btn;
        private System.Windows.Forms.Button Export_Btn;
        private System.Windows.Forms.Button Gear_Button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel Student_Panel;
        private System.Windows.Forms.Button Add_Stud_Button;
        private System.Windows.Forms.Button Attendance_Button;
        private System.Windows.Forms.Button Ext_Btn;
        private System.Windows.Forms.Panel Activity_panel;
        private System.Windows.Forms.Button Create_Templ;
        private System.Windows.Forms.Button Create_Act_Btn;
        private System.Windows.Forms.Panel Settings_Panel;
        private System.Windows.Forms.Button Archive_Btn;
        private System.Windows.Forms.Button Delete_all_data_btn;
        private System.Windows.Forms.Button Email_client_btn;
        private System.Windows.Forms.Button Stud_G_Button;
        private MaterialSkin.Controls.MaterialProgressBar ProgressBar1;
        private System.Windows.Forms.Button OdoslatEmailBtnMainMenu;
    }
}