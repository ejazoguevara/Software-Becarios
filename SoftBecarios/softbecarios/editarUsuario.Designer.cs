namespace SoftBecarios
{
    partial class editarUsuario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editarUsuario));
            this.panelUsuario = new MetroFramework.Controls.MetroPanel();
            this.btnContra = new System.Windows.Forms.Button();
            this.panelPassword = new MetroFramework.Controls.MetroPanel();
            this.imgPass = new System.Windows.Forms.PictureBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtRepitePassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbTipoUser = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.txtUser = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panelUsuario.SuspendLayout();
            this.panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPass)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUsuario
            // 
            this.panelUsuario.Controls.Add(this.btnContra);
            this.panelUsuario.Controls.Add(this.panelPassword);
            this.panelUsuario.Controls.Add(this.cbTipoUser);
            this.panelUsuario.Controls.Add(this.metroLabel5);
            this.panelUsuario.Controls.Add(this.btnGuardar);
            this.panelUsuario.Controls.Add(this.txtNombre);
            this.panelUsuario.Controls.Add(this.txtUser);
            this.panelUsuario.Controls.Add(this.metroLabel2);
            this.panelUsuario.Controls.Add(this.metroLabel1);
            this.panelUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsuario.HorizontalScrollbarBarColor = true;
            this.panelUsuario.HorizontalScrollbarHighlightOnWheel = false;
            this.panelUsuario.HorizontalScrollbarSize = 10;
            this.panelUsuario.Location = new System.Drawing.Point(20, 60);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(359, 335);
            this.panelUsuario.TabIndex = 0;
            this.panelUsuario.VerticalScrollbarBarColor = true;
            this.panelUsuario.VerticalScrollbarHighlightOnWheel = false;
            this.panelUsuario.VerticalScrollbarSize = 10;
            // 
            // btnContra
            // 
            this.btnContra.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnContra.FlatAppearance.BorderSize = 0;
            this.btnContra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContra.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContra.ForeColor = System.Drawing.Color.White;
            this.btnContra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContra.ImageKey = "(ninguno)";
            this.btnContra.Location = new System.Drawing.Point(11, 145);
            this.btnContra.Name = "btnContra";
            this.btnContra.Size = new System.Drawing.Size(136, 27);
            this.btnContra.TabIndex = 27;
            this.btnContra.Text = "Editar Contraseña";
            this.btnContra.UseVisualStyleBackColor = false;
            this.btnContra.Click += new System.EventHandler(this.btnContra_Click);
            // 
            // panelPassword
            // 
            this.panelPassword.Controls.Add(this.imgPass);
            this.panelPassword.Controls.Add(this.txtPassword);
            this.panelPassword.Controls.Add(this.txtRepitePassword);
            this.panelPassword.Controls.Add(this.metroLabel4);
            this.panelPassword.Controls.Add(this.metroLabel3);
            this.panelPassword.HorizontalScrollbarBarColor = true;
            this.panelPassword.HorizontalScrollbarHighlightOnWheel = false;
            this.panelPassword.HorizontalScrollbarSize = 10;
            this.panelPassword.Location = new System.Drawing.Point(11, 172);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(332, 95);
            this.panelPassword.TabIndex = 26;
            this.panelPassword.VerticalScrollbarBarColor = true;
            this.panelPassword.VerticalScrollbarHighlightOnWheel = false;
            this.panelPassword.VerticalScrollbarSize = 10;
            this.panelPassword.Visible = false;
            // 
            // imgPass
            // 
            this.imgPass.Image = ((System.Drawing.Image)(resources.GetObject("imgPass.Image")));
            this.imgPass.Location = new System.Drawing.Point(300, 53);
            this.imgPass.Name = "imgPass";
            this.imgPass.Size = new System.Drawing.Size(24, 24);
            this.imgPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgPass.TabIndex = 30;
            this.imgPass.TabStop = false;
            this.imgPass.Visible = false;
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(138, 18);
            this.txtPassword.MaxLength = 12;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(151, 23);
            this.txtPassword.TabIndex = 26;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtRepitePassword
            // 
            // 
            // 
            // 
            this.txtRepitePassword.CustomButton.Image = null;
            this.txtRepitePassword.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtRepitePassword.CustomButton.Name = "";
            this.txtRepitePassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRepitePassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRepitePassword.CustomButton.TabIndex = 1;
            this.txtRepitePassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRepitePassword.CustomButton.UseSelectable = true;
            this.txtRepitePassword.CustomButton.Visible = false;
            this.txtRepitePassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtRepitePassword.Lines = new string[0];
            this.txtRepitePassword.Location = new System.Drawing.Point(138, 54);
            this.txtRepitePassword.MaxLength = 12;
            this.txtRepitePassword.Name = "txtRepitePassword";
            this.txtRepitePassword.PasswordChar = '*';
            this.txtRepitePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRepitePassword.SelectedText = "";
            this.txtRepitePassword.SelectionLength = 0;
            this.txtRepitePassword.SelectionStart = 0;
            this.txtRepitePassword.ShortcutsEnabled = true;
            this.txtRepitePassword.Size = new System.Drawing.Size(151, 23);
            this.txtRepitePassword.TabIndex = 28;
            this.txtRepitePassword.UseSelectable = true;
            this.txtRepitePassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRepitePassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(8, 55);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(124, 19);
            this.metroLabel4.TabIndex = 29;
            this.metroLabel4.Text = "Repetir Contraseña:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(8, 20);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(78, 19);
            this.metroLabel3.TabIndex = 27;
            this.metroLabel3.Text = "Contraseña:";
            // 
            // cbTipoUser
            // 
            this.cbTipoUser.FormattingEnabled = true;
            this.cbTipoUser.ItemHeight = 23;
            this.cbTipoUser.Location = new System.Drawing.Point(141, 86);
            this.cbTipoUser.Name = "cbTipoUser";
            this.cbTipoUser.Size = new System.Drawing.Size(151, 29);
            this.cbTipoUser.TabIndex = 17;
            this.cbTipoUser.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(11, 90);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(105, 19);
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "Tipo de Usuario:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.ImageKey = "guardar.png";
            this.btnGuardar.ImageList = this.images;
            this.btnGuardar.Location = new System.Drawing.Point(11, 280);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(124, 40);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Actualizar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "cancelar.png");
            this.images.Images.SetKeyName(1, "guardar.png");
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.CustomButton.Image = null;
            this.txtNombre.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.txtNombre.CustomButton.Name = "";
            this.txtNombre.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombre.CustomButton.TabIndex = 1;
            this.txtNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombre.CustomButton.UseSelectable = true;
            this.txtNombre.CustomButton.Visible = false;
            this.txtNombre.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNombre.Lines = new string[0];
            this.txtNombre.Location = new System.Drawing.Point(141, 12);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(202, 23);
            this.txtNombre.TabIndex = 14;
            this.txtNombre.UseSelectable = true;
            this.txtNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.CustomButton.Image = null;
            this.txtUser.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtUser.CustomButton.Name = "";
            this.txtUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUser.CustomButton.TabIndex = 1;
            this.txtUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUser.CustomButton.UseSelectable = true;
            this.txtUser.CustomButton.Visible = false;
            this.txtUser.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUser.Lines = new string[0];
            this.txtUser.Location = new System.Drawing.Point(141, 48);
            this.txtUser.MaxLength = 15;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.ShortcutsEnabled = true;
            this.txtUser.Size = new System.Drawing.Size(151, 23);
            this.txtUser.TabIndex = 15;
            this.txtUser.UseSelectable = true;
            this.txtUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(11, 51);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 19);
            this.metroLabel2.TabIndex = 18;
            this.metroLabel2.Text = "Usuario:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(11, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(62, 19);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Nombre:";
            // 
            // editarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 415);
            this.Controls.Add(this.panelUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "editarUsuario";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Modificar Usuario";
            this.Load += new System.EventHandler(this.editarUsuario_Load);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelUsuario;
        private MetroFramework.Controls.MetroComboBox cbTipoUser;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.Button btnGuardar;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroTextBox txtUser;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.Button btnContra;
        private MetroFramework.Controls.MetroPanel panelPassword;
        private System.Windows.Forms.PictureBox imgPass;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroTextBox txtRepitePassword;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}