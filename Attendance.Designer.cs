namespace CSAS
{
    partial class Dochádzka
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.radioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.Back_Att = new MaterialSkin.Controls.MaterialButton();
            this.CreateButton = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.RemoveBtn = new MaterialSkin.Controls.MaterialButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.attGrid = new System.Windows.Forms.DataGridView();
            this.AddManualAttendanceBtn = new MaterialSkin.Controls.MaterialButton();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.TotalLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.TotalPresentLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.TotalAbsentLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.NameOfStudLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.attGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.White;
            this.radioButton1.Checked = true;
            this.radioButton1.Depth = 0;
            this.radioButton1.Location = new System.Drawing.Point(42, 75);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Ripple = true;
            this.radioButton1.Size = new System.Drawing.Size(110, 37);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Prednáška";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.White;
            this.radioButton2.Depth = 0;
            this.radioButton2.Location = new System.Drawing.Point(163, 75);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Ripple = true;
            this.radioButton2.Size = new System.Drawing.Size(94, 37);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Cvičenie";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // Back_Att
            // 
            this.Back_Att.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Back_Att.Depth = 0;
            this.Back_Att.DrawShadows = true;
            this.Back_Att.HighEmphasis = true;
            this.Back_Att.Icon = null;
            this.Back_Att.Location = new System.Drawing.Point(13, 568);
            this.Back_Att.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Back_Att.MouseState = MaterialSkin.MouseState.HOVER;
            this.Back_Att.Name = "Back_Att";
            this.Back_Att.Size = new System.Drawing.Size(58, 36);
            this.Back_Att.TabIndex = 8;
            this.Back_Att.Text = "Späť";
            this.Back_Att.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Back_Att.UseAccentColor = false;
            this.Back_Att.UseVisualStyleBackColor = true;
            this.Back_Att.Click += new System.EventHandler(this.Back_Att_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.AutoEllipsis = true;
            this.CreateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateButton.Depth = 0;
            this.CreateButton.DrawShadows = true;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.HighEmphasis = true;
            this.CreateButton.Icon = null;
            this.CreateButton.Location = new System.Drawing.Point(861, 114);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(90, 36);
            this.CreateButton.TabIndex = 9;
            this.CreateButton.Text = "Vytvoriť";
            this.CreateButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateButton.UseAccentColor = false;
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(550, 124);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(103, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Dochádzka na";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.White;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(578, 169);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Pre krúžok";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(659, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.TextChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(659, 124);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveBtn.Depth = 0;
            this.RemoveBtn.DrawShadows = true;
            this.RemoveBtn.HighEmphasis = true;
            this.RemoveBtn.Icon = null;
            this.RemoveBtn.Location = new System.Drawing.Point(861, 159);
            this.RemoveBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(101, 36);
            this.RemoveBtn.TabIndex = 15;
            this.RemoveBtn.Text = "Odstrániť";
            this.RemoveBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RemoveBtn.UseAccentColor = false;
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(280, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Depth = 0;
            this.button1.DrawShadows = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(421, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 36);
            this.button1.TabIndex = 17;
            this.button1.Text = "Potvrdiť";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // attGrid
            // 
            this.attGrid.AllowUserToResizeRows = false;
            this.attGrid.BackgroundColor = System.Drawing.Color.White;
            this.attGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.attGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.attGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.attGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.attGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.attGrid.Location = new System.Drawing.Point(19, 124);
            this.attGrid.Name = "attGrid";
            this.attGrid.RowHeadersVisible = false;
            this.attGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.attGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.attGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.attGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.attGrid.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.attGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.attGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.attGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.attGrid.Size = new System.Drawing.Size(503, 433);
            this.attGrid.TabIndex = 0;
            this.attGrid.SelectionChanged += new System.EventHandler(this.attGrid_SelectionChanged);
            // 
            // AddManualAttendanceBtn
            // 
            this.AddManualAttendanceBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddManualAttendanceBtn.Depth = 0;
            this.AddManualAttendanceBtn.DrawShadows = true;
            this.AddManualAttendanceBtn.HighEmphasis = true;
            this.AddManualAttendanceBtn.Icon = null;
            this.AddManualAttendanceBtn.Location = new System.Drawing.Point(861, 203);
            this.AddManualAttendanceBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddManualAttendanceBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddManualAttendanceBtn.Name = "AddManualAttendanceBtn";
            this.AddManualAttendanceBtn.Size = new System.Drawing.Size(151, 36);
            this.AddManualAttendanceBtn.TabIndex = 18;
            this.AddManualAttendanceBtn.Text = "Pridať študenta";
            this.AddManualAttendanceBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddManualAttendanceBtn.UseAccentColor = false;
            this.AddManualAttendanceBtn.UseVisualStyleBackColor = true;
            this.AddManualAttendanceBtn.Click += new System.EventHandler(this.AddManualAttendanceBtn_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(659, 212);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(179, 21);
            this.comboBox3.TabIndex = 19;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Depth = 0;
            this.TotalLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TotalLabel.Location = new System.Drawing.Point(668, 372);
            this.TotalLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(1, 0);
            this.TotalLabel.TabIndex = 20;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(552, 372);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(109, 19);
            this.materialLabel4.TabIndex = 21;
            this.materialLabel4.Text = "Celkovo hodín: ";
            // 
            // TotalPresentLabel
            // 
            this.TotalPresentLabel.AutoSize = true;
            this.TotalPresentLabel.Depth = 0;
            this.TotalPresentLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TotalPresentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TotalPresentLabel.Location = new System.Drawing.Point(668, 406);
            this.TotalPresentLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.TotalPresentLabel.Name = "TotalPresentLabel";
            this.TotalPresentLabel.Size = new System.Drawing.Size(1, 0);
            this.TotalPresentLabel.TabIndex = 22;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(552, 406);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(95, 19);
            this.materialLabel6.TabIndex = 23;
            this.materialLabel6.Text = "Prítomný na: ";
            // 
            // TotalAbsentLabel
            // 
            this.TotalAbsentLabel.AutoSize = true;
            this.TotalAbsentLabel.Depth = 0;
            this.TotalAbsentLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TotalAbsentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TotalAbsentLabel.Location = new System.Drawing.Point(670, 442);
            this.TotalAbsentLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.TotalAbsentLabel.Name = "TotalAbsentLabel";
            this.TotalAbsentLabel.Size = new System.Drawing.Size(1, 0);
            this.TotalAbsentLabel.TabIndex = 24;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(554, 442);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(80, 19);
            this.materialLabel8.TabIndex = 25;
            this.materialLabel8.Text = "Chýbal na: ";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(521, 300);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(1, 0);
            this.materialLabel9.TabIndex = 26;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(552, 334);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(115, 19);
            this.materialLabel3.TabIndex = 27;
            this.materialLabel3.Text = "Meno študenta: ";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(659, 259);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(84, 21);
            this.comboBox4.TabIndex = 29;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(749, 259);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(144, 21);
            this.comboBox5.TabIndex = 30;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.White;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(617, 261);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(36, 19);
            this.materialLabel5.TabIndex = 31;
            this.materialLabel5.Text = "Filter";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.BackColor = System.Drawing.Color.White;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(528, 214);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(125, 19);
            this.materialLabel7.TabIndex = 32;
            this.materialLabel7.Text = "Pridanie študenta";
            // 
            // NameOfStudLabel
            // 
            this.NameOfStudLabel.AutoSize = true;
            this.NameOfStudLabel.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NameOfStudLabel.Location = new System.Drawing.Point(683, 332);
            this.NameOfStudLabel.Name = "NameOfStudLabel";
            this.NameOfStudLabel.Size = new System.Drawing.Size(0, 19);
            this.NameOfStudLabel.TabIndex = 33;
            // 
            // Dochádzka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 619);
            this.Controls.Add(this.NameOfStudLabel);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.TotalAbsentLabel);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.TotalPresentLabel);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.AddManualAttendanceBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.Back_Att);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.attGrid);
            this.MaximizeBox = false;
            this.Name = "Dochádzka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dochádzka";
            this.Load += new System.EventHandler(this.Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView attGrid;
        private MaterialSkin.Controls.MaterialButton AddManualAttendanceBtn;
        private System.Windows.Forms.ComboBox comboBox3;
        private MaterialSkin.Controls.MaterialLabel TotalLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel TotalPresentLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel TotalAbsentLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialButton Back_Att;
        private MaterialSkin.Controls.MaterialButton CreateButton;
        private MaterialSkin.Controls.MaterialButton RemoveBtn;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialRadioButton radioButton1;
        private MaterialSkin.Controls.MaterialRadioButton radioButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.Label NameOfStudLabel;
    }
}