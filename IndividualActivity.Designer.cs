namespace CSAS
{
    partial class IndividualActivity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TaskGrid = new System.Windows.Forms.DataGridView();
            this.ActivityGridView = new System.Windows.Forms.DataGridView();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.ActCreatedCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.studentCombo = new System.Windows.Forms.ComboBox();
            this.SendingEmailCheck = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CreateActBtn = new MaterialSkin.Controls.MaterialButton();
            this.SendMeBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskGrid
            // 
            this.TaskGrid.AllowUserToAddRows = false;
            this.TaskGrid.AllowUserToDeleteRows = false;
            this.TaskGrid.AllowUserToResizeColumns = false;
            this.TaskGrid.AllowUserToResizeRows = false;
            this.TaskGrid.BackgroundColor = System.Drawing.Color.White;
            this.TaskGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TaskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskGrid.DefaultCellStyle = dataGridViewCellStyle10;
            this.TaskGrid.GridColor = System.Drawing.Color.White;
            this.TaskGrid.Location = new System.Drawing.Point(780, 94);
            this.TaskGrid.MultiSelect = false;
            this.TaskGrid.Name = "TaskGrid";
            this.TaskGrid.ReadOnly = true;
            this.TaskGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TaskGrid.RowHeadersVisible = false;
            this.TaskGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TaskGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaskGrid.Size = new System.Drawing.Size(240, 239);
            this.TaskGrid.TabIndex = 13;
            this.TaskGrid.SelectionChanged += new System.EventHandler(this.TaskGrid_SelectionChanged);
            // 
            // ActivityGridView
            // 
            this.ActivityGridView.AllowUserToAddRows = false;
            this.ActivityGridView.AllowUserToDeleteRows = false;
            this.ActivityGridView.AllowUserToResizeColumns = false;
            this.ActivityGridView.BackgroundColor = System.Drawing.Color.White;
            this.ActivityGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ActivityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ActivityGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.ActivityGridView.GridColor = System.Drawing.Color.White;
            this.ActivityGridView.Location = new System.Drawing.Point(452, 94);
            this.ActivityGridView.MultiSelect = false;
            this.ActivityGridView.Name = "ActivityGridView";
            this.ActivityGridView.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ActivityGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.ActivityGridView.RowHeadersVisible = false;
            this.ActivityGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ActivityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ActivityGridView.Size = new System.Drawing.Size(322, 239);
            this.ActivityGridView.TabIndex = 12;
            this.ActivityGridView.SelectionChanged += new System.EventHandler(this.ActivityGridView_SelectionChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel5.Location = new System.Drawing.Point(34, 237);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(146, 19);
            this.materialLabel5.TabIndex = 23;
            this.materialLabel5.Text = "Aktivita pre študenta";
            // 
            // ActCreatedCheckBox
            // 
            this.ActCreatedCheckBox.AutoSize = true;
            this.ActCreatedCheckBox.Depth = 0;
            this.ActCreatedCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ActCreatedCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ActCreatedCheckBox.Location = new System.Drawing.Point(330, 153);
            this.ActCreatedCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ActCreatedCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ActCreatedCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ActCreatedCheckBox.Name = "ActCreatedCheckBox";
            this.ActCreatedCheckBox.Ripple = true;
            this.ActCreatedCheckBox.Size = new System.Drawing.Size(35, 37);
            this.ActCreatedCheckBox.TabIndex = 22;
            this.ActCreatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(368, 94);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(64, 20);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // studentCombo
            // 
            this.studentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.studentCombo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.studentCombo.FormattingEnabled = true;
            this.studentCombo.Location = new System.Drawing.Point(202, 234);
            this.studentCombo.Name = "studentCombo";
            this.studentCombo.Size = new System.Drawing.Size(163, 25);
            this.studentCombo.TabIndex = 19;
            // 
            // SendingEmailCheck
            // 
            this.SendingEmailCheck.AutoSize = true;
            this.SendingEmailCheck.Depth = 0;
            this.SendingEmailCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendingEmailCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SendingEmailCheck.Location = new System.Drawing.Point(330, 115);
            this.SendingEmailCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SendingEmailCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SendingEmailCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendingEmailCheck.Name = "SendingEmailCheck";
            this.SendingEmailCheck.Ripple = true;
            this.SendingEmailCheck.Size = new System.Drawing.Size(35, 37);
            this.SendingEmailCheck.TabIndex = 18;
            this.SendingEmailCheck.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel2.Location = new System.Drawing.Point(34, 94);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(136, 19);
            this.materialLabel2.TabIndex = 16;
            this.materialLabel2.Text = "Dátum odovzdania";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(178, 94);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 20);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // CreateActBtn
            // 
            this.CreateActBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateActBtn.Depth = 0;
            this.CreateActBtn.DrawShadows = true;
            this.CreateActBtn.HighEmphasis = true;
            this.CreateActBtn.Icon = null;
            this.CreateActBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CreateActBtn.Location = new System.Drawing.Point(862, 355);
            this.CreateActBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateActBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateActBtn.Name = "CreateActBtn";
            this.CreateActBtn.Size = new System.Drawing.Size(158, 36);
            this.CreateActBtn.TabIndex = 24;
            this.CreateActBtn.Text = "Vytvoriť aktivitu";
            this.CreateActBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateActBtn.UseAccentColor = false;
            this.CreateActBtn.UseVisualStyleBackColor = true;
            this.CreateActBtn.Click += new System.EventHandler(this.CreateActBtn_Click);
            // 
            // SendMeBox
            // 
            this.SendMeBox.AutoSize = true;
            this.SendMeBox.Depth = 0;
            this.SendMeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendMeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SendMeBox.Location = new System.Drawing.Point(330, 190);
            this.SendMeBox.Margin = new System.Windows.Forms.Padding(0);
            this.SendMeBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SendMeBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendMeBox.Name = "SendMeBox";
            this.SendMeBox.Ripple = true;
            this.SendMeBox.Size = new System.Drawing.Size(35, 37);
            this.SendMeBox.TabIndex = 26;
            this.SendMeBox.UseVisualStyleBackColor = true;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel3.Location = new System.Drawing.Point(34, 126);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(292, 19);
            this.materialLabel3.TabIndex = 27;
            this.materialLabel3.Text = "Odosielanie prednastavených upozornení";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel4.Location = new System.Drawing.Point(37, 162);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(262, 19);
            this.materialLabel4.TabIndex = 28;
            this.materialLabel4.Text = "Posielanie emailu o vytvorení aktivity";
            this.materialLabel4.UseCompatibleTextRendering = true;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel6.Location = new System.Drawing.Point(37, 199);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(259, 19);
            this.materialLabel6.TabIndex = 29;
            this.materialLabel6.Text = "Poslanie upozornenia na hodnotenie";
            this.materialLabel6.UseCompatibleTextRendering = true;
            // 
            // IndividualActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 405);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.SendMeBox);
            this.Controls.Add(this.CreateActBtn);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.ActCreatedCheckBox);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.studentCombo);
            this.Controls.Add(this.SendingEmailCheck);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.TaskGrid);
            this.Controls.Add(this.ActivityGridView);
            this.MaximizeBox = false;
            this.Name = "IndividualActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Individuálna aktivita";
            ((System.ComponentModel.ISupportInitialize)(this.TaskGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskGrid;
        private System.Windows.Forms.DataGridView ActivityGridView;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialCheckbox ActCreatedCheckBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox studentCombo;
        private MaterialSkin.Controls.MaterialCheckbox SendingEmailCheck;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialButton CreateActBtn;
        private MaterialSkin.Controls.MaterialCheckbox SendMeBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
    }
}