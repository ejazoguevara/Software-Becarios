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
    public partial class mostrarVacaciones : MetroForm
    {
        modelo model = new modelo();
        Expediente expe = new Expediente();
        int inicial = 0;

        public mostrarVacaciones()
        {
            InitializeComponent();
        }

        private void mostrarVacaciones_Load(object sender, EventArgs e)
        {
            llenaComboTipo();
            cargarDataGrid();
            inicial = 1;
        }

        public void llenaComboTipo()
        {
            model.comboTipoAlumno(cbTipo);
        }

        public void cargarDataGrid()
        {
            gridResultadosVaca.Columns.Clear();
            model.llenarDataGridVacaciones(gridResultadosVaca, Convert.ToInt16(cbTipo.SelectedValue));
            gridResultadosVaca.Columns[0].Width = 30;
            gridResultadosVaca.Columns[1].Width = 290;
            gridResultadosVaca.Columns[2].Width = 132;
            gridResultadosVaca.Columns[3].Width = 132;
            gridResultadosVaca.Columns[4].Width = 132;
            gridResultadosVaca.Columns[5].Width = 132;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial == 1)
            {
                cargarDataGrid();
            }
        }
    }
}
