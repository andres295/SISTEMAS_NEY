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

namespace SCM.Facturacion
{
    public partial class frmFacturaServicio_Acciones : Form
    {
        public int id_factura = 0;
        public bool frm_cliente = false;
        public string name_cliente = "";
        public bool addItemUSD = false;
        public bool addItemNIO = false;
        public int captar_id_cliente = 0;
        public bool cliente_seleccionado = false;
        public static frmFacturaServicio_Acciones me;
        public frmFacturaServicio_Acciones()
        {
            frmFacturaServicio_Acciones.me = this;
            InitializeComponent();
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool use_interno;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void print_factura(string id_factura)
        {
            try
            {
                if (this.dgvServiciosFacturar.Rows.Count > 0)
                {
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("factura_tickets");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.desde = 1;
                    frmReporte.hasta = cGeneral.numItem;
                    frmReporte.print_pago = "SI";
                    frmReporte.num_factura = id_factura;
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar(false);
        }
        private void click_guardar(bool key)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);
                if (cmbDoctor.Value is null)
                {
                    this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Tiene que seleccionar al especialista.", this.btnGuardar, 0, 38, 3000);
                    cmbDoctor.Focus();
                    return;
                }
                if (dgvServiciosFacturar.Rows.Count > 0)
                {
                    if (decimal.Parse(lblTotalPagar.Text) > 0)
                    {
                        if (this.accion == false)
                        {
                            if (this.captar_id_cliente == 0)
                            {
                                if (!key)
                                {
                                    DialogResult resul = MessageBox.Show("Está apunto de crear una nueva venta, pero todavía no se ha especificado al cliente.\n\n¿Desea especificarlo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        click_agregar(true, false);
                                    }
                                    if (resul == System.Windows.Forms.DialogResult.No)
                                    {
                                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);

                                        if (dtClinete.Rows.Count > 0)
                                        {
                                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                                            NFactura.actualizar_cliente(int.Parse(txtNumVenta.Text), this.captar_id_cliente);

                                            if (this.captar_id_cliente > 0)
                                            {
                                                Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
                                                frm.total_Pagar = lblTotalPagar.Text;
                                                frm.num_venta = txtNumVenta.Text;
                                                frm.captar_id_cliente = this.captar_id_cliente;
                                                frm.name_ventana = 4;
                                                frm.ShowDialog();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);

                                    if (dtClinete.Rows.Count > 0)
                                    {
                                        this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                                        NVentas.actualizar_cliente(int.Parse(txtNumVenta.Text), this.captar_id_cliente);

                                        if (this.captar_id_cliente > 0)
                                        {
                                            Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
                                            frm.total_Pagar = lblTotalPagar.Text;
                                            frm.num_venta = txtNumVenta.Text;
                                            frm.captar_id_cliente = this.captar_id_cliente;
                                            frm.name_ventana = 4;
                                            ///frm.cbEfectivo.Checked = true;
                                            frm.ShowDialog();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
                                frm.total_Pagar = lblTotalPagar.Text;
                                frm.num_venta = txtNumVenta.Text;
                                frm.captar_id_cliente = this.captar_id_cliente;
                                frm.name_ventana = 4;
                                frm.ShowDialog();
                            }

                        }
                        else
                        {
                            ///decimal descuento = obtener_descuento();
                            if (NFactura.modificar(Convert.ToInt32(frmFacturas.me.dgvServicios.ActiveRow.Cells[0].Value), "", decimal.Parse(lblSubtotal.Text), decimal.Parse(lblDescuento.Text), decimal.Parse(lblTotalPagar.Text), true))
                            {
                                txtBuscar.Text = "";
                                txtNumVenta.Text = "0";
                                cliente_seleccionado = false;
                                captar_id_cliente = 0;
                                dgvServicios.DataSource = null;
                                dgvServiciosFacturar.DataSource = null;
                                btnAgregarServicio.Enabled = false;
                                btnModificarServicio.Enabled = false;
                                btnEliminarServicio.Enabled = false;
                                btnGuardar.Enabled = false;
                                btnModificarCliente.Enabled = false;
                                btnEliminarFactura.Enabled = false;
                                btnCancelar.Enabled = false;
                                txtBuscar.Focus();

                            }
                        }
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FACTURACIÓN";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("No se puede facturar con monto a pagar menor o igual a cero.", this.btnGuardar, 0, 38, 3000);
                        return;
                    }

                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "FACTURACIÓN";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No hay servicios para agregar y facturar.", this.btnGuardar, 0, 38, 3000);
                    return;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
        private void frmFacturaServicio_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            delete_tem();
        }
        private void delete_tem()
        {
            try
            {
                if (int.Parse(txtNumVenta.Text) == 0)
                {
                    try
                    {
                        NFactura.quitar_todo_servicio_tem(txtNumVenta.Text, cGeneral.id_user_actual.ToString());
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void frmServicio_Acciones_Load(object sender, EventArgs e)
        {
            txtNumVenta.Text = id_factura.ToString();
            cEstilo_Grid est = new cEstilo_Grid();
            est.grid_selfull_con_alter(this.dgvServiciosFacturar);
            est.SetDoubleBuffered(this.dgvServiciosFacturar);
            cGeneral.ajuste_columnas(this.dgvServiciosFacturar);


            est.grid_selfull_con_alter(this.dgvServicios);
            est.SetDoubleBuffered(this.dgvServicios);
            cGeneral.ajuste_columnas(this.dgvServicios);

            cmbDoctor.DataSource = NEspecialista.lista_combo_by_estado(true);
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Doctor";

            this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
            this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
            this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
            this.cmbDoctor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbServicioEditar.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbDoctor.Focus();

            delete_tem();
            calcularTotales();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //// cargarServicio("FILTRO");
        }
        private void calcularTotales()
        {
            try
            {
                if (dgvServiciosFacturar.Rows.Count > 0)
                {
                    decimal subtotal = 0, descuento = 0, totalpagar = 0;

                    for (int i = 0; i < dgvServiciosFacturar.Rows.Count; i++)
                    {
                        subtotal += decimal.Parse(dgvServiciosFacturar.Rows[i].Cells[4].Value.ToString());
                        descuento += decimal.Parse(dgvServiciosFacturar.Rows[i].Cells[5].Value.ToString());
                        totalpagar += decimal.Parse(dgvServiciosFacturar.Rows[i].Cells[6].Value.ToString());
                    }

                    if (subtotal > 0)
                    {
                        lblSubtotal.Text = subtotal.ToString("N" + cGeneral.decimales_ventas + "");
                    }
                    else
                    {
                        lblSubtotal.Text = 0.ToString("N" + cGeneral.decimales_ventas + "");
                    }
                    if (descuento > 0)
                    {
                        lblDescuento.Text = descuento.ToString("N" + cGeneral.decimales_ventas + "");
                    }
                    else
                    {
                        lblDescuento.Text = 0.ToString("N" + cGeneral.decimales_ventas + "");
                    }
                    if (totalpagar > 0)
                    {
                        lblTotalPagar.Text = totalpagar.ToString("N" + cGeneral.decimales_ventas + "");
                    }
                    else
                    {
                        lblTotalPagar.Text = 0.ToString("N" + cGeneral.decimales_ventas + "");
                    }
                }
                else
                {
                    lblSubtotal.Text = 0.ToString("N" + cGeneral.decimales_ventas + "");
                    lblTotalPagar.Text = 0.ToString("N" + cGeneral.decimales_ventas + "");
                    lblDescuento.Text = 0.ToString("N" + cGeneral.decimales_ventas + "");
                }
            }
            catch (Exception) { }
        }
        private string obtener_concepto()
        {
            string concepto = "";
            try
            {
                if (dgvServiciosFacturar.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvServiciosFacturar.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            concepto = dgvServiciosFacturar.Rows[i].Cells[1].Value.ToString();
                        }
                        else
                        {
                            concepto = concepto + ", " + dgvServiciosFacturar.Rows[i].Cells[1].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception) { return ""; }
            return concepto;
        }
        //private decimal obtener_descuento()
        //{
        //    decimal subtotal = 0, descuento = 0;

        //    try
        //    {

        //        for (int i = 0; i < dgvServiciosFacturar.Rows.Count; i++)
        //        {
        //            subtotal += decimal.Parse(dgvServiciosFacturar.Rows[i].Cells[2].Value.ToString());
        //        }

        //        if (subtotal > 0)
        //        {
        //            if (cbDescuento.Checked)
        //            {
        //                descuento = (nudDescuento.Value * decimal.Parse("0.01")) * subtotal;
        //            }
        //            else
        //            {
        //                descuento = nudDescuento.Value;
        //            }

        //        }
        //        return descuento;
        //    }
        //    catch (Exception)
        //    {

        //        return 0; ;
        //    }
        //}
        private void dgvServicios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvServiciosFacturar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServiciosFacturar.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvServiciosFacturar.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServiciosFacturar.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServiciosFacturar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //this.dgvServicios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvServiciosFacturar.Columns[1].Width = 610;

                this.dgvServiciosFacturar.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvServiciosFacturar.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvServiciosFacturar.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvServiciosFacturar.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";


                this.dgvServiciosFacturar.Columns[0].Frozen = true;
                this.dgvServiciosFacturar.Columns[1].Frozen = true;


                this.dgvServiciosFacturar.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvServiciosFacturar.RowCount > 0)
                {
                    if (NFactura.quitar_servicio_tem(txtNumVenta.Text, this.dgvServiciosFacturar.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString()))
                    {
                        this.dgvServiciosFacturar.DataSource = NFactura.Obtener_servicio_tem(txtNumVenta.Text, cGeneral.id_user_actual.ToString());
                        calcularTotales();
                    }
                }
            }
            catch (Exception) { }
        }
        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            calcularTotales();
        }

        private void cbDescuento_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotales();
        }

        private void cbTipoFact_CheckedChanged(object sender, EventArgs e)
        {
            delete_tem();
            //if ( cbTipoFact.Checked)
            //{
            //    cbTipoFact.Text = "SERVICIO";
            //if (frm_cliente== false)
            //{
            //    cmbServicio.DataSource = NOrdenServicio.lista_combo("SERVICIO");
            //    cmbServicio.ValueMember = "Id";
            //    cmbServicio.DisplayMember = "Cliente";
            //}
            //else
            //{
            //    cmbServicio.DataSource = NOrdenServicio.lista_combo_by_name("SERVICIO",name_cliente);
            //    cmbServicio.ValueMember = "Id";
            //    cmbServicio.DisplayMember = "Cliente";
            //}

            //}
            //else {

            //    if (frm_cliente == false)
            //    {
            //        cbTipoFact.Text = "CONTRATO";
            //        cmbServicio.DataSource = NOrdenServicio.lista_combo(cbTipoFact.Text);
            //        cmbServicio.ValueMember = "Id";
            //        cmbServicio.DisplayMember = "Cliente";
            //    }
            //    else
            //    {
            //        cbTipoFact.Text = "CONTRATO";
            //        cmbServicio.DataSource = NOrdenServicio.lista_combo_by_name(cbTipoFact.Text,name_cliente);
            //        cmbServicio.ValueMember = "Id";
            //        cmbServicio.DisplayMember = "Cliente";
            //    }

            //}

            this.dgvServiciosFacturar.DataSource = null;
            calcularTotales();
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientes frm = new frmClientes();
                /// frm.MdiParent = this;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmEspecialista frm = new CentroMedico.frmEspecialista();
                /// frm.MdiParent = this;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnRefrescarDoctor_Click(object sender, EventArgs e)
        {
            this.cmbDoctor.DataSource = NEspecialista.lista_combo_by_estado(true);
            this.cmbDoctor.ValueMember = "Id";
            this.cmbDoctor.DisplayMember = "Doctor";
        }
        private void btnAgregarServicio_Click_1(object sender, EventArgs e)
        {
            agregar_servicio();
        }
        private void agregar_servicio()
        {
            try
            {
                if (cGeneral.permmiso_apartura_caja && cGeneral.si_caja_aperturada == false)
                {
                    DialogResult resul = MessageBox.Show("No puede vender sin APERTURAR CAJA.\n\n¿Desea aperturar caja ahora mismo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (resul == System.Windows.Forms.DialogResult.Yes)
                    {
                        Caja.frmAperturaCaja frm = new Caja.frmAperturaCaja();
                        frm.ShowDialog();
                        return;
                    }
                    else if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (cmbDoctor.Value is null)
                    {
                        this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Tiene que seleccionar al especialista.", this.btnGuardar, 0, 38, 3000);
                        cmbDoctor.Focus();
                        return;
                    }

                    decimal subTotal = 0;
                    string nombreServicio = "";

                    if (this.cliente_seleccionado == false)
                    {
                        this.txtNumVenta.Text = NVentas.obtener_num_venta().ToString();
                        this.captar_id_cliente = 0;
                        this.captar_id_cliente = 0;
                        this.cliente_seleccionado = true;
                    }
                    try
                    {

                        var service = NOrdenServicio.obtener_datos(int.Parse(this.dgvServicios.CurrentRow.Cells[0].Value.ToString()));
                        if (service.Rows.Count > 0)
                        {
                            subTotal = decimal.Parse(service.Rows[0]["Costo"].ToString());
                            nombreServicio = service.Rows[0]["Servicio"].ToString();
                        }
                    }
                    catch (Exception) { subTotal = 0; }

                    if (!NFactura.valida_servicio_factura_tem(this.txtNumVenta.Text, this.dgvServicios.CurrentRow.Cells[0].Value.ToString()))
                    {
                        if (NFactura.guardar_factura_tem(this.txtNumVenta.Text, this.dgvServicios.CurrentRow.Cells[0].Value.ToString(), "0", 1, subTotal, cGeneral.id_user_actual.ToString(), nombreServicio))
                        {
                            this.dgvServiciosFacturar.DataSource = NFactura.Obtener_servicio_tem(this.txtNumVenta.Text, cGeneral.id_user_actual.ToString());
                            btnCancelar.Enabled = true;
                            btnEliminarFactura.Enabled = true;
                            btnModificarCliente.Enabled = true;
                            calcularTotales();
                            txtBuscar.Text = "";
                            txtBuscar.Focus();
                        }
                        else
                        {
                            this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("El servicio seleccionado no es valido para agregar al detalle de la factura.", this.btnGuardar, 0, 38, 3000);
                            return;
                        }
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("El servicio seleccionado ya se encuentra incluido en esta factura.", this.btnGuardar, 0, 38, 3000);
                        return;
                    }
                } 
            }
            catch (Exception ex)
            {
                this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Error al intentar agregar servicio a la factura.", this.btnGuardar, 0, 38, 3000);
                this.txtBuscar.Focus();
                return;
            }
        }
        private void click_eliminar_item()
        {
            try
            {
                if (dgvServiciosFacturar.RowCount > 0)
                {
                    DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar éste servicio.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.txtBuscar.Focus();
                        return;
                    }

                    if (NFactura.quitar_servicio_tem(txtNumVenta.Text, this.dgvServiciosFacturar.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString()))
                    {
                        this.dgvServiciosFacturar.DataSource = NFactura.Obtener_servicio_tem(txtNumVenta.Text, cGeneral.id_user_actual.ToString());
                        calcularTotales();
                        if (this.dgvServiciosFacturar.Rows.Count == 0)
                        {
                            this.btnAgregarServicio.Enabled = false;
                            this.btnModificarServicio.Enabled = false;
                            this.btnEliminarServicio.Enabled = false;
                            this.btnGuardar.Enabled = false;

                            if (this.dgvServiciosFacturar.Rows.Count > 0)
                                this.txtBuscar.Focus();
                            else
                                this.txtBuscar.Focus();
                        }
                        else
                        {
                            this.dgvServiciosFacturar.Rows[this.dgvServiciosFacturar.CurrentRow.Index].Selected = true;
                            this.txtBuscar.Focus();
                        }

                        calcularTotales();
                    }
                }
                else
                {
                    MessageBox.Show("No hay servicio incluido para eliminar.", "Eliminar Servicio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception) { }
        }
        private void btnEliminarServicio_Click_1(object sender, EventArgs e)
        {
            click_eliminar_item();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmServicio frm = new CentroMedico.frmServicio();
                /// frm.MdiParent = this;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void click_modificar_item()
        {
            if (dgvServiciosFacturar.Rows.Count > 0)
            {
                DataTable dt = NFactura.Obtener_servicio_tem_by_id(this.dgvServiciosFacturar.CurrentRow.Cells[0].Value.ToString());

                if (dt.Rows.Count > 0)
                {
                    gbModificar.Visible = true;

                    cmbServicioEditar.DataSource = NServicio.lista_combo("TODOS");
                    cmbServicioEditar.ValueMember = "Id";
                    cmbServicioEditar.DisplayMember = "Servicio";
                    cmbServicioEditar.Value = dt.Rows[0]["Id_Orden"].ToString();

                    nudCantidadEditar.Value = decimal.Parse(dt.Rows[0]["Cantidad"].ToString());
                    nudDescuentoEditar.Value = decimal.Parse(dt.Rows[0]["Descuento"].ToString());
                    nudCantidadEditar.Focus();
                    this.nudCantidadEditar.Select(0, nudCantidadEditar.Value.ToString().Length);
                }
            }
        }

        private void btnModificarServicio_Click(object sender, EventArgs e)
        {
            click_modificar_item();
        }

        private void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            gbModificar.Visible = false;
        }

        private void btnSalirEditar_Click(object sender, EventArgs e)
        {
            gbModificar.Visible = false;
        }

        private void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            decimal subTotal = 0;
            string nombreServicio = "";
            try
            {
                if (nudCantidadEditar.Value <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La cantidad no puede ser menor a cero.", this.btnGuardarEditar, 0, 38, 3000);
                    this.nudCantidadEditar.Focus();
                    return;
                }

                try
                {
                    decimal valor = decimal.Parse(nudDescuentoEditar.Value.ToString());
                }
                catch (Exception ex)
                {
                    nudDescuentoEditar.Value = 0;
                }
            }
            catch (Exception) { }

            try
            {

                var service = NOrdenServicio.obtener_datos(int.Parse(this.cmbServicioEditar.Value.ToString()));
                if (service.Rows.Count > 0)
                {
                    subTotal = decimal.Parse(service.Rows[0]["Costo"].ToString());
                    nombreServicio = service.Rows[0]["Servicio"].ToString();
                }
            }
            catch (Exception) { subTotal = 0; }


            ///string concepto_servicio = NFactura.Obtener_Concepto_Orden(this.cmbServicio.Value.ToString());
            if (NFactura.update_factura_tem(this.dgvServiciosFacturar.CurrentRow.Cells[0].Value.ToString(), this.cmbServicioEditar.Value.ToString(), int.Parse(nudCantidadEditar.Value.ToString()), decimal.Parse(nudDescuentoEditar.Value.ToString()), subTotal))
            {
                this.dgvServiciosFacturar.DataSource = NFactura.Obtener_servicio_tem(txtNumVenta.Text, cGeneral.id_user_actual.ToString());
                nudCantidadEditar.Value = 1;
                gbModificar.Visible = false;
                calcularTotales();
                txtBuscar.Text = "";
                txtBuscar.Focus();
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("El servicio seleccionado no es valido para agregar al detalle de la factura.", this.btnGuardar, 0, 38, 3000);
                this.cmbServicioEditar.Focus();
                return;
            }
        }

        private void GuardarFactura()
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);
                //if (cmbCliente.Value is null)
                //{
                //    this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Tiene que seleccionar el cliente.", this.btnGuardar, 0, 38, 3000);
                //    cmbCliente.Focus();
                //    return;
                //}
                if (cmbDoctor.Value is null)
                {
                    this.ttMensaje.ToolTipTitle = "FACTURA DE SERVICIOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Tiene que seleccionar al especialista.", this.btnGuardar, 0, 38, 3000);
                    cmbDoctor.Focus();
                    return;
                }
                if (dgvServiciosFacturar.Rows.Count > 0)
                {
                    if (decimal.Parse(lblTotalPagar.Text) > 0)
                    {
                        if (this.accion == false)
                        {
                            if (this.cliente_seleccionado == false)
                            {
                                this.captar_id_cliente = 0;
                                this.cliente_seleccionado = true;
                            }

                            ///decimal descuento = obtener_descuento();
                            string num_factura = NFactura.guardar(txtNumVenta.Text, this.captar_id_cliente.ToString(), cmbDoctor.Value.ToString(), cGeneral.id_user_actual.ToString(), "", decimal.Parse(lblSubtotal.Text), decimal.Parse(lblDescuento.Text), decimal.Parse(lblTotalPagar.Text), cGeneral.TipoMoneda, cGeneral.TC,"1");

                            DialogResult resul = MessageBox.Show("Factura #" + txtNumVenta.Text + " fue generada con éxito.\n\n¿Desea proceder a generar el pago?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resul == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (num_factura.Length > 0)
                                {
                                    Facturacion.frmFacturas_Pagar_Efectivo frm = new Facturacion.frmFacturas_Pagar_Efectivo();
                                    frm.total_Pagar = lblTotalPagar.Text;
                                    frm.num_venta = num_factura;
                                    frm.captar_id_cliente = this.captar_id_cliente;
                                    frm.name_ventana = 1;
                                    frm.ShowDialog();
                                }
                            }
                            else
                            {
                                this.Close();
                                frmFacturas.me.txtBuscar.Text = "*";
                                frmFacturas.me.txtBuscar.Focus();
                            }
                        }
                        else
                        {
                            ///decimal descuento = obtener_descuento();
                            if (NFactura.modificar(Convert.ToInt32(frmFacturas.me.dgvServicios.ActiveRow.Cells[0].Value), "", decimal.Parse(lblSubtotal.Text), decimal.Parse(lblDescuento.Text), decimal.Parse(lblTotalPagar.Text), true))
                            {
                                frmFacturas.me.dgvServicios.DataSource = NFactura.buscar(frmFacturas.me.txtBuscar.Text, Convert.ToDateTime(frmFacturas.me.dtpDesde.Value), Convert.ToDateTime(frmFacturas.me.dtpHasta.Value),true);
                                this.Close();

                            }
                        }
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FACTURACIÓN";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("No se puede facturar con monto a pagar menor o igual a cero.", this.btnGuardar, 0, 38, 3000);
                        return;
                    }

                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "FACTURACIÓN";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No hay servicios para agregar y facturar.", this.btnGuardar, 0, 38, 3000);
                    return;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            click_agregar(false, false);
        }
        void click_agregar(bool pago_venta, bool cambio_cliente)
        {
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.Text = "SELECCIONE EL NOMBRE DEL CLIENTE";
            frm.pago_venta = pago_venta;
            frm.name_ventana = 4;
            frm.cambio_cliente = cambio_cliente;
            frm.ShowDialog();
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.Text = "CAMBIAR EL NOMBRE DEL CLIENTE";
            frm.name_ventana = 1;
            frm.ShowDialog();
        }

        private void btnEliminarFactura_Click(object sender, EventArgs e)
        {
            click_eliminar_venta();
        }
        void click_eliminar_venta()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta factura.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.txtBuscar.Focus();
                    return;
                }

                NFactura.eliminar_fact(Convert.ToInt32(int.Parse(txtNumVenta.Text)));
                this.dgvServiciosFacturar.DataSource = NVentas.cargar_prod(0);
                this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtNumVenta.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtBuscar.Text = "";
                click_cancelar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        public void click_cancelar()
        {
            try
            {
                this.btnCancelar.Enabled = false;
                this.btnAgregarCliente.Enabled = true;
                this.btnModificarCliente.Enabled = false;
                this.btnEliminarFactura.Enabled = false;
                this.cliente_seleccionado = false;
                this.captar_id_cliente = 0;
                ////this.captar_numventa = 0
                if (int.Parse(txtNumVenta.Text) > 0)
                {
                    NFactura.eliminar_fact(Convert.ToInt32(int.Parse(txtNumVenta.Text)));
                }
                this.Text = "FACTURACIÓN DE SERVICIOS MÉDICOS";
                this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtNumVenta.Text = Convert.ToDecimal(0).ToString("N0");
                this.dgvServicios.DataSource = NServicio.buscar("");
                this.dgvServicios.Refresh();

                this.dgvServiciosFacturar.DataSource = NFactura.Obtener_servicio_tem("-1", "0");
                this.dgvServiciosFacturar.Refresh();

                ////this.orden_prod(this.dgvProductos);
                this.calcularTotales();

                this.txtBuscar.Text = "";

                if (dgvServiciosFacturar.Rows.Count > 0)
                {
                    this.btnModificarServicio.Enabled = true;
                    this.btnEliminarServicio.Enabled = true;
                    this.btnGuardar.Enabled = true;
                }
                else
                {
                    this.btnModificarServicio.Enabled = false;
                    this.btnEliminarServicio.Enabled = false;
                    this.btnGuardar.Enabled = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text == "")
                {
                    if (this.dgvServicios.Rows.Count == 1)
                    {
                        DataTable dtFactura1 = NServicio.buscar_by_estado(this.txtBuscar.Text, true);
                        this.dgvServicios.DataSource = dtFactura1;
                        this.dgvServicios.Refresh();
                        return;
                    }

                    this.tBuscar.Enabled = false;
                    this.btnAgregarServicio.Enabled = true;
                    this.btnModificarServicio.Enabled = false;
                    this.btnEliminarServicio.Enabled = false;
                    this.btnAgregarServicio.Enabled = false;

                    DataTable dtFactura = NServicio.buscar_by_estado(this.txtBuscar.Text, true);
                    this.dgvServicios.DataSource = dtFactura;
                    this.dgvServicios.Refresh();

                    if (dgvServiciosFacturar.Rows.Count > 0)
                    {
                        this.btnModificarServicio.Enabled = true;
                        this.btnEliminarServicio.Enabled = true;
                        this.btnGuardar.Enabled = true;
                    }

                    this.txtBuscar.Focus();
                }
                else
                {

                    if (this.dgvServicios.Rows.Count == 1)
                    {
                        if (this.txtBuscar.Text == this.dgvServicios.CurrentRow.Cells[0].Value.ToString())
                        {
                            this.txtBuscar.Text = "";
                            return;
                        }
                    }

                    //if (cGeneral.validar_si_es_CB(this.txtBuscar.Text) && (cod_barra_scaner != this.txtBuscar.Text))
                    //{
                    //    if (this.dgvServicios.Rows.Count == 1)
                    //    {
                    //        if (this.txtBuscar.Text == this.dgvServicios.CurrentRow.Cells[0].Value.ToString())
                    //        {
                    //            this.txtBuscar.Text = "";
                    //            return;
                    //        }
                    //    }

                    //    DataTable dtFactura = NProductos.obtener_productos_venta(this.txtBuscar.Text, cGeneral.stock_producto);
                    //    this.dgvServicios.DataSource = dtFactura;
                    //    this.dgvServicios.Refresh();

                    //    if (this.dgvServicios.Rows.Count == 1)
                    //    {
                    //       //cod_barra_scaner = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                    //       // filtro_cod_barra_scaner = true;
                    //        this.txtBuscar.Text = "";

                    //      ////  click_agregar_prod();

                    //    }
                    //    else
                    //    {
                    //      ///  filtro_cod_barra_scaner = false;
                    //    }
                    //}
                    //else
                    //{
                    //cod_barra_scaner = "";
                    //filtro_cod_barra_scaner = false;
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                    ////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);

                    //}
                }
            }
            catch (Exception)
            {
                this.ttMensaje.Hide(this.txtBuscar);
                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("El dato a buscar no es un identificador de un producto.", this.txtBuscar, 0, 26, 3000);
                DataTable dtFactura = NServicio.buscar_by_estado(this.txtBuscar.Text, true);
                this.dgvServicios.DataSource = dtFactura;
                this.dgvServicios.Refresh();
                return;
            }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;
                this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Ingresar el nombre del servicio a buscar.", this.txtBuscar, 0, 26);
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)


        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar_Servicio();

                if (this.dgvServicios.Rows.Count == 1)
                {

                    e.SuppressKeyPress = true;
                    if (this.txtBuscar.Text != "")
                    {
                        agregar_servicio();
                    }

                }
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvServiciosFacturar.Rows.Count > 0)
                {
                    dgvServiciosFacturar.Rows[0].Selected = true;
                    dgvServiciosFacturar.Focus();
                }
            }
            else if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                click_guardar(true);
            }
            else if (e.KeyValue == cGeneral.f8)
            {
                Caja.frmEgresosDia frm = new Caja.frmEgresosDia();
                frm.ShowDialog();
            }
            else if (e.KeyValue == cGeneral.f9)
            {
                Ventas.frmPedidoProducto frm = new Ventas.frmPedidoProducto();
                frm.ShowDialog();
            }
            else
            if (e.KeyValue == cGeneral.f10)
            {
                if (this.dgvServicios.Rows.Count > 0)
                {
                    Ventas.frmSolicitaPrecioEspecial frm = new Ventas.frmSolicitaPrecioEspecial();
                    DataTable dt = NVentas.cargar_prod(int.Parse(txtNumVenta.Text));
                    bool producto_tiene_precio_especial = false;

                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][0].ToString() == this.dgvServicios.CurrentRow.Cells[0].Value.ToString() && int.Parse(dt.Rows[i][8].ToString()) > 0)
                            {
                                producto_tiene_precio_especial = true;
                            }
                        }
                    }
                    catch (Exception) { }

                    if (!producto_tiene_precio_especial)
                    {
                        decimal cantidad = 0;
                        DataTable dt_datos = NVentas.obtener_cantidad(int.Parse(txtNumVenta.Text), this.dgvServicios.CurrentRow.Cells[0].Value.ToString(), "");

                        if (dt_datos.Rows.Count > 0)
                        {
                            cantidad = decimal.Parse(dt_datos.Rows[0]["Vendio"].ToString());
                        }

                        frm.lblNameProducto.Text = this.dgvServicios.CurrentRow.Cells[1].Value.ToString();
                        frm.cantidad = cantidad;
                        frm.id_producto = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                        frm.id_det_venta = 0; ///int.Parse(this.dgvProductos.CurrentRow.Cells[7].Value.ToString());
                        frm.accion = true;
                        frm.id_venta = int.Parse(this.txtNumVenta.Text);
                        frm.name_ventana = 1;
                        frm.nudPrecioEspecial.Focus();
                        frm.nudPrecioEspecial.Select(0, frm.nudPrecioEspecial.Text.Length);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El producto " + this.dgvServicios.CurrentRow.Cells[1].Value.ToString() + " ya tiene un precio " + this.dgvServicios.CurrentRow.Cells[5].Value.ToString() + " especial aprobado, Si desea cambiar el precio aprobado tiene que eliminar este producto de carrito de compra y agrgarlo a la lista de ventas.", "Producto con precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else if (e.KeyValue == cGeneral.f11)
            {
                print_cotizacion();
            }
            else if (e.KeyValue == cGeneral.f2)
            {
                if (cGeneral.si_filtra_producto_por_composicion)
                {
                    Productos.frmBuscarProductoComposicion frm = new Productos.frmBuscarProductoComposicion();
                    frm.name_ventana = 1;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No tiene suficientes permiso para buscar productos por composición.", "Aviso de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.KeyValue == cGeneral.f3)
            {
                // click_nam_temp(false, true);
            }
            else if (e.KeyValue == cGeneral.f6)
            {
                if (this.dgvServicios.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                if (this.dgvServicios.RowCount > 0)
                {
                    Productos.frmDetProductoComposicion frm = new Productos.frmDetProductoComposicion();
                    frm.idProducto = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f4)
            {
                //if (this.dgvFacturas.RowCount > 0)
                //{
                Productos.frmDetProductoEspecificacion frm = new Productos.frmDetProductoEspecificacion();
                ////frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                frm.fuente = "venta";
                frm.name_ventana = 1;
                frm.ShowDialog();
                //}
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
        public void Buscar_Servicio()
        {
            try
            {

                this.tBuscar.Enabled = false;

                this.dgvServicios.DataSource = NServicio.buscar_by_estado(this.txtBuscar.Text, true);
                this.dgvServicios.Refresh();

                ////tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);

                if (this.dgvServicios.Rows.Count == 0)
                {
                    ///this.lblTotalPaginas.Text = string.Format("PAGINA 0 DE 0");

                    //this.pPaginacion.Enabled = false;
                    this.btnAgregarServicio.Enabled = false;
                    this.btnModificarServicio.Enabled = false;
                    this.btnEliminarServicio.Enabled = false;
                    this.btnAgregarServicio.Enabled = false;

                    if (dgvServicios.Rows.Count > 0)
                    {
                        this.btnAgregarServicio.Enabled = true;
                        this.btnModificarServicio.Enabled = true;
                        this.btnEliminarServicio.Enabled = true;
                        this.btnGuardar.Enabled = true;
                    }
                    else
                    {
                        this.btnAgregarServicio.Enabled = false;
                        this.btnModificarServicio.Enabled = false;
                        this.btnEliminarServicio.Enabled = false;
                        this.btnGuardar.Enabled = false;
                        this.btnGuardar.Enabled = false;
                    }

                    //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                    return;
                }

                this.btnAgregarCliente.Enabled = false;
                this.btnAgregarCliente.Enabled = true;
                this.btnEliminarFactura.Enabled = true;
                this.txtBuscar.Focus();
            }

            catch (Exception)
            {
                this.ttMensaje.Hide(this.txtBuscar);
                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("El dato a buscar no es un identificador de un producto.", this.txtBuscar, 0, 26, 3000);
                DataTable dtServicio = NServicio.buscar("");
                this.dgvServicios.DataSource = dtServicio;
                this.dgvServicios.Refresh();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            click_cancelar();
        }

        private void tCargarServicios_Tick(object sender, EventArgs e)
        {
            if (dgvServiciosFacturar.Rows.Count > 0)
            {
                this.txtRegistros.Text = Convert.ToDecimal(dgvServiciosFacturar.Rows.Count.ToString()).ToString("N0");
            }
        }

        private void dgvServicios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows[e.RowIndex].Cells[2].Value.ToString() == "0")
                    this.btnAgregarServicio.Enabled = false;
                else
                    this.btnAgregarServicio.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvServiciosFacturar_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvServiciosFacturar.Rows.Count > 0)
                {
                    dgvServiciosFacturar.Rows[0].Selected = true;
                    dgvServiciosFacturar.Focus();
                }
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                click_guardar(true);
            }
            else if (e.KeyValue == cGeneral.f8)
            {
                Caja.frmEgresosDia frm = new Caja.frmEgresosDia();
                frm.ShowDialog();
            }
            else if (e.KeyValue == cGeneral.f11)
            {
                print_cotizacion();
            }
            else if (e.KeyValue == 13)
            {
                click_modificar_item();
            }
            else if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
            else if (e.KeyValue == 46)
            {
                click_eliminar_item();
            }
            else if (e.KeyValue == 77)
            {
                this.btnModificarServicio.PerformClick();
            }
        }

        private void dgvServiciosFacturar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServiciosFacturar.Rows.Count > 0)
            {
                btnModificarServicio.Enabled = true;
                btnEliminarServicio.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnModificarServicio.Enabled = false;
                btnEliminarServicio.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void dgvServiciosFacturar_Enter(object sender, EventArgs e)
        {
            if (this.dgvServiciosFacturar.Rows.Count == 0)
                this.txtBuscar.Focus();
        }

        private void dgvServicios_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvServicios.Rows.Count > 0)
            {
                agregar_servicio();
            }
        }

        private void dgvServicios_Enter(object sender, EventArgs e)
        {
            if (this.dgvServicios.Rows.Count == 0)
            {
                this.txtBuscar.Focus();
            }
        }

        private void dgvServicios_KeyDown(object sender, KeyEventArgs e)
        {
            /// MessageBox.Show("Probando key:" + e.KeyValue.ToString());

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                agregar_servicio();
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvServiciosFacturar.Rows.Count > 0)
                {
                    dgvServiciosFacturar.Rows[0].Selected = true;
                    dgvServiciosFacturar.Focus();
                }
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                click_guardar(true);
            }
            else if (e.KeyValue == cGeneral.f8)
            {
                if (this.dgvServicios.RowCount > 0)
                {
                    Caja.frmEgresosDia frm = new Caja.frmEgresosDia();
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f11)
            {
                print_cotizacion();
            }
            else if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
        }

