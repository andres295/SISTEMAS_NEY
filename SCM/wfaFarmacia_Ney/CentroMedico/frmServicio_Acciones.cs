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
    public partial class frmServicio_Acciones : Form
    {
        public bool userExterno = false;
        public frmServicio_Acciones()
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

                if (this.txtServicio.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el nombre del servicio", this.btnGuardar, 0, 38, 3000);
                    this.txtServicio.Focus();
                    return;
                }
                //else if (this.nudTiempoEjecucion.Value <= 0)
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("El tiempo de ejecución del servicio tiene que ser mayor a cero.", this.btnGuardar, 0, 38, 3000);
                //    this.nudTiempoEjecucion.Focus();
                //    return;
                //}
                else if (this.nudCosto.Value <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("El costo del servicio tiene que ser mayor a cero.", this.btnGuardar, 0, 38, 3000);
                    this.nudCosto.Focus();
                    return;
                }
               
                if (this.accion == false)
                {
                    //AGREGAR.
                    if (NServicio.verificar_si_existe(this.txtServicio.Text))
                    {
                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("Ya existe éste nombre", this.btnGuardar, 0, 38, 3000);
                        this.txtServicio.Focus();
                        return;
                    }
                    if (NServicio.guardar(this.txtServicio.Text, nudCosto.Value, this.txtDescripcion.Text, "0"))
                    {
                        if (!userExterno)
                        {
                            frmServicio.me.txtRegistros.Text = NServicio.num_reg().ToString("N0");
                            frmServicio.me.txtBuscar.Enabled = true;

                            this.txtServicio.Text = "";
                            this.txtDescripcion.Text = "";
                            this.nudCosto.Value = 0;
                            this.txtServicio.Focus();

                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El servicio ha sido guardado", this.btnGuardar, 0, 38, 3000);
                        }
                        else
                        {
                            MessageBox.Show("El servicio ha sido guardado.", "Agregar servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (this.txtServicio.Text != frmServicio.me.dgvServicios.CurrentRow.Cells[1].Value.ToString())
                    {
                        if (NServicio.verificar_si_existe(this.txtServicio.Text))
                        {
                            this.ttMensaje.ToolTipTitle = "ERROR";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                            this.ttMensaje.Show("Ya existe éste nombre", this.btnGuardar, 0, 38, 3000);
                            this.txtServicio.Focus();
                            return;
                        }
                    }

                    if (NServicio.modificar(Convert.ToInt32(frmServicio.me.dgvServicios.CurrentRow.Cells[0].Value), this.txtServicio.Text, nudCosto.Value,cbEstado.Checked,txtDescripcion.Text,""))
                    {
                        frmServicio.me.dgvServicios.CurrentRow.Cells[1].Value = this.txtServicio.Text;
                        frmServicio.me.dgvServicios.CurrentRow.Cells[2].Value = this.nudCosto.Value; 
                        frmServicio.me.dgvServicios.CurrentRow.Cells[3].Value = this.txtDescripcion.Text;
                        frmServicio.me.dgvServicios.CurrentRow.Cells[4].Value = this.cbEstado.Checked;
                       
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
            if (!userExterno)
            {
                try
                {
                    frmServicio.me.tEnfoque.Enabled = true;
                }
                catch (Exception ex)
                {
                    cGeneral.error(ex);
                }
            } 
        }

        private void txtBanco_Enter(object sender, EventArgs e)
        {
            this.txtServicio.Select(0, this.txtServicio.TextLength);
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
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

        private void frmServicio_Acciones_Load(object sender, EventArgs e)
        {
            this.txtServicio.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDescripcion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }
    }
}
