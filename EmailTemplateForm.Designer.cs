namespace CSAS
{
    partial class EmailTemplateForm
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
            this.ContentTextBox = new System.Windows.Forms.RichTextBox();
            this.SubjectTextbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.CreateEmailTempBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.TempGridView = new System.Windows.Forms.DataGridView();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.NameOfTempTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ClearBtn = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.TempGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Location = new System.Drawing.Point(48, 191);
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(564, 329);
            this.ContentTextBox.TabIndex = 0;
            this.ContentTextBox.Text = "";
            // 
            // SubjectTextbox
            // 
            this.SubjectTextbox.Depth = 0;
            this.SubjectTextbox.Hint = "";
            this.SubjectTextbox.Location = new System.Drawing.Point(162, 117);
            this.SubjectTextbox.MaxLength = 32767;
            this.SubjectTextbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubjectTextbox.Name = "SubjectTextbox";
            this.SubjectTextbox.PasswordChar = '\0';
            this.SubjectTextbox.SelectedText = "";
            this.SubjectTextbox.SelectionLength = 0;
            this.SubjectTextbox.SelectionStart = 0;
            this.SubjectTextbox.Size = new System.Drawing.Size(564, 23);
            this.SubjectTextbox.TabIndex = 1;
            this.SubjectTextbox.TabStop = false;
            this.SubjectTextbox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(49, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(59, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Subjekt";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(49, 158);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(54, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Správa";
            // 
            // CreateEmailTempBtn
            // 
            this.CreateEmailTempBtn.AutoSize = true;
            this.CreateEmailTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateEmailTempBtn.Depth = 0;
            this.CreateEmailTempBtn.Icon = null;
            this.CreateEmailTempBtn.Location = new System.Drawing.Point(998, 590);
            this.CreateEmailTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateEmailTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateEmailTempBtn.Name = "CreateEmailTempBtn";
            this.CreateEmailTempBtn.Primary = false;
            this.CreateEmailTempBtn.Size = new System.Drawing.Size(132, 36);
            this.CreateEmailTempBtn.TabIndex = 4;
            this.CreateEmailTempBtn.Text = "Uložiť šablónu";
            this.CreateEmailTempBtn.UseVisualStyleBackColor = true;
            this.CreateEmailTempBtn.Click += new System.EventHandler(this.CreateEmailTempBtn_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(49, 590);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(55, 36);
            this.materialFlatButton1.TabIndex = 5;
            this.materialFlatButton1.Text = "Späť";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // TempGridView
            // 
            this.TempGridView.BackgroundColor = System.Drawing.Color.White;
            this.TempGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TempGridView.GridColor = System.Drawing.Color.White;
            this.TempGridView.Location = new System.Drawing.Point(736, 191);
            this.TempGridView.Name = "TempGridView";
            this.TempGridView.Size = new System.Drawing.Size(321, 329);
            this.TempGridView.TabIndex = 6;
            this.TempGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(732, 158);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(199, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Existujúce emailové šablóny";
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(736, 529);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(151, 36);
            this.materialFlatButton2.TabIndex = 8;
            this.materialFlatButton2.Text = "Zobraziť šablónu";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Icon = null;
            this.materialFlatButton3.Location = new System.Drawing.Point(896, 529);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(161, 36);
            this.materialFlatButton3.TabIndex = 9;
            this.materialFlatButton3.Text = "Odstrániť šablónu";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.materialFlatButton3_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(49, 78);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(107, 19);
            this.materialLabel4.TabIndex = 10;
            this.materialLabel4.Text = "Názov šablóny";
            // 
            // NameOfTempTextBox
            // 
            this.NameOfTempTextBox.Depth = 0;
            this.NameOfTempTextBox.Hint = "";
            this.NameOfTempTextBox.Location = new System.Drawing.Point(162, 74);
            this.NameOfTempTextBox.MaxLength = 32767;
            this.NameOfTempTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NameOfTempTextBox.Name = "NameOfTempTextBox";
            this.NameOfTempTextBox.PasswordChar = '\0';
            this.NameOfTempTextBox.SelectedText = "";
            this.NameOfTempTextBox.SelectionLength = 0;
            this.NameOfTempTextBox.SelectionStart = 0;
            this.NameOfTempTextBox.Size = new System.Drawing.Size(564, 23);
            this.NameOfTempTextBox.TabIndex = 11;
            this.NameOfTempTextBox.TabStop = false;
            this.NameOfTempTextBox.UseSystemPasswordChar = false;
            // 
            // ClearBtn
            // 
            this.ClearBtn.AutoSize = true;
            this.ClearBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearBtn.Depth = 0;
            this.ClearBtn.Icon = null;
            this.ClearBtn.Location = new System.Drawing.Point(619, 191);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ClearBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Primary = false;
            this.ClearBtn.Size = new System.Drawing.Size(80, 36);
            this.ClearBtn.TabIndex = 12;
            this.ClearBtn.Text = "Vyčistiť";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // EmailTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 641);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.NameOfTempTextBox);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialFlatButton3);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.TempGridView);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.CreateEmailTempBtn);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.SubjectTextbox);
            this.Controls.Add(this.ContentTextBox);
            this.Name = "EmailTemplateForm";
            this.Text = "Vytvorenie emailovej šablóny";
            this.Load += new System.EventHandler(this.EmailTemplateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TempGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ContentTextBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField SubjectTextbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton CreateEmailTempBtn;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private System.Windows.Forms.DataGridView TempGridView;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField NameOfTempTextBox;
        private MaterialSkin.Controls.MaterialFlatButton ClearBtn;
    }
}