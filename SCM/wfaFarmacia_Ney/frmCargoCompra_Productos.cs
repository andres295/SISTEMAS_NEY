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

namespace SCM
{
    public partial class frmCargoCompra_Productos : Form
    {
        public static frmCargoCompra_Productos me;

        public frmCargoCompra_Productos()
        {
            frmCargoCompra_Productos.me = this;
            InitializeComponent();
        }

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
            public string disp { get; set; }
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
        //                              disp = c.Disponible,
        //                              est = c.Estado
        //                          }).Skip((page - 1) * cGeneral.registros_por_pagina).Take(cGeneral.registros_por_pagina).ToList();

        //    return bl = new BindingList<campos>(query);
        //}

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        void orden()
        {
            try
            {
                this.dgvProductos.Sort(this.dgvProductos.Columns[3], ListSortDirection.Ascending);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCargoCompra_Productos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfree_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvProductos);

                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);

                this.dgvProductos.Columns[0].HeaderText = "ID/CODIGO BARRA";
                this.dgvProductos.Columns[1].HeaderText = "PRODUCTO";
                this.dgvProductos.Columns[2].HeaderText = "PRESENTACION";
                this.dgvProductos.Columns[3].HeaderText = "PROVEEDOR";
                this.dgvProductos.Columns[4].HeaderText = "P/COMPRA";
                this.dgvProductos.Columns[5].HeaderText = "PVP";
                this.dgvProductos.Columns[6].HeaderText = "DESCUENTO";
                this.dgvProductos.Columns[7].HeaderText = "PVPX";
                this.dgvProductos.Columns[8].HeaderText = "IVA";
                this.dgvProductos.Columns[9].HeaderText = "TOTAL";
                this.dgvProductos.Columns[10].HeaderText = "DISPONIBLE";
                this.dgvProductos.Columns[11].HeaderText = "PVFR";
                this.dgvProductos.Columns[12].HeaderText = "ESTADO";
                this.dgvProductos.Refresh();

                this.tBuscar.Interval = cGeneral.timer;
                this.dtpVencimiento.Value = Convert.ToDateTime("01/01/1900");
                cGeneral.ajuste_columnas(this.dgvProductos);

                if (frmCargoCompra.me.btnGuardar.Enabled == true)
                {
                    if (frmCargoCompra.me.dgvProductos.Rows.Count == 1)
                        this.Text = this.Text + " | HAY 1 PRODUCTO AGREGADO";
                    else
                        this.Text = this.Text + " | HAY " + frmCargoCompra.me.dgvProductos.Rows.Count + " PRODUCTOS AGREGADOS";
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                number = 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvProductos.Refresh();
                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);

                if (this.dgvProductos.Rows.Count == 0)
                {
                    this.lblTotalPaginas.Text = string.Format("PAGINA 0 DE 0");

                    this.pPaginacion.Enabled = false;
                    this.nudCantidad.Value = 0;
                    this.nudBonificacion.Value = 0;
                    this.pCantidades.Enabled = false;
                    this.pbModPrecios.Enabled = false;
                    this.txtBuscar.Focus();
                }
                else
                {
                    this.pCantidades.Enabled = true;
                    this.pbModPrecios.Enabled = true;

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

                    //if (this.dgvProductos.Rows.Count == 1)
                    //{
                    //    frmCargoCompra_Mod_Precios frm = new frmCargoCompra_Mod_Precios();
                    //    frm.ShowDialog();
                    //}

                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count == 0)
                    this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    e.SuppressKeyPress = true;

