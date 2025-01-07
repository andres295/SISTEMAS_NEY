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

namespace SCM.Permisos
{
    public partial class frmUsuarios : Form
    {
        public static frmUsuarios me;

        public frmUsuarios()
        {
            frmUsuarios.me = this;
            InitializeComponent();
        }

        void usuarios_sort(int col)
        {
            this.dgvUsuarios.Sort(this.dgvUsuarios.Columns[col], ListSortDirection.Ascending);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmUsuarios_Acciones frm = new frmUsuarios_Acciones();
                frm.accion = true;
                frm.Text = "AGREGAR USUARIO";
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Permisos.frmUsuarios_Acciones frm = new Permisos.frmUsuarios_Acciones();
                frm.accion = false;
                frm.Text = "MODIFICAR";

                DataTable dt_datos = new DataTable();
                dt_datos = NUsuarios.obtener_datos(Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells[0].Value));

                frm.txtUsuario.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.txtContraseña.Text = DesEncriptar(dt_datos.Rows[0].ItemArray[2].ToString());
                frm.cmbTipo.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                frm.txtUsuarioSql.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                frm.txtPasswordSQL.Text ="DEFAULT";
                if (dt_datos.Rows[0].ItemArray[4].ToString() == "ACTIVO")
                    frm.cbEstado.Checked = true;
                else
                    frm.cbEstado.Checked = false;

                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvUsuarios);
                est.SetDoubleBuffered(this.dgvUsuarios);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvUsuarios.DataSource = NUsuarios.buscar("");
                this.txtRegistros.Text = NUsuarios.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvUsuarios);

                if (this.txtRegistros.Text != "0")
                    this.txtBuscar.Enabled = true;

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void CargarUsuario(string filtro)
        {
            try
            {
                DataTable dtTipoUsuario = NUsuarios.obtener_datos(cGeneral.id_user_actual);
                if (dtTipoUsuario.Rows.Count > 0)
                {
                    if (dtTipoUsuario.Rows[0]["Tipo_Usuario"].ToString() == "CIERTO ACCESO")
                    {
                        this.dgvUsuarios.DataSource = NUsuarios.buscarLimitados(filtro, cGeneral.id_user_actual);
                    }
                    else
                    {
                        this.dgvUsuarios.DataSource = NUsuarios.buscar(filtro);
                    }
                }
            }
            catch (Exception) { }
        }
        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;
                CargarUsuario(this.txtBuscar.Text);
                this.usuarios_sort(1);

                if (this.dgvUsuarios.Rows.Count == 0)
                {
                    this.btnModificar.Enabled = false;
                    ///this.btnEliminar.Enabled = false;
                    this.txtBuscar.Focus();
                }
                else
                {
                    this.btnModificar.Enabled = true;
                    /// this.btnEliminar.Enabled = true;
                    this.txtBuscar.Focus();
                }

                if (this.txtBuscar.Text == "")
                    this.btnAgregar.Enabled = true;
                else
                    this.btnAgregar.Enabled = false;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                } 
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvUsuarios.DataSource = NUsuarios.buscar("");

                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                           /// this.btnEliminar.Enabled = false;
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el nombre, tipo y estado del usuario", this.txtBuscar, 0, 26);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
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

        private void dgvUsuarios_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuarios.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.txtBuscar.Text = "";
                    this.txtBuscar.Focus();
                }
                else if (e.KeyValue == 46)
                {
                    if (this.dgvUsuarios.Rows.Count > 0)
                        click_eliminar();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvUsuarios.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
                else
                    this.dgvUsuarios.Focus();
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
                DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste usuario.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.dgvUsuarios.Focus();
                    return;
                }

                NUsuarios.eliminar(Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells[0].Value));
                this.dgvUsuarios.Rows.Remove(this.dgvUsuarios.CurrentRow);
                this.txtRegistros.Text = NUsuarios.num_reg().ToString("N0");

                if (this.txtRegistros.Text == "0")
                {
                    this.txtBuscar.Text = "";
                    this.txtBuscar.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    ///this.btnEliminar.Enabled = false;
                    this.btnAgregar.Focus();
                }
                else
                {
                    this.dgvUsuarios.Rows[this.dgvUsuarios.CurrentRow.Index].Selected = true;

                    if (this.dgvUsuarios.Rows.Count == 0)
                        this.txtBuscar.Focus();
                    else
                        this.dgvUsuarios.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvUsuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvUsuarios.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvUsuarios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvUsuarios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvUsuarios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvUsuarios.Columns[0].Frozen = true;
                this.dgvUsuarios.Columns[1].Frozen = true;

                this.dgvUsuarios.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        /// Encripta una cadena
        public string Encriptar(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex )
            {

                throw ex;
            } 
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(password);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
    }
}
