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
    public partial class frmCargoTransferencia : Form
    {
        public static frmCargoTransferencia me;

        public frmCargoTransferencia()
        {
            frmCargoTransferencia.me = this;
            InitializeComponent();
        }

        public void cargar_totales(string fact)
        {
            try
            {
                DataTable dt_datos = NCargoTransferencia.obtener_totales(fact);

                if (dt_datos.Rows[0].ItemArray[0].ToString() == "")
                    this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales + "");
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCargoTransferencia_Acciones frm = new frmCargoTransferencia_Acciones();
            frm.Text = "AGREGAR";
            frm.dtpFechaDoc.Value = DateTime.Now.Date;

            frm.cmbProveedor.DataSource = NProveedores.lista_combo();
            frm.cmbProveedor.ValueMember = "Id";
            frm.cmbProveedor.DisplayMember = "Proveedor";

            if (frm.cmbProveedor.Items.Count > 0)
                frm.cmbProveedor.SelectedIndex = 0;

            frm.ShowDialog();
        }

        private void frmCargoTransferencia_Load(object sender, EventArgs e)
        {
            this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            cEstilo_Grid est = new cEstilo_Grid();
            est.grid_selfull_con_alter(this.dgvFacturas);
            est.grid_selfree_con_alter(this.dgvProductos);
            est.SetDoubleBuffered(this.dgvFacturas);
            est.SetDoubleBuffered(this.dgvProductos);

            this.tBuscar.Interval = cGeneral.timer;

            this.dgvFacturas.DataSource = NCargoTransferencia.buscar_fact(cGeneral.id_user_actual, "", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
            this.orden_fact(this.dgvFacturas);
            this.dgvProductos.DataSource = NCargoTransferencia.cargar_prod(cGeneral.id_user_actual, "");

            this.txtRegistros.Text = NCargoTransferencia.num_reg().ToString("N0");

            cGeneral.ajuste_columnas(this.dgvFacturas);
            cGeneral.ajuste_columnas(this.dgvProductos);

            if (this.txtRegistros.Text == "0")
                this.btnAgregar.Focus();
            else
            {
                this.txtBuscar.Enabled = true;
                //this.txtBuscar.Focus();
            }

            ///dtpDesde.Value = System.DateTime.Now.AddDays(-30);

            ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        void orden_fact(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[2], ListSortDirection.Ascending);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmCargoTransferencia_Acciones frm = new frmCargoTransferencia_Acciones();
            frm.Text = "MODIFICAR";

            frm.cmbProveedor.DataSource = NProveedores.lista_combo();
            frm.cmbProveedor.ValueMember = "Id";
            frm.cmbProveedor.DisplayMember = "Proveedor";

            DataTable dt_datos = NCargoTransferencia.obtener_datos(cGeneral.id_user_actual, Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));

            if (dt_datos.Rows.Count > 0)
            {
                frm.txtAlmacen.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                frm.txtTipoMov.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                frm.cmbProveedor.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                frm.dtpFechaDoc.Value = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[6].ToString()).Date;
                frm.txtObserv.Text = dt_datos.Rows[0].ItemArray[7].ToString();
            }
            frm.ShowDialog();
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "G";

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                this.dgvFacturas.Columns[2].Frozen = true;

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
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;

                this.dgvProductos.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NCargoTransferencia.buscar_fact(cGeneral.id_user_actual, this.txtBuscar.Text, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                this.orden_fact(this.dgvFacturas);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;

                    ///this.txtBuscar.Focus();
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    /// this.txtBuscar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (this.dgvFacturas.Rows.Count > 0)
            {
                frmCargoTransferencia_Productos frm = new frmCargoTransferencia_Productos();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se puede realizar la acción de producto si no a ingresado el Cargo Transferencia", "Acción Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar_CJ();
        }

        void click_eliminar_CJ()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar éste Cargo Transferencia.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvFacturas.Focus();
                    return;
                }
                DataTable dtProducto = NCargoCompra.valida_disponiblidad_producto("CARGO TRANSFERENCIA", this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (dtProducto.Rows.Count <= 0)
                {
                    NCargoTransferencia.eliminar_CJ(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                    this.dgvFacturas.Rows.Remove(this.dgvFacturas.CurrentRow);
                    if (dgvFacturas.Rows.Count>0)
                    {
                        this.txtRegistros.Text = NCargoTransferencia.num_reg().ToString("N0");
                    } 
                    if (this.txtRegistros.Text == "0")
                    {
                        this.txtBuscar.Enabled = false;
                        this.txtBuscar.Text = "";
                    }
                    else
                    {
                        if (dgvFacturas.Rows.Count>0)
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
                    frm.tipo_mov = "CARGO TRANSFERENCIA";
                    frm.uGridListaProducto.DataBind();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
                else if (e.KeyValue == 46)
                    click_eliminar_CJ();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
            if (this.dgvFacturas.Rows.Count == 0)
            {
                if (this.txtBuscar.Enabled == false)
                {
                    this.btnAgregar.Focus();
                }
            }
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

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            ///// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.btnAgregarProd.Enabled = false;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;

                this.tCargarProd.Enabled = false;
                this.tCargarProd.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tCargarProd_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tCargarProd.Enabled = false;

                if (this.dgvFacturas.Rows.Count > 0)
                {
                    this.dgvProductos.DataSource = NCargoTransferencia.cargar_prod(cGeneral.id_user_actual, this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    cargar_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                    if (NCargoTransferencia.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 1)
                    {
                        //CargoAjuste_Productos_Temp
                        this.btnAgregarProd.Enabled = true;
                        this.btnModificarProd.Enabled = true;
                        this.btnEliminarProd.Enabled = true;
                        this.btnGuardar.Enabled = true;
                    }
                    else if (NCargoTransferencia.verificar_cant_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 2)
                    {
                        //CargoAjuste_Productos
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
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0)
            {
                click_eliminar_prod();
            }
            else
            {
                MessageBox.Show("No se puede realizar la acción de producto si no a ingresado el Cargo Transferencia", "Acción Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

                NCargoTransferencia.eliminar_prod(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value), this.dgvProductos.CurrentRow.Cells["Id"].Value.ToString());
                this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);

                this.dgvFacturas.CurrentRow.Cells[2].Value = NCargoTransferencia.actualizar_nombre_prov(cGeneral.id_user_actual, Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                DataTable dt_totales = NCargoTransferencia.obtener_totales(frmCargoTransferencia.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (dt_totales.Rows[0].ItemArray[0].ToString() == "")
                    this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    this.lblSubtotal.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales + "");

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
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
            else if (e.KeyValue == 46)
                click_eliminar_prod();
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
                if (this.dgvFacturas.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == false)
                        this.btnAgregar.Focus();
                    else
                        this.txtBuscar.Focus();
                }
                else
                    this.dgvFacturas.Focus();
        }

        private void btnModificarProd_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0)
            {
                frmCargoTransferencia_Cantidad frm = new frmCargoTransferencia_Cantidad();
                frm.idItemProducto = int.Parse(this.dgvProductos.CurrentRow.Cells["Id"].Value.ToString());
                frm.dtpVencimiento.Value = Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[6].Value.ToString());
                frm.txtLote.Text = this.dgvProductos.CurrentRow.Cells[7].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se puede realizar la acción de producto si no a ingresado el Cargo Ajuste", "Acción Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.dgvFacturas.Rows.Count > 0 && dgvProductos.Rows.Count > 0)
            {
                click_guardar();
            }
            else
            {
                MessageBox.Show("No se puede realizar la acción de producto si no a ingresado el Cargo Ajuste", "Acción Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }  
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.txtBuscar.Text == "")
                    {
                        this.tBuscar.Enabled = false;

                        this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");

                        this.dgvFacturas.DataSource = NCargoTransferencia.buscar_fact(cGeneral.id_user_actual, "", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                        this.orden_fact(this.dgvFacturas);
                        this.dgvProductos.DataSource = NCargoTransferencia.cargar_prod(cGeneral.id_user_actual, "");

                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnAgregarProd.Enabled = false;
                        this.btnModificarProd.Enabled = false;
                        this.btnEliminarProd.Enabled = false;
                        this.btnGuardar.Enabled = false;

                        if (this.txtBuscar.Enabled == false)
                        {
                            this.btnAgregar.Focus();
                        } 
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

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
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

        private void pbOpciones_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0 && this.dgvFacturas.Rows.Count > 0)
            {
                this.iMPRIMIRENTICKETERAToolStripMenuItem.Enabled = true;
                this.contextMenuStrip1.Show(this.pbOpciones, new Point(0, -50));
            }
            else
            {
                this.iMPRIMIRENTICKETERAToolStripMenuItem.Enabled = false;
            }
        }

        private void iMPRIMIRENTICKETERAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print_cargo_ajuste();
        }
        void click_imprimir()
        {
            print_cargo_ajuste();
        }
        public void print_cargo_ajuste()
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("Desea imprimir el documento de Cargo Transferencia.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvFacturas.Focus();
                        return;
                    }

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("cargo_transferencia_inv");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.num_factura = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frmReporte.Show();

                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        void click_guardar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea guardar éstos productos.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvProductos.Focus();
                    return;
                }

                NCargoTransferencia.guardar(cGeneral.id_user_actual, Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                this.dgvFacturas.CurrentRow.Cells[2].Value = NCargoTransferencia.actualizar_nombre_prov(cGeneral.id_user_actual, Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));

                click_imprimir();

                this.btnAgregarProd.Enabled = false;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.dgvFacturas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 7 && this.btnGuardar.Enabled)
                click_guardar();
            else if (e.KeyChar == 18)
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

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("cargo_transferencia_inventario_rpt");
            frmReporte.fecha_inicio = dtpDesde.Value.ToShortDateString();
            frmReporte.fecha_fin = dtpHasta.Value.ToShortDateString();
            frmReporte.id = txtBuscar.Text;
            frmReporte.Show();
        }

        private void bntReImprimir_Click(object sender, EventArgs e)
        {
            click_imprimir();
        }
    }
}
