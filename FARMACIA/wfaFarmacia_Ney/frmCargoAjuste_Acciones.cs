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
    public partial class frmCargoAjuste_Acciones : Form
    {
        public frmCargoAjuste_Acciones()
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
                if (this.cmbProveedor.Items.Count == 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("La lista de proveedores está vacía", this.btnGuardar, 3000, 0, 38);
                    this.cmbProveedor.Focus();
                    this.cmbProveedor.DroppedDown = true;
                    return;
                }

                if (this.Text == "AGREGAR")
                {
                    NCargoAjuste.guardar_CJ(cGeneral.id_user_actual, this.txtAlmacen.Text, this.txtTipoMov.Text, Convert.ToInt32(this.cmbProveedor.Value), this.cmbProveedor.Text, Convert.ToDateTime(this.dtpFechaDoc.Value), this.txtObserv.Text, cGeneral.id_user_actual);
                    frmCargoAjuste.me.txtRegistros.Text = NCargoAjuste.num_reg().ToString("N0");
                    frmCargoAjuste.me.txtBuscar.Enabled = true;
                    frmCargoAjuste.me.txtBuscar.Text = this.cmbProveedor.Text; 
                }
                else
                {
                    NCargoAjuste.modificar_CJ(Convert.ToInt32(frmCargoAjuste.me.dgvFacturas.CurrentRow.Cells[0].Value), Convert.ToInt32(this.cmbProveedor.Value), this.cmbProveedor.Text, this.dtpFechaDoc.Value, this.txtObserv.Text);
                    frmCargoAjuste.me.dgvFacturas.CurrentRow.Cells[2].Value = NCargoAjuste.actualizar_nombre_prov(cGeneral.id_user_actual, Convert.ToInt32(frmCargoAjuste.me.dgvFacturas.CurrentRow.Cells[0].Value));
                    frmCargoAjuste.me.dgvFacturas.CurrentRow.Cells[3].Value = this.dtpFechaDoc.Value;
                }
                frmCargoAjuste.me.tBuscar.Enabled = false;
                frmCargoAjuste.me.tBuscar.Enabled = true;

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbProveedor_DropDownClosed(object sender, EventArgs e)
        {
            this.dtpFechaDoc.Focus();
        }

        private void frmCargoAjuste_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCargoAjuste.me.tEnfoque.Enabled = true;
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

        private void frmCargoAjuste_Acciones_Load(object sender, EventArgs e)
        {
            this.txtObserv.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            // Have WinComboEditor suggest possible colors.
            this.cmbProveedor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbProveedor.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
