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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using SCM.WsSRIComprobanteElectronico;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.IO;

namespace SCM.SRI
{
    public partial class frmComprobantesElectronicos : Form
    {
        public bool accion;
        public string id_combo;
        public int id_venta = 0, id_det_venta = 0, name_ventana = 0;
        public string id_producto = "";
        public decimal cantidad = 0;

        public frmComprobantesElectronicos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvPendiente.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.gvPendiente, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvEnviadosSRI.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.gvEnviadosSRI, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }
        private void frmPrecioEspecial_Load(object sender, EventArgs e)
        {
            CargarDocumentoPendienteEnviar();
            CargarDocumentoEnviadosSRI();
            CargarDocumentoRetencionEnviadosSRI();
            this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            sumar_ventas_no_enviadas();
        }
        private void CargarDocumentoPendienteEnviar()
        {
            try
            {
                bindingSource1.DataSource = NComprobantesSRI.buscar_comprobantes_no_enviados_a_sri("", dtInifioPendienteSRI.Value, dtFinPendienteSRI.Value);
                bindingNavigator1.BindingSource = bindingSource1;
                gvPendienteSRI.DataSource = bindingSource1;
            }
            catch (Exception) { }
        }
        private void CargarDocumentoEnviadosSRI()
        {
            try
            {
                bindingSource2.DataSource = NComprobantesSRI.buscar_comprobantes_enviados_a_sri("", dtInicioAprobada.Value, dtFinAprobada.Value);
                nvAprobadas.BindingSource = bindingSource2;
                gvEnviadosSRI.DataSource = bindingSource2;
            }
            catch (Exception) { }
        }
        private void CargarDocumentoRetencionEnviadosSRI()
        {
            try
            {
                bsComprobanteRentecion.DataSource = NComprobantesSRI.buscar_comprobantes_retencion_enviados_a_sri( dtInicioRetencion.Value, dtFinRetencion.Value);
                bnComprobanteRetencion.BindingSource = bsComprobanteRentecion;
                ugvComprobanteRetencion.DataSource = bsComprobanteRentecion;
            }
            catch (Exception) { }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CargarDocumentoPendienteEnviar();
        }

        private void dtInifioPendiente_ValueChanged(object sender, EventArgs e)
        {
            CargarDocumentoPendienteEnviar();
        }

