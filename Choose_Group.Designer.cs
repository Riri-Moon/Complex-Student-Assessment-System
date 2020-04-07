namespace CSAS
{
    partial class Choose_Group
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Skupiny_Grid = new System.Windows.Forms.DataGridView();
            this.Select_G_Panel = new System.Windows.Forms.Panel();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Remove_Button = new System.Windows.Forms.Button();
            this.Select_Button = new System.Windows.Forms.Button();
            this.Create_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Skupiny_Grid)).BeginInit();
            this.Select_G_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Skupiny_Grid
            // 
            this.Skupiny_Grid.AllowUserToAddRows = false;
            this.Skupiny_Grid.AllowUserToDeleteRows = false;
            this.Skupiny_Grid.AllowUserToResizeColumns = false;
            this.Skupiny_Grid.BackgroundColor = System.Drawing.Color.White;
            this.Skupiny_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Skupiny_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Skupiny_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Skupiny_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Skupiny_Grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.Skupiny_Grid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.Skupiny_Grid.Location = new System.Drawing.Point(0, 106);
            this.Skupiny_Grid.MultiSelect = false;
            this.Skupiny_Grid.Name = "Skupiny_Grid";
            this.Skupiny_Grid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Skupiny_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Skupiny_Grid.RowHeadersVisible = false;
            this.Skupiny_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Skupiny_Grid.RowTemplate.ReadOnly = true;
            this.Skupiny_Grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Skupiny_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Skupiny_Grid.Size = new System.Drawing.Size(276, 333);
            this.Skupiny_Grid.TabIndex = 4;
            // 
            // Select_G_Panel
            // 
            this.Select_G_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Select_G_Panel.Controls.Add(this.Exit_Button);
            this.Select_G_Panel.Controls.Add(this.Remove_Button);
            this.Select_G_Panel.Controls.Add(this.Select_Button);
            this.Select_G_Panel.Controls.Add(this.Create_Button);
            this.Select_G_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Select_G_Panel.ForeColor = System.Drawing.Color.Transparent;
            this.Select_G_Panel.Location = new System.Drawing.Point(275, 0);
            this.Select_G_Panel.Name = "Select_G_Panel";
            this.Select_G_Panel.Size = new System.Drawing.Size(126, 439);
            this.Select_G_Panel.TabIndex = 5;
            // 
            // Exit_Button
            // 
            this.Exit_Button.FlatAppearance.BorderSize = 0;
            this.Exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_Button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Exit_Button.ForeColor = System.Drawing.Color.Black;
            this.Exit_Button.Location = new System.Drawing.Point(0, 385);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(126, 54);
            this.Exit_Button.TabIndex = 9;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click_1);
            // 
            // Remove_Button
            // 
            this.Remove_Button.BackColor = System.Drawing.Color.White;
            this.Remove_Button.FlatAppearance.BorderSize = 0;
            this.Remove_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove_Button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Remove_Button.ForeColor = System.Drawing.Color.Black;
            this.Remove_Button.Location = new System.Drawing.Point(0, 282);
            this.Remove_Button.Name = "Remove_Button";
            this.Remove_Button.Size = new System.Drawing.Size(126, 54);
            this.Remove_Button.TabIndex = 8;
            this.Remove_Button.Text = "Remove";
            this.Remove_Button.UseVisualStyleBackColor = false;
            this.Remove_Button.Click += new System.EventHandler(this.Remove_Button_Click_1);
            // 
            // Select_Button
            // 
            this.Select_Button.BackColor = System.Drawing.Color.White;
            this.Select_Button.FlatAppearance.BorderSize = 0;
            this.Select_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Select_Button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Select_Button.ForeColor = System.Drawing.Color.Black;
            this.Select_Button.Location = new System.Drawing.Point(0, 117);
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.Size = new System.Drawing.Size(126, 54);
            this.Select_Button.TabIndex = 6;
            this.Select_Button.Text = "Select";
            this.Select_Button.UseVisualStyleBackColor = false;
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click_1);
            // 
            // Create_Button
            // 
            this.Create_Button.BackColor = System.Drawing.Color.White;
            this.Create_Button.FlatAppearance.BorderSize = 0;
            this.Create_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Create_Button.ForeColor = System.Drawing.Color.Black;
            this.Create_Button.Location = new System.Drawing.Point(0, 177);
            this.Create_Button.Name = "Create_Button";
            this.Create_Button.Size = new System.Drawing.Size(126, 54);
            this.Create_Button.TabIndex = 7;
            this.Create_Button.Text = "Create";
            this.Create_Button.UseVisualStyleBackColor = false;
            // 
            // Choose_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 439);
            this.Controls.Add(this.Skupiny_Grid);
            this.Controls.Add(this.Select_G_Panel);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Choose_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Study Group";
            this.Load += new System.EventHandler(this.Choose_Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Skupiny_Grid)).EndInit();
            this.Select_G_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Skupiny_Grid;
        private System.Windows.Forms.Panel Select_G_Panel;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Remove_Button;
        private System.Windows.Forms.Button Create_Button;
        private System.Windows.Forms.Button Select_Button;
    }
}

