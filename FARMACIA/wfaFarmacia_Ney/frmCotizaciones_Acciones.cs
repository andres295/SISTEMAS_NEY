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
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney
{
    public partial class frmCotizaciones_Acciones : Form
    {
        public static frmCotizaciones_Acciones me;

        public frmCotizaciones_Acciones()
        {
            frmCotizaciones_Acciones.me = this;
            InitializeComponent();
        }

        private void frmCotizaciones_Acciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvClientes);
                est.SetDoubleBuffered(this.dgvClientes);

                this.dgvClientes.DataSource = NClientes.buscar("");
                this.orden(this.dgvClientes);

                cGeneral.ajuste_columnas(this.dgvClientes);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvClientes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvClientes.Columns[0].Frozen = true;
                this.dgvClientes.Columns[1].Frozen = true;
                this.dgvClientes.Columns[2].Frozen = true;

                this.dgvClientes.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        public void orden(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns[3], ListSortDirection.Ascending);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();

            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    this.btnSeleccionar.Enabled = false;

                    this.dgvClientes.DataSource = NClientes.buscar(this.txtBuscar.Text);
                    this.orden(this.dgvClientes);
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }
            }
           
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void dgvClientes_Enter(object sender, EventArgs e)
        {
            if (this.dgvClientes.Rows.Count == 0)
                this.txtBuscar.Focus();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                this.dgvClientes.DataSource = NClientes.buscar(this.txtBuscar.Text);
                this.orden(this.dgvClientes);

                if (this.dgvClientes.Rows.Count == 0)
                {
                    this.btnSeleccionar.Enabled = false;
                    this.txtBuscar.Focus();
                    this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnSeleccionar.Enabled = true;
                    this.dgvClientes.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "SELECCIONE EL NOMBRE DEL CLIENTE")
                {
                    long idCotizacion = NCotizaciones.guardar(cGeneral.id_user_actual, Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value), cGeneral.id_user_actual);
                    if (idCotizacion>0)
                    {
                        frmCotizaciones.me.txtRegistros.Text = NCotizaciones.num_reg().ToString("N0");
                        frmCotizaciones.me.txtBuscar.Enabled = true;
                        frmCotizaciones.me.txtNumVenta.Text = idCotizacion.ToString();

                        frmCotizaciones.me.txtBuscar.Text = this.dgvClientes.CurrentRow.Cells[3].Value.ToString();
                        frmCotizaciones.me.tBuscar.Enabled = false;
                        frmCotizaciones.me.tBuscar.Enabled = true;
                    }  
                }
                else
                {
                    NCotizaciones.modificar_cot(Convert.ToInt64(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value), Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value));
                    frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[2].Value = NCotizaciones.actualizar_nombre_prov(Convert.ToInt32(frmCotizaciones.me.dgvFacturas.CurrentRow.Cells[0].Value));
                }

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmCotizaciones_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCotizaciones.me.tEnfoque.Enabled = true;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCotizaciones_AgregarCliente frm = new frmCotizaciones_AgregarCliente();
            frm.ShowDialog();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            this.tEnfoque.Enabled = false;
            this.txtBuscar.Focus();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
    }
}
