using CapaNegocios;
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
using SCM.Globales;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace SCM
{
    public partial class frmStock : Form
    {

        public frmStock()
        {
            InitializeComponent();
        }
        void click_buscar()
        {
            try
            {

                DataTable dt;

                dt = NProductos.buscobtener_stockar(txtBuscar.Text, txtBuscarLaboratorio.Text, cbNuevo.Checked == true ? "S" : "N");
                uGridFactura.DataSource = dt;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            click_buscar();
            group_rpt();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            if (!cGeneral.mnuFiltroNuevoStock)
            {
                cbNuevo.Checked = false;
                cbNuevo.Enabled = false;
            }
            DataTable dt;
            dt = NProductos.buscobtener_stockar("zzz", "zzz", cbNuevo.Checked == true ? "S" : "N");
            uGridFactura.DataSource = dt;
            sumar_factura();
            ///group_rpt();
            this.txtBuscar.Focus(); 
            ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        public void sumar_factura()
        {
            try
            {
                UltraGridBand band = this.uGridFactura.DisplayLayout.Bands[0];
                /// ' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[3]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[4]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[5]);
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

                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";


                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";

            }
            catch (Exception) { }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarCtaProveedorProducto_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ///DataTable dt = generarCtaProveedor();
            //    ReportDocument myReportDocument;
            //    myReportDocument = new ReportDocument();
            //    myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptStock.rpt");

            //    //Set DataBase Login Info
            //    myReportDocument.SetDatabaseLogon(cConexion.gstrdbUsuario, cConexion.gstrdbClave, cConexion.gstrdbServidor, cConexion.gstrdbBaseDatos);
            //    foreach (CrystalDecisions.CrystalReports.Engine.Table table in myReportDocument.Database.Tables)
            //    {
            //        TableLogOnInfo logOnInfo = table.LogOnInfo;
            //        if (logOnInfo != null)
            //        {
            //            logOnInfo.TableName = table.Name;
            //            logOnInfo.ConnectionInfo.DatabaseName = cConexion.gstrdbBaseDatos;
            //            logOnInfo.ConnectionInfo.Password = cConexion.gstrdbClave;
            //            logOnInfo.ConnectionInfo.UserID = cConexion.gstrdbUsuario;
            //            logOnInfo.ConnectionInfo.ServerName = cConexion.gstrdbServidor;
            //            table.ApplyLogOnInfo(logOnInfo);
            //        }
            //    }
            //    myReportDocument.SetParameterValue("@producto", txtBuscar.Text);
            //    crystalReportViewer1.ReportSource = myReportDocument;
            //    crystalReportViewer1.Refresh();
            //   //// myReportDocument.PrintToPrinter(1, false, 1, 999);

            //}
            //catch (Exception ex) { cGeneral.error(ex); }
            try
            {
                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("stock_tickets");
                if (txtBuscar.Text == "*")
                {
                    frmReporte.filtro_producto = "";
                }
                else
                {
                    frmReporte.filtro_producto = txtBuscar.Text;
                }
                if (txtBuscarLaboratorio.Text == "*")
                {
                    frmReporte.filtro_laboratorio = "";
                }
                else
                {
                    frmReporte.filtro_laboratorio = txtBuscarLaboratorio.Text;
                } 
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void group_rpt()
        {
            try
            {
                this.uGridFactura.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
                //this.uGridFactura.DisplayLayout.Bands[0].SortedColumns.Add("Proveedor", false, true);
                //this.uGridFactura.DisplayLayout.Bands[0].SortedColumns.Add("Producto", false, true);
            }
            catch (Exception) { }
        }
        private void uGridFactura_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {


            e.Layout.Bands[0].Columns[0].Width = 100;
            e.Layout.Bands[0].Columns[1].Width = 250;
            e.Layout.Bands[0].Columns[2].Width = 150;
            e.Layout.Bands[0].Columns[3].Width = 60;
            //// e.Layout.Bands[0].Columns[4].Hidden = false;
            e.Layout.Bands[0].Columns[4].Width = 60;
            e.Layout.Bands[0].Columns[5].Width = 60;
            e.Layout.Bands[0].Columns[6].Width = 100;
            e.Layout.Bands[0].Columns[7].Width = 60;
            ///e.Layout.Bands[0].Columns[9].Hidden = false;
            e.Layout.Bands[0].Columns[8].Width = 60;
            e.Layout.Bands[0].Columns[9].Width = 60;
            e.Layout.Bands[0].Columns[10].Width = 60;

            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;

            e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";

            e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

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

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.00";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.00";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


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

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                click_buscar();
                group_rpt();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarLaboratorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtBuscarLaboratorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                click_buscar();
                group_rpt();
            }
        }
    }
}
