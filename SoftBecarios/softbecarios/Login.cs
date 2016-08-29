using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Negocio;
using Entidades;

namespace SoftBecarios
{
    public partial class Login : MetroForm
    {
        modelo model = new modelo();
        Session log = new Session();
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            log.Usuario = txtUser.Text.Trim();
            log.Password = txtPassword.Text.Trim();
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                //DialogResult = DialogResult.OK;
                //this.Close();
                MetroFramework.MetroMessageBox.Show(this, "Falta información correspondiente", "¡Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
            else if(model.login(log))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Nombre de usuario y/o contraseña son incorrectos", "¡Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasSignos(e.KeyChar);
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasSignos(e.KeyChar);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.PerformClick();
            }
        }
    }
}
