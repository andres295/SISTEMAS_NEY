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

namespace SCM.Facturacion
{
    public partial class frmCxPagar : Form
    {
        public static frmCxPagar me;

        public frmCxPagar()
        {
            frmCxPagar.me = this;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvServicios.Rows.Count>0)
                {
                    PagosCxC.frmAddPago frm = new PagosCxC.frmAddPago();
                    frm.Text = "AGREGAR PAGO";
                    //frm.txtIdFactura.Text = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                    //frm.txtCliente.Text = this.dgvServicios.CurrentRow.Cells[1].Value.ToString();
                    //frm.txtFechaFactura.Text = this.dgvServicios.CurrentRow.Cells[9].Value.ToString();
                    //frm.nudMontoFactura.Text = decimal.Parse(this.dgvServicios.CurrentRow.Cells[4].Value.ToString()).ToString("N" + cGeneral.decimales_ventas + ""); 
                    //frm.nudMontoAbono.Text = decimal.Parse(this.dgvServicios.CurrentRow.Cells[5].Value.ToString()).ToString("N" + cGeneral.decimales_ventas + ""); 
                    //frm.nudSaldo.Text = decimal.Parse(this.dgvServicios.CurrentRow.Cells[6].Value.ToString()).ToString();

                    frm.ShowDialog();
                }
               
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
                if (dgvServicios.Rows.Count>0)
                {
                    PagosCxC.frmPagoFacturas frm = new PagosCxC.frmPagoFacturas();
                    frm.Text = "PAGOS DE FACTURA # " + this.dgvServicios.CurrentRow.Cells[0].Value.ToString(); ;
                    frm.txtNumFactura.Text = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                    frm.txtCliente.Text = this.dgvServicios.CurrentRow.Cells[1].Value.ToString();
                    frm.txtMontoFactura.Text = decimal.Parse(this.dgvServicios.CurrentRow.Cells[4].Value.ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    frm.txtAbono.Text = decimal.Parse(this.dgvServicios.CurrentRow.Cells[5].Value.ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    frm.txtSaldo.Text = decimal.Parse(this.dgvServicios.CurrentRow.Cells[6].Value.ToString()).ToString();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
       
        public void servicio_sort(int col)
        {
            this.dgvServicios.Sort(this.dgvServicios.Columns[col], ListSortDirection.Descending);
        }

        private void frmServicio_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvServicios);
                est.SetDoubleBuffered(this.dgvServicios);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),true);
                this.servicio_sort(0);
                this.txtRegistros.Text = NFactura.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvServicios);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                else
                    this.btnAgregar.Focus();
                dtpDesde.Value = System.DateTime.Now.AddDays(-7);
            }
            catch(Exception ex)
            {
                cGeneral.error(ex);
            }
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
                    if (this.dgvServicios.Rows.Count > 0)
                        this.dgvServicios.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvServicio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),true);
                    this.txtBuscar.Text = "";
                    //// this.btnAgregar.Enabled = true;
                    //this.btnModificar.Enabled = false;
                    //this.btnEliminar.Enabled = false;
                    this.txtBuscar.Focus();
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvServicio_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.TextLength);
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvServicios.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == false)
                    {
                        this.btnAgregar.Focus();
                    }
                }
                else
                    this.dgvServicios.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                DialogResult result = MessageBox.Show("Estás seguro(a) de eliminar ésta factura.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NFactura.eliminar(Convert.ToInt32(this.dgvServicios.CurrentRow.Cells[0].Value)))
                    {
                        this.dgvServicios.Rows.Remove(this.dgvServicios.CurrentRow);
                        this.txtRegistros.Text = NFactura.num_reg().ToString("N0");

                        if (this.txtRegistros.Text == "0")
                        {
                            this.btnAgregar.Enabled = true;
                            //this.btnModificar.Enabled = false;
                            //this.btnEliminar.Enabled = false;
                            this.txtBuscar.Enabled = false;
                            this.txtBuscar.Text = "";
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.dgvServicios.Rows[this.dgvServicios.CurrentRow.Index].Selected = true;
                            this.dgvServicios.Focus();
                        }
                    }
                }
                else
                    this.dgvServicios.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),true);

                    //this.btnAgregar.Enabled = true;
                    //this.btnModificar.Enabled = false;
                    //this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvServicios.DataSource = NFactura.buscar(this.txtBuscar.Text, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),true);
                this.servicio_sort(0);

                //if (this.dgvServicios.Rows.Count == 0)
                //{
                //    this.btnModificar.Enabled = false;
                //    this.btnEliminar.Enabled = false;
                //}
                //else
                //{
                //    this.btnModificar.Enabled = true;
                //    this.btnEliminar.Enabled = true;
                //}
                
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
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

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el cliente de la factura.", this.txtBuscar, 0, 26);
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

        private void dgvServicio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvServicios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvServicios.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvServicios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvServicios.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                this.dgvServicios.Columns[0].Frozen = true;
                this.dgvServicios.Columns[1].Frozen = true;

                this.dgvServicios.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }
        public void print_factura()
        {
            try
            {
                if (this.dgvServicios.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("¿Desea imprimir la factura?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvServicios.Focus();
                        return;
                    }

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("factura_tickets");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.desde = 1;
                    frmReporte.hasta = cGeneral.numItem;
                    frmReporte.print_pago = "SI";
                    frmReporte.num_factura = this.dgvServicios.CurrentRow.Cells[0].Value.ToString();
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnPrintVenta_Click(object sender, EventArgs e)
        {
            print_factura();
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows.Count > 0)
                {
                    ///this.nudDesc.Text = this.dgvServicios.CurrentRow.Cells[5].Value.ToString();

                    //if (Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[10].Value).Date == Convert.ToDateTime("1900-01-01").Date)
                    //    this.dtpDesde.Value = DateTime.Today.Date;
                    //else
                    //    this.dtpDesde.Value = Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[10].Value).Date;

                    //if (Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[11].Value).Date == Convert.ToDateTime("1900-01-01").Date)
                    //    this.dtpHasta.Value = DateTime.Today.Date;
                    //else
                    //    this.dtpHasta.Value = Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[11].Value).Date;
                    ///string abono = this.dgvServicios.CurrentRow.Cells[5].Value.ToString();
                    //if (decimal.Parse(this.dgvServicios.CurrentRow.Cells[5].Value.ToString()) > 0)
                    //{
                    //    btnModificar.Enabled = true;
                    //}else
                    //{
                    //    btnModificar.Enabled = false;
                    //}
                    if (decimal.Parse(this.dgvServicios.CurrentRow.Cells[6].Value.ToString()) > 0)
                    {
                        btnAgregar.Enabled = true;
                    }
                    else
                    {
                        btnAgregar.Enabled = false;
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
