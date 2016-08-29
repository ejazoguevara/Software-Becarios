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
using Entidades;
using Negocio;

namespace SoftBecarios
{
    public partial class editarEscuela : MetroForm
    {
        Escuela esc = new Escuela();
        modelo model = new modelo();
        int id;
        public editarEscuela(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void editarEscuela_Load(object sender, EventArgs e)
        {
            esc.Id = id;
            model.obtenerEscuela(esc);
            txtNombre.Text = esc.Nombre;
            txtCorto.Text = esc.Corto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "" || txtCorto.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Los campos son obligatorios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                txtNombre.Focus();
            }
            else
            {
                esc.Nombre = txtNombre.Text.Trim();
                esc.Corto = txtCorto.Text.Trim();
                if(model.modificarEscuela(esc))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Escuela modificada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                    this.Close();
                    Escuelas abrir = new Escuelas();
                    abrir.Show();
                }
            }
        }
    }
}
