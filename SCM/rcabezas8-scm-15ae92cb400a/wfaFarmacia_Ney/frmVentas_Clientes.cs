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
    public partial class frmVentas_Clientes : Form
    {
        public frmVentas_Clientes()
        {
            InitializeComponent();
        }
        public int name_ventana = 0;
        void orden(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[0], ListSortDirection.Descending);
        }

        private void frmVentas_Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvFacturas);

                this.tBuscar.Interval = cGeneral.timer;
                if (name_ventana == 4)
                {
                    this.dgvFacturas.DataSource = NCotizaciones.buscar_cotizacion_tem("", cGeneral.id_user_actual);
                }
                else
                {
                    this.dgvFacturas.DataSource = NVentas.buscar_ventas_tem("", cGeneral.id_user_actual);
                } 
                this.orden(dgvFacturas);
                txtBuscar.Text = "*";
                cGeneral.ajuste_columnas(this.dgvFacturas);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;
                 
                if (name_ventana == 4)
                {
                    this.dgvFacturas.DataSource = NCotizaciones.buscar_cotizacion_tem(this.txtBuscar.Text, cGeneral.id_user_actual);
                }
                else
                {
                    this.dgvFacturas.DataSource = NVentas.buscar_ventas_tem(this.txtBuscar.Text, cGeneral.id_user_actual);
                }
                this.orden(dgvFacturas);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnSeleccionar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    ///this.txtBuscar.Focus();
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnSeleccionar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    ///this.dgvFacturas.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
            //if (this.dgvFacturas.Rows.Count == 0)
              ///  this.txtBuscar.Focus();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
           //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
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

                this.dgvFacturas.Columns[4].DefaultCellStyle.Format = "G";

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                this.dgvFacturas.Columns[2].Frozen = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;

            if (e.KeyValue == 13)
                click_seleccionar();
            else if (e.KeyValue == 27)
                if (this.dgvFacturas.Rows.Count > 0)
                    this.txtBuscar.Text = "";
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                if (this.dgvFacturas.Rows.Count == 0)
                    this.Close();

            } 
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.txtBuscar.Text == "")
                    {
                        this.tBuscar.Enabled = false;
                        this.btnSeleccionar.Enabled = false;
                        this.btnEliminar.Enabled = false;

                        if (name_ventana == 4)
                        {
                            this.dgvFacturas.DataSource = NCotizaciones.buscar_cotizacion_tem("", cGeneral.id_user_actual);
                        }
                       else
                        {
                            this.dgvFacturas.DataSource = NVentas.buscar_ventas_tem("", cGeneral.id_user_actual);
                        }
                        this.orden(dgvFacturas);
                        ///.txtBuscar.Focus();
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            click_seleccionar();
        }

        void click_seleccionar()
        {
            try
            {
                if (name_ventana == 1 )
                {
                    frmVentas.me.txtNumVenta.Text = Convert.ToInt64(this.dgvFacturas.CurrentRow.Cells[0].Value).ToString();
                    frmVentas.me.captar_id_cliente = Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[1].Value);
                    frmVentas.me.cliente_seleccionado = true;

                    if (frmVentas.me.captar_id_cliente == 0)
                    {
                        frmVentas.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        frmVentas.me.Text = frmVentas.me.Text + " - " + "Ventana #1";
                        frmVentas.me.Text = frmVentas.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: NINGUNO ***";

                    }
                    else
                    {
                        DataTable dt = NClientes.obtener_datos(frmVentas.me.captar_id_cliente);
                        frmVentas.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        frmVentas.me.Text = frmVentas.me.Text + " - " + "Ventana #1";
                        frmVentas.me.Text = frmVentas.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: " + dt.Rows[0].ItemArray[3].ToString() + " ***";

                    }

                    frmVentas.me.btnAgregar.Enabled = false;
                    frmVentas.me.btnModificar.Enabled = true;
                    frmVentas.me.btnEliminar.Enabled = true;
                    frmVentas.me.btnCancelar.Enabled = true;

                    frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(frmVentas.me.txtNumVenta.Text));
                    frmVentas.me.orden_prod(frmVentas.me.dgvProductos);
                    frmVentas.me.cargar_totales(int.Parse(frmVentas.me.txtNumVenta.Text));
                    frmVentas.me.txtRegistros.Text = frmVentas.me.dgvProductos.Rows.Count.ToString("N0");

                    if (frmVentas.me.dgvProductos.Rows.Count > 0)
                    {
                        frmVentas.me.btnModificarProd.Enabled = true;
                        frmVentas.me.btnEliminarProd.Enabled = true;
                        frmVentas.me.btnGuardar.Enabled = true;
                    }
                }
                else if (name_ventana == 2)
                {
                    frmVentas_2.me.txtNumVenta.Text = Convert.ToInt64(this.dgvFacturas.CurrentRow.Cells[0].Value).ToString();
                    frmVentas_2.me.captar_id_cliente = Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[1].Value);
                    frmVentas_2.me.cliente_seleccionado = true;

                    if (frmVentas_2.me.captar_id_cliente == 0)
                    {
                        frmVentas_2.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        frmVentas_2.me.Text = frmVentas_2.me.Text + " - " + "Ventana #2";
                        frmVentas_2.me.Text = frmVentas_2.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: NINGUNO ***";

                    }
                    else
                    {
                        DataTable dt = NClientes.obtener_datos(frmVentas_2.me.captar_id_cliente);
                        frmVentas_2.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        frmVentas_2.me.Text = frmVentas_2.me.Text + " - " + "Ventana #2";
                        frmVentas_2.me.Text = frmVentas_2.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: " + dt.Rows[0].ItemArray[3].ToString() + " ***";

                    }

                    frmVentas_2.me.btnAgregar.Enabled = false;
                    frmVentas_2.me.btnModificar.Enabled = true;
                    frmVentas_2.me.btnEliminar.Enabled = true;
                    frmVentas_2.me.btnCancelar.Enabled = true;

                    frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(frmVentas_2.me.txtNumVenta.Text));
                    frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);
                    frmVentas_2.me.cargar_totales(int.Parse(frmVentas_2.me.txtNumVenta.Text));
                    frmVentas_2.me.txtRegistros.Text = frmVentas_2.me.dgvProductos.Rows.Count.ToString("N0");

                    if (frmVentas_2.me.dgvProductos.Rows.Count > 0)
                    {
                        frmVentas_2.me.btnModificarProd.Enabled = true;
                        frmVentas_2.me.btnEliminarProd.Enabled = true;
                        frmVentas_2.me.btnGuardar.Enabled = true;
                    }
                }
                else if (name_ventana == 3)
                {
                    frmVentas_3.me.txtNumVenta.Text = Convert.ToInt64(this.dgvFacturas.CurrentRow.Cells[0].Value).ToString();
                    frmVentas_3.me.captar_id_cliente = Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[1].Value);
                    frmVentas_3.me.cliente_seleccionado = true;

                    if (frmVentas_3.me.captar_id_cliente == 0)
                    {
                        frmVentas_3.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        frmVentas_3.me.Text = frmVentas_3.me.Text + " - " + "Ventana #3";
                        frmVentas_3.me.Text = frmVentas_3.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: NINGUNO ***";

                    }
                    else
                    {
                        DataTable dt = NClientes.obtener_datos(frmVentas_3.me.captar_id_cliente);
                        frmVentas_3.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS";
                        frmVentas_3.me.Text = frmVentas_3.me.Text + " - " + "Ventana #3";
                        frmVentas_3.me.Text = frmVentas_3.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: " + dt.Rows[0].ItemArray[3].ToString() + " ***";

                    }

                    frmVentas_3.me.btnAgregar.Enabled = false;
                    frmVentas_3.me.btnModificar.Enabled = true;
                    frmVentas_3.me.btnEliminar.Enabled = true;
                    frmVentas_3.me.btnCancelar.Enabled = true;

                    frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(frmVentas_3.me.txtNumVenta.Text));
                    frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);
                    frmVentas_3.me.cargar_totales(int.Parse(frmVentas_3.me.txtNumVenta.Text));
                    frmVentas_3.me.txtRegistros.Text = frmVentas_3.me.dgvProductos.Rows.Count.ToString("N0");

                    if (frmVentas_3.me.dgvProductos.Rows.Count > 0)
                    {
                        frmVentas_3.me.btnModificarProd.Enabled = true;
                        frmVentas_3.me.btnEliminarProd.Enabled = true;
                        frmVentas_3.me.btnGuardar.Enabled = true;
                    }
                }
                else if (name_ventana == 4)
                {
                    if (this.dgvFacturas.RowCount>0)
                    {
                        frmCotizaciones.me.txtNumVenta.Text = Convert.ToInt64(this.dgvFacturas.CurrentRow.Cells[0].Value).ToString();
                        frmCotizaciones.me.dgvFacturas.DataSource = NCotizaciones.buscar_by_id(int.Parse(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()));
                        frmCotizaciones.me.dgvProductos.DataSource = NCotizaciones.cargar_prod(int.Parse(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()));
                        frmCotizaciones.me.btnEliminar.Enabled = true;
                        frmCotizaciones.me.btnModificar.Enabled = true;
                        frmCotizaciones.me.btnAgregarProd.Enabled = true;
                    }
                }
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void click_eliminar()
        {
            try
            { 
                if (dgvFacturas.RowCount>0)
                {
                    if (name_ventana == 4)
                    {
                        DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta cotización.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resul == System.Windows.Forms.DialogResult.No)
                        {
                            this.dgvFacturas.Focus();
                            return;
                        }
                        NCotizaciones.eliminar_cot(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                        this.dgvFacturas.DataSource = NCotizaciones.buscar_cotizacion_tem("*", cGeneral.id_user_actual);
                        this.orden(dgvFacturas);
                        cGeneral.ajuste_columnas(this.dgvFacturas);
                    }
                    else
                    {
                        DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta venta.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resul == System.Windows.Forms.DialogResult.No)
                        {
                            this.dgvFacturas.Focus();
                            return;
                        }
                        NVentas.eliminar_venta_tem(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                        this.dgvFacturas.DataSource = NVentas.buscar_ventas_tem("*", cGeneral.id_user_actual);
                        this.orden(dgvFacturas);
                        cGeneral.ajuste_columnas(this.dgvFacturas);
                    }
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }
          
        }
        private void frmVentas_Clientes_FormClosing(object sender, FormClosingEventArgs e)
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
            else if (name_ventana == 4)
            {
                frmCotizaciones.me.tEnfoque.Enabled = true;
            }
        }

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {
            click_seleccionar();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            //cGeneral.caract_especial(e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }
    }
}
