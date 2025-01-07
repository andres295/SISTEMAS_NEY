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

namespace SCM.Catalogos
{
    public partial class frmCatalogo_Acciones : Form
    {
        public static frmCatalogo_Acciones me;

        public frmCatalogo_Acciones()
        {
            frmCatalogo_Acciones.me = this;
            InitializeComponent();
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool externalUse = false;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.txtNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el catálogo", this.btnGuardar, 0, 38, 3000);
                    this.txtNombre.Focus();
                    return;
                }
                try
                {
                    int.Parse(cmbTipo.Value.ToString());
                    //if (!NCatalogo.verificar_si_existe_tipo_catalogo(this.cmbTipo.Text))
                    //{
                        //this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        //this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        //this.ttMensaje.Show("El tipo de catálogo ingresado no existe.", this.btnGuardar, 0, 38, 3000);
                        //this.cmbTipo.Focus();
                        //return;
                    //}
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el tipo del catálogo", this.btnGuardar, 0, 38, 3000);
                    this.cmbTipo.Focus();
                    return;
                }
                if (this.accion == false)
                {
                    //AGREGAR.
                    if (!NCatalogo.verificar_si_existe(this.txtNombre.Text))
                    {
                        if (NCatalogo.guardar(this.txtNombre.Text,  int.Parse(cmbTipo.Value.ToString()),txtCodigo.Text))
                        {
                            if (!externalUse)
                            {
                                Catalogos.frmCatalogo.me.txtRegistros.Text = NCatalogo.num_reg().ToString("N0");
                                Catalogos.frmCatalogo.me.txtBuscar.Enabled = true;

                                this.txtNombre.Text = "";
                                this.txtNombre.Focus();

                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                this.ttMensaje.Show("El catálogo ha sido guardado", this.btnGuardar, 0, 38, 3000);
                            }
                            else
                            {
                                this.Close();
                            }
                        } 
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Ya existe una catálogo con ese nombre", this.btnGuardar, 0, 38, 3000);
                        this.txtNombre.Focus();
                        return;
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (this.txtNombre.Text != Catalogos.frmCatalogo.me.dgvcatalogo.CurrentRow.Cells[1].Value.ToString())
                    {
                        if (NCatalogo.verificar_si_existe(this.txtNombre.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Ya existe catálogo", this.btnGuardar, 0, 38, 3000);
                            this.txtNombre.Focus();
                            return;
                        }
                    }

                    if (NCatalogo.modificar(Convert.ToInt32(Catalogos.frmCatalogo.me.dgvcatalogo.CurrentRow.Cells[0].Value), txtNombre.Text,int.Parse(cmbTipo.Value.ToString()), cbEstado.Checked,txtCodigo.Text))
                    { 
                        Catalogos.frmCatalogo.me.dgvcatalogo.DataSource = NCatalogo.buscar(Catalogos.frmCatalogo.me.txtBuscar.Text); 
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void frmBancos_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!externalUse)
                {
                    Catalogos.frmCatalogo.me.tEnfoque.Enabled = true;
                } 
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }


        private void txtBanco_Enter(object sender, EventArgs e)
        {
            this.txtNombre.Select(0, this.txtNombre.TextLength);
        }


        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void frmBancos_Acciones_Load(object sender, EventArgs e)
        {
            this.txtNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            if (!accion)
            {
                cbEstado.Checked = true;
            }
            this.cmbTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            /// cargarTipoCatalogo();
        }
        private void cargarTipoCatalogo()
        {
            try
            {  
                cmbTipo.DataSource = NCatalogo.cargar_tipo_catalogo();
                cmbTipo.ValueMember = "Id";
                cmbTipo.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            { 
                throw;
            }

        }
    }
}
