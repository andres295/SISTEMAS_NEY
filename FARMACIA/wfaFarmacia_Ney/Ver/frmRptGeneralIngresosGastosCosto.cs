
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using wfaFarmacia_Ney.Globales;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace wfaFarmacia_Ney.Ver
{
    public partial class frmRptGeneralIngresosGastosCosto : Form
    {
        public static frmRptGeneralIngresosGastosCosto me; 
        public frmRptGeneralIngresosGastosCosto()
        {
            frmRptGeneralIngresosGastosCosto.me = this;
            InitializeComponent();
        } 
        private void tDesarrollador_Tick(object sender, EventArgs e)
        {
            string first = this.lblDesarrollador.Text[0].ToString();
            this.lblDesarrollador.Text = this.lblDesarrollador.Text.Remove(0, 1);
            this.lblDesarrollador.Text += first;
        } 
        private void generarHistorico()
        {
            //try
            //{
            //    DataTable dt = NAdministracion.cargar_historico_gastos( this.dtInicio.Value , this.dtFin.Value,1);
            //    if (dt.Rows.Count > 0)
            //    {
            //        gvHistoricoGastos.DataSource = dt;
            //    }
            //    else { gvHistoricoGastos.DataSource = null; }
            //}
            //catch (Exception) { }
        }
        

        //private void btnExportarCtaProveedor_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.gvHistoricoGastos.Rows.Count > 0)
        //        {
        //            DateTime start;
        //            start = DateTime.Now;
        //            TimeSpan timespan;

        //            SaveFileDialog SaveFileDialog = new SaveFileDialog();
        //            SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
        //            string sfilePath = "";
        //            if (DialogResult.OK == SaveFileDialog.ShowDialog())
        //            {
        //                sfilePath = SaveFileDialog.FileName;
        //                if (!sfilePath.EndsWith(".xls"))
        //                {
        //                    sfilePath += ".xls";
        //                }
        //            }

        //            this.ultraGridExcelExporter1.Export(this.gvHistoricoGastos, sfilePath); 
        //            System.Diagnostics.Process proceso = new System.Diagnostics.Process(); 
        //            proceso.StartInfo.FileName = sfilePath;
        //            proceso.Start();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
        //    }
        //} 
        
        private void btnCargarHistorico_Click(object sender, EventArgs e)
        {
            ////this.gvHistoricoGastos.DisplayLayout.ResetBands();
            ///generarHistorico(); 
            ///group_rpt();
            /// sumar_datos();
            ///DataTable dt = generarCtaProveedor();
            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();

            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptGeneralCostoIngresosGasto.rpt");

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
            myReportDocument.SetParameterValue("@Desde", dtInicio.Value.ToShortDateString());
            myReportDocument.SetParameterValue("@Hasta", dtFin.Value.ToShortDateString());
            myReportDocument.SetParameterValue("@tipo", cbTipo.Value);

            //Preview
            crystalReportViewer1.ReportSource = myReportDocument;
            crystalReportViewer1.Refresh();
        }
        //public void sumar_datos()
        //{
            //try
            //{

            //    UltraGridBand band = this.gvHistoricoGastos.DisplayLayout.Bands[0];
            //    ///// ' Add a Horas.
            //    //SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[2]);
            //    //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            //    //summary.DisplayFormat = "Total {0:##,###0.00}";

            //    var summary = gvHistoricoGastos.DisplayLayout.Bands[0].Summaries.Add("" + "_" + gvHistoricoGastos.DisplayLayout.Bands[0].Summaries.Count, SummaryType.Sum, band.Columns[2]);
            //    summary.SummaryDisplayArea = SummaryDisplayAreas.InGroupByRows;

            //}
            //catch (Exception) { }
        //}
        //private void group_rpt()
        //{
            //try
            //{
            //    /*BUENO**/
            //    var band = gvHistoricoGastos.DisplayLayout.Bands[0];
            //    var sortedColumns = band.SortedColumns;
            //    //var columnToSummarize  = band.Layout.Bands["Monto"];

            //    sortedColumns.Add("Fecha", false, true); //last flag indicates is a group by column
            //    sortedColumns.Add("Gasto", false, true); //last flag indicates is a group by column

            //    //var SummarySettings = band.Summaries.Add("SpotCostSum", SummaryType.Sum, band.Columns[2], SummaryPosition.Left);
            //    //SummarySettings.DisplayFormat = "Total Spot Cost = {0}";

            //    this.gvHistoricoGastos.Rows.ExpandAll(true);

                /*PRUEBA*/

                /* Create band */
                //var band     = gvHistoricoGastos.DisplayLayout.Bands[0];
                //Infragistics.Win.UltraWinGrid.UltraGridGroup group1;
                //Infragistics.Win.UltraWinGrid.UltraGridGroup group2;
                //Infragistics.Win.UltraWinGrid.UltraGridColumn col1;
                //Infragistics.Win.UltraWinGrid.UltraGridColumn col2;
                //Infragistics.Win.UltraWinGrid.UltraGridColumn col3;


                ///* Create groups */
                //group1 = band.Groups.Add("Group1", "Location");
                //group2 = band.Groups.Add("Group2", "Item Info");

                ///* Create grid columns - must be already defined in proBindingSource */
                //col1 = band.Columns["Gasto"];
                //col2 = band.Columns["Fecha"];
                //col3 = band.Columns["Monto"];

                ///* Add columns to groups */
                //group1.Columns.Add(col1, 0, 0);
                //group1.Columns.Add(col2, 1, 0);
                //group2.Columns.Add(col3, 0, 0);

                /*PRUEBA 3*/// At the top level of the object hierarchy is the UltraGrid.
                //UltraGridBase grid = this.gvHistoricoGastos;

                //// Then is the layout.
                //UltraGridLayout layout = grid.DisplayLayout;

                //// Bands property returns the collection of bands. A band is analogous to a table in the data structure.
                //// Each band is associated with a table in the data source.
                //BandsCollection bands = layout.Bands;

                //// Get the first band, which is the  top-most band in case you had multple bands.
                //UltraGridBand band = bands[0];

                //// Columns property off UltraGridBand returns the collection of columns associated with the band.
                //ColumnsCollection columns = band.Columns;

                //// You can get a particular column using the column name.
                //UltraGridColumn column = columns["Gasto"];

                //// You can access the Header object associated with the column using Header property.
                //Infragistics.Win.UltraWinGrid.ColumnHeader colHeader = column.Header;

                //// Rows property off the UltraGridBase returns the top most rows.
                //RowsCollection rows = this.gvHistoricoGastos.Rows;

                //// You can get a row by index.
                //UltraGridRow row = rows[0];

                //// You can get a cell associated with a row and a column by using Cells property off the row.
                //// You can use a column object or a column key as illustrated below.
                //UltraGridCell cell = row.Cells[column]; // Using a column object.
                //cell = row.Cells["Gasto"];         // Using a column key.

                //// These objects also have properties that back-reference the object they belong to or are
                //// associated with. Following lines illustrate some of these properties.
                //column = cell.Column;           // Get the column cell is associated with.
                //row = cell.Row;         // Get the row cell is associated with.
                //rows = row.ParentCollection;        // Get the rows collection the row belongs to.
                //column = colHeader.Column;      // Get the column associated with the ColumnHeader object.
                //band = column.Band;         // Get the band associated with the column.
                //band = row.Band;            // Get the band associated with the row.
                //layout = column.Layout;         // Get the layout using a column.
                //layout = band.Layout;           // Get the layout using a band.
                //grid = layout.Grid;         // Get the grid using a band.
                //grid = cell.Row.Band.Layout.Grid; 	// Get the grid using a cell in a single statement.


        //    }
        //    catch (Exception) { }
        //}
        //private void gvHistoricoGastos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        //{ 
        //    e.Layout.Bands[0].Columns[0].Width = 300;
        //    e.Layout.Bands[0].Columns[1].Width = 400;
        //    e.Layout.Bands[0].Columns[2].Width = 300;

        //    e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.0000";
        //    //e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
        //    //e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;

        //    e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
        //    e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
        //    e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

        //    e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
        //    e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
        //    e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
        //    e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
        //    e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
        //    e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

        //    //'-Permite copiar los registros
        //    e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
        //    ///  '-Permite ordenar
        //    e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        //    e.Layout.Override.AllowAddNew = AllowAddNew.No;
        //    e.Layout.Override.AllowDelete = DefaultableBoolean.False;
        //    e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        //}

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("HistorialGastos");
                frmReporte.fecha_inicio = this.dtInicio.Value.ToString("yyyy-MM-dd");
                frmReporte.fecha_fin = this.dtFin.Value.ToString("yyyy-MM-dd");
                frmReporte.detalle_rpt = 1;  
                frmReporte.Show();

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void gvHistoricoGastos_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {

            e.Layout.Bands[0].Columns[0].Width = 300;
            e.Layout.Bands[0].Columns[1].Width = 400;
            e.Layout.Bands[0].Columns[2].Width = 300;

            e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.0000";

            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            //' Set the Filter Action related appearances on the layout
            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;

            ///' Allow the user to modify the row filters.
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;

            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;

            ///'-Permite copiar los registros
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
            ///'-Permite ordenar
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void frmHistoricoGastos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
