using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DComprobantesSRI
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DComprobantesSRI";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ComprobantesSRI ORDER BY Id", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ComprobantesSRI WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(string ClaveAcceso,string FechaEmision,string FechaAutorizacion,string FechaDevolucion,string FechaRechazo,string UsuarioEnviaSRI,string EstadoEnvioSRI,string MensajeRecepcionSRI)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ComprobantesSRI SET FechaEmision = '" + FechaEmision + "', FechaAutorizacion = '" + FechaAutorizacion + "', FechaDevolucion = '" + FechaDevolucion + "', FechaRechazo = '" + FechaRechazo + "', UsuarioEnviaSRI = '" + UsuarioEnviaSRI + "', EstadoEnvioSRI = '" + EstadoEnvioSRI + "', MensajeRecepcionSRI = '" + MensajeRecepcionSRI + "' WHERE ClaveAcceso = " + ClaveAcceso + "", con.conexion);
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

        public bool verificar_si_existe(string claveAcceso)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM ComprobantesSRI WHERE ClaveAcceso = '" + claveAcceso + "'", con.conexion);
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

        public DataTable buscar()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("SELECT TOP 1   * FROM ParametrosSRI ORDER BY Id desc", con.conexion);
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

        public bool guardar(string ClaveAcceso , string TipoDocumento , string NumeroComprobante, string FechaDocumento  , string FechaEmision , DateTime FechaAutorizacion, string FechaDevolucion , string FechaRechazo  , string UsuarioEnviaSRI, string UsuarioGeneraDocumento, string EstadoEnvioSRI , string IdGestor   , string TotalSinImpuestos , string ImporteTotal , string MensajeRecepcionSRI,string numFactura, string ambiente, string tipoEmision)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM ComprobantesSRI WHERE ClaveAcceso = '" + ClaveAcceso + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) <=0)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO ComprobantesSRI VALUES('" + ClaveAcceso + "', '" + TipoDocumento + "', '" + NumeroComprobante + "', '" + FechaDocumento + "', '" + FechaEmision + "', getdate(), null, null, '" + UsuarioEnviaSRI + "', '" + UsuarioGeneraDocumento + "', '" + EstadoEnvioSRI + "', '" + IdGestor + "', '" + TotalSinImpuestos.ToString().Replace(",", ".") + "', '" + ImporteTotal.ToString().Replace(",", ".") + "', '" + MensajeRecepcionSRI + "', '" + numFactura + "', '" + ambiente + "', '" + tipoEmision + "')", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                        resp = true;
                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand("UPDATE ComprobantesSRI SET FechaEmision = '" + FechaEmision + "', FechaAutorizacion = '" + FechaAutorizacion + "', FechaDevolucion = null, FechaRechazo = null, UsuarioEnviaSRI = '" + UsuarioEnviaSRI + "', EstadoEnvioSRI = '" + EstadoEnvioSRI + "', MensajeRecepcionSRI = '" + MensajeRecepcionSRI + "', NoFactura = '" + numFactura + "', Ambiente = '" + ambiente + "', Emision = '" + tipoEmision + "' WHERE ClaveAcceso = " + ClaveAcceso + "", con.conexion);
                        cmd3.CommandType = CommandType.Text;
                        cmd3.ExecuteNonQuery();
                    }
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
        public DataTable buscar_comprobantes_no_enviados_a_sri(string dato, DateTime dInicio, DateTime dFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC SP_Get_Documento_Pendiento_Envio_SRI '0', '" + dInicio.ToShortDateString() + "','" + dFin.ToShortDateString() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_prod'. " + ex.Message);
            }
        }
        public DataTable buscar_comprobantes_enviados_a_sri(string dato, DateTime dInicio, DateTime dFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC SP_Get_Documento_Pendiento_Envio_SRI '1', '" + dInicio.ToShortDateString() + "','" + dFin.ToShortDateString() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_prod'. " + ex.Message);
            }
        }
        public DataTable buscar_comprobantes_retencion_enviados_a_sri(  DateTime dInicio, DateTime dFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC SP_GET_RETENCIONES   '" + dInicio.ToShortDateString() + "','" + dFin.ToShortDateString() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_comprobantes_retencion_enviados_a_sri'. " + ex.Message);
            }
        }
    }
}
