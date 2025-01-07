using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DParametrosSRI
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DParametrosSRI";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, RazonSocial FROM ParametrosSRI ORDER BY RazonSocial", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ParametrosSRI WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id,bool ServicioSRActivo, string Ambiente, string TipoEmision, string TipoDocumentoFactura, string RazonSocial, string NombreComercial, string Codestablecimiento, string Codpuntoemision, string DirMatri, string DirEstablecimiento, string ObligadoContabilidad, string CodigoNumerico, string Moneda, DateTime licenciaDesde, DateTime licenciaHasta,string regimen,string correoSMTP, string passwordSMTP,string rutaxml ,string impresora, string urlSRI,string TipoDocumentoRetencion, bool EsAgenteRetencion, string CodigoAgenteRetencion,string NumContribuyente,decimal montominimo,string codDocSustento)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ParametrosSRI SET ServicioSRActivo = '" + ServicioSRActivo + "', Ambiente = '" + Ambiente + "', TipoEmision = '" + TipoEmision + "', TipoDocumentoFactura = '" + TipoDocumentoFactura + "', RazonSocial = '" + RazonSocial + "', NombreComercial = '" + NombreComercial + "', Codestablecimiento = '" + Codestablecimiento + "', Codpuntoemision = '" + Codpuntoemision + "', DirMatri = '" + DirMatri + "', DirEstablecimiento = '" + DirEstablecimiento + "', ObligadoContabilidad = '" + ObligadoContabilidad + "', CodigoNumerico = '" + CodigoNumerico + "', Moneda = '" + Moneda + "',VigenciaLicenciaDesde = '" + licenciaDesde.ToShortDateString() + "',VigenciaLicenciaHasta = '" + licenciaHasta.ToShortDateString() + "',Regimen = '" + regimen + "',CorreoSMTP = '" + correoSMTP + "',ContrasenaSMTP = '" + passwordSMTP + "',RutaXML = '" + rutaxml + "',ImpresoraTickets ='" + impresora.Trim() + "',URL_SRI_LOCAL ='" + urlSRI.Trim() + "',TipoDocumentoRetencion ='" + TipoDocumentoRetencion.Trim() + "',EsAgenteRetencion ='" + EsAgenteRetencion + "',CodigoAgenteRetencion ='" + CodigoAgenteRetencion.Trim() + "',NumContribuyente ='" + NumContribuyente.Trim() + "',MontoMinimoConsumidorFinal ='" + montominimo.ToString().Replace(",", ".") + "',codDocSustento ='" + codDocSustento + "' WHERE Id = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM ParametrosSRI WHERE Id = '" + id + "'", con.conexion);
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
                    da = new SqlDataAdapter("SELECT TOP 1  * FROM ParametrosSRI ORDER BY Id desc", con.conexion);
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

        public bool guardar(bool ServicioSRActivo, string Ambiente, string TipoEmision, string TipoDocumentoFactura, string RazonSocial, string NombreComercial, string Codestablecimiento, string Codpuntoemision, string DirMatri, string DirEstablecimiento, string ObligadoContabilidad, string CodigoNumerico, string Moneda, DateTime licenciaDesde, DateTime licenciaHasta,string regimen,string correoSMTP,string passwordSMTP,string RutaXML,string impresora, string urlSRI, string TipoDocumentoRetencion, bool EsAgenteRetencion, string CodigoAgenteRetencion, string NumContribuyente, decimal montominimo,string codDocSustento)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ParametrosSRI VALUES('" + ServicioSRActivo + "', '" + Ambiente + "', '" + TipoEmision + "', '" + TipoDocumentoFactura + "', '" + RazonSocial + "', '" + NombreComercial + "', '" + Codestablecimiento + "', '" + Codpuntoemision + "', '" + DirMatri + "', '" + DirEstablecimiento + "', '" + ObligadoContabilidad + "', '" + CodigoNumerico + "', '" + Moneda + "', '" + licenciaDesde.ToShortDateString() + "', '" + licenciaHasta.ToShortDateString() + "', '" + regimen + "', '" + correoSMTP + "', '" + passwordSMTP + "', '" + RutaXML + "','" + impresora.Trim() + "','" + urlSRI.Trim() + "','" + TipoDocumentoRetencion.Trim() + "','" + EsAgenteRetencion + "','" + CodigoAgenteRetencion.Trim() + "','" + NumContribuyente.Trim() + "','" + montominimo.ToString().Replace(",", ".") + "','" + codDocSustento+ "')", con.conexion);
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

    }
}
