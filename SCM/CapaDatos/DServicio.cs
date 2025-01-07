using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DServicio
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DServicio";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Servicio FROM Servicios ORDER BY Servicio", con.conexion);
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

        public DataTable obtener_datos(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Servicios WHERE Id = " + id + "", con.conexion);
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

        public bool eliminar(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Servicios SET Estado = 0 WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string Servicio, decimal costo, bool estado , string descripcion,string tiempo_ejecucion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Servicios SET Servicio = '" + Servicio + "', Costo = '" + costo.ToString() + "', Estado = '" + estado + "', Descripcion = '" + descripcion + "',Tiempo_Ejecucion = '" + tiempo_ejecucion + "' WHERE Id = '" + id + "'", con.conexion);
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

        public bool verificar_si_existe(string id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Servicios WHERE Servicio = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_si_existe'. " + ex.Message);
            }
        }

        public DataTable buscar(string dato) 
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Servicio AS Servicios, Costo AS Costo, Descripcion AS Descripcion, Estado AS Estado FROM Servicios", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Servicio AS Servicio, Costo AS Costo, Descripcion AS Descripcion, Estado AS Estado FROM Servicios", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Servicio AS Servicio, Costo AS Costo, Descripcion AS Descripcion, Estado AS Estado FROM Servicios WHERE Servicio LIKE '%" + dato + "%'", con.conexion);
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
        public DataTable buscar_by_estado(string dato, bool estado)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Servicio AS Servicios, Costo AS Costo, Descripcion AS Descripcion, Estado AS Estado FROM Servicios where estado = '"+ estado +"'", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Servicio AS Servicio, Costo AS Costo, Descripcion AS Descripcion, Estado AS Estado FROM Servicios where estado = '" + estado + "'", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Servicio AS Servicio, Costo AS Costo, Descripcion AS Descripcion, Estado AS Estado FROM Servicios WHERE estado = '" + estado + "' and Servicio  LIKE '%" + dato + "%'", con.conexion);
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
        public int num_reg()
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Servicios", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg'. " + ex.Message);
            }
        }

        public bool guardar(string servicio, decimal costo, string descripcion,string  tiempo_ejecucion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Servicios (Servicio,Costo,Descripcion,Tiempo_Ejecucion) VALUES('" + servicio + "', '" + costo.ToString() + "', '" + descripcion + "', '" + tiempo_ejecucion + "')", con.conexion);
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
        public DataTable lista_combo(string tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (tipo == "TODOS")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Servicio + ': COSTO:' + CAST(Costo AS VARCHAR) AS Servicio FROM Servicios where Estado = 1  ORDER BY Servicio", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Servicio + ': COSTO:' + CAST(Costo AS VARCHAR) AS Servicio FROM Servicios where Estado = 1 and  Id not in (select Id_Orden from[dbo].[Det_FacturaCxC_temp] where Estado = 1 and Id_Orden is not null  UNION ALL select Id_Orden from[dbo].[Det_FacturaCxC] where Estado = 1 and Id_Orden is not null)  ORDER BY Servicio", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt); 
                    }
                     
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
            }
        }
        public DataTable lista_combo_2()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Servicio FROM dbo.Servicios", con.conexion);
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
        public int  servicio_by_name(string name)
        {
            try
            {
                DataTable dt = new DataTable();
                int id_servicio = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id FROM [dbo].[Servicios] WHERE Servicio = '"+ name + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    if (dt.Rows.Count>0)
                    {
                        id_servicio =  int.Parse(dt.Rows[0]["Id"].ToString());
                    }else { id_servicio = 0; }
                 
                    con.desconectar(); 
                }
                return id_servicio;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
            }
        }
        public DataTable lista_tiempo_servicio(string id_servicio)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT  isnull(Tiempo_Ejecucion,0) Tiempo_Ejecucion FROM [dbo].[Servicios] WHERE Id = '" + id_servicio + "'" , con.conexion);
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
    }
}
