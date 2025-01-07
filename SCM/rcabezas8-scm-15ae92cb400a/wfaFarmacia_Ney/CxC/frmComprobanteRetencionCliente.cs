using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using SCM.Globales;
using SCM.WsSRIComprobanteElectronico;

namespace SCM.CxC
{
    public partial class frmComprobanteRetencionCliente : Form
    {
        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE

        public frmComprobanteRetencionCliente()
        {
            InitializeComponent();
        }

        private void frmComprobanteRetencionCliente_Load(object sender, EventArgs e)
        {
            cbTipoDocumento.SelectedIndex = 0;
            cmbImpuestoRetener.SelectedIndex = 0;
            cbTipoDocumento.Enabled = false;
            this.cmbValorImpuesto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            NRetencionesVenta.Delete_Det_TMP_Retenciones(cGeneral.id_user_actual);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbImpuestoRetener_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            cmbValorImpuesto.Text = "";
            //}
            //catch (Exception)  {   }
            nudValorRetenido.Value = 0;
            nudPorcRetencion.Value = 0;
            if (cmbImpuestoRetener.Value.ToString() == "1")
            {
                var lsRetenciones = NRetencionesVenta.Cargar_PorcentajeRENTA(0);
                cmbValorImpuesto.DataSource = lsRetenciones;
                cmbValorImpuesto.ValueMember = "Id";
                cmbValorImpuesto.DisplayMember = "Descripcion";
            }
            else if (cmbImpuestoRetener.Value.ToString() == "2")
            {
                var lsRetenciones = NRetencionesVenta.Cargar_PorcentajeIva(0);
                cmbValorImpuesto.DataSource = lsRetenciones;
                cmbValorImpuesto.ValueMember = "Id";
                cmbValorImpuesto.DisplayMember = "Descripcion";
            }
            else
            {
                cmbValorImpuesto.DataSource = null;
                MessageBox.Show("Debe seleccionar un impuesto valido.", "Invalido tipo impuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbValorImpuesto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbValorImpuesto.Text != "")
                {
                    if (cmbImpuestoRetener.Value.ToString() == "1")
                    {
                        try
                        {
                            DataTable lsRetenciones = NRetencionesVenta.Cargar_PorcentajeRENTA(int.Parse(cmbValorImpuesto.Value.ToString()));
                            nudPorcRetencion.Value = decimal.Parse(lsRetenciones.Rows[0]["PorcRetencion"].ToString());
                            calcularMontoRetencion();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("No es posible obtener el porcentaje de renta: " + ex.Message.ToString(), "Error al obtener porcentaje de renta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            nudPorcRetencion.Value = 0;
                        }

                    }
                    else if (cmbImpuestoRetener.Value.ToString() == "2")
                    {
                        try
                        {
                            DataTable lsRetenciones = NRetencionesVenta.Cargar_PorcentajeIva(int.Parse(cmbValorImpuesto.Value.ToString()));
                            nudPorcRetencion.Value = decimal.Parse(lsRetenciones.Rows[0]["Porcentaje"].ToString());
                            calcularMontoRetencion();
                        }
                        catch (Exception ex)
                        {
                            ///MessageBox.Show("No es posible obtener el porcentaje de IVA: " + ex.Message.ToString(), "Error al obtener porcentaje de IVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            nudPorcRetencion.Value = 0;
                        }

                    }
                    else
                    {
                        nudPorcRetencion.Value = 0;
                    }
                }
                else
                {
                    nudPorcRetencion.Value = 0;
                }
            }
            catch (Exception) { }
        }

        private void nudBaseImponible_ValueChanged(object sender, EventArgs e)
        {

        }
        private void calcularMontoRetencion()
        {
            try
            {
                if (nudPorcRetencion.Value > 0)
                {
                    if (nudBaseImponible.Value > 0)
                    {
                        nudValorRetenido.Value = decimal.Round(decimal.Parse((nudBaseImponible.Value * (nudPorcRetencion.Value / 100)).ToString()), 2);
                    }
                    else
                    {
                        nudValorRetenido.Value = 0;
                    }
                }
                else
                {
                    ///MessageBox.Show("No hay un porcentaje para calcular el valor de la retención, Seleccione el tipo de retencion y su valor de porcentaje", "No hay porcentaje de retención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudValorRetenido.Value = 0;
                }
            }
            catch (Exception)
            {
                nudValorRetenido.Value = 0;
            }
        }

        private void nudBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (nudBaseImponible.Value >0)
            //{
            //    cmbImpuestoRetener.Enabled = true;
            //}
            //else
            //{
            //    cmbImpuestoRetener.Enabled = false;
            //}
            ////calcularMontoRetencion();
        }

        private void btnAddRetencion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.nudValorRetenido.Value <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("El monto de la retención debe de ser mayor a cero.", this.btnAddRetencion, 0, 38, 3000);
                    this.nudValorRetenido.Focus();
                    return;
                }

