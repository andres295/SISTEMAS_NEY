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
    public partial class frmClientes : Form
    {
        public static frmClientes me;

        public frmClientes()
        {
            frmClientes.me = this;
            InitializeComponent();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvClientes.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
                else
                    this.dgvClientes.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientes_Acciones frm = new frmClientes_Acciones();
                frm.Text = "AGREGAR CLIENTE";
                frm.accion = false;

                frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                frm.mtxtRUC.Mask = cGeneral.formato_cedula;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                frm.cmbTipoIdentificacion.DataSource = NTipoIdentificacion.obtener_datos();
                frm.cmbTipoIdentificacion.ValueMember = "Id";
                frm.cmbTipoIdentificacion.DisplayMember = "TipoIdentificacion";

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
                DataTable dt_datos = new DataTable();
                dt_datos = NClientes.obtener_datos(Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value));

                if (dt_datos.Rows.Count> 0)
                {
                    frmClientes_Acciones frm = new frmClientes_Acciones(dt_datos.Rows[0].ItemArray[1].ToString(), dt_datos.Rows[0].ItemArray[2].ToString());
                    frm.Text = "MODIFICAR LOS DATOS DEL CLIENTE";
                    frm.accion = true;

                    frm.cmbTipoIdentificacion.DataSource = NTipoIdentificacion.obtener_datos();
                    frm.cmbTipoIdentificacion.ValueMember = "Id";
                    frm.cmbTipoIdentificacion.DisplayMember = "TipoIdentificacion";

                    frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                    frm.mtxtRUC.Mask = cGeneral.formato_ruc;
                    frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                    frm.mtxtCedula.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                    frm.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                    frm.txtPrimerNombre.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                    frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                    frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                    frm.txtCorreo.Text = dt_datos.Rows[0].ItemArray[6].ToString();
                    frm.txtCiudad.Text = dt_datos.Rows[0].ItemArray[7].ToString();
                    try
                    {
                        frm.cmbTipoIdentificacion.Value = int.Parse( dt_datos.Rows[0].ItemArray[8].ToString());
                    }
                    catch (Exception)  {  }
                    

                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontro el cliente para editar", "Editar client");
                }
               
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

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvClientes);
                est.SetDoubleBuffered(this.dgvClientes);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvClientes.DataSource = NClientes.buscar("");
                this.clientes_sort(3);
                this.txtRegistros.Text = NClientes.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvClientes);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        public void clientes_sort(int col)
        {
            this.dgvClientes.Sort(this.dgvClientes.Columns[col], ListSortDirection.Ascending);
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
                    if (this.dgvClientes.Rows.Count > 0)
                        this.dgvClientes.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvClientes.DataSource = NClientes.buscar("");
                            this.clientes_sort(3);

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

                this.dgvClientes.DataSource = NClientes.buscar(this.txtBuscar.Text);
                this.clientes_sort(3);

                if (this.dgvClientes.Rows.Count == 0)
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvClientes_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.Rows.Count == 0)
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

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.dgvClientes.Rows.Count > 0)
                    {
                        this.txtBuscar.Text = "";
                        this.txtBuscar.Focus();
                    }
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
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
                if (!NClientes.ValidaClienteEnvioSRI(this.dgvClientes.CurrentRow.Cells[0].Value.ToString()))
                {
                    DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste cliente.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.Yes)
                    {
                        NClientes.eliminar(Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value));
                        this.dgvClientes.Rows.Remove(this.dgvClientes.CurrentRow);
                        this.txtRegistros.Text = NClientes.num_reg().ToString("N0");

                        if (this.txtRegistros.Text == "0")
                        {
                            this.txtBuscar.Text = "";
                            this.txtBuscar.Enabled = false;
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.dgvClientes.Rows[this.dgvClientes.CurrentRow.Index].Selected = true;

                            if (this.dgvClientes.Rows.Count == 0)
                                this.txtBuscar.Focus();
                            else
                                this.dgvClientes.Focus();
                        }
                    }
                    else
                        this.dgvClientes.Focus();
                }
                else
                {
                    MessageBox.Show("No es posible eliminar el cliente, ya que este tiene ventas enviadas y/o pendientes de envio al SRI.", "Cliente no se puede eliminar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.ttMensaje.Show("Busca el # cédula, # ruc, nombres, apellidos, teléfono y dirección del cliente", this.txtBuscar, 0, 26);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvClientes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvClientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvClientes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvClientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvClientes.Columns[0].Frozen = true;
                this.dgvClientes.Columns[1].Frozen = true;

                this.dgvClientes.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
