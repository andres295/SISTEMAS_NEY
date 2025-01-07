using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEspecificacion
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DEspecificacion";

        public DataTable lista_combo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Especificacion FROM Especificaciones ORDER BY Especificacion", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Especificaciones WHERE Id = '" + id + "'", con.conexion);
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
        public int num_reg()
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Especificaciones", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Especificacion AS ESPECIFICACIÓN FROM Especificaciones", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Especificacion AS ESPECIFICACIÓN FROM Especificaciones", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Especificacion AS ESPECIFICACIÓN FROM Especificaciones WHERE Especificacion LIKE '%" + dato + "%'", con.conexion);

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
        public int validar_relacion(int id)

        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Productos WHERE Id_Especificacion = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'validar_relacion'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("DELETE Especificaciones WHERE Id = " + id + "", con.conexion);
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

        public int verificar_si_existe(string especif)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Especificaciones WHERE Especificacion LIKE '" + especif + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_si_existe'. " + ex.Message);
            }
        }

        public bool modificar(int id, string especif)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Especificaciones SET Especificacion = '" + especif + "' WHERE Id = " + id + "", con.conexion);
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

        public bool guardar(string especif)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Especificaciones VALUES('" + especif + "')", con.conexion);
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
    }
}
