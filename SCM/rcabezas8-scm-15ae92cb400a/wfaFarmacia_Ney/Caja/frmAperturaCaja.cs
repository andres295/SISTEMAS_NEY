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

namespace SCM.Caja
{
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
           //// frmCargoAjuste.me.tEnfoque.Enabled = true;
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

    

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            nudMonto.Select(0, 99);
            nudMonto.Focus();

            decimal monto_apertura_caja = NCaja.verificar_si_existe(cGeneral.id_user_actual);
            if (monto_apertura_caja > 0 )
            {
                nudMonto.Value = monto_apertura_caja;
                nudMonto.Enabled = false;
                btnGuardar.Enabled = false;
                txtMensaje.Text = "Ya se encuentra aperturada la caja para este día.";
                txtMensaje.Visible = true;
                txtMensaje.Enabled = false;
            }
            else
            {
                txtMensaje.Visible = false;
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Está seguro(a) de aperturar la caja del día: " + System.DateTime.Now.ToShortDateString(), cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                { 
                    return;
                }

                NCaja.abrir_caja(nudMonto.Value, cGeneral.id_user_actual);
                cGeneral.si_caja_aperturada = true;
                MessageBox.Show("Caja se aperturo con éxito!", "Apertura de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible aperturar la caja! " + ex.Message.ToString(), "Apertura de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nudMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar_Click(null, null);
            }
        }
    }
}
