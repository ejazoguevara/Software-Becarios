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
                    if(Validar.ComprobarEmail(txtMail.Text))
                    {

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El correo electrónico no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtApellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtApellidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtLugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCURP_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.telefono(e.KeyChar);
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.correo(e.KeyChar);
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtColonia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtNombreReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtTelefonoReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.telefono(e.KeyChar);
        }

        private void txtAlergia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtEnferCronica_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

        private void txtMedCronica_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
        }

    }
}
