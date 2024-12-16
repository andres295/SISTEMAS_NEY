using CapaNegocios;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
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

namespace wfaFarmacia_Ney.Caja
{
    public partial class frmCierreCajaResumen : Form
    {
        int id_apertura_caja = 0,id_cierre_caja=0;
        bool new_egreso = false;
        decimal nudMontoApertura = 0, nudMontoSistema=0, nudMontoTotalCierre=0, nudMontoTotalUsuario=0, nudMontoEgresos=0, nudMontoFaltante=0, nudMontoSobrante=0;
        string lblUsuario = "";
        public frmCierreCajaResumen()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
           //// frmCargoAjuste.me.tEnfoque.Enabled = true;
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpFechaDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtObserv_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

    

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void calcular_totales()
        {
            try
            {
                decimal totalCierre = 0,totalDenominacion=0,totalDiferencia=0,totalsobrante=0,otroPagosTC =0;
                sumar_denominacion();

                totalCierre = (nudMontoSistema + /*nudMontoIngresos.Value*/0 + nudMontoApertura) - nudMontoEgresos;
                totalDenominacion = (nudMontoTotalEfectivoMoneda.Value + nudMontoTotalEfectivoBillete.Value);
                otroPagosTC = getTotalesOtrosPagos();
                totalDiferencia = (totalCierre - totalDenominacion) - otroPagosTC;
               
                nudMontoTotalCierre =    Convert.ToDecimal( totalCierre.ToString("N" + cGeneral.decimales_ventas + "")); 
                nudMontoTotalUsuario = Convert.ToDecimal(totalDenominacion.ToString("N" + cGeneral.decimales_ventas + ""));
                if (totalDiferencia>0)
                {
                    nudMontoFaltante = Convert.ToDecimal(totalDiferencia.ToString("N" + cGeneral.decimales_ventas + ""));
                }
                else{
                    nudMontoFaltante = 0;
                }

                try
                {
                    totalsobrante = (nudMontoTotalUsuario + otroPagosTC) - nudMontoTotalCierre;
                    nudMontoSobrante = totalsobrante;
                    if (nudMontoSobrante<=0)
                    {
                        nudMontoSobrante = 0;
                    }
                }
                catch (Exception)
                {
                    nudMontoSobrante = 0;
                } 
            }
            catch (Exception)  {  }
        }
        private void sumar_denominacion()
        {
            try
            {
                decimal denominacion_moneda = 0;

                denominacion_moneda = (nudMontoEfectivoMoneda1.Value + nudMontoEfectivoMoneda2.Value + nudMontoEfectivoMoneda3.Value + nudMontoEfectivoMoneda4.Value + nudMontoEfectivoMoneda5.Value + nudMontoEfectivoMoneda6.Value);

                ///MessageBox.Show(denominacion_moneda.ToString());
                nudMontoTotalEfectivoMoneda.Value = denominacion_moneda;
            }
            catch (Exception)
            {
                nudMontoTotalEfectivoMoneda.Value = 0;
            }
            try
            {
                decimal denominacion_billete = 0;

                denominacion_billete = (nudMontoEfectivoBillete1.Value + nudMontoEfectivoBillete2.Value + nudMontoEfectivoBillete3.Value + nudMontoEfectivoBillete4.Value + nudMontoEfectivoBillete5.Value + nudMontoEfectivoBillete6.Value + nudMontoEfectivoBillete7.Value);
             
                nudMontoTotalEfectivoBillete.Value = denominacion_billete;
            }
            catch (Exception)
            {
                nudMontoTotalEfectivoBillete.Value = 0;
            }
        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            ///nudMontoApertura.Select(0, 99);
            ///nudMontoApertura.Focus();

            ///decimal monto_apertura_caja = NCaja.verificar_si_existe(cGeneral.id_user_actual);

            DataTable dtCirre = new DataTable();
            dtCirre = NCaja.obtener_cierre_caja(cGeneral.id_user_actual);
            if (dtCirre.Rows.Count > 0)
            {
                ///Id Apertura Caja
                id_apertura_caja = int.Parse(dtCirre.Rows[0]["Id_Apertura_Caja"].ToString());
                id_cierre_caja = int.Parse(dtCirre.Rows[0]["Id"].ToString());

                nudMontoEgresos = NCaja.obtener_monto_egresos(id_apertura_caja, cGeneral.id_user_actual);

                ///Monto Cabezara
                nudMontoApertura =  decimal.Parse( dtCirre.Rows[0]["MontoApertura"].ToString());
                nudMontoSistema = decimal.Parse(dtCirre.Rows[0]["MontoSistema"].ToString());
                //nudMontoIngresos.Value = decimal.Parse(dtCirre.Rows[0]["MontoIngresos"].ToString());
                nudMontoEgresos = decimal.Parse(dtCirre.Rows[0]["MontoEgresos"].ToString());
                nudMontoTotalCierre = decimal.Parse(dtCirre.Rows[0]["MontoTotalCierre"].ToString());
                nudMontoFaltante = decimal.Parse(dtCirre.Rows[0]["MontoFaltante"].ToString());
                nudMontoFaltante = decimal.Parse(dtCirre.Rows[0]["MontoFaltante"].ToString());

                ///Cantidad Moneda Cabezara
                nudCantidadEfectivoMoneda1.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoMoneda1"].ToString());
                nudCantidadEfectivoMoneda2.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoMoneda2"].ToString());
                nudCantidadEfectivoMoneda3.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoMoneda3"].ToString());
                nudCantidadEfectivoMoneda4.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoMoneda4"].ToString());
                nudCantidadEfectivoMoneda5.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoMoneda5"].ToString());
                nudCantidadEfectivoMoneda6.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoMoneda6"].ToString());

                ///Cantidad Billete 
                nudCantidadEfectivoBillete1.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete1"].ToString());
                nudCantidadEfectivoBillete2.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete2"].ToString());
                nudCantidadEfectivoBillete3.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete3"].ToString());
                nudCantidadEfectivoBillete4.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete4"].ToString());
                nudCantidadEfectivoBillete5.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete5"].ToString());
                nudCantidadEfectivoBillete6.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete6"].ToString());
                nudCantidadEfectivoBillete7.Value = int.Parse(dtCirre.Rows[0]["CantidadEfectivoBillete7"].ToString());


                ///Monto Footer
                nudMontoTotalEfectivoMoneda.Value = decimal.Parse(dtCirre.Rows[0]["MontoTotalEfectivoMoneda"].ToString());
                nudMontoTotalEfectivoBillete.Value = decimal.Parse(dtCirre.Rows[0]["MontoTotalEfectivoBillete"].ToString());
                nudMontoTotalUsuario = decimal.Parse(dtCirre.Rows[0]["MontoTotalUsuario"].ToString()); 
 
                DataTable dt = NCaja.obtener_egreso_caja(id_apertura_caja);
                bsMultiPago.DataSource = dt;
                ///nvEgresos.BindingSource = bsEgresos;
                ///uGridEgresos.DataSource = bsEgresos;
                ///sumar_egresos();
                btnGuardar.Enabled = false;
                ///nvEgresos.Enabled = false;
                btnExportarCtaProveedorProducto.Enabled = true;
                ///nudMontoIngresos.Enabled = false;

            }
            else
            {
                id_apertura_caja = NCaja.obtener_id_caja(cGeneral.id_user_actual);
                if (id_apertura_caja > 0)
                {
                    nudMontoEgresos = NCaja.obtener_monto_egresos(id_apertura_caja, cGeneral.id_user_actual);

                    nudMontoApertura = NCaja.verificar_si_existe(cGeneral.id_user_actual);
                    nudMontoSistema = NVentas.obtener_monto_venta_cierre(cGeneral.id_user_actual);
                    ///nudMontoApertura.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnExportarCtaProveedorProducto.Enabled = false;
                    lblUsuario = cGeneral.name_user;
                    //txtMensaje.Text = "Ya se encuentra aperturada la caja para este día.";
                    //txtMensaje.Visible = true;
                    //txtMensaje.Enabled = false;
                    ///id_apertura_caja =   NCaja.obtener_id_caja(cGeneral.id_user_actual);
                    DataTable dt = NCaja.obtener_egreso_caja(id_apertura_caja);
                    bsMultiPago.DataSource = dt;
                    //nvEgresos.BindingSource = bsEgresos;
                   // uGridEgresos.DataSource = bsEgresos;
                    ///sumar_egresos();
                   /// obtener_egresos();
                    calcular_totales();
                }
                else
                {
                    btnGuardar.Enabled = false;
                    btnExportarCtaProveedorProducto.Enabled = false;
                   //// nvEgresos.Enabled = false;
                }
            }
            cargarMultiPago(id_apertura_caja);
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de cerrar la caja del día: " + System.DateTime.Now.ToShortDateString(), cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                { 
                    return;
                }
                ActualizarMontos();
                NCaja.cierre_caja(cGeneral.id_user_actual, id_apertura_caja,nudMontoApertura,nudMontoSistema,0,nudMontoEgresos,nudMontoTotalCierre,nudMontoFaltante,int.Parse(nudCantidadEfectivoMoneda1.Value.ToString()), int.Parse(nudCantidadEfectivoMoneda2.Value.ToString()), int.Parse(nudCantidadEfectivoMoneda3.Value.ToString()), int.Parse(nudCantidadEfectivoMoneda4.Value.ToString()), int.Parse(nudCantidadEfectivoMoneda5.Value.ToString()), int.Parse(nudCantidadEfectivoMoneda6.Value.ToString()), int.Parse(nudCantidadEfectivoBillete1.Value.ToString()), int.Parse(nudCantidadEfectivoBillete2.Value.ToString()), int.Parse(nudCantidadEfectivoBillete3.Value.ToString()), int.Parse(nudCantidadEfectivoBillete4.Value.ToString()), int.Parse(nudCantidadEfectivoBillete5.Value.ToString()), int.Parse(nudCantidadEfectivoBillete6.Value.ToString()), int.Parse(nudCantidadEfectivoBillete7.Value.ToString()),nudMontoTotalEfectivoMoneda.Value,nudMontoTotalEfectivoBillete.Value,nudMontoTotalUsuario,nudMontoSobrante);
               
