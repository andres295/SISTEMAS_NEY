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

namespace wfaFarmacia_Ney.SRI
{
    public partial class frmSRIPorcRetencion : Form
    {
        public static frmSRIPorcRetencion me;

        public frmSRIPorcRetencion()
        {
            frmSRIPorcRetencion.me = this;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                SRI.frmSRIPorcRetencion_Acciones frm = new SRI.frmSRIPorcRetencion_Acciones();
                frm.Text = "AGREGAR PORCENTAJE DE RETENCIÓN";
                frm.accion = false;
                frm.cbEstado.Checked = true;
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
                SRI.frmSRIPorcRetencion_Acciones frm = new SRI.frmSRIPorcRetencion_Acciones();
                frm.Text = "MODIFICAR PORCENTAJE DE RETENCIÓN";
                frm.accion = true;

                DataTable dt_datos = new DataTable();
                dt_datos = NCatalogosGenerales.cargar_cmb_by_id(Convert.ToInt32(this.dgvCatalogoGeneral.CurrentRow.Cells[0].Value));


                frm.txtDescripcion.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.nudPorcentaje.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[2].ToString());
                frm.txtCodAnexo.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                frm.cbEstado.Checked = bool.Parse( dt_datos.Rows[0].ItemArray[4].ToString());

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        public void bancos_sort(int col)
        {
            this.dgvCatalogoGeneral.Sort(this.dgvCatalogoGeneral.Columns[col], ListSortDirection.Ascending);
        }

        private void frmBancos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvCatalogoGeneral);
                est.SetDoubleBuffered(this.dgvCatalogoGeneral);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvCatalogoGeneral.DataSource = NCatalogosGenerales.buscar(1, txtBuscar.Text);
                this.bancos_sort(1);
                this.txtRegistros.Text = NCatalogosGenerales.num_reg(1).ToString("N0");

                cGeneral.ajuste_columnas(this.dgvCatalogoGeneral);

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
                    if (this.dgvCatalogoGeneral.Rows.Count > 0)
                        this.dgvCatalogoGeneral.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvBancos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.dgvCatalogoGeneral.DataSource = NCatalogosGenerales.cargar_cmb(1);
                    this.txtBuscar.Text = "";
                    ////this.btnAgregar.Enabled = true;
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

        private void dgvBancos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatalogoGeneral.Rows.Count == 0)
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

                if (this.dgvCatalogoGeneral.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == false)
                    {
                        this.btnAgregar.Focus();
                    }
                }
                else
                    this.dgvCatalogoGeneral.Focus();
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
                DialogResult result = MessageBox.Show("Estás seguro(a) de eliminar éste PORCENTAJE DE RETENCIÓN.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NCatalogosGenerales.eliminar(Convert.ToInt32(this.dgvCatalogoGeneral.CurrentRow.Cells[0].Value)))
                    {
                        this.dgvCatalogoGeneral.Rows.Remove(this.dgvCatalogoGeneral.CurrentRow);
                        this.txtRegistros.Text = NCatalogosGenerales.num_reg(1).ToString("N0");

                        if (this.txtRegistros.Text == "0")
                        {
                            ///this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.txtBuscar.Enabled = false;
                            this.txtBuscar.Text = "";
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.dgvCatalogoGeneral.Rows[this.dgvCatalogoGeneral.CurrentRow.Index].Selected = true;
                            this.dgvCatalogoGeneral.Focus();
                        }
                    }
                }
                else
                    this.dgvCatalogoGeneral.Focus();
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
                    this.dgvCatalogoGeneral.DataSource = null;

                    ///this.btnAgregar.Enabled = true;
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

                this.dgvCatalogoGeneral.DataSource = NCatalogosGenerales.buscar(1,this.txtBuscar.Text);
                this.bancos_sort(1);

                if (this.dgvCatalogoGeneral.Rows.Count == 0)
                {
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                }

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
                this.ttMensaje.Show("Busca descripción", this.txtBuscar, 0, 26);
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

        private void dgvBancos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvCatalogoGeneral.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCatalogoGeneral.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvCatalogoGeneral.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCatalogoGeneral.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ////this.dgvBancos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCatalogoGeneral.Columns[0].Frozen = true;
                this.dgvCatalogoGeneral.Columns[1].Frozen = true;

                this.dgvCatalogoGeneral.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
