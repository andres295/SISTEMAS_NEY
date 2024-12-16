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

namespace wfaFarmacia_Ney.Ventas
{
    public partial class frmSolicitaPrecioEspecial : Form
    {
        public bool accion;
        public string id_combo;
        public int id_venta =0,id_det_venta=0, name_ventana=0;
        public string id_producto = "";
        public decimal cantidad = 0;

        public frmSolicitaPrecioEspecial()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        void click_guardar()
        {
            try
            {
                if (this.nudPrecioEspecial.Value <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el precio el precio especial.", this.btnGuardar, 0, 38, 3000);
                    this.nudPrecioEspecial.Focus();
                    this.nudPrecioEspecial.Select(0, this.nudPrecioEspecial.Text.Length);
                    return;
                }  
                if (accion)
                {
                    DialogResult resul = MessageBox.Show("¿Desea solicitar un precio especial para el producto: " + lblNameProducto.Text+ "?" , "Confirmar Solicitud de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    { 
                        return;
                    }
                    DataTable dtPro = NProductos.obtener_datos_pro(id_producto);
                    if (dtPro.Rows.Count>0)
                    {
                        string id_producto =  dtPro.Rows[0]["Id"].ToString();
                        if (NVentas.SolicitaPrecioEspecial(id_venta,id_det_venta, id_producto, nudPrecioEspecial.Value, cantidad, cGeneral.id_user_actual.ToString()) > 0)
                        {
                            MessageBox.Show("Se ha enviado una solicito de precio especial. El administrador aprobará este precio especial, favor notificar esta solicitud.", "Solicitud de precio especial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (name_ventana == 1)
                        {
                            frmVentas.me.txtBuscar.Enabled = true;
                            frmVentas.me.tCargarPrecioEspecial.Enabled = true;
                        }
                        else if (name_ventana == 2)
                        {
                            frmVentas_2.me.txtBuscar.Enabled = true;
                            frmVentas_2.me.tCargarPrecioEspecial.Enabled = true;
                        }
                        else if (name_ventana == 3)
                        {
                            frmVentas_3.me.txtBuscar.Enabled = true;
                            frmVentas_3.me.tCargarPrecioEspecial.Enabled = true;
                        }

                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("No se encontró ningun producto con el ID: " + id_producto, this.btnGuardar, 0, 38, 3000);
                        this.nudPrecioEspecial.Focus();
                        this.nudPrecioEspecial.Select(0, this.nudPrecioEspecial.Text.Length);
                        return;
                    }
 
                } 
                    
                //Ventas.frmDescuentoCombo.me.tBuscar.Enabled = false;
                ///Ventas.frmDescuentoCombo.me.tBuscar.Enabled = true;

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
         
        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (name_ventana == 1)
            {
                frmVentas.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 2)
            {
                frmVentas_2.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 3)
            {
                frmVentas_3.me.tEnfoque.Enabled = true;
            }
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpFechaDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtObserv_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        } 
        private void nudPrecioEspecial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                click_guardar();
            }
          
        }

        private void frmDescuentoCombo_Acciones_Load(object sender, EventArgs e)
        {
            ///lblID.Text = id_combo;
            ///this.txtDescripcion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        } 
    }
}
