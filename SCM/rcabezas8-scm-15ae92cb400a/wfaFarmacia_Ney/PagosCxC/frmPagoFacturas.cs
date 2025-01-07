using CapaNegocios;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using SCM.Globales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCM.PagosCxC
{
    public partial class frmPagoFacturas : Form
    {
        public frmPagoFacturas()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPagoFacturas_Load(object sender, EventArgs e)
        {
            this.ugvFacturas.DataSource = NPagoCxC.Obtener_pago_factura(txtNumFactura.Text);
        }
 
        private void ugvFacturas_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           

            e.Layout.Bands[0].Columns[0].CellAppearance.TextHAlign = HAlign.Left;
            e.Layout.Bands[0].Columns[1].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Left;
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;


            e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[6].CellAppearance.ForeColor = Color.Red;


            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
             e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;

            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            //e.Layout.Override.AllowAddNew = AllowAddNew.No;
            //e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            //e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PagosCxC.frmAddPago frm = new PagosCxC.frmAddPago();
                    frm.Text = "AGREGAR PAGO";
                    frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }
        void click_eliminar()
        {
            try
            {
                DialogResult result = MessageBox.Show("Estás seguro(a) de eliminar este pago.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NPagoCxC.eliminar(Convert.ToInt32(this.ugvFacturas.ActiveRow.Cells[0].Value)))
                    {
                        this.ttMensaje.ToolTipTitle = "ANULAR PAGO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("Pago anulado con éxito.", this.btnEliminar, 0, 38, 3000);
                        this.ugvFacturas.DataSource = NPagoCxC.Obtener_pago_factura(txtNumFactura.Text);

                        Facturacion.frmCxPagar.me.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(Facturacion.frmCxPagar.me.dtpDesde.Value), Convert.ToDateTime(Facturacion.frmCxPagar.me.dtpDesde.Value),true);
                        Facturacion.frmCxPagar.me.tBuscar.Enabled = true;
                        ///this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnPrintVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvFacturas.Rows.Count > 0)
                {
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("recibo");
                    frmReporte.id_pago = this.ugvFacturas.ActiveRow.Cells[0].Value.ToString();
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