                DialogResult resul1 = MessageBox.Show("Caja se ha cerrado con éxito!\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                cGeneral.cierre_caja = true;
                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                { 
                    DataTable dtCirre = new DataTable();
                    dtCirre = NCaja.obtener_cierre_caja(cGeneral.id_user_actual);
                    if (dtCirre.Rows.Count > 0)
                    { 
                        id_cierre_caja = int.Parse(dtCirre.Rows[0]["Id"].ToString());
                    }
                    if (id_cierre_caja > 0)
                    {
                        System.Threading.Tasks.Task.Run(() => { print_recibo(id_cierre_caja); });
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un ID de cierre de caja para imprimir! ", "Imprimir cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else { this.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible aperturar la caja! " + ex.Message.ToString(), "Apertura de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void print_recibo(int id_cierre)
        {
            try
            { 
                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("cierre_caja_recibo"); 
                frmReporte.id_cierre_caja = id_cierre;
                frmReporte.Show();
            }
            catch (Exception) {  }
        }
        private void nudMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }
       
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            new_egreso = true;
        }
        private void nudMontoIngresos_ValueChanged(object sender, EventArgs e)
        {
            try
            { 
                calcular_totales();
            }
            catch (Exception)  {
                ///nudMontoIngresos.Value = 0;
                calcular_totales();
            }
        }

        private void nudMontoIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoMoneda1.Value = nudCantidadEfectivoMoneda1.Value * 1; 
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoMoneda1.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoMoneda2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoMoneda2.Value = nudCantidadEfectivoMoneda2.Value * decimal.Parse("0.5");

                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoMoneda2.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoMoneda3_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoMoneda3.Value = nudCantidadEfectivoMoneda3.Value * decimal.Parse("0.25");

                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoMoneda3.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoMoneda4_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoMoneda4.Value = nudCantidadEfectivoMoneda4.Value * decimal.Parse("0.10");

                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoMoneda4.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoMoneda5_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoMoneda5.Value = nudCantidadEfectivoMoneda5.Value * decimal.Parse("0.05");

                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoMoneda5.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoMoneda6_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoMoneda6.Value = nudCantidadEfectivoMoneda6.Value * decimal.Parse("0.01");

                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoMoneda6.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoMoneda1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void nudCantidadEfectivoMoneda4_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda5_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda6_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudMontoFaltante_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudCantidadEfectivoBillete1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete1.Value = nudCantidadEfectivoBillete1.Value * 100;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete1.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete2.Value = nudCantidadEfectivoBillete2.Value * 50;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete2.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete3_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete3.Value = nudCantidadEfectivoBillete3.Value * 20;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete3.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete4_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete4.Value = nudCantidadEfectivoBillete4.Value * 10;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete4.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete5_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete5.Value = nudCantidadEfectivoBillete5.Value * 5;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete5.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete6_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete6.Value = nudCantidadEfectivoBillete6.Value * 2;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete6.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete7_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nudMontoEfectivoBillete7.Value = nudCantidadEfectivoBillete7.Value * 1;
                calcular_totales();
            }
            catch (Exception)
            {
                nudMontoEfectivoBillete7.Value = 0;
                calcular_totales();
            }
        }

