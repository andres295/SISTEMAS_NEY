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
    public partial class frmComposicionQuimicaProducto : Form
    {
        public static frmComposicionQuimicaProducto me;

        public frmComposicionQuimicaProducto()
        {
            frmComposicionQuimicaProducto.me = this;
            InitializeComponent();
        }

        public string idProducto = "";

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cblComposicionQuimica_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                var checkBoxName = cblComposicionQuimica.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;

                NProductos.asignar_composicion(idProducto, id);

            }
            else
            {
                var checkBoxName = cblComposicionQuimica.Items[e.Index];
                var id = ((ListItem)checkBoxName).Value;
                NProductos.quitar_composicion(idProducto, id);
            }

        }

        private void frmComposicionQuimicaProducto_Load(object sender, EventArgs e)
        {
            cblComposicionQuimica.Enabled = true;
            cargarComposicion();
        }
        public void cargarComposicion()
        {
            try
            {
                DataTable dt = NProductos.obtener_composicion(idProducto,txtBuscar.Text);
                if (dt.Rows.Count > 0)
                {
                    cblComposicionQuimica.Items.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            string composicion ="";
                            try
                            {
                                 composicion = dt.Rows[i]["Composicion"].ToString();
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

                            cblComposicionQuimica.Items.Add(new ListItem(composicion, id), seleccionado);

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
                Productos.frmComposicion_Acciones frm = new Productos.frmComposicion_Acciones();
                frm.accion = true;
                frm.externalUse = true;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cargarComposicion_frm()
        {
            try
            {
                string composicion = NProductos.obtener_composicion_by_producto(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString(),false);
                if (composicion != "")
                {
                    frmProductos_Acciones.me.rtxtComposicion.Text = composicion;
                }
                else { frmProductos_Acciones.me.rtxtComposicion.Text = ""; }
            }
            catch (Exception ex) { }
        }

        private void frmComposicionQuimicaProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            cargarComposicion_frm();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cblComposicionQuimica.Items.Clear();
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
