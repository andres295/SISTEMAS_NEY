using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleados
    {
        string texto = "Hubo un problema en la capa DEmpleados";
        DConexion con;

        public int verificar_ced(string ced)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Empleados WHERE Cedula = '" + ced + "'", con.conexion);
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

        public bool eliminar(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Empleados WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string ced, string empleado, string genero, DateTime nacim, string prof, string direc, string telef)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Empleados SET Cedula = '" + ced + "', Nombres_Apellidos = '" + empleado + "', Genero = '" + genero + "', Nacimiento = '" + nacim + "', Profesion = '" + prof + "', Direccion = '" + direc + "', Telefono = '" + telef + "' WHERE Id = " + id + "", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Empleados WHERE Id = " + id + "", con.conexion);
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

        public bool guardar(string ced, string empleado, string genero, DateTime nacim, string profes, string direc, string telef)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Empleados VALUES('" + ced + "', '" + empleado + "', '" + genero +"', '" + nacim + "', '" + profes + "', '" + direc + "', '" + telef + "')", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Cedula AS CÉDULA, Nombres_Apellidos AS EMPLEADO, Genero AS GÉNERO, Nacimiento AS NACIMIENTO, Profesion AS PROFESIÓN, Telefono AS TELÉFONO, Direccion AS DIRECCIÓN FROM Empleados", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Cedula AS CÉDULA, Nombres_Apellidos AS EMPLEADO, Genero AS GÉNERO, Nacimiento AS NACIMIENTO, Profesion AS PROFESIÓN, Telefono AS TELÉFONO, Direccion AS DIRECCIÓN FROM Empleados", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Cedula AS CÉDULA, Nombres_Apellidos AS EMPLEADO, Genero AS GÉNERO, Nacimiento AS NACIMIENTO, Profesion AS PROFESIÓN, Telefono AS TELÉFONO, Direccion AS DIRECCIÓN FROM Empleados WHERE Cedula LIKE '%" + dato + "%' OR Nombres_Apellidos LIKE '%" + dato + "%' OR Genero LIKE '%" + dato + "%' OR Nacimiento LIKE '%" + dato + "%' OR Profesion LIKE '%" + dato + "%' OR Direccion LIKE '%" + dato + "%' OR Telefono LIKE '%" + dato + "%'", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Empleados", con.conexion);
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
        public int emp_by_name(string name)
        {
            try
            {
                DataTable dt = new DataTable();
                int id_servicio = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id FROM [dbo].[Empleados] WHERE Nombres_Apellidos = '" + name + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        id_servicio = int.Parse(dt.Rows[0]["Id"].ToString());
                    }
                    else { id_servicio = 0; }

                    con.desconectar();
                }
                return id_servicio;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nombres_Apellidos Doctor FROM Empleados ORDER BY Nombres_Apellidos", con.conexion);
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
