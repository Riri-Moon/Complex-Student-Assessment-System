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
            this.exit_attendance = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Back_Att = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.attGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.attGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // exit_attendance
            // 
            this.exit_attendance.Location = new System.Drawing.Point(862, 557);
            this.exit_attendance.Name = "exit_attendance";
            this.exit_attendance.Size = new System.Drawing.Size(137, 50);
            this.exit_attendance.TabIndex = 3;
            this.exit_attendance.Text = "Ukončiť";
            this.exit_attendance.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(42, 75);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Prednáška";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(163, 75);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(66, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Cvičenie";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Back_Att
            // 
            this.Back_Att.Location = new System.Drawing.Point(687, 557);
            this.Back_Att.Name = "Back_Att";
            this.Back_Att.Size = new System.Drawing.Size(137, 50);
            this.Back_Att.TabIndex = 8;
            this.Back_Att.Text = "Späť";
            this.Back_Att.UseVisualStyleBackColor = true;
            this.Back_Att.Click += new System.EventHandler(this.Back_Att_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(893, 101);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(137, 20);
            this.CreateButton.TabIndex = 9;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(550, 102);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(136, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Dochádzka pre deň";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(552, 164);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(110, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Filtrovať podľa ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(692, 162);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.TextChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(692, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(893, 164);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(137, 21);
            this.RemoveBtn.TabIndex = 15;
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(284, 75);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 21);
            this.button1.TabIndex = 17;
            this.button1.Text = "Potvrdiť";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // attGrid
            // 
            this.attGrid.BackgroundColor = System.Drawing.Color.White;
            this.attGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.attGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.attGrid.Location = new System.Drawing.Point(41, 102);
            this.attGrid.Name = "attGrid";
            this.attGrid.RowHeadersVisible = false;
            this.attGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.attGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.attGrid.Size = new System.Drawing.Size(503, 433);
            this.attGrid.TabIndex = 0;
            // 
            // Dochádzka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 619);
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
            this.Controls.Add(this.exit_attendance);
            this.Controls.Add(this.attGrid);
            this.Name = "Dochádzka";
            this.Text = "Dochádzka";
            this.Load += new System.EventHandler(this.Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exit_attendance;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button Back_Att;
        private System.Windows.Forms.Button CreateButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView attGrid;
    }
}