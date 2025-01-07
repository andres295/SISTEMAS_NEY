using CapaNegocios;
using SCM.Globales;
using System; 
using System.Data; 
using System.Windows.Forms;

namespace SCM.Oftamologia
{
    public partial class frmAtencionInmediataOfatamologia : Form
    {
        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public string id_cita = "", hora_cita = "";
        public DateTime dia_cita;
        public int id_servicio = 0,id_doctor = 0;
        public string esta_atendida = ""; 
        public string idPaciente ="";
        public frmAtencionInmediataOfatamologia()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar); 
                int id_paciente = get_id_paciente();

                ////Paciente
                try
                {
                    if ((this.cmbPaciente.Value.ToString() == "" && this.cmbPaciente.Text == "") || (this.cmbPaciente.Value == null))
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Seleccione el paciente.", this.btnGuardar, 0, 38, 3000);
                        this.cmbPaciente.Focus();
                        return;
                    }
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el paciente.", this.btnGuardar, 0, 38, 3000);
                    this.cmbPaciente.Focus();
                    return;
                }
                 
                ///Paciente
                if (id_paciente == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el paciente.", this.btnGuardar, 0, 38, 3000);
                    this.cmbPaciente.Focus();
                    return;
                }
                
                if (this.udDia.Value.ToString() == "" && this.udDia.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el día de la cita.", this.btnGuardar, 0, 38, 3000);
                    this.udDia.Focus();
                    return;
                }
                if (this.udDia.Value.ToString() == "" && this.udDia.Text == "")
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese el día de la cita.", this.btnGuardar, 0, 38, 3000);
                    this.udDia.Focus();
                    return;
                }
                try
                {
                    if ((this.cmbDoctor.Value.ToString() == "" && this.cmbDoctor.Text == "") || (this.cmbDoctor.Value == null))
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Seleccione el especialista.", this.btnGuardar, 0, 38, 3000);
                        this.cmbDoctor.Focus();
                        return;
                    }
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el especialista.", this.btnGuardar, 0, 38, 3000);
                    this.cmbDoctor.Focus();
                    return;
                }
                //if (Convert.ToDateTime(udDia.Value) < Convert.ToDateTime(DateTime.Now.Date))
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Ingrese la fecha mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                //    this.udDia.Focus();
                //    return;
                //}
                //if (txtDescripcion.Text.Length <=0)
                //{
                //    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                //    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                //    this.ttMensaje.Show("Ingrese la razón de su visita", this.btnGuardar, 0, 38, 3000);
                //    this.txtDescripcion.Focus();
                //    return;
                //}
                if (this.accion == false)
                {
                    string idPaciente = "", nombrePaciente = "";
                    int idCita = NCita.guardar(id_paciente.ToString(), cmbDoctor.Value.ToString(), null, Convert.ToDateTime(udDia.Value), System.DateTime.Now, System.DateTime.Now, "ATENCIÓN INMEDIATA", true);
                    if (idCita > 0)
                    {
                        int idExamenFormularioNew = NExamenFormularioPaciente.guardar_diagnostico_fianl(idCita.ToString(), id_paciente.ToString(), Convert.ToDateTime(udDia.Value), System.DateTime.Now, Globales.cGeneral.name_user);
                        if (idExamenFormularioNew > 0)
                        {
                            MessageBox.Show("Cita Médica registrada con éxito!", "Registro de atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            idPaciente = id_paciente.ToString();
                            nombrePaciente = cmbPaciente.Text;
                            this.Close();
                            LoadFormConsultaExterna(idExamenFormularioNew, idPaciente, nombrePaciente, idCita);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No fue posible agendar la cita. Favor contactar con el administrador del sistema", "Error al agendar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //else
                //{
                //    string idPaciente = "", nombrePaciente = "";
                //    NCita.modificar(id_cita, null, null, txtDescripcion.Text, Convert.ToDateTime(udDia.Value), System.DateTime.Now, System.DateTime.Now, true);
                //    MessageBox.Show("Atención inmediata registrada con éxito!", "Registro de atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    idPaciente = id_paciente.ToString();
                //    nombrePaciente = cmbPaciente.Text;
                //    this.Close();
                //    LoadFormConsultaExterna( idPaciente, nombrePaciente, int.Parse(id_cita));
                //}
            }
            catch (Exception ex)
            {
                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show(ex.Message.ToString (), this.btnGuardar, 0, 38, 3000); 
            }
        }
        private void LoadFormConsultaExterna(int idExamenFormulario, string idPaciente, string nombrePaciente, int idCita)
        {
            try
            {
                string generoPaciente = get_genero_paciente(idPaciente);
                if (generoPaciente == "FEMENINO")
                {
                    Consultas.frmEstadoConsultaExterna frmConsulta = new Consultas.frmEstadoConsultaExterna();
                    frmConsulta.idPaciente = idPaciente;
                    frmConsulta.idExamenFormulario = idExamenFormulario.ToString();
                    frmConsulta.NombrePaciente = nombrePaciente;
                    frmConsulta.nuevo_expediente = false;
                    frmConsulta.idCita = idCita;
                    frmConsulta.FechaAtencion = udDia.Value.ToString();
                    frmConsulta.Hora = System.DateTime.Now.ToString();
                    frmConsulta.estadoExamen = true;
                    frmConsulta.ShowDialog();
                }
                else
                {
                    Consultas.frmConsultaFormularios frmConsulta = new Consultas.frmConsultaFormularios();
                    frmConsulta.idPaciente = idPaciente;
                    frmConsulta.idFormulario = idExamenFormulario.ToString();
                    frmConsulta.NombrePaciente = nombrePaciente;
                    frmConsulta.nuevo_expediente = false;
                    frmConsulta.idCita = idCita;
                    frmConsulta.btnImprimirPresuntivo.Enabled = true;
                    frmConsulta.btnVerRecetas.Enabled = true;
                    frmConsulta.tsEditar.Enabled = true;
                    frmConsulta.btnGuardar.Text = "GUARDAR";
                    frmConsulta.btnEliminar.Visible = true;
                    frmConsulta.dtFechaAtencion.Value = DateTime.Parse(udDia.Value.ToString());
                    frmConsulta.udHoraAtencion.Value = System.DateTime.Now;
                    frmConsulta.estadoExamen = true;
                    frmConsulta.ShowDialog();
                }

            }
            catch (Exception ex) { }
        }
        private int get_id_paciente()
        {
            int id_paciente= 0;
            try
            {
                if (!cbFiltroCedula.Checked)
                {
                    try
                    {
                        id_paciente = int.Parse(cmbPaciente.Text);
                    }
                    catch (Exception)
                    {

                        id_paciente = NPaciente.paciente_by_name(cmbPaciente.Text);
                    }
                }
                else
                {
                    id_paciente = NPaciente.paciente_by_cedula(cmbPaciente.Value.ToString());
                }

            }
            catch (Exception)
            {
                id_paciente = 0;
            }
            return id_paciente;
        }
        private string get_genero_paciente(string idpaciente)
        {
            string generoPaciente = "";
            try
            {
                generoPaciente = NPaciente.get_genero_paciente(idpaciente);
            }
            catch (Exception)
            {
                generoPaciente = "N/A";
            }
           
            return generoPaciente; 
        }
        private void frmCitaCliente_Load(object sender, EventArgs e)
        {
            CargarPaciente();
            udDia.Value = System.DateTime.Now;
            cmbDoctor.DataSource = NEspecialista.lista_combo();
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Doctor";

            this.cmbPaciente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest; 
            this.cmbDoctor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
        }

        private void CargarPaciente()
        {
            try
            {
                if (cbFiltroCedula.Checked)
                {
                    cmbPaciente.DataSource = NPaciente.lista_combo();
                    cmbPaciente.ValueMember = "Cedula";
                    cmbPaciente.DisplayMember = "NombreCedula";
                }
                else
                {
                    cmbPaciente.DataSource = NPaciente.lista_combo();
                    cmbPaciente.ValueMember = "Id";
                    cmbPaciente.DisplayMember = "Cliente";
                }
               

                if (idPaciente.Length > 0)
                {
                    cmbPaciente.Value = idPaciente;
                    cmbPaciente.Enabled = false;
                    btnRefrescarPresentacionCompra.Enabled = false;
                    button3.Enabled = false;
                }
                this.cmbPaciente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception)  {    }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ///txtDescripcion.Text.ToUpper();
        }
        private double obtener_Hora_servicio (string id_servicio)
        {
            try
            {
                DataTable dtServ =  NServicio.lista_tiempo_servicio(id_servicio);
                double tiempo_servicio = 0;
                if (dtServ.Rows.Count>0)
                {
                    tiempo_servicio = double.Parse(dtServ.Rows[0]["Tiempo_Ejecucion"].ToString());
                }
                return tiempo_servicio;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void cbAtendida_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(id_cita) > 0)
                {
                    NCita.modificar_cita_atendida(id_cita, true);
                    MessageBox.Show("Cita esta atendida con éxito!", "Registro de cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) {}
        }

        private void btnRefrescarPresentacionCompra_Click(object sender, EventArgs e)
        {
            cmbPaciente.DataSource = NPaciente.lista_combo();
            cmbPaciente.ValueMember = "Id";
            cmbPaciente.DisplayMember = "Cliente";
        }
          
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               Farmacia.frmPaciente_Acciones   frm = new Farmacia.frmPaciente_Acciones();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Servicios.frmServicio_Acciones frm = new Servicios.frmServicio_Acciones();
            //    frm.userExterno = true;
            //    frm.ShowDialog();
            //}
            //catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbPaciente_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbDoctor.DataSource = NEspecialista.lista_combo();
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Doctor";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmEspecialista_Acciones frm = new CentroMedico.frmEspecialista_Acciones();
                frm.userExterno = true;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cbFiltroCedula_CheckedChanged(object sender, EventArgs e)
        {
            CargarPaciente();
        } 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
