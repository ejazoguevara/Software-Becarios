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

namespace SoftBecarios
{
    public partial class nuevoExpediente : MetroForm
    {
        modelo model = new modelo();
        int inicial = 0;
        public nuevoExpediente()
        {
            InitializeComponent();
        }

        private void nuevoExpediente_Load(object sender, EventArgs e)
        {
            combos();
        }

        public void combos()
        {
            model.comboTipoAlumno(cbTipo);
            model.comboEscuelas(cbEscuelas);
            model.comboReligion(cbReligion);
            model.comboServicios(cbServicio, 1);
            cbGenero.SelectedIndex = 0;
            cbCivil.SelectedIndex = 0;
            cbGuardia.SelectedIndex = 0;
            inicial = 1;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial == 1)
            {
                model.comboServicios(cbServicio, Convert.ToInt16(cbTipo.SelectedValue));
            }
            
        }

    }
}
