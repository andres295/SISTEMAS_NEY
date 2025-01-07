using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCotizaciones
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DCotizaciones";

        public void modificar_cot(long id_cot, int id_cliente)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cotizaciones SET Id_Cliente = " + id_cliente + " WHERE Id = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_cot'. " + ex.Message);
            }
        }

        public DataTable obtener_montos_fila(int id_cot, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_montos_fila'. " + ex.Message);
            }
        }

        public DataTable obtener_montos(int id_cot)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Tablas.Subtotal) AS Subtotal, SUM(Tablas.IVA) AS IVA, SUM(Tablas.Descuento) AS Descuento, SUM(Tablas.Total_Pagar) AS Total FROM (SELECT Id_Cotizacion, Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos_Temp UNION ALL SELECT Id_Cotizacion, Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos) AS Tablas WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_montos'. " + ex.Message);
            }
        }

        public string actualizar_nombre_prov(int id_cot)
        {
            try
            {
                string nombre = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF((SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id) = 0 AND (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id) = 0, CONCAT('[0] ', Clientes.Nombres_Apellidos), IIF((SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id) = 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id), '] ', Clientes.Nombres_Apellidos), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id), '] ', Clientes.Nombres_Apellidos))) AS Cliente FROM Cotizaciones INNER JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente WHERE Cotizaciones.Id = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    nombre = cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_nombre_prov'. " + ex.Message);
            }
        }

        public int obtener_cont(int id_cot, string id_prod)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Contiene FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
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

        public DataTable obtener_cant_fracciones(int id_cot, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Vendio / Contiene AS Entero, Vendio - ((Vendio / Contiene) * Contiene) AS Fracciones FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cant_fracciones'. " + ex.Message);
            }
        }

        public int obtener_cant_enteros(int id_cot, string id_prod)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Vendio FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cant_enteros'. " + ex.Message);
            }
        }

        public void modificar_cantidad(int id_cot, string id_prod, long cant, decimal ganan, decimal parc)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT IVA, Descuento, PVF, PVP, Disponible FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    int captar_disp;
                    decimal captar_iva, captar_desc, captar_pvf, captar_pvp;
                    captar_iva = Convert.ToDecimal(dr[0].ToString()); captar_desc = Convert.ToDecimal(dr[1].ToString());
                    captar_pvf = Convert.ToDecimal(dr[2].ToString()); captar_pvp = Convert.ToDecimal(dr[3].ToString());
                    captar_disp = Convert.ToInt32(dr[4].ToString());
                    dr.Close();

                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET Vendio = " + cant + ", PVP = IIF(Contiene = 0, " + captar_pvp.ToString().Replace(",", ".") + ", " + captar_pvp.ToString().Replace(",", ".") + " / Contiene), Disponible = " + captar_disp + " WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET Subtotal = Vendio * PVP WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET IVA = Subtotal * (" + captar_iva.ToString().Replace(",", ".") + " / 100), Descuento = Subtotal * (" + captar_desc.ToString().Replace(",", ".") + " / 100) WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET Total_Pagar = (Subtotal + IVA) - Descuento, Ganancia = " + ganan.ToString().Replace(",", ".") + ", Parcial = " + parc.ToString().Replace(",", ".") + " WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
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

        public void guardar_prod(int id_cot)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("UPDATE Cotizaciones SET NameClienteTem = NULL WHERE Id = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO Cotizaciones_Productos SELECT * FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_prod'. " + ex.Message);
            }
        }

        public DataTable cargar_prod(int id_cot)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (id_cot == 0)
                        da = new SqlDataAdapter("SELECT TOP(0) Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Laboratorio AS PROVEEDOR, Vendio AS VENDIO, Disponible AS DISPONIBLE, PVP AS PVP, Subtotal AS SUBTOTAL, IVA AS IVA, Descuento AS DESCUENTO, Total_Pagar AS [TOTAL A PAGAR] FROM (SELECT Id_Producto, Producto, Presentacion, Laboratorio, Vendio, Disponible, PVP, Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos_Temp UNION ALL SELECT Id_Producto, Producto, Presentacion, Laboratorio, Vendio, Disponible, PVP, Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos) AS Tablas", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Presentacion AS PRESENTACIÓN, Laboratorio AS PROVEEDOR, Vendio AS VENDIO, Disponible AS DISPONIBLE, PVP, Subtotal AS SUBTOTAL, IVA AS IVA, Descuento AS DESCUENTO, Total_Pagar AS [TOTAL A PAGAR] FROM (SELECT Id_Cotizacion, Id_Producto, Producto, Presentacion, Laboratorio, IIF(Contiene = 0, CONVERT(NVARCHAR, Vendio), CONCAT((Vendio/Contiene), 'F', (Vendio - (Vendio/Contiene) * Contiene))) AS Vendio, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS Disponible, IIF(Contiene = 0, PVP, PVP * Contiene) AS PVP, Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos_Temp UNION ALL SELECT Id_Cotizacion, Id_Producto, Producto, Presentacion, Laboratorio, IIF(Contiene = 0, CONVERT(NVARCHAR, Vendio), CONCAT((Vendio/Contiene), 'F', (Vendio - (Vendio/Contiene) * Contiene))) AS Vendio, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) AS Vendio, IIF(Contiene = 0, PVP, PVP * Contiene) AS PVP, Subtotal, IVA, Descuento, Total_Pagar FROM Cotizaciones_Productos) AS Tablas WHERE Tablas.Id_Cotizacion = " + id_cot + "", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Cotizaciones", con.conexion);
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

        public decimal calcular_parcial(string id_prod)
        {
            try
            {
                decimal monto = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(Contiene = 0, PVP, PVP / Contiene) AS PVP, Descuento FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    decimal calcular, captar_pvp;
                    captar_pvp = Convert.ToDecimal(dr[0].ToString());
                    calcular = captar_pvp * (Convert.ToDecimal(dr[1].ToString()) / 100);
                    dr.Close();

                    monto = captar_pvp - calcular;
                }

                return monto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'calcular_parcial'. " + ex.Message);
            }
        }

        public decimal calcular_ganan(string id_prod, long cant)
        {
            try
            {
                decimal monto = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF(Contiene = 0, PVP, PVP / Contiene) AS PVP, IIF(Contiene = 0, PVF, PVF / Contiene) AS PVF FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    decimal captar_pvp, captar_pvf;
                    captar_pvp = Convert.ToDecimal(dr[0].ToString());
                    captar_pvf = Convert.ToDecimal(dr[1].ToString());
                    dr.Close();

                    monto = captar_pvp - captar_pvf;
                    monto *= cant;

                    con.desconectar();
                }

                return monto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'calcular_ganancia'. " + ex.Message);
            }
        }

        public void eliminar_prod(int id_cot, string id_prod)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
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

        public void guardar_prod_temp(int id_cot, string id_prod, int cant, decimal parcial, decimal ganan)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT Productos.Producto, Presentaciones.Presentacion, Proveedores.Proveedor, IIF(Productos.Contiene = 0, Productos.PVP, CONVERT(DECIMAL(18, 4), Productos.PVP / Productos.Contiene)) AS PVP, Productos.Contiene, Productos.Disponible, Productos.Lote, Productos.IVA, Productos.Descuento, cast(Productos.Vencimiento as datetime2) Vencimiento  FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor WHERE IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string captar_prod, captar_pres, captar_prov, captar_lote;
                    decimal captar_pvp, captar_iva_porc, captar_desc_porc;
                    int captar_cont, captar_disp;
                    DateTime captar_venc;
                    captar_prod = dr[0].ToString(); 
                    captar_pres = dr[1].ToString();
                    captar_prov = dr[2].ToString(); 
                    captar_pvp = Convert.ToDecimal(dr[3].ToString());
                    captar_cont = Convert.ToInt32(dr[4].ToString()); 
                    captar_disp = Convert.ToInt32(dr[5].ToString());
                    captar_lote = dr[6].ToString(); 
                    captar_iva_porc = Convert.ToDecimal(dr[7].ToString());
                    captar_desc_porc = Convert.ToDecimal(dr[8].ToString()); 
                    captar_venc = Convert.ToDateTime(dr[9].ToString());
                    dr.Close();

                    cmd = new SqlCommand("INSERT INTO Cotizaciones_Productos_Temp VALUES(" + id_cot + ", '" + id_prod + "', '" + captar_prod + "', '" + captar_pres + "', '" + captar_prov + "', " + cant + ", " + captar_pvp.ToString().Replace(",", ".") + ", 0, 0, 0, 0, 0, " + captar_cont + ", " + captar_disp + ", 0, '" + captar_lote + "', '')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    ///cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET Subtotal = Vendio * PVP, IVA = Subtotal * (" + captar_iva_porc.ToString().Replace(",", ".") + " / 100), Total_Pagar = (Subtotal + IVA) - Descuento, Ganancia = " + ganan.ToString().Replace(",", ".") + ", Vencimiento_Texto = CONCAT(SUBSTRING(UPPER(DATENAME(MONTH, cast('" +  captar_venc + "' as datetime2))), 0, 4), ' ', SUBSTRING(DATENAME(YEAR, cast('" + captar_venc + "' as datetime2)), 3, 3)) WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET Subtotal = Vendio * PVP, IVA = Subtotal * (" + captar_iva_porc.ToString().Replace(",", ".") + " / 100), Total_Pagar = (Subtotal + IVA) - Descuento, Ganancia = " + ganan.ToString().Replace(",", ".") + " WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    //APLICO IVA/DESCUENTO.
                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET IVA = Subtotal  * (" + captar_iva_porc.ToString().Replace(",", ".") + " / 100), Descuento = Subtotal * (" + captar_desc_porc.ToString().Replace(",", ".") + " / 100) WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    //APLICO TOTAL A PAGAR.
                    cmd = new SqlCommand("UPDATE Cotizaciones_Productos_Temp SET Total_Pagar = (Subtotal + IVA) - Descuento WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
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

        public long guardar(int pc, int id_cliente, int id_user)
        {
            try
            {
                long captar_id_venta = 0;
                con = new DConexion(); 
                if (con.conectar())
                {
                    DVentas venta = new DVentas();
                    captar_id_venta = venta.obtener_num_venta();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Cotizaciones VALUES(" + captar_id_venta + ", " + pc + ", " + id_cliente + ", " + id_user + ", GETDATE(),null)", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
                return captar_id_venta;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }

        public int num_reg_save(int id_cot)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg_save'. " + ex.Message);
            }
        }

        public int num_reg_temp(int id_cot)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg_temp'. " + ex.Message);
            }
        }

        public void pagar(int id_cot, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("INSERT INTO Ventas SELECT *,1,'' FROM Cotizaciones WHERE Id = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO Ventas_Pago VALUES(" + id_cot + ", " + monto_efect.ToString().Replace(",", ".") + ", '" + cheque + "', '" + fecha_cobro.ToShortDateString() + "', " + id_banco + ", " + cheque_monto.ToString().Replace(",", ".") + ", '" + img_cheque + "', '" + tranf + "', " + monto_tranf.ToString().Replace(",", ".") + ", '" + img_tranf + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();


                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Producto FROM Cotizaciones_Productos WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        foreach (DataRow fila in dt.Rows)
                        {
                            cmd = new SqlCommand("INSERT INTO Ventas_Productos SELECT *,0,0 FROM Cotizaciones_Productos WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + fila["Id_Producto"].ToString() + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;

                            cmd.ExecuteNonQuery();
                        }

                        foreach (DataRow fila in dt.Rows)
                        {
                            cmd = new SqlCommand("UPDATE Productos SET Disponible = Disponible - (SELECT Vendio FROM Cotizaciones_Productos WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + fila["Id_Producto"].ToString() + "') WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + fila["Id_Producto"].ToString() + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    cmd = new SqlCommand("DELETE Cotizaciones WHERE Id = " + id_cot + " DELETE Cotizaciones_Productos WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'pagar'. " + ex.Message);
            }
        }
        public void actualizar_cliente(long id_cotizacion, int id_cliente, string name_temp)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cotizaciones SET Id_Cliente = '" + id_cliente + "', NameClienteTem = '" + name_temp + "' WHERE Id = " + id_cotizacion + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_cliente'. " + ex.Message);
            }
        }
        public void eliminar_cot(int id_cot)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    //cmd = new SqlCommand("INSERT INTO Codigos_Ventas VALUES(" + id_cot + ")", con.conexion);
                    //cmd.CommandType = CommandType.Text; 
                    //cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Cotizaciones WHERE Id = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Cotizaciones_Productos WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_cot'. " + ex.Message);
            }
        }

        public int verificar_prod_temp(int id_cot, string id_prod)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = " + id_cot + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

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

        public DataTable buscar(int pc, string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Cotizaciones.Id AS [COT. #], Maquina AS [PC #], ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos) AS [NOMBRE DEL CLIENTE], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM Cotizaciones INNER JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Cotizaciones.Id AS [COT. #], Maquina AS [PC #], ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos) AS [NOMBRE DEL CLIENTE], FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM Cotizaciones INNER JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Cotizaciones.Id AS [COT. #], Cotizaciones.Maquina AS [PC #], IIF((SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id) = 0 AND (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id) = 0, CONCAT('[0] ', ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos)), IIF((SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id) = 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id),'] ', ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos)), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id),'] ', ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos)))) AS [NOMBRE DEL CLIENTE], Cotizaciones.FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM Cotizaciones INNER JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente WHERE  Clientes.Nombres_Apellidos LIKE '%" + dato + "%'", con.conexion);

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
        public DataTable buscar_by_id(int idcotizacion)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                     da = new SqlDataAdapter("SELECT Cotizaciones.Id AS [COT. #], Cotizaciones.Maquina AS [PC #], IIF((SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id) = 0 AND (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id) = 0, CONCAT('[0] ', ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos)), IIF((SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id) = 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id),'] ', ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos)), CONCAT('* [', (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id),'] ', ISNULL(Cotizaciones.NameClienteTem,Clientes.Nombres_Apellidos)))) AS [NOMBRE DEL CLIENTE], Cotizaciones.FechaHora_Registro AS [FECHA/HORA REGISTRO] FROM Cotizaciones INNER JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente WHERE  Cotizaciones.Id = '" + idcotizacion + "'", con.conexion);

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_by_id'. " + ex.Message);
            }
        }
        public DataTable buscar_cotizacion_tem(string dato, int id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Cotizaciones.Id [COT. #], Cotizaciones.Id_Cliente [ID],  CASE WHEN Cotizaciones.Id_Cliente = 1 THEN Cotizaciones.NameClienteTem ELSE IIF(Cotizaciones.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) END [CLIENTE], Usuarios.Usuario [RESPONSABLE], Cotizaciones.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Cotizaciones INNER JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Cotizaciones.Id_Usuario", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT  Cotizaciones.Id [COT. #],Cotizaciones.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos_Temp WHERE Id_Cotizacion = Cotizaciones.Id UNION ALL SELECT COUNT(*) AS Registros FROM Cotizaciones_Productos WHERE Id_Cotizacion = Cotizaciones.Id) AS Tablas1)) + '] ' + CASE WHEN Cotizaciones.Id_Cliente = 1 THEN Cotizaciones.NameClienteTem ELSE IIF(Cotizaciones.Id_Cliente = 0, 'NINGUNO', ISNULL(Clientes.Nombres_Apellidos,'NINGUNO')) END [CLIENTE], Usuarios.Usuario [RESPONSABLE], Cotizaciones.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Cotizaciones LEFT JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Cotizaciones.Id_Usuario where  Maquina = '" + id_usuario + "'  AND ( NameClienteTem  is not null and Cotizaciones.Id_Cliente = 1)", con.conexion);
                    else

                        da = new SqlDataAdapter("SELECT Cotizaciones.Id [COT. #], Cotizaciones.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Cotizaciones.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Cotizaciones.Id) AS Tablas1)) + '] ' + CASE WHEN Cotizaciones.Id_Cliente = 1 THEN Cotizaciones.NameClienteTem ELSE IIF(Cotizaciones.Id_Cliente = 0, 'NINGUNO', ISNULL(Clientes.Nombres_Apellidos,'NINGUNO')) END [CLIENTE], Usuarios.Usuario [RESPONSABLE], Cotizaciones.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Cotizaciones LEFT JOIN Clientes ON Clientes.Id = Cotizaciones.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Cotizaciones.Id_Usuario WHERE   Maquina = '" + id_usuario + "'  AND  (Cotizaciones.NameClienteTem   LIKE '%" + dato + "%' OR Clientes.Nombres_Apellidos LIKE '%" + dato + "%'  OR Usuarios.Usuario LIKE '%" + dato + "%') AND (NameClienteTem IS NOT NULL AND Id_Cliente = 1) ", con.conexion);

                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_ventas'. " + ex.Message);
            }
        }
    }
}
