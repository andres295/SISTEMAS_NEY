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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace SCM.Ventas
{
    public partial class frmPrecioEspecial : Form
    {
        public bool accion;
        public string id_combo;
        public int id_venta =0,id_det_venta=0, name_ventana=0;
        public string id_producto = "";
        public decimal cantidad = 0;

        public frmPrecioEspecial()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
         
        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvPendiente.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.gvPendiente, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }
         
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvAprobadas.Rows.Count > 0)  
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

                    this.ultraGridExcelExporter1.Export(this.gvAprobadas, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvRechazadas.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.gvRechazadas, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvTodas.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.gvTodas, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();

                    //width     proceso
                    //   .StartInfo.FileName = sfilePath
                    //   .Start()
                    // end 

                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void frmPrecioEspecial_Load(object sender, EventArgs e)
        {
            cargarPrecioPendiente();
            gvAprobadas.DataSource = null;
            gvRechazadas.DataSource = null;
            gvTodas.DataSource = null;
        }

        private void cargarPrecioPendiente()
        {
            try
            {
                bindingSource1.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
                nvPendientes.BindingSource = bindingSource1;
                gvPendiente.DataSource = bindingSource1; 
            }
            catch (Exception)  {   }
        }
        private void cargarPrecioAprobadas()
        {
            try
            {
                bindingSource2.DataSource = CargarSolicitudPrecioEspecial("Aprobada", dtInicioAprobada.Value, dtFinAprobada.Value);
                nvAprobadas.BindingSource = bindingSource2;
                gvAprobadas.DataSource = bindingSource2; 
            }
            catch (Exception) { }
        }
        private void cargarPrecioRechazadas()
        {
            try
            {
                bindingSource3.DataSource = CargarSolicitudPrecioEspecial("Rechazada", dtInicioRechazada.Value, dtFinRechazada.Value);
                nvRechazadas.BindingSource = bindingSource3;
                gvRechazadas.DataSource = bindingSource3;
            }
            catch (Exception) { }
        }
        private void cargarPrecioTodas()
        {
            try
            {
                bindingSource4.DataSource = CargarSolicitudPrecioEspecial("Todos", dtInicioTodas.Value, dtFinTodas.Value);
                nvTodas.BindingSource = bindingSource4;
                gvTodas.DataSource = bindingSource4;
            }
            catch (Exception) { }
        } 
        private DataTable CargarSolicitudPrecioEspecial(string estado, DateTime dtInicio, DateTime dtFin)
        {
            DataTable dtTable = new DataTable();
            try
            {
                dtTable = NVentas.Obtener_Solicitud_Precio_Especial(estado, dtInicio, dtFin);
                return dtTable;
            }
            catch (Exception)  { return dtTable;  } 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            cargarPrecioPendiente();
        }

        private void dtInifioPendiente_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioPendiente();
        }

        private void dtFinPendiente_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioPendiente();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            cargarPrecioAprobadas();
        }

        private void dtInicioAprobada_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioAprobadas();
        }

        private void dtFinAprobada_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioAprobadas();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            cargarPrecioRechazadas();
        }

        private void dtInicioRechazada_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioRechazadas();
        }

        private void dtFinRechazada_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioRechazadas();
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            cargarPrecioTodas();
        }

        private void dtInicioTodas_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioTodas();
        }

        private void dtFinTodas_ValueChanged(object sender, EventArgs e)
        {
            cargarPrecioTodas();
        }

        private void gvPendiente_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            {
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
            catch (Exception)  {   }
        }

        private void gvAprobadas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
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

        private void gvRechazadas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
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

        private void gvTodas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPendiente.Rows.Count > 0)
                {
                    string nameProducto = this.gvPendiente.Selected.Rows[0].Cells[2].Value.ToString(),id_producto ="";
                    decimal precio = 0,cantidad=0;
                    int id_precio_especial = 0,id_venta =0;
                    try
                    {
                        precio = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[5].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cantidad = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[4].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        id_precio_especial = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[0].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        id_venta = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[6].Value.ToString());
                    }
                    catch (Exception) { }

                    try
                    {
                        id_producto = this.gvPendiente.Selected.Rows[0].Cells[3].Value.ToString();
                    }
                    catch (Exception) { }

                    if (id_precio_especial <= 0)
                    {
                        MessageBox.Show("Seleccione el precio especial que requiera para aprobar.", "Seleccione precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult resul = MessageBox.Show("¿Desea aprobar el precio: " + precio + " especial para el producto: " + nameProducto + "?", "Confirmar aprobación de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    NVentas.ApruebaRechazaPrecioEspecial(id_venta,id_precio_especial, precio,cantidad, id_producto, "Aprobada", cGeneral.id_user_actual.ToString());
                    MessageBox.Show("Precio aprobado con éxito!", "Aprobado de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
                }
            }
            catch (Exception) {   }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPendiente.Rows.Count > 0)
                {
                    string nameProducto = this.gvPendiente.Selected.Rows[0].Cells[2].Value.ToString();
                    decimal precio = 0;
                    int id_precio_especial = 0;
                    try
                    {
                        precio = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[5].Value.ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        id_precio_especial = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[0].Value.ToString());
                    }
                    catch (Exception) { }

                    if (id_precio_especial <= 0)
                    {
                        MessageBox.Show("Seleccione el precio especial que requiere rechazar.", "Seleccione precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult resul = MessageBox.Show("¿Desea rechazar el precio: " + precio + " especial para el producto: " + nameProducto + "?", "Confirmar aprobación de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    NVentas.ApruebaRechazaPrecioEspecial(0,id_precio_especial,0,0,"", "Rechazada", cGeneral.id_user_actual.ToString());
                    MessageBox.Show("Precio rechazado con éxito!", "Rechazo de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
                }
            }
            catch (Exception)  {   } 
        }

        private void nudPrecioEspecial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
            }
          
        }

        private void frmDescuentoCombo_Acciones_Load(object sender, EventArgs e)
        {
            ///lblID.Text = id_combo;
            ///this.txtDescripcion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        } 
    }
}
