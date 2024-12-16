﻿using CapaNegocios;
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

namespace wfaFarmacia_Ney
{
    public partial class frmCotizaciones_Productos : Form
    {
        public static frmCotizaciones_Productos me;

        public frmCotizaciones_Productos()
        {
            frmCotizaciones_Productos.me = this;
            InitializeComponent();
        }

        int number = 1, tamaño = 0;
        string IdCotizacion = "0";
        ////dcDatosDataContext bd = new dcDatosDataContext();

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

        void guardar_prod()
        {
            try
            {
                this.ttMensaje.Hide(this.nudCantidad1);
                this.ttMensaje.Hide(this.nudCantidad2);
                this.ttMensaje.Hide(this.txtBuscar);

                if (this.nudCantidad1.Text == "") this.nudCantidad1.Value = 0;
                if (this.nudCantidad2.Text == "") this.nudCantidad2.Value = 0;
                if (this.nudFracciones.Text == "") this.nudFracciones.Value = 0;
                if (frmCotizaciones.me.dgvFacturas.RowCount>0)
                {
                    IdCotizacion = frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].ToString();
                    frmCotizaciones.me.txtNumVenta.Text = IdCotizacion;
                }


                if (NCotizaciones.verificar_prod_temp(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), this.dgvProductos.CurrentRow.Cells[0].Value.ToString()) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este producto ya está agregado", this.txtBuscar, 0, 26, 3000);
                    this.dgvProductos.Focus();
                    return;
                }

