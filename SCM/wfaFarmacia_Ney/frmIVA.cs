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
    public partial class frmIVA : Form
    {
        public frmIVA()
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
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.nudPVF.Text == "" || this.nudPVF.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el IVA", this.btnGuardar, 0, 38, 3000);
                    this.nudPVF.Focus();
                    return;
                }
                else if (this.txtCodSri.Text.Trim() == ""  )
                {
                    this.ttMensaje.ToolTipTitle = "OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Código del SRI", this.btnGuardar, 0, 38, 3000);
                    this.txtCodSri.Focus();
                    return;
                }
                else if (this.txtCodPorcSRI.Text.Trim() == "")
                {
                    this.ttMensaje.ToolTipTitle = "OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Código del porcentaje del SRI", this.btnGuardar, 0, 38, 3000);
                    this.txtCodPorcSRI.Focus();
                    return;
                }
                else if (this.txtCodPorcSRI.Text.Trim() == "")
                {
                    this.ttMensaje.ToolTipTitle = "OBLIGATORIO";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el Código del porcentaje del SRI", this.btnGuardar, 0, 38, 3000);
                    this.txtCodPorcSRI.Focus();
                    return;
                }
                if (NIVA.guardar(this.nudPVF.Text,txtCodSri.Text,txtCodPorcSRI.Text))
                {
                    cGeneral.IVA = this.nudPVF.Value;
                    cGeneral.IVA_COD_SRI = this.txtCodSri.Text;
                    cGeneral.IVA_PORC_SRI = this.txtCodPorcSRI.Text;
                    this.Close();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudPVF_Enter(object sender, EventArgs e)
        {
            cGeneral.nud_entra_dec_focus(this.nudPVF);
        }

        private void frmEspecificarIVA_Load(object sender, EventArgs e)
        {
            try
            {
                this.nudPVF.Value = cGeneral.IVA;
                this.txtCodSri.Text = cGeneral.IVA_COD_SRI;
                this.txtCodPorcSRI.Text = cGeneral.IVA_PORC_SRI;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nudPVF_Leave(object sender, EventArgs e)
        {
            cGeneral.nud_pierde_dec_focus(this.nudPVF);
        }

        private void nudPVF_KeyDown(object sender, KeyEventArgs e)
        {
            cGeneral.quitar_sonido_nud(e);

            if (e.KeyValue == 13)
                click_guardar();
        }

        private void nudPVF_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.solo_numeros_con_decimal(e);
        }
    }
}
