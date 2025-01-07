using CapaNegocios;
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

namespace SCM.Farmacia
{
    public partial class frmCitasPorVencer : Form
    {
        public frmCitasPorVencer()
        {
            InitializeComponent();
        }


        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmCitasPorVencer_Load(object sender, EventArgs e)
        {
            bsCistas.DataSource = NClientes.citas_por_vencer();
            CitasBindingNavigator.BindingSource = bsCistas;
            this.dgvClientes.DataSource = bsCistas;
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.dgvClientes, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception ex)
            {
                //// cGeneral.error(ex);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            bsCistas.DataSource = NClientes.citas_por_vencer();
            CitasBindingNavigator.BindingSource = bsCistas;
            this.dgvClientes.DataSource = bsCistas;
        }

        private void dgvClientes_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            e.Layout.Bands[0].Columns[0].Width = 200;
            e.Layout.Bands[0].Columns[1].Width = 150;
            e.Layout.Bands[0].Columns[2].Width = 150;
            e.Layout.Bands[0].Columns[3].Width = 150;
            //e.Layout.Bands[0].Columns[3].Width = 60;
            //e.Layout.Bands[0].Columns[4].Width = 60;
            //e.Layout.Bands[0].Columns[5].Width = 60;
            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            //e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            //e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
