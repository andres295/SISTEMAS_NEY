using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DRecuperar
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DRecuperar";

        public int obtener_cont(long id_venta, string id_prod)
        {
            try
            {
                int cont = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Tablas.Contiene FROM (SELECT Id_Venta, Id_Producto, Contiene FROM Ventas_Productos_Temp UNION ALL SELECT Id_Venta, Id_Producto, Contiene FROM Ventas_Productos) AS Tablas WHERE Tablas.Id_Venta = " + id_venta + " AND Tablas.Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cont = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cont;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cont'. " + ex.Message);
            }
        }

        public int verificar_ventas_temp(long id_venta)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registro FROM Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt32(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_ventas_temp'. " + ex.Message);
            }
        }

        public void modificar_pagar(long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("UPDATE Ventas_Pago SET MontoEfectivo = " + monto_efect.ToString().Replace(",", ".") + ", Cheque = '" + cheque + "', FechaCobro = '" + fecha_cobro.ToShortDateString() + "', Id_Banco = " + id_banco + ", Cheque_Monto = " + cheque_monto.ToString().Replace(",", ".") + ", Imagen_Cheque = '" + img_cheque + "', Tranf = '" + tranf + "', Monto_Tranf = " + monto_tranf.ToString().Replace(",", ".") + ", Imagen_Tranf = '" + img_tranf + "' WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        SqlCommand cmd_ejecutar = new SqlCommand("UPDATE Productos SET Disponible = Disponible - " + item["Vendio"].ToString() + " WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + item["Id_Producto"].ToString() + "'", con.conexion);
                        cmd_ejecutar.CommandType = CommandType.Text;
                        cmd_ejecutar.ExecuteNonQuery();

                        cmd = new SqlCommand("INSERT INTO Ventas_Productos (Id_Venta,Id_Producto,Producto,Presentacion,Laboratorio,Vendio,PVP,Subtotal,IVA ,Descuento,Total_Pagar,Ganancia,Contiene,Disponible,Parcial,Lote,Vencimiento_Texto,Subtotal_DP,Subtotal_CP) SELECT Id_Venta,Id_Producto,Producto,Presentacion,Laboratorio,Vendio,PVP,Subtotal,IVA ,Descuento,Total_Pagar,Ganancia,Contiene,Disponible,Parcial,Lote,Vencimiento_Texto,Subtotal_DP,Subtotal_CP FROM Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + item["Id_Producto"].ToString() + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }

                    cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_pagar'. " + ex.Message);
            }
        }

        public DataTable obtener_datos_pago(long id_venta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Venta, MontoEfectivo, Cheque, FechaCobro, IIF(Id_Banco = 0, '', (SELECT Banco FROM Bancos WHERE Id = Ventas_Pago.Id_Banco)) AS Banco, Cheque_Monto, Imagen_Cheque, Tranf, Monto_Tranf, Imagen_Tranf FROM Ventas_Pago WHERE Id_Venta = " + id_venta + "", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos_pago'. " + ex.Message);
            }
        }

        public void eliminar_fact(long id_venta)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd,cmd2;

                    cmd2 = new SqlCommand("EXEC sp_hist_venta " + id_venta + "", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO Codigos_Ventas VALUES(" + id_venta + ")", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas WHERE Id = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas_Pago WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    /*Anulamos el STOCK DE INVENTARIO*/
                    cmd = new SqlCommand("EXEC Sp_Anula_Stock_Movimiento 'VENTA','" + id_venta + "','0'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Ventas_Productos WHERE Id_Venta = " + id_venta + "", con.conexion);
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
        public void actualizar_stock(string Id_Venta, string id, bool accion)
        {
            try
            {
                con = new DConexion();
                int captar_cantidades = 0;

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT SUM( IIF(Contiene = 0, (Vendio), (Vendio))) AS Cantidades FROM Ventas_Productos WHERE Id_Venta = '" + Id_Venta + "' AND Id_Producto = '" + id + "'", con.conexion);
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
        public void eliminar_prod(long id_venta, string id_prod)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT * FROM Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        //TEMP.
                        cmd = new SqlCommand("DELETE Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //NO TEMP.
                        cmd = new SqlCommand("SELECT Vendio FROM Ventas_Productos WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        long cant = Convert.ToInt64(cmd.ExecuteScalar());

                        cmd = new SqlCommand("UPDATE Productos SET Disponible += " + cant + " WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text; 
                        cmd.ExecuteNonQuery();

                        /*Anulamos el STOCK DE INVENTARIO*/
                        cmd = new SqlCommand("EXEC Sp_Anula_Stock_Movimiento 'VENTA','" + id_venta + "','" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE Ventas_Productos WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_prod'. " + ex.Message);
            }
        }

        public void modificar_cantidad(long id_venta, string id_prod, long cant_new, decimal ganan, decimal parc)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT top 1 vp.IVA, vp.Descuento,  pro. PVF, vp.PVP, pro.Disponible FROM Ventas_Productos vp inner join dbo.Productos pro on vp.id_producto =  IIF(pro.CodigoBarra = '', CONVERT(NVARCHAR(MAX), pro.Id), pro.CodigoBarra) WHERE IIF(pro.CodigoBarra = '', CONVERT(NVARCHAR(MAX), pro.Id), pro.CodigoBarra) = '" + id_prod + "' and vp.Id_Venta = '"+ id_venta+ "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    int captar_disp;
                    decimal captar_iva, captar_desc, captar_pvf, captar_pvp;
                    captar_iva = Convert.ToDecimal(dr[0].ToString());
                    captar_desc = Convert.ToDecimal(dr[1].ToString());
                    captar_pvf = Convert.ToDecimal(dr[2].ToString());
                    captar_pvp = Convert.ToDecimal(dr[3].ToString());
                    captar_disp = Convert.ToInt32(dr[4].ToString());
                    dr.Close();

                    if (verificar_siexiste_idprod_ventas(id_venta, id_prod) == 1)
                    {
                        //TEMP.
                        if (con.conectar())
                        {
                            cmd = new SqlCommand("UPDATE Ventas_Productos_Temp SET Vendio = " + cant_new + ", PVP = IIF(Contiene = 0, " + captar_pvp.ToString().Replace(",", ".") + ", " + captar_pvp.ToString().Replace(",", ".") + " / Contiene), Disponible = " + captar_disp + " WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery(); 
                        }
                    }
                    else
                    {
                        //NO TEMP.
                        if (con.conectar())
                        {
                            cmd = new SqlCommand("SELECT Vendio FROM Ventas_Productos WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;

                            long cant_old = Convert.ToInt64(cmd.ExecuteScalar());

                            cmd = new SqlCommand("UPDATE Ventas_Productos SET Vendio = " + cant_new + ", Disponible = " + captar_disp + " WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
  
                            //RECUPERO LA CANTIAD QUE VENDI.
                            cmd = new SqlCommand("UPDATE Productos SET Disponible += " + cant_old + " WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                            //APLICO LA NUEVA CANTIDAD.
                            cmd = new SqlCommand("UPDATE Productos SET Disponible -= " + cant_new + " WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar_cantidad'. " + ex.Message);
            }
        }

        public int verificar_siexiste_idprod_ventas(long id_venta, string id_prod)
        {
            try
            {
                int opcion = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        opcion = 1;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = " + id_venta + " AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        opcion = 2;

                    con.desconectar();
                }

                return opcion;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_siexiste_idprod_ventas'. " + ex.Message);
            }
        }

        public long obtener_vendido(string id_prod)
        {
            try
            {
                long cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Vendio FROM Ventas_Productos WHERE Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = Convert.ToInt64(cmd.ExecuteScalar());
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_vendido'. " + ex.Message);
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
                        da = new SqlDataAdapter("SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario WHERE  (Clientes.Nombres_Apellidos LIKE '%" + dato + "%' OR Usuarios.Usuario LIKE  '%" + dato + "%' OR CAST(Ventas.Id AS VARCHAR ) LIKE  '%" + dato + "%')", con.conexion);

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
                        da = new SqlDataAdapter("SELECT TOP(0) Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE],0[TOTAL A PAGAR] , Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT * FROM (SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE],isnull((select sum(ISNULL([Total_Pagar],0) )  from Ventas_Productos where Id_Venta = Ventas.Id),0) [TOTAL A PAGAR], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario WHERE  CAST(Ventas.FechaHora_Registro AS DATE) BETWEEN CAST('" + dInicio.ToShortDateString() + "' AS DATE) AND CAST('" + dFin.ToShortDateString() + "' AS DATE)) AS RESULT WHERE [TOTAL A PAGAR]>0", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT * FROM (SELECT Ventas.Id [VENTA #], Ventas.Id_Cliente [ID], '[' + CONVERT(NVARCHAR, (SELECT SUM(Tablas1.Registros) AS Registros FROM (SELECT COUNT(*) AS Registros FROM Ventas_Productos_Temp WHERE Id_Venta = Ventas.Id UNION ALL SELECT COUNT(*) AS Registros FROM Ventas_Productos WHERE Id_Venta = Ventas.Id) AS Tablas1)) + '] ' + IIF(Ventas.Id_Cliente = 0, '-', Clientes.Nombres_Apellidos) [CLIENTE],isnull((select sum(ISNULL([Total_Pagar],0) )  from Ventas_Productos where Id_Venta = Ventas.Id),0) [TOTAL A PAGAR], Usuarios.Usuario [RESPONSABLE], Ventas.FechaHora_Registro [FECHA/HORA REGISTRO] FROM Ventas INNER JOIN Clientes ON Clientes.Id = Ventas.Id_Cliente INNER JOIN Usuarios ON Usuarios.Id = Ventas.Id_Usuario WHERE  (Clientes.Nombres_Apellidos LIKE '%" + dato + "%' OR Usuarios.Usuario LIKE  '%" + dato + "%' OR CAST(Ventas.Id AS VARCHAR ) LIKE  '%" + dato + "%') AND CAST(Ventas.FechaHora_Registro AS DATE) BETWEEN CAST('" + dInicio.ToShortDateString() + "' AS DATE) AND CAST('" + dFin.ToShortDateString() + "' AS DATE)) AS RESULT WHERE [TOTAL A PAGAR]>0", con.conexion);

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
        public static DataTable buscar_venta_lista(string dato, DateTime dInicio, DateTime dFin)
        {
            return new DVentas().buscar_ventas_lista(dato, dInicio, dFin);
        }
    }
}
