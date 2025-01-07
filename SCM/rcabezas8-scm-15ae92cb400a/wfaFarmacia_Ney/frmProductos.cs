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

namespace SCM
{
    public partial class  frmProductos : Form
    {
        public static frmProductos me;

        public frmProductos()
        {
            frmProductos.me = this;
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

        //BindingList<campos> listar(string dato, int page)
        //{
        //    BindingList<campos> bl;
        //    List<campos> query = (from c in bd.Cargar_Productos(dato).OrderBy(p => p.Producto)
        //                          select new campos
        //                          {
        //                              id = c.Id,
        //                              prod = c.Producto,
        //                              pres = c.Presentacion,
        //                              prov = c.Proveedor,
        //                              pvf = Convert.ToDecimal(c.PVF),
        //                              pvp = Convert.ToDecimal(c.PVP),
        //                              disp = c.Disponible,
        //                              est = c.Estado
        //                          }).Skip((page - 1) * cGeneral.registros_por_pagina).Take(cGeneral.registros_por_pagina).ToList();

        //    return bl = new BindingList<campos>(query);
        //}

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
           
        }
        private void Cargar_Producto()
        {
            try
            {

                ///pProces.Visible = true;
                this.tBuscar.Enabled = false;
                number = 1;

                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                this.dgvProductos.DataSource = NProductos.obtener_productos_cat(txtBuscar.Text,cbEliminados.Checked);
                this.dgvProductos.Refresh();

                if (this.dgvProductos.Rows.Count == 0)
                {
                    this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", 0, 0);

                    this.pPaginacion.Enabled = false;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    ////this.txtBuscar.Focus();
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                    return;
                }

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                this.pPaginacion.Enabled = true;
                this.btnPrimera.Enabled = false;
                this.brnAnterior.Enabled = false;

                if (tamaño <= 1)
                {
                    this.btnSiguiente.Enabled = false;
                    this.btnUltima.Enabled = false;
                }
                else
                {
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }

                if (this.txtBuscar.Text == "")
                    this.btnAgregar.Enabled = true;
                else
                    this.btnAgregar.Enabled = false;

                this.btnModificar.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.txtBuscar.Focus();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!cbEliminados.Checked)
            {
                try
                {
                    frmProductos_Acciones frm = new frmProductos_Acciones();
                    frm.Text = "MODIFICAR";
                    frm.accion = false;

                    DataTable dt_datos = new DataTable();
                    dt_datos = NProductos.obtener_datos(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    if (dt_datos.Rows.Count > 0)
                    {

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
                        frm.desc_presentacion = dt_datos.Rows[0].ItemArray[2].ToString();
                        frm.cmbProveedor.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                        frm.desc_proveedor = dt_datos.Rows[0].ItemArray[3].ToString();
                        frm.cmbEspecificacion.Text = dt_datos.Rows[0].ItemArray[14].ToString();
                        frm.desc_espeficacion = dt_datos.Rows[0].ItemArray[14].ToString();
                        ////frm.cmbComposiciónQuimica.Text = dt_datos.Rows[0].ItemArray[15].ToString();
                        frm.nudPVF.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                        frm.nudPUR.Text = dt_datos.Rows[0].ItemArray[17].ToString();
                        frm.txtRegistroSanitario.Text = dt_datos.Rows[0].ItemArray[18].ToString();
                        frm.nudPVP.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                        frm.dtpVencimiento.Value = Convert.ToDateTime(dt_datos.Rows[0].ItemArray[6].ToString()).Date;
                        frm.nudContiene.Text = dt_datos.Rows[0].ItemArray[10].ToString();
                        frm.cbIVA.Checked = Convert.ToBoolean(dt_datos.Rows[0].ItemArray[16].ToString());
                        try
                        {
                            if (File.Exists(dt_datos.Rows[0].ItemArray[9].ToString()))
                                frm.pbFoto.ImageLocation = dt_datos.Rows[0].ItemArray[9].ToString();
                            else
                                NProductos.actualizar_foto(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), "");

                            if (frm.pbFoto.ImageLocation != null)
                            {
                                frm.btnQuitar.Visible = true;
                                frm.btnVer.Visible = true;
                            }
                        }
                        catch (Exception) { }

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
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "MODIFICAR PRODUCTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Producto a editar no fue encontrado.", this.btnModificar, 0, 38, 3000);
                        return;
                    }

                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "MODIFICAR PRODUCTO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Los productos que se estan mostrando estan en BANDEJA DE ELIMINADOS.", this.btnModificar, 0, 38, 3000);
                return; 
            } 
          
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvProductos);

                this.tBuscar.Interval = cGeneral.timer;
                this.dgvProductos.DataSource = NProductos.obtener_productos_cat("",cbEliminados.Checked);

                this.dgvProductos.Columns[0].HeaderText = "ID/CODIGO BARRA";
                this.dgvProductos.Columns[1].HeaderText = "PRODUCTO";
                this.dgvProductos.Columns[2].HeaderText = "PRESENTACION";
                this.dgvProductos.Columns[3].HeaderText = "PROVEEDOR";
                this.dgvProductos.Columns[4].HeaderText = "P/COMPRA";
                this.dgvProductos.Columns[5].HeaderText = "PVP";
                this.dgvProductos.Columns[6].HeaderText = "DESCUENTO";
                this.dgvProductos.Columns[7].HeaderText = "PVPX";
                this.dgvProductos.Columns[8].HeaderText = "DISPONIBLE";
                this.dgvProductos.Columns[9].HeaderText = "PVFR";
                this.dgvProductos.Columns[10].HeaderText = "ESTADO";
                this.dgvProductos.Refresh();

