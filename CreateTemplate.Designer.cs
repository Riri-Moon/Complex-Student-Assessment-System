namespace CSAS
{
    partial class CreateTemplate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.ActNameTxtBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.AddTaskBtn = new MaterialSkin.Controls.MaterialButton();
            this.MaxPtsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteTaskBtn = new MaterialSkin.Controls.MaterialButton();
            this.CreateTemplateBtn = new MaterialSkin.Controls.MaterialButton();
            this.AllActTempGrid = new System.Windows.Forms.DataGridView();
            this.EditActTempBtn = new MaterialSkin.Controls.MaterialButton();
            this.RemoveActTempBtn = new MaterialSkin.Controls.MaterialButton();
            this.actLbl = new MaterialSkin.Controls.MaterialLabel();
            this.SaveChangesBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllActTempGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(64, 81);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(109, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Názov aktivity: ";
            // 
            // ActNameTxtBox
            // 
            this.ActNameTxtBox.BackColor = System.Drawing.Color.White;
            this.ActNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ActNameTxtBox.Depth = 0;
            this.ActNameTxtBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.ActNameTxtBox.Location = new System.Drawing.Point(179, 75);
            this.ActNameTxtBox.MaxLength = 32767;
            this.ActNameTxtBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ActNameTxtBox.Multiline = false;
            this.ActNameTxtBox.Name = "ActNameTxtBox";
            this.ActNameTxtBox.Size = new System.Drawing.Size(223, 25);
            this.ActNameTxtBox.TabIndex = 5;
            this.ActNameTxtBox.TabStop = false;
            this.ActNameTxtBox.Text = "";
            this.ActNameTxtBox.UseTallSize = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(64, 112);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(213, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Maximálne bodov za aktivitu: ";
            // 
            // AddTaskBtn
            // 
            this.AddTaskBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddTaskBtn.Depth = 0;
            this.AddTaskBtn.DrawShadows = true;
            this.AddTaskBtn.HighEmphasis = true;
            this.AddTaskBtn.Icon = null;
            this.AddTaskBtn.Location = new System.Drawing.Point(25, 40);
            this.AddTaskBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddTaskBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddTaskBtn.Name = "AddTaskBtn";
            this.AddTaskBtn.Size = new System.Drawing.Size(124, 36);
            this.AddTaskBtn.TabIndex = 7;
            this.AddTaskBtn.Text = "Pridať úlohu";
            this.AddTaskBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddTaskBtn.UseAccentColor = false;
            this.AddTaskBtn.UseVisualStyleBackColor = true;
            this.AddTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // MaxPtsLabel
            // 
            this.MaxPtsLabel.AutoSize = true;
            this.MaxPtsLabel.Depth = 0;
            this.MaxPtsLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MaxPtsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MaxPtsLabel.Location = new System.Drawing.Point(283, 112);
            this.MaxPtsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaxPtsLabel.Name = "MaxPtsLabel";
            this.MaxPtsLabel.Size = new System.Drawing.Size(10, 19);
            this.MaxPtsLabel.TabIndex = 8;
            this.MaxPtsLabel.Text = "0";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DeleteTaskBtn);
            this.panel1.Controls.Add(this.AddTaskBtn);
            this.panel1.Location = new System.Drawing.Point(43, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 696);
            this.panel1.TabIndex = 11;
            // 
            // DeleteTaskBtn
            // 
            this.DeleteTaskBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteTaskBtn.Depth = 0;
            this.DeleteTaskBtn.DrawShadows = true;
            this.DeleteTaskBtn.HighEmphasis = true;
            this.DeleteTaskBtn.Icon = null;
            this.DeleteTaskBtn.Location = new System.Drawing.Point(500, 40);
            this.DeleteTaskBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteTaskBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteTaskBtn.Name = "DeleteTaskBtn";
            this.DeleteTaskBtn.Size = new System.Drawing.Size(153, 36);
            this.DeleteTaskBtn.TabIndex = 8;
            this.DeleteTaskBtn.Text = "Odstrániť úlohu";
            this.DeleteTaskBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DeleteTaskBtn.UseAccentColor = false;
            this.DeleteTaskBtn.UseVisualStyleBackColor = true;
            this.DeleteTaskBtn.Click += new System.EventHandler(this.DeleteTaskBtn_Click);
            // 
            // CreateTemplateBtn
            // 
            this.CreateTemplateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateTemplateBtn.Depth = 0;
            this.CreateTemplateBtn.DrawShadows = true;
            this.CreateTemplateBtn.HighEmphasis = true;
            this.CreateTemplateBtn.Icon = null;
            this.CreateTemplateBtn.Location = new System.Drawing.Point(1194, 769);
            this.CreateTemplateBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateTemplateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateTemplateBtn.Name = "CreateTemplateBtn";
            this.CreateTemplateBtn.Size = new System.Drawing.Size(203, 36);
            this.CreateTemplateBtn.TabIndex = 12;
            this.CreateTemplateBtn.Text = "Vytvoriť novú šablónu\r\n";
            this.CreateTemplateBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateTemplateBtn.UseAccentColor = false;
            this.CreateTemplateBtn.UseVisualStyleBackColor = true;
            this.CreateTemplateBtn.Click += new System.EventHandler(this.CreateTemplateBtn_Click);
            // 
            // AllActTempGrid
            // 
            this.AllActTempGrid.BackgroundColor = System.Drawing.Color.White;
            this.AllActTempGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AllActTempGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.AllActTempGrid.Location = new System.Drawing.Point(1074, 144);
            this.AllActTempGrid.Name = "AllActTempGrid";
            this.AllActTempGrid.Size = new System.Drawing.Size(311, 306);
            this.AllActTempGrid.TabIndex = 13;
            // 
            // EditActTempBtn
            // 
            this.EditActTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditActTempBtn.Depth = 0;
            this.EditActTempBtn.DrawShadows = true;
            this.EditActTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditActTempBtn.HighEmphasis = true;
            this.EditActTempBtn.Icon = null;
            this.EditActTempBtn.Location = new System.Drawing.Point(1074, 459);
            this.EditActTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EditActTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditActTempBtn.Name = "EditActTempBtn";
            this.EditActTempBtn.Size = new System.Drawing.Size(160, 36);
            this.EditActTempBtn.TabIndex = 14;
            this.EditActTempBtn.Text = "Zobraziť šablónu";
            this.EditActTempBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.EditActTempBtn.UseAccentColor = false;
            this.EditActTempBtn.UseVisualStyleBackColor = true;
            this.EditActTempBtn.Click += new System.EventHandler(this.EditActTempBtn_Click);
            // 
            // RemoveActTempBtn
            // 
            this.RemoveActTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveActTempBtn.Depth = 0;
            this.RemoveActTempBtn.DrawShadows = true;
            this.RemoveActTempBtn.HighEmphasis = true;
            this.RemoveActTempBtn.Icon = null;
            this.RemoveActTempBtn.Location = new System.Drawing.Point(1289, 459);
            this.RemoveActTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoveActTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemoveActTempBtn.Name = "RemoveActTempBtn";
            this.RemoveActTempBtn.Size = new System.Drawing.Size(101, 36);
            this.RemoveActTempBtn.TabIndex = 15;
            this.RemoveActTempBtn.Text = "Odstrániť";
            this.RemoveActTempBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RemoveActTempBtn.UseAccentColor = false;
            this.RemoveActTempBtn.UseVisualStyleBackColor = true;
            this.RemoveActTempBtn.Click += new System.EventHandler(this.RemoveActTempBtn_Click);
            // 
            // actLbl
            // 
            this.actLbl.AutoSize = true;
            this.actLbl.Depth = 0;
            this.actLbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.actLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.actLbl.Location = new System.Drawing.Point(1070, 112);
            this.actLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.actLbl.Name = "actLbl";
            this.actLbl.Size = new System.Drawing.Size(247, 19);
            this.actLbl.TabIndex = 16;
            this.actLbl.Text = "Zoznam existujúcich šablón aktivít";
            // 
            // SaveChangesBtn
            // 
            this.SaveChangesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveChangesBtn.Depth = 0;
            this.SaveChangesBtn.DrawShadows = true;
            this.SaveChangesBtn.Enabled = false;
            this.SaveChangesBtn.HighEmphasis = true;
            this.SaveChangesBtn.Icon = null;
            this.SaveChangesBtn.Location = new System.Drawing.Point(1268, 507);
            this.SaveChangesBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SaveChangesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveChangesBtn.Name = "SaveChangesBtn";
            this.SaveChangesBtn.Size = new System.Drawing.Size(124, 36);
            this.SaveChangesBtn.TabIndex = 17;
            this.SaveChangesBtn.Text = "Uložiť zmeny";
            this.SaveChangesBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.SaveChangesBtn.UseAccentColor = false;
            this.SaveChangesBtn.UseVisualStyleBackColor = true;
            this.SaveChangesBtn.Click += new System.EventHandler(this.SaveChangesBtn_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.DrawShadows = true;
            this.materialFlatButton2.HighEmphasis = true;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(788, 769);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Size = new System.Drawing.Size(58, 36);
            this.materialFlatButton2.TabIndex = 18;
            this.materialFlatButton2.Text = "Späť";
            this.materialFlatButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialFlatButton2.UseAccentColor = false;
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(741, 169);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(123, 19);
            this.materialLabel2.TabIndex = 19;
            this.materialLabel2.Text = "Prvé upozornenie";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(730, 210);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(134, 19);
            this.materialLabel5.TabIndex = 21;
            this.materialLabel5.Text = "Druhé upozornenie";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(878, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 25);
            this.comboBox1.TabIndex = 22;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(878, 211);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(173, 25);
            this.comboBox2.TabIndex = 23;
            // 
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 861);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.SaveChangesBtn);
            this.Controls.Add(this.actLbl);
            this.Controls.Add(this.RemoveActTempBtn);
            this.Controls.Add(this.EditActTempBtn);
            this.Controls.Add(this.AllActTempGrid);
            this.Controls.Add(this.CreateTemplateBtn);
            this.Controls.Add(this.MaxPtsLabel);
            this.Controls.Add(this.ActNameTxtBox);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "CreateTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tvorba šablóny";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllActTempGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox ActNameTxtBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialButton AddTaskBtn;
        private MaterialSkin.Controls.MaterialLabel MaxPtsLabel;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton CreateTemplateBtn;
        private System.Windows.Forms.DataGridView AllActTempGrid;
        private MaterialSkin.Controls.MaterialButton EditActTempBtn;
        private MaterialSkin.Controls.MaterialButton RemoveActTempBtn;
        private MaterialSkin.Controls.MaterialButton DeleteTaskBtn;
        private MaterialSkin.Controls.MaterialLabel actLbl;
        private MaterialSkin.Controls.MaterialButton SaveChangesBtn;
        private MaterialSkin.Controls.MaterialButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}