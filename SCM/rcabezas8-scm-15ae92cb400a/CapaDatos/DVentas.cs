using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVentas
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DVentas";

        public string obtener_vendio_texto(long id_venta, string id_prod)
        {
            try
            {
                string cadena = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Vendio FROM (SELECT Id_Venta, Id_Producto, IIF(Contiene = 0, CONVERT(NVARCHAR, Vendio), CONCAT((Vendio/Contiene), 'F', (Vendio - (Vendio/Contiene) * Contiene))) Vendio FROM Ventas_Productos_Temp UNION ALL SELECT Id_Venta, Id_Producto, IIF(Contiene = 0, CONVERT(NVARCHAR, Vendio), CONCAT((Vendio/Contiene), 'F', (Vendio - (Vendio/Contiene) * Contiene))) Vendio FROM Ventas_Productos) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cadena = cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_vendio_texto'. " + ex.Message);
            }
        }

        public DataTable pagar(string id_cliente, long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf, decimal monto_TC, decimal monto_TD, string Adquiriente, decimal tc_interes, string id_tipo_venta)
        {
            DataTable dt = new DataTable();
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    /*AHORA*/
                    decimal montoPago = id_tipo_venta == "1" ? monto_efect : id_tipo_venta == "3"? cheque_monto: id_tipo_venta == "4"? monto_TC: id_tipo_venta == "5"? monto_TD: id_tipo_venta == "6" || id_tipo_venta == "7" ? monto_tranf:0;


                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC sp_Create_Venta '" + id_venta + "','" + id_cliente + "','" + id_tipo_venta + "',0,'" + montoPago.ToString().Replace(",", ".") + "','" + id_banco + "','" + img_cheque + "','" + cheque + "','" + tranf + "','" + Adquiriente + "','" + tc_interes.ToString().Replace(",", ".") + "'", con.conexion);
                    ///[dbo].[sp_Create_Venta] @idVenta int,@IdCliente int,@TipoVenta int, @MultiPago int,@monto decimal (18,4),@idBanco int, @imagenCheque varchar(max),@cheque varchar(100),@trasnferencia varchar(100),@adquirente varchar(100),@interes decimal (18,4)
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'pagar'. " + ex.Message);
            }
            return dt;
        }
        public void ActualizaVenta(long id_venta, string id_cliente, string tipoVenta, string numDocumento)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    /*Actualizamos el cliente de la venta*/
                    cmd = new SqlCommand("Update Ventas Set Id_Cliente = '" + id_cliente + "',Tipo_Venta = '" + tipoVenta + "',NumDoc = '" + numDocumento + "' Where Id = '" + id_venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'ActualizaVenta'. " + ex.Message);
            }
        }
        public void ActualizaClienteVenta(long id_venta, string id_cliente)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    /*Actualizamos el cliente de la venta*/
                    cmd = new SqlCommand("EXEC SP_Actualiza_Cliente_Venta '" + id_venta + "','" + id_cliente + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                     
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'ActualizaClienteVenta'. " + ex.Message);
            }
        }
        public int credito(long id_venta, string num_factura, string id_cliente, string fecha_emision, int dia_pago, string fecha_vencimiento, decimal monto_factura, bool retencion_renta, bool retencion_iva, int tipo_venta, string origen_factura)
        {
            int id_factura_x_cobrar = 0;
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    /*Actualizamos el cliente de la venta*/
                    cmd = new SqlCommand("Update Ventas Set Id_Cliente = '" + id_cliente + "',Tipo_Venta = '" + tipo_venta + "'/*,NumeroComprobante = (select isnull(max(NumeroComprobante),0)+1 from ventas WITH (NOLOCK))*/ Where Id = '" + id_venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    /*Creamos la factura por cobrar*/
                    cmd = new SqlCommand("EXEC sp_Incluir_Cuenta_x_Cobrar '" + id_venta + "','" + num_factura + "','" + id_cliente + "','" + fecha_emision + "','" + dia_pago + "', '" + fecha_vencimiento + "','" + monto_factura.ToString().Replace(",", ".") + "',0,0,'" + monto_factura.ToString().Replace(",", ".") + "',0,'" + monto_factura.ToString().Replace(",", ".") + "','PENDIENTE'," + retencion_renta + "," + retencion_iva + ",'" + origen_factura + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    id_factura_x_cobrar = cmd.ExecuteNonQuery();

                    if (id_factura_x_cobrar > 0)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Ventas_Productos_Temp.*,isnull(prod.Disponible,0) Disponible_ult  FROM Ventas_Productos_Temp WITH (NOLOCK)  inner join Productos prod on Id_Producto = IIF(prod.CodigoBarra = '', CONVERT(NVARCHAR(MAX), prod.Id), prod.CodigoBarra)  WHERE Id_Venta = " + id_venta + "", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow item in dt.Rows)
                        {
                            SqlCommand cmd_ejecutar = new SqlCommand("UPDATE Productos SET Disponible = Disponible - " + item["Vendio"].ToString() + " WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + item["Id_Producto"].ToString() + "'", con.conexion);
                            cmd_ejecutar.CommandType = CommandType.Text;
                            cmd_ejecutar.ExecuteNonQuery();

                            cmd = new SqlCommand("INSERT INTO Ventas_Productos (Id_Venta,Id_Producto,Producto,Presentacion,Laboratorio,Vendio,PVP,Subtotal,IVA ,Descuento,Total_Pagar,Ganancia,Contiene,Disponible,Parcial,Lote,Vencimiento_Texto,Subtotal_DP,Subtotal_CP,Id_Combo,Id_Precio_Especial) SELECT Id_Venta,Id_Producto,Producto,Presentacion,Laboratorio,Vendio,PVP,Subtotal,IVA ,Descuento,Total_Pagar,Ganancia,Contiene,'" + item["Disponible_ult"].ToString().Replace(",", ".") + "',Parcial,Lote,Vencimiento_Texto,Subtotal_DP,Subtotal_CP,Id_Combo,Id_Precio_Especial FROM Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + item["Id_Producto"].ToString() + "' AND Id = '" + item["Id"].ToString() + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                            /*Ejecutamos el movimiento del stock*/
                            cmd = new SqlCommand("EXEC Sp_Create_Stock_Movimiento 'DEBITO','VENTA','"+ item["Id_Producto"].ToString() + "','"+ item["Vendio"].ToString() + "','"+ id_venta + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }

                        cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();  
                    }
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'credito'. " + ex.Message);
            }
            return id_factura_x_cobrar;
        }
        public int credito_servicio(long id_venta, string num_factura, string id_cliente, string fecha_emision, int dia_pago, string fecha_vencimiento, decimal monto_factura, bool retencion_renta, bool retencion_iva, int tipo_venta, string origen_factura)
        {
            int id_factura_x_cobrar = 0;
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
 
                    /*Creamos la factura por cobrar*/
                    cmd = new SqlCommand("EXEC sp_Incluir_Cuenta_x_Cobrar_servicio '" + id_venta + "','" + num_factura + "','" + id_cliente + "','" + fecha_emision + "','" + dia_pago + "', '" + fecha_vencimiento + "','" + monto_factura.ToString().Replace(",", ".") + "',0,0,'" + monto_factura.ToString().Replace(",", ".") + "',0,'" + monto_factura.ToString().Replace(",", ".") + "','PENDIENTE'," + retencion_renta + "," + retencion_iva + ",'" + origen_factura + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    id_factura_x_cobrar = cmd.ExecuteNonQuery();

                    //if (id_factura_x_cobrar > 0)
                    //{
                    //    SqlDataAdapter da = new SqlDataAdapter("SELECT *  FROM FacturasPorCobrar_Detalles_Producto WITH (NOLOCK) WHERE Id_Venta = " + id_venta + "", con.conexion);
                    //    da.SelectCommand.CommandType = CommandType.Text;

                    //    DataTable dt = new DataTable();
                    //    da.Fill(dt);

                    //    foreach (DataRow item in dt.Rows)
                    //    { 
                    //        /*Ejecutamos el movimiento del stock*/
                    //        cmd = new SqlCommand("EXEC Sp_Create_Stock_Movimiento 'DEBITO','VENTA','" + item["Id_Producto"].ToString() + "','" + item["Vendio"].ToString() + "','" + id_venta + "'", con.conexion);
                    //        cmd.CommandType = CommandType.Text;
                    //        cmd.ExecuteNonQuery();
                    //    }

                    //    cmd = new SqlCommand("DELETE FacturasPorCobrar_Detalles_Producto WHERE Id_Venta = " + id_venta + "", con.conexion);
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.ExecuteNonQuery();
                    //} 
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'credito'. " + ex.Message);
            }
            return id_factura_x_cobrar;
        }
        public DataTable buscar_prod_rapido(string cb)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Tablas.Id [ID/CÓDIGO BARRA], Tablas.Descuento [DESCUENTO %], Tablas.PVP, PVPX, PVFR, DISPONIBLE, PRODUCTO, Presentacion [PRESENTACIÓN], Proveedor [PROVEEDOR] FROM (SELECT IIF(CodigoBarra = '', Productos.Id, CodigoBarra) Id, PVP, Descuento, CONVERT(DECIMAL(18, 4), IIF(Descuento = 0, PVP, PVP - (PVP * (Descuento / 100)))) PVPX, CONVERT(DECIMAL(18, 4), IIF(Contiene = 0, PVP, PVP / Contiene)) PVFR, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) DISPONIBLE, Producto [PRODUCTO], Presentaciones.Presentacion, Proveedores.Proveedor FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor) AS Tablas WHERE Tablas.Id = '" + cb + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_prod_rapido'. " + ex.Message);
            }
        }

        public void guardar_prod_temp(long num_venta, string id_prod, long cant, decimal parcial, decimal ganan)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd, cmd2;

                    cmd = new SqlCommand("SELECT Productos.Producto, Presentaciones.Presentacion, Proveedores.Proveedor, IIF(Productos.Contiene = 0, Productos.PVP, CONVERT(DECIMAL(18, 4), Productos.PVP / Productos.Contiene)) AS PVP, Productos.Contiene, Productos.Disponible, Productos.Lote, Productos.IVA, Productos.Descuento, Productos.Vencimiento, IIF(Productos.Contiene = 0, Productos.PVF, CONVERT(DECIMAL(18, 4), Productos.PVF / Productos.Contiene)) AS PVF,ISNULL(Productos.Pvp_Iva,0) Pvp_Iva FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor WHERE IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string captar_prod, captar_pres, captar_prov, captar_lote;
                    decimal captar_pvp, captar_pvF, captar_iva_porc, captar_desc_porc;
                    bool pvp_iva = false;
                    int captar_cont, captar_disp;
                    DateTime captar_venc;
                    captar_prod = dr[0].ToString();
                    captar_pres = dr[1].ToString();
                    captar_prov = dr[2].ToString();
                    captar_pvp = Convert.ToDecimal(dr[3].ToString());
                    captar_pvF = Convert.ToDecimal(dr[10].ToString());
                    captar_cont = Convert.ToInt32(dr[4].ToString());
                    captar_disp = Convert.ToInt32(dr[5].ToString());
                    captar_lote = dr[6].ToString();
                    captar_iva_porc = Convert.ToDecimal(dr[7].ToString());
                    captar_desc_porc = Convert.ToDecimal(dr[8].ToString());
                    captar_venc = Convert.ToDateTime(dr[9].ToString());
                    pvp_iva = Convert.ToBoolean(dr[11].ToString());
                    dr.Close();

                    ///se valida si el iva esta incluido en el PVP
                    //if (pvp_iva)
                    //{
                    //    try
                    //    {
                    //        cmd = new SqlCommand("SELECT ISNULL(ISNULL( (SELECT ISNULL( Monto,0) FROM  IVA),0) / 100,0) + 1 AS Monto,(SELECT ISNULL( Monto,0) FROM  IVA)  AS IVA", con.conexion);
                    //        cmd.CommandType = CommandType.Text;
                    //        dr = cmd.ExecuteReader();
                    //        dr.Read();
                    //        decimal iva_parametro =  decimal.Parse(dr[0].ToString());
                    //        decimal porc_iva = decimal.Parse(dr[1].ToString());
                    //        dr.Close();

                    //        if (porc_iva > 0)
                    //        {
                    //            captar_pvp = captar_pvp / iva_parametro;
                    //            captar_iva_porc = porc_iva;
                    //        }
                    //    }
                    //    catch (Exception exe)  {}
                    //}

                    cmd = new SqlCommand("EXEC sp_Incluir_Producto_Venta_Temp " + num_venta + ", '" + id_prod + "', '" + captar_prod + "', '" + captar_pres + "', '" + captar_prov + "', " + cant.ToString().Replace(",", ".") + ", " + captar_pvp.ToString().Replace(",", ".") + ", 0, 0, 0, 0, 0, " + captar_cont + ", " + captar_disp.ToString().Replace(",", ".") + ", 0, '" + captar_lote + "', '',0,0,0,0", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd2 = new SqlCommand("EXEC sp_Aplica_Combo '" + num_venta + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_prod_temp'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(ISNULL( (SELECT ISNULL( Monto,0) FROM  IVA),0) / 100,0) AS Monto", con.conexion);
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
        public decimal obtener_monto_venta_cierre(int id_usuario)
        {
            try
            {
                decimal monto = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("EXEC sp_obtener_monto_venta_cierre '" + id_usuario + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        monto = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                    catch (Exception)  { monto = 0;  }
                    
                    con.desconectar();
                }

                return monto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_monto_venta_cierre'. " + ex.Message);
            }
        }
        public void modificar_cantidad(long id_venta, string id_prod, long cant, decimal ganan, decimal parc)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd, cmd2;

                    cmd = new SqlCommand("SELECT IVA, Descuento, PVF, PVP, Disponible,ISNULL(Pvp_Iva,0) Pvp_Iva FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    int captar_disp;
                    bool pvp_iva = false;
                    decimal captar_iva, captar_desc, captar_pvf, captar_pvp;
                    captar_iva = Convert.ToDecimal(dr[0].ToString());
                    captar_desc = Convert.ToDecimal(dr[1].ToString());
                    captar_pvf = Convert.ToDecimal(dr[2].ToString());
                    captar_pvp = Convert.ToDecimal(dr[3].ToString());
                    captar_disp = Convert.ToInt32(dr[4].ToString());
                    pvp_iva = Convert.ToBoolean(dr[5].ToString());

                    dr.Close();

                    ///se valida si el iva esta incluido en el PVP
                    //if (pvp_iva)
                    //{
                    //    try
                    //    {
                    //        cmd = new SqlCommand("SELECT ISNULL(ISNULL( (SELECT ISNULL( Monto,0) FROM  IVA),0) / 100,0) +1 AS Monto,(SELECT ISNULL( Monto,0) FROM  IVA)  AS IVA", con.conexion);
                    //        cmd.CommandType = CommandType.Text;
                    //        dr = cmd.ExecuteReader();
                    //        dr.Read();
                    //        decimal iva_parametro = decimal.Parse(dr[0].ToString());
                    //        decimal porc_iva = decimal.Parse(dr[1].ToString());
                    //        dr.Close();

                    //        if (porc_iva > 0)
                    //        {
                    //            captar_pvp = captar_pvp / iva_parametro;
                    //            captar_iva = porc_iva;
                    //        }
                    //    }
                    //    catch (Exception exe) { }
                    //}

                    cmd = new SqlCommand("UPDATE Ventas_Productos_Temp SET Vendio = " + cant.ToString().Replace(",", ".") + ", PVP = IIF(Contiene = 0, " + captar_pvp.ToString().Replace(",", ".") + ", " + captar_pvp.ToString().Replace(",", ".") + " / Contiene), Disponible = " + captar_disp.ToString().Replace(",", ".") + " WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd2 = new SqlCommand("EXEC sp_Aplica_Combo '" + id_venta + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_cantidad'. " + ex.Message);
            }
        }

        public DataTable obtener_cant_fracciones(long id_venta, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM (SELECT Vendio / Contiene AS Entero, Vendio - ((Vendio / Contiene) * Contiene) AS Fracciones, Id_Venta, Id_Producto FROM Ventas_Productos_Temp UNION ALL SELECT IIF(Contiene = 0, Vendio, Vendio / Contiene) AS Entero, IIF(Contiene = 0, 0, Vendio - ((Vendio / Contiene) * Contiene)) AS Fracciones, Id_Venta, Id_Producto FROM Ventas_Productos) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "'", con.conexion);
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

        public int obtener_cant_enteros(long id_venta, string id_prod)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM (SELECT Vendio, Id_Venta, Id_Producto FROM Ventas_Productos_Temp UNION ALL SELECT Vendio, Id_Venta, Id_Producto FROM Ventas_Productos) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "'", con.conexion);
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

        public DataTable obtener_montos_fila(long id_venta, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Tablas.Subtotal, Tablas.IVA, Tablas.Descuento, Tablas.Total_Pagar FROM (SELECT Id_Venta, Id_Producto, Subtotal, IVA, Descuento, Total_Pagar FROM Ventas_Productos_Temp UNION ALL SELECT Id_Venta, Id_Producto, Subtotal, IVA, Descuento, Total_Pagar FROM Ventas_Productos) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "'", con.conexion);
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

        public bool verificar_siexiste_prod(long id_venta, string id_prod)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) AS Registros FROM (SELECT Id_Venta, Id_Producto FROM Ventas_Productos_Temp) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    if (int.Parse(dt.Rows[0]["Registros"].ToString())>0)
                    {
                        resp = true;
                    }

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_siexiste_prod'. " + ex.Message);
            }
        }

        public bool verificar_siexiste_venta(long num_venta)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Ventas WHERE Id = " + num_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_siexiste_venta'. " + ex.Message);
            }
        }

        public DataTable cargar_prod(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC sp_Obtener_Productos_Venta '"+ id_venta + "'", con.conexion); 
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

        public DataTable cargar_count_productos_by_venta(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                   da = new SqlDataAdapter("SELECT Id_Producto FROM Ventas_Productos AS Tablas WHERE Tablas.Id_Venta = " + id_venta + "", con.conexion);

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

        public DataTable buscar_ventas(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario WHERE NOT EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND Clientes.Nombres_Apellidos LIKE '%" + dato + "%' OR NOT EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND Usuarios.Usuario LIKE '%" + dato + "%'", con.conexion);

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
        public DataTable buscar_ventas_lista(string dato, DateTime dInicio, DateTime dFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario WHERE NOT EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND Clientes.Nombres_Apellidos LIKE '%" + dato + "%' OR NOT EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND Usuarios.Usuario LIKE '%" + dato + "%'", con.conexion);

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
        public DataTable buscar_ventas_tem(string dato,int id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Ventas.Id [VENTA #], Ventas.Id_Cliente [ID],  CASE WHEN Ventas.Id_Cliente = 1 THEN Ventas.NameClienteTem ELSE IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) END [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + CASE WHEN Ventas.Id_Cliente = 1 THEN Ventas.NameClienteTem ELSE IIF(Ventas.Id_Cliente = 0, 'NINGUNO', ISNULL(Clientes.Nombres_Apellidos,'NINGUNO')) END [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas LEFT JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario where Ventas.Id not in (select Id_Venta from Ventas_Pago vp where Id_Venta = Ventas.Id ) AND Maquina = '" + id_usuario +"'", con.conexion);
                    else

                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + CASE WHEN Ventas.Id_Cliente = 1 THEN Ventas.NameClienteTem ELSE IIF(Ventas.Id_Cliente = 0, 'NINGUNO', ISNULL(Clientes.Nombres_Apellidos,'NINGUNO')) END [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas LEFT JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario WHERE   Maquina = '" + id_usuario + "' AND NOT EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND  Ventas.NameClienteTem   LIKE '%" + dato + "%' OR Clientes.Nombres_Apellidos LIKE '%" + dato + "%' OR NOT EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND Usuarios.Usuario LIKE '%" + dato + "%' and Ventas.Id not in (select Id_Venta from Ventas_Pago vp where Id_Venta = Ventas.Id )", con.conexion);

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
        public DataTable buscar_ventas_historico(string dato, int id_usuario,DateTime fInicio , DateTime fFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Ventas.Id [VENTA #], IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE],  0 VENDIDO, 0 SUBTOTAL, 0 IVA, 0 DESCUENTO, 0 [TOTAL A PAGAR], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos_temp WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, 'NINGUNO', ISNULL(Clientes.Nombres_Apellidos,'NINGUNO')) [CLIENTE], rpt.VENDIDO, rpt.SUBTOTAL, rpt.IVA, rpt.DESCUENTO, rpt.[TOTAL A PAGAR], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente  INNER JOIN (SELECT SUM(Vendio) VENDIDO, SUM(SUBTOTAL) SUBTOTAL, SUM(IVA) IVA, SUM(DESCUENTO) DESCUENTO, SUM(TOTAL_PAGAR) [TOTAL A PAGAR], Id_Venta FROM 	Ventas_Productos GROUP BY Id_Venta) rpt ON Ventas.Id = rpt.Id_Venta where Ventas.Id  in (select Id_Venta from Ventas_Pago vp where Id_Venta = Ventas.Id ) AND CAST(FechaHora_Registro AS DATE) BETWEEN CAST('" + fInicio.ToShortDateString() + "' AS DATE) AND CAST('" + fFin.ToShortDateString() + "' AS DATE)", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos_temp WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, 'NINGUNO', ISNULL(Clientes.Nombres_Apellidos,'NINGUNO')) [CLIENTE], rpt.VENDIDO, rpt.SUBTOTAL, rpt.IVA, rpt.DESCUENTO, rpt.[TOTAL A PAGAR], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente  INNER JOIN (SELECT SUM(Vendio) VENDIDO, SUM(SUBTOTAL) SUBTOTAL, SUM(IVA) IVA, SUM(DESCUENTO) DESCUENTO, SUM(TOTAL_PAGAR) [TOTAL A PAGAR], Id_Venta FROM 	Ventas_Productos GROUP BY Id_Venta) rpt ON Ventas.Id = rpt.Id_Venta WHERE   EXISTS (SELECT * FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AND Clientes.Nombres_Apellidos LIKE '%" + dato + "%' AND CAST(FechaHora_Registro AS DATE) BETWEEN CAST('" + fInicio.ToShortDateString() + "' AS DATE) AND CAST('" + fFin.ToShortDateString() + "' AS DATE)", con.conexion);

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
        public string actualizar_nombre_cliente(long id_venta)
        {
            try
            {
                string nombre = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IIF((SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id) = 0 AND (SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) = 0, CONCAT('[0] ', Clientes.Nombres_Apellidos), IIF((SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id) = 0, CONCAT('[', (SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id), '] ', Clientes.Nombres_Apellidos), CONCAT('*[', (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id), '] ', Clientes.Nombres_Apellidos))) AS Cliente FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente WHERE Ventas.Id = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    nombre = cmd.ExecuteScalar().ToString();
                    con.desconectar();
                }

                return nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_nombre_cliente'. " + ex.Message);
            }
        }

        public void actualizar_cliente(long id_venta, int id_cliente)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Ventas SET Id_Cliente = " + id_cliente + " WHERE Id = " + id_venta + "", con.conexion);
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
        public void actualizar_cliente(long id_venta, int id_cliente,string name_temp)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Ventas SET Id_Cliente = '" + id_cliente + "', NameClienteTem = '" + name_temp + "' WHERE Id = " + id_venta + "", con.conexion);
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
        public void agregar_venta(long num_venta, int pc, int id_cliente, int id_user)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Ventas ([Id], [Maquina] , [Id_Cliente] , [Id_Usuario] , [FechaHora_Registro]  , [Procesado] , [NameClienteTem] , [Tipo_Venta], [NumDoc] ) VALUES(" + num_venta + ", " + pc + ", " + id_cliente + ", " + id_user + ", GETDATE(),1,'',null,null)", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'agregar_venta'. " + ex.Message);
            }
        }

        public DataTable obtener_montos(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (id_venta == 0)
                        da = new SqlDataAdapter("SELECT 0 AS Subtotal, 0 AS IVA, 0 AS Descuento, 0 AS Total,0 AS Subtotal_DP,0 AS Subtotal_CP,0 SubTotalBruto", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT SUM(Tablas.Subtotal) AS Subtotal, SUM(Tablas.IVA) AS IVA, SUM(Tablas.Descuento) AS Descuento, SUM(Tablas.Total) AS Total,SUM(Tablas.Subtotal_DP) AS Subtotal_DP,SUM(Tablas.Subtotal_CP) AS Subtotal_CP,sum(Tablas.SubTotalBruto) SubTotalBruto FROM ( SELECT Id_Venta, SUM(Subtotal) AS Subtotal, SUM(IVA) AS IVA, SUM(Descuento) AS Descuento, SUM(Total_Pagar) AS Total, SUM(Subtotal_DP) AS Subtotal_DP, SUM(Subtotal_CP) AS Subtotal_CP,SUM(Vendio)*round(PVP,4)  SubTotalBruto FROM Ventas_Productos_Temp GROUP BY Id_Venta ,PVP UNION ALL SELECT Id_Venta, SUM(Subtotal) AS Subtotal, SUM(IVA) AS IVA, SUM(Descuento) AS Descuento, SUM(Total_Pagar) AS Total, SUM(Subtotal_DP) AS Subtotal_DP, SUM(Subtotal_CP) AS Subtotal_CP,SUM(Vendio)*round(PVP,4)  SubTotalBruto FROM Ventas_Productos  GROUP BY Id_Venta,PVP ) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + "", con.conexion);

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

        public void eliminar_fact(long id_venta)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    //cmd = new SqlCommand("INSERT INTO Codigos_Ventas VALUES(" + id_venta + ")", con.conexion);
                    //cmd.CommandType = CommandType.Text; 
                    //cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas WHERE Id = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas_Productos WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    /*Anulamos el STOCK DE INVENTARIO*/
                    cmd = new SqlCommand("EXEC Sp_Anula_Stock_Movimiento 'VENTA','" + id_venta + "','0'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas_Pago WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_fact'. " + ex.Message);
            }
        }

        public void eliminar_venta_tem(long id_venta)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    //cmd = new SqlCommand("INSERT INTO Codigos_Ventas VALUES(" + id_venta + ")", con.conexion);
                    //cmd.CommandType = CommandType.Text;
                    //cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas WHERE Id = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
 
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_fact'. " + ex.Message);
            }
        }
        public void limpia_tem(string id_usuario)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta IN (SELECT Id FROM Ventas WHERE Procesado = 0 and Id_Cliente = 0 AND id_usuario = '" + id_usuario +"')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas WHERE Procesado = 0 and Id_Cliente = 0 AND id_usuario = '" + id_usuario + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_fact'. " + ex.Message);
            }
        }
        public void limpia_tem(string id_usuario,int id_venta)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                   
                    cmd = new SqlCommand("UPDATE Ventas SET Procesado = 0  WHERE Procesado = 1 and Id_Cliente = 0 AND id_usuario = '" + id_usuario + "' and  Id = '" + id_venta + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_fact'. " + ex.Message);
            }
        }
        public void eliminar_prod(long id_venta, string id_prod)
        {
            try
            {
                SqlCommand cmd, cmd2;
                con = new DConexion();

                if (con.conectar())
                {
                    cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    cmd2 = new SqlCommand("EXEC sp_Aplica_Combo '" + id_venta + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_prod'. " + ex.Message);
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
                        da = new SqlDataAdapter("SELECT TOP(0) Tablas.Id [ID/CÓDIGO BARRA], Tablas.Descuento [DESCUENTO %], PVP, PVPX, PVFR, DISPONIBLE, PRODUCTO, Presentacion [PRESENTACIÓN], Proveedor [PROVEEDOR] FROM (SELECT IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), CodigoBarra) Id, PVP, Descuento, CONVERT(DECIMAL(18, 4), IIF(Descuento = 0, PVP, PVP - (PVP * (Descuento / 100)))) PVPX, CONVERT(DECIMAL(18, 4), IIF(Contiene = 0, PVP, PVP / Contiene)) PVFR, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) DISPONIBLE, Producto [PRODUCTO], Presentaciones.Presentacion, Proveedores.Proveedor FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor) AS Tablas", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Tablas.Id [ID/CÓDIGO BARRA], Tablas.Descuento [DESCUENTO %], PVP, PVPX, PVFR, DISPONIBLE, PRODUCTO, Presentacion [PRESENTACIÓN], Proveedor [PROVEEDOR] FROM (SELECT IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), CodigoBarra) Id, PVP, Descuento, CONVERT(DECIMAL(18, 4), IIF(Descuento = 0, PVP, PVP - (PVP * (Descuento / 100)))) PVPX, CONVERT(DECIMAL(18, 4), IIF(Contiene = 0, PVP, PVP / Contiene)) PVFR, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) DISPONIBLE, Producto [PRODUCTO], Presentaciones.Presentacion, Proveedores.Proveedor FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor) AS Tablas", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Tablas.Id [ID/CÓDIGO BARRA], Tablas.Descuento [DESCUENTO %], PVP, PVPX, PVFR, DISPONIBLE, PRODUCTO, Presentacion [PRESENTACIÓN], Proveedor [PROVEEDOR] FROM (SELECT IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), CodigoBarra) Id, PVP, Descuento, CONVERT(DECIMAL(18, 4), IIF(Descuento = 0, PVP, PVP - (PVP * (Descuento / 100)))) PVPX, CONVERT(DECIMAL(18, 4), IIF(Contiene = 0, PVP, PVP / Contiene)) PVFR, IIF(Contiene = 0, CONVERT(NVARCHAR, Disponible), CONCAT((Disponible/Contiene), 'F', (Disponible - (Disponible/Contiene) * Contiene))) DISPONIBLE, Producto [PRODUCTO], Presentaciones.Presentacion, Proveedores.Proveedor FROM Productos INNER JOIN Presentaciones ON Presentaciones.Id = Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor) AS Tablas WHERE Tablas.Producto LIKE '%" + dato + "%' OR Tablas.Presentacion LIKE '%" + dato + "%' OR Tablas.Proveedor LIKE '%" + dato + "%'", con.conexion);

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

        public long obtener_num_venta()
        {
            try
            {
                long id = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Codigos_Ventas where Id <> 0", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        //SI HAY ID ELIMINADOS.
                        cmd = new SqlCommand("SELECT Id AS Registros FROM Codigos_Ventas where Id <> 0 ORDER BY Id", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        id = Convert.ToInt64(cmd.ExecuteScalar());

                        cmd = new SqlCommand("DELETE Codigos_Ventas WHERE Id = " + id + " or Id = 0", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //NO HAY ID ELIMINADOS.
                        cmd = new SqlCommand("SELECT Documento FROM Documentos_Ventas", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        id = Convert.ToInt64(cmd.ExecuteScalar());

                        cmd = new SqlCommand("UPDATE Documentos_Ventas SET Documento = (Documento + 1)", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                    
                    con.desconectar();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_num_venta'. " + ex.Message);
            }
        }

        public DataTable rpt_venta(DateTime dtInicio,  DateTime dtFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                   
                        SqlDataAdapter da;
                        da = new SqlDataAdapter("EXEC Ventas_diaria '" + dtInicio.ToShortDateString() + "','"+ dtFin.ToShortDateString() + "'", con.conexion);
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
        public bool siFacturaCreditoExiste(string id_factura)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                try
                {
                    if (con.conectar())
                    {
                        SqlDataAdapter da;

                        da = new SqlDataAdapter("select count(1) factura from  FacturasPorCobrar  WITH (NOLOCK) where Factura = '" + id_factura + "'", con.conexion);

                        da.SelectCommand.CommandType = CommandType.Text;

                        da.Fill(dt);
                        con.desconectar();
                    }
                    if (int.Parse(dt.Rows[0]["factura"].ToString()) > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch (Exception) { return true; }

            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'siFacturaCreditoExiste'. " + ex.Message);
            }
        }
        public int SolicitaPrecioEspecial(int Id_Venta, int Id_Det_Venta, string Id_Producto, decimal Precio_Especial, decimal Cantidad, string Usuario_Solicita)
        {
            try
            {
                con = new DConexion();
                int result = 0;

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("INSERT INTO Venta_Precio_Especial (Id_Venta ,Id_Det_Venta ,Id_Producto ,Precio_Especial ,Cantidad ,Usuario_Solicita ,CreateDate,Estado ) VALUES(" + Id_Venta + ", " + Id_Det_Venta + ", '" + Id_Producto + "', '" + Precio_Especial.ToString().Replace(",", ".") + "', '" + Cantidad.ToString().Replace(",", ".") + "','" + Usuario_Solicita + "',getdate(),'Pendiente')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                    con.desconectar();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'SolicitaPrecioEspecial'. " + ex.Message);
                return 0;
            }
        }
        public DataTable Obtener_Solicitud_Precio_Especial(string estado, DateTime dtInicio, DateTime dtFin)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC sp_Obtener_Solicitud_Precio_Especial '" + estado.Trim() + "','" + dtInicio.ToShortDateString() + "','" + dtFin.ToShortDateString() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtner_Solicitud_Precio_Especial'. " + ex.Message);
            }
        }
        public int Cantidad_Solicitud_Precio_Especial(int id_venta)
        {
            try
            {
                int result = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) AS Registros from Venta_Precio_Especial inner join Ventas_Productos_Temp ven on Venta_Precio_Especial.Id_Venta = ven.Id_Venta  and Id_Det_Venta = ven.Id   where Venta_Precio_Especial.Id_Venta = '" + id_venta + "' and Estado in ('Pendiente','Aprobada')", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        result = int.Parse(dt.Rows[0]["Registros"].ToString());
                    }
                    con.desconectar();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Cantidad_Solicitud_Precio_Especial'. " + ex.Message);
            }
        }
        public void ApruebaRechazaPrecioEspecial(int id_venta, int id_precio_especial, decimal precio_especial, decimal cantidad, string id_producto, string estado, string usuario)
        {
            try
            {
                con = new DConexion();
                int result = 0;

                if (con.conectar())
                {
                    SqlCommand cmd;

                    if (estado == "Aprobada")
                    {
                        cmd = new SqlCommand("UPDATE Venta_Precio_Especial SET Estado = '" + estado + "',Usuario_Aprueba = '" + usuario + "',FechaAprueba = getdate() WHERE Id = '" + id_precio_especial + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("EXEC sp_Aplica_Precio_Especial '" + id_venta + "','" + id_precio_especial + "','" + precio_especial.ToString().Replace(",", ".") + "','" + cantidad.ToString().Replace(",", ".") + "','" + id_producto + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else if (estado == "Rechazada")
                    {
                        cmd = new SqlCommand("UPDATE Venta_Precio_Especial SET Estado = '" + estado + "',Usuario_Rechaza = '" + usuario + "',FechaRechaza = getdate() WHERE Id = '" + id_precio_especial + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'ApruebaRechazaPrecioEspecial'. " + ex.Message);
            }
        }
        public DataTable obtener_cantidad(long id_venta, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT  *  FROM ( SELECT CAST(Vendio AS DECIMAL(8,2)) Vendio, Id_Venta, Id_Producto,Id FROM Ventas_Productos_Temp WITH(NOLOCK)  UNION SELECT CAST(Vendio AS DECIMAL(8,2)) Vendio, Id_Venta, Id_Producto, 0 Id FROM Ventas_Productos WITH(NOLOCK)) AS Tablas  WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "' /*AND Tablas.Id = '0'*/", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cantidad'. " + ex.Message);
            }
        }
        public DataTable Obtener_Forma_Pago_Venta_Temp(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Id,  tc.Tipo TipoPago, case when MontoEfectivo > 0 then MontoEfectivo when Cheque_Monto > 0 then Cheque_Monto when Monto_Tranf > 0 then Monto_Tranf when Monto_TC > 0 then Monto_TC when Monto_TD > 0 then Monto_TD end  Monto, case when  Cheque_Monto > 0 then Cheque else Tranf end[No.Referencia], bc.Banco, ADQUIRENTE Adquirente, TC_Interes,Imagen_Cheque FROM  dbo.TmpVentas_Pago p inner join dbo.Tipo_Pago tc on p.Tipo_Pago = tc.id  left join dbo.Bancos bc on p.Id_Banco = bc.Id  where Id_Venta = '"+id_venta+"'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Forma_Pago_Venta_Temp'. " + ex.Message);
            }
        }
        public void AgregarFormaPago(long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf, decimal monto_TC, decimal monto_TD, string Adquiriente, decimal tc_interes, string id_tipo_venta)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                { 
                    SqlCommand cmd;
                    cmd = new SqlCommand("INSERT INTO TmpVentas_Pago VALUES(" + id_venta + "," + id_tipo_venta + "," + monto_efect.ToString().Replace(",", ".") + ", '" + cheque + "', '" + fecha_cobro.ToShortDateString() + "', " + id_banco + ", " + cheque_monto.ToString().Replace(",", ".") + ", '" + img_cheque + "', '" + tranf + "', " + monto_tranf.ToString().Replace(",", ".") + ", '" + img_tranf + "', " + monto_TC.ToString().Replace(",", ".") + ", " + monto_TD.ToString().Replace(",", ".") + ", '" + Adquiriente + "', '" + tc_interes.ToString().Replace(",", ".") + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'AgregarFormaPago'. " + ex.Message);
            }
        }

        public bool eliminar_detalle_multi_pago(int id_detalle_pago)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TmpVentas_Pago WHERE Id = '" + id_detalle_pago + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_detalle_multi_pago'. " + ex.Message);
            }
        }
        public bool eliminar_detalle_multi_pago_by_usuario(int id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TmpFacturasPorPagar_Abonos WHERE  Id_Usuario  = '"+ id_usuario + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_detalle_multi_pago_by_usuario'. " + ex.Message);
            }
        }
        public DataTable pagar_multi_pago(string id_cliente, long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf, decimal monto_TC, decimal monto_TD, string Adquiriente, decimal tc_interes, string id_tipo_venta)
        {
            DataTable dt = new DataTable();
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    /*LO NUEVO*/
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC sp_Create_Venta '" + id_venta + "','" + id_cliente + "','" + id_tipo_venta + "',1,'" + monto_efect.ToString().Replace(",", ".") + "',0,'','','','',0", con.conexion);
                     /// @idVenta int, @IdCliente int, @TipoVenta int, @MultiPago int, @monto decimal(18, 4),@idBanco int, @imagenCheque varchar(max),@cheque varchar(100),@trasnferencia varchar(100),@adquirente varchar(100),@interes decimal(18, 4)
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'pagar'. " + ex.Message);
            }
            return dt;
        }
        public DataTable Obtener_Producto_Venta(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("EXEC Sp_Obtener_Productos_Servicios_Venta '" + id_venta + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Producto_Venta'. " + ex.Message);
            }
        }
        public DataTable Obtener_Producto_Venta_by_TipoPago(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC SP_Get_Det_Pago_SRI '" + id_venta + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text; 
                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_Producto_Venta_by_TipoPago'. " + ex.Message);
            }
        }
        public string ObtenerNumeroConsecutivoSR(int IdVenta)
        {
            try
            {
                int result = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {  
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC SP_Asignar_Consecutivo_Venta_SRI '" + IdVenta + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);
                    if (dt.Rows.Count>0)
                    {
                        result = int.Parse(dt.Rows[0]["NumComprobante"].ToString());
                    }
                     
                    con.desconectar();
                }
                return result.ToString().PadLeft(9, '0').ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'ObtenerNumeroConsecutivoSR'. " + ex.Message);
            }
        }
        public bool ValidaVentaEnviadaSRI(string idVenta)
        {
            try
            {
                bool flag = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("select COUNT(*) NumeroComprobante from dbo.ComprobantesSRI where EstadoEnvioSRI = 'AUTORIZADO' AND cast(NumeroComprobante as int)  = (select NumeroComprobante from dbo.Ventas where Id = '" + idVenta + "' and NumeroComprobante is not null )", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        flag = true;
                    }
                    con.desconectar();
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'ValidaVentaEnviadaSRI'. " + ex.Message);
            }
        }
    }
}
