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
using wfaFarmacia_Ney.Globales;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace wfaFarmacia_Ney.Generales
{
    public partial class frmValidaDispArticulo : Form
    {
        public string num_documento = "";
        public string tipo_mov = "";
        public frmValidaDispArticulo()
        {
            InitializeComponent();
        } 
        private void frmStock_Load(object sender, EventArgs e)
        {
            lblEtiqueta.Text = "NO ES POSIBLE ELIMINAR EL MOVIMIENTO: " + tipo_mov + " # Documento: " + num_documento;
        }  
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridListaProducto.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.uGridListaProducto, sfilePath);

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
        private void uGridFactura_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].Width = 200;
            e.Layout.Bands[0].Columns[1].Width = 300;
            e.Layout.Bands[0].Columns[2].Width = 150;
            e.Layout.Bands[0].Columns[3].Width = 150;
            e.Layout.Bands[0].Columns[4].Width = 150;
            //e.Layout.Bands[0].Columns[5].Width = 150;
            //e.Layout.Bands[0].Columns[6].Width = 150;
            //e.Layout.Bands[0].Columns[7].Width = 150;


            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Center; 

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
