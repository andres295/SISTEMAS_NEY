using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.Productos
{
    public partial class frmBuscarProductoComposicion : Form
    {
        public bool pago_venta = false;
        public bool cambio_cliente = false;
        public int name_ventana = 0;
        public bool accion;
        public bool fracciones = false;
        public int captar_id_cliente = 0; 
        List<string> checkedItems = new List<string>();
        public frmBuscarProductoComposicion()
        {
            InitializeComponent();
        } 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_buscar();
        }

        void click_buscar()
        {
            try
            {
                if (name_ventana == 1)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas);

                    if (frm != null)
                    {
                        DataTable dtProducto = new DataTable();
                        dtProducto = NProductos.obtener_productos_venta_por_composicion(this.txtBuscar.Text, cGeneral.stock_producto);

                        if (dtProducto.Rows.Count > 0)
                        {
                            frmVentas.me.dgvFacturas.DataSource = dtProducto;
                            frmVentas.me.dgvFacturas.Refresh();
                            this.Close();
                        }
                        else
                        {
                            frmVentas.me.dgvFacturas.DataSource = dtProducto;
                            frmVentas.me.dgvFacturas.Refresh();
                            this.ttMensaje.ToolTipTitle = "Información";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("No se encontró ningún producto con esa composición química.", this.txtBuscar, 0, 38, 3000);
                        }

                    }
                }
                else if (name_ventana == 2)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_2);

                    if (frm != null)
                    {
                        DataTable dtProducto = new DataTable();
                        dtProducto = NProductos.obtener_productos_venta_por_composicion(this.txtBuscar.Text, cGeneral.stock_producto);

                        if (dtProducto.Rows.Count > 0)
                        {
                            frmVentas_2.me.dgvFacturas.DataSource = dtProducto;
                            frmVentas_2.me.dgvFacturas.Refresh();
                            this.Close();
                        }
                        else
                        {
                            frmVentas_2.me.dgvFacturas.DataSource = dtProducto;
                            frmVentas_2.me.dgvFacturas.Refresh();
                            this.ttMensaje.ToolTipTitle = "Información";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("No se encontró ningún producto con esa composición química.", this.txtBuscar, 0, 38, 3000);
                        }
                    } 
                }
                else if (name_ventana == 3)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_3);

                    if (frm != null)
                    {
                        DataTable dtProducto = new DataTable();
                        dtProducto = NProductos.obtener_productos_venta_por_composicion(this.txtBuscar.Text, cGeneral.stock_producto);

                        if (dtProducto.Rows.Count > 0)
                        {
                            frmVentas_3.me.dgvFacturas.DataSource = dtProducto;
                            frmVentas_3.me.dgvFacturas.Refresh();
                            this.Close();
                        }
                        else
                        {
                            frmVentas_3.me.dgvFacturas.DataSource = dtProducto;
                            frmVentas_3.me.dgvFacturas.Refresh();
                            this.ttMensaje.ToolTipTitle = "Información";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("No se encontró ningún producto con esa composición química.", this.txtBuscar, 0, 38, 3000);
                        }
                    }
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }

        }

        private void frmVentas_Cantidad_Load(object sender, EventArgs e)
        {
            cEstilo_Grid est = new cEstilo_Grid();
            est.grid_selfull_con_alter(this.dgvProductos);
            cargarComposicion();
            cargaProductos("");
            this.dgvProductos.Columns[0].HeaderText = "ID/CODIGO BARRA";
            this.dgvProductos.Columns[1].HeaderText = "PRODUCTO";
            //this.dgvProductos.Columns[2].HeaderText = "PRESENTACION";
            //this.dgvProductos.Columns[3].HeaderText = "PROVEEDOR";
            //this.dgvProductos.Columns[2].HeaderText = "P/COMPRA";
            //this.dgvProductos.Columns[3].HeaderText = "PVP";
            //this.dgvProductos.Columns[4].HeaderText = "DESCUENTO";
            this.dgvProductos.Columns[2].HeaderText = "PVPX";
            this.dgvProductos.Columns[3].HeaderText = "DISPONIBLE";
            this.dgvProductos.Columns[4].HeaderText = "PVFR";
            ///this.dgvProductos.Columns[8].HeaderText = "ESTADO";
            this.dgvProductos.Refresh();
        }
        private void cargaProductos(string id_composicion)
        {
            try
            {

                DataTable especificacion = NProductos.obtener_producto_by_composicion_filter(id_composicion);
                dgvProductos.DataSource = especificacion;
                dgvProductos.Enabled = true;

            }
            catch (Exception ex) { }
        }
        public void cargarComposicion()
        {
            try
            {
                DataTable dt = NProductos.obtener_composicion_by_filter(txtBuscar.Text);
                if (dt.Rows.Count > 0)
                {
                    cblComposicionQuimica.Items.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            string composicion = "";
                            try
                            {
                                composicion = dt.Rows[i]["Composicion"].ToString();
                            }
                            catch (Exception) { composicion = "ND"; }
                            string id = "0";
                            try
                            {
                                id = dt.Rows[i]["Id"].ToString();
                            }
                            catch (Exception) { id = "0"; }

                            bool seleccionado = false;
                            try
                            {
                                seleccionado = dt.Rows[i]["Selecionado"].ToString() == "1" ? true : false;
                            }
                            catch (Exception) { seleccionado = false; }

                            cblComposicionQuimica.Items.Add(new ListItem(composicion, id), seleccionado);

                        }
                        catch (Exception) { }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void nudCantidad1_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_buscar();
        }

        private void nudCantidad2_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_buscar();
        }

        private void nudFracciones_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_buscar();
        }

        private void frmVentas_Cantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (name_ventana == 1)
            {
                frmVentas.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 2)
            {
                frmVentas_2.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 3)
            {
                frmVentas_3.me.tEnfoque.Enabled = true;
            }

        } 
        private bool is_numero(string valor)
        {
            try
            {
                if (valor != "")
                {
                    Convert.ToInt32(valor);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }  
        private void nudCantidad1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        } 
        private void btnGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }

        private void btnGuardar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cblComposicionQuimica_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string id_composicion = "";
            //foreach (var item in cblComposicionQuimica.CheckedItems)
            //    checkedItems.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
            {
                bool exit = false;
                foreach (var item in checkedItems)
                {
                   if (item == cblComposicionQuimica.Items[e.Index].ToString())
                    {
                        exit = true;
                    }
                }
                if (!exit)
                {
                    checkedItems.Add(cblComposicionQuimica.Items[e.Index].ToString());
                } 
            } 
            else
            {
                string sRemove = cblComposicionQuimica.Items[e.Index].ToString();
                checkedItems.Remove(sRemove); 
            } 

            foreach (string item in checkedItems)
            { 
               id_composicion = id_composicion +','+ item; 
            }
            cargaProductos(id_composicion);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cblComposicionQuimica.Items.Clear();
                cargarComposicion();

                for (int count = 0; count < cblComposicionQuimica.Items.Count; count++)
                {
                    if (checkedItems.Contains(cblComposicionQuimica.Items[count].ToString()))
                    {
                        cblComposicionQuimica.SetItemChecked(count, true);
                    }
                }
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

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               

                this.dgvProductos.Rows[e.RowIndex].Cells[4].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[2].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                //this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                //this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                //this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";

                //if (this.dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0" || this.dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0F0")
                //    this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Red;
                //else
                //    this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;
                 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        void click_seleccionar()
        {
            try
            {
                if (name_ventana == 1)
                {
                    frmVentas.me.txtBuscar.Text = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmVentas.me.Buscar_Producto();
                    frmVentas.me.click_agregar_prod();
                    this.Close();
                }
                else if (name_ventana == 2)
                {
                    frmVentas_2.me.txtBuscar.Text = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmVentas_2.me.Buscar_Producto();
                    frmVentas_2.me.click_agregar_prod();
                    this.Close();
                }
                else if (name_ventana == 3)
                {
                    frmVentas_3.me.txtBuscar.Text = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmVentas_3.me.Buscar_Producto();
                    frmVentas_3.me.click_agregar_prod();
                    this.Close();
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                click_seleccionar();
            }
            else if (e.KeyValue == 27)
                this.Close();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            click_seleccionar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            checkedItems.Clear();
            cblComposicionQuimica.Items.Clear();
            cargarComposicion();
            cargaProductos("0");
        }
    }
}
