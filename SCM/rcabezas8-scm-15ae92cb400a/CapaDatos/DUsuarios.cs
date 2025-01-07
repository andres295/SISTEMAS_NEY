using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuarios
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DUsuarios";

        public bool validar_login(int id_user, string pass)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Cantidad FROM Usuarios WHERE Id = " + id_user + " AND Contraseña = '" + pass + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'validar_login'. " + ex.Message);
            }
        }

        public DataTable listar()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();
                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Usuario FROM Usuarios WHERE Estado = 'ACTIVO' ORDER BY Usuario", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'listar'. " + ex.Message);
            }
        }

        public bool guardar(string user, string pass, string tipo, string est,string usuariosql)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios VALUES('" + user + "', '" + pass + "', '" + tipo + "', '" + est + "', '" + usuariosql + "')", con.conexion);
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

        public bool modificar(int id, string user, string pass, string tipo, string est,string usuariosql)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Usuario = '" + user + "', Contraseña = '" + pass + "', Tipo_Usuario = '" + tipo + "', Estado = '" + est + "', UsuarioSQL = '" + usuariosql + "' WHERE Id = " + id + "", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuarios WHERE Id = " + id + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

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
        public DataTable buscarUsuarioLimitado(string dato, int id_usuario_actual)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();
                SqlDataAdapter da;

                if (con.conectar())
                {
                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Usuario AS USUARIO, Contraseña AS CONTRASEÑA, Tipo_Usuario AS TIPO, Estado AS ESTADO FROM Usuarios WHERE Estado = 'ACTIVO' AND Tipo_Usuario = 'CIERTO ACCESO' AND Id <> '" + id_usuario_actual + "'", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Usuario AS USUARIO, Contraseña AS CONTRASEÑA, Tipo_Usuario AS TIPO, Estado AS ESTADO FROM Usuarios WHERE Estado = 'ACTIVO' AND Tipo_Usuario = 'CIERTO ACCESO' AND Id <> '" + id_usuario_actual + "'", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Usuario AS USUARIO, '*********' AS CONTRASEÑA, Tipo_Usuario AS TIPO, Estado AS ESTADO FROM Usuarios WHERE  Estado = 'ACTIVO' and Usuario LIKE '%" + dato + "%' OR Estado LIKE '%" + dato + "%' AND Tipo_Usuario = 'CIERTO ACCESO' AND Id <> '" + id_usuario_actual + "'", con.conexion);

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
        public void eliminar(int id)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Usuarios WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar'. " + ex.Message);
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
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Usuario AS USUARIO, Contraseña AS CONTRASEÑA, Tipo_Usuario AS TIPO, Estado AS ESTADO FROM Usuarios WHERE Estado = 'ACTIVO'", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Usuario AS USUARIO, Contraseña AS CONTRASEÑA, Tipo_Usuario AS TIPO, Estado AS ESTADO FROM Usuarios WHERE Estado = 'ACTIVO'", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Usuario AS USUARIO, '*********' AS CONTRASEÑA, Tipo_Usuario AS TIPO, Estado AS ESTADO FROM Usuarios WHERE  Estado = 'ACTIVO' and Usuario LIKE '%" + dato + "%' OR Estado LIKE '%" + dato + "%'", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Usuarios", con.conexion);
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
        public int es_administrador(int id_usuario)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Usuarios where Tipo_Usuario = 'ADMINISTRADOR' and Id = '" + id_usuario + "'", con.conexion);
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
        public void create_login_sql(string name, string password)
        { 
            try
            {
                SqlCommand cmd;
                con = new DConexion();

                if (con.conectar())
                { 
                    cmd = new SqlCommand("EXEC sp_addUser_sql '" + name.Trim() + "','" + password.Trim() + "','" + DConexion.gstrdbBaseDatos + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'create_login_sql'. " + ex);
            }
        }
    }
}
