using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM
{
    public partial class frmProductos_Acciones : Form
    {
        public static frmProductos_Acciones me;
  
        public frmProductos_Acciones()
        {
            frmProductos_Acciones.me = this;
            InitializeComponent();
        }

        public bool accion;
        public bool externalUse = false;
        public string codBarra = "";
        public string idProducto = "";
        public string desc_proveedor = "";
        public string desc_presentacion = "";
        public string desc_espeficacion = "";
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductos_Acciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtProducto.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                this.txtLote.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                this.cmbPresentacion.MaxDropDownItems = cGeneral.num_lista_cmb;
                this.cmbEspecificacion.MaxDropDownItems = cGeneral.num_lista_cmb;
                this.cmbEspecificacion.MaxDropDownItems = cGeneral.num_lista_cmb;
                this.nudPVF.DecimalPlaces = cGeneral.decimales;
                this.nudPVP.DecimalPlaces = cGeneral.decimales;
            
                if (this.accion == true)
                {
                    if (this.cmbPresentacion.Items.Count > 0)
                        this.cmbPresentacion.SelectedIndex = 0;

                    if (this.cmbProveedor.Items.Count > 0)
                        this.cmbProveedor.SelectedIndex = 0;

                    if (this.cmbEspecificacion.Items.Count > 0)
                        this.cmbEspecificacion.SelectedIndex = 0;

                    ////btnComposicionProducto.Enabled = false;
                }
                else
                {
                    cargarComposicion();
                }


                this.cmbProveedor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                this.cmbEspecificacion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
                this.cmbPresentacion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.nudPVF.Text == "")
                    this.nudPVF.Value = 0;
                else
                    this.nudPVF.Value = Convert.ToDecimal(this.nudPVF.Text);

                if (this.nudPVP.Text == "")
                    this.nudPVP.Value = 0;
                else
                    this.nudPVP.Value = Convert.ToDecimal(this.nudPVP.Text);

                if (this.nudContiene.Text == "")
                    this.nudContiene.Value = 0;
                else
                    this.nudContiene.Value = Convert.ToInt32(this.nudContiene.Text);

                if (this.cbCB.Checked == true)
                    if (this.txtCB.Text == "")
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese el código de barra", this.btnGuardar, 0, 38, 3000);
                        this.txtCB.Focus();
                        return;
                    }

                if (this.txtProducto.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el nombre del producto", this.btnGuardar, 0, 38, 3000);
                    this.txtProducto.Focus();
                    return;
                }
                else if (this.cmbPresentacion.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione la presentación", this.btnGuardar, 0, 38, 3000);
                    this.cmbPresentacion.Focus();
                    return;
                }
                else if (this.cmbEspecificacion.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione al proveedor", this.btnGuardar, 0, 38, 3000);
                    this.cmbEspecificacion.Focus();
                    return;
                }
                else if (this.nudPVF.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el P/Compra", this.btnGuardar, 0, 38, 3000);
                    this.nudPVF.Focus();
                    this.nudPVF.Select(0, this.nudPVF.Text.Length);
                    return;
                }
                else if (this.nudPVP.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el PVP", this.btnGuardar, 0, 38, 3000);
                    this.nudPVP.Focus();
                    this.nudPVP.Select(0, this.nudPVP.Text.Length);
                    return;
                }

                if (this.cbFracciones.Checked == true)
                    if (this.nudContiene.Value == 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad que contiene", this.btnGuardar, 0, 38, 3000);
                        this.nudContiene.Focus();
                        this.nudContiene.Select(0, this.nudContiene.Text.Length);
                        return;
                    }
                
                //if (this.cbVencimiento.Checked == true)
                //    if (this.dtpVencimiento.Value <= DateTime.Now.Date)
                //    {
                //        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //        this.ttMensaje.Show("Ingrese la fecha mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                //        this.dtpVencimiento.Focus();
                //        return;
                //    }
                
                //if (this.cbLote.Checked == true)
                //    if (this.txtLote.Text == "")
                //    {
                //        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //        this.ttMensaje.Show("Ingrese el lote", this.btnGuardar, 0, 38, 3000);
                //        this.txtLote.Focus();
                //        return;
                //    }
                try
                {
                    if (NPresentaciones.buscar(Int32.Parse(this.cmbPresentacion.Value.ToString()).ToString()) <= 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la presentación", this.btnGuardar, 0, 38, 3000);
                        this.cmbPresentacion.Focus();
                        return;
                    }
                }
                catch (Exception) {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la presentación", this.btnGuardar, 0, 38, 3000);
                    this.cmbPresentacion.Focus();
                    return;
                }
                try
                {
                    if (NProveedores.buscar_by_id(Int32.Parse(this.cmbProveedor.Value.ToString()).ToString()) <= 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese el proveedor", this.btnGuardar, 0, 38, 3000);
                        this.cmbProveedor.Focus();
                        return;
                    }
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el proveedor", this.btnGuardar, 0, 38, 3000);
                    this.cmbProveedor.Focus();
                    return;
                }

                try
                {
                    if (NEspecificacion.buscar_by_id(Int32.Parse(this.cmbEspecificacion.Value.ToString()).ToString()) <= 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la especificación", this.btnGuardar, 0, 38, 3000);
                        this.cmbEspecificacion.Focus();
                        return;
                    }
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la especificación", this.btnGuardar, 0, 38, 3000);
                    this.cmbEspecificacion.Focus();
                    return;
                }
                try
                {
                    if (!this.accion)
                    {
                        if (!externalUse)
                        {
                            int contiene = NProductos.obtener_cont(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                            if (contiene != nudContiene.Value)
                            {
                                int factor_restante = NProductos.obtener_cant_fracciones_restante(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                                if (factor_restante > 0)
                                {
                                    ///this.ttMensaje.ToolTipTitle = "VALIDAR DATOS";
                                    ///this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                                    ///this.ttMensaje.Show("No es posible cambiar el valor contiene ya que tiene un factor de: " + factor_restante + " fracciones disponible.", this.btnGuardar, 0, 38, 3000);
                                    MessageBox.Show("No es posible cambiar el valor contiene ya que tiene un factor de: " + factor_restante + " fracciones disponible.", "VALIDAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.nudContiene.Focus();
                                    return;
                                }
                            }
                        } 
                        else
                        {
                            int contiene = NProductos.obtener_cont(idProducto);
                            if (contiene != nudContiene.Value)
                            {
                                int factor_restante = NProductos.obtener_cant_fracciones_restante(idProducto);
                                if (factor_restante > 0)
                                {
                                    ///this.ttMensaje.ToolTipTitle = "VALIDAR DATOS";
                                    ///this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                                    ///this.ttMensaje.Show("No es posible cambiar el valor contiene ya que tiene un factor de: " + factor_restante + " fracciones disponible.", this.btnGuardar, 0, 38, 3000);
                                    MessageBox.Show("No es posible cambiar el valor contiene ya que tiene un factor de: " + factor_restante + " fracciones disponible.", "VALIDAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.nudContiene.Focus();
                                    return;
                                }
                            }
                        }
                    }
                       
                }
                catch (Exception)
                { 
                    ///this.ttMensaje.ToolTipTitle = "ERROR AL VALIDAR DATOS";
                    ///this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    ///this.ttMensaje.Show("No es posible validar la cantidad de fracciones restantes.", this.btnGuardar, 0, 38, 3000);
                    MessageBox.Show("No es posible validar la cantidad de fracciones restantes.", "ERROR AL VALIDAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.nudContiene.Focus();
                    ///return;
                    ///this.nudContiene.Focus();
                    return;
                }
                string est;

                if (this.cbEstado.Checked == true)
                    est = "ACTIVO";
                else
                    est = "NO ACTIVO";

                if (this.accion == true)
                {
                    //AGREGAR.
                    string foto_img = "";

                    if (this.cbCB.Checked == true)
                    {
                        DataTable dtPrdo = NProductos.obtener_datos(txtCB.Text);
                        if (dtPrdo.Rows.Count > 0)
                        {
                            this.ttMensaje.ToolTipTitle = "CODIGO DE BARRA EXISTENTE";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ya está registrado el código de barra: " + txtCB.Text, this.btnGuardar, 0, 38, 3000);
                            this.txtCB.Focus();
                            return;
                        }

                    }

                    if (this.pbFoto.ImageLocation != null)
                        foto_img = Path.Combine(cGeneral.ruta_guardar_img, Path.GetFileName(this.pbFoto.ImageLocation));

                    if (NProductos.guardar(this.txtCB.Text, this.txtProducto.Text, Convert.ToInt32(this.cmbPresentacion.Value), Convert.ToInt32(this.cmbProveedor.Value), this.nudPVF.Text, this.nudPVP.Text, Convert.ToInt32(this.nudContiene.Value), Convert.ToDateTime(this.dtpVencimiento.Value), est, this.txtLote.Text, foto_img, Convert.ToInt32(this.cmbEspecificacion.Value), 0,cbIVA.Checked, cGeneral.name_user,txtRegistroSanitario.Text))
                    {
                        if (!externalUse)
                        {
                            frmProductos.me.txtRegistros.Text = NProductos.num_reg().ToString("N0");
                            frmProductos.me.txtBuscar.Enabled = true;
                        }

                        if (this.pbFoto.ImageLocation != null)
                        {
                            Image img = Image.FromFile(this.pbFoto.ImageLocation);
                            img.Save(Path.Combine(cGeneral.ruta_guardar_img, ""), ImageFormat.Jpeg);
                        }
                        if (!externalUse)
                        {
                            this.txtCB.Text = "";
                            this.txtProducto.Text = "";
                            this.cmbPresentacion.SelectedIndex = 0;
                            this.cmbEspecificacion.SelectedIndex = 0;
                            this.nudPVF.Text = "0";
                            this.nudPVP.Text = "0";
                            this.nudContiene.Value = 0;
                            this.dtpVencimiento.Value = DateTime.Now.Date.AddDays(30);
                            this.txtLote.Text = "";
                            this.pbFoto.ImageLocation = null;
                            this.btnQuitar.Visible = false;

                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El producto ha sido guardado", this.btnGuardar, 0, 38, 3000);

                            if (this.cbCB.Checked == true)
                                this.txtCB.Focus();
                            else
                                this.txtProducto.Focus();
                        }
                        if (externalUse)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {

                    if (codBarra != txtCB.Text && txtCB.TextLength >0)
                    {
                        DataTable dtPrdo = NProductos.obtener_datos(txtCB.Text);
                        if (dtPrdo.Rows.Count > 0)
                        {
                            this.ttMensaje.ToolTipTitle = "CODIGO DE BARRA EXISTENTE";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Ya está registrado el código de barra: " + txtCB.Text, this.btnGuardar, 0, 38, 3000);
                            this.txtCB.Focus();
                            return;
                        } 
                    }
                    if (codBarra != txtCB.Text)
                    { 
                        int cantidadKardex = NProductos.valida_mov_cardex_codigo_barra(codBarra);
                        if (cantidadKardex > 0)
                        {
                            MessageBox.Show("Este producto contien: " + cantidadKardex + " movimientos de KARDEX asociado al código de barra: " + codBarra + ",por lo tanto no es posible cambiar el código de barra existente para este producto.", "MOVIMIENTOS KARDEX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtCB.Text = codBarra.Trim();
                            this.txtCB.Focus();
                            this.cbCB.Checked = false;
                            return;
                        }
                    }

                    //MODIFICAR.
                    if (this.cbEstado.Checked == true)
                        est = "ACTIVO";
                    else
                        est = "NO ACTIVO";

                    try
                    {
                        if (NProductos.modificar(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.txtCB.Text, this.txtProducto.Text, Convert.ToInt32(this.cmbPresentacion.Value), Convert.ToInt32(this.cmbProveedor.Value), this.nudPVF.Text, this.nudPVP.Text, Convert.ToInt32(this.nudContiene.Value), Convert.ToDateTime(this.dtpVencimiento.Value), est, this.txtLote.Text, Convert.ToInt32(this.cmbEspecificacion.Value), 0,cbIVA.Checked, cGeneral.name_user,txtRegistroSanitario.Text))
                        {
                            if (!externalUse)
                            {
                                if (this.txtCB.Text != "")
                                    frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value = this.txtCB.Text;

                                DataTable dt_datos = NProductos.obtener_datos(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                                if (dt_datos.Rows.Count > 0)
                                {
                                    frmProductos.me.dgvProductos.CurrentRow.Cells[6].Value = dt_datos.Rows[0].ItemArray[12].ToString();
                                }
                                frmProductos.me.dgvProductos.CurrentRow.Cells[1].Value = this.txtProducto.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[2].Value = this.cmbPresentacion.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[3].Value = this.cmbEspecificacion.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[4].Value = this.nudPVF.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[5].Value = this.nudPVP.Text;
                               
                                frmProductos.me.dgvProductos.CurrentRow.Cells[10].Value = est;

                                this.Close();
                            }
                            if (externalUse)
                            {
                                this.Close();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (NProductos.modificar(idProducto, this.txtCB.Text, this.txtProducto.Text, Convert.ToInt32(this.cmbPresentacion.Value), Convert.ToInt32(this.cmbProveedor.Value), this.nudPVF.Text, this.nudPVP.Text, Convert.ToInt32(this.nudContiene.Value), Convert.ToDateTime(this.dtpVencimiento.Value), est, this.txtLote.Text, Convert.ToInt32(this.cmbEspecificacion.Value), 0,cbIVA.Checked, cGeneral.name_user,txtRegistroSanitario.Text ))
                        {
                            if (!externalUse)
                            {
                                if (this.txtCB.Text != "")
                                    frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value = this.txtCB.Text;

                                DataTable dt_datos = NProductos.obtener_datos(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString());
                                if (dt_datos.Rows.Count > 0)
                                {
                                    frmProductos.me.dgvProductos.CurrentRow.Cells[6].Value = dt_datos.Rows[0].ItemArray[12].ToString();
                                }
                                frmProductos.me.dgvProductos.CurrentRow.Cells[1].Value = this.txtProducto.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[2].Value = this.cmbPresentacion.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[3].Value = this.cmbEspecificacion.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[4].Value = this.nudPVF.Text;
                                frmProductos.me.dgvProductos.CurrentRow.Cells[5].Value = this.nudPVP.Text;
                              
                                frmProductos.me.dgvProductos.CurrentRow.Cells[10].Value = est;

                                this.Close();
                            }
                            if (externalUse)
                            {
                                this.Close();
                            }
                        }
                    }
                   
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbPresentacion_DropDown(object sender, EventArgs e)
        {
            cargar_pres();
        }

        public void cargar_pres()
        {
            try
            {
                this.cmbPresentacion.DataSource = NPresentaciones.lista_combo();
                this.cmbPresentacion.ValueMember = "Id";
                this.cmbPresentacion.DisplayMember = "Presentacion";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbProveedor_DropDown(object sender, EventArgs e)
        {
            cargar_prov();
        }

        public void cargar_prov()
        {
            try
            {
                this.cmbEspecificacion.DataSource = NProveedores.lista_combo();
                this.cmbEspecificacion.ValueMember = "Id";
                this.cmbEspecificacion.DisplayMember = "Proveedor";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbProveedor_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                this.nudPVF.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbPresentacion_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (this.accion == true)
                    this.cmbEspecificacion.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbCB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbCB.Checked == true)
                {
                    this.txtCB.Enabled = true;
                    this.txtCB.Focus();
                }
                else
                {
                    ///this.txtCB.Text = "";
                    this.txtCB.Enabled = false;
                    this.txtProducto.Focus();
                }

                if (this.accion)
                {
                    this.txtCB.Text = "";
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbVencimiento.Checked == true)
                {
                    this.dtpVencimiento.Enabled = true;
                    this.dtpVencimiento.Value = DateTime.Now.AddDays(30);
                    this.dtpVencimiento.Focus();
                }
                else
                {
                    this.dtpVencimiento.Enabled = false;
                    this.dtpVencimiento.Value = Convert.ToDateTime("01/01/1900");
                    this.txtLote.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbLote_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbLote.Checked == true)
                {
                    this.txtLote.Enabled = true;
                    this.txtLote.Focus();
                }
                else
                {
                    this.txtLote.Text = "";
                    this.txtLote.Enabled = false;
                    this.txtProducto.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbFracciones_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbFracciones.Checked == true)
                {
                    this.nudContiene.Enabled = true;
                    this.nudContiene.Focus();
                }
                else
                {
                    this.nudContiene.Value = 0;
                    this.nudContiene.Enabled = false;
                    this.txtProducto.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudContiene_Enter(object sender, EventArgs e)
        {
            try
            {
                cGeneral.nud_entra_ent_focus(this.nudContiene);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    File.Delete(cGeneral.ruta_guardar_img + "\\" + "testpatch.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("No exite la ruta: " + cGeneral.ruta_guardar_img + " donde se almacenarán las imagenes de los productos.", "Ruta de almacenamiento de imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              

                if (this.pbFoto.ImageLocation == null)
                {
                    DialogResult result = MessageBox.Show("Desea seleccionar una foto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        this.txtProducto.Focus();
                        return;
                    }
                }

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "IMÁGENES JPG|*.JPG";
                openFileDialog1.Title = "SELECCIONE LA FOTO";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.pbFoto.ImageLocation != null)
                        try
                        {
                            File.Delete(cGeneral.ruta_guardar_img + "\\" + Path.GetFileName(this.pbFoto.ImageLocation));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No exite la ruta: " + cGeneral.ruta_guardar_img + " donde se almacenarán las imagenes de los productos.", "Ruta de almacenamiento de imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        

                    this.pbFoto.ImageLocation = openFileDialog1.FileName;

                    if (this.accion == false)
                    { 
                        try
                        {
                            Image img = Image.FromFile(this.pbFoto.ImageLocation);
                            img.Save(Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName), ImageFormat.Jpeg);
                        }
                        catch (Exception)
                        {
                            ///img.Save(Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName), ImageFormat.Jpeg);
                        }
                        
                        try
                        {
                            NProductos.actualizar_foto(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName));

                        }
                        catch (Exception)
                        {
                            NProductos.actualizar_foto(idProducto, Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName));

                        }
                    }

                    this.btnQuitar.Visible = true;
                    this.btnVer.Visible = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudPVF_Leave(object sender, EventArgs e)
        {
            try
            {
                cGeneral.nud_pierde_dec_focus(this.nudPVF);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudPVF_Enter(object sender, EventArgs e)
        {
            try
            {
                cGeneral.nud_entra_dec_focus(this.nudPVF);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudPVP_Leave(object sender, EventArgs e)
        {
            try
            {
                cGeneral.nud_pierde_dec_focus(this.nudPVP);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudPVP_Enter(object sender, EventArgs e)
        {
            try
            {
                cGeneral.nud_entra_dec_focus(this.nudPVP);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Estás seguro(a) de quitar la foto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    this.txtProducto.Focus();
                    return;
                }

                File.Delete(NProductos.obtener_img_prod(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()));
                NProductos.actualizar_foto(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), "");
                this.pbFoto.ImageLocation = null;
                this.btnQuitar.Visible = false;
                this.btnVer.Visible = false;
                this.txtProducto.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbEstado_CheckedChanged(object sender, EventArgs e)
        {
            this.txtProducto.Focus();
        }

        private void frmProductos_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductos);

                if (frm != null)
                    frmProductos.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnQuitar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnQuitar);
                this.ttMensaje.Show("Quitar la foto", this.btnQuitar, 0, 33, 3000);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnQuitar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnQuitar);
        }

        private void btnVer_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnVer);
                this.ttMensaje.Show("Ver la foto en tamaño original", this.btnVer, 0, 33, 3000);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.btnVer);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start(NProductos.obtener_img_prod(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()));
                Process.Start(this.pbFoto.ImageLocation);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductos_AgregarPres frm = new frmProductos_AgregarPres();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedores_Acciones frm = new frmProveedores_Acciones();
                frm.accion = true;
                frm.Text = "AGREGAR PROVEEDOR";

                frm.cmbTipoIdentificacion.DataSource = NTipoIdentificacion.obtener_datos();
                frm.cmbTipoIdentificacion.ValueMember = "Id";
                frm.cmbTipoIdentificacion.DisplayMember = "TipoIdentificacion";

                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;
                this.txtProducto.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudContiene_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudContiene);
        }

        private void nudPVF_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudPVP_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudContiene_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void cmbPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudPVF_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void nudPVP_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void nudContiene_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void dtpVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbEspecificacion_DropDown(object sender, EventArgs e)
        {
            cargar_esp();
        }

        public void cargar_esp()
        {
            try
            {
                this.cmbEspecificacion.DataSource = NEspecificacion.lista_combo();
                this.cmbEspecificacion.ValueMember = "Id";
                this.cmbEspecificacion.DisplayMember = "Especificacion";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void cargar_composicion()
        {
            try
            {
                DataTable dtComposicion   = NComposicionQuimica.cargar_cmb();
                var row = dtComposicion.NewRow();
                row["Id"] = "0";
                row["Nombre"] = "Ninguno";
                dtComposicion.Rows.InsertAt(row, 0);

       
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void cmbEspecificacion_DropDownClosed(object sender, EventArgs e)
        {
            this.nudPVF.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEspecificaciones frm = new frmEspecificaciones();
            frm.accion = true;
            frm.Text = "AGREGAR ESPECIFICACIÓN";
            frm.ShowDialog();
        }

        private void cmbComposiciónQuimica_DropDown(object sender, EventArgs e)
        {
            cargar_composicion();
        }

        private void cmbComposiciónQuimica_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }
        private void cargarComposicion()
        {
            try
            {
                try
                {
                    string composicion = NProductos.obtener_composicion_by_producto(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(),false);
                    if (composicion != "")
                    {
                        rtxtComposicion.Text = composicion;
                    }
                    else { rtxtComposicion.Enabled = false; }
                }
                catch (Exception)
                {

                    string composicion = NProductos.obtener_composicion_by_producto(idProducto,false);
                    if (composicion != "")
                    {
                        rtxtComposicion.Text = composicion;
                    }
                    else { rtxtComposicion.Enabled = false; }
                }
              
            }
            catch (Exception ex) { }
        }

        private void btnComposicionProducto_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Productos.frmComposicionQuimicaProducto frm = new Productos.frmComposicionQuimicaProducto();
                    frm.idProducto = frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.Text = "COMPOSICIÓN QUIMICA DE PRODUCTO";
                    frm.ShowDialog();
                }
                catch (Exception)
                {

                    Productos.frmComposicionQuimicaProducto frm = new Productos.frmComposicionQuimicaProducto();
                    frm.idProducto = idProducto;
                    frm.Text = "COMPOSICIÓN QUIMICA DE PRODUCTO";
                    frm.ShowDialog();
                }
               
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnRefrescarPresentacion_Click(object sender, EventArgs e)
        {
            cmbPresentacion.DataSource = NPresentaciones.lista_combo();
            cmbPresentacion.ValueMember = "Id";
            cmbPresentacion.DisplayMember = "Presentacion";
            if (!accion)
            {
                cmbPresentacion.Text = desc_presentacion;
            }
           
        }

        private void btnRefrescarProveedor_Click(object sender, EventArgs e)
        {
            cmbProveedor.DataSource = NProveedores.lista_combo();
            cmbProveedor.ValueMember = "Id";
            cmbProveedor.DisplayMember = "Proveedor";
            if (!accion)
            {
                cmbProveedor.Text = desc_proveedor;
            }
        }

        private void btnRefrescarEspecificacion_Click(object sender, EventArgs e)
        {
            cmbEspecificacion.DataSource = NEspecificacion.lista_combo();
            cmbEspecificacion.ValueMember = "Id";
            cmbEspecificacion.DisplayMember = "Especificacion";
            if (!accion)
            {
                cmbEspecificacion.Text = desc_espeficacion;
            }
        }

        private void lblHistorico_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmProductos.me.dgvProductos.Rows.Count>0)
            {
                Productos.frmBitacoraProducto frmBitacora = new Productos.frmBitacoraProducto();
                frmBitacora.idProducto = frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                frmBitacora.Show();
            } 
        }
    }
}
