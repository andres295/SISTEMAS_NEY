using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCM.CxP
{
    public partial class frmCuentasPorPagar_Imprimir_Fact : Form
    {
        public frmCuentasPorPagar_Imprimir_Fact()
        {
            InitializeComponent();
        }

        private void frmCuentasPorPagar_Imprimir_Fact_Load(object sender, EventArgs e)
        {
            ///this.btnCerrar.Left = this.Width;

            // TODO: esta línea de código carga datos en la tabla 'dsDatos.CuentaPorPagar_CargarFacturas' Puede moverla o quitarla según sea necesario.
            this.cuentaPorPagar_CargarFacturasTableAdapter.Connection = Globales.cConexion.conexion;
            this.cuentaPorPagar_CargarFacturasTableAdapter.Fill(this.dsDatos.CuentaPorPagar_CargarFacturas, frmCuentasPorPagar.me.id_prov_captado, frmCuentasPorPagar.me.desde_captado, frmCuentasPorPagar.me.hasta_captado, (frmCuentasPorPagar.me.captar_pagado == true ? "PAGADO" : "POR PAGAR"));

            this.reportViewer1.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
