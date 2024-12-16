using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney
{
    public partial class frmVentas_2 : Form
    {
        public static frmVentas_2 me;
        int dia_vencimiento = 0;
        public frmVentas_2()
        {
            frmVentas_2.me = this;
            InitializeComponent();
        }

        public int captar_id_cliente = 0;
        public bool cliente_seleccionado = false;
       ////public long captar_numventa = 0;
        bool filtro_cod_barra_scaner = false;
        string cod_barra_scaner = "";
        int number = 1, tamaño = 0;
        ////dcDatosDataContext bd = new dcDatosDataContext();

        public class campos
        {
            public string id { get; set; }
            public string prod { get; set; }
            public string pres { get; set; }
            public string prov { get; set; }
            public decimal pvf { get; set; }
            public decimal pvp { get; set; }
            public decimal desc { get; set; }
            public decimal pvpx { get; set; }
            public string disp { get; set; }
            public decimal pvfr { get; set; }
            public string est { get; set; }
        }
        public void cargar_totales(long id_venta)
        {
            try
            {
                DataTable dt_datos = NVentas.obtener_montos(id_venta);

                if (dt_datos.Rows.Count == 0)
                {
                    this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubTotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                }
                else
                {
                    Decimal subtotalSinImpuesto = 0;
                    if (dt_datos.Rows[0].ItemArray[0].ToString() == "")
                        this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    else
                        this.lblSubtotal.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[6].ToString()).ToString("N" + cGeneral.decimales_ventas + "");

                    if (dt_datos.Rows[0].ItemArray[1].ToString() == "")
                        this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    else
                        this.lblIVA.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales_ventas + "");

                    if (dt_datos.Rows[0].ItemArray[2].ToString() == "")
                        this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    else
                        this.lblDescuento.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales_ventas + "");

                    if (dt_datos.Rows[0].ItemArray[3].ToString() == "")
                        this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    else
                        this.lblTotalPagar.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales_ventas + "");

                    if (dt_datos.Rows[0].ItemArray[4].ToString() == "")
                    {
                        this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    } 
                    else
                    {
                        this.lblSubtotal_DP.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        subtotalSinImpuesto += Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
                    } 
                    if (dt_datos.Rows[0].ItemArray[5].ToString() == "")
                    {
                        this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    } 
                    else
                    {
                        this.lblSubtotal_CP.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[5].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        subtotalSinImpuesto += Convert.ToDecimal(dt_datos.Rows[0].ItemArray[5].ToString());
                    }
                    this.lblSubTotalSI.Text =  subtotalSinImpuesto.ToString("N" + cGeneral.decimales_ventas + "");
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden_prod(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
        }

        private void frmVentas_2_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                this.Text = this.Text + " - " + "Ventana #2";
                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.grid_selfree_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvProductos);

                this.tBuscar.Interval = cGeneral.timer;

                ////tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                DataTable dtFacturas = NProductos.obtener_productos_venta(this.txtBuscar.Text, cGeneral.stock_producto);

                this.dgvFacturas.DataSource = dtFacturas;

                this.dgvFacturas.Columns[0].HeaderText = "ID/CODIGO BARRA";
                this.dgvFacturas.Columns[1].HeaderText = "PRODUCTO";
                this.dgvFacturas.Columns[2].HeaderText = "PROVEEDOR";
                this.dgvFacturas.Columns[3].HeaderText = "STOCK";
                this.dgvFacturas.Columns[4].HeaderText = "PVP";
                this.dgvFacturas.Columns[5].HeaderText = "% DESC.";
                this.dgvFacturas.Columns[6].HeaderText = "PVPX";
                this.dgvFacturas.Columns[7].HeaderText = "PVFR";
                this.dgvFacturas.Columns[8].HeaderText = "TOTAL";
                this.dgvFacturas.Columns[9].HeaderText = "PROMOCION";
                this.dgvFacturas.Columns[10].Visible = false;

                this.dgvFacturas.Refresh();

                if (dtFacturas.Rows.Count > 0)
                {
                    this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                   //// this.orden_prod(this.dgvProductos);
                }
                this.cargar_totales(0);

                this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubTotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");



                this.lblIVA_Texto.Text = "IVA (" + cGeneral.IVA.ToString("N2") + "%):";
                this.label10.Text = "SUBTOTAL (" + cGeneral.IVA.ToString("N2") + "%):";
                if (!cGeneral.permiso_genera_cotizacion)
                {
                    lblF11.Visible = false;
                    lblF11Title.Visible = false;
                }
                cGeneral.ajuste_columnas(this.dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvProductos);

                if (this.txtRegistros.Text != "0")
                    this.txtBuscar.Focus();

                try
                {
                    int es_administrador = NUsuarios.es_administrador(cGeneral.id_user_actual);
                    if (es_administrador > 0)
                    {
                        btnPrintVenta.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    btnPrintVenta.Enabled = false;
                }
                 NVentas.limpia_tem(cGeneral.id_user_actual.ToString());
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            click_agregar(false,false);
        }

        void click_agregar(bool pago_venta,bool cambio_cliente)
        { 
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.Text = "SELECCIONE EL NOMBRE DEL CLIENTE";
            frm.pago_venta = pago_venta;
            frm.name_ventana = 2;
            frm.cambio_cliente = cambio_cliente;
            frm.ShowDialog();
        }
        void click_nam_temp(bool pago_venta, bool cambio_cliente)
        {
            Ventas.frmVentas_NombreTemp frm = new Ventas.frmVentas_NombreTemp();
            ////frm.Text = "SELECCIONE EL NOMBRE DEL CLIENTE";
            frm.pago_venta = pago_venta;
            frm.name_ventana = 2;
            frm.cambio_cliente = cambio_cliente;
            frm.ShowDialog();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.Text = "CAMBIAR EL NOMBRE DEL CLIENTE";
            frm.name_ventana = 2;
            frm.ShowDialog();
        }

        private void aplicar_color_productos_vencidos()
        {
            try
            {
                for (int i = 0; i < dgvFacturas.RowCount; i++)
                {
                    string s = dgvFacturas.Rows[i].Cells[10].Value.ToString();
                    if (bool.Parse(dgvFacturas.Rows[i].Cells[10].Value.ToString()))
                    {
                        dgvFacturas.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                    }
                }
            }
            catch (Exception) { }
        }
        public void Buscar_Producto()
        {
            try
            {
                if (!filtro_cod_barra_scaner)
                {
                    this.tBuscar.Enabled = false;
                    number = 1;

                    this.dgvFacturas.DataSource = NProductos.obtener_productos_venta(this.txtBuscar.Text, cGeneral.stock_producto);
                    this.dgvFacturas.Refresh();

                    aplicar_color_productos_vencidos();
                    ////tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);

                    if (this.dgvFacturas.Rows.Count == 0)
                    {
                        this.lblTotalPaginas.Text = string.Format("PAGINA 0 DE 0");

                        //this.pPaginacion.Enabled = false;
                        this.btnAgregar.Enabled = false;
                        this.btnModificar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnAgregarProd.Enabled = false;

                        if (dgvProductos.Rows.Count > 0)
                        {
                            this.btnModificarProd.Enabled = true;
                            this.btnEliminarProd.Enabled = true;
                            this.btnGuardar.Enabled = true;
                        }
                        else
                        {
                            this.btnModificarProd.Enabled = false;
                            this.btnEliminarProd.Enabled = false;
                            this.btnGuardar.Enabled = false;
                        }

                        //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                        return;
                    }

                    cod_barra_scaner = "";
                    filtro_cod_barra_scaner = false;
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.txtBuscar.Focus();
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
                    if (this.dgvFacturas.Rows.Count == 1)
                    {
                        return;
                    }

                    this.tBuscar.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnAgregarProd.Enabled = false;

                    DataTable dtFactura = NProductos.obtener_productos_venta("", cGeneral.stock_producto);

                    this.dgvFacturas.DataSource = dtFactura;
                    this.dgvFacturas.Refresh();

                    if (dgvProductos.Rows.Count > 0)
                    {
                        this.btnModificarProd.Enabled = true;
                        this.btnEliminarProd.Enabled = true;
                        this.btnGuardar.Enabled = true;
                    }

                    this.txtBuscar.Focus();
                }
                else
                {

                    if (this.dgvFacturas.Rows.Count == 1)
                    {
                        if (this.txtBuscar.Text == this.dgvFacturas.CurrentRow.Cells[0].Value.ToString())
                        {
                            this.txtBuscar.Text = "";
                            return;
                        }
                    }

                    if (cGeneral.validar_si_es_CB(this.txtBuscar.Text) && (cod_barra_scaner != this.txtBuscar.Text))
                    {
                        if (this.dgvFacturas.Rows.Count == 1)
                        {
                            if (this.txtBuscar.Text == this.dgvFacturas.CurrentRow.Cells[0].Value.ToString())
                            {
                                this.txtBuscar.Text = "";
                                return;
                            }
                        }

                        DataTable dtFactura = NProductos.obtener_productos_venta(this.txtBuscar.Text, cGeneral.stock_producto);
                        this.dgvFacturas.DataSource = dtFactura;
                        this.dgvFacturas.Refresh();

                        if (this.dgvFacturas.Rows.Count == 1)
                        {
                            cod_barra_scaner = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                            filtro_cod_barra_scaner = true;
                            this.txtBuscar.Text = "";

                            click_agregar_prod();

                        }
                        else
                        {
                            filtro_cod_barra_scaner = false;
                        }
                    }
                    else
                    {
                        cod_barra_scaner = "";
                        filtro_cod_barra_scaner = false;
                        this.tBuscar.Enabled = false;
                        this.tBuscar.Enabled = true;
                        ////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);

                    }
                }
            }
            catch (Exception)
            {
                this.ttMensaje.Hide(this.txtBuscar);
                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("El dato a buscar no es un identificador de un producto.", this.txtBuscar, 0, 26, 3000);
                DataTable dtFactura = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                this.dgvFacturas.DataSource = dtFactura;
                this.dgvFacturas.Refresh();
                return;
            }
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvFacturas.Columns[10].Visible = false;
                //this.dgvFacturas.Rows[e.RowIndex].Cells[8].Style.Font = new Font(this.dgvFacturas.Font, FontStyle.Bold);
                //this.dgvFacturas.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Blue;

                this.dgvFacturas.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvFacturas.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvFacturas.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvFacturas.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvFacturas.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                ////this.dgvFacturas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                ///this.dgvFacturas.Columns[12].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                /// this.dgvFacturas.Columns[4].Visible = false;

                this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {

            /// MessageBox.Show("Probando key:" + e.KeyValue.ToString());

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                click_agregar_prod();
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Rows[0].Selected = true;
                    dgvProductos.Focus();
                }
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                click_guardar(true);
            } 
            else if (e.KeyValue == cGeneral.f6)
            {
                if (this.dgvFacturas.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                if (this.dgvFacturas.RowCount > 0)
                {
                    Productos.frmDetProductoComposicion frm = new Productos.frmDetProductoComposicion();
                    frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f8)
            {
                if (this.dgvFacturas.RowCount > 0)
                {
                    Caja.frmEgresosDia frm = new Caja.frmEgresosDia(); 
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f9)
            {
                Ventas.frmPedidoProducto frm = new Ventas.frmPedidoProducto();
                frm.ShowDialog();
            }
            else if (e.KeyValue == cGeneral.f10)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    Ventas.frmSolicitaPrecioEspecial frm = new Ventas.frmSolicitaPrecioEspecial();
                    DataTable dt = NVentas.cargar_prod(int.Parse(txtNumVenta.Text));
                    bool producto_tiene_precio_especial = false;

                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][0].ToString() == this.dgvProductos.CurrentRow.Cells[0].Value.ToString() && int.Parse(dt.Rows[i][8].ToString()) > 0)
                            {
                                producto_tiene_precio_especial = true;
                            }
                        }
                    }
                    catch (Exception) { }

                    if (!producto_tiene_precio_especial)
                    {
                        decimal cantidad = 0;
                        DataTable dt_datos = NVentas.obtener_cantidad(int.Parse(txtNumVenta.Text), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(),""/*, this.dgvProductos.CurrentRow.Cells[7].Value.ToString()*/);

                        if (dt_datos.Rows.Count > 0)
                        {
                            cantidad = decimal.Parse(dt_datos.Rows[0]["Vendio"].ToString());
                        }

                        frm.lblNameProducto.Text = this.dgvProductos.CurrentRow.Cells[1].Value.ToString();
                        frm.cantidad = cantidad;
                        frm.id_producto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                        frm.id_det_venta = 0; ///int.Parse(this.dgvProductos.CurrentRow.Cells[7].Value.ToString());
                        frm.accion = true;
                        frm.id_venta = int.Parse(this.txtNumVenta.Text);
                        frm.name_ventana = 2;
                        frm.nudPrecioEspecial.Focus();
                        frm.nudPrecioEspecial.Select(0, frm.nudPrecioEspecial.Text.Length);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El producto " + this.dgvProductos.CurrentRow.Cells[1].Value.ToString() + " ya tiene un precio " + this.dgvProductos.CurrentRow.Cells[5].Value.ToString() + " especial aprobado, Si desea cambiar el precio aprobado tiene que eliminar este producto de carrito de compra y agrgarlo a la lista de ventas.", "Producto con precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else if (e.KeyValue == cGeneral.f11)
            {
                print_cotizacion();
            }
            else if (e.KeyValue == cGeneral.f4)
            {
                //if (this.dgvFacturas.RowCount > 0)
                //{
                    Productos.frmDetProductoEspecificacion frm = new Productos.frmDetProductoEspecificacion();
                    ///frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.name_ventana = 2;
                    frm.ShowDialog();
                //}
            }
            else if (e.KeyValue == cGeneral.f2)
            {
                if (cGeneral.si_filtra_producto_por_composicion)
                {
                    Productos.frmBuscarProductoComposicion frm = new Productos.frmBuscarProductoComposicion();
                    frm.name_ventana = 2;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No tiene suficientes permiso para buscar productos por composición.", "Aviso de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            else if (e.KeyValue == cGeneral.f3)
            {
                click_nam_temp(false, true);
            }
            else if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            } 
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar_Producto();

                if (this.dgvFacturas.Rows.Count == 1)
                {

                    e.SuppressKeyPress = true;
                    if (this.txtBuscar.Text != "")
                    {
                        click_agregar_prod();
                    }

                }
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Rows[0].Selected = true;
                    dgvProductos.Focus();
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
                if (this.dgvProductos.Rows.Count > 0)
                {
                    Ventas.frmSolicitaPrecioEspecial frm = new Ventas.frmSolicitaPrecioEspecial();
                    DataTable dt = NVentas.cargar_prod(int.Parse(txtNumVenta.Text));
                    bool producto_tiene_precio_especial = false;

                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][0].ToString() == this.dgvProductos.CurrentRow.Cells[0].Value.ToString() && int.Parse(dt.Rows[i][8].ToString()) > 0)
                            {
                                producto_tiene_precio_especial = true;
                            }
                        }
                    }
                    catch (Exception) { }

                    if (!producto_tiene_precio_especial)
                    {
                        decimal cantidad = 0;
                        DataTable dt_datos = NVentas.obtener_cantidad(int.Parse(txtNumVenta.Text), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(),"");

                        if (dt_datos.Rows.Count > 0)
                        {
                            cantidad = decimal.Parse(dt_datos.Rows[0]["Vendio"].ToString());
                        }

                        frm.lblNameProducto.Text = this.dgvProductos.CurrentRow.Cells[1].Value.ToString();
                        frm.cantidad = cantidad;
                        frm.id_producto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                        frm.id_det_venta = 0; ///int.Parse(this.dgvProductos.CurrentRow.Cells[7].Value.ToString());
                        frm.accion = true;
                        frm.id_venta = int.Parse(this.txtNumVenta.Text);
                        frm.name_ventana = 2;
                        frm.nudPrecioEspecial.Focus();
                        frm.nudPrecioEspecial.Select(0, frm.nudPrecioEspecial.Text.Length);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El producto " + this.dgvProductos.CurrentRow.Cells[1].Value.ToString() + " ya tiene un precio " + this.dgvProductos.CurrentRow.Cells[5].Value.ToString() + " especial aprobado, Si desea cambiar el precio aprobado tiene que eliminar este producto de carrito de compra y agrgarlo a la lista de ventas.", "Producto con precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    frm.name_ventana = 2;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No tiene suficientes permiso para buscar productos por composición.", "Aviso de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } 
            else if (e.KeyValue == cGeneral.f3)
            {
                click_nam_temp(false,true);
            }
            else if (e.KeyValue == cGeneral.f6)
            {
                if (this.dgvFacturas.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                if (this.dgvFacturas.RowCount > 0)
                {
                    Productos.frmDetProductoComposicion frm = new Productos.frmDetProductoComposicion();
                    frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
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
                    frm.name_ventana = 2;
                    frm.ShowDialog();
                //}
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            click_agregar_prod();
        }
        private void alerta_producto_vencimiento(string producto)
        {
            try
            {
                dia_vencimiento = NProductos.obtener_dia_vencimiento(producto);
                if (dia_vencimiento <= cGeneral.dia_vencimiento && dia_vencimiento != 0)
                {
                    MessageBox.Show("Este producto se vencerá en: " + dia_vencimiento + " días", "Alerta de vencimiento de producto", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
            catch (Exception)  { dia_vencimiento = 0; }
        }
        public void click_agregar_prod()
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
                if (this.btnAgregarProd.Enabled == true)
                {
                    if (this.dgvFacturas.Rows.Count <= 0)
                    {
                        this.ttMensaje.Hide(this.txtBuscar);

                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("No hay producto seleccionado para agregar", this.txtBuscar, 0, 26, 3000);
                        this.txtBuscar.Focus();
                        return;
                    }

                    if (NVentas.verificar_siexiste_prod(int.Parse(txtNumVenta.Text), this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) && !cGeneral.validar_si_es_CB(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()))
                    {
                        if (dgvProductos.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvProductos.Rows.Count; i++)
                            {
                                if (this.dgvProductos.Rows[i].Cells[0].Value.ToString() == this.dgvFacturas.CurrentRow.Cells[0].Value.ToString())
                                {
                                    this.ttMensaje.Hide(this.txtBuscar);
                                    this.ttMensaje.ToolTipTitle = "ERROR";
                                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                                    this.ttMensaje.Show("Este producto ya está agregado", this.txtBuscar, 0, 26, 3000);
                                    this.txtBuscar.Focus();
                                    return;
                                }
                            }
                        }
                    }
                    long   captar_disp = 0;
                    if (txtNumVenta.Text != "0")
                    {
                        captar_disp = NProductos.obtener_disponible_vs_venta(this.txtNumVenta.Text, dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        if (captar_disp < 0)
                        {
                            this.ttMensaje.Hide(this.txtBuscar);
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("No hay suficiente en stock", this.txtBuscar, 0, 26, 3000);
                            this.txtBuscar.Focus();
                            return;
                        }
                    } 
                    alerta_producto_vencimiento(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                    if (dia_vencimiento <= 0)
                    {
                        MessageBox.Show("¡Este producto se encuentra vencido. Favor ir al la ficha del producto y actualizar la fecha de vencimiento!.","Vencimiento de producto",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }

                    if (this.cliente_seleccionado == false)
                    {
                        ////DialogResult resul = MessageBox.Show("Está apunto de crear una nueva venta, pero todavía no se ha especificado al cliente.\n\n¿Desea especificarlo?", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        //if (resul == System.Windows.Forms.DialogResult.Yes)
                        //    click_agregar();
                        //else if (resul == System.Windows.Forms.DialogResult.No)
                        //{
                        this.txtNumVenta.Text = NVentas.obtener_num_venta().ToString();
                        this.captar_id_cliente = 0;

                        ///DataTable dt = NClientes.obtener_datos(this.captar_id_cliente);
                        this.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        this.Text = this.Text +" - "+ "Ventana #2" + " | *** CLIENTE: NINGUNO ***";

                        if (int.Parse(this.txtNumVenta.Text) > 0)
                        {
                            NVentas.agregar_venta(int.Parse(this.txtNumVenta.Text), cGeneral.id_user_actual, this.captar_id_cliente, cGeneral.id_user_actual);
                            this.cliente_seleccionado = true;
                            btnCancelar.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnModificar.Enabled = true;

                            int contiene = NProductos.obtener_contiene(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                            /*Se valida que el precio de venta no sea menor al precio de compra.*/
                            if (validaDescuentovsPVPProducto(contiene))
                            {
                                return;
                            }
                            if (contiene <= 0)
                            {
                                //frmVentas_Cantidad_Scanner frm = new frmVentas_Cantidad_Scanner();
                                //frm.Text = "AGREGAR CANTIDAD";
                                //frm.nudCantidad1.Value = 1;
                                //frm.accion = false;
                                //frm.ShowDialog();
                                click_guardar_tem(false);
                            }
                            else
                            {
                                frmVentas_Cantidad frm = new frmVentas_Cantidad();
                                frm.Text = "AGREGAR CANTIDAD";
                                frm.accion = false;
                                frm.name_ventana = 2;
                                frm.nudCantidad1.Text = "0";
                                frm.fracciones = true;
                                frm.nudFracciones.TabIndex = 0;
                                frm.nudFracciones.Focus();
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar un número de factura para asignar. Contactar con el administrador","No se encontró núero de factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } 
                    }
                    else
                    {
                        if (this.captar_id_cliente != 0)
                        {
                            DataTable dt = NClientes.obtener_datos(this.captar_id_cliente);
                            if (dt.Rows.Count>0)
                            {
                                this.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                                this.Text = this.Text +" - "+ "Ventana #2" + " | *** CLIENTE: " + dt.Rows[0].ItemArray[3].ToString() + " ***";
                            }
                            else
                            {
                                MessageBox.Show("No se encontró un cliente para la venta", "Cliente venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                           
                        }

                        int contiene = NProductos.obtener_contiene(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        /*Se valida que el precio de venta no sea menor al precio de compra.*/
                        if (validaDescuentovsPVPProducto(contiene))
                        {
                            return;
                        }
                        if (contiene <= 0)
                        {
                            //frmVentas_Cantidad_Scanner frm = new frmVentas_Cantidad_Scanner();
                            //frm.Text = "AGREGAR CANTIDAD";
                            //frm.nudCantidad1.Value = 1;
                            //frm.accion = false;
                            //frm.ShowDialog();
                            click_guardar_tem(false);
                        }
                        else
                        {
                            frmVentas_Cantidad frm = new frmVentas_Cantidad();
                            frm.Text = "AGREGAR CANTIDAD";
                            frm.accion = false;
                            frm.name_ventana = 2;
                            frm.fracciones = true;
                            frm.nudCantidad1.Text = "0";
                            frm.nudFracciones.TabIndex = 0;
                            frm.nudFracciones.Focus();
                            frm.ShowDialog();
                        }

                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvFacturas.Rows[e.RowIndex].Cells[5].Value.ToString() == "0" || this.dgvFacturas.Rows[e.RowIndex].Cells[5].Value.ToString() == "0F0")
                    this.btnAgregarProd.Enabled = false;
                else
                    this.btnAgregarProd.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
      

                this.dgvProductos.Columns[1].DefaultCellStyle.Format = "@";
                this.dgvProductos.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + ""; 
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + ""; 

                //this.dgvProductos.Rows[e.RowIndex].Cells[1].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                //this.dgvProductos.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;
                this.dgvProductos.Columns[2].Frozen = true;

                this.dgvProductos.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            click_eliminar_prod();
        }

        void click_eliminar_prod()
        {
            try
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar éste producto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.txtBuscar.Focus();
                        return;
                    }

                    NVentas.eliminar_prod(int.Parse(txtNumVenta.Text), this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);
                    this.cargar_totales(int.Parse(txtNumVenta.Text));
                    this.txtRegistros.Text = this.dgvProductos.Rows.Count.ToString("N0");

                    if (this.dgvProductos.Rows.Count == 0)
                    {
                        this.btnAgregarProd.Enabled = false;
                        this.btnModificarProd.Enabled = false;
                        this.btnEliminarProd.Enabled = false;
                        this.btnGuardar.Enabled = false;

                        if (this.dgvFacturas.Rows.Count > 0)
                            this.txtBuscar.Focus();
                        else
                            this.txtBuscar.Focus();
                    }
                    else
                    {
                        this.dgvProductos.Rows[this.dgvProductos.CurrentRow.Index].Selected = true;
                        this.txtBuscar.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No existe ningún producto agregado para eliminar", "Seleccionar los productos para eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Rows[0].Selected = true;
                    dgvProductos.Focus();
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
            else if (e.KeyValue == cGeneral.f9)
            {
                Ventas.frmPedidoProducto frm = new Ventas.frmPedidoProducto();
                frm.ShowDialog();
            }
            else if (e.KeyValue == cGeneral.f10)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    Ventas.frmSolicitaPrecioEspecial frm = new Ventas.frmSolicitaPrecioEspecial();
                    DataTable dt = NVentas.cargar_prod(int.Parse(txtNumVenta.Text));
                    bool producto_tiene_precio_especial = false;

                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][0].ToString() == this.dgvProductos.CurrentRow.Cells[0].Value.ToString() && int.Parse(dt.Rows[i][8].ToString()) > 0)
                            {
                                producto_tiene_precio_especial = true;
                            }
                        }
                    }
                    catch (Exception) { }

                    if (!producto_tiene_precio_especial)
                    {
                        decimal cantidad = 0;
                        DataTable dt_datos = NVentas.obtener_cantidad(int.Parse(txtNumVenta.Text), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), "");

                        if (dt_datos.Rows.Count > 0)
                        {
                            cantidad = decimal.Parse(dt_datos.Rows[0]["Vendio"].ToString());
                        }

                        frm.lblNameProducto.Text = this.dgvProductos.CurrentRow.Cells[1].Value.ToString();
                        frm.cantidad = cantidad;
                        frm.id_producto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                        frm.id_det_venta = 0; ///int.Parse(this.dgvProductos.CurrentRow.Cells[7].Value.ToString());
                        frm.accion = true;
                        frm.id_venta = int.Parse(this.txtNumVenta.Text);
                        frm.name_ventana = 2;
                        frm.nudPrecioEspecial.Focus();
                        frm.nudPrecioEspecial.Select(0, frm.nudPrecioEspecial.Text.Length);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El producto " + this.dgvProductos.CurrentRow.Cells[1].Value.ToString() + " ya tiene un precio " + this.dgvProductos.CurrentRow.Cells[5].Value.ToString() + " especial aprobado, Si desea cambiar el precio aprobado tiene que eliminar este producto de carrito de compra y agrgarlo a la lista de ventas.", "Producto con precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else if (e.KeyValue == cGeneral.f11)
            {
                print_cotizacion();
            }
            else if (e.KeyValue == cGeneral.f6)
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    Productos.frmDetProductoComposicion frm = new Productos.frmDetProductoComposicion();
                    frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyValue == cGeneral.f4)
            {
                //if (this.dgvProductos.RowCount > 0)
                //{
                    Productos.frmDetProductoEspecificacion frm = new Productos.frmDetProductoEspecificacion();
                    ///frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.name_ventana = 2;
                    frm.ShowDialog();
               /// }
            }
            else if (e.KeyValue == cGeneral.f2)
            {
                if (cGeneral.si_filtra_producto_por_composicion)
                {
                    Productos.frmBuscarProductoComposicion frm = new Productos.frmBuscarProductoComposicion();
                    frm.name_ventana = 2;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No tiene suficientes permiso para buscar productos por composición.", "Aviso de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.KeyValue == cGeneral.f3)
            {
                click_nam_temp(false, true);
            }
            else if (e.KeyValue == 13)
            {
                click_modificar_prod();
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
                click_eliminar_prod();
            }  
            else if (e.KeyValue == 77)
            {
                this.btnModificarProd.PerformClick();
            }  
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count == 0)
                this.txtBuscar.Focus();
        }

        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
            if (this.dgvFacturas.Rows.Count == 0)
            {
                this.txtBuscar.Focus();
            }

        }

        private void btnModificarProd_Click(object sender, EventArgs e)
        {
            click_modificar_prod();
        }

        void click_modificar_prod()
        {
            if (this.dgvProductos.RowCount > 0)
            {  
                frmVentas_Cantidad frm = new frmVentas_Cantidad();
                frm.Text = "MODIFICAR CANTIDAD";
                frm.name_ventana = 2;
                frm.accion = true; 
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existe ningún producto agregado para modificar", "Seleccionar los productos para modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar(false);
        }

        void click_guardar(bool key)
        {
            if (!cGeneral.cierre_caja)
            {
                if (this.dgvProductos.RowCount > 0)
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
                                    NVentas.actualizar_cliente(int.Parse(txtNumVenta.Text), this.captar_id_cliente);

                                    if (this.captar_id_cliente > 0)
                                    {
                                        Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
                                        frm.total_Pagar = lblTotalPagar.Text;
                                        frm.num_venta = txtNumVenta.Text;
                                        frm.captar_id_cliente = this.captar_id_cliente;
                                        frm.name_ventana = 2;
                                        frm.ShowDialog();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontro ningún cliente de tipo CONSUMIDOR FINAL", "Cliente consumidor final", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    frm.name_ventana = 2;
                                    ///frm.cbEfectivo.Checked = true;
                                    frm.ShowDialog();
                                }
                            }
                        }

                    }
                    else
                    {
                        Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
                        ///frm.cbEfectivo.Checked = true;
                        frm.total_Pagar = lblTotalPagar.Text;
                        frm.captar_id_cliente = captar_id_cliente;
                        frm.num_venta = txtNumVenta.Text;
                        frm.name_ventana = 2;
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No existe ningún producto agregado para facturar", "Seleccionar los productos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Caja ya fue cerrada el día de hoy. No es posible realizar ventas hasta el día de mañana.", "Caja del día cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void pbOpciones_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0)
            {
                int es_administrador = NUsuarios.es_administrador(cGeneral.id_user_actual);
                if (es_administrador > 0)
                {
                    this.iMPRIMIRToolStripMenuItem.Enabled = true;
                    this.contextMenuStrip1.Show(this.pbOpciones, new Point(-85, -35));
                }

            }
        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click_imprimir();
        }
        private void iMPRIMIRCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print_cotizacion();
        }

        void click_imprimir()
        {
            print_venta();
        }
        public void print_venta()
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("Desea ver el reporte de productos.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.txtBuscar.Focus();
                        return;
                    }

                    if (cGeneral.numItem >= dgvProductos.Rows.Count)
                    {
                        Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                        frmReporte.fecha_inicio = "";
                        frmReporte.fecha_fin = "";
                        frmReporte.desde = 1;
                        frmReporte.hasta = cGeneral.numItem;
                        frmReporte.print_pago = "SI";
                        frmReporte.num_factura = Convert.ToString(int.Parse(txtNumVenta.Text));
                        frmReporte.Show();
                    }
                    else
                    {
                        int itemRecord = 0;
                        for (int i = 0; i < 20; i++)
                        {

                            itemRecord += cGeneral.numItem;

                            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                            frmReporte.fecha_inicio = "";
                            frmReporte.fecha_fin = "";
                            frmReporte.desde = itemRecord - cGeneral.numItem + 1;
                            frmReporte.hasta = itemRecord;
                            frmReporte.print_pago = "NO";
                            frmReporte.num_factura = Convert.ToString(int.Parse(txtNumVenta.Text));
                            frmReporte.Show();

                            if (itemRecord >= dgvProductos.Rows.Count)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        public void print_cotizacion()
        {
            try
            {
                if (!cGeneral.permiso_genera_cotizacion)
                {
                    MessageBox.Show("Usted no tiene permiso para generar e imprimir cotización", "No tiene permiso a cotizar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (this.dgvProductos.Rows.Count > 0)
                {
                    if (this.captar_id_cliente == 0)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);
                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NVentas.actualizar_cliente(int.Parse(txtNumVenta.Text), this.captar_id_cliente);
                            btnModificar.Enabled = true;
                        } 
                    }
                    DialogResult resul = MessageBox.Show("¿Desea imprimir la cotización de esta venta?.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.txtBuscar.Focus();
                        return;
                    }
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_cotizacion");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.desde = 1;
                    frmReporte.hasta = cGeneral.numItem;
                    frmReporte.print_pago = "NO";
                    frmReporte.num_factura = Convert.ToString(int.Parse(txtNumVenta.Text));
                    frmReporte.Show();

                    //else
                    //{
                    //    MessageBox.Show("Debe de seleccionar el cliente antes de imprimir la cotización", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }
                else
                {
                    MessageBox.Show("No hay ningún producto agregado para imprimir la cotización", "Imprimir cotización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void dgvFacturas_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
               if (e.KeyChar == 18)
                click_imprimir(); 
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                //if (this.dgvFacturas.Rows.Count == 0 && this.dgvProductos.Rows.Count == 0)
                    this.txtBuscar.Focus();
                //else
                //    if (this.dgvFacturas.Rows.Count > 0 && this.txtBuscar.Text != "")
                //    this.txtBuscar.Focus();
                //else
                //    this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar_venta();
        }

        void click_eliminar_venta()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta venta.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.txtBuscar.Focus();
                    return;
                }

                NVentas.eliminar_fact(Convert.ToInt32(int.Parse(txtNumVenta.Text)));
                this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtNumVenta.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtBuscar.Text = "";
                click_cancelar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVentas_Temp_Click(object sender, EventArgs e)
        {
            this.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
            this.dgvFacturas.Refresh();
            frmVentas_Clientes frm = new frmVentas_Clientes();
            frm.name_ventana = 2;
            frm.ShowDialog();
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnCancelar);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.Show("Cancelar", this.btnCancelar, 0, 38, 3000);
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnCancelar);
        }

        private void btnVentas_Temp_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnVentas_Temp);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.Show("Ventas guardadas temporalmente", this.btnVentas_Temp, 0, 38, 3000);
        }

        private void btnVentas_Temp_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnVentas_Temp);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            click_cancelar();
        }

        public void click_cancelar()
        {
            try
            {
                this.btnCancelar.Enabled = false;
                this.btnAgregar.Enabled = true;
                this.btnModificar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.cliente_seleccionado = false;
                this.captar_id_cliente = 0;
                ////this.captar_numventa = 0
                if (int.Parse(txtNumVenta.Text)>0)
                {
                    NVentas.eliminar_fact(Convert.ToInt32(int.Parse(txtNumVenta.Text)));
                } 
                this.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                this.Text = this.Text + " - " + "Ventana #2";
                this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtNumVenta.Text = Convert.ToDecimal(0).ToString("N0");
                this.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                this.dgvFacturas.Refresh();

                this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                ////this.orden_prod(this.dgvProductos);
                this.cargar_totales(0);

                this.txtBuscar.Text = "";

                if (dgvProductos.Rows.Count > 0)
                {
                    this.btnModificarProd.Enabled = true;
                    this.btnEliminarProd.Enabled = true;
                    this.btnGuardar.Enabled = true;
                }
                else
                {
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
 

        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Busca el código de barra, nombre, presentación y el proveedor del producto", this.txtBuscar, 0, 26);
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            try
            {
                //number = 1;

                //this.dgvFacturas.DataSource = NProductos.obtener_productos_venta(this.txtBuscar.Text);
                //this.dgvFacturas.Refresh();

                //this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                //this.btnPrimera.Enabled = false;
                //this.brnAnterior.Enabled = false;
                //this.btnSiguiente.Enabled = true;
                //this.btnUltima.Enabled = true;

                //this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void brnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                //number -= 1;

                //this.dgvFacturas.DataSource = NProductos.obtener_productos_venta(this.txtBuscar.Text);
                //this.dgvFacturas.Refresh();

                //this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                //if (number == 1)
                //{
                //    this.btnPrimera.Enabled = false;
                //    this.brnAnterior.Enabled = false;
                //    this.btnSiguiente.Enabled = true;
                //    this.btnUltima.Enabled = true;
                //}
                //else
                //{
                //    this.btnPrimera.Enabled = true;
                //    this.brnAnterior.Enabled = true;
                //    this.btnSiguiente.Enabled = true;
                //    this.btnUltima.Enabled = true;
                //}

                //this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                //number += 1;

                //this.dgvFacturas.DataSource = NProductos.obtener_productos_venta(this.txtBuscar.Text);
                //this.dgvFacturas.Refresh();

                //this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                //if (number == tamaño)
                //{
                //    this.btnPrimera.Enabled = true;
                //    this.brnAnterior.Enabled = true;
                //    this.btnSiguiente.Enabled = false;
                //    this.btnUltima.Enabled = false;
                //}
                //else
                //{
                //    this.btnPrimera.Enabled = true;
                //    this.brnAnterior.Enabled = true;
                //    this.btnSiguiente.Enabled = true;
                //    this.btnUltima.Enabled = true;
                //}

                //this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            try
            {
                //number = tamaño;

                //this.dgvFacturas.DataSource = NProductos.obtener_productos_venta(this.txtBuscar.Text);
                //this.dgvFacturas.Refresh();

                //this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                //this.btnPrimera.Enabled = true;
                //this.brnAnterior.Enabled = true;
                //this.btnSiguiente.Enabled = false;
                //this.btnUltima.Enabled = false;
                //this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                try
                {
                    DataGridViewRow row = (DataGridViewRow)dgvFacturas.Rows[e.RowIndex];
                    if (row != null)
                    {
                        string imagenUrl = NProductos.obtener_img_prod(row.Cells[0].Value.ToString());
                        if (imagenUrl != null)
                        {
                            if (File.Exists(imagenUrl))
                            {
                                pbFoto.ImageLocation = imagenUrl;
                                gbProducto.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    dgvFacturas.Cursor = Cursors.Default;
                    /// pImagen.Visible = false;
                }

            }
            else
                dgvFacturas.Cursor = Cursors.Default;
            ///pImagen.Visible = false;
        }

        private void dgvFacturas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvFacturas.Cursor = Cursors.Default;
            /// pImagen.Visible = false;
            gbProducto.Visible = false;
        }

        private void dgvProductos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                try
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[e.RowIndex];
                    if (row != null)
                    {
                        string imagenUrl = NProductos.obtener_img_prod(row.Cells[0].Value.ToString());
                        if (imagenUrl != null)
                        {
                            if (File.Exists(imagenUrl))
                            {
                                pbFoto.ImageLocation = imagenUrl;
                                gbProducto.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    dgvProductos.Cursor = Cursors.Default;
                    /// pImagen.Visible = false;
                }

            }
            else
                dgvProductos.Cursor = Cursors.Default;
            ///pImagen.Visible = false;
        }

        private void dgvProductos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos.Cursor = Cursors.Default;
            /// pImagen.Visible = false;
            gbProducto.Visible = false;
        }

        private void txtBuscar_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {

        }

        private void tCargarProd_Tick(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                this.txtRegistros.Text = Convert.ToDecimal(dgvProductos.Rows.Count.ToString()).ToString("N0");
            }
        }

        private void btnPrintVenta_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnPrintVenta);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.Show("Imprimir ventas del historial.", this.btnPrintVenta, 0, 38, 3000);
        }

        private void btnPrintVenta_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnPrintVenta);
        }

        private void btnPrintVenta_Click(object sender, EventArgs e)
        {
            Ventas.frmVentas_Historial frm = new Ventas.frmVentas_Historial();
            frm.name_ventana = 2;
            frm.ShowDialog();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                btnModificarProd.Enabled = true;
                btnEliminarProd.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnModificarProd.Enabled = false;
                btnEliminarProd.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {

            if (this.dgvFacturas.Rows.Count > 0)
            {
                click_agregar_prod();
            }
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            
        }

        private void frmVentas_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                NVentas.limpia_tem(cGeneral.id_user_actual.ToString(),int.Parse(txtNumVenta.Text));
            }
            catch (Exception)  {  }
        }

        private void frmVentas_2_MinimumSizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void btnRefrescarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.RowCount > 0)
                {
                    DataTable dtProductos = new DataTable();
                    dtProductos = NVentas.cargar_prod(int.Parse(txtNumVenta.Text));
                    dgvProductos.DataSource = dtProductos;
                    cargar_totales(int.Parse(txtNumVenta.Text));

                }
            }
            catch (Exception) { }
        }

        void click_guardar_tem(bool accion)
        {
            try
            {
                long captar_cant = 1, captar_disp = 0;

                if (dgvFacturas.Rows.Count == 0)
                    captar_disp = NProductos.obtener_disponible(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                else
                    captar_disp = NProductos.obtener_disponible(dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (captar_cant > captar_disp)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay suficiente en stock", this.txtBuscar, 0, 38, 3000);

                    if (this.txtBuscar.Enabled)
                        this.txtBuscar.Focus();
                    return;
                }

                NProductos.actualizar_desc(dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                decimal calc_ganan, calc_parc;
                calc_ganan = NCotizaciones.calcular_ganan(dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                calc_parc = NCotizaciones.calcular_parcial(dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                //NUEVA VENTA.
                NVentas.guardar_prod_temp(int.Parse(txtNumVenta.Text), dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_parc, calc_ganan);

                dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(txtNumVenta.Text));
                ///orden_prod(dgvProductos);
                cargar_totales(int.Parse(txtNumVenta.Text));


                DataTable dtFacturas = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                this.dgvFacturas.DataSource = dtFacturas;

                btnModificarProd.Enabled = true;
                btnEliminarProd.Enabled = true;
                btnGuardar.Enabled = true;
                txtBuscar.Text = "";
                txtBuscar.Focus();
                ////this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private bool validaDescuentovsPVPProducto(int contiene)
        {
            bool result = false;
            if (dgvFacturas.Rows.Count > 0)
            {
                decimal pvpf = 0;
                decimal PrecioCompra = NProductos.obtener_precio_compra(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                string nombreProducto = dgvFacturas.CurrentRow.Cells[1].Value.ToString();
                try
                {
                    pvpf = Math.Round(decimal.Parse(dgvFacturas.CurrentRow.Cells[7].Value.ToString()), 2, MidpointRounding.AwayFromZero);

                }
                catch (Exception) { }

                try
                {
                    if (contiene > 0)
                    {
                        var precioFinal = Math.Round((PrecioCompra / contiene), 2, MidpointRounding.AwayFromZero);
                        if (pvpf < precioFinal)
                        {
                            result = true;
                            MessageBox.Show("No se puede vender el producto #: " + nombreProducto + " a un precio por debajo del PRECIO COMPRA", "Precio venta mayor a PRECIO COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (pvpf < PrecioCompra)
                        {
                            result = true;
                            MessageBox.Show("No se puede vender el producto #: " + nombreProducto + " a un precio por debajo del PRECIO COMPRA", "Precio venta mayor a PRECIO COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = true;
                    MessageBox.Show("No se puede vender el producto #: " + nombreProducto + " a un precio por debajo del PRECIO COMPRA", "Precio venta mayor a PRECIO COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay productos para agregar.", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }
    }
}
