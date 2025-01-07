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
    public partial class frmExamenesGenerales : Form
    {
        string vCedula = "";
        string vRuc = "";
        public string idPaciente;
        public string NombrePaciente;
        public bool gestacion = false;
        public decimal costoServicio = 0;
        public static frmExamenesGenerales me;
        public frmExamenesGenerales(string cedulaActual = "", string rucActual = "")
        {
            frmExamenesGenerales.me = this;
            InitializeComponent();
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool nuevo_examen = false;
        public bool externalUse = false;
        public int idCita = 0;
        public string idExamen = "";
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
            ////cmbFormulario.Focus();
            /////lblNombreCliente.Text = idPaciente + " - " + NombrePaciente; 
            ///loadFormulario();

            this.ucbExamen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbDoctor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbPaciente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;

            LoadDoctor();
            LoadExamen(13);
            LoadPaciente();
            this.ucbExamen.SelectedIndex = 0;
            this.cmbDoctor.SelectedIndex = 0;
            ///this.cmbPaciente.SelectedIndex = 0;
            CargarArchivos();
            if (nuevo_examen)
            {  
                btnImprimir.BackColor = Color.DodgerBlue;
                NExamenFormularioPaciente.eliminar_archivo_examen_general_hc_temp(cGeneral.name_user);
            }
            else
            {
                btnImprimir.Enabled = true;
                txtID.Text = idExamen;
                if (idExamen.Length>0)
                {
                    obtenerDatosExamenParaModificar(idExamen);
                    CargarArchivos();
                }
               
            }
            loadfoto();
            ///tHoraScore.Enabled = true;

            ///NExamenFormularioPaciente.eliminar_temp_by_paciente(int.Parse(idPaciente), cGeneral.name_user);
            ///cargarFormularioPaciente(); 
        }
        private void loadfoto()
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NPaciente.obtener_datos(Convert.ToInt32(cmbPaciente.Value.ToString()));

                if (dt_datos.Rows.Count > 0)
                {
                    if (File.Exists(dt_datos.Rows[0].ItemArray[17].ToString()))
                    {
                        pbFoto.ImageLocation = dt_datos.Rows[0].ItemArray[17].ToString();
                    }
                    else { pbFoto.ImageLocation = null; }
                }
                else { pbFoto.ImageLocation = null; }
            }
            catch (Exception) { pbFoto.ImageLocation = null; }
        }
        private void obtenerDatosExamenParaModificar(string idExamen)
        {
            try
            { 
                DataTable dtExamen = NExamenFormularioPaciente.cargar_examen_general_hc(int.Parse(idExamen));
                if (dtExamen.Rows.Count>0)
                {
                    ucbExamen.Value = int.Parse(dtExamen.Rows[0][1].ToString()); 
                    cmbPaciente.Value = int.Parse(dtExamen.Rows[0][2].ToString());
                    cmbDoctor.Value = int.Parse(dtExamen.Rows[0][3].ToString()); 
                    txtObservacion.Text  =  dtExamen.Rows[0][4].ToString();
                    costoServicio = decimal.Parse(dtExamen.Rows[0][5].ToString());
                    dtFechaAtencion.Value = DateTime.Parse(dtExamen.Rows[0][6].ToString());
                }
            }
            catch (Exception)  {     }
        }

        private void LoadPaciente()
        {
            try
            {

                cmbPaciente.DataSource = NPaciente.lista_combo();
                cmbPaciente.ValueMember = "Id";
                cmbPaciente.DisplayMember = "Cliente";

                if (idPaciente != "0" && idPaciente.Length > 0)
                {
                    cmbPaciente.Value = idPaciente;
                    ///cmbPaciente.Enabled = false;
                    ///btnRefrescarPresentacionCompra.Enabled = false;
                    ////button3.Enabled = false;
                }
                else
                {
                    this.cmbPaciente.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }
        private void LoadExamen(int idTipo)
        {
            try
            {
                ucbExamen.DataSource = NCatalogo.cargar_cmb_by_tipo(idTipo);
                ucbExamen.ValueMember = "Id";
                ucbExamen.DisplayMember = "Descripcion";
            }
            catch (Exception) { }
        }
        private void LoadDoctor()
        {
            try
            {
                cmbDoctor.DataSource = NEspecialista.lista_combo();
                cmbDoctor.ValueMember = "Id";
                cmbDoctor.DisplayMember = "Doctor";
            }
            catch (Exception) { }
        }
        private void LoadCatalogoById(UltraComboEditor combo, int id)
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
        private void btnAgregarPadecimiento_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                Catalogos.frmCatalogo.me.txtBuscar.Text = "*";
                ////frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            if (txtObservacion.Text.Length <= 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Ingrese la observación del exámen.", this.txtObservacion, 0, 38, 3000);
                this.txtObservacion.Focus();
                return;
            }
        }

        private void CargarArchivos()
        {
            try
            {
                if (nuevo_examen)
                {
                    int.Parse(cmbPaciente.Value.ToString());
                    bsArchivo.DataSource = NExamenFormularioPaciente.cargar_archivo_examen_general_temp(int.Parse(cmbPaciente.Value.ToString()),cGeneral.name_user);
                    bnArchivo.BindingSource = bsArchivo;
                    this.ugvArchivoExamen.DataSource = bsArchivo;
                }
                else
                {
                    try
                    {
                        if (txtID.Text.Length>0)
                        {
                            bsArchivo.DataSource = NExamenFormularioPaciente.cargar_archivo_examen_general(int.Parse(txtID.Text.ToString()));
                            bnArchivo.BindingSource = bsArchivo;
                            this.ugvArchivoExamen.DataSource = bsArchivo;
                        } 
                    }
                    catch (Exception)   {   }
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe id del paciente para cargar los archivos adjuntos", "No existe ID del paciente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButton25_Click(object sender, EventArgs e)
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

        private void btnImprimirPresuntivo_Click(object sender, EventArgs e)
        {
            try
            {

                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenFormulario");
               /// ///rmReporte.idExamenFormulario = idFormulario;
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVerRecetas_Click(object sender, EventArgs e)
        {
            try
            {

                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenFormularioReceta");
                ///frmReporte.idExamenFormulario = idFormulario;
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
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
                    MessageBox.Show("Porfavor seleccione un archivo.", "Seleccionar archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            VerArchivo();
        }
        private void VerArchivo()
        {
            try
            {
                if (ugvArchivoExamen.Rows.Count > 0)
                {
                    int idFile = Convert.ToInt32(this.ugvArchivoExamen.ActiveRow.Cells[0].Value);
                    string nameFile = this.ugvArchivoExamen.ActiveRow.Cells[1].Value.ToString();
                    string extFile = this.ugvArchivoExamen.ActiveRow.Cells[2].Value.ToString();
                    if (nuevo_examen)
                    {
                        byte[] dataFile = NExamenFormularioPaciente.get_file_item_examen_general(idFile,true);

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
                    else if (txtID.Text.Length>0)
                    {
                        byte[] dataFile = NExamenFormularioPaciente.get_file_item_examen_general(idFile,false);

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
            VerArchivo();
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
                            ///CargarArchivosMaternal();
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
        private void btnNuevoDocumento_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("Porfavor seleccione un archivo.", "Seleccionar archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadExamen(9);
        }

        private void btnRefrescarPresentacionCompra_Click(object sender, EventArgs e)
        {
            LoadPaciente();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadDoctor();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmEspecialista_Acciones frm = new CentroMedico.frmEspecialista_Acciones();
                frm.userExterno = true;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Farmacia.frmPaciente_Acciones frm = new Farmacia.frmPaciente_Acciones();
                frm.Text = "AGREGAR PACIENTE";
                frm.accion = false;
                frm.nuevo_cliente = true;
                frm.externalUse = true;

                frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                ///frm.mtxtRUC.Mask = cGeneral.formato_cedula;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;
                frm.mtxtConvencional.Mask = cGeneral.formato_telefono;

                /*Se carga catalogo de tipo sangre*/
                frm.cmbTipoSangre.DataSource = NCatalogo.obtener_datos_by_tipe(1);
                frm.cmbTipoSangre.ValueMember = "Id";
                frm.cmbTipoSangre.DisplayMember = "Descripcion";

                /*Se carga estado civil*/
                frm.cmbEstadoCivil.DataSource = NCatalogo.obtener_datos_by_tipe(2);
                frm.cmbEstadoCivil.ValueMember = "Id";
                frm.cmbEstadoCivil.DisplayMember = "Descripcion";

                /*Se carga nacionalidad*/
                frm.cmbNacionalidad.DataSource = NCatalogo.obtener_datos_by_tipe(3);
                frm.cmbNacionalidad.ValueMember = "Id";
                frm.cmbNacionalidad.DisplayMember = "Descripcion";

                /*Se carga instrucciones*/
                frm.cmbInstruccion.DataSource = NCatalogo.obtener_datos_by_tipe(4);
                frm.cmbInstruccion.ValueMember = "Id";
                frm.cmbInstruccion.DisplayMember = "Descripcion";

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (nuevo_examen)
            { 
                int idExamenResult = NExamenFormularioPaciente.agregar_examen_general_hc(int.Parse(ucbExamen.Value.ToString()), int.Parse(cmbPaciente.Value.ToString()), int.Parse(cmbDoctor.Value.ToString()),txtObservacion.Text, costoServicio, Convert.ToDateTime(dtFechaAtencion.Value), cGeneral.name_user);
                if (idExamenResult > 0)
                {
                    tHora.Enabled = false;
                    MessageBox.Show(ucbExamen.Text +" agregado con éxito!", "Exámen HC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    idExamen = idExamenResult.ToString(); 
                    nuevo_examen = false;
                    btnAgregar.Enabled = true;
                    txtID.Text = idExamen; 
                    btnAgregar.Text = "GUARDAR";
                    btnCancelar.Text = "SALIR";
                    btnImprimir.Enabled = true;
                    btnImprimir.BackColor = Color.Black;
                    CargarArchivos();

                   /// this.Close();
                }
            }
            else
            {
                bool idExamenResult = NExamenFormularioPaciente.modificar_examen_general_hc( int.Parse(txtID.Text.ToString()), int.Parse(ucbExamen.Value.ToString()), int.Parse(cmbPaciente.Value.ToString()), int.Parse(cmbDoctor.Value.ToString()), txtObservacion.Text, costoServicio, Convert.ToDateTime(dtFechaAtencion.Value));
                if (idExamenResult)
                {
                    tHora.Enabled = false;
                    MessageBox.Show(ucbExamen.Text + " modificado con éxito!", "Exámen HC", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    nuevo_examen = false;
                    btnAgregar.Enabled = true;
                    txtID.Text = idExamen;
                    btnAgregar.Text = "GUARDAR";
                    btnCancelar.Text = "SALIR";
                    CargarArchivos();

                    /// this.Close();
                }
            }
        }
        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHitoriaClinica_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarArchivo_Click(object sender, EventArgs e)
        {
            if (txtFile.Text.Length <= 0)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No ha seleccionado el archivo para soportar este exámen.", this.btnAgregarExamenFile, 0, 38, 3000);
                this.txtFile.Focus();
                return;
            }
            ////Paciente
            try
            {
                if ((this.cmbPaciente.Value.ToString() == "" && this.cmbPaciente.Text == "") || (this.cmbPaciente.Value == null))
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el paciente.", this.btnAgregarArchivo, 0, 38, 3000);
                    this.cmbPaciente.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("Seleccione el paciente.", this.btnAgregarArchivo, 0, 38, 3000);
                this.cmbPaciente.Focus();
                return;
            }

            if (nuevo_examen)
            {
                var bytesFile = File.ReadAllBytes(openFileDialog1.FileName);
                var flag = NExamenFormularioPaciente.AgregarExamenFileGeneralHCTmp(int.Parse(cmbPaciente.Value.ToString()), bytesFile, Path.GetFileName(openFileDialog1.FileName), Path.GetExtension(openFileDialog1.FileName), cGeneral.name_user);
                MessageBox.Show("Archivo agregado con éxito!", "Exámenes Generales (HC)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFile.Text = "";
            }
            else if (txtID.Text.Length>0)
            {  
                var bytesFile = File.ReadAllBytes(openFileDialog1.FileName);
                var flag = NExamenFormularioPaciente.AgregarExamenFileGeneralHC(int.Parse(txtID.Text.ToString()), bytesFile, Path.GetFileName(openFileDialog1.FileName), Path.GetExtension(openFileDialog1.FileName));
                MessageBox.Show("Archivo agregado con éxito!", "Exámenes Generales (HC)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFile.Text = "";
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No hay un ID exámen para agregar el archivo (documento).", this.btnAgregarExamenFile, 0, 38, 3000);
                this.txtFile.Focus();
                return;
            }
            
            CargarArchivos();

        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            CargarArchivos();
        }

        private void ugvArchivoExamen_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].Width = 50;
            e.Layout.Bands[0].Columns[1].Width = 350;
            e.Layout.Bands[0].Columns[2].Width = 200;
            e.Layout.Bands[0].Columns[3].Width = 100; 

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

        private void toolStripButton18_Click_1(object sender, EventArgs e)
        {
            VerArchivo();
        }

        private void ugvArchivoExamen_DoubleClick_1(object sender, EventArgs e)
        {
            VerArchivo();
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ugvArchivoExamen.Rows.Count > 0)
                {
                    int idFile = Convert.ToInt32(this.ugvArchivoExamen.ActiveRow.Cells[0].Value);
                    DialogResult resul1 = MessageBox.Show("¿Está seguro que desea eliminar este archivo?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resul1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (nuevo_examen)
                        {
                            if (NExamenFormularioPaciente.eliminar_archivo_examen_general_hc(idFile,true))
                            {
                                MessageBox.Show("Archivo eliminado con éxito!", "Eliminar archivo adjunto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarArchivos();
                            }
                        }
                        else
                        {
                            if (NExamenFormularioPaciente.eliminar_archivo_examen_general_hc(idFile,false))
                            {
                                MessageBox.Show("Archivo eliminado con éxito!", "Eliminar archivo adjunto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarArchivos();
                            }
                        }
                    }
                }
                else
                {
                    this.ttMensaje.Show("No hay archivos adjuntos para ELIMINAR. Ingresar al menos una archivo poder eliminar.", this.ugvArchivoExamen, 0, 38, 3000); 
                }
            }
            catch (Exception)
            {
                this.ttMensaje.Show("No hay archivos adjuntos para ELIMINAR. Ingresar al menos una archivo poder eliminar.", this.ugvArchivoExamen, 0, 38, 3000);  
            }
        }

        private void ucbExamen_ValueChanged(object sender, EventArgs e)
        {
            if (ucbExamen.Text.Contains("CERTIFICADO"))
            {
                lblObservacion.Text = "CERTIFICO";
            }
            else
            {
                lblObservacion.Text = "OBSERVACIONES";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenGeneralHC");
                frmReporte.idExamen = txtID.Text;
                frmReporte.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbPaciente_ValueChanged(object sender, EventArgs e)
        {
            loadfoto();
        }

        private void btnAgregarExamenFile_Click(object sender, EventArgs e)
        {

        }
    }
}