        private void nudCantidadEfectivoBillete1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete3_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudMontoIngresos_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                calcular_totales();
            }
            catch (Exception)
            {
                ///nudMontoIngresos.Value = 0;
                calcular_totales();
            }
        }

        private void uDetalleMultiPago_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ////e.Layout.Bands[0].Columns[0].Width = 50;
            e.Layout.Bands[0].Columns[2].Width = 100;
            e.Layout.Bands[0].Columns[1].Width = 150;
            e.Layout.Bands[0].Columns["Id"].Hidden = true;
            e.Layout.Bands[0].Columns[3].Hidden = true;

            e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void nudCantidadEfectivoBillete4_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete5_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete6_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete7_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void btnExportarCtaProveedorProducto_Click(object sender, EventArgs e)
        {
            if (id_cierre_caja > 0)
            {
                print_recibo(id_cierre_caja);
            }
            else
            {
                MessageBox.Show("No se encontró un ID de cierre de caja para imprimir! ", "Imprimir cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void cargarMultiPago(int idAperturaCaja)
        {
            try
            {
                DataTable dtCirre = new DataTable();
                dtCirre = NCaja.VentasMultiPagoByUsuario(System.DateTime.Now,System.DateTime.Now, Globales.cGeneral.id_user_actual, id_apertura_caja,0);
                if (dtCirre.Rows.Count > 0)
                {
                    bsMultiPago.DataSource = dtCirre;
                    this.uDetalleMultiPago.DisplayLayout.ResetBands();
                    nvDetalleMultiPago.BindingSource = bsMultiPago;
                    uDetalleMultiPago.DataSource = bsMultiPago;
                    uDetalleMultiPago.DataBind();
                    sumar_det_pago();
                }
            }
            catch (Exception)   {   }
        }
        public void sumar_det_pago()
        {
            try
            {
                UltraGridBand band = this.uDetalleMultiPago.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[2]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                ///summary.Appearance.TextHAlign = HAlign.Right;
                summary.Appearance.ForeColor = Color.White;
                summary.Appearance.BackColor = Color.DimGray;
                summary.Appearance.FontData.Bold = DefaultableBoolean.True;

                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.DimGray;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DimGray;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "SUMA TOTALES:";


            }
            catch (Exception) { }
        }

        public decimal getTotalesOtrosPagos()
        {
            decimal otrosPagos = 0;
            try
            {
                if (uDetalleMultiPago.Rows.Count > 0)
                {
                    for (int i = 0; i < uDetalleMultiPago.Rows.Count; i++)
                    {
                        otrosPagos += decimal.Parse(uDetalleMultiPago.Rows[i].Cells[2].Value.ToString());
                    }
                }
                else
                {
                    otrosPagos = 0;
                }
            }
            catch (Exception) { }
            return otrosPagos;
        }
        private void ActualizarMontos()
        {
            try
            {
                nudMontoEgresos = NCaja.obtener_monto_egresos(id_apertura_caja, cGeneral.id_user_actual); 
                nudMontoApertura = NCaja.verificar_si_existe(cGeneral.id_user_actual);
                nudMontoSistema = NVentas.obtener_monto_venta_cierre(cGeneral.id_user_actual);
            }
            catch (Exception) {   }
        }
    }
}
