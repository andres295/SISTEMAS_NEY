using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.Productos
{
    public partial class frmBitacoraProducto : Form
    {
        public frmBitacoraProducto()
        {
            InitializeComponent();
        }

        public string idProducto = "";
        public bool eliminado = false;
        private void frmDetProducto_Load(object sender, EventArgs e)
        {
            ////this.txtNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            ///this.rtxtComposicion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBitacoraProducto_Load(object sender, EventArgs e)
        {
            cEstilo_Grid est = new cEstilo_Grid();
            est.grid_selfull_con_alter(this.dgvProductos);

            dgvProductos .DataSource = NProductos.bitacora_producto(idProducto, eliminado);
        }
    }
}
