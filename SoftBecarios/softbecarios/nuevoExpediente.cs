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
using MetroFramework.Controls;
using Negocio;

namespace SoftBecarios
{
    public partial class nuevoExpediente : MetroForm
    {
        modelo model = new modelo();
        int inicial = 0;
        DateTime date = DateTime.Today;

        public nuevoExpediente()
        {
            InitializeComponent();
        }

        private void nuevoExpediente_Load(object sender, EventArgs e)
        {
            tabExpedienteNuevo.SelectTab(0);
            dtNacimiento.MaxDate = date;
            dtTermino.MinDate = date;
            dtTermino.MaxDate = date.AddYears(1);
            dtInicio.MinDate = date.AddMonths(-2);
            dtInicio.MaxDate = date;
            combos();
            contador();
        }

        public void combos()
        {
            model.comboTipoAlumno(cbTipo);
            model.comboEscuelas(cbEscuelas);
            model.comboReligion(cbReligion);
            model.comboServicios(cbServicio, 1);
            cbGenero.SelectedIndex = 0;
            cbCivil.SelectedIndex = 0;
            cbGuardia.SelectedIndex = 0;
            cbTurno.SelectedIndex = 0;
            cbTallaB.SelectedIndex = 0;
            cbTallaD.SelectedIndex = 0;
            cbTallaF.SelectedIndex = 0;
            cbTallaP.SelectedIndex = 0;
            cbTallaZ.SelectedIndex = 0;
            cbTipoSangre.SelectedIndex = 0;
            inicial = 1;
        }

        public Boolean camposVacios()
        {
            Boolean tab1 = false;
            Boolean tab3 = false;
            Boolean flag = false;
            foreach(Control x in tabPersonales.Controls)
            {
                if(x is MetroTextBox)
                {
                    if(x.Text == "")
                    {
                        tab1 = true;  
                    }
                }
            }
            foreach (Control x in tabReferencia.Controls)
            {
                if (x is MetroTextBox)
                {
                    if (x.Text == "")
                    {
                        tab3 = true;
                    }
                }
            }
            if(tab1 == true || tab3 == true )
            {
                MetroFramework.MetroMessageBox.Show(this, "Existen campos que son obligatorios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag = true;
            }
            return flag;
        }

        public Boolean validaFechas()
        {
            Boolean flag = false;
            if(date.ToShortDateString() == dtNacimiento.Value.ToShortDateString() || dtNacimiento.Value.Year > (date.Year - 18))
            {
                flag = true;
                MetroFramework.MetroMessageBox.Show(this, "La fecha de nacimiento no debe ser igual o menor de 18 años que la actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return flag;
        }

        public void contador()
        {
            lblNumero.Text = Convert.ToString(model.contadorExp());
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial == 1)
            {
                model.comboServicios(cbServicio, Convert.ToInt16(cbTipo.SelectedValue));
            }
            
        }

        private void txtAlergia_Leave(object sender, EventArgs e)
        {
            if(txtAlergia.Text == "")
            {
                txtAlergia.Text = "*****";
            }
        }

        private void txtEnferCronica_Leave(object sender, EventArgs e)
        {
            if(txtEnferCronica.Text == "")
            {
                txtEnferCronica.Text = "*****";
            }
        }

        private void txtMedCronica_Leave(object sender, EventArgs e)
        {
            if(txtMedCronica.Text == "")
            {
                txtMedCronica.Text = "*****";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(camposVacios())
            {
                if(validaFechas())
                {

                }
            }
        }

    }
}
