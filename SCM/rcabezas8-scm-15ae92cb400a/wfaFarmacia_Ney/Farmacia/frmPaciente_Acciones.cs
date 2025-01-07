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
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace SCM.Farmacia
{
    public partial class frmPaciente_Acciones : Form
    {
        string vCedula = "";
        string vRuc = "";
        public string idNacionalidad;
        public string idEstadoCivil;
        public string idTipoSangre;
        public string idInstruccion;

        public frmPaciente_Acciones(string cedulaActual = "", string rucActual = "")
        {
            InitializeComponent();
            vCedula = cedulaActual;
            vRuc = rucActual;
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool nuevo_cliente = false;
        public bool externalUse = false;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void saveFoto()
        {
            try
            {
                string foto_img = "";

                if (this.pbFoto.ImageLocation != null)
                    foto_img = Path.Combine(cGeneral.ruta_guardar_img, Path.GetFileName(this.pbFoto.ImageLocation));

                if (this.pbFoto.ImageLocation != null)
                {
                    Image img = Image.FromFile(this.pbFoto.ImageLocation);
                    img.Save(Path.Combine(cGeneral.ruta_guardar_img, ""), ImageFormat.Jpeg);
                }

            }
            catch (Exception) { }

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);

                if (this.mtxtCedula.Text == "" )
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el número de cédula", this.btnGuardar, 0, 38, 3000);
                    this.mtxtCedula.Focus();
                    return;
                } 
                else if (this.txtPrimerNombre.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese los nombres y apellidos", this.btnGuardar, 0, 38, 2000);
                    this.txtPrimerNombre.Focus();
                    return;
                } 
                else if (NPaciente.verificar_ced(this.mtxtCedula.Text, vCedula) > 0 && this.mtxtCedula.Text.Length > 0)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("Este número de cédula ya existe", this.btnGuardar, 0, 38, 3000);
                    this.mtxtCedula.Focus();
                    return;
                } 
                else if (this.nudEdad.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la edad", this.btnGuardar, 0, 38, 3000);
                    this.nudEdad.Focus();
                    this.nudEdad.Select(0, this.nudEdad.Text.Length);
                    return;
                }

                try
                {
                    int.Parse(cmbTipoSangre.Value.ToString());
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el tipo de sangre", this.btnGuardar, 0, 38, 3000);
                    this.cmbTipoSangre.Focus();
                    return;
                } 
                try
                {
                    int.Parse(cmbEstadoCivil.Value.ToString());
                }
                catch (Exception)
                { 
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el estado civil", this.btnGuardar, 0, 38, 3000);
                    this.cmbEstadoCivil.Focus();
                    return; 
                }
                try
                {
                    int.Parse(cmbInstruccion.Value.ToString());
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione la instrucción", this.btnGuardar, 0, 38, 3000);
                    this.cmbInstruccion.Focus();
                    return;
                }
                try
                {
                    int.Parse(cmbNacionalidad.Value.ToString());
                }
                catch (Exception)
                { 
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione la nacionalidad", this.btnGuardar, 0, 38, 3000);
                    this.cmbNacionalidad.Focus();
                    return; 
                }

                if (this.accion == false)
                {
                    ////MessageBox.Show("Formato Fecha", this.dtpNacimiento.Value.ToString());
                    //AGREGAR.
                    if (NPaciente.guardar(this.mtxtCedula.Text, "", this.txtPrimerNombre.Text, this.cmbGenero.Text, this.dtpNacimiento.Value,nudEdad.Value.ToString(), (this.mtxtTelefono.Text == "" ? "":this.mtxtTelefono.Text), this.txtDireccion.Text, this.txtCorreo.Text,"", int.Parse(cmbTipoSangre.Value.ToString()), int.Parse(cmbEstadoCivil.Value.ToString()),int.Parse(cmbNacionalidad.Value.ToString()),mtxtConvencional.Text, int.Parse(cmbInstruccion.Value.ToString()), this.pbFoto.ImageLocation != null? cGeneral.ruta_guardar_img + "\\" + Path.GetFileName(this.pbFoto.ImageLocation) : ""))
                    {
                        try
                        {
                            if (this.pbFoto.ImageLocation != null)
                            {
                                Image img = Image.FromFile(this.pbFoto.ImageLocation);
                                img.Save(Path.Combine(cGeneral.ruta_guardar_img, Path.GetFileName(this.pbFoto.ImageLocation)), ImageFormat.Jpeg);
                            } 
                        }
                        catch (Exception)
                        {
                            ///img.Save(Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName), ImageFormat.Jpeg);
                        }

                        if (!externalUse)
                        {
                          
                            frmPaciente.me.txtRegistros.Text = NPaciente.num_reg().ToString("N0");
                            frmPaciente.me.txtBuscar.Enabled = true;

                            frmPaciente.me.bsCliente.DataSource = NPaciente.buscar(frmPaciente.me.txtBuscar.Text);
                            frmPaciente.me.ClienteBindingNavigator.BindingSource = frmPaciente.me.bsCliente;
                            frmPaciente.me.dgvClientes.DataSource = frmPaciente.me.bsCliente;

                            this.ttMensaje.ToolTipTitle = "LISTO";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                            this.ttMensaje.Show("El paciente ha sido guardado", this.btnGuardar, 0, 38, 2000);

                            this.mtxtCedula.Text = ""; 
                            this.txtPrimerNombre.Text = "";
                            this.mtxtTelefono.Text = "";
                            this.txtDireccion.Text = "";
                            this.mtxtCedula.Focus();
                            MessageBox.Show("Paciente fue agregado con éxito.", "Agregar paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Paciente fue agregado con éxito.", "Agregar paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    //MODIFICAR.
                    if (NPaciente.modificar(Convert.ToInt32(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value), this.mtxtCedula.Text, "", this.txtPrimerNombre.Text, this.cmbGenero.Text, this.dtpNacimiento.Value, nudEdad.Value.ToString(), (this.mtxtTelefono.Text == "" ? "":this.mtxtTelefono.Text), this.txtDireccion.Text, this.txtCorreo.Text,"", int.Parse(cmbTipoSangre.Value.ToString()), int.Parse(cmbEstadoCivil.Value.ToString()), int.Parse(cmbNacionalidad.Value.ToString()), mtxtConvencional.Text, int.Parse(cmbInstruccion.Value.ToString())))
                    {
                        frmPaciente.me.bsCliente.DataSource = NPaciente.buscar(frmPaciente.me.txtBuscar.Text);
                        frmPaciente.me.ClienteBindingNavigator.BindingSource = frmPaciente.me.bsCliente;
                        frmPaciente.me.dgvClientes.DataSource = frmPaciente.me.bsCliente;

                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("El paciente ha sido guardado", this.btnGuardar, 0, 38, 2000);
                        //this.Close();
                    }
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmClientes_Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

                if (frm != null)
                    frmPaciente.me.tEnfoque.Enabled = true;

                //Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentas_Acciones);

                //if (frm1 != null)
                //    frmVentas_Acciones.me.tEnfoque.Enabled = true;
            }
            catch (Exception ex) { }
        }

        private void mtxtCedula_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtCedula.MaskFull)
                    this.mtxtCedula.Select(0, this.mtxtCedula.TextLength);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        } 

        private void txtPrimerNombre_Enter(object sender, EventArgs e)
        {
            this.txtPrimerNombre.Select(0, this.txtPrimerNombre.TextLength);
        }

        private void mtxtTelefono_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull)
                    this.mtxtTelefono.Select(0, this.mtxtTelefono.TextLength);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            this.txtDireccion.Select(0, this.txtDireccion.TextLength);
        } 
        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtTelefono.MaskFull) 
                    this.mtxtConvencional.Focus();
                
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmClientes_Acciones_Load(object sender, EventArgs e)
        {
            this.txtPrimerNombre.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtCorreo.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);
            this.txtDireccion.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

            this.mtxtCedula.Mask = cGeneral.formato_cedula;
            ///this.mtxtRUC.Mask = cGeneral.formato_ruc;
            this.mtxtTelefono.Mask      = cGeneral.formato_telefono;
            this.mtxtConvencional.Mask  = cGeneral.formato_telefono;
            this.cmbNacionalidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbTipoSangre.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbEstadoCivil.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbInstruccion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;

            if (accion)
            { 
                cargar_contrato_cliente();
                cargar_factura_cliente();
                cargar_pago_cliente();
                cargar_servicio_cliente();
                cargar_cita_cliente();
                cargar_consultas_externas();
            } 
            if(nuevo_cliente)
            { 
                CistasBindingNavigator.Enabled = false;
                ContratoBindingNavigator.Enabled = false;
                ServicioBindingNavigator.Enabled = false;
                FacturaBindingNavigator.Enabled = false;
                PagoBindingNavigator.Enabled = false;
                ConsultasExternasBindingNavigator.Enabled = false;
            }
            else
            {
                CistasBindingNavigator.Enabled = true;
                ContratoBindingNavigator.Enabled = true;
                ServicioBindingNavigator.Enabled = true;
                FacturaBindingNavigator.Enabled = true;
                PagoBindingNavigator.Enabled = true;
                ConsultasExternasBindingNavigator.Enabled = true;
            }
        }
        private void cargarTipoSangre()
        {
            try
            {

                this.cmbTipoSangre.DataSource = NCatalogo.obtener_datos_by_tipe(1);
                this.cmbTipoSangre.ValueMember = "Id";
                this.cmbTipoSangre.DisplayMember = "Descripcion";

            }
            catch (Exception) { }
        }
        private void cargarEstadoCivil()
        {
            try
            {

                this.cmbEstadoCivil.DataSource = NCatalogo.obtener_datos_by_tipe(2);
                this.cmbEstadoCivil.ValueMember = "Id";
                this.cmbEstadoCivil.DisplayMember = "Descripcion";

            }
            catch (Exception) { }
        }
        private void cargarNacionalidad()
        {
            try
            {

                this.cmbNacionalidad.DataSource = NCatalogo.obtener_datos_by_tipe(3);
                this.cmbNacionalidad.ValueMember = "Id";
                this.cmbNacionalidad.DisplayMember = "Descripcion";

            }
            catch (Exception) { }
        }
        private void cargarInstruccion()
        {
            try
            {

                this.cmbInstruccion.DataSource = NCatalogo.obtener_datos_by_tipe(4);
                this.cmbInstruccion.ValueMember = "Id";
                this.cmbInstruccion.DisplayMember = "Descripcion";

            }
            catch (Exception) { }
        }
        private void cargar_contrato_cliente()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NContrato.buscar_by_cliente(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString());

                bsContrato.DataSource = dt_datos;
                ContratoBindingNavigator.BindingSource = bsContrato;
                ugvContratos.DataSource = bsContrato;

            }
            catch (Exception)  {  }
        }
        private void cargar_servicio_cliente()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NOrdenServicio.buscar_by_cliente(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString());

                bsServicio.DataSource = dt_datos;
                ServicioBindingNavigator.BindingSource = bsServicio;
                ugvServicio.DataSource = bsServicio;

            }
            catch (Exception) { }
        }
        private void cargar_cita_cliente()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NCita.buscar_by_paciente(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString());

                bsCistas.DataSource = dt_datos;
                CistasBindingNavigator.BindingSource = bsCistas;
                ugvCitas.DataSource = bsCistas;

            }
            catch (Exception) { }
        }
        private void cargar_consultas_externas()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NConsultaExternaAnammnesis.get_consulta_externa_by_paciente(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString());

                bsConsultasExternas.DataSource = dt_datos;
                ConsultasExternasBindingNavigator.BindingSource = bsCistas;
                ugvConsultasExternas.DataSource = bsConsultasExternas;

            }
            catch (Exception) { }
        }
        private void cargar_factura_cliente()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NFactura.buscar_by_cliente(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString());

                bsFactura.DataSource = dt_datos;
                FacturaBindingNavigator.BindingSource = bsFactura;
                ugvFacturas.DataSource = bsFactura;

            }
            catch (Exception) { }
        }
        private void cargar_pago_cliente()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NPagoCxC.Obtener_by_cliente(frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString());

                bsPago.DataSource = dt_datos;
                PagoBindingNavigator.BindingSource = bsPago;
                ugvPagos.DataSource = bsPago;

            }
            catch (Exception) { }
        }
        private void mtxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (mtxtCedula.Text.Length > 0)
            //{
            //    mtxtRUC.Text = "";
            //}else { mtxtCedula.Text = ""; }
            cGeneral.quitar_sonido_txt(e);
        }
        private void mtxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (mtxtRUC.Text.Length>0)
            //{
            //    mtxtCedula.Text = "";
            //}else { mtxtRUC.Text = ""; }

            cGeneral.quitar_sonido_txt(e);
        }
        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
            cGeneral.caract_especial(e);
        }
        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            cGeneral.quitar_sonido_txt(e);
        }
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Servicios.frmContratoServicio_Acciones frm = new Servicios.frmContratoServicio_Acciones();
        //        frm.Text = "AGREGAR NUEVO CONTRATO DE SERVICIO";
        //        frm.accion = false;
        //        frm.use_interno = true;
        //        frm.cmbCliente.DataSource = NPaciente.lista_combo();
        //        frm.cmbCliente.ValueMember = "Id";
        //        frm.cmbCliente.DisplayMember = "Cliente";
        //        frm.cmbCliente.Text = txtPrimerNombre.Text;
        //        frm.cmbCliente.Enabled = false;

        //        frm.cmbDoctor.DataSource = NEmpleados.lista_combo();
        //        frm.cmbDoctor.ValueMember = "Id";
        //        frm.cmbDoctor.DisplayMember = "Doctor";

        //        //frm.cmbServicio.DataSource = NServicio.lista_combo("0", cGeneral.id_user_actual.ToString());
        //        //frm.cmbServicio.ValueMember = "Id";
        //        //frm.cmbServicio.DisplayMember = "Servicio";

        //        //frm.cbAtendida.Checked = false;
        //        //frm.cbAtendida.Enabled = false;

        //        frm.cbFacturada.Checked = false;
        //        frm.cbFacturada.Enabled = false;

        //        frm.id_servicio = 0;

        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        cGeneral.error(ex);
        //    }
        //}
        //public void print_orden()
        //{
        //    try
        //    {
        //        if (this.ugvContratos.Rows.Count > 0)
        //        {
        //            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ConsentimientoFormato");
        //            frmReporte.id_contrato = this.ugvContratos.ActiveRow.Cells[0].Value.ToString();
        //            frmReporte.Show();
        //        }
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}
        //private void toolStripButton29_Click(object sender, EventArgs e)
        //{
        //    print_orden();
        //}

        //private void toolStripButton17_Click(object sender, EventArgs e)
        //{
        //    print_ticket();
        //}
        //public void print_ticket()
        //{
        //    try
        //    {
        //        if (this.ugvContratos.Rows.Count > 0)
        //        {
        //            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ContratoServicio");
        //            frmReporte.id_contrato = this.ugvContratos.ActiveRow.Cells[0].Value.ToString();
        //            frmReporte.Show();
        //        }
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        private void ugvCita_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].Width = 150;
            e.Layout.Bands[0].Columns[1].Width = 150;
            e.Layout.Bands[0].Columns[2].Width = 200;
            e.Layout.Bands[0].Columns[3].Width = 150;
            e.Layout.Bands[0].Columns[4].Width = 150;
            e.Layout.Bands[0].Columns[5].Width = 150;
            ///e.Layout.Bands[0].Columns[5].Width = 150;

            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            e.Layout.Bands[0].Columns[0].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[1].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = HAlign.Center;
            ///e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;

            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            //e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            //e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }
        private void ugvContratos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            //e.Layout.Bands[0].Columns[2].Width = 150;
            //e.Layout.Bands[0].Columns[3].Width = 60;
            //e.Layout.Bands[0].Columns[4].Width = 60;
            //e.Layout.Bands[0].Columns[5].Width = 60;
            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            ////e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }
        private void ugvFacturas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            //e.Layout.Bands[0].Columns[2].Width = 150;
            //e.Layout.Bands[0].Columns[3].Width = 60;
            //e.Layout.Bands[0].Columns[4].Width = 60;
            //e.Layout.Bands[0].Columns[5].Width = 60;
            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            //e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            e.Layout.Bands[0].Columns[1].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[1].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }
        private void ugvPagos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            //e.Layout.Bands[0].Columns[2].Width = 150;
            //e.Layout.Bands[0].Columns[3].Width = 60;
            //e.Layout.Bands[0].Columns[4].Width = 60;
            //e.Layout.Bands[0].Columns[5].Width = 60;
            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            //e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            //e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }
        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvCitas.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.ugvCitas, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }
        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvFacturas.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.ugvFacturas, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }
        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvPagos.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.ugvPagos, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }
        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvPagos.Rows.Count > 0)
                {
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("recibo");
                    frmReporte.id_pago = this.ugvPagos.ActiveRow.Cells[0].Value.ToString();
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvFacturas.Rows.Count > 0)
                {
                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("factura_tickets");
                    frmReporte.fecha_inicio = "";
                    frmReporte.fecha_fin = "";
                    frmReporte.desde = 1;
                    frmReporte.hasta = cGeneral.numItem;
                    frmReporte.print_pago = "SI";
                    frmReporte.num_factura = this.ugvFacturas.ActiveRow.Cells[0].Value.ToString();
                    frmReporte.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        //private void toolStripButton2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Pagos.frmAddPago frm = new Pagos.frmAddPago();
        //        frm.Text = "AGREGAR PAGO";
        //        frm.use_interno = true;
        //        frm.cmbCliente.Text = txtPrimerNombre.Text;
        //        frm.frm_cliente = true;
        //        try
        //        {
        //            frm.ugvFacturas.DataSource = NFactura.buscar_saldo_by_name(txtPrimerNombre.Text);
        //        }
        //        catch (Exception) { }


        //        frm.cmbCliente.Enabled = false;
        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        cGeneral.error(ex);
        //    }
        //}

        //private void toolStripButton9_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Facturas.frmFacturaServicio_Acciones frm = new Facturas.frmFacturaServicio_Acciones();
        //        frm.Text = "AGREGAR FACTURA";
        //        frm.accion = false;
        //        frm.use_interno = true;
        //        frm.frm_cliente = true;
        //        frm.name_cliente = txtPrimerNombre.Text;
        //        ///frm.cbTipoFact.Checked = true;
        //        frm.cmbServicio.DataSource = NOrdenServicio.lista_combo_by_name("SERVICIO", txtPrimerNombre.Text);
        //        frm.cmbServicio.ValueMember = "Id";
        //        frm.cmbServicio.DisplayMember = "Cliente";
        //        frm.cbInactiva.Enabled = false;

        //        frm.id_factura = 0;

        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        cGeneral.error(ex);
        //    }
        //}

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            cargar_contrato_cliente();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            cargar_factura_cliente();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            cargar_pago_cliente();
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            cargar_servicio_cliente();
        }

        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvServicio.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.ugvServicio, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }
        //public void print_servicio()
        //{
        //    try
        //    {
        //        if (this.ugvServicio.Rows.Count > 0)
        //        {
        //            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("orden_servicio");
        //            frmReporte.fecha_inicio = "";
        //            frmReporte.fecha_fin = "";
        //            frmReporte.desde = 1;
        //            frmReporte.hasta = cGeneral.numItem;
        //            frmReporte.print_pago = "SI";
        //            frmReporte.num_orden = this.ugvServicio.ActiveRow.Cells[0].Value.ToString();
        //            frmReporte.Show();
        //        }
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}
        //public void print_servicio_ticket()
        //{
        //    try
        //    {
        //        if (this.ugvServicio.Rows.Count > 0)
        //        {
        //            Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("orden_tickets");
        //            frmReporte.fecha_inicio = "";
        //            frmReporte.fecha_fin = "";
        //            frmReporte.desde = 1;
        //            frmReporte.hasta = cGeneral.numItem;
        //            frmReporte.print_pago = "SI";
        //            frmReporte.num_orden = this.ugvServicio.ActiveRow.Cells[0].Value.ToString();
        //            frmReporte.Show();
        //        }
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        //private void toolStripButton37_Click(object sender, EventArgs e)
        //{
        //    print_servicio();
        //}

        //private void toolStripButton38_Click(object sender, EventArgs e)
        //{
        //    print_servicio_ticket();
        //}

        //private void toolStripButton18_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Servicios.frmOrdenServicio_Acciones frm = new Servicios.frmOrdenServicio_Acciones();
        //        frm.Text = "AGREGAR ORDEN DE SERVICIO";
        //        frm.accion = false;
        //        frm.use_interno = true;
        //        frm.cmbCliente.DataSource = NPaciente.lista_combo();
        //        frm.cmbCliente.ValueMember = "Id";
        //        frm.cmbCliente.DisplayMember = "Cliente";
        //        frm.cmbCliente.Text = txtPrimerNombre.Text;
        //        frm.cmbCliente.Enabled = false;

        //        frm.cmbDoctor.DataSource = NEmpleados.lista_combo();
        //        frm.cmbDoctor.ValueMember = "Id";
        //        frm.cmbDoctor.DisplayMember = "Doctor";

        //        frm.cmbServicio.DataSource = NServicio.lista_combo("0", cGeneral.id_user_actual.ToString());
        //        frm.cmbServicio.ValueMember = "Id";
        //        frm.cmbServicio.DisplayMember = "Servicio";

        //        frm.cbAtendida.Checked = false;
        //        frm.cbAtendida.Enabled = false;

        //        frm.cbFacturada.Checked = false;
        //        frm.cbFacturada.Enabled = false;

        //        frm.id_servicio = 0;

        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        cGeneral.error(ex);
        //    }
        //}

        private void ugvServicio_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            //e.Layout.Bands[0].Columns[2].Width = 150;
            //e.Layout.Bands[0].Columns[3].Width = 60;
            //e.Layout.Bands[0].Columns[4].Width = 60;
            //e.Layout.Bands[0].Columns[5].Width = 60;
            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            ////e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            //e.Layout.Bands[0].Columns[2].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[2].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowDelete = DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void mtxtRUC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        Reportes.frmFacturasConSaldo frm = new Reportes.frmFacturasConSaldo();
        //        frm.use_interno = true;
        //        frm.id_cliente = frmPaciente.me.dgvClientes.ActiveRow.Cells[0].Value.ToString();
        //        frm.dtpDesde.Value = System.DateTime.Now.AddMonths(-7);
        //        ///frm.MdiParent = this;
        //        frm.Show();
        //    }
        //    catch (Exception) { }
        //}

        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumRegistro.Text.Length > 0)
                {
                    Farmacia.frmCitaPaciente frm = new Farmacia.frmCitaPaciente();
                    frm.idPaciente = txtNumRegistro.Text;
                    frm.Show();
                }
            }
            catch (Exception) { }
        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            try
            {
                int id_ser = 0, id_doctor = 0;
                if (this.ugvCitas.Rows.Count > 0)
                {
                    Farmacia.frmCitaPaciente frm = new Farmacia.frmCitaPaciente();
                    id_ser = NServicio.servicio_by_name(this.ugvCitas.ActiveRow.Cells[2].Value.ToString());
                    id_doctor = NEmpleados.emp_by_name(this.ugvCitas.ActiveRow.Cells[1].Value.ToString());
                    frm.accion = true;
                    frm.id_servicio = id_ser;
                    frm.id_doctor = id_doctor;
                    frm.idPaciente = txtNumRegistro.Text;
                    frm.id_cita = this.ugvCitas.ActiveRow.Cells[0].Value.ToString();
                    frm.cbAtendida.Checked = this.ugvCitas.ActiveRow.Cells[7].Value.ToString() == "Atendida" ? true : false;
                    frm.cmbServicio.Value = id_ser;
                    frm.cmbDoctor.Value = id_doctor;
                    frm.udDia.Value = Convert.ToDateTime(this.ugvCitas.ActiveRow.Cells[3].Value);
                    frm.dia_cita = Convert.ToDateTime(this.ugvCitas.ActiveRow.Cells[3].Value);
                    frm.hora_cita = this.ugvCitas.ActiveRow.Cells[4].Value.ToString();
                    frm.udHora.Value = this.ugvCitas.ActiveRow.Cells[4].Value.ToString();
                    frm.txtDescripcion.Text = this.ugvCitas.ActiveRow.Cells[6].Value.ToString();
                    frm.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            cargar_cita_cliente();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            DialogResult resul1 = MessageBox.Show("¿Está seguro que desea cancelar esta cita?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resul1 == System.Windows.Forms.DialogResult.Yes)
            {
                if (NCita.eliminar(this.ugvCitas.ActiveRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Cita cancelada con éxito!", "Cancelación de cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar_cita_cliente();
                }
            }
        }
        void click_eliminar()
        {
            try
            {
                DialogResult result = MessageBox.Show("Estás seguro(a) de anular este pago.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NPagoCxC.eliminar(Convert.ToInt32(this.ugvPagos.ActiveRow.Cells[0].Value)))
                    { 
                        MessageBox.Show("Pago anulado con éxito!", "Anular pago", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        ///this.Close();
                        cargar_pago_cliente();
                    }
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
        private void ugvCita_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                int id_ser = 0, id_doctor = 0;
                if (this.ugvCitas.Rows.Count > 0)
                {
                    Farmacia.frmCitaPaciente frm = new Farmacia.frmCitaPaciente();
                    id_ser = NServicio.servicio_by_name(this.ugvCitas.ActiveRow.Cells[2].Value.ToString());
                    id_doctor = NEmpleados.emp_by_name(this.ugvCitas.ActiveRow.Cells[1].Value.ToString());
                    frm.accion = true; 
                    frm.id_servicio = id_ser;
                    frm.id_doctor = id_doctor;
                    frm.idPaciente = txtNumRegistro.Text;
                    frm.id_cita = this.ugvCitas.ActiveRow.Cells[0].Value.ToString();
                    frm.cbAtendida.Checked = this.ugvCitas.ActiveRow.Cells[7].Value.ToString() == "Atendida" ? true : false;
                    frm.cmbServicio.Value = id_ser;
                    frm.cmbDoctor.Value = id_doctor;
                    frm.udDia.Value = Convert.ToDateTime(this.ugvCitas.ActiveRow.Cells[3].Value);
                    frm.udHora.Value = this.ugvCitas.ActiveRow.Cells[4].Value.ToString();
                    frm.dia_cita = Convert.ToDateTime(this.ugvCitas.ActiveRow.Cells[3].Value);
                    frm.hora_cita =  this.ugvCitas.ActiveRow.Cells[4].Value.ToString();
                    frm.txtDescripcion.Text = this.ugvCitas.ActiveRow.Cells[6].Value.ToString();
                    frm.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            click_eliminar();
        }

        //private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        Reportes.frmEstadoCuenta frm = new Reportes.frmEstadoCuenta();
        //        frm.cmbCliente.Text = txtPrimerNombre.Text;
        //        //frm.MdiParent = this;
        //        frm.Show();
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnRefrescarPresentacionCompra_Click(object sender, EventArgs e)
        {
            cargarTipoSangre();
            if (!nuevo_cliente)
            {
                cmbTipoSangre.Value = idTipoSangre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarEstadoCivil();
            if (!nuevo_cliente)
            {
                cmbEstadoCivil.Value = idEstadoCivil;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargarNacionalidad();
            if (!nuevo_cliente)
            {
                cmbNacionalidad.Value = idNacionalidad;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cargarInstruccion();
            if (!nuevo_cliente)
            {
                cmbInstruccion.Value = idInstruccion;
            }
        }

        private void toolStripButton44_Click(object sender, EventArgs e)
        {
            cargar_consultas_externas();
        }

        private void toolStripButton47_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvConsultasExternas.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.ugvConsultasExternas, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
            }
            catch (Exception)
            {
                /// MessageBox.Show("la ruta del archivo especificado no existe", "Nombre de archivo invalido");
            }
        }

        private void mtxtConvencional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtConvencional.MaskFull)
                    this.txtDireccion.Focus(); 

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpNacimiento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int edad = DateTime.Today.Year - dtpNacimiento.Value.Year;

                //si el mes es menor restamos un año directamente
                if (DateTime.Today.Month < dtpNacimiento.Value.Month)
                {
                    nudEdad.Value = --edad;
                }
                //sino preguntamos si estamos en el mismo mes, si es el mismo preguntamos si el dia de hoy es menor al de la fecha de nacimiento
                else if (DateTime.Today.Month == dtpNacimiento.Value.Month && DateTime.Today.Day < dtpNacimiento.Value.Day)
                {
                    nudEdad.Value = --edad;
                }

                nudEdad.Value = edad;
            }
            catch (Exception)
            {
                nudEdad.Value = 0;
            }
        }

        private void nudEdad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    File.Delete(cGeneral.ruta_guardar_img + "\\" + "testpatch.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("No exite la ruta: " + cGeneral.ruta_guardar_img + " donde se almacenarán las imagenes de los pacientes.", "Ruta de almacenamiento de imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (this.pbFoto.ImageLocation == null)
                {
                    DialogResult result = MessageBox.Show("Desea seleccionar una foto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.No)
                    { 
                        return;
                    }
                }

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "IMÁGENES JPG|*.JPG";
                openFileDialog1.Title = "SELECCIONE LA FOTO";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.pbFoto.ImageLocation != null)
                        try
                        {
                            File.Delete(cGeneral.ruta_guardar_img + "\\" + Path.GetFileName(this.pbFoto.ImageLocation));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No exite la ruta: " + cGeneral.ruta_guardar_img + " donde se almacenarán las imagenes de los pacientes.", "Ruta de almacenamiento de imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                    this.pbFoto.ImageLocation = openFileDialog1.FileName;

                    if (this.accion == true)
                    {
                        try
                        {
                            Image img = Image.FromFile(this.pbFoto.ImageLocation);
                            img.Save(Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName), ImageFormat.Jpeg);
                        }
                        catch (Exception)
                        {
                            ///img.Save(Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName), ImageFormat.Jpeg);
                        }

                        try
                        {
                            NPaciente.actualizar_foto(txtNumRegistro.Text, Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName));

                        }
                        catch (Exception)
                        {
                            NPaciente.actualizar_foto(txtNumRegistro.Text, Path.Combine(cGeneral.ruta_guardar_img, openFileDialog1.SafeFileName));

                        }
                    }

                    this.btnQuitar.Visible = true;
                    this.btnVer.Visible = true;
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start(NProductos.obtener_img_prod(frmProductos.me.dgvProductos.CurrentRow.Cells[0].Value.ToString()));
                Process.Start(this.pbFoto.ImageLocation);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Estás seguro(a) de quitar la foto.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                { 
                    return;
                }

                File.Delete(NPaciente.obtener_img_prod(txtNumRegistro.Text));
                NPaciente.actualizar_foto(txtNumRegistro.Text, "");
                this.pbFoto.ImageLocation = null;
                this.btnQuitar.Visible = false;
                this.btnVer.Visible = false; 
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
    }
}
