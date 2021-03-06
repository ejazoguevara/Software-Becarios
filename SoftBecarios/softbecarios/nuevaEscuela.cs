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
using Entidades;
using Negocio;

namespace SoftBecarios
{
    public partial class nuevaEscuela : MetroForm
    {
        Escuela esc = new Escuela();
        modelo model = new modelo();
        public nuevaEscuela()
        {
            InitializeComponent();
        }

        private void txtCorto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasSignos(e.KeyChar);   
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasSignos(e.KeyChar); 
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
                if(model.guardarEscuela(esc))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Escuela guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                    this.Close();
                    Escuelas abrir = new Escuelas();
                    abrir.Show();
                }
            }
        }
    }
}
