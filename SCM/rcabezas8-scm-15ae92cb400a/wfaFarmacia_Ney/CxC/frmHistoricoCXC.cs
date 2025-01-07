﻿using CapaNegocios;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.CxC
{
    public partial class frmHistoricoCXC : Form
    {
        public static frmHistoricoCXC me;

        public frmHistoricoCXC()
        {
            frmHistoricoCXC.me = this;
            InitializeComponent();
        }

        public int id_cliente_captado;
        public DateTime desde_captado, hasta_captado;
        public bool captar_pagado = false;

        public void actualizar_fila_fact(string fact)
        {
            DataTable dt_datos = NCuentasPorCobrar.actualizar_fila_fact(fact);

            frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[4].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString());
            frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[5].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString());
            frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[6].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[2].ToString());
            frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[7].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString());
            frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[8].Value = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[4].ToString());
            frmCuentasPorCobrar.me.uGridFactura.Selected.Rows[0].Cells[9].Value = dt_datos.Rows[0].ItemArray[5].ToString();
        }

        public void facturas_sort(int col)
        {
            ////this.uGridFactura.Sort(this.uGridFactura.com[col], ListSortDirection.Ascending);
        }

        public void productos_sort(int col)
        {
            ///  this.uGridFactura.Sort(this.uGridFactura.Columns[col], ListSortDirection.Ascending);
        }

        private void frmCuentasPorCobrar_Load(object sender, EventArgs e)
        {
            try
            {
                //cEstilo_Grid est = new cEstilo_Grid();
                ///// est.grid_selfull_con_alter(this.uGridFactura);
                ///// est.grid_selfree_con_alter(this.uGridFactura);
                //est.SetDoubleBuffered(this.uGridFactura);
                //est.SetDoubleBuffered(this.uGridFactura);

                //this.uGridFactura.DataSource = NCuentasPorCobrar.cargar_vacio_fact();
                //this.facturas_sort(0);
                //this.uGridProducto.DataSource = NCuentasPorCobrar.cargar_prod("");
                //this.productos_sort(1);

                //this.lblSubtotal12.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                //this.lblSubtotal0.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                //this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                //this.lblSubtotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                //this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                //this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                //this.lblMontoFact.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                /////this.uGridFactura.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
                /////this.uGridProducto.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
                /////cGeneral.ajuste_columnas(this.dgvFacturas);
                /////cGeneral.ajuste_columnas(this.dgvProductos);
                //sumar_factura();
                //sumar_producto();
                this.lblSubtotal12.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotal0.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotalSI.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                this.lblMontoFact.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales_ventas + "");
                ///this.uGridFactura.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
                try
                {
                    DataTable dtCliente = NClientes.lista_combo();
                    var row = dtCliente.NewRow();
                    row["Id"] = "0";
                    row["Cliente"] = "Todos";
                    dtCliente.Rows.InsertAt(row, 0);

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
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
            sumar_factura();
        }

        private void pbOpciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridFactura.Rows.Count > 0)
                {
                    try
                    {
                        Convert.ToDecimal(this.uGridFactura.Selected.Rows[0].Cells[5].Value);
                       
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Seleccione una venta", "Seleccionar venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    /*Activamos la opcion de nota de credito*/
                    if (Convert.ToDecimal(this.uGridFactura.Selected.Rows[0].Cells[7].Value) == 0)
                    {
                        this.nOTASDECRÉDITOToolStripMenuItem.Enabled = true; 
                    } 
                    else
                    {
                        this.nOTASDECRÉDITOToolStripMenuItem.Enabled = false; 
                    }
                    /*Activamos la opcion de retencion*/
                    if (Convert.ToDecimal(this.uGridFactura.Selected.Rows[0].Cells[12].Value) == 0)
                    { 
                        this.rETENCIONEStoolStripMenuItem.Enabled = true;
                    }
                    else
                    { 
                        this.rETENCIONEStoolStripMenuItem.Enabled = false;
                    }
                    if (this.uGridFactura.Selected.Rows[0].Cells[14].Value.ToString() == "PAGADO" || this.uGridFactura.Selected.Rows[0].Cells[14].Value.ToString() == "CANCELADO")
                    {
                        this.aBONARToolStripMenuItem.Enabled = false;
                        this.nOTASDECRÉDITOToolStripMenuItem.Enabled = false;
                        this.rETENCIONEStoolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        this.aBONARToolStripMenuItem.Enabled = true;
                        this.nOTASDECRÉDITOToolStripMenuItem.Enabled = true;
                        this.rETENCIONEStoolStripMenuItem.Enabled = true;
                    }
                }
                else
                    this.aBONARToolStripMenuItem.Enabled = false;

                this.ttMensaje.Hide(this.pbOpciones);
                this.contextMenuStrip1.Show(this.pbOpciones, new Point(-55, -100));
            }
            catch (Exception ex) { cGeneral.error(ex); }

            if (cGeneral.mnuPermisoRetenciones == false)
            {
                this.rETENCIONEStoolStripMenuItem.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            abrir_buscador();
        }

        void abrir_buscador()
        {
            try
            {
               CxC.frmCuentasPorCobrar_Buscar frm = new CxC.frmCuentasPorCobrar_Buscar();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbOpciones_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.pbOpciones);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("OPCIONES", this.pbOpciones, new Point(-15, -27));
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbOpciones_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbOpciones);
        }

        private void tInicio_Tick(object sender, EventArgs e)
        {
            this.tInicio.Enabled = false;
            ///abrir_buscador();
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvFacturas.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                //this.dgvFacturas.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvFacturas.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvFacturas.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvFacturas.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvFacturas.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                //this.dgvFacturas.Columns[0].Frozen = true;
                //this.dgvFacturas.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                //this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                //this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dgvProductos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                //this.dgvProductos.Rows[e.RowIndex].Cells[3].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                //this.dgvProductos.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Blue;
                //this.dgvProductos.Rows[e.RowIndex].Cells[4].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                //this.dgvProductos.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Green;

                //this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvProductos.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                //this.dgvProductos.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

                //this.dgvProductos.Columns[0].Frozen = true;
                //this.dgvProductos.Columns[1].Frozen = true;

                //this.dgvProductos.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void aBONARToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (uGridFactura.Rows.Count > 0)
            {
                id_cliente_captado = NCuentasPorCobrar.cargar_id_cliente(uGridFactura.Selected.Rows[0].Cells[1].Value.ToString());
                decimal saldo =  decimal.Parse( uGridFactura.Selected.Rows[0].Cells[15].Value.ToString());
                //frmCuentasPorPagar_Sel_Fact frm2 = new frmCuentasPorPagar_Sel_Fact();
                //frm2.idProveedor = id_cliente_captado;
                //frm2.ShowDialog(); 
                frmCxCMultiPago frm = new frmCxCMultiPago();
                frm.captar_id_cliente   = id_cliente_captado;
                frm.total_Pagar           = saldo.ToString("N2");
                frm.lblSaldoFactura.Text = saldo.ToString("N2");
                //frm.nudMontoFactura.Value  = decimal.Parse( saldo.ToString("N2"));
                frm.lblNumFactura.Text = uGridFactura.Selected.Rows[0].Cells[1].Value.ToString();
                frm.num_venta = uGridFactura.Selected.Rows[0].Cells[1].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No una venta selecciónada para realizar el pago", "Abonar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

          
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.uGridFactura.Rows.Count == 0 && this.uGridFactura.Rows.Count == 0)
                    this.btnBuscar.Focus();
                else
                    this.uGridFactura.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        } 
        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.uGridFactura.Rows.Count > 0)
                {
                    this.uGridProducto.DataSource = NCuentasPorCobrar.cargar_prod((this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString()));
                    this.productos_sort(1);

                    DataTable dt = NCuentasPorCobrar.obtener_totales(this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString());

                    this.lblSubtotal12.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubtotal0.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblDescuento.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubtotalSI.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales_ventas + ""); 
                    this.lblIVA.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[4].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblMontoFact.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[5].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    this.lblSubtotal.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[6].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    this.aBONARToolStripMenuItem.Enabled = true;
                    this.rEGISTRARNCToolStripMenuItem.Enabled = true;
                    this.eXPORTARToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void cargarProducto()
        {
            try
            {
                if (this.uGridFactura.Rows.Count > 0)
                {
                    this.uGridProducto.DataSource = NCuentasPorCobrar.cargar_prod((this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString()));
                    ////sumar_producto();
                    this.productos_sort(1);


                    DataTable dt = NCuentasPorCobrar.obtener_totales(this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString());

                    if (dt.Rows.Count > 0)
                    {
                        this.lblSubtotal12.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        this.lblSubtotal0.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        this.lblDescuento.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        this.lblSubtotalSI.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales_ventas + ""); 
                        this.lblIVA.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[4].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        this.lblMontoFact.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[5].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                        this.lblSubtotal.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[6].ToString()).ToString("N" + cGeneral.decimales_ventas + "");
                    }
                    this.aBONARToolStripMenuItem.Enabled = true;
                    this.rEGISTRARNCToolStripMenuItem.Enabled = true;
                    this.eXPORTARToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void nOTASDECRÉDITOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uGridFactura.Rows.Count > 0)
            {
                DialogResult resul = MessageBox.Show("Desea realizar una NC nórmal o sólo con monto.\n\nElija SI para una NC nórmal.\nElija NO para una NC sólo con monto.", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    frmCuentasPorCobrar_NC frm = new frmCuentasPorCobrar_NC(); 
                    frm.num_venta = this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString();
                    frm.automatica = true;
                    frm.ShowDialog();
                }
                else if (resul == System.Windows.Forms.DialogResult.No)
                {
                    frmCuentasPorCobrar_NC_Montos frm = new frmCuentasPorCobrar_NC_Montos();
                    frm.num_venta = this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString();
                    frm.saldo  = decimal.Parse(uGridFactura.Selected.Rows[0].Cells[15].Value.ToString());
                    frm.id_cliente_captado =  NCuentasPorCobrar.cargar_id_cliente(uGridFactura.Selected.Rows[0].Cells[1].Value.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No una venta selecciónada para realizar una Nota de Crédito", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportarCtaProveedor_Click(object sender, EventArgs e)
        {
            if (uGridFactura.Rows.Count > 0)
            {
                if (MessageBox.Show("Desea exportar los datos a excel?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    exportarGridExcel exc = new exportarGridExcel();
                    ////  exc.hojaexcel(uGridFactura);

                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar", "Exportar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportarCtaProveedorProducto_Click(object sender, EventArgs e)
        {
            if (uGridProducto.Rows.Count > 0)
            {
                if (MessageBox.Show("Desea exportar los datos a excel?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    exportarGridExcel exc = new exportarGridExcel();
                    ////exc.hojaexcel(dgvProductos);

                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar", "Exportar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void uGridFactura_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            { 
                e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

                e.Layout.Bands[0].Columns[7].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[7].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

                e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

                e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[13].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[13].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[13].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[14].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[14].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[14].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[15].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[15].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[15].Header.Appearance.TextHAlign = HAlign.Right;

                e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
                e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
                e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

                e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
                e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
                e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
                e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
                e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
                e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

                e.Layout.Override.AllowAddNew = AllowAddNew.No;
                e.Layout.Override.AllowDelete = DefaultableBoolean.False;
                e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            }
            catch (Exception)  {   }
        }

        private void btnExportarCtaProveedorProducto_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridProducto.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.uGridProducto, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }

            }
            catch (Exception)
            {
                //// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }

        }

        private void btnExportarCtaProveedor_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridFactura.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.uGridFactura, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }

        }

        public void sumar_factura()
        {
            try
            {
                UltraGridBand band = this.uGridFactura.DisplayLayout.Bands[0];
                ///' Add a Horas.
                ///
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[3]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[4]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[5]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[6]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[7]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[8]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[9]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[10]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[13]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[14]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";


                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[15]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

            }
            catch (Exception) { }
        }
        public void sumar_producto()
        {
            try
            {
                UltraGridBand band = this.uGridProducto.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[5]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[6]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[7]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[8]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[9]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

            }
            catch (Exception) { }
        }
        private void uGridProducto_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
                e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
                e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

                e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
                e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
                e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
                e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
                e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
                e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;


                e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
                e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
                e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[7].Format = "$###,###,##0.0000";
                e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[7].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
                e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
                e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;


                e.Layout.Override.AllowAddNew = AllowAddNew.No;
                e.Layout.Override.AllowDelete = DefaultableBoolean.False;
                e.Layout.Override.AllowUpdate = DefaultableBoolean.False;

            }
            catch (Exception)  {   }
           
        }

        private void uGridFactura_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string id_factura = uGridFactura.Selected.Rows[0].Cells[1].Value.ToString();
            }
            catch (Exception) { }

            cargarProducto();
        }

        private void uGridFactura_KeyDown(object sender, KeyEventArgs e)
        {
            cargarProducto();
        }

        private void uGridFactura_KeyUp(object sender, KeyEventArgs e)
        {
            cargarProducto();
        }

        private void uGridFactura_BeforeRowActivate(object sender, RowEventArgs e)
        {
            /// cargarProducto();
        }

        private void uGridFactura_AfterRowActivate(object sender, EventArgs e)
        {
            ////cargarProducto();
        }

        private void rETENCIONEStoolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (uGridFactura.Rows.Count > 0)
            {
                CxC.frmComprobanteRetencionCliente frm = new CxC.frmComprobanteRetencionCliente();
                string num_venta = this.uGridFactura.Selected.Rows[0].Cells[1].Value.ToString();
                string fechaEmisioNFactura = this.uGridFactura.Selected.Rows[0].Cells[2].Value.ToString();
                id_cliente_captado = NCuentasPorCobrar.cargar_id_cliente(num_venta);
                frm.lbldFactura.Text = num_venta;
                frm.cmbCliente.DataSource = NClientes.lista_combo();
                frm.cmbCliente.ValueMember = "Id";
                frm.cmbCliente.DisplayMember = "Cliente";
                frm.cmbCliente.Value = id_cliente_captado;
                frm.dtFechaEmisionDocumento.Value = DateTime.Parse(fechaEmisioNFactura);
                frm.cmbCliente.Enabled = false;
                frm.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Favor seleccionar una factura.", "Seleccionar factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCuentasPorCobrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tInicio.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //void click_buscar()
            //{
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
                this.uGridFactura.DisplayLayout.ResetBands();

                uGridFactura.DataSource = dt;
                    sumar_factura();
                    facturas_sort(0);

                    ////frmCuentasPorCobrar.me.lblProv.Text = this.cmbProveedor.Text + " (" + frmCuentasPorCobrar.me.uGridProducto.Rows.Count + "):";
                    id_cliente_captado = Convert.ToInt32(this.cmbCliente.Value);
                    desde_captado = this.dtpDesde.Value;
                    hasta_captado = this.dtpHasta.Value;
                    captar_pagado = (this.rbtnPagadas.Checked == true ? true : false);
                    //this.Close();
                }
                catch (Exception ex) { cGeneral.error(ex); }
            //}
        }

        private void lISTADEFACTURASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCuentasPorCobrar_Imprimir_Fact frm = new frmCuentasPorCobrar_Imprimir_Fact();
            cGeneral.frm_sin_borde(frm, false);
            frm.ShowDialog();
        }
    }
}
