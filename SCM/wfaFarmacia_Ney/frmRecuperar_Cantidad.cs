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
    public partial class frmRecuperar_Cantidad : Form
    {
        public frmRecuperar_Cantidad()
        {
            InitializeComponent();
        }

        public bool accion;

        private void nudCantidad1_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudCantidad1);
        }

        private void nudCantidad1_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudCantidad1);
        }

        private void nudCantidad2_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudCantidad2);
        }

        private void nudCantidad2_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudCantidad2);
        }

        private void nudFracciones_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudFracciones);
        }

        private void nudFracciones_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudFracciones);
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
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.nudCantidad1.Text == "") this.nudCantidad1.Value = 0;
                if (this.nudCantidad2.Text == "") this.nudCantidad2.Value = 0;
                if (this.nudFracciones.Text == "") this.nudFracciones.Value = 0;

                int captar_cont;

                if (this.accion == false)
                    captar_cont = NProductos.obtener_cont(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                else
                    captar_cont = NRecuperar.obtener_cont(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                if (this.nudCantidad1.Enabled == true)
                {
                    if (this.nudCantidad1.Value == 0)
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
                    if (this.nudCantidad2.Value == 0 && this.nudFracciones.Value == 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad2, 0, 26, 3000);
                        this.nudCantidad2.Focus();
                        return;
                    }
                }

                long captar_cant_new = 0, captar_disp = 0;

                if (this.nudCantidad1.Enabled == true)
                    captar_cant_new = Convert.ToInt64(this.nudCantidad1.Value);
                else
                {
                    captar_cant_new = Convert.ToInt64(this.nudCantidad2.Value);
                    captar_cant_new = captar_cant_new * captar_cont;
                    captar_cant_new += Convert.ToInt64(this.nudFracciones.Value);
                }

                if (frmRecuperar.me.dgvFacturas.Rows.Count == 0)
                    captar_disp = NProductos.obtener_disponible(frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                else
                    captar_disp = NProductos.obtener_disponible(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (captar_cant_new > captar_disp)
                {
                    frmRecuperar.me.dgvFacturas.CurrentRow.Cells[5].Value = NProductos.obtener_disponible_texto(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay suficiente en stock", this.btnGuardar, 0, 38, 3000);

                    if (this.nudCantidad1.Enabled)
                        this.nudCantidad1.Focus();
                    else
                        this.nudCantidad2.Focus();

                    return;
                }

                if (this.accion == false)
                    NProductos.actualizar_desc(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                else
                    NProductos.actualizar_desc(frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                decimal calc_ganan, calc_parc;

                if (this.accion == false)
                {
                    calc_ganan = NCotizaciones.calcular_ganan(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant_new);
                    calc_parc = NCotizaciones.calcular_parcial(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    calc_ganan = NCotizaciones.calcular_ganan(frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant_new);
                    calc_parc = NCotizaciones.calcular_parcial(frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                }

                if (this.accion == false)
                {
                    //AGREGAR.
                    NVentas.guardar_prod_temp(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), captar_cant_new, calc_parc, calc_ganan);

                    frmRecuperar.me.dgvProductos.DataSource = NVentas.cargar_prod(frmRecuperar.me.captar_numventa);
                    frmRecuperar.me.orden_prod(frmRecuperar.me.dgvProductos);
                    frmRecuperar.me.btnGuardar.Enabled = true;
                }
                else
                {
                    //MODIFICAR.
                    NRecuperar.modificar_cantidad(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant_new, calc_ganan, calc_parc);
                    DataTable dt_datos = NVentas.obtener_montos_fila(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    frmRecuperar.me.dgvProductos.CurrentRow.Cells[2].Value = NVentas.obtener_vendio_texto(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                    frmRecuperar.me.dgvProductos.CurrentRow.Cells[5].Value = dt_datos.Rows[0].ItemArray[3].ToString(); 
                }

                frmRecuperar.me.cargar_totales(frmRecuperar.me.captar_numventa);

                frmRecuperar.me.btnModificarProd.Enabled = true;
                frmRecuperar.me.btnEliminarProd.Enabled = true;
                frmRecuperar.me.btnGuardar.Enabled = true;
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmRecuperar_Cantidad_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.accion)
                {
                    //MODIFICAR.
                    this.Text = "MODIFICAR CANTIDAD";

                    if (NProductos.obtener_cont(frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) == 0)
                    {
                        this.nudCantidad1.Value = Convert.ToInt32(NVentas.obtener_cant_enteros(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()));

                        this.lblCantidad1.Enabled = true;
                        this.nudCantidad1.Enabled = true;

                        this.lblCantidad2.Enabled = false;
                        this.nudCantidad2.Enabled = false;
                        this.nudFracciones.Enabled = false;
                        this.label7.Enabled = false;
                        this.nudCantidad1.Focus();
                    }
                    else
                    {
                        DataTable dt_datos = NVentas.obtener_cant_fracciones(frmRecuperar.me.captar_numventa, frmRecuperar.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                        this.nudCantidad2.Value = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString());
                        this.nudFracciones.Value = Convert.ToInt32(dt_datos.Rows[0].ItemArray[1].ToString());

                        this.lblCantidad2.Enabled = true;
                        this.label7.Enabled = true;
                        this.nudCantidad2.Enabled = true;
                        this.nudFracciones.Enabled = true;

                        this.lblCantidad1.Enabled = false;
                        this.nudCantidad1.Enabled = false;
                        this.nudCantidad2.Focus();
                    }
                }
                else
                {
                    //AGREGAR.
                    this.Text = "AGREGAR CANTIDAD";

                    if (NProductos.obtener_cont(frmRecuperar.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString()) == 0)
                    {
                        this.lblCantidad1.Enabled = true;
                        this.nudCantidad1.Enabled = true;

                        this.lblCantidad2.Enabled = false;
                        this.nudCantidad2.Enabled = false;
                        this.nudFracciones.Enabled = false;
                        this.label7.Enabled = false;
                        this.nudCantidad1.Focus();
                    }
                    else
                    {
                        this.lblCantidad2.Enabled = true;
                        this.label7.Enabled = true;
                        this.nudCantidad2.Enabled = true;
                        this.nudFracciones.Enabled = true;

                        this.lblCantidad1.Enabled = false;
                        this.nudCantidad1.Enabled = false;
                        this.nudCantidad2.Focus();
                    }
                }
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

        private void frmRecuperar_Cantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRecuperar.me.tEnfoque.Enabled = true;
        }
    }
}
