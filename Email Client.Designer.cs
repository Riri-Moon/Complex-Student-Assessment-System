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
            this.save_email = new System.Windows.Forms.Button();
            this.cancel_email = new System.Windows.Forms.Button();
            this.Exit_email = new System.Windows.Forms.Button();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.CreateEmailTemplateContext = new System.Windows.Forms.ToolStripMenuItem();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_email
            // 
            this.save_email.Location = new System.Drawing.Point(237, 328);
            this.save_email.Name = "save_email";
            this.save_email.Size = new System.Drawing.Size(81, 32);
            this.save_email.TabIndex = 0;
            this.save_email.Text = "Save";
            this.save_email.UseVisualStyleBackColor = true;
            this.save_email.Click += new System.EventHandler(this.save_email_Click);
            // 
            // cancel_email
            // 
            this.cancel_email.Location = new System.Drawing.Point(237, 403);
            this.cancel_email.Name = "cancel_email";
            this.cancel_email.Size = new System.Drawing.Size(81, 32);
            this.cancel_email.TabIndex = 1;
            this.cancel_email.Text = "Cancel";
            this.cancel_email.UseVisualStyleBackColor = true;
            this.cancel_email.Click += new System.EventHandler(this.cancel_email_Click);
            // 
            // Exit_email
            // 
            this.Exit_email.Location = new System.Drawing.Point(29, 403);
            this.Exit_email.Name = "Exit_email";
            this.Exit_email.Size = new System.Drawing.Size(75, 32);
            this.Exit_email.TabIndex = 2;
            this.Exit_email.Text = "Exit";
            this.Exit_email.UseVisualStyleBackColor = true;
            this.Exit_email.Click += new System.EventHandler(this.Exit_email_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 105);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(59, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Api Key";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 156);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(97, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Mail Address";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(148, 157);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 20);
            this.textBox2.TabIndex = 8;
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
            // Email_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 462);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.Exit_email);
            this.Controls.Add(this.cancel_email);
            this.Controls.Add(this.save_email);
            this.Name = "Email_Client";
            this.Text = "Email Client";
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_email;
        private System.Windows.Forms.Button cancel_email;
        private System.Windows.Forms.Button Exit_email;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CreateEmailTemplateContext;
    }
}