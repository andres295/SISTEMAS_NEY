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

namespace SCM.CxP
{
    public partial class frmCuentasPorPagar_Sel_Fact : Form
    {
        public static frmCuentasPorPagar_Sel_Fact me;
        public int idProveedor   = 0;

        public frmCuentasPorPagar_Sel_Fact()
        {
            frmCuentasPorPagar_Sel_Fact.me = this;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCuentasPorPagar_Sel_Fact_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnCerrar.Left = this.Width;

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.grid_selfull_con_alter(this.dgvSeleccionadas);
                est.SetDoubleBuffered(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvSeleccionadas);

                this.dgvFacturas.DataSource = NCuentasPorPagar.cargar_fact(frmCuentasPorPagar.me.id_prov_captado, frmCuentasPorPagar.me.desde_captado, frmCuentasPorPagar.me.hasta_captado);
                this.dgvFacturas.Sort(this.dgvFacturas.Columns[0], ListSortDirection.Ascending);

                this.cargar_sel();

                cGeneral.ajuste_columnas(this.dgvFacturas);
                cGeneral.ajuste_columnas(this.dgvSeleccionadas);

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void cargar_sel()
        {
            this.dgvSeleccionadas.DataSource = NCuentasPorPagar.cargar_fact_sel(cGeneral.id_user_actual);
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvFacturas.Columns[1].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnQuitar);

                if (this.dgvSeleccionadas.Rows.Count == 1)
                    click_quitar_sel();

                if (this.dgvSeleccionadas.Rows.Count == 0)
                {
                    this.sELECCIONADOToolStripMenuItem.Enabled = false;
                    this.tODOSToolStripMenuItem.Enabled = false;
                }
                else if (this.dgvSeleccionadas.Rows.Count == 1)
                {
                    this.sELECCIONADOToolStripMenuItem.Enabled = true;
                    this.tODOSToolStripMenuItem.Enabled = false;
                    this.contextMenuStrip1.Show(this.btnQuitar, new Point(-53, 54));
                }
                else
                {
                    this.sELECCIONADOToolStripMenuItem.Enabled = true;
                    this.tODOSToolStripMenuItem.Enabled = true;
                    this.contextMenuStrip1.Show(this.btnQuitar, new Point(-53, 54));
                }

                this.nudEfectivo.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFacturas.Rows.Count == 1)
                    click_agregar();

                if (this.dgvSeleccionadas.Rows.Count == 1)
                {
                    this.sELECCIONADOToolStripMenuItem1.Enabled = true;
                    this.tODOSToolStripMenuItem1.Enabled = false;
                }
                else
                {
                    this.sELECCIONADOToolStripMenuItem1.Enabled = true;
                    this.tODOSToolStripMenuItem1.Enabled = true;
                    this.contextMenuStrip2.Show(this.btnAgregar, new Point(-53, 54));
                }

                this.nudEfectivo.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void click_agregar()
        {
            try
            {
                this.ttMensaje.Hide(this.btnQuitar);

                if (NCuentasPorPagar.validar_fact_sel(cGeneral.id_user_actual, this.dgvFacturas.CurrentRow.Cells[0].Value.ToString()))
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta factura ya está agregada", this.btnQuitar, new Point(-65, 55), 3000);
                    this.dgvFacturas.Focus();
                    return;
                }

                NCuentasPorPagar.seleccionar_fact(cGeneral.id_user_actual, this.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), Convert.ToDecimal(this.dgvFacturas.CurrentRow.Cells[1].Value));

                this.cargar_sel();
                this.dgvSeleccionadas.FirstDisplayedScrollingRowIndex = this.dgvSeleccionadas.Rows.Count - 1;
                this.nudEfectivo.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvSeleccionadas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvSeleccionadas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvSeleccionadas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvSeleccionadas.Columns[1].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvSeleccionadas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void sELECCIONADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click_quitar_sel();
        }

