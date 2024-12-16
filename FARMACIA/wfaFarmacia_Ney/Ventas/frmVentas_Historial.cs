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

namespace wfaFarmacia_Ney.Ventas
{
    public partial class frmVentas_Historial : Form
    {
        public int name_ventana = 0;
        public frmVentas_Historial()
        {
            InitializeComponent();
        }

        void orden(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
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
                this.dgvFacturas.DataSource = NVentas.buscar_ventas_historico("", cGeneral.id_user_actual,Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                this.orden(dgvFacturas);
                txtBuscar.Text = "*";
                cGeneral.ajuste_columnas(this.dgvFacturas);
                ////dtpDesde.Value = System.DateTime.Now.AddDays(-30);
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
            //        this.btnSeleccionar.Enabled = false;
            //        ////this.btnEliminar.Enabled = false;

            //        this.dgvFacturas.DataSource = NVentas.buscar_ventas_historico("", cGeneral.id_user_actual, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
            //        this.orden(dgvFacturas);
            //        ///.txtBuscar.Focus();
            //    }
            //    else
            //    {
            //        this.tBuscar.Enabled = false;
            //        this.tBuscar.Enabled = true;
            //    }
            //}
            //catch (Exception ex) { cGeneral.error(ex); }
        }
        
        private void tBuscar_Tick(object sender, EventArgs e)
        {
           
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
                ////this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvFacturas.Columns[2].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";


                this.dgvFacturas.Columns[7].DefaultCellStyle.Format = "G";

                this.dgvFacturas.Columns[0].Frozen = true;
                this.dgvFacturas.Columns[1].Frozen = true;
                //this.dgvFacturas.Columns[2].Frozen = true;
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
                    this.tBuscar.Enabled = false;

                    this.dgvFacturas.DataSource = NVentas.buscar_ventas_historico(this.txtBuscar.Text, cGeneral.id_user_actual, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                    this.orden(dgvFacturas);

                    if (this.dgvFacturas.Rows.Count == 0)
                    {
                        this.btnSeleccionar.Enabled = false;
                        ///this.btnEliminar.Enabled = false;
                        ///this.txtBuscar.Focus();
                        ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                    }
                    else
                    {
                        this.btnSeleccionar.Enabled = true;
                        ///this.btnEliminar.Enabled = true;
                        ///this.dgvFacturas.Focus();
                    }
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
                    this.txtBuscar.Text = "";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            click_seleccionar();
        }

        void click_seleccionar()
        {
            try
            {
                long cod_vnta = Convert.ToInt64(this.dgvFacturas.CurrentRow.Cells[0].Value);

                if (cod_vnta>0)
                {
                    DataTable dtProductos = new  DataTable();
                    dtProductos  =  NVentas.cargar_count_productos_by_venta(cod_vnta);

                    int cant_Producto = 0;

                    if (dtProductos.Rows.Count>0)
                    {
                        cant_Producto = dtProductos.Rows.Count;
                    }
                    if (cant_Producto > 0)
                    {
                        if (cGeneral.numItem >= cant_Producto)
                        {
                            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                            frmReporte.fecha_inicio = "";
                            frmReporte.fecha_fin = "";
                            frmReporte.desde = 1;
                            frmReporte.hasta = cGeneral.numItem;
                            frmReporte.print_pago = "SI";
                            frmReporte.num_factura = Convert.ToString(cod_vnta);
                            frmReporte.Show();
                        }
                        else
                        {
                            int itemRecord = 0;
                            for (int i = 0; i < 20; i++)
                            {

                                itemRecord += cGeneral.numItem;

                                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_recibo");
                                frmReporte.fecha_inicio = "";
                                frmReporte.fecha_fin = "";
                                frmReporte.desde = itemRecord - cGeneral.numItem + 1;
                                frmReporte.hasta = itemRecord;
                                frmReporte.print_pago = "NO";
                                frmReporte.num_factura = Convert.ToString(cod_vnta);
                                frmReporte.Show();

                                if (itemRecord >= cant_Producto)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void click_eliminar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de eliminar ésta venta.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvFacturas.Focus();
                    return;
                }

                NVentas.eliminar_venta_tem(Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[0].Value));
                this.dgvFacturas.DataSource = NVentas.buscar_ventas_historico("*", cGeneral.id_user_actual, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));

                this.orden(dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvFacturas);
            }
            catch (Exception ex) { cGeneral.error(ex); }
          
        }
        private void frmVentas_Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (name_ventana == 1)
            {
                frmVentas.me.tEnfoque.Enabled = true;
            }else if (name_ventana == 2)
            {
                frmVentas_2.me.tEnfoque.Enabled = true;
            }
            else if(name_ventana == 3)
            {
                frmVentas_3.me.tEnfoque.Enabled = true;
            }

        }

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {
           //// click_seleccionar();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //cGeneral.quitar_sonido_txt(e);
            //cGeneral.caract_especial(e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NVentas.buscar_ventas_historico(this.txtBuscar.Text, cGeneral.id_user_actual, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                this.orden(dgvFacturas);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnSeleccionar.Enabled = false; 
                }
                else
                {
                    this.btnSeleccionar.Enabled = true; 
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvFacturas.DataSource = NVentas.buscar_ventas_historico(this.txtBuscar.Text, cGeneral.id_user_actual, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));
                this.orden(dgvFacturas);

                if (this.dgvFacturas.Rows.Count == 0)
                {
                    this.btnSeleccionar.Enabled = false; 
                }
                else
                {
                    this.btnSeleccionar.Enabled = true; 
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnExportarCtaProveedor_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count > 0)
            {
                if (MessageBox.Show("Desea exportar los datos a excel?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    exportarGridExcel exc = new exportarGridExcel();
                    exc.hojaexcel(dgvFacturas);

                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar", "Exportar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
