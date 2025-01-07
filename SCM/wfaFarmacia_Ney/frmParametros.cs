using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using SCM.Globales;

namespace SCM
{
    public partial class frmParametros : Form
    {
        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE

        public frmParametros()
        {
            InitializeComponent();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            this.tbParametros.Tabs[1].Visible = false;
            try
            {
                DataTable dt = NParametros.buscar("");
                if (dt.Rows.Count > 0)
                {
                    lblId.Text = dt.Rows[0]["Id"].ToString();
                    txtNombreEmpresa.Text = dt.Rows[0]["Nombre_Empresa"].ToString();
                    mtxtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                    txtCorreo.Text = dt.Rows[0]["Correo"].ToString();
                    txtDireccion.Text = dt.Rows[0]["Direccion"].ToString();
                    txtRuc.Text = dt.Rows[0]["Ruc"].ToString();
                    txtAlias.Text = dt.Rows[0]["Alias"].ToString();
                    txtRutaImagen.Text = dt.Rows[0]["Ruta_Imagen"].ToString();
                    txtRutaBackup.Text = dt.Rows[0]["Ruta_Backup"].ToString();
                    txtNumeroItems.Text = dt.Rows[0]["NumItem"].ToString();
                    cbFormato.Text = dt.Rows[0]["Alto_Print_Factura"].ToString();
                    cbAutomatico.Checked = bool.Parse(dt.Rows[0]["BK_Automatico"].ToString());
                    dtpDesde.Value = Convert.ToDateTime( dt.Rows[0]["BK_Desde"].ToString());
                    dtpHasta.Value = Convert.ToDateTime(dt.Rows[0]["BK_Hasta"].ToString());
                    txtNumeroStock.Text = dt.Rows[0]["Stock_producto"].ToString();
                    txtDiaVencimientoProducto.Text = dt.Rows[0]["Dia_Vencimiento"].ToString();
                    txtNumVentanas.Text = dt.Rows[0]["NumVentanaVenta"].ToString();
                    dtIinicioRenta.Value = Convert.ToDateTime(DesEncriptar(dt.Rows[0]["NVIA"].ToString()));
                    dtFinRenta.Value     = Convert.ToDateTime(DesEncriptar(dt.Rows[0]["NVIB"].ToString()));
                    txtNotaAvisoCM.Text = dt.Rows[0]["NotaAvisoCM"].ToString();
                    txtEspecialidades.Text = dt.Rows[0]["Especialidades"].ToString();
                    txtRegistroSanitario.Text = dt.Rows[0]["RegistroSanitario"].ToString();
                    if (cGeneral.tipo_usuario =="ADMINISTRADOR")
                    {
                        this.tbParametros.Tabs[1].Visible = true;
                    }
                }

                NConexion.ObtenerParametros();
                txtImageFondo.Text = NConexion.gstrBackground;
            }
            catch (Exception ex)
            {

                this.ttMensaje.ToolTipTitle = "ERROR CARGA DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("Error al cargar el dato", this.btnGuardar, 0, 38, 3000);
                this.mtxtTelefono.Focus();

            }

        }

