using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DAjusteTecla
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DAjusteTecla";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT [Id],[F1],[F2],[F3],[F4],[F5],[F6],[F7],[F8],[F9],[F10],[F11] ,[F12],[Id_Usuario] FROM AjusteTecla ORDER BY Id_Usuario", con.conexion);
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

        public DataTable obtener_datos(int id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT [Id],[F1],[F2],[F3],[F4],[F5],[F6],[F7],[F8],[F9],[F10],[F11] ,[F12],[Id_Usuario] FROM AjusteTecla   WHERE Id_Usuario = " + id_usuario + "", con.conexion);
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

        public bool modificar(int id_usuario, string f1, string f2, string f3, string f4,string f5,string f6, string f7, string f8, string f9,string f10,string f11,string f12)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE AjusteTecla SET  [F1] = '" + f1 + "',[F2] = '" + f2 + "',[F3] = '" + f3 + "',[F4] = '" + f4 + "',[F5] = '" + f5 + "',[F6] = '" + f6 + "',[F7] = '" + f7 + "',[F8] = '" + f8 + "',[F9] = '" + f9 + "',[F10] = '" + f10 + "',[F11] = '" + f11 + "' ,[F12] = '" + f12 + "' where Id_Usuario = '" + id_usuario + "'", con.conexion);
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

        public bool verificar_si_existe(int id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM AjusteTecla WHERE Id_Usuario = '" + id_usuario + "'", con.conexion);
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

        public DataTable buscar(int id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("SELECT [Id],[F1],[F2],[F3],[F4],[F5],[F6],[F7],[F8],[F9],[F10],[F11] ,[F12],[Id_Usuario] FROM AjusteTecla where Id_Usuario = '"+ id_usuario + "'", con.conexion);
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

        public bool guardar(int id_usuario, string f1, string f2, string f3, string f4, string f5, string f6, string f7, string f8, string f9, string f10, string f11, string f12)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO AjusteTecla (F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F12,Id_Usuario) VALUES('" + f1 + "', '" + f2 + "', '" + f3 + "', '" + f4 + "', '" + f5 + "', '" + f6 + "', '" + f7 + "', '" + f8 + "', '" + f9 + "', '" + f10 + "', '" + f11 + "', '" + f12 + "', '" + id_usuario + "')", con.conexion);
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
    }
}
