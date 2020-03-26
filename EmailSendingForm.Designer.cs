namespace CSAS
{
    partial class EmailSendingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailSendingForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.OdoslatBtnSendForm = new MaterialSkin.Controls.MaterialFlatButton();
            this.BackBtnSendForm = new MaterialSkin.Controls.MaterialFlatButton();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.SelectAllBtnPrimaryEmail = new MaterialSkin.Controls.MaterialRadioButton();
            this.SelectAllSecondaryEmail = new MaterialSkin.Controls.MaterialRadioButton();
            this.SelectManually = new MaterialSkin.Controls.MaterialRadioButton();
            this.GroupComboEmail = new System.Windows.Forms.ComboBox();
            this.GroupCheckBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox1, null);
            this.richTextBox1.Location = new System.Drawing.Point(84, 163);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(742, 305);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // ToTextBox
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.ToTextBox, this.autocompleteMenu1);
            this.ToTextBox.Location = new System.Drawing.Point(158, 69);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(548, 20);
            this.ToTextBox.TabIndex = 1;
            // 
            // subjectTextBox
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.subjectTextBox, null);
            this.subjectTextBox.Location = new System.Drawing.Point(158, 102);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(548, 20);
            this.subjectTextBox.TabIndex = 2;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(80, 72);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(48, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Komu";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(81, 101);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(59, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Subjekt";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(81, 141);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(54, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Správa";
            // 
            // OdoslatBtnSendForm
            // 
            this.OdoslatBtnSendForm.AutoSize = true;
            this.OdoslatBtnSendForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OdoslatBtnSendForm.Depth = 0;
            this.OdoslatBtnSendForm.Icon = null;
            this.OdoslatBtnSendForm.Location = new System.Drawing.Point(744, 488);
            this.OdoslatBtnSendForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OdoslatBtnSendForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.OdoslatBtnSendForm.Name = "OdoslatBtnSendForm";
            this.OdoslatBtnSendForm.Primary = false;
            this.OdoslatBtnSendForm.Size = new System.Drawing.Size(82, 36);
            this.OdoslatBtnSendForm.TabIndex = 4;
            this.OdoslatBtnSendForm.Text = "Odoslať";
            this.OdoslatBtnSendForm.UseVisualStyleBackColor = true;
            this.OdoslatBtnSendForm.Click += new System.EventHandler(this.OdoslatBtnSendForm_Click);
            // 
            // BackBtnSendForm
            // 
            this.BackBtnSendForm.AutoSize = true;
            this.BackBtnSendForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtnSendForm.Depth = 0;
            this.BackBtnSendForm.Icon = null;
            this.BackBtnSendForm.Location = new System.Drawing.Point(85, 488);
            this.BackBtnSendForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtnSendForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtnSendForm.Name = "BackBtnSendForm";
            this.BackBtnSendForm.Primary = false;
            this.BackBtnSendForm.Size = new System.Drawing.Size(55, 36);
            this.BackBtnSendForm.TabIndex = 5;
            this.BackBtnSendForm.Text = "Späť";
            this.BackBtnSendForm.UseVisualStyleBackColor = true;
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.AllowsTabKey = true;
            this.autocompleteMenu1.AppearInterval = 1;
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.autocompleteMenu1.ImageList = null;
            this.autocompleteMenu1.Items = new string[0];
            this.autocompleteMenu1.MinFragmentLength = 1;
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // SelectAllBtnPrimaryEmail
            // 
            this.SelectAllBtnPrimaryEmail.AutoSize = true;
            this.SelectAllBtnPrimaryEmail.Depth = 0;
            this.SelectAllBtnPrimaryEmail.Font = new System.Drawing.Font("Roboto", 10F);
            this.SelectAllBtnPrimaryEmail.Location = new System.Drawing.Point(835, 67);
            this.SelectAllBtnPrimaryEmail.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAllBtnPrimaryEmail.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SelectAllBtnPrimaryEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectAllBtnPrimaryEmail.Name = "SelectAllBtnPrimaryEmail";
            this.SelectAllBtnPrimaryEmail.Ripple = true;
            this.SelectAllBtnPrimaryEmail.Size = new System.Drawing.Size(222, 30);
            this.SelectAllBtnPrimaryEmail.TabIndex = 6;
            this.SelectAllBtnPrimaryEmail.Text = "Vybrať všetkých primárny email";
            this.SelectAllBtnPrimaryEmail.UseVisualStyleBackColor = true;
            this.SelectAllBtnPrimaryEmail.CheckedChanged += new System.EventHandler(this.SelectAllBtnPrimaryEmail_CheckedChanged);
            // 
            // SelectAllSecondaryEmail
            // 
            this.SelectAllSecondaryEmail.AutoSize = true;
            this.SelectAllSecondaryEmail.Depth = 0;
            this.SelectAllSecondaryEmail.Font = new System.Drawing.Font("Roboto", 10F);
            this.SelectAllSecondaryEmail.Location = new System.Drawing.Point(835, 97);
            this.SelectAllSecondaryEmail.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAllSecondaryEmail.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SelectAllSecondaryEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectAllSecondaryEmail.Name = "SelectAllSecondaryEmail";
            this.SelectAllSecondaryEmail.Ripple = true;
            this.SelectAllSecondaryEmail.Size = new System.Drawing.Size(239, 30);
            this.SelectAllSecondaryEmail.TabIndex = 7;
            this.SelectAllSecondaryEmail.Text = "Vybrať všetkých sekundárny email";
            this.SelectAllSecondaryEmail.UseVisualStyleBackColor = true;
            this.SelectAllSecondaryEmail.CheckedChanged += new System.EventHandler(this.SelectAllSecondaryEmail_CheckedChanged);
            // 
            // SelectManually
            // 
            this.SelectManually.AutoSize = true;
            this.SelectManually.Checked = true;
            this.SelectManually.Depth = 0;
            this.SelectManually.Font = new System.Drawing.Font("Roboto", 10F);
            this.SelectManually.Location = new System.Drawing.Point(835, 127);
            this.SelectManually.Margin = new System.Windows.Forms.Padding(0);
            this.SelectManually.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SelectManually.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectManually.Name = "SelectManually";
            this.SelectManually.Ripple = true;
            this.SelectManually.Size = new System.Drawing.Size(107, 30);
            this.SelectManually.TabIndex = 8;
            this.SelectManually.Text = "Vybrať ručne";
            this.SelectManually.UseVisualStyleBackColor = true;
            this.SelectManually.CheckedChanged += new System.EventHandler(this.SelectManually_CheckedChanged);
            // 
            // GroupComboEmail
            // 
            this.GroupComboEmail.Enabled = false;
            this.GroupComboEmail.FormattingEnabled = true;
            this.GroupComboEmail.Location = new System.Drawing.Point(972, 166);
            this.GroupComboEmail.Name = "GroupComboEmail";
            this.GroupComboEmail.Size = new System.Drawing.Size(121, 21);
            this.GroupComboEmail.TabIndex = 10;
            // 
            // GroupCheckBtn
            // 
            this.GroupCheckBtn.AutoSize = true;
            this.GroupCheckBtn.Depth = 0;
            this.GroupCheckBtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.GroupCheckBtn.Location = new System.Drawing.Point(835, 157);
            this.GroupCheckBtn.Margin = new System.Windows.Forms.Padding(0);
            this.GroupCheckBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.GroupCheckBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GroupCheckBtn.Name = "GroupCheckBtn";
            this.GroupCheckBtn.Ripple = true;
            this.GroupCheckBtn.Size = new System.Drawing.Size(114, 30);
            this.GroupCheckBtn.TabIndex = 11;
            this.GroupCheckBtn.Text = "Vybrať krúžok";
            this.GroupCheckBtn.UseVisualStyleBackColor = true;
            this.GroupCheckBtn.CheckedChanged += new System.EventHandler(this.GroupCheckBtn_CheckedChanged);
            // 
            // EmailSendingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 545);
            this.Controls.Add(this.GroupCheckBtn);
            this.Controls.Add(this.GroupComboEmail);
            this.Controls.Add(this.SelectManually);
            this.Controls.Add(this.SelectAllSecondaryEmail);
            this.Controls.Add(this.SelectAllBtnPrimaryEmail);
            this.Controls.Add(this.BackBtnSendForm);
            this.Controls.Add(this.OdoslatBtnSendForm);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.richTextBox1);
            this.Name = "EmailSendingForm";
            this.Text = "EmailSendingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialFlatButton OdoslatBtnSendForm;
        private MaterialSkin.Controls.MaterialFlatButton BackBtnSendForm;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private MaterialSkin.Controls.MaterialRadioButton SelectAllBtnPrimaryEmail;
        private MaterialSkin.Controls.MaterialRadioButton SelectAllSecondaryEmail;
        private MaterialSkin.Controls.MaterialRadioButton SelectManually;
        private System.Windows.Forms.ComboBox GroupComboEmail;
        private MaterialSkin.Controls.MaterialRadioButton GroupCheckBtn;
    }
}