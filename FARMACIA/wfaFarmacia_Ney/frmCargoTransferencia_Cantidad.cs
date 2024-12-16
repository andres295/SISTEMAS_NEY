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
    public partial class frmCargoTransferencia_Cantidad : Form
    {
        public int idItemProducto = 0;
        public frmCargoTransferencia_Cantidad()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmCargoTransferencia_Cantidad_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_datos = NCargoTransferencia.obtener_enteros_fracciones(Convert.ToInt32(frmCargoTransferencia.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                if (NProductos.obtener_cont(frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()) == 0)
                {
                    this.nudCantidad1.Value = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString());

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
                    this.nudCantidad2.Value = Convert.ToInt32(dt_datos.Rows[0].ItemArray[1].ToString());
                    this.nudFracciones.Value = Convert.ToInt32(dt_datos.Rows[0].ItemArray[2].ToString());

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.nudCantidad1.Text == "") this.nudCantidad1.Value = 0;
                if (this.nudCantidad2.Text == "") this.nudCantidad2.Value = 0;
                if (this.nudFracciones.Text == "") this.nudFracciones.Value = 0;

                int captar_cont = NProductos.obtener_cont(frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());

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

                NCargoTransferencia.modificar_cantidad(Convert.ToInt32(frmCargoTransferencia.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant,dtpVencimiento.Value,txtLote.Text, idItemProducto.ToString());

                if (this.nudCantidad1.Enabled == true)
                {
                    frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[3].Value = this.nudCantidad1.Value;
                    frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[5].Value = NCargoTransferencia.obtener_subtotal(Convert.ToInt32(frmCargoTransferencia.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[3].Value = this.nudCantidad2.Value + "F" + this.nudFracciones.Value;
                    frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[5].Value = NCargoTransferencia.obtener_subtotal(Convert.ToInt32(frmCargoTransferencia.me.dgvFacturas.CurrentRow.Cells[0].Value), frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                }
                frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[6].Value = dtpVencimiento.Value.ToShortDateString();
                frmCargoTransferencia.me.dgvProductos.CurrentRow.Cells[7].Value = txtLote.Text.Trim();
                frmCargoTransferencia.me.cargar_totales(frmCargoTransferencia.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudCantidad1_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void nudCantidad2_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void nudFracciones_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }
    }
}