        private void dtFinPendiente_ValueChanged(object sender, EventArgs e)
        {
            CargarDocumentoPendienteEnviar();
        }
        private void gvPendiente_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Bands[0].Columns[8].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[9].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[10].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[11].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[12].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[13].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[14].Format = "###,###,##0.00";

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
            catch (Exception) { }
        }

        private void gvAprobadas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Bands[0].Columns[10].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[11].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[12].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[13].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[14].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[15].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[16].Format = "###,###,##0.00";
                e.Layout.Bands[0].Columns[17].Format = "###,###,##0.00";

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
            catch (Exception) { }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPendiente.Rows.Count > 0)
                {
                    string nameProducto = this.gvPendiente.Selected.Rows[0].Cells[2].Value.ToString(), id_producto = "";
                    decimal precio = 0, cantidad = 0;
                    int id_precio_especial = 0, id_venta = 0;
                    try
                    {
                        precio = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[5].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cantidad = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[4].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        id_precio_especial = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[0].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        id_venta = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[6].Value.ToString());
                    }
                    catch (Exception) { }

                    try
                    {
                        id_producto = this.gvPendiente.Selected.Rows[0].Cells[3].Value.ToString();
                    }
                    catch (Exception) { }

                    if (id_precio_especial <= 0)
                    {
                        MessageBox.Show("Seleccione el precio especial que requiera para aprobar.", "Seleccione precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult resul = MessageBox.Show("¿Desea aprobar el precio: " + precio + " especial para el producto: " + nameProducto + "?", "Confirmar aprobación de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    NVentas.ApruebaRechazaPrecioEspecial(id_venta, id_precio_especial, precio, cantidad, id_producto, "Aprobada", cGeneral.id_user_actual.ToString());
                    MessageBox.Show("Precio aprobado con éxito!", "Aprobado de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ///gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
                }
            }
            catch (Exception) { }

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.gvPendienteSRI.DisplayLayout.ResetBands();

            gvPendienteSRI.DataSource = null;
            CargarDocumentoPendienteEnviar();
            sumar_ventas_no_enviadas();

        }
        public void sumar_ventas_no_enviadas()
        {
            try
            {
                UltraGridBand band = this.gvPendienteSRI.DisplayLayout.Bands[0];
                ///' Add a Horas.
                ///

                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[8]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[9]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[10]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[13]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[14]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}"; 
            }
            catch (Exception) { }
        }
        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            gvEnviadosSRI.DataSource = null;
            CargarDocumentoEnviadosSRI();
            sumar_totales_ventas_enviados();
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvPendienteSRI.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.gvPendienteSRI, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void tsbEnviarComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPendienteSRI.Rows.Count > 0)
                {
                    DataTable dt = NParametrosSRI.buscar();
                    if (dt.Rows.Count > 0)
                    {
                        if (bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString()))
                        {
                            decimal montoMinimoConsumidorFinal = 0;
                            try
                            {
                              montoMinimoConsumidorFinal = decimal.Parse(dt.Rows[0]["MontoMinimoConsumidorFinal"].ToString());
                            }
                            catch (Exception)   {
                                montoMinimoConsumidorFinal = 0;
                                MessageBox.Show("Parametro máximo de monto consumidor final para el SRI no esta configurado.", "Parametro monto máximo no configurado en  configuración de SRI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                gvSRI.Visible = false;
                                return;
                            }
                            
                            DateTime dtFinicioLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaDesde"].ToString());
                            DateTime dtFFinLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaHasta"].ToString());
                            var nombreComercial = dt.Rows[0]["NombreComercial"].ToString();

                            if (dtFinicioLicencia <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && dtFFinLicencia >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
                            {
                                gvSRI.Visible = true;
                                string idVenta = "", usrGeneraDoc = "", codDoc = "", numComprobante = "", idCliente = "", tipoDocumentoComprador = "", razonSocialComprador = "", numIdentificacionComprador = "", dirComprador = "";
                                decimal totalSinImpuesto = 0, totalDescuento = 0, totalPropina = 0, importeTotal = 0, valorRetIva = 0, valorRetRenta = 0;
                                DateTime fechaDocumento = new DateTime();

                                /*Instancia de Objetos del servicio para enviar los datos*/
                                List<totalImpuesto> vTotalImpuestos = new List<totalImpuesto>();
                                List<Pagos> vPagos = new List<Pagos>();
                                List<ItemPorProducto> vItemPorProductos = new List<ItemPorProducto>();
                                List<DetalleImpuestosItem> vDetalleImpuestosItems = new List<DetalleImpuestosItem>();

                                try
                                {
                                    codDoc = this.gvPendienteSRI.Selected.Rows[0].Cells["IdTipoDocumento"].Value.ToString();
                                    idVenta = this.gvPendienteSRI.Selected.Rows[0].Cells["IdVenta"].Value.ToString();
                                    /*TipoDocumentoFactura*/
                                    if (codDoc == "01")
                                    {
                                        idCliente = this.gvPendienteSRI.Selected.Rows[0].Cells["Id_Cliente"].Value.ToString();
                                        var totalAPagarValida = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells["TotalPagar"].Value.ToString());
                                        
                                        if (idCliente.Length > 0)
                                        {
                                            if (idCliente == "1" && totalAPagarValida >= montoMinimoConsumidorFinal)
                                            {
                                                DialogResult resuls = MessageBox.Show("El monto a pagar es mayor al maximo de envio al SRI para un cliente CONSUMIDOR FINAL. El monto MÁXIMO configurado en SRI es: " + montoMinimoConsumidorFinal.ToString() + " y el total a pagar es: " + totalAPagarValida.ToString() + ".\n\n¿Desea cambiar el cliente de esta venta?","Monto máximo de envio al SRI para CONSUMIDOR FINAL.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (resuls == System.Windows.Forms.DialogResult.Yes)
                                                {
                                                    gvCambiarCliente.Visible = true;
                                                    gvSRI.Visible = false;
                                                    ObtenerCliente(idCliente);
                                                    lblIDVENTA.Text = idVenta;
                                                    return;
                                                }
                                                else
                                                {
                                                    gvSRI.Visible = false;
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                /*Datos de comprobante(venta)*/
                                                numComprobante = this.gvPendienteSRI.Selected.Rows[0].Cells["NumeroComprobante"].Value.ToString();
                                                if (numComprobante == "XXXXX")
                                                {
                                                    numComprobante = NVentas.ObtenerNumeroConsecutivoSR(int.Parse(idVenta));
                                                }
                                                fechaDocumento = Convert.ToDateTime(this.gvPendienteSRI.Selected.Rows[0].Cells["FechaDocumento"].Value.ToString());
                                                usrGeneraDoc = this.gvPendienteSRI.Selected.Rows[0].Cells["Id_Usuario"].Value.ToString();
                                                /*Datos de cliente*/
                                                DataTable dtCliente = NClientes.obtener_datos(int.Parse(idCliente));
                                                /*Datos de cliente*/
                                                DataTable dtDetProductoVenta = NVentas.Obtener_Producto_Venta(int.Parse(idVenta));
                                                if (dtCliente.Rows.Count > 0)
                                                {
                                                    /*Datos de cliente*/
                                                    tipoDocumentoComprador = dtCliente.Rows[0]["Codigo"].ToString();
                                                    numIdentificacionComprador = dtCliente.Rows[0]["Cedula"].ToString().Length > 0 ? dtCliente.Rows[0]["Cedula"].ToString() : dtCliente.Rows[0]["RUC"].ToString();
                                                    razonSocialComprador = dtCliente.Rows[0]["Nombres_Apellidos"].ToString();
                                                    dirComprador = dtCliente.Rows[0]["Ciudad"].ToString().Trim() + " / " + dtCliente.Rows[0]["Direccion"].ToString().Trim();

                                                    if (tipoDocumentoComprador.Length <= 0)
                                                    {
                                                        MessageBox.Show("No se encontró tipo de documento para el cliente: " + idCliente, "No se encontro tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        gvSRI.Visible = false;
                                                        return;
                                                    }
                                                    else if (numIdentificacionComprador.Length <= 0)
                                                    {
                                                        MessageBox.Show("Cliente no tiene un número de documento valido: " + idCliente, "Número de documento no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        gvSRI.Visible = false;
                                                        return;
                                                    }
                                                    /*Datos de venta valore monto, iva, descuento*/
                                                    var subtotal = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells["SubTotalSinImpuestos"].Value.ToString());
                                                    var subtotal_cp = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells[10].Value.ToString());
                                                    var subtotal_dp = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells[11].Value.ToString()); 
                                                    var tdescuento = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells["Descuento"].Value.ToString());
                                                    var totalIva = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells["IVA"].Value.ToString());
                                                    var totalAPagar = decimal.Parse(this.gvPendienteSRI.Selected.Rows[0].Cells["TotalPagar"].Value.ToString());

                                                    /*Se asignan valores de monto del comprobante de FACTURA*/
                                                    totalSinImpuesto = decimal.Parse(subtotal.ToString("N" + 2 + ""));
                                                    totalDescuento = decimal.Parse(tdescuento.ToString("N" + 2 + ""));
                                                    totalPropina = 0; /*Se asigna en cero por default: no existe propina en sistema*/
                                                    importeTotal = decimal.Parse(totalAPagar.ToString("N" + 2 + ""));
                                                    valorRetIva = decimal.Parse(totalIva.ToString("N" + 2 + ""));
                                                    valorRetRenta = 0; /*Se asigna en cero por default: no existe retención renta en sistema*/

                                                    if (valorRetIva > 0 && cGeneral.IVA_COD_SRI.Trim().Length <= 0)
                                                    {
                                                        MessageBox.Show("No ha configurado en sistema ningún codigo de tipo de impuesto relacionado al SRI en la sección de impuesto (IVA)", "No hay código de impuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        gvSRI.Visible = false;
                                                        return;
                                                    }
                                                    /**Se Asigna el total impuesto con IVA si venta tiene IVA*/
                                                    if (subtotal_dp > 0 && totalIva > 0)
                                                    {
                                                        vTotalImpuestos.Add(new totalImpuesto
                                                        {
                                                            codigo = cGeneral.IVA_COD_SRI.Trim(),
                                                            codigoPorcentaje = cGeneral.IVA_PORC_SRI.Trim(),
                                                            baseImponible = decimal.Parse(subtotal_dp.ToString("N" + 2 + "")),
                                                            valor = decimal.Parse(totalIva.ToString("N" + 2 + ""))
                                                        });
                                                    }
                                                    /**Se Asigna el total cero por ciento que no tiene impuesto*/
                                                    if (subtotal_cp > 0)
                                                    {
                                                        vTotalImpuestos.Add(new totalImpuesto
                                                        {
                                                            codigo = cGeneral.IVA_COD_SRI.Trim(),
                                                            codigoPorcentaje = "0",
                                                            baseImponible = decimal.Parse(subtotal_cp.ToString("N" + 2 + "")),
                                                            valor = decimal.Parse(0.ToString("N" + 2 + ""))
                                                        });
                                                    }

                                                    DataTable dtTipoPagoVenta = NVentas.Obtener_Producto_Venta_by_TipoPago(int.Parse(idVenta));

                                                    /*Se asignan los valores del tipo de pago*/
                                                    if (dtTipoPagoVenta.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow itemTipoPago in dtTipoPagoVenta.Rows)
                                                        {
                                                            var efectivo = decimal.Parse(itemTipoPago["Efectivo"].ToString());
                                                            var tc = decimal.Parse(itemTipoPago["TC"].ToString());
                                                            var td = decimal.Parse(itemTipoPago["TD"].ToString());
                                                            var otros = decimal.Parse(itemTipoPago["Otros"].ToString());
                                                            var CODIGO_SRI = itemTipoPago["CODIGO_SRI"].ToString();
                                                            var montoPago = efectivo > 0 ? efectivo : tc > 0 ? tc : td > 0 ? td : otros > 0 ? otros : 0;

                                                            if (montoPago > 0)
                                                            {
                                                                if (CODIGO_SRI.ToString().Trim().Length > 0)
                                                                {
                                                                    vPagos.Add(new Pagos
                                                                    {
                                                                        formaPago = CODIGO_SRI.ToString().Trim(),
                                                                        total = decimal.Parse(montoPago.ToString("N" + 2 + "")),
                                                                        plazo = "0",
                                                                        unidadTiempo = "dias"
                                                                    });
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("No se encontro CODIGO de tipo de pago SRI para para la venta #:" + idVenta + "con monto de pago: " + montoPago, "No hay CODIGO SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    gvSRI.Visible = false;
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("No se encontro monto pago para el tipo de pago en SRI #:" + CODIGO_SRI, "No hay monto de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                gvSRI.Visible = false;
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("No se encontro tipos de pago para la venta #:" + idVenta, "No hay tipo de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        gvSRI.Visible = false;
                                                        return;
                                                    }
                                                    if (dtDetProductoVenta.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow row in dtDetProductoVenta.Rows)
                                                        {
                                                            List<DetalleImpuestosItem> DetItemImpuestos = new List<DetalleImpuestosItem>();
                                                            List<ItemPorProductoDetallesAdicionales> dAdicionalItem = new List<ItemPorProductoDetallesAdicionales>();
                                                            /*Se asignana valores adicionales de items facturados*/
                                                            /*Presentación*/
                                                            dAdicionalItem.Add(new ItemPorProductoDetallesAdicionales
                                                            {
                                                                Nombre = "Presentacion",
                                                                Valor = "Presentación: " + row["Presentacion"].ToString()
                                                            });
                                                            /*Presentación*/
                                                            dAdicionalItem.Add(new ItemPorProductoDetallesAdicionales
                                                            {
                                                                Nombre = "Laboratorio",
                                                                Valor = "Laboratorio: " + row["Laboratorio"].ToString()
                                                            });
                                                            var ivaItem = decimal.Parse(decimal.Parse(row["IVA"].ToString()).ToString("N" + 2 + ""));
                                                            var subTotalItem = decimal.Parse(decimal.Parse(row["Subtotal"].ToString()).ToString("N" + 2 + ""));
                                                            var subtotalDPItem = decimal.Parse(decimal.Parse(row["Subtotal_DP"].ToString()).ToString("N" + 2 + ""));
                                                            /*Se asignan valroes de impuestos por items facturados*/
                                                            DetItemImpuestos.Add(new DetalleImpuestosItem
                                                            {
                                                                codigo = cGeneral.IVA_COD_SRI.Trim(),
                                                                codigoPorcentaje = ivaItem > 0 ? cGeneral.IVA_PORC_SRI.Trim() : "0",
                                                                tarifa = ivaItem > 0 ? decimal.Parse(cGeneral.IVA.ToString("N" + 2 + "")) : 0,
                                                                baseImponible = ivaItem > 0 ? decimal.Parse(subtotalDPItem.ToString("N" + 2 + "")) : decimal.Parse(subTotalItem.ToString("N" + 2 + "")),
                                                                valor = decimal.Parse(ivaItem.ToString("N" + 2 + ""))
                                                            });

                                                            /*Se asignan valores de items de producto facturados*/
                                                            vItemPorProductos.Add(new ItemPorProducto
                                                            {
                                                                DetItemAdicional = dAdicionalItem.ToArray(),
                                                                codigoPrincipal = row["Id_Producto"].ToString(),
                                                                codigoAuxiliar = row["Id_Producto"].ToString(),
                                                                descripcion = row["Producto"].ToString(),
                                                                cantidad = decimal.Parse(decimal.Parse(row["Vendio"].ToString()).ToString("N" + 2 + "")),
                                                                descuento = decimal.Parse(decimal.Parse(row["Descuento"].ToString()).ToString("N" + 2 + "")),
                                                                precioUnitario = decimal.Parse(decimal.Parse(row["PVP"].ToString()).ToString("N" + 2 + "")),
                                                                precioTotalSinImpuesto = decimal.Parse(decimal.Parse(row["Subtotal"].ToString()).ToString("N" + 2 + "")),
                                                                DetItemImpuestos = DetItemImpuestos.ToArray()
                                                            }); ;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("No existen producto agregado a la venta #" + idVenta, "No existen productos en venta" + idCliente, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        gvSRI.Visible = false;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se encontro cliente a procesar, favor verificar la venta y cliente asignado a esta.", "Error de mapeo de datos #cliente: " + idCliente, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    gvSRI.Visible = false;
                                                    return;
                                                }
                                            }  
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se encontro cliente a procesar, favor verificar la venta y cliente asignado a esta.", "Error de mapeo de datos #cliente: " + idCliente, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            gvSRI.Visible = false;
                                            return;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    CargarDocumentoPendienteEnviar();
                                    MessageBox.Show("Error al mapear los datos: " + ex.Message.ToString(), "Error de mapeo de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    gvSRI.Visible = false;
                                    return;
                                }

                                DialogResult resul = MessageBox.Show("¿Esta seguro de enviar el comprobante número: " + numComprobante + " al SRI?", "Confirmar envio de comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (resul == System.Windows.Forms.DialogResult.No)
                                {
                                    gvSRI.Visible = false;
                                    return;
                                }
                                /*Enviar comprobante a SRI*/
                                SRI.Model.SriServices sriService = new Model.SriServices();
                                string refNoFactura = "", refAmbiente = "", refTipoEmision = "", refImpresora = "";
                                var responseSRI = sriService.AutorizacionComprobante(fechaDocumento.ToString("dd/MM/yyyy"), tipoDocumentoComprador, numComprobante, razonSocialComprador, numIdentificacionComprador, dirComprador, totalSinImpuesto, totalDescuento, totalPropina, importeTotal, valorRetIva, valorRetRenta, vTotalImpuestos.ToArray(), vPagos.ToArray(), vItemPorProductos.ToArray(), vDetalleImpuestosItems.ToArray(), ref refNoFactura, ref refAmbiente, ref refTipoEmision, ref refImpresora);
                                gvSRI.Visible = false;
                                 
                                if (responseSRI != null)
                                {

                                    /*Se valida resultado de SERVICIO: SRI*/ 
                                    if (responseSRI.MensajeErrorInterno.Length >0)
                                    {
                                        MessageBox.Show(responseSRI.MensajeErrorInterno, "Error al ejecutar servicio del SRI - LOCAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    } 
                                    if (!responseSRI.ErrorInterno)
                                    {
                                        /*Si SRI recibe el comprobante*/
                                        if (responseSRI.estado == "RECIBIDA")
                                        {
                                            bool autorizada = false;
                                            var responseKey = sriService.RecepcionComprobante(responseSRI.ClaveAcceso);
                                            foreach (var item in responseKey.autorizaciones)
                                            {
                                                if (item.estado == "AUTORIZADO")
                                                {
                                                    NComprobantesSRI.guardar(responseSRI.ClaveAcceso, codDoc, numComprobante, fechaDocumento.ToShortDateString(), fechaDocumento.ToShortDateString(), System.DateTime.Now, null, null, cGeneral.id_user_actual.ToString(), usrGeneraDoc, item.estado, idCliente, totalSinImpuesto.ToString().Replace(",", "."), importeTotal.ToString().Replace(",", "."), "Comprobante AUTORIZADO en SRI", refNoFactura, refAmbiente, refTipoEmision);
                                                    CargarDocumentoPendienteEnviar();
                                                    CargarDocumentoEnviadosSRI();
                                                    autorizada = true;
                                                    gvSRI.Visible = false;
                                                    DialogResult response = MessageBox.Show("Estado: " + item.estado + ". El SRI ha autorizado con éxito el comprobante #" + numComprobante + " generando el número de clave de acceso:" + responseKey.claveAccesoConsultada + ".\n\n¿Desea imprimir el comprobante del SRI?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                    if (response == System.Windows.Forms.DialogResult.Yes)
                                                    {
                                                        System.Threading.Tasks.Task.Run(() => { print_comprobante_sri(idVenta, refImpresora); });
                                                    }
                                                    return;
                                                }
                                            }
                                            if (!autorizada)
                                            {
                                                string mensajesSRI = "";
                                                int contador = 1;
                                                foreach (var item in responseKey.autorizaciones)
                                                {
                                                    foreach (var mensaje in item.mensajes)
                                                    {
                                                        if (contador == 1)
                                                        {
                                                            mensajesSRI += "No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                        }
                                                        else
                                                        {
                                                            mensajesSRI += "; No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                        }
                                                        contador += 1;
                                                    }
                                                }
                                                MessageBox.Show("El SRI NO AUTORIZADO el comprobante. Detalle del rechazo:" + mensajesSRI, "Rechazo de comprobante en SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                gvSRI.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            /*Si SRI devuelve el comprobante*/
                                            if (responseSRI.estado == "DEVUELTA")
                                            {
                                                var responseKey = sriService.RecepcionComprobante(responseSRI.ClaveAcceso);
                                                bool autorizada = false;
                                                if (responseKey.autorizaciones.ToList().Count > 0)
                                                {
                                                    foreach (var item in responseKey.autorizaciones)
                                                    {
                                                        if (item.estado == "AUTORIZADO")
                                                        {
                                                            NComprobantesSRI.guardar(responseSRI.ClaveAcceso, codDoc, numComprobante, fechaDocumento.ToShortDateString(), fechaDocumento.ToShortDateString(), System.DateTime.Now, null, null, cGeneral.id_user_actual.ToString(), usrGeneraDoc, item.estado, idCliente, totalSinImpuesto.ToString().Replace(",", "."), importeTotal.ToString().Replace(",", "."), "Comprobante AUTORIZADO en SRI", refNoFactura, refAmbiente, refTipoEmision);
                                                            CargarDocumentoPendienteEnviar();
                                                            CargarDocumentoEnviadosSRI();
                                                            autorizada = true;
                                                            gvSRI.Visible = false;
                                                            DialogResult response = MessageBox.Show("Estado: " + item.estado + ". El SRI ha autorizado con éxito el comprobante #" + numComprobante + " generando el número de clave de acceso:" + responseKey.claveAccesoConsultada + ".\n\n¿Desea imprimir el comprobante del SRI?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                            if (response == System.Windows.Forms.DialogResult.Yes)
                                                            {
                                                                System.Threading.Tasks.Task.Run(() => { print_comprobante_sri(idVenta, refImpresora); });
                                                            }
                                                            return;
                                                        }
                                                    }
                                                    if (!autorizada)
                                                    {

                                                        string mensajesSRI = "";
                                                        int contador = 1;


                                                        foreach (var item in responseKey.autorizaciones)
                                                        {
                                                            foreach (var mensaje in item.mensajes)
                                                            {
                                                                if (contador == 1)
                                                                {
                                                                    mensajesSRI += "No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                                }
                                                                else
                                                                {
                                                                    mensajesSRI += "; No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                                }
                                                                contador += 1;
                                                            }
                                                        }
                                                        MessageBox.Show("El SRI NO AUTORIZADO el comprobante. Detalle del rechazo:" + mensajesSRI, "Rechazo de comprobante en SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        gvSRI.Visible = false;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    string mensajesSRI = "";
                                                    int contador = 1;
                                                    foreach (var item in responseSRI.comprobantes)
                                                    {
                                                        foreach (var mensaje in item.mensajes)
                                                        {
                                                            if (contador == 1)
                                                            {
                                                                mensajesSRI += "No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                            }
                                                            else
                                                            {
                                                                mensajesSRI += "; No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                            }
                                                            contador += 1;
                                                        }
                                                    }
                                                    MessageBox.Show("El SRI NO AUTORIZADO el comprobante. Detalle del rechazo:" + mensajesSRI, "Rechazo de comprobante en SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    gvSRI.Visible = false;
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                string mensajesSRI = "";
                                                int contador = 1;
                                                foreach (var item in responseSRI.comprobantes)
                                                {
                                                    foreach (var mensaje in item.mensajes)
                                                    {
                                                        if (contador == 1)
                                                        {
                                                            mensajesSRI += "No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                        }
                                                        else
                                                        {
                                                            mensajesSRI += "; No:" + contador + ":" + mensaje.mensaje.ToString() + " DETALLE: " + mensaje.informacionAdicional;
                                                        }
                                                        contador += 1;
                                                    }
                                                }
                                                MessageBox.Show("El SRI NO AUTORIZADO el comprobante. Detalle del rechazo:" + mensajesSRI, "Rechazo de comprobante en SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                gvSRI.Visible = false;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        CargarDocumentoPendienteEnviar();
                                        MessageBox.Show("Ocurrio un error al intentar enviar el comprobante al SRI. Detalle del error:" + responseSRI.MensajeErrorInterno, "Error de envio de comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        gvSRI.Visible = false;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Licencia de servicio SRI en " + cGeneral.name_system + " no esta VIGENTE. Contactar con el administrador para su renovación.", "Servicio SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Servicio del SRI a nivel de " + cGeneral.name_system + " esta INACTIVO. Contactar con el administrador para verificar la vigencia de la LICENCIA.", "Servicio SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay ningún documento pendiente para enviar al SRI", "No hay registros a enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                gvSRI.Visible = false;
            }
            catch (Exception ex)
            {
                gvSRI.Visible = false;
                MessageBox.Show("Selecione un comprobante para enviar." + ex.Message.ToString(), "Seleccione un comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvEnviadosSRI.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.gvEnviadosSRI, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void tsbReImprimirComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEnviadosSRI.Rows.Count > 0)
                {
                    DataTable dt = NParametrosSRI.buscar();
                    var refImpresora = dt.Rows[0]["ImpresoraTickets"].ToString();
                    var idVenta = this.gvEnviadosSRI.Selected.Rows[0].Cells["IdVenta"].Value.ToString();
                    System.Threading.Tasks.Task.Run(() => { print_comprobante_sri(idVenta, refImpresora); });
                }
            }
            catch (Exception) { }
        }

        private void stbEnvioCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEnviadosSRI.Rows.Count > 0)
                {
                    DataTable dt = NParametrosSRI.buscar();
                    if (dt.Rows.Count > 0)
                    {
                        if (bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString()))
                        {
                            DateTime dtFinicioLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaDesde"].ToString());
                            DateTime dtFFinLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaHasta"].ToString());
                            var nombreComercial = dt.Rows[0]["NombreComercial"].ToString();

                            if (dtFinicioLicencia <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && dtFFinLicencia >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
                            {
                                var rutaXML = dt.Rows[0]["RutaXML"].ToString();
                                var CorreoSMTP = dt.Rows[0]["CorreoSMTP"].ToString();
                                var ContrasenaSMTP = dt.Rows[0]["ContrasenaSMTP"].ToString();
                                var idCliente = this.gvEnviadosSRI.Selected.Rows[0].Cells["Id_Cliente"].Value.ToString();
                                var numFactura = this.gvEnviadosSRI.Selected.Rows[0].Cells["NoFactura"].Value.ToString();
                                var claveAcceso = this.gvEnviadosSRI.Selected.Rows[0].Cells["ClaveAcceso"].Value.ToString();
                                var fechaAutorizacion = this.gvEnviadosSRI.Selected.Rows[0].Cells["FechaAutorizacion"].Value.ToString();
                                var IdVenta = this.gvEnviadosSRI.Selected.Rows[0].Cells["IdVenta"].Value.ToString();
                                /*Datos de cliente*/
                                DataTable dtCliente = NClientes.obtener_datos(int.Parse(idCliente));
                                if (dtCliente.Rows.Count > 0)
                                {
                                    gvCorreo.Visible = true;
                                    var correo = dtCliente.Rows[0]["Correo"].ToString();
                                    var nombres = dtCliente.Rows[0]["Nombres_Apellidos"].ToString();
                                    if (correo.Trim().Length > 0)
                                    {
                                        SMTP.Mail mail = new SMTP.Mail();
                                        string style = "style=\"color:#020766;font-weight:bold;font-size: 18px;\"";
                                        StringBuilder sb = new StringBuilder();
                                        string subject = "COMPROBANTE ELECTRONICO";
                                        sb.Append("<html><head><title>COMPROBANTE ELECTRONICO</title></head><body>");
                                        sb.Append("<p " + style + ">Estimado cliente: " + nombres.ToUpper() + "</p>");
                                        sb.Append("<p>Hemos emitido el siguiente comprobante electrónico </p>");
                                        sb.Append("<p>Documento: FACTURA </p>");
                                        sb.Append("<p>Número: " + numFactura.ToUpper() + " </p>");
                                        sb.Append("<p>Clave de acceso: " + claveAcceso + " </p>");
                                        sb.Append("<p>Fecha: " + fechaAutorizacion + " </p>");
                                        sb.Append("<p></p>");
                                        sb.Append("<p></p>");
                                        sb.Append("<p>Puede consultar los comprobantes electrónicos autorizados ingresando a: </p>");
                                        sb.Append("<p>https://srienlinea.sri.gob.ec/comprobantes-electronicos-internet/publico/validezComprobantes.jsf</p>");
                                        sb.Append("<p>Saludos Cordiales</p></body></html>");
                                        //Exportamos la factura a PDF
                                        AddFacturaPDF(IdVenta, numFactura);
                                        mail.SendEmail(correo, CorreoSMTP, CorreoSMTP, ContrasenaSMTP, subject, sb.ToString(), numFactura, claveAcceso, rutaXML);
                                        MessageBox.Show("Comprobante de venta enviado de forma éxitosa al email: " + correo, "Comprobante enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("El cliente: " + nombres + " no posee ningún corre electrónico configurado. Favor verificar en la ficha de cliente para poder enviar el comprobante", "Cliente no posee correo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontro el cliente con ID:" + idCliente + ". Favor verificar", "No se encontro el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Licencia de servicio SRI en " + cGeneral.name_system + " no esta VIGENTE. Contactar con el administrador para su renovación.", "Servicio SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Servicio del SRI a nivel de " + cGeneral.name_system + " esta INACTIVO. Contactar con el administrador para verificar la vigencia de la LICENCIA.", "Servicio SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                gvCorreo.Visible = false;
                MessageBox.Show("Ocurrio un error al intentar enviar el comprobante por correo: " + ex.Message.ToString(), "Error al enviar el comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            gvCorreo.Visible = false;
        }

        private void nudPrecioEspecial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

        }

        private void tsbWhatsApp_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            DialogResult resul = MessageBox.Show("¿Esta seguro de cambiar el cliente: " + cmbCliente.Text + " a la venta #"+lblIDVENTA.Text + "?", "Confirmar cambio de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resul == System.Windows.Forms.DialogResult.Yes)
            { 
                NVentas.ActualizaClienteVenta( int.Parse( lblIDVENTA.Text), cmbCliente.Value.ToString());
                MessageBox.Show("Cliente actualizado de forma éxitosa", "Cambio de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDocumentoPendienteEnviar();
                gvCambiarCliente.Visible = false;
            }
        }
        private void ObtenerCliente(string idCliente)
        {

            try
            {

                DataTable dtCliente = CapaNegocios.NClientes.buscar_Cat();
                ///llenamos la lista de clientes para los creditos.
                this.cmbCliente.DataSource = dtCliente;
                this.cmbCliente.ValueMember = "ID";
                this.cmbCliente.DisplayMember = "CLIENTE";
                this.cmbCliente.SelectedIndex = 0;
                this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                this.cmbCliente.Value = idCliente;
                 
            }
            catch (Exception)
            {

            } 
    }

    private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            gvCambiarCliente.Visible = false;
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPendienteSRI.Rows.Count > 0)
                {
                    lblIDVENTA.Text = this.gvPendienteSRI.Selected.Rows[0].Cells["IdVenta"].Value.ToString();
                    var idCliente = this.gvPendienteSRI.Selected.Rows[0].Cells["Id_Cliente"].Value.ToString();
                    gvCambiarCliente.Visible = true;
                    ObtenerCliente(idCliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            ugvComprobanteRetencion.DataSource = null;
            CargarDocumentoRetencionEnviadosSRI();
            sumar_totales_RETENCION();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvComprobanteRetencion.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.ugvComprobanteRetencion, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void ugvComprobanteRetencion_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
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
            catch (Exception) { }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            try
            {
                if (ugvComprobanteRetencion.Rows.Count > 0)
                {
                    DataTable dt = NParametrosSRI.buscar();
                    if (dt.Rows.Count > 0)
                    {
                        if (bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString()))
                        {
                            DateTime dtFinicioLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaDesde"].ToString());
                            DateTime dtFFinLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaHasta"].ToString());
                            var nombreComercial = dt.Rows[0]["NombreComercial"].ToString();

                            if (dtFinicioLicencia <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && dtFFinLicencia >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
                            {
                                var rutaXML = dt.Rows[0]["RutaXML"].ToString();
                                var CorreoSMTP = dt.Rows[0]["CorreoSMTP"].ToString();
                                var ContrasenaSMTP = dt.Rows[0]["ContrasenaSMTP"].ToString();
                                var nombres = this.ugvComprobanteRetencion.Selected.Rows[0].Cells["Proveedor"].Value.ToString();
                                var correo = this.ugvComprobanteRetencion.Selected.Rows[0].Cells["Correo"].Value.ToString();
                                var numFactura = this.ugvComprobanteRetencion.Selected.Rows[0].Cells["#Factura"].Value.ToString();
                                var claveAcceso = this.ugvComprobanteRetencion.Selected.Rows[0].Cells["ClaveAcceso"].Value.ToString();
                                var fechaAutorizacion = this.ugvComprobanteRetencion.Selected.Rows[0].Cells["Fecha_Registro"].Value.ToString();
                                var idRetencion = this.ugvComprobanteRetencion.Selected.Rows[0].Cells["Id"].Value.ToString();
                                /*Datos de cliente*/
                                ///DataTable dtCliente = NClientes.obtener_datos(int.Parse(idCliente));

                                gvCorreoRetencion.Visible = true; 
                                    if (correo.Trim().Length > 0)
                                    {
                                        SMTP.Mail mail = new SMTP.Mail();
                                        string style = "style=\"color:#020766;font-weight:bold;font-size: 18px;\"";
                                        StringBuilder sb = new StringBuilder();
                                        string subject = "COMPROBANTE ELECTRONICO DE RETENCIÓN";
                                        sb.Append("<html><head><title>COMPROBANTE ELECTRONICO DE RETENCIÓN</title></head><body>");
                                        sb.Append("<p " + style + ">Estimado proveedor: " + nombres.ToUpper() + "</p>");
                                        sb.Append("<p>Hemos emitido el siguiente comprobante electrónico de retención </p>");
                                        sb.Append("<p>Documento: RETENCIÓN </p>");
                                        sb.Append("<p>Número: " + numFactura.ToUpper() + " </p>");
                                        sb.Append("<p>Clave de acceso: " + claveAcceso + " </p>");
                                        sb.Append("<p>Fecha: " + fechaAutorizacion + " </p>");
                                        sb.Append("<p></p>");
                                        sb.Append("<p></p>");
                                        sb.Append("<p>Puede consultar los comprobantes electrónicos autorizados ingresando a: </p>");
                                        sb.Append("<p>https://srienlinea.sri.gob.ec/comprobantes-electronicos-internet/publico/validezComprobantes.jsf</p>");
                                        sb.Append("<p>Saludos Cordiales</p></body></html>");
                                        //Exportamos la factura a PDF
                                        AddFacturaRetencionPDF(idRetencion, numFactura);
                                        mail.SendEmail(correo, CorreoSMTP, CorreoSMTP, ContrasenaSMTP, subject, sb.ToString(), numFactura, claveAcceso, rutaXML);
                                        MessageBox.Show("Comprobante de retención enviado de forma éxitosa al email: " + correo, "Comprobante enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   
                                }
                                else
                                {
                                    MessageBox.Show("No se encontro correo del proveedor: " + nombres + ". Favor verificar", "No se encontro el correo proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Licencia de servicio SRI en " + cGeneral.name_system + " no esta VIGENTE. Contactar con el administrador para su renovación.", "Servicio SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Servicio del SRI a nivel de " + cGeneral.name_system + " esta INACTIVO. Contactar con el administrador para verificar la vigencia de la LICENCIA.", "Servicio SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                gvCorreoRetencion.Visible = false;
                MessageBox.Show("Ocurrio un error al intentar enviar el comprobante por correo: " + ex.Message.ToString(), "Error al enviar el comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            gvCorreoRetencion.Visible = false;
        }

        public void print_comprobante_sri(string idVenta, string impresora)
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();
                if (impresora == "Logic Control")
                {
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptComprobanteSRI_BaucherSRI.rpt");

                }
                else if (impresora == "EPSON")
                {
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptComprobanteSRI_Baucher.rpt");
                }
                else
                {
                    MessageBox.Show("No hay un formato de impresora para el tickets configurado", "No hay ningún formato configurado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Set DataBase Login Info
                myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                {
                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                    if (logOnInfo != null)
                    {
                        logOnInfo.TableName = table.Name;
                        logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                        logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                        logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                        logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                        table.ApplyLogOnInfo(logOnInfo);
                    }
                }
                //Provide parameter values
                myReportDocument.SetParameterValue("@id", idVenta);
                myReportDocument.SetParameterValue("printpago", "SI");

                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = cGeneral.Impresora;
                bool ImpresoraValida = ps.IsValid;
                ps.Copies = 1;
                PageSettings pg = new PageSettings();
                pg.PrinterSettings = ps;
                myReportDocument.PrintToPrinter(ps, pg, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error al imprimir el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cGeneral.error(ex);
            }
        }
        private void AddFacturaPDF(string idVenta, string nofactura)
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();
                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptFacturaComprobanteSRI.rpt");
                //Set DataBase Login Info
                myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                {
                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                    if (logOnInfo != null)
                    {
                        logOnInfo.TableName = table.Name;
                        logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                        logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                        logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                        logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                        table.ApplyLogOnInfo(logOnInfo);
                    }
                }
                //Provide parameter values
                myReportDocument.SetParameterValue("@id", idVenta);
                //exporta el pdf
                DiskFileDestinationOptions filedest = new DiskFileDestinationOptions();
                ExportOptions o = new ExportOptions();
                o = new ExportOptions();
                o.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                o.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                filedest.DiskFileName = System.IO.Directory.GetCurrentDirectory() + "\\" + nofactura + ".pdf";

                o.ExportDestinationOptions = filedest;
                myReportDocument.Export(o);
                filedest = null;
                o = null;
                myReportDocument.Dispose();
                myReportDocument = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error al descargar el PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cGeneral.error(ex);
            }
        }
        private void AddFacturaRetencionPDF(string idRetencion,string nofactura)
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();
                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptFacturaComprobanteRetencionSRI.rpt");
                //Set DataBase Login Info
                myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                {
                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                    if (logOnInfo != null)
                    {
                        logOnInfo.TableName = table.Name;
                        logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                        logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                        logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                        logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                        table.ApplyLogOnInfo(logOnInfo);
                    }
                }
                //Provide parameter values
                myReportDocument.SetParameterValue("@id", idRetencion);
                //exporta el pdf
                DiskFileDestinationOptions filedest = new DiskFileDestinationOptions();
                ExportOptions o = new ExportOptions();
                o = new ExportOptions();
                o.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                o.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                filedest.DiskFileName = System.IO.Directory.GetCurrentDirectory() + "\\" + nofactura + ".pdf";

                o.ExportDestinationOptions = filedest;
                myReportDocument.Export(o);
                filedest = null;
                o = null;
                myReportDocument.Dispose();
                myReportDocument = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error al descargar el PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cGeneral.error(ex);
            }
        }
        public void sumar_totales_ventas_enviados()
        {
            try
            {
                gvEnviadosSRI.Refresh();
                gvEnviadosSRI.Update();
                gvEnviadosSRI.Rows[0].Activate();
                gvEnviadosSRI.EndUpdate();

                UltraGridBand band = this.gvEnviadosSRI.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[10]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary2 = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary2.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary3 = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary3.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary4 = band.Summaries.Add(SummaryType.Sum, band.Columns[13]);
                summary4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary4.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary5 = band.Summaries.Add(SummaryType.Sum, band.Columns[14]);
                summary5.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary5.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary6 = band.Summaries.Add(SummaryType.Sum, band.Columns[15]);
                summary6.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary6.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary7 = band.Summaries.Add(SummaryType.Sum, band.Columns[16]);
                summary7.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary7.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary8 = band.Summaries.Add(SummaryType.Sum, band.Columns[17]);
                summary8.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary8.DisplayFormat = "${0:##,###0.00}";

                ///summary.Appearance.TextHAlign = HAlign.Right;
                //summary.Appearance.ForeColor = Color.White;
                //summary.Appearance.BackColor = Color.LightBlue;
                //summary.Appearance.FontData.Bold = DefaultableBoolean.True;

                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.DodgerBlue;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DodgerBlue;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "TOTALES VENTA $:";


            }
            catch (Exception) { }
        }
        public void sumar_totales_RETENCION()
        {
            try
            {
                ugvComprobanteRetencion.Refresh();
                ugvComprobanteRetencion.Update();
                ugvComprobanteRetencion.Rows[0].Activate();
                ugvComprobanteRetencion.EndUpdate();

                UltraGridBand band = this.ugvComprobanteRetencion.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[9]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary2 = band.Summaries.Add(SummaryType.Sum, band.Columns[10]);
                summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary2.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary3 = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary3.DisplayFormat = "${0:##,###0.00}";

                //SummarySettings summary2 = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                //summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary2.DisplayFormat = "${0:##,###0.00}";

                //SummarySettings summary3 = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                //summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary3.DisplayFormat = "${0:##,###0.00}";


                //SummarySettings summary4 = band.Summaries.Add(SummaryType.Sum, band.Columns[13]);
                //summary4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary4.DisplayFormat = "${0:##,###0.00}";


                //SummarySettings summary5 = band.Summaries.Add(SummaryType.Sum, band.Columns[14]);
                //summary5.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary5.DisplayFormat = "${0:##,###0.00}";


                //SummarySettings summary6 = band.Summaries.Add(SummaryType.Sum, band.Columns[15]);
                //summary6.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary6.DisplayFormat = "${0:##,###0.00}";


                //SummarySettings summary7 = band.Summaries.Add(SummaryType.Sum, band.Columns[16]);
                //summary7.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary7.DisplayFormat = "${0:##,###0.00}";


                //SummarySettings summary8 = band.Summaries.Add(SummaryType.Sum, band.Columns[17]);
                //summary8.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary8.DisplayFormat = "${0:##,###0.00}";

                ///summary.Appearance.TextHAlign = HAlign.Right;
                //summary.Appearance.ForeColor = Color.White;
                //summary.Appearance.BackColor = Color.LightBlue;
                //summary.Appearance.FontData.Bold = DefaultableBoolean.True;

                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.DodgerBlue;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DodgerBlue;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "TOTALES RETENCIÓN $:";


            }
            catch (Exception) { }
        }
        public void sumar_totales_Ventas_pendientes()
        {
            try
            {
                gvPendienteSRI.Refresh();
                gvPendienteSRI.Update();
                gvPendienteSRI.Rows[0].Activate();
                gvPendienteSRI.EndUpdate();
                 
                UltraGridBand band = this.gvPendienteSRI.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[8]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary2 = band.Summaries.Add(SummaryType.Sum, band.Columns[9]);
                summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary2.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary3 = band.Summaries.Add(SummaryType.Sum, band.Columns[10]);
                summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary3.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary4 = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                summary4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary4.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary5 = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                summary5.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary5.DisplayFormat = "${0:##,###0.00}";


                SummarySettings summary6 = band.Summaries.Add(SummaryType.Sum, band.Columns[13]);
                summary6.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary6.DisplayFormat = "${0:##,###0.00}";

                SummarySettings summary7 = band.Summaries.Add(SummaryType.Sum, band.Columns[14]);
                summary7.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary7.DisplayFormat = "${0:##,###0.00}";


                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.DodgerBlue;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DodgerBlue;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "TOTALES VENTAS $:";


            }
            catch (Exception) { }
        }
    }
}
