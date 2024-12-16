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

namespace wfaFarmacia_Ney
{
    public partial class frmVentas_Cantidad : Form
    {
        public frmVentas_Cantidad()
        {
            InitializeComponent();
        }

        public bool accion;
        public int name_ventana = 0;
        public bool fracciones = false;

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
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.accion == false)
                {
                    if ((this.nudCantidad2.Text == "" && this.nudFracciones.Text == "") || (this.nudCantidad2.Text == "0" && this.nudFracciones.Text == "0"))
                    {
                        this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad", this.nudFracciones, 0, 26, 3000);
                        nudFracciones.Focus();
                        return;
                    }
                }
                else
                {
                    int contiene = 0;
                    if (name_ventana == 1)
                    {
                        contiene = NProductos.obtener_contiene(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }
                    else if (name_ventana == 2)
                    {
                        contiene = NProductos.obtener_contiene(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }
                    else if (name_ventana == 3)
                    {
                        contiene = NProductos.obtener_contiene(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }

                    if (contiene > 0)
                    {
                        if ((this.nudCantidad2.Text == "" && this.nudFracciones.Text == "") || (this.nudCantidad2.Text == "0" && this.nudFracciones.Text == "0"))
                        {
                            this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ingrese la cantidad", this.nudFracciones, 0, 26, 3000);
                            nudFracciones.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (this.nudCantidad1.Text == "" || this.nudCantidad1.Text == "0")
                        {
                            this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad1, 0, 26, 3000);
                            this.nudCantidad1.Focus();
                            return;
                        }
                    }

                }


                if (this.nudCantidad1.Text == "") this.nudCantidad1.Text = "0";
                if (this.nudCantidad2.Text == "") this.nudCantidad2.Text = "0";
                if (this.nudFracciones.Text == "") this.nudFracciones.Text = "0";

                int captar_cont = 0;

                if (this.accion == false)
                {
                    if (name_ventana == 1)
                    {
                        captar_cont = NProductos.obtener_cont(frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    }
                    else if (name_ventana == 2)
                    {
                        captar_cont = NProductos.obtener_cont(frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    }
                    else if (name_ventana == 3)
                    {
                        captar_cont = NProductos.obtener_cont(frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    }
                }
                else
                {
                    if (name_ventana == 1)
                    {
                        captar_cont = NProductos.obtener_cont(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }
                    else if (name_ventana == 2)
                    {
                        captar_cont = NProductos.obtener_cont(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }
                    else if (name_ventana == 3)
                    {
                        captar_cont = NProductos.obtener_cont(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }
                }

                if (this.nudCantidad1.Enabled == true)
                {
                    if (this.nudCantidad1.Text == "0")
                    {
                        this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad1, 0, 26, 3000);
                        this.nudCantidad1.Focus();
                        return;
                    }
                }
                else
                {
                    if (this.nudCantidad2.Text == "0" && this.nudFracciones.Text == "0")
                    {
                        this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad", this.nudFracciones, 0, 26, 3000);
                        this.nudFracciones.Focus();
                        return;
                    }
                }

                long captar_cant = 0, captar_disp = 0;

                if (this.nudCantidad1.Enabled == true)
                    captar_cant = Convert.ToInt64(this.nudCantidad1.Text);
                else
                {
                    captar_cant = Convert.ToInt64(this.nudCantidad2.Text);
                    captar_cant = captar_cant * captar_cont;
                    captar_cant += Convert.ToInt64(this.nudFracciones.Text);
                }

                if (name_ventana == 1)
                {
                    if (frmVentas.me.dgvFacturas.Rows.Count == 0)
                        captar_disp = NProductos.obtener_disponible(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    else
                        captar_disp = NProductos.obtener_disponible(frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                }
                else if (name_ventana == 2)
                {
                    if (frmVentas_2.me.dgvFacturas.Rows.Count == 0)
                        captar_disp = NProductos.obtener_disponible(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    else
                        captar_disp = NProductos.obtener_disponible(frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                }
                else if (name_ventana == 3)
                {
                    if (frmVentas_3.me.dgvFacturas.Rows.Count == 0)
                        captar_disp = NProductos.obtener_disponible(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    else
                        captar_disp = NProductos.obtener_disponible(frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                }

                if (captar_cant > captar_disp)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay suficiente en stock", this.btnGuardar, 0, 38, 3000);

                    if (this.nudCantidad1.Enabled)
                        this.nudCantidad1.Focus();
                    else
                        this.nudCantidad2.Focus();

                    return;
                }
                if (name_ventana == 1)
                {
                    if (this.accion == false)
                        NProductos.actualizar_desc(frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    else
                        NProductos.actualizar_desc(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    decimal calc_ganan, calc_parc;

                    if (this.accion == false)
                    {
                        calc_ganan = NCotizaciones.calcular_ganan(frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                        calc_parc = NCotizaciones.calcular_parcial(frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    }
                    else
                    {
                        calc_ganan = NCotizaciones.calcular_ganan(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                        calc_parc = NCotizaciones.calcular_parcial(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }

                    if (this.accion == false)
                    {
                        //NUEVA VENTA.
                        NVentas.guardar_prod_temp(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_parc, calc_ganan);

                        frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(frmVentas.me.txtNumVenta.Text));
                        ////frmVentas.me.orden_prod(frmVentas.me.dgvProductos);
                        frmVentas.me.cargar_totales(int.Parse(frmVentas.me.txtNumVenta.Text));

                        frmVentas.me.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                        frmVentas.me.dgvFacturas.Refresh();

                        frmVentas.me.btnModificarProd.Enabled = true;
                        frmVentas.me.btnEliminarProd.Enabled = true;
                        frmVentas.me.btnGuardar.Enabled = true;
                        frmVentas.me.txtBuscar.Text = "";
                        this.Close();
                    }
                    else
                    {
                        //MODIFICAR CANTIDAD.
                        NVentas.modificar_cantidad(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_ganan, calc_parc);
                        DataTable dt_datos = NVentas.obtener_montos_fila(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                        frmVentas.me.dgvProductos.CurrentRow.Cells[2].Value = NVentas.obtener_vendio_texto(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                        frmVentas.me.dgvProductos.CurrentRow.Cells[5].Value = dt_datos.Rows[0].ItemArray[3].ToString();
                   
                        frmVentas.me.cargar_totales(int.Parse(frmVentas.me.txtNumVenta.Text));

                        frmVentas.me.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                        frmVentas.me.dgvFacturas.Refresh();

                        frmVentas.me.btnModificarProd.Enabled = true;
                        frmVentas.me.btnEliminarProd.Enabled = true;
                        frmVentas.me.btnGuardar.Enabled = true;
                        this.Close();
                    }
                }
                else if (name_ventana == 2)
                {
                    if (this.accion == false)
                        NProductos.actualizar_desc(frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    else
                        NProductos.actualizar_desc(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    decimal calc_ganan, calc_parc;

                    if (this.accion == false)
                    {
                        calc_ganan = NCotizaciones.calcular_ganan(frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                        calc_parc = NCotizaciones.calcular_parcial(frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    }
                    else
                    {
                        calc_ganan = NCotizaciones.calcular_ganan(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                        calc_parc = NCotizaciones.calcular_parcial(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }

                    if (this.accion == false)
                    {
                        //NUEVA VENTA.
                        NVentas.guardar_prod_temp(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_parc, calc_ganan);

                        frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(frmVentas_2.me.txtNumVenta.Text));
                        ////frmVentas.me.orden_prod(frmVentas.me.dgvProductos);
                        frmVentas_2.me.cargar_totales(int.Parse(frmVentas_2.me.txtNumVenta.Text));

                        frmVentas_2.me.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                        frmVentas_2.me.dgvFacturas.Refresh();

                        frmVentas_2.me.btnModificarProd.Enabled = true;
                        frmVentas_2.me.btnEliminarProd.Enabled = true;
                        frmVentas_2.me.btnGuardar.Enabled = true;
                        frmVentas_2.me.txtBuscar.Text = "";
                        this.Close();
                    }
                    else
                    {
                        //MODIFICAR CANTIDAD.
                        NVentas.modificar_cantidad(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_ganan, calc_parc);
                        DataTable dt_datos = NVentas.obtener_montos_fila(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                        frmVentas_2.me.dgvProductos.CurrentRow.Cells[2].Value = NVentas.obtener_vendio_texto(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                        frmVentas_2.me.dgvProductos.CurrentRow.Cells[5].Value = dt_datos.Rows[0].ItemArray[3].ToString();
                    

                        frmVentas_2.me.cargar_totales(int.Parse(frmVentas_2.me.txtNumVenta.Text));

                        frmVentas_2.me.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                        frmVentas_2.me.dgvFacturas.Refresh();

                        frmVentas_2.me.btnModificarProd.Enabled = true;
                        frmVentas_2.me.btnEliminarProd.Enabled = true;
                        frmVentas_2.me.btnGuardar.Enabled = true;
                        this.Close();
                    }
                }
                else if (name_ventana == 3)
                {
                    if (this.accion == false)
                        NProductos.actualizar_desc(frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    else
                        NProductos.actualizar_desc(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    decimal calc_ganan, calc_parc;

                    if (this.accion == false)
                    {
                        calc_ganan = NCotizaciones.calcular_ganan(frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                        calc_parc = NCotizaciones.calcular_parcial(frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                    }
                    else
                    {
                        calc_ganan = NCotizaciones.calcular_ganan(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                        calc_parc = NCotizaciones.calcular_parcial(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    }

                    if (this.accion == false)
                    {
                        //NUEVA VENTA.
                        NVentas.guardar_prod_temp(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_parc, calc_ganan);

                        frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(frmVentas_3.me.txtNumVenta.Text));
                        ////frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);
                        frmVentas_3.me.cargar_totales(int.Parse(frmVentas_3.me.txtNumVenta.Text));

                        frmVentas_3.me.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                        frmVentas_3.me.dgvFacturas.Refresh();

                        frmVentas_3.me.btnModificarProd.Enabled = true;
                        frmVentas_3.me.btnEliminarProd.Enabled = true;
                        frmVentas_3.me.btnGuardar.Enabled = true;
                        frmVentas_3.me.txtBuscar.Text = "";
                        this.Close();
                    }
                    else
                    {
                        //MODIFICAR CANTIDAD.
                        NVentas.modificar_cantidad(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_ganan, calc_parc);
                        DataTable dt_datos = NVentas.obtener_montos_fila(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                        frmVentas_3.me.dgvProductos.CurrentRow.Cells[2].Value = NVentas.obtener_vendio_texto(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                        frmVentas_3.me.dgvProductos.CurrentRow.Cells[5].Value = dt_datos.Rows[0].ItemArray[3].ToString();
                        
                        frmVentas_3.me.cargar_totales(int.Parse(frmVentas_3.me.txtNumVenta.Text));

                        frmVentas_3.me.dgvFacturas.DataSource = NProductos.obtener_productos_venta("", cGeneral.stock_producto);
                        frmVentas_3.me.dgvFacturas.Refresh();

                        frmVentas_3.me.btnModificarProd.Enabled = true;
                        frmVentas_3.me.btnEliminarProd.Enabled = true;
                        frmVentas_3.me.btnGuardar.Enabled = true;
                        this.Close();
                    }
                }

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmVentas_Cantidad_Load(object sender, EventArgs e)
        {
            try
            {
                if (name_ventana == 1)
                {
                    if (this.accion)
                    {
                        //MODIFICAR.
                        if (NProductos.obtener_cont(frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) == 0)
                        {
                            this.nudCantidad1.Text = NVentas.obtener_cant_enteros(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()).ToString();

                            this.lblCantidad1.Enabled = true;
                            this.nudCantidad1.Enabled = true;

                            this.lblCantidad2.Enabled = false;
                            this.nudCantidad2.Enabled = false;
                            this.nudFracciones.Enabled = false;
                            this.label7.Enabled = false;
                            nudFracciones.Select(0, 1);
                            /////this.nudCantidad1.Focus();
                        }
                        else
                        {
                            DataTable dt_datos = NVentas.obtener_cant_fracciones(int.Parse(frmVentas.me.txtNumVenta.Text), frmVentas.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                            this.nudCantidad2.Text = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString()).ToString();
                            this.nudFracciones.Text = Convert.ToInt32(dt_datos.Rows[0].ItemArray[1].ToString()).ToString();

                            this.lblCantidad2.Enabled = true;
                            lblCantidad2.Text = "";
                            this.label7.Enabled = true;
                            this.nudCantidad2.Enabled = true;
                            this.nudFracciones.Enabled = true;

                            nudCantidad2.Select(0, 1);

                            this.lblCantidad1.Enabled = false;
                            this.nudCantidad1.Enabled = false;
                            ////  this.nudFracciones.Focus();
                        }
                    }
                    else
                    {
                        //AGREGAR.
                        if (NProductos.obtener_cont(frmVentas.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 0)
                        {
                            this.lblCantidad1.Enabled = true;
                            this.nudCantidad1.Enabled = true;

                            this.lblCantidad2.Enabled = false;
                            this.nudCantidad2.Enabled = false;
                            this.nudFracciones.Enabled = false;
                            this.label7.Enabled = false;
                            /////  this.nudCantidad1.Focus();
                        }
                        else
                        {
                            this.lblCantidad2.Enabled = true;
                            this.label7.Enabled = true;
                            this.nudCantidad2.Enabled = true;
                            this.nudFracciones.Enabled = true;

                            this.lblCantidad1.Enabled = false;
                            this.nudCantidad1.Enabled = false;
                            //// this.nudFracciones.Focus();
                        }
                    }
                }
                else if (name_ventana == 2)
                {
                    if (this.accion)
                    {
                        //MODIFICAR.
                        if (NProductos.obtener_cont(frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) == 0)
                        {
                            this.nudCantidad1.Text = NVentas.obtener_cant_enteros(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()).ToString();

                            this.lblCantidad1.Enabled = true;
                            this.nudCantidad1.Enabled = true;

                            this.lblCantidad2.Enabled = false;
                            this.nudCantidad2.Enabled = false;
                            this.nudFracciones.Enabled = false;
                            this.label7.Enabled = false;
                            nudFracciones.Select(0, 1);
                            /////this.nudCantidad1.Focus();
                        }
                        else
                        {
                            DataTable dt_datos = NVentas.obtener_cant_fracciones(int.Parse(frmVentas_2.me.txtNumVenta.Text), frmVentas_2.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                            this.nudCantidad2.Text = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString()).ToString();
                            this.nudFracciones.Text = Convert.ToInt32(dt_datos.Rows[0].ItemArray[1].ToString()).ToString();

                            this.lblCantidad2.Enabled = true;
                            lblCantidad2.Text = "";
                            this.label7.Enabled = true;
                            this.nudCantidad2.Enabled = true;
                            this.nudFracciones.Enabled = true;

                            nudCantidad2.Select(0, 1);

                            this.lblCantidad1.Enabled = false;
                            this.nudCantidad1.Enabled = false;
                            ////  this.nudFracciones.Focus();
                        }
                    }
                    else
                    {
                        //AGREGAR.
                        if (NProductos.obtener_cont(frmVentas_2.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 0)
                        {
                            this.lblCantidad1.Enabled = true;
                            this.nudCantidad1.Enabled = true;

                            this.lblCantidad2.Enabled = false;
                            this.nudCantidad2.Enabled = false;
                            this.nudFracciones.Enabled = false;
                            this.label7.Enabled = false;
                            /////  this.nudCantidad1.Focus();
                        }
                        else
                        {
                            this.lblCantidad2.Enabled = true;
                            this.label7.Enabled = true;
                            this.nudCantidad2.Enabled = true;
                            this.nudFracciones.Enabled = true;

                            this.lblCantidad1.Enabled = false;
                            this.nudCantidad1.Enabled = false;
                            //// this.nudFracciones.Focus();
                        }
                    }
                }
                else if (name_ventana == 3)
                {
                    if (this.accion)
                    {
                        //MODIFICAR.
                        if (NProductos.obtener_cont(frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) == 0)
                        {
                            this.nudCantidad1.Text = NVentas.obtener_cant_enteros(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()).ToString();

                            this.lblCantidad1.Enabled = true;
                            this.nudCantidad1.Enabled = true;

                            this.lblCantidad2.Enabled = false;
                            this.nudCantidad2.Enabled = false;
                            this.nudFracciones.Enabled = false;
                            this.label7.Enabled = false;
                            nudFracciones.Select(0, 1);
                            /////this.nudCantidad1.Focus();
                        }
                        else
                        {
                            DataTable dt_datos = NVentas.obtener_cant_fracciones(int.Parse(frmVentas_3.me.txtNumVenta.Text), frmVentas_3.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                            this.nudCantidad2.Text = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString()).ToString();
                            this.nudFracciones.Text = Convert.ToInt32(dt_datos.Rows[0].ItemArray[1].ToString()).ToString();

                            this.lblCantidad2.Enabled = true;
                            lblCantidad2.Text = "";
                            this.label7.Enabled = true;
                            this.nudCantidad2.Enabled = true;
                            this.nudFracciones.Enabled = true;

                            nudCantidad2.Select(0, 1);

                            this.lblCantidad1.Enabled = false;
                            this.nudCantidad1.Enabled = false;
                            ////  this.nudFracciones.Focus();
                        }
                    }
                    else
                    {
                        //AGREGAR.
                        if (NProductos.obtener_cont(frmVentas_3.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 0)
                        {
                            this.lblCantidad1.Enabled = true;
                            this.nudCantidad1.Enabled = true;

                            this.lblCantidad2.Enabled = false;
                            this.nudCantidad2.Enabled = false;
                            this.nudFracciones.Enabled = false;
                            this.label7.Enabled = false;
                            /////  this.nudCantidad1.Focus();
                        }
                        else
                        {
                            this.lblCantidad2.Enabled = true;
                            this.label7.Enabled = true;
                            this.nudCantidad2.Enabled = true;
                            this.nudFracciones.Enabled = true;

                            this.lblCantidad1.Enabled = false;
                            this.nudCantidad1.Enabled = false;
                            //// this.nudFracciones.Focus();
                        }
                    }
                }

                this.lblCantidad2.Visible = true;
                this.nudFracciones.Focus();
                this.nudFracciones.Select(0, 2);
            }
            catch (Exception ex) { cGeneral.error(ex); }
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
            if (!is_numero(nudFracciones.Text))
            {
                nudFracciones.Text = "";

                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("No es un valor númerico", this.nudFracciones, 0, 38, 3000);
            }
        }

        private void nudCantidad2_TextChanged(object sender, EventArgs e)
        {
            if (!is_numero(nudCantidad2.Text))
            {
                nudCantidad2.Text = "";

                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("No es un valor númerico", this.nudCantidad2, 0, 38, 3000);
            }
        }

        private void nudCantidad1_TextChanged(object sender, EventArgs e)
        {
            if (!is_numero(nudCantidad1.Text))
            {
                nudCantidad1.Text = "";

                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("No es un valor númerico", this.nudCantidad1, 0, 38, 3000);
            }
        }

        private void nudCantidad1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }

        private void nudCantidad2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }

        private void nudFracciones_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }
    }
}
