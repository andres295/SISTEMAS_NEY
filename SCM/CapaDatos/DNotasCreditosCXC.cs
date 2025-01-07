using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DNotasCreditosCXC
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DNotasCreditosCXC";

        public DataTable obtener_totales(string nc)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Subtotal) AS Subtotal, SUM(IVA) AS IVA, SUM(Descuento) AS Descuento, SUM(Total) AS Total FROM (SELECT Id_NC, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total  FROM NotasCreditos_Productos_TempCXC UNION ALL SELECT Id_NC, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_ProductosCXC) AS Tablas WHERE Tablas.Id_NC = '" + nc + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_totales'. " + ex.Message);
            }
        }

        public DataTable obtener_datos_fila(string nc, string fact, string id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Cantidad, Bonificacion, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_totales'. " + ex.Message);
            }
        }

        public void actualizar_cantidad(string nc, string fact, string id, int cant, int bonif)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("UPDATE NotasCreditos_Productos_TempCXC SET Cantidad = " + cant + ", Bonificacion = " + bonif + " WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT IVA, Desc_Porc FROM CargoCompra WHERE Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    decimal captar_iva, captar_desc;
                    captar_iva = Convert.ToDecimal(dr[0].ToString()) / 100;
                    captar_desc = Convert.ToDecimal(dr[1].ToString()) / 100;

                    dr.Close();

                    cmd = new SqlCommand("UPDATE NotasCreditos_Productos_TempCXC SET Subtotal = (Cantidad * PVF), IVA = Subtotal * " + captar_iva.ToString().Replace(",", ".") + ", Descuento = Subtotal * " + captar_desc.ToString().Replace(",", ".") + " WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_cantidad'. " + ex.Message);
            }
        }

        public int existe_prod(string nc, string Id_Venta, string id)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "' AND Id_Venta = '" + Id_Venta + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'existe_prod'. " + ex.Message);
            }
        }

        public int verificar_temp(string nc)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_temp'. " + ex.Message);
            }
        }

        public int verificar(string nc)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos_ProductosCXC WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar'. " + ex.Message);
            }
        }

        public DataTable cargar_prod(string nc)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Cantidad AS [CANT.], Bonificacion AS [BONIF.], PVF AS [P/COMPRA], Subtotal AS [SUBTOTAL], IVA, Descuento AS [DESCUENTO], ((Subtotal + IVA) - Descuento) AS [TOTAL A DEDUCIR] FROM (SELECT Id_NC, Id_Producto, Producto, Cantidad, Bonificacion, PVF, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_Productos_TempCXC UNION ALL SELECT Id_NC, Id_Producto, Producto, Cantidad, Bonificacion, PVF, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_ProductosCXC ) AS Tablas WHERE Tablas.Id_NC = '" + nc + "'", con.conexion);
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

        public int num_reg()
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos", con.conexion);
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

        public string actualizar_nombre(string nc)
        {
            try
            {
                string nombre = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF((SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = NotasCreditosCXC.NC) = 0 AND (SELECT COUNT(*) AS Registros FROM NotasCreditos_ProductosCXC WHERE Id_NC = NotasCreditosCXC.NC) = 0, '[0] ' + CLIENTE, IIF((SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = NotasCreditosCXC.NC) = 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM NotasCreditos_ProductosCXC WHERE Id_NC = NotasCreditosCXC.NC), '] ', CLIENTE), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = NotasCreditosCXC.NC), '] ', CLIENTE))) AS CLIENTE FROM NotasCreditosCXC WHERE NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    nombre = dr[0].ToString();
                    dr.Close();

                    con.desconectar();
                }

                return nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_nombre'. " + ex.Message);
            }
        }

        public void guardar_nc(string nc, int num_venta, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser,string tipoNC,decimal monto)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO NotasCreditosCXC ([NC],[Id_Venta_Afec] ,[Id_Cliente] ,[Cliente] ,[Fecha_Emision] ,[Matriz] ,[RUC],[Direccion] ,[Telefono] ,[Observacion] ,[FechaHora_Registro] , [TipoNC] , [Monto] ) VALUES('" + nc + "', '" + num_venta + "', " + id_prov + ", '" + prov + "', '" + fecha_emision.ToShortDateString() + "', '" + matriz + "', '" + ruc + "', '" + dir + "', '" + tel + "', '" + obser + "', GETDATE(), '" + tipoNC + "','" + monto.ToString().Replace(",", ".") + "')", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    if (tipoNC == "Monto")
                    {
                        cmd = new SqlCommand("UPDATE FacturasPorCobrar SET Monto_NC = (ISNULL(Monto_NC,0) + " + monto.ToString().Replace(",", ".") + "), Monto_TotalPagar = (Monto_TotalPagar - " + monto.ToString().Replace(",", ".") + ") WHERE Num_Venta = '" + num_venta + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();  
                    } 
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_nc'. " + ex.Message);
            }
        }

        public void actualizar_nc(string nc_actual, string nc, string fact, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE NotasCreditos  SET  NC = '" + nc + "', Id_Factura_Afec = '" + fact + "', Id_Proveedor = '" + id_prov + "', Proveedor = '" + prov + "', Fecha_Emision = '" + fecha_emision.ToShortDateString() + "', Matriz = '" + matriz + "', RUC = '" + ruc + "', Direccion = '" + dir + "', Telefono = '" + tel + "', Observacion = '" + obser + "' WHERE NC = '"+ nc_actual + "'" , con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("UPDATE NotasCreditos_ProductosCXC  SET  Id_NC = '" + nc + "' WHERE Id_NC = '" + nc_actual + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();


                    SqlCommand cmd3 = new SqlCommand("UPDATE NotasCreditos_Productos_TempCXC  SET  Id_NC = '" + nc + "' WHERE Id_NC = '" + nc_actual + "'", con.conexion);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.ExecuteNonQuery();


                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_nc'. " + ex.Message);
            }
        }
        public int validar_nc(string nc)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();
                int idNc = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT 	COUNT(NC) ID FROM NotasCreditos WHERE NC = '" + nc + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    if(dt.Rows.Count>0)
                    {
                        idNc = int.Parse(dt.Rows[0]["ID"].ToString());
                    }
                    con.desconectar();
                }
                return idNc;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_nc'. " + ex.Message);
            }
        }

        public void actualizar_stock(string nc, string fact, string id, bool accion)
        {
            try
            {
                con = new DConexion();
                int captar_cantidades = 0;

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT SUM( IIF(Contiene = 0, (Cantidad + Bonificacion), (Cantidad * Contiene) + (Bonificacion * Contiene))) AS Cantidades FROM NotasCreditos_ProductosCXC WHERE Id_NC = '" + nc + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    captar_cantidades = Convert.ToInt32(dr[0].ToString());
                    dr.Close();

                    if (accion)
                        cmd = new SqlCommand("UPDATE Productos SET Disponible = (Disponible - (" + captar_cantidades + ")) WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    else
                        cmd = new SqlCommand("UPDATE Productos SET Disponible = (Disponible + (" + captar_cantidades + ")) WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'deducir_stock'. " + ex.Message);
            }
        }

        public void deducir_nc(string nc, string fact)
        {
            try
            {
                con = new DConexion();
                decimal captar_totales = 0;

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT SUM((Subtotal + IVA) - Descuento) AS Totales FROM NotasCreditos_ProductosCXC WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();                    
                    captar_totales = Convert.ToDecimal(dr[0].ToString());
                    dr.Close();

                    cmd = new SqlCommand("UPDATE FacturasPorCobrar SET Monto_NC = (Monto_NC - " + captar_totales.ToString().Replace(",", ".") + ") WHERE Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE FacturasPorCobrar SET Monto_TotalPagar = (Monto_Fact - Monto_NC) WHERE Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'deducir_nc'. " + ex.Message);
            }
        }

        public void eliminar_nc(string nc)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("DELETE NotasCreditos WHERE NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE NotasCreditos_ProductosCXC WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_nc'. " + ex.Message);
            }
        }

        public void guardar(string nc, string Num_Venta)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    decimal captar_monto = 0;

                    cmd = new SqlCommand("SELECT SUM(((Subtotal + IVA) - Descuento)) AS Total FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    captar_monto = Convert.ToDecimal(dr[0].ToString());
                    dr.Close();

                    cmd = new SqlCommand("UPDATE FacturasPorCobrar SET Monto_NC = (ISNULL(Monto_NC,0) + " + captar_monto.ToString().Replace(",", ".") + "), Monto_TotalPagar = (Monto_Fact - Monto_NC) WHERE Num_Venta = '" + Num_Venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE NotasCreditosCXC SET Monto =  '" + captar_monto.ToString().Replace(",", ".") + "' WHERE NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE FacturasPorCobrar SET Monto_TotalPagar = (Monto_Fact - Monto_NC) WHERE Num_Venta = '" + Num_Venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO NotasCreditos_ProductosCXC SELECT * FROM NotasCreditos_Productos_TempCXC", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "' AND Id_Venta = '" + Num_Venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    /*Se actualiza el estado de la factura*/
                    cmd = new SqlCommand("exec SP_Cancelar_Factura_CXC '" + Num_Venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }

        public void eliminar_prod(string nc, string id)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE NotasCreditos_Productos_TempCXC WHERE Id_NC = '" + nc + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_prod'. " + ex.Message);
            }
        }

        public void modificar_nc()
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_nc'. " + ex.Message);
            }
        }

        public DataTable obtener_datos_nc(string nc)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT NC, Id_Venta_Afec, Id_Cliente, Cliente, Fecha_Emision, Matriz, RUC, Direccion, Telefono, Observacion, Cliente FROM NotasCreditosCXC WHERE NC = '" + nc + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos_nc'. " + ex.Message);
            }
        }

        public DataTable obtener_datos_fact_sel(string num_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT FacturasPorCobrar.Num_Venta, Clientes.RUC, Clientes.Direccion, Clientes.Telefono, Clientes.Nombres_Apellidos CLIENTE FROM FacturasPorCobrar INNER JOIN Clientes ON Clientes.Id = FacturasPorCobrar.Id_Cliente WHERE FacturasPorCobrar.Num_Venta = '" + num_venta + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos_fact_sel'. " + ex.Message);
            }
        }

        public DataTable cargar_fact_sel(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) FacturasPorCobrar.Num_Venta AS [VENTA #], FacturasPorCobrar.Id_Cliente AS ID, Clientes.Nombres_Apellidos AS CLIENTE, Clientes.RUC, Clientes.Telefono AS TELÉFONO FROM FacturasPorCobrar INNER JOIN Clientes ON Clientes.Id = FacturasPorCobrar.Id_Cliente", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT FacturasPorCobrar.Num_Venta AS [VENTA #], FacturasPorCobrar.Id_Cliente AS ID, Clientes.Nombres_Apellidos AS CLIENTE, Clientes.RUC, Clientes.Telefono AS TELÉFONO FROM FacturasPorCobrar INNER JOIN Clientes ON Clientes.Id = FacturasPorCobrar.Id_Cliente", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT FacturasPorCobrar.Num_Venta AS [VENTA #], FacturasPorCobrar.Id_Cliente AS ID, CONCAT('[', (SELECT COUNT(*) AS Registros FROM FacturasPorCobrar_Productos WHERE Id_Factura = FacturasPorCobrar.Factura), '] ', Clientes.Nombres_Apellidos) AS CLIENTE, Clientes.RUC, Clientes.Telefono AS TELÉFONO FROM FacturasPorCobrar INNER JOIN Clientes ON Clientes.Id = FacturasPorCobrar.Id_Cliente WHERE FacturasPorCobrar.Estado IN ( 'POR PAGAR','PENDIENTE') AND (Clientes.Nombres_Apellidos LIKE '%" + dato + "%' OR   Factura = '" + dato + "' )", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_fact_sel'. " + ex.Message);
            }
        }

        public DataTable buscar_prod(string num_venta, string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) '' AS [ID/CÓDIGO BARRA], 0 AS [P/COMPRA], 0 AS [CANT.], 0 AS [BONIF.], '' AS PRODUCTO, '' AS PRESENTACIÓN, '' AS PROVEEDOR", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], PVF AS PVF, Vendio AS [CANT.], 0 AS [BONIF.], prod.PRODUCTO AS PRODUCTO, Presentacion AS PRESENTACIÓN, prov.Proveedor AS PROVEEDOR  FROM FacturasPorCobrar_Detalles_Producto  LEFT JOIN Productos prod on  FacturasPorCobrar_Detalles_Producto.Id_Producto =  IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra) left join Proveedores  prov on prod.Id_Proveedor = prov.id WHERE FacturasPorCobrar_Detalles_Producto.Id_Venta= '" + num_venta + "'", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], PVF AS PVF, Vendio AS [CANT.], 0 AS [BONIF.], prod.PRODUCTO AS PRODUCTO, Presentacion AS PRESENTACIÓN, prov.Proveedor AS PROVEEDOR  FROM FacturasPorCobrar_Detalles_Producto  LEFT JOIN Productos prod on  FacturasPorCobrar_Detalles_Producto.Id_Producto =  IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra) left join Proveedores  prov on prod.Id_Proveedor = prov.id WHERE FacturasPorCobrar_Detalles_Producto.Id_Venta = '" + num_venta + "' AND (prod.Producto LIKE '%" + dato + "%' OR Presentacion LIKE '%" + dato + "%' OR CAST(FacturasPorCobrar_Detalles_Producto.Id_Producto AS VARCHAR) LIKE '%" + dato + "%')", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_prod'. " + ex.Message);
            }
        }

        public void guardar_prod_temp(string nc, string Id_Venta, string id, int cant, int bonif)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd,cmd2;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;
                    string prod;
                    decimal iva = 0, descuento = 0;
                    decimal pvf, calc_subt, calc_iva = 0, calc_desc = 0;
                    int cont;

                    cmd = new SqlCommand("SELECT  prod.PVP Producto, prod.PVF, prod.IVA, 0 Desc_Porc, prod.Contiene  FROM FacturasPorCobrar_Detalles_Producto cxcdet  left join Productos prod on cxcdet.Id_Producto = IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR, prod.Id), prod.CodigoBarra)  INNER JOIN FacturasPorCobrar cxc ON cxc.Num_Venta = cxcdet.Id_Venta WHERE cxcdet.Id_Venta = '" + Id_Venta + "' AND cxcdet.Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

     
                    try
                    {
                        da = new SqlDataAdapter("SELECT ISNULL(IVA,0) IVA,ISNULL(Descuento,0) DESCUENTO  FROM dbo.FacturasPorCobrar_Detalles_Producto WHERE Id_Venta = '" + Id_Venta + "' AND  Id_Producto = '" + id + "'", con.conexion);
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            try
                            {
                                iva = decimal.Parse(dt.Rows[0]["IVA"].ToString());
                            }
                            catch (Exception) { iva = 0; }
                            try
                            {
                                descuento = decimal.Parse(dt.Rows[0]["DESCUENTO"].ToString());
                            }
                            catch (Exception) { descuento = 0; }
                        }
                    }
                    catch (Exception)  { }

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    prod = dr[0].ToString();
                    pvf = Convert.ToDecimal(dr[1].ToString());
                    calc_subt = cant * pvf;


                    if (iva  >0)
                    {
                        calc_iva = (Convert.ToDecimal(dr[2].ToString()) == 0 ? 0 : calc_subt * (Convert.ToDecimal(dr[2].ToString()) / 100));

                    }
                    if (descuento > 0)
                    {
                        calc_desc = (Convert.ToDecimal(dr[3].ToString()) == 0 ? 0 : calc_subt * (Convert.ToDecimal(dr[3].ToString()) / 100));

                    }
                    cont = Convert.ToInt32(dr[4].ToString());
                    dr.Close();

                    cmd = new SqlCommand("INSERT INTO NotasCreditos_Productos_TempCXC VALUES('" + nc + "', '" + Id_Venta + "', '" + id + "', '" + prod + "', " + cant + ", " + bonif + ", " + pvf.ToString().Replace(",", ".") + ", " + calc_subt.ToString().Replace(",", ".") + ", " + calc_iva.ToString().Replace(",", ".") + ", " + calc_desc.ToString().Replace(",", ".") + ", " + cont + ")", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_prod_temp'. " + ex.Message);
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
                        da = new SqlDataAdapter("SELECT TOP(0) NC AS [NC #], Id_Venta_Afec AS [VENTA. AFECT. #], CLIENTE , RUC, Telefono AS [TELÉFONO], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM NotasCreditosCXC", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT NC AS [NC #], Id_Venta_Afec AS [VENTA. AFECT. #], CLIENTE, RUC, Telefono AS [TELÉFONO], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM NotasCreditosCXC", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT NC AS [NC #], Id_Venta_Afec AS [VENTA. AFECT. #], IIF((SELECT COUNT(*) As Registros FROM NotasCreditos_ProductosCXC WHERE NotasCreditos_ProductosCXC.Id_NC = NotasCreditosCXC.NC) > 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM NotasCreditos_ProductosCXC WHERE Id_NC = NotasCreditosCXC.NC), '] ', CLIENTE), IIF((SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = NotasCreditosCXC.NC) = 0, CONCAT('[0] ', CLIENTE), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_TempCXC WHERE Id_NC = NotasCreditosCXC.NC), '] ', CLIENTE))) AS [CLIENTE], RUC, Telefono AS [TELÉFONO], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM NotasCreditosCXC WHERE NC LIKE '%" + dato + "%' OR Cliente LIKE '%" + dato + "%'", con.conexion);

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
        public DataTable buscar_rpt_nc(int IdCliente, DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("exec sp_get_rpt_notas_credito_cxc '" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + IdCliente + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_rpt_nc'. " + ex.Message);
            }
        }
        public DataTable buscar_rpt_ck(int idcliente, DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("exec sp_get_rpt_ck_cxc '" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + idcliente + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'sp_get_rpt_ck'. " + ex.Message);
            }
        }
        public DataTable buscar_rpt_pagos(int idcliente, DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("exec sp_get_rpt_pagos_cxc '" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + idcliente + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'sp_get_rpt_ck'. " + ex.Message);
            }
        }
    }
}
