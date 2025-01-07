using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DIVA
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DIVA";

        public void aplicar_quitar_general(string iva)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DISABLE TRIGGER tgr_update_stock ON Productos; UPDATE Productos SET IVA = " + iva.Replace(",", ".") + "; ENABLE TRIGGER tgr_update_stock ON Productos;", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " 'aplicar_quitar_general'. " + ex.Message);
            }
        }        

        public void aplicar_quitar_todos(int id_prov, string iva)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET IVA = " + iva.Replace(",", ".") + " WHERE Id_Proveedor = " + id_prov + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " 'aplicar_quitar_todos'. " + ex.Message);
            }
        }
        public void aplicar_quitar_pvp_todos(int id_prov, bool aplicar  )
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET Pvp_Iva = '" + aplicar + "' WHERE Id_Proveedor = " + id_prov + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " 'aplicar_quitar_todos'. " + ex.Message);
            }
        }
        public void aplicar_quitar_sel(string id, string iva)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET IVA = " + iva.Replace(",", ".") + " WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " 'aplicar_quitar_sel'. " + ex.Message);
            }
        }
        public void aplicar_quitar_pvp_sel(string id,bool aplicar)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET Pvp_Iva = '"+ aplicar + "' WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " 'aplicar_quitar_sel'. " + ex.Message);
            }
        }

        public DataTable buscar_prod(int id_prov,string datos)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    if (datos == "")
                    {
                        if (id_prov == 0)
                            da = new SqlDataAdapter("SELECT TOP(0) Id AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Id_Presentacion AS PRESENTACIÓN, Id_Proveedor AS PROVEEDOR, '' AS DISPONIBLE, '' AS [IVA %], isnull(Pvp_Iva,0) [PVP INCLUYE IVA] FROM Productos", con.conexion);
                        else
                            da = new SqlDataAdapter("SELECT IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) AS [ID/CÓDIGO BARRA], Productos.Producto AS PRODUCTO, Presentaciones.Presentacion AS PRESENTACIÓN, Proveedores.Proveedor AS PROVEEDOR, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS DISPONIBLE, IVA AS [IVA %], isnull(Pvp_Iva,0) [PVP INCLUYE IVA] FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor WHERE Productos.Id_Proveedor = " + id_prov + "", con.conexion);

                        da.SelectCommand.CommandType = CommandType.Text;

                        da.Fill(dt);
                        con.desconectar();
                    }
                    else
                    {
                        da = new SqlDataAdapter("EXEC sp_Obtener_Producto_iva '"+ datos +"'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                        con.desconectar();
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_prod'. " + ex.Message);
            }
        }

        public decimal obtener_iva()
        {
            try
            {
                decimal monto = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL( (SELECT ISNULL( Monto,0) FROM  IVA),0) AS Monto", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    monto = Convert.ToDecimal(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return monto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_iva'. " + ex.Message);
            }
        }
        public string obtener_iva_cod_sri()
        {
            try
            {
                string CODIGO_SRI = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT CODIGO_SRI FROM IVA", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    CODIGO_SRI =  cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return CODIGO_SRI;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_iva_cod_sri'. " + ex.Message);
            }
        }
        public bool guardar(string monto, string CODIGO_SRI, string codporcsri)
        {
            try
            {
                con = new DConexion();
                bool resp = false;

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE IVA SET Monto = '" + monto.Replace(",", ".") + "',CODIGO_SRI = '" + CODIGO_SRI + "',Codigo_Porc_Iva = '" + codporcsri + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("DISABLE TRIGGER [dbo].[tgr_update_stock] on [dbo].[Productos];  UPDATE Productos  SET IVA = '" + monto.Replace(",", ".") + "' WHERE IVA > 0;  ENABLE  TRIGGER [dbo].[tgr_update_stock] on [dbo].[Productos];", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();


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
        public string obtener_iva_porc_sri()
        {
            try
            {
                string CODIGO_SRI = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Codigo_Porc_Iva FROM IVA", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    CODIGO_SRI = cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return CODIGO_SRI;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_iva_porc_sri'. " + ex.Message);
            }
        }
    }
}
