using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCM.CxC
{
    public partial class frmCuentasPorCobrar_Imprimir_Fact : Form
    {
        public frmCuentasPorCobrar_Imprimir_Fact()
        {
            InitializeComponent();
        }

        private void frmCuentasPorCobrar_Imprimir_Fact_Load(object sender, EventArgs e)
        {
            ///this.btnCerrar.Left = this.Width;

            // TODO: esta línea de código carga datos en la tabla 'dsDatos.CuentaPorPagar_CargarFacturas' Puede moverla o quitarla según sea necesario.
            this.cuentaPorPagar_CargarFacturasTableAdapter.Connection = Globales.cConexion.conexion;
            this.cuentaPorPagar_CargarFacturasTableAdapter.Fill(this.dsDatos.CuentaPorPagar_CargarFacturas, frmCuentasPorCobrar.me.id_cliente_captado, frmCuentasPorCobrar.me.desde_captado, frmCuentasPorCobrar.me.hasta_captado, (frmCuentasPorCobrar.me.captar_pagado == true ? "PAGADO" : "POR PAGAR"));

            this.reportViewer1.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
