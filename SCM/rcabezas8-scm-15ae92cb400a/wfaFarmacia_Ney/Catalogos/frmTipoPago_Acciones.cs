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
    public partial class frmTipoPago_Acciones : Form
    {
        public frmTipoPago_Acciones()
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

                if (this.txtBanco.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el tipo de pago", this.btnGuardar, 0, 38, 3000);
                    this.txtBanco.Focus();
                    return;
                }
                else if (this.txtCodSri.Text.Trim() == "")
                {
                    this.ttMensaje.ToolTipTitle = "OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Código del SRI", this.btnGuardar, 0, 38, 3000);
                    this.txtCodSri.Focus();
                    return;
                }
                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NTipoPago.guardar(this.txtBanco.Text,txtCodSri.Text.Trim()))
                    {
                        Catalogos.frmTipoPago.me.txtRegistros.Text = NTipoPago.num_reg().ToString("N0");
                        Catalogos.frmTipoPago.me.txtBuscar.Enabled = true;

                        this.txtBanco.Text = "";
                        this.txtBanco.Focus();

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El tipo de pago ha sido guardado", this.btnGuardar, 0, 38, 3000);
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (this.txtBanco.Text != Catalogos.frmTipoPago.me.dgvBancos.CurrentRow.Cells[1].Value.ToString())
                    {
                        if (NTipoPago.verificar_si_existe(this.txtBanco.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Ya existe éste nombre", this.btnGuardar, 0, 38, 3000);
                            this.txtBanco.Focus();
                            return;
                        }
                    }

                    if (NTipoPago.modificar(Convert.ToInt32(Catalogos.frmTipoPago.me.dgvBancos.CurrentRow.Cells[0].Value), txtBanco.Text,txtCodSri.Text.Trim(), cbEstado.Checked))
                    {
                        Catalogos.frmTipoPago.me.dgvBancos.CurrentRow.Cells[1].Value = this.txtBanco.Text;
                        Catalogos.frmTipoPago.me.dgvBancos.CurrentRow.Cells[2].Value = this.cbEstado.Checked;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        } 
        private void txtBanco_Enter(object sender, EventArgs e)
        {
            this.txtBanco.Select(0, this.txtBanco.TextLength);
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
            this.txtBanco.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
 
        }

        private void frmTipoPago_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Catalogos.frmTipoPago.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
    }
}
