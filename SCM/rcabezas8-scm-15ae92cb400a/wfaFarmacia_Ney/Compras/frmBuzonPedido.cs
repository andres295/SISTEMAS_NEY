using CapaNegocios; 
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.Compras
{
    public partial class frmBuzonPedido : Form
    {
        public static frmBuzonPedido me;

        public frmBuzonPedido()
        {
            frmBuzonPedido.me = this;
            InitializeComponent();
        }

        ////dcDatosDataContext bd = new dcDatosDataContext();
        int number = 1, tamaño = 0;

        public class campos
        {
            public string id { get; set; }
            public string prod { get; set; }
            public string pres { get; set; }
            public string prov { get; set; }
            public decimal pvf { get; set; }
            public decimal pvp { get; set; }
            public string disp { get; set; }
            public string est { get; set; }
        }  
        private void Cargar_Buzon()
        {
            try
            {

                ///pProces.Visible = true;
                this.tBuscar.Enabled = false;
                number = 1;
                 
                this.uGridProducto.DataSource = NBuzonPedido.obtener_datos(dtpDesde.Value,dtpHasta.Value);
                this.uGridProducto.Refresh();

                if (this.uGridProducto.Rows.Count == 0)
                { 
                    this.btnEliminar.Enabled = false; 
                    return;
                } 

                if (this.txtBuscarProducto.Text == "")
                    this.btnAgregar.Enabled = true;
                else
                    this.btnAgregar.Enabled = false;

                ///this.btnModificar.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.txtBuscarProducto.Focus();
               /// pProces.Visible = false;
            }
            catch (Exception ex) {
               //// pProces.Visible = false;
                cGeneral.error(ex);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductos_Acciones frm = new frmProductos_Acciones();
                frm.Text = "AGREGAR";
                frm.accion = true;
                frm.idProducto = "999999999";

                frm.cmbPresentacion.DataSource = NPresentaciones.lista_combo();
                frm.cmbPresentacion.ValueMember = "Id";
                frm.cmbPresentacion.DisplayMember = "Presentacion";

                frm.cmbProveedor.DataSource = NProveedores.lista_combo();
                frm.cmbProveedor.ValueMember = "Id";
                frm.cmbProveedor.DisplayMember = "Proveedor";

                frm.cmbEspecificacion.DataSource = NEspecificacion.lista_combo();
                frm.cmbEspecificacion.ValueMember = "Id";
                frm.cmbEspecificacion.DisplayMember = "Especificacion";

                frm.dtpVencimiento.Value = DateTime.Now.Date.AddDays(60);
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        } 
        private void CargarProveedor()
        {
            try
            {
               DataTable dtProveedor = NProveedores.lista_combo();

                var row = dtProveedor.NewRow();
                row["Id"] = "0";
                row["Proveedor"] = "Todos";
                dtProveedor.Rows.InsertAt(row, 0);

                cmbProveedor.DataSource = dtProveedor;
                cmbProveedor.ValueMember = "Id";
                cmbProveedor.DisplayMember = "Proveedor";

                cmbProveedor.Text = "Todos";
            }
            catch (Exception) {  }
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscarProducto.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
              
                this.tBuscar.Interval = cGeneral.timer;
                this.uGridProducto.DataSource = NBuzonPedido.obtener_datos(dtpDesde.Value,dtpHasta.Value);

                if (uGridProducto.Rows.Count > 0)
                {
                    //btnExportar.Enabled = true;
                    //btnVer.Enabled = true;
                    btnEliminar.Enabled = true;
                    //txtBuscarProducto.Enabled = true;
                    ///txtBuscarProveedor.Enabled = true;
                }
                else
                {
                    //btnExportar.Enabled = false;
                    //btnVer.Enabled = false;
                    btnEliminar.Enabled = false;
                    //txtBuscarProducto.Enabled = false;
                    ///txtBuscarProveedor.Enabled = false;
                }

                this.txtRegistros.Text = uGridProducto.Rows.Count().ToString("N0");
 
                if (this.txtRegistros.Text != "0")
                {
                    //this.txtBuscarProducto.Enabled = true;
                    ///this.txtBuscarProveedor.Enabled = true;
                }

                CargarProveedor();
                this.cmbProveedor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        } 

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste producto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.uGridProducto.Focus();
                    return;
                }

               /// NBuzonPedido.eliminar_prod(this.uGridProducto.ActiveRow.Cells[0].Value.ToString());
               /// this.uGridProducto.Rows.re(this.uGridProducto.ActiveRow);
                this.txtRegistros.Text = NProductos.num_reg().ToString("N0");

                if (this.txtRegistros.Text == "0")
                {
                    this.txtBuscarProducto.Text = "";
                    this.cmbProveedor.Text = "";
                    //this.txtBuscarProducto.Enabled = false;
                    //this.cmbProveedor.Enabled = false;
                    //this.btnAgregar.Enabled = true;
                    ///this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    //this.btnAgregar.Focus();
                }
                else
                {
                    this.uGridProducto.Rows[this.uGridProducto.ActiveRow.Index].Selected = true;

                    if (this.uGridProducto.Rows.Count > 0)
                    {
                        uGridProducto.Focus();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        } 
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        buscar();

                    }
                    catch (Exception ex) { cGeneral.error(ex); }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        } 
        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.txtBuscarProducto.Text = "";
                    this.txtBuscarProducto.Focus();
                }
                else if (e.KeyValue == 46)
                {
                    if (this.uGridProducto.Rows.Count > 0)
                        click_eliminar();
                }
                else if (e.KeyValue == 255 || e.KeyValue == 173)
                {
                    if (this.uGridProducto.Rows.Count > 0)
                    {
                        Productos.frmDetProducto frm = new Productos.frmDetProducto();
                        frm.idProducto = this.uGridProducto.ActiveRow.Cells[0].Value.ToString();
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }  
        private void uGridProducto_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.00";
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
       
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridProducto.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.uGridProducto, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                     
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
                else
                {
                    this.ttMensaje.Hide(this.txtBuscarProducto);

                    this.ttMensaje.ToolTipTitle = "";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                    this.ttMensaje.ShowAlways = true;
                    this.ttMensaje.Show("No hay datos para exportar", this.btnExportar, 0, 26);
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                pnGenerandoBuzon.Visible = true; 
                pbGenerarBuzon.Value = 45;
                tBuscar.Enabled = true;
                NBuzonPedido.guardar_buzon(dtpDesde.Value, dtpHasta.Value);
                pbGenerarBuzon.Value = 60;
                this.uGridProducto.DataSource = NBuzonPedido.obtener_datos(dtpDesde.Value, dtpHasta.Value);
                this.txtRegistros.Text = uGridProducto.Rows.Count().ToString("N0");
                pbGenerarBuzon.Value = 100;
                txtBuscarProducto.Text = "";
                cmbProveedor.Text = "Todos";
                if (uGridProducto.Rows.Count > 0)
                { 
                    //btnExportar.Enabled = true;
                    //btnVer.Enabled = true;
                    btnEliminar.Enabled = true;
                    //txtBuscarProducto.Enabled = true;
                    ///txtBuscarProveedor.Enabled = true;
                }
                else
                {
                    //btnExportar.Enabled = false;
                    //btnVer.Enabled = false;
                    btnEliminar.Enabled = false;
                    //txtBuscarProducto.Enabled = false;
                    ///txtBuscarProveedor.Enabled = false;
                }
                 
                //this.ttMensaje.ToolTipTitle = "Buzón de Pedido";
                //this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //this.ttMensaje.Show("Buzón de pedido fue generado.", this.btnAgregar, 0, 26);

                tBuscar.Enabled = false;
                pnGenerandoBuzon.Visible = false; 
            }
            catch (Exception ex)  {

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnGenerandoBuzon.Visible = false;
                pbGenerarBuzon.Value = 0;
            }

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (uGridProducto.Rows.Count>0)
            {
                NBuzonPedido.eliminar_buzon(uGridProducto.ActiveRow.Cells[0].Value.ToString());
                this.uGridProducto.DataSource = NBuzonPedido.obtener_datos(dtpDesde.Value, dtpHasta.Value);
                this.txtRegistros.Text = uGridProducto.Rows.Count().ToString("N0");

                if (uGridProducto.Rows.Count > 0)
                {
                    //btnExportar.Enabled = true;
                    //btnVer.Enabled = true;
                    btnEliminar.Enabled = true;
                    //txtBuscarProducto.Enabled = true;
                   /// txtBuscarProveedor.Enabled = true;
                }
                else
                {
                    //btnExportar.Enabled = false;
                    //btnVer.Enabled = false;
                    btnEliminar.Enabled = false;
                    //txtBuscarProducto.Enabled = false;
                    ////txtBuscarProveedor.Enabled = false;
                }
                 
                this.ttMensaje.ToolTipTitle = "Buzón de Pedido";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Buzón limpiado con éxito.", this.btnEliminar, 0, 26);
            } 
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uGridProducto.Rows.Count > 0)
                {
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("buzon_pedido");
                    frmReporte.filtro_producto_buzon = txtBuscarProducto.Text;
                    frmReporte.filtro_proveedor_buzon = cmbProveedor.Text == "Todos" || cmbProveedor.Text == "*" ? "": cmbProveedor.Text;
                    frmReporte.Show();
                }
                else
                {
                    this.ttMensaje.Hide(this.txtBuscarProducto);

                    this.ttMensaje.ToolTipTitle = "";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                    this.ttMensaje.ShowAlways = true;
                    this.ttMensaje.Show("No hay datos para imprimir", this.btnVer, 0, 26);
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }  
         
        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscarProducto);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {

        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            
        }

        private void Filtrar_Buzon (string filtroProducto,string filtroProveedor)
        {
            try
            {
                //NBuzonPedido.guardar_buzon(dtpDesde.Value, dtpHasta.Value);
                //this.tBuscar.Enabled = false;
                this.uGridProducto.DataSource = NBuzonPedido.buscar(filtroProducto ,filtroProveedor);
                this.uGridProducto.Refresh();
                this.txtRegistros.Text = uGridProducto.Rows.Count().ToString("N0");
 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void buscar()
        {
            string filtroProveedor;
            if (cmbProveedor.Text == "Todos" || cmbProveedor.Text == "*")
            {
                filtroProveedor = "";
            }
            else
            {
                filtroProveedor = cmbProveedor.Text;
            }

            Filtrar_Buzon(txtBuscarProducto.Text, filtroProveedor);
        }
    }
}
