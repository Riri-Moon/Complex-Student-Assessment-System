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
            this.SubjectTextbox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.CreateEmailTempBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialButton();
            this.TempGridView = new System.Windows.Forms.DataGridView();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.NameOfTempTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.ClearBtn = new MaterialSkin.Controls.MaterialButton();
            this.AddEmailTemplateAttachmentsBtn = new MaterialSkin.Controls.MaterialButton();
            this.AttachmentsGrid = new System.Windows.Forms.DataGridView();
            this.OpenAttachmentBtn = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.TempGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Location = new System.Drawing.Point(48, 191);
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(564, 329);
            this.ContentTextBox.TabIndex = 0;
            this.ContentTextBox.Text = "";
            this.ContentTextBox.TextChanged += new System.EventHandler(this.ContentTextBox_TextChanged);
            this.ContentTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ContentTextBox_KeyUp);
            // 
            // SubjectTextbox
            // 
            this.SubjectTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SubjectTextbox.Depth = 0;
            this.SubjectTextbox.Font = new System.Drawing.Font("Roboto", 12F);
            this.SubjectTextbox.Location = new System.Drawing.Point(162, 117);
            this.SubjectTextbox.MaxLength = 32767;
            this.SubjectTextbox.MouseState = MaterialSkin.MouseState.OUT;
            this.SubjectTextbox.Multiline = false;
            this.SubjectTextbox.Name = "SubjectTextbox";
            this.SubjectTextbox.Size = new System.Drawing.Size(564, 25);
            this.SubjectTextbox.TabIndex = 1;
            this.SubjectTextbox.TabStop = false;
            this.SubjectTextbox.Text = "";
            this.SubjectTextbox.UseTallSize = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(49, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(54, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Subjekt";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(49, 158);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(51, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Správa";
            // 
            // CreateEmailTempBtn
            // 
            this.CreateEmailTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateEmailTempBtn.Depth = 0;
            this.CreateEmailTempBtn.DrawShadows = true;
            this.CreateEmailTempBtn.HighEmphasis = true;
            this.CreateEmailTempBtn.Icon = null;
            this.CreateEmailTempBtn.Location = new System.Drawing.Point(1044, 590);
            this.CreateEmailTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateEmailTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateEmailTempBtn.Name = "CreateEmailTempBtn";
            this.CreateEmailTempBtn.Size = new System.Drawing.Size(71, 36);
            this.CreateEmailTempBtn.TabIndex = 4;
            this.CreateEmailTempBtn.Text = "Uložiť";
            this.CreateEmailTempBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateEmailTempBtn.UseAccentColor = false;
            this.CreateEmailTempBtn.UseVisualStyleBackColor = true;
            this.CreateEmailTempBtn.Click += new System.EventHandler(this.CreateEmailTempBtn_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.DrawShadows = true;
            this.materialFlatButton1.HighEmphasis = true;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(26, 590);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Size = new System.Drawing.Size(30, 36);
            this.materialFlatButton1.TabIndex = 5;
            this.materialFlatButton1.Text = "s";
            this.materialFlatButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialFlatButton1.UseAccentColor = false;
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // TempGridView
            // 
            this.TempGridView.BackgroundColor = System.Drawing.Color.White;
            this.TempGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TempGridView.GridColor = System.Drawing.Color.White;
            this.TempGridView.Location = new System.Drawing.Point(746, 191);
            this.TempGridView.Name = "TempGridView";
            this.TempGridView.Size = new System.Drawing.Size(321, 329);
            this.TempGridView.TabIndex = 6;
            this.TempGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(732, 158);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(201, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Existujúce emailové šablóny";
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.DrawShadows = true;
            this.materialFlatButton2.HighEmphasis = true;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(746, 529);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Size = new System.Drawing.Size(90, 36);
            this.materialFlatButton2.TabIndex = 8;
            this.materialFlatButton2.Text = "Zobraziť";
            this.materialFlatButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialFlatButton2.UseAccentColor = false;
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.DrawShadows = true;
            this.materialFlatButton3.HighEmphasis = true;
            this.materialFlatButton3.Icon = null;
            this.materialFlatButton3.Location = new System.Drawing.Point(966, 529);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Size = new System.Drawing.Size(101, 36);
            this.materialFlatButton3.TabIndex = 9;
            this.materialFlatButton3.Text = "Odstrániť";
            this.materialFlatButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialFlatButton3.UseAccentColor = false;
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.materialFlatButton3_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(49, 78);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(106, 19);
            this.materialLabel4.TabIndex = 10;
            this.materialLabel4.Text = "Názov šablóny";
            // 
            // NameOfTempTextBox
            // 
            this.NameOfTempTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameOfTempTextBox.Depth = 0;
            this.NameOfTempTextBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.NameOfTempTextBox.Location = new System.Drawing.Point(162, 74);
            this.NameOfTempTextBox.MaxLength = 32767;
            this.NameOfTempTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NameOfTempTextBox.Multiline = false;
            this.NameOfTempTextBox.Name = "NameOfTempTextBox";
            this.NameOfTempTextBox.Size = new System.Drawing.Size(564, 25);
            this.NameOfTempTextBox.TabIndex = 11;
            this.NameOfTempTextBox.TabStop = false;
            this.NameOfTempTextBox.Text = "";
            this.NameOfTempTextBox.UseTallSize = false;
            // 
            // ClearBtn
            // 
            this.ClearBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearBtn.Depth = 0;
            this.ClearBtn.DrawShadows = true;
            this.ClearBtn.HighEmphasis = true;
            this.ClearBtn.Icon = null;
            this.ClearBtn.Location = new System.Drawing.Point(763, 90);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ClearBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(84, 36);
            this.ClearBtn.TabIndex = 12;
            this.ClearBtn.Text = "Vyčistiť";
            this.ClearBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ClearBtn.UseAccentColor = false;
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // AddEmailTemplateAttachmentsBtn
            // 
            this.AddEmailTemplateAttachmentsBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddEmailTemplateAttachmentsBtn.Depth = 0;
            this.AddEmailTemplateAttachmentsBtn.DrawShadows = true;
            this.AddEmailTemplateAttachmentsBtn.HighEmphasis = true;
            this.AddEmailTemplateAttachmentsBtn.Icon = null;
            this.AddEmailTemplateAttachmentsBtn.Location = new System.Drawing.Point(49, 529);
            this.AddEmailTemplateAttachmentsBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddEmailTemplateAttachmentsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddEmailTemplateAttachmentsBtn.Name = "AddEmailTemplateAttachmentsBtn";
            this.AddEmailTemplateAttachmentsBtn.Size = new System.Drawing.Size(136, 36);
            this.AddEmailTemplateAttachmentsBtn.TabIndex = 13;
            this.AddEmailTemplateAttachmentsBtn.Text = "Pridať prílohy";
            this.AddEmailTemplateAttachmentsBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddEmailTemplateAttachmentsBtn.UseAccentColor = false;
            this.AddEmailTemplateAttachmentsBtn.UseVisualStyleBackColor = true;
            this.AddEmailTemplateAttachmentsBtn.Click += new System.EventHandler(this.AddEmailTemplateAttachmentsBtn_Click);
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
            this.AttachmentsGrid.Location = new System.Drawing.Point(206, 529);
            this.AttachmentsGrid.Name = "AttachmentsGrid";
            this.AttachmentsGrid.ReadOnly = true;
            this.AttachmentsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AttachmentsGrid.RowHeadersVisible = false;
            this.AttachmentsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AttachmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AttachmentsGrid.Size = new System.Drawing.Size(254, 72);
            this.AttachmentsGrid.TabIndex = 14;
            this.AttachmentsGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AttachmentsGrid_KeyUp);
            // 
            // OpenAttachmentBtn
            // 
            this.OpenAttachmentBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenAttachmentBtn.Depth = 0;
            this.OpenAttachmentBtn.DrawShadows = true;
            this.OpenAttachmentBtn.HighEmphasis = true;
            this.OpenAttachmentBtn.Icon = null;
            this.OpenAttachmentBtn.Location = new System.Drawing.Point(467, 529);
            this.OpenAttachmentBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OpenAttachmentBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.OpenAttachmentBtn.Name = "OpenAttachmentBtn";
            this.OpenAttachmentBtn.Size = new System.Drawing.Size(147, 36);
            this.OpenAttachmentBtn.TabIndex = 15;
            this.OpenAttachmentBtn.Text = "Otvoriť prílohu";
            this.OpenAttachmentBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.OpenAttachmentBtn.UseAccentColor = false;
            this.OpenAttachmentBtn.UseVisualStyleBackColor = true;
            this.OpenAttachmentBtn.Click += new System.EventHandler(this.OpenAttachmentBtn_Click);
            // 
            // EmailTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 641);
            this.Controls.Add(this.OpenAttachmentBtn);
            this.Controls.Add(this.AttachmentsGrid);
            this.Controls.Add(this.AddEmailTemplateAttachmentsBtn);
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
            this.MaximizeBox = false;
            this.Name = "EmailTemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vytvorenie emailovej šablóny";
            this.Load += new System.EventHandler(this.EmailTemplateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TempGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ContentTextBox;
        private MaterialSkin.Controls.MaterialTextBox  SubjectTextbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton CreateEmailTempBtn;
        private MaterialSkin.Controls.MaterialButton materialFlatButton1;
        private System.Windows.Forms.DataGridView TempGridView;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialButton materialFlatButton3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox NameOfTempTextBox;
        private MaterialSkin.Controls.MaterialButton ClearBtn;
        private MaterialSkin.Controls.MaterialButton AddEmailTemplateAttachmentsBtn;
        private System.Windows.Forms.DataGridView AttachmentsGrid;
        private MaterialSkin.Controls.MaterialButton OpenAttachmentBtn;
    }
}