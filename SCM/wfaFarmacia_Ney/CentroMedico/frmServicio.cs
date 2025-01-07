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

namespace SCM.CentroMedico
{
    public partial class frmServicio : Form
    {
        public static frmServicio me;

        public frmServicio()
        {
            frmServicio.me = this;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmServicio_Acciones frm = new frmServicio_Acciones();
                frm.Text = "AGREGAR SERVICIO";
                frm.accion = false;
      
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
                frmServicio_Acciones frm = new frmServicio_Acciones();
                frm.Text = "MODIFICAR LOS DATOS DEL SERVICIO";
                frm.accion = true;

                DataTable dt_datos = new DataTable();
                dt_datos = NServicio.obtener_datos(Convert.ToInt32(this.dgvServicios.CurrentRow.Cells[0].Value));

     
                frm.txtServicio.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.nudCosto.Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[2].ToString());
                frm.cbEstado.Checked = bool.Parse( dt_datos.Rows[0].ItemArray[6].ToString());
                ///frm.nudTiempoEjecucion.Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString());
                frm.txtDescripcion.Text = dt_datos.Rows[0].ItemArray[4].ToString();

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        public void servicio_sort(int col)
        {
            this.dgvServicios.Sort(this.dgvServicios.Columns[col], ListSortDirection.Ascending);
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

                this.dgvServicios.DataSource = NServicio.buscar("");
                this.servicio_sort(1);
                this.txtRegistros.Text = NServicio.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvServicios);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                else
                    this.btnAgregar.Focus();
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
                    this.dgvServicios.DataSource = NServicio.buscar("");
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
                DialogResult result = MessageBox.Show("Estás seguro(a) de eliminar éste servicio.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NServicio.eliminar(Convert.ToInt32(this.dgvServicios.CurrentRow.Cells[0].Value)))
                    {
                        this.dgvServicios.Rows.Remove(this.dgvServicios.CurrentRow);
                        this.txtRegistros.Text = NServicio.num_reg().ToString("N0");

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
                    this.dgvServicios.DataSource = NServicio.buscar("");

                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
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

                this.dgvServicios.DataSource = NServicio.buscar(this.txtBuscar.Text);
                this.servicio_sort(1);

                if (this.dgvServicios.Rows.Count == 0)
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
                    this.btnAgregar.Enabled = true;
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
                this.ttMensaje.Show("Busca el nombre del servicio", this.txtBuscar, 0, 26);
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
                this.dgvServicios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvServicios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvServicios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ///this.dgvServicios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvServicios.Columns[0].Frozen = true;
                this.dgvServicios.Columns[1].Frozen = true;
                this.dgvServicios.Columns[2].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";

                this.dgvServicios.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
