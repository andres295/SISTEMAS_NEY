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

namespace SCM.Catalogos
{
    public partial class frmCatalogo : Form
    {
        public static frmCatalogo me;

        public frmCatalogo()
        {
            frmCatalogo.me = this;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo_Acciones frm = new Catalogos.frmCatalogo_Acciones();
                frm.Text = "AGREGAR CATÁLOGO";

                frm.cmbTipo.DataSource = NCatalogo.cargar_tipo_catalogo();
                frm.cmbTipo.ValueMember = "Id";
                frm.cmbTipo.DisplayMember = "Descripcion";

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
                if(dgvcatalogo.Rows.Count >0)
                {
                    Catalogos.frmCatalogo_Acciones frm = new Catalogos.frmCatalogo_Acciones();
                    frm.Text = "MODIFICAR CATÁLOGO";
                    frm.accion = true;

                    DataTable dt_datos = new DataTable();
                    dt_datos = NCatalogo.obtener_datos_by_tipe(Convert.ToInt32(this.dgvcatalogo.CurrentRow.Cells[0].Value));


                    frm.txtNombre.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                    frm.cbEstado.Checked = bool.Parse(dt_datos.Rows[0].ItemArray[3].ToString());
                    frm.cmbTipo.Value = dt_datos.Rows[0].ItemArray[2].ToString();
                    frm.txtCodigo.Text = dt_datos.Rows[0].ItemArray[5].ToString();

                    frm.cmbTipo.DataSource = NCatalogo.cargar_tipo_catalogo();
                    frm.cmbTipo.ValueMember = "Id";
                    frm.cmbTipo.DisplayMember = "Descripcion";
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay ningún registro para seleccionar");
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        //public void bancos_sort(int col)
        //{
        //    this.dgvcatalogo.Sort(this.dgvcatalogo.Columns[col], ListSortDirection.Ascending);
        //}

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                //est.grid_selfull_con_alter(this.dgvcatalogo);
                //est.SetDoubleBuffered(this.dgvcatalogo);
                dgvcatalogo.ReadOnly = true;
                this.tBuscar.Interval = cGeneral.timer;

                this.dgvcatalogo.DataSource = NCatalogo.buscar("");
                ////this.bancos_sort(1);
                this.txtRegistros.Text = NCatalogo.num_reg().ToString("N0");

                ///cGeneral.ajuste_columnas(this.dgvcatalogo);

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
            txtBuscar.Focus();
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
                    if (this.dgvcatalogo.Rows.Count > 0)
                        this.dgvcatalogo.Focus();
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
                    this.dgvcatalogo.DataSource = NCatalogo.buscar("");
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
                if (this.dgvcatalogo.Rows.Count == 0)
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

                if (this.dgvcatalogo.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == false)
                    {
                        this.btnAgregar.Focus();
                    }
                }
                else
                    this.dgvcatalogo.Focus();
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
                DialogResult result = MessageBox.Show("Estás seguro(a) de eliminar la especialidad.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NCatalogo.eliminar(Convert.ToInt32(this.dgvcatalogo.CurrentRow.Cells[0].Value)))
                    {
                        this.dgvcatalogo.Rows.Remove(this.dgvcatalogo.CurrentRow);
                        this.txtRegistros.Text = NCatalogo.num_reg().ToString("N0");

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
                            try
                            {
                                if (dgvcatalogo.Rows.Count>0)
                                {
                                    this.dgvcatalogo.Rows[this.dgvcatalogo.CurrentRow.Index].Selected = true;
                                    this.dgvcatalogo.Focus();
                                } 
                            }
                            catch (Exception)  {  }
                          
                        }
                    }
                }
                else
                    this.dgvcatalogo.Focus();
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
                    this.dgvcatalogo.DataSource = NCatalogo.buscar("");

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

                this.dgvcatalogo.DataSource = NCatalogo.buscar(this.txtBuscar.Text);
                ///this.bancos_sort(1);
                //dgvcatalogo.AllowUserToAddRows = false;
                //dgvcatalogo.AllowUserToDeleteRows = false;
                //dgvcatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvcatalogo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //dgvcatalogo.AutoResizeColumns();
                //dgvcatalogo.AutoResizeRows();
                //dgvcatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                //dgvcatalogo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
               
                if (this.dgvcatalogo.Rows.Count == 0)
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
            txtBuscar.Focus();
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
                this.ttMensaje.Show("Busca la descripción", this.txtBuscar, 0, 26);
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
                //this.dgvcatalogo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dgvcatalogo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //this.dgvcatalogo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dgvcatalogo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //this.dgvcatalogo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ////this.dgvBancos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvcatalogo.Columns[1].Width = 350;
                this.dgvcatalogo.Columns[2].Width = 250;
                this.dgvcatalogo.Columns[4].Width = 150;
                this.dgvcatalogo.Columns[0].Frozen = true;
                ////this.dgvcatalogo.Columns[1].Frozen = true;

                this.dgvcatalogo.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
