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
    public partial class frmCuentasPorCobrar_NC_Productos : Form
    {
        public bool filtrar_producto = false;
        public frmCuentasPorCobrar_NC_Productos()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudCantidad);
        }

        private void nudCantidad_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudCantidad);
        } 
        private void frmCuentasPorCobrar_NC_Productos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfree_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvProductos);

                this.tBuscar.Interval = cGeneral.timer;

                if (frmCuentasPorCobrar_NC.me.btnGuardar.Enabled == true)
                {
                    if (frmCuentasPorCobrar_NC.me.dgvProductos.Rows.Count == 1)
                        this.Text = this.Text + " | HAY 1 PRODUCTO AGREGADO";
                    else
                        this.Text = this.Text + " | HAY " + frmCuentasPorCobrar_NC.me.dgvProductos.Rows.Count + " PRODUCTOS AGREGADOS";
                }

                if (filtrar_producto)
                {
                    txtBuscar.Text = "*";
                    cargar_productos_automatico();
                }
                else
                {
                    this.dgvProductos.DataSource = NNotasCreditosCXC.buscar_prod("", "");
                }
               
                this.orden();

                cGeneral.ajuste_columnas(this.dgvProductos);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void orden()
        {
            this.dgvProductos.Sort(this.dgvProductos.Columns[2], ListSortDirection.Ascending);
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count == 0)
                this.txtBuscar.Focus();
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

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;
                this.dgvProductos.Columns[2].Frozen = true;
                this.dgvProductos.Columns[3].Frozen = true;
                this.dgvProductos.Columns[4].Frozen = true;

                Font font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[2].Style.Font = font;
                this.dgvProductos.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Blue;
                this.dgvProductos.Rows[e.RowIndex].Cells[3].Style.Font = font;
                this.dgvProductos.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Red;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
            else if (e.KeyValue == 27)
                this.Close();
        }

        void click_guardar()
        {
            try
            {
                this.ttMensaje.Hide(this.nudCantidad); 
                long disponibilidad = 0;

                if (this.nudCantidad.Text == "")
                {
                    this.nudCantidad.Value = 0;
                    this.nudCantidad.Text = this.nudCantidad.Value.ToString();
                }
                else
                    this.nudCantidad.Value = Convert.ToDecimal(this.nudCantidad.Text);
                     disponibilidad = NProductos.obtener_disponible(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                 
                if (this.nudCantidad.Text == "0")
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad, 0, 26, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
                else if (Convert.ToInt32(this.nudCantidad.Value) > Convert.ToInt32(this.dgvProductos.CurrentRow.Cells[2].Value))
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta cantidad es mayor que la real", this.nudCantidad, 0, 26, 3000);
                    this.nudCantidad.Focus();
                    return;
                }  
                else if (NNotasCreditosCXC.existe_prod(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString()) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este producto ya está agregado", this.nudCantidad, 0, 26, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
                else if (disponibilidad < Convert.ToInt32(this.nudCantidad.Value))
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("La disponiblidad de este producto es: " + disponibilidad + ". No se puede acreditar más de lo disponible.", this.nudCantidad, 0, 26, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
                NNotasCreditosCXC.guardar_prod_temp(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(this.nudCantidad.Value),0);

                frmCuentasPorCobrar_NC.me.dgvProductos.DataSource = NNotasCreditosCXC.cargar_prod(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                frmCuentasPorCobrar_NC.me.orden_prod(frmCuentasPorCobrar_NC.me.dgvProductos);
                frmCuentasPorCobrar_NC.me.cargar_totales();

                frmCuentasPorCobrar_NC.me.btnModificarProd.Enabled = true;
                frmCuentasPorCobrar_NC.me.btnEliminarProd.Enabled = true;
                frmCuentasPorCobrar_NC.me.btnGuardar.Enabled = true;

                frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[2].Value = NNotasCreditosCXC.actualizar_nombre(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                this.txtBuscar.Focus();
                this.txtBuscar.Text = "";

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvProductos.DataSource = NNotasCreditosCXC.buscar_prod(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), this.txtBuscar.Text);
                this.orden();

                if (this.dgvProductos.Rows.Count == 0)
                {
                    this.nudCantidad.Value = 0; 
                    this.pCantidades.Enabled = false;
                    this.txtBuscar.Focus();
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.pCantidades.Enabled = true;
                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
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
                        this.ttMensaje.Hide(this.txtBuscar);
                        this.ttMensaje.Hide(this.nudCantidad);

                        this.tBuscar.Enabled = false;
                        this.dgvProductos.DataSource = NNotasCreditosCXC.buscar_prod("", "");
                        this.orden();
                        this.nudCantidad.Value = 0; 
                        this.pCantidades.Enabled = false;
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
        private void cargar_productos_automatico()
        {
            try
            {
                if (frmCuentasPorCobrar_NC.me.dgvFacturas.RowCount>0)
                {
                    this.tBuscar.Enabled = false;

                    this.dgvProductos.DataSource = NNotasCreditosCXC.buscar_prod(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), this.txtBuscar.Text);
                    this.orden();

                    if (this.dgvProductos.Rows.Count == 0)
                    {
                        this.nudCantidad.Value = 0; 
                        this.pCantidades.Enabled = false;
                        this.txtBuscar.Focus();
                        ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                    }
                    else
                    {
                        this.pCantidades.Enabled = true;
                        this.txtBuscar.Focus();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void nudBonificacion_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
    }
}
