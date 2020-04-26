namespace CSAS
{
    partial class FinalGradeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.StudentGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MaxPtsBox = new MaterialSkin.Controls.MaterialTextBox();
            this.SemPtsBox = new MaterialSkin.Controls.MaterialTextBox();
            this.LecPtsBox = new MaterialSkin.Controls.MaterialTextBox();
            this.TotalPtsBox = new MaterialSkin.Controls.MaterialTextBox();
            this.MissedSemBox = new MaterialSkin.Controls.MaterialTextBox();
            this.MissedLecBox = new MaterialSkin.Controls.MaterialTextBox();
            this.FinalGradeBox = new MaterialSkin.Controls.MaterialTextBox();
            this.GradeBtn = new MaterialSkin.Controls.MaterialButton();
            this.BackBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentGrid
            // 
            this.StudentGrid.AllowUserToAddRows = false;
            this.StudentGrid.AllowUserToDeleteRows = false;
            this.StudentGrid.AllowUserToResizeColumns = false;
            this.StudentGrid.AllowUserToResizeRows = false;
            this.StudentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentGrid.BackgroundColor = System.Drawing.Color.White;
            this.StudentGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.StudentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.StudentGrid.GridColor = System.Drawing.Color.White;
            this.StudentGrid.Location = new System.Drawing.Point(34, 89);
            this.StudentGrid.MultiSelect = false;
            this.StudentGrid.Name = "StudentGrid";
            this.StudentGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.StudentGrid.RowHeadersVisible = false;
            this.StudentGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.StudentGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.StudentGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.StudentGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.StudentGrid.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.StudentGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.StudentGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.StudentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentGrid.Size = new System.Drawing.Size(308, 317);
            this.StudentGrid.TabIndex = 0;
            this.StudentGrid.SelectionChanged += new System.EventHandler(this.StudentGrid_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(377, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Maximum bodov za semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(404, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Celkovo získaných bodov";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(430, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vymeškaných cvičení";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(407, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Vymeškaných prednášok\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(520, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Známka";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(389, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bodov za aktivitu na cvičení";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.Location = new System.Drawing.Point(367, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Bodov za aktivitu na prednáške\r\n";
            // 
            // MaxPtsBox
            // 
            this.MaxPtsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MaxPtsBox.Depth = 0;
            this.MaxPtsBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.MaxPtsBox.Location = new System.Drawing.Point(605, 107);
            this.MaxPtsBox.MaxLength = 6;
            this.MaxPtsBox.MouseState = MaterialSkin.MouseState.OUT;
            this.MaxPtsBox.Multiline = false;
            this.MaxPtsBox.Name = "MaxPtsBox";
            this.MaxPtsBox.Size = new System.Drawing.Size(87, 25);
            this.MaxPtsBox.TabIndex = 1;
            this.MaxPtsBox.Text = "";
            this.MaxPtsBox.UseTallSize = false;
            // 
            // SemPtsBox
            // 
            this.SemPtsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SemPtsBox.Depth = 0;
            this.SemPtsBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.SemPtsBox.Location = new System.Drawing.Point(605, 138);
            this.SemPtsBox.MaxLength = 5;
            this.SemPtsBox.MouseState = MaterialSkin.MouseState.OUT;
            this.SemPtsBox.Multiline = false;
            this.SemPtsBox.Name = "SemPtsBox";
            this.SemPtsBox.Size = new System.Drawing.Size(87, 25);
            this.SemPtsBox.TabIndex = 2;
            this.SemPtsBox.Text = "";
            this.SemPtsBox.UseTallSize = false;
            // 
            // LecPtsBox
            // 
            this.LecPtsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LecPtsBox.Depth = 0;
            this.LecPtsBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.LecPtsBox.Location = new System.Drawing.Point(605, 166);
            this.LecPtsBox.MaxLength = 5;
            this.LecPtsBox.MouseState = MaterialSkin.MouseState.OUT;
            this.LecPtsBox.Multiline = false;
            this.LecPtsBox.Name = "LecPtsBox";
            this.LecPtsBox.Size = new System.Drawing.Size(87, 25);
            this.LecPtsBox.TabIndex = 3;
            this.LecPtsBox.Text = "";
            this.LecPtsBox.UseTallSize = false;
            // 
            // TotalPtsBox
            // 
            this.TotalPtsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalPtsBox.Depth = 0;
            this.TotalPtsBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.TotalPtsBox.Location = new System.Drawing.Point(605, 207);
            this.TotalPtsBox.MaxLength = 6;
            this.TotalPtsBox.MouseState = MaterialSkin.MouseState.OUT;
            this.TotalPtsBox.Multiline = false;
            this.TotalPtsBox.Name = "TotalPtsBox";
            this.TotalPtsBox.Size = new System.Drawing.Size(87, 25);
            this.TotalPtsBox.TabIndex = 4;
            this.TotalPtsBox.Text = "";
            this.TotalPtsBox.UseTallSize = false;
            // 
            // MissedSemBox
            // 
            this.MissedSemBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MissedSemBox.Depth = 0;
            this.MissedSemBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.MissedSemBox.Location = new System.Drawing.Point(605, 312);
            this.MissedSemBox.MaxLength = 2;
            this.MissedSemBox.MouseState = MaterialSkin.MouseState.OUT;
            this.MissedSemBox.Multiline = false;
            this.MissedSemBox.Name = "MissedSemBox";
            this.MissedSemBox.Size = new System.Drawing.Size(87, 25);
            this.MissedSemBox.TabIndex = 5;
            this.MissedSemBox.Text = "";
            this.MissedSemBox.UseTallSize = false;
            // 
            // MissedLecBox
            // 
            this.MissedLecBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MissedLecBox.Depth = 0;
            this.MissedLecBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.MissedLecBox.Location = new System.Drawing.Point(605, 339);
            this.MissedLecBox.MaxLength = 2;
            this.MissedLecBox.MouseState = MaterialSkin.MouseState.OUT;
            this.MissedLecBox.Multiline = false;
            this.MissedLecBox.Name = "MissedLecBox";
            this.MissedLecBox.Size = new System.Drawing.Size(87, 25);
            this.MissedLecBox.TabIndex = 6;
            this.MissedLecBox.Text = "";
            this.MissedLecBox.UseTallSize = false;
            // 
            // FinalGradeBox
            // 
            this.FinalGradeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FinalGradeBox.Depth = 0;
            this.FinalGradeBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.FinalGradeBox.Location = new System.Drawing.Point(605, 374);
            this.FinalGradeBox.MaxLength = 50;
            this.FinalGradeBox.MouseState = MaterialSkin.MouseState.OUT;
            this.FinalGradeBox.Multiline = false;
            this.FinalGradeBox.Name = "FinalGradeBox";
            this.FinalGradeBox.Size = new System.Drawing.Size(87, 25);
            this.FinalGradeBox.TabIndex = 7;
            this.FinalGradeBox.Text = "";
            this.FinalGradeBox.UseTallSize = false;
            // 
            // GradeBtn
            // 
            this.GradeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GradeBtn.Depth = 0;
            this.GradeBtn.DrawShadows = true;
            this.GradeBtn.HighEmphasis = true;
            this.GradeBtn.Icon = null;
            this.GradeBtn.Location = new System.Drawing.Point(689, 439);
            this.GradeBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GradeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GradeBtn.Name = "GradeBtn";
            this.GradeBtn.Size = new System.Drawing.Size(94, 36);
            this.GradeBtn.TabIndex = 10;
            this.GradeBtn.Text = "Hodnotiť";
            this.GradeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GradeBtn.UseAccentColor = false;
            this.GradeBtn.UseVisualStyleBackColor = true;
            this.GradeBtn.Click += new System.EventHandler(this.GradeBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.DrawShadows = true;
            this.BackBtn.HighEmphasis = true;
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(24, 439);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(58, 36);
            this.BackBtn.TabIndex = 11;
            this.BackBtn.Text = "Späť";
            this.BackBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBtn.UseAccentColor = false;
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Checked = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Location = new System.Drawing.Point(355, 64);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(203, 37);
            this.materialRadioButton1.TabIndex = 8;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Navrhované hodnotenie";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            this.materialRadioButton1.CheckedChanged += new System.EventHandler(this.materialRadioButton1_CheckedChanged);
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Location = new System.Drawing.Point(583, 64);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(184, 37);
            this.materialRadioButton2.TabIndex = 9;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Zapísané hodnotenie";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // FinalGradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 506);
            this.Controls.Add(this.materialRadioButton2);
            this.Controls.Add(this.materialRadioButton1);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.GradeBtn);
            this.Controls.Add(this.FinalGradeBox);
            this.Controls.Add(this.MissedLecBox);
            this.Controls.Add(this.MissedSemBox);
            this.Controls.Add(this.TotalPtsBox);
            this.Controls.Add(this.LecPtsBox);
            this.Controls.Add(this.SemPtsBox);
            this.Controls.Add(this.MaxPtsBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StudentGrid);
            this.Name = "FinalGradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudentGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialTextBox MaxPtsBox;
        private MaterialSkin.Controls.MaterialTextBox SemPtsBox;
        private MaterialSkin.Controls.MaterialTextBox LecPtsBox;
        private MaterialSkin.Controls.MaterialTextBox TotalPtsBox;
        private MaterialSkin.Controls.MaterialTextBox MissedSemBox;
        private MaterialSkin.Controls.MaterialTextBox MissedLecBox;
        private MaterialSkin.Controls.MaterialTextBox FinalGradeBox;
        private MaterialSkin.Controls.MaterialButton GradeBtn;
        private MaterialSkin.Controls.MaterialButton BackBtn;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
    }
}