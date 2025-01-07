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
    public partial class frmRecuperar_Lista : Form
    {
        public frmRecuperar_Lista()
        {
            InitializeComponent();
        }

        void orden(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[0], ListSortDirection.Descending);
        }

        private void frmRecuperar_Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvFacturas);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvFacturas.DataSource = NRecuperar.buscar_venta_lista("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                this.orden(dgvFacturas);

                cGeneral.ajuste_columnas(this.dgvFacturas);
                ////dtpDesde.Value = System.DateTime.Now.AddDays(-30);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            buscar_ventas();
        }
        private void buscar_ventas()
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NRecuperar.buscar_venta_lista(this.txtBuscar.Text, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                this.orden(dgvFacturas);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnSeleccionar.Enabled = false;
                    ///this.txtBuscar.Focus();
                    //////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnSeleccionar.Enabled = true;
                    ///this.dgvFacturas.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }

        }
        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
            ///   if (this.dgvFacturas.Rows.Count == 0)
            ///this.txtBuscar.Focus();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            ///// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
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
                if (this.dgvFacturas.Rows.Count == 0)
                    this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.txtBuscar.Text == "")
                    {
                        this.tBuscar.Enabled = false;
                        this.btnSeleccionar.Enabled = false;

                        this.dgvFacturas.DataSource = NRecuperar.buscar_venta_lista("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                        this.orden(dgvFacturas);
                        ///this.txtBuscar.Focus();
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
                frmRecuperar.me.captar_numventa = Convert.ToInt64(this.dgvFacturas.CurrentRow.Cells[0].Value);
                frmRecuperar.me.captar_id_cliente = Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[1].Value);
                frmRecuperar.me.cliente_seleccionado = true;

                DataTable dt = NClientes.obtener_datos(frmRecuperar.me.captar_id_cliente);
                frmRecuperar.me.Text = "RECUPERAR LOS PRODUCTOS DE UNA VENTA";
                frmRecuperar.me.Text = frmRecuperar.me.Text + " | *** VENTA # " + this.dgvFacturas.CurrentRow.Cells[0].Value + ", CLIENTE: " + dt.Rows[0].ItemArray[3].ToString() + " ***";

                frmRecuperar.me.btnModificar.Enabled = true;
                frmRecuperar.me.btnEliminar.Enabled = true;
                frmRecuperar.me.btnCancelar.Enabled = true;

                frmRecuperar.me.dgvProductos.DataSource = NVentas.cargar_prod(frmRecuperar.me.captar_numventa);
                frmRecuperar.me.orden_prod(frmRecuperar.me.dgvProductos);
                frmRecuperar.me.cargar_totales(frmRecuperar.me.captar_numventa);
                frmRecuperar.me.txtRegistros.Text = frmRecuperar.me.dgvProductos.Rows.Count.ToString("N0");

                frmRecuperar.me.btnModificarProd.Enabled = true;
                frmRecuperar.me.btnEliminarProd.Enabled = true;
                frmRecuperar.me.txtBuscar.Enabled = true;

                if (NRecuperar.verificar_ventas_temp(frmRecuperar.me.captar_numventa) == 0)
                    frmRecuperar.me.btnGuardar.Enabled = false;
                else
                    frmRecuperar.me.btnGuardar.Enabled = true;

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmRecuperar_Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRecuperar.me.tEnfoque.Enabled = true;
        }

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {
            click_seleccionar();
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

        private void dgvFacturas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.dgvFacturas.Rows.Count > 0)
                this.btnSeleccionar.PerformClick();
        }

        private void dgvFacturas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.btnSeleccionar.Enabled = false;

                    this.dgvFacturas.DataSource = NRecuperar.buscar_venta_lista("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                    this.orden(dgvFacturas);
                    ///this.txtBuscar.Focus();
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.btnSeleccionar.Enabled = false;

                    this.dgvFacturas.DataSource = NRecuperar.buscar_venta_lista("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                    this.orden(dgvFacturas);
                    ///this.txtBuscar.Focus();
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
}
