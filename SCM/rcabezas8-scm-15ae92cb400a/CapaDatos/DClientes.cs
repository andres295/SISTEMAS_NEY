using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClientes
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DClientes";
        public int verificar_ced(string ced)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Clientes WHERE Cedula = '" + ced + "'", con.conexion);
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
        public DataTable Obtener_Cliente_by_cedula(string ced)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 Id FROM Clientes WHERE RUC = '" + ced + "'", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + "verificar_ced" + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Clientes WHERE RUC = '" + ruc + "'", con.conexion);
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
        public bool validar_guardar_default(string cliente)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Clientes WHERE Nombres_Apellidos = '" + cliente + "'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Clientes VALUES('', '', '" + cliente + "', '', '', '')", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("DELETE Clientes WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string ced, string ruc, string cliente, string telef, string direc, string correo, string ciudad, int tipodocumento)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Cedula = '" + ced + "', RUC = '" + ruc + "', Nombres_Apellidos = '" + cliente + "', Telefono = '" + telef + "', Direccion = '" + direc + "', Correo = '" + correo + "', Ciudad = '" + ciudad + "', TipoDocumento = '" + tipodocumento + "' WHERE Id = " + id + "", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT cli.*,ti.Codigo FROM Clientes cli LEFT JOIN  Tipo_Identificacion ti on cli.TipoDocumento = ti.id  WHERE cli.Id = " + id + "", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Cedula AS CÉDULA, RUC, Nombres_Apellidos AS CLIENTE, Correo AS [CORREO ELECTRÓNICO], Telefono AS TELÉFONO, Direccion AS DIRECCIÓN FROM Clientes WITCH(NOLOCK)", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Cedula AS CÉDULA, RUC, Nombres_Apellidos AS CLIENTE, Correo AS [CORREO ELECTRÓNICO], Telefono AS TELÉFONO, Direccion AS DIRECCIÓN FROM Clientes WITCH(NOLOCK)", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, Cedula AS CÉDULA, RUC, Nombres_Apellidos AS CLIENTE, Correo AS [CORREO ELECTRÓNICO], Telefono AS TELÉFONO, Direccion AS DIRECCIÓN FROM Clientes WITCH(NOLOCK) WHERE Cedula LIKE '%" + dato + "%' OR RUC LIKE '%" + dato + "%' OR Nombres_Apellidos LIKE '%" + dato + "%' OR Telefono LIKE '%" + dato + "%' OR Direccion LIKE '%" + dato + "%'", con.conexion);

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
        public DataTable buscar_Cat( )
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                     
                      da = new SqlDataAdapter("SELECT Id AS ID,  Nombres_Apellidos AS CLIENTE   FROM Clientes WITCH(NOLOCK)", con.conexion);
                    
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
                con = new DConexion();
                int cant = 0;

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Clientes", con.conexion);
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

        public bool guardar(string ced, string ruc, string cliente, string telef, string direc, string correo,string ciudad, int tipodocumento)
        {
            try
            {
                con = new DConexion();
                bool resp = false;

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Clientes VALUES('" + ced + "', '" + ruc + "', '" + cliente + "', '" + telef + "', '" + direc + "', '" + correo + "', '" + ciudad + "', '" + tipodocumento + "')", con.conexion);
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
        public DataTable lista_combo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nombres_Apellidos Cliente FROM Clientes ORDER BY Nombres_Apellidos", con.conexion);
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
        public DataTable lista_combo_ciudad()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct Ciudad FROM Clientes where Ciudad is not null and len(Ciudad)>0", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo_ciudad'. " + ex.Message);
            }
        }
        public DataTable obtener_id_venta(string Num_Venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Cliente FROM FacturasPorCobrar WHERE Num_Venta = '" + Num_Venta + "'", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_id_venta'. " + ex.Message);
            }
        }
        public bool ValidaClienteEnvioSRI(string IdCliente)
        {
            try
            {
                bool flag = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("select COUNT(*) NumeroComprobante from dbo.ComprobantesSRI where /*EstadoEnvioSRI = 'AUTORIZADO' AND*/ cast(NumeroComprobante as int)  IN ((select NumeroComprobante from dbo.Ventas where Id_Cliente = '" + IdCliente + "' and NumeroComprobante is not null ))", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        flag = true;
                    }
                    con.desconectar();
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'ValidaVentaEnviadaSRI'. " + ex.Message);
            }
        }
    }
}
