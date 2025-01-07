using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Reporting.WinForms;
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

namespace SCM
{
    public partial class frmVentasMensual : Form
    {
        public frmVentasMensual()
        {
            InitializeComponent();
        }

        private void frmVentasMensual_Load(object sender, EventArgs e)
        {
            ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();

                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptResumenMensual.rpt");

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
                myReportDocument.SetParameterValue("@Desde", this.dtpDesde.Value.ToString("yyyy-MM-dd"));
                myReportDocument.SetParameterValue("@Hasta", this.dtpHasta.Value.ToString("yyyy-MM-dd"));
                crReporte.ReportSource = myReportDocument;
                crReporte.Refresh();
                ///cr.PrintToPrinter(1, false, 1, 999);

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
