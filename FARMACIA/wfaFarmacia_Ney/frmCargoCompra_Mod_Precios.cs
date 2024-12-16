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
    public partial class frmCargoCompra_Mod_Precios : Form
    {
        public frmCargoCompra_Mod_Precios()
        {
            InitializeComponent();
        }

        private void frmCargoCompra_Mod_Precios_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_datos = NProductos.obtener_datos(frmCargoCompra_Productos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                this.nudPVF.Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
                this.nudPVP.Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[5].ToString());
                this.dtpVencimiento.Value = Convert.ToDateTime((dt_datos.Rows[0].ItemArray[6].ToString()));

                this.txtLote.Text = dt_datos.Rows[0].ItemArray[8].ToString();

                if (this.dtpVencimiento.Value == Convert.ToDateTime("01/01/1900"))
                    this.cbVenc.Checked = false;
                else
                    this.cbVenc.Checked = true;

                if (this.txtLote.Text == "")
                    this.cbLote.Checked = false;
                else
                    this.cbLote.Checked = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }

        }

        private void nudPVF_Enter(object sender, EventArgs e)
        {
            this.nudPVF.Select(0, this.nudPVF.Text.Length);
        }

        private void nudPVP_Enter(object sender, EventArgs e)
        {
            this.nudPVP.Select(0, this.nudPVP.Text.Length);
        }

        private void txtLote_Enter(object sender, EventArgs e)
        {
            this.txtLote.Select(0, this.txtLote.Text.Length);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        void guardar()
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.nudPVF.Text == "")
                    this.nudPVF.Text = this.nudPVF.Value.ToString();
                if (this.nudPVP.Text == "")
                    this.nudPVP.Text = this.nudPVP.Value.ToString();

                if (this.nudPVF.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el P/Compra", this.btnGuardar, 0, 25, 3000);
                    this.nudPVF.Focus();
                    return;
                }
                else if (this.nudPVP.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el PVP", this.btnGuardar, 0, 25, 3000);
                    this.nudPVP.Focus();
                    return;
                }

                NCargoCompra.actualizar_precios(frmCargoCompra_Productos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.nudPVF.Value, this.nudPVP.Value, this.dtpVencimiento.Value, this.txtLote.Text);
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbVenc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbVenc.Checked)
            {
                this.dtpVencimiento.Enabled = true;
                ////this.dtpVencimiento.Value = DateTime.Now.Date;
                this.dtpVencimiento.Focus();
            }
            else
            {
                this.dtpVencimiento.Enabled = false;
                ////this.dtpVencimiento.Value = Convert.ToDateTime("01/01/1900");
                this.nudPVF.Focus();
            }
        }

        private void cbLote_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbLote.Checked)
            {
                this.txtLote.Enabled = true;
                this.txtLote.Focus();
            }
            else
            {
                this.txtLote.Enabled = false;
                ////this.txtLote.Text = "";
                this.nudPVF.Focus();
            }
        }
    }
}
