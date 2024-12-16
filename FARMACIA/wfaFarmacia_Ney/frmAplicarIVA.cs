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

namespace wfaFarmacia_Ney
{
    public partial class frmAplicarIVA : Form
    {
        public frmAplicarIVA()
        {
            InitializeComponent();
        }

        void columnas_prov(DataGridView dgv)
        {
            try
            {
                dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
                dgv.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        void columnas_prod(DataGridView dgv)
        {
            try
            {
                dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns[0].Frozen = true;
                dgv.Columns[1].Frozen = true;

                dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
                dgv.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvProveedores.DataSource = NDescuentos.buscar_prov(this.txtBuscar.Text);
                this.columnas_prov(this.dgvProveedores);

                if (this.dgvProveedores.Rows.Count == 0)
                {
                    this.btnGeneral.Enabled = true;
                    this.btnGuardarIvaPVP.Enabled = true;
                    /// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnGuardarIvaPVP.Enabled = false;
                    this.btnGeneral.Enabled = false;
                    txtBuscar.Focus();
                    ////  this.dgvProveedores.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void frmAplicarIVA_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvProveedores);
                est.grid_selfull_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvProveedores);
                est.SetDoubleBuffered(this.dgvProductos);

                ///this.dgvProveedores.DataSource = NIVA.buscar_prod("");
                ///this.columnas_prov(this.dgvProveedores);
                this.dgvProductos.DataSource = NIVA.buscar_prod(0, txtBuscar.Text);
                this.columnas_prod(this.dgvProductos);

                ///cGeneral.ajuste_columnas(this.dgvProductos);
                cGeneral.ajuste_columnas(this.dgvProveedores);
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_Enter(object sender, EventArgs e)
        {
            try
            {
                //if (this.dgvProveedores.Rows.Count == 0)
                //    this.txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                        this.dgvProductos.Focus();

                    e.SuppressKeyPress = true;
                }

                if (e.KeyValue == 27)
                {
                    this.txtBuscar.Text = "";
                    ///this.txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.tCargarProd.Enabled = false;
                this.tCargarProd.Enabled = true;
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
                this.dgvProductos.Rows[e.RowIndex].Cells[5].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count == 0)
                {
                    if (this.dgvProveedores.Rows.Count == 0)
                        this.txtBuscar.Focus();
                    else
                        this.dgvProveedores.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    e.SuppressKeyPress = true;

                if (e.KeyValue == 27)
                {
                    this.txtBuscar.Text = "";
                    ///this.txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    gbIva.Enabled = true;

                    if (Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[5].Value) == 0)
                    {
                        this.btnQuitar.Enabled = false;
                        this.btnGuardar.Enabled = true;
                    }
                    else
                    {
                        this.btnQuitar.Enabled = true;
                        this.btnGuardar.Enabled = false;
                    }
                    if (Convert.ToBoolean(this.dgvProductos.CurrentRow.Cells[6].Value))
                    {
                        this.btnQuitarIvaPVP.Enabled = true;
                        this.btnGuardarIvaPVP.Enabled = false;
                    }
                    else
                    {
                        this.btnQuitarIvaPVP.Enabled = false;
                        this.btnGuardarIvaPVP.Enabled = true;

                    }
                }
            }
            catch (Exception ex) { }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text != "")
                        this.txtBuscar.Text = "";
                    else
                        this.Close();
                } 
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvProveedores.DataSource = NDescuentos.buscar_prov("");
                            this.columnas_prov(this.dgvProveedores);
                            this.dgvProductos.DataSource = NIVA.buscar_prod(0, txtBuscar.Text);
                            this.columnas_prod(this.dgvProductos);
                            this.gbDescuento.Enabled = false;
                            this.btnGeneral.Enabled = true;
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
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);
                decimal iva = cGeneral.IVA;

                if (rbtnSel.Checked == true)
                {
                    //SELECCIONADO.
                    NIVA.aplicar_quitar_sel(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), iva.ToString());
                    this.dgvProductos.CurrentRow.Cells[5].Value = iva.ToString("N" + cGeneral.decimales + "");

                    this.btnQuitar.Enabled = true;
                    this.btnGuardar.Enabled = false;


                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El IVA se aplicó correctamente", this.btnGuardar, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
                else
                {
                    //TODOS.
                    for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                    {
                        NIVA.aplicar_quitar_sel(this.dgvProductos.Rows[i].Cells[0].Value.ToString(), iva.ToString());
                        this.dgvProductos.Rows[i].Cells[5].Value = iva.ToString("N" + cGeneral.decimales + "");
                    }
                    this.btnQuitar.Enabled = true;
                    this.btnGuardar.Enabled = false;

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El IVA se aplicó correctamente en éstos productos", this.btnQuitar, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnQuitar);
                DialogResult resul;

                if (rbtnSel.Checked == true)
                {
                    //SELECCIONADO.
                    resul = MessageBox.Show("Desea quitar el IVA al producto seleccionado.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProductos.Focus();
                        return;
                    }

                    NIVA.aplicar_quitar_sel(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), "0");
                    this.dgvProductos.CurrentRow.Cells[5].Value = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");

                    this.btnGuardar.Enabled = true;
                    this.btnQuitar.Enabled = false;

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El IVA se quitó", this.btnQuitar, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
                else
                {
                    //TODOS.
                    resul = MessageBox.Show("Desea quitar el IVA a éstos productos.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProductos.Focus();
                        return;
                    }
                    try
                    {
                        for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                        {
                            NIVA.aplicar_quitar_sel(this.dgvProductos.Rows[i].Cells[0].Value.ToString(), "0");
                            this.dgvProductos.Rows[i].Cells[5].Value = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                        }

                        this.btnGuardar.Enabled = true;
                        this.btnQuitar.Enabled = false;

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El IVA se quitó correctamente en éstos productos", this.btnQuitar, 0, 38, 3000);
                        this.dgvProductos.Focus();
                    }
                    catch (Exception) { }

                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGeneral);
                DialogResult resul = MessageBox.Show("Desea aplicar/quitar el IVA a todos los productos en general.\n\nElije SI para aplicar a todos.\nElije NO para quitar a todos.", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    //APLICAR.
                    NIVA.aplicar_quitar_general(cGeneral.IVA.ToString());

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El IVA se aplicó correctamente de forma general", this.btnGeneral, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
                else if (resul == System.Windows.Forms.DialogResult.No)
                {
                    //QUITAR.
                    NIVA.aplicar_quitar_general("0");

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El IVA se quitó correctamente de forma general", this.btnGeneral, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
                else
                {
                    this.dgvProductos.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void tCargarProd_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tCargarProd.Enabled = false;

                if (this.dgvProveedores.Rows.Count > 0)
                {
                    this.dgvProductos.DataSource = NIVA.buscar_prod(Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value), txtBuscarProducto.Text);
                    columnas_prod(this.dgvProductos);

                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        this.gbDescuento.Enabled = true;
                        this.gbIva.Enabled = true;
                    }
                    else
                    {
                        this.gbDescuento.Enabled = false;
                        this.gbIva.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnQuitarIvaPVP_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnQuitarIvaPVP);
                DialogResult resul;

                if (rbtnSelPVP.Checked == true)
                {
                    //SELECCIONADO.
                    resul = MessageBox.Show("Desea quitar el PVP INCLUYE IVA al producto seleccionado.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProductos.Focus();
                        return;
                    }

                    NIVA.aplicar_quitar_pvp_sel(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), false);
                    this.dgvProductos.CurrentRow.Cells[6].Value = false;

                    this.btnGuardarIvaPVP.Enabled = true;
                    this.btnQuitarIvaPVP.Enabled = false;

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El PVP INCLUYE IVA se quitó", this.btnQuitarIvaPVP, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
                else
                {
                    //TODOS.
                    resul = MessageBox.Show("Desea quitar el PVP INCLUYE IVA a éstos productos.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProductos.Focus();
                        return;
                    }
                    for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                    {
                        NIVA.aplicar_quitar_pvp_sel(this.dgvProductos.Rows[i].Cells[0].Value.ToString(), false);
                        this.dgvProductos.Rows[i].Cells[6].Value = false;
                    }

                    this.btnGuardarIvaPVP.Enabled = true;
                    this.btnQuitarIvaPVP.Enabled = false;

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El PVP INCLUYE IVA se quitó correctamente en éstos productos", this.btnQuitarIvaPVP, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnGuardarIvaPVP_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardarIvaPVP);
                decimal iva = cGeneral.IVA;

                if (rbtnSelPVP.Checked == true)
                {
                    //SELECCIONADO.
                    NIVA.aplicar_quitar_pvp_sel(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), true);
                    this.dgvProductos.CurrentRow.Cells[6].Value = true;

                    this.btnQuitarIvaPVP.Enabled = true;
                    this.btnGuardarIvaPVP.Enabled = false;

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El PVP INCLUYE IVA se aplicó correctamente", this.btnGuardarIvaPVP, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
                else
                {
                    //TODOS.
                    for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                    {
                        NIVA.aplicar_quitar_pvp_sel(this.dgvProductos.Rows[i].Cells[0].Value.ToString(), true);
                        this.dgvProductos.Rows[i].Cells[6].Value = true;
                    }
                    this.btnQuitarIvaPVP.Enabled = true;
                    this.btnGuardarIvaPVP.Enabled = false;

                    this.ttMensaje.ToolTipTitle = "LISTO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                    this.ttMensaje.Show("El PVP INCLUYE IVA se aplicó correctamente en éstos productos", this.btnGuardarIvaPVP, 0, 38, 3000);
                    this.dgvProductos.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            dgvProductos_SelectionChanged(null, null);

        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    ////this.tBuscar.Enabled = false;
                    this.dgvProductos.DataSource = NIVA.buscar_prod(0, txtBuscarProducto.Text);
                    this.dgvProductos.Refresh();
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        this.gbDescuento.Enabled = true;
                        this.txtBuscarProducto.Focus();
                    }   
                    else
                        this.gbDescuento.Enabled = false;

                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
           
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
