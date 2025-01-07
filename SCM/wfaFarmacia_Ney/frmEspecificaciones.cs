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
    public partial class frmEspecificaciones : Form
    {
        public frmEspecificaciones()
        {
            InitializeComponent();
        }

        public bool accion = false;

        void especificaciones_sort(int col)
        {
            this.dgvEspecificaciones.Sort(this.dgvEspecificaciones.Columns[col], ListSortDirection.Ascending);
        }

        private void frmEspecificaciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtEspecificacion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvEspecificaciones);
                est.SetDoubleBuffered(this.dgvEspecificaciones);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvEspecificaciones.DataSource = NEspecificacion.buscar("");
                this.especificaciones_sort(1);

                cGeneral.ajuste_columnas(this.dgvEspecificaciones);
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGuardar1.Visible = true;
                this.btnAgregar.Visible = false;
                ///this.txtBuscar.Enabled = false;
                this.btnModificar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnGuardar1.Enabled = true;
                this.txtEspecificacion.Enabled = true;
                this.txtEspecificacion.Text = "";
                this.txtEspecificacion.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtEspecificacion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la especificacion", this.btnGuardar1, 0, 40, 3000);
                    this.txtEspecificacion.Focus();
                    return;
                }

                if (NEspecificacion.verificar_si_existe(this.txtEspecificacion.Text) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta especificación ya existe", this.btnGuardar1, 0, 40, 3000);
                    this.txtEspecificacion.Focus();
                    return;
                }

                //AGREGAR.
                if (this.txtEspecificacion.Text != "")
                    if (NEspecificacion.guardar(this.txtEspecificacion.Text))
                    {
                        Form frm_prod = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductos);

                        if (frm_prod != null)
                        {
                            if (frmProductos_Acciones.me.cmbEspecificacion.Items.Count == 0)
                                frmProductos_Acciones.me.cargar_esp();
                        }

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("La especificación ha sido guardada", this.btnGuardar1, 0, 40, 3000);

                        this.txtEspecificacion.Text = "";
                        this.txtEspecificacion.Focus();
                    }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvEspecificaciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvEspecificaciones.Rows.Count > 0)
                    this.txtEspecificacion.Text = this.dgvEspecificaciones.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.click_modificar();
        }

        void click_modificar()
        {
            try
            {
                this.btnGuardar2.Visible = true;
                this.btnModificar.Visible = false;
                this.txtBuscar.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnGuardar2.Enabled = true;
                this.txtEspecificacion.Enabled = true;
                this.txtEspecificacion.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtEspecificacion.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la especificación", this.btnGuardar2, 0, 40, 3000);
                    this.txtEspecificacion.Focus();
                    return;
                }

                if (NEspecificacion.verificar_si_existe(this.txtEspecificacion.Text) > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta especificación ya existe", this.btnGuardar2, 0, 40, 3000);
                    this.txtEspecificacion.Focus();
                    return;
                }

                //MODIFICAR.
                if (NEspecificacion.modificar(Convert.ToInt32(this.dgvEspecificaciones.CurrentRow.Cells[0].Value), this.txtEspecificacion.Text))
                {
                    this.dgvEspecificaciones.CurrentRow.Cells[1].Value = this.txtEspecificacion.Text;
                    this.especificaciones_sort(1);

                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Visible = true;
                    this.btnGuardar2.Visible = false;
                    this.btnEliminar.Enabled = true;
                    this.txtBuscar.Enabled = true;
                    this.txtEspecificacion.Enabled = false;
                    this.dgvEspecificaciones.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtEspecificacion_Enter(object sender, EventArgs e)
        {
            this.txtEspecificacion.Select(0, this.txtEspecificacion.Text.Length);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                if (NEspecificacion.validar_relacion(Convert.ToInt32(this.dgvEspecificaciones.CurrentRow.Cells[0].Value)) <= 0)
                {
                    DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar ésta especificación.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resul == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NEspecificacion.eliminar(Convert.ToInt32(this.dgvEspecificaciones.CurrentRow.Cells[0].Value)))
                        {
                            this.dgvEspecificaciones.Rows.Remove(this.dgvEspecificaciones.CurrentRow);

                            if (NEspecificacion.num_reg() == 0)
                            {
                                this.txtEspecificacion.Text = "";
                                this.txtBuscar.Enabled = false;
                                this.txtBuscar.Text = "";
                                this.btnAgregar.Focus();
                            }
                            else
                            {
                                this.dgvEspecificaciones.Rows[this.dgvEspecificaciones.CurrentRow.Index].Selected = true;
                                this.dgvEspecificaciones.Focus();
                            }
                        }
                    }
                    else
                        this.dgvEspecificaciones.Focus();
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Esta especificación esta asignada a varios productos.", this.btnEliminar, 0, 40, 3000);
                    this.txtEspecificacion.Focus();
                    return;
                } 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvEspecificaciones_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.btnGuardar1.Visible == true || this.btnGuardar2.Visible == true)
                    {
                        if (this.btnGuardar2.Visible == true)
                            this.txtEspecificacion.Text = this.dgvEspecificaciones.CurrentRow.Cells[1].Value.ToString();

                        this.btnAgregar.Visible = true;
                        this.btnGuardar1.Visible = false;
                        this.btnAgregar.Enabled = false;
                        this.btnModificar.Visible = true;
                        this.btnGuardar2.Visible = false;
                        this.btnModificar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.txtEspecificacion.Enabled = false;
                        this.txtBuscar.Enabled = true;
                        this.dgvEspecificaciones.Focus();
                    }
                    else
                        if (this.txtBuscar.Text != "")
                        {
                            this.txtBuscar.Text = "";
                            this.txtBuscar.Focus();
                        }
                        else
                            this.Close();
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtEspecificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtEspecificacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.txtEspecificacion.Enabled = false;

                    if (this.btnGuardar1.Visible == true)
                    {
                        //AGREGAR.
                        this.btnAgregar.Visible = true;
                        this.btnGuardar1.Enabled = false;

                        if (NEspecificacion.num_reg() == 0)
                        {
                            this.txtBuscar.Enabled = false;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.btnAgregar.Focus();
                        }
                        else
                        {
                            this.txtBuscar.Enabled = true;
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.txtBuscar.Focus();
                        }
                    }
                    else
                    {
                        //MODIFICAR.
                        this.txtEspecificacion.Text = this.dgvEspecificaciones.CurrentRow.Cells[1].Value.ToString();
                        this.btnModificar.Visible = true;
                        this.btnGuardar2.Visible = false;

                        this.txtBuscar.Enabled = true;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.dgvEspecificaciones.Focus();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvEspecificaciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvEspecificaciones.Rows.Count > 0)
                    if (this.btnModificar.Visible == true)
                        this.click_modificar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvEspecificaciones.DataSource = NEspecificacion.buscar(this.txtBuscar.Text);
                this.especificaciones_sort(1);

                if (this.dgvEspecificaciones.Rows.Count == 0)
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                    else
                        this.txtBuscar.Text = "";
                }
                else if (e.KeyValue == 40)
                {
                    if (this.dgvEspecificaciones.Rows.Count > 0)
                        this.dgvEspecificaciones.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvEspecificaciones.DataSource = NEspecificacion.buscar("");
                            this.especificaciones_sort(1);

                            this.txtEspecificacion.Text = "";
                            this.btnAgregar.Enabled = true;
                            this.btnModificar.Enabled = false;
                            this.btnEliminar.Enabled = false;
                        }
                        else
                        {
                            this.tBuscar.Enabled = false;
                            this.tBuscar.Enabled = true;
                        }
                    }
                    catch (Exception ex) { cGeneral.error(ex); }
                }
               
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (NEspecificacion.num_reg() > 0)
                {
                    this.btnAgregar.Enabled = true;
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                else
                    this.btnAgregar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvEspecificaciones_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvEspecificaciones.Rows.Count == 0)
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvEspecificaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvEspecificaciones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvEspecificaciones.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