                if (uGridDetalleRetencion.Rows.Count > 0)
                {
                    for (int i = 0; i < uGridDetalleRetencion.Rows.Count; i++)
                    {
                        string ImpuestoRetener = uGridDetalleRetencion.Rows[i].Cells["ImpuestoRetener"].Value.ToString();
                        if (ImpuestoRetener == cmbImpuestoRetener.Text)
                        {
                            this.ttMensaje.ToolTipTitle = "DATOS DUPLICADOS";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ya tiene agregado una retención de tipo: " + ImpuestoRetener, this.btnAddRetencion, 0, 38, 3000);
                            this.nudValorRetenido.Focus();
                            return;
                        }
                    }
                }

                NRetencionesVenta.Agregar_det_tmp_retencion(cmbImpuestoRetener.Value.ToString(), int.Parse(cmbValorImpuesto.Value.ToString()), nudPorcRetencion.Value, nudBaseImponible.Value, nudValorRetenido.Value, cGeneral.id_user_actual);
                cargarDetRetenciones();
                sumar_totales();
            }
            catch (Exception)
            {
                MessageBox.Show("Revise los datos de la retención que desea añadir. Hay algún dato que falta.", "Ingrese datos de retención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void sumar_totales()
        {
            try
            {
                uGridDetalleRetencion.Refresh();
                uGridDetalleRetencion.Update();
                uGridDetalleRetencion.Rows[0].Activate();
                uGridDetalleRetencion.EndUpdate();

                UltraGridBand band = this.uGridDetalleRetencion.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[5]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                ///summary.Appearance.TextHAlign = HAlign.Right;
                summary.Appearance.ForeColor = Color.White;
                summary.Appearance.BackColor = Color.ForestGreen;
                summary.Appearance.FontData.Bold = DefaultableBoolean.True;

                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.ForestGreen;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.ForestGreen;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "TOTALES RETENCIÓN $:";

            }
            catch (Exception) { }
        }
        private void cargarDetRetenciones()
        {
            try
            {
                uGridDetalleRetencion.DataSource = null;
                bsRetenciones.DataSource = NRetencionesVenta.Obtener_Det_TMP_Retenciones(cGeneral.id_user_actual);
                nvRetenciones.BindingSource = bsRetenciones;
                uGridDetalleRetencion.DataSource = bsRetenciones;
                uGridDetalleRetencion.DataBind();
            }
            catch (Exception) { }
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (uGridDetalleRetencion.Rows.Count > 0)
            {
                ///string id = uGridEgresos.Selected.Rows[0].Cells["Id"].Value.ToString();
                int id = int.Parse(uGridDetalleRetencion.ActiveRow.Cells["Id"].Value.ToString());
                if (id > 0)
                {
                    NRetencionesVenta.Delete_Det_TMP_Retenciones_by_id(id);
                    cargarDetRetenciones();
                }
            }
        }

        private void uGridDetalleRetencion_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

        private void nudBaseImponible_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calcularMontoRetencion();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (uGridDetalleRetencion.Rows.Count > 0)
            {
                #region("VARIABLES")
                string vnumDocSustento = "", vcodDocSustento ="", tipoIdentificacionRetenedor = "", razonSocialRetenedor = "", numIdentificacionRetenedor = "", dirComprador = "", correo = "", telefono = "";

                #endregion
                /*Se activa el process*/
                //gvSRI.Visible = true;
                DialogResult resul = MessageBox.Show("Está seguro(a) que desea agregar la retención a la factura #: " + lbldFactura.Text + " ?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                //DataTable dtParametrosSRI = NParametrosSRI.buscar(); 
                //if (dtParametrosSRI.Rows.Count>0)
                //{
                   
                //    vnumDocSustento = dtParametrosSRI.Rows[0]["Codestablecimiento"].ToString() + "" + dtParametrosSRI.Rows[0]["Codpuntoemision"].ToString() ;
                //    vcodDocSustento = dtParametrosSRI.Rows[0]["CodDocSustento"].ToString();
                //    if (vcodDocSustento.Length <= 0)
                //    {
                //        MessageBox.Show("El CodDocSustento no esta configurado en los parametros del SRI", "CodDocSustento no configurado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("No se encontro parametros de configuracion de SRI", "No hay parametros de cofiguración de SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                /*Se valida si existe proveedor para la retención*/
                DataTable dtCliente = NClientes.obtener_datos(int.Parse(cmbCliente.Value.ToString()));
                if (dtCliente.Rows.Count > 0)
                { 
                    razonSocialRetenedor = dtCliente.Rows[0]["Nombres_Apellidos"].ToString();
                    numIdentificacionRetenedor = dtCliente.Rows[0]["RUC"].ToString().Length>0? dtCliente.Rows[0]["RUC"].ToString():dtCliente.Rows[0]["Cedula"].ToString();
                    dirComprador = dtCliente.Rows[0]["Direccion"].ToString();
                    correo = dtCliente.Rows[0]["Correo"].ToString();
                    telefono = dtCliente.Rows[0]["Telefono"].ToString();  
                }
                else
                {
                    MessageBox.Show("No se encontro cliente.");
                    return;
                }

                DataTable dt = NRetencionesVenta.Agregar_Retencion(dtFecha.Value, int.Parse(cmbCliente.Value.ToString()), dtFechaEmisionDocumento.Value, cbTipoDocumento.Text, lbldFactura.Text, dtPeriodoFiscal.Value, cGeneral.id_user_actual);

                /*Se valida si la retención se agrego con éxito*/
                if (dt.Rows.Count > 0)
                {
                    string numComprobante = dt.Rows[0]["NumComprobante"].ToString();
                    MessageBox.Show("Comprobante de retención #" + numComprobante +" agregado con éxito.","Comprobante de retención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    for (int fila = 0; fila < frmCuentasPorCobrar.me.uGridFactura.Rows.Count; fila++)
                    {
                        if (lbldFactura.Text == frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[1].Value.ToString())
                        {
                            DataTable dt_datos = NCuentasPorCobrar.actualizar_fila_fact(lbldFactura.Text);

                            //frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[14].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString());
                            frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[15].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
                            //frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[16].Value = dt_datos.Rows[0].ItemArray[5].ToString();
                            frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[11].Value = dt_datos.Rows[0].ItemArray[6].ToString();
                            frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[12].Value = dt_datos.Rows[0].ItemArray[7].ToString();
                            break;
                        }
                    }
                    this.Close();
                }  
            }
            else
            {

                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No se puede agregar la retención porque esta no tiene un detalle. Favor ingresar minimo un tipo de retención para continuar.", this.btnGuardar, 0, 38, 3000);
                this.cmbImpuestoRetener.Focus();
                ///gvSRI.Visible = false;
                return;
            }
        }
    }
}
