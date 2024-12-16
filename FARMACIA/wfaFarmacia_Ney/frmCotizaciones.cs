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
    public partial class frmCotizaciones : Form
    {
        public static frmCotizaciones me;
        public int captar_id_cliente = 0;
        public frmCotizaciones()
        {
            frmCotizaciones.me = this;
            InitializeComponent();
        }

        public void cargar_totales(int id_cot)
        {
            try
            {
                DataTable dt_datos = NCotizaciones.obtener_montos(id_cot);

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
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden_prod(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
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

                this.dgvFacturas.DataSource = NCotizaciones.buscar(0, "");
                this.orden_fact(this.dgvFacturas);
                this.dgvProductos.DataSource = NCotizaciones.cargar_prod(0);
                this.orden_prod(this.dgvProductos);

                this.txtRegistros.Text = NCotizaciones.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvProductos);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden_fact(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[2], ListSortDirection.Ascending);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCotizaciones_Acciones frm = new frmCotizaciones_Acciones();
            frm.Text = "SELECCIONE EL NOMBRE DEL CLIENTE";
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmCotizaciones_Acciones frm = new frmCotizaciones_Acciones();
            frm.Text = "CAMBIAR EL NOMBRE DEL CLIENTE";
            frm.ShowDialog();
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NCotizaciones.buscar(cGeneral.id_user_actual, this.txtBuscar.Text);
                this.orden_fact(this.dgvFacturas);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnAgregarProd.Enabled = false;
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
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
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvFacturas.Columns[3].DefaultCellStyle.Format = "G";

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                this.dgvFacturas.Columns[2].Frozen = true;

                this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Rows[0].Selected = true;
                    dgvProductos.Focus();
                }
            }
            else if (e.KeyValue == cGeneral.f3)
            {
                click_nam_temp(false, true);
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                click_imprimir();
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                guardar();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnAgregarProd.Enabled = false;
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;

                    this.dgvFacturas.DataSource = NCotizaciones.buscar(0, "");
                    this.orden_fact(this.dgvFacturas);
                    this.dgvProductos.DataSource = NCotizaciones.cargar_prod(0);
                    this.orden_prod(this.dgvProductos);
                    this.cargar_totales(0);

                    this.txtBuscar.Focus();
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
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
            else if (e.KeyValue == cGeneral.f3)
            {
                click_nam_temp(false, true);
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                click_imprimir();
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                guardar();
            }
        }
        void click_nam_temp(bool pago_venta, bool cambio_cliente)
        {
            Ventas.frmVentas_NombreTemp frm = new Ventas.frmVentas_NombreTemp();
            frm.Text = "GUARDAR TEMP COTIZACIÓN";
            frm.pago_venta = pago_venta;
            frm.name_ventana = 4;
            frm.cambio_cliente = cambio_cliente;
            frm.ShowDialog();
        }
        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            frmCotizaciones_Productos frm = new frmCotizaciones_Productos();
            frm.ShowDialog();
        }

        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvProductos.DataSource = NCotizaciones.cargar_prod(Convert.ToInt32(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value));
                this.orden_prod(this.dgvProductos);
                this.cargar_totales(Convert.ToInt32(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value));

                if (NCotizaciones.num_reg_temp(Convert.ToInt32(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value)) > 0)
                {
                    this.btnAgregarProd.Enabled = true;
                    this.btnModificarProd.Enabled = true;
                    this.btnEliminarProd.Enabled = true;
                    this.btnGuardar.Enabled = true;
                }
                else if (NCotizaciones.num_reg_save(Convert.ToInt32(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value)) > 0)
                {
                    this.btnAgregarProd.Enabled = false;
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;
                }
                else
                {
                    this.btnAgregarProd.Enabled = true;
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[10].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                this.dgvProductos.Rows[e.RowIndex].Cells[5].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;

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
                DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar éste producto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvProductos.Focus();
                    return;
                }

                NCotizaciones.eliminar_prod(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value), this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                this.dgvFacturas.CurrentRow.Cells[2].Value = NCotizaciones.actualizar_nombre_prov(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                this.cargar_totales(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));

                this.dgvProductos.DataSource = NCotizaciones.cargar_prod(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                this.orden_prod(this.dgvProductos);

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
            {
                if (this.txtBuscar.Text == "")
                    this.Close();
                else
                    this.txtBuscar.Text = "";
            }
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
            else if (e.KeyValue == cGeneral.f1)
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Rows[0].Selected = true;
                    dgvProductos.Focus();
                }
            }
            else if (e.KeyValue == cGeneral.f3)
            {
                click_nam_temp(false, true);
            }
            else if (e.KeyValue == cGeneral.f5)
            {
                click_imprimir();
            }
            else if (e.KeyValue == cGeneral.f7)
            {
                guardar();
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
                    this.btnAgregar.Focus();
                else
                    this.txtBuscar.Focus();
            }
        }

        private void btnModificarProd_Click(object sender, EventArgs e)
        {
            frmCotizaciones_Cantidad frm = new frmCotizaciones_Cantidad();
            frm.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        void guardar()
        {
            try
            {
                DialogResult resul;

                if (this.dgvProductos.Rows.Count == 1)
                    resul = MessageBox.Show("Desea guardar el producto de ésta cotización.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    resul = MessageBox.Show("Desea guardar los productos de ésta cotización.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvProductos.Focus();
                    return;
                }

                NCotizaciones.guardar_prod(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                this.dgvFacturas.CurrentRow.Cells[2].Value = NCotizaciones.actualizar_nombre_prov(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));

                this.btnAgregarProd.Enabled = false;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;

                this.ttMensaje.ToolTipTitle = "LISTO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;

                if (this.dgvProductos.Rows.Count == 1)
                    this.ttMensaje.Show("El producto ha sido guardado", this.txtBuscar, 0, 26, 3000);
                else
                    this.ttMensaje.Show("Los productos han sido guardado", this.txtBuscar, 0, 26, 3000);

                this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbOpciones_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count > 0)
            {
                if (this.btnGuardar.Enabled == false)
                    this.pAGARCOTIZACIÓNToolStripMenuItem.Enabled = true;
                else
                    this.pAGARCOTIZACIÓNToolStripMenuItem.Enabled = false;

                this.iMPRIMIRToolStripMenuItem.Enabled = true;
                this.contextMenuStrip1.Show(this.pbOpciones, new Point(-85, -55));
            }
        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click_imprimir();
        }

        void click_imprimir()
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("Desea imprimir la Cotización.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvFacturas.Focus();
                        return;
                    }

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("rpt_cotizacion_venta");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.num_cotizacion = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frmReporte.Show();

                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 7)
                guardar();
            else if (e.KeyChar == 16)
                click_pagar();
            else if (e.KeyChar == 18)
                click_imprimir();
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 7)
                guardar();
            else if (e.KeyChar == 16)
                click_pagar();
            else if (e.KeyChar == 18)
                click_imprimir();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvProductos.Rows.Count == 0)
                    if (this.dgvFacturas.Rows.Count == 0)
                    {
                        if (this.txtBuscar.Enabled == true)
                            this.txtBuscar.Focus();
                        else
                            this.btnAgregar.Focus();
                    }
                    else
                        this.dgvFacturas.Focus();
                else
                    this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar_cot();
        }

        void click_eliminar_cot()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta cotización.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvFacturas.Focus();
                    return;
                }

                NCotizaciones.eliminar_cot(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                this.dgvFacturas.Rows.Remove(this.dgvFacturas.CurrentRow);
                this.txtRegistros.Text = NCotizaciones.num_reg().ToString("N0");

                if (this.txtRegistros.Text == "0")
                {
                    this.txtBuscar.Enabled = false;
                    this.txtBuscar.Text = "";
                }
                else
                {
                    this.dgvFacturas.Rows[this.dgvFacturas.CurrentRow.Index].Selected = true;
                    this.dgvFacturas.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pAGARCOTIZACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click_pagar();
        }

        void click_pagar()
        {
            if (this.dgvProductos.Rows.Count > 0)
                if (this.btnGuardar.Enabled == false)
                {
                    Cotizacion.frmCotizacion_Pagar_Efectivo frm = new Cotizacion.frmCotizacion_Pagar_Efectivo();
                    frm.captura_num_cotizacion = this.dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                    frm.cbEfectivo.Checked = true;
                    frm.ShowDialog();
                }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.RowCount > 0)
                {
                    txtNumVenta.Text = dgvFacturas.CurrentRow.Cells[0].Value.ToString();
                } 
            }
            catch (Exception)
            {

                txtNumVenta.Text = "0";
            }
           
        }

        private void btnVentas_Temp_Click(object sender, EventArgs e)
        {
            //this.dgvFacturas.DataSource = NCotizaciones.buscar_by_id(0);
            //this.dgvFacturas.Refresh();

            //this.dgvProductos.DataSource = NCotizaciones.cargar_prod(0);
            //this.dgvProductos.Refresh();
            frmVentas_Clientes frm = new frmVentas_Clientes();
            frm.Text = "COTIZACIONES GUARDADAS TEMPORALMENTE";
            frm.name_ventana = 4;
            frm.ShowDialog();
        }
    }
}
