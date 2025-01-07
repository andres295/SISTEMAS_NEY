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

namespace SCM.Ventas
{
    public partial class frmVentas_NombreTemp : Form
    {
        public bool pago_venta = false;
        public bool cambio_cliente = false;
        public int name_ventana = 0;
        public bool accion;
        public bool fracciones = false;
        public int captar_id_cliente = 0;
        public frmVentas_NombreTemp()
        {
            InitializeComponent();
        }

        //private void nudCantidad1_Enter(object sender, EventArgs e)
        //{
        //    cGeneral.nud_entra_ent_focus(this.nudCantidad1);
        //}

        //private void nudCantidad1_Leave(object sender, EventArgs e)
        //{
        //    cGeneral.nud_pierde_ent_focus(this.nudCantidad1);
        //}

        //private void nudCantidad2_Enter(object sender, EventArgs e)
        //{
        //    cGeneral.nud_entra_ent_focus(this.nudCantidad2);
        //}

        //private void nudCantidad2_Leave(object sender, EventArgs e)
        //{
        //    cGeneral.nud_pierde_ent_focus(this.nudCantidad2);
        //}

        //private void nudFracciones_Enter(object sender, EventArgs e)
        //{
        //    cGeneral.nud_entra_ent_focus(this.nudFracciones);
        //}

        //private void nudFracciones_Leave(object sender, EventArgs e)
        //{
        //    cGeneral.nud_pierde_ent_focus(this.nudFracciones);
        //}

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
                if (txtNombre.Text.Length <= 0)
                { 
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Tiene que definir el nombre del cliente", this.txtNombre, 0, 38, 3000);
                    return;
                }

                if (name_ventana == 1)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas);

                    if (frm != null)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);
                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NVentas.actualizar_cliente(int.Parse(frmVentas.me.txtNumVenta.Text), captar_id_cliente,txtNombre.Text);

                            frmVentas.me.txtNumVenta.Text = "0";
                            frmVentas.me.captar_id_cliente = 0;
                            frmVentas.me.click_cancelar();
                        }

                    }
                }
                else if (name_ventana == 2)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_2);

                    if (frm != null)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);
                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NVentas.actualizar_cliente(int.Parse(frmVentas_2.me.txtNumVenta.Text), captar_id_cliente, txtNombre.Text);

                            frmVentas_2.me.txtNumVenta.Text = "0";
                            frmVentas_2.me.captar_id_cliente = 0;
                            frmVentas_2.me.click_cancelar();
                        }

                    } 
                }
                else if (name_ventana == 3)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_3);

                    if (frm != null)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);
                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NVentas.actualizar_cliente(int.Parse(frmVentas_3.me.txtNumVenta.Text), captar_id_cliente, txtNombre.Text);

                            frmVentas_3.me.txtNumVenta.Text = "0";
                            frmVentas_3.me.captar_id_cliente = 0;
                            frmVentas_3.me.click_cancelar();
                        }

                    }
                }
                /*Cotización*/
                else if (name_ventana == 4)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCotizaciones);

                    if (frm != null)
                    {
                        DataTable dtClinete = NClientes.Obtener_Cliente_by_cedula(cGeneral.cedula_cliente_comercial);
                        if (dtClinete.Rows.Count > 0)
                        {
                            this.captar_id_cliente = int.Parse(dtClinete.Rows[0]["Id"].ToString());
                            NCotizaciones.actualizar_cliente(int.Parse(frmCotizaciones.me.txtNumVenta.Text), captar_id_cliente, txtNombre.Text);

                            frmCotizaciones.me.txtNumVenta.Text = "0";
                            frmCotizaciones.me.dgvFacturas.DataSource = NCotizaciones.buscar(cGeneral.id_user_actual, "");
                            frmCotizaciones.me.dgvProductos.DataSource = NCotizaciones.cargar_prod(0);
                            frmCotizaciones.me.txtBuscar.Text = "";
                            frmCotizaciones.me.txtBuscar.Focus();
                            frmCotizaciones.me.tEnfoque.Enabled = true;
                            frmCotizaciones.me.btnAgregar.Enabled = true;
                            frmCotizaciones.me.btnModificar.Enabled = false;
                            frmCotizaciones.me.btnEliminar.Enabled = false;
                            frmCotizaciones.me.btnAgregarProd.Enabled = false;
                            //frmCotizaciones.me.captar_id_cliente = 0;
                            //frmCotizaciones.me.click_cancelar();
                        }

                    }
                }
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }

        }

        private void frmVentas_Cantidad_Load(object sender, EventArgs e)
        {
           
        }

        private void nudCantidad1_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void nudCantidad2_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void nudFracciones_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void frmVentas_Cantidad_FormClosing(object sender, FormClosingEventArgs e)
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
            else if (name_ventana == 4)
            {
                frmCotizaciones.me.tEnfoque.Enabled = true;
            }
        }

        private void pCantidades_Paint(object sender, PaintEventArgs e)
        {

        }



        private void nudFracciones_KeyPress(object sender, KeyPressEventArgs e)
        {


        }
        private bool is_numero(string valor)
        {
            try
            {
                if (valor != "")
                {
                    Convert.ToInt32(valor);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void nudFracciones_TextChanged(object sender, EventArgs e)
        {
            //if (!is_numero(nudFracciones.Text))
            //{
            //    nudFracciones.Text = "";

            //    this.ttMensaje.ToolTipTitle = "ERROR";
            //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
            //    this.ttMensaje.Show("No es un valor númerico", this.nudFracciones, 0, 38, 3000);
            //}
        }

        private void nudCantidad2_TextChanged(object sender, EventArgs e)
        {
            //if (!is_numero(nudCantidad2.Text))
            //{
            //    nudCantidad2.Text = "";

            //    this.ttMensaje.ToolTipTitle = "ERROR";
            //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
            //    this.ttMensaje.Show("No es un valor númerico", this.nudCantidad2, 0, 38, 3000);
            //}
        }

        private void nudCantidad1_TextChanged(object sender, EventArgs e)
        {
            //if (!is_numero(txtNombre.Text))
            //{
            //    txtNombre.Text = "";

            //    this.ttMensaje.ToolTipTitle = "ERROR";
            //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
            //    this.ttMensaje.Show("No es un valor númerico", this.txtNombre, 0, 38, 3000);
            //}
        }

        private void nudCantidad1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }


        private void btnGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }
    }
}
