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
using SCM.Globales;

namespace SCM.Cotizacion
{
    public partial class frmCotizacion_Pagar_Efectivo : Form
    {
      

        public frmCotizacion_Pagar_Efectivo()
        {
            InitializeComponent();
        }

        decimal diferencia;
        public string captura_num_cotizacion = "";
        string ruta_img_cheque, ruta_img_tranf;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tSumar_Tick(object sender, EventArgs e)
        {
            try
            {
                decimal efec;

                if (this.nudEfectivo.Text == "")
                    efec = 0;
                else
                    efec = Convert.ToDecimal(this.nudEfectivo.Text);

                decimal captar_sumatoria;
                captar_sumatoria = (efec);
                this.lblIngresado.Text = captar_sumatoria.ToString("N" + cGeneral.decimales_ventas + "");

                diferencia = Convert.ToDecimal(this.lblTotalPagar.Text) - captar_sumatoria;

                if (diferencia < 0)
                    diferencia *= -1;

                this.lblDiferencia.Text = diferencia.ToString("N" + cGeneral.decimales_ventas + "");
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

                if (this.cbEfectivo.Checked == false)
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
                }

                if (Convert.ToDecimal(this.lblIngresado.Text) < Convert.ToDecimal(this.lblTotalPagar.Text))
                {
                    this.ttMensaje.ToolTipTitle = "CORREGIR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El monto ingresado es MENOR que el total a pagar", this.btnPagar, 0, 38, 6000);

                    if (this.cbEfectivo.Checked)
                        this.nudEfectivo.Focus();

                    return;
                }

                DialogResult resul = MessageBox.Show("Desea guardar éste pago.", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    NCotizaciones.pagar(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), Convert.ToDecimal(this.nudEfectivo.Value), "", System.DateTime.Now, 0, 0, ruta_img_cheque,"",0, ruta_img_tranf);

                    DialogResult resul1 = MessageBox.Show("La cotización ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        print_venta();
                    }

                    frmCotizaciones.me.txtRegistros.Text = NCotizaciones.num_reg().ToString("N0");
                    frmCotizaciones.me.txtBuscar.Text = "";

                    if (frmCotizaciones.me.txtRegistros.Text == "0")
                        frmCotizaciones.me.txtBuscar.Enabled = false;

                    this.Close();
                }
                else if (resul == System.Windows.Forms.DialogResult.No)
                    this.Close();
                else
                    if (this.cbEfectivo.Checked)
                    this.nudEfectivo.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        public void print_venta()
        {
            try
            {
                if (frmCotizaciones.me.dgvProductos.Rows.Count > 0)
                {

                    if (cGeneral.numItem >= frmCotizaciones.me.dgvProductos.Rows.Count)
                    {
                        string numVenta = frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                        Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                        frmReporte.fecha_inicio = "";
                        frmReporte.fecha_fin = "";
                        frmReporte.desde = 1;
                        frmReporte.hasta = cGeneral.numItem;
                        frmReporte.print_pago = "SI";
                        frmReporte.num_factura = numVenta;
                        frmReporte.Show();
                    }
                    else
                    {


                        int itemRecord = 0;
                        for (int i = 0; i < 20; i++)
                        {

                            itemRecord += cGeneral.numItem;

                            string numVenta = frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                            frmReporte.fecha_inicio = "";
                            frmReporte.fecha_fin = "";
                            frmReporte.desde = itemRecord - cGeneral.numItem + 1;
                            frmReporte.hasta = itemRecord;
                            frmReporte.print_pago = "NO";
                            frmReporte.num_factura = numVenta;
                            frmReporte.Show();

                            if (itemRecord >= frmCotizaciones.me.dgvProductos.Rows.Count)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        //public void print_venta()
        //{
        //    try
        //    {
        //        if (frmCotizaciones.me.dgvProductos.Rows.Count > 0)
        //        {

        //            if (cGeneral.numItem >= frmCotizaciones.me.dgvProductos.Rows.Count)
        //            {
        //                string numVenta = Convert.ToString(frmCotizaciones.me.captar_numventa);
        //                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
        //                frmReporte.fecha_inicio = "";
        //                frmReporte.fecha_fin = "";
        //                frmReporte.desde = 1;
        //                frmReporte.hasta = cGeneral.numItem;
        //                frmReporte.print_pago = "SI";
        //                frmReporte.num_factura = numVenta;
        //                frmReporte.Show();
        //            }
        //            else
        //            {


        //                int itemRecord = 0;
        //                for (int i = 0; i < 20; i++)
        //                {

        //                    itemRecord += cGeneral.numItem;

        //                    string numVenta = Convert.ToString(frmCotizaciones.me.captar_numventa);
        //                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
        //                    frmReporte.fecha_inicio = "";
        //                    frmReporte.fecha_fin = "";
        //                    frmReporte.desde = itemRecord - cGeneral.numItem + 1;
        //                    frmReporte.hasta = itemRecord;
        //                    frmReporte.print_pago = "NO";
        //                    frmReporte.num_factura = numVenta;
        //                    frmReporte.Show();

        //                    if (itemRecord >= frmCotizaciones.me.dgvProductos.Rows.Count)
        //                    {
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}
        private void nudEfectivo_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudEfectivo);
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
        private void frmVentas_Pagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCotizaciones.me.tEnfoque.Enabled = true;
        }

        private void nudEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
            if (e.KeyCode == Keys.Enter)
            {
                btnPagar_Click(null, null);
            }
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

        private void frmVentas_Pagar_Efectivo_Load(object sender, EventArgs e)
        {
            try
            {
                this.nudEfectivo.DecimalPlaces = cGeneral.decimales_ventas;
                this.lblTotalPagar.Text = frmCotizaciones.me.lblTotalPagar.Text;
                this.lblDiferencia.Text = this.lblTotalPagar.Text;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void nudEfectivo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudMontoTransf_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }
    }
}
