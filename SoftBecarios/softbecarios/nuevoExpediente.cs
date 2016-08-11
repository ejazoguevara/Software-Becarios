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
using Entidades;

namespace SoftBecarios
{
    public partial class nuevoExpediente : MetroForm
    {
        modelo model = new modelo();
        Expediente expe = new Expediente();
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

        // Llena los combos de la base de datos y otros los inicia con un valor
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
            cbTallaF.SelectedIndex = 0;
            cbTallaP.SelectedIndex = 0;
            cbTallaZ.SelectedIndex = 0;
            cbTipoSangre.SelectedIndex = 0;
            inicial = 1;
        }

        // Limpia los campos para un nuevo expediente
        public void limpiar()
        {
            foreach (Control x in tabPersonales.Controls)
            {
                if (x is MetroTextBox)
                {
                    x.Text = "";
                }
            }
            foreach (Control x in tabReferencia.Controls)
            {
                if (x is MetroTextBox)
                {
                    x.Text = "";
                }
            }
            foreach (Control x in tabMedicos.Controls)
            {
                if (x is MetroTextBox)
                {
                    x.Text = "*****";
                }
            }
            txtCedula.Text = "S/N";
            dtNacimiento.Value = date;
            dtInicio.Value = date;
            dtTermino.Value = date;
            cbGenero.SelectedIndex = 0;
            cbCivil.SelectedIndex = 0;
            cbGuardia.SelectedIndex = 0;
            cbTurno.SelectedIndex = 0;
            cbTallaB.SelectedIndex = 0;
            cbTallaF.SelectedIndex = 0;
            cbTallaP.SelectedIndex = 0;
            cbTallaZ.SelectedIndex = 0;
            cbTipoSangre.SelectedIndex = 0;
            cbEscuelas.SelectedIndex = 0;
            cbReligion.SelectedIndex = 0;
            cbServicio.SelectedIndex = 0;
            cbTipoSangre.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
        }

        // Valida que no tenga campos vacios que son obligatorios
        public Boolean camposVacios()
        {
            Boolean tab1 = false;
            Boolean tab3 = false;
            Boolean flag = true;
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
                flag = false;
            }
            return flag;
        }

        // Valida las fechas
        public Boolean validaFechas()
        {
            Boolean flag = true;
            if(date.ToShortDateString() == dtNacimiento.Value.ToShortDateString() || dtNacimiento.Value.Year > (date.Year - 18))
            {
                flag = false;
                MetroFramework.MetroMessageBox.Show(this, "La fecha de nacimiento no debe ser igual o menor de 18 años que la actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return flag;
        }

        // Obtiene el número del siguiente alumno
        public void contador()
        {
            lblNumero.Text = Convert.ToString(model.contadorExp());
        }

        // Asigna valores a la clase Expedientes
        public void asignarValores()
        {
            
            expe.Nombre = txtNombre.Text.Trim();
            expe.ApellidoP = txtApellidoP.Text.Trim();
            expe.ApellidoM = txtApellidoM.Text.Trim();
            expe.RFC = txtRFC.Text.Trim();
            expe.CURP = txtCURP.Text.Trim();
            expe.Domicilio = txtDomicilio.Text.Trim();
            expe.Colonia = txtColonia.Text.Trim();
            expe.Lugar = txtLugar.Text.Trim();
            expe.Telefono = txtTelefono.Text.Trim();
            expe.Mail = txtMail.Text.Trim();
            expe.Cedula = txtCedula.Text.Trim();
            expe.Per_Referencia = txtNombreReferencia.Text.Trim();
            expe.Tel_Referencia = txtTelefonoReferencia.Text.Trim();
            expe.Alergias = txtAlergia.Text.Trim();
            expe.Enf_Cronica = txtEnferCronica.Text.Trim();
            expe.Med_Cronico = txtMedCronica.Text.Trim();
            expe.Genero = Convert.ToString(cbGenero.SelectedItem);
            expe.Guardia = Convert.ToString(cbGuardia.SelectedItem);
            expe.Civil = Convert.ToString(cbCivil.SelectedItem);
            expe.Turno = Convert.ToString(cbTurno.SelectedItem);
            expe.Tipo_Sangre = Convert.ToString(cbTipoSangre.SelectedItem);
            expe.Nacimiento = dtNacimiento.Value.ToString("yyyy-MM-dd");
            expe.Fec_Inicio = dtInicio.Value.ToString("yyyy-MM-dd");
            expe.Fec_Termino = dtTermino.Value.ToString("yyyy-MM-dd");
            expe.Tipo = Convert.ToInt16(cbTipo.SelectedValue);
            expe.Numero = Convert.ToInt16(lblNumero.Text.Trim());
            expe.Servicio = Convert.ToInt16(cbServicio.SelectedValue);
            expe.Escuela = Convert.ToInt16(cbEscuelas.SelectedValue);
            expe.Religion = Convert.ToInt16(cbReligion.SelectedValue);     
            expe.T_Bata = Convert.ToInt16(cbTallaB.SelectedItem);
            expe.T_Filipina = Convert.ToInt16(cbTallaF.SelectedItem);
            expe.T_Pantalon = Convert.ToInt16(cbTallaP.SelectedItem);
            expe.T_Zapato = Convert.ToDouble(cbTallaZ.SelectedItem);
            
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial == 1)
            {
                model.comboServicios(cbServicio, Convert.ToInt16(cbTipo.SelectedValue));
                int op = Convert.ToInt16(cbTipo.SelectedValue);
                switch (op)
                {
                    case 1: {cbGuardia.Enabled = true; txtCedula.Enabled = true; break;}
                    case 2: { cbGuardia.Enabled = true; txtCedula.Enabled = false; break; }
                    case 3: { cbGuardia.Enabled = false; txtCedula.Enabled = false; break; }
                    case 4: { cbGuardia.Enabled = false; txtCedula.Enabled = false; break; }
                    case 5: { cbGuardia.Enabled = false; txtCedula.Enabled = false; break; }
                }
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
                        asignarValores();
                        if (model.guardarExpediente(expe))
                        {
                            limpiar();
                            MetroFramework.MetroMessageBox.Show(this, "Expediente guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            contador();
                            tabExpedienteNuevo.SelectTab(0);
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Ocurrio un error al tratar de guardar", "¡Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El correo electrónico no es válido", "¡Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            e.Handled = Validar.letrasynumeros(e.KeyChar);
        }

        private void txtCURP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.letrasynumeros(e.KeyChar);
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
            e.Handled = Validar.letrasSignos(e.KeyChar);
        }

        private void txtColonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validar.soloLetras(e.KeyChar);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            if(txtCedula.Text == "")
            {
                txtCedula.Text = "S/N";
            }
        }

    }
}
