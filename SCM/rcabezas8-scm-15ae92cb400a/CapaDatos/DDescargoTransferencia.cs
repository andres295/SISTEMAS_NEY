using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDescargoTransferencia
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DDescargoTransferencia";

        public DataTable obtener_datos(int pc, int id_fact)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DescargoTransferencia WHERE  Id = " + id_fact + "", con.conexion);
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

        public void eliminar_CJ(int id)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("DELETE DescargoTransferencia WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Factura, Id_Producto FROM DescargoTransferencia_Productos WHERE Id_Factura = " + id + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dt.Rows)
                        {
                            cmd = new SqlCommand("UPDATE Productos SET Disponible = Disponible + (SELECT sum(Cantidad) FROM DescargoTransferencia_Productos WHERE Id_Factura = " + id + " AND Id_Producto = '" + fila[1].ToString() + "') WHERE IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) = '" + fila[1].ToString() + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;

                            cmd.ExecuteNonQuery();
                        }

                        cmd = new SqlCommand("DELETE FROM DescargoTransferencia_Productos WHERE Id_Factura = " + id + "", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }

                    /*Anulamos el STOCK DE INVENTARIO*/
                    cmd = new SqlCommand("EXEC Sp_Anula_Stock_Movimiento 'DESCARGOTRANSFERENCIA','" + id + "','0'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_CJ'. " + ex.Message);
            }
        }

        public DataTable obtener_totales(string fact)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Subtotal) AS Subtotal FROM (SELECT Id_Factura, Subtotal FROM DescargoTransferencia_Productos_Temp UNION ALL SELECT Id_Factura, Subtotal FROM DescargoTransferencia_Productos) AS Tablas WHERE Tablas.Id_Factura = '" + fact + "'", con.conexion);
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
        public decimal valida_disponibilidad_stock(string id_prod)
        {
            try
            {
                con = new DConexion();
                decimal value = 0;
                if (con.conectar())
                {
                    SqlCommand cmd;

                    //OBTENGO LO DISPONIBLE DEL PRODUCTO.
                    cmd = new SqlCommand("SELECT isnull(sum(Disponible),0) AS Registros  FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    value = Convert.ToDecimal(cmd.ExecuteScalar());
                    con.desconectar();
                }
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'valida_disponibilidad_stock'. " + ex.Message);
            }
        }
        public int verificar_prod_temp(int id_fact, string id_prod)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos_Temp WHERE Id_Factura = " + id_fact + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        cant = Convert.ToInt32(cmd.ExecuteScalar());

                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_prod_temp'. " + ex.Message);
            }
        }

        public void guardar_prod_temp(int pc, int id_fact, string id_prod, string prod, string pres, long cant, DateTime fechavence, string lote)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    //OBTENGO LO DISPONIBLE DEL PRODUCTO.
                    cmd = new SqlCommand("SELECT Disponible, PVF, PVP, Contiene FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    long captar_disp = Convert.ToInt64(dr[0].ToString());
                    decimal captar_pvf, captar_pvp; captar_pvf = Convert.ToDecimal(dr[1].ToString()); captar_pvp = Convert.ToDecimal(dr[2].ToString());
                    int captar_cont = Convert.ToInt32(dr[3].ToString());
                    dr.Close();

                    //INSERTA EL NUEVO PRODUCTO.
                    cmd = new SqlCommand("INSERT INTO DescargoTransferencia_Productos_Temp VALUES(" + pc + ", " + id_fact + ", '" + id_prod + "', '" + prod + "', '" + pres + "', " + cant + ", " + captar_pvf.ToString().Replace(",", ".") + ", " + captar_pvp.ToString().Replace(",", ".") + ", 0, " + captar_cont + ", 0, '', '','" + fechavence.ToString("yyyy/MM/dd") + "','" + lote + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    //ACTUALIZO.
                    cmd = new SqlCommand("UPDATE DescargoTransferencia_Productos_Temp SET Subtotal = Cantidad * IIF(Contiene = 0, PVF, PVF / Contiene), Disponible = " + captar_disp + ", Cantidad_Texto = IIF(Contiene = 0, CONVERT(NVARCHAR, Cantidad), CONCAT((Cantidad/Contiene), 'F', (Cantidad - (Cantidad/Contiene) * Contiene))), Disponible_Texto = IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) WHERE Maquina = " + pc + " AND Id_Factura = " + id_fact + " AND Id_Producto = '" + id_prod + "'", con.conexion);
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

        public void modificar_CJ(int id, int id_prov, string prov, DateTime fecha_doc, string observ)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE DescargoTransferencia SET Id_Laboratorio = " + id_prov + ", Laboratorio = '" + prov + "', Fecha_Documento = '" + fecha_doc.ToShortDateString()+ "', Observacion = '" + observ + "' WHERE Id = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_CJ'. " + ex.Message);
            }
        }

        public void modificar_cantidad(int id_fact, string id_prod, long cant, DateTime vencimiento, string lote, string idItemPro)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT Disponible FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    long captar_disp = Convert.ToInt64(dr[0].ToString());
                    dr.Close();

                    cmd = new SqlCommand("UPDATE DescargoTransferencia_Productos_Temp SET Cantidad = " + cant + ", Disponible = " + captar_disp + ", FechaVence = '" + vencimiento.ToShortDateString() + "', Lote = '" + lote + "' WHERE Id_Factura = " + id_fact + " AND Id = '" + idItemPro + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE DescargoTransferencia_Productos_Temp SET Subtotal = IIF(Contiene = 0, Cantidad * PVF, Cantidad * PVF / Contiene), Cantidad_Texto = IIF(Contiene = 0, CONVERT(NVARCHAR, Cantidad), CONCAT((Cantidad/Contiene), 'F', (Cantidad - (Cantidad/Contiene) * Contiene))), Disponible_Texto = IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) WHERE Id_Factura = " + id_fact + " AND Id = '" + idItemPro + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_cantidad'. " + ex.Message);
            }            
        }

        public void guardar(int pc, int id_fact)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("INSERT INTO DescargoTransferencia_Productos ([Maquina]  ,[Id_Factura]  ,[Id_Producto] ,[Producto] ,[Presentacion] ,[Cantidad] ,[PVF] ,[PVP] ,[Subtotal] ,[Contiene] ,[Disponible],[Cantidad_Texto] ,[Disponible_Texto] ,[FechaVence]  ,[Lote] ) SELECT [Maquina]  ,[Id_Factura]  ,[Id_Producto] ,[Producto] ,[Presentacion] ,[Cantidad] ,[PVF] ,[PVP] ,[Subtotal] ,[Contiene] ,[Disponible],[Cantidad_Texto] ,[Disponible_Texto] ,[FechaVence]  ,[Lote]  FROM DescargoTransferencia_Productos_Temp where Id_Factura = '" + id_fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT Maquina, Id_Factura, Id_Producto, Cantidad,Id FROM DescargoTransferencia_Productos_Temp WHERE Maquina = " + pc + " AND Id_Factura = " + id_fact + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        cmd = new SqlCommand("UPDATE Productos SET Disponible = Disponible - (SELECT Cantidad FROM DescargoTransferencia_Productos_Temp WHERE  Id_Factura = " + id_fact + "  AND Id_Producto = '" + fila[2].ToString() + "' AND Id = '" + fila[4].ToString() + "') WHERE IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) = '" + fila[2].ToString() + "'", con.conexion);
                        cmd.CommandType = CommandType.Text; 
                        cmd.ExecuteNonQuery();

                        /*Se agrega el movimiento en STOCK*/
                        cmd = new SqlCommand("EXEC Sp_Create_Stock_Movimiento 'DEBITO','DescargoTransferencia','" + fila[2].ToString() + "','" + fila[3].ToString() + "','" + id_fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("DELETE FROM DescargoTransferencia_Productos_Temp WHERE Maquina = " + pc + " AND Id_Factura = " + id_fact + "", con.conexion);
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

        public decimal obtener_subtotal(int id_fact, string id_prod)
        {
            try
            {
                decimal monto = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Subtotal FROM DescargoTransferencia_Productos_Temp WHERE Id_Factura = " + id_fact + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    monto = Convert.ToDecimal(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return monto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_subtotal'. " + ex.Message);
            }
        }

        public DataTable obtener_enteros_fracciones(int id_fact, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Cantidad, (Cantidad /  CASE WHEN Contiene = 0 then Cantidad else   ISNULL(Contiene,0) end) AS Entero, (Cantidad - ((  Cantidad / CASE WHEN ISNULL(Contiene,0) = 0 then Cantidad else  Contiene end) * Contiene)) AS Fracciones FROM DescargoTransferencia_Productos_Temp WHERE Id_Factura = " + id_fact + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_enteros_fracciones'. " + ex.Message);
            }
        }

        public DataTable buscar_prod(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) AS [ID/CÓDIGO BARRA], Productos.PVF AS [P/COMPRA], IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS DISPONIBLE, IIF(Productos.Vencimiento = '1900-01-01' AND Productos.Lote = '', Productos.Producto, IIF(Productos.Vencimiento != '1900-01-01' AND Productos.Lote != '', Productos.Producto + ' V. ' + SUBSTRING(UPPER(DATENAME(MONTH, Vencimiento)), 0, 4) + ' ' + SUBSTRING(DATENAME(YEAR, Vencimiento), 3, 3) + ', L. ' + Productos.Lote, IIF(Productos.Vencimiento != '' AND Productos.Lote = '', Productos.Producto + ' V. ' + SUBSTRING(UPPER(DATENAME(MONTH, Vencimiento)), 0, 4) + ' ' + SUBSTRING(DATENAME(YEAR, Vencimiento), 3, 3), Productos.Producto + ' L. ' + Productos.Lote))) AS PRODUCTO, Presentaciones.Presentacion AS PRESENTACIÓN, Proveedores.Proveedor AS PROVEEDOR FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) AS [ID/CÓDIGO BARRA], Productos.PVF AS [P/COMPRA], IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS DISPONIBLE, IIF(Productos.Vencimiento = '1900-01-01' AND Productos.Lote = '', Productos.Producto, IIF(Productos.Vencimiento != '1900-01-01' AND Productos.Lote != '', Productos.Producto + ' V. ' + SUBSTRING(UPPER(DATENAME(MONTH, Vencimiento)), 0, 4) + ' ' + SUBSTRING(DATENAME(YEAR, Vencimiento), 3, 3) + ', L. ' + Productos.Lote, IIF(Productos.Vencimiento != '' AND Productos.Lote = '', Productos.Producto + ' V. ' + SUBSTRING(UPPER(DATENAME(MONTH, Vencimiento)), 0, 4) + ' ' + SUBSTRING(DATENAME(YEAR, Vencimiento), 3, 3), Productos.Producto + ' L. ' + Productos.Lote))) AS PRODUCTO, Presentaciones.Presentacion AS PRESENTACIÓN, Proveedores.Proveedor AS PROVEEDOR FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) AS [ID/CÓDIGO BARRA], Productos.PVF AS [P/COMPRA], IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS DISPONIBLE, IIF(Productos.Vencimiento = '1900-01-01' AND Productos.Lote = '', IIF(Productos.Contiene = 0, Productos.Producto, Productos.Producto), IIF(Productos.Vencimiento != '1900-01-01' AND Productos.Lote != '', IIF(Productos.Contiene = 0, Productos.Producto, Productos.Producto) + ' V. ' + SUBSTRING(UPPER(DATENAME(MONTH, Vencimiento)), 0, 4) + ' ' + SUBSTRING(DATENAME(YEAR, Vencimiento), 3, 3) + ', L. ' + Productos.Lote, IIF(Productos.Vencimiento != '' AND Productos.Lote = '', IIF(Productos.Contiene = 0, Productos.Producto, Productos.Producto) + ' V. ' + SUBSTRING(UPPER(DATENAME(MONTH, Vencimiento)), 0, 4) + ' ' + SUBSTRING(DATENAME(YEAR, Vencimiento), 3, 3), IIF(Productos.Contiene = 0, Productos.Producto, Productos.Producto) + ' L. ' + Productos.Lote))) AS PRODUCTO, Presentaciones.Presentacion AS PRESENTACIÓN, Proveedores.Proveedor AS PROVEEDOR FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor WHERE Disponible > 0 AND (IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) LIKE '" + dato + "' OR Productos.Producto LIKE '%" + dato + "%' OR Presentaciones.Presentacion LIKE '%" + dato + "%' OR Proveedores.Proveedor LIKE '%" + dato + "%')", con.conexion);

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

        public string actualizar_nombre_prov(int pc, int id_fact)
        {
            try
            {
                string nombre = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos_Temp WHERE Id_Factura = " + id_fact + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        cmd = new SqlCommand("SELECT CONCAT('[', (SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos WHERE Id_Factura = DescargoTransferencia.Id), '] ', Proveedores.Proveedor) AS Proveedor FROM DescargoTransferencia INNER JOIN Proveedores ON Proveedores.Id = DescargoTransferencia.Id_Laboratorio WHERE DescargoTransferencia.Id = " + id_fact + "", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        nombre = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT CONCAT('* [', (SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos_Temp WHERE Id_Factura = DescargoTransferencia.Id), '] ', Proveedores.Proveedor) AS Proveedor FROM DescargoTransferencia INNER JOIN Proveedores ON Proveedores.Id = DescargoTransferencia.Id_Laboratorio WHERE DescargoTransferencia.Id = " + id_fact + "", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        nombre = cmd.ExecuteScalar().ToString();
                    }

                    con.desconectar();
                }

                return nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_nombre_prov'. " + ex.Message);
            }
        }

        public void eliminar_prod(int id_fact, string id_prod)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE DescargoTransferencia_Productos_Temp WHERE Id_Factura = " + id_fact + " AND Id = '" + id_prod + "'", con.conexion);
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

        public void guardar_CJ(int pc, string alm, string mov, int id_prov, string prov, DateTime fecha_doc, string obs, int id_resp)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO DescargoTransferencia VALUES(" + pc +  ", '" + alm + "', '" + mov + "', " + id_prov + ", '" + prov + "', '" + fecha_doc.ToShortDateString() + "', '" + obs + "', GETDATE(), " + id_resp + ", 0)", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_CJ'. " + ex.Message);
            }
        }

        public int verificar_cant_prod(string id_fact)
        {
            try
            {
                con = new DConexion();
                int opcion = 0; //1 = CargoCompra_Productos_Temp, 2 = CargoCompra_Productos

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos_Temp WHERE Id_Factura = " + id_fact + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        opcion = 1;
                    else
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos WHERE Id_Factura = " + id_fact + "", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            opcion = 2;
                    }

                    con.desconectar();
                }

                return opcion;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_cant_prod'. " + ex.Message);
            }
        }

        public DataTable cargar_prod(int pc, string id_fact)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (id_fact == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Cantidad_Texto AS CANTIDAD, PVF AS [P/COMPRA], Subtotal AS SUBTOTAL,FechaVence,Lote, Id FROM DescargoTransferencia_Productos", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Cantidad_Texto AS CANTIDAD, PVF AS [P/COMPRA], Subtotal AS SUBTOTAL,FechaVence,Lote, Id  FROM (SELECT Id_Producto, Producto, Presentacion, Cantidad_Texto, PVF, Subtotal,FechaVence,Lote, Id  FROM DescargoTransferencia_Productos WHERE  Id_Factura = '" + id_fact + "' UNION ALL SELECT Id_Producto, Producto, Presentacion, Cantidad_Texto, PVF, Subtotal,FechaVence,Lote, Id  FROM DescargoTransferencia_Productos_Temp WHERE  Id_Factura = '" + id_fact + "') AS Tablas", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM DescargoTransferencia", con.conexion);
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

        public DataTable buscar_fact(int pc, string dato, DateTime dInicio, DateTime dFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, Almacen AS ALMACÉN, Laboratorio AS PROVEEDOR, Fecha_Documento AS [FECHA DOC.], Id_Resp AS RESPONSABLE, FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM DescargoTransferencia", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, Almacen AS ALMACÉN, Laboratorio AS PROVEEDOR, Fecha_Documento AS [FECHA DOC.], Id_Resp AS RESPONSABLE, FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM DescargoTransferencia  where cast(Fecha_Documento as Date) Between cast('" + dInicio.ToShortDateString() + "'as date) AND cast('" + dFin.ToShortDateString() + "' as date)", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT DescargoTransferencia.Id AS ID, Almacen AS ALMACÉN, IIF((SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos WHERE Maquina = DescargoTransferencia.Maquina AND Id_Factura = DescargoTransferencia.Id) > 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos WHERE Maquina = DescargoTransferencia.Maquina AND Id_Factura = DescargoTransferencia.Id), '] ', Laboratorio), IIF((SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos_Temp WHERE Maquina = DescargoTransferencia.Maquina AND Id_Factura = DescargoTransferencia.Id) = 0, CONCAT('[0] ', Laboratorio), CONCAT(' * [', (SELECT COUNT(*) AS Registros FROM DescargoTransferencia_Productos_Temp WHERE Maquina = DescargoTransferencia.Maquina AND Id_Factura = DescargoTransferencia.Id), '] ', Laboratorio)))  AS PROVEEDOR, Fecha_Documento AS [FECHA DOC.], Usuarios.Usuario AS RESPONSABLE, FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM DescargoTransferencia INNER JOIN Usuarios ON Usuarios.Id = DescargoTransferencia.Id_Resp WHERE  DescargoTransferencia.Laboratorio LIKE '%" + dato + "%' and cast(DescargoTransferencia.Fecha_Documento as Date) Between cast('" + dInicio.ToShortDateString() + "'as date) AND cast('" + dFin.ToShortDateString() + "' as date)", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_fact'. " + ex.Message);
            }
        }
    }
}
