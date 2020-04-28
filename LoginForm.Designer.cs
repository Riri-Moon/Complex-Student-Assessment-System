namespace CSAS
{
    partial class LoginForm
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
            this.NameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.FirstPssBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCheckbox1 = new MaterialSkin.Controls.MaterialCheckbox();
            this.LoginBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Depth = 0;
            this.NameBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.NameBox.Location = new System.Drawing.Point(118, 78);
            this.NameBox.MaxLength = 15;
            this.NameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NameBox.Multiline = false;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(182, 25);
            this.NameBox.TabIndex = 0;
            this.NameBox.Text = "";
            this.NameBox.UseTallSize = false;
            // 
            // FirstPssBox
            // 
            this.FirstPssBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstPssBox.Depth = 0;
            this.FirstPssBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.FirstPssBox.Location = new System.Drawing.Point(118, 119);
            this.FirstPssBox.MaxLength = 30;
            this.FirstPssBox.MouseState = MaterialSkin.MouseState.OUT;
            this.FirstPssBox.Multiline = false;
            this.FirstPssBox.Name = "FirstPssBox";
            this.FirstPssBox.Password = true;
            this.FirstPssBox.Size = new System.Drawing.Size(182, 25);
            this.FirstPssBox.TabIndex = 1;
            this.FirstPssBox.Text = "";
            this.FirstPssBox.UseTallSize = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(54, 121);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(41, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Heslo";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(54, 78);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(41, 19);
            this.materialLabel1.TabIndex = 7;
            this.materialLabel1.Text = "Meno";
            // 
            // materialCheckbox1
            // 
            this.materialCheckbox1.AutoSize = true;
            this.materialCheckbox1.Depth = 0;
            this.materialCheckbox1.Location = new System.Drawing.Point(57, 158);
            this.materialCheckbox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox1.Name = "materialCheckbox1";
            this.materialCheckbox1.Ripple = true;
            this.materialCheckbox1.Size = new System.Drawing.Size(257, 37);
            this.materialCheckbox1.TabIndex = 4;
            this.materialCheckbox1.Text = "Zapamätať prihlasovacie meno";
            this.materialCheckbox1.UseVisualStyleBackColor = true;
            // 
            // LoginBtn
            // 
            this.LoginBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginBtn.Depth = 0;
            this.LoginBtn.DrawShadows = true;
            this.LoginBtn.HighEmphasis = true;
            this.LoginBtn.Icon = null;
            this.LoginBtn.Location = new System.Drawing.Point(409, 70);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(115, 36);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Registrovať";
            this.LoginBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.LoginBtn.UseAccentColor = false;
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Depth = 0;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(433, 211);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(91, 36);
            this.materialButton1.TabIndex = 2;
            this.materialButton1.Text = "Prihlásiť";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.linkLabel1.Location = new System.Drawing.Point(374, 121);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(150, 23);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zabudnuté heslo";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Depth = 0;
            this.materialButton2.DrawShadows = true;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(13, 211);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(82, 36);
            this.materialButton2.TabIndex = 5;
            this.materialButton2.Text = "Ukončiť";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 262);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.materialCheckbox1);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.FirstPssBox);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prihlásenie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox NameBox;
        private MaterialSkin.Controls.MaterialTextBox FirstPssBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox1;
        private MaterialSkin.Controls.MaterialButton LoginBtn;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
    }
}