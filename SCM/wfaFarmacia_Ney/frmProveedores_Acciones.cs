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
    public partial class frmProveedores_Acciones : Form
    {
        public frmProveedores_Acciones()
        {
            InitializeComponent();
        }

        public bool accion;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                try
                {
                    int.Parse(this.cmbTipoIdentificacion.Value.ToString());
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el tipo de identificación del proveedr", this.btnGuardar, 0, 38, 3000);
                    this.cmbTipoIdentificacion.Focus();
                    return;
                }
                if (this.txtProveedor.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el proveedor", this.btnGuardar, 0, 38, 3000);
                    this.txtProveedor.Focus();
                    return;
                }
                else if (this.mtxtRUC.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número de RUC", this.btnGuardar, 0, 38, 3000);
                    this.mtxtRUC.Focus();
                    return;
                }
                //else if (this.txtMatriz.Text == "")
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Ingrese la matriz", this.btnGuardar, 0, 38, 3000);
                //    this.txtMatriz.Focus();
                //    return;
                //}
                
                if (this.mtxtTelefono.Text != "")
                    if (this.mtxtTelefono.MaskFull == false)
                    {
                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("El número de teléfono está incompleto", this.btnGuardar, 0, 38, 3000);
                        this.mtxtTelefono.Focus();
                        this.mtxtTelefono.Select(this.mtxtTelefono.Text.Length, 0);
                        return;
                    }
                
                if (this.mtxtRUC.MaskFull == false)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El número de "+ cmbTipoIdentificacion.Text +" está incompleto", this.btnGuardar, 0, 38, 3000);
                    this.mtxtRUC.Focus();
                    this.mtxtRUC.Select(this.mtxtRUC.Text.Length, 0);
                    return;
                }
                if (this.ucTipoContribuyente.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Seleccione el tipo de contribuyente", this.btnGuardar, 0, 38, 3000);
                    this.ucTipoContribuyente.Focus();
                    this.ucTipoContribuyente.Select(this.ucTipoContribuyente.Text.Length, 0);
                    return;
                }
                //else if (this.txtGerente.Text == "")
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Ingrese el gerente", this.btnGuardar, 0, 38, 3000);
                //    this.txtGerente.Focus();
                //    return;
                //}
                //else if (this.mtxtAutorizacion.Text == "")
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Ingrese la autorización", this.btnGuardar, 0, 38, 3000);
                //    this.mtxtAutorizacion.Focus();
                //    return;
                //}
                //else if (this.mtxtAutorizacion.MaskFull == false)
                //{
                //    this.ttMensaje.ToolTipTitle = "ERROR";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                //    this.ttMensaje.Show("El número de autorización está incompleto", this.btnGuardar, 0, 38, 3000);
                //    this.mtxtAutorizacion.Focus();
                //    return;
                //}

                this.ttMensaje.Hide(this.btnGuardar);

                if (this.accion == true)
                {
                    //AGREGAR.
                    if (NProveedores.guardar(this.txtProveedor.Text, "", this.txtDireccion.Text, this.mtxtTelefono.Text, this.mtxtRUC.Text, "", "", "", Convert.ToInt32(this.cmbTipoIdentificacion.Value), txtCorreo.Text, txtNombreComercial.Text, ucTipoContribuyente.Text, txtAgenteRetencion.Text))
                    {
                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El proveedor ha sido guardado", this.btnGuardar, 0, 38, 2000);

                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores);
                        
                        if (frm != null)
                        {
                            frmProveedores.me.txtRegistros.Text = NProveedores.num_reg().ToString("N0");
                            frmProveedores.me.txtBuscar.Enabled = true;
                        }

                        Form frm_prod = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductos);

                        if (frm_prod != null)
                        {
                            if (frmProductos_Acciones.me.cmbEspecificacion.Items.Count == 0)
                                frmProductos_Acciones.me.cargar_prov();
                        }

                        this.txtProveedor.Text = "";
                        this.mtxtRUC.Text = "";
                        //this.txtMatriz.Text = "";
                        this.txtDireccion.Text = "";
                        this.mtxtTelefono.Text = "";
                        //this.txtGerente.Text = "";
                        //this.mtxtAutorizacion.Text = "";
                        //this.txtDatos.Text = "";
                        this.txtProveedor.Focus();
                    }
                }
                else
                {
                    //MODIFICAR
                    if (NProveedores.modificar(Convert.ToInt32(frmProveedores.me.dgvProveedores.CurrentRow.Cells[0].Value), this.txtProveedor.Text, "", this.txtDireccion.Text, this.mtxtTelefono.Text, this.mtxtRUC.Text, "","", "", Convert.ToInt32(this.cmbTipoIdentificacion.Value),txtCorreo.Text,txtNombreComercial.Text, ucTipoContribuyente.Text,txtAgenteRetencion.Text))
                    {
                        frmProveedores.me.id_captado = Convert.ToInt32(frmProveedores.me.dgvProveedores.CurrentRow.Cells[0].Value);
                        frmProveedores.me.prov_captado = this.txtProveedor.Text;

                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[1].Value = this.mtxtRUC.Text;
                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[2].Value = this.txtProveedor.Text;
                        //frmProveedores.me.dgvProveedores.CurrentRow.Cells[3].Value = this.txtGerente.Text;
                        //frmProveedores.me.dgvProveedores.CurrentRow.Cells[4].Value = this.mtxtAutorizacion.Text;
                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[3].Value = this.txtNombreComercial.Text;
                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[4].Value = this.ucTipoContribuyente.Text;
                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[5].Value = this.txtAgenteRetencion.Text;
                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[6].Value = this.txtCorreo.Text;
                        frmProveedores.me.dgvProveedores.CurrentRow.Cells[7].Value = this.mtxtTelefono.Text;
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmProveedores_Acciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbTipoIdentificacion.Focus();
                this.txtProveedor.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                //this.txtMatriz.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                //this.txtGerente.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                //this.txtDatos.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                 
                this.mtxtTelefono.Mask = cGeneral.formato_telefono;
                this.cmbTipoIdentificacion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtTelefono_Enter(object sender, EventArgs e)
        {
            this.mtxtTelefono.Select(0, 0);
        }

        //private void mtxtRUC_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.mtxtRUC.MaskFull == true)
        //            this.txtMatriz.Focus();
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull == true)
                    this.mtxtTelefono.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        //private void mtxtAutorizacion_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.mtxtAutorizacion.MaskFull == true)
        //            this.txtDatos.Focus();
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        private void frmProveedores_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form frm;
                frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores);

                if (frm != null)
                    frmProveedores.me.tEnfoque.Enabled = true;

                frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductos_Acciones);

                if (frm != null)
                    frmProductos_Acciones.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtMatriz_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtGerente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void mtxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void mtxtAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }

        private void txtDatos_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtxtAutorizacion_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } 
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        } 
        private void label18_Click(object sender, EventArgs e)
        {

        } 
        private void label2_Click(object sender, EventArgs e)
        {

        } 
        private void label17_Click(object sender, EventArgs e)
        {

        } 
        private void label13_Click(object sender, EventArgs e)
        {

        } 
        private void cmbTipoIdentificacion_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTipoIdentificacion.Value.ToString() != "2")
            {
                this.mtxtRUC.Mask = cGeneral.formato_ruc;
            }
            else
            {
                this.mtxtRUC.Mask = cGeneral.formato_cedula;
            }
        }
    }
}
