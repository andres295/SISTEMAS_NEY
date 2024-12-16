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
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.SRI
{
    public partial class frmParametrosSRI : Form
    {
        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE

        public frmParametrosSRI()
        {
            InitializeComponent();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = NParametrosSRI.buscar();
                if (dt.Rows.Count > 0)
                {
                    lblId.Text = dt.Rows[0]["Id"].ToString();
                    txtAmbiente.Text = dt.Rows[0]["Ambiente"].ToString();
                    txtTipoEmision.Text = dt.Rows[0]["TipoEmision"].ToString();
                    txtTipoDocumentoFactura.Text = dt.Rows[0]["TipoDocumentoFactura"].ToString();
                    txtRazonSocial.Text = dt.Rows[0]["RazonSocial"].ToString();
                    txtNombreComercial.Text = dt.Rows[0]["NombreComercial"].ToString();
                    txtCodEstablecimiento.Text = dt.Rows[0]["Codestablecimiento"].ToString();
                    txtPuntoEmision.Text = dt.Rows[0]["Codpuntoemision"].ToString();
                    txtDireccionMatriz.Text = dt.Rows[0]["DirMatri"].ToString();
                    txtDireccionEstablecimiento.Text = dt.Rows[0]["DirEstablecimiento"].ToString();
                    txtObligadoContabilidad.Text = dt.Rows[0]["ObligadoContabilidad"].ToString(); 
                    txttxtCodigoNumerico.Text = dt.Rows[0]["CodigoNumerico"].ToString();
                    txtMoneda.Text = dt.Rows[0]["Moneda"].ToString();
                    cbActivarServicio.Checked = bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString());
                    dtpInicio.Value = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaDesde"].ToString());
                    dtFin.Value = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaHasta"].ToString());
                    txtRegimen.Text =  dt.Rows[0]["Regimen"].ToString() ;
                    txtCorreoSMTP.Text = dt.Rows[0]["CorreoSMTP"].ToString();
                    txtContrasena.Text = dt.Rows[0]["ContrasenaSMTP"].ToString();
                    txtRutaXML.Text = dt.Rows[0]["RutaXML"].ToString();
                    cbFormato.Text = dt.Rows[0]["ImpresoraTickets"].ToString();
                    txtUrlSri.Text = dt.Rows[0]["URL_SRI_LOCAL"].ToString();
                    txtTipoDocumentoRetencion.Text = dt.Rows[0]["TipoDocumentoRetencion"].ToString();
                    cbAgenteRetencion.Checked = bool.Parse( dt.Rows[0]["EsAgenteRetencion"].ToString());
                    txtCodigoAgenteRetencion.Text = dt.Rows[0]["CodigoAgenteRetencion"].ToString();
                    txtNumContribuyente.Text = dt.Rows[0]["NumContribuyente"].ToString();
                    txtcodDocSustento.Text = dt.Rows[0]["codDocSustento"].ToString();
                    try
                    {
                        nudMontoMinimo.Value = decimal.Parse(dt.Rows[0]["MontoMinimoConsumidorFinal"].ToString());
                    }
                    catch (Exception)
                    {
                        nudMontoMinimo.Value = 0;
                    }
                   
                }

                NConexion.ObtenerParametros(); 
            }
            catch (Exception ex)
            {

                this.ttMensaje.ToolTipTitle = "ERROR CARGA DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("Error al cargar el dato", this.btnGuardar, 0, 38, 3000);
                this.txtRazonSocial.Focus();

            } 
        }  
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.txtAmbiente.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Ambiente", this.btnGuardar, 0, 38, 3000);
                    this.txtAmbiente.Focus();
                    return;
                }
                else if (this.txtTipoEmision.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Tipo Emision", this.btnGuardar, 0, 38, 3000);
                    this.txtTipoEmision.Focus();
                    return;
                } 
                else if (this.txtTipoDocumentoFactura.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el tipo de factura(comprobante)", this.btnGuardar, 0, 38, 3000);
                    this.txtTipoDocumentoFactura.Focus();
                    return;
                }
                else if (this.txtRazonSocial.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la razón social", this.btnGuardar, 0, 38, 3000);
                    this.txtRazonSocial.Focus();
                    return;
                }
                else if (this.txtNombreComercial.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el nombre comercial", this.btnGuardar, 0, 38, 3000);
                    this.txtNombreComercial.Focus();
                    return;
                } 
                else if (this.txtCodEstablecimiento.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el codigo del establecimiento", this.btnGuardar, 0, 38, 3000);
                    this.txtCodEstablecimiento.Focus();
                    return;
                } 
                else if (this.txtPuntoEmision.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el punto de emisión", this.btnGuardar, 0, 38, 3000);
                    this.txtPuntoEmision.Focus();
                    return;
                }
                else if (this.txtDireccionMatriz.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la dirección de la matriz", this.btnGuardar, 0, 38, 3000);
                    this.txtDireccionMatriz.Focus();
                    return;
                }
                else if (this.txtDireccionEstablecimiento.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la dirección del establecimiento", this.btnGuardar, 0, 38, 3000);
                    this.txtDireccionEstablecimiento.Focus();
                    return;
                }
                else if (this.txtObligadoContabilidad.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el obligado contabilidad", this.btnGuardar, 0, 38, 3000);
                    this.txtObligadoContabilidad.Focus();
                    return;
                }
                else if (this.labelCodigoNumerico.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el codigo númerico", this.btnGuardar, 0, 38, 3000);
                    this.labelCodigoNumerico.Focus();
                    return;
                }
                else if (this.labelMoneda.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la moneda", this.btnGuardar, 0, 38, 3000);
                    this.labelMoneda.Focus();
                    return;
                }
                else if (this.txtUrlSri.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la URL del Servicio del SRI Desarrolaldor de forma LOCAL.", this.btnGuardar, 0, 38, 3000);
                    this.txtUrlSri.Focus();
                    return;
                }
                else if (this.txtcodDocSustento.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el  codDocSustento.", this.btnGuardar, 0, 38, 3000);
                    this.txtcodDocSustento.Focus();
                    return;
                }
                if (NParametrosSRI.verificar_si_existe(this.lblId.Text))
                        {
                            //MODIFICAR.
                            if (NParametrosSRI.modificar(int.Parse(this.lblId.Text),cbActivarServicio.Checked, this.txtAmbiente.Text,txtTipoEmision.Text,txtTipoDocumentoFactura.Text,txtRazonSocial.Text,txtNombreComercial.Text,txtCodEstablecimiento.Text,txtPuntoEmision.Text,txtDireccionMatriz.Text,txtDireccionEstablecimiento.Text,txtObligadoContabilidad.Text,txttxtCodigoNumerico.Text,txtMoneda.Text,dtpInicio.Value,dtFin.Value,txtRegimen.Text.Trim(),txtCorreoSMTP.Text.Trim(),txtContrasena.Text.Trim(),txtRutaXML.Text.Trim() , cbFormato.Text.Trim(),txtUrlSri.Text,txtTipoDocumentoRetencion.Text,cbAgenteRetencion.Checked,txtCodigoAgenteRetencion.Text,txtNumContribuyente.Text,nudMontoMinimo.Value,txtcodDocSustento.Text))
                            {
                                this.txtAmbiente.Focus();
                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info; 
                                this.ttMensaje.Show("El parametro SRI ha sido guardado", this.btnGuardar, 0, 38, 3000);
                            }
                       }
                    else {
                            //AGREGAR.
                            if (NParametrosSRI.guardar(cbActivarServicio.Checked,this.txtAmbiente.Text, txtTipoEmision.Text, this.txtTipoDocumentoFactura.Text, txtRazonSocial.Text, txtNombreComercial.Text, txtCodEstablecimiento.Text, txtPuntoEmision.Text, txtDireccionMatriz.Text, txtDireccionEstablecimiento.Text, txtObligadoContabilidad.Text, txttxtCodigoNumerico.Text, txtMoneda.Text,dtpInicio.Value,dtFin.Value,txtRegimen.Text.ToString().Trim(),txtCorreoSMTP.Text.Trim(),txtContrasena.Text.Trim(),txtRutaXML.Text.Trim(),cbFormato.Text.Trim(),txtUrlSri.Text.Trim(), txtTipoDocumentoRetencion.Text, cbAgenteRetencion.Checked, txtCodigoAgenteRetencion.Text, txtNumContribuyente.Text, nudMontoMinimo.Value,  txtcodDocSustento.Text))
                    {
                                this.txtAmbiente.Focus();
                                this.ttMensaje.ToolTipTitle = "LISTO"; 
                                this.ttMensaje.Show("El parametro SRI ha sido guardado", this.btnGuardar, 0, 38, 3000);
                                this.Close();
                            }
                    }  
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
                }
            }
            else
            {
                MessageBox.Show("Porfavor selecione la imagen.");
            } 
        } 
    }
}