        void click_quitar_sel()
        {
            try
            {
                NCuentasPorPagar.quitar_fact_sel(cGeneral.id_user_actual, this.dgvSeleccionadas.CurrentRow.Cells[0].Value.ToString());
                this.cargar_sel();

                if (this.dgvSeleccionadas.Rows.Count > 0)
                    this.dgvSeleccionadas.Focus();
                else
                    this.dgvFacturas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tODOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de quitar éstas facturas.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvSeleccionadas.Focus();
                    return;
                }

                for (int i = 0; i < this.dgvSeleccionadas.Rows.Count; i++)
                {
                    NCuentasPorPagar.quitar_fact_sel(cGeneral.id_user_actual, this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString());
                }

                this.cargar_sel();
                this.dgvFacturas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvFacturas.Rows.Count > 0)
                this.click_agregar();
        }

        private void sELECCIONADOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.click_agregar();
        }

        private void dgvSeleccionadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
                click_quitar_sel();
        }

        private void dgvSeleccionadas_Enter(object sender, EventArgs e)
        {
            if (this.dgvSeleccionadas.Rows.Count == 0)
                this.dgvFacturas.Focus();
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnAgregar);

            if (this.nudEfectivo.Text == "")
                this.nudEfectivo.Value = 0;
            else
                this.nudEfectivo.Value = Convert.ToDecimal(this.nudEfectivo.Text);

            if (this.dgvSeleccionadas.Rows.Count == 0)
            {
                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("No hay facturas seleccionadas", this.btnGuardar, 0, 38, 3000);
                this.nudEfectivo.Focus();
                return;
            }
            else if (Convert.ToDecimal(this.nudEfectivo.Value) == 0)
            {
                this.ttMensaje.ToolTipTitle = "AVISO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Especifique el monto en efectivo", this.btnGuardar, 0, 38, 3000);
                this.nudEfectivo.Focus();
                return;
            }

            frmCxpMultiPago frm = new frmCxpMultiPago();
            frm.captar_id_proveedor = idProveedor;
            frm.total_Pagar = this.nudEfectivo.Value.ToString();
            frm.ShowDialog();
           /// click_pagar();
        }

        void click_pagar()
        {
            try
            {
                this.ttMensaje.Hide(this.btnAgregar);

                if (this.nudEfectivo.Text == "")
                    this.nudEfectivo.Value = 0;
                else
                    this.nudEfectivo.Value = Convert.ToDecimal(this.nudEfectivo.Text);

                if (this.dgvSeleccionadas.Rows.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay facturas seleccionadas", this.btnGuardar, 0, 38, 3000);
                    this.nudEfectivo.Focus();
                    return;
                }
                else if (Convert.ToDecimal(this.nudEfectivo.Value) == 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Especifique el monto en efectivo", this.btnGuardar, 0, 38, 3000);
                    this.nudEfectivo.Focus();
                    return;
                }

                DialogResult resul = MessageBox.Show("Desea realizar éste pago.", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal captar_monto = 0;
                    captar_monto = this.nudEfectivo.Value;

                    for (int i = 0; i < this.dgvSeleccionadas.Rows.Count; i++)
                    {
                        if (captar_monto >= Convert.ToDecimal(this.dgvSeleccionadas.Rows[i].Cells[1].Value))
                        {
                            //PAGADO.
                            //NCuentasPorPagar.abonar(cGeneral.id_user_actual, this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString(), this.dtpFechaCobro.Value, Convert.ToDecimal(this.dgvSeleccionadas.Rows[i].Cells[1].Value), "PAGADO", "1");
                            NCuentasPorPagar.abonar(cGeneral.id_user_actual, this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString(), Convert.ToDecimal(this.dgvSeleccionadas.Rows[i].Cells[1].Value), "", System.DateTime.Now, 0, 0, null, null, 0, "1", "PAGADO");
                           
                            captar_monto -= Convert.ToDecimal(this.dgvSeleccionadas.Rows[i].Cells[1].Value);
                        }
                        else
                        {
                            //PENDIENTE.
                            NCuentasPorPagar.abonar(cGeneral.id_user_actual, this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString(), Convert.ToDecimal(this.dgvSeleccionadas.Rows[i].Cells[1].Value), "", System.DateTime.Now, 0, 0, null, null, 0, "1", "PENDIENTE");
                        }
                    }

                    for (int i = 0; i < this.dgvSeleccionadas.Rows.Count; i++)
                    {
                        for (int fila = 0; fila < frmCuentasPorPagar.me.uGridFactura.Rows.Count; fila++)
                        {
                            if (this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString() == frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[0].Value.ToString())
                            {
                                DataTable dt_datos = NCuentasPorPagar.actualizar_fila_fact(this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString());

                                frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[4].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString());
                                frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[5].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString());
                                frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[6].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[2].ToString());
                                frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[7].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString());
                                frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[8].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
                                frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[9].Value = dt_datos.Rows[0].ItemArray[5].ToString();
                                break;
                            }
                        }
                    }

                    this.Close();
                }
                else if (resul == System.Windows.Forms.DialogResult.No)
                    this.Close();
                else
                    this.nudEfectivo.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tODOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgvFacturas.Rows.Count; i++)
                {
                    NCuentasPorPagar.seleccionar_fact(cGeneral.id_user_actual, this.dgvFacturas.Rows[i].Cells[0].Value.ToString(), Convert.ToDecimal(this.dgvFacturas.Rows[i].Cells[1].Value));
                }

                this.cargar_sel();
                this.dgvSeleccionadas.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudEfectivo_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudEfectivo);
        }

        private void nudEfectivo_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudEfectivo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.dgvSeleccionadas.Rows.Count == 0)
                this.lblMonto.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
            else
            {
                decimal captar_monto = 0;

                try
                {
                    for (int i = 0; i < this.dgvSeleccionadas.Rows.Count; i++)
                    {
                        for (int fila = 0; fila < frmCuentasPorPagar.me.uGridFactura.Rows.Count; fila++)
                        {
                            if (this.dgvSeleccionadas.Rows[i].Cells[0].Value.ToString() == frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[0].Value.ToString())
                            {
                                captar_monto += Convert.ToDecimal(frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[8].Value);
                                this.lblMonto.Text = captar_monto.ToString("N" + cGeneral.decimales + "");
                                break;
                            }
                        }
                    }
                }
                catch (Exception)  {  }
            }
        }

        private void frmCuentasPorPagar_Sel_Fact_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                NCuentasPorPagar.quitar_fact_todos(cGeneral.id_user_actual);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
