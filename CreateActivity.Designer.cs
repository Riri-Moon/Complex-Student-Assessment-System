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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateActivity));
            this.ActivityGridView = new System.Windows.Forms.DataGridView();
            this.CreateActBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.SendingEmailCheck = new MaterialSkin.Controls.MaterialCheckbox();
            this.groupCmbo = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.TaskGrid = new System.Windows.Forms.DataGridView();
            this.ActCreatedCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
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
            resources.ApplyResources(this.ActivityGridView, "ActivityGridView");
            this.ActivityGridView.MultiSelect = false;
            this.ActivityGridView.Name = "ActivityGridView";
            this.ActivityGridView.ReadOnly = true;
            this.ActivityGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ActivityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ActivityGridView.SelectionChanged += new System.EventHandler(this.ActivityGridView_SelectionChanged);
            // 
            // CreateActBtn
            // 
            resources.ApplyResources(this.CreateActBtn, "CreateActBtn");
            this.CreateActBtn.Depth = 0;
            this.CreateActBtn.DrawShadows = true;
            this.CreateActBtn.HighEmphasis = true;
            this.CreateActBtn.Icon = null;
            this.CreateActBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateActBtn.Name = "CreateActBtn";
            this.CreateActBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateActBtn.UseAccentColor = false;
            this.CreateActBtn.UseVisualStyleBackColor = true;
            this.CreateActBtn.Click += new System.EventHandler(this.CreateActBtn_Click);
            // 
            // materialFlatButton2
            // 
            resources.ApplyResources(this.materialFlatButton2, "materialFlatButton2");
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.DrawShadows = true;
            this.materialFlatButton2.HighEmphasis = true;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialFlatButton2.UseAccentColor = false;
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            resources.ApplyResources(this.materialLabel1, "materialLabel1");
            this.materialLabel1.Depth = 0;
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // materialLabel2
            // 
            resources.ApplyResources(this.materialLabel2, "materialLabel2");
            this.materialLabel2.Depth = 0;
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            // 
            // materialLabel3
            // 
            resources.ApplyResources(this.materialLabel3, "materialLabel3");
            this.materialLabel3.Depth = 0;
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            // 
            // SendingEmailCheck
            // 
            resources.ApplyResources(this.SendingEmailCheck, "SendingEmailCheck");
            this.SendingEmailCheck.Depth = 0;
            this.SendingEmailCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SendingEmailCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendingEmailCheck.Name = "SendingEmailCheck";
            this.SendingEmailCheck.Ripple = true;
            this.SendingEmailCheck.UseVisualStyleBackColor = true;
            this.SendingEmailCheck.CheckedChanged += new System.EventHandler(this.SendingEmailCheck_CheckedChanged);
            // 
            // groupCmbo
            // 
            this.groupCmbo.FormattingEnabled = true;
            resources.ApplyResources(this.groupCmbo, "groupCmbo");
            this.groupCmbo.Name = "groupCmbo";
            this.groupCmbo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dateTimePicker2
            // 
            resources.ApplyResources(this.dateTimePicker2, "dateTimePicker2");
            this.dateTimePicker2.Name = "dateTimePicker2";
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
            resources.ApplyResources(this.TaskGrid, "TaskGrid");
            this.TaskGrid.MultiSelect = false;
            this.TaskGrid.Name = "TaskGrid";
            this.TaskGrid.ReadOnly = true;
            this.TaskGrid.RowHeadersVisible = false;
            this.TaskGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ActCreatedCheckBox
            // 
            resources.ApplyResources(this.ActCreatedCheckBox, "ActCreatedCheckBox");
            this.ActCreatedCheckBox.Depth = 0;
            this.ActCreatedCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ActCreatedCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ActCreatedCheckBox.Name = "ActCreatedCheckBox";
            this.ActCreatedCheckBox.Ripple = true;
            this.ActCreatedCheckBox.UseVisualStyleBackColor = true;
            this.ActCreatedCheckBox.CheckedChanged += new System.EventHandler(this.ActCreatedCheckBox_CheckedChanged);
            // 
            // materialLabel4
            // 
            resources.ApplyResources(this.materialLabel4, "materialLabel4");
            this.materialLabel4.Depth = 0;
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.UseCompatibleTextRendering = true;
            // 
            // materialLabel5
            // 
            resources.ApplyResources(this.materialLabel5, "materialLabel5");
            this.materialLabel5.Depth = 0;
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            // 
            // CreateActivity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.ActCreatedCheckBox);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.TaskGrid);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.groupCmbo);
            this.Controls.Add(this.SendingEmailCheck);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.CreateActBtn);
            this.Controls.Add(this.ActivityGridView);
            this.Name = "CreateActivity";
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ActivityGridView;
        private MaterialSkin.Controls.MaterialButton CreateActBtn;
        private MaterialSkin.Controls.MaterialButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialCheckbox SendingEmailCheck;
        private System.Windows.Forms.ComboBox groupCmbo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView TaskGrid;
        private MaterialSkin.Controls.MaterialCheckbox ActCreatedCheckBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}