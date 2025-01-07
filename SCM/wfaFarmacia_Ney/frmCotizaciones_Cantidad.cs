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
    public partial class frmCotizaciones_Cantidad : Form
    {
        public frmCotizaciones_Cantidad()
        {
            InitializeComponent();
        }

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

                int captar_cont = NProductos.obtener_cont(frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

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
                    else
                        if (Convert.ToInt32(this.nudFracciones.Value) > captar_cont)
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR ";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Este producto contiene " + captar_cont + " fraccciones.", this.nudFracciones, 0, 26, 3000);
                            this.nudFracciones.Focus();
                            return;
                        }
                }

                long captar_cant = 0;

                if (this.nudCantidad1.Enabled == true)
                    captar_cant = Convert.ToInt64(this.nudCantidad1.Value);
                else
                {
                    captar_cant = Convert.ToInt64(this.nudCantidad2.Value);
                    captar_cant = captar_cant * captar_cont;
                    captar_cant += Convert.ToInt64(this.nudFracciones.Value);
                }

                if (NProductos.obtener_disponible(frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) < captar_cant)
                {
                    frmCotizaciones.me.dgvProductos.CurrentRow.Cells[5].Value = NProductos.obtener_disponible_texto(frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay suficiente en stock", this.btnGuardar, 0, 38, 3000);

                    if (this.nudCantidad1.Enabled)
                        this.nudCantidad1.Focus();
                    else
                        this.nudCantidad2.Focus();

                    return;
                }

                NProductos.actualizar_desc(frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                decimal calc_ganan, calc_parc;
                calc_ganan = NCotizaciones.calcular_ganan(frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                calc_parc = NCotizaciones.calcular_parcial(frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                NCotizaciones.modificar_cantidad(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_ganan, calc_parc);

                if (this.nudCantidad1.Enabled == true)
                    frmCotizaciones.me.dgvProductos.CurrentRow.Cells[4].Value = this.nudCantidad1.Value;
                else
                    frmCotizaciones.me.dgvProductos.CurrentRow.Cells[4].Value = this.nudCantidad2.Value + "F" + this.nudFracciones.Value;

                DataTable dt_datos = NCotizaciones.obtener_montos_fila(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                frmCotizaciones.me.dgvProductos.CurrentRow.Cells[7].Value = dt_datos.Rows[0].ItemArray[0].ToString();
                frmCotizaciones.me.dgvProductos.CurrentRow.Cells[8].Value = dt_datos.Rows[0].ItemArray[1].ToString();
                frmCotizaciones.me.dgvProductos.CurrentRow.Cells[9].Value = dt_datos.Rows[0].ItemArray[2].ToString();
                frmCotizaciones.me.dgvProductos.CurrentRow.Cells[10].Value = dt_datos.Rows[0].ItemArray[3].ToString();

                frmCotizaciones.me.cargar_totales(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value));
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCotizaciones_Cantidad_Load(object sender, EventArgs e)
        {
            try
            {
                if (NCotizaciones.obtener_cont(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) == 0)
                {
                    this.nudCantidad1.Value = Convert.ToInt32(NCotizaciones.obtener_cant_enteros(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()));

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
                    DataTable dt_datos = NCotizaciones.obtener_cant_fracciones(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCotizaciones.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

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

        private void frmCotizaciones_Cantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCotizaciones.me.tEnfoque.Enabled = true;
        }
    }
}