        private void nudCantidadEditar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardarEditar_Click(null, null);
            }
        }

        private void nudDescuentoEditar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardarEditar_Click(null, null);
            }
        }
        public void print_cotizacion()
        {
            try
            {
                if (!cGeneral.permiso_genera_cotizacion)
                {
                    MessageBox.Show("Usted no tiene permiso para generar e imprimir cotización", "No tiene permiso a cotizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.dgvServiciosFacturar.Rows.Count > 0)
                {
                    if (this.captar_id_cliente == 0)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);
                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NFactura.actualizar_cliente(int.Parse(txtNumVenta.Text), this.captar_id_cliente);
                            btnModificarCliente.Enabled = true;
                        }
                    }
                    DialogResult resul = MessageBox.Show("¿Desea imprimir la cotización de esta venta?.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.txtBuscar.Focus();
                        return;
                    }
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_cotizacion_servicio");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.desde = 1;
                    frmReporte.hasta = cGeneral.numItem;
                    frmReporte.print_pago = "NO";
                    frmReporte.num_factura = Convert.ToString(int.Parse(txtNumVenta.Text));
                    frmReporte.id_cliente = this.captar_id_cliente.ToString();
                    frmReporte.tipoVenta = "1";
                    frmReporte.Show();
                }
                else
                {
                    MessageBox.Show("No hay ningún producto agregado para imprimir la cotización", "Imprimir cotización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvServicios_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dgvServicios.Columns[2].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
        }
         
    }
}