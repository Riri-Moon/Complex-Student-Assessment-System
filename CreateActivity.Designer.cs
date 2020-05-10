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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateActivity));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ActivityGridView = new System.Windows.Forms.DataGridView();
            this.CreateActBtn = new MaterialSkin.Controls.MaterialButton();
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
            this.SendMeBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ActivityGridView
            // 
            this.ActivityGridView.AllowUserToAddRows = false;
            this.ActivityGridView.AllowUserToDeleteRows = false;
            this.ActivityGridView.AllowUserToResizeColumns = false;
            this.ActivityGridView.AllowUserToResizeRows = false;
            this.ActivityGridView.BackgroundColor = System.Drawing.Color.White;
            this.ActivityGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ActivityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ActivityGridView.DefaultCellStyle = dataGridViewCellStyle21;
            this.ActivityGridView.GridColor = System.Drawing.Color.White;
            resources.ApplyResources(this.ActivityGridView, "ActivityGridView");
            this.ActivityGridView.MultiSelect = false;
            this.ActivityGridView.Name = "ActivityGridView";
            this.ActivityGridView.ReadOnly = true;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ActivityGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
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
            // 
            // groupCmbo
            // 
            this.groupCmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.groupCmbo, "groupCmbo");
            this.groupCmbo.FormattingEnabled = true;
            this.groupCmbo.Name = "groupCmbo";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.dateTimePicker2, "dateTimePicker2");
            this.dateTimePicker2.Name = "dateTimePicker2";
            // 
            // TaskGrid
            // 
            this.TaskGrid.AllowUserToAddRows = false;
            this.TaskGrid.AllowUserToDeleteRows = false;
            this.TaskGrid.AllowUserToResizeColumns = false;
            this.TaskGrid.AllowUserToResizeRows = false;
            this.TaskGrid.BackgroundColor = System.Drawing.Color.White;
            this.TaskGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskGrid.DefaultCellStyle = dataGridViewCellStyle23;
            this.TaskGrid.GridColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TaskGrid, "TaskGrid");
            this.TaskGrid.MultiSelect = false;
            this.TaskGrid.Name = "TaskGrid";
            this.TaskGrid.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TaskGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.TaskGrid.RowHeadersVisible = false;
            this.TaskGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaskGrid.SelectionChanged += new System.EventHandler(this.TaskGrid_SelectionChanged);
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
            // SendMeBox
            // 
            resources.ApplyResources(this.SendMeBox, "SendMeBox");
            this.SendMeBox.Depth = 0;
            this.SendMeBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SendMeBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendMeBox.Name = "SendMeBox";
            this.SendMeBox.Ripple = true;
            this.SendMeBox.UseVisualStyleBackColor = true;
            // 
            // materialLabel6
            // 
            resources.ApplyResources(this.materialLabel6, "materialLabel6");
            this.materialLabel6.Depth = 0;
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.UseCompatibleTextRendering = true;
            // 
            // materialLabel7
            // 
            resources.ApplyResources(this.materialLabel7, "materialLabel7");
            this.materialLabel7.Depth = 0;
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            // 
            // CreateActivity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.SendMeBox);
            this.Controls.Add(this.materialLabel6);
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
            this.Controls.Add(this.CreateActBtn);
            this.Controls.Add(this.ActivityGridView);
            this.MaximizeBox = false;
            this.Name = "CreateActivity";
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ActivityGridView;
        private MaterialSkin.Controls.MaterialButton CreateActBtn;
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
        private MaterialSkin.Controls.MaterialCheckbox SendMeBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
    }
}