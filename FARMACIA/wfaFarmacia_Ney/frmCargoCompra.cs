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
    public partial class frmCargoCompra : Form
    {
        public static frmCargoCompra me;

        public frmCargoCompra()
        {
            frmCargoCompra.me = this;
            InitializeComponent();
        }

        string fact_selec;
        public bool directo = false;
        public bool tipo_pago; //Credito = FALSE, Contado = TRUE

        public void facturas_sort(int col)
        {
            this.dgvFacturas.Sort(this.dgvFacturas.Columns[col], ListSortDirection.Ascending);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargoCompra_Agregar frm;
                DialogResult resul = MessageBox.Show(this, "Esta nueva factura será al crédito ó al contado.\n\nElije SI por si es al CRÉDITO.\nElije NO por si es al CONTADO.", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    this.tipo_pago = false;

                    frm = new frmCargoCompra_Agregar();
                    frm.Text = "AGREGAR CC";
                    frm.accion = true;
                    frm.lblCredito.Text = "ESTA FACTURA ES 'AL CRÉDITO'";
                    frm.nudDiasPago.Enabled = true;
                    frm.ShowDialog();
                }
                else if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.tipo_pago = true;

                    frm = new frmCargoCompra_Agregar();
                    frm.Text = "AGREGAR CC";
                    frm.accion = true;
                    frm.lblCredito.Text = "ESTA FACTURA ES 'AL CONTADO'";
                    frm.nudDiasPago.Enabled = false;
                    frm.ShowDialog();
                }
                else
                    if (txtBuscar.Enabled == false)
                        this.btnAgregar.Focus();
                    else
                        this.txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargoCompra_Agregar frm = new frmCargoCompra_Agregar();
                frm.Text = "MODIFICAR CC";
                frm.accion = false;
              
                DataTable dt_datos = NCargoCompra.obtener_datos(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                frm.mtxtFactura.Text = dt_datos.Rows[0].ItemArray[0].ToString();
                frm.num_fac_rec = dt_datos.Rows[0].ItemArray[0].ToString();
                frm.cmbProveedor.DataSource = NProveedores.lista_combo();
                frm.cmbProveedor.ValueMember = "Id";
                frm.cmbProveedor.DisplayMember = "Proveedor";
                
                frm.cmbProveedor.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.dtpFechaDoc.Value = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[2].ToString());
                frm.nudDiasPago.Value = Convert.ToInt32(dt_datos.Rows[0].ItemArray[3].ToString());
                frm.lblFechaPago.Text = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[4]).ToShortDateString();
                frm.txtObserv.Text = dt_datos.Rows[0].ItemArray[7].ToString();

                if (this.dgvFacturas.CurrentRow.Cells[5].Value.ToString() == "POR PAGAR")
                    frm.lblCredito.Text = "ESTA FACTURA ES 'AL CRÉDITO'";
                else
                    frm.lblCredito.Text = "ESTA FACTURA ES 'AL CONTADO'";

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void frmCargoCompra_Load(object sender, EventArgs e)
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

                this.dgvFacturas.DataSource = NCargoCompra.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                ///this.facturas_sort(1);
                this.dgvProductos.DataSource = NCargoCompra.cargar_prod("");
                ///this.productos_sort(1);

                this.txtRegistros.Text = Convert.ToDecimal(dgvProductos.Rows.Count.ToString()).ToString("N0");
                this.label6.Text = "IVA (" + cGeneral.IVA.ToString("N2") + "%):";

                cGeneral.ajuste_columnas(this.dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvProductos);

                if (this.txtRegistros.Text != "0")
                {
                    ////this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                ////dtpDesde.Value = System.DateTime.Now.AddDays(-30);

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NCargoCompra.buscar(this.txtBuscar.Text, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                ////this.facturas_sort(1);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;

                    this.txtBuscar.Focus();
                    ////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;

                    if (this.directo)
                    {
                        this.directo = false;
                        click_agregarprod();
                    }
                    else
                        this.txtBuscar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.txtBuscar.Text == "")
            //    {
            //        this.tBuscar.Enabled = false;
            //        this.dgvFacturas.DataSource = NCargoCompra.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
            //        ////this.facturas_sort(1);
            //        this.dgvProductos.DataSource = NCargoCompra.cargar_prod("");
            //        this.productos_sort(1);

            //        this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
            //        this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
            //        this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
            //        this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");

            //        this.fact_selec = "";

            //        this.btnAgregar.Enabled = true;
            //        this.btnModificar.Enabled = false;
            //        this.btnEliminar.Enabled = false;
                    
            //        this.btnAgregarProd.Enabled = false;
            //        this.btnModificarProd.Enabled = false;
            //        this.btnEliminarProd.Enabled = false;
            //        this.btnGuardar.Enabled = false;
            //        this.txtBuscar.Focus();
            //    }
            //    else
            //    {
            //        this.tBuscar.Enabled = false;
            //        this.tBuscar.Enabled = true;
            //    }
            //}
            //catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            /////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                    else
                        this.txtBuscar.Text = "";
                }
                else if (e.KeyValue == 40)
                {
                    if (this.dgvFacturas.Rows.Count > 0)
                        this.dgvFacturas.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvFacturas.DataSource = NCargoCompra.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                            ////this.facturas_sort(1);
                            this.dgvProductos.DataSource = NCargoCompra.cargar_prod("");
                            ////this.productos_sort(1);

                            this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.lblSubTotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");

                            this.fact_selec = "";

                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;

                            this.btnAgregarProd.Enabled = false;
                            this.btnModificarProd.Enabled = false;
                            this.btnEliminarProd.Enabled = false;
                            this.btnGuardar.Enabled = false;
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
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el # de factura y el proveedor del cargo compra", this.txtBuscar, 0, 26);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFacturas.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == false)
                    {
                        this.btnAgregar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    e.SuppressKeyPress = true;

                if (e.KeyValue == 13)
                {
                    frmCargoCompra_Productos frm = new frmCargoCompra_Productos();
                    frm.ShowDialog();
                }
                else if (e.KeyValue == 27)
                {
                    this.dgvFacturas.DataSource = NCargoCompra.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                    this.txtBuscar.Text = "";
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.txtBuscar.Focus();
                }
                else if (e.KeyValue == 46)
                    if (this.btnEliminar.Enabled == true)
                        this.click_eliminar();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea eliminar éste cargo compra.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvFacturas.Focus();
                    return;
                }

                DataTable dtProducto = NCargoCompra.valida_disponiblidad_producto("CARGO COMPRA",this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (dtProducto.Rows.Count<=0)
                {
                    NCargoCompra.eliminar_fact(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    this.dgvFacturas.Rows.Remove(this.dgvFacturas.CurrentRow);
                  
                    try
                    {
                        if (this.dgvFacturas.Rows.Count > 0)
                        {
                            this.txtRegistros.Text = Convert.ToDecimal(dgvProductos.Rows.Count.ToString()).ToString("N0");
                            this.dgvFacturas.CurrentRow.Cells[1].Value = NCargoCompra.actualizar_nombre_prov(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        }
                    }
                    catch (Exception) { }

                    if (this.txtRegistros.Text == "0")
                    {
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        /////this.txtBuscar.Enabled = false;
                        this.txtBuscar.Text = "";
                        this.btnAgregar.Focus();
                    }
                    else
                    {
                        if (this.dgvFacturas.Rows.Count > 0)
                        {
                            this.dgvFacturas.Rows[this.dgvFacturas.CurrentRow.Index].Selected = true;
                            this.dgvFacturas.Focus();
                        }
                    }
                }
                else
                {
                    Generales.frmValidaDispArticulo frm = new Generales.frmValidaDispArticulo();
                    frm.uGridListaProducto.DataSource = dtProducto;
                    frm.num_documento = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.tipo_mov = "CARGO COMPRA"; 
                    frm.uGridListaProducto.DataBind();
                    frm.ShowDialog();  
                }
                
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvProductos.Rows.Count == 0)
                    if (this.dgvFacturas.Rows.Count == 0)
                    {
                        if (this.txtBuscar.Enabled == false)
                        {
                            this.btnAgregar.Focus();
                        }
                    }
                    else
                        this.dgvFacturas.Focus();
                else
                    this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            click_agregarprod();
        }

        void click_agregarprod()
        {
            try
            {
                frmCargoCompra_Productos frm = new frmCargoCompra_Productos();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void productos_sort(int col)
        {
            this.dgvProductos.Sort(this.dgvProductos.Columns[col], ListSortDirection.Ascending);
        }

        private void tCargarProd_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tCargarProd.Enabled = false;

                if (this.dgvFacturas.Rows.Count > 0)
                {
                    //if (fact_selec != this.dgvFacturas.CurrentRow.Cells[0].Value.ToString())
                    //{
                        fact_selec = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();

                        this.dgvProductos.DataSource = NCargoCompra.cargar_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                       /// this.productos_sort(1);
                        this.txtRegistros.Text = Convert.ToDecimal(dgvProductos.Rows.Count.ToString()).ToString("N0");
                        cargar_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                        if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 1)
                        {
                            //CargoCompra_Productos_Temp
                            this.btnAgregarProd.Enabled = true;
                            this.btnModificarProd.Enabled = true;
                            this.btnEliminarProd.Enabled = true;
                            this.btnGuardar.Enabled = true;
                        }
                        else if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 2)
                        {
                            //CargoCompra_Productos
                            this.btnAgregarProd.Enabled = false;
                            this.btnModificarProd.Enabled = false;
                            this.btnEliminarProd.Enabled = false;
                            this.btnGuardar.Enabled = false;
                        }
                        else
                        {
                            //NO HAY NADA.
                            this.btnAgregarProd.Enabled = true;
                            this.btnModificarProd.Enabled = false;
                            this.btnEliminarProd.Enabled = false;
                            this.btnGuardar.Enabled = false;
                        }
                    //}
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void cargar_totales(string fact)
        {
            try
            {
                DataTable dt_datos = NCargoCompra.obtener_totales(fact);

                if (dt_datos.Rows[0].ItemArray[0].ToString() == "")
                    this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[1].ToString() == "")
                    this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblIVA.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[2].ToString() == "")
                    this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblDescuento.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[3].ToString() == "")
                    this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblTotalPagar.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[4].ToString() == "")
                    this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal_CP.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[5].ToString() == "")
                    this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal_DP.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[5].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[6].ToString() == "")
                    this.lblSubTotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubTotalSI.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[6].ToString()).ToString("N" + cGeneral.decimales + "");
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
                DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste producto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvProductos.Focus();
                    return;
                }

                NCargoCompra.eliminar_prod(this.dgvProductos.CurrentRow.Cells["Id"].Value.ToString());
                this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);
                this.dgvFacturas.CurrentRow.Cells[1].Value = NCargoCompra.actualizar_nombre_prov(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                DataTable dt_totales = NCargoCompra.obtener_totales(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (dt_totales.Rows[0].ItemArray[0].ToString() == "")
                    this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[1].ToString() == "")
                    this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblIVA.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[2].ToString() == "")
                    this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblDescuento.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[3].ToString() == "")
                    this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblTotalPagar.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[4].ToString() == "")
                    this.lblSubtotal_CP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal_CP.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[4].ToString()).ToString("N" + cGeneral.decimales + "");


                if (dt_totales.Rows[0].ItemArray[5].ToString() == "")
                    this.lblSubtotal_DP.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal_DP.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[5].ToString()).ToString("N" + cGeneral.decimales + "");


                if (dt_totales.Rows[0].ItemArray[6].ToString() == "")
                    this.lblSubTotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubTotalSI.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[6].ToString()).ToString("N" + cGeneral.decimales + "");


                if (this.dgvProductos.Rows.Count == 0)
                {
                    this.btnAgregarProd.Enabled = true;
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;
                    this.dgvFacturas.Focus();
                }
                else
                {
                    this.dgvProductos.Rows[this.dgvProductos.CurrentRow.Index].Selected = true;
                    this.dgvProductos.Focus();
                }
                this.txtRegistros.Text = Convert.ToDecimal(dgvProductos.Rows.Count.ToString()).ToString("N0");
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.txtBuscar.Text = "";
                else if (e.KeyValue == 46)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                        if (this.btnEliminarProd.Enabled == true)
                            click_eliminar_prod();
                }
                else if (e.KeyValue == 68)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 1)
                        {
                            if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[9].Value) == 0)
                                NCargoCompra.aplicar_quitar_desc_sel(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), true,0);
                            else
                                NCargoCompra.aplicar_quitar_desc_sel(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), false,0);

                            DataTable dt = NCargoCompra.obtener_totales_fila(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[14].Value.ToString());
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[7].Value = dt.Rows[0].ItemArray[0].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[8].Value = dt.Rows[0].ItemArray[4].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[9].Value = dt.Rows[0].ItemArray[1].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[10].Value = dt.Rows[0].ItemArray[2].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[11].Value = dt.Rows[0].ItemArray[3].ToString();

                            cargar_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        }
                    }
                }
                else if (e.KeyValue == 73)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 1)
                        {
                            if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[8].Value) == 0)
                                NCargoCompra.aplicar_quitar_iva_sel(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), true, cGeneral.IVA);
                            else
                                NCargoCompra.aplicar_quitar_iva_sel(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), false, cGeneral.IVA);

                            DataTable dt = NCargoCompra.obtener_totales_fila(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[14].Value.ToString());
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[7].Value = dt.Rows[0].ItemArray[0].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[8].Value = dt.Rows[0].ItemArray[4].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[9].Value = dt.Rows[0].ItemArray[1].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[10].Value = dt.Rows[0].ItemArray[2].ToString();
                            frmCargoCompra.me.dgvProductos.CurrentRow.Cells[11].Value = dt.Rows[0].ItemArray[3].ToString();

                            cargar_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        }
                    }
                }
                else if (e.KeyValue == 77)
                    this.btnModificarProd.PerformClick();
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

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count == 0)
                    if (this.dgvFacturas.Rows.Count == 0)
                    {
                        if (this.txtBuscar.Enabled == false)
                        {
                            this.btnAgregar.Focus();
                        }
                    }
                    else
                        this.dgvFacturas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificarProd_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargoCompra_Cantidad frm = new frmCargoCompra_Cantidad();

                DataTable dt_datos = NCargoCompra.obtener_cantidades(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[14].Value.ToString());

                if (dt_datos.Rows.Count>0)
                { 
                    frm.nudCantidad.Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString());
                    frm.nudBonificacion.Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString());
                    frm.dtpVencimiento.Value = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[2].ToString());
                    frm.txtLote.Text =  dt_datos.Rows[0].ItemArray[3].ToString() ;
                    frm.idItemProducto = int.Parse(this.dgvProductos.CurrentRow.Cells[14].Value.ToString());

                }
                else
                {
                    frm.nudCantidad.Value = 0;
                    frm.nudBonificacion.Value =0;
                    frm.dtpVencimiento.Value = Convert.ToDateTime("01/01/1900");
                    frm.txtLote.Text = "";

                }

                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void click_guardar()
        {
            try
            {
                DialogResult resul = MessageBox.Show(this, "Deseas guardar los productos de éste cargo compra.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvProductos.Focus();
                    return;
                }

                NCargoCompra.guardar_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                this.dgvFacturas.CurrentRow.Cells[1].Value = NCargoCompra.actualizar_nombre_prov(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (frmCargoCompra.me.tipo_pago == false)
                {
                    NCuentasPorPagar.guardar_fact(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    NCuentasPorPagar.guardar_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                }

                this.ttMensaje.ToolTipTitle = "LISTO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;

                this.btnAgregarProd.Enabled = false;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;

                if (this.dgvProductos.Rows.Count == 1)
                    this.ttMensaje.Show("El producto se guardó/aplicó correctamente", this.txtBuscar, 0, 26, 5000);
                else
                    this.ttMensaje.Show("Los productos se guardó/aplicó correctamente", this.txtBuscar, 0, 26, 5000);

                print_venta(); 
              
                this.btnGuardar.Enabled = false;
 
                this.dgvFacturas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        private void pbOpciones_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0)
            {
                this.iMPRIMIRENTICKETERAToolStripMenuItem.Enabled = true;
                this.mODIFICARCANTIDADESToolStripMenuItem.Enabled = (this.btnAgregarProd.Enabled == true ? true : false);
                this.contextMenuStrip1.Show(this.pbOpciones, new Point(0, -50));
            }
            else
            {
                this.iMPRIMIRENTICKETERAToolStripMenuItem.Enabled = false;
            }
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 4)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 1)
                        {
                            if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[9].Value) == 0)
                                NCargoCompra.aplicar_quitar_desc_todos(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), false, 0);
                            else
                                NCargoCompra.aplicar_quitar_desc_todos(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), true, Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[9].Value));

                            for (int i = 0; i < frmCargoCompra.me.dgvProductos.Rows.Count; i++)
                            {
                                DataTable dt = NCargoCompra.obtener_totales_fila(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.Rows[i].Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[14].Value.ToString());
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[7].Value = dt.Rows[0].ItemArray[0].ToString();
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[8].Value = dt.Rows[0].ItemArray[1].ToString();
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[9].Value = dt.Rows[0].ItemArray[2].ToString();
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[10].Value = dt.Rows[0].ItemArray[3].ToString();
                            }

                            cargar_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        }
                    }
                }
                else if (e.KeyChar == 9)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 1)
                        {
                            if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[8].Value) == 0)
                                NCargoCompra.aplicar_quitar_iva_todos(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), false, cGeneral.IVA);
                            else
                                NCargoCompra.aplicar_quitar_iva_todos(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), true, cGeneral.IVA);

                            for (int i = 0; i < frmCargoCompra.me.dgvProductos.Rows.Count; i++)
                            {
                                DataTable dt = NCargoCompra.obtener_totales_fila(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.Rows[i].Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[14].Value.ToString());
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[7].Value = dt.Rows[0].ItemArray[0].ToString();
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[8].Value = dt.Rows[0].ItemArray[1].ToString();
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[9].Value = dt.Rows[0].ItemArray[2].ToString();
                                frmCargoCompra.me.dgvProductos.Rows[i].Cells[10].Value = dt.Rows[0].ItemArray[3].ToString();
                            }

                            cargar_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        }
                    }
                }
                if (e.KeyChar == 7 && this.btnGuardar.Enabled)
                    click_guardar();
                else if (e.KeyChar == 18)
                    click_imprimir();

               //// MessageBox.Show("Mensaje"+ e.KeyChar, "Aviso");
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;

                this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;


                this.dgvProductos.Rows[e.RowIndex].Cells[5].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Blue;
                this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Red;

                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[10].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[11].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;

                this.dgvProductos.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ////this.btnAgregarProd.Enabled = true;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;

                this.tCargarProd.Enabled = false;
                this.tCargarProd.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mODIFICARCANTIDADESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    if (NCargoCompra.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 2)
                        return;

                    frmCargoCompra_Opciones frm = new frmCargoCompra_Opciones();
                    int contador_iva = 0, contador_desc = 0;

                    for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                    {
                        if (Convert.ToDecimal(this.dgvProductos.Rows[i].Cells[10].Value) > 0)
                            contador_iva += 1;

                        if (Convert.ToDecimal(this.dgvProductos.Rows[i].Cells[9].Value) > 0)
                            contador_desc += 1;
                    }

                    if (contador_iva == this.dgvProductos.Rows.Count)
                    {
                        frm.cbIVA.Checked = true;
                        frm.rbtnIVA_Todos.Checked = true;
                    }
                    else
                    {
                        if (contador_iva == 0)
                        {
                            frm.cbIVA.Checked = false;
                            frm.rbtnIVA_Todos.Checked = true;
                        }
                        else
                        {
                            if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[10].Value) == 0)
                                frm.cbIVA.Checked = false;
                            else
                                frm.cbIVA.Checked = true;

                            frm.rbtnIVA_Sel.Checked = true;
                        }
                    }

                    if (contador_desc > 0)
                    {
                        decimal porc_descuento = ((Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[9].Value) * 100)/ (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[7].Value)));
                        frm.nuDescuento.Value = porc_descuento;
                    }
                   
                    if (contador_desc == this.dgvProductos.Rows.Count)
                    {
                        frm.cbDesc.Checked = true;
                        frm.rbtnDesc_Todos.Checked = true;
                    }
                    else
                    {
                        if (contador_desc == 0)
                        {
                            frm.cbDesc.Checked = false;
                            frm.rbtnDesc_Todos.Checked = true;
                        }
                        else
                        {
                            if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[9].Value) == 0)
                                frm.cbDesc.Checked = false;
                            else
                                frm.cbDesc.Checked = true;

                            frm.rbtnDesc_Sel.Checked = true;
                        }
                    }

                    frm.ShowDialog();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
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
                    DialogResult resul = MessageBox.Show("Desea imprimir la factura de Cargo Compra.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvFacturas.Focus();
                        return;
                    }

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("cargo_compra");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.num_factura = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frmReporte.Show();

                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void iMPRIMIRENTICKETERAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click_imprimir();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
