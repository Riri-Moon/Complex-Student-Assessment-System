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
            this.ToTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.subjectTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.OdoslatBtnSendForm = new MaterialSkin.Controls.MaterialButton();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.SelectAllBtnPrimaryEmail = new MaterialSkin.Controls.MaterialRadioButton();
            this.SelectAllSecondaryEmail = new MaterialSkin.Controls.MaterialRadioButton();
            this.SelectManually = new MaterialSkin.Controls.MaterialRadioButton();
            this.GroupComboEmail = new System.Windows.Forms.ComboBox();
            this.GroupCheckBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialButton();
            this.AttachmentsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox1, null);
            this.richTextBox1.Location = new System.Drawing.Point(32, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(742, 305);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            // 
            // ToTextBox
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.ToTextBox, this.autocompleteMenu1);
            this.ToTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ToTextBox.Depth = 0;
            this.ToTextBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.ToTextBox.Location = new System.Drawing.Point(106, 72);
            this.ToTextBox.MaxLength = 50;
            this.ToTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ToTextBox.Multiline = false;
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(548, 25);
            this.ToTextBox.TabIndex = 1;
            this.ToTextBox.Text = "";
            this.ToTextBox.UseTallSize = false;
            // 
            // subjectTextBox
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.subjectTextBox, null);
            this.subjectTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subjectTextBox.Depth = 0;
            this.subjectTextBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.subjectTextBox.Location = new System.Drawing.Point(106, 105);
            this.subjectTextBox.MaxLength = 50;
            this.subjectTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.subjectTextBox.Multiline = false;
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(548, 25);
            this.subjectTextBox.TabIndex = 2;
            this.subjectTextBox.Text = "";
            this.subjectTextBox.UseTallSize = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(28, 75);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(43, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Komu";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(29, 104);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(60, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Predmet";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(29, 144);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(51, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Správa";
            // 
            // OdoslatBtnSendForm
            // 
            this.OdoslatBtnSendForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OdoslatBtnSendForm.Depth = 0;
            this.OdoslatBtnSendForm.DrawShadows = true;
            this.OdoslatBtnSendForm.HighEmphasis = true;
            this.OdoslatBtnSendForm.Icon = null;
            this.OdoslatBtnSendForm.Location = new System.Drawing.Point(969, 571);
            this.OdoslatBtnSendForm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OdoslatBtnSendForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.OdoslatBtnSendForm.Name = "OdoslatBtnSendForm";
            this.OdoslatBtnSendForm.Size = new System.Drawing.Size(87, 36);
            this.OdoslatBtnSendForm.TabIndex = 4;
            this.OdoslatBtnSendForm.Text = "Odoslať";
            this.OdoslatBtnSendForm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.OdoslatBtnSendForm.UseAccentColor = false;
            this.OdoslatBtnSendForm.UseVisualStyleBackColor = true;
            this.OdoslatBtnSendForm.Click += new System.EventHandler(this.OdoslatBtnSendForm_Click);
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
            this.SelectAllBtnPrimaryEmail.Location = new System.Drawing.Point(798, 109);
            this.SelectAllBtnPrimaryEmail.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAllBtnPrimaryEmail.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SelectAllBtnPrimaryEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectAllBtnPrimaryEmail.Name = "SelectAllBtnPrimaryEmail";
            this.SelectAllBtnPrimaryEmail.Ripple = true;
            this.SelectAllBtnPrimaryEmail.Size = new System.Drawing.Size(258, 37);
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
            this.SelectAllSecondaryEmail.Location = new System.Drawing.Point(798, 146);
            this.SelectAllSecondaryEmail.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAllSecondaryEmail.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SelectAllSecondaryEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectAllSecondaryEmail.Name = "SelectAllSecondaryEmail";
            this.SelectAllSecondaryEmail.Ripple = true;
            this.SelectAllSecondaryEmail.Size = new System.Drawing.Size(277, 37);
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
            this.SelectManually.Location = new System.Drawing.Point(798, 72);
            this.SelectManually.Margin = new System.Windows.Forms.Padding(0);
            this.SelectManually.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SelectManually.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectManually.Name = "SelectManually";
            this.SelectManually.Ripple = true;
            this.SelectManually.Size = new System.Drawing.Size(125, 37);
            this.SelectManually.TabIndex = 8;
            this.SelectManually.TabStop = true;
            this.SelectManually.Text = "Vybrať ručne";
            this.SelectManually.UseVisualStyleBackColor = true;
            this.SelectManually.CheckedChanged += new System.EventHandler(this.SelectManually_CheckedChanged);
            // 
            // GroupComboEmail
            // 
            this.GroupComboEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupComboEmail.Enabled = false;
            this.GroupComboEmail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupComboEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GroupComboEmail.FormattingEnabled = true;
            this.GroupComboEmail.Location = new System.Drawing.Point(954, 190);
            this.GroupComboEmail.Name = "GroupComboEmail";
            this.GroupComboEmail.Size = new System.Drawing.Size(121, 25);
            this.GroupComboEmail.TabIndex = 10;
            // 
            // GroupCheckBtn
            // 
            this.GroupCheckBtn.AutoSize = true;
            this.GroupCheckBtn.Depth = 0;
            this.GroupCheckBtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.GroupCheckBtn.Location = new System.Drawing.Point(798, 183);
            this.GroupCheckBtn.Margin = new System.Windows.Forms.Padding(0);
            this.GroupCheckBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.GroupCheckBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GroupCheckBtn.Name = "GroupCheckBtn";
            this.GroupCheckBtn.Ripple = true;
            this.GroupCheckBtn.Size = new System.Drawing.Size(133, 37);
            this.GroupCheckBtn.TabIndex = 11;
            this.GroupCheckBtn.Text = "Vybrať krúžok";
            this.GroupCheckBtn.UseVisualStyleBackColor = true;
            this.GroupCheckBtn.CheckedChanged += new System.EventHandler(this.GroupCheckBtn_CheckedChanged);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.DrawShadows = true;
            this.materialFlatButton1.HighEmphasis = true;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(33, 490);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Size = new System.Drawing.Size(136, 36);
            this.materialFlatButton1.TabIndex = 12;
            this.materialFlatButton1.Text = "Pridať prílohy";
            this.materialFlatButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialFlatButton1.UseAccentColor = false;
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click_1);
            // 
            // AttachmentsGrid
            // 
            this.AttachmentsGrid.AllowUserToAddRows = false;
            this.AttachmentsGrid.AllowUserToDeleteRows = false;
            this.AttachmentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AttachmentsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.AttachmentsGrid.BackgroundColor = System.Drawing.Color.White;
            this.AttachmentsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AttachmentsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AttachmentsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AttachmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AttachmentsGrid.ColumnHeadersVisible = false;
            this.AttachmentsGrid.Location = new System.Drawing.Point(214, 490);
            this.AttachmentsGrid.Name = "AttachmentsGrid";
            this.AttachmentsGrid.ReadOnly = true;
            this.AttachmentsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AttachmentsGrid.RowHeadersVisible = false;
            this.AttachmentsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AttachmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AttachmentsGrid.Size = new System.Drawing.Size(254, 117);
            this.AttachmentsGrid.TabIndex = 13;
            this.AttachmentsGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AttachmentsGrid_KeyUp);
            // 
            // EmailSendingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 622);
            this.Controls.Add(this.AttachmentsGrid);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.GroupCheckBtn);
            this.Controls.Add(this.GroupComboEmail);
            this.Controls.Add(this.SelectManually);
            this.Controls.Add(this.SelectAllSecondaryEmail);
            this.Controls.Add(this.SelectAllBtnPrimaryEmail);
            this.Controls.Add(this.OdoslatBtnSendForm);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.richTextBox1);
            this.MaximizeBox = false;
            this.Name = "EmailSendingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private MaterialSkin.Controls.MaterialTextBox ToTextBox;
        private MaterialSkin.Controls.MaterialTextBox subjectTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton OdoslatBtnSendForm;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private MaterialSkin.Controls.MaterialRadioButton SelectAllBtnPrimaryEmail;
        private MaterialSkin.Controls.MaterialRadioButton SelectAllSecondaryEmail;
        private MaterialSkin.Controls.MaterialRadioButton SelectManually;
        private System.Windows.Forms.ComboBox GroupComboEmail;
        private MaterialSkin.Controls.MaterialRadioButton GroupCheckBtn;
        private MaterialSkin.Controls.MaterialButton materialFlatButton1;
        private System.Windows.Forms.DataGridView AttachmentsGrid;
    }
}