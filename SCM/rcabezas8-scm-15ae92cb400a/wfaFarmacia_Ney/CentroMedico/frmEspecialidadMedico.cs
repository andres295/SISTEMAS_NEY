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

namespace SCM.CentroMedico
{
    public partial class frmEspecialidadMedico : Form
    {
        public static frmEspecialidadMedico me;

        public frmEspecialidadMedico()
        {
            frmEspecialidadMedico.me = this;
            InitializeComponent();
        }

        public string IdMedico = "";

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cblComposicionQuimica_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                var checkBoxName = cblEspecialidad.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;

                NEspecialidad.asignar_composicion(IdMedico, id,"I");

            }
            else
            {
                var checkBoxName = cblEspecialidad.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;
                NEspecialidad.asignar_composicion(IdMedico, id,"D");
            }

        }

        private void frmComposicionQuimicaProducto_Load(object sender, EventArgs e)
        {
            cblEspecialidad.Enabled = true;
            cargarComposicion();
        }
        public void cargarComposicion()
        {
            try
            {
                DataTable dt = NEspecialidad.obtener_especialidad_by_medico(IdMedico,txtBuscar.Text);
                if (dt.Rows.Count > 0)
                {
                    cblEspecialidad.Items.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            string composicion ="";
                            try
                            {
                                 composicion = dt.Rows[i]["Descripcion"].ToString();
                            }
                            catch (Exception) { composicion = "ND"; }
                            string id ="0";
                            try
                            {
                                 id = dt.Rows[i]["Id"].ToString();
                            }
                            catch (Exception) {  id ="0";  }

                            bool seleccionado = false;
                            try
                            {
                                 seleccionado = dt.Rows[i]["Selecionado"].ToString() == "1" ? true : false;
                            }
                            catch (Exception) {  seleccionado = false;  }

                            cblEspecialidad.Items.Add(new ListItem(composicion, id), seleccionado);

                        }
                        catch (Exception ) {  }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmEspecialidad_Acciones frm = new CentroMedico.frmEspecialidad_Acciones();
                frm.accion = false;
                frm.externalUse = true;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cargarEspecialidad_frm()
        {
            try
            {
                string especialidad = NEspecialidad.obtener_especialidad_by_medico_by_id(frmEspecialista.me.dgvEmpleados.CurrentRow.Cells[0].Value.ToString(),false);
                if (especialidad != "")
                {
                    CentroMedico.frmEspecialista_Acciones.me.txtProfesion.Text = especialidad;
                }
                else { CentroMedico.frmEspecialista_Acciones.me.txtProfesion.Text = ""; }
            }
            catch (Exception ex) { }
        }

        private void frmComposicionQuimicaProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            cargarEspecialidad_frm();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cblEspecialidad.Items.Clear();
                cargarComposicion();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
