using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney
{
    public partial class frmRecuperar_Pagar : Form
    {
        public frmRecuperar_Pagar()
        {
            InitializeComponent();
        }

        decimal diferencia;
        public string ruta_img_cheque, ruta_img_tranf;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCuentasPorPagar_Abonar_Load(object sender, EventArgs e)
        {
            try
            {
                this.nudEfectivo.DecimalPlaces = cGeneral.decimales;
                this.nudMontoCheque.DecimalPlaces = cGeneral.decimales;
                this.nudMontoTransf.DecimalPlaces = cGeneral.decimales;

                this.dtpFechaCobro.Value = DateTime.Now.Date;
                this.lblTotalPagar.Text = frmRecuperar.me.lblTotalPagar.Text;
                this.lblDiferencia.Text = this.lblTotalPagar.Text;

                this.cmbBanco.DataSource = NBancos.cargar_cmb();
                this.cmbBanco.DisplayMember = "Banco";
                this.cmbBanco.ValueMember = "Id";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbEfectivo.Checked)
                {
                    this.pEfectivo.Enabled = true;
                    this.nudEfectivo.Focus();
                }
                else
                {
                    this.nudEfectivo.Value = 0;
                    this.nudEfectivo.Text = this.nudEfectivo.Value.ToString();
                    this.pEfectivo.Enabled = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudEfectivo_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudEfectivo);
        }

        private void cbCheque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbCheque.Checked)
                {
                    this.pCheque.Enabled = true;
                    this.txtCheque.Focus();
                }
                else
                {
                    this.txtCheque.Text = "";
                    this.dtpFechaCobro.Value = DateTime.Now.Date;

                    if (this.cmbBanco.Items.Count > 0)
                        this.cmbBanco.SelectedIndex = 0;

                    this.nudMontoCheque.Value = 0;
                    this.nudMontoCheque.Text = this.nudMontoCheque.Value.ToString();
                    this.pCheque.Enabled = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbTransf_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbTransf.Checked)
                {
                    this.pTransf.Enabled = true;
                    this.txtNumTransf.Focus();
                }
                else
                {
                    this.txtNumTransf.Text = "";
                    this.nudMontoTransf.Value = 0;
                    this.nudMontoTransf.Text = this.nudMontoTransf.Value.ToString();
                    this.pTransf.Enabled = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbImagenCheque_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "IMÁGENES JPG|*.JPG";
                openFileDialog1.Title = "SELECCIONE LA FOTO DEL CHEQUE";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta_img_cheque = openFileDialog1.FileName;
                    this.pbFoto.ImageLocation = openFileDialog1.FileName;
                    this.pbEliminarCheque.Visible = true;
                    this.pbVerCheque.Visible = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbVerCheque_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.pbVerCheque);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Ver la foto", this.pbVerCheque, 0, 38);

                this.tMostrarImagen.Enabled = true;
                this.pbFoto.ImageLocation = null;
                this.pbFoto.ImageLocation = ruta_img_cheque;
                this.pContenedorFoto.Location = new Point(296, 12);
                this.pContenedorFoto.Visible = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbVerCheque_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbVerCheque);
            
            this.tMostrarImagen.Enabled = false;
            this.pContenedorFoto.Visible = false;
        }

        private void pbVerTransf_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.pbVerTransf);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Ver la foto", this.pbVerTransf, 0, 38);

                this.tMostrarImagen.Enabled = true;
                this.pbFoto.ImageLocation = null;
                this.pbFoto.ImageLocation = ruta_img_tranf;
                this.pContenedorFoto.Location = new Point(296, 143);
                this.pContenedorFoto.Visible = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbVerTransf_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbVerTransf);

            this.tMostrarImagen.Enabled = false;
            this.pContenedorFoto.Visible = false;
        }

        private void pbImagenTransf_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "IMÁGENES JPG|*.JPG";
                openFileDialog1.Title = "SELECCIONE LA FOTO DE DEPÓSITO/TRANSFERENCIA";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta_img_tranf = openFileDialog1.FileName;
                    this.pbFoto.ImageLocation = openFileDialog1.FileName;
                    this.pbEliminarTransf.Visible = true;
                    this.pbVerTransf.Visible = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tSumar_Tick(object sender, EventArgs e)
        {
            try
            {
                decimal efec, cheq, tran;

                if (this.nudEfectivo.Text == "")
                    efec = 0;
                else
                    efec = Convert.ToDecimal(this.nudEfectivo.Text);

                if (this.nudMontoCheque.Text == "")
                    cheq = 0;
                else
                    cheq = Convert.ToDecimal(this.nudMontoCheque.Text);

                if (this.nudMontoTransf.Text == "")
                    tran = 0;
                else
                    tran = Convert.ToDecimal(this.nudMontoTransf.Text);

                decimal captar_sumatoria;
                captar_sumatoria = (efec + cheq) + tran;
                this.lblIngresado.Text = captar_sumatoria.ToString("N" + cGeneral.decimales + "");

                diferencia = Convert.ToDecimal(this.lblTotalPagar.Text) - captar_sumatoria;

                if (diferencia < 0)
                    diferencia *= -1;

                this.lblDiferencia.Text = diferencia.ToString("N" + cGeneral.decimales + "");
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnPagar);

                if (this.nudEfectivo.Text == "")
                    this.nudEfectivo.Value = 0;
                else
                    this.nudEfectivo.Value = Convert.ToDecimal(this.nudEfectivo.Text);

                if (this.nudMontoCheque.Text == "")
                    this.nudMontoCheque.Value = 0;
                else
                    this.nudMontoCheque.Value = Convert.ToDecimal(this.nudMontoCheque.Text);

                if (this.nudMontoTransf.Text == "")
                    this.nudMontoTransf.Value = 0;
                else
                    this.nudMontoTransf.Value = Convert.ToDecimal(this.nudMontoTransf.Text);

                if (this.cbEfectivo.Checked == false && this.cbCheque.Checked == false && this.cbTransf.Checked == false)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Elija el tipo de pago", this.btnPagar, 0, 38, 3000);
                    return;
                }
                else
                {
                    if (this.cbEfectivo.Checked)
                    {
                        if (Convert.ToDecimal(this.nudEfectivo.Value) == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Especifique el monto en efectivo", this.btnPagar, 0, 38, 3000);
                            this.nudEfectivo.Focus();
                            return;
                        }
                    }
                    
                    if (this.cbCheque.Checked)
                    {
                        if (this.txtCheque.Text == "")
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ingrese el número de cheque", this.btnPagar, 0, 38, 3000);
                            this.txtCheque.Focus();
                            return;
                        }
                        else if (this.cmbBanco.Items.Count == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "CORREGIR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("La lista de bancos está vacía", this.btnPagar, 0, 38, 3000);
                            this.cmbBanco.Focus();
                            this.cmbBanco.DroppedDown = true;
                            return;
                        }
                        else if (Convert.ToDecimal(this.nudMontoCheque.Value) == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ingrese el monto del cheque", this.btnPagar, 0, 38, 3000);
                            this.nudMontoCheque.Focus();
                            return;
                        }
                    }
                    
                    if (this.cbTransf.Checked)
                    {
                        if (this.txtNumTransf.Text == "")
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ingrese el número de depós./transf.", this.btnPagar, 0, 38, 4000);
                            this.txtNumTransf.Focus();
                            return;
                        }
                        else if (Convert.ToDecimal(this.nudMontoTransf.Value) == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ingrese el monto del depós./transf.", this.btnPagar, 0, 38, 3000);
                            this.nudMontoTransf.Focus();
                            return;
                        }
                    }                    
                }

                if (Convert.ToDecimal(this.lblIngresado.Text) < Convert.ToDecimal(this.lblTotalPagar.Text))
                {
                    this.ttMensaje.ToolTipTitle = "CORREGIR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El monto ingresado es MENOR que el total a pagar", this.btnPagar, 0, 38, 6000);

                    if (this.cbEfectivo.Checked)
                        this.nudEfectivo.Focus();
                    else if (this.cbCheque.Checked)
                        this.txtCheque.Focus();
                    else
                        this.txtNumTransf.Focus();

                    return;
                }

                NRecuperar.modificar_pagar(frmRecuperar.me.captar_numventa, Convert.ToDecimal(this.nudEfectivo.Value), this.txtCheque.Text, this.dtpFechaCobro.Value, Convert.ToInt32(this.cmbBanco.SelectedValue), Convert.ToDecimal(this.nudMontoCheque.Value), ruta_img_cheque, this.txtNumTransf.Text, Convert.ToDecimal(this.nudMontoTransf.Value), ruta_img_tranf);
                frmRecuperar.me.txtBuscar.Text = "";

                frmRecuperar.me.dgvProductos.DataSource = NVentas.cargar_prod(frmRecuperar.me.captar_numventa);
                frmRecuperar.me.orden_prod(frmRecuperar.me.dgvProductos);

                frmRecuperar.me.btnAgregarProd.Enabled = false;
                frmRecuperar.me.btnModificarProd.Enabled = false;
                frmRecuperar.me.btnEliminarProd.Enabled = false;
                frmRecuperar.me.btnGuardar.Enabled = false;
                frmRecuperar.me.captar_numventa = 0;
                frmRecuperar.me.captar_id_cliente = 0;
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbBanco_DropDownClosed(object sender, EventArgs e)
        {
            this.nudMontoCheque.Focus();
        }

        private void nudEfectivo_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudEfectivo);
        }

        private void nudMontoCheque_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudMontoCheque);
        }

        private void nudMontoCheque_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudMontoCheque);
        }

        private void nudMontoTransf_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudMontoTransf);
        }

        private void nudMontoTransf_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudMontoTransf);
        }

        private void nudEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudMontoCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudMontoTransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void pbEliminarCheque_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea quitar la foto del cheque.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.nudMontoCheque.Focus();
                    return;
                }

                ruta_img_cheque = "";
                this.pbFoto.ImageLocation = null;
                this.pbEliminarCheque.Visible = false;
                this.pbVerCheque.Visible = false;
                this.nudMontoCheque.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbEliminarTransf_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea quitar la foto del depósito/transferencia.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.nudMontoTransf.Focus();
                    return;
                }

                ruta_img_tranf = "";
                this.pbFoto.ImageLocation = null;
                this.pbEliminarTransf.Visible = false;
                this.pbVerTransf.Visible = false;
                this.nudMontoTransf.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbImagenCheque_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbImagenCheque);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Seleccionar la foto", this.pbImagenCheque, 0, 38);
        }

        private void pbImagenCheque_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbImagenCheque);
        }

        private void pbEliminarCheque_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbEliminarCheque);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Quitar la foto", this.pbEliminarCheque, 0, 38);
        }

        private void pbEliminarCheque_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbEliminarCheque);
        }

        private void pbEliminarTransf_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbEliminarTransf);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Quitar la foto", this.pbEliminarTransf, 0, 38);
        }

        private void pbEliminarTransf_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbEliminarTransf);
        }

        private void pbImagenTransf_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbImagenTransf);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Seleccionar la foto", this.pbImagenTransf, 0, 38);
        }

        private void pbImagenTransf_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbImagenTransf);
        }

        private void frmVentas_Pagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRecuperar.me.tEnfoque.Enabled = true;
        }

        private void nudEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void dtpFechaCobro_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudMontoCheque_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void txtNumTransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void nudMontoTransf_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }
    }
}
