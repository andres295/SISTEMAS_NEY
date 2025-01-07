using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.Productos
{
    public partial class frmComposicion_Acciones : Form
    {
        public frmComposicion_Acciones()
        {
            InitializeComponent();
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool externalUse = false;
        public string nombre = "";
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.txtNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el nombre de la composición", this.btnGuardar, 0, 38, 3000);
                    this.txtNombre.Focus();
                    return;
                }
                if (this.rtxtComposicion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la composición", this.btnGuardar, 0, 38, 3000);
                    this.txtNombre.Focus();
                    return;
                }

                if (this.accion == true)
                {
                    //AGREGAR.
                    if (NComposicionQuimica.valida_nombre(this.txtNombre.Text) <= 0)
                    {
                        if (NComposicionQuimica.guardar(this.txtNombre.Text, this.rtxtComposicion.Text))
                        {
                            if (!externalUse)
                            {
                                frmComposicionQuimica.me.txtRegistros.Text = NComposicionQuimica.num_reg().ToString("N0");
                                frmComposicionQuimica.me.txtBuscar.Enabled = true;

                                this.txtNombre.Text = "";
                                this.rtxtComposicion.Text = "";
                                this.txtNombre.Focus();

                                this.ttMensaje.ToolTipTitle = "LISTO";
                                this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                                this.ttMensaje.Show("La composición ha sido guardada", this.btnGuardar, 0, 38, 3000);

                            }
                            else
                            {
                                ////cargarComposicion();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        this.ttMensaje.Show("El nombre de la composición ya existe.", this.btnGuardar, 0, 38, 3000);
                        this.txtNombre.Focus();
                        return;
                    }
                }
                else
                {
                    if (nombre != this.txtNombre.Text)
                    {
                        if (NComposicionQuimica.valida_nombre(this.txtNombre.Text) <= 0)
                        {
                            if (NComposicionQuimica.modificar(Convert.ToInt32(frmComposicionQuimica.me.dgvComposicion.CurrentRow.Cells[0].Value), this.txtNombre.Text, this.rtxtComposicion.Text))
                            {
                                frmComposicionQuimica.me.dgvComposicion.CurrentRow.Cells[1].Value = this.txtNombre.Text;
                                frmComposicionQuimica.me.dgvComposicion.CurrentRow.Cells[2].Value = this.rtxtComposicion.Text;
                                this.Close();
                            }
                        }
                        else
                        {
                            this.ttMensaje.Show("El nombre de la composición ya existe.", this.btnGuardar, 0, 38, 3000);
                            this.txtNombre.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (NComposicionQuimica.modificar(Convert.ToInt32(frmComposicionQuimica.me.dgvComposicion.CurrentRow.Cells[0].Value), this.txtNombre.Text, this.rtxtComposicion.Text))
                        {
                            frmComposicionQuimica.me.dgvComposicion.CurrentRow.Cells[1].Value = this.txtNombre.Text;
                            frmComposicionQuimica.me.dgvComposicion.CurrentRow.Cells[2].Value = this.rtxtComposicion.Text;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
        public void cargarComposicion()
        {
            try
            {
                DataTable dt = NProductos.obtener_composicion(frmComposicionQuimicaProducto.me.idProducto,"");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem li = new ListItem();
                        frmComposicionQuimicaProducto.me.cblComposicionQuimica = null;
                        frmComposicionQuimicaProducto.me.cblComposicionQuimica.Items.Add(new ListItem(dt.Rows[i]["Composicion"].ToString(), dt.Rows[i]["Id"].ToString()), dt.Rows[i]["Selecionado"].ToString() == "1" ? true : false);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void frmComposicion_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (!externalUse)
                {
                    frmComposicionQuimica.me.tEnfoque.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            this.txtNombre.Select(0, this.txtNombre.TextLength);
        }

        private void rtxtComposicion_Enter(object sender, EventArgs e)
        {
            this.rtxtComposicion.Select(0, this.rtxtComposicion.TextLength);
        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rtxtComposicion_KeyPress(object sender, KeyPressEventArgs e)
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


        private void frmComposicion_Acciones_Load(object sender, EventArgs e)
        {
            this.txtNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            ///this.rtxtComposicion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }

        private void rrtxtComposicion_Enter(object sender, EventArgs e)
        {
            this.rtxtComposicion.Select(0, this.rtxtComposicion.TextLength);
        }

        private void rrtxtComposicion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
