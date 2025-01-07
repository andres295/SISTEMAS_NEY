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
using SCM.Globales;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace SCM.Ventas
{
    public partial class frmRptSugerenciaPedido : Form
    {
        public frmRptSugerenciaPedido()
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
            DataTable usuario = new DataTable();
            usuario = NUsuarios.listar();
            var row = usuario.NewRow();
            row["Id"] = "0";
            row["Usuario"] = "TODOS";
            obtenerSolicitud();
            usuario.Rows.InsertAt(row, 0);
            this.cmbUsuario.DataSource = usuario;
            this.cmbUsuario.ValueMember = "Id";
            this.cmbUsuario.DisplayMember = "Usuario";
            this.cmbUsuario.SelectedIndex = 0;
            this.cmbUsuario.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
        }


        void click_buscar()
        {
            try
            {
                ///DataTable dt = generarCtaProveedor();
                ReportDocument myReportDocument;
                myReportDocument = new ReportDocument();
                myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\Reportes\\rptCierreCaja.rpt");

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
                //myReportDocument.SetParameterValue("@fini", Convert.ToDateTime(this.dtpDesde.Value));
                //myReportDocument.SetParameterValue("@ffin", Convert.ToDateTime(this.dtpHasta.Value));
                //crystalReportViewer1.ReportSource = myReportDocument;
                //crystalReportViewer1.Refresh();
                ///cr.PrintToPrinter(1, false, 1, 999);

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerarCtaProveedor_Click(object sender, EventArgs e)
        {
            obtenerSolicitud();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            click_buscar();
        }
        private void obtenerSolicitud()
        {
            try
            {
                this.uGridRegistro.DisplayLayout.ResetBands();
                DataTable dt = NProductos.Obtener_Solicitud_by_usuario(int.Parse(cmbUsuario.Value.ToString()), dtpFecha.Value, dtpHasta.Value);
                bsSolicitud.DataSource = dt;
                nvSolicitud.BindingSource = bsSolicitud;
                uGridRegistro.DataSource = bsSolicitud;
                sumar_montos();

            }
            catch (Exception) { }
        }

        private void uGridRegistro_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ////e.Layout.Bands[0].Columns[0].Width = 50;
            e.Layout.Bands[0].Columns[2].Width = 80;
            e.Layout.Bands[0].Columns[3].Width = 80;
            e.Layout.Bands[0].Columns[4].Width = 80;
            e.Layout.Bands[0].Columns[1].Width = 300;
            /// e.Layout.Bands[0].Hidden = false;

            e.Layout.Bands[0].Columns["Id"].Hidden = true;

            e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

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

        private void btnExportarCtaProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridRegistro.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.uGridRegistro, sfilePath);

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (uGridRegistro.Rows.Count > 0)
            {
                if (MessageBox.Show("Está seguro(a) de eliminar esta solicitud?.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ///string id = uGridEgresos.Selected.Rows[0].Cells["Id"].Value.ToString();
                    int id = int.Parse(uGridRegistro.ActiveRow.Cells["IdSugerencia"].Value.ToString());
                    if (id > 0)
                    {
                        MessageBox.Show("Registro de solicitud de producto eliminado con éxito!.", "Solicitud de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NProductos.eliminar_solicitud_producto(id);
                        obtenerSolicitud();
                    }
                    else
                    {
                        MessageBox.Show("Registro de solicitud de producto no se puede eliminado!.", "Solicitud de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (uGridRegistro.Rows.Count > 0)
            {
                if (MessageBox.Show("Está seguro(a) de eliminar esta solicitud?.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ///string id = uGridEgresos.Selected.Rows[0].Cells["Id"].Value.ToString();
                    int id = int.Parse(uGridRegistro.ActiveRow.Cells["IdSugerencia"].Value.ToString());
                    if (id > 0)
                    {
                        MessageBox.Show("Registro de solicitud de producto eliminado con éxito!.", "Solicitud de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NProductos.eliminar_solicitud_producto(id);
                        obtenerSolicitud();
                    }
                    else
                    {
                        MessageBox.Show("Registro de solicitud de producto no se puede eliminado!.", "Solicitud de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("sugerencia_pedido");
            frmReporte.fecha_inicio = dtpFecha.Value.ToShortDateString();
            frmReporte.fecha_fin =dtpHasta.Value.ToShortDateString();
            frmReporte.id_usuario = int.Parse(cmbUsuario.Value.ToString()); 
            frmReporte.Show();
        }

        public void sumar_montos()
        {
            try
            {
                UltraGridBand band = this.uGridRegistro.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[2]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;

                ///summary.Appearance.TextHAlign = HAlign.Right;
                summary.Appearance.ForeColor = Color.White;
                summary.Appearance.BackColor = Color.DimGray;
                summary.Appearance.FontData.Bold = DefaultableBoolean.True;

                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band.Override.SummaryFooterAppearance.BackColor = Color.DimGray;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DimGray;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "TOTALES CANTIDAD:";

                UltraGridBand band2 = this.uGridRegistro.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary2 = band2.Summaries.Add(SummaryType.Sum, band2.Columns[3]);
                summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary2.DisplayFormat = "${0:##,###0.00}";

                ///summary.Appearance.TextHAlign = HAlign.Right;
                summary2.Appearance.ForeColor = Color.White;
                summary2.Appearance.BackColor = Color.DimGray;
                summary2.Appearance.FontData.Bold = DefaultableBoolean.True;

                band2.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;

                band2.Override.SummaryFooterAppearance.BackColor = Color.DimGray;
                band2.Override.SummaryFooterCaptionAppearance.BackColor = Color.DimGray;

                band2.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band2.SummaryFooterCaption = "TOTALES:";


            }
            catch (Exception) { }
        }
    }
}
