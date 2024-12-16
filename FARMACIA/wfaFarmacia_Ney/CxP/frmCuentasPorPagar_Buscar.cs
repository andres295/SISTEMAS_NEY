using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.CxP
{
    public partial class frmCuentasPorPagar_Buscar : Form
    {
        public frmCuentasPorPagar_Buscar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCuentasPorPagar_Buscar_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtProveedor = NCuentasPorPagar.listar_prov();

                var row = dtProveedor.NewRow();
                row["Id_Proveedor"] = "0";
                row["Proveedor"] = "Todos";
                dtProveedor.Rows.InsertAt(row,0);

                this.cmbProveedor.DataSource = dtProveedor;
                this.cmbProveedor.ValueMember = "Id_Proveedor";
                this.cmbProveedor.DisplayMember = "Proveedor";

                this.dtpDesde.Value = DateTime.Now.Date;
                this.dtpDesde.Value = this.dtpDesde.Value.AddDays(-30);
                this.dtpHasta.Value = DateTime.Now.Date;
                this.cmbProveedor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                if (this.cmbProveedor.Items.Count > 0)
                    this.cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            click_buscar();
        }

        void click_buscar()
        {
            try
            {
                this.ttMensaje.Hide(this.btnBuscar);

                if (this.cmbProveedor.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay proveedores en la lista", this.btnBuscar, 0, 38, 3000);
                    this.cmbProveedor.Focus();
                    this.cmbProveedor.DroppedDown = true;
                    return;
                }

                DataTable dt;

                if (rbtnPendientes.Checked == true)
                    dt = NCuentasPorPagar.buscar(Convert.ToInt32(this.cmbProveedor.Value), Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value), "POR PAGAR");
                else
                    dt = NCuentasPorPagar.buscar(Convert.ToInt32(this.cmbProveedor.Value), Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value), "PAGADO");

                if (dt.Rows.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No se encontró ningún registro", this.btnBuscar, 0, 38, 3000);
                    this.dtpDesde.Focus();
                    return;
                }
                frmCuentasPorPagar.me.uGridFactura.DisplayLayout.ResetBands(); 
                frmCuentasPorPagar.me.uGridFactura.DataSource = dt;
                ///frmCuentasPorPagar.me.sumar_factura();
                frmCuentasPorPagar.me.facturas_sort(0);

                ////frmCuentasPorPagar.me.lblProv.Text = this.cmbProveedor.Text + " (" + frmCuentasPorPagar.me.uGridProducto.Rows.Count + "):";
                frmCuentasPorPagar.me.id_prov_captado = Convert.ToInt32(this.cmbProveedor.Value);
                frmCuentasPorPagar.me.desde_captado = this.dtpDesde.Value;
                frmCuentasPorPagar.me.hasta_captado = this.dtpHasta.Value;
                frmCuentasPorPagar.me.captar_pagado = (this.rbtnPagadas.Checked == true ? true : false);
                frmCuentasPorPagar.me.sumar_factura();
                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_buscar();
        }

        private void dtpHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_buscar();
        }

        private void cmbProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_buscar();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpDesde.Value > this.dtpHasta.Value)
                this.dtpDesde.Value = this.dtpHasta.Value;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpHasta.Value < this.dtpDesde.Value)
                this.dtpHasta.Value = this.dtpDesde.Value;
        }

        private void dtpDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }
    }
}
