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
    public partial class frmRecuperar : Form
    {
        public static frmRecuperar me;

        public frmRecuperar()
        {
            frmRecuperar.me = this;
            InitializeComponent();
        }

        public int captar_id_cliente = 0;
        public bool cliente_seleccionado = false;
        public long captar_numventa = 0;
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

        //BindingList<campos> listar(string dato, int page)
        //{
        //    BindingList<campos> bl;
        //    List<campos> query = (from c in bd.Cargar_Productos(dato).OrderBy(p => p.Producto)
        //                          select new campos
        //                          {
        //                              id = c.Id,
        //                              prod = c.Producto,
        //                              pres = c.Presentacion,
        //                              prov = c.Proveedor,
        //                              pvf = Convert.ToDecimal(c.PVF),
        //                              pvp = Convert.ToDecimal(c.PVP),
        //                              desc = Convert.ToDecimal(c.Descuento),
        //                              pvpx = Convert.ToDecimal(c.PVPX),
        //                              disp = c.Disponible,
        //                              pvfr = Convert.ToDecimal(c.PVFR),
        //                              est = c.Estado
        //                          }).Skip((page - 1) * cGeneral.registros_por_pagina).Take(cGeneral.registros_por_pagina).ToList();

        //    return bl = new BindingList<campos>(query);
        //}

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
                    this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
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
                    this.lblSubTotalSI.Text = subtotalSinImpuesto.ToString("N" + cGeneral.decimales_ventas + "");
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden_prod(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
        }

        private void frmRecuperar_Load(object sender, EventArgs e)
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

                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);

                this.dgvFacturas.Columns[0].HeaderText = "ID/CODIGO BARRA";
                this.dgvFacturas.Columns[1].HeaderText = "PRODUCTO";
                this.dgvFacturas.Columns[2].HeaderText = "PRESENTACION";
                this.dgvFacturas.Columns[3].HeaderText = "PROVEEDOR";
                this.dgvFacturas.Columns[4].HeaderText = "P/COMPRA";
                this.dgvFacturas.Columns[5].HeaderText = "PVP";
                this.dgvFacturas.Columns[6].HeaderText = "DESCUENTO";
                this.dgvFacturas.Columns[7].HeaderText = "PVPX";
                this.dgvFacturas.Columns[8].HeaderText = "DISPONIBLE";
                this.dgvFacturas.Columns[9].HeaderText = "PVFR";
                this.dgvFacturas.Columns[10].HeaderText = "ESTADO";
                this.dgvFacturas.Refresh();

                this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                this.orden_prod(this.dgvProductos);

                this.cargar_totales(0);

                cGeneral.ajuste_columnas(this.dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvProductos);

                this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblIVA_Texto.Text = "IVA (" + cGeneral.IVA.ToString("N2") + "%):";
                this.lblSubTotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmVentas_Acciones frm = new frmVentas_Acciones();
            frm.name_ventana = 1;
            frm.Text = "CAMBIAR EL NOMBRE DEL CLIENTE";
            frm.ShowDialog();
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvFacturas.Refresh();

                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.lblTotalPaginas.Text = 
                        ("PAGINA 0 DE 0");

                    this.pPaginacion.Enabled = false;
                   //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                    return;
                }

                this.lblTotalPaginas.Text = string.Format("PAGINA 1 DE {0}", tamaño);
                this.pPaginacion.Enabled = true;
                this.btnPrimera.Enabled = false;
                this.brnAnterior.Enabled = false;

                if (tamaño == 1)
                {
                    this.btnSiguiente.Enabled = false;
                    this.btnUltima.Enabled = false;
                }
                else
                {
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }

                this.txtBuscar.Focus();
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

                this.dgvFacturas.Rows[e.RowIndex].Cells[8].Style.Font = new Font(this.dgvFacturas.Font, FontStyle.Bold);
                this.dgvFacturas.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Blue;

                this.dgvFacturas.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;

                this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == cGeneral.f7)
            {
                click_guardar();
            }
            else if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else if(e.KeyValue == 13)
            {
                click_agregar_prod();
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
            if (e.KeyValue == cGeneral.f7)
            {
                click_guardar();
            }
            else if(e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    if (this.dgvProductos.Rows.Count == 0)
                        this.Close();
                    else
                        click_cancelar();
                else
                    this.txtBuscar.Text = "";
            }
            else if(e.KeyCode == Keys.Enter)
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.btnAgregarProd.Enabled = false;

                    this.pPaginacion.Enabled = false;
                    this.btnPrimera.Enabled = false;
                    this.brnAnterior.Enabled = false;
                    this.btnSiguiente.Enabled = false;
                    this.btnUltima.Enabled = false;

                    this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", 0, 0);

                    this.dgvFacturas.DataSource = NProductos.obtener_productos("");
                    this.dgvFacturas.Refresh();

                    this.txtBuscar.Focus();
                }
                else
                {
                    if (cGeneral.validar_si_es_CB(this.txtBuscar.Text))
                    {
                        this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                        this.dgvFacturas.Refresh();
                    }
                    else
                    {
                        this.tBuscar.Enabled = false;
                        this.tBuscar.Enabled = true;
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
            if (!NVentas.ValidaVentaEnviadaSRI(captar_numventa.ToString()))
            {
                try
                {
                    this.ttMensaje.Hide(this.txtBuscar);

                    if (this.btnAgregarProd.Enabled == true)
                    {
                        if (this.dgvFacturas.Rows.Count > 0)
                            if (NVentas.verificar_siexiste_prod(this.captar_numventa, this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()))
                            {
                                this.ttMensaje.ToolTipTitle = "ERROR";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                                this.ttMensaje.Show("Este producto ya está agregado", this.txtBuscar, 0, 26, 3000);
                                this.dgvFacturas.Focus();
                                return;
                            }

                        frmRecuperar_Cantidad frm = new frmRecuperar_Cantidad();
                        frm.accion = false;
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
            {
                MessageBox.Show("No es posible agregar un producto a esta venta, esta ya  fue enviada y AUTORIZADA al SRI.", "Venta ya fue AUTORIZADA en el SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (!NVentas.ValidaVentaEnviadaSRI(captar_numventa.ToString()))
            {
                try
                {
                    DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar éste producto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProductos.Focus();
                        return;
                    }

                    NRecuperar.eliminar_prod(this.captar_numventa, this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);
                    this.cargar_totales(this.captar_numventa);
                    this.txtRegistros.Text = this.dgvProductos.Rows.Count.ToString("N0");

                    if (this.dgvProductos.Rows.Count == 0)
                    {
                        NRecuperar.eliminar_fact(Convert.ToInt32(this.captar_numventa));
                        this.btnCancelar.PerformClick();
                    }
                    else
                    {
                        this.dgvProductos.Rows[this.dgvProductos.CurrentRow.Index].Selected = true;
                        this.dgvProductos.Focus();
                    }
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
            {
                MessageBox.Show("No es posible eliminar un producto de esta venta, esta ya  fue enviada y AUTORIZADA al SRI.", "Venta ya fue AUTORIZADA en el SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == cGeneral.f7)
            {
                click_guardar();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            } 
            else  if (e.KeyValue == 13)
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
            else if (e.KeyValue == 255 || e.KeyValue == 173)
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    Productos.frmDetProducto frm = new Productos.frmDetProducto();
                    frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
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
                if (this.txtBuscar.Enabled == false)
                    this.btnVentas_Temp.Focus();
                else
                    this.txtBuscar.Focus();
            }
        }

        private void btnModificarProd_Click(object sender, EventArgs e)
        {
            click_modificar_prod();
        }

        void click_modificar_prod()
        {
            if (!NVentas.ValidaVentaEnviadaSRI(captar_numventa.ToString()))
            {
                frmRecuperar_Cantidad frm = new frmRecuperar_Cantidad();
                frm.Text = "MODIFICAR CANTIDAD";
                frm.accion = true;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No es posible editar un producto de esta venta, esta ya  fue enviada y AUTORIZADA al SRI.", "Venta ya fue AUTORIZADA en el SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        void click_guardar()
        {
            if (dgvProductos.Rows.Count > 0)
            {
                Ventas.frmRecuperar_Pagar_Efectivo frm = new Ventas.frmRecuperar_Pagar_Efectivo();
                frm.cbEfectivo.Checked = true;
                frm.ShowDialog();
            }
          
        }

        private void pbOpciones_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0)
            {
                this.iMPRIMIRToolStripMenuItem.Enabled = true;
                this.contextMenuStrip1.Show(this.pbOpciones, new Point(-85, -35));
            }
        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click_imprimir();
        }

        public void click_imprimir()
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

                    if (cGeneral.numItem >= dgvProductos.Rows.Count)
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

        private void dgvFacturas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 7)
                click_guardar();
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

                if (this.cliente_seleccionado == false)
                    this.btnVentas_Temp.Focus();
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
           if (!NVentas.ValidaVentaEnviadaSRI(captar_numventa.ToString()))
            {
                try
                {
                    DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta venta.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvFacturas.Focus();
                        return;
                    }
                    ///Actiualizamos el stock
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                        {
                            NRecuperar.actualizar_stock(captar_numventa.ToString(), this.dgvProductos.Rows[i].Cells[0].Value.ToString(), false);
                        }
                    }
                    ///Eliminamos la factura
                    NRecuperar.eliminar_fact(Convert.ToInt32(this.captar_numventa));

                    click_cancelar();
                    ///this.dgvFacturas.Rows.Remove(this.dgvFacturas.CurrentRow);
                    ///this.txtRegistros.Text = this.dgvProductos.Rows.Count.ToString("N0");

                    if (this.txtRegistros.Text == "0")
                    {
                        this.txtBuscar.Enabled = false;
                        this.txtBuscar.Text = "";
                    }
                    else
                    {
                        ////this.dgvFacturas.Rows[this.dgvFacturas.CurrentRow.Index].Selected = true;
                        this.dgvFacturas.Focus();
                    }
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
            {
                MessageBox.Show("No es posible eliminar la venta, ya que esta fue enviada y AUTORIZADA al SRI.", "Venta ya fue AUTORIZADA en el SRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVentas_Temp_Click(object sender, EventArgs e)
        {
            frmRecuperar_Lista frm = new frmRecuperar_Lista();
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
            this.ttMensaje.Show("Lista de ventas", this.btnVentas_Temp, 0, 38, 3000);
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
                this.btnModificar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.cliente_seleccionado = false;
                this.captar_id_cliente = 0;
                this.Text = "RECUPERAR LOS PRODUCTOS DE UNA VENTA";

                this.dgvFacturas.DataSource = NProductos.obtener_productos("");
                this.dgvFacturas.Refresh();

                this.dgvProductos.DataSource = NVentas.cargar_prod(0);
                this.orden_prod(this.dgvProductos);
                this.cargar_totales(0);

                this.txtBuscar.Text = "";
                this.txtBuscar.Enabled = false;
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
                number = 1;

                this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvFacturas.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                this.btnPrimera.Enabled = false;
                this.brnAnterior.Enabled = false;
                this.btnSiguiente.Enabled = true;
                this.btnUltima.Enabled = true;

                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void brnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                number -= 1;

                this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvFacturas.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                if (number == 1)
                {
                    this.btnPrimera.Enabled = false;
                    this.brnAnterior.Enabled = false;
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }
                else
                {
                    this.btnPrimera.Enabled = true;
                    this.brnAnterior.Enabled = true;
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }

                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                number += 1;

                this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvFacturas.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                if (number == tamaño)
                {
                    this.btnPrimera.Enabled = true;
                    this.brnAnterior.Enabled = true;
                    this.btnSiguiente.Enabled = false;
                    this.btnUltima.Enabled = false;
                }
                else
                {
                    this.btnPrimera.Enabled = true;
                    this.brnAnterior.Enabled = true;
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }

                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            try
            {
                number = tamaño;

                this.dgvFacturas.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvFacturas.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                this.btnPrimera.Enabled = true;
                this.brnAnterior.Enabled = true;
                this.btnSiguiente.Enabled = false;
                this.btnUltima.Enabled = false;
                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnPrintVenta_Click(object sender, EventArgs e)
        {
            Ventas.frmVentas_Historial frm = new Ventas.frmVentas_Historial();
            frm.ShowDialog();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tCargarProd_Tick(object sender, EventArgs e)
        {

        }

        private void tInicio_Tick(object sender, EventArgs e)
        {
            this.tInicio.Enabled = false;
            this.btnVentas_Temp.PerformClick();
        }
    }
}
