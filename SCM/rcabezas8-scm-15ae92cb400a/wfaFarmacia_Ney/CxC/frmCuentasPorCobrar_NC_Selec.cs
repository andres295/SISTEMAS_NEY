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

namespace SCM.CxC
{
    public partial class frmCuentasPorCobrar_NC_Selec : Form
    {
        public frmCuentasPorCobrar_NC_Selec()
        {
            InitializeComponent();
        }

        void orden()
        {
            this.dgvFacturas.Sort(this.dgvFacturas.Columns[2], ListSortDirection.Ascending);
        }

        private void frmCuentasPorCobrar_NC_Selec_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                est.grid_selfull_con_alter(this.dgvFacturas);
                est.SetDoubleBuffered(this.dgvFacturas);

                this.tBuscar.Interval = cGeneral.timer;

                this.dgvFacturas.DataSource = NNotasCreditosCXC.cargar_fact_sel("");
                this.orden();

                cGeneral.ajuste_columnas(this.dgvFacturas);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_sel();
        }

        void click_sel()
        {
            try
            {
                DataTable dt_datos = NNotasCreditosCXC.obtener_datos_fact_sel(this.dgvFacturas.CurrentRow.Cells[0].Value.ToString());

                frmCuentasPorCobrar_NC_Agregar.me.mtxtFactura.Text = dt_datos.Rows[0].ItemArray[0].ToString();
                frmCuentasPorCobrar_NC_Agregar.me.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                ///frmCuentasPorCobrar_NC_Agregar.me.txtMatriz.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                frmCuentasPorCobrar_NC_Agregar.me.txtDireccion.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                frmCuentasPorCobrar_NC_Agregar.me.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();

                frmCuentasPorCobrar_NC_Agregar.me.id_cliente_captado = Convert.ToInt32(this.dgvFacturas.CurrentRow.Cells[1].Value);
                frmCuentasPorCobrar_NC_Agregar.me.cliente_captado = this.dgvFacturas.CurrentRow.Cells[2].Value.ToString();

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.dgvFacturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                this.dgvFacturas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dgvFacturas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.dgvFacturas.Columns[0].Frozen = true;
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

                this.dgvFacturas.DataSource = NNotasCreditosCXC.cargar_fact_sel(this.txtBuscar.Text);
                this.orden();

                if (this.dgvFacturas.Rows.Count == 0)
                {

                    this.btnGuardar.Enabled = false;
                   //// this.txtBuscar.Focus();
                    ////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
                }
                else
                {
                    this.btnGuardar.Enabled = true;
                    ///this.dgvFacturas.Focus();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            ////this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
        }

        private void frmCuentasPorPagar_NC_Selec_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCuentasPorCobrar_NC_Agregar.me.tEnfoque.Enabled = true;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    if (this.dgvFacturas.Rows.Count > 0)
            //        click_sel();
            //}
            //else 
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtBuscar.Text == "")
                {
                    this.dgvFacturas.DataSource = NNotasCreditosCXC.cargar_fact_sel("");
                    this.orden();
                    ///this.txtBuscar.Focus();
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }

            }  
            else if (e.KeyValue == 40)
                if (this.dgvFacturas.Rows.Count > 0)
                    this.dgvFacturas.Focus();
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_sel();
        }

        private void dgvFacturas_Enter(object sender, EventArgs e)
        {
           /// if (this.dgvFacturas.Rows.Count == 0)
               //// this.txtBuscar.Focus();
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
