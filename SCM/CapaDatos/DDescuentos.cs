using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDescuentos
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DDescuentos";

        public bool guardar_todos(int id_prov, DateTime desde, DateTime hasta, string desc)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET Descuento = '" + desc.Replace(",", ".") + "', Descuento_Desde = '" + desde.ToShortDateString() + "', Descuento_Hasta = '" + hasta.ToShortDateString() + "' WHERE Id_Proveedor = " + id_prov + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_todos'. " + ex.Message);
            }
        }

        public bool guardar_selec(string id, DateTime desde, DateTime hasta, string desc)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET Descuento = '" + desc.Replace(",", ".") + "', Descuento_Desde = '" + desde.ToShortDateString() + "', Descuento_Hasta = '" + hasta.ToShortDateString() + "' WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_selec'. " + ex.Message);
            }
        }

        public bool verificar_descuento(int id_prov)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(COUNT(Descuento) = 0, 0, SUM(Descuento)) AS Cant FROM Productos WHERE Id_Proveedor = " + id_prov + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToDecimal(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_descuento'. " + ex.Message);
            }
        }

        public DataTable buscar_prod(int id_prov, string datos)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (datos == "")
                    {
                        SqlDataAdapter da;
                        da = new SqlDataAdapter("EXEC sp_Obtener_Producto_By_Proveedor '" + id_prov + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;

                        da.Fill(dt);
                    }
                    else
                    {
                        try
                        {
                            int id = Int32.Parse(datos);
                        }
                        catch (Exception)
                        {
                            if ((datos.Length > 0 && datos.Length <= 4) && (datos != "" && datos != "*"))
                            {
                                datos = "";
                            }

                        }

                        SqlDataAdapter da;
                        da = new SqlDataAdapter("EXEC sp_Obtener_Producto_Descuento '" + datos + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                   
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_prod'. " + ex.Message);
            }
        }

        public DataTable buscar_prov(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    
                    da = new SqlDataAdapter("EXEC sp_Obtener_Proveedores '" + dato + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_prov'. " + ex.Message);
            }
        }
        public DataTable buscar_descuento_by_producto(string id_prov)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                      SqlDataAdapter da;
                        da = new SqlDataAdapter("EXEC sp_Obtener_Descuento_Categoria_By_Producto '" + id_prov + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_descuento_by_producto'. " + ex.Message);
            }
        }
        public bool guardar_descuento_categoria(string accion , int id_descuento , string id_producto, string cant_min , string cant_max , string  descuento ,DateTime desde ,DateTime hasta )
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("EXEC sp_Incluir_Descuento_Categoria '" + accion + "','" + id_descuento + "','" + id_producto + "','" + cant_min.Replace(",", ".") + "','" + cant_max.Replace(",", ".") + "','" + descuento.Replace(",", ".") + "','" + desde.ToString("yyyy-MM-dd") + "', '" + hasta.ToString("yyyy-MM-dd") + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_descuento'. " + ex.Message);
            }
        }
        public int valida_descuento_categoria(string accion, string id_producto, string cant_min, string cant_max, string descuento, DateTime desde, DateTime hasta)
        {
            try
            {
                bool resp = false;
                con = new DConexion();
                int cantidad = 0;
                if (con.conectar())
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("SELECT count(1) CANTIDAD FROM [dbo].[Descuento_Categoria] WHERE Id_Producto IN (SELECT Distinct Id FROM  [dbo].Productos WHERE  IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_producto + "') AND (( CAST([Descuento_Desde] AS DATE) BETWEEN CAST('" + desde.ToString("yyyy-MM-dd") + "' AS DATE) AND  CAST( '" + hasta.ToString("yyyy-MM-dd") + "' AS DATE) ) OR ( CAST([Descuento_Hasta] AS DATE) BETWEEN  CAST('" + desde.ToString("yyyy-MM-dd") + "' AS DATE) AND  CAST('" + hasta.ToString("yyyy-MM-dd") + "' AS DATE)) ) AND Cant_Min = '" + cant_min.Replace(",", ".") + "' and Cant_Max = '" + cant_max.Replace(",", ".") + "' and Descuento = '" + descuento.Replace(",", ".") + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        cantidad = int.Parse(dt.Rows[0]["CANTIDAD"].ToString());
                    }

                    con.desconectar();
                }

                return cantidad;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_descuento'. " + ex.Message);
            }
        }

        public DataTable Obtener_Descuento_Linea()
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("select dl.ID [# DESCUENTO],dl.DESCRIPCION,dl.PORCENTAJE,dl.VENCE_DESDE [FECHA INICIO],dl.VENCE_HASTA [FECHA FIN],usr.Usuario [CREADO POR], dl.ESTADO, dl.CreateDate [CREADO EL] from Descuento_Linea_Producto dl left join Usuarios usr on dl.CreateUser = usr.Id order by dl.Id desc ", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Descuento_Linea'. " + ex.Message);
            }
        }
        public int agregar_descuento_linea(string descripcion, decimal porcentaje, DateTime dtInicio, DateTime dtFin, bool estado, int usuario)
        {
            try
            {
                int id_pro = 0, resp = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Descuento_Linea_Producto (Descripcion,Porcentaje,Vence_Desde,Vence_Hasta,CreateUser,Estado,CreateDate) VALUES ( '" + descripcion + "','" + porcentaje.ToString().Replace(",", ".") + "','" + dtInicio.ToShortDateString() + "','" + dtFin.ToShortDateString() + "','" + usuario + "','" + estado + "',GetDate())  select @@IDENTITY", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = int.Parse(cmd.ExecuteScalar().ToString());
                    con.desconectar();

                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'agregar_descuento_linea'. " + ex.Message);
            }
        }
        public int modificar_descuento_linea(int id_descuento, string descripcion, decimal porcentaje, DateTime dtInicio, DateTime dtFin, bool estado)
        {
            try
            {
                int id_pro = 0, resp = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Descuento_Linea_Producto SET Descripcion = '" + descripcion + "',Porcentaje = '" + porcentaje.ToString().Replace(",", ".") + "',Vence_Desde = '" + dtInicio.ToShortDateString() + "',Vence_Hasta = '" + dtFin.ToShortDateString() + "',Estado = '" + estado + "' WHERE Id = '" + id_descuento + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = cmd.ExecuteNonQuery();
                    con.desconectar();

                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_descuento_linea'. " + ex.Message);
            }
        }
        public int eliminar_descuento_linea(int id_descuento)
        {
            try
            {
                int id_pro = 0, resp = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Descuento_Linea_Producto SET  Estado = 0 WHERE Id = '" + id_descuento + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = cmd.ExecuteNonQuery();
                    con.desconectar();

                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_descuento_linea'. " + ex.Message);
            }
        }
        public DataTable Obtener_lineas_descuento(string id_descuento)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("exec sp_Obtener_Lineas_Descuento '" + id_descuento + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_lineas_descuento'. " + ex.Message);
            }
        }
        
        public bool asignar_linea_descuento(string id_descuento, string id_Producto)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Descuento_Linea_Producto_Det WHERE Id_Descuento_Linea = '" + id_descuento + "' AND Id_Producto = '" + id_Producto + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) <= 0)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Descuento_Linea_Producto_Det (Id_Descuento_Linea, Id_Producto) VALUES('" + id_descuento + "', '" + id_Producto + "')", con.conexion);
                        cmd2.CommandType = CommandType.Text;

                        cmd2.ExecuteNonQuery();
                        resp = true;
                    }
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'asignar_linea_descuento'. " + ex.Message);
            }
        }
        public int is_existe_linea_descuento(string id_descuento, string id_Producto)
        {
            try
            {
                int resp = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Descuento_Linea_Producto_Det WHERE Id_Descuento_Linea = '" + id_descuento + "' AND Id_Producto = '" + id_Producto + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = Convert.ToInt32(cmd.ExecuteScalar());
                     
                } 
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'asignar_linea_descuento'. " + ex.Message);
            }
        }
        public bool quitar_linea_descuento(string id_descuento, string id_producto)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Descuento_Linea_Producto_Det WHERE  Id_Descuento_Linea = '" + id_descuento + "' and Id_Producto = '" + id_producto + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_linea_descuento'. " + ex.Message);
            }
        }
        public DataTable buscar_combo(string dato, DateTime dInicio, DateTime dFin)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id,Descripcion DESCRIPCION ,Precio_Combo [PRECIO COMBO] ,Cant_Min [CANT. MINIMA] ,Cant_Max [CANT. MAXIMA] ,Vence_Desde [VENCE DESDE],Vence_Hasta [VENCE HASTA],CreateUser [CREADO POR],case when Estado = 1 then 'ACTIVO' else 'INACTIVO' end AS ESTADO,CreateDate [CREADO EL] FROM Descuento_Combo", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id,Descripcion DESCRIPCION ,Precio_Combo [PRECIO COMBO] ,Cant_Min  [CANT. MINIMA],Cant_Max [CANT. MAXIMA] ,Vence_Desde [VENCE DESDE],Vence_Hasta [VENCE HASTA],CreateUser [CREADO POR],case when Estado = 1 then 'ACTIVO' else 'INACTIVO' end AS ESTADO,CreateDate [CREADO EL] FROM Descuento_Combo  where cast(CreateDate as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date) ORDER BY CreateDate DESC", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id,Descripcion DESCRIPCION ,Precio_Combo [PRECIO COMBO] ,Cant_Min [CANT. MINIMA] ,Cant_Max  [CANT. MAXIMA],Vence_Desde [VENCE DESDE],Vence_Hasta [VENCE HASTA],CreateUser [CREADO POR],case when Estado = 1 then 'ACTIVO' else 'INACTIVO' end AS ESTADO,CreateDate  [CREADO EL] FROM Descuento_Combo WHERE Descripcion like '%" + dato + "%' AND  cast(CreateDate as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date) ORDER BY CreateDate DESC", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_combo'. " + ex.Message);
            }
        }
        public int num_reg_decuento_combo()
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Descuento_Combo", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg_decuento_combo'. " + ex.Message);
            }
        }
        public int modificar_descuento_combo(string id, string Descripcion, decimal Precio_Combo, int Cant_Min, int Cant_Max, DateTime Vence_Desde, DateTime Vence_Hasta, bool estado)
        {
            try
            {
                int resp = 0;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("EXEC sp_Modificar_Descuento_Combo '" + id + "','" + Descripcion + "','" + Precio_Combo + "','" + Cant_Min.ToString().Replace(",", ".") + "','" + Cant_Max.ToString().Replace(",", ".") + "','" + Vence_Desde.ToString("yyyy-MM-dd") + "', '" + Vence_Hasta.ToString("yyyy-MM-dd") + "','" + estado + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = cmd.ExecuteNonQuery();
                    resp = 1;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_descuento_combo'. " + ex.Message);
            }
        }
        public int guardar_descuento_combo(string Descripcion, decimal Precio_Combo, int Cant_Min, int Cant_Max, DateTime Vence_Desde, DateTime Vence_Hasta, string CreateUser)
        {
            try
            {
                int resp = 0;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("EXEC sp_Create_Descuento_Combo '" + Descripcion + "','" + Precio_Combo + "','" + Cant_Min.ToString().Replace(",", ".") + "','" + Cant_Max.ToString().Replace(",", ".") + "','" + Vence_Desde.ToString("yyyy-MM-dd") + "', '" + Vence_Hasta.ToString("yyyy-MM-dd") + "', '" + CreateUser.ToUpper() + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = cmd.ExecuteNonQuery();
                    resp = 1;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_descuento_combo'. " + ex.Message);
            }
        }
        public void eliminar_prod_combo(string id_combo, string id_prod)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Descuento_Combo_Productos WHERE Id_Descuento_Combo = '" + id_combo + "' AND Id_Producto in (select Id from Productos pro where IIF(pro.CodigoBarra = '', CONVERT(NVARCHAR(MAX), pro.Id), pro.CodigoBarra) = '" + id_prod + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_prod_combo'. " + ex.Message);
            }
        }
        public int eliminar_descuento_combo(string id)
        {
            try
            {
                int resp = 0;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("UPDATE Descuento_Combo SET Estado = 0 WHERE Id =  '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    resp = cmd.ExecuteNonQuery();
                    resp = 1;
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_descuento_combo'. " + ex.Message);
            }
        }
        public int agregar_prod_combo(string id_descuento_combo, string id_prdocuto)
        {
            try
            {
                int id_pro = 0, resp = 0;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd1 = new SqlCommand("SELECT Distinct Id FROM  [dbo].Productos WHERE  IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prdocuto + "'", con.conexion);
                    cmd1.CommandType = CommandType.Text;
                    id_pro = Convert.ToInt32(cmd1.ExecuteScalar());

                    if (id_pro > 0)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Descuento_Combo_Productos (Id_Descuento_Combo,Id_Producto) VALUES ( '" + id_descuento_combo + "','" + id_pro + "')", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        resp = cmd.ExecuteNonQuery();
                        resp = 1;
                        con.desconectar();
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'agregar_prod_combo'. " + ex.Message);
            }
        }
        public DataTable buscar_producto_by_combo(string id_combo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("EXEC sp_Obtener_Productos_By_Combo '" + id_combo + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_producto_by_combo'. " + ex.Message);
            }
        }
        public int verificar_prod_combo(int id_combo, string id_prod)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(com.Id_Producto) AS Registros FROM Descuento_Combo_Productos com inner join Productos pro on com.Id_Producto = pro.Id WHERE com.Id_Descuento_Combo = " + id_combo + " AND IIF(pro.CodigoBarra = '', CONVERT(NVARCHAR(MAX), pro.Id), pro.CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        cant = Convert.ToInt32(cmd.ExecuteScalar());

                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_prod_combo'. " + ex.Message);
            }
        }
    }
}
