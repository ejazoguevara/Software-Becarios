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

namespace SoftBecarios
{
    public partial class Usuarios : MetroForm
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoUsuario abrir = new nuevoUsuario();
            abrir.Show();
        }
    }
}
