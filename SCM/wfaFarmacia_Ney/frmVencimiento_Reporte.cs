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
    public partial class frmVencimiento_Reporte : Form
    {
        public frmVencimiento_Reporte()
        {
            InitializeComponent();
        }

        private void frmVencimiento_Reporte_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnCerrar.Left = this.Width;
            }
            catch (Exception ex) { cGeneral.error(ex); }

            ////this.r_VencimientoTableAdapter.Connection = Globales.cConexion.conexion;
           /// this.reportViewer1.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
