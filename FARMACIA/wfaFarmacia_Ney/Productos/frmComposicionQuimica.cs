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

namespace wfaFarmacia_Ney.Productos
{
    public partial class frmComposicionQuimica : Form
    {
        public static frmComposicionQuimica me;

        public frmComposicionQuimica()
        {
            frmComposicionQuimica.me = this;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmComposicion_Acciones frm = new frmComposicion_Acciones();
                frm.Text = "AGREGAR COMPOSICION QUÍMICA";
                frm.accion = true;
                frm.ShowDialog();
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
                frmComposicion_Acciones frm = new frmComposicion_Acciones();
                frm.Text = "MODIFICAR LOS DATOS DE COMPOSICION QUIMICA";
                frm.accion = false;

                DataTable dt_datos = new DataTable();
                dt_datos = NComposicionQuimica.obtener_datos(Convert.ToInt32(this.dgvComposicion.CurrentRow.Cells[0].Value));

                frm.nombre = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.txtNombre.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.rtxtComposicion.Text = dt_datos.Rows[0].ItemArray[2].ToString();

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        public void dato_sort(int col)
        {
            this.dgvComposicion.Sort(this.dgvComposicion.Columns[col], ListSortDirection.Ascending);
        }

        private void frmComposicionQuimica_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvComposicion);
                est.SetDoubleBuffered(this.dgvComposicion);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvComposicion.DataSource = NComposicionQuimica.buscar("");
                this.dato_sort(1);
                this.txtRegistros.Text = NComposicionQuimica.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvComposicion);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                else
                    this.btnAgregar.Focus();

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
                    if (this.dgvComposicion.Rows.Count > 0)
                        this.dgvComposicion.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        this.tBuscar.Enabled = false;

                        this.dgvComposicion.DataSource = NComposicionQuimica.buscar(this.txtBuscar.Text);
                        this.dato_sort(1);

                        if (this.dgvComposicion.Rows.Count == 0)
                        {
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                        }
                        else
                        {
                            this.btnModificar.Enabled = true;
                            this.btnEliminar.Enabled = true;
                        }

                        if (this.txtBuscar.Text == "")
                            this.btnAgregar.Enabled = true;
                        else
                            this.btnAgregar.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        cGeneral.error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvComposicion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.dgvComposicion.DataSource = NComposicionQuimica.buscar("");
                    this.txtBuscar.Text = "";
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
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

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.TextLength);
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvComposicion.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
                else
                    this.dgvComposicion.Focus();
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
                DialogResult result = MessageBox.Show("Estás seguro(a) de eliminar ésta composición química.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NComposicionQuimica.eliminar(Convert.ToInt32(this.dgvComposicion.CurrentRow.Cells[0].Value)))
                    {
                        this.dgvComposicion.Rows.Remove(this.dgvComposicion.CurrentRow);
                        this.txtRegistros.Text = NComposicionQuimica.num_reg().ToString("N0");

                        if (this.txtRegistros.Text == "0")
                        {
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.txtBuscar.Enabled = false;
                            this.txtBuscar.Text = "";
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.dgvComposicion.Rows[this.dgvComposicion.CurrentRow.Index].Selected = true;
                            this.dgvComposicion.Focus();
                        }
                    }
                }
                else
                    this.dgvComposicion.Focus();
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
            //try
            //{
            //    if (this.txtBuscar.Text == "")
            //    {
            //        this.tBuscar.Enabled = false;
            //        this.dgvComposicion.DataSource = NComposicionQuimica.buscar("");

            //        this.btnAgregar.Enabled = true;
            //        this.btnModificar.Enabled = false;
            //        this.btnEliminar.Enabled = false;
            //    }
            //    else
            //    {
            //        this.tBuscar.Enabled = false;
            //        this.tBuscar.Enabled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    cGeneral.error(ex);
            //}
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
           
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
                this.ttMensaje.Show("Busca el nombre de la composición química", this.txtBuscar, 0, 26);
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

        private void dgvComposicion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvComposicion.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvComposicion.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvComposicion.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
                this.dgvComposicion.Columns[0].Frozen = true;
                this.dgvComposicion.Columns[1].Frozen = true;

                this.dgvComposicion.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvComposicion_Enter(object sender, EventArgs e)
        {

            try
            {
                if (this.dgvComposicion.Rows.Count == 0)
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
    }
}
