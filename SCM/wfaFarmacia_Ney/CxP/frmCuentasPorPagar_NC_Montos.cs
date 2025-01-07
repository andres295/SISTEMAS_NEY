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

namespace SCM.CxP
{
    public partial class frmCuentasPorPagar_NC_Montos : Form
    {
        public static frmCuentasPorPagar_NC_Montos me;
        public int idProveedor   = 0;
        public string nu_factura = "";
        public decimal saldo = 0;
        public int id_prov_captado = 0;
        public string prov_matrix = "";
        public string prov_dir = "";
        public string prov_tel = "";
        public string prov_ruc = "";
        public string prov_captado = "";
        public frmCuentasPorPagar_NC_Montos()
        {
            frmCuentasPorPagar_NC_Montos.me = this;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCuentasPorPagar_Sel_Fact_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Ingrese el monto de la NC " + "NumFactura: " + nu_factura;
                this.nudMonto.Select(0, 4);
                this.lblSaldo.Text = saldo.ToString("N2");

                DataTable dt_datos = NProveedores.obtener_datos(id_prov_captado);

                if (dt_datos.Rows.Count > 0)
                {
                    id_prov_captado = Convert.ToInt32(dt_datos.Rows[0].ItemArray[0].ToString());
                    prov_captado = dt_datos.Rows[0].ItemArray[1].ToString();
                    prov_matrix= dt_datos.Rows[0].ItemArray[2].ToString();
                    prov_dir = dt_datos.Rows[0].ItemArray[3].ToString();
                    prov_tel = dt_datos.Rows[0].ItemArray[4].ToString();
                    prov_ruc = dt_datos.Rows[0].ItemArray[5].ToString();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (nudMonto.Value > saldo)
            {
                this.ttMensaje.ToolTipTitle = "AVISO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No se puede crear una NC con monto mayor al SALDO de la factura.", this.nudMonto, 0, 38, 3000);
                this.nudMonto.Focus();
                return;
            }
            if (nudMonto.Value <= 0)
            {
                this.ttMensaje.ToolTipTitle = "AVISO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese el monto de la NC.", this.nudMonto, 0, 38, 3000);
                this.nudMonto.Focus();
                return;
            }
            if (txtObservacion.Text.Length <= 0)
            {
                this.ttMensaje.ToolTipTitle = "AVISO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la observación de la NC", this.txtObservacion, 0, 38, 3000);
                this.txtObservacion.Focus();
                return;
            } 
            NNotasCreditos.guardar_nc("999", nu_factura, id_prov_captado, prov_captado, System.DateTime.Now, prov_matrix, prov_ruc, prov_dir, prov_tel, this.txtObservacion.Text, "Monto",nudMonto.Value);
            MessageBox.Show("NC agregada con éxito.", "Agregar NC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            for (int fila = 0; fila < frmCuentasPorPagar.me.uGridFactura.Rows.Count; fila++)
            {
                if (nu_factura == frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[1].Value.ToString())
                {
                    DataTable dt_datos = NCuentasPorPagar.actualizar_fila_fact(nu_factura);

                    frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[10].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString());
                    frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[14].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString());
                    frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[15].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
                    frmCuentasPorPagar.me.uGridFactura.Rows[fila].Cells[16].Value = dt_datos.Rows[0].ItemArray[5].ToString();
                    break;
                }
            }
            this.Close();
        }
    }
}
