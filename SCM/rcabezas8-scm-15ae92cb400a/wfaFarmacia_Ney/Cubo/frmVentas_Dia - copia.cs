using CapaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.Cubo
{
    public partial class frmVentas_Dia : Form
    {
        public frmVentas_Dia()
        {
            InitializeComponent();
        }

        ///dcDatosDataContext bd = new dcDatosDataContext();
        int number = 0, tamaño = 0;

        public class campos
        {
            public DateTime fecha { get; set; }
            public decimal total { get; set; }
            public decimal ganancia { get; set; }
        }

        private void frmVentas_Dia_Load(object sender, EventArgs e)
        {
            //////this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }


        void click_buscar()
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();
                if (cbDetalle.Checked)
                {
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentas_de_dia_det.rpt");
                }
                else if (cbMultiProducto.Checked)
                {
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentas_de_dia_tipoPago.rpt");
                }
                else {
                    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVentas_de_dia.rpt"); 
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
                myReportDocument.SetParameterValue("@Inicio", this.dtpDesde.Value.ToString("yyyy-MM-dd"));
                myReportDocument.SetParameterValue("@Fin", this.dtpHasta.Value.ToString("yyyy-MM-dd"));
                crystalReportViewer1.ReportSource = myReportDocument;
                crystalReportViewer1.Refresh();
                ///cr.PrintToPrinter(1, false, 1, 999);

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbMultiProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMultiProducto.Checked)
            {
                cbDetalle.Visible = false;
                cbDetalle.Checked = false;
            }
            else
            {
                cbDetalle.Visible = true;
            }
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            click_buscar();
        }

    }
}
