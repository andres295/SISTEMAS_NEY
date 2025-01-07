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

namespace SCM.CxC
{
    public partial class frmCuentasPorCobrar_NC_Cantidad : Form
    {
        public frmCuentasPorCobrar_NC_Cantidad()
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
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.nudCantidad.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La cantidad no puede estar vacío", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
                //else if (this.nudBonificacion.Enabled == true)
                //{
                //    if (this.nudBonificacion.Text == "")
                //    {
                //        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //        this.ttMensaje.Show("La bonificación no puede estar vacío", this.btnGuardar, 0, 38, 3000);
                //        this.nudCantidad.Focus();
                //        return;
                //    }
                //}

                DataTable dt = NCargoCompra.obtener_datos_prod(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                if (Convert.ToInt32(this.nudCantidad.Value) > Convert.ToInt32(dt.Rows[0].ItemArray[7].ToString()))
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("La cantidad tope es " + dt.Rows[0].ItemArray[7].ToString(), this.btnGuardar, 0, 38, 3000);
                    this.nudCantidad.Focus();
                    return;
                }
                //else if (Convert.ToInt32(this.nudBonificacion.Value) > Convert.ToInt32(dt.Rows[0].ItemArray[8].ToString()))
                //{
                //    this.ttMensaje.ToolTipTitle = "ERROR";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                //    this.ttMensaje.Show("La bonificación tope es " + dt.Rows[0].ItemArray[8].ToString(), this.btnGuardar, 0, 38, 3000);
                //    this.nudBonificacion.Focus();
                //    return;
                //}

                NNotasCreditosCXC.actualizar_cantidad(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(this.nudCantidad.Value), 0);

                DataTable dt_datos = NNotasCreditosCXC.obtener_datos_fila(frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvFacturas.CurrentRow.Cells[1].Value.ToString(), frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[2].Value = dt_datos.Rows[0].ItemArray[0].ToString();
                frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[3].Value = dt_datos.Rows[0].ItemArray[1].ToString();
                frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[5].Value = dt_datos.Rows[0].ItemArray[2].ToString();
                frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[6].Value = dt_datos.Rows[0].ItemArray[3].ToString();
                frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[7].Value = dt_datos.Rows[0].ItemArray[4].ToString();
                frmCuentasPorCobrar_NC.me.dgvProductos.CurrentRow.Cells[8].Value = dt_datos.Rows[0].ItemArray[5].ToString();

                frmCuentasPorCobrar_NC.me.cargar_totales();
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
    }
}
