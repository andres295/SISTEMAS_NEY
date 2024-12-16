using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DCatalogosGenerales
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DCatalogosGenerales";

        public DataTable cargar_cmb(int tipoCatalogo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {  
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion , PorcRetencion , CodAnexo ,Estado, Fecha_Registro FROM TBLCatalogosGenerales WITH (NOLOCK) WHERE TipoCatalogo = " + tipoCatalogo +" ORDER BY Id", con.conexion);
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
        public DataTable cargar_cmb_by_id(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion , ISNULL(PorcRetencion,0) PorcRetencion , CodAnexo ,Estado, Fecha_Registro FROM TBLCatalogosGenerales WITH (NOLOCK) WHERE Id = " + id +"", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb_by_id'. " + ex.Message);
            }
        }
        public DataTable buscar(int tipocatalogo,string Descripcion)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (Descripcion != "")
                    {
                        if (Descripcion == "*")
                        {
                            Descripcion = "";
                        }
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion , PorcRetencion , CodAnexo ,Estado, Fecha_Registro FROM TBLCatalogosGenerales WITH (NOLOCK) WHERE Descripcion like  '%" + Descripcion + "%' and  TipoCatalogo = " + tipocatalogo + "", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 0 Id, Descripcion , PorcRetencion , CodAnexo ,Estado, Fecha_Registro FROM TBLCatalogosGenerales WITH (NOLOCK) WHERE Id = 0", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    
                    con.desconectar();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb_by_id'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("UPDATE TBLCatalogosGenerales Set Estado = 0  WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string Descripcion, decimal PorcRetencion,string CodAnexo, bool estado)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE TBLCatalogosGenerales SET Descripcion = '" + Descripcion + "', PorcRetencion = '" + PorcRetencion + "', CodAnexo = '" + CodAnexo + "',Estado = '" + estado + "' WHERE Id = '"+ id +"'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM TBLCatalogosGenerales WHERE Id = '" + id + "'", con.conexion);
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
        public int num_reg(int tipoCatalogo)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM TBLCatalogosGenerales WHERE TipoCatalogo = " + tipoCatalogo + "", con.conexion);
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

        public bool guardar( int TipoCatalogo, string Descripcion, decimal PorcRetencion, string CodAnexo)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBLCatalogosGenerales (TipoCatalogo,Descripcion,PorcRetencion,CodAnexo) VALUES('" + TipoCatalogo + "','" + Descripcion + "','" + PorcRetencion.ToString().Replace(",", ".") + "','" + CodAnexo + "')", con.conexion);
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
