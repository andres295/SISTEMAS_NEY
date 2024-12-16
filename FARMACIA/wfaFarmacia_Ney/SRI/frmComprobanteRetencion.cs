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
using wfaFarmacia_Ney.Globales;
using wfaFarmacia_Ney.WsSRIComprobanteElectronico;

namespace wfaFarmacia_Ney.SRI
{
    public partial class frmComprobanteRetencion : Form
    {
        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE

        public frmComprobanteRetencion()
        {
            InitializeComponent();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            cbTipoDocumento.SelectedIndex = 0;
            cmbImpuestoRetener.SelectedIndex = 0;
            cbTipoDocumento.Enabled = false;
            this.cmbValorImpuesto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            NSriRetenciones.Delete_Det_TMP_Retenciones(cGeneral.id_user_actual);
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
                var lsRetenciones = NSriRetenciones.Cargar_PorcentajeRENTA(0);
                cmbValorImpuesto.DataSource = lsRetenciones;
                cmbValorImpuesto.ValueMember = "Id";
                cmbValorImpuesto.DisplayMember = "Descripcion";
            }
            else if (cmbImpuestoRetener.Value.ToString() == "2")
            {
                var lsRetenciones = NSriRetenciones.Cargar_PorcentajeIva(0);
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
                            DataTable lsRetenciones = NSriRetenciones.Cargar_PorcentajeRENTA(int.Parse(cmbValorImpuesto.Value.ToString()));
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
                            DataTable lsRetenciones = NSriRetenciones.Cargar_PorcentajeIva(int.Parse(cmbValorImpuesto.Value.ToString()));
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

                NSriRetenciones.Agregar_det_tmp_retencion(cmbImpuestoRetener.Value.ToString(), int.Parse(cmbValorImpuesto.Value.ToString()), nudPorcRetencion.Value, nudBaseImponible.Value, nudValorRetenido.Value, cGeneral.id_user_actual);
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
                bsRetenciones.DataSource = NSriRetenciones.Obtener_Det_TMP_Retenciones(cGeneral.id_user_actual);
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
                    NSriRetenciones.Delete_Det_TMP_Retenciones_by_id(id);
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
                gvSRI.Visible = true;
                DialogResult resul = MessageBox.Show("Está seguro(a) que desea agregar la retención a la factura #: " + lbldFactura.Text + " ?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                DataTable dtParametrosSRI = NParametrosSRI.buscar(); 
                if (dtParametrosSRI.Rows.Count>0)
                {
                   
                    vnumDocSustento = dtParametrosSRI.Rows[0]["Codestablecimiento"].ToString() + "" + dtParametrosSRI.Rows[0]["Codpuntoemision"].ToString() ;
                    vcodDocSustento = dtParametrosSRI.Rows[0]["CodDocSustento"].ToString();
                    if (vcodDocSustento.Length <= 0)
                    {
                        MessageBox.Show("El CodDocSustento no esta configurado en los parametros del SRI", "CodDocSustento no configurado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro parametros de configuracion de SRI", "No hay parametros de cofiguración de SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /*Se valida si existe proveedor para la retención*/
                DataTable dtProveedor = NProveedores.obtener_datos(int.Parse(cmbProveedor.Value.ToString()));
                if (dtProveedor.Rows.Count > 0)
                {
                    try
                    {
                        var tipoIdentificacion = NTipoIdentificacion.Obtener_Tipo_Identificacion_by_id(int.Parse(dtProveedor.Rows[0]["TipoIdentifiacion"].ToString()));
                        if (tipoIdentificacion.Rows.Count > 0)
                        {
                            tipoIdentificacionRetenedor = tipoIdentificacion.Rows[0]["Codigo"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("El proveedor no tiene un tipo identificacion valido para poder enviar al SRI", "Proveedor no tiene tipo identificacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El proveedor no tiene un tipo identificacion valido para poder enviar al SRI", "Proveedor no tiene tipo identificacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                    razonSocialRetenedor = dtProveedor.Rows[0]["Proveedor"].ToString();
                    numIdentificacionRetenedor = dtProveedor.Rows[0]["RUC"].ToString();
                    dirComprador = dtProveedor.Rows[0]["Direccion"].ToString();
                    correo = dtProveedor.Rows[0]["Correo"].ToString();
                    telefono = dtProveedor.Rows[0]["Telefono"].ToString();

                    if (tipoIdentificacionRetenedor.Length <= 0)
                    {
                        MessageBox.Show("No se encontró tipo de documento para el proveedor: " + cmbProveedor.Text, "No se encontro tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (numIdentificacionRetenedor.Length <= 0)
                    {
                        MessageBox.Show("Proveedor no tiene un número de documento valido: " + cmbProveedor.Text, "Número de documento no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro proveedor.");
                    return;
                }

                DataTable dt = NSriRetenciones.Agregar_Retencion(dtFecha.Value, int.Parse(cmbProveedor.Value.ToString()), dtFechaEmisionDocumento.Value, cbTipoDocumento.Text, lbldFactura.Text, dtPeriodoFiscal.Value, cGeneral.id_user_actual);

                /*Se valida si la retención se agrego con éxito*/
                if (dt.Rows.Count > 0)
                {
                    int idProveedor = int.Parse(cmbProveedor.Value.ToString());
                    int idRetencion = int.Parse(dt.Rows[0]["IdRetencion"].ToString());
                    string numComprobante = dt.Rows[0]["NumComprobante"].ToString();
                    vnumDocSustento = vnumDocSustento + "" + numComprobante;
                    string periodoFisacal = dtPeriodoFiscal.Value.Month<=9?"0" + dtPeriodoFiscal.Value.Month.ToString() + '/' + dtPeriodoFiscal.Value.Year.ToString(): dtPeriodoFiscal.Value.Month.ToString() + '/' + dtPeriodoFiscal.Value.Year.ToString();

                    List<DetalleImpuestosRetencion> vDetalleImpuestosRetencion = new List<DetalleImpuestosRetencion>();
                    List<DetalleInfoAdicional> vDetalleInfoAdicional = new List<DetalleInfoAdicional>();

                    DataTable dtDetRetencion = NSriRetenciones.Obtener_Det_Retenciones(idRetencion);

                    /*Se valida si la retención tiene detalles*/
                    /*Se agrega detalle de retención*/
                    if (dtDetRetencion.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDetRetencion.Rows)
                        {
                            /*Se asignan valores de items de producto facturados*/
                            vDetalleImpuestosRetencion.Add(new DetalleImpuestosRetencion
                            {
                                codigo = row["codigo"].ToString(),
                                codigoRetencion = row["codigoRetencion"].ToString(),
                                baseImponible = decimal.Parse(row["baseImponible"].ToString()),
                                porcentajeRetener = decimal.Parse(row["porcentajeRetener"].ToString()),
                                valorRetenido = decimal.Parse(row["valorRetenido"].ToString()),
                                codDocSustento = vcodDocSustento,
                                numDocSustento = vnumDocSustento,///lbldFactura.Text,
                                fechaEmisionDocSustento = dtFechaEmisionDocumento.Value.ToString("dd/MM/yyyy")

                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen retenciones agregadas  a la FACTURA #" + lbldFactura.Text, "No existen retenciones en FACTURA" + idProveedor, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gvSRI.Visible = false;
                        return;
                    }

                    /*Se agregan detalles adicionales*/
                    /*Se asignan valores de items de producto facturados*/
                    /*Adicional: 1*/
                    vDetalleInfoAdicional.Add(new DetalleInfoAdicional
                    {
                        Nombre = "Número Factiura",
                        Valor = lbldFactura.Text

                    });
                    vDetalleInfoAdicional.Add(new DetalleInfoAdicional
                    {
                        Nombre = "Direccion",
                        Valor = dirComprador

                    });
                    /*Adicional: 2*/
                    vDetalleInfoAdicional.Add(new DetalleInfoAdicional
                    {
                        Nombre = "Correo",
                        Valor = correo

                    });
                    /*Adicional: 3*/
                    vDetalleInfoAdicional.Add(new DetalleInfoAdicional
                    {
                        Nombre = "Teléfono",
                        Valor = telefono

                    });

                    /*Enviar comprobante a SRI*/
                    SRI.Model.SriServices sriService = new Model.SriServices();
                    string refNoFactura = "", refAmbiente = "", refTipoEmision = "", refImpresora = "";
                    var responseSRI = sriService.AutorizacionRetencion(dtFecha.Value.ToString("dd/MM/yyyy"), tipoIdentificacionRetenedor, numComprobante, razonSocialRetenedor, numIdentificacionRetenedor, dirComprador, periodoFisacal, vDetalleImpuestosRetencion.ToArray(), vDetalleInfoAdicional.ToArray(), ref refNoFactura, ref refAmbiente, ref refTipoEmision, ref refImpresora);
                    if (responseSRI != null)
                    {

                        /*Se valida resultado de SERVICIO: SRI*/
                        if (responseSRI.MensajeErrorInterno.Length > 0)
                        {
                            NSriRetenciones.DeleteRetencion(idRetencion);
                            MessageBox.Show(responseSRI.MensajeErrorInterno, "Error al ejecutar servicio del SRI - LOCAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            gvSRI.Visible = false;
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
                                        autorizada = true;
                                        gvSRI.Visible = false;
                                        var result = NSriRetenciones.UpdateClaveAccesoRetencion(idRetencion, responseSRI.ClaveAcceso);
                                        if (result)
                                        {
                                            gvSRI.Visible = false;
                                            MessageBox.Show("Estado: " + item.estado + ". El SRI ha autorizado con éxito el comprobante de retención #" + numComprobante + " generando el número de clave de acceso:" + responseKey.claveAccesoConsultada +". Si desea enviar este comprobante por correo tiene que ir a la bandeja de retenciones y ahi lo podria enviar al proveedor.", "Retención enviada al SRI con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Close();
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
                                    NSriRetenciones.DeleteRetencion(idRetencion);
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
                                                autorizada = true;
                                                gvSRI.Visible = false;
                                                var result = NSriRetenciones.UpdateClaveAccesoRetencion(idRetencion, responseSRI.ClaveAcceso);
                                                if (result)
                                                {
                                                    gvSRI.Visible = false;
                                                    MessageBox.Show("Estado: " + item.estado + ". El SRI ha autorizado con éxito el comprobante de retención #" + numComprobante + " generando el número de clave de acceso:" + responseKey.claveAccesoConsultada + ". Si desea enviar este comprobante por correo tiene que ir a la bandeja de retenciones y ahi lo podria enviar al proveedor.", "Retención enviada al SRI con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.Close();
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
                                            NSriRetenciones.DeleteRetencion(idRetencion);
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
                                        NSriRetenciones.DeleteRetencion(idRetencion);
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
                                    NSriRetenciones.DeleteRetencion(idRetencion);
                                    MessageBox.Show("El SRI NO AUTORIZADO el comprobante. Detalle del rechazo:" + mensajesSRI, "Rechazo de comprobante en SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    gvSRI.Visible = false;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            NSriRetenciones.DeleteRetencion(idRetencion);
                            MessageBox.Show("Ocurrio un error al intentar enviar el comprobante al SRI. Detalle del error:" + responseSRI.MensajeErrorInterno, "Error de envio de comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            gvSRI.Visible = false;
                            return;
                        }
                    } 
                } 
            }
            else
            {

                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No se puede agregar la retención porque esta no tiene un detalle. Favor ingresar minimo un tipo de retención para continuar.", this.btnGuardar, 0, 38, 3000);
                this.cmbImpuestoRetener.Focus();
                gvSRI.Visible = false;
                return;
            }
        }
    }
}
