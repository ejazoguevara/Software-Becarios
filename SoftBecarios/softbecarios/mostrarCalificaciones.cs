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
    public partial class mostrarCalificaciones : MetroForm
    {
        modelo model = new modelo();
        Expediente expe = new Expediente();
        int inicial = 0;

        public mostrarCalificaciones()
        {
            InitializeComponent();
        }

        private void mostrarCalificaciones_Load(object sender, EventArgs e)
        {
            llenaComboTipo();
            cargarDataGrid();
            inicial = 1;

        }

        public void llenaComboTipo()
        {
            model.comboTipoAlumnoCalif(cbTipo);
        }

        public void cargarDataGrid()
        {

        }
    }
}
