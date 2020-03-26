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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.ActNameTxtBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.AddTaskBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.MaxPtsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteTaskBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.CreateTemplateBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.AllActTempGrid = new System.Windows.Forms.DataGridView();
            this.EditActTempBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.RemoveActTempBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.actLbl = new MaterialSkin.Controls.MaterialLabel();
            this.SaveChangesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllActTempGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(64, 81);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(111, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Názov aktivity: ";
            // 
            // ActNameTxtBox
            // 
            this.ActNameTxtBox.Depth = 0;
            this.ActNameTxtBox.Hint = "";
            this.ActNameTxtBox.Location = new System.Drawing.Point(203, 77);
            this.ActNameTxtBox.MaxLength = 32767;
            this.ActNameTxtBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ActNameTxtBox.Name = "ActNameTxtBox";
            this.ActNameTxtBox.PasswordChar = '\0';
            this.ActNameTxtBox.SelectedText = "";
            this.ActNameTxtBox.SelectionLength = 0;
            this.ActNameTxtBox.SelectionStart = 0;
            this.ActNameTxtBox.Size = new System.Drawing.Size(223, 23);
            this.ActNameTxtBox.TabIndex = 5;
            this.ActNameTxtBox.TabStop = false;
            this.ActNameTxtBox.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(64, 112);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(248, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Maximálny počet bodov za aktivitu: ";
            // 
            // AddTaskBtn
            // 
            this.AddTaskBtn.AutoSize = true;
            this.AddTaskBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddTaskBtn.Depth = 0;
            this.AddTaskBtn.Icon = null;
            this.AddTaskBtn.Location = new System.Drawing.Point(25, 40);
            this.AddTaskBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddTaskBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddTaskBtn.Name = "AddTaskBtn";
            this.AddTaskBtn.Primary = false;
            this.AddTaskBtn.Size = new System.Drawing.Size(117, 36);
            this.AddTaskBtn.TabIndex = 7;
            this.AddTaskBtn.Text = "Pridať úlohu";
            this.AddTaskBtn.UseVisualStyleBackColor = true;
            this.AddTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // MaxPtsLabel
            // 
            this.MaxPtsLabel.AutoSize = true;
            this.MaxPtsLabel.Depth = 0;
            this.MaxPtsLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.MaxPtsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MaxPtsLabel.Location = new System.Drawing.Point(318, 112);
            this.MaxPtsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaxPtsLabel.Name = "MaxPtsLabel";
            this.MaxPtsLabel.Size = new System.Drawing.Size(17, 19);
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
            this.panel1.Location = new System.Drawing.Point(43, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 696);
            this.panel1.TabIndex = 11;
            // 
            // DeleteTaskBtn
            // 
            this.DeleteTaskBtn.AutoSize = true;
            this.DeleteTaskBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteTaskBtn.Depth = 0;
            this.DeleteTaskBtn.Icon = null;
            this.DeleteTaskBtn.Location = new System.Drawing.Point(500, 40);
            this.DeleteTaskBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteTaskBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteTaskBtn.Name = "DeleteTaskBtn";
            this.DeleteTaskBtn.Primary = false;
            this.DeleteTaskBtn.Size = new System.Drawing.Size(144, 36);
            this.DeleteTaskBtn.TabIndex = 8;
            this.DeleteTaskBtn.Text = "Odstrániť úlohu";
            this.DeleteTaskBtn.UseVisualStyleBackColor = true;
            this.DeleteTaskBtn.Click += new System.EventHandler(this.DeleteTaskBtn_Click);
            // 
            // CreateTemplateBtn
            // 
            this.CreateTemplateBtn.AutoSize = true;
            this.CreateTemplateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateTemplateBtn.Depth = 0;
            this.CreateTemplateBtn.Icon = null;
            this.CreateTemplateBtn.Location = new System.Drawing.Point(1195, 795);
            this.CreateTemplateBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateTemplateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateTemplateBtn.Name = "CreateTemplateBtn";
            this.CreateTemplateBtn.Primary = false;
            this.CreateTemplateBtn.Size = new System.Drawing.Size(190, 36);
            this.CreateTemplateBtn.TabIndex = 12;
            this.CreateTemplateBtn.Text = "Vytvoriť novú šablónu\r\n";
            this.CreateTemplateBtn.UseVisualStyleBackColor = true;
            this.CreateTemplateBtn.Click += new System.EventHandler(this.CreateTemplateBtn_Click);
            // 
            // AllActTempGrid
            // 
            this.AllActTempGrid.BackgroundColor = System.Drawing.Color.White;
            this.AllActTempGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllActTempGrid.Location = new System.Drawing.Point(1074, 144);
            this.AllActTempGrid.Name = "AllActTempGrid";
            this.AllActTempGrid.Size = new System.Drawing.Size(311, 306);
            this.AllActTempGrid.TabIndex = 13;
            // 
            // EditActTempBtn
            // 
            this.EditActTempBtn.AutoSize = true;
            this.EditActTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditActTempBtn.Depth = 0;
            this.EditActTempBtn.Icon = null;
            this.EditActTempBtn.Location = new System.Drawing.Point(1074, 459);
            this.EditActTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EditActTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditActTempBtn.Name = "EditActTempBtn";
            this.EditActTempBtn.Primary = false;
            this.EditActTempBtn.Size = new System.Drawing.Size(151, 36);
            this.EditActTempBtn.TabIndex = 14;
            this.EditActTempBtn.Text = "Zobraziť šablónu";
            this.EditActTempBtn.UseVisualStyleBackColor = true;
            this.EditActTempBtn.Click += new System.EventHandler(this.EditActTempBtn_Click);
            // 
            // RemoveActTempBtn
            // 
            this.RemoveActTempBtn.AutoSize = true;
            this.RemoveActTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveActTempBtn.Depth = 0;
            this.RemoveActTempBtn.Icon = null;
            this.RemoveActTempBtn.Location = new System.Drawing.Point(1289, 459);
            this.RemoveActTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoveActTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemoveActTempBtn.Name = "RemoveActTempBtn";
            this.RemoveActTempBtn.Primary = false;
            this.RemoveActTempBtn.Size = new System.Drawing.Size(96, 36);
            this.RemoveActTempBtn.TabIndex = 15;
            this.RemoveActTempBtn.Text = "Odstrániť";
            this.RemoveActTempBtn.UseVisualStyleBackColor = true;
            this.RemoveActTempBtn.Click += new System.EventHandler(this.RemoveActTempBtn_Click);
            // 
            // actLbl
            // 
            this.actLbl.AutoSize = true;
            this.actLbl.Depth = 0;
            this.actLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.actLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.actLbl.Location = new System.Drawing.Point(1070, 112);
            this.actLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.actLbl.Name = "actLbl";
            this.actLbl.Size = new System.Drawing.Size(241, 19);
            this.actLbl.TabIndex = 16;
            this.actLbl.Text = "Zoznam existujúcich šablón aktivít";
            // 
            // SaveChangesBtn
            // 
            this.SaveChangesBtn.AutoSize = true;
            this.SaveChangesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveChangesBtn.Depth = 0;
            this.SaveChangesBtn.Icon = null;
            this.SaveChangesBtn.Location = new System.Drawing.Point(1268, 507);
            this.SaveChangesBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SaveChangesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveChangesBtn.Name = "SaveChangesBtn";
            this.SaveChangesBtn.Primary = false;
            this.SaveChangesBtn.Size = new System.Drawing.Size(117, 36);
            this.SaveChangesBtn.TabIndex = 17;
            this.SaveChangesBtn.Text = "Uložiť zmeny";
            this.SaveChangesBtn.UseVisualStyleBackColor = true;
            this.SaveChangesBtn.Click += new System.EventHandler(this.SaveChangesBtn_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(764, 795);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(55, 36);
            this.materialFlatButton2.TabIndex = 18;
            this.materialFlatButton2.Text = "Späť";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(730, 168);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(124, 19);
            this.materialLabel2.TabIndex = 19;
            this.materialLabel2.Text = "Prvé upozornenie";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(730, 259);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(134, 19);
            this.materialLabel3.TabIndex = 20;
            this.materialLabel3.Text = "Tretie upozornenie";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
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
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(878, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(878, 211);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 23;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(878, 260);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 24;
            // 
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 846);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel3);
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
            this.Name = "CreateTemplate";
            this.Text = "Tvorba šablóny";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllActTempGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField ActNameTxtBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialFlatButton AddTaskBtn;
        private MaterialSkin.Controls.MaterialLabel MaxPtsLabel;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton CreateTemplateBtn;
        private System.Windows.Forms.DataGridView AllActTempGrid;
        private MaterialSkin.Controls.MaterialFlatButton EditActTempBtn;
        private MaterialSkin.Controls.MaterialFlatButton RemoveActTempBtn;
        private MaterialSkin.Controls.MaterialFlatButton DeleteTaskBtn;
        private MaterialSkin.Controls.MaterialLabel actLbl;
        private MaterialSkin.Controls.MaterialFlatButton SaveChangesBtn;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}