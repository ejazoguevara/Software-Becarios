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
    public partial class mostrarExpedientes : MetroForm
    {
        modelo model = new modelo();
        public mostrarExpedientes()
        {
            InitializeComponent();
        }

        private void mostrarExpedientes_Load(object sender, EventArgs e)
        {
            llenaComboTipo();
        }

        public void llenaComboTipo()
        {
            model.comboTipoAlumno(cbTipo);
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
