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
using System.Collections;

namespace SoftBecarios
{
    public partial class mostrarCalificaciones : MetroForm
    {
        modelo model = new modelo();
        Expediente expe = new Expediente();
        Calificaciones cal = new Calificaciones();
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
            switch (Convert.ToInt16(cbTipo.SelectedValue))
            {
                case 1:
                    {
                        gridCalificacionesR1.Visible = true;
                        gridResultadosCalifMIP.Visible = false;
                        ArrayList list = new ArrayList();
                        list = model.obtieneIDalumnos(list, 1);
                        if (list.Count != 0)
                        {
                            gridCalificacionesR1.Rows.Add(list.Count);
                            for (int i = 0; i < list.Count; i++)
                            {
                                
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        gridResultadosCalifMIP.Visible = true;
                        gridCalificacionesR1.Visible = false;
                        ArrayList list = new ArrayList();
                        list = model.obtieneIDalumnos(list, 2);
                        if (list.Count != 0)
                        {
                            gridResultadosCalifMIP.Rows.Add(list.Count);
                            for (int i = 0; i < list.Count; i++)
                            {
                                model.obtieneCalificaciones(cal, Convert.ToInt16(list[i]), 2);
                                gridResultadosCalifMIP.Rows[i].Cells[0].Value = cal.Numero;
                                gridResultadosCalifMIP.Rows[i].Cells[1].Value = cal.Nombre;
                                gridResultadosCalifMIP.Rows[i].Cells[2].Value = cal.Califica[0];
                                gridResultadosCalifMIP.Rows[i].Cells[3].Value = cal.Califica[1];
                                gridResultadosCalifMIP.Rows[i].Cells[4].Value = cal.Califica[2];
                                gridResultadosCalifMIP.Rows[i].Cells[5].Value = cal.Califica[3];
                                gridResultadosCalifMIP.Rows[i].Cells[6].Value = cal.Califica[4];
                                gridResultadosCalifMIP.Rows[i].Cells[7].Value = cal.Califica[5];
                                gridResultadosCalifMIP.Rows[i].Cells[8].Value = cal.Promedio;
                            }
                        }
                        break;
                    }
            }
        }

        public void agregarAlumnoDataGrid()
        {
            
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
