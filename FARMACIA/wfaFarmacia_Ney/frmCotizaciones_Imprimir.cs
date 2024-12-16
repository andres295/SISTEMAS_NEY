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
    public partial class frmCotizaciones_Imprimir : Form
    {
        public frmCotizaciones_Imprimir()
        {
            InitializeComponent();
        }

        public int id_cot = 0;

        private void frmCotizaciones_Imprimir_Load(object sender, EventArgs e)
        {
            try
            {
                ////this.btnCerrar.Left = this.Width;
                this.btnCerrar.Visible = true;

                // TODO: esta línea de código carga datos en la tabla 'dsDatos.r_Cotizaciones_Prod' Puede moverla o quitarla según sea necesario.
                this.r_Cotizaciones_ProdTableAdapter.Connection = Globales.cConexion.conexion;
                this.r_Cotizaciones_ProdTableAdapter.Fill(this.dsDatos.r_Cotizaciones_Prod, id_cot);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCotizaciones_Imprimir_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCotizaciones.me.tEnfoque.Enabled = true;
        }
    }
}
