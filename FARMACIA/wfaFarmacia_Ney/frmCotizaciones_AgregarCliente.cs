﻿using CapaNegocios;
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
    public partial class frmCotizaciones_AgregarCliente : Form
    {
        public frmCotizaciones_AgregarCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            click_guardar();
        }

        void click_guardar()
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.txtPrimerNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el primer nombre", this.btnGuardar, 0, 38, 2000);
                    this.txtPrimerNombre.Focus();
                    return;
                }
                else if (NClientes.validar_guardar_default(this.txtPrimerNombre.Text))
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este cliente ya existe", this.btnGuardar, 0, 38, 2000);
                    this.txtPrimerNombre.Focus();
                    return;
                }

                NClientes.guardar_default(this.txtPrimerNombre.Text);

                if (frmCotizaciones_Acciones.me.txtBuscar.Text != "")
                {
                    frmCotizaciones_Acciones.me.dgvClientes.DataSource = NClientes.buscar(frmCotizaciones_Acciones.me.txtBuscar.Text);
                    frmCotizaciones_Acciones.me.orden(frmCotizaciones_Acciones.me.dgvClientes);
                    frmCotizaciones_Acciones.me.btnSeleccionar.Enabled = true;
                }

                this.Close();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPrimerNombre_Enter(object sender, EventArgs e)
        {
            this.txtPrimerNombre.Select(0, this.txtPrimerNombre.Text.Length);
        }

        private void txtPrimerNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_guardar();
        }

        private void txtPrimerApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                click_guardar();
        }

        private void frmCotizaciones_AgregarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCotizaciones_Acciones.me.tEnfoque.Enabled = true;
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }

        private void frmCotizaciones_AgregarCliente_Load(object sender, EventArgs e)
        {
            this.txtPrimerNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
        }
    }
}