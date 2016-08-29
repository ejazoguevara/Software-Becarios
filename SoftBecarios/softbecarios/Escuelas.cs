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
    public partial class Escuelas : MetroForm
    {
        modelo model = new modelo();
        
        public Escuelas()
        {
            InitializeComponent();
        }

        public void cargarGrid()
        {
            model.cargarDataGridEscuela(gridEscuelas);
            gridEscuelas.Columns[0].Visible = false;
            gridEscuelas.Columns[1].Width = 330;
        }
        private void Escuelas_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevaEscuela abrir = new nuevaEscuela();
            this.Close();
            abrir.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(gridEscuelas.CurrentRow.Cells[0].Value);
                editarEscuela abrir = new editarEscuela(id);
                this.Close();
                abrir.ShowDialog();
            }catch(Exception){

            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroFramework.MetroMessageBox.Show(this, "¿Esta seguro que desea eliminar la escuela: " + gridEscuelas.CurrentRow.Cells[1].Value.ToString() + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 150) == DialogResult.Yes)
                {
                    int id = Convert.ToInt16(gridEscuelas.CurrentRow.Cells[0].Value);
                    if (model.eliminarEscuela(id))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Escuela eliminada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                        cargarGrid();
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }
    }
}
