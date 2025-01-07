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
    public partial class frmCargoCompra_Cantidad : Form
    {
        public int idItemProducto  = 0;
        public frmCargoCompra_Cantidad()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCargoCompra_Cantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmCargoCompra.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
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
                decimal porc_descuento = 0;

                if (this.nudCantidad.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La cantidad no puede estar vacío", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
                else if (this.dtpVencimiento.Value <= DateTime.Now.Date)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la fecha mayor a la fecha actual", this.dtpVencimiento, 0, 26, 3000);
                    this.dtpVencimiento.Focus();
                    return;
                }
                //else if (this.nudBonificacion.Text == "")
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("La bonificación no puede estar vacío", this.btnGuardar, 0, 38, 3000);
                //    this.nudCantidad.Focus();
                //    return;
                //}

                try
                {
                    porc_descuento  = ((Convert.ToDecimal(frmCargoCompra.me.dgvProductos.CurrentRow.Cells[9].Value) * 100) / (Convert.ToDecimal(frmCargoCompra.me.dgvProductos.CurrentRow.Cells[7].Value)));
                }
                catch (Exception)   { porc_descuento = 0;  }

                NCargoCompra.actualizar_cantidades(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(this.nudCantidad.Value), Convert.ToInt32(this.nudBonificacion.Value), porc_descuento,dtpVencimiento.Value,txtLote.Text,idItemProducto.ToString());

                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[5].Value = this.nudCantidad.Value;
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[6].Value = this.nudBonificacion.Value;

                DataTable dt_datos = NCargoCompra.obtener_totales_fila(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), idItemProducto.ToString());
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[7].Value = dt_datos.Rows[0].ItemArray[0].ToString();
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[8].Value = dt_datos.Rows[0].ItemArray[4].ToString().ToString();
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[9].Value = dt_datos.Rows[0].ItemArray[2].ToString().ToString();
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[10].Value = dt_datos.Rows[0].ItemArray[1].ToString().ToString();
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[11].Value = dt_datos.Rows[0].ItemArray[3].ToString().ToString();
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[12].Value = dtpVencimiento.Value.ToShortDateString();
                frmCargoCompra.me.dgvProductos.CurrentRow.Cells[13].Value = txtLote.Text.Trim();

                DataTable dt_totales = NCargoCompra.obtener_totales(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                if (dt_totales.Rows[0].ItemArray[0].ToString() == "")
                    frmCargoCompra.me.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblSubtotal.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[1].ToString() == "")
                    frmCargoCompra.me.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblIVA.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[2].ToString() == "")
                    frmCargoCompra.me.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblDescuento.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_totales.Rows[0].ItemArray[3].ToString() == "")
                    frmCargoCompra.me.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblTotalPagar.Text = Convert.ToDecimal(dt_totales.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales + "");

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void nudBonificacion_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void nudBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void frmCargoCompra_Cantidad_Load(object sender, EventArgs e)
        {

        }
    }
}
