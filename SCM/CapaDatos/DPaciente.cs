using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPaciente
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DPaciente";
        public int verificar_ced(string ced)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Paciente WHERE Cedula = '" + ced + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + "verificar_ced" + ex.Message);
            }
        }
        public DataTable lista_combo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nombres_Apellidos Cliente,Cedula+' - '+Nombres_Apellidos NombreCedula,Cedula FROM Paciente ORDER BY Nombres_Apellidos", con.conexion);
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
        public DataTable Obtener_Cliente_by_cedula(string ced)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 Id FROM Paciente WHERE Cedula = '" + ced + "'", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + "Obtener_Cliente_by_cedula" + ex.Message);
            }
        }
        public int verificar_ruc(string ruc)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Paciente WHERE RUC = '" + ruc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + "verificar_ruc" + ex.Message);
            }
        }
        public bool validar_guardar_default(string cliente)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Paciente WHERE Nombres_Apellidos = '" + cliente + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'validar_guardar_default'. " + ex.Message);
            }
        }
        public void guardar_default(string cliente)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Paciente VALUES('', '', '" + cliente + "', '', '', '')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_default'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("DELETE Paciente WHERE Id = " + id + "", con.conexion);
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
        public bool modificar(int id, string ced, string ruc, string cliente, string genero, DateTime nacim, string edad, string telef, string direc, string correo,string padre, int tiposangre, int estadocivl, int nacionalidad,string convencional, int instruccion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Paciente SET Cedula = '" + ced + "', RUC = '" + ruc + "', Nombres_Apellidos = '" + cliente + "', Genero = '" + genero + "', Nacimiento = '" + nacim.ToString("yyyy-MM-dd") + "', Edad = '" + edad + "', Telefono = '" + telef + "', Direccion = '" + direc + "', Correo = '" + correo + "', Padre = '" + padre + "', IdTipoSangre = '" + tiposangre + "', IdEstadoCivil = '" + estadocivl + "', IdNacionalidad = '" + nacionalidad + "', Convencional = '" + convencional + "', IdInstruccion = '" + instruccion + "' WHERE Id = " + id + "", con.conexion);
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
        public DataTable obtener_datos(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Paciente WHERE Id = " + id + "", con.conexion);
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
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS [NO.REGISTRO]/*, NULL [PRÓXIMA CITA]*/,Cedula AS CÉDULA, Nombres_Apellidos AS NOMBRES,    '' [TIPO SANGRE],'' [NACIONALIDAD],'' [ESTADO CIVIL],Correo AS [CORREO ELECTRÓNICO], Telefono AS CELULAR,Convencional CONVENCIONAL, Direccion AS DIRECCIÓN, Edad AS EDAD, Nacimiento NACIMIENTO,Genero GENERO/*, Saldo AS SALDO */ ,Foto FROM Paciente", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Paciente.Id AS[NO.REGISTRO]/*, CITAS.Fecha as [PRÓXIMA CITA]*/, Cedula AS CÉDULA, Nombres_Apellidos AS NOMBRES, TS.Descripcion[TIPO SANGRE], NA.Descripcion[NACIONALIDAD], EC.Descripcion[ESTADO CIVIL], Correo AS[CORREO ELECTRÓNICO], Telefono AS CELULAR, Convencional CONVENCIONAL, Direccion AS DIRECCIÓN, Edad AS EDAD, Nacimiento NACIMIENTO, Genero GENERO/*, Saldo AS SALDO*/, Foto  FROM Paciente  LEFT JOIN dbo.Catalogo NA ON NA.idtipocatalogo = 3 and  IdNacionalidad = NA.Id  LEFT JOIN dbo.Catalogo TS ON  ts.idtipocatalogo = 1 and IdTipoSangre = TS.Id  LEFT JOIN dbo.Catalogo EC ON ec.idtipocatalogo = 2 and IdEstadoCivil = EC.Id  LEFT JOIN(SELECT  max(cita.Fecha_Cita) fecha, cita.Id_Paciente FROM[dbo].[CitaPaciente] cita   where cast(cita.Fecha_Cita as date) >= cast(getdate() as date) and cita.Estado = 1 AND cita.Atendida = 0 group by cita.Id_Paciente) AS CITAS ON Paciente.Id = CITAS.Id_Paciente ORDER BY Paciente.Id DESC", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Paciente.Id AS[NO.REGISTRO]/*, CITAS.Fecha as [PRÓXIMA CITA]*/, Cedula AS CÉDULA, Nombres_Apellidos AS NOMBRES, TS.Descripcion[TIPO SANGRE], NA.Descripcion[NACIONALIDAD], EC.Descripcion[ESTADO CIVIL], Correo AS[CORREO ELECTRÓNICO], Telefono AS CELULAR, Convencional CONVENCIONAL, Direccion AS DIRECCIÓN, Edad AS EDAD, Nacimiento NACIMIENTO, Genero GENERO/*, Saldo AS SALDO*/ ,Foto FROM Paciente  LEFT JOIN dbo.Catalogo NA ON NA.idtipocatalogo = 3 and  IdNacionalidad = NA.Id  LEFT JOIN dbo.Catalogo TS ON  ts.idtipocatalogo = 1 and IdTipoSangre = TS.Id  LEFT JOIN dbo.Catalogo EC ON ec.idtipocatalogo = 2 and IdEstadoCivil = EC.Id  LEFT JOIN(SELECT  max(cita.Fecha_Cita) fecha, cita.Id_Paciente FROM[dbo].[CitaPaciente] cita   where cast(cita.Fecha_Cita as date) >= cast(getdate() as date) and cita.Estado = 1 AND cita.Atendida = 0 group by cita.Id_Paciente) AS CITAS ON Paciente.Id = CITAS.Id_Paciente WHERE Cedula LIKE '%" + dato + "%' OR RUC LIKE '%" + dato + "%' OR Nombres_Apellidos LIKE '%" + dato + "%' OR Telefono LIKE '%" + dato + "%' OR Direccion LIKE '%" + dato + "%' OR Cedula LIKE '%" + dato + "%' ORDER BY Paciente.Id DESC", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
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
        public DataTable citas_por_vencer()
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                     da = new SqlDataAdapter("EXEC  sp_rpt_citas_programada_por_vencer", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'citas_por_vencer'. " + ex.Message);
            }
        }
        public DataTable citas_paciente()
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC  sp_Citas_Paciente", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'citas_paciente'. " + ex.Message);
            }
        }
        public DataTable citas_by_paciente(string idcliente, DateTime finicio, DateTime ffin)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC  sp_Citas_by_Paciente '" + idcliente + "','" + finicio.ToString("yyyy-MM-dd") + "','" + ffin.ToString("yyyy-MM-dd") + "'", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'citas_by_paciente'. " + ex.Message);
            }
        }
        public DataTable examenes_generales_by_paciente(string idcliente, DateTime finicio, DateTime ffin)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC  sp_examenes_generales_by_Paciente '" + idcliente + "','" + finicio.ToString("yyyy-MM-dd") + "','" + ffin.ToString("yyyy-MM-dd") + "'", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'examenes_generales_by_paciente'. " + ex.Message);
            }
        }
        public DataTable examenes_generales_by_especialista(string idespecialista, DateTime finicio, DateTime ffin,decimal porc_comision)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC  sp_examenes_generales_by_Especialista '" + idespecialista + "','" + finicio.ToString("yyyy-MM-dd") + "','" + ffin.ToString("yyyy-MM-dd") + "','" + porc_comision.ToString().Replace(",", ".") + "'", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'examenes_generales_by_especialista'. " + ex.Message);
            }
        }
        public DataTable examenes_generales_by_especialista_grafico(string idespecialista, DateTime finicio, DateTime ffin, decimal porc_comision)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC  sp_examenes_generales_by_Especialista_Grafico '" + idespecialista + "','" + finicio.ToString("yyyy-MM-dd") + "','" + ffin.ToString("yyyy-MM-dd") + "','" + porc_comision.ToString().Replace(",", ".") + "'", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'examenes_generales_by_especialista'. " + ex.Message);
            }
        }
        public int num_reg()
        {
            try
            {
                con = new DConexion();
                int cant = 0;

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Paciente", con.conexion);
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
        public bool guardar(string ced, string ruc, string cliente, string genero, DateTime nacim, string edad,string telef, string direc, string correo,string padre, int tiposangre, int estadocivl, int  nacionalidad,string convencional, int instruccion,string foto)
        { 
            try
            {
                con = new DConexion();
                bool resp = false;
              
                if (con.conectar())
                {
                   
                    SqlCommand cmd = new SqlCommand("INSERT INTO Paciente VALUES('" + ced + "', '" + ruc + "', '" + cliente + "', '" + telef + "', '" + direc + "', '" + correo + "', 0, '" + edad + "', '" + nacim.ToString("yyyy-MM-dd") + "', '" + genero + "', '" + padre + "', '" + tiposangre + "', '" + estadocivl + "', '" + nacionalidad + "', '" + convencional + "', '" + instruccion + "', '" + foto + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message + nacim.ToString("yyyy-MM-dd") + nacim.ToString("yyyy-MM-dd"));
            }
        }
        public int paciente_by_name(string name)
        {
            try
            {
                DataTable dt = new DataTable();
                int id_cliente = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id FROM [dbo].[Paciente] WHERE Nombres_Apellidos = '" + name.Trim() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        id_cliente = int.Parse(dt.Rows[0]["Id"].ToString());
                    }
                    else { id_cliente = 0; }

                    con.desconectar();
                }
                return id_cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cliente_by_name'. " + ex.Message);
            }
        }
        public int paciente_by_cedula(string cedula)
        {
            try
            {
                DataTable dt = new DataTable();
                int id_cliente = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 Id FROM [dbo].[Paciente] WHERE Cedula = '" + cedula + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        id_cliente = int.Parse(dt.Rows[0]["Id"].ToString());
                    }
                    else { id_cliente = 0; }

                    con.desconectar();
                }
                return id_cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cliente_by_cedula'. " + ex.Message);
            }
        }
        public string get_genero_paciente(string idPaciente)
        {
            try
            {
                DataTable dt = new DataTable();
                string genero_paciente = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 ISNULL(Genero,'N/A') Genero FROM [dbo].[Paciente] WHERE Id = '" + idPaciente + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        genero_paciente = dt.Rows[0]["Genero"].ToString();
                    }
                    else { genero_paciente = "N/A"; }

                    con.desconectar();
                }
                return genero_paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'get_genero_paciente'. " + ex.Message);
            }
        }
        public void actualizar_foto(string id, string foto)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Paciente SET Foto = '" + foto + "' WHERE id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_foto'. " + ex.Message);
            }
        }
        public string obtener_img_prod(string id)
        {
            try
            {
                string img = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Foto FROM Paciente WHERE  Id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    img = cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return img;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_img_prod'. " + ex.Message);
            }
        }
    }
}
