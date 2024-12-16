using CapaNegocios;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using wfaFarmacia_Ney.Globales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaFarmacia_Ney.PagosCxC
{
    public partial class frmAddPago : Form
    {
        public bool use_interno;
        public bool frm_cliente = false;
        public frmAddPago()
        {
            InitializeComponent();
        }

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }
        private void cargar_cliente()
        {
            try
            {
                this.cmbCliente.DataSource = NClientes.lista_combo();
                this.cmbCliente.ValueMember = "Id";
                this.cmbCliente.DisplayMember = "Cliente";
            }
            catch (Exception) { }
        }
        private void cargar_tipo_pago()
        {
            try
            {
                this.cmbTipoPago.DataSource = NTipoPago.lista_combo();
                this.cmbTipoPago.ValueMember = "Id";
                this.cmbTipoPago.DisplayMember = "Tipo";
                cmbTipoPago.SelectedIndex = 0;
            }
            catch (Exception) { }
        }
        private void cargar_factura_pendiente(string id_cliente,string moneda)
        {
            try
            {
                this.ugvFacturas.DataSource = NFactura.buscar_saldo(id_cliente, moneda);
            }
            catch (Exception) { }
        }
        private void frmAddPago_Load(object sender, EventArgs e)
        { 
            cargar_cliente();
            cargar_tipo_pago(); 

            if (frm_cliente == false)
            {
                cbMoneda.SelectedIndex = 0;
                cargar_factura_pendiente("",cbMoneda.Text);
            }
            else
            {
                cbMoneda.SelectedIndex = 0;
            }
            this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbTipoPago.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            lblTipoCambio.Text = cGeneral.TC.ToString();
        }

        private void cmbCliente_ValueChanged(object sender, EventArgs e)
        {

            cargar_factura_pendiente(cmbCliente.Value.ToString(),cbMoneda.Text);
        }

        private void ugvFacturas_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            e.Layout.Bands[0].Columns[0].Width = 70;
            e.Layout.Bands[0].Columns[1].Width = 250;
            e.Layout.Bands[0].Columns[2].Width = 100;
            e.Layout.Bands[0].Columns[3].Width = 70;
            e.Layout.Bands[0].Columns[4].Width = 70;
            e.Layout.Bands[0].Columns[5].Width = 100;

            e.Layout.Bands[0].Columns[0].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[1].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = HAlign.Left;
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Left;
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Left;


            e.Layout.Bands[0].Columns[2].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[2].CellAppearance.ForeColor = Color.Red;

            e.Layout.Bands[0].Columns[3].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[3].CellAppearance.ForeColor = Color.Red;

            e.Layout.Bands[0].Columns[4].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[4].CellAppearance.ForeColor = Color.Blue;
 

            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
           //// e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;

            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            //e.Layout.Override.AllowAddNew = AllowAddNew.No;
            //e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            //e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void ugvFacturas_AfterCellUpdate(object sender, CellEventArgs e)
        {
            calcular_abono();
        }

        private void calcular_abono()
        {
            try
            {
                decimal abono = 0;
                if (ugvFacturas.Rows.Count>0)
                {
                    for (int i = 0; i < ugvFacturas.Rows.Count; i++)
                    {
                        if (decimal.Parse(ugvFacturas.Rows[i].Cells[4].Value.ToString())<= decimal.Parse(ugvFacturas.Rows[i].Cells[3].Value.ToString()))
                        {
                            abono += decimal.Parse(ugvFacturas.Rows[i].Cells[4].Value.ToString());
                        }  else
                        {
                            ugvFacturas.Rows[i].Cells[4].Value = 0;
                        }
                    }

                    nudMontoPago.Value = abono;
                }
                else
                {
                    nudMontoPago.Value = abono;
                }
            }
            catch (Exception) { }
        }

        private void nudMontoPago_ValueChanged(object sender, EventArgs e)
        {
            calcular_abono();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(nudMontoPago.Value <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "PAGO FACTURA";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Tiene que seleccionar una factura y el monto abonar.", this.btnGuardar, 0, 38, 3000);
                    return;
                }
                if (cmbCliente.Value is null)
                {
                    this.ttMensaje.ToolTipTitle = "PAGO FACTURA";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Tiene que seleccionar el cliente.", this.btnGuardar, 0, 38, 3000);
                    return;
                }
                if (cmbTipoPago.Value is null)
                {
                    this.ttMensaje.ToolTipTitle = "PAGO FACTURA";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Tiene que seleccionar el tipo de pago.", this.btnGuardar, 0, 38, 3000);
                    return;
                }

                DataTable dt = tem_fact();
                string num_factura = NPagoCxC.guardar(cGeneral.id_user_actual.ToString(), cmbCliente.Value.ToString(), dtpFechaPago.Value,nudMontoPago.Value,cmbTipoPago.Value.ToString(), txtNumReferencia.Text,txtComentario.Text, dt,cbMoneda.Text, cGeneral.TC);
                if (Convert.ToInt32(num_factura) > 0)
                 {
                    this.ttMensaje.ToolTipTitle = "PAGO FACTURA";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("Pago ingresado con éxito.", this.btnGuardar, 0, 38, 3000);

                    if (!use_interno)
                    {
                        Facturacion.frmCxPagar.me.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(Facturacion.frmCxPagar.me.dtpDesde.Value), Convert.ToDateTime(Facturacion.frmCxPagar.me.dtpDesde.Value),true);
                        Facturacion.frmCxPagar.me.tBuscar.Enabled = true;
                    }
                    DialogResult resul1 = MessageBox.Show("El recibo ha sido guardado.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        print_reporte(num_factura);
                    }

                    this.Close();
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "PAGO FACTURA";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Ocurrio un error al intengar realizar el pago a la factura. Contactar con su administrador.", this.btnGuardar, 0, 38, 3000);
                    return;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Ocurrio un error al intentar guardar el pago." + er.Message.ToString(), "Error al guardar el pago");
                return;
            }
        }
        private void print_reporte (string id_pago)
        {
            try
            {
                if (this.ugvFacturas.Rows.Count > 0)
                {
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("recibo");
                    frmReporte.id_pago = id_pago;
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private DataTable tem_fact ()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("num_factura");
            dt.Columns.Add("monto");

            try
            {
                if (ugvFacturas.Rows.Count > 0)
                {
                    for (int i = 0; i < ugvFacturas.Rows.Count; i++)
                    {
                        if (decimal.Parse(ugvFacturas.Rows[i].Cells[4].Value.ToString()) <= decimal.Parse(ugvFacturas.Rows[i].Cells[3].Value.ToString()))
                        {
                            string num_factura = ugvFacturas.Rows[i].Cells[0].Value.ToString();
                            decimal abono_factura = decimal.Parse(ugvFacturas.Rows[i].Cells[4].Value.ToString());
                            if (abono_factura > 0)
                            {
                                var row = dt.NewRow();
                                row["num_factura"] = num_factura;
                                row["monto"] = abono_factura;
                                dt.Rows.InsertAt(row, i);
                            }
                        }
                    }
                }

                return dt;
            }
            catch (Exception) { return dt; }
            
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmTipoPago frm = new Catalogos.frmTipoPago();
                frm.txtBuscar.Text = "*";
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnRefrescarCliente_Click(object sender, EventArgs e)
        {
            cargar_tipo_pago();
        }

        private void txtNumReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargar_factura_pendiente(cmbCliente.Value.ToString(), cbMoneda.Text);
            }
            catch (Exception)  {  } 
        } 
    }
}
