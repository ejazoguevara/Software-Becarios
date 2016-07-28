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

namespace SoftBecarios
{
    public partial class Principal : MetroForm
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            nuevoExpediente abrir = new nuevoExpediente();
            abrir.Show();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Acerca abrir = new Acerca();
            abrir.Show();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarExpedientes abrir = new mostrarExpedientes();
            abrir.Show();
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                        Acerca abrir = new Acerca();
                        abrir.Show();
                        break;
                    }
                case Keys.F5:
                    {
                        nuevoExpediente abrir = new nuevoExpediente();
                        abrir.Show();
                        break;
                    }
                case Keys.F6:
                    {
                        mostrarExpedientes abrir = new mostrarExpedientes();
                        abrir.Show();
                        break;
                    }
                case Keys.F7: { break; }
                case Keys.F8: { break; }
                case Keys.F9: { break; }
                case Keys.F10: { break; }
                case Keys.F12: { break; }
            }
        }

        private void btnEscuelas_Click(object sender, EventArgs e)
        {
            Escuelas abrir = new Escuelas();
            abrir.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios abrir = new Usuarios();
            abrir.Show();
        }

        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            perfilExpediente abrir = new perfilExpediente();
            abrir.Show();
        }

    }
}
