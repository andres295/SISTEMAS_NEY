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

namespace SCM.CentroMedico
{
    public partial class frmEspecialidad_Acciones : Form
    {
        public static frmEspecialidad_Acciones me;

        public frmEspecialidad_Acciones()
        {
            frmEspecialidad_Acciones.me = this;
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

                if (this.txtBanco.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la especialidad", this.btnGuardar, 0, 38, 3000);
                    this.txtBanco.Focus();
                    return;
                }

                if (this.accion == false)
                {
                    //AGREGAR.
                    if (!NEspecialidad.verificar_si_existe(this.txtBanco.Text))
                    {
                        if (NEspecialidad.guardar(this.txtBanco.Text))
                        {
                            if (!externalUse)
                            {
                                CentroMedico.frmEspecialidad.me.txtRegistros.Text = NEspecialidad.num_reg().ToString("N0");
                                CentroMedico.frmEspecialidad.me.txtBuscar.Enabled = true;

                                this.txtBanco.Text = "";
                                this.txtBanco.Focus();

                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                this.ttMensaje.Show("La especialidad ha sido guardado", this.btnGuardar, 0, 38, 3000);
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
                        this.ttMensaje.Show("Ya existe una especialidad con ese nombre", this.btnGuardar, 0, 38, 3000);
                        this.txtBanco.Focus();
                        return;
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (this.txtBanco.Text != CentroMedico.frmEspecialidad.me.dgvEspecialidad.CurrentRow.Cells[1].Value.ToString())
                    {
                        if (NEspecialidad.verificar_si_existe(this.txtBanco.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Ya existe éste nombre", this.btnGuardar, 0, 38, 3000);
                            this.txtBanco.Focus();
                            return;
                        }
                    }

                    if (NEspecialidad.modificar(Convert.ToInt32(CentroMedico.frmEspecialidad.me.dgvEspecialidad.CurrentRow.Cells[0].Value), txtBanco.Text, cbEstado.Checked))
                    {
                        CentroMedico.frmEspecialidad.me.dgvEspecialidad.CurrentRow.Cells[1].Value = this.txtBanco.Text;
                        CentroMedico.frmEspecialidad.me.dgvEspecialidad.CurrentRow.Cells[2].Value = this.cbEstado.Checked;

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
            if (!accion)
            {
                cbEstado.Checked = true;
            }
        }

        private void frmEspecialidad_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!externalUse)
                {
                    CentroMedico.frmEspecialidad.me.tEnfoque.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
    }
}
