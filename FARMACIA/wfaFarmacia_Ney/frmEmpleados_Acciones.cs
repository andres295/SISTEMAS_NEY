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
    public partial class frmEmpleados_Acciones : Form
    {
        private string vCedula ="";
        public frmEmpleados_Acciones(string cedulaActual = "" )
        {
            InitializeComponent();
            vCedula = cedulaActual;
        }

        public bool accion;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.mtxtCedula.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número de cédula", this.btnGuardar, 0, 38, 3000);
                    this.mtxtCedula.Focus();
                    return;
                }
                else if (this.txtPrimerNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese los nombres y apellidos", this.btnGuardar, 0, 38, 3000);
                    this.txtPrimerNombre.Focus();
                    return;
                }
                else if (NEmpleados.verificar_ced(this.mtxtCedula.Text,vCedula) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este número de cédula ya existe", this.btnGuardar, 0, 38, 3000);
                    this.mtxtCedula.Focus();
                    return;
                }

                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NEmpleados.guardar(this.mtxtCedula.Text, this.txtPrimerNombre.Text, this.cmbGenero.Text, this.dtpNacimiento.Value, this.txtProfesion.Text, (this.mtxtTelefono.Text == "" ? "" : this.mtxtTelefono.Text), this.txtDireccion.Text))
                    {
                        frmEmpleados.me.txtRegistros.Text = NEmpleados.num_reg().ToString("N0");
                        frmEmpleados.me.txtBuscar.Enabled = true;

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El empleado ha sido guardado", this.btnGuardar, 0, 38, 2000);

                        this.mtxtCedula.Text = "";
                        this.txtPrimerNombre.Text = "";
                        this.cmbGenero.SelectedIndex = 0;
                        this.dtpNacimiento.Value = DateTime.Today;
                        this.txtProfesion.Text = "";
                        this.mtxtTelefono.Text = "";
                        this.txtDireccion.Text = "";
                        this.mtxtCedula.Focus();
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (NEmpleados.modificar(Convert.ToInt32(frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[0].Value), this.mtxtCedula.Text, this.txtPrimerNombre.Text, this.cmbGenero.Text, this.dtpNacimiento.Value, this.txtProfesion.Text, this.txtDireccion.Text, this.mtxtTelefono.Text))
                    {
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[1].Value = this.mtxtCedula.Text;
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[2].Value = this.txtPrimerNombre.Text;
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[3].Value = this.cmbGenero.Text;
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[4].Value = this.dtpNacimiento.Value.ToShortDateString();
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[5].Value = this.txtProfesion.Text;
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[6].Value = this.mtxtTelefono.Text;
                        frmEmpleados.me.dgvEmpleados.CurrentRow.Cells[7].Value = this.txtDireccion.Text;
                        
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtCedula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtCedula.MaskFull == true)
                    this.txtPrimerNombre.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull == true)
                    this.txtDireccion.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpNacimiento_CloseUp(object sender, EventArgs e)
        {
            this.txtProfesion.Focus();
        }

        private void cmbGenero_DropDownClosed(object sender, EventArgs e)
        {
            this.dtpNacimiento.Focus();
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtProfesion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmEmpleados_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmEmpleados.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void cmbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void dtpNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void frmEmpleados_Acciones_Load(object sender, EventArgs e)
        {
            this.txtPrimerNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtProfesion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            this.mtxtCedula.Mask = cGeneral.formato_cedula;
            this.mtxtTelefono.Mask = cGeneral.formato_telefono;
        }
    }
}
