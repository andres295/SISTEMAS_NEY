using CapaNegocios;
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
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid; 

namespace SCM.Facturacion
{
    public partial class frmFacturas : Form
    {
        public static frmFacturas me;

        public frmFacturas()
        {
            frmFacturas.me = this;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Facturacion.frmFacturaServicio_Acciones   frm = new Facturacion.frmFacturaServicio_Acciones();
                ///frm.Text = "AGREGAR FACTURA";
                frm.accion = false; 
                frm.cmbDoctor.DataSource = NEspecialista.lista_combo();
                frm.cmbDoctor.ValueMember = "Id";
                frm.cmbDoctor.DisplayMember = "Doctor";
                 
                ///frm.cbInactiva.Enabled = false; 
                frm.id_factura = 0;  

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        } 
        private void frmServicio_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
               //// est.grid_selfull_con_alter(this.dgvServicios);
                est.SetDoubleBuffered(this.dgvServicios);

                this.tBuscar.Interval = cGeneral.timer;
                this.txtRegistros.Text = NFactura.num_reg().ToString("N0");

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                //else
                //    this.btnAgregar.Focus();
                dtpDesde.Value = System.DateTime.Now.AddDays(-7);
            }
            catch(Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                    else
                        this.txtBuscar.Text = "";
                }
                else if (e.KeyValue == 40)
                {
                    if (this.dgvServicios.Rows.Count > 0)
                        this.dgvServicios.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvServicio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),cbAnuladas.Checked == true?false:true);
                    this.txtBuscar.Text = "";
                    //// this.btnAgregar.Enabled = true;
                    this.btnVer.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.txtBuscar.Focus();
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvServicio_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                    {
                        this.txtBuscar.Focus();
                    }
                      
                    //else
                    //    this.btnAgregar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.TextLength);
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvServicios.Rows.Count == 0)
                {
                    //if (this.txtBuscar.Enabled == false)
                    //{
                    //    this.btnAgregar.Focus();
                    //}
                }
                else
                    this.dgvServicios.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                if (Convert.ToBoolean(this.dgvServicios.ActiveRow.Cells["Estado"].Value.ToString()))
                {
                    DialogResult result = MessageBox.Show("Estás seguro(a) de ANULAR ésta factura.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NFactura.eliminar(Convert.ToInt32(this.dgvServicios.ActiveRow.Cells[0].Value.ToString())))
                        {
                            ///this.dgvServicios.Rows.Remove(this.dgvServicios.CurrentRow);
                            this.txtRegistros.Text = NFactura.num_reg().ToString("N0");

                            if (this.txtRegistros.Text == "0")
                            {
                                ///this.btnAgregar.Enabled = true;
                                this.btnVer.Enabled = false;
                                this.btnEliminar.Enabled = false;
                                this.txtBuscar.Enabled = false;
                                this.txtBuscar.Text = "";
                                ///this.btnAgregar.Focus();
                            }
                            else
                            {
                                ///this.dgvServicios.Rows[this.dgvServicios.CurrentRow.Index].Selected = true;
                                this.dgvServicios.Focus();
                            }
                            MessageBox.Show("Factura anulada con éxito!", "Anular factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBuscar_TextChanged(null, null);
                        }
                    }
                    else
                        this.dgvServicios.Focus();
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "ANULAR FACTURA";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No se puede ANULAR esta factura ya esta anulada.", this.btnEliminar, 0, 38, 3000);
                    return;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.dgvServicios.DataSource = NFactura.buscar("", Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),cbAnuladas.Checked == true?false:true);

                    ///this.btnAgregar.Enabled = true;
                    this.btnVer.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvServicios.DataSource = NFactura.buscar(this.txtBuscar.Text, Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value),cbAnuladas.Checked == true ? false : true);
              
                if (this.dgvServicios.Rows.Count == 0)
                {
                    this.btnVer.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.btnVer.Enabled = true;
                    this.btnEliminar.Enabled = true;
                }
                
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el cliente de la factura.", this.txtBuscar, 0, 26);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void dgvServicio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //    this.dgvServicios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //    this.dgvServicios.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //    this.dgvServicios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    this.dgvServicios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    this.dgvServicios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    this.dgvServicios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    this.dgvServicios.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    this.dgvServicios.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //    //this.dgvServicios.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    //this.dgvServicios.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //    this.dgvServicios.Columns[2].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
            //    this.dgvServicios.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
            //    this.dgvServicios.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
            //    this.dgvServicios.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";

            //    this.dgvServicios.Columns[0].Frozen = true;
            //    this.dgvServicios.Columns[1].Frozen = true;

            //    this.dgvServicios.ScrollBars = ScrollBars.Both;
            //}
            //catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }
        public void print_factura()
        {
            try
            {
                if (this.dgvServicios.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("¿Desea imprimir la factura?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvServicios.Focus();
                        return;
                    }

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("nueva_venta_cotizacion_servicio");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.desde = 1;
                    frmReporte.hasta = cGeneral.numItem;
                    frmReporte.print_pago = "NO";
                    frmReporte.id_cliente = this.dgvServicios.ActiveRow.Cells[11].Value.ToString();
                    frmReporte.tipoVenta = "2";
                    frmReporte.num_factura = this.dgvServicios.ActiveRow.Cells[0].Value.ToString();
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void btnPrintVenta_Click(object sender, EventArgs e)
        {
            print_factura();
        }
        
        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cbAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(null, null);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Facturacion.frmFacturaServicio_Acciones frm = new Facturacion.frmFacturaServicio_Acciones();
                frm.Text = "FACTURA DE SERVICIOS MÉDICOS#: " + this.dgvServicios.ActiveRow.Cells[0].Value.ToString();
                frm.accion = true;
                frm.btnGuardar.Enabled = false;
                frm.btnEliminarServicio.Enabled = false;
                frm.btnAgregarServicio.Enabled = false;
                ///frm.cbTipoFact.Enabled = false;

                DataTable dt_datos = new DataTable();
                dt_datos = NFactura.obtener_datos(Convert.ToInt32(this.dgvServicios.ActiveRow.Cells[0].Value));

                if (dt_datos.Rows.Count > 0)
                {
                    frm.id_factura = Convert.ToInt32(this.dgvServicios.ActiveRow.Cells[0].Value.ToString());
                    frm.txtNumVenta.Text = this.dgvServicios.ActiveRow.Cells[0].Value.ToString();


                    frm.cmbDoctor.DataSource = NEspecialista.lista_combo_by_estado(true);
                    frm.cmbDoctor.ValueMember = "Id";
                    frm.cmbDoctor.DisplayMember = "Doctor"; 
                    frm.cmbDoctor.Value = this.dgvServicios.ActiveRow.Cells[0].Value.ToString();

                    ///frm.lblDescuento.Text = dt_datos.Rows[0].ItemArray[6].ToString();

                    frm.dgvServiciosFacturar.DataSource = NFactura.Obtener_servicio_tem(this.dgvServicios.ActiveRow.Cells[0].Value.ToString(), cGeneral.id_user_actual.ToString());

                    //if (!bool.Parse(dt_datos.Rows[0].ItemArray[5].ToString()))
                    //{
                        frm.btnAgregarCliente.Enabled = false;
                        frm.btnModificarCliente.Enabled = false;
                        frm.btnEliminarFactura.Enabled = false;

                        frm.btnGuardar.Enabled = false;
                        frm.btnModificarServicio.Enabled = false;
                        frm.btnAgregarServicio.Enabled = false;
                        frm.btnEliminarServicio.Enabled = false;
                    //}

                }
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.dgvServicios, sfilePath);

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

        private void dgvServicios_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].Width = 70;
            e.Layout.Bands[0].Columns[1].Width = 250;
            e.Layout.Bands[0].Columns[2].Width = 100;
            e.Layout.Bands[0].Columns[3].Width = 70;
            e.Layout.Bands[0].Columns[4].Width = 70;
            e.Layout.Bands[0].Columns[5].Width = 100;

            e.Layout.Bands[0].Columns[0].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[1].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = HAlign.Left;
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Left;
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Left;


            e.Layout.Bands[0].Columns[2].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[2].CellAppearance.ForeColor = Color.Red;

            e.Layout.Bands[0].Columns[3].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[3].CellAppearance.ForeColor = Color.Red;

            e.Layout.Bands[0].Columns[4].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[4].CellAppearance.ForeColor = Color.Red;

            e.Layout.Bands[0].Columns[5].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Columns[5].CellAppearance.ForeColor = Color.Red;

            e.Layout.Bands[0].Columns[6].Format = "###,###,##0.00";
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
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

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void btnPrintTickets_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("¿Desea imprimir el tickets?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvServicios.Focus();
                        return;
                    }

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("recibo_tickets_servicio"); 
                    frmReporte.num_factura = this.dgvServicios.ActiveRow.Cells[0].Value.ToString();
                    frmReporte.num_factura = this.dgvServicios.ActiveRow.Cells[0].Value.ToString();
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
