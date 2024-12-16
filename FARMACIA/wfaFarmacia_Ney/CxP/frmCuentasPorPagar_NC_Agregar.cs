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

namespace wfaFarmacia_Ney.CxP
{
    public partial class frmCuentasPorPagar_NC_Agregar : Form
    {
        public static frmCuentasPorPagar_NC_Agregar me;
        ///public static frmCuentasPorPagar_NC me;
        public string nu_factura = "";
        public bool automatica = false;

        public frmCuentasPorPagar_NC_Agregar()
        {
           frmCuentasPorPagar_NC_Agregar.me = this;
            InitializeComponent();
        }

        public int id_prov_captado = 0;
        public string prov_captado = "";
        public string nc_actual = "";

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnGuardar);

            frmCuentasPorPagar_NC_Selec frm = new frmCuentasPorPagar_NC_Selec();
            frm.ShowDialog();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            this.tEnfoque.Enabled = false;

            if (this.btnProv.Visible == false)
                this.mtxtNC.Focus();
            else
            {
                if (this.mtxtFactura.MaskFull)
                    this.txtObser.Focus();
                else
                    this.mtxtRUC.Focus();
            }
        }

        private void mtxtNC_TextChanged(object sender, EventArgs e)
        {
            if (this.mtxtNC.MaskFull)
            {
                this.btnProv.Enabled = true;
                
                if (this.btnProv.Visible)
                {
                    if (this.Text == "AGREGAR")
                    {
                        if (this.mtxtFactura.MaskFull == false)
                        {
                            frmCuentasPorPagar_NC_Selec frm = new frmCuentasPorPagar_NC_Selec();
                            frm.ShowDialog();
                        }
                    }
                }
                else
                    this.dtpFechaDoc.Focus();
            }
            else
                this.btnProv.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.mtxtNC.MaskFull == false)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El número de NC está vacío/incompleto", this.btnGuardar, 0, 38, 3000);
                    this.mtxtNC.Focus();
                    return;
                }
                else if (this.mtxtFactura.MaskFull == false)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Haga click en 'Proveedores' para seleccionar\nla factura afectada", this.btnGuardar, 0, 38, 5000);
                    return;
                }
                
                if (this.Text == "AGREGAR")
                {
                    if (NNotasCreditos.validar_nc(this.mtxtNC.Text) <= 0)
                    {
                        NNotasCreditos.guardar_nc(this.mtxtNC.Text, this.mtxtFactura.Text, id_prov_captado, prov_captado, this.dtpFechaDoc.Value, this.txtMatriz.Text, this.mtxtRUC.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtObser.Text,"Normal",0);

                        frmCuentasPorPagar_NC.me.abrir_frm = true;
                        frmCuentasPorPagar_NC.me.txtRegistros.Text = NNotasCreditos.num_reg().ToString("N0");
                        frmCuentasPorPagar_NC.me.txtBuscar.Enabled = true;
                        frmCuentasPorPagar_NC.me.txtBuscar.Text = this.mtxtNC.Text;

                        frmCuentasPorPagar_NC.me.tBuscar.Enabled = false;
                        frmCuentasPorPagar_NC.me.tBuscar.Enabled = true;

                        this.Close();
                    }
                    else
                    {
                        this.ttMensaje.Show("El número de NC está registrado en otro documento.", this.btnGuardar, 0, 38, 3000);
                        this.mtxtNC.Focus();
                        return;
                    }
                }
                if (this.Text == "MODIFICAR")
                {
                    if (nc_actual != this.mtxtNC.Text)
                    {
                        if (NNotasCreditos.validar_nc(this.mtxtNC.Text) <= 0)
                        {
                            NNotasCreditos.actualizar_nc(nc_actual,this.mtxtNC.Text, this.mtxtFactura.Text, id_prov_captado, prov_captado, this.dtpFechaDoc.Value, this.txtMatriz.Text, this.mtxtRUC.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtObser.Text);

                            frmCuentasPorPagar_NC.me.abrir_frm = true;
                            frmCuentasPorPagar_NC.me.txtRegistros.Text = NNotasCreditos.num_reg().ToString("N0");
                            frmCuentasPorPagar_NC.me.txtBuscar.Enabled = true;
                            frmCuentasPorPagar_NC.me.txtBuscar.Text = this.mtxtNC.Text;
                            this.Close();
                        }
                        else
                        {
                            this.ttMensaje.Show("El número de NC está registrado en otro documento.", this.btnGuardar, 0, 38, 3000);
                            this.mtxtNC.Focus();
                            return;
                        }
                    }
                    else
                    {
                        NNotasCreditos.actualizar_nc(nc_actual,this.mtxtNC.Text, this.mtxtFactura.Text, id_prov_captado, prov_captado, this.dtpFechaDoc.Value, this.txtMatriz.Text, this.mtxtRUC.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtObser.Text);

                        frmCuentasPorPagar_NC.me.abrir_frm = true;
                        frmCuentasPorPagar_NC.me.txtRegistros.Text = NNotasCreditos.num_reg().ToString("N0");
                        frmCuentasPorPagar_NC.me.txtBuscar.Enabled = true;
                        frmCuentasPorPagar_NC.me.txtBuscar.Text = this.mtxtNC.Text;
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCuentasPorPagar_NC_Agregar_Load(object sender, EventArgs e)
        {
            this.txtProv.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtObser.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
  
            if (this.automatica)
            {
                this.mtxtFactura.Text = this.nu_factura;

                DataTable dt_datos = NProveedores.obtener_datos(frmCuentasPorPagar.me.id_prov_captado);
                try
                {
                    if (dt_datos.Rows.Count>0 )
                    {
                        this.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                        this.txtProv.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                        this.txtMatriz.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                        this.txtDireccion.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                        this.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();

                        id_prov_captado = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString());
                        prov_captado = this.txtProv.Text;

                        this.btnProv.Visible = false;
                    }
                    else
                    {
                        DataTable dt_datos_fac = NProveedores.obtener_id_factura(this.mtxtFactura.Text);
                        DataTable dt_datos_prov = NProveedores.obtener_datos(int.Parse(dt_datos_fac.Rows[0]["Id_Proveedor"].ToString()));

                        if (dt_datos_prov.Rows.Count > 0)
                        {
                            this.mtxtRUC.Text = dt_datos_prov.Rows[0].ItemArray[5].ToString();
                            this.txtProv.Text = dt_datos_prov.Rows[0].ItemArray[1].ToString();
                            this.txtMatriz.Text = dt_datos_prov.Rows[0].ItemArray[2].ToString();
                            this.txtDireccion.Text = dt_datos_prov.Rows[0].ItemArray[3].ToString();
                            this.mtxtTelefono.Text = dt_datos_prov.Rows[0].ItemArray[4].ToString();

                            id_prov_captado = Convert.ToInt32(dt_datos_prov.Rows[0].ItemArray[0].ToString());
                            prov_captado = this.txtProv.Text;

                            this.btnProv.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("No se encontro el dato del proveedor.", "Datos de proveedor no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                catch (Exception) { this.btnProv.Visible = true; this.btnProv.Enabled = true; }
             
            }

            this.mtxtNC.Mask = cGeneral.formato_NC;
            this.mtxtFactura.Mask = cGeneral.formato_factura;
            this.mtxtTelefono.Mask = cGeneral.formato_telefono;
        }

        private void mtxtNC_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void dtpFechaDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void mtxtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void mtxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void txtMatriz_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtObser_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
    }
}
