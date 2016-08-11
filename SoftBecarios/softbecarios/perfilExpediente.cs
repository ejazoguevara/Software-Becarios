using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Entidades;
using Negocio;

namespace SoftBecarios
{
    public partial class perfilExpediente : MetroForm
    {
        Expediente expe;
        modelo model = new modelo();
        DateTime date = DateTime.Today;
        int inicial = 0;

        public perfilExpediente(Expediente expe)
        {
            InitializeComponent();
            this.expe = expe;
        }

        private void perfilExpediente_Load(object sender, EventArgs e)
        {
            tabPerfilExpediente.SelectTab(0);
            dtNacimiento.MaxDate = date;
            dtTermino.MinDate = date;
            dtTermino.MaxDate = date.AddYears(1);
            dtInicio.MinDate = date.AddMonths(-2);
            dtInicio.MaxDate = date;
            dtVac1Inicio.MinDate = date.AddMonths(-1);
            dtVac2Inicio.MinDate = date.AddMonths(-1);
            dtVac1Termino.MaxDate = date.AddYears(1);
            dtVac2Termino.MaxDate = date.AddYears(1);
            model.mostrarExpediente(expe);
            combos();
            asignaValores();
            switch (Convert.ToInt16(cbTipo.SelectedValue))
            {
                case 1: { panelCalMip.Visible = false; break; }
                case 2: { txtCedula.Enabled = false; panelCalR1.Visible = false;  break; }
                case 3: { cbGuardia.Enabled = false; txtCedula.Enabled = false; panelCalMip.Visible = false; panelCalR1.Visible = false; break; }
                case 4: { txtCedula.Enabled = false; panelVaca1.Visible = false; panelVaca2.Visible = false; panelCalMip.Visible = false; panelCalR1.Visible = false; break; }
                case 5: { cbGuardia.Enabled = false; txtCedula.Enabled = false; panelVaca2.Visible = false; panelCalMip.Visible = false; panelCalR1.Visible = false; break; }
            }
        }

        public void asignaValores()
        {
            cbTipo.SelectedValue = expe.Tipo;
            txtNombre.Text = expe.Nombre;
            txtApellidoP.Text = expe.ApellidoP;
            txtApellidoM.Text = expe.ApellidoM;
            lblNumero.Text = expe.Numero.ToString();
            txtLugar.Text = expe.Lugar;
            dtNacimiento.Text = expe.Nacimiento;
            dtInicio.Text = expe.Fec_Inicio;
            dtTermino.Text = expe.Fec_Termino;
            cbGenero.SelectedItem = expe.Genero;
            txtRFC.Text = expe.RFC;
            txtCURP.Text = expe.CURP;
            txtDomicilio.Text = expe.Domicilio;
            txtColonia.Text = expe.Colonia;
            txtTelefono.Text = expe.Telefono;
            txtMail.Text = expe.Mail;
            cbCivil.SelectedItem = expe.Civil;
            cbTallaP.SelectedItem = expe.T_Pantalon.ToString();
            cbTallaF.SelectedItem = expe.T_Filipina.ToString();
            cbTallaB.SelectedItem = expe.T_Bata.ToString();
            cbTallaZ.SelectedItem = expe.T_Zapato.ToString();
            cbGuardia.SelectedItem = expe.Guardia;
            txtCedula.Text = expe.Cedula;
            cbTurno.SelectedItem = expe.Turno;
            cbServicio.SelectedValue = expe.Servicio;
            cbEscuelas.SelectedValue = expe.Escuela;
            txtNombreReferencia.Text = expe.Per_Referencia;
            txtTelefonoReferencia.Text = expe.Tel_Referencia;
            txtAlergia.Text = expe.Alergias;
            cbTipoSangre.SelectedItem = expe.Tipo_Sangre;
            txtEnferCronica.Text = expe.Enf_Cronica;
            txtMedCronica.Text = expe.Med_Cronico;

        }
        public void combos()
        {
            model.comboTipoAlumno(cbTipo);
            model.comboEscuelas(cbEscuelas);
            model.comboReligion(cbReligion);
            model.comboServicios(cbServicio, expe.Tipo); 
            cbTipo.Enabled = false;
            dtInicio.Enabled = false;
            dtTermino.Enabled = false;
            inicial = 1;
        }

