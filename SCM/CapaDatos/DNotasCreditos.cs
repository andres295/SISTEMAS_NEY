using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DNotasCreditos
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DNotasCreditos";

        public DataTable obtener_totales(string nc)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Subtotal) AS Subtotal, SUM(IVA) AS IVA, SUM(Descuento) AS Descuento, SUM(Total) AS Total FROM (SELECT Id_NC, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total  FROM NotasCreditos_Productos_Temp UNION ALL SELECT Id_NC, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_Productos) AS Tablas WHERE Tablas.Id_NC = '" + nc + "'", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Cantidad, Bonificacion, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
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

                    cmd = new SqlCommand("UPDATE NotasCreditos_productos_temp SET Cantidad = " + cant + ", Bonificacion = " + bonif + " WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT ISNULL(NULLIF( (ISNULL(IVA,0) * 100)/ (Subtotal - Descuento),0),0) IVA,ISNULL(NULLIF((Descuento*100)/Subtotal,0),0) DESCUENTO , Subtotal FROM dbo.CargoCompra_Productos WHERE Id_Factura = '" + fact + "' AND  Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();


                    decimal captar_iva, captar_desc;
                    captar_iva = Convert.ToDecimal(dr[0].ToString()) / 100;
                    captar_desc = Convert.ToDecimal(dr[1].ToString()) / 100;

                    dr.Close();

                    /*Acutlaizamos los subtotales*/
                    cmd = new SqlCommand("UPDATE NotasCreditos_productos_temp SET Subtotal = (Cantidad * PVF), IVA = Subtotal * " + captar_iva.ToString().Replace(",", ".") + ", Descuento = Subtotal * " + captar_desc.ToString().Replace(",", ".") + " WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    /*Acutlaizamos los iva y descuento*/
                    cmd = new SqlCommand("UPDATE NotasCreditos_productos_temp SET IVA = Subtotal * " + captar_iva.ToString().Replace(",", ".") + ", Descuento = Subtotal * " + captar_desc.ToString().Replace(",", ".") + " WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
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

        public int existe_prod(string nc, string fact, string id)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "' AND Id_Producto = '" + id + "'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos WHERE Id_NC = '" + nc + "'", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Cantidad AS [CANT.], Bonificacion AS [BONIF.], PVF AS [P/COMPRA], Subtotal AS [SUBTOTAL], IVA, Descuento AS [DESCUENTO], ((Subtotal + IVA) - Descuento) AS [TOTAL A DEDUCIR] FROM (SELECT Id_NC, Id_Producto, Producto, Cantidad, Bonificacion, PVF, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_Productos_Temp UNION ALL SELECT Id_NC, Id_Producto, Producto, Cantidad, Bonificacion, PVF, Subtotal, IVA, Descuento, ((Subtotal + IVA) - Descuento) AS Total FROM NotasCreditos_Productos ) AS Tablas WHERE Tablas.Id_NC = '" + nc + "'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT IIF((SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = NotasCreditos.NC) = 0 AND (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos WHERE Id_NC = NotasCreditos.NC) = 0, '[0] ' + Proveedor, IIF((SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = NotasCreditos.NC) = 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos WHERE Id_NC = NotasCreditos.NC), '] ', Proveedor), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = NotasCreditos.NC), '] ', Proveedor))) AS Proveedor FROM NotasCreditos WHERE NC = '" + nc + "'", con.conexion);
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

        public void guardar_nc(string nc, string fact, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser,string tipoNC,decimal monto)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO NotasCreditos ([NC],[Id_Factura_Afec] ,[Id_Proveedor] ,[Proveedor] ,[Fecha_Emision] ,[Matriz] ,[RUC],[Direccion] ,[Telefono] ,[Observacion] ,[FechaHora_Registro] , [TipoNC] , [Monto] ) VALUES('" + nc + "', '" + fact + "', " + id_prov + ", '" + prov + "', '" + fecha_emision.ToShortDateString() + "', '" + matriz + "', '" + ruc + "', '" + dir + "', '" + tel + "', '" + obser + "', GETDATE(), '" + tipoNC + "','" + monto.ToString().Replace(",", ".") + "')", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    if (tipoNC == "Monto")
                    {
                        cmd = new SqlCommand("UPDATE FacturasPorPagar SET Monto_NC = (ISNULL(Monto_NC,0) + " + monto.ToString().Replace(",", ".") + "), Monto_TotalPagar = (Monto_TotalPagar - " + monto.ToString().Replace(",", ".") + ") WHERE Factura = '" + fact + "'", con.conexion);
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

                    SqlCommand cmd2 = new SqlCommand("UPDATE NotasCreditos_Productos  SET  Id_NC = '" + nc + "' WHERE Id_NC = '" + nc_actual + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();


                    SqlCommand cmd3 = new SqlCommand("UPDATE NotasCreditos_Productos_Temp  SET  Id_NC = '" + nc + "' WHERE Id_NC = '" + nc_actual + "'", con.conexion);
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

                    cmd = new SqlCommand("SELECT ISNULL(SUM( IIF(Contiene = 0, (Cantidad + Bonificacion), (Cantidad * Contiene) + (Bonificacion * Contiene))),0) AS Cantidades FROM NotasCreditos_Productos WHERE Id_NC = '" + nc + "' AND Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    captar_cantidades = Convert.ToInt32(dr[0].ToString());
                    dr.Close();

                    if (captar_cantidades > 0)
                    {
                        if (accion)
                            cmd = new SqlCommand("UPDATE Productos SET Disponible = (Disponible - (" + captar_cantidades + ")) WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                        else
                            cmd = new SqlCommand("UPDATE Productos SET Disponible = (Disponible + (" + captar_cantidades + ")) WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                   
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

                    cmd = new SqlCommand("SELECT ISNULL( SUM((Subtotal + IVA) - Descuento),0) AS Totales FROM NotasCreditos_Productos WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();                    
                    captar_totales = Convert.ToDecimal(dr[0].ToString());
                    dr.Close();

                    if (captar_totales > 0)
                    {
                        cmd = new SqlCommand("UPDATE FacturasPorPagar SET Monto_NC = (Monto_NC - " + captar_totales.ToString().Replace(",", ".") + ") WHERE Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("UPDATE FacturasPorPagar SET Monto_TotalPagar = (Monto_Fact - Monto_NC) WHERE Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    } 
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

                    cmd = new SqlCommand("DELETE NotasCreditos_Productos WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "'", con.conexion);
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

        public void guardar(string nc, string fact)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    decimal captar_monto = 0;

                    cmd = new SqlCommand("SELECT SUM(((Subtotal + IVA) - Descuento)) AS Total FROM NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    captar_monto = Convert.ToDecimal(dr[0].ToString());
                    dr.Close();

                    cmd = new SqlCommand("UPDATE FacturasPorPagar SET Monto_NC = (ISNULL(Monto_NC,0) + " + captar_monto.ToString().Replace(",", ".") + "), Monto_TotalPagar = (Monto_Fact - Monto_NC) WHERE Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE NotasCreditos SET Monto =  '" + captar_monto.ToString().Replace(",", ".") + "' WHERE NC = '" + nc + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE FacturasPorPagar SET Monto_TotalPagar = (Monto_Fact - Monto_NC) WHERE Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO NotasCreditos_Productos SELECT * FROM NotasCreditos_Productos_Temp", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "' AND Id_Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    /*Se actualiza el estado de la factura*/
                    cmd = new SqlCommand("exec SP_Cancelar_Factura_CXP '" + fact + "'", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("DELETE NotasCreditos_Productos_Temp WHERE Id_NC = '" + nc + "' AND Id_Producto = '" + id + "'", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT NC, Id_Factura_Afec, Id_Proveedor, Proveedor, Fecha_Emision, Matriz, RUC, Direccion, Telefono, Observacion, Proveedor FROM NotasCreditos WHERE NC = '" + nc + "'", con.conexion);
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

        public DataTable obtener_datos_fact_sel(string num_factura)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT FacturasPorPagar.Factura, Proveedores.RUC, Proveedores.Matriz, Proveedores.Direccion, Proveedores.Telefono, Proveedores.Proveedor FROM FacturasPorPagar INNER JOIN Proveedores ON Proveedores.Id = FacturasPorPagar.Id_Proveedor WHERE FacturasPorPagar.Factura = '" + num_factura + "'", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) FacturasPorPagar.Factura AS [FACTURA #], FacturasPorPagar.Id_Proveedor AS ID, Proveedores.Proveedor AS PROVEEDOR, Proveedores.RUC, Proveedores.Telefono AS TELÉFONO FROM FacturasPorPagar INNER JOIN Proveedores ON Proveedores.Id = FacturasPorPagar.Id_Proveedor", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT FacturasPorPagar.Factura AS [FACTURA #], FacturasPorPagar.Id_Proveedor AS ID, Proveedores.Proveedor AS PROVEEDOR, Proveedores.RUC, Proveedores.Telefono AS TELÉFONO FROM FacturasPorPagar INNER JOIN Proveedores ON Proveedores.Id = FacturasPorPagar.Id_Proveedor", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT FacturasPorPagar.Factura AS [FACTURA #], FacturasPorPagar.Id_Proveedor AS ID, CONCAT('[', (SELECT COUNT(*) AS Registros FROM FacturasPorPagar_Productos WHERE Id_Factura = FacturasPorPagar.Factura), '] ', Proveedores.Proveedor) AS PROVEEDOR, Proveedores.RUC, Proveedores.Telefono AS TELÉFONO FROM FacturasPorPagar INNER JOIN Proveedores ON Proveedores.Id = FacturasPorPagar.Id_Proveedor WHERE FacturasPorPagar.Estado = 'POR PAGAR' AND (Proveedores.Proveedor LIKE '%" + dato + "%' OR   Factura = '" + dato + "' )", con.conexion);

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

        public DataTable buscar_prod(string fact, string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id_Producto AS [ID/CÓDIGO BARRA], PVF AS [P/COMPRA], Cantidad AS [CANT.], Bonificacion AS [BONIF.], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Proveedor AS PROVEEDOR FROM CargoCompra_Productos INNER JOIN Presentaciones ON Presentaciones.Id = CargoCompra_Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos.Id_Presentacion", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], PVF AS [P/COMPRA], Cantidad AS [CANT.], Bonificacion AS [BONIF.], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Proveedor AS PROVEEDOR FROM CargoCompra_Productos LEFT JOIN Presentaciones ON Presentaciones.Id = CargoCompra_Productos.Id_Presentacion LEFT JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos.Id_Presentacion WHERE CargoCompra_Productos.Id_Factura = '" + fact + "'", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], PVF AS [P/COMPRA], Cantidad AS [CANT.], Bonificacion AS [BONIF.], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Proveedor AS PROVEEDOR FROM CargoCompra_Productos LEFT JOIN Presentaciones ON Presentaciones.Id = CargoCompra_Productos.Id_Presentacion LEFT JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos.Id_Presentacion WHERE CargoCompra_Productos.Id_Factura = '" + fact + "' AND (Producto LIKE '%" + dato + "%' OR Presentaciones.Presentacion LIKE '%" + dato + "%' OR Proveedores.Proveedor LIKE '%" + dato + "%' OR CAST(Id_Producto AS VARCHAR) LIKE '%" + dato + "%')", con.conexion);

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

        public void guardar_prod_temp(string nc, string fact, string id, int cant, int bonif)
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
                    decimal iva_proc = 0, por_descuento = 0, subtotal=0;
                    decimal pvf, calc_subt, calc_iva = 0, calc_desc = 0;
                    int cont;

                    cmd = new SqlCommand("SELECT CargoCompra_Productos.Producto, CargoCompra_Productos.PVF, CargoCompra_Productos.IVA, CargoCompra_Productos.Descuento Desc_Porc, CargoCompra_Productos.Contiene FROM CargoCompra_Productos INNER JOIN CargoCompra ON CargoCompra.Factura = CargoCompra_Productos.Id_Factura WHERE CargoCompra_Productos.Id_Factura = '" + fact + "' AND CargoCompra_Productos.Id_Producto = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

     
                    try
                    {
                        da = new SqlDataAdapter("SELECT ISNULL(NULLIF( (ISNULL(IVA,0) * 100)/ (Subtotal - Descuento),0),0) IVA,ISNULL(NULLIF((Descuento*100)/Subtotal,0),0) DESCUENTO , Subtotal FROM dbo.CargoCompra_Productos WHERE Id_Factura = '" + fact + "' AND  Id_Producto = '" + id + "'", con.conexion);
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            try
                            {
                                iva_proc = decimal.Parse(dt.Rows[0]["IVA"].ToString());
                            }
                            catch (Exception) { iva_proc = 0; }
                            try
                            {
                                por_descuento = decimal.Parse(dt.Rows[0]["DESCUENTO"].ToString());
                            }
                            catch (Exception) { por_descuento = 0; }

                            try
                            {
                                subtotal = decimal.Parse(dt.Rows[0]["Subtotal"].ToString());
                            }
                            catch (Exception) { subtotal = 0; }
                        }
                    }
                    catch (Exception)  { }

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    prod = dr[0].ToString();
                    pvf = Convert.ToDecimal(dr[1].ToString());
                    calc_subt = cant * pvf;

                    if (por_descuento > 0)
                    {
                        calc_desc = (Convert.ToDecimal(dr[3].ToString()) == 0 ? 0 : calc_subt * (por_descuento / 100));

                    }

                    if (iva_proc > 0)
                    {
                        calc_iva = (Convert.ToDecimal(dr[2].ToString())== 0 ? 0 : (calc_subt - calc_desc) * (iva_proc / 100));

                    }
                  
                    cont = Convert.ToInt32(dr[4].ToString());
                    dr.Close();

                    cmd = new SqlCommand("INSERT INTO NotasCreditos_Productos_Temp VALUES('" + nc + "', '" + fact + "', '" + id + "', '" + prod + "', " + cant + ", " + bonif + ", " + pvf.ToString().Replace(",", ".") + ", " + calc_subt.ToString().Replace(",", ".") + ", " + calc_iva.ToString().Replace(",", ".") + ", " + calc_desc.ToString().Replace(",", ".") + ", " + cont + ")", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) NC AS [NC #], Id_Factura_Afec AS [FACT. AFECT. #], Proveedor AS [PROVEEDOR], RUC, Telefono AS [TELÉFONO], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM NotasCreditos", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT NC AS [NC #], Id_Factura_Afec AS [FACT. AFECT. #], Proveedor AS [PROVEEDOR], RUC, Telefono AS [TELÉFONO], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM NotasCreditos", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT NC AS [NC #], Id_Factura_Afec AS [FACT. AFECT. #], IIF((SELECT COUNT(*) As Registros FROM NotasCreditos_Productos WHERE NotasCreditos_Productos.Id_NC = NotasCreditos.NC) > 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos WHERE Id_NC = NotasCreditos.NC), '] ', Proveedor), IIF((SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = NotasCreditos.NC) = 0, CONCAT('[0] ', Proveedor), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM NotasCreditos_Productos_Temp WHERE Id_NC = NotasCreditos.NC), '] ', Proveedor))) AS [PROVEEDOR], RUC, Telefono AS [TELÉFONO], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM NotasCreditos WHERE NC LIKE '%" + dato + "%' OR Proveedor LIKE '%" + dato + "%'", con.conexion);

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
        public DataTable buscar_rpt_nc(int id_prov, DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("exec sp_get_rpt_notas_credito '" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + id_prov + "'", con.conexion);
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
        public DataTable buscar_rpt_ck(int id_prov, DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter("exec sp_get_rpt_ck '" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + id_prov + "'", con.conexion);
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

                    da = new SqlDataAdapter("exec sp_get_rpt_pagos_cxp '" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + idcliente + "'", con.conexion);
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
