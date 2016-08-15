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
    public partial class mostrarExpedientes : MetroForm
    {
        modelo model = new modelo();
        Expediente expe = new Expediente();
        int inicial = 0;
        public mostrarExpedientes()
        {
            InitializeComponent();
        }

        private void mostrarExpedientes_Load(object sender, EventArgs e)
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
            gridResultadosMostrar.Columns.Clear();
            model.llenarDataGridExpedientes(gridResultadosMostrar, Convert.ToInt16(cbTipo.SelectedValue));
            gridResultadosMostrar.Columns[0].Visible = false;
            gridResultadosMostrar.Columns[1].Width = 30;
            gridResultadosMostrar.Columns[2].Width = 290;
            gridResultadosMostrar.Columns[3].Width = 60;
            gridResultadosMostrar.Columns[4].Width = 190;
            gridResultadosMostrar.Columns[5].Width = 175;
            // Agregar columnas nuevas
            DataGridViewButtonColumn addcolumn = new DataGridViewButtonColumn();
            addcolumn.Name = "perfil";
            addcolumn.HeaderText = "Perfil";
            addcolumn.Text = "Ver";
            gridResultadosMostrar.Columns.Add(addcolumn);
            DataGridViewButtonColumn addcolumn2 = new DataGridViewButtonColumn();
            addcolumn2.Name = "eliminar";
            addcolumn2.HeaderText = "Eliminar";
            addcolumn2.Text = "B";
            gridResultadosMostrar.Columns.Add(addcolumn2);
            gridResultadosMostrar.Columns[6].Width = 50;
            gridResultadosMostrar.Columns[7].Width = 50;
            
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial == 1)
            {
                cargarDataGrid();
            }
        }

        private void gridResultadosMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                expe.ID = Convert.ToInt16(gridResultadosMostrar.Rows[e.RowIndex].Cells[0].Value);
                perfilExpediente ver = new perfilExpediente(expe);
                this.Close();
                ver.Show();
            }
        }
        
    }
}
