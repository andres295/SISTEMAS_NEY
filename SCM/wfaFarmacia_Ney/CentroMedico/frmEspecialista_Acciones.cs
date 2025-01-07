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

namespace SCM.CentroMedico
{
    public partial class frmEspecialista_Acciones : Form
    {
        public static frmEspecialista_Acciones me;
        private string vCedula ="";
        public string idMedico = "";
        public bool userExterno = false;
        public int idEspecialista = 0;
        public bool isNuevo = false;
        public frmEspecialista_Acciones(string cedulaActual = "" )
        {
            frmEspecialista_Acciones.me = this;
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
                else if (NEspecialista.verificar_ced(this.mtxtCedula.Text,vCedula) > 0)
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
                    int pidEspecialista = NEspecialista.guardar(this.mtxtCedula.Text, this.txtPrimerNombre.Text, this.cmbGenero.Text, this.dtpNacimiento.Value, this.txtProfesion.Text, (this.mtxtTelefono.Text == "" ? "" : this.mtxtTelefono.Text), this.txtDireccion.Text);
                    if (pidEspecialista > 0)
                    {
                        if (!userExterno)
                        {
                            frmEspecialista.me.txtRegistros.Text = NEspecialista.num_reg().ToString("N0");
                            frmEspecialista.me.txtBuscar.Enabled = true;
                            this.accion = true;
                            vCedula = mtxtCedula.Text;
                            idEspecialista = pidEspecialista;
                            btnRefrescarPresentacion.Enabled = true;
                            btnComposicionProducto.Enabled = true;

                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El especialista ha sido guardado. Ahora debe de agregar las especialidades de este.", this.btnGuardar, 0, 38, 2000);

                            //this.mtxtCedula.Text = "";
                            //this.txtPrimerNombre.Text = "";
                            //this.cmbGenero.SelectedIndex = 0;
                            //this.dtpNacimiento.Value = DateTime.Today;
                            //this.txtProfesion.Text = "";
                            //this.mtxtTelefono.Text = "";
                            //this.txtDireccion.Text = "";
                            //this.mtxtCedula.Focus();
                        }
                        else
                        {
                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El especialista ha sido guardado. Ahora debe de agregar las especialidades de este.", this.btnGuardar, 0, 38, 2000);

                        }
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (NEspecialista.modificar(idEspecialista, this.mtxtCedula.Text, this.txtPrimerNombre.Text, this.cmbGenero.Text, this.dtpNacimiento.Value, this.txtProfesion.Text, this.txtDireccion.Text, this.mtxtTelefono.Text,cbEstado.Checked))
                    {
                        if (!isNuevo)
                        {
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[1].Value = this.mtxtCedula.Text;
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[2].Value = this.txtPrimerNombre.Text;
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[3].Value = this.cmbGenero.Text;
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[4].Value = this.dtpNacimiento.Value.ToString("yyyy-MM-dd");
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[5].Value = this.txtProfesion.Text;
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[6].Value = this.mtxtTelefono.Text;
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[7].Value = this.txtDireccion.Text;
                            frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[8].Value = cbEstado.Checked;

                            this.Close();
                        }
                        else
                        {
                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El especialista ha sido guardado. Ahora debe de agregar las especialidades de este.", this.btnGuardar, 0, 38, 2000);

                        }
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

        private void frmEspecialista_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userExterno)
            { 
                try
                {
                    frmEspecialista.me.tEnfoque.Enabled = true;
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
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

        private void frmEspecialista_Acciones_Load(object sender, EventArgs e)
        {
            this.txtPrimerNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtProfesion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            this.mtxtCedula.Mask = cGeneral.formato_cedula;
            this.mtxtTelefono.Mask = cGeneral.formato_telefono;
            if (accion)
            {
                cargarEspecialidad();
            }
            else {
                txtProfesion.Enabled = false;
            }
        }
        private void cargarEspecialidad()
        {
            try
            {
                try
                {
                    string composicion = NEspecialidad.obtener_especialidad_by_medico_by_id(idEspecialista.ToString(), false);
                    if (composicion != "")
                    {
                        txtProfesion.Text = composicion;
                    }
                    else { txtProfesion.Enabled = false; }
                }
                catch (Exception)
                {

                    string composicion = NEspecialidad.obtener_especialidad_by_medico_by_id(idMedico, false);
                    if (composicion != "")
                    {
                        txtProfesion.Text = composicion;
                    }
                    else { txtProfesion.Enabled = false; }
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
                    CentroMedico.frmEspecialidadMedico frm = new CentroMedico.frmEspecialidadMedico();
                    frm.IdMedico = idEspecialista.ToString();
                    frm.Text = "ESPECIALIDADES";
                    frm.ShowDialog();
                }
                catch (Exception)
                {

                    CentroMedico.frmEspecialidadMedico frm = new CentroMedico.frmEspecialidadMedico();
                    frm.IdMedico = idMedico;
                    frm.Text = "ESPECIALIDADES";
                    frm.ShowDialog();
                }

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnRefrescarPresentacion_Click(object sender, EventArgs e)
        {
            cargarEspecialidad();
        }
    }
}
