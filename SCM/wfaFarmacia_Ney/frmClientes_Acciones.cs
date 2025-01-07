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
    public partial class frmClientes_Acciones : Form
    {
        string vCedula = "";
        string vRuc = "";
        public frmClientes_Acciones(string cedulaActual = "", string rucActual = "")
        {
            InitializeComponent();
            vCedula = cedulaActual;
            vRuc = rucActual;
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool externalUse = false;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                try
                {
                    int.Parse(this.cmbTipoIdentificacion.Value.ToString());
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el tipo de documento del cliente", this.btnGuardar, 0, 38, 3000);
                    this.cmbTipoIdentificacion.Focus();
                    return;
                }

                if (this.mtxtCedula.Text == "" && this.mtxtRUC.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número de cédula/RUC", this.btnGuardar, 0, 38, 3000);
                    this.mtxtCedula.Focus();
                    return;
                }
                else if (this.mtxtCedula.Text != "" && this.mtxtRUC.Text != "")
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("No se puede registrar número de cédula y RUC a\nla misma vez. Favor, elija una sóla.", this.btnGuardar, 0, 38, 6000);
                    this.mtxtCedula.Focus();
                    return;
                }
                else if (this.txtPrimerNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese los nombres y apellidos", this.btnGuardar, 0, 38, 2000);
                    this.txtPrimerNombre.Focus();
                    return;
                }
                //else if (this.txtCorreo.Text == "")
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Ingrese el correo electrónico", this.btnGuardar, 0, 38, 2000);
                //    this.txtCorreo.Focus();
                //    return;
                //}
                else if (this.mtxtTelefono.Text != "")
                    if (this.mtxtTelefono.MaskFull == false)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("El número de teléfono está incompleto", this.btnGuardar, 0, 38, 3000);
                        this.mtxtTelefono.Focus();
                        return;
                    }
                 else if (NClientes.verificar_ced(this.mtxtCedula.Text, vCedula) > 0 && this.mtxtCedula.Text.Length >0)
                    {
                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("Este número de cédula ya existe", this.btnGuardar, 0, 38, 3000);
                        this.mtxtCedula.Focus();
                        return;
                    }
                else if (NClientes.verificar_ruc(this.mtxtRUC.Text, vRuc) > 0 && this.mtxtRUC.Text.Length > 0)
                    {
                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("Este número RUC ya existe", this.btnGuardar, 0, 38, 3000);
                        this.mtxtRUC.Focus();
                        return;
                   }
                else if (int.Parse(this.cmbTipoIdentificacion.Value.ToString())<=0)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Seleccione el tipo de documento del cliente", this.btnGuardar, 0, 38, 3000);
                        this.cmbTipoIdentificacion.Focus();
                        return;
                    }
                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NClientes.guardar(this.mtxtCedula.Text, this.mtxtRUC.Text, this.txtPrimerNombre.Text, (this.mtxtTelefono.Text == "" ? "":this.mtxtTelefono.Text), this.txtDireccion.Text, this.txtCorreo.Text,txtCiudad.Text, Convert.ToInt32(this.cmbTipoIdentificacion.Value)))
                    {
                        if (!externalUse)
                        {
                            frmClientes.me.txtRegistros.Text = NClientes.num_reg().ToString("N0");
                            frmClientes.me.txtBuscar.Enabled = true;

                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El cliente ha sido guardado", this.btnGuardar, 0, 38, 2000);

                            this.mtxtCedula.Text = "";
                            this.mtxtRUC.Text = "";
                            this.txtPrimerNombre.Text = "";
                            this.mtxtTelefono.Text = "";
                            this.txtDireccion.Text = "";
                            this.mtxtCedula.Focus();
                            return;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (NClientes.modificar(Convert.ToInt32(frmClientes.me.dgvClientes.CurrentRow.Cells[0].Value), this.mtxtCedula.Text, this.mtxtRUC.Text, this.txtPrimerNombre.Text, (this.mtxtTelefono.Text == "" ? "":this.mtxtTelefono.Text), this.txtDireccion.Text, this.txtCorreo.Text,txtCiudad.Text, Convert.ToInt32(this.cmbTipoIdentificacion.Value)))
                    {
                        frmClientes.me.dgvClientes.CurrentRow.Cells[1].Value = this.mtxtCedula.Text;
                        frmClientes.me.dgvClientes.CurrentRow.Cells[2].Value = this.mtxtRUC.Text;
                        frmClientes.me.dgvClientes.CurrentRow.Cells[3].Value = this.txtPrimerNombre.Text;
                        frmClientes.me.dgvClientes.CurrentRow.Cells[4].Value = this.txtCorreo.Text;
                        frmClientes.me.dgvClientes.CurrentRow.Cells[5].Value = this.mtxtTelefono.Text;
                        frmClientes.me.dgvClientes.CurrentRow.Cells[6].Value = this.txtDireccion.Text;

                        this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmClientes_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

                if (frm != null)
                    frmClientes.me.tEnfoque.Enabled = true;

                Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_Acciones);

                if (frm1 != null)
                    frmVentas_Acciones.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtCedula_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtCedula.MaskFull)
                    this.mtxtCedula.Select(0, this.mtxtCedula.TextLength);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtRUC_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtRUC.MaskFull)
                    this.mtxtRUC.Select(0, this.mtxtRUC.TextLength);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPrimerNombre_Enter(object sender, EventArgs e)
        {
            this.txtPrimerNombre.Select(0, this.txtPrimerNombre.TextLength);
        }

        private void mtxtTelefono_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull)
                    this.mtxtTelefono.Select(0, this.mtxtTelefono.TextLength);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            this.txtDireccion.Select(0, this.txtDireccion.TextLength);
        }

        private void mtxtCedula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtCedula.MaskFull)
                    this.mtxtRUC.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtRUC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtRUC.MaskFull)
                    this.txtPrimerNombre.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull)
                    this.txtDireccion.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
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

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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

        private void frmClientes_Acciones_Load(object sender, EventArgs e)
        {
            this.txtPrimerNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtCorreo.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            this.mtxtCedula.Mask = cGeneral.formato_cedula;
            this.mtxtRUC.Mask = cGeneral.formato_ruc;
            this.mtxtTelefono.Mask = cGeneral.formato_telefono;

            this.cmbTipoIdentificacion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
        }

        private void mtxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mtxtCedula.Text.Length > 0)
            {
                mtxtRUC.Text = "";
            }else { mtxtCedula.Text = ""; }
            cGeneral.quitar_sonido_txt(e);
        }

        private void mtxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mtxtRUC.Text.Length>0)
            {
                mtxtCedula.Text = "";
            }else { mtxtRUC.Text = ""; }

            cGeneral.quitar_sonido_txt(e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }
    }
}
