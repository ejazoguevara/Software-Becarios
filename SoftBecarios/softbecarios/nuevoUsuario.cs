﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Entidades;
using Negocio;

namespace SoftBecarios
{
    public partial class nuevoUsuario : MetroForm
    {
        modelo model = new modelo();
        Usuario user = new Usuario();
        public nuevoUsuario()
        {
            InitializeComponent();
        }

        public Boolean validaVacios()
        {
            Boolean flag = false;
            foreach (Control x in panelUsuario.Controls)
            {
                if (x is MetroTextBox)
                {
                    if (x.Text == "")
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        private void nuevoUsuario_Load(object sender, EventArgs e)
        {
            model.comboTipoUsuario(cbTipoUser);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasynumeros(e.KeyChar);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasSignos(e.KeyChar);
        }

        private void txtRepitePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            imgPass.Visible = true;
            e.Handled = Validar.letrasSignos(e.KeyChar); 
            if (txtPassword.Text == txtRepitePassword.Text + e.KeyChar)
            {
                imgPass.Image = System.Drawing.Image.FromFile("Resources/correcto.png");
            }
            else
            {
                imgPass.Image = System.Drawing.Image.FromFile("Resources/incorrecto.png");
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validaVacios())
            {
                MetroFramework.MetroMessageBox.Show(this, "Existen campos vacios, todos son obligatorios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
            }
            else if(txtPassword.Text == txtRepitePassword.Text)
            {
                // Guardar Usuario
                user.Nombre = txtNombre.Text.Trim();
                user.User = txtUser.Text.Trim();
                user.Password = txtPassword.Text.Trim();
                user.Permisos = Convert.ToInt16(cbTipoUser.SelectedValue);
                if (model.guardarUsuario(user))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Usuario guardado corectamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                    this.Close();
                    Usuarios abrir = new Usuarios();
                    abrir.Show();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Los campos contraseña no coinciden", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
            }
        }
    }
}
