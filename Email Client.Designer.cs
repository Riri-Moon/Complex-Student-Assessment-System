namespace CSAS
{
    partial class Email_Client
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
            this.save_email = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.textBox2 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.CreateEmailTemplateContext = new System.Windows.Forms.ToolStripMenuItem();
            this.materialMultiLineTextBox1 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.ABox = new MaterialSkin.Controls.MaterialTextBox();
            this.BBox = new MaterialSkin.Controls.MaterialTextBox();
            this.CBox = new MaterialSkin.Controls.MaterialTextBox();
            this.DBox = new MaterialSkin.Controls.MaterialTextBox();
            this.EBox = new MaterialSkin.Controls.MaterialTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.DeleteAllGroupDataBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_email
            // 
            this.save_email.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save_email.Depth = 0;
            this.save_email.DrawShadows = true;
            this.save_email.HighEmphasis = true;
            this.save_email.Icon = null;
            this.save_email.Location = new System.Drawing.Point(859, 411);
            this.save_email.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.save_email.MouseState = MaterialSkin.MouseState.HOVER;
            this.save_email.Name = "save_email";
            this.save_email.Size = new System.Drawing.Size(69, 36);
            this.save_email.TabIndex = 0;
            this.save_email.Text = "Uložiť";
            this.save_email.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.save_email.UseAccentColor = false;
            this.save_email.UseVisualStyleBackColor = true;
            this.save_email.Click += new System.EventHandler(this.save_email_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(29, 112);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(52, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Api key";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(29, 161);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(119, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Emailová adresa";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Roboto", 12F);
            this.textBox1.Location = new System.Drawing.Point(165, 112);
            this.textBox1.MaxLength = 200;
            this.textBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            this.textBox1.UseTallSize = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Depth = 0;
            this.textBox2.Font = new System.Drawing.Font("Roboto", 12F);
            this.textBox2.Location = new System.Drawing.Point(165, 162);
            this.textBox2.MaxLength = 55;
            this.textBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(293, 25);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "";
            this.textBox2.UseTallSize = false;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateEmailTemplateContext});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(214, 26);
            this.materialContextMenuStrip1.Text = "Vytvoriť";
            // 
            // CreateEmailTemplateContext
            // 
            this.CreateEmailTemplateContext.Name = "CreateEmailTemplateContext";
            this.CreateEmailTemplateContext.Size = new System.Drawing.Size(213, 22);
            this.CreateEmailTemplateContext.Text = "Vytvoriť emailovú šablónu";
            this.CreateEmailTemplateContext.Click += new System.EventHandler(this.CreateEmailTemplateContext_Click);
            // 
            // materialMultiLineTextBox1
            // 
            this.materialMultiLineTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialMultiLineTextBox1.Depth = 0;
            this.materialMultiLineTextBox1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox1.Hint = "";
            this.materialMultiLineTextBox1.Location = new System.Drawing.Point(31, 224);
            this.materialMultiLineTextBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox1.Name = "materialMultiLineTextBox1";
            this.materialMultiLineTextBox1.Size = new System.Drawing.Size(367, 165);
            this.materialMultiLineTextBox1.TabIndex = 3;
            this.materialMultiLineTextBox1.Text = "";
            this.materialMultiLineTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.materialMultiLineTextBox1_KeyUp);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(29, 202);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(50, 19);
            this.materialLabel3.TabIndex = 10;
            this.materialLabel3.Text = "Podpis";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(780, 82);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(148, 19);
            this.materialLabel4.TabIndex = 11;
            this.materialLabel4.Text = "Stupnica hodnotenia";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(783, 112);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(23, 19);
            this.materialLabel5.TabIndex = 13;
            this.materialLabel5.Text = "A - ";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(783, 161);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(23, 19);
            this.materialLabel6.TabIndex = 14;
            this.materialLabel6.Text = "B - ";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(783, 202);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(23, 19);
            this.materialLabel7.TabIndex = 15;
            this.materialLabel7.Text = "C - ";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(782, 244);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(24, 19);
            this.materialLabel8.TabIndex = 16;
            this.materialLabel8.Text = "D - ";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(784, 284);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(22, 19);
            this.materialLabel9.TabIndex = 17;
            this.materialLabel9.Text = "E - ";
            // 
            // ABox
            // 
            this.ABox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ABox.Depth = 0;
            this.ABox.Font = new System.Drawing.Font("Roboto", 12F);
            this.ABox.Location = new System.Drawing.Point(816, 110);
            this.ABox.MaxLength = 5;
            this.ABox.MouseState = MaterialSkin.MouseState.OUT;
            this.ABox.Multiline = false;
            this.ABox.Name = "ABox";
            this.ABox.Size = new System.Drawing.Size(67, 25);
            this.ABox.TabIndex = 4;
            this.ABox.Text = "";
            this.ABox.UseTallSize = false;
            this.ABox.Enter += new System.EventHandler(this.ABox_Enter);
            // 
            // BBox
            // 
            this.BBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BBox.Depth = 0;
            this.BBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.BBox.Location = new System.Drawing.Point(816, 159);
            this.BBox.MaxLength = 5;
            this.BBox.MouseState = MaterialSkin.MouseState.OUT;
            this.BBox.Multiline = false;
            this.BBox.Name = "BBox";
            this.BBox.Size = new System.Drawing.Size(67, 25);
            this.BBox.TabIndex = 5;
            this.BBox.Text = "";
            this.BBox.UseTallSize = false;
            this.BBox.Enter += new System.EventHandler(this.BBox_Enter);
            // 
            // CBox
            // 
            this.CBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CBox.Depth = 0;
            this.CBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.CBox.Location = new System.Drawing.Point(816, 200);
            this.CBox.MaxLength = 5;
            this.CBox.MouseState = MaterialSkin.MouseState.OUT;
            this.CBox.Multiline = false;
            this.CBox.Name = "CBox";
            this.CBox.Size = new System.Drawing.Size(67, 25);
            this.CBox.TabIndex = 6;
            this.CBox.Text = "";
            this.CBox.UseTallSize = false;
            this.CBox.Enter += new System.EventHandler(this.CBox_Enter);
            // 
            // DBox
            // 
            this.DBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DBox.Depth = 0;
            this.DBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.DBox.Location = new System.Drawing.Point(816, 242);
            this.DBox.MaxLength = 5;
            this.DBox.MouseState = MaterialSkin.MouseState.OUT;
            this.DBox.Multiline = false;
            this.DBox.Name = "DBox";
            this.DBox.Size = new System.Drawing.Size(67, 25);
            this.DBox.TabIndex = 7;
            this.DBox.Text = "";
            this.DBox.UseTallSize = false;
            this.DBox.Enter += new System.EventHandler(this.DBox_Enter);
            // 
            // EBox
            // 
            this.EBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EBox.Depth = 0;
            this.EBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.EBox.Location = new System.Drawing.Point(816, 282);
            this.EBox.MaxLength = 5;
            this.EBox.MouseState = MaterialSkin.MouseState.OUT;
            this.EBox.Multiline = false;
            this.EBox.Name = "EBox";
            this.EBox.Size = new System.Drawing.Size(67, 25);
            this.EBox.TabIndex = 8;
            this.EBox.Text = "";
            this.EBox.UseTallSize = false;
            this.EBox.Enter += new System.EventHandler(this.EBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(557, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Body za aktivitu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(473, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Šablóna cvičenie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(473, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Šablóna prednáška";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(606, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 25);
            this.comboBox1.TabIndex = 22;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(607, 161);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(147, 25);
            this.comboBox2.TabIndex = 23;
            // 
            // DeleteAllGroupDataBtn
            // 
            this.DeleteAllGroupDataBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteAllGroupDataBtn.Depth = 0;
            this.DeleteAllGroupDataBtn.DrawShadows = true;
            this.DeleteAllGroupDataBtn.HighEmphasis = true;
            this.DeleteAllGroupDataBtn.Icon = null;
            this.DeleteAllGroupDataBtn.Location = new System.Drawing.Point(620, 341);
            this.DeleteAllGroupDataBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteAllGroupDataBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteAllGroupDataBtn.Name = "DeleteAllGroupDataBtn";
            this.DeleteAllGroupDataBtn.Size = new System.Drawing.Size(188, 36);
            this.DeleteAllGroupDataBtn.TabIndex = 25;
            this.DeleteAllGroupDataBtn.Text = "Vymazať dáta skupiny";
            this.DeleteAllGroupDataBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DeleteAllGroupDataBtn.UseAccentColor = false;
            this.DeleteAllGroupDataBtn.UseVisualStyleBackColor = true;
            this.DeleteAllGroupDataBtn.Click += new System.EventHandler(this.DeleteAllGroupDataBtn_Click);
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(476, 330);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(452, 2);
            this.materialDivider2.TabIndex = 38;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // Email_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 462);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.DeleteAllGroupDataBtn);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EBox);
            this.Controls.Add(this.DBox);
            this.Controls.Add(this.CBox);
            this.Controls.Add(this.BBox);
            this.Controls.Add(this.ABox);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialMultiLineTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.save_email);
            this.MaximizeBox = false;
            this.Name = "Email_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Email_Client_Load);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton save_email;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBox1;
        private MaterialSkin.Controls.MaterialTextBox textBox2;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CreateEmailTemplateContext;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialTextBox ABox;
        private MaterialSkin.Controls.MaterialTextBox BBox;
        private MaterialSkin.Controls.MaterialTextBox CBox;
        private MaterialSkin.Controls.MaterialTextBox DBox;
        private MaterialSkin.Controls.MaterialTextBox EBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private MaterialSkin.Controls.MaterialButton DeleteAllGroupDataBtn;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
    }
}