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

namespace wfaFarmacia_Ney.Ventas
{
    public partial class frmPedidoProducto : Form
    {
        int id_apertura_caja = 0,id_cierre_caja=0;
        bool new_puedido = false;
        public frmPedidoProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            utfrmSolicitud.Visible = false;
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
        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            obtenerSolicitud();
            this.cmbProducto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            sumar_montos();
        }
        private void obtenerSolicitud()
        {
            try
            {
                this.uGridSolicitud.DisplayLayout.ResetBands();
                DataTable dt = NProductos.Obtener_Solicitud_by_usuario(cGeneral.id_user_actual,System.DateTime.Now,System.DateTime.Now);
                bsSolicitud.DataSource = dt;
                nvSolicitud.BindingSource = bsSolicitud;
                uGridSolicitud.DataSource = bsSolicitud;
                sumar_montos();

            }
            catch (Exception) {}
        }
         
        public void sumar_montos()
        {
            try
            {
                UltraGridBand band = this.uGridSolicitud.DisplayLayout.Bands[0];
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

                UltraGridBand band2 = this.uGridSolicitud.DisplayLayout.Bands[0];
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
         
        private void cargar_egresos()
        {
            try
            {
                DataTable dt = NCaja.obtener_egreso_caja(id_apertura_caja);
                bsSolicitud.DataSource = dt;
                nvSolicitud.BindingSource = bsSolicitud;
                uGridSolicitud.DataSource = bsSolicitud; 
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
                if (uGridSolicitud.Rows.Count > 0)
                {
                    uGridSolicitud.Refresh();
                    uGridSolicitud.Update();
                    uGridSolicitud.Rows[0].Activate();
                    uGridSolicitud.EndUpdate();
                    for (int i = 0; i < uGridSolicitud.Rows.Count; i++)
                    {
                        int id_egreso = 0;
                        decimal monto_egreso = 0;
                        DateTime fecha = System.DateTime.Now;
                        try
                        {
                          id_egreso =  int.Parse(uGridSolicitud.Rows[i].Cells[0].Value.ToString());
                        }
                        catch (Exception) {   }

                        try
                        {
                            monto_egreso = decimal.Parse(uGridSolicitud.Rows[i].Cells[2].Value.ToString());
                        }
                        catch (Exception) { }



                        if (id_egreso <= 0)
                        {
                            if (monto_egreso>0)
                            {
                                if (new_puedido)
                                {
                                    NCaja.incluir_egreso(cGeneral.id_user_actual, id_apertura_caja, uGridSolicitud.Rows[i].Cells[1].Value.ToString(), monto_egreso, fecha);
                                    update_row = true;
                                    new_puedido = false;
                                } 
                            }
                            else
                            {
                                ////uGridEgresos.Rows[i].Cells[2].Appearance.bac = Color.LightCyan;
                                uGridSolicitud.Rows[i].Cells[2].Value = 0.00;
                                uGridSolicitud.Rows[i].Cells[2].Band.Layout.Appearance.BackColor = Color.LightYellow;
                                uGridSolicitud.Rows[i].Activate();
                                MessageBox.Show("Tiene que ingresar el monto del egreso.", "Ingresar el monto del egreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                        else
                        {
                            if (!new_puedido)
                            {
                                NCaja.update_egreso(id_egreso, uGridSolicitud.Rows[i].Cells[1].Value.ToString(), monto_egreso);
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
         
        private void cargarProducto()
        {
            try
            {
                DataTable dt = NProductos.cargarCatProducto();

                if (dt.Rows.Count > 0)
                {

                    this.cmbProducto.DataSource = dt;
                    this.cmbProducto.ValueMember = "Id";
                    this.cmbProducto.DisplayMember = "Producto";

                    if (this.cmbProducto.Items.Count > 0)
                        this.cmbProducto.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            new_puedido = true;
            this.nudCantidad.Value = 0;
            this.nudMonto.Value = 0;
            utfrmSolicitud.Visible = true;
            cargarProducto();
        }
         
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (uGridSolicitud.Rows.Count > 0)
            {
                if (MessageBox.Show("Está seguro(a) de eliminar esta solicitud?.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ///string id = uGridEgresos.Selected.Rows[0].Cells["Id"].Value.ToString();
                    int id = int.Parse(uGridSolicitud.ActiveRow.Cells["IdSugerencia"].Value.ToString());
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
            obtenerSolicitud();
        }

        private void uGridSolicitud_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

        private void cmbProducto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbProducto.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el producto", this.btnGuardar, 0, 38, 3000);
                    this.cmbProducto.Focus();
                    return;
                } 
                if (new_puedido)
                {
                    bool result = NProductos.Agregar_Registro_Solicitud_Producto(this.cmbProducto.Text, nudCantidad.Value, nudMonto.Value, cGeneral.id_user_actual);
                    if (result)
                    {
                        MessageBox.Show("Registro de solicitud de producto agregado con éxito!.", "Solicitud de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obtenerSolicitud();
                        utfrmSolicitud.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible agregar el registro de solicitud de producto" + ex.Message.ToString(), "Solicitud de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        } 
    }
}
