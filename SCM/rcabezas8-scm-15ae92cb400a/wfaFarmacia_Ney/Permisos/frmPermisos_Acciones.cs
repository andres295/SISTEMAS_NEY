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

namespace SCM.Permisos
{
    public partial class frmPermisos_Acciones : Form
    {
        public frmPermisos_Acciones()
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

                if (this.txtVentana.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el nombre del módulo", this.btnGuardar, 0, 38, 3000);
                    this.txtVentana.Focus();
                    return;
                }
                else if (this.txtNumVentana.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número del módulo", this.btnGuardar, 0, 38, 3000);
                    this.txtVentana.Focus();
                    return;
                }

                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NModulo.guardar(this.txtNumVentana.Text, this.txtVentana.Text))
                    {
                        Permisos.frmPermisos.me.txtRegistros.Text = NModulo.num_reg().ToString("N0");
                        Permisos.frmPermisos.me.txtBuscar.Enabled = true;

                        this.txtNumVentana.Text = "";
                        this.txtVentana.Text = "";
                        this.txtVentana.Focus();

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El módulo ha sido guardado", this.btnGuardar, 0, 38, 3000);
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (this.txtVentana.Text != Permisos.frmPermisos.me.dgvModulos.CurrentRow.Cells[2].Value.ToString())
                    {
                        if (NModulo.verificar_si_existe(this.txtVentana.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Ya existe éste nombre", this.btnGuardar, 0, 38, 3000);
                            this.txtVentana.Focus();
                            return;
                        }
                    }

                    if (NModulo.modificar(Convert.ToInt32(Permisos.frmPermisos.me.dgvModulos.CurrentRow.Cells[0].Value), this.txtNumVentana.Text, this.txtVentana.Text,cbEstado.Checked))
                    {
                        Permisos.frmPermisos.me.dgvModulos.CurrentRow.Cells[2].Value = this.txtVentana.Text;
                        Permisos.frmPermisos.me.dgvModulos.CurrentRow.Cells[1].Value = this.txtNumVentana.Text;
                        Permisos.frmPermisos.me.dgvModulos.CurrentRow.Cells[4].Value =  Convert.ToBoolean(cbEstado.Checked);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void frmPermisos_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Permisos.frmPermisos.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtVentana_Enter(object sender, EventArgs e)
        {
            this.txtNumVentana.Select(0, this.txtNumVentana.TextLength);
        }

        private void txtNumVentana_Enter(object sender, EventArgs e)
        { 
            this.txtNumVentana.Select(0, this.txtNumVentana.TextLength);
        }
       
        private void txtVentana_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumVentana_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmPermisos_Accioness_Load(object sender, EventArgs e)
        {
            this.txtVentana.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtNumVentana.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }
    }
}
