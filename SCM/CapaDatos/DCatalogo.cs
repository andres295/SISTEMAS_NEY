using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DCatalogo
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DCatalogo";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion FROM Catalogo ORDER BY Descripcion", con.conexion);
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
        public DataTable cargar_cmb_by_tipo(int idTipo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion, Codigo+'-'+Descripcion DesCod FROM Catalogo where IdTipoCatalogo = '" + idTipo + "' and Estado = 1 Order by Id asc", con.conexion);
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
        public DataTable cargar_tipo_catalogo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion FROM CatalogoTipo", con.conexion);
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
        public DataTable lista_combo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion  FROM Catalogo where Estado = 1 ORDER BY Descripcion", con.conexion);
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
        public DataTable obtener_datos(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Catalogo WHERE Id = " + id + "", con.conexion);
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
        public DataTable obtener_datos_by_tipe(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Catalogo WHERE IdTipoCatalogo = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("UPDATE Catalogo Set Estado = 0  WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string Descripcion, int idTipoCatalogo, bool estado, string codigo)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Catalogo SET Descripcion = '" + Descripcion + "', Estado = '" + estado + "', IdTipoCatalogo = '" + idTipoCatalogo + "', Codigo = '" + codigo + "' WHERE Id = '" + id + "'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Catalogo WHERE Descripcion = '" + id + "'", con.conexion);
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
        public bool verificar_si_existe_tipo_catalogo(string tipoCatalogo)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CatalogoTipo WHERE Descripcion = '" + tipoCatalogo + "'", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Descripcion AS Descripcion,'' Tipo, Estado AS ESTADO, Fecha_Registro AS [FECHA REGISTRO],CODIGO FROM Catalogo", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Catalogo.Id AS ID, Catalogo.Descripcion AS Descripcion, tc.Descripcion Tipo, Catalogo.Estado AS ESTADO, Catalogo.Fecha_Registro AS [FECHA REGISTRO],CODIGO FROM Catalogo left join CatalogoTipo tc on Catalogo.IdTipoCatalogo = tc.Id", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Catalogo.Id AS ID, Catalogo.Descripcion AS Descripcion,tc.Descripcion Tipo, Catalogo.Estado AS ESTADO, Catalogo.Fecha_Registro AS [FECHA REGISTRO],CODIGO FROM Catalogo left join CatalogoTipo tc on Catalogo.IdTipoCatalogo = tc.Id WHERE Catalogo.Descripcion LIKE '%" + dato + "%' OR Catalogo.Codigo LIKE '%" + dato + "%'", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Catalogo", con.conexion);
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

        public bool guardar(string Descripcion, int idTipoCatalogo, string codigo)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Catalogo (Descripcion,IdTipoCatalogo,Codigo) VALUES('" + Descripcion + "','" + idTipoCatalogo + "','" + codigo + "')", con.conexion);
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
        public DataTable obtener_Catalogo_by_medico(string id, string filtro)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Catalogo_medico '" + id + "','" + filtro + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_Catalogo_by_medico'. " + ex.Message);
            }
        }
        public string obtener_Catalogo_by_medico_by_id(string id, bool tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();
                string composicion = "";

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Catalogo_medico_By_Id '" + id + "','" + tipo + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                    if (dt.Rows.Count > 0)
                    {
                        composicion = dt.Rows[0]["Descripcion"].ToString();
                    }
                }
                return composicion;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_Catalogo_by_medico_by_id'. " + ex.Message);
            }
        }
        public bool asignar_quitar_Catalogo_medico(string Id_medico, string id_Catalogo, string accion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("EXEC sp_Accion_Catalogo_Medico '" + Id_medico + "', '" + id_Catalogo + "','" + accion + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'asignar_quitar_Catalogo_medico'. " + ex.Message);
            }
        }
    }
}
