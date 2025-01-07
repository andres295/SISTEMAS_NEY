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

namespace SCM.Cubo
{
    public partial class frmKardex : Form
    {

        public frmKardex()
        {
            InitializeComponent();
        }
        void click_buscar()
        {
            try
            {

                DataTable dt;
                this.uGridFactura.DisplayLayout.ResetBands();

                dt = NProductos.buscar_kardex(dtpDesde.Value, dtpHasta.Value,cbProducto.Value.ToString(), cbMovimiento.Value.ToString());
                uGridFactura.DataSource = dt;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            click_buscar();
            group_rpt();
            sumar_ventas();
        }
        public void sumar_ventas()
        {
            try
            {
                if (cbMovimiento.Value.ToString() == "1")
                {
                    UltraGridBand band = this.uGridFactura.DisplayLayout.Bands[0];
                    /// ' Add a Horas.
                    SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[5]);
                    summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                    summary.DisplayFormat = "Total {0:##,###0.00}"; 
                } 
  
            }
            catch (Exception) { }
        }
        private void frmStock_Load(object sender, EventArgs e)
        {
            uGridFactura.DataSource = null;
            ///group_rpt();
            cargarMovimiento();
            cargarProducto();

            this.cbProducto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cbMovimiento.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            //////this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void cargarMovimiento()
        {
            try
            {
                DataTable dt = NProductos.buscar2();

                if (dt.Rows.Count > 0)
                {

                    this.cbMovimiento.DataSource = dt;
                    this.cbMovimiento.ValueMember = "ID";
                    this.cbMovimiento.DisplayMember = "TIPO";

                    if (this.cbMovimiento.Items.Count > 0)
                        this.cbMovimiento.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarCtaProveedorProducto_Click(object sender, EventArgs e)
        {
            try
            { 
                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("kardex");
                frmReporte.fecha_inicio = this.dtpDesde.Value.ToString("yyyy-MM-dd");
                frmReporte.fecha_fin = this.dtpHasta.Value.ToString("yyyy-MM-dd");
                frmReporte.id_producto = cbProducto.Value.ToString();
                frmReporte.id_mov = cbMovimiento.Value.ToString();

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
    
        private void uGridFactura_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].Width = 300;
            e.Layout.Bands[0].Columns[1].Width = 100;
            e.Layout.Bands[0].Columns[2].Width = 100;
            e.Layout.Bands[0].Columns[3].Width = 200;
            e.Layout.Bands[0].Columns[4].Width = 150;
            e.Layout.Bands[0].Columns[5].Width = 150;
            e.Layout.Bands[0].Columns[6].Width = 150;
            e.Layout.Bands[0].Columns[7].Width = 150;


            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;

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
      
        private void cargarProductoFiltro()
        {
            try
            {
                if (txtCodigo.TextLength > 0)
                {
                    DataTable dt = NProductos.cargarProductoFiltro2(txtCodigo.Text);

                    if (dt.Rows.Count > 0)
                    {

                        this.cbProducto.DataSource = dt;
                        this.cbProducto.ValueMember = "Id";
                        this.cbProducto.DisplayMember = "Producto";

                        if (this.cbProducto.Items.Count > 0)
                            this.cbProducto.SelectedIndex = 0;
                    }
                }
                else
                {
                    cargarProducto();
                }

            }
            catch (Exception) { }
        }

        private void cargarProducto()
        {
            try
            {
                DataTable dt = NProductos.cargarProductoFiltro1();

                if (dt.Rows.Count > 0)
                {

                    this.cbProducto.DataSource = dt;
                    this.cbProducto.ValueMember = "Id";
                    this.cbProducto.DisplayMember = "Producto";

                    if (this.cbProducto.Items.Count > 0)
                        this.cbProducto.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            cargarProductoFiltro();
        }

        private void txtCodigo_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
