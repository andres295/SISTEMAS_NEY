using CapaNegocios;
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

namespace SCM.Descuentos
{
    public partial class frmDescuentosCategoria : Form
    {
        public frmDescuentosCategoria()
        {
            InitializeComponent();
        }

        void proveedores_sort(int col)
        {
            this.dgvProveedores.Sort(this.dgvProveedores.Columns[col], ListSortDirection.Ascending);
        }

        void productos_sort(int col)
        {
            this.dgvProductos.Sort(this.dgvProductos.Columns[col], ListSortDirection.Ascending);
        }
        void dgvDescuentoCategoria_sort(int col)
        {
            this.dgvDescuentoCategoria.Sort(this.dgvDescuentoCategoria.Columns[col], ListSortDirection.Ascending);
        }

        private void frmDescuentos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvProveedores);
                est.grid_selfull_con_alter(this.dgvProductos);
                est.grid_selfull_con_alter(this.dgvDescuentoCategoria);
                est.SetDoubleBuffered(this.dgvProveedores);
                est.SetDoubleBuffered(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvDescuentoCategoria);

                this.tBuscar.Interval = cGeneral.timer;

                this.dtpDesde.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                this.dtpHasta.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString());

                this.dgvProveedores.DataSource = NDescuentos.buscar_prov("");
                this.proveedores_sort(1);
                this.dgvProductos.DataSource = NDescuentos.buscar_prod(0, "");
                this.productos_sort(1);
                this.dgvDescuentoCategoria.DataSource = NDescuentos.buscar_descuento_by_producto("0");
                this.dgvDescuentoCategoria_sort(1);

                cGeneral.ajuste_columnas(this.dgvProductos);
                cGeneral.ajuste_columnas(this.dgvProveedores);
                cGeneral.ajuste_columnas(this.dgvDescuentoCategoria);
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvProveedores.DataSource = NDescuentos.buscar_prov(this.txtBuscar.Text);
                this.proveedores_sort(1);

                if (this.dgvProveedores.Rows.Count > 0)
                    this.txtBuscar.Focus();

            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.tCargarProd.Enabled = false;
                this.tCargarProd.Enabled = true;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProveedores.Rows.Count == 0)
                    this.txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count == 0)
                {
                    if (this.dgvProveedores.Rows.Count == 0)
                        this.txtBuscar.Focus();
                    else
                        this.dgvProveedores.Focus();
                }
            }
            catch (Exception ex)
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
                    if (this.txtBuscar.Text != "")
                        this.txtBuscar.Text = "";
                    else
                        this.Close();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvProveedores.DataSource = NDescuentos.buscar_prov("");
                            this.proveedores_sort(1);
                            this.dgvProductos.DataSource = NDescuentos.buscar_prod(0, "");
                            this.productos_sort(1);

                            this.dtpDesde.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                            this.dtpHasta.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                            this.nudDesc.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                            this.gbDescuento.Enabled = false;
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

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpDesde.Value > this.dtpHasta.Value)
                    this.dtpDesde.Value = this.dtpHasta.Value;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                    this.dtpHasta.Value = this.dtpDesde.Value;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void nudDesc_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudDesc);
        }

        private void nudDesc_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudDesc);
        }

        private void nudDesc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_nud(e);

                if (e.KeyValue == 27)
                    this.dgvProductos.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dtpDesde_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.dgvProductos.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dtpHasta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.dgvProductos.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                        this.dgvProductos.Focus();

                    e.SuppressKeyPress = true;
                }

                if (e.KeyValue == 27)
                {
                    this.txtBuscar.Text = "";
                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    e.SuppressKeyPress = true;

                if (e.KeyValue == 13)
                    this.nudDesc.Focus();
                else if (e.KeyValue == 27)
                {
                    this.txtBuscar.Text = "";
                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.nudCantidadMin.Text == "" || this.nudCantidadMin.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la cantidad minima", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidadMin.Focus();
                    return;
                }
                if (this.nudCantidadMax.Text == "" || this.nudCantidadMax.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la cantidad máxima", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidadMax.Focus();
                    return;
                }
                if (this.nudDesc.Text == "" || this.nudDesc.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el porcentaje del descuento", this.btnGuardar, 0, 38, 3000);
                    this.nudDesc.Focus();
                    return;
                }


                if (DateTime.Parse(System.DateTime.Now.ToShortDateString()) > DateTime.Parse(dtpDesde.Value.ToShortDateString()))
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La fecha de inicio tiene que ser mayor o igual al día corriente.", this.btnGuardar, 0, 38, 3000);
                    this.dtpDesde.Focus();
                    return;
                }
                if (DateTime.Parse(System.DateTime.Now.ToShortDateString()) > DateTime.Parse(dtpHasta.Value.ToShortDateString()))
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La fecha de fin tiene que ser mayor o igual al día corriente.", this.btnGuardar, 0, 38, 3000);
                    this.dtpHasta.Focus();
                    return;
                }

                DialogResult resul;

                if (this.dgvProductos.Rows.Count >= 1)
                {
                    string accion = "I";
                    int id_descuento = 0;
                    if (rbtnAgregar.Checked)
                    {
                        accion = "I";
                    }
                    else
                    {
                        if (this.dgvDescuentoCategoria.Rows.Count >= 1)
                        {
                            accion = "U";
                            id_descuento = int.Parse(this.dgvDescuentoCategoria.CurrentRow.Cells[0].Value.ToString());
                        }
                        else { accion = "I"; }
                    }

                    //EN CASO DE UN SOLO PRODUCTO.
                    if (this.dgvProductos.Rows.Count == 1)
                    {
                        resul = MessageBox.Show("Desea agregar el descuento por categoria al producto seleccionado.\n\n¿Desea aplicar los cambios? ", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resul == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (NDescuentos.valida_descuento_categoria(accion, this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value) <= 0)
                            {
                                if (NDescuentos.guardar_descuento_categoria(accion, id_descuento, this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value))
                                {
                                    this.ttMensaje.ToolTipTitle = "LISTO";
                                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                    this.ttMensaje.Show("El descuento por categoría se aplicó correctamente", this.btnQuitar, 0, 38, 3000);
                                    buscar_descunto_produco();
                                }
                            }
                            else
                            {
                                this.ttMensaje.ToolTipTitle = "VALORES DEL DESCUENTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                                this.ttMensaje.Show("Los valores del descuento ya existen para este producto", this.btnGuardar, 0, 38, 3000);
                                this.nudDesc.Focus();
                                this.dgvProductos.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                                return;

                            }
                        }
                    }
                    else
                    {

                        //EN CASO DE VARIOS  PRODUCTO.
                        resul = MessageBox.Show("Desea agregar el descuento por categoría a estos productos.\n\n¿Desea aplicar los cambios?\n\nElije SI para todos.\nElije NO para el seleccionado", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (resul == System.Windows.Forms.DialogResult.Yes)
                        {
                            for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                            {
                                if (NDescuentos.valida_descuento_categoria(accion, this.dgvProductos.Rows[i].Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value) <= 0)
                                {
                                    if (NDescuentos.guardar_descuento_categoria(accion, id_descuento, this.dgvProductos.Rows[i].Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value))
                                    {
                                        id_descuento = 0;
                                    }
                                }
                                else
                                {
                                    this.dgvProductos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                }
                            }
                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El descuento por categoría se aplicó correctamente", this.btnQuitar, 0, 38, 3000);
                            buscar_descunto_produco();
                            this.nudDesc.Focus();
                        }
                        else if (resul == System.Windows.Forms.DialogResult.No)
                        {
                            if (NDescuentos.valida_descuento_categoria(accion, this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value) <= 0)
                            {
                                if (NDescuentos.guardar_descuento_categoria(accion, id_descuento, this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value))
                                {
                                    this.ttMensaje.ToolTipTitle = "LISTO";
                                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                    this.ttMensaje.Show("El descuento por categoría se aplicó correctamente", this.btnQuitar, 0, 38, 3000);
                                    buscar_descunto_produco();
                                }
                            }
                            else
                            {
                                this.ttMensaje.ToolTipTitle = "VALORES DEL DESCUENTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                                this.ttMensaje.Show("Los valores del descuento ya existen para este producto", this.btnGuardar, 0, 38, 3000);
                                this.nudDesc.Focus();
                                this.dgvProductos.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                                return;
                            }
                        }
                        else
                            this.nudDesc.Focus();
                    }


                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    this.nudDesc.Focus();
                    cargarProducto();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void cargarProducto()
        {
            try
            {
                try
                {
                    frmProductos_Acciones frm = new frmProductos_Acciones();
                    frm.Text = "MODIFICAR";
                    frm.accion = false;
                    frm.externalUse = true;
                    frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();

                    DataTable dt_datos = new DataTable();
                    dt_datos = NProductos.obtener_datos(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    frm.cmbPresentacion.DataSource = NPresentaciones.lista_combo();
                    frm.cmbPresentacion.ValueMember = "Id";
                    frm.cmbPresentacion.DisplayMember = "Presentacion";

                    frm.cmbProveedor.DataSource = NProveedores.lista_combo();
                    frm.cmbProveedor.ValueMember = "Id";
                    frm.cmbProveedor.DisplayMember = "Proveedor";


                    DataTable dtComposicion = NComposicionQuimica.cargar_cmb();
                    var row = dtComposicion.NewRow();
                    row["Id"] = "0";
                    row["Nombre"] = "Ninguno";
                    dtComposicion.Rows.InsertAt(row, 0);

                    //frm.cmbComposiciónQuimica.DataSource = dtComposicion;
                    //frm.cmbComposiciónQuimica.ValueMember = "Id";
                    //frm.cmbComposiciónQuimica.DisplayMember = "Nombre";

                    frm.cmbEspecificacion.DataSource = NEspecificacion.lista_combo();
                    frm.cmbEspecificacion.ValueMember = "Id";
                    frm.cmbEspecificacion.DisplayMember = "Especificacion";

                    if (cGeneral.validar_si_es_CB(dt_datos.Rows[0].ItemArray[0].ToString()))
                    {
                        frm.txtCB.Text = dt_datos.Rows[0].ItemArray[0].ToString();
                        frm.codBarra = dt_datos.Rows[0].ItemArray[0].ToString();
                    }
                    else { frm.cbCB.Enabled = true; }

                    frm.txtProducto.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                    frm.cmbPresentacion.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                    frm.cmbEspecificacion.Text = dt_datos.Rows[0].ItemArray[14].ToString(); 
                    frm.cmbProveedor.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                    ////frm.cmbComposiciónQuimica.Text = dt_datos.Rows[0].ItemArray[15].ToString();
                    frm.nudPVF.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                    frm.nudPVP.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                    frm.dtpVencimiento.Value = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[6].ToString()).Date;
                    frm.nudContiene.Text = dt_datos.Rows[0].ItemArray[10].ToString();

                    if (File.Exists(dt_datos.Rows[0].ItemArray[9].ToString()))
                        frm.pbFoto.ImageLocation = dt_datos.Rows[0].ItemArray[9].ToString();
                    else
                        NProductos.actualizar_foto(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), "");

                    if (frm.pbFoto.ImageLocation != null)
                    {
                        frm.btnQuitar.Visible = true;
                        frm.btnVer.Visible = true;
                    }

                    if (dt_datos.Rows[0].ItemArray[7].ToString() == "ACTIVO")
                        frm.cbEstado.Checked = true;
                    else
                        frm.cbEstado.Checked = false;

                    frm.txtLote.Text = dt_datos.Rows[0].ItemArray[8].ToString();
                    frm.nudContiene.Text = dt_datos.Rows[0].ItemArray[10].ToString();

                    if (frm.nudContiene.Value == 0)
                        frm.cbFracciones.Checked = false;
                    else
                        frm.cbFracciones.Checked = true;

                    if (Convert.ToDateTime(dt_datos.Rows[0].ItemArray[6].ToString()).ToShortDateString() == "01/01/1900")
                        frm.cbVencimiento.Checked = false;
                    else
                        frm.cbVencimiento.Checked = true;

                    if (frm.txtLote.Text == "")
                        frm.cbLote.Checked = false;
                    else
                        frm.cbLote.Checked = true;

                    frm.ShowDialog();
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            catch (Exception) { }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult resul;

                if (this.dgvProductos.Rows.Count >= 1)
                {
                    string accion = "D";
                    int id_descuento = 0;

                    if (this.dgvDescuentoCategoria.Rows.Count >= 1)
                    {
                        accion = "D";
                        id_descuento = int.Parse(this.dgvDescuentoCategoria.CurrentRow.Cells[0].Value.ToString());
                    }


                    //EN CASO DE UN SOLO PRODUCTO.
                    if (this.dgvProductos.Rows.Count == 1)
                    {
                        resul = MessageBox.Show("Desea quitar el descuento por categoria al producto seleccionado.\n\n¿Desea aplicar los cambios? ", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resul == System.Windows.Forms.DialogResult.Yes)
                        {

                            if (NDescuentos.guardar_descuento_categoria(accion, id_descuento, this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value))
                            {
                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                this.ttMensaje.Show("El descuento por categoría se quito correctamente", this.btnQuitar, 0, 38, 3000);
                                buscar_descunto_produco();
                            }
                        }

                    }
                    else
                    {

                        //EN CASO DE VARIOS  PRODUCTO.
                        resul = MessageBox.Show("Desea quitar el descuento por categoría a estos productos.\n\n¿Desea aplicar los cambios?\n\nElije SI para todos.\nElije NO para el seleccionado", cGeneral.name_system, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (resul == System.Windows.Forms.DialogResult.Yes)
                        {
                            for (int i = 0; i < this.dgvProductos.Rows.Count; i++)
                            {
                                if (NDescuentos.guardar_descuento_categoria(accion, id_descuento, this.dgvProductos.Rows[i].Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value))
                                {
                                    id_descuento = 0;
                                }
                            }

                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El descuento por categoría se quito correctamente", this.btnQuitar, 0, 38, 3000);
                            buscar_descunto_produco();

                        }
                        else if (resul == System.Windows.Forms.DialogResult.No)
                        {
                            if (NDescuentos.guardar_descuento_categoria(accion, id_descuento, this.dgvProductos.Rows[0].Cells[0].Value.ToString(), this.nudCantidadMin.Value.ToString(), this.nudCantidadMax.Value.ToString(), this.nudDesc.Text, this.dtpDesde.Value, this.dtpHasta.Value))
                            {
                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                this.ttMensaje.Show("El descuento por categoría se quito correctamente", this.btnQuitar, 0, 38, 3000);
                                buscar_descunto_produco();
                            }
                        }
                        else
                            this.nudDesc.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.dgvProductos.Rows.Count > 0)
                //{
                //    this.nudDesc.Text = this.dgvProductos.CurrentRow.Cells[5].Value.ToString();

                //    if (Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[10].Value).Date == Convert.ToDateTime("1900-01-01").Date)
                //        this.dtpDesde.Value = DateTime.Today.Date;
                //    else
                //        this.dtpDesde.Value = Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[10].Value).Date;

                //    if (Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[11].Value).Date == Convert.ToDateTime("1900-01-01").Date)
                //        this.dtpHasta.Value = DateTime.Today.Date;
                //    else
                //        this.dtpHasta.Value = Convert.ToDateTime(this.dgvProductos.CurrentRow.Cells[11].Value).Date;

                //}
                //if (this.dgvProveedores.Rows.Count > 0)
                //{
                //    if (NDescuentos.verificar_descuento(Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value)))
                //        this.btnQuitar.Enabled = true;
                //    else
                //        this.btnQuitar.Enabled = false;
                //}
                //if (this.dgvProductos.Rows.Count > 0)
                //{
                //    if (decimal.Parse(this.dgvProductos.CurrentRow.Cells[5].Value.ToString()) > 0)
                //    {
                //        this.btnQuitar.Enabled = true;
                //    }
                //    else
                //        this.btnQuitar.Enabled = false;
                //}
                buscar_descunto_produco();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void tCargarProd_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tCargarProd.Enabled = false;

                if (this.dgvProveedores.Rows.Count > 0)
                {
                    this.dgvProductos.DataSource = NDescuentos.buscar_prod(Convert.ToInt32(this.dgvProveedores.CurrentRow.Cells[0].Value), "");
                    this.productos_sort(1);

                    if (this.dgvProductos.Rows.Count > 0)
                        this.gbDescuento.Enabled = true;
                    else
                        this.gbDescuento.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProveedores.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProveedores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvProveedores.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buscar_descunto_produco()
        {
            try
            {

                if (this.dgvProductos.Rows.Count > 0)
                {
                    string id_producto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();

                    ////this.tBuscar.Enabled = false;
                    this.dgvDescuentoCategoria.DataSource = NDescuentos.buscar_descuento_by_producto(id_producto);
                    this.dgvDescuentoCategoria.Refresh();
                    //if (this.dgvDescuentoCategoria.Rows.Count > 0)
                    //    ////this.gbDescuento.Enabled = true;
                    //else
                    //    this.gbDescuento.Enabled = false;
                }


            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                try
                {
                    this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvProductos.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    this.dgvProductos.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                    this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                    this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                    this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                    this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                    this.dgvProductos.Columns[8].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";

                    this.dgvProductos.Columns[7].Visible = false;
                    this.dgvProductos.Columns[0].Frozen = true;
                    this.dgvProductos.Columns[1].Frozen = true;

                    this.dgvProductos.ScrollBars = ScrollBars.Both;
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvDescuentoCategoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                try
                {
                    this.dgvDescuentoCategoria.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvDescuentoCategoria.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dgvDescuentoCategoria.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dgvDescuentoCategoria.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dgvDescuentoCategoria.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dgvDescuentoCategoria.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    this.dgvDescuentoCategoria.Columns[0].Frozen = true;
                    this.dgvDescuentoCategoria.Columns[1].Frozen = true;

                    this.dgvDescuentoCategoria.ScrollBars = ScrollBars.Both;
                }
                catch (Exception ex) { cGeneral.error(ex); }
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
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvDescuentoCategoria_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDescuentoCategoria.Rows.Count > 0 && this.dgvProductos.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(this.dgvDescuentoCategoria.CurrentRow.Cells[3].Value) > 0)
                    {
                        this.btnQuitar.Enabled = true;
                        this.btnGuardar.Enabled = true;
                    }
                    else
                    {
                        this.btnQuitar.Enabled = false;
                        this.btnGuardar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }


            try
            {
                if (this.dgvDescuentoCategoria.Rows.Count > 0)
                {
                    this.nudCantidadMin.Text = this.dgvDescuentoCategoria.CurrentRow.Cells[1].Value.ToString();
                    this.nudCantidadMax.Text = this.dgvDescuentoCategoria.CurrentRow.Cells[2].Value.ToString();
                    this.nudDesc.Text = this.dgvDescuentoCategoria.CurrentRow.Cells[3].Value.ToString();

                    if (Convert.ToDateTime(this.dgvDescuentoCategoria.CurrentRow.Cells[4].Value).Date == Convert.ToDateTime("1900-01-01").Date)
                        this.dtpDesde.Value = DateTime.Today.Date;
                    else
                        this.dtpDesde.Value = Convert.ToDateTime(this.dgvDescuentoCategoria.CurrentRow.Cells[4].Value).Date;

                    if (Convert.ToDateTime(this.dgvDescuentoCategoria.CurrentRow.Cells[5].Value).Date == Convert.ToDateTime("1900-01-01").Date)
                        this.dtpHasta.Value = DateTime.Today.Date;
                    else
                        this.dtpHasta.Value = Convert.ToDateTime(this.dgvDescuentoCategoria.CurrentRow.Cells[5].Value).Date;

                }
                else
                {
                    this.nudCantidadMin.Text = "0";
                    this.nudCantidadMax.Text = "0";
                    this.nudDesc.Text = "0";
                    this.dtpDesde.Value = DateTime.Today.Date;
                    this.dtpHasta.Value = DateTime.Today.Date;
                }

            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    ////this.tBuscar.Enabled = false;
                    this.dgvProductos.DataSource = NDescuentos.buscar_prod(0, txtBuscarProducto.Text);
                    this.dgvProductos.Refresh();
                    if (this.dgvProductos.Rows.Count > 0)
                        this.gbDescuento.Enabled = true;
                    else
                        this.gbDescuento.Enabled = false;

                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
           
        }
    }
}
