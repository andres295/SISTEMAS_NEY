using CapaNegocios;
using System; 
using System.Data; 
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.CxC
{
    public partial class frmCuentasPorCobrar_Buscar : Form
    {
        public frmCuentasPorCobrar_Buscar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCuentasPorCobrar_Buscar_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtCliente =  NClientes.lista_combo(); 
                var row = dtCliente.NewRow();
                row["Id"] = "0";
                row["Cliente"] = "Todos";
                dtCliente.Rows.InsertAt(row,0);

                this.cmbCliente.DataSource = dtCliente;
                this.cmbCliente.ValueMember = "Id";
                this.cmbCliente.DisplayMember = "Cliente";

                DataTable dtCiudad = NClientes.lista_combo_ciudad();
                var rowCiudad = dtCiudad.NewRow();
                rowCiudad["Ciudad"] = "0";
                rowCiudad["Ciudad"] = "Todos";
                dtCiudad.Rows.InsertAt(rowCiudad, 0);

                this.cmbCiudad.DataSource = dtCiudad;
                this.cmbCiudad.ValueMember = "Ciudad";
                this.cmbCiudad.DisplayMember = "Ciudad";

                this.dtpDesde.Value = DateTime.Now.Date;
                this.dtpDesde.Value = this.dtpDesde.Value.AddDays(-30);
                this.dtpHasta.Value = DateTime.Now.Date;
                this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                this.cmbCiudad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                if (this.cmbCliente.Items.Count > 0)
                    this.cmbCliente.SelectedIndex = 0;
                if (this.cmbCiudad.Items.Count > 0)
                    this.cmbCiudad.SelectedIndex = 0;
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

                if (this.cmbCliente.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No hay proveedores en la lista", this.btnBuscar, 0, 38, 3000);
                    this.cmbCliente.Focus();
                    this.cmbCliente.DroppedDown = true;
                    return;
                }

                DataTable dt;

                if (rbtnPendientes.Checked == true)
                    dt = NCuentasPorCobrar.buscar(Convert.ToInt32(this.cmbCliente.Value), this.cmbCiudad.Text, Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value), "PENDIENTE");
                else
                    dt = NCuentasPorCobrar.buscar(Convert.ToInt32(this.cmbCliente.Value), this.cmbCiudad.Text, Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value), "PAGADO");

                if (dt.Rows.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No se encontró ningún registro", this.btnBuscar, 0, 38, 3000);
                    this.dtpDesde.Focus();
                    return;
                }
                frmCuentasPorCobrar.me.uGridFactura.DisplayLayout.ResetBands();
                frmCuentasPorCobrar.me.uGridFactura.DataSource = dt;
                ///frmCuentasPorCobrar.me.sumar_factura();
                frmCuentasPorCobrar.me.facturas_sort(0);

                ////frmCuentasPorCobrar.me.lblProv.Text = this.cmbProveedor.Text + " (" + frmCuentasPorCobrar.me.uGridProducto.Rows.Count + "):";
                frmCuentasPorCobrar.me.id_cliente_captado = Convert.ToInt32(this.cmbCliente.Value);
                frmCuentasPorCobrar.me.desde_captado = this.dtpDesde.Value;
                frmCuentasPorCobrar.me.hasta_captado = this.dtpHasta.Value;
                frmCuentasPorCobrar.me.captar_pagado = (this.rbtnPagadas.Checked == true ? true : false);
                frmCuentasPorCobrar.me.sumar_factura();
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
