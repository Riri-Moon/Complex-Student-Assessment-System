namespace CSAS
{
    partial class AddStudentForm
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
            this.AddStudRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.EditStudRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.StudentsCombo = new System.Windows.Forms.ComboBox();
            this.LoadStudentBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.NameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.SurnameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.EmailBox = new MaterialSkin.Controls.MaterialTextBox();
            this.EmailUcmBox = new MaterialSkin.Controls.MaterialTextBox();
            this.IsicBox = new MaterialSkin.Controls.MaterialTextBox();
            this.GradeBox = new MaterialSkin.Controls.MaterialTextBox();
            this.GroupCombo = new System.Windows.Forms.ComboBox();
            this.GroupAttCombo = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new MaterialSkin.Controls.MaterialButton();
            this.BackBtn = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // AddStudRadio
            // 
            this.AddStudRadio.AutoSize = true;
            this.AddStudRadio.Checked = true;
            this.AddStudRadio.Depth = 0;
            this.AddStudRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddStudRadio.Location = new System.Drawing.Point(18, 75);
            this.AddStudRadio.Margin = new System.Windows.Forms.Padding(0);
            this.AddStudRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AddStudRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddStudRadio.Name = "AddStudRadio";
            this.AddStudRadio.Ripple = true;
            this.AddStudRadio.Size = new System.Drawing.Size(144, 37);
            this.AddStudRadio.TabIndex = 0;
            this.AddStudRadio.TabStop = true;
            this.AddStudRadio.Text = "Pridať študenta";
            this.AddStudRadio.UseVisualStyleBackColor = true;
            this.AddStudRadio.CheckedChanged += new System.EventHandler(this.AddStudRadio_CheckedChanged);
            // 
            // EditStudRadio
            // 
            this.EditStudRadio.AutoSize = true;
            this.EditStudRadio.Depth = 0;
            this.EditStudRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.EditStudRadio.Location = new System.Drawing.Point(18, 117);
            this.EditStudRadio.Margin = new System.Windows.Forms.Padding(0);
            this.EditStudRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.EditStudRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditStudRadio.Name = "EditStudRadio";
            this.EditStudRadio.Ripple = true;
            this.EditStudRadio.Size = new System.Drawing.Size(152, 37);
            this.EditStudRadio.TabIndex = 1;
            this.EditStudRadio.Text = "Upraviť študenta";
            this.EditStudRadio.UseVisualStyleBackColor = true;
            // 
            // StudentsCombo
            // 
            this.StudentsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentsCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StudentsCombo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.StudentsCombo.FormattingEnabled = true;
            this.StudentsCombo.Location = new System.Drawing.Point(180, 123);
            this.StudentsCombo.Name = "StudentsCombo";
            this.StudentsCombo.Size = new System.Drawing.Size(186, 25);
            this.StudentsCombo.TabIndex = 2;
            // 
            // LoadStudentBtn
            // 
            this.LoadStudentBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoadStudentBtn.Depth = 0;
            this.LoadStudentBtn.DrawShadows = true;
            this.LoadStudentBtn.HighEmphasis = true;
            this.LoadStudentBtn.Icon = null;
            this.LoadStudentBtn.Location = new System.Drawing.Point(409, 118);
            this.LoadStudentBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoadStudentBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoadStudentBtn.Name = "LoadStudentBtn";
            this.LoadStudentBtn.Size = new System.Drawing.Size(83, 36);
            this.LoadStudentBtn.TabIndex = 3;
            this.LoadStudentBtn.Text = "Načítať";
            this.LoadStudentBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.LoadStudentBtn.UseAccentColor = false;
            this.LoadStudentBtn.UseVisualStyleBackColor = true;
            this.LoadStudentBtn.Click += new System.EventHandler(this.LoadStudentBtn_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(26, 181);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(41, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Meno";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(251, 181);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(73, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Priezvisko";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(26, 237);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(41, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Email";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(251, 237);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(79, 19);
            this.materialLabel4.TabIndex = 40;
            this.materialLabel4.Text = "Email UCM";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(26, 286);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(29, 19);
            this.materialLabel5.TabIndex = 41;
            this.materialLabel5.Text = "ISIC";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(26, 322);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(49, 19);
            this.materialLabel6.TabIndex = 42;
            this.materialLabel6.Text = "Ročník";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(26, 361);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(50, 19);
            this.materialLabel7.TabIndex = 10;
            this.materialLabel7.Text = "Krúžok";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(280, 361);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(124, 19);
            this.materialLabel8.TabIndex = 11;
            this.materialLabel8.Text = "Krúžok pre export";
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.White;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Depth = 0;
            this.NameBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.NameBox.Location = new System.Drawing.Point(90, 175);
            this.NameBox.MaxLength = 32767;
            this.NameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NameBox.Multiline = false;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(133, 25);
            this.NameBox.TabIndex = 4;
            this.NameBox.Text = "";
            this.NameBox.UseTallSize = false;
            // 
            // SurnameBox
            // 
            this.SurnameBox.BackColor = System.Drawing.Color.White;
            this.SurnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SurnameBox.Depth = 0;
            this.SurnameBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.SurnameBox.Location = new System.Drawing.Point(330, 175);
            this.SurnameBox.MaxLength = 32767;
            this.SurnameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.SurnameBox.Multiline = false;
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(139, 25);
            this.SurnameBox.TabIndex = 5;
            this.SurnameBox.Text = "";
            this.SurnameBox.UseTallSize = false;
            // 
            // EmailBox
            // 
            this.EmailBox.BackColor = System.Drawing.Color.White;
            this.EmailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailBox.Depth = 0;
            this.EmailBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.EmailBox.Location = new System.Drawing.Point(90, 231);
            this.EmailBox.MaxLength = 32767;
            this.EmailBox.MouseState = MaterialSkin.MouseState.OUT;
            this.EmailBox.Multiline = false;
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(133, 25);
            this.EmailBox.TabIndex = 6;
            this.EmailBox.Text = "";
            this.EmailBox.UseTallSize = false;
            // 
            // EmailUcmBox
            // 
            this.EmailUcmBox.BackColor = System.Drawing.Color.White;
            this.EmailUcmBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailUcmBox.Depth = 0;
            this.EmailUcmBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.EmailUcmBox.Location = new System.Drawing.Point(336, 231);
            this.EmailUcmBox.MaxLength = 32767;
            this.EmailUcmBox.MouseState = MaterialSkin.MouseState.OUT;
            this.EmailUcmBox.Multiline = false;
            this.EmailUcmBox.Name = "EmailUcmBox";
            this.EmailUcmBox.Size = new System.Drawing.Size(133, 25);
            this.EmailUcmBox.TabIndex = 7;
            this.EmailUcmBox.Text = "";
            this.EmailUcmBox.UseTallSize = false;
            // 
            // IsicBox
            // 
            this.IsicBox.BackColor = System.Drawing.Color.White;
            this.IsicBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IsicBox.Depth = 0;
            this.IsicBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.IsicBox.Location = new System.Drawing.Point(90, 280);
            this.IsicBox.MaxLength = 32767;
            this.IsicBox.MouseState = MaterialSkin.MouseState.OUT;
            this.IsicBox.Multiline = false;
            this.IsicBox.Name = "IsicBox";
            this.IsicBox.Size = new System.Drawing.Size(133, 25);
            this.IsicBox.TabIndex = 8;
            this.IsicBox.Text = "";
            this.IsicBox.UseTallSize = false;
            // 
            // GradeBox
            // 
            this.GradeBox.BackColor = System.Drawing.Color.White;
            this.GradeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GradeBox.Depth = 0;
            this.GradeBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.GradeBox.Location = new System.Drawing.Point(90, 316);
            this.GradeBox.MaxLength = 32767;
            this.GradeBox.MouseState = MaterialSkin.MouseState.OUT;
            this.GradeBox.Multiline = false;
            this.GradeBox.Name = "GradeBox";
            this.GradeBox.Size = new System.Drawing.Size(133, 25);
            this.GradeBox.TabIndex = 9;
            this.GradeBox.Text = "";
            this.GradeBox.UseTallSize = false;
            // 
            // GroupCombo
            // 
            this.GroupCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupCombo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GroupCombo.FormattingEnabled = true;
            this.GroupCombo.Location = new System.Drawing.Point(90, 359);
            this.GroupCombo.Name = "GroupCombo";
            this.GroupCombo.Size = new System.Drawing.Size(68, 25);
            this.GroupCombo.TabIndex = 10;
            this.GroupCombo.SelectedIndexChanged += new System.EventHandler(this.GroupCombo_SelectedIndexChanged);
            // 
            // GroupAttCombo
            // 
            this.GroupAttCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupAttCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupAttCombo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GroupAttCombo.FormattingEnabled = true;
            this.GroupAttCombo.Location = new System.Drawing.Point(424, 359);
            this.GroupAttCombo.Name = "GroupAttCombo";
            this.GroupAttCombo.Size = new System.Drawing.Size(68, 25);
            this.GroupAttCombo.TabIndex = 11;
            // 
            // SaveBtn
            // 
            this.SaveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveBtn.Depth = 0;
            this.SaveBtn.DrawShadows = true;
            this.SaveBtn.HighEmphasis = true;
            this.SaveBtn.Icon = null;
            this.SaveBtn.Location = new System.Drawing.Point(424, 439);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SaveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(90, 36);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "Vytvoriť";
            this.SaveBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.SaveBtn.UseAccentColor = false;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.DrawShadows = true;
            this.BackBtn.HighEmphasis = true;
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(18, 439);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(58, 36);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Späť";
            this.BackBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBtn.UseAccentColor = false;
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(552, 508);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.GroupAttCombo);
            this.Controls.Add(this.GroupCombo);
            this.Controls.Add(this.GradeBox);
            this.Controls.Add(this.IsicBox);
            this.Controls.Add(this.EmailUcmBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.LoadStudentBtn);
            this.Controls.Add(this.StudentsCombo);
            this.Controls.Add(this.EditStudRadio);
            this.Controls.Add(this.AddStudRadio);
            this.MaximizeBox = false;
            this.Name = "AddStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddStudentForm";
            this.Load += new System.EventHandler(this.AddStudentForm_Load);
            this.Leave += new System.EventHandler(this.AddStudentForm_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRadioButton AddStudRadio;
        private MaterialSkin.Controls.MaterialRadioButton EditStudRadio;
        private System.Windows.Forms.ComboBox StudentsCombo;
        private MaterialSkin.Controls.MaterialButton LoadStudentBtn;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialTextBox NameBox;
        private MaterialSkin.Controls.MaterialTextBox SurnameBox;
        private MaterialSkin.Controls.MaterialTextBox EmailBox;
        private MaterialSkin.Controls.MaterialTextBox EmailUcmBox;
        private MaterialSkin.Controls.MaterialTextBox IsicBox;
        private MaterialSkin.Controls.MaterialTextBox GradeBox;
        private System.Windows.Forms.ComboBox GroupCombo;
        private System.Windows.Forms.ComboBox GroupAttCombo;
        private MaterialSkin.Controls.MaterialButton SaveBtn;
        private MaterialSkin.Controls.MaterialButton BackBtn;
    }
}