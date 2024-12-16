using CapaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.Ventas
{
    public partial class frmVentas_MultiPago : Form
    {

        private bool clikChecked = false;
        public string total_Pagar = "";
        public string num_venta = "";
        public int name_ventana = 0;
        public bool cliente_cargado = false;
        public bool banco_cargado = false;
        public int captar_id_cliente = 0;
        public frmVentas_MultiPago()
        {
            InitializeComponent();
        }

        decimal diferencia;
        string ruta_img_cheque, ruta_img_tranf;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //private void cbEfectivo_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.cbEfectivo.Checked)
        //        {
        //            this.pEfectivo.Enabled = true;
        //            this.nudEfectivo.Focus();
        //        }
        //        else
        //        {
        //            this.nudEfectivo.Value = 0;
        //            this.nudEfectivo.Text = this.nudEfectivo.Value.ToString();
        //            this.pEfectivo.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        private void nudEfectivo_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudEfectivo);
        }

        private void tSumar_Tick(object sender, EventArgs e)
        {
            try
            {
                decimal efec;

                if (this.nudEfectivo.Text == "")
                    efec = 0;
                else
                    efec = Convert.ToDecimal(this.nudEfectivo.Text);

                decimal captar_sumatoria;
                captar_sumatoria = (efec);
                this.lblIngresado.Text = captar_sumatoria.ToString("N" + cGeneral.decimales_ventas + "");

                diferencia =  captar_sumatoria - Convert.ToDecimal(this.lblTotalPagar.Text);

                if (diferencia < 0)
                     //diferencia *= -1;
                     diferencia = 0;

                this.lblDiferencia.Text = diferencia.ToString("N" + cGeneral.decimales_ventas + "");
            }
            catch (Exception ex) { }
            calculaDiaCredito();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnPagar);
                int countProducto = 0;
                decimal totalMontoPago = 0;

                for (int i = 0; i < uDetallePago.Rows.Count ; i++)
                {
                    totalMontoPago +=  decimal.Parse( uDetallePago.Rows[i].Cells[2].Value.ToString());
                }

                if (totalMontoPago != decimal.Parse(lblTotalPagar.Text.ToString()))
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La suma del monto total de pago no es igual al monto total a pagar.", this.btnPagar, 0, 38, 3000);
                    this.cmbTipoVenta.Focus();
                    return;
                }

                if (!clikChecked)
                { 
                    clikChecked = true;
                    DataTable dtResult =  NVentas.pagar_multi_pago(cmbCliente.Value.ToString(),int.Parse(num_venta), Convert.ToDecimal(this.nudEfectivo.Value), "", System.DateTime.Now, 0, 0, ruta_img_cheque, "", 0, ruta_img_tranf, 0, 0, mtxtAdquiriente.Text, 0, cmbTipoVenta.Value.ToString());
                    if (dtResult.Rows.Count>0)
                    { 
                        if (bool.Parse(dtResult.Rows[0]["Exito"].ToString()))
                        {
                            if (name_ventana == 1)
                            {
                                frmVentas.me.txtBuscar.Text = "";

                                frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                                frmVentas.me.btnAgregarProd.Enabled = false;
                                frmVentas.me.btnModificarProd.Enabled = false;
                                frmVentas.me.btnEliminarProd.Enabled = false;
                                frmVentas.me.btnGuardar.Enabled = false;


                                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                try
                                {
                                    countProducto = frmVentas.me.dgvProductos.Rows.Count;
                                }
                                catch (Exception) { }


                                frmVentas.me.txtNumVenta.Text = "0";
                                frmVentas.me.captar_id_cliente = 0;
                                frmVentas.me.click_cancelar();
                                frmVentas.me.tEnfoque.Enabled = true;

                                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                }

                            }
                            else if (name_ventana == 2)
                            {
                                frmVentas_2.me.txtBuscar.Text = "";

                                frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                                frmVentas_2.me.btnAgregarProd.Enabled = false;
                                frmVentas_2.me.btnModificarProd.Enabled = false;
                                frmVentas_2.me.btnEliminarProd.Enabled = false;
                                frmVentas_2.me.btnGuardar.Enabled = false;


                                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                try
                                {
                                    countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                                }
                                catch (Exception) { }

                                frmVentas_2.me.txtNumVenta.Text = "0";
                                frmVentas_2.me.captar_id_cliente = 0;
                                frmVentas_2.me.click_cancelar();
                                frmVentas_2.me.tEnfoque.Enabled = true;

                                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                }


                            }
                            else if (name_ventana == 3)
                            {
                                frmVentas_3.me.txtBuscar.Text = "";

                                frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                                frmVentas_3.me.btnAgregarProd.Enabled = false;
                                frmVentas_3.me.btnModificarProd.Enabled = false;
                                frmVentas_3.me.btnEliminarProd.Enabled = false;
                                frmVentas_3.me.btnGuardar.Enabled = false;


                                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                try
                                {
                                    countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                                }
                                catch (Exception) { }

                                frmVentas_3.me.txtNumVenta.Text = "0";
                                frmVentas_3.me.captar_id_cliente = 0;
                                frmVentas_3.me.click_cancelar();
                                frmVentas_3.me.tEnfoque.Enabled = true;

                                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                }
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(dtResult.Rows[0]["Error"].ToString(), "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No fue posible procesar la venta, el resultado de la tabla de ventas es nulo", "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) { clikChecked = false; cGeneral.error(ex); }
        }
        public void print_venta(int count_row)
        {
            try
            {
                if (count_row > 0)
                {

                    if (cGeneral.numItem >= count_row)
                    {
                        ///DataTable dt = generarCtaProveedor();
                        ReportDocument myReportDocument;
                        myReportDocument = new ReportDocument();
                        if (cGeneral.alto_factura == "Formato 18,5 alto")
                        {
                            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaRecibo.rpt");

                        }
                        else if (cGeneral.alto_factura == "Formato 21,5 alto")

                        {
                            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaReciboFormato2.rpt");
                        }
                        else if (cGeneral.alto_factura == "Logic control Lr2000")

                        {
                            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptComprobanteSRI_BaucherConsumidorFInal.rpt");
                        }
                        else if (cGeneral.alto_factura == "Automático")

                        {
                            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaReciboFormatoAutomatico.rpt");
                        }
                        else
                        {
                            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaRecibo.rpt");

                        }

                        //Set DataBase Login Info
                        myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                        foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                        {
                            TableLogOnInfo logOnInfo = table.LogOnInfo;
                            if (logOnInfo != null)
                            {
                                logOnInfo.TableName = table.Name;
                                logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                                logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                                logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                                logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                                table.ApplyLogOnInfo(logOnInfo);
                            }
                        }

                        //Provide parameter values
                        myReportDocument.SetParameterValue("@id", num_venta);
                        myReportDocument.SetParameterValue("@desde", 1);
                        myReportDocument.SetParameterValue("@hasta", cGeneral.numItem);
                        myReportDocument.SetParameterValue("printpago", "SI");

                        PrinterSettings ps = new PrinterSettings();
                        ps.PrinterName = cGeneral.Impresora;
                        bool ImpresoraValida = ps.IsValid;
                        ps.Copies = 1;
                        PageSettings pg = new PageSettings();
                        pg.PrinterSettings = ps;

                        myReportDocument.PrintToPrinter(ps, pg, false);

                    }
                    else
                    {


                        int itemRecord = 0;
                        for (int i = 0; i < 20; i++)
                        {

                            itemRecord += cGeneral.numItem;

                            ///DataTable dt = generarCtaProveedor();
                            ReportDocument myReportDocument;
                            myReportDocument = new ReportDocument();
                            if (cGeneral.alto_factura == "Formato 18,5 alto")
                            {
                                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaRecibo.rpt");

                            }
                            else if (cGeneral.alto_factura == "Formato 21,5 alto")

                            {
                                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaReciboFormato2.rpt");
                            }
                            else if (cGeneral.alto_factura == "Logic control Lr2000")

                            {
                                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptComprobanteSRI_BaucherConsumidorFInal.rpt");
                            }
                            else if (cGeneral.alto_factura == "Automático")

                            {
                                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaReciboFormatoAutomatico.rpt");
                            }
                            else
                            {
                                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaRecibo.rpt");

                            }

                            //Set DataBase Login Info
                            myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                            foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                            {
                                TableLogOnInfo logOnInfo = table.LogOnInfo;
                                if (logOnInfo != null)
                                {
                                    logOnInfo.TableName = table.Name;
                                    logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                                    logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                                    logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                                    logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                                    table.ApplyLogOnInfo(logOnInfo);
                                }
                            }

                            //Provide parameter values
                            myReportDocument.SetParameterValue("@id", num_venta);
                            myReportDocument.SetParameterValue("@desde", itemRecord - cGeneral.numItem + 1);
                            myReportDocument.SetParameterValue("@hasta", itemRecord);
                            myReportDocument.SetParameterValue("printpago", "NO");

                            PrinterSettings ps = new PrinterSettings();
                            ps.PrinterName = cGeneral.Impresora;
                            bool ImpresoraValida = ps.IsValid;
                            ps.Copies = 1;
                            PageSettings pg = new PageSettings();
                            pg.PrinterSettings = ps;

                            myReportDocument.PrintToPrinter(ps, pg, false);

                            if (itemRecord >= count_row)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay productos en la ventana de ventas para imprimir.", "Imprimir el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error al imprimir el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cGeneral.error(ex);
            }
        }
        public void print_nota_venta(int count_row)
        {
            try
            {
                if (count_row > 0)
                {

                    if (cGeneral.numItem >= count_row)
                    {
                        ///DataTable dt = generarCtaProveedor();
                        ReportDocument myReportDocument;
                        myReportDocument = new ReportDocument();

                        myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptNotaVentaRecibo.rpt");


                        //Set DataBase Login Info
                        myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                        foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                        {
                            TableLogOnInfo logOnInfo = table.LogOnInfo;
                            if (logOnInfo != null)
                            {
                                logOnInfo.TableName = table.Name;
                                logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                                logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                                logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                                logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                                table.ApplyLogOnInfo(logOnInfo);
                            }
                        }

                        //Provide parameter values
                        myReportDocument.SetParameterValue("@id", num_venta);
                        myReportDocument.SetParameterValue("@desde", 1);
                        myReportDocument.SetParameterValue("@hasta", cGeneral.numItem);
                        myReportDocument.SetParameterValue("printpago", "SI");

                        PrinterSettings ps = new PrinterSettings();
                        ps.PrinterName = cGeneral.Impresora;
                        bool ImpresoraValida = ps.IsValid;
                        ps.Copies = 1;
                        PageSettings pg = new PageSettings();
                        pg.PrinterSettings = ps;

                        myReportDocument.PrintToPrinter(ps, pg, false);

                    }
                    else
                    {


                        int itemRecord = 0;
                        for (int i = 0; i < 20; i++)
                        {

                            itemRecord += cGeneral.numItem;

                            ///DataTable dt = generarCtaProveedor();
                            ReportDocument myReportDocument;
                            myReportDocument = new ReportDocument();

                            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptNotaVentaRecibo.rpt");


                            //Set DataBase Login Info
                            myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
                            foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
                            {
                                TableLogOnInfo logOnInfo = table.LogOnInfo;
                                if (logOnInfo != null)
                                {
                                    logOnInfo.TableName = table.Name;
                                    logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
                                    logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
                                    logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
                                    logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
                                    table.ApplyLogOnInfo(logOnInfo);
                                }
                            }

                            //Provide parameter values
                            myReportDocument.SetParameterValue("@id", num_venta);
                            myReportDocument.SetParameterValue("@desde", itemRecord - cGeneral.numItem + 1);
                            myReportDocument.SetParameterValue("@hasta", itemRecord);
                            myReportDocument.SetParameterValue("printpago", "NO");

                            PrinterSettings ps = new PrinterSettings();
                            ps.PrinterName = cGeneral.Impresora;
                            bool ImpresoraValida = ps.IsValid;
                            ps.Copies = 1;
                            PageSettings pg = new PageSettings();
                            pg.PrinterSettings = ps;

                            myReportDocument.PrintToPrinter(ps, pg, false);

                            if (itemRecord >= count_row)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay productos en la ventana de nota de venta para imprimir.", "Imprimir el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error al imprimir el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cGeneral.error(ex);
            }
        }
        private void nudEfectivo_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudEfectivo);
        }

        private void nudEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudMontoCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudMontoTransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }
        private void frmVentas_Pagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (name_ventana == 1)
            {
                frmVentas.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 2)
            {
                frmVentas_2.me.tEnfoque.Enabled = true;
            }
            else if (name_ventana == 3)
            {
                frmVentas_3.me.tEnfoque.Enabled = true;
            }
            //else if (name_ventana == 4)
            //{
            //    Ventas.frmNotaVentaCliente.me.tEnfoque.Enabled = true;
            //}

        }
        private void nudEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
            if (!clikChecked)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        this.ttMensaje.Hide(this.nudEfectivo);
                        int countProducto = 0;

                        if (this.nudEfectivo.Text == "")
                            this.nudEfectivo.Value = 0;
                        else
                            this.nudEfectivo.Value = Convert.ToDecimal(this.nudEfectivo.Text);

                        if (decimal.Parse(this.lblTotalPagar.Text) <= 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("No se puede guardar una venta con Total a Pagar menor o igual a cero.", this.nudEfectivo, 0, 38, 3000);
                            this.nudEfectivo.Focus();
                            return;
                        }
                        else if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Elija el tipo de pago", this.nudEfectivo, 0, 38, 3000);
                            this.cmbTipoVenta.Focus();
                            return;
                        }
                        else
                        {
                            if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                            {
                                if (Convert.ToDecimal(this.nudEfectivo.Value) == 0)
                                {
                                    this.ttMensaje.ToolTipTitle = "AVISO";
                                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                                    this.ttMensaje.Show("Especifique el monto en efectivo", this.nudEfectivo, 0, 38, 3000);
                                    this.nudEfectivo.Focus();
                                    return;
                                }
                            }
                        }

                        if (Convert.ToDecimal(this.lblIngresado.Text) < Convert.ToDecimal(this.lblTotalPagar.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "CORREGIR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("El monto ingresado es MENOR que el total a pagar", this.nudEfectivo, 0, 38, 6000);

                            if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                                this.nudEfectivo.Focus();

                            return;
                        }
                        if (!clikChecked)
                        {
                            clikChecked = true;
                            //if (name_ventana == 4)
                            //{
                            //    NNotaVentaCliente.pagar(int.Parse(num_venta), Convert.ToDecimal(this.nudEfectivo.Value), "", System.DateTime.Now, 0, 0, ruta_img_cheque, "", 0, ruta_img_tranf,0,0,mtxtAdquiriente.Text,0);
                            //}
                            //else
                            //{
                            DataTable dtResult =  NVentas.pagar(cmbCliente.Value.ToString(),int.Parse(num_venta), Convert.ToDecimal(this.nudEfectivo.Value), "", System.DateTime.Now, 0, 0, ruta_img_cheque, "", 0, ruta_img_tranf, 0, 0, mtxtAdquiriente.Text, 0, cmbTipoVenta.Value.ToString());
                            //} 
                            if (dtResult.Rows.Count > 0)
                            {
                                if (bool.Parse(dtResult.Rows[0]["Exito"].ToString()))
                                {
                                    if (name_ventana == 1)
                                    {
                                        frmVentas.me.txtBuscar.Text = "";

                                        frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                        frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                                        frmVentas.me.btnAgregarProd.Enabled = false;
                                        frmVentas.me.btnModificarProd.Enabled = false;
                                        frmVentas.me.btnEliminarProd.Enabled = false;
                                        frmVentas.me.btnGuardar.Enabled = false;


                                        DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        try
                                        {
                                            countProducto = frmVentas.me.dgvProductos.Rows.Count;
                                        }
                                        catch (Exception) { }


                                        frmVentas.me.txtNumVenta.Text = "0";
                                        frmVentas.me.captar_id_cliente = 0;
                                        frmVentas.me.click_cancelar();
                                        frmVentas.me.tEnfoque.Enabled = true;

                                        if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                        }

                                    }
                                    else if (name_ventana == 2)
                                    {
                                        frmVentas_2.me.txtBuscar.Text = "";

                                        frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                        frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                                        frmVentas_2.me.btnAgregarProd.Enabled = false;
                                        frmVentas_2.me.btnModificarProd.Enabled = false;
                                        frmVentas_2.me.btnEliminarProd.Enabled = false;
                                        frmVentas_2.me.btnGuardar.Enabled = false;


                                        DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        try
                                        {
                                            countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                                        }
                                        catch (Exception) { }

                                        frmVentas_2.me.txtNumVenta.Text = "0";
                                        frmVentas_2.me.captar_id_cliente = 0;
                                        frmVentas_2.me.click_cancelar();
                                        frmVentas_2.me.tEnfoque.Enabled = true;

                                        if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                        }


                                    }
                                    else if (name_ventana == 3)
                                    {
                                        frmVentas_3.me.txtBuscar.Text = "";

                                        frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                        frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                                        frmVentas_3.me.btnAgregarProd.Enabled = false;
                                        frmVentas_3.me.btnModificarProd.Enabled = false;
                                        frmVentas_3.me.btnEliminarProd.Enabled = false;
                                        frmVentas_3.me.btnGuardar.Enabled = false;


                                        DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        try
                                        {
                                            countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                                        }
                                        catch (Exception) { }

                                        frmVentas_3.me.txtNumVenta.Text = "0";
                                        frmVentas_3.me.captar_id_cliente = 0;
                                        frmVentas_3.me.click_cancelar();
                                        frmVentas_3.me.tEnfoque.Enabled = true;

                                        if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                        }
                                    }
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show(dtResult.Rows[0]["Error"].ToString(), "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No fue posible procesar la venta, el resultado de la tabla de ventas es nulo", "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex) { clikChecked = false; cGeneral.error(ex); }
                }
            }
        }
        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void dtpFechaCobro_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudMontoCheque_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void txtNumTransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void frmVentas_Pagar_Efectivo_Load(object sender, EventArgs e)
        {
            try
            {
                this.nudEfectivo.DecimalPlaces = cGeneral.decimales_ventas;
                if (name_ventana <= 3)
                {
                    this.mtxtFactura.Mask = cGeneral.formato_factura;
                }

                //if (name_ventana == 1)
                //{
                //    this.lblTotalPagar.Text = frmVentas.me.lblTotalPagar.Text;
                //    total_Pagar = this.lblTotalPagar.Text;
                //}
                //else  if (name_ventana == 2)
                //{
                //    this.lblTotalPagar.Text = frmVentas_2.me.lblTotalPagar.Text;
                //    total_Pagar = this.lblTotalPagar.Text;
                //}
                //else if (name_ventana == 3)
                //{
                //    this.lblTotalPagar.Text = frmVentas_3.me.lblTotalPagar.Text;
                ///   total_Pagar = this.lblTotalPagar.Text;
                //}
                ////this.cmbTipoVenta.Visible = false; 
                this.lblTotalPagar.Text = total_Pagar;
                this.lblDiferencia.Text = this.lblTotalPagar.Text;
                ObtenerTipoPago();
                ObtenerCliente();
                NVentas.eliminar_detalle_multi_pago_by_usuario(cGeneral.id_user_actual);
                ///this.cmbTipoVenta.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void ObtenerTipoPago()
        {
            try
            {
                cmbTipoVenta.DataSource = CapaNegocios.NTipoPago.cargar_cmb(cGeneral.permiso_venta_credito);
                cmbTipoVenta.ValueMember = "Id";
                cmbTipoVenta.DisplayMember = "Tipo";
                cmbTipoVenta.SelectedIndex = 0;
                this.cmbTipoVenta.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception) { }
        }
        private void ObtenerCliente()
        {
            try
            {
                try
                {
                    int.Parse(cmbTipoVenta.Value.ToString());

                    if (!cliente_cargado)
                    {
                        if (captar_id_cliente > 0)
                        {
                            if (this.cmbTipoVenta.Text == "CREDITO" || this.cmbTipoVenta.Text == "CHEQUE" || this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO" || this.cmbTipoVenta.Text == "TRANSFERENCIAS" || this.cmbTipoVenta.Text == "DEPOSITOS")
                            {
                                DataTable dtCliente = CapaNegocios.NClientes.buscar("*");
                                ///llenamos la lista de clientes para los creditos.
                                this.cmbCliente.DataSource = dtCliente;
                                this.cmbCliente.ValueMember = "ID";
                                this.cmbCliente.DisplayMember = "CLIENTE";
                                this.cmbCliente.SelectedIndex = 0;
                                this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                                this.cmbCliente.Value = captar_id_cliente;

                            }
                            else
                            {
                                DataTable dtCliente = CapaNegocios.NClientes.buscar("*");
                                ///llenamos la lista de clientes para los otros tipos de pago
                                this.cmbCliente.DataSource = dtCliente;
                                this.cmbCliente.ValueMember = "ID";
                                this.cmbCliente.DisplayMember = "CLIENTE";
                                this.cmbCliente.SelectedIndex = 0;
                                this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                                this.cmbCliente.Value = captar_id_cliente;
                            }
                            cliente_cargado = true;
                        }
                        else
                        {
                            DataTable dtCliente = CapaNegocios.NClientes.buscar("*");
                            ///llenamos la lista de clientes para los otros tipos de pago
                            this.cmbCliente.DataSource = dtCliente;
                            this.cmbCliente.ValueMember = "ID";
                            this.cmbCliente.DisplayMember = "CLIENTE";
                            this.cmbCliente.SelectedIndex = 0;
                            this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                            this.cmbCliente.Value = captar_id_cliente;
                        }
                        cliente_cargado = true;
                    }
                    else
                    {
                        DataTable dtCliente = CapaNegocios.NClientes.buscar("*");
                        ///llenamos la lista de clientes para los otros tipos de pago
                        this.cmbCliente.DataSource = dtCliente;
                        this.cmbCliente.ValueMember = "ID";
                        this.cmbCliente.DisplayMember = "CLIENTE";
                        this.cmbCliente.SelectedIndex = 0;
                        this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                        this.cmbCliente.Value = captar_id_cliente;
                        cliente_cargado = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe de seleccionar un tipo de venta correcto: " + cmbTipoVenta.Text + " no existe o no esta activo en el sistema", "Error selección tipo venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTipoVenta.Text = "";
                }
            }
            catch (Exception) { }
        }
        private void ObtenerBancos()
        {
            try
            {
                if (!banco_cargado)
                {
                    DataTable dtBanco = CapaNegocios.NBancos.buscar("*");
                    ///llenamos la lista de clientes para los creditos.
                    this.cmbBanco.DataSource = dtBanco;
                    this.cmbBanco.ValueMember = "ID";
                    this.cmbBanco.DisplayMember = "Banco";
                    this.cmbBanco.SelectedIndex = 0;
                    this.cmbBanco.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                    banco_cargado = true;
                }
            }
            catch (Exception) { }
        }
        private void cmbTipoVenta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ///Inactivamos controles de adquiriente
                this.lblAdquiriente.Visible = false;
                this.lblRequeridoAdquiriente.Visible = false;
                this.mtxtAdquiriente.Visible = false;
                this.mtxtNumDocumento.Mask = null;
                this.nudOtrosPagos.Enabled = true;
                this.nudOtrosPagos.Value = 0;
                this.nudOtrosPagos.Visible = true;
                this.lblMontoEtiqueta.Visible = true;
                this.lblMontoEtiquetaRequerido.Visible = true;
                this.lblMontoEtiqueta.Text = "MONTO:";
                ruta_img_cheque = "";
                this.pbFoto.ImageLocation = null;
                this.pbEliminarCheque.Visible = false;
                this.pbVerCheque.Visible = false;
                this.gbImagenCheque.Visible = false;

                /*CONTADO*/
                if (this.cmbTipoVenta.Text == "CONTADO")
                {
                    this.pPagoContado.Tabs[0].Selected = true;
                    this.pPagoContado.Tabs[0].Enabled = true;
                    this.pPagoContado.Tabs[1].Enabled = false;
                    this.pPagoContado.Tabs[1].Visible = false;
                    this.pPagoContado.Tabs[2].Enabled = false;
                    this.pPagoContado.Tabs[2].Visible = false;
                    this.pPagoContado.Tabs[0].Visible = true;
                    this.pEfectivo.Enabled = true;
                    this.nudEfectivo.Focus();
                    this.nudEfectivo.Select();
                    this.nudEfectivo.Select(0, 4);
                    this.Width = 980;
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
                /*CREDITO*/
                else if (this.cmbTipoVenta.Text == "CREDITO")
                {
                    this.pPagoContado.Tabs[1].Selected = true;
                    this.pPagoContado.Tabs[1].Enabled = true;
                    this.pPagoContado.Tabs[0].Enabled = false;
                    this.pPagoContado.Tabs[0].Visible = false;
                    this.pPagoContado.Tabs[2].Enabled = false;
                    this.pPagoContado.Tabs[2].Visible = false;
                    this.pPagoContado.Tabs[1].Visible = true;

                    this.pCredito.Enabled = true;
                    this.mtxtFactura.Focus();
                    this.mtxtFactura.Select();
                    this.lblMontoCrédito.Text = lblTotalPagar.Text;
                    ObtenerCliente();
                    mtxtFactura_TextChanged(null, null);
                    this.Width = 390;
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
                /*CHEQUE*/
                else if (this.cmbTipoVenta.Text == "CHEQUE" || this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO" || this.cmbTipoVenta.Text == "TRANSFERENCIAS" || this.cmbTipoVenta.Text == "DEPOSITOS")
                {
                    this.Width = 980;
                    this.StartPosition = FormStartPosition.CenterScreen;
                    this.pPagoContado.Tabs[2].Text = cmbTipoVenta.Text;
                    this.pPagoContado.Tabs[2].Visible = true;
                    this.pPagoContado.Tabs[2].Selected = true;
                    this.pPagoContado.Tabs[2].Enabled = true;
                    this.pPagoContado.Tabs[0].Enabled = false;
                    this.pPagoContado.Tabs[0].Visible = false;
                    this.pPagoContado.Tabs[1].Enabled = false;
                    this.pPagoContado.Tabs[1].Visible = false;

                    this.pOrosPagos.Enabled = true;
                    this.mtxtNumDocumento.Focus();
                    this.mtxtNumDocumento.Select();
                    ///this.lblMontoOtrosPagos.Text = lblTotalPagar.Text;
                    ////this.lblMontoTotalOtrosPagos.Text = lblTotalPagar.Text;

                    /*inactiva campos de fecha de cobro*/
                    this.dtpFechaCobro.Visible = false;
                    this.lblEtiquetaFechaCobro.Visible = false;
                    this.lblValidaFechaCobro.Visible = false;

                    if (this.cmbTipoVenta.Text == "CHEQUE")
                    {
                        this.gbImagenCheque.Visible = true;
                        this.dtpFechaCobro.Visible = true;
                        this.lblEtiquetaFechaCobro.Visible = true;
                        this.lblValidaFechaCobro.Visible = true;
                        this.mtxtNumDocumento.Text = "";
                        this.lblTipodDocumento.Text = "Número Cheque:";
                        this.lblNumeroTipoDocumento.Text = "Número Cheque:";
                        this.lblMontoTipoDocumento.Text = "Monto Cheque:";
                        this.nudOtrosPagos.Text = lblTotalPagar.Text;
                        this.nudOtrosPagos.Enabled = false;
                        this.nudOtrosPagos.Visible = false;
                        this.lblMontoEtiqueta.Visible = false;
                        this.lblMontoEtiquetaRequerido.Visible = false;

                    }
                    else if (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO")
                    {
                        this.mtxtNumDocumento.Text = "";
                        ////this.mtxtNumDocumento.Mask = cGeneral.formato_numero_autirizacion;
                        this.lblTipodDocumento.Text = "Número REF:";
                        this.lblNumeroTipoDocumento.Text = "Número REF:";
                        this.lblMontoTipoDocumento.Text = "Monto a Debitar:";
                        this.lblAdquiriente.Visible = true;
                        this.lblRequeridoAdquiriente.Visible = true;
                        this.mtxtAdquiriente.Visible = true;

                        if (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO")
                        {
                            this.lblMontoTipoDocumento.Text = "Interés a Debitar:";
                            this.lblMontoEtiqueta.Text = "INTERÉS:";
                        }
                        else
                        {
                            this.nudOtrosPagos.Text = lblTotalPagar.Text;
                            this.nudOtrosPagos.Enabled = false;
                            this.nudOtrosPagos.Visible = false;
                            this.lblMontoEtiqueta.Visible = false;
                            this.lblMontoEtiquetaRequerido.Visible = false;

                            this.lblMontoEtiqueta.Text = "MONTO:";
                            this.lblMontoTipoDocumento.Text = "Monto a Debitar:";
                        }
                    }
                    else if (this.cmbTipoVenta.Text == "TRANSFERENCIAS")
                    {
                        this.nudOtrosPagos.Text = lblTotalPagar.Text;
                        this.nudOtrosPagos.Enabled = false;
                        this.nudOtrosPagos.Visible = false;
                        this.lblMontoEtiqueta.Visible = false;
                        this.lblMontoEtiquetaRequerido.Visible = false;

                        this.mtxtNumDocumento.Text = "";
                        this.lblTipodDocumento.Text = "Número TF:";
                        this.lblNumeroTipoDocumento.Text = "Número TF:";
                        this.lblMontoTipoDocumento.Text = "Monto de TF:";
                    }
                    else if (this.cmbTipoVenta.Text == "DEPOSITOS")
                    {
                        this.nudOtrosPagos.Text = lblTotalPagar.Text;
                        this.nudOtrosPagos.Enabled = false;
                        this.nudOtrosPagos.Visible = false;
                        this.lblMontoEtiqueta.Visible = false;
                        this.lblMontoEtiquetaRequerido.Visible = false;

                        this.mtxtNumDocumento.Text = "";
                        this.lblTipodDocumento.Text = "Número Deposito:";
                        this.lblNumeroTipoDocumento.Text = "Número Deposito:";
                        this.lblMontoTipoDocumento.Text = "Monto Deposito:";
                    }
                    ObtenerCliente();
                    ObtenerBancos();
                    ///mtxtFactura_TextChanged(null, null);
                }
                else
                {
                    this.pPagoContado.Tabs[0].Visible = true;
                    this.nudEfectivo.Value = 0;
                    this.nudEfectivo.Text = this.nudEfectivo.Value.ToString();
                    this.pEfectivo.Enabled = false;
                    this.pPagoContado.Tabs[0].Selected = true;
                    this.pPagoContado.Tabs[0].Enabled = true;
                    this.pPagoContado.Tabs[1].Enabled = false;
                    this.pPagoContado.Tabs[1].Visible = false;
                    this.pPagoContado.Tabs[2].Enabled = false;
                    this.pPagoContado.Tabs[2].Visible = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void nudDiasPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }
        private void nudDiasPago_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardarCredito_Click(null, null);
            }
        }
        private void nudMontoTransf_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }
        private void mtxtFactura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (name_ventana <= 3)
                {
                    lblCredito.Text = "FACTURA #: " + mtxtFactura.Text;
                }
                else
                {
                    lblCredito.Text = "Nota Venta #: " + mtxtFactura.Text;
                }


                if (this.mtxtFactura.MaskFull)
                    this.nudDiasPago.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnGuardarCredito_Click(object sender, EventArgs e)
        {
            int countProducto = 0;
            this.ttMensaje.Hide(this.btnPagar);

            if (this.mtxtFactura.MaskFull == false)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("El número de factura está incompleto", this.btnPagar, 0, 38, 3000);
                this.mtxtFactura.Focus();
                return;
            }
            else if (this.cmbCliente.Items.Count == 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("La lista de cliente está vacía", this.btnPagar, 0, 38, 3000);
                this.cmbCliente.Focus();
                this.cmbCliente.DroppedDown = true;
                return;
            }
            else if (this.nudDiasPago.Enabled)
            {
                if (this.nudDiasPago.Value == 0 || this.nudDiasPago.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número de días", this.btnPagar, 0, 38, 3000);
                    this.nudDiasPago.Focus();
                    return;
                }
            }

            if (!NVentas.siFacturaCreditoExiste(this.mtxtFactura.Text))
            {
                DialogResult resul1 = MessageBox.Show("Genarar factura por cobrar.\n\n¿Desea enviar ésta factura a las facturas pendientes de cobro?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (name_ventana <= 3)
                        {
                            if (NVentas.credito(int.Parse(num_venta), mtxtFactura.Text, cmbCliente.Value.ToString(), System.DateTime.Now.ToShortDateString(), int.Parse(nudDiasPago.Value.ToString()), lblFechaPago.Text, decimal.Parse(lblMontoCrédito.Text), cbRetencionRenta.Checked, cbRetencionIva.Checked, int.Parse(cmbTipoVenta.Value.ToString()), "Venta") > 0)
                            {
                                if (name_ventana == 1)
                                {
                                    frmVentas.me.txtBuscar.Text = "";

                                    frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                    frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                                    frmVentas.me.btnAgregarProd.Enabled = false;
                                    frmVentas.me.btnModificarProd.Enabled = false;
                                    frmVentas.me.btnEliminarProd.Enabled = false;
                                    frmVentas.me.btnGuardar.Enabled = false;

                                    DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    try
                                    {
                                        countProducto = frmVentas.me.dgvProductos.Rows.Count;
                                    }
                                    catch (Exception) { }


                                    frmVentas.me.txtNumVenta.Text = "0";
                                    frmVentas.me.captar_id_cliente = 0;
                                    frmVentas.me.click_cancelar();
                                    frmVentas.me.tEnfoque.Enabled = true;

                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                    }

                                }
                                else if (name_ventana == 2)
                                {
                                    frmVentas_2.me.txtBuscar.Text = "";

                                    frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                    frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                                    frmVentas_2.me.btnAgregarProd.Enabled = false;
                                    frmVentas_2.me.btnModificarProd.Enabled = false;
                                    frmVentas_2.me.btnEliminarProd.Enabled = false;
                                    frmVentas_2.me.btnGuardar.Enabled = false;


                                    DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    try
                                    {
                                        countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                                    }
                                    catch (Exception) { }

                                    frmVentas_2.me.txtNumVenta.Text = "0";
                                    frmVentas_2.me.captar_id_cliente = 0;
                                    frmVentas_2.me.click_cancelar();
                                    frmVentas_2.me.tEnfoque.Enabled = true;

                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                    }


                                }
                                else if (name_ventana == 3)
                                {
                                    frmVentas_3.me.txtBuscar.Text = "";

                                    frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                    frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                                    frmVentas_3.me.btnAgregarProd.Enabled = false;
                                    frmVentas_3.me.btnModificarProd.Enabled = false;
                                    frmVentas_3.me.btnEliminarProd.Enabled = false;
                                    frmVentas_3.me.btnGuardar.Enabled = false;


                                    DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    try
                                    {
                                        countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                                    }
                                    catch (Exception) { }

                                    frmVentas_3.me.txtNumVenta.Text = "0";
                                    frmVentas_3.me.captar_id_cliente = 0;
                                    frmVentas_3.me.click_cancelar();
                                    frmVentas_3.me.tEnfoque.Enabled = true;

                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                    }
                                }

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No es posible generar el número de factura de crédito. Contactar el el administrador del sistema", "FALTAN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //else if (name_ventana == 4)
                        //{
                        //    if (NNotaVentaCliente.credito(int.Parse(num_venta), mtxtFactura.Text, cmbCliente.Value.ToString(), System.DateTime.Now.ToShortDateString(), int.Parse(nudDiasPago.Value.ToString()), lblFechaPago.Text, decimal.Parse(lblMontoCrédito.Text), cbRetencionRenta.Checked, cbRetencionIva.Checked, int.Parse(cmbTipoVenta.Value.ToString()),"NotaVenta") > 0)
                        //    {
                        //        Ventas.frmNotaVentaCliente.me.txtBuscar.Text = "";

                        //        Ventas.frmNotaVentaCliente.me.dgvProductos.DataSource = NNotaVentaCliente.cargar_prod(int.Parse(num_venta));
                        //        Ventas.frmNotaVentaCliente.me.orden_prod(Ventas.frmNotaVentaCliente.me.dgvProductos);

                        //        Ventas.frmNotaVentaCliente.me.btnAgregarProd.Enabled = false;
                        //        Ventas.frmNotaVentaCliente.me.btnModificarProd.Enabled = false;
                        //        Ventas.frmNotaVentaCliente.me.btnEliminarProd.Enabled = false;
                        //        Ventas.frmNotaVentaCliente.me.btnGuardar.Enabled = false;

                        //        DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        //        try
                        //        {
                        //            countProducto = Ventas.frmNotaVentaCliente.me.dgvProductos.Rows.Count;
                        //        }
                        //        catch (Exception) { }


                        //        Ventas.frmNotaVentaCliente.me.txtNumVenta.Text = "0";
                        //        Ventas.frmNotaVentaCliente.me.captar_id_cliente = 0;
                        //        Ventas.frmNotaVentaCliente.me.click_cancelar();
                        //        Ventas.frmNotaVentaCliente.me.tEnfoque.Enabled = true;

                        //        if (resul == System.Windows.Forms.DialogResult.Yes)
                        //        {
                        //            System.Threading.Tasks.Task.Run(() => { print_nota_venta(countProducto); });
                        //        }
                        //        this.Close();
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("No es posible generar el número de factura de crédito. Contactar el el administrador del sistema", "FALTAN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                MessageBox.Show("El nùmero de factura: " + this.mtxtFactura.Text + " ya esta registrado en sistema.", "NÙMERO DE FACTURA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mtxtFactura.Focus();
                this.mtxtFactura.ForeColor = Color.Red;
            }
        }
        private void btnCancelarCredito_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSumarOtroTipoPago_Tick(object sender, EventArgs e)
        {
            try
            {
                decimal efec;

                if (this.nudOtrosPagos.Text == "")
                    efec = 0;
                else
                    efec = Convert.ToDecimal(this.nudOtrosPagos.Text);

                decimal captar_sumatoria;
                captar_sumatoria = (efec);
                this.lblMontoOtrosPagos.Text = captar_sumatoria.ToString("N" + cGeneral.decimales_ventas + "");

                //diferencia = Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Text) - captar_sumatoria;

                //if (diferencia < 0)
                //    diferencia *= -1;

                //this.lblMontoOtrosPagos.Text = diferencia.ToString("N" + cGeneral.decimales_ventas + "");
            }
            catch (Exception ex) { }
            calculaDiaCredito();
        }

        private void mtxtNumDocumento_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.cmbTipoVenta.Text == "CHEQUE")
                {
                    this.lblNumeroTipoDocumento.Text = "Número Cheque: " + mtxtNumDocumento.Text;
                }
                else if (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO")
                {
                    this.lblNumeroTipoDocumento.Text = "Número REF: " + mtxtNumDocumento.Text;
                }
                else if (this.cmbTipoVenta.Text == "TRANSFERENCIAS")
                {
                    this.lblNumeroTipoDocumento.Text = "Número TF: " + mtxtNumDocumento.Text;
                }
                else if (this.cmbTipoVenta.Text == "DEPOSITOS")
                {
                    this.lblNumeroTipoDocumento.Text = "Número Deposito: " + mtxtNumDocumento.Text;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void GuardarOtroTipoPago()
        {
            try
            {

                int countProducto = 0;

                if (this.nudOtrosPagos.Text == "")
                    this.nudOtrosPagos.Value = 0;
                else
                    this.nudOtrosPagos.Value = Convert.ToDecimal(this.nudOtrosPagos.Text);
                if (mtxtNumDocumento.TextLength <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("El número de documento " + cmbTipoVenta.Text + " es requerido.", this.btnPagar, 0, 38, 3000);
                    this.mtxtNumDocumento.Focus();
                    return;
                }
                else if (decimal.Parse(this.lblMontoTotalOtrosPagos.Text) <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No se puede guardar una venta con Total a Pagar menor o igual a cero.", this.btnPagar, 0, 38, 3000);
                    this.nudOtrosPagos.Focus();
                    return;
                }
                else if (int.Parse(this.cmbTipoVenta.Value.ToString()) < 3)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Elija el tipo de pago", this.btnPagar, 0, 38, 3000);
                    this.cmbTipoVenta.Focus();
                    return;
                }
                else if (this.cmbBanco.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Elija el BANCO de pago.", this.btnPagar, 0, 38, 3000);
                    this.cmbBanco.Focus();
                    return;
                }
                else if (mtxtAdquiriente.TextLength <= 0 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Especifique el ADQUIRENTE, este es requerido para: " + cmbTipoVenta.Text + "", this.btnPagar, 0, 38, 3000);
                    this.mtxtAdquiriente.Focus();
                    return;
                }
                else
                {
                    if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                    {
                        if (Convert.ToDecimal(this.nudOtrosPagos.Value) == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            ///this.ttMensaje.Show("Especifique el monto en efectivo", this.btnGuardarOtroTipoPago, 0, 38, 3000);
                            this.ttMensaje.Show("El monto interés tiene que ser mayor a 0.", this.btnPagar, 0, 38, 6000);
                            this.nudOtrosPagos.Focus();
                            return;
                        }
                    }
                }
                if (Convert.ToDecimal(this.nudOtrosPagos.Text) <= 0 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                {
                    this.ttMensaje.ToolTipTitle = "CORREGIR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El monto interés tiene que ser mayor a 0.", this.btnPagar, 0, 38, 6000);

                    if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                        this.nudOtrosPagos.Focus();

                    return;
                }
                //if (Convert.ToDecimal(this.nudOtrosPagos.Text) < Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Text) && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                //{
                //    this.ttMensaje.ToolTipTitle = "CORREGIR";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error; 
                //    this.ttMensaje.Show("El monto ingresado es MENOR que el total a pagar", this.btnGuardarOtroTipoPago, 0, 38, 6000);

                //    if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                //        this.nudOtrosPagos.Focus();

                //    return;
                //}
                if (!clikChecked)
                {
                    clikChecked = true;
                    //if (name_ventana == 4)
                    //{
                    //    NNotaVentaCliente.ActualizaNotaVenta(int.Parse(num_venta), cmbClientecOtrosTipoPago.Value.ToString(), cmbTipoVenta.Value.ToString(), mtxtNumDocumento.Text);
                    //    NNotaVentaCliente.pagar(int.Parse(num_venta),0, cmbTipoVenta.Text == "CHEQUE" ? mtxtNumDocumento.Text: "", dtpFechaCobro.Value, int.Parse(cmbBanco.Value.ToString()), cmbTipoVenta.Text == "CHEQUE"?Convert.ToDecimal(this.nudOtrosPagos.Value):0, ruta_img_cheque, cmbTipoVenta.Text != "CHEQUE" ? this.mtxtNumDocumento.Text: "", cmbTipoVenta.Text == "TRANSFERENCIAS" || cmbTipoVenta.Text == "DEPOSITOS" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, ruta_img_tranf, cmbTipoVenta.Text == "TARJETA DE CREDITO" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Text.ToString()) : 0, cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0,mtxtAdquiriente.Text, cmbTipoVenta.Text == "TARJETA DE CREDITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0);
                    //}
                    //else
                    //{
                    NVentas.ActualizaVenta(int.Parse(num_venta), cmbCliente.Value.ToString(), cmbTipoVenta.Value.ToString(), mtxtNumDocumento.Text);
                    DataTable dtResult =  NVentas.pagar(cmbCliente.Value.ToString(),int.Parse(num_venta), 0, cmbTipoVenta.Text == "CHEQUE" ? mtxtNumDocumento.Text : "", dtpFechaCobro.Value, int.Parse(cmbBanco.Value.ToString()), cmbTipoVenta.Text == "CHEQUE" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, ruta_img_cheque, cmbTipoVenta.Text != "CHEQUE" ? this.mtxtNumDocumento.Text : "", cmbTipoVenta.Text == "TRANSFERENCIAS" || cmbTipoVenta.Text == "DEPOSITOS" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, ruta_img_tranf, cmbTipoVenta.Text == "TARJETA DE CREDITO" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Text.ToString()) : 0, cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, mtxtAdquiriente.Text, cmbTipoVenta.Text == "TARJETA DE CREDITO" || cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, cmbTipoVenta.Value.ToString());
                    //} 
                    if (dtResult.Rows.Count > 0)
                    {
                        if (bool.Parse(dtResult.Rows[0]["Exito"].ToString()))
                        {
                            if (name_ventana == 1)
                            {
                                frmVentas.me.txtBuscar.Text = "";

                                frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                                frmVentas.me.btnAgregarProd.Enabled = false;
                                frmVentas.me.btnModificarProd.Enabled = false;
                                frmVentas.me.btnEliminarProd.Enabled = false;
                                frmVentas.me.btnGuardar.Enabled = false;


                                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                try
                                {
                                    countProducto = frmVentas.me.dgvProductos.Rows.Count;
                                }
                                catch (Exception) { }


                                frmVentas.me.txtNumVenta.Text = "0";
                                frmVentas.me.captar_id_cliente = 0;
                                frmVentas.me.click_cancelar();
                                frmVentas.me.tEnfoque.Enabled = true;

                                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                }

                            }
                            else if (name_ventana == 2)
                            {
                                frmVentas_2.me.txtBuscar.Text = "";

                                frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                                frmVentas_2.me.btnAgregarProd.Enabled = false;
                                frmVentas_2.me.btnModificarProd.Enabled = false;
                                frmVentas_2.me.btnEliminarProd.Enabled = false;
                                frmVentas_2.me.btnGuardar.Enabled = false;


                                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                try
                                {
                                    countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                                }
                                catch (Exception) { }

                                frmVentas_2.me.txtNumVenta.Text = "0";
                                frmVentas_2.me.captar_id_cliente = 0;
                                frmVentas_2.me.click_cancelar();
                                frmVentas_2.me.tEnfoque.Enabled = true;

                                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                }


                            }
                            else if (name_ventana == 3)
                            {
                                frmVentas_3.me.txtBuscar.Text = "";

                                frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                                frmVentas_3.me.btnAgregarProd.Enabled = false;
                                frmVentas_3.me.btnModificarProd.Enabled = false;
                                frmVentas_3.me.btnEliminarProd.Enabled = false;
                                frmVentas_3.me.btnGuardar.Enabled = false;


                                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                try
                                {
                                    countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                                }
                                catch (Exception) { }

                                frmVentas_3.me.txtNumVenta.Text = "0";
                                frmVentas_3.me.captar_id_cliente = 0;
                                frmVentas_3.me.click_cancelar();
                                frmVentas_3.me.tEnfoque.Enabled = true;

                                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                }
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(dtResult.Rows[0]["Error"].ToString(), "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No fue posible procesar la venta, el resultado de la tabla de ventas es nulo", "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) { clikChecked = false; cGeneral.error(ex); }
        }

        private void btnCloseOtroPago_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudOtrosPagos_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
            if (e.KeyCode == Keys.Enter)
            {
                //// btnGuardarOtroTipoPago_Click(null, null);
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void lblMontoTotalOtrosPagos_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarFormaPagoContado_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnAgregarFormaPagoContado);
                int countProducto = 0;

                if (this.nudEfectivo.Text == "")
                    this.nudEfectivo.Value = 0;
                else
                    this.nudEfectivo.Value = Convert.ToDecimal(this.nudEfectivo.Text);

                //if (decimal.Parse(this.lblTotalPagar.Text) <= 0)
                //{
                //    this.ttMensaje.ToolTipTitle = "AVISO";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("No se puede guardar una venta con Total a Pagar menor o igual a cero.", this.btnAgregarFormaPagoContado, 0, 38, 3000);
                //    this.nudEfectivo.Focus();
                //    return;
                //}
                //else 
                if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Elija el tipo de pago", this.btnAgregarFormaPagoContado, 0, 38, 3000);
                    this.cmbTipoVenta.Focus();
                    return;
                }
                else
                {
                    if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                    {
                        if (Convert.ToDecimal(this.nudEfectivo.Value) == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Especifique el monto en efectivo", this.btnAgregarFormaPagoContado, 0, 38, 3000);
                            this.nudEfectivo.Focus();
                            return;
                        }
                    }
                }

                //if (Convert.ToDecimal(this.lblIngresado.Text) < Convert.ToDecimal(this.lblTotalPagar.Text))
                //{
                //    this.ttMensaje.ToolTipTitle = "CORREGIR";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                //    this.ttMensaje.Show("El monto ingresado es MENOR que el total a pagar", this.btnAgregarFormaPagoContado, 0, 38, 6000);

                //    //if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                //    this.nudEfectivo.Focus();

                //    return;
                //}
                //if (!clikChecked)
                {
                    //bool ventaMultiPago = uDetallePago.Rows.Count > 0 ? true : false;
                    //DialogResult resul3 = new DialogResult();
                    //if (!ventaMultiPago)
                    //{
                    //    resul3 = MessageBox.Show("¿Desa pagar esta venta con este pago? Presione SI para continuar o NO para agregar mas formas de pago.", "¿Pago de contado?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //}
                    //if (resul3 == System.Windows.Forms.DialogResult.Yes && ventaMultiPago == false)
                    //{
                    //    clikChecked = true;
                    //    NVentas.pagar(int.Parse(num_venta), Convert.ToDecimal(this.nudEfectivo.Value), "", System.DateTime.Now, 0, 0, ruta_img_cheque, "", 0, ruta_img_tranf, 0, 0, mtxtAdquiriente.Text, 0, cmbTipoVenta.Value.ToString());

                    //    if (name_ventana == 1)
                    //    {
                    //        frmVentas.me.txtBuscar.Text = "";

                    //        frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                    //        frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                    //        frmVentas.me.btnAgregarProd.Enabled = false;
                    //        frmVentas.me.btnModificarProd.Enabled = false;
                    //        frmVentas.me.btnEliminarProd.Enabled = false;
                    //        frmVentas.me.btnGuardar.Enabled = false;


                    //        DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //        try
                    //        {
                    //            countProducto = frmVentas.me.dgvProductos.Rows.Count;
                    //        }
                    //        catch (Exception) { }


                    //        frmVentas.me.txtNumVenta.Text = "0";
                    //        frmVentas.me.captar_id_cliente = 0;
                    //        frmVentas.me.click_cancelar();
                    //        frmVentas.me.tEnfoque.Enabled = true;

                    //        if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    //        {
                    //            System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                    //        }

                    //    }
                    //    else if (name_ventana == 2)
                    //    {
                    //        frmVentas_2.me.txtBuscar.Text = "";

                    //        frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                    //        frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                    //        frmVentas_2.me.btnAgregarProd.Enabled = false;
                    //        frmVentas_2.me.btnModificarProd.Enabled = false;
                    //        frmVentas_2.me.btnEliminarProd.Enabled = false;
                    //        frmVentas_2.me.btnGuardar.Enabled = false;


                    //        DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //        try
                    //        {
                    //            countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                    //        }
                    //        catch (Exception) { }

                    //        frmVentas_2.me.txtNumVenta.Text = "0";
                    //        frmVentas_2.me.captar_id_cliente = 0;
                    //        frmVentas_2.me.click_cancelar();
                    //        frmVentas_2.me.tEnfoque.Enabled = true;

                    //        if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    //        {
                    //            System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                    //        }


                    //    }
                    //    else if (name_ventana == 3)
                    //    {
                    //        frmVentas_3.me.txtBuscar.Text = "";

                    //        frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                    //        frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                    //        frmVentas_3.me.btnAgregarProd.Enabled = false;
                    //        frmVentas_3.me.btnModificarProd.Enabled = false;
                    //        frmVentas_3.me.btnEliminarProd.Enabled = false;
                    //        frmVentas_3.me.btnGuardar.Enabled = false;


                    //        DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //        try
                    //        {
                    //            countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                    //        }
                    //        catch (Exception) { }

                    //        frmVentas_3.me.txtNumVenta.Text = "0";
                    //        frmVentas_3.me.captar_id_cliente = 0;
                    //        frmVentas_3.me.click_cancelar();
                    //        frmVentas_3.me.tEnfoque.Enabled = true;

                    //        if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    //        {
                    //            System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                    //        }
                    //    }
                    //    this.Close();
                    //}
                    //else
                    //{
                        NVentas.AgregarFormaPago(int.Parse(num_venta), Convert.ToDecimal(this.nudEfectivo.Value), "", System.DateTime.Now, 0, 0, ruta_img_cheque, "", 0, ruta_img_tranf, 0, 0, mtxtAdquiriente.Text, 0, cmbTipoVenta.Value.ToString());
                        cargar_detalle_pago();
                        nudEfectivo.Value = 0;
                    //}
                }
            }
            catch (Exception ex) { clikChecked = false; cGeneral.error(ex); }
        }

        private void calculaDiaCredito()
        {
            try
            {
                if (this.nudDiasPago.Text == "")
                    this.lblFechaPago.Text = System.DateTime.Now.AddDays(0).Date.ToShortDateString();
                else
                    this.lblFechaPago.Text = System.DateTime.Now.AddDays(Convert.ToDouble(this.nudDiasPago.Text)).Date.ToShortDateString();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregarFormaPagoCredito_Click(object sender, EventArgs e)
        {
            GuardarVentaCredito();
        }

        private void GuardarVentaCredito()
        {
            int countProducto = 0;
            this.ttMensaje.Hide(this.btnAgregarFormaPagoCredito);

            if (this.mtxtFactura.MaskFull == false)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("El número de factura está incompleto", this.btnAgregarFormaPagoCredito, 0, 38, 3000);
                this.mtxtFactura.Focus();
                return;
            }
            else if (this.cmbCliente.Items.Count == 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("La lista de cliente está vacía", this.btnAgregarFormaPagoCredito, 0, 38, 3000);
                this.cmbCliente.Focus();
                this.cmbCliente.DroppedDown = true;
                return;
            }
            else if (this.nudDiasPago.Enabled)
            {
                if (this.nudDiasPago.Value == 0 || this.nudDiasPago.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número de días", this.btnAgregarFormaPagoCredito, 0, 38, 3000);
                    this.nudDiasPago.Focus();
                    return;
                }
            }

            if (!NVentas.siFacturaCreditoExiste(this.mtxtFactura.Text))
            {
                DialogResult resul1 = MessageBox.Show("Genarar factura por cobrar.\n\n¿Desea enviar ésta factura a las facturas pendientes de cobro?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (name_ventana <= 3)
                        {
                            if (NVentas.credito(int.Parse(num_venta), mtxtFactura.Text, cmbCliente.Value.ToString(), System.DateTime.Now.ToShortDateString(), int.Parse(nudDiasPago.Value.ToString()), lblFechaPago.Text, decimal.Parse(lblMontoCrédito.Text), cbRetencionRenta.Checked, cbRetencionIva.Checked, int.Parse(cmbTipoVenta.Value.ToString()), "Venta") > 0)
                            {
                                if (name_ventana == 1)
                                {
                                    frmVentas.me.txtBuscar.Text = "";

                                    frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                    frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                                    frmVentas.me.btnAgregarProd.Enabled = false;
                                    frmVentas.me.btnModificarProd.Enabled = false;
                                    frmVentas.me.btnEliminarProd.Enabled = false;
                                    frmVentas.me.btnGuardar.Enabled = false;

                                    DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    try
                                    {
                                        countProducto = frmVentas.me.dgvProductos.Rows.Count;
                                    }
                                    catch (Exception) { }


                                    frmVentas.me.txtNumVenta.Text = "0";
                                    frmVentas.me.captar_id_cliente = 0;
                                    frmVentas.me.click_cancelar();
                                    frmVentas.me.tEnfoque.Enabled = true;

                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                    }

                                }
                                else if (name_ventana == 2)
                                {
                                    frmVentas_2.me.txtBuscar.Text = "";

                                    frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                    frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                                    frmVentas_2.me.btnAgregarProd.Enabled = false;
                                    frmVentas_2.me.btnModificarProd.Enabled = false;
                                    frmVentas_2.me.btnEliminarProd.Enabled = false;
                                    frmVentas_2.me.btnGuardar.Enabled = false;


                                    DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    try
                                    {
                                        countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                                    }
                                    catch (Exception) { }

                                    frmVentas_2.me.txtNumVenta.Text = "0";
                                    frmVentas_2.me.captar_id_cliente = 0;
                                    frmVentas_2.me.click_cancelar();
                                    frmVentas_2.me.tEnfoque.Enabled = true;

                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                    }


                                }
                                else if (name_ventana == 3)
                                {
                                    frmVentas_3.me.txtBuscar.Text = "";

                                    frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                                    frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                                    frmVentas_3.me.btnAgregarProd.Enabled = false;
                                    frmVentas_3.me.btnModificarProd.Enabled = false;
                                    frmVentas_3.me.btnEliminarProd.Enabled = false;
                                    frmVentas_3.me.btnGuardar.Enabled = false;


                                    DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    try
                                    {
                                        countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                                    }
                                    catch (Exception) { }

                                    frmVentas_3.me.txtNumVenta.Text = "0";
                                    frmVentas_3.me.captar_id_cliente = 0;
                                    frmVentas_3.me.click_cancelar();
                                    frmVentas_3.me.tEnfoque.Enabled = true;

                                    if (resul == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                                    }
                                }

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No es posible generar el número de factura de crédito. Contactar el el administrador del sistema", "FALTAN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //else if (name_ventana == 4)
                        //{
                        //    if (NNotaVentaCliente.credito(int.Parse(num_venta), mtxtFactura.Text, cmbCliente.Value.ToString(), System.DateTime.Now.ToShortDateString(), int.Parse(nudDiasPago.Value.ToString()), lblFechaPago.Text, decimal.Parse(lblMontoCrédito.Text), cbRetencionRenta.Checked, cbRetencionIva.Checked, int.Parse(cmbTipoVenta.Value.ToString()),"NotaVenta") > 0)
                        //    {
                        //        Ventas.frmNotaVentaCliente.me.txtBuscar.Text = "";

                        //        Ventas.frmNotaVentaCliente.me.dgvProductos.DataSource = NNotaVentaCliente.cargar_prod(int.Parse(num_venta));
                        //        Ventas.frmNotaVentaCliente.me.orden_prod(Ventas.frmNotaVentaCliente.me.dgvProductos);

                        //        Ventas.frmNotaVentaCliente.me.btnAgregarProd.Enabled = false;
                        //        Ventas.frmNotaVentaCliente.me.btnModificarProd.Enabled = false;
                        //        Ventas.frmNotaVentaCliente.me.btnEliminarProd.Enabled = false;
                        //        Ventas.frmNotaVentaCliente.me.btnGuardar.Enabled = false;

                        //        DialogResult resul = MessageBox.Show("La factura de crédito ha sido guardada con éxito.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        //        try
                        //        {
                        //            countProducto = Ventas.frmNotaVentaCliente.me.dgvProductos.Rows.Count;
                        //        }
                        //        catch (Exception) { }


                        //        Ventas.frmNotaVentaCliente.me.txtNumVenta.Text = "0";
                        //        Ventas.frmNotaVentaCliente.me.captar_id_cliente = 0;
                        //        Ventas.frmNotaVentaCliente.me.click_cancelar();
                        //        Ventas.frmNotaVentaCliente.me.tEnfoque.Enabled = true;

                        //        if (resul == System.Windows.Forms.DialogResult.Yes)
                        //        {
                        //            System.Threading.Tasks.Task.Run(() => { print_nota_venta(countProducto); });
                        //        }
                        //        this.Close();
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("No es posible generar el número de factura de crédito. Contactar el el administrador del sistema", "FALTAN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                MessageBox.Show("El nùmero de factura: " + this.mtxtFactura.Text + " ya esta registrado en sistema.", "NÙMERO DE FACTURA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mtxtFactura.Focus();
                this.mtxtFactura.ForeColor = Color.Red;
            }
        }

        private void btnAgregarFormaPagoCheque_Click(object sender, EventArgs e)
        {
            GuardarVentaOtrosPagos();
        }

        private void uDetallePago_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ////e.Layout.Bands[0].Columns[0].Width = 50;
            e.Layout.Bands[0].Columns[2].Width = 100;
            e.Layout.Bands[0].Columns[1].Width = 150;
            /// e.Layout.Bands[0].Hidden = false;

            e.Layout.Bands[0].Columns["Id"].Hidden = true;

            e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;


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

        private void GuardarVentaOtrosPagos()
        {
            try
            {
                this.ttMensaje.Hide(this.btnAgregarFormaPagoCheque);
                int countProducto = 0;

                if (this.nudOtrosPagos.Text == "")
                    this.nudOtrosPagos.Value = 0;
                else
                    this.nudOtrosPagos.Value = Convert.ToDecimal(this.nudOtrosPagos.Text);
                if (mtxtNumDocumento.TextLength <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("El número de documento " + cmbTipoVenta.Text + " es requerido.", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                    this.mtxtNumDocumento.Focus();
                    return;
                }
                else if (decimal.Parse(this.lblMontoTotalOtrosPagos.Text) <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No se puede guardar una venta con Total a Pagar menor o igual a cero.", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                    this.lblMontoTotalOtrosPagos.Focus();
                    return;
                }
                else if (int.Parse(this.cmbTipoVenta.Value.ToString()) < 3)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Elija el tipo de pago", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                    this.cmbTipoVenta.Focus();
                    return;
                }
                else if (this.cmbBanco.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Elija el BANCO de pago.", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                    this.cmbBanco.Focus();
                    return;
                }
                else if (mtxtAdquiriente.TextLength <= 0 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                {
                    this.ttMensaje.ToolTipTitle = "AVISO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Especifique el ADQUIRENTE, este es requerido para: " + cmbTipoVenta.Text + "", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                    this.mtxtAdquiriente.Focus();
                    return;
                }
                else
                {
                    if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                    {
                        if (Convert.ToDecimal(this.nudOtrosPagos.Value) == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            ///this.ttMensaje.Show("Especifique el monto en efectivo", this.btnGuardarOtroTipoPago, 0, 38, 3000);
                            this.ttMensaje.Show("El monto interés tiene que ser mayor a 0.", this.btnAgregarFormaPagoCheque, 0, 38, 6000);
                            this.nudOtrosPagos.Focus();
                            return;
                        }
                    }
                }
                if (Convert.ToDecimal(this.nudOtrosPagos.Text) <= 0 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                {
                    this.ttMensaje.ToolTipTitle = "CORREGIR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El monto interés tiene que ser mayor a 0.", this.btnAgregarFormaPagoCheque, 0, 38, 6000);

                    if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                        this.nudOtrosPagos.Focus();

                    return;
                }
                if (!clikChecked)
                { 
                    NVentas.AgregarFormaPago(int.Parse(num_venta), 0, cmbTipoVenta.Text == "CHEQUE" ? mtxtNumDocumento.Text : "", dtpFechaCobro.Value, int.Parse(cmbBanco.Value.ToString()), cmbTipoVenta.Text == "CHEQUE" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Value) : 0, ruta_img_cheque, cmbTipoVenta.Text != "CHEQUE" ? this.mtxtNumDocumento.Text : "", cmbTipoVenta.Text == "TRANSFERENCIAS" || cmbTipoVenta.Text == "DEPOSITOS" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Value) : 0, ruta_img_tranf, cmbTipoVenta.Text == "TARJETA DE CREDITO" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Text.ToString()) : 0, cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Value) : 0, mtxtAdquiriente.Text, cmbTipoVenta.Text == "TARJETA DE CREDITO" || cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, cmbTipoVenta.Value.ToString());
                    cargar_detalle_pago();
                    mtxtNumDocumento.Text = "";
                    mtxtAdquiriente.Text = "";
                    nudOtrosPagos.Value = 0;
                    lblMontoTotalOtrosPagos.Value = 0;
                    cmbBanco.SelectedIndex = 0;
                    ruta_img_cheque = "";
                    this.pbFoto.ImageLocation = null;
                    this.pContenedorFoto.Visible = false;
                    this.pbEliminarCheque.Visible = false;
                    this.pbVerCheque.Visible = false;
                }
            }
            catch (Exception ex) { clikChecked = false; cGeneral.error(ex); }
        }
        public void sumar_det_pago()
        {
            try
            {
                UltraGridBand band = this.uDetallePago.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[2]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                ///summary.Appearance.TextHAlign = HAlign.Right;
                summary.Appearance.ForeColor = Color.White;
                summary.Appearance.BackColor = Color.DimGray;
                summary.Appearance.FontData.Bold = DefaultableBoolean.True;

                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.DimGray;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DimGray;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "SUMA TOTALES $:";


            }
            catch (Exception) { }
        }

        private void tsbDeleteDetallePago_Click(object sender, EventArgs e)
        {
            try
            {
                if (uDetallePago.Rows.Count > 0)
                {
                    ///string id = uGridEgresos.Selected.Rows[0].Cells["Id"].Value.ToString();
                    int id = int.Parse(uDetallePago.ActiveRow.Cells["Id"].Value.ToString());
                    if (id > 0)
                    {
                        NVentas.eliminar_detalle_multi_pago(id);
                        cargar_detalle_pago();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }

        private void cargar_detalle_pago()
        {
            try
            {
                DataTable dt = NVentas.Obtener_Forma_Pago_Venta_Temp(int.Parse(num_venta));
                bsDetallePago.DataSource = dt;
                this.uDetallePago.DisplayLayout.ResetBands();
                nvDetallePago.BindingSource = bsDetallePago;
                uDetallePago.DataSource = bsDetallePago;
                uDetallePago.DataBind();
                sumar_det_pago(); 
            }
            catch (Exception ex)  { MessageBox.Show(ex.Message.ToString());  }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            cargar_detalle_pago();
        }

        private void pPagoContado_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lblMontoTotalOtrosPagos_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
            if (!clikChecked)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.lblMontoTotalOtrosPagos.Value != Convert.ToDecimal(this.lblTotalPagar.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "CORREGIR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("El monto ingresado es MENOR que el total a pagar", this.btnAgregarFormaPagoContado, 0, 38, 6000);

                            //if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                            this.nudEfectivo.Focus();

                            return;
                        }

                        this.ttMensaje.Hide(this.btnAgregarFormaPagoCheque);
                        int countProducto = 0;

                        if (this.nudOtrosPagos.Text == "")
                            this.nudOtrosPagos.Value = 0;
                        else
                            this.nudOtrosPagos.Value = Convert.ToDecimal(this.nudOtrosPagos.Text);
                        if (mtxtNumDocumento.TextLength <= 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("El número de documento " + cmbTipoVenta.Text + " es requerido.", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                            this.mtxtNumDocumento.Focus();
                            return;
                        }
                        else if (decimal.Parse(this.lblMontoTotalOtrosPagos.Text) <= 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("No se puede guardar una venta con Total a Pagar menor o igual a cero.", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                            this.lblMontoTotalOtrosPagos.Focus();
                            return;
                        }
                        else if (int.Parse(this.cmbTipoVenta.Value.ToString()) < 3)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Elija el tipo de pago", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                            this.cmbTipoVenta.Focus();
                            return;
                        }
                        else if (this.cmbBanco.Items.Count == 0)
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Elija el BANCO de pago.", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                            this.cmbBanco.Focus();
                            return;
                        }
                        else if (mtxtAdquiriente.TextLength <= 0 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                        {
                            this.ttMensaje.ToolTipTitle = "AVISO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Especifique el ADQUIRENTE, este es requerido para: " + cmbTipoVenta.Text + "", this.btnAgregarFormaPagoCheque, 0, 38, 3000);
                            this.mtxtAdquiriente.Focus();
                            return;
                        }
                        else
                        {
                            if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                            {
                                if (Convert.ToDecimal(this.nudOtrosPagos.Value) == 0)
                                {
                                    this.ttMensaje.ToolTipTitle = "AVISO";
                                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                                    ///this.ttMensaje.Show("Especifique el monto en efectivo", this.btnGuardarOtroTipoPago, 0, 38, 3000);
                                    this.ttMensaje.Show("El monto interés tiene que ser mayor a 0.", this.btnAgregarFormaPagoCheque, 0, 38, 6000);
                                    this.nudOtrosPagos.Focus();
                                    return;
                                }
                            }
                        }
                        if (Convert.ToDecimal(this.nudOtrosPagos.Text) <= 0 && (this.cmbTipoVenta.Text == "TARJETA DE CREDITO" || this.cmbTipoVenta.Text == "TARJETA DE DEBITO"))
                        {
                            this.ttMensaje.ToolTipTitle = "CORREGIR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("El monto interés tiene que ser mayor a 0.", this.btnAgregarFormaPagoCheque, 0, 38, 6000);

                            if (int.Parse(this.cmbTipoVenta.Value.ToString()) != 1)
                                this.nudOtrosPagos.Focus();

                            return;
                        }
                        if (!clikChecked)
                        { 
                            clikChecked = true;
                            NVentas.ActualizaVenta(int.Parse(num_venta), cmbCliente.Value.ToString(), cmbTipoVenta.Value.ToString(), mtxtNumDocumento.Text);
                            DataTable dtResult =  NVentas.pagar(cmbCliente.Value.ToString(),int.Parse(num_venta), 0, cmbTipoVenta.Text == "CHEQUE" ? mtxtNumDocumento.Text : "", dtpFechaCobro.Value, int.Parse(cmbBanco.Value.ToString()), cmbTipoVenta.Text == "CHEQUE" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, ruta_img_cheque, cmbTipoVenta.Text != "CHEQUE" ? this.mtxtNumDocumento.Text : "", cmbTipoVenta.Text == "TRANSFERENCIAS" || cmbTipoVenta.Text == "DEPOSITOS" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, ruta_img_tranf, cmbTipoVenta.Text == "TARJETA DE CREDITO" ? Convert.ToDecimal(this.lblMontoTotalOtrosPagos.Text.ToString()) : 0, cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, mtxtAdquiriente.Text, cmbTipoVenta.Text == "TARJETA DE CREDITO" || cmbTipoVenta.Text == "TARJETA DE DEBITO" ? Convert.ToDecimal(this.nudOtrosPagos.Value) : 0, cmbTipoVenta.Value.ToString());
                            if (dtResult.Rows.Count > 0)
                            {
                                if (bool.Parse(dtResult.Rows[0]["Exito"].ToString()))
                                {
                                    cargarVentanas(countProducto);
                                }
                                else
                                {
                                    MessageBox.Show(dtResult.Rows[0]["Error"].ToString(), "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No fue posible procesar la venta, el resultado de la tabla de ventas es nulo", "Error al guardar la venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex) { clikChecked = false; cGeneral.error(ex); }
                }
            }
        }

        private void pbVerCheque_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbVerCheque_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbEliminarCheque_Click(object sender, EventArgs e)
        {

        }

        private void pbEliminarCheque_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbEliminarCheque_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbImagenCheque_Click(object sender, EventArgs e)
        {

        }

        private void pbImagenCheque_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbImagenCheque_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbImagenCheque_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "IMÁGENES JPG|*.JPG";
                openFileDialog1.Title = "SELECCIONE LA FOTO DEL CHEQUE";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta_img_cheque = openFileDialog1.FileName;
                    this.pbFoto.ImageLocation = openFileDialog1.FileName;
                    this.pbEliminarCheque.Visible = true;
                    this.pbVerCheque.Visible = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbImagenCheque_MouseEnter_1(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbImagenCheque);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Seleccionar la foto", this.pbImagenCheque, 0, 38);
        }

        private void pbImagenCheque_MouseLeave_1(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbImagenCheque);
        }

        private void pbEliminarCheque_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea quitar la foto del cheque.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    ///this.nudMontoCheque.Focus();
                    return;
                }

                ruta_img_cheque = "";
                this.pbFoto.ImageLocation = null;
                this.pbEliminarCheque.Visible = false;
                this.pbVerCheque.Visible = false;
                ///this.nudMontoCheque.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbEliminarCheque_MouseEnter_1(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbEliminarCheque);

            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Quitar la foto", this.pbEliminarCheque, 0, 38);
        }

        private void pbEliminarCheque_MouseLeave_1(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbEliminarCheque);
        }

        private void pbVerCheque_MouseEnter_1(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.pbVerCheque);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Ver la foto", this.pbVerCheque, 0, 38);

                this.tMostrarImagen.Enabled = true;
                this.pbFoto.ImageLocation = null;
                this.pbFoto.ImageLocation = ruta_img_cheque;
                this.pContenedorFoto.Location = new Point(296, 12);
                this.pContenedorFoto.Visible = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbVerCheque_MouseLeave_1(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.pbVerCheque);

            this.tMostrarImagen.Enabled = false;
            this.pContenedorFoto.Visible = false;
        }

        private void cmbCliente_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uDetallePago_MouseHover(object sender, EventArgs e)
        { 
            this.tMostrarImagen.Enabled = false;
            this.pContenedorFoto.Visible = false;
        }

        private void uDetallePago_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void uDetallePago_MouseEnterElement(object sender, UIElementEventArgs e)
        {
            verImagen();
        }
        private void verImagen()
        {
            try
            {
                if (uDetallePago.Rows.Count > 0)
                {
                    try
                    {
                        string ruta_img_cheque = uDetallePago.ActiveRow.Cells["Imagen_Cheque"].Value.ToString();
                        if (ruta_img_cheque != null)
                        {
                            if (File.Exists(ruta_img_cheque))
                            {
                                this.tMostrarImagen.Enabled = true;
                                this.pbFoto.ImageLocation = null;
                                this.pbFoto.ImageLocation = ruta_img_cheque;
                                this.pContenedorFoto.Location = new Point(296, 12);
                                this.pContenedorFoto.Visible = true;
                            }
                            else
                            {
                                this.tMostrarImagen.Enabled = false;
                                this.pContenedorFoto.Visible = false;
                            }
                        }
                        else
                        {
                            this.tMostrarImagen.Enabled = false;
                            this.pContenedorFoto.Visible = false;
                        }

                    }
                    catch (Exception)
                    {
                        /// pImagen.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void uDetallePago_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            this.tMostrarImagen.Enabled = false;
            this.pContenedorFoto.Visible = false;
        }

        private void uDetallePago_AfterRowActivate(object sender, EventArgs e)
        {
            verImagen();
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {

        }

        private void cargarVentanas(int countProducto)
        {
            if (name_ventana == 1)
            {
                frmVentas.me.txtBuscar.Text = "";

                frmVentas.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                frmVentas.me.orden_prod(frmVentas.me.dgvProductos);

                frmVentas.me.btnAgregarProd.Enabled = false;
                frmVentas.me.btnModificarProd.Enabled = false;
                frmVentas.me.btnEliminarProd.Enabled = false;
                frmVentas.me.btnGuardar.Enabled = false;


                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                try
                {
                    countProducto = frmVentas.me.dgvProductos.Rows.Count;
                }
                catch (Exception) { }


                frmVentas.me.txtNumVenta.Text = "0";
                frmVentas.me.captar_id_cliente = 0;
                frmVentas.me.click_cancelar();
                frmVentas.me.tEnfoque.Enabled = true;

                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                }

            }
            else if (name_ventana == 2)
            {
                frmVentas_2.me.txtBuscar.Text = "";

                frmVentas_2.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                frmVentas_2.me.orden_prod(frmVentas_2.me.dgvProductos);

                frmVentas_2.me.btnAgregarProd.Enabled = false;
                frmVentas_2.me.btnModificarProd.Enabled = false;
                frmVentas_2.me.btnEliminarProd.Enabled = false;
                frmVentas_2.me.btnGuardar.Enabled = false;


                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                try
                {
                    countProducto = frmVentas_2.me.dgvProductos.Rows.Count;
                }
                catch (Exception) { }

                frmVentas_2.me.txtNumVenta.Text = "0";
                frmVentas_2.me.captar_id_cliente = 0;
                frmVentas_2.me.click_cancelar();
                frmVentas_2.me.tEnfoque.Enabled = true;

                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                }


            }
            else if (name_ventana == 3)
            {
                frmVentas_3.me.txtBuscar.Text = "";

                frmVentas_3.me.dgvProductos.DataSource = NVentas.cargar_prod(int.Parse(num_venta));
                frmVentas_3.me.orden_prod(frmVentas_3.me.dgvProductos);

                frmVentas_3.me.btnAgregarProd.Enabled = false;
                frmVentas_3.me.btnModificarProd.Enabled = false;
                frmVentas_3.me.btnEliminarProd.Enabled = false;
                frmVentas_3.me.btnGuardar.Enabled = false;


                DialogResult resul1 = MessageBox.Show("La venta ha sido cancelada.\n\n¿Desea imprimir el recibo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                try
                {
                    countProducto = frmVentas_3.me.dgvProductos.Rows.Count;
                }
                catch (Exception) { }

                frmVentas_3.me.txtNumVenta.Text = "0";
                frmVentas_3.me.captar_id_cliente = 0;
                frmVentas_3.me.click_cancelar();
                frmVentas_3.me.tEnfoque.Enabled = true;

                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Threading.Tasks.Task.Run(() => { print_venta(countProducto); });
                }
            }
            this.Close();
        }
    }
}
