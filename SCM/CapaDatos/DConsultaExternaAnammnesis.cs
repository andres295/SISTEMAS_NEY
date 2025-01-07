using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DConsultaExternaAnammnesis
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DConsultaExternaAnammnesis";
 
        public bool guardar(string IdPaciente, DateTime FechaAtencion ,  DateTime Hora ,string HitoriaClinica , string txtMotivoConsultaA, string txtMotivoConsultaB, string txtMotivoConsultaC, string txtMotivoConsultaD, string txtAntecedentesPersonalesA, string txtAntecedentesPersonalesB , string txtAntecedentesPersonalesC, string txtAntecedentesPersonalesD , string txtAntecedentesFamiliaresA, string txtAntecedentesFamiliaresB, string txtAntecedentesFamiliaresC, string txtAntecedentesFamiliaresD, string txtEnfermedadProblemaActualA, string txtEnfermedadProblemaActualB , string txtEnfermedadProblemaActualC, string txtEnfermedadProblemaActualD, string txtRevisionOrganoSistemaA, string txtRevisionOrganoSistemaB, string txtRevisionOrganoSistemaC, string txtRevisionOrganoSistemaD, string txtSignoVitalMedicionTemporalBucal, string txtSignoVitalMedicionTemporalAuxiliar, string txtSignoVitalMedicionFrecuenciaRespitatoria, string txtSignoVitalMedicionCircunferenciaCuello, string txtSignoVitalMedicionPeso, string txtSignoVitalMedicionTalla , string txtSignoVitalMedicionPerimetroCintura, string txtSignoVitalMedicionPerimetroCadera, string txtSignoVitalMedicionPerimetroCefalico, string txtExamenFisicoA, string txtExamenFisicoB, string txtExamenFisicoC, string txtExamenFisicoD, string txtDiagnosticoPresuntivoDiagnostico, string txtDiagnosticoPresuntivoCIE, string txtTratamientoPresuntivoA, string txtTratamientoPresuntivoB, DateTime dtFechaEvolucionMedicamentoA, DateTime dtFechaEvolucionMedicamentoB, string txtPrescipcion1, string txtPrescipcion2 , string txtPrescipcion3 , string txtPrescipcion4, string txtPrescipcion5, string txtPrescipcion6, string txtDiagnosticoDefinitivoDiagnostico, string txtDiagnosticoDefinitivoCIE, string txtTratamientoDefinitivo)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[CONSULTAS_EXTERNA_ANAMNESIS] ([IdPaciente],[FechaAtencion] ,[Hora] ,[HitoriaClinica] ,[txtMotivoConsultaA],[txtMotivoConsultaB],[txtMotivoConsultaC],[txtMotivoConsultaD],[txtAntecedentesPersonalesA],[txtAntecedentesPersonalesB] ,[txtAntecedentesPersonalesC],[txtAntecedentesPersonalesD] ,[txtAntecedentesFamiliaresA],[txtAntecedentesFamiliaresB],[txtAntecedentesFamiliaresC],[txtAntecedentesFamiliaresD],[txtEnfermedadProblemaActualA],[txtEnfermedadProblemaActualB] ,[txtEnfermedadProblemaActualC],[txtEnfermedadProblemaActualD],[txtRevisionOrganoSistemaA],[txtRevisionOrganoSistemaB],[txtRevisionOrganoSistemaC],[txtRevisionOrganoSistemaD],[txtSignoVitalMedicionTemporalBucal],[txtSignoVitalMedicionTemporalAuxiliar],[txtSignoVitalMedicionFrecuenciaRespitatoria],[txtSignoVitalMedicionCircunferenciaCuello],[txtSignoVitalMedicionPeso],[txtSignoVitalMedicionTalla] ,[txtSignoVitalMedicionPerimetroCintura],[txtSignoVitalMedicionPerimetroCadera],[txtSignoVitalMedicionPerimetroCefalico],[txtExamenFisicoA],[txtExamenFisicoB],[txtExamenFisicoC],[txtExamenFisicoD],[txtDiagnosticoPresuntivoDiagnostico],[txtDiagnosticoPresuntivoCIE],[txtTratamientoPresuntivoA],[txtTratamientoPresuntivoB],[dtFechaEvolucionMedicamentoA],[dtFechaEvolucionMedicamentoB],[txtPrescipcion1],[txtPrescipcion2] ,[txtPrescipcion3] ,[txtPrescipcion4],[txtPrescipcion5],[txtPrescipcion6],[txtDiagnosticoDefinitivoDiagnostico],[txtDiagnosticoDefinitivoCIE],[txtTratamientoDefinitivo]) VALUES('" + IdPaciente + "','" + FechaAtencion.ToString("yyyy-MM-dd") + "','" + Hora.ToString("yyyy-MM-dd HH:mm:ss") + "','" + HitoriaClinica + "','" + txtMotivoConsultaA + "', '" + txtMotivoConsultaB + "','" + txtMotivoConsultaC + "','" + txtMotivoConsultaD + "', '" + txtAntecedentesPersonalesA + "','" + txtAntecedentesPersonalesB + "','" + txtAntecedentesPersonalesC + "', '" + txtAntecedentesPersonalesD + "','" + txtAntecedentesFamiliaresA + "','" +  txtAntecedentesFamiliaresB + "', '" + txtAntecedentesFamiliaresC + "', '" + txtAntecedentesFamiliaresD + "', '" + txtEnfermedadProblemaActualA + "', '" + txtEnfermedadProblemaActualB + "','" + txtEnfermedadProblemaActualC + "','" +  txtEnfermedadProblemaActualD + "', '" + txtRevisionOrganoSistemaA + "','" + txtRevisionOrganoSistemaB + "','" +  txtRevisionOrganoSistemaC + "', '" + txtRevisionOrganoSistemaD + "','" + txtSignoVitalMedicionTemporalBucal + "','" +  txtSignoVitalMedicionTemporalAuxiliar + "', '" + txtSignoVitalMedicionFrecuenciaRespitatoria + "','" + txtSignoVitalMedicionCircunferenciaCuello + "','" +  txtSignoVitalMedicionPeso + "','" + txtSignoVitalMedicionTalla + "','" + txtSignoVitalMedicionPerimetroCintura + "','" + txtSignoVitalMedicionPerimetroCadera + "', '" + txtSignoVitalMedicionPerimetroCefalico + "','" + txtExamenFisicoA + "','" +  txtExamenFisicoB + "', '" + txtExamenFisicoC + "','" + txtExamenFisicoD + "','" +  txtDiagnosticoPresuntivoDiagnostico + "', '" + txtDiagnosticoPresuntivoCIE + "','" + txtTratamientoPresuntivoA + "','" + txtTratamientoPresuntivoB + "', '" + dtFechaEvolucionMedicamentoA.ToString("yyyy-MM-dd") + "','" + dtFechaEvolucionMedicamentoB.ToString("yyyy-MM-dd") + "','" +  txtPrescipcion1 + "', '" + txtPrescipcion2 + "','" + txtPrescipcion3 +"','" + txtPrescipcion4 + "', '" + txtPrescipcion5 +"', '"+ txtPrescipcion6 + "','" + txtDiagnosticoDefinitivoDiagnostico + "', '" + txtDiagnosticoDefinitivoCIE + "', '" + txtTratamientoDefinitivo + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }
        public DataTable get_consulta_externa_by_paciente(string idPaciente)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT *  FROM CONSULTAS_EXTERNA_ANAMNESIS  WHERE IdPaciente = '" + idPaciente + "'", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + "get_consulta_externa_by_paciente" + ex.Message);
            }
        }
    }
}
