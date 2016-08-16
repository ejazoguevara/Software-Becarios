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
        Calificaciones cal = new Calificaciones();
        DateTime date = DateTime.Today;
        

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
            dtInicio.MinDate = date.AddYears(-1);
            dtInicio.MaxDate = date;
            dtVac1Inicio.MinDate = date.AddYears(-1);
            dtVac2Inicio.MinDate = date.AddYears(-1);
            dtVac1Termino.MaxDate = date.AddYears(1);
            dtVac2Termino.MaxDate = date.AddYears(1);
            model.mostrarExpediente(expe);
            combos();
            asignaValores();
            mostrarCalificacionesMIP();
            switch (Convert.ToInt16(cbTipo.SelectedValue))
            {
                case 1: { panelCalMip.Visible = false; cbTurno.Enabled = false; break; } // Residentes
                case 2: { txtCedula.Enabled = false; panelCalR1.Visible = false; cbTurno.Enabled = false; break; } // Internos
                case 3: { cbGuardia.Enabled = false; txtCedula.Enabled = false; panelCalMip.Visible = false; panelCalR1.Visible = false; break; } // Serv. Social
                case 4: { txtCedula.Enabled = false; panelVaca1.Visible = false; panelVaca2.Visible = false; panelCalMip.Visible = false; panelCalR1.Visible = false; cbTurno.Enabled = false; break; } // Estudiantes Med.
                case 5: { cbGuardia.Enabled = false; txtCedula.Enabled = false; panelVaca2.Visible = false; panelCalMip.Visible = false; panelCalR1.Visible = false; break; } // Practicas Prof.
            }
            desactivaPanelMIP();
            switch (Convert.ToInt16(cbServicio.SelectedValue))
            {
                
                case 3: { 
                    if (txtCirTotal.Text == "0") 
                    { panelCirugia.Enabled = true;
                    btnGuardaCalifica.Enabled = true;
                    } break; }
                case 5: { 
                    if (txtComTotal.Text == "0") 
                    { panelComunidad.Enabled = true;
                    btnGuardaCalifica.Enabled = true;
                    } break; }
                case 10: { 
                    if (txtGinTotal.Text == "0") 
                    { panelGineco.Enabled = true;
                    btnGuardaCalifica.Enabled = true;
                    } break; }
                case 13: { 
                    if (txtMedTotal.Text == "0") 
                    { panelMedInterna.Enabled = true;
                    btnGuardaCalifica.Enabled = true;
                    } break; }
                case 19: { 
                    if (txtPedTotal.Text == "0") 
                    { panelPediatria.Enabled = true;
                    btnGuardaCalifica.Enabled = true;
                    } break; }
                case 29: { 
                    if (txtUrgTotal.Text == "0") 
                    { panelUrgencias.Enabled = true;
                    btnGuardaCalifica.Enabled = true;
                    } break; }
                
            }
        }

        public void mostrarCalificacionesMIP()
        {
            // Calificaciones de Cirugía
            cal.ID_Alumno = expe.ID;
            cal.ID_Servicio = 3;
            if(model.existeCalificacionMIP(cal))
            {
                model.mostrarCalificacionesMIP(cal);
                txtCir1.Text = cal.Cal_Cogno.ToString();
                txtCir2.Text = cal.Cal_Psico.ToString();
                txtCir3.Text = cal.Cal_Afect.ToString();
                txtCirTotal.Text = cal.Cal_Final.ToString();
            }
            // Calificaciones de Comunidad
            cal.ID_Alumno = expe.ID;
            cal.ID_Servicio = 5;
            if (model.existeCalificacionMIP(cal))
            {
                model.mostrarCalificacionesMIP(cal);
                txtCom1.Text = cal.Cal_Cogno.ToString();
                txtCom2.Text = cal.Cal_Psico.ToString();
                txtCom3.Text = cal.Cal_Afect.ToString();
                txtComTotal.Text = cal.Cal_Final.ToString();
            }
            // Calificaciones de Ginecología
            cal.ID_Alumno = expe.ID;
            cal.ID_Servicio = 10;
            if(model.existeCalificacionMIP(cal))
            {
                 model.mostrarCalificacionesMIP(cal);
                txtGin1.Text = cal.Cal_Cogno.ToString();
                txtGin2.Text = cal.Cal_Psico.ToString();
                txtGin3.Text = cal.Cal_Afect.ToString();
                txtGinTotal.Text = cal.Cal_Final.ToString();
            }
            // Calificaciones de Medicina Interna
            cal.ID_Alumno = expe.ID;
            cal.ID_Servicio = 13;
            if (model.existeCalificacionMIP(cal))
            {
                 model.mostrarCalificacionesMIP(cal);
                txtMed1.Text = cal.Cal_Cogno.ToString();
                txtMed2.Text = cal.Cal_Psico.ToString();
                txtMed3.Text = cal.Cal_Afect.ToString();
                txtMedTotal.Text = cal.Cal_Final.ToString();
            }
            // Calificaciones de Pediatria
            cal.ID_Alumno = expe.ID;
            cal.ID_Servicio = 19;
            if (model.existeCalificacionMIP(cal))
            {
                model.mostrarCalificacionesMIP(cal);
                txtPed1.Text = cal.Cal_Cogno.ToString();
                txtPed2.Text = cal.Cal_Psico.ToString();
                txtPed3.Text = cal.Cal_Afect.ToString();
                txtPedTotal.Text = cal.Cal_Final.ToString();
            }
            // Calificaciones de Urgencias
            cal.ID_Alumno = expe.ID;
            cal.ID_Servicio = 29;
            if (model.existeCalificacionMIP(cal))
            {
                model.mostrarCalificacionesMIP(cal);
                txtUrg1.Text = cal.Cal_Cogno.ToString();
                txtUrg2.Text = cal.Cal_Psico.ToString();
                txtUrg3.Text = cal.Cal_Afect.ToString();
                txtUrgTotal.Text = cal.Cal_Final.ToString();
            }
            

        }

        // Coloca los datos correspondientes en cada campo
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

            // Tab Vacaciones
            dtVac1Inicio.Text = expe.Vac1_Inicio;
            dtVac1Termino.Text = expe.Vac1_Termino;
            dtVac2Inicio.Text = expe.Vac2_Inicio;
            dtVac2Termino.Text = expe.Vac2_Termino;

        }


        // Asigna los valores a la clase para luego actualizar los datos en la BD
        public void actualizaValores()
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

        // Asigna valores solo de Vacaciones a la clase para ser guardados en la BD
        public void asignaVacaciones()
        {
            expe.Vac1_Inicio = dtVac1Inicio.Value.ToString("yyyy-MM-dd");
            expe.Vac1_Termino = dtVac1Termino.Value.ToString("yyyy-MM-dd");
            expe.Vac2_Inicio = dtVac2Inicio.Value.ToString("yyyy-MM-dd");
            expe.Vac2_Termino = dtVac2Termino.Value.ToString("yyyy-MM-dd");
        }

        // Asigna valores solo de Calificaciones a la clase para ser guardado en la BD
        public void asignaCalificaciones()
        {
            switch (Convert.ToInt16(cbTipo.SelectedValue))
            {
                case 1:
                    {
                        
                        break;
                    }
                case 2:
                    {
                        
                        break;
                    }
            }
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

        public void desactivaPanelMIP()
        {
            foreach(Control x in panelCalMip.Controls)
            {
                if (x is MetroPanel)
                {
                    x.Enabled = false;
                }
            }
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, "La calificación no debe ser mayor a 20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }

        private void btnGuardar3_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }

        private void btnGuardar4_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }

        private void btnGuardaVaca_Click(object sender, EventArgs e)
        {
            asignaVacaciones();
            if (model.guardaVacaciones(expe))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vacaciones guardadas con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Ocurrio un error al intentar guardar, consulte al administrador", "¡Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardaCalifica_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(cbTipo.SelectedValue))
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        switch (Convert.ToInt16(cbServicio.SelectedValue))
                        {
                            case 3: {
                                if (txtCirTotal.Text == "0")
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Debe capturar la calificación para poder guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    cal.Cal_Cogno = Convert.ToInt16(txtCir1.Text);
                                    cal.Cal_Psico = Convert.ToInt16(txtCir2.Text);
                                    cal.Cal_Afect = Convert.ToInt16(txtCir3.Text);
                                    cal.Cal_Final = Convert.ToInt16(txtCirTotal.Text);
                                    expe.Promedio = Convert.ToDouble(lblCalFinalMip.Text);
                                    cal.ID_Alumno = expe.ID;
                                    cal.ID_Servicio = 3;
                                    if (model.guardaCalificacionesMIP(cal, expe))
                                    {
                                        MetroFramework.MetroMessageBox.Show(this, "Calificación guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        desactivaPanelMIP();
                                        btnGuardaCalifica.Enabled = false;
                                    }
                                } break;
                            }
                            case 5: {
                                if (txtComTotal.Text == "0")
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Debe capturar la calificación para poder guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    cal.Cal_Cogno = Convert.ToInt16(txtCom1.Text);
                                    cal.Cal_Psico = Convert.ToInt16(txtCom2.Text);
                                    cal.Cal_Afect = Convert.ToInt16(txtCom3.Text);
                                    cal.Cal_Final = Convert.ToInt16(txtComTotal.Text);
                                    expe.Promedio = Convert.ToDouble(lblCalFinalMip.Text);
                                    cal.ID_Alumno = expe.ID;
                                    cal.ID_Servicio = 5;
                                    if (model.guardaCalificacionesMIP(cal, expe))
                                    {
                                        MetroFramework.MetroMessageBox.Show(this, "Calificación guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        desactivaPanelMIP();
                                        btnGuardaCalifica.Enabled = false;
                                    }
                                } break;
                            }
                            case 10: {
                                if (txtGinTotal.Text == "0")
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Debe capturar la calificación para poder guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    cal.Cal_Cogno = Convert.ToInt16(txtGin1.Text);
                                    cal.Cal_Psico = Convert.ToInt16(txtGin2.Text);
                                    cal.Cal_Afect = Convert.ToInt16(txtGin3.Text);
                                    cal.Cal_Final = Convert.ToInt16(txtGinTotal.Text);
                                    expe.Promedio = Convert.ToDouble(lblCalFinalMip.Text);
                                    cal.ID_Alumno = expe.ID;
                                    cal.ID_Servicio = 10;
                                    if (model.guardaCalificacionesMIP(cal, expe))
                                    {
                                        MetroFramework.MetroMessageBox.Show(this, "Calificación guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        desactivaPanelMIP();
                                        btnGuardaCalifica.Enabled = false;
                                    }
                                } break;
                            }
                            case 13: {
                                if (txtMedTotal.Text == "0")
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Debe capturar la calificación para poder guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    cal.Cal_Cogno = Convert.ToInt16(txtMed1.Text);
                                    cal.Cal_Psico = Convert.ToInt16(txtMed2.Text);
                                    cal.Cal_Afect = Convert.ToInt16(txtMed3.Text);
                                    cal.Cal_Final = Convert.ToInt16(txtMedTotal.Text);
                                    expe.Promedio = Convert.ToDouble(lblCalFinalMip.Text);
                                    cal.ID_Alumno = expe.ID;
                                    cal.ID_Servicio = 13;
                                    if (model.guardaCalificacionesMIP(cal, expe))
                                    {
                                        MetroFramework.MetroMessageBox.Show(this, "Calificación guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        desactivaPanelMIP();
                                        btnGuardaCalifica.Enabled = false;
                                    }
                                } break;
                            }
                            case 19: {
                                if (txtPedTotal.Text == "0")
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Debe capturar la calificación para poder guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    cal.Cal_Cogno = Convert.ToInt16(txtPed1.Text);
                                    cal.Cal_Psico = Convert.ToInt16(txtPed2.Text);
                                    cal.Cal_Afect = Convert.ToInt16(txtPed3.Text);
                                    cal.Cal_Final = Convert.ToInt16(txtPedTotal.Text);
                                    expe.Promedio = Convert.ToDouble(lblCalFinalMip.Text);
                                    cal.ID_Alumno = expe.ID;
                                    cal.ID_Servicio = 19;
                                    if (model.guardaCalificacionesMIP(cal, expe))
                                    {
                                        MetroFramework.MetroMessageBox.Show(this, "Calificación guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        desactivaPanelMIP();
                                        btnGuardaCalifica.Enabled = false;
                                    }
                                } break;
                            }
                            case 29: {
                                if (txtUrgTotal.Text == "0")
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Debe capturar la calificación para poder guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    cal.Cal_Cogno = Convert.ToInt16(txtUrg1.Text);
                                    cal.Cal_Psico = Convert.ToInt16(txtUrg2.Text);
                                    cal.Cal_Afect = Convert.ToInt16(txtUrg3.Text);
                                    cal.Cal_Final = Convert.ToInt16(txtUrgTotal.Text);
                                    expe.Promedio = Convert.ToDouble(lblCalFinalMip.Text);
                                    cal.ID_Alumno = expe.ID;
                                    cal.ID_Servicio = 29;
                                    if (model.guardaCalificacionesMIP(cal, expe))
                                    {
                                        MetroFramework.MetroMessageBox.Show(this, "Calificación guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        desactivaPanelMIP();
                                        btnGuardaCalifica.Enabled = false;
                                    }
                                } break;
                            }
                        }
                        break;
                    }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (camposVacios())
            {
                if (validaFechas())
                {
                    if (Validar.ComprobarEmail(txtMail.Text))
                    {
                        // Vamos a actualizar los cambios y guardar vacaciones y calificaciones
                        actualizaValores();
                        if (model.actualizaExpediente(expe))
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Expediente actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Ocurrio un error al intentar guardar, consulte al administrador", "¡Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void cbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(cbTipo.SelectedValue))
            {
                case 1:
                    {
                        
                        break;
                    }
                case 2:
                    {
                        switch (Convert.ToInt16(cbServicio.SelectedValue))
                        {
                            case 3: { if (txtCirTotal.Text == "0") { desactivaPanelMIP(); panelCirugia.Enabled = true; } break; }
                            case 5: { if (txtComTotal.Text == "0") { desactivaPanelMIP(); panelComunidad.Enabled = true; } break; }
                            case 10: { if (txtGinTotal.Text == "0") { desactivaPanelMIP(); panelGineco.Enabled = true; } break; }
                            case 13: { if (txtMedTotal.Text == "0") { desactivaPanelMIP(); panelMedInterna.Enabled = true; } break; }
                            case 19: { if (txtPedTotal.Text == "0") { desactivaPanelMIP(); panelPediatria.Enabled = true; } break; }
                            case 29: { if (txtUrgTotal.Text == "0") { desactivaPanelMIP(); panelUrgencias.Enabled = true; } break; }
                        }
                        break;
                    }
            }
        }

       

       
    }
}
