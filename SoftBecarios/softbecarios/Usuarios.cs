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
    public partial class Usuarios : MetroForm
    {
        modelo model = new modelo();
        Usuario user = new Usuario();
        public Usuarios()
        {
            InitializeComponent();
        }

        public void cargarDataGrid()
        {
            gridUsuarios.Columns.Clear();
            model.cargarDataGridUsuarios(gridUsuarios);
            gridUsuarios.Columns[0].Visible = false;
            gridUsuarios.Columns[1].Width = 200;
            gridUsuarios.Columns[2].Width = 100;
            // Agregar columnas nuevas
            DataGridViewButtonColumn addcolumn = new DataGridViewButtonColumn();
            addcolumn.Name = "edit";
            addcolumn.HeaderText = "Editar";
            gridUsuarios.Columns.Add(addcolumn);
            DataGridViewButtonColumn addcolumn2 = new DataGridViewButtonColumn();
            addcolumn2.Name = "eliminar";
            addcolumn2.HeaderText = "Eliminar";
            gridUsuarios.Columns.Add(addcolumn2);
            gridUsuarios.Columns[3].Width = 50;
            gridUsuarios.Columns[4].Width = 50;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoUsuario abrir = new nuevoUsuario();
            this.Close();
            abrir.ShowDialog();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
            model.usuarioActivo(user);
        }

        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                user.ID = Convert.ToInt16(gridUsuarios.CurrentRow.Cells[0].Value);
                editarUsuario abrir = new editarUsuario(user);
                abrir.ShowDialog();
            }
            else if (e.ColumnIndex == 4)
            {
                if (Convert.ToInt16(gridUsuarios.CurrentRow.Cells[0].Value) == user.ID || Convert.ToInt16(gridUsuarios.CurrentRow.Cells[0].Value) == 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "No puedes eliminar este usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                }
                else if (MetroFramework.MetroMessageBox.Show(this, "¿Seguro que deseas eliminar a: " + gridUsuarios.CurrentRow.Cells[1].Value.ToString() + "?", "Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question,150) == DialogResult.Yes) 
                {
                    int id = Convert.ToInt16(gridUsuarios.CurrentRow.Cells[0].Value);
                    if (model.eliminaUsuario(id))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Usuario eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150);
                        cargarDataGrid();
                    }
                }
            }
        }
    }
}
