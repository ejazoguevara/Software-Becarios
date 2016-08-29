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
    public partial class Principal : MetroForm
    {
        modelo model = new modelo();
        Usuario user = new Usuario();
        public Principal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            nuevoExpediente abrir = new nuevoExpediente();
            abrir.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Acerca abrir = new Acerca();
            abrir.ShowDialog();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarExpedientes abrir = new mostrarExpedientes();
            abrir.ShowDialog();
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: { btnAyuda.PerformClick(); break; }
                case Keys.F5: { btnAgregar.PerformClick(); break; }
                case Keys.F6: { btnMostrar.PerformClick(); break; }
                case Keys.F7: { btnVacaciones.PerformClick(); break; }
                case Keys.F8: { btnCalificaciones.PerformClick(); break; }
                case Keys.F9: { btnEscuelas.PerformClick(); break; }
                case Keys.F10:{ btnUsuarios.PerformClick(); break; }
                case Keys.F12:{ btnCerrar.PerformClick(); break; }
            }
        }

        private void btnEscuelas_Click(object sender, EventArgs e)
        {
            Escuelas abrir = new Escuelas();
            abrir.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios abrir = new Usuarios();
            abrir.ShowDialog();
        }

        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            mostrarCalificaciones abrir = new mostrarCalificaciones();
            abrir.ShowDialog();
        }

        private void btnVacaciones_Click(object sender, EventArgs e)
        {
            mostrarVacaciones abrir = new mostrarVacaciones();
            abrir.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            loading();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            model.cierraSesiones();
            loading();
        }

        public void loading()
        {
            Login log = new Login();
            lblHeader.Text = "";
            log.ShowDialog();
            if (log.DialogResult == DialogResult.Cancel)
            {
                log.Close();
                Application.Exit();
            }
            else if (log.DialogResult == DialogResult.OK)
            {
                model.usuarioActivo(user);
                lblHeader.Text = "Usuario conectado: " + user.Nombre;
                if (user.Permisos != 1)
                {
                    btnAgregar.Enabled = false;
                    btnEscuelas.Enabled = false;
                    btnUsuarios.Enabled = false;
                }
                else
                {
                    btnAgregar.Enabled = true;
                    btnEscuelas.Enabled = true;
                    btnUsuarios.Enabled = true;
                }
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            model.cierraSesiones();
        }

    }
}
