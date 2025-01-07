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

namespace SCM.SRI
{
    public partial class frmSRIPorcRetencion_Acciones : Form
    {
        public frmSRIPorcRetencion_Acciones()
        {
            InitializeComponent();
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);
                if (this.txtDescripcion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la descripción del porcentaje", this.btnGuardar, 0, 38, 3000);
                    this.txtDescripcion.Focus();
                    return;
                }
                else if (this.nudPorcentaje.Value <=0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el porcentaje de retención", this.btnGuardar, 0, 38, 3000);
                    this.nudPorcentaje.Focus();
                    return;
                }
               
                else if (this.txtCodAnexo.Text.Trim() == "")
                {
                    this.ttMensaje.ToolTipTitle = "OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Código de ANEXO para la retención", this.btnGuardar, 0, 38, 3000);
                    this.txtCodAnexo.Focus();
                    return;
                }
                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NCatalogosGenerales.guardar(1,this.txtDescripcion.Text,nudPorcentaje.Value,txtCodAnexo.Text.Trim()))
                    {
                        SRI.frmSRIPorcRetencion.me.txtRegistros.Text = NCatalogosGenerales.num_reg(1).ToString("N0");
                        SRI.frmSRIPorcRetencion.me.txtBuscar.Enabled = true;

                        this.txtDescripcion.Text = "";
                        this.txtDescripcion.Focus();

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El porcentaje de retención ha sido guardado", this.btnGuardar, 0, 38, 3000);
                    }
                }
                else
                {
                    //MODIFICAR.
                    //if (this.txtDescripcion.Text != Catalogos.frmTipoPago.me.dgvBancos.CurrentRow.Cells[1].Value.ToString())
                    //{
                    //    if (NCatalogosGenerales.verificar_si_existe(this.txtDescripcion.Text))
                    //    {
                    //        this.ttMensaje.ToolTipTitle = "ERROR";
                    //        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    //        this.ttMensaje.Show("Ya existe ésta descripción", this.btnGuardar, 0, 38, 3000);
                    //        this.txtDescripcion.Focus();
                    //        return;
                    //    }
                    //}

                    if (NCatalogosGenerales.modificar(Convert.ToInt32(SRI.frmSRIPorcRetencion.me.dgvCatalogoGeneral.CurrentRow.Cells[0].Value), txtDescripcion.Text,nudPorcentaje.Value,txtCodAnexo.Text.Trim(), cbEstado.Checked))
                    {
                        SRI.frmSRIPorcRetencion.me.dgvCatalogoGeneral.CurrentRow.Cells[1].Value = this.txtDescripcion.Text;
                        SRI.frmSRIPorcRetencion.me.dgvCatalogoGeneral.CurrentRow.Cells[2].Value = this.nudPorcentaje.Value;
                        SRI.frmSRIPorcRetencion.me.dgvCatalogoGeneral.CurrentRow.Cells[3].Value = this.txtCodAnexo.Text;
                        SRI.frmSRIPorcRetencion.me.dgvCatalogoGeneral.CurrentRow.Cells[4].Value = this.cbEstado.Checked;
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
                SRI.frmSRIPorcRetencion.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }


        private void txtBanco_Enter(object sender, EventArgs e)
        {
            this.txtDescripcion.Select(0, this.txtDescripcion.TextLength);
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
            this.txtDescripcion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
 
        }
    }
}
