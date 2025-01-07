using CapaNegocios;
using SCM.Globales;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SCM.Descuentos
{
    public partial class frmAgregarDescuentoLinea : Form
    {
        public static frmAgregarDescuentoLinea me;
        public bool accion; 

        public frmAgregarDescuentoLinea()
        {
            frmAgregarDescuentoLinea.me = this;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int result_value_accion = 0;
            if (this.txtDescripcion.Text == "")
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la descripción", this.btnGuardar, 0, 38, 3000);
                this.txtDescripcion.Focus();
                return;
            }
            else if (this.nudPorcentaje.Value <= 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese el porcentaje del descuento.", this.btnGuardar, 0, 38, 3000);
                this.nudPorcentaje.Focus();
                this.nudPorcentaje.Select(0, this.nudPorcentaje.Text.Length);
                return;
            } 
            else if (this.dtpFechaInicio.Value < DateTime.Now.Date)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la fecha de inicio mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                this.dtpFechaInicio.Focus();
                return;
            }
            else if (this.dtpFechaFin.Value < DateTime.Now.Date)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la fecha de fin mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                this.dtpFechaFin.Focus();
                return;
            }
            else if (DateTime.Parse( this.dtpFechaInicio.Value.ToShortDateString()) > DateTime.Parse(this.dtpFechaFin.Value.ToShortDateString()))
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", this.btnGuardar, 0, 38, 3000);
                this.dtpFechaInicio.Focus();
                return;
            }
            else if (cbProductosAgregados.Items.Count > 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ya hay productos agregados a este descuento, si desea guardar o cambiar algun valor del descuento, primero debe de desmarcar los productos agregados y luego guardar los cambios generales del descuento.", this.btnGuardar, 0, 38, 3000);
                this.nudPorcentaje.Focus();
                return;
            }
            if (accion)
            {
                result_value_accion = NDescuentos.agregar_descuento_linea(txtDescripcion.Text.Trim(), decimal.Parse(nudPorcentaje.Value.ToString()), dtpFechaInicio.Value, dtpFechaFin.Value, cbEstado.Checked, cGeneral.id_user_actual);
                if (result_value_accion > 0)
                {
                    MessageBox.Show("Descuento de producto agregado con éxito. Ahora tiene que asignar los productos que aplicaran a este descuento.", "Descuento de PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Height = 486;
                    this.lblID.Text = result_value_accion.ToString();
                    accion = false;

                    int id_descuento = 0;
                    try
                    {
                        id_descuento = int.Parse(lblID.Text);
                        Descuentos.frmDescuentoLinea.me.bindingSource1.DataSource = NDescuentos.Obtener_Descuento_Linea();
                        Descuentos.frmDescuentoLinea.me.nvDescuentos.BindingSource = Descuentos.frmDescuentoLinea.me.bindingSource1;
                        Descuentos.frmDescuentoLinea.me.gvDescuentoLinea.DataSource = Descuentos.frmDescuentoLinea.me.bindingSource1;
                        cargarLineas(id_descuento,true);
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                result_value_accion = NDescuentos.modificar_descuento_linea(int.Parse(lblID.Text), txtDescripcion.Text.Trim(), decimal.Parse(nudPorcentaje.Value.ToString()), dtpFechaInicio.Value,dtpFechaFin.Value, cbEstado.Checked);
                if (result_value_accion > 0)
                {
                    MessageBox.Show("Descuento de producto modificado con éxito. ", "Descuento de PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Descuentos.frmDescuentoLinea.me.bindingSource1.DataSource = NDescuentos.Obtener_Descuento_Linea();
                    Descuentos.frmDescuentoLinea.me.nvDescuentos.BindingSource = Descuentos.frmDescuentoLinea.me.bindingSource1;
                    Descuentos.frmDescuentoLinea.me.gvDescuentoLinea.DataSource = Descuentos.frmDescuentoLinea.me.bindingSource1;
                }
            }
        }

        private void frmAgregarDescuentoLinea_Load(object sender, EventArgs e)
        {
            if (accion)
            {
                this.Height = 243;
            }
            else
            {
                int id_descuento = 0;
                try
                {
                    id_descuento = int.Parse(lblID.Text);
                    cargarLineas(id_descuento,true); 
                }
                catch (Exception)   {  }
                timer2.Enabled = false;
            } 
        }
        private void cargarLineas(int id_descuento, bool todos)
        {
            try
            {
                DataTable dt = NDescuentos.Obtener_lineas_descuento(id_descuento.ToString());

                if (todos)
                {
                    cblProducto.Items.Clear();
                    DataRow[] rowsNoAgregados = dt.Select("PRODUCTO like '%" + txtBuscar.Text.Trim() + "%'"); 
                    ///No agregados
                    foreach (DataRow row in rowsNoAgregados)
                    {
                        cblProducto.Items.Add(new ListItem(row["PRODUCTO"].ToString(), row["Id"].ToString()), row["ELEGIR"].ToString() == "1" ? true : false);
                    }
                } 

                cbProductosAgregados.Items.Clear();
                DataRow[] rowsAgregados   = dt.Select("PRODUCTO like '%" + txtBuscar.Text.Trim() + "%' and ELEGIR = 1"); 
                ///Agregados
                foreach (DataRow row in rowsAgregados)
                {
                    cbProductosAgregados.Items.Add(new ListItem(row["PRODUCTO"].ToString(), row["Id"].ToString()), true);
                }  
            }
            catch (Exception ex) { }
        }  
        private void cblLinea_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                int id_descuento = 0;
                id_descuento = int.Parse(lblID.Text);
                if (id_descuento > 0)
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        var checkBoxName = cblProducto.Items[e.Index];
                        var id = ((ListItem)checkBoxName).Value;
                        if (validaPVPvsDescuento(id))
                        {
                            NDescuentos.asignar_linea_descuento(id_descuento.ToString(), id);
                        }
                        else
                        {
                            if (NDescuentos.is_existe_linea_descuento(id_descuento.ToString(), id) <= 0)
                            {
                                timer2.Enabled = true;
                            } 
                        }
                    }
                    else
                    {
                        var checkBoxName = cblProducto.Items[e.Index];
                        var id = ((ListItem)checkBoxName).Value;
                        NDescuentos.quitar_linea_descuento(id_descuento.ToString(), id); 
                    }
                }
                else
                {
                    MessageBox.Show("No existe ningún ID descuento para asignar LINEAS", "Descuento LINEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                cargarLineas(id_descuento,false);
            }
            catch (Exception) { }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void BuscarProducto()
        {
            int id_descuento = 0;
            try
            {
                id_descuento = int.Parse(lblID.Text);
                cargarLineas(id_descuento,true);
            }
            catch (Exception) { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void txtBuscar_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyCode == Keys.Enter)
            {
                BuscarProducto();
            }
        }

        private void cbProductosAgregados_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            { 
                if (e.NewValue == CheckState.Unchecked)
                {
                    foreach (Object item in cblProducto.Items)
                    {
                        if (item.ToString().Trim() == cbProductosAgregados.Text.Trim())
                        {
                            int index = cblProducto.Items.IndexOf(item); 
                            cblProducto.SetItemChecked(index, false);
                            timer1.Enabled = true;
                            break;
                        } 
                    } 
                } 
            }
            catch (Exception) { }
        }  
        private void Cargar_Click(object sender, EventArgs e)
        {
            int id_descuento = 0;
            try
            {
                cbProductosAgregados.Update();
                cbProductosAgregados.EndUpdate();
                id_descuento = int.Parse(lblID.Text);
                cargarLineas(id_descuento, false);
            }
            catch (Exception) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int id_descuento = 0;
            try
            { 
                id_descuento = int.Parse(lblID.Text);
                cargarLineas(id_descuento, false);
                timer1.Enabled = false;
            }
            catch (Exception) { timer1.Enabled = false; }
        }

        private bool validaPVPvsDescuento(string idProducto)
        {
            try
            {
                decimal porDes = nudPorcentaje.Value;
                var producto =  NProductos.obtener_datos(idProducto);
                decimal pvp = 0;
                decimal pvf = 0;
                decimal descuento = 0;
                decimal precioVentaFinal = 0;

                if (producto.Rows.Count>0)
                {
                    pvp =  decimal.Parse( producto.Rows[0]["PVP"].ToString());
                    pvf = decimal.Parse(producto.Rows[0]["PVF"].ToString());

                    if (pvf >0)
                    {
                        descuento = ((porDes / 100) * pvp);
                        precioVentaFinal = pvp - descuento;

                        if (precioVentaFinal< pvf)
                        {
                            MessageBox.Show("Descuento  no debe de exeder el precio de compra del producto: P.Compra: " + pvf + ",P.Venta:" + pvp + ",Menos descuento: " + descuento + "Precio venta final:" + precioVentaFinal + " como se podra observar en los valores el precio de venta-descuento es menor al precio de compra.", "Datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El precio de compra es menor o igual a cero", "Error al validar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar validar el Precio de compra vs el precio de descuento: " + ex.Message, "Error al validar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int id_descuento = 0;
            try
            {
                id_descuento = int.Parse(lblID.Text);
                cargarLineas(id_descuento, true);
                timer2.Enabled = false;
            }
            catch (Exception) { timer2.Enabled = false; }
        }
    }
}
