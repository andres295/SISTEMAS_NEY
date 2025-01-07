using CapaNegocios;
using System; 
using System.Data; 
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.CxC
{
    public partial class frmCuentasPorCobrar_NC_Agregar : Form
    {
        public static frmCuentasPorCobrar_NC_Agregar me;
        ///public static frmCuentasPorCobrar_NC me;
        public string num_venta = "";
        public bool automatica = false;

        public frmCuentasPorCobrar_NC_Agregar()
        {
            frmCuentasPorCobrar_NC_Agregar.me = this;
            InitializeComponent();
        }

        public int id_cliente_captado = 0;
        public string cliente_captado = "";
        public string nc_actual = "";

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnGuardar); 
            frmCuentasPorCobrar_NC_Selec frm = new frmCuentasPorCobrar_NC_Selec();
            frm.ShowDialog();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            this.tEnfoque.Enabled = false;

            //if (this.btnProv.Visible == false)
                this.mtxtNC.Focus();
            //else
            //{
            //    if (this.mtxtFactura.MaskFull)
            //        this.txtObser.Focus();
            //    else
            //        this.mtxtRUC.Focus();
            //}
        }

        private void mtxtNC_TextChanged(object sender, EventArgs e)
        {
            if (this.mtxtNC.MaskFull)
            {
                this.btnCliente.Enabled = true;
                
                if (this.btnCliente.Visible)
                {
                    if (this.Text == "AGREGAR")
                    {
                        //if (this.mtxtFactura.MaskFull == false)
                        //{
                            frmCuentasPorCobrar_NC_Selec frm = new frmCuentasPorCobrar_NC_Selec();
                            frm.ShowDialog();
                        //}
                    }
                }
                else
                    this.dtpFechaDoc.Focus();
            }
            else
                this.btnCliente.Enabled = false;
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
                //else if (this.mtxtFactura.MaskFull == false)
                //{
                    //this.ttMensaje.ToolTipTitle = "ERROR";
                    //this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    //this.ttMensaje.Show("Haga click en 'Clientes' para seleccionar\nla venta afectada", this.btnGuardar, 0, 38, 5000);
                    //return;
                //}
                
                if (this.Text == "AGREGAR")
                {
                    if (NNotasCreditosCXC.validar_nc(this.mtxtNC.Text) <= 0)
                    {
                        NNotasCreditosCXC.guardar_nc(this.mtxtNC.Text, int.Parse(this.mtxtFactura.Text), id_cliente_captado, cliente_captado, this.dtpFechaDoc.Value, "", this.mtxtRUC.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtObser.Text,"Normal",0);

                        frmCuentasPorCobrar_NC.me.abrir_frm = true;
                        frmCuentasPorCobrar_NC.me.txtRegistros.Text = NNotasCreditosCXC.num_reg().ToString("N0");
                        frmCuentasPorCobrar_NC.me.txtBuscar.Enabled = true;
                        frmCuentasPorCobrar_NC.me.txtBuscar.Text = this.mtxtNC.Text;

                        frmCuentasPorCobrar_NC.me.tBuscar.Enabled = false;
                        frmCuentasPorCobrar_NC.me.tBuscar.Enabled = true;

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
                        if (NNotasCreditosCXC.validar_nc(this.mtxtNC.Text) <= 0)
                        {
                            NNotasCreditosCXC.actualizar_nc(nc_actual,this.mtxtNC.Text, this.mtxtFactura.Text, id_cliente_captado, cliente_captado, this.dtpFechaDoc.Value, "", this.mtxtRUC.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtObser.Text);

                            frmCuentasPorCobrar_NC.me.abrir_frm = true;
                            frmCuentasPorCobrar_NC.me.txtRegistros.Text = NNotasCreditosCXC.num_reg().ToString("N0");
                            frmCuentasPorCobrar_NC.me.txtBuscar.Enabled = true;
                            frmCuentasPorCobrar_NC.me.txtBuscar.Text = this.mtxtNC.Text;
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
                        NNotasCreditosCXC.actualizar_nc(nc_actual,this.mtxtNC.Text, this.mtxtFactura.Text, id_cliente_captado, cliente_captado, this.dtpFechaDoc.Value, "", this.mtxtRUC.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtObser.Text);

                        frmCuentasPorCobrar_NC.me.abrir_frm = true;
                        frmCuentasPorCobrar_NC.me.txtRegistros.Text = NNotasCreditosCXC.num_reg().ToString("N0");
                        frmCuentasPorCobrar_NC.me.txtBuscar.Enabled = true;
                        frmCuentasPorCobrar_NC.me.txtBuscar.Text = this.mtxtNC.Text;
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCuentasPorCobrar_NC_Agregar_Load(object sender, EventArgs e)
        {
            this.txtCliente.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtObser.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
  
            if (this.automatica)
            {
                this.mtxtFactura.Text = this.num_venta;

                DataTable dt_datos = NClientes.obtener_datos(frmCuentasPorCobrar.me.id_cliente_captado);
                try
                {
                    if (dt_datos.Rows.Count>0 )
                    {
                        this.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                        this.txtCliente.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                        ///this.txtMatriz.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                        this.txtDireccion.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                        this.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();

                        id_cliente_captado = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString());
                        cliente_captado = this.txtCliente.Text;

                        this.btnCliente.Visible = false;
                    }
                    else
                    {
                        DataTable dt_datos_ven = NClientes.obtener_id_venta(this.mtxtFactura.Text);
                        DataTable dt_datos_cliente = NClientes.obtener_datos(int.Parse(dt_datos_ven.Rows[0]["Id_Cliente"].ToString()));

                        if (dt_datos_cliente.Rows.Count > 0)
                        {
                            this.mtxtRUC.Text = dt_datos_cliente.Rows[0].ItemArray[2].ToString();
                            this.txtCliente.Text = dt_datos_cliente.Rows[0].ItemArray[3].ToString();
                            ///this.txtMatriz.Text = dt_datos_prov.Rows[0].ItemArray[2].ToString();
                            this.txtDireccion.Text = dt_datos_cliente.Rows[0].ItemArray[5].ToString();
                            this.mtxtTelefono.Text = dt_datos_cliente.Rows[0].ItemArray[4].ToString();
                            id_cliente_captado = Convert.ToInt32(dt_datos_cliente.Rows[0].ItemArray[0].ToString());
                            cliente_captado = this.txtCliente.Text;

                            this.btnCliente.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("No se encontro el dato del proveedor.", "Datos de proveedor no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                catch (Exception) { this.btnCliente.Visible = true; this.btnCliente.Enabled = true; }
             
            }

            this.mtxtNC.Mask = cGeneral.formato_NC;
            ///this.mtxtFactura.Mask = cGeneral.formato_factura;
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
