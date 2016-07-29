using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;

namespace SoftBecarios
{
    public partial class perfilExpediente : MetroForm
    {
        public perfilExpediente()
        {
            InitializeComponent();
        }

        private void txtCom1_TextChanged(object sender, EventArgs e)
        {
            if (txtCom1.Text != "")
            {
                txtComTotal.Text = Convert.ToString(Convert.ToInt16(txtCom1.Text) + Convert.ToInt16(txtCom2.Text) + Convert.ToInt16(txtCom3.Text));
            }
            
        }

        private void txtCom2_TextChanged(object sender, EventArgs e)
        {
            if (txtCom2.Text != "")
            {
                txtComTotal.Text = Convert.ToString(Convert.ToInt16(txtCom1.Text) + Convert.ToInt16(txtCom2.Text) + Convert.ToInt16(txtCom3.Text));
            }
            
        }

        private void txtCom3_TextChanged(object sender, EventArgs e)
        {
            if (txtCom3.Text != "")
            {
                txtComTotal.Text = Convert.ToString(Convert.ToInt16(txtCom1.Text) + Convert.ToInt16(txtCom2.Text) + Convert.ToInt16(txtCom3.Text));
            }
            
        }
    }
}
