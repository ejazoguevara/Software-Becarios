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

        private void Escuelas_Load(object sender, EventArgs e)
        {
            model.cargarDataGridEscuela(gridEscuelas);
            gridEscuelas.Columns[0].Width = 330;
        }
    }
}
