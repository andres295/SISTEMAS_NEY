using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;
using wfaFarmacia_Ney.Properties;

namespace wfaFarmacia_Ney
{
    public partial class frmInicioSesion : Form
    {
        public static frmInicioSesion me;

        public frmInicioSesion()
        {
           
            frmInicioSesion.me = this;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Height = 250;
                this.SendToBack ();
                NConexion.ObtenerParametros();

                txtUsuario.Text = NConexion.gstrdbUsuario;
                txtContrasena.Text = DesEncriptar(NConexion.gstrdbClave);
                txtServidor.Text = NConexion.gstrdbServidor;
                TxtBasedeDatos.Text = NConexion.gstrdbBaseDatos;
                tbxImpresora.Text = NConexion.gstrImpresora;

                this.txtContraseña.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                if (NConexion.gstrdbBaseDatos != "ND" && NConexion.gstrdbBaseDatos != null)
                {
                    this.cmbUsuario.DataSource = NUsuarios.listar();
                    this.cmbUsuario.ValueMember = "Id";
                    this.cmbUsuario.DisplayMember = "Usuario";
                }
               
                if (NConexion.gstrdbId != "")
                {
                    this.cbRecordar.Checked = true;
                    this.cmbUsuario.SelectedValue = NConexion.gstrdbId;
                }
                else
                {
                    if (this.cmbUsuario.Items.Count > 0)
                        this.cmbUsuario.SelectedIndex = 0;
                }
                
                txtServidor.Text = NConexion.gstrdbServidor;
                TxtBasedeDatos.Text = NConexion.gstrdbBaseDatos;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbUsuario_DropDownClosed(object sender, EventArgs e)
        {
            this.txtContraseña.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_entrar();
        }

        void click_entrar()
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);
                ///'obtener el valor de los parametros
                NConexion.gstrdbUsuario = txtUsuario.Text.Trim();
                NConexion.gstrdbClave = Encriptar(txtContrasena.Text);
                NConexion.gstrdbServidor = txtServidor.Text;
                NConexion.gstrdbBaseDatos = TxtBasedeDatos.Text;
                NConexion.gstrImpresora = tbxImpresora.Text;

                if (NConexion.conectar())
                {
                    NConexion.GuardarConexion();
                    if (this.txtContraseña.Text == "")
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la contraseña", this.btnGuardar, 0, 38, 3000);
                        this.txtContraseña.Focus();
                        return;
                    }

                    if (NUsuarios.validar_login(Convert.ToInt32(this.cmbUsuario.SelectedValue), Encriptar( this.txtContraseña.Text)) == false)
                    {
                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("La contraseña es incorrecta", this.btnGuardar, 0, 38, 3000);
                        this.txtContraseña.Focus();
                        this.txtContraseña.Select(0, this.txtContraseña.Text.Length);
                        return;
                    }

                    if (this.cbRecordar.Checked)
                    {

                        NConexion.gstrdbId = this.cmbUsuario.SelectedValue.ToString();
                        NConexion.GuardarIdUser();
                    }
                    else
                    {
                        NConexion.gstrdbId = "";
                        NConexion.GuardarIdUser();
                    }

                    cGeneral.id_user_actual = Convert.ToInt32(this.cmbUsuario.SelectedValue);
                    try
                    {
                        DataTable dtTipoUsuario = NUsuarios.obtener_datos(Convert.ToInt32(this.cmbUsuario.SelectedValue));
                        if (dtTipoUsuario.Rows.Count > 0)
                        {
                            cGeneral.tipo_usuario = dtTipoUsuario.Rows[0]["Tipo_Usuario"].ToString();
                        }
                    }
                    catch (Exception) { }

                    cGeneral.Impresora = tbxImpresora.Text;
                    this.Hide();
                    try
                    {
                        NParametros.backup_bd(NConexion.gstrdbBaseDatos, true);
                    }
                    catch (Exception)  {
                        MessageBox.Show("Favor revisar la ruta para realizar el Backup ya que no se ha podido realizar.", "Backup no se ha prodido realizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        MDI.frmPrincipal frm = new MDI.frmPrincipal();
                        frm.lblUsuario.Text = this.cmbUsuario.Text;
                        cGeneral.name_user = this.cmbUsuario.Text;
                        frm.ShowDialog();
                        frm.BringToFront();
                    }
                    catch (Exception ex) {   }
                 
                }

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            this.txtContraseña.Select(0, this.txtContraseña.Text.Length);
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_entrar();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void btnTestConexion_Click(object sender, EventArgs e)
        {
            NConexion.gstrdbUsuario = txtUsuario.Text.Trim();
            NConexion.gstrdbClave = Encriptar(txtContrasena.Text);
            NConexion.gstrdbServidor = txtServidor.Text;
            NConexion.gstrdbBaseDatos = TxtBasedeDatos.Text;

            NConexion.GuardarConexion();
            if (conectar())
            {
                this.cmbUsuario.DataSource = NUsuarios.listar();
                this.cmbUsuario.ValueMember = "Id";
                this.cmbUsuario.DisplayMember = "Usuario";
                cGeneral.IVA = NIVA.obtener_iva();

                MessageBox.Show("Conexión realizada con éxito!", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No ex posible conectarse al servidor!", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public bool conectar()
        {
            bool resp = false;
            try
            {
                SqlConnection conexion;
                string cadena = @"Data Source=" + txtServidor.Text + ";Initial Catalog=" + TxtBasedeDatos.Text + ";Persist Security Info=True;User ID=" + txtUsuario.Text.Trim() + ";Password=" + txtContrasena.Text + ";Connect Timeout=9000";

                conexion = new SqlConnection(cadena);
                conexion.Open();
                resp = true;
                
                return resp;
            }
            catch (Exception)
            {
                MessageBox.Show("No es posible conectarse al servidor!", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resp;
        }
        private void btnServidor_Click(object sender, EventArgs e)
        {
            gbServidor.Visible = true;
            this.Height = 452;
        }

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

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
