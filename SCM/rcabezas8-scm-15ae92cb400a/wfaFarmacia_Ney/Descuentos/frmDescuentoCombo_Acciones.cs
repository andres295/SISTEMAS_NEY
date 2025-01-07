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

namespace SCM.Descuentos
{
    public partial class frmDescuentoCombo_Acciones : Form
    {
        public bool accion;
        public string id_combo;

        public frmDescuentoCombo_Acciones()
        {
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
            try
            {
                if (this.txtDescripcion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la descripción", this.btnGuardar, 0, 38, 3000);
                    this.txtDescripcion.Focus();
                    return;
                }
                else if (this.nudPrecioCombo.Value <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el precio del combo.", this.btnGuardar, 0, 38, 3000);
                    this.nudPrecioCombo.Focus();
                    this.nudPrecioCombo.Select(0, this.nudPrecioCombo.Text.Length);
                    return;
                }
                else if (this.nudCantidadMinima.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la cantidad minima.", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidadMinima.Focus();
                    this.nudCantidadMinima.Select(0, this.nudCantidadMinima.Text.Length);
                    return;
                }
                else if (this.nudCantidadMaxima.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la cantidad máxima.", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidadMaxima.Focus();
                    this.nudCantidadMaxima.Select(0, this.nudCantidadMaxima.Text.Length);
                    return;
                }
                else if (nudCantidadMinima.Value > this.nudCantidadMaxima.Value)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La cantidad minima no puede ser mayor a la cantidad máxima.", this.btnGuardar, 0, 38, 3000);
                    this.nudCantidadMinima.Focus();
                    this.nudCantidadMinima.Select(0, this.nudCantidadMinima.Text.Length);
                    return;
                }
                else if(this.dtpFechaInicio.Value < DateTime.Now.Date)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la fecha de inicio mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                    this.dtpFechaInicio.Focus();
                    return;
                }
                else if(this.dtpFechaFin.Value <= DateTime.Now.Date)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la fecha de fin mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                    this.dtpFechaFin.Focus();
                    return;
                }
                else if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", this.btnGuardar, 0, 38, 3000);
                    this.dtpFechaInicio.Focus();
                    return;
                }
                if (accion)
                {
                    NDescuentos.guardar_descuento_combo( this.txtDescripcion.Text,nudPrecioCombo.Value,int.Parse(nudCantidadMinima.Value.ToString()),int.Parse(nudCantidadMaxima.Value.ToString()), Convert.ToDateTime(this.dtpFechaInicio.Value), Convert.ToDateTime(this.dtpFechaFin.Value), cGeneral.name_user);
                    Descuentos.frmDescuentoCombo.me.txtRegistros.Text = NDescuentos.num_reg_decuento_combo().ToString("N0"); 
                    Descuentos.frmDescuentoCombo.me.txtBuscar.Text = this.txtDescripcion.Text;
                    Descuentos.frmDescuentoCombo.me.txtBuscar.Enabled = true;
                }
                else
                {
                    try
                    {
                        if (int.Parse(lblID.Text) > 0)
                        {
                            NDescuentos.modificar_descuento_combo(lblID.Text, this.txtDescripcion.Text, nudPrecioCombo.Value, int.Parse(nudCantidadMinima.Value.ToString()), int.Parse(nudCantidadMaxima.Value.ToString()), Convert.ToDateTime(this.dtpFechaInicio.Value), Convert.ToDateTime(this.dtpFechaFin.Value),cbEstado.Checked);
                            Descuentos.frmDescuentoCombo.me.txtRegistros.Text = NDescuentos.num_reg_decuento_combo().ToString("N0");
                            Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[1].Value = txtDescripcion.Text;
                            Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[2].Value = nudPrecioCombo.Value;
                            Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[3].Value = nudCantidadMinima.Value;
                            Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[4].Value = nudCantidadMaxima.Value;
                            Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[5].Value = dtpFechaInicio.Value;
                            Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[6].Value = dtpFechaFin.Value;
                            if (cbEstado.Checked)
                            {
                                Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[8].Value = "ACTIVO";
                            }
                            else
                            {
                                Descuentos.frmDescuentoCombo.me.dgvCombo.CurrentRow.Cells[8].Value = "INACTIVO";
                            }

                            Descuentos.frmDescuentoCombo.me.txtBuscar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontro ningun ID para modificar", "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se encontro ningun ID para modificar", "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                Descuentos.frmDescuentoCombo.me.tBuscar.Enabled = false;
                Descuentos.frmDescuentoCombo.me.tBuscar.Enabled = true;

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbProveedor_DropDownClosed(object sender, EventArgs e)
        {
            this.dtpFechaInicio.Focus();
        }

        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            Descuentos.frmDescuentoCombo.me.tEnfoque.Enabled = true;
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

        private void frmDescuentoCombo_Acciones_Load(object sender, EventArgs e)
        {
            lblID.Text = id_combo;
            this.txtDescripcion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        } 
    }
}