        // Valida que no tenga campos vacios que son obligatorios
        public Boolean camposVacios()
        {
            Boolean tab1 = false;
            Boolean tab3 = false;
            Boolean flag = true;
            foreach (Control x in tabPersonales.Controls)
            {
                if (x is MetroTextBox)
                {
                    if (x.Text == "")
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
            if (tab1 == true || tab3 == true)
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
            if (date.ToShortDateString() == dtNacimiento.Value.ToShortDateString() || dtNacimiento.Value.Year > (date.Year - 18))
            {
                flag = false;
                MetroFramework.MetroMessageBox.Show(this, "La fecha de nacimiento no debe ser igual o menor de 18 años que la actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return flag;
        }


        private void txtCom1_TextChanged(object sender, EventArgs e)
        {
            if (txtCom1.Text != "")
            {
                txtComTotal.Text = Convert.ToString(Convert.ToInt16(txtCom1.Text) + Convert.ToInt16(txtCom2.Text) + Convert.ToInt16(txtCom3.Text));
            }
            
        }

        private void txtCom1_Leave(object sender, EventArgs e)
        {
            if (txtCom1.Text == "")
            {
                txtCom1.Text = "0";
            }
            else if (Convert.ToInt16(txtCom1.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCom1.Text = "0";
            }
        }

        private void txtCom2_TextChanged(object sender, EventArgs e)
        {
            if (txtCom2.Text != "")
            {
                txtComTotal.Text = Convert.ToString(Convert.ToInt16(txtCom1.Text) + Convert.ToInt16(txtCom2.Text) + Convert.ToInt16(txtCom3.Text));
            }
            
        }

        private void txtCom2_Leave(object sender, EventArgs e)
        {
            if (txtCom2.Text == "")
            {
                txtCom2.Text = "0";
            }
            else if (Convert.ToInt16(txtCom2.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCom2.Text = "0";
            }
        }

        private void txtCom3_TextChanged(object sender, EventArgs e)
        {
            if (txtCom3.Text != "")
            {
                txtComTotal.Text = Convert.ToString(Convert.ToInt16(txtCom1.Text) + Convert.ToInt16(txtCom2.Text) + Convert.ToInt16(txtCom3.Text));
            }
            
        }

        private void txtCom3_Leave(object sender, EventArgs e)
        {
            if (txtCom3.Text == "")
            {
                txtCom3.Text = "0";
            }
            else if (Convert.ToInt16(txtCom3.Text) > 20)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCom3.Text = "0";
            }
        }

        private void txtCom1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCom2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCom3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCir1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCir2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCir3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtGin1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtGin2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtGin3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtMed1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtMed2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtMed3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtPed1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtPed2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtPed3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtUrg1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtUrg2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtUrg3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCalRes1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCalRes2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCalRes3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCalRes4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCalRes5_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCalRes6_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Validar.soloNumeros(e.KeyChar);
        }

        private void txtCir1_Leave(object sender, EventArgs e)
        {
            if (txtCir1.Text == "")
            {
                txtCir1.Text = "0";
            }
            else if (Convert.ToInt16(txtCir1.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCir1.Text = "0";
            }
        }

        private void txtCir1_TextChanged(object sender, EventArgs e)
        {
            if (txtCir1.Text != "")
            {
                txtCirTotal.Text = Convert.ToString(Convert.ToInt16(txtCir1.Text) + Convert.ToInt16(txtCir2.Text) + Convert.ToInt16(txtCir3.Text));
            }
        }

        private void txtCir2_Leave(object sender, EventArgs e)
        {
            if (txtCir2.Text == "")
            {
                txtCir2.Text = "0";
            }
            else if (Convert.ToInt16(txtCir2.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCir2.Text = "0";
            }
        }

        private void txtCir2_TextChanged(object sender, EventArgs e)
        {
            if (txtCir2.Text != "")
            {
                txtCirTotal.Text = Convert.ToString(Convert.ToInt16(txtCir1.Text) + Convert.ToInt16(txtCir2.Text) + Convert.ToInt16(txtCir3.Text));
            }
        }

        private void txtCir3_Leave(object sender, EventArgs e)
        {
            if (txtCir3.Text == "")
            {
                txtCir3.Text = "0";
            }
            else if (Convert.ToInt16(txtCir3.Text) > 20)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCir3.Text = "0";
            }
        }

        private void txtCir3_TextChanged(object sender, EventArgs e)
        {
            if (txtCir3.Text != "")
            {
                txtCirTotal.Text = Convert.ToString(Convert.ToInt16(txtCir1.Text) + Convert.ToInt16(txtCir2.Text) + Convert.ToInt16(txtCir3.Text));
            }
        }

        private void txtGin1_Leave(object sender, EventArgs e)
        {
            if (txtGin1.Text == "")
            {
                txtGin1.Text = "0";
            }
            else if (Convert.ToInt16(txtGin1.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtGin1.Text = "0";
            }
        }

        private void txtGin1_TextChanged(object sender, EventArgs e)
        {
            if (txtGin1.Text != "")
            {
                txtGinTotal.Text = Convert.ToString(Convert.ToInt16(txtGin1.Text) + Convert.ToInt16(txtGin2.Text) + Convert.ToInt16(txtGin3.Text));
            }
        }

        private void txtGin2_Leave(object sender, EventArgs e)
        {
            if (txtGin2.Text == "")
            {
                txtGin2.Text = "0";
            }
            else if (Convert.ToInt16(txtGin2.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtGin2.Text = "0";
            }
        }

        private void txtGin2_TextChanged(object sender, EventArgs e)
        {
            if (txtGin2.Text != "")
            {
                txtGinTotal.Text = Convert.ToString(Convert.ToInt16(txtGin1.Text) + Convert.ToInt16(txtGin2.Text) + Convert.ToInt16(txtGin3.Text));
            }
        }

        private void txtGin3_Leave(object sender, EventArgs e)
        {
            if (txtGin3.Text == "")
            {
                txtGin3.Text = "0";
            }
            else if (Convert.ToInt16(txtGin3.Text) > 20)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtGin3.Text = "0";
            }
        }

        private void txtGin3_TextChanged(object sender, EventArgs e)
        {
            if (txtGin3.Text != "")
            {
                txtGinTotal.Text = Convert.ToString(Convert.ToInt16(txtGin1.Text) + Convert.ToInt16(txtGin2.Text) + Convert.ToInt16(txtGin3.Text));
            }
        }

        private void txtMed1_Leave(object sender, EventArgs e)
        {
            if (txtMed1.Text == "")
            {
                txtMed1.Text = "0";
            }
            else if (Convert.ToInt16(txtMed1.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMed1.Text = "0";
            }
        }

        private void txtMed1_TextChanged(object sender, EventArgs e)
        {
            if (txtMed1.Text != "")
            {
                txtMedTotal.Text = Convert.ToString(Convert.ToInt16(txtMed1.Text) + Convert.ToInt16(txtMed2.Text) + Convert.ToInt16(txtMed3.Text));
            }
        }

        private void txtMed2_Leave(object sender, EventArgs e)
        {
            if (txtMed2.Text == "")
            {
                txtMed2.Text = "0";
            }
            else if (Convert.ToInt16(txtMed2.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMed2.Text = "0";
            }
        }

        private void txtMed2_TextChanged(object sender, EventArgs e)
        {
            if (txtMed2.Text != "")
            {
                txtMedTotal.Text = Convert.ToString(Convert.ToInt16(txtMed1.Text) + Convert.ToInt16(txtMed2.Text) + Convert.ToInt16(txtMed3.Text));
            }
        }

        private void txtMed3_Leave(object sender, EventArgs e)
        {
            if (txtMed3.Text == "")
            {
                txtMed3.Text = "0";
            }
            else if (Convert.ToInt16(txtMed3.Text) > 20)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMed3.Text = "0";
            }
        }

        private void txtMed3_TextChanged(object sender, EventArgs e)
        {
            if (txtMed3.Text != "")
            {
                txtMedTotal.Text = Convert.ToString(Convert.ToInt16(txtMed1.Text) + Convert.ToInt16(txtMed2.Text) + Convert.ToInt16(txtMed3.Text));
            }
        }

        private void txtPed1_Leave(object sender, EventArgs e)
        {
            if (txtPed1.Text == "")
            {
                txtPed1.Text = "0";
            }
            else if (Convert.ToInt16(txtPed1.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPed1.Text = "0";
            }
        }

        private void txtPed1_TextChanged(object sender, EventArgs e)
        {
            if (txtPed1.Text != "")
            {
                txtPedTotal.Text = Convert.ToString(Convert.ToInt16(txtPed1.Text) + Convert.ToInt16(txtPed2.Text) + Convert.ToInt16(txtPed3.Text));
            }
        }

        private void txtPed2_Leave(object sender, EventArgs e)
        {
            if (txtPed2.Text == "")
            {
                txtPed2.Text = "0";
            }
            else if (Convert.ToInt16(txtPed2.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPed2.Text = "0";
            }
        }

        private void txtPed2_TextChanged(object sender, EventArgs e)
        {
            if (txtPed2.Text != "")
            {
                txtPedTotal.Text = Convert.ToString(Convert.ToInt16(txtPed1.Text) + Convert.ToInt16(txtPed2.Text) + Convert.ToInt16(txtPed3.Text));
            }
        }

        private void txtPed3_Leave(object sender, EventArgs e)
        {
            if (txtPed3.Text == "")
            {
                txtPed3.Text = "0";
            }
            else if (Convert.ToInt16(txtPed3.Text) > 20)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPed3.Text = "0";
            }
        }

        private void txtPed3_TextChanged(object sender, EventArgs e)
        {
            if (txtPed3.Text != "")
            {
                txtPedTotal.Text = Convert.ToString(Convert.ToInt16(txtPed1.Text) + Convert.ToInt16(txtPed2.Text) + Convert.ToInt16(txtPed3.Text));
            }
        }

        private void txtUrg1_Leave(object sender, EventArgs e)
        {
            if (txtUrg1.Text == "")
            {
                txtUrg1.Text = "0";
            }
            else if (Convert.ToInt16(txtUrg1.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUrg1.Text = "0";
            }
        }

        private void txtUrg1_TextChanged(object sender, EventArgs e)
        {
            if (txtUrg1.Text != "")
            {
                txtUrgTotal.Text = Convert.ToString(Convert.ToInt16(txtUrg1.Text) + Convert.ToInt16(txtUrg2.Text) + Convert.ToInt16(txtUrg3.Text));
            }
        }

        private void txtUrg2_Leave(object sender, EventArgs e)
        {
            if (txtUrg2.Text == "")
            {
                txtUrg2.Text = "0";
            }
            else if (Convert.ToInt16(txtUrg2.Text) > 40)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUrg2.Text = "0";
            }
        }

        private void txtUrg2_TextChanged(object sender, EventArgs e)
        {
            if (txtUrg2.Text != "")
            {
                txtUrgTotal.Text = Convert.ToString(Convert.ToInt16(txtUrg1.Text) + Convert.ToInt16(txtUrg2.Text) + Convert.ToInt16(txtUrg3.Text));
            }
        }

        private void txtUrg3_Leave(object sender, EventArgs e)
        {
            if (txtUrg3.Text == "")
            {
                txtUrg3.Text = "0";
            }
            else if (Convert.ToInt16(txtUrg3.Text) > 20)
            {
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUrg3.Text = "0";
            }
        }

        private void txtUrg3_TextChanged(object sender, EventArgs e)
        {
            if (txtUrg3.Text != "")
            {
                txtUrgTotal.Text = Convert.ToString(Convert.ToInt16(txtUrg1.Text) + Convert.ToInt16(txtUrg2.Text) + Convert.ToInt16(txtUrg3.Text));
            }
        }

        private void txtComTotal_TextChanged(object sender, EventArgs e)
        {
            lblCalFinalMip.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtComTotal.Text) + Convert.ToDouble(txtCirTotal.Text) + Convert.ToDouble(txtGinTotal.Text) + Convert.ToDouble(txtMedTotal.Text) + Convert.ToDouble(txtPedTotal.Text) + Convert.ToDouble(txtUrgTotal.Text)) / 6),2));
        }

        private void txtCirTotal_TextChanged(object sender, EventArgs e)
        {
            lblCalFinalMip.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtComTotal.Text) + Convert.ToDouble(txtCirTotal.Text) + Convert.ToDouble(txtGinTotal.Text) + Convert.ToDouble(txtMedTotal.Text) + Convert.ToDouble(txtPedTotal.Text) + Convert.ToDouble(txtUrgTotal.Text)) / 6), 2));
        }

        private void txtGinTotal_TextChanged(object sender, EventArgs e)
        {
            lblCalFinalMip.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtComTotal.Text) + Convert.ToDouble(txtCirTotal.Text) + Convert.ToDouble(txtGinTotal.Text) + Convert.ToDouble(txtMedTotal.Text) + Convert.ToDouble(txtPedTotal.Text) + Convert.ToDouble(txtUrgTotal.Text)) / 6), 2)); 
        }

        private void txtMedTotal_TextChanged(object sender, EventArgs e)
        {
            lblCalFinalMip.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtComTotal.Text) + Convert.ToDouble(txtCirTotal.Text) + Convert.ToDouble(txtGinTotal.Text) + Convert.ToDouble(txtMedTotal.Text) + Convert.ToDouble(txtPedTotal.Text) + Convert.ToDouble(txtUrgTotal.Text)) / 6), 2));
        }

        private void txtPedTotal_TextChanged(object sender, EventArgs e)
        {
            lblCalFinalMip.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtComTotal.Text) + Convert.ToDouble(txtCirTotal.Text) + Convert.ToDouble(txtGinTotal.Text) + Convert.ToDouble(txtMedTotal.Text) + Convert.ToDouble(txtPedTotal.Text) + Convert.ToDouble(txtUrgTotal.Text)) / 6), 2));
        }

        private void txtUrgTotal_TextChanged(object sender, EventArgs e)
        {
            lblCalFinalMip.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtComTotal.Text) + Convert.ToDouble(txtCirTotal.Text) + Convert.ToDouble(txtGinTotal.Text) + Convert.ToDouble(txtMedTotal.Text) + Convert.ToDouble(txtPedTotal.Text) + Convert.ToDouble(txtUrgTotal.Text)) / 6), 2));
        }

        private void txtCalRes1_Leave(object sender, EventArgs e)
        {
            if (txtCalRes1.Text == "")
            {
                txtCalRes1.Text = "0";
            }
            else if (Convert.ToInt16(txtCalRes1.Text) > 100)
            {
                MetroMessageBox.Show(this, "El rango de calificación es de 1 a 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCalRes1.Text = "0";
            }
        }

        private void txtCalRes2_Leave(object sender, EventArgs e)
        {
            if (txtCalRes2.Text == "")
            {
                txtCalRes2.Text = "0";
            }
            else if (Convert.ToInt16(txtCalRes2.Text) > 100)
            {
                MetroMessageBox.Show(this, "El rango de calificación es de 1 a 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCalRes2.Text = "0";
            }
        }

        private void txtCalRes3_Leave(object sender, EventArgs e)
        {
            if (txtCalRes3.Text == "")
            {
                txtCalRes3.Text = "0";
            }
            else if (Convert.ToInt16(txtCalRes3.Text) > 100)
            {
                MetroMessageBox.Show(this, "El rango de calificación es de 1 a 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCalRes3.Text = "0";
            }
        }

        private void txtCalRes4_Leave(object sender, EventArgs e)
        {
            if (txtCalRes4.Text == "")
            {
                txtCalRes4.Text = "0";
            }
            else if (Convert.ToInt16(txtCalRes4.Text) > 100)
            {
                MetroMessageBox.Show(this, "El rango de calificación es de 1 a 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCalRes4.Text = "0";
            }
        }

        private void txtCalRes5_Leave(object sender, EventArgs e)
        {
            if (txtCalRes5.Text == "")
            {
                txtCalRes5.Text = "0";
            }
            else if (Convert.ToInt16(txtCalRes5.Text) > 100)
            {
                MetroMessageBox.Show(this, "El rango de calificación es de 1 a 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCalRes5.Text = "0";
            }
        }

        private void txtCalRes6_Leave(object sender, EventArgs e)
        {
            if (txtCalRes6.Text == "")
            {
                txtCalRes6.Text = "0";
            }
            else if (Convert.ToInt16(txtCalRes6.Text) > 100)
            {
                MetroMessageBox.Show(this, "El rango de calificación es de 1 a 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCalRes6.Text = "0";
            }
        }

        private void txtCalRes1_TextChanged(object sender, EventArgs e)
        {
            if (txtCalRes1.Text != "")
            {
                lblCalFinalRes.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtCalRes1.Text) + Convert.ToDouble(txtCalRes2.Text) + Convert.ToDouble(txtCalRes3.Text) + Convert.ToDouble(txtCalRes4.Text) + Convert.ToDouble(txtCalRes5.Text) + Convert.ToDouble(txtCalRes6.Text)) / 6), 2));
            }
        }

        private void txtCalRes2_TextChanged(object sender, EventArgs e)
        {
            if (txtCalRes2.Text != "")
            {
                lblCalFinalRes.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtCalRes1.Text) + Convert.ToDouble(txtCalRes2.Text) + Convert.ToDouble(txtCalRes3.Text) + Convert.ToDouble(txtCalRes4.Text) + Convert.ToDouble(txtCalRes5.Text) + Convert.ToDouble(txtCalRes6.Text)) / 6), 2));
            }
        }

        private void txtCalRes3_TextChanged(object sender, EventArgs e)
        {
            if (txtCalRes3.Text != "")
            {
                lblCalFinalRes.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtCalRes1.Text) + Convert.ToDouble(txtCalRes2.Text) + Convert.ToDouble(txtCalRes3.Text) + Convert.ToDouble(txtCalRes4.Text) + Convert.ToDouble(txtCalRes5.Text) + Convert.ToDouble(txtCalRes6.Text)) / 6), 2));
            }
        }

        private void txtCalRes4_TextChanged(object sender, EventArgs e)
        {
            if (txtCalRes4.Text != "")
            {
                lblCalFinalRes.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtCalRes1.Text) + Convert.ToDouble(txtCalRes2.Text) + Convert.ToDouble(txtCalRes3.Text) + Convert.ToDouble(txtCalRes4.Text) + Convert.ToDouble(txtCalRes5.Text) + Convert.ToDouble(txtCalRes6.Text)) / 6), 2));
            }
        }

        private void txtCalRes5_TextChanged(object sender, EventArgs e)
        {
            if (txtCalRes5.Text != "")
            {
                lblCalFinalRes.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtCalRes1.Text) + Convert.ToDouble(txtCalRes2.Text) + Convert.ToDouble(txtCalRes3.Text) + Convert.ToDouble(txtCalRes4.Text) + Convert.ToDouble(txtCalRes5.Text) + Convert.ToDouble(txtCalRes6.Text)) / 6), 2));
            }
        }

        private void txtCalRes6_TextChanged(object sender, EventArgs e)
        {
            if (txtCalRes6.Text != "")
            {
                lblCalFinalRes.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtCalRes1.Text) + Convert.ToDouble(txtCalRes2.Text) + Convert.ToDouble(txtCalRes3.Text) + Convert.ToDouble(txtCalRes4.Text) + Convert.ToDouble(txtCalRes5.Text) + Convert.ToDouble(txtCalRes6.Text)) / 6), 2));
            }
        }

        private void txtAlergia_Leave(object sender, EventArgs e)
        {
            if (txtAlergia.Text == "")
            {
                txtAlergia.Text = "*****";
            }
        }

        private void txtEnferCronica_Leave(object sender, EventArgs e)
        {
            if (txtEnferCronica.Text == "")
            {
                txtEnferCronica.Text = "*****";
            }
        }

        private void txtMedCronica_Leave(object sender, EventArgs e)
        {
            if (txtMedCronica.Text == "")
            {
                txtMedCronica.Text = "*****";
            }
        }

       

       
    }
}
