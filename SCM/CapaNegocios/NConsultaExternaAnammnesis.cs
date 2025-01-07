using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NConsultaExternaAnammnesis
    {
        public static bool guardar(string IdPaciente, DateTime FechaAtencion, DateTime Hora, string HitoriaClinica, string txtMotivoConsultaA, string txtMotivoConsultaB, string txtMotivoConsultaC, string txtMotivoConsultaD, string txtAntecedentesPersonalesA, string txtAntecedentesPersonalesB, string txtAntecedentesPersonalesC, string txtAntecedentesPersonalesD, string txtAntecedentesFamiliaresA, string txtAntecedentesFamiliaresB, string txtAntecedentesFamiliaresC, string txtAntecedentesFamiliaresD, string txtEnfermedadProblemaActualA, string txtEnfermedadProblemaActualB, string txtEnfermedadProblemaActualC, string txtEnfermedadProblemaActualD, string txtRevisionOrganoSistemaA, string txtRevisionOrganoSistemaB, string txtRevisionOrganoSistemaC, string txtRevisionOrganoSistemaD, string txtSignoVitalMedicionTemporalBucal, string txtSignoVitalMedicionTemporalAuxiliar, string txtSignoVitalMedicionFrecuenciaRespitatoria, string txtSignoVitalMedicionCircunferenciaCuello, string txtSignoVitalMedicionPeso, string txtSignoVitalMedicionTalla, string txtSignoVitalMedicionPerimetroCintura, string txtSignoVitalMedicionPerimetroCadera, string txtSignoVitalMedicionPerimetroCefalico, string txtExamenFisicoA, string txtExamenFisicoB, string txtExamenFisicoC, string txtExamenFisicoD, string txtDiagnosticoPresuntivoDiagnostico, string txtDiagnosticoPresuntivoCIE, string txtTratamientoPresuntivoA, string txtTratamientoPresuntivoB, DateTime dtFechaEvolucionMedicamentoA, DateTime dtFechaEvolucionMedicamentoB, string txtPrescipcion1, string txtPrescipcion2, string txtPrescipcion3, string txtPrescipcion4, string txtPrescipcion5, string txtPrescipcion6, string txtDiagnosticoDefinitivoDiagnostico, string txtDiagnosticoDefinitivoCIE, string txtTratamientoDefinitivo)
        {
            return new DConsultaExternaAnammnesis().guardar(IdPaciente,FechaAtencion, Hora, HitoriaClinica, txtMotivoConsultaA, txtMotivoConsultaB, txtMotivoConsultaC, txtMotivoConsultaD, txtAntecedentesPersonalesA, txtAntecedentesPersonalesB, txtAntecedentesPersonalesC, txtAntecedentesPersonalesD, txtAntecedentesFamiliaresA, txtAntecedentesFamiliaresB, txtAntecedentesFamiliaresC, txtAntecedentesFamiliaresD, txtEnfermedadProblemaActualA, txtEnfermedadProblemaActualB, txtEnfermedadProblemaActualC, txtEnfermedadProblemaActualD, txtRevisionOrganoSistemaA, txtRevisionOrganoSistemaB, txtRevisionOrganoSistemaC, txtRevisionOrganoSistemaD, txtSignoVitalMedicionTemporalBucal, txtSignoVitalMedicionTemporalAuxiliar, txtSignoVitalMedicionFrecuenciaRespitatoria, txtSignoVitalMedicionCircunferenciaCuello, txtSignoVitalMedicionPeso, txtSignoVitalMedicionTalla, txtSignoVitalMedicionPerimetroCintura, txtSignoVitalMedicionPerimetroCadera, txtSignoVitalMedicionPerimetroCefalico, txtExamenFisicoA, txtExamenFisicoB, txtExamenFisicoC, txtExamenFisicoD, txtDiagnosticoPresuntivoDiagnostico, txtDiagnosticoPresuntivoCIE, txtTratamientoPresuntivoA, txtTratamientoPresuntivoB, dtFechaEvolucionMedicamentoA, dtFechaEvolucionMedicamentoB, txtPrescipcion1, txtPrescipcion2, txtPrescipcion3, txtPrescipcion4, txtPrescipcion5, txtPrescipcion6, txtDiagnosticoDefinitivoDiagnostico, txtDiagnosticoDefinitivoCIE, txtTratamientoDefinitivo);
        }
        public static DataTable get_consulta_externa_by_paciente(string idPaciente)
        {
            return new DConsultaExternaAnammnesis().get_consulta_externa_by_paciente(idPaciente);
        }
    }
}