                int captar_cont = NProductos.obtener_cont(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                if (this.nudCantidad1.Enabled == true)
                {
                    if (this.nudCantidad1.Value == 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad1, 0, 26, 3000);
                        this.nudCantidad1.Focus();
                        return;
                    }
                }
                else
                {
                    if (this.nudCantidad2.Value == 0 && this.nudFracciones.Value == 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FANTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese la cantidad", this.nudCantidad2, 0, 26, 3000);
                        this.nudCantidad2.Focus();
                        return;
                    }
                    else
                        if (Convert.ToInt32(this.nudFracciones.Value) > captar_cont)
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR ";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Este producto contiene " + captar_cont + " fraccciones.", this.nudFracciones, 0, 26, 3000);
                            this.nudFracciones.Focus();
                            return;
                        }
                }

                int captar_cant = 0;

                if (this.nudCantidad1.Enabled == true)
                    captar_cant = Convert.ToInt32(this.nudCantidad1.Value);
                else
                {
                    captar_cant = Convert.ToInt32(this.nudCantidad2.Value);
                    captar_cant = captar_cant * captar_cont;
                    captar_cant += Convert.ToInt32(this.nudFracciones.Value);
                }

                if (NProductos.obtener_disponible(this.dgvProductos.CurrentRow.Cells[0].Value.ToString()) < captar_cant)
                {
                    try
                    {
                        this.dgvProductos.CurrentRow.Cells[5].Value = NProductos.obtener_disponible_texto(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                    }
                    catch (Exception)
                    {
                        this.dgvProductos.CurrentRow.Cells[5].Value = 0;

                    }

                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;

                    if (this.nudCantidad1.Enabled)
                    {
                        this.ttMensaje.Show("No hay suficiente en stock", this.nudCantidad1, 0, 26, 3000);
                        this.nudCantidad1.Focus();
                    }
                    else
                    {
                        this.ttMensaje.Show("No hay suficiente en stock", this.nudCantidad2, 0, 26, 3000);
                        this.nudCantidad2.Focus();
                    }

                    return;
                }

                NProductos.actualizar_desc(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                decimal calc_ganan, calc_parcial;
                calc_ganan = NCotizaciones.calcular_ganan(this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant);
                calc_parcial = NCotizaciones.calcular_parcial(this.dgvProductos.CurrentRow.Cells[0].Value.ToString());

                NCotizaciones.guardar_prod_temp(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), this.dgvProductos.CurrentRow.Cells[0].Value.ToString(), captar_cant, calc_parcial, calc_ganan);

                frmCotizaciones.me.dgvProductos.DataSource = NCotizaciones.cargar_prod(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value));
                frmCotizaciones.me.orden_prod(frmCotizaciones.me.dgvProductos);

                frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[2].Value = NCotizaciones.actualizar_nombre_prov(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value));
                frmCotizaciones.me.cargar_totales(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value));

                frmCotizaciones.me.btnAgregarProd.Enabled = true;
                frmCotizaciones.me.btnEliminarProd.Enabled = true;
                frmCotizaciones.me.btnModificarProd.Enabled = true;
                frmCotizaciones.me.btnGuardar.Enabled = true;

                if (frmCotizaciones.me.dgvProductos.Rows.Count == 1)
                    this.Text = "AGREGAR PRODUCTOS" + " | HAY 1 PRODUCTO AGREGADO";
                else
                    this.Text = "AGREGAR PRODUCTOS" + " | HAY " + frmCotizaciones.me.dgvProductos.Rows.Count + " PRODUCTOS AGREGADOS";

                this.txtBuscar.Focus();
                this.txtBuscar.Text = "";
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                if (this.dgvProductos.Rows.Count == 0)
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
                        this.ttMensaje.Hide(this.txtBuscar);
                        this.ttMensaje.Hide(this.nudCantidad1);

                        this.tBuscar.Enabled = false;
                        this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", 0, 0);

                        tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                        this.dgvProductos.DataSource = NProductos.obtener_productos("");
                        this.dgvProductos.Refresh();

                        this.nudCantidad1.Value = 0;
                        this.nudFracciones.Value = 0;
                        this.pCantidades.Enabled = false;
                        this.txtBuscar.Focus();
                    }
                    else
                    {
                        if (cGeneral.validar_si_es_CB(this.txtBuscar.Text))
                        {
                            tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                            this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                            this.dgvProductos.Refresh();

                            this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                            if (this.nudCantidad1.Enabled == true)
                                this.nudCantidad1.Focus();
                            else
                                this.nudCantidad2.Focus();
                        }
                        else
                        {
                            this.tBuscar.Enabled = false;
                            this.tBuscar.Enabled = true;
                        }
                    }
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }  
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.ToolTipTitle = "";
            this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
            this.ttMensaje.ShowAlways = true;
            this.ttMensaje.Show("Busca el código de barra, nombre, presentación y el proveedor del producto", this.txtBuscar, 0, 26);
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void nudCantidad1_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                guardar_prod();
            else if (e.KeyValue == 27)
                this.txtBuscar.Text = "";
        }

        private void nudCantidad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void nudCantidad1_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudCantidad1);
        }

        private void nudCantidad2_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                guardar_prod();
            else if (e.KeyValue == 27)
                this.txtBuscar.Text = "";
        }

        private void nudCantidad2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void nudCantidad2_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudCantidad2);
        }

        private void nudFracciones_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                guardar_prod();
            else if (e.KeyValue == 27)
                this.txtBuscar.Text = "";
        }

        private void nudFracciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void nudFracciones_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudFracciones);
        }

        private void nudCantidad1_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudCantidad1);
        }

        private void nudCantidad2_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudCantidad2);
        }

        private void nudFracciones_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudFracciones);
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

                this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
                this.dgvProductos.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;

                this.dgvProductos.Columns[4].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";
                this.dgvProductos.Columns[5].DefaultCellStyle.Format = "N" + cGeneral.decimales + "";

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

        private void dgvProductos_Enter(object sender, EventArgs e)
        {
            if (this.dgvProductos.Rows.Count == 0)
                this.txtBuscar.Focus();
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    e.SuppressKeyPress = true;

                if (e.KeyValue == 13)
                {
                    if (this.nudCantidad1.Enabled == true)
                        this.nudCantidad1.Focus();
                    else
                        this.nudCantidad2.Focus();
                }
                else if (e.KeyValue == 27)
                {
                    if (this.dgvProductos.Rows.Count > 0)
                        this.txtBuscar.Text = "";
                }
                else if (e.KeyValue == 255 || e.KeyValue == 173)
                {
                    if (this.dgvProductos.RowCount > 0)
                    {
                        Productos.frmDetProducto frm = new Productos.frmDetProducto();
                        frm.idProducto = this.dgvProductos.CurrentRow.Cells[0].Value.ToString();
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (NProductos.obtener_cont(this.dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString()) == 0)
                {
                    this.pCantidades.Enabled = true;
                    this.lblCantidad2.Enabled = false;
                    this.nudCantidad2.Enabled = false;
                    this.nudFracciones.Enabled = false;
                    this.label5.Enabled = false;
                    this.nudCantidad2.Value = 0;
                    this.nudFracciones.Value = 0;

                    this.lblCantidad1.Enabled = true;
                    this.nudCantidad1.Enabled = true;
                }
                else
                {
                    this.pCantidades.Enabled = true;
                    this.lblCantidad1.Enabled = false;
                    this.nudCantidad1.Enabled = false;
                    this.nudCantidad1.Value = 0;

                    this.lblCantidad2.Enabled = true;
                    this.label5.Enabled = true;
                    this.nudCantidad2.Enabled = true;
                    this.nudFracciones.Enabled = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
                this.dgvProductos.Refresh();

                if (this.dgvProductos.Rows.Count == 0)
                {
                    this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", 0, 0);

                    this.pPaginacion.Enabled = false;
                    this.nudCantidad1.Value = 0;
                    this.nudCantidad2.Value = 0;
                    this.nudFracciones.Value = 0;
                    this.pCantidades.Enabled = false;
                    this.txtBuscar.Focus();
                    ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.lblTotalPaginas.Text = string.Format("PAGINA {0} DE {1}", number, tamaño);

                    this.pCantidades.Enabled = true;
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

                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCotizaciones_Productos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfree_con_alter(this.dgvProductos);
                est.SetDoubleBuffered(this.dgvProductos);

                this.tBuscar.Interval = cGeneral.timer;

                tamaño = NProductos.tamaño(this.txtBuscar.Text, cGeneral.registros_por_pagina);
                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);

                //this.dgvProductos.Columns[0].HeaderText = "ID/CODIGO BARRA";
                //this.dgvProductos.Columns[1].HeaderText = "PRODUCTO";
                //this.dgvProductos.Columns[2].HeaderText = "PRESENTACION";
                //this.dgvProductos.Columns[3].HeaderText = "PROVEEDOR";
                //this.dgvProductos.Columns[4].HeaderText = "P/COMPRA";
                //this.dgvProductos.Columns[5].HeaderText = "PVP";
                //this.dgvProductos.Columns[6].HeaderText = "DESCUENTO";
                //this.dgvProductos.Columns[7].HeaderText = "PVPX";
                //this.dgvProductos.Columns[8].HeaderText = "DISPONIBLE";
                //this.dgvProductos.Columns[9].HeaderText = "PVFR";
                //this.dgvProductos.Columns[10].HeaderText = "ESTADO";
                this.dgvProductos.Refresh();

                cGeneral.ajuste_columnas(this.dgvProductos);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCotizaciones_Productos_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCotizaciones.me.tEnfoque.Enabled = true;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            try
            {
                number = 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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

        private void brnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                number -= 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                number += 1;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            try
            {
                number = tamaño;

                this.dgvProductos.DataSource = NProductos.obtener_productos(this.txtBuscar.Text);
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
    }
}