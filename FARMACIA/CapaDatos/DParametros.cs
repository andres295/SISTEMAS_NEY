using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DParametros
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DParametros";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nombre_Empresa FROM Parametros ORDER BY Nombre_Empresa", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Parametros WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string nombre, string telef, string correo, string direc,string ruc,string alias, string ruta_imagen, string ruta_backup,int numItem,string alto_factura,bool automatico, DateTime dtInicio, DateTime dtFin,int stock_producto, int Dia_Vencimiento,string num_ventana, DateTime finicio, DateTime ffin)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Parametros SET Nombre_Empresa = '" + nombre + "', Telefono = '" + telef + "', Correo = '" + correo + "', Direccion = '" + direc + "', Ruc = '" + ruc + "', Alias = '" + alias + "', Ruta_Imagen = '" + ruta_imagen + "', Ruta_Backup = '" + ruta_backup + "', NumItem = '" + numItem + "', Alto_Print_Factura = '" + alto_factura + "', BK_Automatico = '" + automatico + "', BK_Desde = '"+ dtInicio.ToString("yyyy-MM-dd") + "', BK_Hasta = '" + dtFin.ToString("yyyy-MM-dd") + "', Stock_producto = '" + stock_producto + "', Dia_Vencimiento = '" + Dia_Vencimiento + "', NumVentanaVenta = '" + num_ventana + "', NVIA = '" + Encriptar(finicio.ToString("yyyy-MM-dd")) + "', NVIB = '" + Encriptar(ffin.ToString("yyyy-MM-dd")) + "'  WHERE Id = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Parametros WHERE Id = '" + id + "'", con.conexion);
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
                    da = new SqlDataAdapter("SELECT TOP 1 Id , Nombre_Empresa , Telefono , Correo, Direccion,Ruc,Alias,Ruta_Imagen,Ruta_Backup,NumItem,Alto_Print_Factura,BK_Automatico,BK_Desde, BK_Hasta,Stock_producto,Dia_Vencimiento,NumVentanaVenta,NVIA,NVIB FROM Parametros ORDER BY Id desc", con.conexion);
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

        public bool guardar(string nombre, string telef, string correo, string direc, string ruc, string alias, string ruta_imagen, string ruta_backup,int numItem,string alto_factura,bool automatico,DateTime dtInicio, DateTime dtFin,int stock_producto,int Dia_Vencimiento,string numventana, DateTime finicio, DateTime ffin)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Parametros VALUES('" + nombre + "', '" + telef + "', '" + correo + "', '" + direc + "', '" + ruc + "', '" + alias + "', '" + ruta_imagen + "', '" + ruta_backup + "', '" + numItem + "', '" + alto_factura + "', '" + automatico + "', '" + dtFin.ToString("yyyy-MM-dd") + "', '" + dtFin.ToString("yyyy-MM-dd") + "', '" + stock_producto + "', '" + Dia_Vencimiento + "', '" + numventana + "', '" + Encriptar(finicio.ToString("yyyy-MM-dd")) + "', '" + Encriptar(ffin.ToString("yyyy-MM-dd")) + "')", con.conexion);
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
        public string getParametro(string parametro)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("exec sp_Get_Parametro '" + parametro + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
                if (dt.Rows.Count>0)
                {
                    return dt.Rows[0]["Parametro"].ToString();
                }
                else { return ""; }
               
            }
            catch (Exception)
            {
                return "";
            }
        }
        public bool backup_bd(string name_bd,bool automatico)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("exec sp_Backup_BD '" + name_bd + "','" + automatico +"'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'backup_bd'. " + ex.Message);
            }
        }
        /// Encripta una cadena
        public string Encriptar(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(value);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(value);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
