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
    public partial class frmVentas_Acciones : Form
    {
        public static frmVentas_Acciones me;
        public bool pago_venta = false;
        public bool cambio_cliente = false;
        public int name_ventana = 0; 
        public frmVentas_Acciones()
        {
            frmVentas_Acciones.me = this;
            InitializeComponent();
        }

        private void frmVentas_Acciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvClientes);
                est.SetDoubleBuffered(this.dgvClientes);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvClientes.DataSource = NClientes.buscar("");
                this.orden(this.dgvClientes);

                cGeneral.ajuste_columnas(this.dgvClientes);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvClientes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvClientes.Columns[0].Frozen = true;
                this.dgvClientes.Columns[1].Frozen = true;
                this.dgvClientes.Columns[2].Frozen = true;

                this.dgvClientes.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[3], ListSortDirection.Ascending);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            } 
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.btnSeleccionar.Enabled = false;

                    this.dgvClientes.DataSource = NClientes.buscar(this.txtBuscar.Text);
                    this.orden(this.dgvClientes);
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }
            }
           
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
            
            if (e.KeyValue == 13)
                click_seleccionar();
            else if (e.KeyValue == 27)
                this.Close();
        }

        private void dgvClientes_Enter(object sender, EventArgs e)
        {
            //if (this.dgvClientes.Rows.Count == 0)
            //    this.txtBuscar.Focus();
        } 
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        } 
        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvClientes.DataSource = NClientes.buscar(this.txtBuscar.Text);
                this.orden(this.dgvClientes);

                if (this.dgvClientes.Rows.Count == 0)
                {
                    this.btnSeleccionar.Enabled = false;
                    ////this.txtBuscar.Focus();
                   //// this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnSeleccionar.Enabled = true;
                   //// this.dgvClientes.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            click_seleccionar();
        }

        void click_seleccionar()
        {
            try
            {
                if (name_ventana == 1)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas);

                    if (frm != null)
                    {
                        //VENTANA VENTAS.
                        frmVentas.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        frmVentas.me.cliente_seleccionado = true;
                        frmVentas.me.btnCancelar.Enabled = true;

                        if (cambio_cliente)
                        {
                            NVentas.actualizar_cliente(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.captar_id_cliente);
                        }
                        else
                        {
                            if (NVentas.verificar_siexiste_venta(int.Parse(frmVentas.me.txtNumVenta.Text)) == false)
                            {
                                frmVentas.me.txtNumVenta.Text = NVentas.obtener_num_venta().ToString();
                                NVentas.agregar_venta(int.Parse(frmVentas.me.txtNumVenta.Text), cGeneral.id_user_actual, frmVentas.me.captar_id_cliente, cGeneral.id_user_actual);
                            }
                            else
                                NVentas.actualizar_cliente(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.captar_id_cliente);
                        }

                        DataTable dt_datos = NClientes.obtener_datos(frmVentas.me.captar_id_cliente);
                        frmVentas.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS" + " - " + "Ventana #"+ name_ventana;
                        frmVentas.me.Text = frmVentas.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";
                        if (pago_venta)
                        {
                            //Ventas.frmVentas_Pagar_Efectivo frm2 = new Ventas.frmVentas_Pagar_Efectivo();
                            //frm2.cmbTipoVenta.Enabled = true;
                            //frm2.name_ventana = this.name_ventana;
                            //frm2.total_Pagar = frmVentas.me.lblTotalPagar.Text;
                            //frm2.num_venta = frmVentas.me.txtNumVenta.Text;
                            //frm2.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                            //frm2.ShowDialog();

                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = frmVentas.me.lblTotalPagar.Text;
                            frm2.num_venta = frmVentas.me.txtNumVenta.Text;
                            frm2.captar_id_cliente = frmVentas.me.captar_id_cliente;
                            frm2.name_ventana = 1;
                            frm2.ShowDialog();
                        }

                    }
                    else
                    {
                        //VENTANA RECUPERAR VENTAS.
                        frmRecuperar.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        frmRecuperar.me.cliente_seleccionado = true;
                        frmVentas.me.btnCancelar.Enabled = true;

                        NVentas.actualizar_cliente(frmRecuperar.me.captar_numventa, frmRecuperar.me.captar_id_cliente);

                        DataTable dt_datos = NClientes.obtener_datos(frmRecuperar.me.captar_id_cliente);
                        frmRecuperar.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS" + " - " + "Ventana #" + name_ventana;
                        frmRecuperar.me.Text = frmRecuperar.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";

                        if (pago_venta)
                        {
                            //Ventas.frmVentas_Pagar_Efectivo frm2 = new Ventas.frmVentas_Pagar_Efectivo();
                            //frm2.cmbTipoVenta.Enabled = true;
                            //frm2.name_ventana = this.name_ventana;
                            //frm2.total_Pagar = frmVentas.me.lblTotalPagar.Text;
                            //frm2.num_venta = frmVentas.me.txtNumVenta.Text;
                            //frm2.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                            //frm2.ShowDialog();

                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = frmRecuperar.me.lblTotalPagar.Text;
                            frm2.num_venta   = Convert.ToString(frmRecuperar.me.captar_numventa);
                            frm2.captar_id_cliente = frmRecuperar.me.captar_id_cliente;
                            frm2.name_ventana = 1;
                            frm2.ShowDialog();
                        }
                    }
                }
                else if (name_ventana == 2)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_2);

                    if (frm != null)
                    {
                        //VENTANA VENTAS.
                        frmVentas_2.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        frmVentas_2.me.cliente_seleccionado = true;
                        frmVentas_2.me.btnCancelar.Enabled = true;

                        if (cambio_cliente)
                        {
                            NVentas.actualizar_cliente(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.captar_id_cliente);
                        }
                        else
                        {
                            if (NVentas.verificar_siexiste_venta(int.Parse(frmVentas_2.me.txtNumVenta.Text)) == false)
                            {
                                frmVentas_2.me.txtNumVenta.Text = NVentas.obtener_num_venta().ToString();
                                NVentas.agregar_venta(int.Parse(frmVentas_2.me.txtNumVenta.Text), cGeneral.id_user_actual, frmVentas_2.me.captar_id_cliente, cGeneral.id_user_actual);
                            }
                            else
                                NVentas.actualizar_cliente(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.captar_id_cliente);
                        }

                        DataTable dt_datos = NClientes.obtener_datos(frmVentas_2.me.captar_id_cliente);
                        frmVentas_2.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS" + " - " + "Ventana #" + name_ventana;
                        frmVentas_2.me.Text = frmVentas_2.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";
                        if (pago_venta)
                        {
                            //Ventas.frmVentas_Pagar_Efectivo frm2 = new Ventas.frmVentas_Pagar_Efectivo();
                            //frm2.cmbTipoVenta.Enabled = true;
                            //frm2.name_ventana = this.name_ventana;
                            //frm2.total_Pagar = frmVentas_2.me.lblTotalPagar.Text;
                            //frm2.num_venta = frmVentas_2.me.txtNumVenta.Text;
                            //frm2.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                            //frm2.ShowDialog();

                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = frmVentas_2.me.lblTotalPagar.Text;
                            frm2.num_venta = frmVentas_2.me.txtNumVenta.Text;
                            frm2.captar_id_cliente = frmVentas_2.me.captar_id_cliente;
                            frm2.name_ventana = 2;
                            frm2.ShowDialog();
                        }

                    }
                    else
                    {
                        //VENTANA RECUPERAR VENTAS.
                        frmRecuperar.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        frmRecuperar.me.cliente_seleccionado = true;
                        frmVentas_2.me.btnCancelar.Enabled = true;

                        NVentas.actualizar_cliente(frmRecuperar.me.captar_numventa, frmRecuperar.me.captar_id_cliente);

                        DataTable dt_datos = NClientes.obtener_datos(frmRecuperar.me.captar_id_cliente);
                        frmRecuperar.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS" + " - " + "Ventana #" + name_ventana;
                        frmRecuperar.me.Text = frmRecuperar.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";

                        if (pago_venta)
                        {
                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = frmRecuperar.me.lblTotalPagar.Text;
                            frm2.num_venta = Convert.ToString(frmRecuperar.me.captar_numventa);
                            frm2.captar_id_cliente = frmRecuperar.me.captar_id_cliente;
                            frm2.name_ventana = 1;
                            frm2.ShowDialog();
                        }
                    }
                }
                else if (name_ventana == 3)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_3);

                    if (frm != null)
                    {
                        //VENTANA VENTAS.
                        frmVentas_3.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        frmVentas_3.me.cliente_seleccionado = true;
                        frmVentas_3.me.btnCancelar.Enabled = true;

                        if (cambio_cliente)
                        {
                            NVentas.actualizar_cliente(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.captar_id_cliente);
                        }
                        else
                        {
                            if (NVentas.verificar_siexiste_venta(int.Parse(frmVentas_3.me.txtNumVenta.Text)) == false)
                            {
                                frmVentas_3.me.txtNumVenta.Text = NVentas.obtener_num_venta().ToString();
                                NVentas.agregar_venta(int.Parse(frmVentas_3.me.txtNumVenta.Text), cGeneral.id_user_actual, frmVentas_3.me.captar_id_cliente, cGeneral.id_user_actual);
                            }
                            else
                                NVentas.actualizar_cliente(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.captar_id_cliente);
                        }

                        DataTable dt_datos = NClientes.obtener_datos(frmVentas_3.me.captar_id_cliente);
                        frmVentas_3.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS" + " - " + "Ventana #" + name_ventana;
                        frmVentas_3.me.Text = frmVentas_3.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";
                        if (pago_venta)
                        {
                            //Ventas.frmVentas_Pagar_Efectivo frm2 = new Ventas.frmVentas_Pagar_Efectivo();
                            //frm2.cmbTipoVenta.Enabled = true;
                            //frm2.name_ventana = this.name_ventana;
                            //frm2.total_Pagar = frmVentas_3.me.lblTotalPagar.Text;
                            //frm2.num_venta = frmVentas_3.me.txtNumVenta.Text;
                            //frm2.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                            //frm2.ShowDialog();

                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = frmVentas_3.me.lblTotalPagar.Text;
                            frm2.num_venta = frmVentas_3.me.txtNumVenta.Text;
                            frm2.captar_id_cliente = frmVentas_3.me.captar_id_cliente;
                            frm2.name_ventana = 3;
                            frm2.ShowDialog();
                        }

                    }
                    else
                    {
                        //VENTANA RECUPERAR VENTAS.
                        frmRecuperar.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        frmRecuperar.me.cliente_seleccionado = true;
                        frmVentas_3.me.btnCancelar.Enabled = true;

                        NVentas.actualizar_cliente(frmRecuperar.me.captar_numventa, frmRecuperar.me.captar_id_cliente);

                        DataTable dt_datos = NClientes.obtener_datos(frmRecuperar.me.captar_id_cliente);
                        frmRecuperar.me.Text = "REALIZAR UNA VENTA DE PRODUCTOS" + " - " + "Ventana #" + name_ventana;
                        frmRecuperar.me.Text = frmRecuperar.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";

                        if (pago_venta)
                        {
                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = frmRecuperar.me.lblTotalPagar.Text;
                            frm2.num_venta = Convert.ToString(frmRecuperar.me.captar_numventa);
                            frm2.captar_id_cliente = frmRecuperar.me.captar_id_cliente;
                            frm2.name_ventana = 1;
                            frm2.ShowDialog();
                        }
                    }
                }
                else if (name_ventana == 4)
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Facturacion.frmFacturaServicio_Acciones);

                    if (frm != null)
                    {
                        //VENTANA VENTAS.
                        Facturacion.frmFacturaServicio_Acciones.me.captar_id_cliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                        Facturacion.frmFacturaServicio_Acciones.me.cliente_seleccionado = true;
                        Facturacion.frmFacturaServicio_Acciones.me.btnCancelar.Enabled = true;

                        if (cambio_cliente)
                        {
                            NFactura.actualizar_cliente(int.Parse(Facturacion.frmFacturaServicio_Acciones.me.txtNumVenta.Text), Facturacion.frmFacturaServicio_Acciones.me.captar_id_cliente);
                        }
                        else
                        {
                            if (NFactura.verificar_siexiste_venta(int.Parse(Facturacion.frmFacturaServicio_Acciones.me.txtNumVenta.Text)) == false && int.Parse(Facturacion.frmFacturaServicio_Acciones.me.txtNumVenta.Text) <= 0 )
                            {
                                Facturacion.frmFacturaServicio_Acciones.me.txtNumVenta.Text = NVentas.obtener_num_venta().ToString(); 
                            } 
                        }

                        DataTable dt_datos = NClientes.obtener_datos(Facturacion.frmFacturaServicio_Acciones.me.captar_id_cliente);
                        Facturacion.frmFacturaServicio_Acciones.me.Text = "FACTURACIÓN DE SERVICIOS MÉDICOS";
                        Facturacion.frmFacturaServicio_Acciones.me.Text = Facturacion.frmFacturaServicio_Acciones.me.Text + " | *** CLIENTE: " + dt_datos.Rows[0].ItemArray[3].ToString() + " ***";
                        if (pago_venta)
                        { 
                            Ventas.frmVentas_MultiPago frm2 = new Ventas.frmVentas_MultiPago();
                            frm2.total_Pagar = Facturacion.frmFacturaServicio_Acciones.me.lblTotalPagar.Text;
                            frm2.num_venta = Facturacion.frmFacturaServicio_Acciones.me.txtNumVenta.Text;
                            frm2.captar_id_cliente = Facturacion.frmFacturaServicio_Acciones.me.captar_id_cliente;
                            frm2.name_ventana = 4;
                            frm2.ShowDialog();
                        }

                    } 
                }
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmVentas_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (name_ventana == 1)
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas);

                if (frm != null)
                    frmVentas.me.tEnfoque.Enabled = true;
                else
                    frmRecuperar.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 2)
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_2);

                if (frm != null)
                    frmVentas_2.me.tEnfoque.Enabled = true;
                else
                    frmRecuperar.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 3)
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_3);

                if (frm != null)
                    frmVentas_3.me.tEnfoque.Enabled = true;
                else
                    frmRecuperar.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 4)
            {
                try
                {
                    Facturacion.frmFacturaServicio_Acciones.me.tEnfoque.Enabled = true;
                }
                catch (Exception)  {  }
                
            }
            else  
            {
                try
                {
                    frmRecuperar.me.tEnfoque.Enabled = true;
                }
                catch (Exception) { }

            }

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmClientes_Acciones frm = new frmClientes_Acciones();
            frm.Text = "AGREGAR CLIENTE";
            frm.accion = false;
            frm.externalUse = true;
            
            frm.mtxtCedula.Mask = cGeneral.formato_cedula;
            frm.mtxtRUC.Mask = cGeneral.formato_cedula;
            frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

            frm.cmbTipoIdentificacion.DataSource = NTipoIdentificacion.obtener_datos();
            frm.cmbTipoIdentificacion.ValueMember = "Id";
            frm.cmbTipoIdentificacion.DisplayMember = "TipoIdentificacion";

            frm.ShowDialog();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            this.tEnfoque.Enabled = false;
            ////this.txtBuscar.Focus();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void dgvClientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.dgvClientes.Rows.Count > 0)
                this.btnSeleccionar.PerformClick();
        }
    }
}
