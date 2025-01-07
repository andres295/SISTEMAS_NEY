﻿using CapaNegocios;
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

namespace SCM.Productos
{
    public partial class frmDetProductoEspecificacion : Form
    {
        public frmDetProductoEspecificacion()
        {
            InitializeComponent();
        }
        public int name_ventana = 0;
        public string idProducto = "";
        public string fuente = "";
        private void frmDetProducto_Load(object sender, EventArgs e)
        {
            ////this.txtNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            ///this.rtxtComposicion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetProducto_Load_1(object sender, EventArgs e)
        {
            cEstilo_Grid est = new cEstilo_Grid();
            est.grid_selfull_con_alter(this.dgvProductos);

            //DataTable dtProducto = NProductos.obtener_producto_by_especificacion(txtBuscar.Text);

            //if (dtProducto.Rows.Count>0)
            //{
                ////txtEspecificacion.Text = dtProducto.Rows[0]["Especificacion"].ToString();
                //// txtComposicion.Text = dtProducto.Rows[0]["ComposicionQuimica"].ToString();
                ////cargarComposicion();
                cargaProductos();

            this.dgvProductos.Columns[0].HeaderText = "ID/CODIGO BARRA";
            this.dgvProductos.Columns[1].HeaderText = "PRODUCTO";
            //this.dgvProductos.Columns[2].HeaderText = "PRESENTACION";
            //this.dgvProductos.Columns[3].HeaderText = "PROVEEDOR";
            this.dgvProductos.Columns[2].HeaderText = "P/COMPRA";
            this.dgvProductos.Columns[3].HeaderText = "PVP";
            this.dgvProductos.Columns[4].HeaderText = "DESCUENTO";
            this.dgvProductos.Columns[5].HeaderText = "PVPX";
            this.dgvProductos.Columns[6].HeaderText = "DISPONIBLE";
            this.dgvProductos.Columns[7].HeaderText = "PVFR";
            this.dgvProductos.Columns[8].HeaderText = "ESTADO";
            this.dgvProductos.Refresh();
            //}
        }
        //private void cargarComposicion()
        //{
        //    try
        //    {
        //        string composicion = NProductos.obtener_composicion_by_producto(idProducto);
        //        if (composicion != "")
        //        {
        //            rtxtComposicion.Text = composicion;
        //        }
        //        else { rtxtComposicion.Enabled = false; }
        //    }
        //    catch (Exception ex) { }
        //}
        private void cargaProductos()
        {
            try
            {
            
                DataTable especificacion = NProductos.obtener_producto_by_especificacion(txtBuscar.Text);
                dgvProductos.DataSource = especificacion;
                dgvProductos.Enabled = true;
              
            }
            catch (Exception ex) { }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                this.dgvProductos.Rows[e.RowIndex].Cells[4].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[2].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvProductos.Columns[3].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";
                this.dgvProductos.Columns[7].DefaultCellStyle.Format = "N" + cGeneral.decimales_ventas + "";

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
        void click_seleccionar()
        {
            try
            {
                if (name_ventana == 1)
                {
                    frmVentas.me.txtBuscar.Text = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmVentas.me.Buscar_Producto();
                    frmVentas.me.click_agregar_prod();
                    this.Close();
                }
                else if (name_ventana == 2)
                {
                    frmVentas_2.me.txtBuscar.Text = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmVentas_2.me.Buscar_Producto();
                    frmVentas_2.me.click_agregar_prod();
                    this.Close();
                }
                else if (name_ventana == 3)
                {
                    frmVentas_3.me.txtBuscar.Text = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    frmVentas_3.me.Buscar_Producto();
                    frmVentas_3.me.click_agregar_prod();
                    this.Close();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ////click_seleccionar();
        }

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count == 0)
                    click_seleccionar();
           
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                click_seleccionar();
            } 
            else if (e.KeyValue == 27)
                this.Close();
        }

        private void dgvProductos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos.Cursor = Cursors.Default;
            /// pImagen.Visible = false;
            gbProducto.Visible = false;
        }

        private void dgvProductos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                try
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[e.RowIndex];
                    if (row != null)
                    {
                        string imagenUrl = NProductos.obtener_img_prod(row.Cells[0].Value.ToString());
                        if (imagenUrl != null)
                        {
                            if (File.Exists(imagenUrl))
                            {
                                pbFoto.ImageLocation = imagenUrl;
                                gbProducto.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    dgvProductos.Cursor = Cursors.Default;
                    /// pImagen.Visible = false;
                }

            }
            else
                dgvProductos.Cursor = Cursors.Default;
            ///pImagen.Visible = false;
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            click_seleccionar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargaProductos();
            }
        }
         
    }
}