        public bool validar_stock()
        {
            try
            {
                int.Parse(this.txtNumeroStock.Text.ToString()); 
                return true;
            }
            catch (Exception)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese el número de stock para cargar el producto en VENTANA de ventas.", this.btnGuardar, 0, 38, 3000);
                this.txtNumeroStock.Focus();

                return false;
            }
        }
        public bool validar_item()
        {
            try
            {
                int.Parse(this.txtNumeroItems.Text.ToString()); 
                return true;
            }
            catch (Exception)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese el número de ITEMS para imprimir en el reporte de VENTA.", this.btnGuardar, 0, 38, 3000);
                this.txtNumeroItems.Focus();

                return false;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.txtNombreEmpresa.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el nombre de la empresa", this.btnGuardar, 0, 38, 3000);
                    this.txtNombreEmpresa.Focus();
                    return;
                }
                else if (this.mtxtTelefono.Text != "")
                    if (this.mtxtTelefono.MaskFull == false)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("El número de teléfono está incompleto", this.btnGuardar, 0, 38, 3000);
                        this.mtxtTelefono.Focus();
                        return;
                    }
                if (this.txtNumVentanas.MaskFull == true)
                {
                    try
                    {
                        if (int.Parse(txtNumVentanas.Text) > 3)
                        {
                            this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("El número de ventana para ventas tiene que ser menor o igual a 3", this.btnGuardar, 0, 38, 3000);
                            this.txtNumVentanas.Focus();
                            return;
                        } 
                    }
                    catch (Exception) {    }

                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No ha definido el número de ventana de ventas.", this.btnGuardar, 0, 38, 3000);
                    this.txtNumVentanas.Focus();
                    return;
                }
                if (!validar_stock())
                {
                    return;
                }
                if (!validar_item())
                {
                    return;
                }
                if (NParametros.verificar_si_existe(this.lblId.Text))
                        {
                            //MODIFICAR.
                            if (NParametros.modificar( int.Parse(this.lblId.Text), this.txtNombreEmpresa.Text, (this.mtxtTelefono.Text == "" ? "" : this.mtxtTelefono.Text), this.txtCorreo.Text, this.txtDireccion.Text, this.txtRuc.Text, this.txtAlias.Text, this.txtRutaImagen.Text,this.txtRutaBackup.Text,int.Parse(this.txtNumeroItems.Text.ToString()),cbFormato.Text,cbAutomatico.Checked,dtpDesde.Value,dtpHasta.Value, int.Parse(this.txtNumeroStock.Text.ToString()), int.Parse(this.txtDiaVencimientoProducto.Text.ToString()),txtNumVentanas.Text,dtIinicioRenta.Value, dtFinRenta.Value,txtNotaAvisoCM.Text,txtEspecialidades.Text,txtRegistroSanitario.Text))
                            {
                                this.txtNombreEmpresa.Focus();
                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                cGeneral.numItem = int.Parse(this.txtNumeroItems.Text.ToString());
                                cGeneral.numVentana = int.Parse(this.txtNumVentanas.Text.ToString());
                                cGeneral.stock_producto = int.Parse(this.txtNumeroStock.Text.ToString());
                                cGeneral.dia_vencimiento = int.Parse(this.txtDiaVencimientoProducto.Text.ToString());
                                cGeneral.alto_factura = cbFormato.Text;
                                cGeneral.ruta_guardar_img = txtRutaImagen.Text;
                                this.ttMensaje.Show("El parametro ha sido guardado", this.btnGuardar, 0, 38, 3000);
                            }
                       }
                    else {
                            //AGREGAR.
                            if (NParametros.guardar(this.txtNombreEmpresa.Text, (this.mtxtTelefono.Text == "" ? "" : this.mtxtTelefono.Text), this.txtCorreo.Text, this.txtDireccion.Text, this.txtRuc.Text, this.txtAlias.Text, this.txtRutaImagen.Text,this.txtRutaBackup.Text,int.Parse(this.txtNumeroItems.Text.ToString()), cbFormato.Text,cbAutomatico.Checked,dtpDesde.Value,dtpHasta.Value, int.Parse(this.txtNumeroStock.Text.ToString()), int.Parse(this.txtDiaVencimientoProducto.Text.ToString()),txtNumVentanas.Text, dtIinicioRenta.Value, dtFinRenta.Value,txtNotaAvisoCM.Text, txtEspecialidades.Text,txtRegistroSanitario.Text))
                            {
                                this.txtNombreEmpresa.Focus();
                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                cGeneral.numItem = int.Parse(this.txtNumeroItems.Text.ToString());
                                cGeneral.numVentana = int.Parse(this.txtNumVentanas.Text.ToString());
                                cGeneral.stock_producto = int.Parse(this.txtNumeroStock.Text.ToString());
                                cGeneral.dia_vencimiento = int.Parse(this.txtDiaVencimientoProducto.Text.ToString());
                                cGeneral.alto_factura = cbFormato.Text;
                                cGeneral.ruta_guardar_img = txtRutaImagen.Text;
                                this.ttMensaje.Show("El parametro ha sido guardado", this.btnGuardar, 0, 38, 3000);
                                this.Close();
                            }
                    } 
                NConexion.gstrBackground = this.txtImageFondo.Text;
                NConexion.GuardaBackground();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFileImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog1.Title = "Seleccione el archivo para cargar.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "Seleccione una imagen valida (*.jpg; *.png)|*.jpg; *.png";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists)
                {
                    string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    txtImageFondo.Text = path;
                }
            }
            else
            {
                MessageBox.Show("Porfavor selecione la imagen.");
            }

        }
        /// Encripta una cadena
        public string Encriptar(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(value);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(value);
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
