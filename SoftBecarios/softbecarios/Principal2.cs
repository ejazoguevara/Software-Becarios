using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftBecarios
{
    public partial class Principal2 : Form
    {
        public Principal2()
        {
            InitializeComponent();
        }

        private void toolStripButton1_MouseEnter(object sender, EventArgs e)
        {
            xMenu.Image = new System.Drawing.Bitmap(@"menu\menu2.png");
        }

        private void xMenu_MouseLeave(object sender, EventArgs e)
        {
            xMenu.Image = new System.Drawing.Bitmap(@"menu\menu.png");
        }
    }
}
