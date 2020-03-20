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
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
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
            this.CreateTemplateBtn.Location = new System.Drawing.Point(764, 517);
            this.CreateTemplateBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateTemplateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateTemplateBtn.Name = "CreateTemplateBtn";
            this.CreateTemplateBtn.Primary = false;
            this.CreateTemplateBtn.Size = new System.Drawing.Size(190, 36);
            this.CreateTemplateBtn.TabIndex = 12;
            this.CreateTemplateBtn.Text = "Vytvoriť novú aktivitu";
            this.CreateTemplateBtn.UseVisualStyleBackColor = true;
            this.CreateTemplateBtn.Click += new System.EventHandler(this.CreateTemplateBtn_Click);
            // 
            // AllActTempGrid
            // 
            this.AllActTempGrid.BackgroundColor = System.Drawing.Color.White;
            this.AllActTempGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllActTempGrid.Location = new System.Drawing.Point(764, 133);
            this.AllActTempGrid.Name = "AllActTempGrid";
            this.AllActTempGrid.Size = new System.Drawing.Size(383, 306);
            this.AllActTempGrid.TabIndex = 13;
            // 
            // EditActTempBtn
            // 
            this.EditActTempBtn.AutoSize = true;
            this.EditActTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditActTempBtn.Depth = 0;
            this.EditActTempBtn.Icon = null;
            this.EditActTempBtn.Location = new System.Drawing.Point(764, 448);
            this.EditActTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EditActTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditActTempBtn.Name = "EditActTempBtn";
            this.EditActTempBtn.Primary = false;
            this.EditActTempBtn.Size = new System.Drawing.Size(149, 36);
            this.EditActTempBtn.TabIndex = 14;
            this.EditActTempBtn.Text = "Zobraziť aktivitu";
            this.EditActTempBtn.UseVisualStyleBackColor = true;
            this.EditActTempBtn.Click += new System.EventHandler(this.EditActTempBtn_Click);
            // 
            // RemoveActTempBtn
            // 
            this.RemoveActTempBtn.AutoSize = true;
            this.RemoveActTempBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveActTempBtn.Depth = 0;
            this.RemoveActTempBtn.Icon = null;
            this.RemoveActTempBtn.Location = new System.Drawing.Point(988, 448);
            this.RemoveActTempBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoveActTempBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemoveActTempBtn.Name = "RemoveActTempBtn";
            this.RemoveActTempBtn.Primary = false;
            this.RemoveActTempBtn.Size = new System.Drawing.Size(159, 36);
            this.RemoveActTempBtn.TabIndex = 15;
            this.RemoveActTempBtn.Text = "Odstrániť aktivitu";
            this.RemoveActTempBtn.UseVisualStyleBackColor = true;
            this.RemoveActTempBtn.Click += new System.EventHandler(this.RemoveActTempBtn_Click);
            // 
            // actLbl
            // 
            this.actLbl.AutoSize = true;
            this.actLbl.Depth = 0;
            this.actLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.actLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.actLbl.Location = new System.Drawing.Point(761, 112);
            this.actLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.actLbl.Name = "actLbl";
            this.actLbl.Size = new System.Drawing.Size(123, 18);
            this.actLbl.TabIndex = 16;
            this.actLbl.Text = "Existujúce aktivity";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(1030, 795);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(117, 36);
            this.materialFlatButton1.TabIndex = 17;
            this.materialFlatButton1.Text = "Uložiť zmeny";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
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
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 846);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.materialFlatButton1);
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
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
    }
}