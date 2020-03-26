namespace CSAS
{
    partial class CreateActivity
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
            this.ActivityGridView = new System.Windows.Forms.DataGridView();
            this.CreateActBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.SendingEmailCheck = new MaterialSkin.Controls.MaterialCheckBox();
            this.groupLabel = new MaterialSkin.Controls.MaterialLabel();
            this.groupCmbo = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.TaskGrid = new System.Windows.Forms.DataGridView();
            this.ActCreatedCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ActivityGridView
            // 
            this.ActivityGridView.AllowUserToAddRows = false;
            this.ActivityGridView.AllowUserToDeleteRows = false;
            this.ActivityGridView.AllowUserToResizeColumns = false;
            this.ActivityGridView.BackgroundColor = System.Drawing.Color.White;
            this.ActivityGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ActivityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActivityGridView.GridColor = System.Drawing.Color.White;
            this.ActivityGridView.Location = new System.Drawing.Point(45, 106);
            this.ActivityGridView.MultiSelect = false;
            this.ActivityGridView.Name = "ActivityGridView";
            this.ActivityGridView.ReadOnly = true;
            this.ActivityGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ActivityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ActivityGridView.Size = new System.Drawing.Size(322, 409);
            this.ActivityGridView.TabIndex = 0;
            this.ActivityGridView.SelectionChanged += new System.EventHandler(this.ActivityGridView_SelectionChanged);
            // 
            // CreateActBtn
            // 
            this.CreateActBtn.AutoSize = true;
            this.CreateActBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateActBtn.Depth = 0;
            this.CreateActBtn.Icon = null;
            this.CreateActBtn.Location = new System.Drawing.Point(845, 545);
            this.CreateActBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateActBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateActBtn.Name = "CreateActBtn";
            this.CreateActBtn.Primary = false;
            this.CreateActBtn.Size = new System.Drawing.Size(149, 36);
            this.CreateActBtn.TabIndex = 1;
            this.CreateActBtn.Text = "Vytvoriť aktivitu";
            this.CreateActBtn.UseVisualStyleBackColor = true;
            this.CreateActBtn.Click += new System.EventHandler(this.CreateActBtn_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(45, 545);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(55, 36);
            this.materialFlatButton2.TabIndex = 2;
            this.materialFlatButton2.Text = "Späť";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(373, 75);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(111, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Úlohy v aktivite";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(783, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(642, 75);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(125, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Dátum odovzdaia";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(642, 106);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(229, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Odosielanie upozornení emailom";
            // 
            // SendingEmailCheck
            // 
            this.SendingEmailCheck.AutoSize = true;
            this.SendingEmailCheck.Depth = 0;
            this.SendingEmailCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.SendingEmailCheck.Location = new System.Drawing.Point(899, 102);
            this.SendingEmailCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SendingEmailCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SendingEmailCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendingEmailCheck.Name = "SendingEmailCheck";
            this.SendingEmailCheck.Ripple = true;
            this.SendingEmailCheck.Size = new System.Drawing.Size(26, 30);
            this.SendingEmailCheck.TabIndex = 7;
            this.SendingEmailCheck.UseVisualStyleBackColor = true;
            this.SendingEmailCheck.CheckedChanged += new System.EventHandler(this.SendingEmailCheck_CheckedChanged);
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Depth = 0;
            this.groupLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.groupLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupLabel.Location = new System.Drawing.Point(642, 181);
            this.groupLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(135, 19);
            this.groupLabel.TabIndex = 8;
            this.groupLabel.Text = "Vytvoriť pre krúžok";
            this.groupLabel.Click += new System.EventHandler(this.materialLabel4_Click);
            // 
            // groupCmbo
            // 
            this.groupCmbo.FormattingEnabled = true;
            this.groupCmbo.Location = new System.Drawing.Point(899, 182);
            this.groupCmbo.Name = "groupCmbo";
            this.groupCmbo.Size = new System.Drawing.Size(121, 21);
            this.groupCmbo.TabIndex = 9;
            this.groupCmbo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(973, 75);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(64, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // TaskGrid
            // 
            this.TaskGrid.AllowUserToAddRows = false;
            this.TaskGrid.AllowUserToDeleteRows = false;
            this.TaskGrid.AllowUserToResizeColumns = false;
            this.TaskGrid.BackgroundColor = System.Drawing.Color.White;
            this.TaskGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskGrid.GridColor = System.Drawing.Color.White;
            this.TaskGrid.Location = new System.Drawing.Point(373, 106);
            this.TaskGrid.MultiSelect = false;
            this.TaskGrid.Name = "TaskGrid";
            this.TaskGrid.ReadOnly = true;
            this.TaskGrid.RowHeadersVisible = false;
            this.TaskGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaskGrid.Size = new System.Drawing.Size(240, 409);
            this.TaskGrid.TabIndex = 11;
            // 
            // ActCreatedCheckBox
            // 
            this.ActCreatedCheckBox.AutoSize = true;
            this.ActCreatedCheckBox.Depth = 0;
            this.ActCreatedCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.ActCreatedCheckBox.Location = new System.Drawing.Point(899, 138);
            this.ActCreatedCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ActCreatedCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ActCreatedCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ActCreatedCheckBox.Name = "ActCreatedCheckBox";
            this.ActCreatedCheckBox.Ripple = true;
            this.ActCreatedCheckBox.Size = new System.Drawing.Size(26, 30);
            this.ActCreatedCheckBox.TabIndex = 13;
            this.ActCreatedCheckBox.UseVisualStyleBackColor = true;
            this.ActCreatedCheckBox.CheckedChanged += new System.EventHandler(this.ActCreatedCheckBox_CheckedChanged);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(642, 142);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(231, 19);
            this.materialLabel4.TabIndex = 12;
            this.materialLabel4.Text = "Odoslať email o vytvorení aktivity";
            // 
            // CreateActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 618);
            this.Controls.Add(this.ActCreatedCheckBox);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.TaskGrid);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.groupCmbo);
            this.Controls.Add(this.groupLabel);
            this.Controls.Add(this.SendingEmailCheck);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.CreateActBtn);
            this.Controls.Add(this.ActivityGridView);
            this.Name = "CreateActivity";
            this.Text = "Vytvoriť aktivitu";
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ActivityGridView;
        private MaterialSkin.Controls.MaterialFlatButton CreateActBtn;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialCheckBox SendingEmailCheck;
        private MaterialSkin.Controls.MaterialLabel groupLabel;
        private System.Windows.Forms.ComboBox groupCmbo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView TaskGrid;
        private MaterialSkin.Controls.MaterialCheckBox ActCreatedCheckBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}