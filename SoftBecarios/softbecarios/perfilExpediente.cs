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
using Entidades;
using Negocio;

namespace SoftBecarios
{
    public partial class perfilExpediente : MetroForm
    {
        Expediente expe;
        modelo model = new modelo();
        public perfilExpediente(Expediente expe)
        {
            InitializeComponent();
            this.expe = expe;
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

        private void perfilExpediente_Load(object sender, EventArgs e)
        {
            model.mostrarExpediente(expe);
            MetroFramework.MetroMessageBox.Show(this, Convert.ToString(expe.Numero));
        }

       
    }
}
