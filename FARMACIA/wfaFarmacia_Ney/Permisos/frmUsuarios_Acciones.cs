using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.Permisos
{
    public partial class frmUsuarios_Acciones : Form
    {
        public frmUsuarios_Acciones()
        {
            InitializeComponent();
        }

        public bool accion;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Acciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtUsuario.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                this.txtContraseña.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                if (cGeneral.tipo_usuario == "CIERTO ACCESO")
                {
                    this.cmbTipo.Enabled = false;
                    this.cmbTipo.SelectedIndex = 1;
                }
                else if (this.accion == true)
                {
                    this.cmbTipo.SelectedIndex = 0;
                }

                cargarPermiso();
                PuedeHeredarPermiso();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbTipo_DropDownClosed(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.txtUsuario.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el usuario", this.btnGuardar, 0, 38, 3000);
                    this.txtUsuario.Focus();
                    return;
                }
                else if (this.txtContraseña.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la contraseña", this.btnGuardar, 0, 38, 3000);
                    this.txtContraseña.Focus();
                    return;
                }

                string estado;

                if (this.cbEstado.Checked == true)
                    estado = "ACTIVO";
                else
                    estado = "NO ACTIVO";

                if (this.accion == true)
                {
                    //AGREGAR.
                    if (NUsuarios.guardar(this.txtUsuario.Text, Encriptar( this.txtContraseña.Text), this.cmbTipo.Text, estado,txtUsuarioSql.Text.Trim()))
                    {
                        NUsuarios.create_login_sql(txtUsuarioSql.Text.Trim(), txtPasswordSQL.Text);
                        frmUsuarios.me.txtRegistros.Text = NUsuarios.num_reg().ToString("N0");
                        frmUsuarios.me.txtBuscar.Enabled = true;

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El usuario ha sido guardado", this.btnGuardar, 0, 38, 3000);

                        this.txtUsuario.Text = "";
                        this.txtContraseña.Text = "";
                        this.cmbTipo.SelectedIndex = 0;
                        this.cbEstado.Checked = true;
                        this.txtUsuario.Focus();
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (NUsuarios.modificar(Convert.ToInt32(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value), this.txtUsuario.Text, Encriptar(this.txtContraseña.Text), this.cmbTipo.Text, estado,txtUsuarioSql.Text.Trim()))
                    {
                        NUsuarios.create_login_sql(txtUsuarioSql.Text.Trim(), txtPasswordSQL.Text);
                        frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[1].Value = this.txtUsuario.Text;
                        frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[3].Value = this.cmbTipo.Text;
                        frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[4].Value = estado;
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblCaract.Text = "" + this.txtUsuario.Text.Length + "/" + this.txtUsuario.MaxLength + "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);

                if (e.KeyChar == 32)
                    e.Handled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmUsuarios_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmUsuarios.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.Text.ToString() == "CIERTO ACCESO")
            {
                cblPermiso.Enabled = true;
                cblHerenciaPermiso.Enabled = true;
            }
            else {
                cblPermiso.Enabled = false;
                cblHerenciaPermiso.Enabled = false;
            }
        }

        private void cargarPermiso()
        {
            try
            {
                DataTable dt = NPermiso.getPermisoByUsuarioAsignado(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString(), cGeneral.tipo_usuario, "0", "0");
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        cblPermiso.Items.Add(new ListItem(dt.Rows[i]["Ventanas"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Asignado"].ToString() == "1" ? true : false);
                //    }
                //}
                DataRow[] rows = dt.Select("Ventanas like '%" + txtBuscar.Text.Trim() + "%'");
                cblPermiso.Items.Clear();
                foreach (DataRow row in rows)
                {
                    cblPermiso.Items.Add(new ListItem(row["Ventanas"].ToString(), row["Id"].ToString()), row["Asignado"].ToString() == "1" ? true : false);
                }
            }
            catch (Exception ex) { }
        }

        private void cargarParaHerenciaPermiso()
        {
            try
            {

                if (cGeneral.id_user_actual.ToString() == "ADMINISTRADOR")
                {
                    DataTable dt = NPermiso.getPermisoByUsuarioAsignado(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString(), cGeneral.tipo_usuario, "0", "0");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cblPermiso.Items.Add(new ListItem(dt.Rows[i]["Ventanas"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Asignado"].ToString() == "1" ? true : false);
                        }
                    }
                }
                else
                {
                    DataTable dt = NPermiso.getPermisoByUsuarioAsignado(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString(), cGeneral.tipo_usuario, "1", "1");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cblPermiso.Items.Add(new ListItem(dt.Rows[i]["Ventanas"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Asignado"].ToString() == "1" ? true : false);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void PuedeHeredarPermiso()
        {
            try
            {
                if (cGeneral.id_user_actual.ToString() == "ADMINISTRADOR")
                {
                    DataTable dt = NPermiso.getPermisoByUsuarioAsignado(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString(), cGeneral.tipo_usuario, "0", "0");
                    //if (dt.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        cblHerenciaPermiso.Items.Add(new ListItem(dt.Rows[i]["Ventanas"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Asignado"].ToString() == "1" ? true : false);
                    //    }
                    //}
                    DataRow[] rows = dt.Select("Ventanas like '%" + txtBuscar.Text.Trim() + "%'");
                    cblHerenciaPermiso.Items.Clear();
                    foreach (DataRow row in rows)
                    {
                        cblHerenciaPermiso.Items.Add(new ListItem(row["Ventanas"].ToString(), row["Id"].ToString()), row["Asignado"].ToString() == "1" ? true : false);
                    }
                }
                else
                {
                    DataTable dt = NPermiso.getPermisoByUsuarioAsignado(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString(), cGeneral.tipo_usuario, "1", "1");
                    //if (dt.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        cblHerenciaPermiso.Items.Add(new ListItem(dt.Rows[i]["Ventanas"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Asignado"].ToString() == "1" ? true : false);
                    //    }
                    //}
                    DataRow[] rows = dt.Select("Ventanas like '%" + txtBuscar.Text.Trim() + "%'");
                    cblHerenciaPermiso.Items.Clear();
                    foreach (DataRow row in rows)
                    {
                        cblHerenciaPermiso.Items.Add(new ListItem(row["Ventanas"].ToString(), row["Id"].ToString()), row["Asignado"].ToString() == "1" ? true : false);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void PermisoParaHeredar()
        {
            try
            {
                DataTable dt = NPermiso.getPermisoByUsuarioAsignado(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString(), cGeneral.tipo_usuario, "0", "1");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cblPermiso.Items.Add(new ListItem(dt.Rows[i]["Ventanas"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Asignado"].ToString() == "1" ? true : false);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void cblPermiso_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                var checkBoxName = cblPermiso.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;

                 NPermiso.asignar(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), id,0);

            }
            else
            {
                var checkBoxName = cblPermiso.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;
                 NPermiso.quitar(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), id);
            } 
        }

        private void cblHerenciaPermiso_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                var checkBoxName = cblHerenciaPermiso.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;

                NPermiso.asignar(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), id,1);

            }
            else
            {
                var checkBoxName = cblHerenciaPermiso.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;
                NPermiso.quitar(frmUsuarios.me.dgvUsuarios.CurrentRow.Cells[0].Value.ToString(), id);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarPermiso();
            PuedeHeredarPermiso();
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
            catch (Exception ex)
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
