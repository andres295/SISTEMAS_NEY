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

namespace wfaFarmacia_Ney
{
    public partial class frmCargoCompra_Opciones : Form
    {
        decimal por_descuento = 0;
        public frmCargoCompra_Opciones()
        {
            InitializeComponent();
        }

        private void frmCargoCompra_Opciones_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = NCargoCompra.obtener_datos(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
                this.cbIVA.Text = "IVA " + cGeneral.IVA.ToString("N" + cGeneral.decimales + "") + "%:";
                /////this.cbDesc.Text = "DESCUENTO " + Convert.ToDecimal(dt.Rows[0].ItemArray[6].ToString()).ToString("N" + cGeneral.decimales + "") + "%:";
                /////por_descuento = Convert.ToDecimal(dt.Rows[0].ItemArray[6].ToString());
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbIVA_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.panel1.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbDesc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.panel2.Focus();
              if (cbDesc.Checked)
                {
                    nuDescuento.Enabled = true;
                }
                else
                {
                    nuDescuento.Enabled = false;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            { 
                if (this.cbDesc.Checked == true)
                {
                    if (nuDescuento.Value>0)
                    {
                        por_descuento = nuDescuento.Value;
                        //APLICAR.
                        if (this.rbtnDesc_Todos.Checked == true)
                            NCargoCompra.aplicar_quitar_desc_todos(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), true, por_descuento);
                        else
                            NCargoCompra.aplicar_quitar_desc_sel(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), true, por_descuento);

                         NCargoCompra.actualizar_iva(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), cGeneral.IVA);
                    }
                    else
                    {
                        MessageBox.Show("El porcentaje del descuento tiene que ser mayor a cero.", "Ingresar descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
                else
                {
                    //QUITAR.
                    if (this.rbtnDesc_Todos.Checked == true)
                        NCargoCompra.aplicar_quitar_desc_todos(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), false,0);
                    else
                        NCargoCompra.aplicar_quitar_desc_sel(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), false,0);

                    NCargoCompra.actualizar_iva(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), cGeneral.IVA);
                }
                if (this.cbIVA.Checked == true)
                {
                    //APLICAR.
                    if (this.rbtnIVA_Todos.Checked == true)
                        NCargoCompra.aplicar_quitar_iva_todos(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), true, cGeneral.IVA);
                    else
                        NCargoCompra.aplicar_quitar_iva_sel(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), true, cGeneral.IVA);
                }
                else
                {
                    //QUITAR.
                    if (this.rbtnIVA_Todos.Checked == true)
                        NCargoCompra.aplicar_quitar_iva_todos(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), false, cGeneral.IVA);
                    else
                        NCargoCompra.aplicar_quitar_iva_sel(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(), false, cGeneral.IVA);
                }

                for (int i = 0; i < frmCargoCompra.me.dgvProductos.Rows.Count; i++)
                {
                    DataTable dt = NCargoCompra.obtener_totales_fila(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.Rows[i].Cells[0].Value.ToString(), frmCargoCompra.me.dgvProductos.Rows[i].Cells[14].Value.ToString());
                    frmCargoCompra.me.dgvProductos.Rows[i].Cells[7].Value = dt.Rows[0].ItemArray[0].ToString();
                    frmCargoCompra.me.dgvProductos.Rows[i].Cells[8].Value = dt.Rows[0].ItemArray[4].ToString();
                    frmCargoCompra.me.dgvProductos.Rows[i].Cells[9].Value = dt.Rows[0].ItemArray[2].ToString();
                    frmCargoCompra.me.dgvProductos.Rows[i].Cells[10].Value = dt.Rows[0].ItemArray[1].ToString();
                    frmCargoCompra.me.dgvProductos.Rows[i].Cells[11].Value = dt.Rows[0].ItemArray[3].ToString();
                }

                this.Close();
                cargar_totales(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString());
            }
            
            catch (Exception ex) { cGeneral.error(ex); }
        }
        public void cargar_totales(string fact)
        {
            try
            {
                DataTable dt_datos = NCargoCompra.obtener_totales(fact);

                if (dt_datos.Rows[0].ItemArray[0].ToString() == "")
                    frmCargoCompra.me.lblSubtotal.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblSubtotal.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[0].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[1].ToString() == "")
                    frmCargoCompra.me.lblIVA.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblIVA.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[1].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[2].ToString() == "")
                    frmCargoCompra.me.lblDescuento.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblDescuento.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[2].ToString()).ToString("N" + cGeneral.decimales + "");

                if (dt_datos.Rows[0].ItemArray[3].ToString() == "")
                    frmCargoCompra.me.lblTotalPagar.Text = Convert.ToDecimal(0).ToString("N" + cGeneral.decimales + "");
                else
                    frmCargoCompra.me.lblTotalPagar.Text = Convert.ToDecimal(dt_datos.Rows[0].ItemArray[3].ToString()).ToString("N" + cGeneral.decimales + "");
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
