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
    public partial class frmPresentaciones : Form
    {
        public frmPresentaciones()
        {
            InitializeComponent();
        }

        bool realizo = false;

        void presentaciones_sort(int col)
        {
            this.dgvPresentaciones.Sort(this.dgvPresentaciones.Columns[col], ListSortDirection.Ascending);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGuardar1.Visible = true;
                this.btnAgregar.Visible = false;
                this.btnModificar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnGuardar1.Enabled = true;
                this.txtPresentacion.Enabled = true;
                this.dgvPresentaciones.Enabled = false;
                this.txtPresentacion.Text = "";
                this.txtPresentacion.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        void click_guardar()
        {
            try
            {
                if (this.txtPresentacion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la presentación", this.btnGuardar1, 0, 40, 3000);
                    this.txtPresentacion.Focus();
                    return;
                }

                if (NPresentaciones.verificar_si_existe(this.txtPresentacion.Text) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta presentación ya existe", this.btnGuardar1, 0, 40, 3000);
                    this.txtPresentacion.Focus();
                    return;
                }

                //AGREGAR.
                if (this.txtPresentacion.Text != "")
                    if (NPresentaciones.guardar(this.txtPresentacion.Text))
                    {
                        this.realizo = true;
                        this.dgvPresentaciones.DataSource = NPresentaciones.cargar();
                        this.presentaciones_sort(1);

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("La presentación ha sido guardada", this.btnGuardar1, 0, 40, 3000);

                        this.txtPresentacion.Text = "";
                        this.txtPresentacion.Focus();
                    }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.opcion_modificar();
        }

        void opcion_modificar()
        {
            this.btnGuardar2.Visible = true;
            this.btnModificar.Visible = false;
            this.btnAgregar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGuardar2.Enabled = true;
            this.txtPresentacion.Enabled = true;
            this.dgvPresentaciones.Enabled = false;
            this.txtPresentacion.Focus();
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            click_modificar();
        }

        void click_modificar()
        {
            try
            {
                if (this.txtPresentacion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la presentación", this.btnGuardar2, 0, 40, 3000);
                    this.txtPresentacion.Focus();
                    return;
                }

                if (this.txtPresentacion.Text != this.dgvPresentaciones.CurrentRow.Cells[1].Value.ToString())
                    if (NPresentaciones.verificar_si_existe(this.txtPresentacion.Text) > 0)
                    {
                        this.ttMensaje.ToolTipTitle = "ERROR";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                        this.ttMensaje.Show("Esta presentación ya existe", this.btnGuardar2, 0, 40, 3000);
                        this.txtPresentacion.Focus();
                        return;
                    }

                //MODIFICAR.
                if (NPresentaciones.modificar(Convert.ToInt32(this.dgvPresentaciones.CurrentRow.Cells[0].Value), this.txtPresentacion.Text))
                {
                    this.realizo = true;
                    this.dgvPresentaciones.CurrentRow.Cells[1].Value = this.txtPresentacion.Text;

                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Visible = true;
                    this.btnGuardar2.Visible = false;
                    this.btnEliminar.Enabled = true;
                    this.txtPresentacion.Enabled = false;
                    this.dgvPresentaciones.Enabled = true;
                    this.dgvPresentaciones.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                if (NPresentaciones.validar_relacion(Convert.ToInt32(this.dgvPresentaciones.CurrentRow.Cells[0].Value)) <= 0)
                {
                    DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar ésta presentación.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NPresentaciones.eliminar(Convert.ToInt32(this.dgvPresentaciones.CurrentRow.Cells[0].Value)))
                        {
                            this.dgvPresentaciones.Rows.Remove(this.dgvPresentaciones.CurrentRow);

                            if (this.dgvPresentaciones.Rows.Count == 0)
                            {
                                this.btnAgregar.Enabled = true;
                                this.btnModificar.Enabled = false;
                                this.btnEliminar.Enabled = false;
                                this.txtPresentacion.Text = "";
                                this.btnAgregar.Focus();
                            }
                            else
                            {
                                this.dgvPresentaciones.Rows[this.dgvPresentaciones.CurrentRow.Index].Selected = true;
                                this.dgvPresentaciones.Focus();
                            }
                        }
                    }
                    else
                        this.dgvPresentaciones.Focus();
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta presentación esta asignada a varios productos.", this.btnEliminar, 0, 40, 3000);
                    this.txtPresentacion.Focus();
                    return;
                }

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmPresentaciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtPresentacion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvPresentaciones);
                est.SetDoubleBuffered(this.dgvPresentaciones);

                this.dgvPresentaciones.DataSource = NPresentaciones.cargar();
                this.presentaciones_sort(1);

                cGeneral.ajuste_columnas(this.dgvPresentaciones);

                if (this.dgvPresentaciones.Rows.Count > 0)
                {
                    this.txtPresentacion.Text = this.dgvPresentaciones.CurrentRow.Cells[1].Value.ToString();

                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.dgvPresentaciones.Focus();
                }
                else
                    this.btnAgregar.Focus();

                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvPresentaciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPresentaciones.Rows.Count > 0)
                    this.txtPresentacion.Text = this.dgvPresentaciones.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvPresentaciones_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    this.opcion_modificar();
                }

                if (e.KeyValue == 27)
                {
                    this.ttMensaje.Hide(this.btnGuardar1);
                    this.ttMensaje.Hide(this.btnGuardar2);

                    if (this.txtPresentacion.Enabled == true)
                    {
                        this.txtPresentacion.Text = this.dgvPresentaciones.CurrentRow.Cells[1].Value.ToString();

                        this.btnAgregar.Visible = true;
                        this.btnGuardar1.Visible = false;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Visible = true;
                        this.btnGuardar2.Visible = false;
                        this.btnModificar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.txtPresentacion.Enabled = false;
                        this.dgvPresentaciones.Enabled = true;
                        this.dgvPresentaciones.Focus();
                    }
                    else
                        this.Close();
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                    if (this.btnGuardar1.Visible == true)
                        click_guardar();
                    else
                        click_modificar();
                else if (e.KeyValue == 27)
                {
                    this.ttMensaje.Hide(this.btnGuardar1);
                    this.ttMensaje.Hide(this.btnGuardar2);

                    this.txtPresentacion.Enabled = false;
                    this.dgvPresentaciones.Enabled = true;

                    if (this.btnGuardar1.Visible == true)
                    {
                        //AGREGAR.
                        this.btnAgregar.Visible = true;
                        this.btnGuardar1.Enabled = false;
                        this.btnAgregar.Enabled = true;

                        if (this.dgvPresentaciones.Rows.Count == 0)
                        {
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.txtPresentacion.Text = this.dgvPresentaciones.CurrentRow.Cells[1].Value.ToString();

                            this.btnModificar.Enabled = true;
                            this.btnEliminar.Enabled = true;
                            this.dgvPresentaciones.Focus();
                        }
                    }
                    else
                    {
                        //MODIFICAR.
                        this.txtPresentacion.Text = this.dgvPresentaciones.CurrentRow.Cells[1].Value.ToString();
                        this.btnModificar.Visible = true;
                        this.btnGuardar2.Visible = false;

                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.dgvPresentaciones.Enabled = true;
                        this.dgvPresentaciones.Focus();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void txtPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvPresentaciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPresentaciones.Rows.Count > 0)
                    if (this.btnModificar.Visible == true)
                        this.opcion_modificar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvPresentaciones.Rows.Count == 0)
                    this.btnAgregar.Focus();
                else
                    this.dgvPresentaciones.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmPresentaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductos_Acciones);

                if (frm != null)                    
                {
                    if (this.realizo)
                    {
                        frmProductos_Acciones.me.cmbPresentacion.DataSource = NPresentaciones.lista_combo();
                        frmProductos_Acciones.me.cmbPresentacion.ValueMember = "Id";
                        frmProductos_Acciones.me.cmbPresentacion.DisplayMember = "Presentacion";
                    }

                    frmProductos_Acciones.me.tEnfoque.Enabled = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvPresentaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvPresentaciones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvPresentaciones.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPresentacion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
