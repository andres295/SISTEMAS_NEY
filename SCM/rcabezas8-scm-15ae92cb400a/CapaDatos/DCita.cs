using System; 
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCita
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DCita";

        public DataTable lista_combo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id,Id_Paciente,Fecha_Cita,Hora_Cita,Observacion,Estado,Fecha_Sistema,Atendida FROM CitaPaciente ORDER BY Id", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
            }
        }
        public int buscar_by_id(string id)

        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CitaPaciente WHERE Id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg'. " + ex.Message);
            }

        }
        public DataTable buscar_by_paciente(string id_paciente)
        {

            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT cit.Id, emp.Nombres_Apellidos Doctor,ISNULL(ser.Servicio,'S/N')Servicio,Fecha_Cita [Fecha],Hora_Cita [Hora Inicio],Hora__fin_Cita [Hora Fin],Observacion,case when Atendida = 1 then 'Atendida' else 'Pendiente' end as Atendida  FROM CitaPaciente cit left join Servicios ser on Id_Servicio = ser.Id  left join Especialista emp on Id_Doctor = emp.Id WHERE cit.Estado = 1 and Id_Paciente = '" + id_paciente + "' ORDER BY  cit.Id DESC", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
            }

        }
        public int num_reg()
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CitaPaciente", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg'. " + ex.Message);
            }
        }
        public DataTable valida_cita(DateTime dia, DateTime hora_inicio, DateTime hora_fin,string id_doctor)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();
                int valor = 0;

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC  sp_valida_cita_hora '" + dia.ToString("yyyy-MM-dd") +"','" + hora_inicio.ToString("yyyy-MM-dd HH:mm:ss") + "','" + hora_fin.ToString("yyyy-MM-dd HH:mm:ss") + "','" + id_doctor + "'", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
 
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'valida_cita'. " + ex.Message);
            }
        }
        public int guardar(string id_paciente, string id_doctor,string id_servicio, DateTime fecha, DateTime hora, DateTime hora_fin, string observacion, bool atendida)
        {
            try
            { 
                int idCita = 0;

                con = new DConexion();

                if (con.conectar())
                {  
                    SqlCommand cmd = new SqlCommand("INSERT INTO CitaPaciente VALUES('" + id_paciente+ "','" + id_servicio + "', '" + fecha.ToString("yyyy-MM-dd") + "', '" + hora.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +  hora_fin.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + observacion + "',1,getdate(),'"+ atendida +"','" + id_doctor + "') SELECT @@IDENTITY", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        idCita = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                    catch (Exception)
                    {
                        idCita = 0;
                    } 
                    con.desconectar();
                }

                return idCita;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }
        public bool eliminar(string id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE CitaPaciente Set Estado = 0 WHERE Id = '" + id + "'", con.conexion);
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
        public bool modificar(string id, string id_doctor, string id_servicio, string observacion, DateTime fecha, DateTime hora, DateTime hora_fin,bool atendida)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE CitaPaciente SET Observacion = '" + observacion + "', Id_Doctor = '" + id_doctor + "', Id_Servicio = '" + id_servicio + "', Fecha_Cita = '" + fecha.ToString("yyyy-MM-dd") + "', Hora_Cita = '" + hora.ToString("yyyy-MM-dd HH:mm:ss") + "', Hora__fin_Cita = '" + hora_fin.ToString("yyyy-MM-dd HH:mm:ss") + "', Atendida = '" + atendida + "' WHERE Id = " + id + "", con.conexion);
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
        public bool modificar_cita_atendida(string id,  bool atendida)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE CitaPaciente SET Atendida = '" + atendida + "' WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_cita_atendida'. " + ex.Message);
            }
        }
        public DataTable obtener_datos(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CitaPaciente WHERE Id = " + id + "", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }
        public DataTable buscar(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id,Id_Paciente,Fecha_Cita,Hora_Cita,Observacion,Estado,Fecha_Sistema,Atendida FROM CitaPaciente", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id,Id_Paciente,Fecha_Cita,Hora_Cita,Observacion,Estado,Fecha_Sistema,Atendida FROM CitaPaciente", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id,Id_Paciente,Fecha_Cita,Hora_Cita,Observacion,Estado,Fecha_Sistema,Atendida FROM CitaPaciente", con.conexion);

                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar'. " + ex.Message);
            }
        }
    }
}
