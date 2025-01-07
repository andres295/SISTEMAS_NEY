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
    public partial class frmProductos_AgregarPres : Form
    {
        public frmProductos_AgregarPres()
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

                if (this.txtPrimerNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la presentación", this.btnGuardar, 0, 38, 2000);
                    this.txtPrimerNombre.Focus();
                    return;
                }
                else if (NPresentaciones.verificar_si_existe(this.txtPrimerNombre.Text) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este presentación ya existe", this.btnGuardar, 0, 38, 2000);
                    this.txtPrimerNombre.Focus();
                    return;
                }

                NPresentaciones.guardar(this.txtPrimerNombre.Text);

                if (frmProductos_Acciones.me.cmbPresentacion.Items.Count == 0)
                    frmProductos_Acciones.me.cargar_pres();

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPrimerNombre_Enter(object sender, EventArgs e)
        {
            this.txtPrimerNombre.Select(0, this.txtPrimerNombre.Text.Length);
        }

        private void txtPrimerNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_guardar();
        }

        private void txtPrimerApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_guardar();
        }

        private void frmProductos_AgregarPres_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProductos_Acciones.me.tEnfoque.Enabled = true;
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void frmProductos_AgregarPres_Load(object sender, EventArgs e)
        {
            this.txtPrimerNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }
    }
}
