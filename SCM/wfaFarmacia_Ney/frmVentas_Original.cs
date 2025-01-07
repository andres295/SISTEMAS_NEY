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
using SCM.Globales;

namespace SCM
{
    public partial class frmVentas_Original : Form
    {
        public static frmVentas_Original me;

        public frmVentas_Original()
        {
            frmVentas_Original.me = this;
            InitializeComponent();
        }

        public int captar_id_cliente = 0;
        public bool cliente_seleccionado = false;
        public long captar_numventa = 0;
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
                }
                else
                {
                    if (dt_datos.Rows[0].ItemArray[0].ToString() == "")
                        this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    else
                        this.lblSubtotal.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales_ventas + "");

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
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden_prod(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.grid_selfree_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvProductos);

                this.tBuscar.Interval = cGeneral.timer;

                ////tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                DataTable dtFacturas = NProductos.obtener_productos(this.txtBuscar.Text);

                this.dgvFacturas.DataSource = dtFacturas;

                this.dgvFacturas.Columns[0].HeaderText = "ID/CODIGO BARRA";
                this.dgvFacturas.Columns[1].HeaderText = "PRODUCTO";
                this.dgvFacturas.Columns[2].HeaderText = "PRESENTACION";
                this.dgvFacturas.Columns[3].HeaderText = "PROVEEDOR";
                this.dgvFacturas.Columns[4].HeaderText = "P/COMPRA";
                this.dgvFacturas.Columns[5].HeaderText = "PVP";
                this.dgvFacturas.Columns[6].HeaderText = "DESCUENTO";
                this.dgvFacturas.Columns[7].HeaderText = "PVPX";
                this.dgvFacturas.Columns[8].HeaderText = "IVA";
                this.dgvFacturas.Columns[9].HeaderText = "TOTAL";
                this.dgvFacturas.Columns[10].HeaderText = "DISPONIBLE";
                this.dgvFacturas.Columns[11].HeaderText = "PVFR";
                this.dgvFacturas.Columns[12].HeaderText = "ESTADO";
                this.dgvFacturas.Columns[4].Visible = false;
                this.dgvFacturas.Refresh();

                if (dtFacturas.Rows.Count > 0)
                {
                    this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                    this.orden_prod(this.dgvProductos);
                }
                this.cargar_totales(0);

                this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");