                this.txtRegistros.Text = NProductos.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvProductos);

                if (this.txtRegistros.Text != "0")
                    this.txtBuscar.Enabled = true;

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        void click_eliminar()
        {
            if (!cbEliminados.Checked)
            {
                try
                {
                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        string codBarra = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                        int cantidadKardex = NProductos.valida_mov_cardex_codigo_barra(codBarra);

                        if (cantidadKardex > 0)
                        {
                            MessageBox.Show("Este producto contien: " + cantidadKardex + " movimientos de KARDEX : " + codBarra + ",por lo tanto no es posible eliminar este producto.", "MOVIMIENTOS KARDEX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste producto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resul == System.Windows.Forms.DialogResult.No)
                    {
                        this.dgvProductos.Focus();
                        return;
                    }

                    NProductos.eliminar(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), cGeneral.name_user);
                    this.dgvProductos.Rows.Remove(this.dgvProductos.CurrentRow);
                    this.txtRegistros.Text = NProductos.num_reg().ToString("N0");

                    if (this.dgvProductos.Rows.Count > 0)
                    {
                        if (this.txtRegistros.Text == "0")
                        {
                            this.txtBuscar.Text = "";

                            this.txtBuscar.Enabled = false;
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.dgvProductos.Rows[this.dgvProductos.CurrentRow.Index].Selected = true;

                            if (this.dgvProductos.Rows.Count > 0)
                            {
                                dgvProductos.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "ELIMINAR PRODUCTO";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Los productos que se estan mostrando estan en BANDEJA DE ELIMINADOS.", this.btnModificar, 0, 38, 3000);
                return;
            }
               
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Cargar_Producto();
                }
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                    else
                        this.txtBuscar.Text = "";
                }
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;

                            this.tBuscar.Enabled = false;
                            this.dgvProductos.DataSource = NProductos.obtener_productos_cat("",cbEliminados.Checked);
                            this.dgvProductos.Refresh();

                            this.pPaginacion.Enabled = false;
                            this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);
                        }
                        else
                        {
                            if (cGeneral.validar_si_es_CB(this.txtBuscar.Text))
                            {
                                Cargar_Producto();
                            }
                            this.tBuscar.Enabled = false;
                            this.tBuscar.Enabled = true;
                        }
                    }
                    catch (Exception ex) { cGeneral.error(ex); }
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.txtBuscar.Text = "";
                    this.txtBuscar.Focus();
                }
                else if (e.KeyValue == 46)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                        click_eliminar();
                }
                else if (e.KeyValue == 255 || e.KeyValue == 173)
                {
                    if (this.dgvProductos.RowCount>0)
                    {
                        Productos.frmDetProducto frm = new Productos.frmDetProducto();
                        frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvProductos.Rows.Count > 0)
                {
                    if (this.txtBuscar.Enabled == false)
                    {
                        this.btnAgregar.Focus();
                    }
                       
                }
                else
                    this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el nombre, presentación y proveedor del producto", this.txtBuscar, 0, 26);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                //this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[6].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales + ""; 
                this.dgvProductos.Columns[9].DefaultCellStyle.Format = "N" + cGeneral.decimales + ""; 

                //if (this.dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0" || this.dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0F0")
                //    this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Red;
                //else
                //    this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[0].Frozen = true;
                this.dgvProductos.Columns[1].Frozen = true;

                this.dgvProductos.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                number += 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos_cat(txtBuscar.Text,cbEliminados.Checked);
                this.dgvProductos.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                if (number == tamaño)
                {
                    this.btnPrimera.Enabled = true;
                    this.brnAnterior.Enabled = true;
                    this.btnSiguiente.Enabled = false;
                    this.btnUltima.Enabled = false;
                }
                else
                {
                    this.btnPrimera.Enabled = true;
                    this.brnAnterior.Enabled = true;
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }
                
                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void brnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                number -= 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos_cat(txtBuscar.Text,cbEliminados.Checked);
                this.dgvProductos.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                if (number == 1)
                {
                    this.btnPrimera.Enabled = false;
                    this.brnAnterior.Enabled = false;
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }
                else
                {
                    this.btnPrimera.Enabled = true;
                    this.brnAnterior.Enabled = true;
                    this.btnSiguiente.Enabled = true;
                    this.btnUltima.Enabled = true;
                }

                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            try
            {
                number = tamaño;

                this.dgvProductos.DataSource = NProductos.obtener_productos_cat(txtBuscar.Text,cbEliminados.Checked);
                this.dgvProductos.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                this.btnPrimera.Enabled = true;
                this.brnAnterior.Enabled = true;
                this.btnSiguiente.Enabled = false;
                this.btnUltima.Enabled = false;
                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbEliminados.Checked)
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    Productos.frmBitacoraProducto frmBitacora = new Productos.frmBitacoraProducto();
                    frmBitacora.idProducto = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmBitacora.eliminado = cbEliminados.Checked;
                    frmBitacora.Show();
                }
            }
            else
            {
                btnModificar_Click(null, null);
            }
          
        }

        private void cbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_Producto();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            try
            {
                number = 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos_cat(txtBuscar.Text,cbEliminados.Checked);
                this.dgvProductos.Refresh();

                this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                this.btnPrimera.Enabled = false;
                this.brnAnterior.Enabled = false;
                this.btnSiguiente.Enabled = true;
                this.btnUltima.Enabled = true;

                this.dgvProductos.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
