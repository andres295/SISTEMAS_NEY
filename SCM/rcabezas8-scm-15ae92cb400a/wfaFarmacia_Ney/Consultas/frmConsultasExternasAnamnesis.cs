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

namespace SCM.Consultas
{
    public partial class frmConsultasExternasAnamnesis : Form
    {
        string vCedula = "";
        string vRuc = "";
        public string idPaciente;
        public string NombrePaciente;

        public frmConsultasExternasAnamnesis(string cedulaActual = "", string rucActual = "")
        {
            InitializeComponent(); 
        }

        public bool accion; //AGREGAR = FALSE; MODIFICAR = TRUE
        public bool nuevo_cliente = false;
        public bool externalUse = false;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultasExternasAnamnesis_Load(object sender, EventArgs e)
        {
            txtMotivoConsultaA.Focus();
            lblNombreCliente.Text = idPaciente + " - " + NombrePaciente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (NConsultaExternaAnammnesis.guardar(idPaciente, Convert.ToDateTime(dtFechaAtencion.Value), Convert.ToDateTime(udHoraAtencion.Value), txtHitoriaClinica.Text, txtMotivoConsultaA.Text, txtMotivoConsultaB.Text, txtMotivoConsultaC.Text, txtMotivoConsultaD.Text, txtAntecedentesPersonalesA.Text, txtAntecedentesPersonalesB.Text, txtAntecedentesPersonalesC.Text, txtAntecedentesPersonalesD.Text, txtAntecedentesFamiliaresA.Text, txtAntecedentesFamiliaresB.Text, txtAntecedentesFamiliaresC.Text, txtAntecedentesFamiliaresD.Text, txtEnfermedadProblemaActualA.Text, txtEnfermedadProblemaActualB.Text, txtEnfermedadProblemaActualC.Text, txtEnfermedadProblemaActualD.Text, txtRevisionOrganoSistemaA.Text, txtRevisionOrganoSistemaB.Text, txtRevisionOrganoSistemaC.Text, txtRevisionOrganoSistemaD.Text, txtSignoVitalMedicionTemporalBucal.Text, txtSignoVitalMedicionTemporalAuxiliar.Text, txtSignoVitalMedicionFrecuenciaRespitatoria.Text, txtSignoVitalMedicionCircunferenciaCuello.Text, txtSignoVitalMedicionPeso.Text, txtSignoVitalMedicionTalla.Text, txtSignoVitalMedicionPerimetroCintura.Text, txtSignoVitalMedicionPerimetroCadera.Text, txtSignoVitalMedicionPerimetroCefalico.Text, txtExamenFisicoA.Text, txtExamenFisicoB.Text, txtExamenFisicoC.Text, txtExamenFisicoD.Text, txtDiagnosticoPresuntivoDiagnostico.Text, txtDiagnosticoPresuntivoCIE.Text, txtTratamientoPresuntivoA.Text, txtTratamientoPresuntivoB.Text, Convert.ToDateTime(dtFechaEvolucionMedicamentoA.Value), Convert.ToDateTime(dtFechaEvolucionMedicamentoB.Value), txtPrescipcion1.Text, txtPrescipcion2.Text, txtPrescipcion3.Text, txtPrescipcion4.Text, txtPrescipcion5.Text, txtPrescipcion6.Text, txtDiagnosticoDefinitivoDiagnostico.Text, txtDiagnosticoDefinitivoCIE.Text, txtTratamientoDefinitivo.Text))
            {
                MessageBox.Show("FORMULARIO CONSULTAS EXTERNA Y ANAMNESIS agregado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarDiagnostico_Click(object sender, EventArgs e)
        {
            if (NConsultaExternaAnammnesis.guardar(idPaciente, Convert.ToDateTime(dtFechaAtencion.Value), Convert.ToDateTime(udHoraAtencion.Value), txtHitoriaClinica.Text, txtMotivoConsultaA.Text, txtMotivoConsultaB.Text, txtMotivoConsultaC.Text, txtMotivoConsultaD.Text, txtAntecedentesPersonalesA.Text, txtAntecedentesPersonalesB.Text, txtAntecedentesPersonalesC.Text, txtAntecedentesPersonalesD.Text, txtAntecedentesFamiliaresA.Text, txtAntecedentesFamiliaresB.Text, txtAntecedentesFamiliaresC.Text, txtAntecedentesFamiliaresD.Text, txtEnfermedadProblemaActualA.Text, txtEnfermedadProblemaActualB.Text, txtEnfermedadProblemaActualC.Text, txtEnfermedadProblemaActualD.Text, txtRevisionOrganoSistemaA.Text, txtRevisionOrganoSistemaB.Text, txtRevisionOrganoSistemaC.Text, txtRevisionOrganoSistemaD.Text, txtSignoVitalMedicionTemporalBucal.Text, txtSignoVitalMedicionTemporalAuxiliar.Text, txtSignoVitalMedicionFrecuenciaRespitatoria.Text, txtSignoVitalMedicionCircunferenciaCuello.Text, txtSignoVitalMedicionPeso.Text, txtSignoVitalMedicionTalla.Text, txtSignoVitalMedicionPerimetroCintura.Text, txtSignoVitalMedicionPerimetroCadera.Text, txtSignoVitalMedicionPerimetroCefalico.Text, txtExamenFisicoA.Text, txtExamenFisicoB.Text, txtExamenFisicoC.Text, txtExamenFisicoD.Text, txtDiagnosticoPresuntivoDiagnostico.Text, txtDiagnosticoPresuntivoCIE.Text, txtTratamientoPresuntivoA.Text, txtTratamientoPresuntivoB.Text, Convert.ToDateTime(dtFechaEvolucionMedicamentoA.Value), Convert.ToDateTime(dtFechaEvolucionMedicamentoB.Value), txtPrescipcion1.Text, txtPrescipcion2.Text, txtPrescipcion3.Text, txtPrescipcion4.Text, txtPrescipcion5.Text, txtPrescipcion6.Text, txtDiagnosticoDefinitivoDiagnostico.Text, txtDiagnosticoDefinitivoCIE.Text, txtTratamientoDefinitivo.Text))
            {
                MessageBox.Show("FORMULARIO CONSULTAS EXTERNA Y ANAMNESIS agregado con éxito!", "Consulta Externa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
