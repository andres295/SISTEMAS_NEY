using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SCM.Globales;

namespace SCM.Consultas
{
    public partial class frmEstadoConsultaExterna : Form
    {
        public string idPaciente, idExamenFormulario, nombrePaciente;
        public int idCita;
        public string NombrePaciente; 
        public string Hora, FechaAtencion;
        public bool nuevo_expediente, estadoExamen = false;

        public frmEstadoConsultaExterna()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbEstado.Text == "NORMAL")
            {
                Consultas.frmConsultaFormularios frmConsulta = new Consultas.frmConsultaFormularios();
                frmConsulta.idPaciente = idPaciente;
                frmConsulta.idFormulario = idExamenFormulario;
                frmConsulta.NombrePaciente = NombrePaciente;
                frmConsulta.nuevo_expediente = false;
                frmConsulta.idCita = idCita;
                frmConsulta.btnImprimirPresuntivo.Enabled = true;
                frmConsulta.btnVerRecetas.Enabled = true;
                frmConsulta.tsEditar.Enabled = true;
                frmConsulta.btnGuardar.Text = "GUARDAR";
                frmConsulta.btnEliminar.Visible = true;
                frmConsulta.dtFechaAtencion.Value = DateTime.Parse(FechaAtencion);
                frmConsulta.udHoraAtencion.Value = DateTime.Parse(Hora);
                frmConsulta.estadoExamen = true;
                frmConsulta.ShowDialog();
                this.Close();
            }
            else
            {
                Consultas.frmConsultaFormularios frmConsulta = new Consultas.frmConsultaFormularios();
                frmConsulta.idPaciente = idPaciente;
                frmConsulta.gestacion = true;
                frmConsulta.idFormulario = idExamenFormulario.ToString();
                frmConsulta.NombrePaciente = NombrePaciente;
                frmConsulta.nuevo_expediente = false;
                frmConsulta.idCita = idCita;
                frmConsulta.btnImprimirPresuntivo.Enabled = true;
                frmConsulta.btnVerRecetas.Enabled = true;
                frmConsulta.tsEditar.Enabled = true;
                frmConsulta.btnGuardar.Text = "GUARDAR";
                frmConsulta.btnEliminar.Visible = true;
                frmConsulta.dtFechaAtencion.Value = DateTime.Parse(FechaAtencion);
                frmConsulta.udHoraAtencion.Value = DateTime.Parse(Hora);
                frmConsulta.estadoExamen = true;
                frmConsulta.ShowDialog();
                this.Close();
            }

        }

        private void frmEstadoConsultaExterna_Load(object sender, EventArgs e)
        {
            cmbEstado.Text = "NORMAL";
        }
    }
}
