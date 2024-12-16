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
    public partial class frmProveedores : Form
    {
        public static frmProveedores me;

        public frmProveedores()
        {
            frmProveedores.me = this;
            InitializeComponent();
        }

        public int id_captado;
        public string prov_captado;

        void proveedores_sort(int col)
        {
            this.dgvProveedores.Sort(this.dgvProveedores.Columns[col], ListSortDirection.Ascending);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvProveedores.DataSource = NProveedores.buscar(this.txtBuscar.Text);
                this.proveedores_sort(2);

                if (this.dgvProveedores.Rows.Count == 0)
                {
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                   //// this.dgvProveedores.Focus();
                }

                if (this.txtBuscar.Text == "")
                    this.btnAgregar.Enabled = true;
                else
                    this.btnAgregar.Enabled = false;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvProveedores);
                est.SetDoubleBuffered(this.dgvProveedores);

                this.tBuscar.Interval = cGeneral.timer;

                this.txtRegistros.Text = NProveedores.num_reg().ToString("N0");
                this.dgvProveedores.DataSource = NProveedores.buscar("");
                this.proveedores_sort(2);

                cGeneral.ajuste_columnas(this.dgvProveedores);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                   /// this.txtBuscar.Focus();
                }
                else
                    this.btnAgregar.Focus();

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedores_Acciones frm = new frmProveedores_Acciones();
                frm.accion = true;
                frm.Text = "AGREGAR PROVEEDOR";

                frm.cmbTipoIdentificacion.DataSource = NTipoIdentificacion.obtener_datos();
                frm.cmbTipoIdentificacion.ValueMember = "Id";
                frm.cmbTipoIdentificacion.DisplayMember = "TipoIdentificacion";

                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedores_Acciones frm = new frmProveedores_Acciones();
                frm.Text = "MODIFICAR LOS DATOS DEL PROVEEDOR";
                frm.accion = false;

                DataTable dt_datos = new DataTable();
                dt_datos = NProveedores.obtener_datos(Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value));

                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                frm.cmbTipoIdentificacion.DataSource = NTipoIdentificacion.obtener_datos();
                frm.cmbTipoIdentificacion.ValueMember = "Id";
                frm.cmbTipoIdentificacion.DisplayMember = "TipoIdentificacion";

                frm.txtProveedor.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                ///frm.txtMatriz.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                ///frm.txtGerente.Text = dt_datos.Rows[0].ItemArray[6].ToString();
                //frm.mtxtAutorizacion.Text = dt_datos.Rows[0].ItemArray[7].ToString();
                ///frm.txtDatos.Text = dt_datos.Rows[0].ItemArray[8].ToString();
                try
                {
                    frm.cmbTipoIdentificacion.Value = int.Parse(dt_datos.Rows[0].ItemArray[9].ToString());
                }
                catch (Exception) { }
                frm.txtCorreo.Text = dt_datos.Rows[0].ItemArray[10].ToString();
                frm.txtNombreComercial.Text = dt_datos.Rows[0].ItemArray[11].ToString();
                frm.ucTipoContribuyente.Value = dt_datos.Rows[0].ItemArray[12].ToString();
                frm.txtAgenteRetencion.Text = dt_datos.Rows[0].ItemArray[13].ToString();
                 
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                if (NProveedores.validar_relacion(Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value)) <= 0)
                {
                    DialogResult result;
                    result = MessageBox.Show("Estás seguro(a) de eliminar a éste proveedor.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProveedores.Focus();
                        return;
                    }

                    if (NProveedores.eliminar(Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value)))
                    {
                        this.txtRegistros.Text = NProveedores.num_reg().ToString("N0");
                        this.dgvProveedores.Rows.Remove(this.dgvProveedores.CurrentRow);

                        if (this.txtRegistros.Text == "0")
                        {
                            this.dgvProveedores.DataSource = NProveedores.buscar("");
                            this.proveedores_sort(2);
                            this.txtBuscar.Enabled = false;
                            this.txtBuscar.Text = "";
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            try
                            {
                                this.dgvProveedores.Rows[this.dgvProveedores.CurrentRow.Index].Selected = true;
                            }
                            catch (Exception)   {     } 

                        }
                    }
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este proveedor esta asignada a varios productos.", this.btnEliminar, 0, 40, 3000);
                    ////this.txtBuscar.Focus();
                    return;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvProveedores.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
                else
                    this.dgvProveedores.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                    else
                    {
                        this.txtBuscar.Text = "";
                        //this.dgvProveedores.DataSource = NProveedores.buscar("");
                        ////.txtBuscar.Focus();
                    }
                }
                else if (e.KeyValue == 46)
                {
                    if (this.dgvProveedores.Rows.Count > 0)
                        click_eliminar();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
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
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvProveedores.DataSource = NProveedores.buscar("");
                            this.proveedores_sort(2);

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
                    catch (Exception ex) { cGeneral.error(ex); }
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProveedores_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProveedores.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                    {
                        this.txtBuscar.Focus();
                        ////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                    }
                    else
                        this.btnAgregar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
           //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductos_Acciones);

                if (frm != null)
                {
                    if (frmProductos_Acciones.me.cmbEspecificacion.Items.Count > 0)
                        if (Convert.ToInt32(frmProductos_Acciones.me.cmbEspecificacion.Value) == this.id_captado)
                        {
                            frmProductos_Acciones.me.cmbEspecificacion.DataSource = NProveedores.lista_combo();
                            frmProductos_Acciones.me.cmbEspecificacion.ValueMember = "Id";
                            frmProductos_Acciones.me.cmbEspecificacion.DisplayMember = "Proveedor";

                            frmProductos_Acciones.me.cmbEspecificacion.Text = this.prov_captado;
                        }

                    frmProductos_Acciones.me.tEnfoque.Enabled = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProveedores.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProveedores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProveedores.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProveedores.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProveedores.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProveedores.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvProveedores.Columns[0].Frozen = true;
                this.dgvProveedores.Columns[1].Frozen = true;

                this.dgvProveedores.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
