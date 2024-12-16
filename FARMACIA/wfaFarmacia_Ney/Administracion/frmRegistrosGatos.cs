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
using wfaFarmacia_Ney.Globales;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace wfaFarmacia_Ney.Administracion
{
    public partial class frmRegistrosGatos : Form
    {
        bool new_egreso = false;
        public bool accion;
        public int id_gasto;   
        
        public static frmRegistrosGatos me;
        public frmRegistrosGatos()
        {
            frmRegistrosGatos.me = this;
            InitializeComponent();
        } 

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        void click_guardar()
        {
            //try
            //{
            //    if (this.nudPrecioEspecial.Value <= 0)
            //    {
            //        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
            //        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
            //        this.ttMensaje.Show("Ingrese el precio el precio especial.", this.btnGuardar, 0, 38, 3000);
            //        this.nudPrecioEspecial.Focus();
            //        this.nudPrecioEspecial.Select(0, this.nudPrecioEspecial.Text.Length);
            //        return;
            //    }  
            //    if (accion)
            //    {
            //        DialogResult resul = MessageBox.Show("¿Desea solicitar un precio especial para el producto: " + lblNameProducto.Text+ "?" , "Confirmar Solicitud de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //        if (resul == System.Windows.Forms.DialogResult.No)
            //        { 
            //            return;
            //        }
            //        DataTable dtPro = NProductos.obtener_datos_pro(id_producto);
            //        if (dtPro.Rows.Count>0)
            //        {
            //            string id_producto =  dtPro.Rows[0]["Id"].ToString();
            //            if (NVentas.SolicitaPrecioEspecial(id_venta,id_det_venta, id_producto, nudPrecioEspecial.Value, cantidad, cGeneral.id_user_actual.ToString()) > 0)
            //            {
            //                MessageBox.Show("Se ha enviado una solicito de precio especial. El administrador aprobará este precio especial, favor notificar esta solicitud.", "Solicitud de precio especial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            if (name_ventana == 1)
            //            {
            //                frmVentas.me.txtBuscar.Enabled = true;
            //            }
            //            else if (name_ventana == 2)
            //            {
            //                frmVentas_2.me.txtBuscar.Enabled = true;
            //            }
            //            else if (name_ventana == 3)
            //            {
            //                frmVentas_3.me.txtBuscar.Enabled = true;
            //            }

            //        }
            //        else
            //        {
            //            this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
            //            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
            //            this.ttMensaje.Show("No se encontró ningun producto con el ID: " + id_producto, this.btnGuardar, 0, 38, 3000);
            //            this.nudPrecioEspecial.Focus();
            //            this.nudPrecioEspecial.Select(0, this.nudPrecioEspecial.Text.Length);
            //            return;
            //        }
 
            //    } 
                    
            //    //Ventas.frmDescuentoCombo.me.tBuscar.Enabled = false;
            //    ///Ventas.frmDescuentoCombo.me.tBuscar.Enabled = true;

            //    this.Close();
            //}
            //catch (Exception ex) { cGeneral.error(ex); }
        }
         
        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
     
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

        //private void toolStripButton4_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.gvAprobadas.Rows.Count > 0)  
        //        {
        //            DateTime start;
        //            start = DateTime.Now;
        //            TimeSpan timespan;

        //            SaveFileDialog SaveFileDialog = new SaveFileDialog();
        //            SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
        //            string sfilePath = "";
        //            if (DialogResult.OK == SaveFileDialog.ShowDialog())
        //            {
        //                sfilePath = SaveFileDialog.FileName;
        //                if (!sfilePath.EndsWith(".xls"))
        //                {
        //                    sfilePath += ".xls";
        //                }
        //            }

        //            this.ultraGridExcelExporter1.Export(this.gvAprobadas, sfilePath);

        //            System.Diagnostics.Process proceso = new System.Diagnostics.Process();

        //            //width     proceso
        //            //   .StartInfo.FileName = sfilePath
        //            //   .Start()
        //            // end 

        //            proceso.StartInfo.FileName = sfilePath;
        //            proceso.Start();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
        //    }
        //}

        //private void toolStripButton9_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.gvRechazadas.Rows.Count > 0)
        //        {
        //            DateTime start;
        //            start = DateTime.Now;
        //            TimeSpan timespan;

        //            SaveFileDialog SaveFileDialog = new SaveFileDialog();
        //            SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
        //            string sfilePath = "";
        //            if (DialogResult.OK == SaveFileDialog.ShowDialog())
        //            {
        //                sfilePath = SaveFileDialog.FileName;
        //                if (!sfilePath.EndsWith(".xls"))
        //                {
        //                    sfilePath += ".xls";
        //                }
        //            }

        //            this.ultraGridExcelExporter1.Export(this.gvRechazadas, sfilePath);

        //            System.Diagnostics.Process proceso = new System.Diagnostics.Process();

        //            //width     proceso
        //            //   .StartInfo.FileName = sfilePath
        //            //   .Start()
        //            // end 

        //            proceso.StartInfo.FileName = sfilePath;
        //            proceso.Start();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
        //    }
        //}

        //private void toolStripButton10_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.gvTodas.Rows.Count > 0)
        //        {
        //            DateTime start;
        //            start = DateTime.Now;
        //            TimeSpan timespan;

        //            SaveFileDialog SaveFileDialog = new SaveFileDialog();
        //            SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
        //            string sfilePath = "";
        //            if (DialogResult.OK == SaveFileDialog.ShowDialog())
        //            {
        //                sfilePath = SaveFileDialog.FileName;
        //                if (!sfilePath.EndsWith(".xls"))
        //                {
        //                    sfilePath += ".xls";
        //                }
        //            }

        //            this.ultraGridExcelExporter1.Export(this.gvTodas, sfilePath);

        //            System.Diagnostics.Process proceso = new System.Diagnostics.Process();

        //            //width     proceso
        //            //   .StartInfo.FileName = sfilePath
        //            //   .Start()
        //            // end 

        //            proceso.StartInfo.FileName = sfilePath;
        //            proceso.Start();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
        //    }
        //}

        //private void frmPrecioEspecial_Load(object sender, EventArgs e)
        //{

        //    gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtFinPendiente.Value, dtFinPendiente.Value);
        //    gvAprobadas.DataSource = null;
        //    gvRechazadas.DataSource = null;
        //    gvTodas.DataSource = null;

        //}
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

        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{
        //    gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
        //}

        //private void dtInifioPendiente_ValueChanged(object sender, EventArgs e)
        //{
        //    gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
        //}

        //private void dtFinPendiente_ValueChanged(object sender, EventArgs e)
        //{
        //    gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
        //}

        //private void toolStripButton11_Click(object sender, EventArgs e)
        //{
        //    gvAprobadas.DataSource = CargarSolicitudPrecioEspecial("Aprobada", dtInicioAprobada.Value, dtFinAprobada.Value);
        //}

        //private void dtInicioAprobada_ValueChanged(object sender, EventArgs e)
        //{
        //    gvAprobadas.DataSource = CargarSolicitudPrecioEspecial("Aprobada", dtInicioAprobada.Value, dtFinAprobada.Value);
        //}

        //private void dtFinAprobada_ValueChanged(object sender, EventArgs e)
        //{
        //    gvAprobadas.DataSource = CargarSolicitudPrecioEspecial("Aprobada", dtInicioAprobada.Value, dtFinAprobada.Value);
        //}

        //private void toolStripButton19_Click(object sender, EventArgs e)
        //{
        //    gvRechazadas.DataSource = CargarSolicitudPrecioEspecial("Rechazada", dtInicioRechazada.Value, dtFinRechazada.Value);
        //}

        //private void dtInicioRechazada_ValueChanged(object sender, EventArgs e)
        //{
        //    gvRechazadas.DataSource = CargarSolicitudPrecioEspecial("Rechazada", dtInicioRechazada.Value, dtFinRechazada.Value);
        //}

        //private void dtFinRechazada_ValueChanged(object sender, EventArgs e)
        //{
        //    gvRechazadas.DataSource = CargarSolicitudPrecioEspecial("Rechazada", dtInicioRechazada.Value, dtFinRechazada.Value);
        //}

        //private void toolStripButton27_Click(object sender, EventArgs e)
        //{
        //    gvTodas.DataSource = CargarSolicitudPrecioEspecial("Todos", dtInicioTodas.Value, dtFinTodas.Value);
        //}

        //private void dtInicioTodas_ValueChanged(object sender, EventArgs e)
        //{
        //    gvTodas.DataSource = CargarSolicitudPrecioEspecial("Todos", dtInicioTodas.Value, dtFinTodas.Value);
        //}

        //private void dtFinTodas_ValueChanged(object sender, EventArgs e)
        //{
        //    gvTodas.DataSource = CargarSolicitudPrecioEspecial("Todos", dtInicioTodas.Value, dtFinTodas.Value);
        //}

        

        private void frmDescuentoLinea_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cargarCatGastos();
            this.cmbGasto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
        }
        private void ListaGastos()
        {
            try
            {
                cmbGasto.DataSource = NAdministracion.Lista_Cat_Gastos();
                cmbGasto.ValueMember = "ID";
                cmbGasto.DisplayMember = "DESCRIPCION";
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargarCatGastos()
        {

            try
            {
                bsGastos.DataSource = gvGastos.DataSource = NAdministracion.Cargar_Registro_Gastos();
                nvGastos.BindingSource = bsGastos;
                gvGastos.DataSource = bsGastos;
            }
            catch (Exception)  {  }
        }
        private void tlRefrescar_Click(object sender, EventArgs e)
        {
            cargarCatGastos();
        }  

        private void tlExpotarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvGastos.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.gvGastos, sfilePath);

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

        private void dbNuevoDescuento_Click(object sender, EventArgs e)
        {
            if (gvGastos.Rows.Count>0)
            {
                try
                {
                   
                    Descuentos.frmAgregarDescuentoLinea frm = new Descuentos.frmAgregarDescuentoLinea();
                    frm.lblID.Text = this.gvGastos.Selected.Rows[0].Cells[0].Value.ToString();
                    frm.txtDescripcion.Text = this.gvGastos.Selected.Rows[0].Cells[1].Value.ToString();
                    frm.nudPorcentaje.Value =   decimal.Parse(this.gvGastos.Selected.Rows[0].Cells[2].Value.ToString());
                    frm.dtpFechaInicio.Value = DateTime.Parse(this.gvGastos.Selected.Rows[0].Cells[3].Value.ToString());
                    frm.dtpFechaFin.Value = DateTime.Parse(this.gvGastos.Selected.Rows[0].Cells[4].Value.ToString());
                    frm.cbEstado.Checked = bool.Parse(this.gvGastos.Selected.Rows[0].Cells[6].Value.ToString());
                    frm.ShowDialog();
                }
                catch (Exception)   { MessageBox.Show("Seleccione un registro", "Aviso de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);  }
               
            } 
        }

        private void dbNuevoDescuento_Click_1(object sender, EventArgs e)
        {
            ListaGastos();
            new_egreso = true;
            nudMonto.Value = 0;
            utfrmGastos.Visible = true;
            dtpFecha.Value = System.DateTime.Now;
            //bsGastos.AddNew();
        }
          
        private void tlEliminarDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvGastos.Rows.Count>0)
                {
                    DialogResult resul = MessageBox.Show("¿Desea eliminar el registro de gasto: " + this.gvGastos.Selected.Rows[0].Cells[1].Value.ToString() + "?", "Confirmar eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    if (NAdministracion.Eliminar_Cat_Gastos(this.gvGastos.Selected.Rows[0].Cells[0].Value.ToString(), false,cGeneral.name_user))
                    {
                        MessageBox.Show("Registro de gasto eliminado con éxito. ", "Registro de gastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tlRefrescar_Click(null, null);
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Seleccione un registro", "Aviso de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void gvGastos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Bands[0].Columns["DESCRIPCION"].Width = 350;
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            utfrmGastos.Visible = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
           
            if (this.cmbGasto.Items.Count == 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Seleccione el tipo de gasto", this.btnGuardar, 0, 38, 3000);
                this.cmbGasto.Focus();
                return;
            }
            try
            {
                if (NAdministracion.buscar_tipo_gasto(Int32.Parse(this.cmbGasto.Value.ToString()).ToString()) <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el tipo de gasto", this.btnGuardar, 0, 38, 3000);
                    this.cmbGasto.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Seleccione el tipo de gasto", this.btnGuardar, 0, 38, 3000);
                this.cmbGasto.Focus();
                return;
            }
            if (this.nudMonto.Value == 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese el monto del gasto", this.btnGuardar, 0, 38, 3000);
                this.nudMonto.Focus();
                this.nudMonto.Select(0, this.nudMonto.Text.Length);
                return;
            } 
            if (new_egreso)
            {
                bool result =  NAdministracion.Agregar_Registro_Gastos(Convert.ToInt32(this.cmbGasto.Value),nudMonto.Value,dtpFecha.Value, cGeneral.name_user);
                if (result)
                {
                    MessageBox.Show("Registro de gastos agregado con éxito!.", "Gastos de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarCatGastos();
                    utfrmGastos.Visible = false;
                } 
            } 
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click_1(null,null);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        { 
            if (gvGastos.Rows.Count > 0)
            {
                try
                { 
                    id_gasto = int.Parse(this.gvGastos.Selected.Rows[0].Cells[0].Value.ToString());
                    ////txtDescripcion.Text = this.gvGastos.Selected.Rows[0].Cells[1].Value.ToString();
                    utfrmGastos.Visible = true;
                }
                catch (Exception) { MessageBox.Show("Seleccione un registro", "Aviso de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            }
        }


        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvPendiente.Rows.Count > 0)
        //        {
        //            string nameProducto = this.gvPendiente.Selected.Rows[0].Cells[2].Value.ToString(),id_producto ="";
        //            decimal precio = 0,cantidad=0;
        //            int id_precio_especial = 0,id_venta =0;
        //            try
        //            {
        //                precio = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[5].Value.ToString());
        //            }
        //            catch (Exception) { }
        //            try
        //            {
        //                cantidad = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[4].Value.ToString());
        //            }
        //            catch (Exception) { }
        //            try
        //            {
        //                id_precio_especial = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[0].Value.ToString());
        //            }
        //            catch (Exception) { }
        //            try
        //            {
        //                id_venta = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[6].Value.ToString());
        //            }
        //            catch (Exception) { }

        //            try
        //            {
        //                id_producto = this.gvPendiente.Selected.Rows[0].Cells[3].Value.ToString();
        //            }
        //            catch (Exception) { }

        //            if (id_precio_especial <= 0)
        //            {
        //                MessageBox.Show("Seleccione el precio especial que requiera para aprobar.", "Seleccione precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            DialogResult resul = MessageBox.Show("¿Desea aprobar el precio: " + precio + " especial para el producto: " + nameProducto + "?", "Confirmar aprobación de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //            if (resul == System.Windows.Forms.DialogResult.No)
        //            {
        //                return;
        //            }
        //            NVentas.ApruebaRechazaPrecioEspecial(id_venta,id_precio_especial, precio,cantidad, id_producto, "Aprobada", cGeneral.id_user_actual.ToString());
        //            MessageBox.Show("Precio aprobado con éxito!", "Aprobado de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
        //        }
        //    }
        //    catch (Exception) {   }

        //}

        //private void toolStripButton2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvPendiente.Rows.Count > 0)
        //        {
        //            string nameProducto = this.gvPendiente.Selected.Rows[0].Cells[2].Value.ToString();
        //            decimal precio = 0;
        //            int id_precio_especial = 0;
        //            try
        //            {
        //                precio = decimal.Parse(this.gvPendiente.Selected.Rows[0].Cells[5].Value.ToString());
        //            }
        //            catch (Exception) { }
        //            try
        //            {
        //                id_precio_especial = int.Parse(this.gvPendiente.Selected.Rows[0].Cells[0].Value.ToString());
        //            }
        //            catch (Exception) { }

        //            if (id_precio_especial <= 0)
        //            {
        //                MessageBox.Show("Seleccione el precio especial que requiere rechazar.", "Seleccione precio especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            DialogResult resul = MessageBox.Show("¿Desea rechazar el precio: " + precio + " especial para el producto: " + nameProducto + "?", "Confirmar aprobación de Precio Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //            if (resul == System.Windows.Forms.DialogResult.No)
        //            {
        //                return;
        //            }
        //            NVentas.ApruebaRechazaPrecioEspecial(0,id_precio_especial,0,0,"", "Rechazada", cGeneral.id_user_actual.ToString());
        //            MessageBox.Show("Precio rechazado con éxito!", "Rechazo de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            gvPendiente.DataSource = CargarSolicitudPrecioEspecial("Pendiente", dtInifioPendiente.Value, dtFinPendiente.Value);
        //        }
        //    }
        //    catch (Exception)  {   } 
        //}

        private void nudPrecioEspecial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                click_guardar();
            }
          
        }

        private void frmDescuentoCombo_Acciones_Load(object sender, EventArgs e)
        {
            ///lblID.Text = id_combo;
            ///this.txtDescripcion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }

        private void gvGastos_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //toolStripButton1_Click(null, null);
        }

        private void tlActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvGastos.Rows.Count > 0)
                {
                    DialogResult resul = MessageBox.Show("¿Desea activar el Catálogo de gastos?: " + this.gvGastos.Selected.Rows[0].Cells[1].Value.ToString() + "?", "Confirmar eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    if (NAdministracion.Eliminar_Activar_Cat_Gastos(this.gvGastos.Selected.Rows[0].Cells[0].Value.ToString(),true))
                    {
                        MessageBox.Show("Catálogo de gasto activo con éxito. ", "Catálogo de gastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tlRefrescar_Click(null, null);
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Seleccione un registro", "Aviso de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void gvGastos_BeforeRowActivate(object sender, RowEventArgs e)
        {
            try
            {
                bool activa = Boolean.Parse(e.Row.Cells["Estado"].Value.ToString());
                if (activa)
                {
                    tlEliminarDescuento.Enabled = true;
                }
                else { tlEliminarDescuento.Enabled = false; }
            }
            catch (Exception)  {   }
           
        }
    }
}
