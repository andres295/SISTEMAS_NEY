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
    public partial class frmBancos_Acciones : Form
    {
        public frmBancos_Acciones()
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
                    this.ttMensaje.Show("Ingrese el nombre del banco", this.btnGuardar, 0, 38, 3000);
                    this.txtBanco.Focus();
                    return;
                }
                else if (this.mtxtTelefono.Text != "")
                    if (this.mtxtTelefono.MaskFull == false)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("El número de teléfono está incompleto", this.btnGuardar, 0, 38, 3000);
                        this.mtxtTelefono.Focus();
                        return;
                    }

                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NBancos.guardar(this.txtBanco.Text, (this.mtxtTelefono.Text == "" ? "":this.mtxtTelefono.Text), this.txtCorreo.Text, this.txtDireccion.Text))
                    {
                        frmBancos.me.txtRegistros.Text = NBancos.num_reg().ToString("N0");
                        frmBancos.me.txtBuscar.Enabled = true;

                        this.txtBanco.Text = "";
                        this.mtxtTelefono.Text = "";
                        this.txtCorreo.Text = "";
                        this.txtDireccion.Text = "";
                        this.txtBanco.Focus();

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El banco ha sido guardado", this.btnGuardar, 0, 38, 3000);
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (this.txtBanco.Text != frmBancos.me.dgvBancos.CurrentRow.Cells[1].Value.ToString())
                    {
                        if (NBancos.verificar_si_existe(this.txtBanco.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Ya existe éste nombre", this.btnGuardar, 0, 38, 3000);
                            this.txtBanco.Focus();
                            return;
                        }
                    }

                    if (NBancos.modificar(Convert.ToInt32(frmBancos.me.dgvBancos.CurrentRow.Cells[0].Value), this.txtBanco.Text, this.mtxtTelefono.Text, this.txtCorreo.Text, this.txtDireccion.Text))
                    {
                        frmBancos.me.dgvBancos.CurrentRow.Cells[1].Value = this.txtBanco.Text;
                        frmBancos.me.dgvBancos.CurrentRow.Cells[2].Value = this.mtxtTelefono.Text;
                        frmBancos.me.dgvBancos.CurrentRow.Cells[3].Value = this.txtCorreo.Text;
                        frmBancos.me.dgvBancos.CurrentRow.Cells[4].Value = this.txtDireccion.Text;
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
                frmBancos.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull)
                    this.txtCorreo.Focus();
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

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            this.txtCorreo.Select(0, this.txtCorreo.TextLength);
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            this.txtDireccion.Select(0, this.txtDireccion.TextLength);
        }

        private void mtxtTelefono_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull)
                    this.mtxtTelefono.Select(0, this.mtxtTelefono.TextLength);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
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
            this.txtCorreo.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            this.mtxtTelefono.Mask = cGeneral.formato_telefono;
        }
    }
}
