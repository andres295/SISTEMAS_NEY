using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DCuentasPorPagar
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DCuentasPorPagar";

        public DataTable buscar(int id_prov, DateTime desde, DateTime hasta, string est)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    
                        da = new SqlDataAdapter("exec sp_CuentaPorPagar '" + id_prov + "','" + desde.ToShortDateString() + "','" + hasta.ToShortDateString() + "','" + est  + "'", con.conexion);
                        da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable listar_prov()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT FacturasPorPagar.Id_Proveedor, Proveedores.Proveedor FROM FacturasPorPagar INNER JOIN Proveedores ON Proveedores.Id = FacturasPorPagar.Id_Proveedor GROUP BY FacturasPorPagar.Id_Proveedor, Proveedores.Proveedor ORDER BY Proveedores.Proveedor", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'listar_prov'. " + ex.Message);
            }
        }

        public bool validar_fact_sel(int maq, string fact)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Facturas_Seleccionadas WHERE Maquina = " + maq + " AND Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'validar_fact_sel'. " + ex.Message);
            }
        }

        public void quitar_fact_todos(int maq)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Facturas_Seleccionadas WHERE Maquina = " + maq + "", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_fact_todos'. " + ex.Message);
            }
        }

        public void quitar_fact_sel(int maq, string fact)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Facturas_Seleccionadas WHERE Maquina = " + maq + " AND Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_fact_sel'. " + ex.Message);
            }
        }

        public void seleccionar_fact(int maquina, string fact, decimal monto)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Facturas_Seleccionadas VALUES(" + maquina +  ", '" + fact + "', " + monto.ToString().Replace(",", ".") + ")", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'seleccionar_fact'. " + ex.Message);
            }
        }

        public DataTable actualizar_fila_fact(string fact)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT FacturasPorPagar.Monto_Fact, FacturasPorPagar.Monto_NC, (FacturasPorPagar.Monto_Fact - FacturasPorPagar.Monto_NC) AS TotalPagar, ISNULL((SELECT SUM(Monto_Efectivo) + SUM(Monto_Multipago)  FROM FacturasPorPagar_Abonos WHERE FacturasPorPagar_Abonos.Factura = FacturasPorPagar.Factura), 0) AS Abonado, (Monto_TotalPagar - ISNULL((SELECT SUM(Monto_Efectivo) + SUM(monto_multipago)   FROM FacturasPorPagar_Abonos WHERE FacturasPorPagar_Abonos.Factura = FacturasPorPagar.Factura), 0)) AS Saldo, FacturasPorPagar.Estado FROM FacturasPorPagar WHERE FacturasPorPagar.Factura = '" + fact + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_fila_fact'. " + ex.Message);
            }
        }

        
        public int abonar_factura_multipago(int id_user, string fact)
        {
            int result = 0;
            try
            {
                DataTable dt = new DataTable(); 
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec SP_Pagar_Factura_CXP '" + fact + "','" + id_user + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text; 
                    da.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        SqlCommand cmd;
                        cmd = new SqlCommand("exec SP_Cancelar_Factura_CXP'" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        result = int.Parse(dt.Rows[0][0].ToString());
                    } 
                    con.desconectar();
                } 
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'abonar_factura_multipago'. " + ex.Message);
            }
            return result;
        }

        public void guardar_prod(string id_fact)
        {
            try
            {
                con = new DConexion();
                SqlCommand cmd;

                if (con.conectar())
                {
                    cmd = new SqlCommand("INSERT INTO FacturasPorPagar_Productos SELECT CargoCompra_Productos.Id_Factura, CargoCompra_Productos.Id_Producto, CargoCompra_Productos.Producto, CargoCompra_Productos.Id_Presentacion, CargoCompra_Productos.Cantidad, CargoCompra_Productos.Bonificacion, CargoCompra_Productos.PVF, Productos.PVP, CargoCompra_Productos.Subtotal, CargoCompra_Productos.IVA, CargoCompra_Productos.Descuento, CargoCompra_Productos.TotalPagar AS Total, CargoCompra_Productos.Contiene, CONVERT(DATE, GETDATE()) AS Fecha_Registro, CONVERT(TIME(0), GETDATE()) AS Hora_Registro, CargoCompra_Productos.Id_Usuario, Productos.Disponible, 0 AS PUR, 0 AS Utilidad_Porc, Productos.Vencimiento AS Fecha_Vencimiento, Productos.Lote FROM CargoCompra_Productos INNER JOIN Productos ON IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) = CargoCompra_Productos.Id_Producto WHERE CargoCompra_Productos.Id_Factura = '" + id_fact + "'", con.conexion);
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

        public void guardar_fact(string fact)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO FacturasPorPagar SELECT Factura, CargoCompra.Id_Proveedor, Fecha_Documento, Dias_Pago, Fecha_Pago, SUM(CargoCompra_Productos.TotalPagar) AS MontoFact, 0, SUM(CargoCompra_Productos.TotalPagar) AS MontoTotal, Estado, 0 MontoRetencion FROM CargoCompra INNER JOIN CargoCompra_Productos ON CargoCompra_Productos.Id_Factura = CargoCompra.Factura WHERE CargoCompra.Factura = '" + fact + "' GROUP BY Factura, CargoCompra.Id_Proveedor, Fecha_Documento, Dias_Pago, Fecha_Pago, Estado", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_fact'. " + ex.Message);
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
                    SqlDataAdapter da = new SqlDataAdapter("exec sp_Obtener_Totales_Factura '" + fact + "'", con.conexion);
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

        public DataTable cargar_prod(string fact)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    
                    if (fact == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id_Producto AS [ID/CÓDIGO BARRA], Producto AS PRODUCTO, Presentacion AS [PRESENTACIÓN], Cantidad AS [CANTIDAD], Bonificacion AS [BONIF.], PVF AS [P/COMPRA], Subtotal AS [SUBTOTAL], IVA AS [IVA], Descuento AS [DESCUENTO], Total AS [TOTAL A PAGAR], Fecha_Registro AS [FECHA/HORA REGISTRO] FROM (SELECT Id_Factura, Id_Producto, Producto, Presentacion, Cantidad, Bonificacion, PVF, Subtotal, IVA, Descuento, Total, Fecha_Registro FROM FacturasPorPagar_Productos) AS Tabla", con.conexion);
                    else
                        da = new SqlDataAdapter("EXEC sp_Productos_Por_Factura_Por_Pagar '" + fact + "'", con.conexion);

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
        public int cargar_id_proveedor(string fact)
        {
            try
            {
                DataTable dt = new DataTable();
                int id_proveedor = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    
                      da = new SqlDataAdapter("select Id_Proveedor from FacturasPorPagar where Factura = '" + fact + "'", con.conexion);
           
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        id_proveedor = int.Parse(dt.Rows[0]["Id_Proveedor"].ToString());
                    }
                    con.desconectar();
                }
                return id_proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_id_proveedor'. " + ex.Message);
            }
        }
        public DataTable cargar_fact_sel(int maquina)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Factura AS [FACTURA #], CAST(Monto AS DECIMAL(8,2)) AS SALDO FROM Facturas_Seleccionadas WHERE Maquina = " + maquina + "", con.conexion);
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

        public DataTable cargar_fact(int id_prov, DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT FacturasPorPagar.Factura AS [FACTURA #], CAST((Monto_TotalPagar - ISNULL((SELECT SUM(Monto_Efectivo) FROM FacturasPorPagar_Abonos WHERE FacturasPorPagar_Abonos.Factura = FacturasPorPagar.Factura), 0))AS DECIMAL(8,2)) AS SALDO FROM FacturasPorPagar WHERE FacturasPorPagar.Id_Proveedor = " + id_prov + " AND (Fecha_Emision BETWEEN '" + desde.ToShortDateString() + "' AND '" + hasta.ToShortDateString() + "') AND Estado = 'POR PAGAR'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_fact'. " + ex.Message);
            }
        }

        public DataTable cargar_vacio_fact()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("select  0 Proveedor, 0 [Factura],    0 [F.Emision],  0  AS Subtotal, 0 Descuento, 0 AS Sub12Porc,  0 AS Sub0Porc, 0 AS SubtotalSinImpuesto,  0 Iva,  0 [TotalPagar], 0 [NotaCredito], 0 [Ret.Renta],0 [Ret.Iva], 0 [Total], 0 Abono,  0 AS Saldo,  0 Estado where  1=0", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_vacio_fact'. " + ex.Message);
            }
        }
        public void AgregarFormaPago(int id_usuario, string id_factura, decimal monto_efect, string num_documento, DateTime fecha_cobro, int id_banco, decimal monto_multipago,string img_doc,string Adquiriente, decimal Interes_MultiPago, string id_tipo_pago)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("INSERT INTO TmpFacturasPorPagar_Abonos VALUES('" + id_usuario + "','" + id_factura + "','" + fecha_cobro.ToShortDateString() + "','" + monto_efect.ToString().Replace(",", ".") + "',getdate(), '" + id_tipo_pago + "','" + num_documento + "','" + id_banco + "', '" + monto_multipago.ToString().Replace(",", ".") + "', '" + img_doc + "', '" + Adquiriente + "', '" + Interes_MultiPago.ToString().Replace(",", ".") + "')", con.conexion);
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
        public DataTable Obtener_Forma_Pago_Venta_Temp(string Id_factura)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Id,  tc.Tipo TipoPago, case when Monto_Efectivo > 0 then Monto_Efectivo else Monto_Multipago end Monto, Num_Doc   [No.Referencia], bc.Banco, ADQUIRENTE Adquirente, Interes_MultiPago TC_Interes, Imagen_Doc Imagen_Cheque FROM  dbo.TmpFacturasPorPagar_Abonos p inner join dbo.Tipo_Pago tc on p.Tipo_Pago = tc.id  left join dbo.Bancos bc on p.Id_Banco = bc.Id  where Factura = '" + Id_factura + "'", con.conexion);
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
        public bool eliminar_detalle_multi_pago(int id_detalle_pago)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE TmpFacturasPorPagar_Abonos WHERE Id = '" + id_detalle_pago + "'", con.conexion);
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
        public void abonar(int id_usuario, string id_factura, decimal monto_efect, string num_documento, DateTime fecha_cobro, int id_banco, decimal monto_multipago, string img_doc, string Adquiriente, decimal Interes_MultiPago, string id_tipo_pago, string est)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("INSERT INTO FacturasPorPagar_Abonos VALUES('" + id_usuario + "', '" + id_factura + "', '" + fecha_cobro.ToShortDateString() + "', '" + monto_efect.ToString().Replace(",", ".") + "', GETDATE(), '" + id_tipo_pago + "', '" + num_documento + "', '" + id_banco + "', '" + monto_multipago.ToString().Replace(",", ".") + "', '" + img_doc + "', '" + Adquiriente + "', '" + Interes_MultiPago.ToString().Replace(",", ".") + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    if (est == "PAGADO")
                    {
                        cmd = new SqlCommand("UPDATE FacturasPorPagar SET Estado = 'PAGADO' WHERE Factura = '" + id_factura + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("UPDATE CargoCompra SET Estado = 'PAGADO' WHERE Factura = '" + id_factura + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    /*Se actualiza el estado de la factura*/
                    cmd = new SqlCommand("exec SP_Cancelar_Factura_CXP '" + id_factura + "'", con.conexion);
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
    }
}
