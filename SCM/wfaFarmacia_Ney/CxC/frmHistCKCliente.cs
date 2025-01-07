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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.CxC
{
    public partial class frmHistCKCliente : Form
    {
        public frmHistCKCliente()
        {
            InitializeComponent();
        }

        private void frmHistCKCliente_Load(object sender, EventArgs e)
        {

            //this.btnCerrar.Left = this.Width;
            //this.btnCerrar.Visible = true;
            //if (!cGeneral.mnuFiltroNuevoStock)
            //{
            //    cbNuevo.Checked = false;
            //    cbNuevo.Enabled = false;
            //}
            this.dtpDesde.Value = System.DateTime.Now.AddDays(-15);
            this.dtpHasta.Value = DateTime.Now.Date;
            this.uGridFactura.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            CargarCliente();
            this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            //click_buscar();
            //sumar_factura();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_buscar();
        }
        void click_buscar()
        {
            try
            {
                this.uGridFactura.DisplayLayout.ResetBands();
                DataTable dt; 
                dt = NNotasCreditosCXC.buscar_rpt_ck(Convert.ToInt32(this.cmbCliente.Value), Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value));
                uGridFactura.DataSource = dt;
                sumar_factura();

               /// sumar_factura();
            }
            catch (Exception ex) { cGeneral.error(ex); }
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

                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[8]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";

                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[9]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";


                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[10]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";


                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[11]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";

                summary = band.Summaries.Add(SummaryType.Sum, band.Columns[12]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";

                //summary = band.Summaries.Add(SummaryType.Sum, band.Columns[13]);
                //summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                //summary.DisplayFormat = "${0:##,###0.00}";

            }
            catch (Exception) { }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
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

        private void btnExportarCtaProveedorProducto_Click(object sender, EventArgs e)
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();
                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptVencimiento.rpt");

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
                myReportDocument.SetParameterValue("@Desde", Convert.ToDateTime(this.dtpDesde.Value));
                myReportDocument.SetParameterValue("@Hasta", Convert.ToDateTime(this.dtpHasta.Value));
                ///crystalReportViewer1.ReportSource = myReportDocument;
                ///crystalReportViewer1.Refresh();
                ///cr.PrintToPrinter(1, false, 1, 999);
                myReportDocument.PrintToPrinter(1, false, 1, 999);
               //// this.Close();

            }
            catch (Exception ex) { cGeneral.error(ex); }
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

                e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.00";
                e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;

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
            catch (Exception) { }

        }
        private void CargarCliente()
        {
            try
            {
                DataTable dtProveedor = NClientes.lista_combo();

                var row = dtProveedor.NewRow();
                row["Id"] = "0";
                row["Cliente"] = "Todos";
                dtProveedor.Rows.InsertAt(row, 0);

                cmbCliente.DataSource = dtProveedor;
                cmbCliente.ValueMember = "Id";
                cmbCliente.DisplayMember = "Cliente";

                cmbCliente.Text = "Todos";
            }
            catch (Exception) { }
        }
    }
}
