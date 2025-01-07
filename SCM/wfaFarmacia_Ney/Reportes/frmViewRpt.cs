using CapaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.Reportes
{
    public partial class frmViewRpt : Form
    {
        public string fecha_inicio;
        public string fecha_fin;
        public string id;
        public int desde;
        public int hasta;
        public string print_pago;
        public string num_factura;
        public string num_cotizacion;
        public static string gstrdbServidor = "";    //'-Mantiene el nombre del servidor
        public static string gstrdbBaseDatos = "";    ///'-Mantiene el nombre de la Base de Datos
        public static string gstrdbUsuario = "";      //'-Mantiene el nombre del usuario
        public static string gstrdbClave = "";       /// '-Mantiene la clave del usuario
        private string nombrereporte ="";
        public string id_producto = "";
        public string id_mov = "";
        public string filtro_producto = "";
        public string filtro_laboratorio = "";
        public int id_cierre_caja;
        public int id_usuario;
        public int detalle_rpt = 0;
        public string filtro_producto_buzon = "";
        public string filtro_proveedor_buzon = "";
        public string id_pago;
        public string id_cliente = "";
        public string tipoVenta = "";
        public string tipoPago = "";
        public string idExamenFormulario;
        public string idExamen;
        public string idEspecialista;
        public string id_contrato;
        public bool isDetalle = false;
        public decimal porc_comision = 0;
        public frmViewRpt(string rptName) 
        {
            InitializeComponent();
            nombrereporte = rptName;
        }

        private void frmViewRpt_Load(object sender, EventArgs e)
        {
            cargarReporte();
        }
        private void cargarReporte()
        {
            try
            {
                if (nombrereporte == "cargo_compra")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCargoCompraCC.rpt");

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
                    myReportDocument.SetParameterValue("@numfactura", num_factura);
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    ///crystalReportViewer1.Refresh();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();

                }
                if (nombrereporte == "cargo_ajuste_inv")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCargoAjusteInventario.rpt");

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
                    myReportDocument.SetParameterValue("@id", num_factura);
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    ///crystalReportViewer1.Refresh();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();

                }
                if (nombrereporte == "cargo_transferencia_inv")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCargoTransferenciaInventario.rpt");

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
                    myReportDocument.SetParameterValue("@id", num_factura);
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    ///crystalReportViewer1.Refresh();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();

                }
                if (nombrereporte == "descargo_ajuste_inv")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptDescargoAjusteInventario.rpt");

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
                    myReportDocument.SetParameterValue("@id", num_factura);
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    ///crystalReportViewer1.Refresh();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "descargo_transferencia_inv")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptDescargoTransferenciaInventario.rpt");

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
                    myReportDocument.SetParameterValue("@id", num_factura);
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    ///crystalReportViewer1.Refresh();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "rpt_cotizacion_venta")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCotizacion.rpt");

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
                    myReportDocument.SetParameterValue("@id", num_cotizacion);
                    // crystalReportViewer1.ReportSource = myReportDocument;
                    // crystalReportViewer1.Refresh();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "nueva_venta_recibo")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    if (cGeneral.alto_factura == "Formato 18,5 alto")
                    {
                        myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaRecibo.rpt");

                    }
                   else if  (cGeneral.alto_factura == "Formato 21,5 alto")

                     {
                        myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaReciboFormato2.rpt");
                     }
                    else if (cGeneral.alto_factura == "Logic control Lr2000")

                    {
                        myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptComprobanteSRI_BaucherConsumidorFInal.rpt");
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
                    myReportDocument.SetParameterValue("@id", num_factura);
                    myReportDocument.SetParameterValue("@desde", desde);
                    myReportDocument.SetParameterValue("@hasta", hasta);
                    myReportDocument.SetParameterValue("printpago", print_pago);

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;
 
                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "nueva_venta_cotizacion")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaCotizacion.rpt");
  
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
                    myReportDocument.SetParameterValue("@id", num_factura); 
                    myReportDocument.SetParameterValue("printpago", print_pago);

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "nueva_venta_cotizacion_servicio")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentaServicios.rpt");

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

                    myReportDocument.SetParameterValue("@id", num_factura);
                    myReportDocument.SetParameterValue("@idCliente", id_cliente);
                    myReportDocument.SetParameterValue("tipoVenta", tipoVenta);
                    myReportDocument.SetParameterValue("printpago", "NO");

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps; 

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "recibo_tickets_servicio")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptTicketsServicio.rpt");

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

                    myReportDocument.SetParameterValue("@id_venta", num_factura);
                    myReportDocument.SetParameterValue("tipoPago", tipoPago);

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                }
                if (nombrereporte == "cargo_ajuste_inventario_rpt")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCargoAjusteInventarioGen.rpt");

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
                    myReportDocument.SetParameterValue("@fInicio", fecha_inicio);
                    myReportDocument.SetParameterValue("@fFin", fecha_fin);
                    myReportDocument.SetParameterValue("@proveedor", id);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    
                }
                if (nombrereporte == "cargo_transferencia_inventario_rpt")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCargoTransferenciaInventarioGen.rpt");

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
                    myReportDocument.SetParameterValue("@fInicio", fecha_inicio);
                    myReportDocument.SetParameterValue("@fFin", fecha_fin);
                    myReportDocument.SetParameterValue("@proveedor", id);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();

                }
                if (nombrereporte == "descargo_ajuste_inventario_rpt")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptDescargoAjusteInventarioGen.rpt");

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
                    myReportDocument.SetParameterValue("@fInicio", fecha_inicio);
                    myReportDocument.SetParameterValue("@fFin", fecha_fin);
                    myReportDocument.SetParameterValue("@proveedor", id);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();

                }
                if (nombrereporte == "descargo_transferencia_inventario_rpt")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptDescargoTransferenciaInventarioGen.rpt");

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
                    myReportDocument.SetParameterValue("@fInicio", fecha_inicio);
                    myReportDocument.SetParameterValue("@fFin", fecha_fin);
                    myReportDocument.SetParameterValue("@proveedor", id);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();

                }
                if (nombrereporte == "kardex")
                {  
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptKardexReporte.rpt");

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
                    myReportDocument.SetParameterValue("@fini", fecha_inicio);
                    myReportDocument.SetParameterValue("@ffin", fecha_fin);
                    myReportDocument.SetParameterValue("@id_producto", id_producto);
                    myReportDocument.SetParameterValue("@mov", id_mov);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();

                }
                if (nombrereporte == "HistorialGastos")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptHostoricoGastos.rpt");

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
                    myReportDocument.SetParameterValue("@Desde", fecha_inicio);
                    myReportDocument.SetParameterValue("@Hasta", fecha_fin);
                    myReportDocument.SetParameterValue("@detalle", detalle_rpt);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();

                }
                if (nombrereporte == "buzon_pedido")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptBuzonPedido.rpt");

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

                    myReportDocument.SetParameterValue("@filtro_producto", filtro_producto_buzon);
                    myReportDocument.SetParameterValue("@filtro_proveedor", filtro_proveedor_buzon);

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();

                }
                if (nombrereporte == "stock_tickets")
                {  
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptStock.rpt");

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

                    //PrinterSettings ps = new PrinterSettings();
                    //ps.PrinterName = cGeneral.Impresora;
                    //bool ImpresoraValida = ps.IsValid;
                    //ps.Copies = 1;
                    //PageSettings pg = new PageSettings();
                    //pg.PrinterSettings = ps;

                    myReportDocument.SetParameterValue("@producto",filtro_producto);
                    myReportDocument.SetParameterValue("@laboratorio", filtro_laboratorio);
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close();
                    ///myReportDocument.PrintToPrinter(ps, pg, false);
                    ///this.Close();
                }
                if (nombrereporte == "cierre_caja_recibo")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCierreCajaRecibo.rpt");

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
                     
                    myReportDocument.SetParameterValue("@id_cierre", id_cierre_caja);
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    ///crystalReportViewer1.Refresh();
                    ///
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cGeneral.Impresora;
                    bool ImpresoraValida = ps.IsValid;
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;

                    //Preview
                    //crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();

                    myReportDocument.PrintToPrinter(ps, pg, false);
                    this.Close(); 
                }
                if (nombrereporte == "sugerencia_pedido")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptSugerenciaPedido.rpt");

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

                    myReportDocument.SetParameterValue("@id_usuario", id_usuario);
                    myReportDocument.SetParameterValue("@finicio", fecha_inicio);
                    myReportDocument.SetParameterValue("@ffin", fecha_fin);

                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();

                }
                if (nombrereporte == "recibo")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptPagoFacturaCliente.rpt");

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
                    myReportDocument.SetParameterValue("@id_pago", id_pago);
                    //Preview
                    ///crystalReportViewer1.ReportSource = myReportDocument;
                    //crystalReportViewer1.Refresh();
                    myReportDocument.PrintToPrinter(1, false, 1, 999);
                    this.Close();

                }
                if (nombrereporte == "ConsentimientoFormato")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptConsentimientoFormato.rpt");

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
                    myReportDocument.SetParameterValue("@id_contrato", id_contrato);
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
                if (nombrereporte == "ContratoServicio")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptContratoServicio.rpt");

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
                    myReportDocument.SetParameterValue("@id_contrato", id_contrato);
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
                if (nombrereporte == "ExamenFormulario")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rtpExamenFormulario.rpt");

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
                    myReportDocument.SetParameterValue("@idExamen", idExamenFormulario);
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
                if (nombrereporte == "ExamenFormularioScore")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rtpControlScoreMama.rpt");

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
                    myReportDocument.SetParameterValue("@idFormulario", idExamenFormulario);
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
                if (nombrereporte == "ExamenFormularioReceta")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptRecetaMedicacionPrescriocion.rpt");

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
                    myReportDocument.SetParameterValue("@idExamen", idExamenFormulario);
                    myReportDocument.SetParameterValue("tipoFiltro", "Medicamento");
                    myReportDocument.SetParameterValue("tipoFiltro2", "Prescripcion");
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
                if (nombrereporte == "ExamenGeneralHC")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptExamenGeneralHC.rpt");

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
                    myReportDocument.SetParameterValue("@idExamen", idExamen);
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
                if (nombrereporte == "ExamenEspecialista")
                {
                    ///DataTable dt = generarCtaProveedor();
                    ReportDocument myReportDocument;
                    myReportDocument = new ReportDocument();

                    if (isDetalle)
                    {
                        myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptAtecionEspecialistaDetalle.rpt");
                    }
                    else
                    {
                        myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptAtecionEspecialista.rpt");
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
                    myReportDocument.SetParameterValue("@idEspecialista", idEspecialista);
                    myReportDocument.SetParameterValue("@finicio", fecha_inicio);
                    myReportDocument.SetParameterValue("@fechafin", fecha_fin);
                    myReportDocument.SetParameterValue("@porc_comision", porc_comision);
                    //Preview
                    crystalReportViewer1.ReportSource = myReportDocument;
                    crystalReportViewer1.Refresh();
                    ///myReportDocument.PrintToPrinter(1, false, 1, 999);
                    ///this.Close();

                }
            }
            catch (Exception ex) {MessageBox.Show( ex.Message.ToString (),"Error al cargar o imprimir el reporte: " + nombrereporte,MessageBoxButtons.OK,MessageBoxIcon.Error); }

        }
        private DataTable generarCtaProveedor()
        {
            DataTable dt = new DataTable();
            try
            {
                ////dt = NConexion.ObtenerParametros("EXEC dbo.sp_ObtenerEstadodeCtaPorPagar '" + fecha_inicio + "','" + fecha_fin + "','" + id + "'");
                return dt;
            }
            catch (Exception) { return dt; }
        }
        private DataTable generarCtaCliente()
        {
            DataTable dt = new DataTable();
            try
            {
               /// dt = NConexion.ObtenerDatos("EXEC dbo.sp_ObtenerEstadodeCtaPorCobrar '" + fecha_inicio + "','" + fecha_fin + "','" + id + "'");
                return dt;
            }
            catch (Exception) { return dt; }
        }
        public static void ObtenerParametros()
        {
            try
            {
                //'Obtener Valores regedit
                RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SCM\\Conexion");
                RegistryKey regConexion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SCM\\Conexion");

                gstrdbUsuario = regConexion.GetValue("Usuario", "").ToString();
                gstrdbClave = regConexion.GetValue("Clave", "").ToString();
                gstrdbServidor = regConexion.GetValue("Servidor", "(local)").ToString();
                gstrdbBaseDatos = regConexion.GetValue("BaseDatos", "ND").ToString();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
    }
}
