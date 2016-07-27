namespace SoftBecarios
{
    partial class Principal2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal2));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.xMenu = new System.Windows.Forms.ToolStripButton();
            this.xAgregar = new System.Windows.Forms.ToolStripButton();
            this.xMostrar = new System.Windows.Forms.ToolStripButton();
            this.xVacaciones = new System.Windows.Forms.ToolStripButton();
            this.xCalificaciones = new System.Windows.Forms.ToolStripButton();
            this.xAyuda = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMenu,
            this.xAgregar,
            this.xMostrar,
            this.xVacaciones,
            this.xCalificaciones,
            this.xAyuda});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(56, 729);
            this.menu.TabIndex = 0;
            this.menu.Text = "toolStrip1";
            // 
            // xMenu
            // 
            this.xMenu.AutoSize = false;
            this.xMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xMenu.Image = ((System.Drawing.Image)(resources.GetObject("xMenu.Image")));
            this.xMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xMenu.Name = "xMenu";
            this.xMenu.Size = new System.Drawing.Size(55, 55);
            this.xMenu.Text = "toolStripButton1";
            this.xMenu.MouseEnter += new System.EventHandler(this.toolStripButton1_MouseEnter);
            this.xMenu.MouseLeave += new System.EventHandler(this.xMenu_MouseLeave);
            // 
            // xAgregar
            // 
            this.xAgregar.AutoSize = false;
            this.xAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xAgregar.Image = ((System.Drawing.Image)(resources.GetObject("xAgregar.Image")));
            this.xAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xAgregar.Name = "xAgregar";
            this.xAgregar.Size = new System.Drawing.Size(55, 55);
            this.xAgregar.Text = "toolStripButton2";
            // 
            // xMostrar
            // 
            this.xMostrar.AutoSize = false;
            this.xMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xMostrar.Image = ((System.Drawing.Image)(resources.GetObject("xMostrar.Image")));
            this.xMostrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xMostrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xMostrar.Name = "xMostrar";
            this.xMostrar.Size = new System.Drawing.Size(55, 55);
            this.xMostrar.Text = "toolStripButton3";
            // 
            // xVacaciones
            // 
            this.xVacaciones.AutoSize = false;
            this.xVacaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xVacaciones.Image = ((System.Drawing.Image)(resources.GetObject("xVacaciones.Image")));
            this.xVacaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xVacaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xVacaciones.Name = "xVacaciones";
            this.xVacaciones.Size = new System.Drawing.Size(55, 55);
            this.xVacaciones.Text = "toolStripButton4";
            // 
            // xCalificaciones
            // 
            this.xCalificaciones.AutoSize = false;
            this.xCalificaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xCalificaciones.Image = ((System.Drawing.Image)(resources.GetObject("xCalificaciones.Image")));
            this.xCalificaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xCalificaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xCalificaciones.Name = "xCalificaciones";
            this.xCalificaciones.Size = new System.Drawing.Size(55, 55);
            this.xCalificaciones.Text = "toolStripButton5";
            // 
            // xAyuda
            // 
            this.xAyuda.AutoSize = false;
            this.xAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xAyuda.Image = ((System.Drawing.Image)(resources.GetObject("xAyuda.Image")));
            this.xAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xAyuda.Name = "xAyuda";
            this.xAyuda.Size = new System.Drawing.Size(55, 55);
            this.xAyuda.Text = "toolStripButton6";
            // 
            // Principal2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Principal2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Expedientes";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton xMenu;
        private System.Windows.Forms.ToolStripButton xAgregar;
        private System.Windows.Forms.ToolStripButton xMostrar;
        private System.Windows.Forms.ToolStripButton xVacaciones;
        private System.Windows.Forms.ToolStripButton xCalificaciones;
        private System.Windows.Forms.ToolStripButton xAyuda;
    }
}