                if (e.KeyValue == 13)
                    this.nudCantidad.Focus();
                else if (e.KeyValue == 27)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                        this.txtBuscar.Text = "";
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
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudCantidad);
        }

        private void nudBonificacion_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudBonificacion);
        }

        private void nudCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_nud(e);

                if (e.KeyValue == 13)
                    guardar_prod();
                else if (e.KeyValue == 27)
                    this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void guardar_prod()
        {
            try
            {
                this.ttMensaje.Hide(this.nudCantidad);

                if (this.nudCantidad.Text == "") this.nudCantidad.Value = 0;
                if (this.nudBonificacion.Text == "") this.nudBonificacion.Value = 0;

                //if (NCargoCompra.verificar_prod(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString()))
                //{
                //    this.ttMensaje.ToolTipTitle = "ERROR";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                //    this.ttMensaje.Show("Este producto ya está agregado", this.nudCantidad, 0, 26, 3000);
                //    this.dgvProductos.Focus();
                //    return;
                //}
                //else 
                if (this.nudCantidad.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad, 0, 26, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
               else if (this.dtpVencimiento.Value <= DateTime.Now.Date)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la fecha mayor a la fecha actual", this.dtpVencimiento, 0, 26, 3000);
                    this.dtpVencimiento.Focus();
                    return;
                }
                //else if (this.nudBonificacion.Value >= this.nudCantidad.Value)
                //{
                //    this.ttMensaje.ToolTipTitle = "ERROR";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                //    this.ttMensaje.Show("La bonificación debe ser menor que la cantidad", this.nudCantidad, 0, 26, 5000);
                //    this.nudBonificacion.Focus();
                //    return;
                //}

                //AQUI LO GUARDA.
                NCargoCompra.agregar_prod_temp(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(this.nudCantidad.Text), Convert.ToInt32(this.nudBonificacion.Text), cGeneral.id_user_actual, dtpVencimiento.Value,txtLote.Text.Trim());

                frmCargoCompra.me.dgvProductos.DataSource = NCargoCompra.cargar_prod(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                ////frmCargoCompra.me.productos_sort(1);
                frmCargoCompra.me.txtRegistros.Text = Convert.ToDecimal(frmCargoCompra.me.dgvProductos.Rows.Count.ToString()).ToString("N0");

                frmCargoCompra.me.cargar_totales(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[1].Value = NCargoCompra.actualizar_nombre_prov(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                frmCargoCompra.me.btnEliminarProd.Enabled = true;
                frmCargoCompra.me.btnModificarProd.Enabled = true;
                frmCargoCompra.me.btnGuardar.Enabled = true;
                 
                txtBuscar.Text = "";
                nudCantidad.Value = 0;
                nudBonificacion.Value = 0;
                txtLote.Text = "";
                dtpVencimiento.Value = System.DateTime.Now;
                txtBuscar.Focus();

                if (frmCargoCompra.me.dgvProductos.Rows.Count == 1)
                    this.Text = "AGREGAR PRODUCTOS" + " | HAY 1 PRODUCTO AGREGADO";
                else
                    this.Text = "AGREGAR PRODUCTOS" + " | HAY " + frmCargoCompra.me.dgvProductos.Rows.Count + " PRODUCTOS AGREGADOS";

                //this.txtBuscar.Focus();
                //this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudBonificacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_nud(e);

                if (e.KeyValue == 13)
                    guardar_prod();
                else if (e.KeyValue == 27)
                    this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.ttMensaje.Hide(this.txtBuscar);
                            this.ttMensaje.Hide(this.nudCantidad);

                            this.tBuscar.Enabled = false;
                            this.dgvProductos.DataSource = NProductos.obtener_productos("");

                            this.pPaginacion.Enabled = false;
                            this.btnPrimera.Enabled = false;
                            this.brnAnterior.Enabled = false;
                            this.btnSiguiente.Enabled = false;
                            this.btnUltima.Enabled = false;
                            this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", 0, 0);

                            this.nudCantidad.Value = 0;
                            this.nudBonificacion.Value = 0;
                            this.dtpVencimiento.Value = Convert.ToDateTime("01/01/1900");
                            this.txtLote.Text = "";
                            this.pCantidades.Enabled = false;
                            this.pbModPrecios.Enabled = false;
                            this.txtBuscar.Focus();
                        }
                        else
                        {
                            this.tBuscar.Enabled = false;
                            this.tBuscar.Enabled = true;
                        }
                    }
                    catch (Exception ex) { cGeneral.error(ex); }
                }
                if (e.KeyValue == 27)
                {
                    if (this.dgvProductos.Rows.Count == 0)
                        this.Close();
                    else
                        this.txtBuscar.Text = "";
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el código de barra, nombre, presentación y el proveedor del producto", this.txtBuscar, 0, 26);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudCantidad_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudCantidad);
        }

        private void nudBonificacion_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudBonificacion);
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void nudBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void pbModPrecios_Click(object sender, EventArgs e)
        {
            frmCargoCompra_Mod_Precios frm = new frmCargoCompra_Mod_Precios();
            frm.ShowDialog();
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            try
            {
                number = 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvProductos.Refresh();

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

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvProductos.Refresh();

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

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvProductos.Refresh();

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

        private void btnAddProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductos_Acciones frm = new frmProductos_Acciones();
                frm.Text = "AGREGAR";
                frm.accion = true;
                frm.idProducto = "999999999";
                frm.externalUse = true;

                frm.cmbPresentacion.DataSource = NPresentaciones.lista_combo();
                frm.cmbPresentacion.ValueMember = "Id";
                frm.cmbPresentacion.DisplayMember = "Presentacion";

                frm.cmbProveedor.DataSource = NProveedores.lista_combo();
                frm.cmbProveedor.ValueMember = "Id";
                frm.cmbProveedor.DisplayMember = "Proveedor";

                frm.cmbEspecificacion.DataSource = NEspecificacion.lista_combo();
                frm.cmbEspecificacion.ValueMember = "Id";
                frm.cmbEspecificacion.DisplayMember = "Especificacion";

                frm.dtpVencimiento.Value = DateTime.Now.Date.AddDays(60);
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";
                this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";
                this.dgvProductos.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";
                this.dgvProductos.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";
                this.dgvProductos.Columns[11].DefaultCellStyle.Format = "N" + cGeneral.decimales_cargo_compra + "";

                //if (this.dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0" || this.dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0F0")
                //    this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Red;
                //else
                //    this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;

                this.dgvProductos.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpVencimiento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_nud(e);

                if (e.KeyValue == 13)
                    guardar_prod();
                else if (e.KeyValue == 27)
                    this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtLote_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void txtLote_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_nud(e);

                if (e.KeyValue == 13)
                    guardar_prod();
                else if (e.KeyValue == 27)
                    this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            try
            {
                number = tamaño;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvProductos.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                this.btnPrimera.Enabled = true;
                this.brnAnterior.Enabled = true;
                this.btnSiguiente.Enabled = false;
                this.btnUltima.Enabled = false;
                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
