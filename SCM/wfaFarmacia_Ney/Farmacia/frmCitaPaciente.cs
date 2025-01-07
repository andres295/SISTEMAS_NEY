using CapaNegocios;
using SCM.Globales;
using System; 
using System.Data; 
using System.Windows.Forms;

namespace SCM.Farmacia
{
    public partial class frmCitaPaciente : Form
    {
        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public string id_cita = "", hora_cita = "";
        public DateTime dia_cita;
        public int id_servicio = 0,id_doctor = 0;
        public string esta_atendida = "";
        private bool validaCambioCita = false;
        public string idPaciente ="";
        public frmCitaPaciente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.btnGuardar);
                int id_serv = get_id_servicio();
                int id_doctor = get_id_doctor();
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
                ////Doctor
                try
                {
                    if ((this.cmbDoctor.Value.ToString() == "" && this.cmbDoctor.Text == "") || (this.cmbDoctor.Value == null))
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Seleccione el doctor.", this.btnGuardar, 0, 38, 3000);
                        this.cmbDoctor.Focus();
                        return;
                    }
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el doctor.", this.btnGuardar, 0, 38, 3000);
                    this.cmbDoctor.Focus();
                    return;
                }
                ///Servicio
                try
                {
                    if ((this.cmbServicio.Value.ToString() == "" && this.cmbServicio.Text == "") || (this.cmbServicio.Value == null))
                    {
                        this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                        this.ttMensaje.Show("Seleccione el servicio.", this.btnGuardar, 0, 38, 3000);
                        this.cmbServicio.Focus();
                        return;
                    }
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el servicio.", this.btnGuardar, 0, 38, 3000);
                    this.cmbServicio.Focus();
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
                ///Doctor
                if (id_doctor == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el doctor.", this.btnGuardar, 0, 38, 3000);
                    this.cmbDoctor.Focus();
                    return;
                }
                if (accion && id_doctor == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el doctor.", this.btnGuardar, 0, 38, 3000);
                    this.cmbDoctor.Focus();
                    return;
                }
                ////Servicio
                if (id_serv == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el servicio.", this.btnGuardar, 0, 38, 3000);
                    this.cmbServicio.Focus();
                    return;
                }
                if (accion && id_servicio == 0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Seleccione el servicio.", this.btnGuardar, 0, 38, 3000);
                    this.cmbServicio.Focus();
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
                if (Convert.ToDateTime(udDia.Value) < Convert.ToDateTime(DateTime.Now.Date))
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la fecha mayor a la fecha actual", this.btnGuardar, 0, 38, 3000);
                    this.udDia.Focus();
                    return;
                }
                if (txtDescripcion.Text.Length <=0)
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("Ingrese la razón de su visita", this.btnGuardar, 0, 38, 3000);
                    this.txtDescripcion.Focus();
                    return;
                }
                if (this.accion == false)
                {
                    string hora_string = "";
                    ///DataTable dtCita = NCita.valida_cita(Convert.ToDateTime(udDia.Value), Convert.ToDateTime(udHora.Value), Convert.ToDateTime(udHora.Value).AddMinutes(obtener_Hora_servicio(cmbServicio.Value.ToString())), cmbDoctor.Value.ToString());
                    ///if (dtCita.Rows.Count <= 0)
                    ///{
                        NCita.guardar(cmbPaciente.Value.ToString(), cmbDoctor.Value.ToString(), cmbServicio.Value.ToString(), Convert.ToDateTime(udDia.Value), Convert.ToDateTime(udHora.Value), Convert.ToDateTime(udHora.Value).AddMinutes(obtener_Hora_servicio(cmbServicio.Value.ToString())), txtDescripcion.Text,false);
                        MessageBox.Show("Cita registrada con éxito!", "Registro de cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    //}
                    //else
                    //{
                    //    string nombre = "", hora_inicio = ""; string hora_fin = "";
                    //    nombre = dtCita.Rows[0]["Cliente"].ToString();
                    //    hora_inicio = dtCita.Rows[0]["Hora"].ToString();
                    //    hora_fin = dtCita.Rows[0]["Hora_Fin"].ToString();

                    //    MessageBox.Show("Ya se encuentra una cita programada en la hora indicada para el paciente: " + nombre + " de: " + hora_inicio + " a: " + hora_fin, "Registro de cita programada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    udHora.Focus();
                    //}
                }
                else
                {
                   ///  string hora_string = "";
                   /// DataTable dtCita = new DataTable();
                   /// validaCambioCita = validaDatosCita();

                    //if (validaCambioCita)
                    //{ 
                     ////DataTable dtCita   = NCita.valida_cita(Convert.ToDateTime(udDia.Value), Convert.ToDateTime(udHora.Value), Convert.ToDateTime(udHora.Value).AddMinutes(obtener_Hora_servicio(cmbServicio.Value.ToString())), cmbDoctor.Value.ToString());
                    //}
                    //if (validaCambioCita)
                    //{
                        //if (dtCita.Rows.Count <= 0)
                        //{
                            NCita.modificar(id_cita, cmbDoctor.Value.ToString(), cmbServicio.Value.ToString(), txtDescripcion.Text, Convert.ToDateTime(udDia.Value), Convert.ToDateTime(udHora.Value), Convert.ToDateTime(udHora.Value).AddMinutes(obtener_Hora_servicio(cmbServicio.Value.ToString())), cbAtendida.Checked);
                            MessageBox.Show("Cita actualizada con éxito!", "Registro de cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        //}
                        //else
                        //{
                        //    string nombre = "", hora_inicio = ""; string hora_fin = "";
                        //    nombre = dtCita.Rows[0]["Cliente"].ToString();
                        //    hora_inicio = dtCita.Rows[0]["Hora"].ToString();
                        //    hora_fin = dtCita.Rows[0]["Hora_Fin"].ToString();

                        //    MessageBox.Show("Ya se encuentra una cita programada en la hora indicada para el paciente: " + nombre + " de: " + hora_inicio + " a: " + hora_fin, "Registro de cita programada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    udHora.Focus();
                        //}
                    //}
                    //else
                    //{
                    //    NCita.modificar(id_cita, cmbDoctor.Value.ToString(), cmbServicio.Value.ToString(), txtDescripcion.Text, Convert.ToDateTime(udDia.Value), Convert.ToDateTime(udHora.Value), Convert.ToDateTime(udHora.Value).AddMinutes(obtener_Hora_servicio(cmbServicio.Value.ToString())), cbAtendida.Checked);
                    //    MessageBox.Show("Cita actualizada con éxito!", "Registro de cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.Close();
                    //}
                   
                }
            }
            catch (Exception ex)
            {
                this.ttMensaje.ToolTipTitle = "ERROR";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show(ex.Message.ToString (), this.btnGuardar, 0, 38, 3000); 
            }
        }
        /// <summary>
        /// Descripción: Validar cita
        /// </summary>
        /// <returns></returns>
        private bool validaDatosCita ()
        {
            try
            {
                string shora_cambiada = Convert.ToDateTime(udHora.Value).ToString("HH:mm:ss");
          
                if (id_doctor.ToString() != cmbDoctor.Value.ToString() || hora_cita != shora_cambiada ||  dia_cita != Convert.ToDateTime(udDia.Value))
                {
                    return true; 
                }
                else{
                    return false;
                } 
            }
            catch (Exception)
            {
                return false;
            }
        }
        private int get_id_servicio ()
        {
            int id_servicio = 0;
            try
            {
                try
                {
                    id_servicio = int.Parse(cmbServicio.Text);
                }
                catch (Exception)
                {

                    id_servicio = NServicio.servicio_by_name(cmbServicio.Text);
                }

            
            }
            catch (Exception)
            {
                id_servicio = 0;
            }
            return id_servicio;
        }
        private int get_id_doctor()
        {
            int id_doctor = 0;
            try
            {
                try
                {
                    id_doctor = int.Parse(cmbDoctor.Text);
                }
                catch (Exception)
                {

                    id_doctor = NEmpleados.emp_by_name(cmbDoctor.Text);
                }


            }
            catch (Exception)
            {
                id_doctor = 0;
            }
            return id_doctor;
        }
        private int get_id_paciente()
        {
            int id_paciente= 0;
            try
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
            catch (Exception)
            {
                id_paciente = 0;
            }
            return id_paciente;
        }
        private void frmCitaCliente_Load(object sender, EventArgs e)
        {
            //if (accion)
            //{
            //    if (esta_atendida == "Atendida")
            //    {
            //        cbAtendida.Checked = true;
            //    }
            //    else
            //    {
            //        cbAtendida.Checked = false;
            //    }
            //}

            cmbPaciente.DataSource = NClientes.lista_combo();
            cmbPaciente.ValueMember = "Id";
            cmbPaciente.DisplayMember = "Cliente";

            if (idPaciente.Length > 0)
            {
                cmbPaciente.Value = idPaciente;
                cmbPaciente.Enabled = false;
                btnRefrescarPresentacionCompra.Enabled = false;
                button3.Enabled = false;
            }

            cmbServicio.DataSource = NServicio.lista_combo_2();
            cmbServicio.ValueMember = "Id";
            cmbServicio.DisplayMember = "Servicio";

            cmbDoctor.DataSource = NEmpleados.lista_combo();
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Doctor";

            this.cmbPaciente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbServicio.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbDoctor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
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
                    NCita.modificar_cita_atendida(id_cita, cbAtendida.Checked);
                    MessageBox.Show("Cita esta atendida con éxito!", "Registro de cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) {}
        }

        private void btnRefrescarPresentacionCompra_Click(object sender, EventArgs e)
        {
            cmbPaciente.DataSource = NClientes.lista_combo();
            cmbPaciente.ValueMember = "Id";
            cmbPaciente.DisplayMember = "Cliente";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbDoctor.DataSource = NEmpleados.lista_combo();
            cmbDoctor.ValueMember = "Id";
            cmbDoctor.DisplayMember = "Doctor";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbServicio.DataSource = NServicio.lista_combo_2();
            cmbServicio.ValueMember = "Id";
            cmbServicio.DisplayMember = "Servicio";

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Empleados.frmEmpleados_Acciones frm = new Empleados.frmEmpleados_Acciones();
                frm.userExterno = true;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmServicio_Acciones frm = new CentroMedico.frmServicio_Acciones();
                frm.userExterno = true;
                frm.ShowDialog();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cmbServicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
