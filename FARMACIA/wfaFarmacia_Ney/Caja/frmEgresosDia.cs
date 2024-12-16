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
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.Caja
{
    public partial class frmEgresosDia : Form
    {
        int id_apertura_caja = 0,id_cierre_caja=0;
        bool new_egreso = false;
        public frmEgresosDia()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
           //// frmCargoAjuste.me.tEnfoque.Enabled = true;
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpFechaDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtObserv_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
        private void cargarEgreso()
        {
            try
            {
                DataTable dt = NAdministracion.Cargar_Cat_Gastos();

                if (dt.Rows.Count > 0)
                {

                    this.cmbEgreso.DataSource = dt;
                    this.cmbEgreso.ValueMember = "ID";
                    this.cmbEgreso.DisplayMember = "DESCRIPCION";

                    if (this.cmbEgreso.Items.Count > 0)
                        this.cmbEgreso.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }
        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            cargarEgreso();
            obtenerEgresos();
            this.cmbEgreso.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
        }
        private void obtenerEgresos()
        {
            try
            {

                this.uGridEgresos.DataSource = null;
                DataTable dtCirre = new DataTable();
                dtCirre = NCaja.obtener_cierre_caja(cGeneral.id_user_actual);
                if (dtCirre.Rows.Count > 0)
                {
                    ///Id Apertura Caja
                    id_apertura_caja = int.Parse(dtCirre.Rows[0]["Id_Apertura_Caja"].ToString());
                    id_cierre_caja = int.Parse(dtCirre.Rows[0]["Id"].ToString());


                    DataTable dt = NCaja.obtener_egreso_caja(id_apertura_caja);
                    bsEgresos.DataSource = dt;
                    nvEgresos.BindingSource = bsEgresos;
                    uGridEgresos.DataSource = bsEgresos;
                    sumar_egresos();
                    nvEgresos.Enabled = false;
                    lblAperturaCaja.Visible = false;
                    lkAperturarCaja.Visible = false;

                }
                else
                {
                    id_apertura_caja = NCaja.obtener_id_caja(cGeneral.id_user_actual);
                    if (id_apertura_caja > 0)
                    {

                        DataTable dt = NCaja.obtener_egreso_caja(id_apertura_caja);
                        bsEgresos.DataSource = dt;
                        nvEgresos.BindingSource = bsEgresos;
                        uGridEgresos.DataSource = bsEgresos;
                        sumar_egresos();
                        lblAperturaCaja.Visible = false;
                        lkAperturarCaja.Visible = false;
                    }
                    else
                    {
                        lblAperturaCaja.Visible = true;
                        lblAperturaCaja.Enabled = true;
                        lblAperturaCaja.Text = "NESCESITA APERTURAR CAJA:";
                        lkAperturarCaja.Visible = true;
                        lkAperturarCaja.Enabled = true;
                    }
                }
            }
            catch (Exception) {}
        }
         
        public void sumar_egresos()
        {
            try
            {
                UltraGridBand band = this.uGridEgresos.DisplayLayout.Bands[0];
                ///' Add a Horas.
                SummarySettings summary = band.Summaries.Add(SummaryType.Sum, band.Columns[2]);
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
                summary.DisplayFormat = "${0:##,###0.00}";
                 
                ///summary.Appearance.TextHAlign = HAlign.Right;
                summary.Appearance.ForeColor = Color.White;
                summary.Appearance.BackColor = Color.DimGray;
                summary.Appearance.FontData.Bold = DefaultableBoolean.True;
 
                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;
          
                band.Override.SummaryFooterAppearance.BackColor = Color.DimGray;
                band.Override.SummaryFooterCaptionAppearance.BackColor = Color.DimGray;

                band.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
                band.SummaryFooterCaption = "TOTALES GASTOS$:";


            }
            catch (Exception) { }
        } 
         
        private void cargar_egresos()
        {
            try
            {
                DataTable dt = NCaja.obtener_egreso_caja(id_apertura_caja);
                bsEgresos.DataSource = dt;
                nvEgresos.BindingSource = bsEgresos;
                uGridEgresos.DataSource = bsEgresos; 
            }
            catch (Exception)  {    }
        } 
        private void print_recibo(int id_cierre)
        {
            try
            { 
                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("cierre_caja_recibo"); 
                frmReporte.id_cierre_caja = id_cierre;
                frmReporte.Show();
            }
            catch (Exception) {  }
        } 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool update_row = false;
                if (uGridEgresos.Rows.Count > 0)
                {
                    uGridEgresos.Refresh();
                    uGridEgresos.Update();
                    uGridEgresos.Rows[0].Activate();
                    uGridEgresos.EndUpdate();
                    for (int i = 0; i < uGridEgresos.Rows.Count; i++)
                    {
                        int id_egreso = 0;
                        decimal monto_egreso = 0;
                        DateTime fecha = System.DateTime.Now;
                        try
                        {
                          id_egreso =  int.Parse(uGridEgresos.Rows[i].Cells[0].Value.ToString());
                        }
                        catch (Exception) {   }

                        try
                        {
                            monto_egreso = decimal.Parse(uGridEgresos.Rows[i].Cells[2].Value.ToString());
                        }
                        catch (Exception) { }

                        try
                        {
                            fecha = DateTime.Parse(uGridEgresos.Rows[i].Cells[3].Value.ToString());
                        }
                        catch (Exception) { }

                        if (id_egreso <= 0)
                        {
                            if (monto_egreso>0)
                            {
                                if (new_egreso)
                                {
                                    NCaja.incluir_egreso(cGeneral.id_user_actual, id_apertura_caja, uGridEgresos.Rows[i].Cells[1].Value.ToString(), monto_egreso, fecha);
                                    update_row = true;
                                    new_egreso = false;
                                } 
                            }
                            else
                            {
                                ////uGridEgresos.Rows[i].Cells[2].Appearance.bac = Color.LightCyan;
                                uGridEgresos.Rows[i].Cells[2].Value = 0.00;
                                uGridEgresos.Rows[i].Cells[2].Band.Layout.Appearance.BackColor = Color.LightYellow;
                                uGridEgresos.Rows[i].Activate();
                                MessageBox.Show("Tiene que ingresar el monto del gasto.", "Ingresar el monto del gasto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                        else
                        {
                            if (!new_egreso)
                            {
                                NCaja.update_egreso_By_Fecha(id_egreso, uGridEgresos.Rows[i].Cells[1].Value.ToString(), monto_egreso, fecha);
                            } 
                        }

                    }
                    if (update_row)
                    {
                        cargar_egresos();
                    }  
                }
            }
            catch (Exception) {}
        }

        private void uGridEgresos_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ////e.Layout.Bands[0].Columns[0].Width = 50; 
            e.Layout.Bands[0].Columns[1].Width = 340;
            e.Layout.Bands[0].Columns[2].Width = 100;
            e.Layout.Bands[0].Columns[3].Width = 50;

            /// e.Layout.Bands[0].Hidden = false;

            e.Layout.Bands[0].Columns["Id"].Hidden = true; 

            e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;
             

            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            ///e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            new_egreso = true;
        }
         
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (uGridEgresos.Rows.Count > 0)
            {
                if (MessageBox.Show("Está seguro(a) de eliminar este gasto?.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ///string id = uGridEgresos.Selected.Rows[0].Cells["Id"].Value.ToString();
                    int id = int.Parse(uGridEgresos.ActiveRow.Cells["Id"].Value.ToString());
                    if (id > 0)
                    {
                        NCaja.eliminar_egreso(id);
                        cargar_egresos();
                    }
                }
            }
        } 
        private void nudMontoIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }   

        private void nudCantidadEfectivoMoneda1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void nudCantidadEfectivoMoneda4_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda5_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoMoneda6_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudMontoFaltante_ValueChanged(object sender, EventArgs e)
        {

        }    
        private void nudCantidadEfectivoBillete1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete3_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete4_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete5_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete6_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudCantidadEfectivoBillete7_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void lkAperturarCaja_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Caja.frmAperturaCaja frmCaja = new Caja.frmAperturaCaja();
                frmCaja.Show();
            }
            catch (Exception) { }
        } 
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            obtenerEgresos();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (nudMonto.Value<=0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Monto no ingresado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMonto.Focus();
                return;
            }
            else if  (cmbEgreso.Text.Length<=0)
                {
                MessageBox.Show("Debe ingresar el gasto.", "Gasto no ingresado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEgreso.Focus();
                return;
            }
            else if (id_apertura_caja<=0)
            {
                MessageBox.Show("No se ha aperturado la caja para cubrir el gasto.", "No se aperturo caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEgreso.Focus();
                return;
            }
            else
            {
                if ( NCaja.incluir_egreso(cGeneral.id_user_actual, id_apertura_caja, cmbEgreso.Text, nudMonto.Value, dtpHasta.Value))
                {
                    MessageBox.Show("Gasto ingresado con éxito.", "Gasto registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nudMonto.Value = 0;
                    obtenerEgresos();
                } 
                else
                {
                    MessageBox.Show("No fue posible registrar el gasto.", "Gasto no registrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            } 
        }

        private void btnExportarCtaProveedorProducto_Click(object sender, EventArgs e)
        {
            if (id_cierre_caja > 0)
            {
                print_recibo(id_cierre_caja);
            }
            else
            {
                MessageBox.Show("No se encontró un ID de cierre de caja para imprimir! ", "Imprimir cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}
