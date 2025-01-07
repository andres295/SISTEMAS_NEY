using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using SCM.Globales;

namespace SCM.Empleados
{
    public partial class frmEmpleados : Form
    {
        public static frmEmpleados me;

        public frmEmpleados()
        {
            frmEmpleados.me = this;
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvEmpleados);
                est.SetDoubleBuffered(this.dgvEmpleados);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvEmpleados.DataSource = NEmpleados.buscar("");
                this.empleados_sort(2);
                this.txtRegistros.Text = NEmpleados.num_reg().ToString("N0");

                cGeneral.ajuste_columnas(this.dgvEmpleados);

                if (this.txtRegistros.Text == "0")
                    this.btnAgregar.Focus();
                else
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
                ///this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmpleados_Acciones frm = new frmEmpleados_Acciones();
                frm.Text = "AGREGAR EMPLEADO";
                frm.accion = false;
                frm.cmbGenero.SelectedIndex = 0;
                frm.dtpNacimiento.Value = Convert.ToDateTime("01-01-2000").Date;
                frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NEmpleados.obtener_datos(Convert.ToInt32(this.dgvEmpleados.CurrentRow.Cells[0].Value));

                frmEmpleados_Acciones frm = new frmEmpleados_Acciones(dt_datos.Rows[0].ItemArray[1].ToString());
                frm.Text = "MODIFICAR LOS DATOS DEL EMPLEADO";
                frm.accion = true;

                frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                frm.mtxtCedula.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                frm.txtPrimerNombre.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                frm.cmbGenero.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                frm.dtpNacimiento.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                frm.txtProfesion.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[6].ToString();
                frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[7].ToString();

                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void empleados_sort(int col)
        {
            this.dgvEmpleados.Sort(this.dgvEmpleados.Columns[col], ListSortDirection.Ascending);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvEmpleados.DataSource = NEmpleados.buscar(this.txtBuscar.Text);
                this.empleados_sort(1);

                if (this.dgvEmpleados.Rows.Count == 0)
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
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvEmpleados_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvEmpleados.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
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
                    if (this.dgvEmpleados.Rows.Count > 0)
                        this.dgvEmpleados.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (this.txtBuscar.Text == "")
                        {
                            this.tBuscar.Enabled = false;
                            this.dgvEmpleados.DataSource = NEmpleados.buscar("");
                            this.empleados_sort(2);

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

        private void dgvEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.dgvEmpleados.Rows.Count > 0)
                    {
                        this.txtBuscar.Text = "";
                        this.txtBuscar.Focus();
                    }
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvEmpleados.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
                else
                    this.dgvEmpleados.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.click_eliminar();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        void click_eliminar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste empleado.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NEmpleados.eliminar(Convert.ToInt32(this.dgvEmpleados.CurrentRow.Cells[0].Value)))
                    {
                        this.dgvEmpleados.Rows.Remove(this.dgvEmpleados.CurrentRow);
                        this.txtRegistros.Text = NEmpleados.num_reg().ToString("N0");

                        if (this.txtRegistros.Text == "0")
                        {
                            this.txtBuscar.Text = "";
                            this.txtBuscar.Enabled = false;
                        }
                        else
                        {
                            this.dgvEmpleados.Rows[this.dgvEmpleados.CurrentRow.Index].Selected = true;

                            if (this.dgvEmpleados.Rows.Count == 0)
                                this.txtBuscar.Focus();
                            else
                                this.dgvEmpleados.Focus();
                        }
                    }
                }
                else
                    this.dgvEmpleados.Focus();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el # cédula, nombres, apellidos, género, teléfono y dirección del empleado", this.txtBuscar, 0, 26);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.ttMensaje.Hide(this.txtBuscar);
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            ///this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void dgvEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvEmpleados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEmpleados.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEmpleados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvEmpleados.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEmpleados.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEmpleados.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvEmpleados.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEmpleados.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvEmpleados.Columns[0].Frozen = true;
                this.dgvEmpleados.Columns[1].Frozen = true;
                this.dgvEmpleados.Columns[2].Frozen = true;

                this.dgvEmpleados.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
