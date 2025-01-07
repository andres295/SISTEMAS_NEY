using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CapaDatos
{
    public class DExamenFormularioPaciente
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DExamenFormularioPaciente";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ExamenFormularioPaciente ORDER BY Descripcion_Valor", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb'. " + ex.Message);
            }
        }
        public DataTable cargar_cmb_by_id(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT *,case when IdAtecedenteFamiliar != 0 THEN  IdAtecedenteFamiliar WHEN IdTipoPatologiaCP != 0 then IdTipoPatologiaCP when IdTipoPatologiaSP != 0 then IdTipoPatologiaSP   when IdSignosVitalesMediciones != 0 then IdSignosVitalesMediciones when IdExamenFisicoCP !=0 then IdExamenFisicoCP when IdExamenFisicoSP !=0 then IdExamenFisicoSP when IdDiagnosticoPresuntivoCIE != 0 then IdDiagnosticoPresuntivoCIE when IdDiagnosticoDefinitivoCIE != 0 then IdDiagnosticoDefinitivoCIE else 0 end IdCat FROM ExamenFormularioPaciente Where Id = '" + id+ "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb_by_id'. " + ex.Message);
            }
        }
        public DataTable cargar_cmb_by_paciente(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ExamenFormularioPaciente Where IdPaciente = '" + id + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb_by_id'. " + ex.Message);
            }
        }
        public DataTable cargar_contro_score_by_formulario(int idFormato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                     SqlDataAdapter da = new SqlDataAdapter("EXEC sp_obtener_score_by_formulario '" + idFormato + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_contro_score_by_formulario'. " + ex.Message);
            }
        }
        public DataTable cargar_cmb_by_paciente_temp(string idFormulario, int id,string usuario_crea)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if(idFormulario != null)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("EXEC sp_Obtiene_Formulario_tem_by_paciente '" + idFormulario + "','" + id + "','" + usuario_crea + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("EXEC sp_Obtiene_Formulario_tem_by_paciente null,'" + id + "','" + usuario_crea + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }  
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb_by_id'. " + ex.Message);
            }
        }
        public DataTable cargar_detalle_examen(string idFormulario, int idExamen, string usuario_crea)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da = new SqlDataAdapter("select id, IdSignosVitalesMediciones, Descripcion_Valor from ExamenFormularioPaciente where IdFormulario = '"+ idFormulario + "' and IdExamenPaciente = '"+ idExamen + "' union all select id, IdSignosVitalesMediciones, Descripcion_Valor from TpmExamenFormularioPaciente where IdFormulario = '" + idFormulario + "' and Usuario_Crea = '" + usuario_crea + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_detalle_examen'. " + ex.Message);
            }
        }
        public DataTable delete_detalle_examen(string idFormulario, int idExamen, string usuario_crea)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("DELETE ExamenFormularioPaciente where IdFormulario = '" + idFormulario + "' and IdExamenPaciente = '" + idExamen + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("DELETE TpmExamenFormularioPaciente where IdFormulario = '" + idFormulario + "' and Usuario_Crea = '" + usuario_crea + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'delete_detalle_examen'. " + ex.Message);
            }
        }
        public bool eliminar(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ExamenFormularioPaciente Set Estado = 0  WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true; 
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar'. " + ex.Message);
            }
        }
        public bool eliminar_temp(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TpmExamenFormularioPaciente  WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true; 
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_temp'. " + ex.Message);
            }
        }
        public bool eliminar_ControlScoreMama(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE ControlScoreMama  WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_ControlScoreMama'. " + ex.Message);
            }
        }
        public bool eliminar_archivo_hc(int idArchivo)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ExamenesHistoriaClinica set estado = 0   WHERE Id = " + idArchivo + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_archivo_hc'. " + ex.Message);
            }
        }
        public bool eliminar_archivo_examen_general_hc(int idArchivo, bool temp)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    if (temp)
                    {
                        SqlCommand cmd = new SqlCommand("DELETE TmpArchivoExamenesGeneralHC WHERE Id = " + idArchivo + "", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE ArchivoExamenesGeneralHC set estado = 0   WHERE Id = " + idArchivo + "", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    } 
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_archivo_examen_general_hc'. " + ex.Message);
            }
        }
        public bool eliminar_archivo_examen_general_hc_temp(string usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                   
                        SqlCommand cmd = new SqlCommand("DELETE TmpArchivoExamenesGeneralHC WHERE UsuarioCrea = '" + usuario + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                  
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_archivo_examen_general_hc_temp'. " + ex.Message);
            }
        }
        public bool eliminar_formulario_item(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE ExamenFormularioPaciente  WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_temp'. " + ex.Message);
            }
        }
        public bool eliminar_temp_by_paciente(int idPaciente, string usuario_crea)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TpmExamenFormularioPaciente  WHERE IdPaciente = '" + idPaciente + "' and Usuario_Crea = '" + usuario_crea + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true; 
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar'. " + ex.Message);
            }
        }
        public bool modificar(int id,string Descripcion_Valor, bool Estado, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisico, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Catalogo SET Descripcion_Valor = '" + Descripcion_Valor + "', Estado = '" + Estado + "', Usuario_Crea = '" + Usuario_Crea + "', IdAtecedenteFamiliar = '" + IdAtecedenteFamiliar + "', IdTipoPatologiaCP = '" + IdTipoPatologiaCP + "', IdTipoPatologiaSP = '" + IdTipoPatologiaSP + "', IdSignosVitalesMediciones = '" + IdSignosVitalesMediciones + "', IdDiagnosticoPresuntivoCIE = '" + IdDiagnosticoPresuntivoCIE + "', IdDiagnosticoDefinitivoCIE = '" + IdDiagnosticoDefinitivoCIE + "', Medicamento = '" + Medicamento + "', Prescripcion = '" + Prescripcion + "' WHERE Id = '" + id +"'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true; 
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar'. " + ex.Message);
            }
        }   

        public bool guardar(int IdPaciente,int idFormulario, string Descripcion_Valor, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisico, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ExamenFormularioPaciente (IdPaciente,IdFormulario, Descripcion_Valor,Fecha_Registro,Estado, Usuario_Crea, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, IdExamenFisico, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, Medicamento, Prescripcion) VALUES('" + IdPaciente + "','" + idFormulario + "','" + Descripcion_Valor + "',getdate(),1,'" + Usuario_Crea + "','" + IdAtecedenteFamiliar + "','" + IdTipoPatologiaCP + "','" + IdTipoPatologiaSP + "','" + IdSignosVitalesMediciones + "','" + IdExamenFisico + "','" + IdDiagnosticoPresuntivoCIE + "','" + IdDiagnosticoDefinitivoCIE + "','" + Medicamento + "','" + Prescripcion + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }
        public bool guardar_temp(int IdPaciente, int idFormulario, string Descripcion_Valor, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisicoCP,int IdExamenFisicoSP, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TpmExamenFormularioPaciente (IdPaciente,IdFormulario, Descripcion_Valor,Fecha_Registro,Estado, Usuario_Crea, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, IdExamenFisicoCP,IdExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, Medicamento, Prescripcion) VALUES('" + IdPaciente + "','" + idFormulario + "','" + Descripcion_Valor + "',getdate(),1,'" + Usuario_Crea + "','" + IdAtecedenteFamiliar + "','" + IdTipoPatologiaCP + "','" + IdTipoPatologiaSP + "','" + IdSignosVitalesMediciones + "','" + IdExamenFisicoCP + "','" + IdExamenFisicoSP + "','" + IdDiagnosticoPresuntivoCIE + "','" + IdDiagnosticoDefinitivoCIE + "','" + Medicamento + "','" + Prescripcion + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                     
                    cmd.ExecuteNonQuery(); 
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_temp'. " + ex.Message);
            }
        }
        public bool guardar_formulario_item( int IdExamenPaciente, int IdPaciente, int idFormulario, string Descripcion_Valor, string Usuario_Crea, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisicoCP,int IdExamenFisicoSP, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ExamenFormularioPaciente (IdExamenPaciente,IdPaciente,IdFormulario, Descripcion_Valor,Fecha_Registro,Estado, Usuario_Crea, IdAtecedenteFamiliar, IdTipoPatologiaCP, IdTipoPatologiaSP, IdSignosVitalesMediciones, IdExamenFisicoCP,IdExamenFisicoSP, IdDiagnosticoPresuntivoCIE, IdDiagnosticoDefinitivoCIE, Medicamento, Prescripcion) VALUES('" + IdExamenPaciente + "','" + IdPaciente + "','" + idFormulario + "','" + Descripcion_Valor + "',getdate(),1,'" + Usuario_Crea + "','" + IdAtecedenteFamiliar + "','" + IdTipoPatologiaCP + "','" + IdTipoPatologiaSP + "','" + IdSignosVitalesMediciones + "','" + IdExamenFisicoCP + "','" + IdExamenFisicoSP + "','" + IdDiagnosticoPresuntivoCIE + "','" + IdDiagnosticoDefinitivoCIE + "','" + Medicamento + "','" + Prescripcion + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_formulario_item'. " + ex.Message);
            }
        }
        public bool modificar_formulario_item( int IdFormularioItem, int idFormulario, string Descripcion_Valor, int IdAtecedenteFamiliar, int IdTipoPatologiaCP, int IdTipoPatologiaSP, int IdSignosVitalesMediciones, int IdExamenFisicoCP,int IdExamenFisicoSP, int IdDiagnosticoPresuntivoCIE, int IdDiagnosticoDefinitivoCIE, string Medicamento, string Prescripcion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                { 
                    /*Se modifica detalle*/
                    SqlCommand cmd = new SqlCommand("UPDATE ExamenFormularioPaciente SET idFormulario = '"+ idFormulario + "',  Descripcion_Valor  = '" + Descripcion_Valor + "',  IdAtecedenteFamiliar  = '" + IdAtecedenteFamiliar + "',  IdTipoPatologiaCP  = '" + IdTipoPatologiaCP + "',  IdTipoPatologiaSP  = '" + IdTipoPatologiaSP + "',  IdSignosVitalesMediciones  = '" + IdSignosVitalesMediciones + "',  IdExamenFisicoCP  = '" + IdExamenFisicoCP + "',  IdExamenFisicoSP  = '" + IdExamenFisicoSP + "',  IdDiagnosticoPresuntivoCIE  = '" + IdDiagnosticoPresuntivoCIE + "',  IdDiagnosticoDefinitivoCIE  = '" + IdDiagnosticoDefinitivoCIE + "',  Medicamento  = '" + Medicamento + "',  Prescripcion = '"+ Prescripcion + "' where Id =  '"+ IdFormularioItem + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_formulario_item'. " + ex.Message);
            }
        }
        public int guardar_diagnostico_fianl(string idCita,string IdPaciente, DateTime FechaAtencion, DateTime Hora, string Usuario_Crea)
        {
            try
            { 
                int id = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ExamenPaciente (IdCita,IdPaciente,Fecha_Atencion, Hora,Usuario_Crea) VALUES('" + idCita + "','" + IdPaciente + "','" + FechaAtencion.ToString("yyyy-MM-dd") + "','" + Hora.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Usuario_Crea + "') select @@IDENTITY", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                       id = int.Parse(cmd.ExecuteScalar().ToString());

                        if (id > 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO ExamenFormularioPaciente (IdExamenPaciente, IdPaciente,IdFormulario,Descripcion_Valor,Estado,Fecha_Registro,Usuario_Crea,IdAtecedenteFamiliar,IdTipoPatologiaCP,IdTipoPatologiaSP,IdSignosVitalesMediciones,IdExamenFisicoCP,IdExamenFisicoSP,IdDiagnosticoPresuntivoCIE,IdDiagnosticoDefinitivoCIE,Medicamento,Prescripcion)  Select '" + id + "' IdExamenPaciente, IdPaciente,IdFormulario,Descripcion_Valor,	Estado,	Fecha_Registro	,Usuario_Crea,IdAtecedenteFamiliar,IdTipoPatologiaCP,IdTipoPatologiaSP,IdSignosVitalesMediciones,IdExamenFisicoCP,IdExamenFisicoSP,IdDiagnosticoPresuntivoCIE,	IdDiagnosticoDefinitivoCIE,	Medicamento,Prescripcion from TpmExamenFormularioPaciente where IdPaciente = '" + IdPaciente +"' and Usuario_Crea = '" + Usuario_Crea +"'" , con.conexion);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.ExecuteNonQuery(); 
                            con.desconectar(); 
                        } 
                    }
                    catch (Exception)
                    {
                        id = 0;
                    }  
                } 
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_diagnostico_fianl'. " + ex.Message);
            }
        }
        public int agregar_examen_general_hc(int IdExamen, int IdPaciente , int IdEspecialista ,string Observacion , decimal Costo, DateTime Fecha_Atencion, string UsuarioCrea)
        {
            try
            {
                int id = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ExamenesGeneralHC (IdExamen, IdPaciente , IdEspecialista ,Observacion ,Costo,Fecha_Atencion,UsuarioCrea) VALUES('" + IdExamen + "','" + IdPaciente + "','" + IdEspecialista + "','" + Observacion + "','" + Costo.ToString().Replace(",", ".") + "','" + Fecha_Atencion.ToString("yyyy-MM-dd") + "','" + UsuarioCrea + "') select @@IDENTITY", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        id = int.Parse(cmd.ExecuteScalar().ToString());

                        if (id > 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO ArchivoExamenesGeneralHC (IdExamenGeneralHC, ArchivoResultado,NombreArchivo,ExtArchivo)  Select '" + id + "' IdExamenGeneralHC, ArchivoResultado,NombreArchivo,ExtArchivo from TmpArchivoExamenesGeneralHC  where IdPaciente = '" + IdPaciente + "' and UsuarioCrea = '" + UsuarioCrea + "'", con.conexion);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.ExecuteNonQuery();

                            SqlCommand cmd3 = new SqlCommand("Delete TmpArchivoExamenesGeneralHC where IdPaciente = '" + IdPaciente + "' and UsuarioCrea = '" + UsuarioCrea + "'", con.conexion);
                            cmd3.CommandType = CommandType.Text;
                            cmd3.ExecuteNonQuery();

                            con.desconectar();
                        }
                    }
                    catch (Exception)
                    {
                        id = 0;
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'agregar_examen_general_hc'. " + ex.Message);
            }
        }
        public bool modificar_examen_general_hc(int IdExamenItem, int IdExamen, int IdPaciente, int IdEspecialista, string Observacion, decimal Costo, DateTime Fecha_Atencion)
        {
            bool resp = false;
            try
            { 
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("update ExamenesGeneralHC set IdExamen = '"+ IdExamen + "', IdPaciente = '" + IdPaciente + "' ,IdEspecialista =  '" + IdEspecialista + "', Observacion = '" + Observacion + "', Costo = '" + Costo.ToString().Replace(",", ".") + "' , Fecha_Atencion =  '" + Fecha_Atencion.ToString("yyyy-MM-dd") + "' Where Id = '"+ IdExamenItem + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.desconectar(); 
                }
                resp = true;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_examen_general_hc'. " + ex.Message); 
            }
            return resp;
        }
        public bool modificar_diagnostico_fianl(string idExamenFormulario, DateTime FechaAtencion, DateTime Hora)
        {
            try
            {
                bool resp = false;
                int id = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    /*Se modifica cabezera*/
                    SqlCommand cmd = new SqlCommand("UPDATE ExamenPaciente SET Fecha_Atencion = '" + FechaAtencion.ToString("yyyy-MM-dd") + "',  Hora  = '" + Hora.ToString("yyyy-MM-dd HH:mm:ss") + "' where Id =  '" + idExamenFormulario + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_diagnostico_fianl'. " + ex.Message);
            }
        }
        public bool eliminar_diagnostico_fianl(string idExamenFormulario)
        {
            try
            {
                bool resp = false;
                int id = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    /*Se modifica cabezera*/
                    SqlCommand cmd = new SqlCommand("UPDATE ExamenPaciente SET Estado = 0 where Id =  '" + idExamenFormulario + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_diagnostico_fianl'. " + ex.Message);
            }
        }
        public bool eliminar_examen_general_hc(string idExamen)
        {
            try
            {
                bool resp = false;
                int id = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    /*Se modifica cabezera*/
                    SqlCommand cmd = new SqlCommand("UPDATE ExamenesGeneralHC SET Estado = 0 where Id =  '" + idExamen + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_examen_general_hc'. " + ex.Message);
            }
        }
        public bool AgregarScoreMama(int IdPaciente, int IdFormulario , DateTime Fecha_Atencion , DateTime Hora , int IdControScore1 , int IdControScore2 , int IdControScore3 , int IdControScore4 , int IdControScore5 , int IdControScore6 , int IdControScore7 , int IdControScore8 , int IdControScore9 , int IdControScore10 , int ValorScore1 ,int ValorScore2 , int alorScore3 , int ValorScore4 , int ValorScore5 , int ValorScore6 , int ValorScore7 , int ValorScore8 , int ValorScore9 , int ValorScore10 , int PuntajeScore1 , int PuntajeScore2 , int PuntajeScore3, int PuntajeScore4 , int PuntajeScore5 , int PuntajeScore6 , int PuntajeScore7 , int PuntajeScore8 , int PuntajeScore9 , int PuntajeScore10,string  responsable)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ControlScoreMama (IdPaciente, IdFormulario , Fecha_Atencion , Hora , IdControScore1 ,IdControScore2 , IdControScore3 , IdControScore4 , IdControScore5 ,IdControScore6 , IdControScore7 , IdControScore8 , IdControScore9 , IdControScore10 , ValorScore1 ,ValorScore2 , ValorScore3 , ValorScore4 , ValorScore5 , ValorScore6 , ValorScore7 ,ValorScore8 , ValorScore9 , ValorScore10 , PuntajeScore1 , PuntajeScore2 , PuntajeScore3, PuntajeScore4 ,PuntajeScore5 , PuntajeScore6 , PuntajeScore7 , PuntajeScore8 , PuntajeScore9 , PuntajeScore10 ,responsable) VALUES('"+ IdPaciente + "','" + IdFormulario + "','" + Fecha_Atencion.ToString("yyyy-MM-dd") + "','" + Hora.ToString("yyyy-MM-dd HH:mm:ss") + "','" + IdControScore1 + "','" +  IdControScore2 + "','" + IdControScore3 + "','" + IdControScore4 + "','" + IdControScore5 + "','" +  IdControScore6 + "','" + IdControScore7 + "','" + IdControScore8 + "','" + IdControScore9 + "','" + IdControScore10 + "','" + ValorScore1 + "','" +  ValorScore2 + "','" + alorScore3 + "','" + ValorScore4 + "','" + ValorScore5 + "','" + ValorScore6 + "','" + ValorScore7 + "','" +  ValorScore8 + "','" + ValorScore9 + "','" + ValorScore10 + "','" + PuntajeScore1 + "','" + PuntajeScore2 + "','" + PuntajeScore3 + "','" + PuntajeScore4 + "','" +  PuntajeScore5 + "','" + PuntajeScore6 + "','" + PuntajeScore7 + "','" + PuntajeScore8 + "','" + PuntajeScore9 + "','" + PuntajeScore10 + "','" + responsable + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'AgregarScoreMama'. " + ex.Message);
            }
        }
        public bool AgregarExamenFile(int IdPaciente, int IdFormulario, int IdExamen ,string Comentario,byte[] archivo,string nombreFile,string extFile)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                { 

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO ExamenesHistoriaClinica (IdPaciente, IdFormulario , IdExamen ,Comentario,ArchivoResultado,NombreArchivo,ExtArchivo ) VALUES(@IdPaciente, @IdFormulario , @IdExamen ,@Comentario,@ArchivoResultado,@NombreArchivo,@ExtArchivo )", con.conexion);

                    cmd2.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = IdPaciente;
                    cmd2.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                    cmd2.Parameters.Add("@IdExamen", SqlDbType.Int).Value = IdExamen;
                    cmd2.Parameters.Add("@Comentario", SqlDbType.Char).Value = Comentario;
                    cmd2.Parameters.Add("@ArchivoResultado", SqlDbType.Binary).Value = archivo;
                    cmd2.Parameters.Add("@NombreArchivo", SqlDbType.Char).Value = nombreFile;
                    cmd2.Parameters.Add("@ExtArchivo", SqlDbType.Char).Value = extFile;
                    /// cmd2.Parameters.Add("@IdExamen", SqlDbType.Int).Value = IdExamen;

                    cmd2.CommandType = CommandType.Text;
                    int rows = cmd2.ExecuteNonQuery();
                    if (rows >0)
                    {
                        resp = true;
                    } 
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'AgregarExamenFile'. " + ex.Message);
            }
        }
        public bool AgregarExamenFileGeneralHCTmp(int IdPaciente, byte[] archivo, string nombreFile,string extFile, string usuarioCrea)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO TmpArchivoExamenesGeneralHC (IdPaciente,ArchivoResultado,NombreArchivo,ExtArchivo,UsuarioCrea ) VALUES(@IdPaciente,@ArchivoResultado,@NombreArchivo,@ExtArchivo,@UsuarioCrea )", con.conexion);

                    cmd2.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = IdPaciente; 
                    cmd2.Parameters.Add("@ArchivoResultado", SqlDbType.Binary).Value = archivo;
                    cmd2.Parameters.Add("@NombreArchivo", SqlDbType.Char).Value = nombreFile;
                    cmd2.Parameters.Add("@ExtArchivo", SqlDbType.Char).Value = extFile;
                    cmd2.Parameters.Add("@UsuarioCrea", SqlDbType.Char).Value = usuarioCrea;
                    /// cmd2.Parameters.Add("@IdExamen", SqlDbType.Int).Value = IdExamen;

                    cmd2.CommandType = CommandType.Text;
                    int rows = cmd2.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        resp = true;
                    }
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'AgregarExamenFileGeneralHCTmp'. " + ex.Message);
            }
        }
        public bool AgregarExamenFileGeneralHC(int IdExamen, byte[] archivo, string nombreFile, string extFile)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO ArchivoExamenesGeneralHC (IdExamenGeneralHC,ArchivoResultado,NombreArchivo,ExtArchivo) VALUES(@IdExamenGeneralHC,@ArchivoResultado,@NombreArchivo,@ExtArchivo)", con.conexion);

                    cmd2.Parameters.Add("@IdExamenGeneralHC", SqlDbType.Int).Value = IdExamen;
                    cmd2.Parameters.Add("@ArchivoResultado", SqlDbType.Binary).Value = archivo;
                    cmd2.Parameters.Add("@NombreArchivo", SqlDbType.Char).Value = nombreFile;
                    cmd2.Parameters.Add("@ExtArchivo", SqlDbType.Char).Value = extFile; 
                    /// cmd2.Parameters.Add("@IdExamen", SqlDbType.Int).Value = IdExamen;

                    cmd2.CommandType = CommandType.Text;
                    int rows = cmd2.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        resp = true;
                    }
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'AgregarExamenFileGeneralHC'. " + ex.Message);
            }
        }
        public DataTable cargar_archivo_maternal(int idFormularioExamen)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("select  a.Id,cat.Descripcion Examen, a.Comentario,a.NombreArchivo,a.ExtArchivo from  [dbo].[ExamenesHistoriaClinica] a inner join dbo.Catalogo cat on a.IdExamen = cat.Id where a.IdFormulario = '" + idFormularioExamen + "' and a.estado = 1", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_archivo_maternal'. " + ex.Message);
            }
        }
        public DataTable cargar_archivo_examen_general_temp(int idpaciente, string usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, NombreArchivo, ExtArchivo, FechaRegistro, Estado, UsuarioCrea FROm dbo.TmpArchivoExamenesGeneralHC a  where a.IdPaciente = '" + idpaciente + "' and a.UsuarioCrea = '" + usuario + "' and a.estado = 1", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_archivo_maternal'. " + ex.Message);
            }
        }
        public DataTable cargar_examen_general_hc(int idExamen)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROm dbo.ExamenesGeneralHC a  where a.id = '" + idExamen + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_examen_general_hc'. " + ex.Message);
            }
        }
        public DataTable cargar_archivo_examen_general(int idExamen)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, NombreArchivo, ExtArchivo, FechaRegistro, Estado FROm dbo.ArchivoExamenesGeneralHC a  where a.IdExamenGeneralHC = '" + idExamen + "' and a.estado = 1", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_archivo_maternal'. " + ex.Message);
            }
        }
        public byte[] get_file_item_formulario(int idFile)
        {
            try
            {
                byte[] byteData = null;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                { 
                    SqlCommand cmd2 = new SqlCommand("Select ArchivoResultado from  [dbo].[ExamenesHistoriaClinica] where Id = @id", con.conexion); 
                    cmd2.Parameters.Add("@Id", SqlDbType.Int).Value = idFile; 
                    SqlDataReader reader = cmd2.ExecuteReader();

                    if (reader.Read())
                    {
                       byteData = (byte[])reader[0]; 
                    } 

                    con.desconectar();
                }

                return byteData;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'get_file_item_formulario'. " + ex.Message);
            }
        }
        public byte[] get_file_item_examen_general(int idFile, bool temp)
        {
            try
            {
                byte[] byteData = null;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                { 
                    if (temp)
                    {
                        SqlCommand cmd2 = new SqlCommand("Select ArchivoResultado from  [dbo].[TmpArchivoExamenesGeneralHC] where Id = @id", con.conexion);
                        cmd2.Parameters.Add("@Id", SqlDbType.Int).Value = idFile;
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            byteData = (byte[])reader[0];
                        }
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("Select ArchivoResultado from  [dbo].[ArchivoExamenesGeneralHC] where Id = @id", con.conexion);
                        cmd2.Parameters.Add("@Id", SqlDbType.Int).Value = idFile;
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            byteData = (byte[])reader[0];
                        }
                    } 
                   
                    con.desconectar();
                }

                return byteData;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'get_file_item_examen_general '. " + ex.Message);
            }
        }
    }
}
