namespace CSAS
{
    partial class GradeActivityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GradeActivityForm));
            this.MaterialTabCOntrol = new MaterialSkin.Controls.MaterialTabControl();
            this.Drawer = new MaterialSkin.Controls.MaterialDrawer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MaterialTabCOntrol
            // 
            this.MaterialTabCOntrol.Depth = 0;
            this.MaterialTabCOntrol.HotTrack = true;
            resources.ApplyResources(this.MaterialTabCOntrol, "MaterialTabCOntrol");
            this.MaterialTabCOntrol.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaterialTabCOntrol.Multiline = true;
            this.MaterialTabCOntrol.Name = "MaterialTabCOntrol";
            this.MaterialTabCOntrol.SelectedIndex = 0;
            this.MaterialTabCOntrol.SelectedIndexChanged += new System.EventHandler(this.MaterialTabCOntrol_SelectedIndexChanged);
            // 
            // Drawer
            // 
            this.Drawer.AutoHide = false;
            this.Drawer.BackColor = System.Drawing.Color.White;
            this.Drawer.BackgroundWithAccent = false;
            this.Drawer.BaseTabControl = this.MaterialTabCOntrol;
            this.Drawer.Depth = 0;
            this.Drawer.HighlightWithAccent = true;
            this.Drawer.IndicatorWidth = 5;
            this.Drawer.IsOpen = true;
            resources.ApplyResources(this.Drawer, "Drawer");
            this.Drawer.MouseState = MaterialSkin.MouseState.HOVER;
            this.Drawer.Name = "Drawer";
            this.Drawer.ShowIconsWhenHidden = false;
            this.Drawer.UseColors = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Drawer);
            this.panel1.Name = "panel1";
            // 
            // GradeActivityForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MaterialTabCOntrol);
            this.DrawerUseColors = true;
            this.DrawerWidth = 400;
            this.MaximizeBox = false;
            this.Name = "GradeActivityForm";
            this.Sizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GradeActivityForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MaterialTabCOntrol;
        private MaterialSkin.Controls.MaterialDrawer Drawer;
        private System.Windows.Forms.Panel panel1;
    }
}