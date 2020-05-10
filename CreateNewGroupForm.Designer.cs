namespace CSAS
{
    partial class CreateNewGroupForm
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
            this.CreateBtn = new MaterialSkin.Controls.MaterialButton();
            this.CancelBtn = new MaterialSkin.Controls.MaterialButton();
            this.GroupNameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CreateBtn
            // 
            this.CreateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateBtn.Depth = 0;
            this.CreateBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateBtn.DrawShadows = true;
            this.CreateBtn.HighEmphasis = true;
            this.CreateBtn.Icon = null;
            this.CreateBtn.Location = new System.Drawing.Point(314, 169);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(90, 36);
            this.CreateBtn.TabIndex = 2;
            this.CreateBtn.Text = "Vytvoriť";
            this.CreateBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateBtn.UseAccentColor = false;
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.DrawShadows = true;
            this.CancelBtn.HighEmphasis = true;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(26, 169);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(71, 36);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Zrušiť";
            this.CancelBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CancelBtn.UseAccentColor = false;
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // GroupNameBox
            // 
            this.GroupNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GroupNameBox.Depth = 0;
            this.GroupNameBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.GroupNameBox.Location = new System.Drawing.Point(111, 72);
            this.GroupNameBox.MaxLength = 40;
            this.GroupNameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.GroupNameBox.Multiline = false;
            this.GroupNameBox.Name = "GroupNameBox";
            this.GroupNameBox.Size = new System.Drawing.Size(219, 25);
            this.GroupNameBox.TabIndex = 0;
            this.GroupNameBox.Text = "";
            this.GroupNameBox.UseTallSize = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.label1.Location = new System.Drawing.Point(22, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Názov";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.label2.Location = new System.Drawing.Point(22, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forma";
            // 
            // FormCombo
            // 
            this.FormCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormCombo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.FormCombo.FormattingEnabled = true;
            this.FormCombo.Location = new System.Drawing.Point(111, 122);
            this.FormCombo.Name = "FormCombo";
            this.FormCombo.Size = new System.Drawing.Size(121, 23);
            this.FormCombo.TabIndex = 1;
            // 
            // CreateNewGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 228);
            this.Controls.Add(this.FormCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupNameBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CreateBtn);
            this.MaximizeBox = false;
            this.Name = "CreateNewGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vytvoriť novú skupinu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton CreateBtn;
        private MaterialSkin.Controls.MaterialButton CancelBtn;
        private MaterialSkin.Controls.MaterialTextBox GroupNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FormCombo;
    }
}