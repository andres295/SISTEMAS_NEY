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

namespace SCM.CxC
{
    public partial class frmCuentasPorCobrar_NC : Form
    {
        public static frmCuentasPorCobrar_NC me;
        public string num_venta = "";
        public bool automatica = false;
        public frmCuentasPorCobrar_NC()
        {
            frmCuentasPorCobrar_NC.me = this;
            InitializeComponent();
        }

        public bool abrir_frm = false;

        public void orden_fact(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
        }

        public void orden_prod(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
        }

        private void frmCuentasPorCobrar_NC_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.grid_selfree_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvProductos);

                this.dgvFacturas.DataSource = NNotasCreditosCXC.buscar("");
                this.orden_fact(this.dgvFacturas);
                this.dgvProductos.DataSource = NNotasCreditosCXC.cargar_prod("");
                this.orden_prod(this.dgvProductos);

                this.txtRegistros.Text = NNotasCreditosCXC.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvProductos);

                if (this.txtRegistros.Text == "0")
                    this.btnAgregar.Focus();
                else
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCuentasPorCobrar_NC_Agregar frm = new frmCuentasPorCobrar_NC_Agregar();
            frm.Text = "AGREGAR";
            frm.automatica = this.automatica;
            frm.num_venta = this.num_venta;
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_datos = NNotasCreditosCXC.obtener_datos_nc(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                frmCuentasPorCobrar_NC_Agregar frm = new frmCuentasPorCobrar_NC_Agregar();
                frm.Text = "MODIFICAR";

                frm.mtxtNC.Mask = cGeneral.formato_NC;
                frm.mtxtFactura.Mask = cGeneral.formato_factura;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;
                frm.mtxtRUC.Mask = cGeneral.formato_ruc;
                frm.nc_actual = dt_datos.Rows[0].ItemArray[0].ToString();
                frm.mtxtNC.Text = dt_datos.Rows[0].ItemArray[0].ToString();
                frm.dtpFechaDoc.Value = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[4].ToString()).Date;
                frm.mtxtFactura.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[6].ToString();
                frm.txtCliente.Text = dt_datos.Rows[0].ItemArray[10].ToString();
                ///frm.txtMatriz.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[7].ToString();
                frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[8].ToString();
                frm.txtObser.Text = dt_datos.Rows[0].ItemArray[9].ToString();

                frm.id_cliente_captado = Convert.ToInt32(dt_datos.Rows[0].ItemArray[2].ToString());
                frm.cliente_captado = dt_datos.Rows[0].ItemArray[10].ToString();
                
                frm.ShowDialog();
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
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;

                Font font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[2].Style.Font = font;
                this.dgvProductos.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Blue;
                this.dgvProductos.Rows[e.RowIndex].Cells[3].Style.Font = font;
                this.dgvProductos.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Red;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void cargar_totales()
        {
            try
            {
                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                    this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                    this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                    this.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                }
                else
                {
                    DataTable dt_datos;

                    if (this.txtBuscar.Text == "")
                        dt_datos = NNotasCreditosCXC.obtener_totales("");
                    else
                        dt_datos = NNotasCreditosCXC.obtener_totales(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

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
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NNotasCreditosCXC.buscar(this.txtBuscar.Text);
                this.orden_fact(this.dgvFacturas);
                this.cargar_totales();

                if (this.dgvFacturas.Rows.Count == 0)
                {
                   /// this.txtBuscar.Focus();
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.dgvProductos.DataSource = NNotasCreditosCXC.cargar_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    this.orden_prod(this.dgvProductos);

                    this.tAutoFrm.Enabled = true;
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;

                    ///this.dgvFacturas.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
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

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                this.dgvFacturas.Columns[2].Frozen = true;

                this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "G";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFacturas.Rows.Count == 0)
                    if (this.txtBuscar.Enabled == false)
                        this.btnAgregar.Focus();
                    else
                        this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count == 0)
                    this.dgvFacturas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
            else if (e.KeyValue == 46)
                click_eliminar_prod();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.txtBuscar.Text == "")
                    {
                        this.dgvFacturas.DataSource = NNotasCreditosCXC.buscar("");
                        this.orden_fact(this.dgvFacturas);
                        this.dgvProductos.DataSource = NNotasCreditosCXC.cargar_prod("");
                        this.orden_prod(this.dgvProductos);

                        this.cargar_totales();

                        this.tBuscar.Enabled = false;
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

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            frmCuentasPorCobrar_NC_Productos frm = new frmCuentasPorCobrar_NC_Productos();
            frm.ShowDialog();
        }

        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvFacturas.Rows.Count > 0)
                {
                    this.dgvProductos.DataSource = NNotasCreditosCXC.cargar_prod(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.orden_prod(this.dgvProductos);

                    if (NNotasCreditosCXC.verificar(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString()) > 0)
                    {
                        this.btnAgregarProd.Enabled = false;
                        this.btnModificarProd.Enabled = false;
                        this.btnEliminarProd.Enabled = false;
                        this.btnGuardar.Enabled = false;
                    }
                    else
                    {
                        if (NNotasCreditosCXC.verificar_temp(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString()) == 0)
                        {
                            this.btnAgregarProd.Enabled = true;
                            this.btnModificarProd.Enabled = false;
                            this.btnEliminarProd.Enabled = false;
                            this.btnGuardar.Enabled = false;
                        }
                        else
                        {
                            this.btnAgregarProd.Enabled = true;
                            this.btnModificarProd.Enabled = true;
                            this.btnEliminarProd.Enabled = true;
                            this.btnGuardar.Enabled = true;
                        }
                    }

                    DataTable dt_datos;

                    if (this.txtBuscar.Text == "")
                        dt_datos = NNotasCreditosCXC.obtener_totales("");
                    else
                        dt_datos = NNotasCreditosCXC.obtener_totales(this.dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString());

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
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificarProd_Click(object sender, EventArgs e)
        {
            frmCuentasPorCobrar_NC_Cantidad frm = new frmCuentasPorCobrar_NC_Cantidad();
            frm.nudCantidad.Value = Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[2].Value);
           /// frm.nudBonificacion.Value = Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[3].Value);

            //if (frm.nudBonificacion.Value == 0)
            //{
            //    frm.label4.Enabled = false;
            //    frm.nudBonificacion.Enabled = false;
            //}

            frm.ShowDialog();
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

                NNotasCreditosCXC.eliminar_prod(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);
                cargar_totales();

                this.dgvFacturas.CurrentRow.Cells[2].Value = NNotasCreditosCXC.actualizar_nombre(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (this.dgvProductos.Rows.Count == 0)
                {
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        void click_guardar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea guardar ésta NC.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvFacturas.Focus();
                    return;
                }

                NNotasCreditosCXC.guardar(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvFacturas.CurrentRow.Cells[1].Value.ToString());
                frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[2].Value = NNotasCreditosCXC.actualizar_nombre(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                {
                    NNotasCreditosCXC.actualizar_stock(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), this.dgvProductos.Rows[i].Cells[0].Value.ToString(), true);
                }

                for (int fila = 0; fila < frmCuentasPorCobrar.me.uGridFactura.Rows.Count; fila++)
                {
                    if (num_venta == frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[1].Value.ToString())
                    {
                        DataTable dt_datos = NCuentasPorCobrar.actualizar_fila_fact(num_venta);

                        frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[10].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString());
                        frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[14].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString());  
                        frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[15].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
                        frmCuentasPorCobrar.me.uGridFactura.Rows[fila].Cells[16].Value = dt_datos.Rows[0].ItemArray[5].ToString();
                        break;
                    }
                }
                this.Close();
                ///frmCuentasPorCobrar.me.actualizar_fila_fact(frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[0].Value.ToString());

                this.btnAgregarProd.Enabled = false;
                this.btnModificarProd.Enabled = false;
                this.btnEliminarProd.Enabled = false;
                this.btnGuardar.Enabled = false;

                this.ttMensaje.ToolTipTitle = "LISTO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                this.ttMensaje.Show("La NC ha sido guardada", this.txtBuscar, 0, 26, 3000);
                this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea eliminar ésta NC.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvFacturas.Focus();
                    return;
                }

                if (this.dgvProductos.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                    {
                        NNotasCreditosCXC.actualizar_stock(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), this.dgvProductos.Rows[i].Cells[0].Value.ToString(), false);
                    }

                    NNotasCreditosCXC.deducir_nc(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.dgvFacturas.CurrentRow.Cells[1].Value.ToString());
                }

                NNotasCreditosCXC.eliminar_nc(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                this.dgvFacturas.Rows.Remove(this.dgvFacturas.CurrentRow);
                this.txtRegistros.Text = NNotasCreditosCXC.num_reg().ToString("N0");

                this.ttMensaje.ToolTipTitle = "LISTO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                this.ttMensaje.Show("La NC ha sido eliminada", this.txtBuscar, 0, 26, 3000);

                if (this.txtRegistros.Text == "0")
                {
                    this.btnAgregarProd.Enabled = false;
                    this.btnModificarProd.Enabled = false;
                    this.btnEliminarProd.Enabled = false;
                    this.btnGuardar.Enabled = false;
                    this.txtBuscar.Enabled = false;
                    this.txtBuscar.Text = "";
                    this.btnAgregar.Focus();
                }
                else
                {

                    if (this.dgvFacturas.Rows.Count > 0)
                    {
                        frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[2].Value = NNotasCreditosCXC.actualizar_nombre(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                        this.dgvFacturas.Rows[this.dgvProductos.CurrentRow.Index].Selected = true;
                        this.dgvFacturas.Focus();
                    } 
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tAutoFrm_Tick(object sender, EventArgs e)
        {
            this.tAutoFrm.Enabled = false;

            if (abrir_frm)
            {
                abrir_frm = false;

                frmCuentasPorCobrar_NC_Productos frm = new frmCuentasPorCobrar_NC_Productos();
                frm.filtrar_producto = true;
                frm.ShowDialog();
            }
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
    }
}
