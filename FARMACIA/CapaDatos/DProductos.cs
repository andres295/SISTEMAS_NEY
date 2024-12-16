using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProductos
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DProductos";
        
        public string obtener_disponible_texto(string id_prod)
        {
            try
            {
                string cadena = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS Dispobible_Texto FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cadena = cmd.ExecuteScalar().ToString();
                    try
                    {
                        Int32.Parse(cadena);
                    }
                    catch (Exception)
                    {

                        cadena = "0";
                    }
                    con.desconectar();
                }

                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_disponible_texto'. " + ex.Message);
            }
        }

        public long obtener_disponible(string id_prod)
        {
            try
            {
                long cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Disponible FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '"  + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt64(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_disponible'. " + ex.Message);
            }
        }
        public long obtener_id_Producto(string id_prod)
        {
            try
            {
                long cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt64(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_disponible'. " + ex.Message);
            }
        }

        public void actualizar_desc(string id_prod)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(CONVERT(DATE, GETDATE()) > Descuento_Hasta, 1, 2) AS Accion FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    //SI ES 1, ENTONCES ACTUALIZA A CERO EL DESCUENTO Y LAS FECHAS A 1900-01-01.
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                    {
                        cmd = new SqlCommand("UPDATE Productos SET Descuento = 0, Descuento_Desde ='1900-01-01', Descuento_Hasta = '1900-01-01' WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_desc'. " + ex.Message);
            }
        }

        public int obtener_cont(string id)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Contiene FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cont'. " + ex.Message);
            }
        }
        public int obtener_cant_fracciones_restante(string id)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(IIF(prod.Contiene = 0, CONVERT(NVARCHAR(MAX), 0), prod.Disponible - ((prod.Disponible/prod.Contiene) * prod.Contiene)),0) AS Stock FROM Productos prod WHERE IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR(MAX), prod.Id), prod.CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cont'. " + ex.Message);
            }
        }
        public string obtener_img_prod(string id)
        {
            try
            {
                string img = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Foto FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    img = cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return img;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_img_prod'. " + ex.Message);
            }
        }
        public int obtener_contiene(string id)
        {
            try
            {
                int contiene = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Contiene FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        contiene = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                    catch (Exception) { }
                  
                    con.desconectar();
                }

                return contiene;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_img_prod'. " + ex.Message);
            }
        }
        public decimal obtener_precio_compra(string id)
        {
            try
            {
                decimal precio_compra = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT PVF FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        precio_compra = decimal.Parse(cmd.ExecuteScalar().ToString());
                    }
                    catch (Exception) { }

                    con.desconectar();
                }

                return precio_compra;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_img_prod'. " + ex.Message);
            }
        }
        public int obtener_dia_vencimiento(string id)
        {
            int dia_vence = 0;
            try
            { 
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("select top 1 isnull(datediff(dd,getdate(), max(Vencimiento)),0) dia_vence from Stock_Productos where  Id_Producto in ( select top 1 id from dbo.Productos where  IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "') and stock > 0 and estado = 1", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        dia_vence = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                    catch (Exception) { }

                    con.desconectar();
                } 
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_img_prod'. " + ex.Message);
            }

            return dia_vence;
        }
        public int tamaño(string dato, int registro_por_pagina)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("Tamaño_Productos_Buscar", con.conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", dato);
                    cmd.Parameters.AddWithValue("@RegistrosPorPagina", registro_por_pagina);

                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@TotalPaginas";
                    par.SqlDbType = SqlDbType.Int;
                    par.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(par);

                    cmd.ExecuteNonQuery();

                    cant = Convert.ToInt32(cmd.Parameters["@TotalPaginas"].Value);
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'tamaño'. " + ex.Message);
            }
        }

        public DataTable buscar1(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT prod.Id, prod.Producto, pres.Presentacion, prov.Proveedor, pvf, pvp, Disponible, Estado FROM Productos prod INNER JOIN Presentaciones pres ON pres.Id = prod.Id_Presentacion INNER JOIN Proveedores prov ON prov.Id = prod.Id_Presentacion", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar1'. " + ex.Message);
            }
        }
        
        public DataTable buscar(string dato, int pagina_actual, int tamaño)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("Paginar_Productos_Buscar", con.conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", dato);
                    cmd.Parameters.AddWithValue("@Pagina_Actual", pagina_actual);
                    cmd.Parameters.AddWithValue("@Tamaño", tamaño);

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        public DataTable buscar2()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM(SELECT 'TODOS' TIPO, 0 ID UNION SELECT 'VENTAS' TIPO, 1 ID UNION SELECT 'CARGO COMPRAS' TIPO, 2 ID UNION SELECT 'CARGO AJUSTE DE INVENTARIO' TIPO, 3 ID UNION SELECT 'DESCARGO AJUSTE DE INVENTARIO' TIPO, 4 ID UNION SELECT 'NOTAS DE CRÉDITO' TIPO, 5  ID UNION SELECT 'CARGO POR TRANSFERENCIA' TIPO, 6  ID UNION SELECT 'DESCARGO POR TRANSFERENCIA' TIPO, 7  ID) R ORDER BY ID ASC", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar2'. " + ex.Message);
            }
        }
        public DataTable cargarProductoFiltro1()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra) AS Id, Producto  FROM dbo.Productos prod", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargarProductoFiltro1'. " + ex.Message);
            }
        }
        public DataTable cargarProductoFiltro2(string filtro)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra) AS Id, IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra) +' - '+ Producto AS Producto  FROM dbo.Productos prod  where IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra)  like '%" + filtro + "%'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargarProductoFiltro2'. " + ex.Message);
            }
        }

        public void eliminar(string id,string name_usuario)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    DataTable dtProd = new DataTable(); 
                    SqlCommand cmd1 = new SqlCommand("SELECT top 1 * FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(dtProd);

                    SqlCommand cmd = new SqlCommand("DELETE Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    try
                    {
                        if (dtProd.Rows.Count > 0)

                        {
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO Productos_Bitacora VALUES('" + dtProd.Rows[0]["Id"] + "','" + dtProd.Rows[0]["CodigoBarra"] + "', '" + dtProd.Rows[0]["Producto"] + "', " + dtProd.Rows[0]["Id_Presentacion"] + ", " + dtProd.Rows[0]["Id_Proveedor"] + ", '" + dtProd.Rows[0]["PVF"].ToString().Replace(",", ".") + "', '" + dtProd.Rows[0]["PVP"].ToString().Replace(",", ".") + "', " + dtProd.Rows[0]["Contiene"] + ", '" + DateTime.Parse(dtProd.Rows[0]["Vencimiento"].ToString()).ToShortDateString() + "', '" + dtProd.Rows[0]["Estado"] + "', 0, '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', '" + dtProd.Rows[0]["Disponible"].ToString().Replace(",", ".") + "', '" + dtProd.Rows[0]["Lote"].ToString().Replace(",", ".") + "', '" + dtProd.Rows[0]["Foto"] + "','" + dtProd.Rows[0]["IVA"].ToString().Replace(",", ".") + "', '" + dtProd.Rows[0]["PUR"].ToString().Replace(",", ".") + "', '" + dtProd.Rows[0]["Utilidad"].ToString().Replace(",", ".") + "', '" + dtProd.Rows[0]["Id_Especificacion"] + "', '" + dtProd.Rows[0]["Id_Composicion"] + "','" + dtProd.Rows[0]["Pvp_Iva"] + "','Delete',getdate(),'" + name_usuario + "')", con.conexion);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.ExecuteNonQuery();
                        }
                    }
                    catch (Exception) { }

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar'. " + ex.Message);
            }
        }

        public void actualizar_foto(string id, string foto)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET Foto = '" + foto + "' WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_foto'. " + ex.Message);
            }
        }

        public bool modificar(string id, string cb, string prod, int id_pres, int id_prov, string pvf, string pvp, int cont, DateTime venc, string est, string lote, int id_especif,int Id_Composicion,bool pvp_iva,string name_user,string registro_sanitario)
        {
            try
            {
                bool resp = false;
                long idProducto = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd3 = new SqlCommand("SELECT Id FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd3.CommandType = CommandType.Text; 
                    idProducto = Convert.ToInt64(cmd3.ExecuteScalar());

                    SqlCommand cmd1 = new SqlCommand("EXEC sp_actualizar_factor_conversion '"+ idProducto + "','" + cont + "','system'", con.conexion);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();

                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Productos_Bitacora VALUES('" + idProducto + "','" + cb + "', '" + prod + "', " + id_pres + ", " + id_prov + ", '" + pvf.Replace(",", ".") + "', '" + pvp.Replace(",", ".") + "', " + cont + ", '" + venc.ToShortDateString() + "', '" + est + "', 0, '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', 0, '" + lote + "', '', 0, 0, 0, " + id_especif + ", " + Id_Composicion + ",'" + pvp_iva + "','Actualizar',getdate(),'"+ name_user + "', '" + registro_sanitario + "')", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception) { }

                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET CodigoBarra = '" + cb + "', Producto = '" + prod + "', Id_Presentacion = " + id_pres + ", Id_Proveedor = " + id_prov + ", PVF = '" + pvf.Replace(",", ".") + "', PVP = '" + pvp.Replace(",", ".") + "', Contiene = " + cont + ", Vencimiento = '" + venc.ToShortDateString() + "', Estado = '" + est + "', Lote = '" + lote + "', Id_Especificacion = " + id_especif + ", Id_Composicion  = " + Id_Composicion + ", Pvp_Iva = '" + pvp_iva + "', RegistroSanitario = '" + registro_sanitario + "'  WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
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

        public bool guardar(string cb, string prod, int id_pres, int id_prov, string pvf, string pvp, int cont, DateTime venc, string est, string lote, string foto, int id_especif,int id_composicion,bool pvp_iva,string name_usuario, string registro_sanitario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();
                int idProducto = 0;

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Productos VALUES('" + cb + "', '" + prod + "', " + id_pres + ", " + id_prov + ", '" + pvf.Replace(",", ".") + "', '" + pvp.Replace(",", ".") + "', " + cont + ", '" + venc.ToShortDateString() + "', '" + est + "', 0, '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', 0, '" + lote + "', '" + foto + "', 0, 0, 0, " + id_especif + ", " + id_composicion + ",'"+ pvp_iva + "', '" + registro_sanitario + "') SELECT @@IDENTITY", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    idProducto = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idProducto > 0 )
                    {
                        try
                        {
                            SqlCommand cmd3 = new SqlCommand("INSERT INTO Productos_Bitacora VALUES('" + idProducto + "','" + cb + "', '" + prod + "', " + id_pres + ", " + id_prov + ", '" + pvf.Replace(",", ".") + "', '" + pvp.Replace(",", ".") + "', " + cont + ", '" + venc.ToShortDateString() + "', '" + est + "', 0, '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', '" + Convert.ToDateTime("1900-01-01").ToShortDateString() + "', 0, '" + lote + "', '" + foto + "', 0, 0, 0, " + id_especif + ", " + id_composicion + ",'" + pvp_iva + "','Insertar',getdate(),'" + name_usuario + "')", con.conexion);
                            cmd3.CommandType = CommandType.Text;
                            cmd3.ExecuteNonQuery();
                        }
                        catch (Exception)  {}
                        

                        SqlCommand cmd2 = new SqlCommand("UPDATE Composicion_Producto  SET Id_Producto = '" + idProducto + "' WHERE Id_Producto = 999999999", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery(); 

                        resp = true;
                    }  
                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Cant FROM Productos", con.conexion);
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
        public int valida_mov_cardex_codigo_barra(string codigo_barra)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("EXEC sp_Valida_Kardex_CodigoBarra '"+ codigo_barra + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'valida_mov_cardex_codigo_barra'. " + ex.Message);
            }
        }
        public DataTable obtener_datos(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Producto_By_Id '" + id + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

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
        public DataTable obtener_producto_by_composicion(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Producto_By_Composicion '" + id + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_composicion_by_productos'. " + ex.Message);
            }
        }
        public DataTable obtener_producto_by_especificacion(string especificacion)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Producto_By_Especificacion '" + especificacion + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_producto_by_especificacion'. " + ex.Message);
            }
        }
        public DataTable obtener_producto_by_composicion_filter(string id_composicion)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Producto_By_Composicion_Filter '" + id_composicion + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_producto_by_composicion_filter'. " + ex.Message);
            }
        }
        public DataTable obtener_composicion(string id,string filtro)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Composicion_Producto '" + id + "','"  + filtro + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

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
        public string obtener_composicion_by_producto(string id,bool tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();
                string composicion = "";

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Composicion_Producto_By_Id '" + id + "','" + tipo + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                    if ( dt.Rows.Count>0)
                    {
                        composicion = dt.Rows[0]["Composicion"].ToString();
                    }
                }
                return composicion;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }
        public DataTable obtener_composicion_by_producto(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();
                string composicion = "";

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Composicion_Producto_By_Id '" + id + "','" + 1 + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

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
        public bool asignar_composicion(string Id_Producto, string Id_Composicion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("EXEC sp_Incluir_Composicion_Producto '" + Id_Producto + "', '" + Id_Composicion + "','I'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'asignar_composicion'. " + ex.Message);
            }
        }
        public bool quitar_composicion(string Id_Producto, string Id_Composicion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("EXEC sp_Incluir_Composicion_Producto '" + Id_Producto + "','" + Id_Composicion + "','D'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_composicion'. " + ex.Message);
            }
        }
        public DataTable obtener_productos(string datos)
        {
            DataTable dt = new DataTable();
            try
            {
               
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec Cargar_Productos '" + datos + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_productos'. " + ex.Message);
            }
        }
        public DataTable obtener_productos_venta(string datos,int stock_producto)
        {
            DataTable dt = new DataTable();
            try
            {

                con = new DConexion();

                if (con.conectar())
                {
                    if (datos.Length <= 19)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("exec Cargar_Productos_Venta '" + datos + "','" + stock_producto + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text; 
                        da.Fill(dt);
                    } else  {
                        SqlDataAdapter da = new SqlDataAdapter("exec Cargar_Productos_Venta '','" + stock_producto + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_productos'. " + ex.Message);
            }
        }
        public DataTable obtener_productos_venta_por_composicion(string datos, int stock_producto)
        {
            DataTable dt = new DataTable();
            try
            {

                con = new DConexion();

                if (con.conectar())
                {
                    if (datos == "*")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("exec sp_cursor_producto_composicion '','" + stock_producto + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("exec sp_cursor_producto_composicion '" + datos + "','" + stock_producto + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_productos_venta_por_composicion'. " + ex.Message);
            }
        }
        public DataTable obtener_productos_cat(string datos,bool eliminado)
        {
            DataTable dt = new DataTable();
            try
            {
               
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec Cargar_Productos_Cat '" + datos + "','" + eliminado + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_productos_cat'. " + ex.Message);
            }
        }
        public DataTable obtener_stock(string producto,string proveedor, string filtroNuevo)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    if (producto == "*")
                    {
                        producto = "";
                    }
                    if (proveedor == "*")
                    {
                        proveedor = "";
                    }

                    SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.Stock '"+ producto + "','" + proveedor + "','" + filtroNuevo + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_stock'. " + ex.Message);
            }
        }
        public DataTable obtener_kardex(DateTime dInicio, DateTime dFin, string id_producto,string mov)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.sp_ObtenerKardex '" + dInicio.ToShortDateString() +"','" + dFin .ToShortDateString()+ "','" + id_producto + "','" + mov + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_Vencimiento'. " + ex.Message);
            }
        }
        public DataTable obtener_historico_compra_producto(DateTime dInicio, DateTime dFin, string producto, string tipo)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.SP_Get_Historico_Compra_Producto '" + dInicio.ToShortDateString() + "','" + dFin.ToShortDateString() + "','" + producto + "','" + tipo + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_historico_compra_producto'. " + ex.Message);
            }
        }
        public DataTable bitacora_producto(string id,bool eliminado)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (!eliminado)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT pro.Usuario, pro.Id,pro.CodigoBarra, pro.Producto, pre.Presentacion, prov.Proveedor, pro.PVF PrecioCompra,case when pvp_iva= 1 then 'SI' else 'NO' end [PVP.INC.IVA],pro.PVP PrecioVentaPublico,pro.Contiene, pro.Vencimiento, Pro.Estado,pro.Lote,esp.Especificacion,pro.Accion,pro.CreateDate,pro.RegistroSanitario   FROM [dbo].[Productos_Bitacora] pro left join dbo.Presentaciones pre on pro.Id_Presentacion = pre.Id left join dbo.Proveedores prov on pro.Id_Proveedor = prov.Id left join dbo.Especificaciones esp on pro.Id_Especificacion = esp.Id where pro.Id = (select Id from dbo.Productos prod where IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra) = '" + id + "')  order by pro.CreateDate  desc", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT pro.Usuario, pro.Id,pro.CodigoBarra, pro.Producto, pre.Presentacion, prov.Proveedor, pro.PVF PrecioCompra,case when pvp_iva= 1 then 'SI' else 'NO' end [PVP.INC.IVA],pro.PVP PrecioVentaPublico,pro.Contiene, pro.Vencimiento, Pro.Estado,pro.Lote,esp.Especificacion,pro.Accion,pro.CreateDate,pro.RegistroSanitario   FROM [dbo].[Productos_Bitacora] pro left join dbo.Presentaciones pre on pro.Id_Presentacion = pre.Id left join dbo.Proveedores prov on pro.Id_Proveedor = prov.Id left join dbo.Especificaciones esp on pro.Id_Especificacion = esp.Id where IIF(pro.CodigoBarra = '', CONVERT(NVARCHAR, pro.Id), pro.CodigoBarra) = '" + id + "'  order by pro.CreateDate  desc", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }  
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'bitacora_producto'. " + ex.Message);
            }
        }
         public DataTable obtener_composicion_by_filter(string filtro)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter(" SELECT	   p.[Id]  ,Composicion , 0 Selecionado FROM   [dbo].[ComposicionQuimica] p WHERE    [Estado] = 1  AND  p.Composicion like '%' + '" + filtro + "' + '%' ORDER BY Composicion ASC", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_composicion_by_filter'. " + ex.Message);
            }
        }
        public DataTable Obtener_Solicitud_by_usuario(int id_usuario, DateTime dtinicio, DateTime dtFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("Exec SP_Obtener_Solicitud_Producto '" + id_usuario + "','" + dtinicio.ToShortDateString() + "','" + dtFin.ToShortDateString() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Solicitud_by_usuario'. " + ex.Message);
            }
        }
        public bool Agregar_Registro_Solicitud_Producto(string producto, decimal cantidad, decimal monto, int id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Solicitud_Producto (Producto,Cantidad_Solicita,Deposito,Id_Usuario,FechaHora_Registro,Estado) VALUES('" + producto + "', '" + cantidad.ToString().Replace(",", ".") + "', '" + monto.ToString().Replace(",", ".") + "','" + id_usuario + "',getdate(),1)", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Agregar_Registro_Solicitud_Producto'. " + ex.Message);
            }
        }
        public bool eliminar_solicitud_producto(int id_solicitud)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Solicitud_Producto SET Estado = 0  WHERE Id = '" + id_solicitud + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_solicitud_producto'. " + ex.Message);
            }
        }
        public DataTable cargarCatProducto()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT  prod.Id , Producto  FROM dbo.Productos prod", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargarCatProducto'. " + ex.Message);
            }
        }
        public DataTable obtener_datos_pro(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Producto,Id_Presentacion,isnull(Contiene,0)Contiene,pre.Presentacion,Productos.Id FROM dbo.Productos WITH(NOLOCK) left join dbo.Presentaciones pre WITH(NOLOCK) on Id_Presentacion = pre.Id WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_img_prod'. " + ex.Message);
            }
        }
        public long obtener_disponible_vs_venta(string idventa,string id_prod)
        {
            try
            {
                long cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT  isnull(sum(pr.Disponible),0)-(isnull((select sum(vp.vendio) from Ventas_Productos_Temp vp where vp.Id_Venta = '" + idventa + "' and  vp.Id_Producto  = '" + id_prod + "') ,0)+1) disponible FROM Productos pr WHERE IIF(pr.CodigoBarra = '', CONVERT(NVARCHAR(MAX), pr.Id), pr.CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt64(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_disponible_vs_venta'. " + ex.Message);
            }
        }
    }
}
