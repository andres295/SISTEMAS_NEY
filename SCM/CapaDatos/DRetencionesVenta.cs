using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DRetencionesVenta
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DRetencionesVenta";

        public DataTable Cargar_PorcentajeIva(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (id<=0)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Descripcion,Id FROM PorcentajeIva WITH (NOLOCK)  Where Estado = 1  ORDER BY Id", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text; 
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PorcentajeIva WITH (NOLOCK)  Where Id = '" + id +"' and Estado = 1 ORDER BY Id", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                   
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Cargar_PorcentajeIva'. " + ex.Message);
            }
        }
        public DataTable Cargar_PorcentajeRenta(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (id <= 0)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Descripcion +' - ' +cast(PorcRetencion as varchar(50)) +'%'Descripcion,Id FROM TBLCatalogosGenerales WITH (NOLOCK)  Where Estado = 1 and TipoCatalogo = 1  ORDER BY Id", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLCatalogosGenerales WITH (NOLOCK)  Where Id = '" + id + "' and Estado = 1 and TipoCatalogo = 1   ORDER BY Id", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Cargar_PorcentajeIva'. " + ex.Message);
            }
        }
        public int Agregar_det_tmp_retencion(string impuestoRetener, int idValorImpuesto,decimal porcRetencion,decimal baseimponible, decimal valorretenido, int idUsuario)
        { 
            try
            {
                con = new DConexion();
                int result = 0;

                if (con.conectar())
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("INSERT INTO TmpRetencionesVentaDet (ImpuestoRetener, ValorImpuesto, BaseImponible , PorcRetencion, ValorRetenido , IdUsuario) VALUES('" + impuestoRetener + "','" + idValorImpuesto + "','" + baseimponible.ToString().Replace(",", ".") + "','" + porcRetencion.ToString().Replace(",", ".") + "','" + valorretenido.ToString().Replace(",", ".") + "','" + idUsuario + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                    con.desconectar();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'agregar_det_tmp_retencion'. " + ex.Message); 
            }
        }
        public DataTable Obtener_Det_TMP_Retenciones(int idUsuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT det.Id,  case when  ImpuestoRetener = '1' THEN 'RENTA' when   ImpuestoRetener = '2' then 'IVA'  when ImpuestoRetener = '3' THEN 'ISD' else 'OTROS'  end as ImpuestoRetener,case when  ImpuestoRetener = '1' THEN cat.Descripcion when   ImpuestoRetener = '2' then porcIva.Descripcion  when ImpuestoRetener = '3' THEN 'ISD' else 'N/A'  end as ValorImpuesto,det.PorcRetencion,BaseImponible, ValorRetenido  FROM TmpRetencionesVentaDet det WITH (NOLOCK)  LEFT JOIN dbo.TBLCatalogosGenerales cat on valorimpuesto = cat.id LEFT JOIN dbo.PorcentajeIva porcIva on valorimpuesto = porcIva.id Where idUsuario = '" + idUsuario + "'  ORDER BY Id", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt); 
                    con.desconectar();
                } 
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Det_TMP_Retenciones'. " + ex.Message);
            }
        }
        public DataTable Obtener_Det_Retenciones(int idRetencion)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT det.Id,   ImpuestoRetener codigo, case when  ImpuestoRetener = '1' THEN cat.CodAnexo when   ImpuestoRetener = '2' then porcIva.Codigo  when ImpuestoRetener = '3' THEN 'ISD' else '0'  end as codigoRetencion ,baseImponible, det.PorcRetencion porcentajeRetener,valorRetenido  FROM RetencionesSRIDet det WITH (NOLOCK)  LEFT JOIN dbo.TBLCatalogosGenerales cat on valorimpuesto = cat.id LEFT JOIN dbo.PorcentajeIva porcIva on valorimpuesto = porcIva.id Where IdRetencion =   '" + idRetencion + "'  ORDER BY Id", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Det_TMP_Retenciones'. " + ex.Message);
            }
        }
        public bool Delete_Det_TMP_Retenciones(int idUsuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TmpRetencionesVentaDet WHERE idUsuario = '" + idUsuario + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Delete_Det_TMP_Retenciones'. " + ex.Message);
            }
        }
        public bool DeleteRetencion(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE RetencionesSRI WHERE id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("DELETE RetencionesSRIDet WHERE IdRetencion = '" + id + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'DeleteRetencion'. " + ex.Message);
            }
        }
        public bool UpdateClaveAccesoRetencion(int id, string claveAcceso )
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE RetencionesSRI SET  ClaveAcceso = '" + claveAcceso + "' WHERE  id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'UpdateClaveAccesoRetencion'. " + ex.Message);
            }
        }
        public bool Delete_Det_TMP_Retenciones_by_id(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TmpRetencionesVentaDet WHERE Id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Delete_Det_TMP_Retenciones_by_id'. " + ex.Message);
            }
        }
        public DataTable Agregar_Retencion(DateTime Fecha, int IdCliente, DateTime FechaEmision,string TipoDocumento,string NumDocumento,DateTime PeriodoFiscal,int IdUsuarioRegistro)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC SP_Incluir_Retenciones_Venta '" + Fecha.ToShortDateString() + "','" + IdCliente + "','" + FechaEmision.ToShortDateString() + "','" + TipoDocumento + "','" + NumDocumento + "','" + PeriodoFiscal.ToShortDateString() + "','" + IdUsuarioRegistro + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;  
                    da.Fill(dt);
                     
                    /*Se actualiza el estado de la factura*/
                    SqlCommand cmd;
                    cmd = new SqlCommand("exec SP_Cancelar_Factura_CXC '" + NumDocumento + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Agregar_Retencion'. " + ex.Message);
            }
        }
    }
}
