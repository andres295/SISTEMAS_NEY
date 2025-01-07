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

namespace SCM
{
    public partial class frmCargoCompra_Agregar : Form
    {
        public frmCargoCompra_Agregar()
        {
            InitializeComponent();
        }

        public bool accion;
        public string fact_captada;
        public string num_fac_rec = "";

        private void frmCargoCompra_Agregar_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtObserv.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                this.mtxtFactura.Mask = cGeneral.formato_factura;
                this.cmbProveedor.MaxDropDownItems = cGeneral.num_lista_cmb;

                if (this.accion)
                {
                    this.lblFechaPago.Text = this.dtpFechaDoc.Value.AddDays(Convert.ToDouble(this.nudDiasPago.Value)).ToShortDateString();

                    this.cmbProveedor.DataSource = NProveedores.lista_combo();
                    this.cmbProveedor.ValueMember = "Id";
                    this.cmbProveedor.DisplayMember = "Proveedor";

                    if (this.cmbProveedor.Items.Count > 0)
                        this.cmbProveedor.SelectedIndex = 0;
                }
                this.cmbProveedor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtxtFactura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtFactura.MaskFull)
                    this.dtpFechaDoc.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.mtxtFactura.MaskFull == false)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("El número de factura está incompleto", this.btnGuardar, 0, 38, 3000);
                    this.mtxtFactura.Focus();
                    return;
                }
                else if (this.cmbProveedor.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La lista de proveedores está vacía", this.btnGuardar, 0, 38, 3000);
                    this.cmbProveedor.Focus();
                    this.cmbProveedor.DroppedDown = true;
                    return;
                }
                else if (this.nudDiasPago.Enabled)
                {
                    if (this.nudDiasPago.Value == 0 || this.nudDiasPago.Text == "")
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ingrese el número de días", this.btnGuardar, 0, 38, 3000);
                        this.nudDiasPago.Focus();
                        return;
                    }
                }
               

                string est;

                if (frmCargoCompra.me.tipo_pago)
                    est = "CANCELADO";
                else
                    est = "POR PAGAR";

                this.lblFechaPago.Text = this.dtpFechaDoc.Value.AddDays(Convert.ToDouble(this.nudDiasPago.Value)).Date.ToShortDateString();

                if (accion)
                {
                    //AGREGAR.
                    if (!NCargoCompra.siFacturaExiste(this.mtxtFactura.Text))
                    {
                        NCargoCompra.guardar_fact(this.mtxtFactura.Text, Convert.ToInt32(this.cmbProveedor.Value), this.dtpFechaDoc.Value, Convert.ToInt32(this.nudDiasPago.Value), Convert.ToDateTime(this.lblFechaPago.Text), "0", 0, this.txtObserv.Text, est);
                        frmCargoCompra.me.txtRegistros.Text = Convert.ToDecimal(frmCargoCompra.me.dgvProductos.Rows.Count.ToString()).ToString("N0");

                        this.fact_captada = this.mtxtFactura.Text;

                        this.mtxtFactura.Text = "";
                        this.cmbProveedor.SelectedIndex = 0;
                        this.dtpFechaDoc.Value = DateTime.Today.Date;
                        this.nudDiasPago.Value = 0;
                        this.lblFechaPago.Text = this.dtpFechaDoc.Value.AddDays(Convert.ToDouble(this.nudDiasPago.Value)).Date.ToShortDateString();
                        this.txtObserv.Text = "";

                        frmCargoCompra.me.txtBuscar.Enabled = true;
                        frmCargoCompra.me.directo = true;

                        frmCargoCompra.me.tBuscar.Enabled = false;
                        frmCargoCompra.me.tBuscar.Enabled = true;

                        this.Close();
                    }
                    else  {
                          MessageBox.Show("El nùmero de factura: " + this.mtxtFactura.Text + " ya esta registrado en sistema.", "NÙMERO DE FACTURA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.mtxtFactura.Focus();
                        this.mtxtFactura.ForeColor = Color.Red;
                    }
                    
                }
                else
                {
                    if (num_fac_rec != this.mtxtFactura.Text)
                    {
                        if (NCargoCompra.siFacturaExiste(this.mtxtFactura.Text))
                        {
                            MessageBox.Show("El nùmero de factura: " + this.mtxtFactura.Text + " ya esta registrado en sistema.", "NÙMERO DE FACTURA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.mtxtFactura.Focus();
                            this.mtxtFactura.ForeColor = Color.Red;
                        }
                        else
                        {
                            //MODIFICAR.
                            NCargoCompra.modificar(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.mtxtFactura.Text, Convert.ToInt32(this.cmbProveedor.Value), Convert.ToDateTime(this.dtpFechaDoc.Value), Convert.ToInt32(this.nudDiasPago.Value), Convert.ToDateTime(this.lblFechaPago.Text), this.txtObserv.Text, est, cGeneral.IVA,0);

                            frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value = this.mtxtFactura.Text;
                            frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[1].Value = this.cmbProveedor.Text;
                            frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[2].Value = this.dtpFechaDoc.Text;
                            frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[3].Value = this.nudDiasPago.Text;
                            frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[4].Value = this.lblFechaPago.Text;
                            frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[5].Value = est;


                            this.Close();
                        }
                    }
                    else
                    {
                        //MODIFICAR.
                        NCargoCompra.modificar(frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value.ToString(), this.mtxtFactura.Text, Convert.ToInt32(this.cmbProveedor.Value), Convert.ToDateTime(this.dtpFechaDoc.Value), Convert.ToInt32(this.nudDiasPago.Value), Convert.ToDateTime(this.lblFechaPago.Text), this.txtObserv.Text, est, cGeneral.IVA,0);

                        frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[0].Value = this.mtxtFactura.Text;
                        frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[1].Value = this.cmbProveedor.Text;
                        frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[2].Value = this.dtpFechaDoc.Text;
                        frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[3].Value = this.nudDiasPago.Text;
                        frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[4].Value = this.lblFechaPago.Text;
                        frmCargoCompra.me.dgvFacturas.CurrentRow.Cells[5].Value = est;

                        this.Close();
                    }
                 
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudDiasPago_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_ent_focus(this.nudDiasPago);
        }

        private void txtObserv_Enter(object sender, EventArgs e)
        {
            this.txtObserv.Select(0, this.txtObserv.Text.Length);
        }

        private void dtpFechaDoc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblFechaPago.Text = this.dtpFechaDoc.Value.AddDays(Convert.ToDouble(this.nudDiasPago.Value)).Date.ToShortDateString();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCargoCompra_Agregar_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.accion)
                    frmCargoCompra.me.txtBuscar.Text = this.fact_captada;

                frmCargoCompra.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudDiasPago_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_ent_focus(this.nudDiasPago);
        }

        private void tDias_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.nudDiasPago.Text == "")
                    this.lblFechaPago.Text = this.dtpFechaDoc.Value.AddDays(0).Date.ToShortDateString();
                else
                    this.lblFechaPago.Text = this.dtpFechaDoc.Value.AddDays(Convert.ToDouble(this.nudDiasPago.Text)).Date.ToShortDateString();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudDiasPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_enteros(e);
        }

        private void nudIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void nudDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }

        private void mtxtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpFechaDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void nudDiasPago_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void nudIVA_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void nudDesc_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);
        }

        private void txtObserv_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
    }
}
