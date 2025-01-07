using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NExamenFormularioPaciente
    {
        public static DataTable cargar_cmb()
        {
            return new DExamenFormularioPaciente().cargar_cmb();
        }
        public static DataTable cargar_cmb_by_id(int id)
        {
            return new DExamenFormularioPaciente().cargar_cmb_by_id(id);
        }
        public static DataTable cargar_cmb_by_paciente(int id)
        {
            return new DExamenFormularioPaciente().cargar_cmb_by_paciente(id);
        }
        public static DataTable cargar_contro_score_by_formulario(int id)
        {
            return new DExamenFormularioPaciente().cargar_contro_score_by_formulario(id);
        }
        public static DataTable cargar_cmb_by_paciente_temp(string idFormulario,int id,string usuario_crea)
        {
            return new DExamenFormularioPaciente().cargar_cmb_by_paciente_temp(idFormulario,id, usuario_crea);
        }
        public static DataTable cargar_detalle_examen(string idFormulario, int id, string usuario_crea)
        {
            return new DExamenFormularioPaciente().cargar_detalle_examen(idFormulario, id, usuario_crea);
        }
        public static DataTable delete_detalle_examen(string idFormulario, int id, string usuario_crea)
        {
            return new DExamenFormularioPaciente().delete_detalle_examen(idFormulario, id, usuario_crea);
        }
        public static DataTable cargar_archivo_maternal(int idFormulario)
        {
            return new DExamenFormularioPaciente().cargar_archivo_maternal(idFormulario);
        }
        public static DataTable cargar_archivo_examen_general_temp(int idpaciente, string usuario)
        {
            return new DExamenFormularioPaciente().cargar_archivo_examen_general_temp( idpaciente,  usuario);
        }
        public static DataTable cargar_examen_general_hc(int idExamen)
        {
            return new DExamenFormularioPaciente().cargar_examen_general_hc(idExamen);
        }
        public static DataTable cargar_archivo_examen_general(int idExamen)
        {
            return new DExamenFormularioPaciente().cargar_archivo_examen_general(idExamen);
        }
        public static byte[] get_file_item_formulario(int idFile)
        {
            return new DExamenFormularioPaciente().get_file_item_formulario(idFile);
        }
        public static byte[] get_file_item_examen_general(int idFile,bool temp)
        {
            return new DExamenFormularioPaciente().get_file_item_examen_general(idFile, temp);
        } 
        public static bool eliminar(int id)
        {
            return new DExamenFormularioPaciente().eliminar(id);
        }
        public static bool eliminar_formulario_item(int id)
        {
            return new DExamenFormularioPaciente().eliminar_formulario_item(id);
        }
        public static bool eliminar_temp(int id)
        {
            return new DExamenFormularioPaciente().eliminar_temp(id);
        }
        public static bool eliminar_ControlScoreMama(int id)
        {
            return new DExamenFormularioPaciente().eliminar_ControlScoreMama(id);
        }
        public static bool eliminar_archivo_hc(int id)
        {
            return new DExamenFormularioPaciente().eliminar_archivo_hc(id);
        }
        public static bool eliminar_archivo_examen_general_hc(int id,bool temp)
        {
            return new DExamenFormularioPaciente().eliminar_archivo_examen_general_hc(id, temp);
        }
        public static bool eliminar_archivo_examen_general_hc_temp(string UsuarioCrea)
        {
            return new DExamenFormularioPaciente().eliminar_archivo_examen_general_hc_temp( UsuarioCrea);
        }
        public static bool eliminar_temp_by_paciente(int id,string usuario_crea)
        {
            return new DExamenFormularioPaciente().eliminar_temp_by_paciente(id,usuario_crea);
        }
        public static bool modificar(int id, string Descripcion_Valor, bool Estado, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisico, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            return new DExamenFormularioPaciente().modificar( id,  Descripcion_Valor,  Estado,  Usuario_Crea,  IdAtecedenteFamiliar,  IdTipoPatologiaCP,  IdTipoPatologiaSP,  IdSignosVitalesMediciones,  IdExamenFisico,  IdDiagnosticoPresuntivoCIE,  IdDiagnosticoDefinitivoCIE,  Medicamento,  Prescripcion);
        }  

        public static bool guardar(int IdPaciente,int idFormulario, string Descripcion_Valor, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisico, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            return new DExamenFormularioPaciente().guardar( IdPaciente, idFormulario,  Descripcion_Valor,  Usuario_Crea,  IdAtecedenteFamiliar,  IdTipoPatologiaCP,  IdTipoPatologiaSP,  IdSignosVitalesMediciones,  IdExamenFisico,  IdDiagnosticoPresuntivoCIE,  IdDiagnosticoDefinitivoCIE, Medicamento,  Prescripcion);
        }
        public static bool guardar_temp(int IdPaciente, int idFormulario, string Descripcion_Valor, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisicoCP,int IdExamenFisicoSP, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            return new DExamenFormularioPaciente().guardar_temp(IdPaciente, idFormulario, Descripcion_Valor, Usuario_Crea, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, IdExamenFisicoCP, IdExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, Medicamento, Prescripcion);
        }
        public static bool guardar_formulario_item(int IdExamenPaciente,int IdPaciente, int idFormulario, string Descripcion_Valor, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisicoCP,int IdExamenFisicoSP, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            return new DExamenFormularioPaciente().guardar_formulario_item(IdExamenPaciente, IdPaciente, idFormulario, Descripcion_Valor, Usuario_Crea, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, IdExamenFisicoCP, IdExamenFisicoSP,IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, Medicamento, Prescripcion);
        }
        public static bool modificar_formulario_item(int IdExamenItem, int idFormulario, string Descripcion_Valor, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisicoCP,int IdExamenFisicoSP, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            return new DExamenFormularioPaciente().modificar_formulario_item(IdExamenItem, idFormulario, Descripcion_Valor, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, IdExamenFisicoCP, IdExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, Medicamento, Prescripcion);
        }
        public static int guardar_diagnostico_fianl(string idCita, string IdPaciente, DateTime FechaAtencion, DateTime Hora, string Usuario_Crea)
        {
            return new DExamenFormularioPaciente().guardar_diagnostico_fianl(idCita,IdPaciente,  FechaAtencion,  Hora,  Usuario_Crea);
        }
        public static int agregar_examen_general_hc(int IdExamen, int IdPaciente, int IdEspecialista, string Observacion, decimal Costo, DateTime Fecha_Atencion, string UsuarioCrea)
        {
            return new DExamenFormularioPaciente().agregar_examen_general_hc(IdExamen, IdPaciente, IdEspecialista, Observacion, Costo, Fecha_Atencion, UsuarioCrea);
        }
        public static bool modificar_examen_general_hc( int idExamenItem, int IdExamen, int IdPaciente, int IdEspecialista, string Observacion, decimal Costo, DateTime Fecha_Atencion)
        {
            return new DExamenFormularioPaciente().modificar_examen_general_hc(idExamenItem,IdExamen, IdPaciente, IdEspecialista, Observacion, Costo, Fecha_Atencion);
        }
        public static bool modificar_diagnostico_fianl(string idExamenFormulario, DateTime FechaAtencion, DateTime Hora)
        {
            return new DExamenFormularioPaciente().modificar_diagnostico_fianl(idExamenFormulario, FechaAtencion, Hora);
        }
        public static bool eliminar_diagnostico_fianl(string idExamenFormulario)
        {
            return new DExamenFormularioPaciente().eliminar_diagnostico_fianl(idExamenFormulario);
        }
        public static bool eliminar_examen_general_hc(string idExamen)
        {
            return new DExamenFormularioPaciente().eliminar_examen_general_hc(idExamen);
        }
        public static bool AgregarScoreMama(int IdPaciente, int IdFormulario, DateTime Fecha_Atencion, DateTime Hora, int IdControScore1, int IdControScore2, int IdControScore3, int IdControScore4, int IdControScore5, int IdControScore6, int IdControScore7, int IdControScore8, int IdControScore9, int IdControScore10, int ValorScore1, int ValorScore2, int alorScore3, int ValorScore4, int ValorScore5, int ValorScore6, int ValorScore7, int ValorScore8, int ValorScore9, int ValorScore10, int PuntajeScore1, int PuntajeScore2, int PuntajeScore3, int PuntajeScore4, int PuntajeScore5, int PuntajeScore6, int PuntajeScore7, int PuntajeScore8, int PuntajeScore9, int PuntajeScore10,string responsable)
        {
            return new DExamenFormularioPaciente().AgregarScoreMama(IdPaciente, IdFormulario, Fecha_Atencion, Hora, IdControScore1, IdControScore2, IdControScore3, IdControScore4, IdControScore5, IdControScore6, IdControScore7, IdControScore8, IdControScore9, IdControScore10, ValorScore1, ValorScore2, alorScore3, ValorScore4, ValorScore5, ValorScore6, ValorScore7, ValorScore8, ValorScore9, ValorScore10, PuntajeScore1, PuntajeScore2, PuntajeScore3, PuntajeScore4, PuntajeScore5, PuntajeScore6, PuntajeScore7, PuntajeScore8, PuntajeScore9, PuntajeScore10,responsable);
        }
        public static bool AgregarExamenFile(int IdPaciente, int IdFormulario, int IdExamen, string Comentario, byte[] archivo,string nombreFile, string extFile)
        {
            return new DExamenFormularioPaciente().AgregarExamenFile(IdPaciente, IdFormulario, IdExamen, Comentario, archivo,nombreFile,extFile );
        }
        public static bool AgregarExamenFileGeneralHCTmp(int IdPaciente, byte[] archivo, string nombreFile, string extFile, string usuarioCrea)
        {
            return new DExamenFormularioPaciente().AgregarExamenFileGeneralHCTmp(IdPaciente, archivo,  nombreFile,  extFile,  usuarioCrea);
        }
        public static bool AgregarExamenFileGeneralHC(int IdExamen, byte[] archivo, string nombreFile, string extFile)
        {
            return new DExamenFormularioPaciente().AgregarExamenFileGeneralHC(IdExamen, archivo, nombreFile, extFile);
        }
    }
}
