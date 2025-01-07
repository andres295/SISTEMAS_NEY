using CapaNegocios;
using SCM.Globales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.IO;
using System.Diagnostics;
using System.Net.Mail;
using System.Net.Mime;

namespace SCM.Consultas
{
    public partial class frmConsultaFormularios : Form
    {
        string vCedula = "";
        string vRuc = "";
        public string idPaciente;
        public string NombrePaciente;
        public bool gestacion = false;
        public static frmConsultaFormularios me;
        public frmConsultaFormularios(string cedulaActual = "", string rucActual = "")
        {
            frmConsultaFormularios.me = this;
            InitializeComponent(); 
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool nuevo_expediente = false;
        public bool externalUse = false;
        public int idCita = 0;
        public string idFormulario = "";
        public string fechaAtencion = "";
        public string Hora = "";
        public bool estadoExamen = false;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
             
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarDiagnostico_Click(object sender, EventArgs e)
        {
            //if (NConsultaExternaAnammnesis.guardar(idPaciente, Convert.ToDateTime(dtFechaAtencion.Value), Convert.ToDateTime(udHoraAtencion.Value), txtHitoriaClinica.Text, txtMotivoConsultaA.Text, txtMotivoConsultaB.Text, txtMotivoConsultaC.Text, txtMotivoConsultaD.Text, txtAntecedentesPersonalesA.Text, txtAntecedentesPersonalesB.Text, txtAntecedentesPersonalesC.Text, txtAntecedentesPersonalesD.Text, txtAntecedentesFamiliaresA.Text, txtAntecedentesFamiliaresB.Text, txtAntecedentesFamiliaresC.Text, txtAntecedentesFamiliaresD.Text, txtEnfermedadProblemaActualA.Text, txtEnfermedadProblemaActualB.Text, txtEnfermedadProblemaActualC.Text, txtEnfermedadProblemaActualD.Text, txtRevisionOrganoSistemaA.Text, txtRevisionOrganoSistemaB.Text, txtRevisionOrganoSistemaC.Text, txtRevisionOrganoSistemaD.Text, txtSignoVitalMedicionTemporalBucal.Text, txtSignoVitalMedicionTemporalAuxiliar.Text, txtSignoVitalMedicionFrecuenciaRespitatoria.Text, txtSignoVitalMedicionCircunferenciaCuello.Text, txtSignoVitalMedicionPeso.Text, txtSignoVitalMedicionTalla.Text, txtSignoVitalMedicionPerimetroCintura.Text, txtSignoVitalMedicionPerimetroCadera.Text, txtSignoVitalMedicionPerimetroCefalico.Text, txtExamenFisicoA.Text, txtExamenFisicoB.Text, txtExamenFisicoC.Text, txtExamenFisicoD.Text, txtDiagnosticoPresuntivoDiagnostico.Text, txtDiagnosticoPresuntivoCIE.Text, txtTratamientoPresuntivoA.Text, txtTratamientoPresuntivoB.Text, Convert.ToDateTime(dtFechaEvolucionMedicamentoA.Value), Convert.ToDateTime(dtFechaEvolucionMedicamentoB.Value), txtPrescipcion1.Text, txtPrescipcion2.Text, txtPrescipcion3.Text, txtPrescipcion4.Text, txtPrescipcion5.Text, txtPrescipcion6.Text, txtDiagnosticoDefinitivoDiagnostico.Text, txtDiagnosticoDefinitivoCIE.Text, txtTratamientoDefinitivo.Text))
            //{
            //    MessageBox.Show("FORMULARIO CONSULTAS EXTERNA Y ANAMNESIS agregado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
        }

        private void frmConsultaFormularios_Load(object sender, EventArgs e)
        {
            cmbFormulario.Focus();
            lblNombreCliente.Text = idPaciente + " - " + NombrePaciente; 
            loadFormulario();
             
            this.cmbFormulario.SelectedIndex = 0;

            this.cmbFormulario.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbCatalogo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest; 
            this.ucbExamen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            
            this.txtHitoriaClinica.Text = idFormulario;
            tHoraScore.Enabled = true;

            NExamenFormularioPaciente.eliminar_temp_by_paciente(int.Parse(idPaciente), cGeneral.name_user);
            cargarFormularioPaciente();
            if (nuevo_expediente)
            {
                tHora.Enabled = true;
                tsEditar.Enabled = false;
                btnImprimirPresuntivo.BackColor = Color.DodgerBlue;
                btnVerRecetas.BackColor = Color.DodgerBlue;
            }
            else
            {
                try
                {
                    dtFechaAtencion.Value = DateTime.Parse(fechaAtencion);
                }
                catch (Exception) {    }

                try
                {
                    udHoraAtencion.Value = DateTime.Parse(Hora);
                }
                catch (Exception)  {  }
                btnEliminar.Visible = true;
                tsEditar.Enabled = true;
                btnGuardar.Text = "GUARDAR";

                if (idFormulario.Length>0)
                {
                    btnImprimirPresuntivo.Enabled = true;
                    btnVerRecetas.Enabled = true;
                } 
                if (!estadoExamen)
                {
                    btnAgregar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAgregar.Enabled = false;
                    tsEditar.Enabled = false;
                    bgDeleteFormulario.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnGuardar.BackColor = Color.DodgerBlue;
                }
            }
            if (!gestacion)
            {
                this.pConsulta.Tabs[1].Visible = false;
                ////this.pConsulta.Tabs[1].Selected = false;
                this.pConsulta.Tabs[2].Visible = false;
               //// this.pConsulta.Tabs[2].Selected = false;
            }
        }

        private void LoadCatalogo(int idTipo)
        {
            try
            {

                cmbCatalogo.DataSource = NCatalogo.cargar_cmb_by_tipo(idTipo);
                cmbCatalogo.ValueMember = "Id";
                if (cbBuscarPorCodigo.Checked)
                {
                    cmbCatalogo.DisplayMember = "DesCod";
                   /// this.cmbCatalogo.SelectedIndex = 0;
                }
                else
                {
                    cmbCatalogo.DisplayMember = "Descripcion"; 
                }
                cmbCatalogo.Text = "";
                cmbCatalogo.SelectedIndex = 0;
            }
            catch (Exception)  {  }
        }
        private void LoadCatalogoById( UltraComboEditor combo, int id)
        {
            try
            {
                combo.DataSource = NCatalogo.obtener_datos(id);
                combo.ValueMember = "Id";
                combo.DisplayMember = "Descripcion";
                combo.SelectedIndex = 0;
            }
            catch (Exception) { }
        }
        private void loadFormulario()
        {
            try
            {
                cmbFormulario.DataSource = NCatalogo.cargar_cmb_by_tipo(6);
                cmbFormulario.ValueMember = "Id";
                cmbFormulario.DisplayMember = "Descripcion";
            }
            catch (Exception)   {    }
        }
        private void loadTipoExamenes()
        {
            try
            {
                ucbExamen.DataSource = NCatalogo.cargar_cmb_by_tipo(12);
                ucbExamen.ValueMember = "Id";
                ucbExamen.DisplayMember = "Descripcion";
                ucbExamen.SelectedIndex = 0;
            }
            catch (Exception) { }
        }
        private void btnAddFormulario_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                Catalogos.frmCatalogo.me.txtBuscar.Text = "*";
               //// frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnRefrescarFormulario_Click(object sender, EventArgs e)
        {
            loadFormulario();

        }

        private void btnRegrescarPadecimiento_Click(object sender, EventArgs e)
        {
            if (cmbFormulario.Value.ToString() == "16")
            {
                LoadCatalogo(5); 
            }
            else if (cmbFormulario.Value.ToString() == "18")
            {
                LoadCatalogo(7); 
            }
            else if (cmbFormulario.Value.ToString() == "19")
            {
                LoadCatalogo(8); 
            }
            else if (cmbFormulario.Value.ToString() == "20")
            {
                LoadCatalogo(9); 
            }
            else if (cmbFormulario.Value.ToString() == "21")
            {
                LoadCatalogo(10); 
            } 
            else if (cmbFormulario.Value.ToString() == "24")
            {
                LoadCatalogo(10); 
            }
        }

        private void btnAgregarPadecimiento_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                Catalogos.frmCatalogo.me.txtBuscar.Text = "";
                ////frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbFormulario_ValueChanged(object sender, EventArgs e)
        {
            cmbCatalogo.Visible = false;
            cmbCatalogo.Text = null;
            lblTipoCatalogo.Visible = false; 
            btnAgregarCatalogo.Visible = false;
            btnRegrescarCatalogo.Visible = false;
            cbCP.Visible = false;
            cbSP.Visible = false;
            cbSP.Checked = false;
            cbCP.Checked = false;
            lblDescripcion.Text = "Descripción:";
            pnMedicamentoPrescriocion.Visible = false;
            cbCP.Checked = false;
            cbSP.Checked = false;
            cbBuscarPorCodigo.Visible = false;
            cbBuscarPorCodigo.Checked = false;
            btnOtrosFormularios.Visible = false;
            btnAgregar.Enabled = true;
            cmbFormulario.Enabled = true;

            if (cmbFormulario.Value.ToString() == "16")
            {
                LoadCatalogo(5);
                this.cmbCatalogo.SelectedIndex = 0;
                lblTipoCatalogo.Text = "Padecimiento";
                cmbCatalogo.Visible = true;
                lblTipoCatalogo.Visible = true; 
                btnAgregarCatalogo.Visible = true;
                btnRegrescarCatalogo.Visible = true;
            } 
            else if (cmbFormulario.Value.ToString() == "18")
            {
                LoadCatalogo(7);
                this.cmbCatalogo.SelectedIndex = 0;
                lblTipoCatalogo.Text = "Tipo Patología";
                cmbCatalogo.Visible = true;
                lblTipoCatalogo.Visible = true; 
                btnAgregarCatalogo.Visible = true;
                btnRegrescarCatalogo.Visible = true;
                cbCP.Visible = true;
                cbSP.Visible = true;
            }
            else if (cmbFormulario.Value.ToString() == "19")
            {
                LoadCatalogo(8);
                this.cmbCatalogo.SelectedIndex = 0;
                lblTipoCatalogo.Text = "Signos vitales:";
                cmbCatalogo.Visible = true;
                lblTipoCatalogo.Visible = true; 
                btnAgregarCatalogo.Visible = true;
                btnRegrescarCatalogo.Visible = true;
                lblDescripcion.Text = "VALORES:";
                btnOtrosFormularios.Visible = true;
                btnAgregar.Enabled = false;
                cmbFormulario.Enabled = false;
                LoadCatalogoSignosVitales(8);
                gbDetalleOtrosFormularios.Visible = true;
                CargamosDatosSignosVitales();

            }
            else if (cmbFormulario.Value.ToString() == "20")
            {
                LoadCatalogo(9);
                this.cmbCatalogo.SelectedIndex = 0;
                lblTipoCatalogo.Text = "Examen Físico:";
                cmbCatalogo.Visible = true;
                lblTipoCatalogo.Visible = true; 
                btnAgregarCatalogo.Visible = true;
                btnRegrescarCatalogo.Visible = true;
                cbCP.Visible = true;
                cbSP.Visible = true;
            }
            else if (cmbFormulario.Value.ToString() == "21")
            {
                LoadCatalogo(10);
                this.cmbCatalogo.SelectedIndex = 0;
                lblTipoCatalogo.Text = "CIE:";
                lblDescripcion.Text = "Diagnostico";
                cmbCatalogo.Visible = true;
                lblTipoCatalogo.Visible = true; 
                btnAgregarCatalogo.Visible = true;
                btnRegrescarCatalogo.Visible = true;
                cbBuscarPorCodigo.Visible = true;
            }
            else if (cmbFormulario.Value.ToString() == "23")
            {
                lblDescripcion.Text = "EVOLUCIÓN:";
                pnMedicamentoPrescriocion.Visible = true;
            }
            else if (cmbFormulario.Value.ToString() == "24")
            {
                LoadCatalogo(10);
                this.cmbCatalogo.SelectedIndex = 0;
                lblTipoCatalogo.Text = "CIE:";
                lblDescripcion.Text = "Diagnostico";
                cmbCatalogo.Visible = true;
                lblTipoCatalogo.Visible = true; 
                btnAgregarCatalogo.Visible = true;
                btnRegrescarCatalogo.Visible = true;
                cbBuscarPorCodigo.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if ((this.cmbFormulario.Value.ToString() == "" && this.cmbFormulario.Text == "") || (this.cmbFormulario.Value == null))
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el formulario.", this.cmbFormulario, 0, 38, 3000);
                    this.cmbFormulario.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Seleccione el formulario.", this.cmbFormulario, 0, 38, 3000);
                this.cmbFormulario.Focus();
                return;
            }
            if (txtDescripcion.Text.Length <= 0 &&  cmbFormulario.Value.ToString() != "23")
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la descripción/valor del formulario", this.txtDescripcion, 0, 38, 3000);
                this.txtDescripcion.Focus();
                return;
            }

            //DialogResult resul = MessageBox.Show("Desea agregar este formulario al expediente del paciente: " + lblNombreCliente.Text, cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (resul == System.Windows.Forms.DialogResult.No)
            //{
            //    this.dgvFormularios.Focus();
            //    return;
            //}
            //else
            //{
            try
            {
                int tipoPatologiaCP = 0, tipoPatologiaSP = 0, ExamenFisicoCP = 0, ExamenFisicoSP = 0;
                int.Parse(idPaciente);
                int IdAtecedenteFamiliar = int.Parse(OptieneIdCatalogo("16"));
                /*Tipo Patología*/
                if (cmbFormulario.Value.ToString() == "18")
                {
                    if (cbCP.Checked)
                    {
                        tipoPatologiaCP = int.Parse(OptieneIdCatalogo("18"));
                    }
                    else if (cbSP.Checked)
                    {
                        tipoPatologiaSP = int.Parse(OptieneIdCatalogo("18"));
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Marque el check si es CON o SIN (CP,SP) patología.", this.cbCP, 0, 38, 3000);
                        this.cmbCatalogo.Focus();
                        return;
                    }
                } 
                /*Examen Fisico*/
                if (cmbFormulario.Value.ToString() == "20")
                {
                    if (cbCP.Checked)
                    {
                        ExamenFisicoCP = int.Parse(OptieneIdCatalogo("20"));
                    }
                    else if (cbSP.Checked)
                    {
                        ExamenFisicoSP = int.Parse(OptieneIdCatalogo("20"));
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Marque el check si es CON o SIN (CP,SP) patología.", this.cbCP, 0, 38, 3000);
                        this.cmbCatalogo.Focus();
                        return;
                    }
                }

                int IdTipoPatologiaCP = tipoPatologiaCP;
                int IdTipoPatologiaSP = tipoPatologiaSP;
                int IdSignosVitalesMediciones = int.Parse(OptieneIdCatalogo("19")); 
                int IdDiagnosticoPresuntivoCIE = int.Parse(OptieneIdCatalogo("21"));
                int IdDiagnosticoDefinitivoCIE = int.Parse(OptieneIdCatalogo("24"));

                if (nuevo_expediente)
                {
                    if (NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), txtDescripcion.Text, Globales.cGeneral.name_user, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, ExamenFisicoCP, ExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, txtMedicamento.Text, txtPrescripcion.Text))
                    {
                        ////MessageBox.Show("Formulario agregado con éxito!", "Registro de formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCatalogo.SelectedIndex = 0;
                        txtDescripcion.Text = "";
                        txtMedicamento.Text = "";
                        txtPrescripcion.Text = "";
                        cbCP.Checked = false;
                        cbSP.Checked = false;
                        cargarFormularioPaciente();
                    }
                }
                else
                {
                    if (idFormulario.Length>0)
                    {
                        if (NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), txtDescripcion.Text, Globales.cGeneral.name_user, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, ExamenFisicoCP, ExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, txtMedicamento.Text, txtPrescripcion.Text))
                        {
                            ////MessageBox.Show("Formulario agregado con éxito!", "Registro de formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbCatalogo.SelectedIndex = 0;
                            txtDescripcion.Text = "";
                            txtMedicamento.Text = "";
                            txtPrescripcion.Text = "";
                            cbCP.Checked = false;
                            cbSP.Checked = false;
                            cargarFormularioPaciente();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe id del formulario para guardar su detalle.", "No existe ID del formulario.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No existe id del paciente para cargar su expediente de formulario", "No existe ID del paciente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            cargarFormularioPaciente();
        }
        private void cargarFormularioPaciente()
        {
            try
            {
                if (nuevo_expediente)
                {
                    int.Parse(idPaciente);
                    bsExpediente.DataSource = NExamenFormularioPaciente.cargar_cmb_by_paciente_temp(null, int.Parse(idPaciente),cGeneral.name_user);
                    ExpedienteBindingNavigator.BindingSource = bsExpediente;
                    this.dgvFormularios.DataSource = bsExpediente;
                }
                else
                {
                    int.Parse(idPaciente);
                    bsExpediente.DataSource = NExamenFormularioPaciente.cargar_cmb_by_paciente_temp(idFormulario, int.Parse(idPaciente), cGeneral.name_user);
                    ExpedienteBindingNavigator.BindingSource = bsExpediente;
                    this.dgvFormularios.DataSource = bsExpediente;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe id del paciente para cargar su expediente de formulario", "No existe ID del paciente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarArchivosMaternal()
        {
            try
            {
                if (nuevo_expediente)
                {
                    int.Parse(idPaciente);
                    bsArchivo.DataSource = NExamenFormularioPaciente.cargar_archivo_maternal(int.Parse(idFormulario));
                    bnArchivo.BindingSource = bsArchivo;
                    this.ugvArchivoExamen.DataSource = bsArchivo;
                }
                else
                {
                    int.Parse(idPaciente);
                    bsArchivo.DataSource = NExamenFormularioPaciente.cargar_archivo_maternal(int.Parse(idFormulario));
                    bnArchivo.BindingSource = bsArchivo;
                    this.ugvArchivoExamen.DataSource = bsArchivo;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe id del paciente para cargar su expediente de formulario", "No existe ID del paciente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string OptieneIdCatalogo(string idString)
        {
            string idCatalogo = "0";
            try
            { 
                if (cmbFormulario.Value.ToString() == idString)
                {
                    idCatalogo = this.cmbCatalogo.Value.ToString();
                }
            }
            catch (Exception)  {}
            return idCatalogo;
        } 
        private void cbCP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCP.Checked)
            {
                cbSP.Checked = false;
            }
        } 
        private void cbSP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSP.Checked)
            {
                cbCP.Checked = false;
            }
        } 
        private void dgvFormularios_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[1].Width = 300;
            e.Layout.Bands[0].Columns[2].Width = 250;
            e.Layout.Bands[0].Columns[3].Width = 250;
            e.Layout.Bands[0].Columns[4].Width = 250;
            e.Layout.Bands[0].Columns[5].Width = 250;
            e.Layout.Bands[0].Columns[6].Width = 250;
            e.Layout.Bands[0].Columns[7].Width = 250;
            e.Layout.Bands[0].Columns[8].Width = 250;
            e.Layout.Bands[0].Columns[9].Width = 250;

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
                if (this.dgvFormularios.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.dgvFormularios, sfilePath);

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
        private void bgDeleteFormulario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFormularios.Rows.Count > 0)
                {
                    int idFormularioItem = Convert.ToInt32(this.dgvFormularios.ActiveRow.Cells[0].Value);
                    DialogResult resul1 = MessageBox.Show("¿Está seguro que desea eliminar este formulario?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (nuevo_expediente)
                        {
                            if (NExamenFormularioPaciente.eliminar_temp(idFormularioItem))
                            {
                                MessageBox.Show("Formulario eliminado con éxito!", "Eliminar formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarFormularioPaciente();
                            }
                        }
                        else
                        {
                            if (NExamenFormularioPaciente.eliminar_formulario_item(idFormularioItem))
                            {
                                MessageBox.Show("Formulario eliminado con éxito!", "Eliminar formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarFormularioPaciente();
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
 
               this.ttMensaje.Show("No hay registros de formulario ingresados para ELIMINAR. Ingresar al menos un formulario para poder eliminar.", this.dgvFormularios, 0, 38, 3000);
               
            } 
           
        } 
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (nuevo_expediente)
            {
                if (dgvFormularios.Rows.Count <= 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No hay registros de formulario ingresados. Ingresar al menos un formulario para poder guardar el formulario de consulta.", this.btnGuardar, 0, 38, 3000);
                    this.dgvFormularios.Focus();
                    return;
                }
                int idExamenFormularioNew  = NExamenFormularioPaciente.guardar_diagnostico_fianl(idCita.ToString(), idPaciente, Convert.ToDateTime(dtFechaAtencion.Value), Convert.ToDateTime(udHoraAtencion.Value), Globales.cGeneral.name_user);
                 if (idExamenFormularioNew >0)
                {
                    tHora.Enabled = false;
                    MessageBox.Show("FORMULARIOS DE CONSULTAS EXTERNA Y ANAMNESIS agregado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    //idFormulario = idExamenFormularioNew.ToString();
                    //txtHitoriaClinica.Text = idExamenFormularioNew.ToString();
                    //nuevo_expediente = false;
                    //btnImprimirPresuntivo.Enabled = true;
                    //btnVerRecetas.Enabled = true;
                    //tsEditar.Enabled = true;
                    //btnGuardar.Text = "GUARDAR"; 
                    ////cancelaEdicion();
                }
            }
            else
            {
                if (idFormulario.Length>0)
                {
                    if (NExamenFormularioPaciente.modificar_diagnostico_fianl(idFormulario, Convert.ToDateTime(dtFechaAtencion.Value), Convert.ToDateTime(udHoraAtencion.Value)))
                    {
                        MessageBox.Show("FORMULARIOS DE CONSULTAS EXTERNA Y ANAMNESIS modificado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No existe ningún examen registrado para el paciente: " + lblNombreCliente.Text, this.btnGuardar, 0, 38, 3000);
                    this.dgvFormularios.Focus();
                    return;
                }
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        { 
            if (dgvFormularios.Rows.Count>0)
            {
                CargaDatosModificar();
            }
            else
            {
                this.ttMensaje.Show("No hay registros de formulario ingresados para editar. Ingresar al menos un formulario para poder editarlo.", this.dgvFormularios, 0, 38, 3000);
            } 
        }

        private void CargaDatosModificar()
        {
            try
            {
                int idFormulario = Convert.ToInt32(this.dgvFormularios.ActiveRow.Cells[0].Value);
                DataTable dtFormulario = NExamenFormularioPaciente.cargar_cmb_by_id(idFormulario);

                if (dtFormulario.Rows.Count > 0)
                {
                    if (dtFormulario.Rows[0]["IdFormulario"].ToString() != "19")
                    {
                        btnAgregar.Enabled = false;
                        btnEditarGuardar.Enabled = true;
                        btnCancelarEdicion.Enabled = true;
                        dgvFormularios.Enabled = false;
                        bgDeleteFormulario.Enabled = false;
                        txtDescripcion.Text = dtFormulario.Rows[0]["Descripcion_Valor"].ToString();
                        cmbFormulario.Value = dtFormulario.Rows[0]["IdFormulario"].ToString();
                        txtMedicamento.Text = dtFormulario.Rows[0]["Medicamento"].ToString();
                        txtPrescripcion.Text = dtFormulario.Rows[0]["Prescripcion"].ToString();
                        cmbCatalogo.Value = dtFormulario.Rows[0]["IdCat"].ToString();

                        if (int.Parse(dtFormulario.Rows[0]["IdTipoPatologiaCP"].ToString()) > 0)
                        {
                            cbCP.Checked = true;
                        }
                        else if (int.Parse(dtFormulario.Rows[0]["IdTipoPatologiaSP"].ToString()) > 0)
                        {
                            cbSP.Checked = true;
                        }
                        else if (int.Parse(dtFormulario.Rows[0]["IdExamenFisicoCP"].ToString()) > 0)
                        {
                            cbCP.Checked = true;
                        }
                        else if (int.Parse(dtFormulario.Rows[0]["IdExamenFisicoSP"].ToString()) > 0)
                        {
                            cbSP.Checked = true;
                        }
                    }
                    else
                    {
                        LoadCatalogoSignosVitales(8);
                        gbDetalleOtrosFormularios.Visible = true;
                        CargamosDatosSignosVitales();
                    }
                }
                else
                {
                    this.ttMensaje.Show("No hay registros de formulario ingresados para editar. Ingresar al menos un formulario para poder editarlo.", this.dgvFormularios, 0, 38, 3000);
                }

            }
            catch (Exception)
            {
                btnAgregar.Enabled = true;
                btnEditarGuardar.Enabled = false;
                btnCancelarEdicion.Enabled = false;
                dgvFormularios.Enabled = true;
                bgDeleteFormulario.Enabled = true;
                txtDescripcion.Text = "";
                cmbFormulario.SelectedIndex = 0;
                txtMedicamento.Text = "";
                txtPrescripcion.Text = "";
            }
       }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            cancelaEdicion();
        }
        private void cancelaEdicion()
        {
            btnAgregar.Enabled = true;
            btnEditarGuardar.Enabled = false;
            btnCancelarEdicion.Enabled = false;
            dgvFormularios.Enabled = true;
            bgDeleteFormulario.Enabled = true;
            cmbCatalogo.SelectedIndex = 0;
            txtDescripcion.Text = "";
            txtMedicamento.Text = "";
            txtPrescripcion.Text = "";
            cmbFormulario.SelectedIndex = 0;
            cargarFormularioPaciente();
        }
        private void btnEditarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.cmbFormulario.Value.ToString() == "" && this.cmbFormulario.Text == "") || (this.cmbFormulario.Value == null))
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el formulario.", this.cmbFormulario, 0, 38, 3000);
                    this.cmbFormulario.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Seleccione el formulario.", this.cmbFormulario, 0, 38, 3000);
                this.cmbFormulario.Focus();
                return;
            }
            if (txtDescripcion.Text.Length <= 0 && cmbFormulario.Value.ToString() != "23")
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la descripción/valor del formulario", this.txtDescripcion, 0, 38, 3000);
                this.txtDescripcion.Focus();
                return;
            } 
            try
            {
                int tipoPatologiaCP = 0, tipoPatologiaSP = 0, ExamenFisicoCP = 0, ExamenFisicoSP = 0;
                int.Parse(idPaciente);
                int IdAtecedenteFamiliar = int.Parse(OptieneIdCatalogo("16"));
                /*Tipo Patología*/
                if (cmbFormulario.Value.ToString() == "18")
                {
                    if (cbCP.Checked)
                    {
                        tipoPatologiaCP = int.Parse(OptieneIdCatalogo("18"));
                    }
                    else if (cbSP.Checked)
                    {
                        tipoPatologiaSP = int.Parse(OptieneIdCatalogo("18"));
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Marque el check si es CON o SIN (CP,SP) patología.", this.cbCP, 0, 38, 3000);
                        this.cmbCatalogo.Focus();
                        return;
                    }
                }
                /*Examen Fisico*/
                if (cmbFormulario.Value.ToString() == "20")
                {
                    if (cbCP.Checked)
                    {
                        ExamenFisicoCP = int.Parse(OptieneIdCatalogo("20"));
                    }
                    else if (cbSP.Checked)
                    {
                        ExamenFisicoSP = int.Parse(OptieneIdCatalogo("20"));
                    }
                    else
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Marque el check si es CON o SIN (CP,SP) patología.", this.cbCP, 0, 38, 3000);
                        this.cmbCatalogo.Focus();
                        return;
                    }
                }
                int IdTipoPatologiaCP = tipoPatologiaCP;
                int IdTipoPatologiaSP = tipoPatologiaSP;
                int IdSignosVitalesMediciones = int.Parse(OptieneIdCatalogo("19")); 
                int IdDiagnosticoPresuntivoCIE = int.Parse(OptieneIdCatalogo("21"));
                int IdDiagnosticoDefinitivoCIE = int.Parse(OptieneIdCatalogo("24"));
                 
                if (dgvFormularios.Rows.Count > 0)
                { 
                    int idFomrItem = Convert.ToInt32(this.dgvFormularios.ActiveRow.Cells[0].Value);
                    if (NExamenFormularioPaciente.modificar_formulario_item(idFomrItem, int.Parse(cmbFormulario.Value.ToString()), txtDescripcion.Text, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, ExamenFisicoCP, ExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, txtMedicamento.Text, txtPrescripcion.Text))
                    {
                        MessageBox.Show("Formulario modificado con éxito!", "Registro de formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCatalogo.SelectedIndex = 0;
                        txtDescripcion.Text = "";
                        txtMedicamento.Text = "";
                        txtPrescripcion.Text = "";
                        cbSP.Checked = false;
                        cbCP.Checked = false;
                        cancelaEdicion();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado el formulario para actualizar su detalle.", "No existe ID del formulario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No existe id del paciente para cargar su expediente de formulario", "No existe ID del paciente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idFormulario.Length > 0)
            {
                if (NExamenFormularioPaciente.eliminar_diagnostico_fianl(idFormulario))
                {
                    MessageBox.Show("FORMULARIOS DE CONSULTAS EXTERNA Y ANAMNESIS eliminado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No existe ningún examen registrado para el paciente: " + lblNombreCliente.Text, this.btnGuardar, 0, 38, 3000);
                this.dgvFormularios.Focus();
                return;
            }
        }

        private void btnImprimirPresuntivo_Click(object sender, EventArgs e)
        {
            try
            {

                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenFormulario");
                frmReporte.idExamenFormulario = idFormulario;
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVerRecetas_Click(object sender, EventArgs e)
        {
            try
            {

                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenFormularioReceta");
                frmReporte.idExamenFormulario = idFormulario;
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            try
            { 
                udHoraAtencion.Value = System.DateTime.Now;
                 
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tHoraScore_Tick(object sender, EventArgs e)
        {
            try
            {
                dtHoraScore.Value = System.DateTime.Now;

            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }
        private void cargarHistoricoControScoMama()
        {
            try
            {
                bsHistoricoEcoMama.DataSource = NExamenFormularioPaciente.cargar_contro_score_by_formulario(int.Parse(idFormulario));
                bnHistoricoEcoMama.BindingSource = bsHistoricoEcoMama;
                this.ugvHistoricoEcoMama.DataSource = bsHistoricoEcoMama;
            }
            catch (Exception) {}
        }
        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        { 
            if (e.Tab.Text == "CONTROL DE SIGNOS VITALES Y MEDICIONES DE SCORE MAMÁ")
            {
                cargarHistoricoControScoMama();
                LoadCatalogoById(cmbControScore1, 40);
                LoadCatalogoById(cmbControScore2, 38);
                LoadCatalogoById(cmbControScore3, 39);
                LoadCatalogoById(cmbControScore4, 43);
                LoadCatalogoById(cmbControScore5, 42);
                LoadCatalogoById(cmbControScore6, 58);
                LoadCatalogoById(cmbControScore7, 59);
                LoadCatalogoById(cmbControScore8, 60);
                LoadCatalogoById(cmbControScore9, 61);
               /// LoadCatalogoById(cmbControScore10, 58);

                nudValorScore1.Value = 0;
                nudValorScore2.Value = 0;
                nudValorScore3.Value = 0;
                nudValorScore4.Value = 0;
                nudValorScore5.Value = 0;
                nudValorScore6.Value = 0;
                nudValorScore7.Value = 0;
                nudValorScore8.Value = 0;
                nudValorScore9.Value = 0;
                ///nudValorScore10.Value = 0;

                nudPuntajeScore1.Value = 0;
                nudPuntajeScore2.Value = 0;
                nudPuntajeScore3.Value = 0;
                nudPuntajeScore4.Value = 0;
                nudPuntajeScore5.Value = 0;
                nudPuntajeScore6.Value = 0;
                nudPuntajeScore7.Value = 0;
                nudPuntajeScore8.Value = 0;
                nudPuntajeScore9.Value = 0;
               /// nudPuntajeScore10.Value = 0;
               lblResponsable.Text = cGeneral.name_user;
            }
            else if (e.Tab.Text == "Historia Clínica Maternal Perinatal - MSP")
            {
                if (idFormulario.Length >0)
                {
                    btnAgregarExamenFile.Enabled = true;
                    loadTipoExamenes();
                    CargarArchivosMaternal();
                }
                else
                {
                    btnAgregarExamenFile.Enabled = false;
                    MessageBox.Show("Tiene que guardar primero el formulario, para luego agregar Historia Clínica Maternal Perinatla  - MSP ", "Aviso formulario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAgregarScoreMama_Click(object sender, EventArgs e)
        {
            if (txtHitoriaClinica.Text.Length<=0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No existe o no esta registrado el formulario. Favor primero guardar el formulario y luego proceder agregar el SCORE MAMÁ.", this.btnAgregarScoreMama, 0, 38, 3000);
                this.cmbControScore1.Focus();
                return;
            }
            if (idFormulario != "")
            {
                var flag = NExamenFormularioPaciente.AgregarScoreMama(int.Parse(idPaciente), int.Parse(idFormulario), Convert.ToDateTime(dtFechaScore.Value), Convert.ToDateTime(dtHoraScore.Value), int.Parse(cmbControScore1.Value.ToString()), int.Parse(cmbControScore2.Value.ToString()), int.Parse(cmbControScore3.Value.ToString()), int.Parse(cmbControScore4.Value.ToString()), int.Parse(cmbControScore5.Value.ToString()), int.Parse(cmbControScore6.Value.ToString()), int.Parse(cmbControScore7.Value.ToString()), int.Parse(cmbControScore8.Value.ToString()), int.Parse(cmbControScore9.Value.ToString()), 0, int.Parse(nudValorScore1.Value.ToString()), int.Parse(nudValorScore2.Value.ToString()), int.Parse(nudValorScore3.Value.ToString()), int.Parse(nudValorScore4.Value.ToString()), int.Parse(nudValorScore5.Value.ToString()), int.Parse(nudValorScore6.Value.ToString()), int.Parse(nudValorScore7.Value.ToString()), int.Parse(nudValorScore8.Value.ToString()), int.Parse(nudValorScore9.Value.ToString()), 0, int.Parse(nudPuntajeScore1.Value.ToString()), int.Parse(nudPuntajeScore2.Value.ToString()), int.Parse(nudPuntajeScore3.Value.ToString()), int.Parse(nudPuntajeScore4.Value.ToString()), int.Parse(nudPuntajeScore5.Value.ToString()), int.Parse(nudPuntajeScore6.Value.ToString()), int.Parse(nudPuntajeScore7.Value.ToString()), int.Parse(nudPuntajeScore8.Value.ToString()), int.Parse(nudPuntajeScore9.Value.ToString()), 0,lblResponsable.Text);
                MessageBox.Show("Control de Signos Vitales y medición de Score Mamá agregado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarHistoricoControScoMama();
            } 
        }
        private bool validarCampos()
        {
            bool flag = false;
            try
            {
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore2.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore2.Focus();
                    flag = false;
                }
                if (nudValorScore3.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore3.Focus();
                    flag = false;
                }
                if (nudValorScore4.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
                if (nudValorScore1.Value == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Este campo no puede quedar en cero o vacio.", this.btnAgregarScoreMama, 0, 38, 3000);
                    this.nudValorScore1.Focus();
                    flag = false;
                }
            }
            catch (Exception)
            { 
                flag = false;
            }
            return flag;
        }

        private void nudValorScore1_ValueChanged(object sender, EventArgs e)
        {
            var v = nudValorScore1.Value;
        }

        private void nudValorScore1_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            cargarHistoricoControScoMama();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvHistoricoEcoMama.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.ugvHistoricoEcoMama, sfilePath);

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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {

                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenFormularioScore");
                frmReporte.idExamenFormulario = idFormulario;
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ugvHistoricoEcoMama.Rows.Count > 0)
                {
                    int idFormularioItem = Convert.ToInt32(this.ugvHistoricoEcoMama.ActiveRow.Cells[0].Value);
                    DialogResult resul1 = MessageBox.Show("¿Está seguro que desea eliminar control de score mamá?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    { 
                        if (NExamenFormularioPaciente.eliminar_ControlScoreMama(idFormularioItem))
                        {
                            MessageBox.Show("Control de Score mamá eliminado con éxito!", "Eliminar Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarHistoricoControScoMama();
                        } 
                    }
                }
                else
                {
                    this.ttMensaje.Show("No hay registros de formulario ingresados para ELIMINAR. Ingresar al menos un formulario para poder eliminar.", this.ugvHistoricoEcoMama, 0, 38, 3000);

                }
            }
            catch (Exception)
            {

                this.ttMensaje.Show("No hay registros de formulario ingresados para ELIMINAR. Ingresar al menos un formulario para poder eliminar.", this.ugvHistoricoEcoMama, 0, 38, 3000);

            }
        }

        private void btnNuevoDocumento_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx;*.png;*.jpg;)|*.pdf; *.docx; *.xlsx;*.png;*.jpg;";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        txtFile.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Porfavor seleccione un archivo.","Seleccionar archivo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregarExamenFile_Click(object sender, EventArgs e)
        { 
            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Porfavor seleccione un archivo");
                }
                else
                {
                    try
                    {
                        if ((this.ucbExamen.Value.ToString() == "" && this.ucbExamen.Text == "") || (this.ucbExamen.Value == null))
                        {
                            this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                            this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                            this.ttMensaje.Show("Seleccione el tipo de exámen.", this.ucbExamen, 0, 38, 3000);
                            this.ucbExamen.Focus();
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Seleccione el tipo de exámen.", this.ucbExamen, 0, 38, 3000);
                        this.ucbExamen.Focus();
                        return;
                    }
                    if (txtFile.Text.Length <= 0)
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("No ha seleccionado el archivo para soportar este exámen.", this.btnAgregarExamenFile, 0, 38, 3000);
                        this.txtFile.Focus();
                        return;
                    }
                    if (idFormulario != "")
                    {
                        var bytesFile = File.ReadAllBytes(openFileDialog1.FileName);  
                        var flag = NExamenFormularioPaciente.AgregarExamenFile(int.Parse(idPaciente), int.Parse(idFormulario), int.Parse(ucbExamen.Value.ToString()), txtValoracion.Text.ToUpper(), bytesFile, Path.GetFileName(openFileDialog1.FileName), Path.GetExtension(openFileDialog1.FileName));
                        MessageBox.Show("Historia Clínica Maternal Perinatal - MSP agrgaga con éxito", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFile.Text = "";
                        txtValoracion.Text = "";
                        CargarArchivosMaternal();
                        ///// cargarHistoricoControScoMama();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            CargarArchivosMaternal();
        }

        private void ugvArchivoExamen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].Width = 50;
            e.Layout.Bands[0].Columns[1].Width = 300;
            e.Layout.Bands[0].Columns[2].Width = 350;
            e.Layout.Bands[0].Columns[3].Width = 200;
            e.Layout.Bands[0].Columns[4].Width = 50;

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

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ugvArchivoExamen.Rows.Count > 0)
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

                    this.ultraGridExcelExporter1.Export(this.ugvArchivoExamen, sfilePath);

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

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            cargarArchivo();
        } 
        private void  cargarArchivo()
        {
            try
            {
                if (ugvArchivoExamen.Rows.Count > 0)
                {
                    int idFile = Convert.ToInt32(this.ugvArchivoExamen.ActiveRow.Cells[0].Value);
                    string nameFile = this.ugvArchivoExamen.ActiveRow.Cells[3].Value.ToString();
                    string extFile = this.ugvArchivoExamen.ActiveRow.Cells[4].Value.ToString();
                    byte[] dataFile = NExamenFormularioPaciente.get_file_item_formulario(idFile);
                      
                    if (dataFile != null)
                    {
                        string newfile = @"C:\DOC_HC";
                        DirectoryInfo l_dDirInfo = new DirectoryInfo(newfile);
                        if (l_dDirInfo.Exists == false)
                        {
                            Directory.CreateDirectory(newfile);
                        }
                        string NewPath = newfile + "\\" + nameFile;

                        using (FileStream fStream = new FileStream(NewPath, FileMode.Create))
                        {
                            fStream.Write(dataFile, 0, dataFile.Length);
                        }
                        Process.Start(NewPath);
                    }
                }
                else
                {
                    this.ttMensaje.Show("No hay documentos agregados. Agregar al menos un documento para que se pueda visualizar.", this.ugvArchivoExamen, 0, 38, 3000);

                }
            }
            catch (Exception)
            {
                this.ttMensaje.Show("No hay documentos agregados. Agregar al menos un documento para que se pueda visualizar.", this.ugvArchivoExamen, 0, 38, 3000);
            }
        }

        private void ugvArchivoExamen_DoubleClick(object sender, EventArgs e)
        {
            cargarArchivo();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        { 
            try
            {
                if (ugvArchivoExamen.Rows.Count > 0)
                {
                    int idFile = Convert.ToInt32(this.ugvArchivoExamen.ActiveRow.Cells[0].Value);
                    DialogResult resul1 = MessageBox.Show("¿Está seguro que desea eliminar esta Historia Clínica Maternal Perinatal -MSP?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NExamenFormularioPaciente.eliminar_archivo_hc(idFile))
                        {
                            MessageBox.Show("Historia Clínica Maternal Perinatal -MSP eliminado con éxito!", "Eliminar Historia Clínica Maternal Perinatal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarArchivosMaternal();
                        }
                    }
                }
                else
                {
                    this.ttMensaje.Show("No hay registros de Historia Clínica Maternal Perinatal ingresados para ELIMINAR. Ingresar al menos una Historia Clínica Maternal Perinatal para poder eliminar.", this.ugvArchivoExamen, 0, 38, 3000);

                }
            }
            catch (Exception)
            {

                this.ttMensaje.Show("No hay registros de Historia Clínica Maternal Perinatal ingresados para ELIMINAR. Ingresar al menos una Historia Clínica Maternal Perinatal para poder eliminar.", this.ugvArchivoExamen, 0, 38, 3000);

            }
        }

        private void cmbCatalogo_ValueChanged(object sender, EventArgs e)
        {
          
           
        }

        private void cmbCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (cmbFormulario.Value.ToString() == "21" || cmbFormulario.Value.ToString() == "24")
            {
                try
                {
                    int idCat = 0;
                    try
                    {
                        idCat = int.Parse(cmbCatalogo.Value.ToString());

                        DataTable dt = NCatalogo.obtener_datos(idCat);

                        if (dt.Rows.Count > 0)
                        {
                            lblCodigoCat.Text = dt.Rows[0]["Codigo"].ToString();
                            lblCodigoCat.Visible = true;
                        }
                    }
                    catch (Exception)
                    {
                        lblCodigoCat.Visible = false;
                        lblCodigoCat.Text = "";
                        ///MessageBox.Show("Favor seleccionar un catálogo de la lista correcto.", "Seleccione un catálogo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (Exception) { lblCodigoCat.Visible = false; lblCodigoCat.Text = ""; }
            }
            else
            {
                lblCodigoCat.Visible = false;
            }
        }

        private void cbBuscarPorCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFormulario.Value.ToString() == "21" || cmbFormulario.Value.ToString() == "24")
            {
                LoadCatalogo(10);
            }
        }

        private void btnOtrosFormularios_Click(object sender, EventArgs e)
        {
            LoadCatalogoSignosVitales(8);
            gbDetalleOtrosFormularios.Visible = true;
            cmbFormulario.Enabled = false;
            btnAgregar.Enabled= false ;
            CargamosDatosSignosVitales();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            gbDetalleOtrosFormularios.Visible = false;
            cmbFormulario.Enabled = true;
        }
        private void LoadCatalogoSignosVitales(int idTipo)
        {
            try
            {

                DataTable dtSignosVitales = NCatalogo.cargar_cmb_by_tipo(idTipo);

                cmbPresionArterialSistólica.DataSource = dtSignosVitales;
                cmbPresionArterialSistólica.ValueMember = "Id";
                cmbPresionArterialSistólica.DisplayMember = "Descripcion";
                cmbPresionArterialSistólica.SelectedIndex = 0;

                cmbPrecionAlterialDiagnostica.DataSource = dtSignosVitales;
                cmbPrecionAlterialDiagnostica.ValueMember = "Id";
                cmbPrecionAlterialDiagnostica.DisplayMember = "Descripcion";
                cmbPrecionAlterialDiagnostica.SelectedIndex = 1;

                cmbFrecuenciaCardiaca.DataSource = dtSignosVitales;
                cmbFrecuenciaCardiaca.ValueMember = "Id";
                cmbFrecuenciaCardiaca.DisplayMember = "Descripcion";
                cmbFrecuenciaCardiaca.SelectedIndex = 2;

                cmbTempearaturaBucal.DataSource = dtSignosVitales;
                cmbTempearaturaBucal.ValueMember = "Id";
                cmbTempearaturaBucal.DisplayMember = "Descripcion";
                cmbTempearaturaBucal.SelectedIndex = 3;

                cmbTemperaturaAuxiliar.DataSource = dtSignosVitales;
                cmbTemperaturaAuxiliar.ValueMember = "Id";
                cmbTemperaturaAuxiliar.DisplayMember = "Descripcion";
                cmbTemperaturaAuxiliar.SelectedIndex = 4;

                cmbFrecuenciaRespiratoria.DataSource = dtSignosVitales;
                cmbFrecuenciaRespiratoria.ValueMember = "Id";
                cmbFrecuenciaRespiratoria.DisplayMember = "Descripcion";
                cmbFrecuenciaRespiratoria.SelectedIndex = 5;

                cmbCircunferenciaCuello.DataSource = dtSignosVitales;
                cmbCircunferenciaCuello.ValueMember = "Id";
                cmbCircunferenciaCuello.DisplayMember = "Descripcion";
                cmbCircunferenciaCuello.SelectedIndex = 6;

                cmbPeso.DataSource = dtSignosVitales;
                cmbPeso.ValueMember = "Id";
                cmbPeso.DisplayMember = "Descripcion";
                cmbPeso.SelectedIndex = 7;

                cmbTalla.DataSource = dtSignosVitales;
                cmbTalla.ValueMember = "Id";
                cmbTalla.DisplayMember = "Descripcion";
                cmbTalla.SelectedIndex = 8;

                cmbPerimetroCintura.DataSource = dtSignosVitales;
                cmbPerimetroCintura.ValueMember = "Id";
                cmbPerimetroCintura.DisplayMember = "Descripcion";
                cmbPerimetroCintura.SelectedIndex = 9;

                cmbPerimetroCadena.DataSource = dtSignosVitales;
                cmbPerimetroCadena.ValueMember = "Id";
                cmbPerimetroCadena.DisplayMember = "Descripcion";
                cmbPerimetroCadena.SelectedIndex = 10;

                cmbPerimetroCefalico.DataSource = dtSignosVitales;
                cmbPerimetroCefalico.ValueMember = "Id";
                cmbPerimetroCefalico.DisplayMember = "Descripcion";
                cmbPerimetroCefalico.SelectedIndex = 11;

                cmbSaturacionOxigeno.DataSource = dtSignosVitales;
                cmbSaturacionOxigeno.ValueMember = "Id";
                cmbSaturacionOxigeno.DisplayMember = "Descripcion";
                cmbSaturacionOxigeno.SelectedIndex = 12;

            }
            catch (Exception) { }
        }
        private void CargamosDatosSignosVitales()
        {
            try
            {

              DataTable dt = NExamenFormularioPaciente.cargar_detalle_examen(cmbFormulario.Value.ToString(), int.Parse(idFormulario), cGeneral.name_user);

                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    { 
                        if (cmbPresionArterialSistólica.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudPrecionAlterialSistolica.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString()); 
                        }
                        //else
                        //{
                        //    nudPrecionAlterialSistolica.Value = 0;
                        //}
                        if (cmbPrecionAlterialDiagnostica.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudPrecionAlterialDiagnostica.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudPrecionAlterialDiagnostica.Value = 0;
                        //}
                        if (cmbFrecuenciaCardiaca.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudFrecuenciaCardiaca.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudFrecuenciaCardiaca.Value = 0;
                        //}
                        if (cmbTempearaturaBucal.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudTempearaturaBucal.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudTempearaturaBucal.Value = 0;
                        //}
                        if (cmbTemperaturaAuxiliar.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudTemperaturaAuxiliar.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudTemperaturaAuxiliar.Value = 0;
                        //}
                        if (cmbFrecuenciaRespiratoria.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudFrecuenciaRespiratoria.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudFrecuenciaRespiratoria.Value = 0;
                        //}
                        if (cmbCircunferenciaCuello.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudCircunferenciaCuello.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudCircunferenciaCuello.Value = 0;
                        //}
                        if (cmbPeso.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudPeso.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudPeso.Value = 0;
                        //}
                        if (cmbTalla.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudTalla.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudTalla.Value = 0;
                        //}
                        if (cmbPerimetroCintura.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudPerimetroCintura.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudPerimetroCintura.Value = 0;
                        //}
                        if (cmbPerimetroCadena.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudPerimetroCadena.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudPerimetroCadena.Value = 0;
                        //}
                        if (cmbPerimetroCefalico.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudPerimetroCefalico.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudPerimetroCefalico.Value = 0;
                        //}
                        if (cmbSaturacionOxigeno.Value.ToString() == dt.Rows[i]["IdSignosVitalesMediciones"].ToString())
                        {
                            nudSaturacionOxigeno.Value = int.Parse(dt.Rows[i]["Descripcion_Valor"].ToString());
                        }
                        //else
                        //{
                        //    nudSaturacionOxigeno.Value = 0;
                        //}
                    } 
                }
                else
                {
                    nudPrecionAlterialSistolica.Value = 0;
                    nudPrecionAlterialDiagnostica.Value = 0;
                    nudFrecuenciaCardiaca.Value = 0;
                    nudTempearaturaBucal.Value = 0;
                    nudTemperaturaAuxiliar.Value = 0;
                    nudFrecuenciaRespiratoria.Value = 0;
                    nudCircunferenciaCuello.Value = 0;
                    nudPeso.Value = 0;
                    nudTalla.Value = 0;
                    nudPerimetroCintura.Value = 0;
                    nudPerimetroCadena.Value = 0;
                    nudPerimetroCefalico.Value = 0;
                    nudSaturacionOxigeno.Value = 0;
                }
            }
            catch (Exception)
            { 
                nudPrecionAlterialSistolica.Value = 0;
                nudPrecionAlterialDiagnostica.Value = 0;
                nudFrecuenciaCardiaca.Value = 0;
                nudTempearaturaBucal.Value = 0;
                nudTemperaturaAuxiliar.Value = 0;
                nudFrecuenciaRespiratoria.Value = 0;
                nudCircunferenciaCuello.Value = 0;
                nudPeso.Value = 0;
                nudTalla.Value = 0;
                nudPerimetroCintura.Value = 0;
                nudPerimetroCadena.Value = 0;
                nudPerimetroCefalico.Value = 0;
                nudSaturacionOxigeno.Value = 0;
            }
        }
        private void ultraTabPageControl16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardarSignoVital_Click(object sender, EventArgs e)
        {
            try
            {
                if (nuevo_expediente)
                {
                    NExamenFormularioPaciente.delete_detalle_examen(cmbFormulario.Value.ToString(), int.Parse(idFormulario), cGeneral.name_user);
                    //Presión Arterial(Sistólica)
                    if (nudPrecionAlterialSistolica.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPrecionAlterialSistolica.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPresionArterialSistólica.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Presión Arterial(Diastólica)
                    if (nudPrecionAlterialDiagnostica.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPrecionAlterialDiagnostica.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPrecionAlterialDiagnostica.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Frecuencia Cardiaca(Min)
                    if (nudFrecuenciaCardiaca.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudFrecuenciaCardiaca.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbFrecuenciaCardiaca.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Temperatura Bucal(°C)
                    if (nudTempearaturaBucal.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudTempearaturaBucal.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbTempearaturaBucal.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Temperatura Axilar(°C)
                    if (nudTemperaturaAuxiliar.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudTemperaturaAuxiliar.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbTemperaturaAuxiliar.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Frecuencia Respiratoria(Min)
                    if (nudFrecuenciaRespiratoria.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudFrecuenciaRespiratoria.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbFrecuenciaRespiratoria.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Circunferencia de Cuello(Cm)
                    if (nudCircunferenciaCuello.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudCircunferenciaCuello.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbCircunferenciaCuello.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Peso(Kg)
                    if (nudPeso.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPeso.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPeso.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Talla(M)
                    if (nudTalla.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudTalla.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbTalla.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Perímetro Cintura(Cm)
                    if (nudPerimetroCintura.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPerimetroCintura.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPerimetroCintura.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Perímetro Cadera(Cm)
                    if (nudPerimetroCadena.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPerimetroCadena.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPerimetroCadena.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Perímetro Cefálico(Cm)
                    if (nudPerimetroCefalico.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPerimetroCefalico.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPerimetroCefalico.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    //Saturación de Oxígeno
                    if (nudSaturacionOxigeno.Value > 0)
                    {
                        NExamenFormularioPaciente.guardar_temp(int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudSaturacionOxigeno.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbSaturacionOxigeno.Value.ToString()), 0, 0, 0, 0, null, null);
                    }
                    cargarFormularioPaciente();
                    MessageBox.Show("Signos vitales agregados con éxito.", "Datos guardados.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gbDetalleOtrosFormularios.Visible = false;
                }
                else
                {
                    if (idFormulario.Length > 0)
                    {
                        NExamenFormularioPaciente.delete_detalle_examen(cmbFormulario.Value.ToString(), int.Parse(idFormulario), cGeneral.name_system);
                        //Presión Arterial(Sistólica)
                        if (nudPrecionAlterialSistolica.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario),int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPrecionAlterialSistolica.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPresionArterialSistólica.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Presión Arterial(Diastólica)
                        if (nudPrecionAlterialDiagnostica.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPrecionAlterialDiagnostica.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPrecionAlterialDiagnostica.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Frecuencia Cardiaca(Min)
                        if (nudFrecuenciaCardiaca.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudFrecuenciaCardiaca.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbFrecuenciaCardiaca.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Temperatura Bucal(°C)
                        if (nudTempearaturaBucal.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudTempearaturaBucal.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbTempearaturaBucal.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Temperatura Axilar(°C)
                        if (nudTemperaturaAuxiliar.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudTemperaturaAuxiliar.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbTemperaturaAuxiliar.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Frecuencia Respiratoria(Min)
                        if (nudFrecuenciaRespiratoria.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudFrecuenciaRespiratoria.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbFrecuenciaRespiratoria.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Circunferencia de Cuello(Cm)
                        if (nudCircunferenciaCuello.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudCircunferenciaCuello.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbCircunferenciaCuello.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Peso(Kg)
                        if (nudPeso.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPeso.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPeso.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Talla(M)
                        if (nudTalla.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudTalla.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbTalla.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Perímetro Cintura(Cm)
                        if (nudPerimetroCintura.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPerimetroCintura.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPerimetroCintura.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Perímetro Cadera(Cm)
                        if (nudPerimetroCadena.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPerimetroCadena.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPerimetroCadena.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Perímetro Cefálico(Cm)
                        if (nudPerimetroCefalico.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudPerimetroCefalico.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbPerimetroCefalico.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        //Saturación de Oxígeno
                        if (nudSaturacionOxigeno.Value > 0)
                        {
                            NExamenFormularioPaciente.guardar_formulario_item(int.Parse(idFormulario), int.Parse(idPaciente), int.Parse(cmbFormulario.Value.ToString()), nudSaturacionOxigeno.Value.ToString(), Globales.cGeneral.name_user, 0, 0, 0, int.Parse(cmbSaturacionOxigeno.Value.ToString()), 0, 0, 0, 0, null, null);
                        }
                        cargarFormularioPaciente();
                        MessageBox.Show("Signos vitales agregados con éxito.", "Datos guardados.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gbDetalleOtrosFormularios.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show( "No existe id del formulario para guardar su detalle.", "No existe ID del formulario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "No existe ID del formulario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            nudPrecionAlterialSistolica.Value = 0;
            nudPrecionAlterialDiagnostica.Value = 0;
            nudFrecuenciaCardiaca.Value = 0;
            nudTempearaturaBucal.Value = 0;
            nudTemperaturaAuxiliar.Value = 0;
            nudFrecuenciaRespiratoria.Value = 0;
            nudCircunferenciaCuello.Value = 0;
            nudPeso.Value = 0;
            nudTalla.Value = 0;
            nudPerimetroCintura.Value = 0;
            nudPerimetroCadena.Value = 0;
            nudPerimetroCefalico.Value = 0;
            nudSaturacionOxigeno.Value = 0;
            cmbFormulario.Enabled = true;
        }

        private void btnEliminarSignoVital_Click(object sender, EventArgs e)
        {
            NExamenFormularioPaciente.delete_detalle_examen(cmbFormulario.Value.ToString(), int.Parse(idFormulario), cGeneral.name_user);
            nudPrecionAlterialSistolica.Value = 0;
            nudPrecionAlterialDiagnostica.Value = 0;
            nudFrecuenciaCardiaca.Value = 0;
            nudTempearaturaBucal.Value = 0;
            nudTemperaturaAuxiliar.Value = 0;
            nudFrecuenciaRespiratoria.Value = 0;
            nudCircunferenciaCuello.Value = 0;
            nudPeso.Value = 0;
            nudTalla.Value = 0;
            nudPerimetroCintura.Value = 0;
            nudPerimetroCadena.Value = 0;
            nudPerimetroCefalico.Value = 0;
            nudSaturacionOxigeno.Value = 0;
            cargarFormularioPaciente();
            MessageBox.Show("Signos vitales eliminados con éxito.", "Eliminar signos vitales", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            gbDetalleOtrosFormularios.Visible = false;
            cmbFormulario.Enabled = true;
        }
    }
}