                this.lblIVA_Texto.Text = "IVA (" + cGeneral.IVA.ToString("N2") + "%):";

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
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            click_agregar(false);
        }

        void click_agregar(bool pago_venta)
        {
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.Text = "SELECCIONE EL NOMBRE DEL CLIENTE";
            frm.pago_venta = pago_venta;
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.Text = "CAMBIAR EL NOMBRE DEL CLIENTE";
            frm.ShowDialog();
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {

        }
        private void Buscar_Producto()
        {
            try
            {
                if (!filtro_cod_barra_scaner)
                {
                    this.tBuscar.Enabled = false;
                    number = 1;

                    this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                    this.dgvFacturas.Refresh();


                    ////tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);

                    if (this.dgvFacturas.Rows.Count == 0)
                    {
                        this.lblTotalPaginas.Text = string.Format("PAGINA 0 DE 0");

                        //this.pPaginacion.Enabled = false;
                        this.btnAgregar.Enabled = false;
                        this.btnModificar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnAgregarProd.Enabled = false;
                        this.btnModificarProd.Enabled = false;
                        this.btnEliminarProd.Enabled = false;
                        this.btnGuardar.Enabled = false;
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
           
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvFacturas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFacturas.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvFacturas.Rows[e.RowIndex].Cells[8].Style.Font = new Font(this.dgvFacturas.Font, FontStyle.Bold);
                this.dgvFacturas.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Blue;

                this.dgvFacturas.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[11].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";


                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                /// this.dgvFacturas.Columns[4].Visible = false;

                this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {

            //// MessageBox.Show("Probando key:" + e.KeyValue.ToString());

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                click_agregar_prod();
            }

            if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
            else if (e.KeyValue == 255 || e.KeyValue == 173)
            {
                if (this.dgvFacturas.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
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
                    click_agregar_prod();
                }
            }
            if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }

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

                //this.pPaginacion.Enabled = false;
                //this.btnPrimera.Enabled = false;
                //this.brnAnterior.Enabled = false;
                //this.btnSiguiente.Enabled = false;
                //this.btnUltima.Enabled = false;

                //this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", 0, 0);
                //this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");

                DataTable dtFactura = NProductos.obtener_productos("");

                this.dgvFacturas.DataSource = dtFactura;
                this.dgvFacturas.Refresh();

                if (dtFactura.Rows.Count > 0)
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
                if (e.KeyCode == Keys.Enter)
                {
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

                        DataTable dtFactura = NProductos.obtener_productos(this.txtBuscar.Text);
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
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            click_agregar_prod();
        }

        void click_agregar_prod()
        {
            try
            {
                if (this.btnAgregarProd.Enabled == true)
                {
                    if (this.dgvFacturas.Rows.Count <= 0)
                    {
                        this.ttMensaje.Hide(this.txtBuscar);

                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("No hay producto seleccionado para agregar", this.txtBuscar, 0, 26, 3000);
                        this.dgvFacturas.Focus();
                        return;
                    }

                    if (NVentas.verificar_siexiste_prod(this.captar_numventa, this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()))
                    {
                        this.ttMensaje.Hide(this.txtBuscar);

                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("Este producto ya está agregado", this.txtBuscar, 0, 26, 3000);
                        this.dgvFacturas.Focus();
                        return;
                    }

                    if (this.cliente_seleccionado == false)
                    {
                        ////DialogResult resul = MessageBox.Show("Está apunto de crear una nueva venta, pero todavía no se ha especificado al cliente.\n\n¿Desea especificarlo?", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        //if (resul == System.Windows.Forms.DialogResult.Yes)
                        //    click_agregar();
                        //else if (resul == System.Windows.Forms.DialogResult.No)
                        //{
                        this.captar_numventa = NVentas.obtener_num_venta();
                        this.captar_id_cliente = 0;

                        DataTable dt = NClientes.obtener_datos(this.captar_id_cliente);
                        this.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        this.Text = this.Text + " | *** CLIENTE: NINGUNO ***";

                        NVentas.agregar_venta(this.captar_numventa, cGeneral.id_user_actual, this.captar_id_cliente, cGeneral.id_user_actual);
                        this.cliente_seleccionado = true;
                        btnCancelar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnModificar.Enabled = true;

                        int contiene = NProductos.obtener_contiene(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                        if (contiene <= 0)
                        {
                            frmVentas_Cantidad_Scanner frm = new frmVentas_Cantidad_Scanner();
                            frm.Text = "AGREGAR CANTIDAD";
                            frm.nudCantidad1.Value = 1;
                            frm.accion = false;
                            frm.ShowDialog();
                        }
                        else
                        {
                            frmVentas_Cantidad frm = new frmVentas_Cantidad();
                            frm.Text = "AGREGAR CANTIDAD";
                            frm.accion = false;
                            frm.ShowDialog();
                        }


                        //}
                        //else
                        //    this.dgvFacturas.Focus();
                    }
                    else
                    {
                        if (this.captar_id_cliente != 0)
                        {
                            DataTable dt = NClientes.obtener_datos(this.captar_id_cliente);
                            this.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                            this.Text = this.Text + " | *** CLIENTE: " + dt.Rows[0].ItemArray[3].ToString() + " ***";
                        }

                        int contiene = NProductos.obtener_contiene(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        if (contiene <= 0)
                        {
                            frmVentas_Cantidad_Scanner frm = new frmVentas_Cantidad_Scanner();
                            frm.Text = "AGREGAR CANTIDAD";
                            frm.nudCantidad1.Value = 1;
                            frm.accion = false;
                            frm.ShowDialog();
                        }
                        else
                        {
                            frmVentas_Cantidad frm = new frmVentas_Cantidad();
                            frm.Text = "AGREGAR CANTIDAD";
                            frm.accion = false;
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
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvProductos.Columns[1].DefaultCellStyle.Format = "@";
                this.dgvProductos.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                this.dgvProductos.Rows[e.RowIndex].Cells[1].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Blue;

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
                        this.dgvProductos.Focus();
                        return;
                    }

                    NVentas.eliminar_prod(this.captar_numventa, this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);
                    this.cargar_totales(this.captar_numventa);
                    this.txtRegistros.Text = this.dgvProductos.Rows.Count.ToString("N0");

                    if (this.dgvProductos.Rows.Count == 0)
                    {
                        this.btnAgregarProd.Enabled = false;
                        this.btnModificarProd.Enabled = false;
                        this.btnEliminarProd.Enabled = false;
                        this.btnGuardar.Enabled = false;

                        if (this.dgvFacturas.Rows.Count > 0)
                            this.dgvFacturas.Focus();
                        else
                            this.txtBuscar.Focus();
                    }
                    else
                    {
                        this.dgvProductos.Rows[this.dgvProductos.CurrentRow.Index].Selected = true;
                        this.dgvProductos.Focus();
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
                e.SuppressKeyPress = true;

            if (e.KeyValue == 13)
                click_modificar_prod();
            else if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
            else if (e.KeyValue == 46)
                click_eliminar_prod();
            else if (e.KeyValue == 77)
                this.btnModificarProd.PerformClick();
            else if (e.KeyValue == 255 || e.KeyValue == 173)
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.fuente = "venta";
                    frm.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
                    frm.ShowDialog();
                }
            }
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count == 0)
                this.dgvFacturas.Focus();
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
            click_guardar();
        }

        void click_guardar()
        {
            if (this.dgvProductos.RowCount > 0)
            {
                if (this.captar_id_cliente == 0)
                {
                    DialogResult resul = MessageBox.Show("Está apunto de crear una nueva venta, pero todavía no se ha especificado al cliente.\n\n¿Desea especificarlo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resul == System.Windows.Forms.DialogResult.Yes)
                    {
                        click_agregar(true);
                    }
                    if(resul == System.Windows.Forms.DialogResult.No)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);

                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NVentas.actualizar_cliente(this.captar_numventa, this.captar_id_cliente);

                            if (this.captar_id_cliente > 0)
                            {
                                Ventas.frmVentas_MultiPago frm = new Ventas.frmVentas_MultiPago();
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
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No existe ningún producto agregado para facturar", "Seleccionar los productos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        this.dgvFacturas.Focus();
                        return;
                    }

                    if (cGeneral.numItem >= frmVentas.me.dgvProductos.Rows.Count)
                    {
                        Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                        frmReporte.fecha_inicio = "";
                        frmReporte.fecha_fin = "";
                        frmReporte.desde = 1;
                        frmReporte.hasta = cGeneral.numItem;
                        frmReporte.print_pago = "SI";
                        frmReporte.num_factura = Convert.ToString(this.captar_numventa);
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
                            frmReporte.num_factura = Convert.ToString(this.captar_numventa);
                            frmReporte.Show();

                            if (itemRecord >= frmVentas.me.dgvProductos.Rows.Count)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void dgvFacturas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 7)
                click_guardar();

            //ctrl+m: modificar
            //if (e.KeyChar == 13)
            //{
            //    click_agregar();
            //}
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 7)
                click_guardar();
            else if (e.KeyChar == 18)
                click_imprimir();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvFacturas.Rows.Count == 0 && this.dgvProductos.Rows.Count == 0)
                    this.txtBuscar.Focus();
                else
                    if (this.dgvFacturas.Rows.Count > 0 && this.txtBuscar.Text != "")
                    this.dgvFacturas.Focus();
                else
                    this.txtBuscar.Focus();
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
                    this.dgvFacturas.Focus();
                    return;
                }

                NVentas.eliminar_fact(Convert.ToInt32(this.captar_numventa));
                this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");
                this.txtBuscar.Text = "";
                click_cancelar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVentas_Temp_Click(object sender, EventArgs e)
        {
            this.dgvFacturas.DataSource = NProductos.obtener_productos("");
            this.dgvFacturas.Refresh();
            frmVentas_Clientes frm = new frmVentas_Clientes();
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
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.cliente_seleccionado = false;
                this.captar_id_cliente = 0;
                this.captar_numventa = 0;
                this.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                this.txtRegistros.Text = Convert.ToDecimal(0).ToString("N0");

                this.dgvFacturas.DataSource = NProductos.obtener_productos("");
                this.dgvFacturas.Refresh();

                this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                this.orden_prod(this.dgvProductos);
                this.cargar_totales(0);

                this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);

            if (e.KeyChar == 7)
                if (this.btnGuardar.Enabled)
                    click_guardar();

            //ctrl+t:venta temporal
            if (e.KeyChar == 20)
            {
                frmVentas_Clientes frm = new frmVentas_Clientes();
                frm.ShowDialog();
            }
            //ctrl+n: nueva venta
            //if (e.KeyChar == 14)
            //{
            //    click_agregar();
            //}
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

                //this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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

                //this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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

                //this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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

                //this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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
            frm.ShowDialog();
        }

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {

            if (this.dgvFacturas.Rows.Count > 0)
            {
                click_agregar_prod();
            }
        }
    }
}
