using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DFactura
    {
        DConexion con;
        string texto = "Hubo un problema en la capa FacturaCxC";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Id_Usuario FROM FacturaCxC with(nolock) ORDER BY Id", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_cmb'. " + ex.Message);
            }
        }

        public DataTable obtener_datos(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FacturaCxC with(nolock) WHERE Id_Venta = " + id + "", con.conexion);
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

        public bool eliminar(int id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE FacturaCxC SET Estado = 0 WHERE Id_Venta = " + id + "", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar'. " + ex.Message);
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

                    cmd = new SqlCommand("UPDATE FacturaCxC SET Estado = 0 WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Det_FacturaCxC  WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Det_FacturaCxC_temp WHERE Id_Venta = " + id_venta + "", con.conexion);
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

        public bool modificar(int id, string Observacion, decimal Subtotal, decimal Descuento, decimal Total, bool estado)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE FacturaCxC SET Observacion = '" + Observacion + "', Subtotal = '" + Subtotal.ToString()+ "', Descuento = '" + Descuento.ToString() + "', Total = '" + Total.ToString() + "', Estado = '" + estado + "' WHERE Id = " + id + "", con.conexion);
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

        public bool verificar_si_existe(string id)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock) WHERE Id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_si_existe'. " + ex.Message);
            }
        }

        public DataTable buscar(string dato,DateTime dInicio, DateTime dFin,bool estado)

        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    if (dato == "")
                        da = new SqlDataAdapter("SELECT  TOP(0)    F. [Id_Venta] as [NUM VENTA] ,cl.Nombres_Apellidos CLIENTE,F.[Subtotal] [SUBTOTAL],f.[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA,tc.Tipo TipoPago, f.Id_Especialista,f.Id_Cliente  FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df with(nolock) on f.Id_Venta = df.Id_Venta   INNER JOIN dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id left join Tipo_Pago tc on f.Tipo_Venta = tc.Id where f.estado ='" + estado + "' ", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT DISTINCT F. [Id_Venta] as [NUM VENTA] ,cl.Nombres_Apellidos CLIENTE,F.[Subtotal] [SUBTOTAL],f.[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA,tc.Tipo TipoPago,f.Id_Especialista,f.Id_Cliente  FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df with(nolock) on f.Id_Venta = df.Id_Venta  inner join  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id left join Tipo_Pago tc on f.Tipo_Venta = tc.Id  WHERE cast(f.FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date) and  f.estado ='" + estado + "'", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT DISTINCT F. [Id_Venta] as [NUM VENTA] ,cl.Nombres_Apellidos CLIENTE,F.[Subtotal] [SUBTOTAL],f.[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA,tc.Tipo TipoPago,f.Id_Especialista,f.Id_Cliente  FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df with(nolock) on f.Id_Venta = df.Id_Venta  inner join  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id  left join Tipo_Pago tc on f.Tipo_Venta = tc.Id  WHERE  (cl.Nombres_Apellidos LIKE '%" + dato + "%' ) AND cast(f.FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date) and f.estado ='" + estado + "' ", con.conexion);

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

        public DataTable buscar_by_cliente(string dato)

        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("SELECT DISTINCT F. [Id] as [NUM FACTURA],Moneda, TipoCambio, F.[Subtotal] [SUBTOTAL],[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Observacion]  OBSERVACION,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df with(nolock) on f.Id = df.Id_Venta  inner join  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id   WHERE f.Estado = 1 and cl.Id = '" + dato +"' order by f.Id desc", con.conexion);

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

        public DataTable buscar_pendiente_pago(string dato, DateTime dInicio, DateTime dFin)

        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    if (dato == "")
                        da = new SqlDataAdapter("SELECT  TOP(0)    F. [Id] as [NUM FACTURA] ,cl.Nombres_Apellidos CLIENTE,F.[Subtotal] [SUBTOTAL],[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Observacion]  OBSERVACION,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df  with(nolock) on f.Id = df.Id_Venta   INNER JOIN dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id where F.Saldo>0 ", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT DISTINCT F. [Id] as [NUM FACTURA] ,cl.Nombres_Apellidos CLIENTE,F.[Subtotal] [SUBTOTAL],[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Observacion]  OBSERVACION,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df with(nolock) on f.Id = df.Id_Venta  inner join  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id  WHERE  F.Saldo>0 and cast(f.FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date)", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT DISTINCT F. [Id] as [NUM FACTURA] ,cl.Nombres_Apellidos CLIENTE,F.[Subtotal] [SUBTOTAL],[Descuento] DESCUENTO ,[Total] TOTAL, ISNULL(F.Abono,0) ABONO,F.Saldo SALDO,f.[Observacion]  OBSERVACION,f.[Estado] ESTADO,f.[FechaHora_Registro] FECHA FROM [dbo].[FacturaCxC] f with(nolock) INNER JOIN dbo.Det_FacturaCxC df with(nolock) on f.Id = df.Id_Venta  inner join  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id   WHERE  F.Saldo>0 and  (emp.Nombres_Apellidos LIKE '%" + dato + "%' OR  cl.Nombres_Apellidos LIKE '%" + dato + "%' ) AND cast(f.FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date)", con.conexion);

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

        public DataTable buscar_saldo_by_name(string name,string moneda)


        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                     da = new SqlDataAdapter("SELECT  F. [Id] as [NUM FACTURA] , ( SELECT  (select STUFF((SELECT ', ' +  dfac.Concepto from dbo.Det_FacturaCxC dfac with(nolock) where dfac.Id_Venta = f.Id  FOR XML PATH('')) ,1,1,'') AS Concepto) Concepto) CONCEPTO, [Total] TOTAL, F.Saldo SALDO, cast(0.00 as decimal(8,2))  ABONO, f.Observacion OBSERVACION FROM [dbo].[FacturaCxC] f with(nolock)   INNER JOIN  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id WHERE f.Moneda = '" + moneda + "' and f.Estado = 1 and f.Saldo > 0 AND cl.Nombres_Apellidos = '" + name + "'", con.conexion);

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

        public DataTable buscar_saldo(string id_cliente,string moneda)

        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("SELECT  F. [Id] as [NUM FACTURA] , ( SELECT  (select STUFF((SELECT ', ' +  dfac.Concepto from dbo.Det_FacturaCxC dfac with(nolock) where dfac.Id_Venta = f.Id  FOR XML PATH('')) ,1,1,'') AS Concepto) Concepto) CONCEPTO, [Total] TOTAL, F.Saldo SALDO, cast(0.00 as decimal(8,2))  ABONO, f.Observacion OBSERVACION FROM [dbo].[FacturaCxC] f  with(nolock)  INNER JOIN  dbo.Clientes cl with(nolock) on f.Id_Cliente = cl.Id WHERE f.moneda = '" + moneda + "' and f.Estado = 1 and f.Saldo > 0 AND F.Id_Cliente = '" + id_cliente + "'", con.conexion);

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

        public int num_reg()
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock)", con.conexion);
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

        public string guardar(string NumVenta, string id_cliente, string id_especialista, string Id_Usuario, string Observacion, decimal Subtotal, decimal Descuento, decimal Total, string moneda, decimal tipoCambio,string TipoVenta)
        {
            try
            {
                bool resp = false;
                string num_factura = "";
                con = new DConexion(); 

                if (con.conectar())
                {

                    if (TipoVenta == "2")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO FacturaCxC (Id_Venta,Id_Cliente,Id_Especialista,Id_Usuario,Observacion,Subtotal,Descuento,Total,Abono,Saldo,Moneda,TipoCambio,Tipo_Venta) VALUES('" + NumVenta + "','" + id_cliente + "','" + id_especialista + "','" + Id_Usuario + "', '" + Observacion + "', '" + Subtotal.ToString() + "', '" + Descuento.ToString() + "', '" + Total.ToString() + "', '" + 0.ToString() + "','" + Total.ToString() + "', '" + moneda + "', '" + tipoCambio.ToString() + "', '" + TipoVenta.ToString() + "') SELECT @@IDENTITY", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        num_factura = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO FacturaCxC (Id_Venta,Id_Cliente,Id_Especialista,Id_Usuario,Observacion,Subtotal,Descuento,Total,Abono,Saldo,Moneda,TipoCambio,Tipo_Venta) VALUES('" + NumVenta + "','" + id_cliente + "','" + id_especialista + "','" + Id_Usuario + "', '" + Observacion + "', '" + Subtotal.ToString() + "', '" + Descuento.ToString() + "', '" + Total.ToString() + "', '" + Total.ToString() + "','" + 0.ToString() + "', '" + moneda + "', '" + tipoCambio.ToString() + "', '" + TipoVenta.ToString() + "') SELECT @@IDENTITY", con.conexion);
                        cmd1.CommandType = CommandType.Text;
                        num_factura = cmd1.ExecuteScalar().ToString();
                    } 
                    if (num_factura != null)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Det_FacturaCxC (Id_Venta,Id_Orden,Cantidad,Subtotal,Descuento,TotalPagar,Id_Contrato,Concepto) SELECT Id_Venta, Id_Orden,Cantidad,Subtotal,Descuento,TotalPagar,Id_Contrato,Concepto FROM [dbo].[Det_FacturaCxC_temp] WHERE Id_Venta = '" + NumVenta + "' and Id_Usuario = '" + Id_Usuario + "'", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();

                        SqlCommand cmd3 = new SqlCommand("DELETE Det_FacturaCxC_temp WHERE  Id_Venta = '"+ NumVenta +"' AND  Id_Usuario = '" + Id_Usuario + "'", con.conexion);
                        cmd3.CommandType = CommandType.Text;
                        cmd3.ExecuteNonQuery();

                        /*Agregamos el ticets*/
                        SqlCommand cmd4 = new SqlCommand("EXEC Sp_Crud_Tickets '" + NumVenta + "','" + id_cliente + "','" + id_especialista + "'", con.conexion);
                        cmd4.CommandType = CommandType.Text;
                        cmd4.ExecuteNonQuery();
                    } 
                    resp = true;
                }

                return num_factura;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }

        public bool guardar_factura_tem(string id_venta, string Id_Orden,string Id_Contrato, int cantidad, decimal Subtotal,string Id_Usuario,string concepto)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    decimal total = decimal.Round(Subtotal * cantidad, 2); 
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock) WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    int validarVenta = Convert.ToInt32(cmd.ExecuteScalar());

                    if (validarVenta == 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO Det_FacturaCxC_temp (Id_Venta,Id_Orden,Id_Contrato,Cantidad,Descuento,Subtotal,TotalPagar,Id_Usuario,Concepto) VALUES('" + id_venta + "', '" + Id_Orden + "', '" + Id_Contrato + "', '" + cantidad.ToString() + "',0, '" + total.ToString() + "', '" + total.ToString() + "', '" + Id_Usuario + "', '" + concepto + "')", con.conexion);
                        cmd1.CommandType = CommandType.Text;
                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Det_FacturaCxC (Id_Venta,Id_Orden,Id_Contrato,Cantidad,Descuento,Subtotal,TotalPagar,Concepto) VALUES('" + id_venta + "', '" + Id_Orden + "', '" + Id_Orden + "', '" + cantidad.ToString() + "',0, '" + total.ToString() + "', '" + total.ToString() + "', '" + concepto + "')", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    }
                   
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_servicio_tem'. " + ex.Message);
            }
        }
        public bool valida_servicio_factura_tem(string id_venta, string id_servicio)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                { 
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock) WHERE Id_Venta = " + id_venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    int validarVenta = Convert.ToInt32(cmd.ExecuteScalar());

                    if (validarVenta == 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) AS Registros FROM Det_FacturaCxC_temp with(nolock) WHERE Id_Venta = '" + id_venta + "' and Id_Orden = '" + id_servicio + "'", con.conexion);
                        cmd1.CommandType = CommandType.Text;
                        if (Convert.ToInt32(cmd1.ExecuteScalar()) > 0)
                        {
                            resp = true;
                        }
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) AS Registros FROM Det_FacturaCxC with(nolock) WHERE Id_Venta = '" + id_venta + "' and Id_Orden = '" + id_servicio + "'", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        if (Convert.ToInt32(cmd2.ExecuteScalar()) > 0)
                        {
                            resp = true;
                        }
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_servicio_tem'. " + ex.Message);
            }
        }
        public bool update_factura_tem(string idRow,string id_servicio_orden,int cantidad,decimal descuento, decimal costo_servicio)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    decimal totalPagar = decimal.Round((costo_servicio * cantidad) - descuento, 2);
                    decimal subTotal = decimal.Round((costo_servicio * cantidad), 2);

                    SqlCommand cmd = new SqlCommand("UPDATE  Det_FacturaCxC_temp set Id_Orden = '" + id_servicio_orden + "', Cantidad = '" + cantidad.ToString() + "', Descuento = '" + descuento.ToString() + "', Subtotal = '" + subTotal.ToString() + "', TotalPagar = '" + totalPagar.ToString() + "' where id = '" + idRow + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                  
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'update_factura_tem'. " + ex.Message);
            }
        }

        public bool quitar_todo_servicio_tem(string Id_Venta, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                   
                     SqlCommand cmd = new SqlCommand("DELETE  Det_FacturaCxC_temp WHERE  /*Id_Venta = '" + Id_Venta + "' AND */ Id_Usuario = '" + id_usuario + "'", con.conexion);
                     cmd.CommandType = CommandType.Text;
                     cmd.ExecuteNonQuery();
                     resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_servicio_tem'. " + ex.Message);
            }
        }

        public bool quitar_servicio_tem(string Id_Venta, string Id_Orden, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock) WHERE Id_Venta = " + Id_Venta + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    int validarVenta = Convert.ToInt32(cmd.ExecuteScalar());

                    if (validarVenta == 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("DELETE  Det_FacturaCxC_temp WHERE  Id_Venta = '" + Id_Venta + "' AND  Id = '" + Id_Orden + "' AND Id_Usuario = '" + id_usuario + "'", con.conexion);
                        cmd1.CommandType = CommandType.Text;
                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("DELETE  Det_FacturaCxC WHERE  Id_Venta = '" + Id_Venta + "' AND  Id = '" + Id_Orden + "'", con.conexion);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    } 
                    resp = true;
                } 
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_servicio_tem'. " + ex.Message);
            }
        }

        public bool quitar_contrato_tem(string Id_Venta, string id_contrato, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    if (Id_Venta == "0")
                    {
                        SqlCommand cmd = new SqlCommand("DELETE  Det_FacturaCxC_temp WHERE  Id_Venta = '" + Id_Venta + "' AND  Id_Contrato = '" + id_contrato + "' AND Id_Usuario = '" + id_usuario + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("DELETE  Det_FacturaCxC WHERE  Id_Venta = '" + Id_Venta + "' AND  Id_Contrato = '" + id_contrato + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    } 
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_contrato_tem'. " + ex.Message);
            }
        }

        public DataTable Obtener_servicio_tem(string id_orden, string id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock) WHERE Id_Venta = " + id_orden + "", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    int validarVenta = Convert.ToInt32(cmd.ExecuteScalar());
                     
                    if (validarVenta == 0)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT ft.[Id]  , ser.Servicio SERVICIOS, [Cantidad] [CANTIDAD],  cast(ser.Costo as decimal(8,2)) COSTO,[Subtotal] [SUBTOTAL],Descuento [DESCUENTO],TotalPagar [TOTAL A PAGAR]  FROM [dbo].[Det_FacturaCxC_temp] ft with(nolock) inner join dbo.Servicios ser with(nolock) on ft.Id_Orden = ser.Id  WHERE ft.Id_Venta = '" + id_orden + "' and ft.Id_Usuario = '" + id_usuario + "'", con.conexion);
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  ft.[Id_Orden] Id  ,ser.Servicio  SERVICIOS,[Cantidad] [CANTIDAD],  cast(ser.Costo as decimal(8,2)) COSTO,[Subtotal] [SUBTOTAL],Descuento [DESCUENTO],TotalPagar [TOTAL A PAGAR] FROM [dbo].[Det_FacturaCxC] ft with(nolock) inner join dbo.Servicios ser with(nolock) on ft.Id_Orden = ser.Id WHERE ft.Id_Venta = '" + id_orden + "'", con.conexion);
                        da.Fill(dt);
                    }

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }

        public DataTable Obtener_servicio_tem_by_id(string id_orden)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                { 
                    SqlDataAdapter da = new SqlDataAdapter("SELECT id, Id_Venta,Id_Orden,Cantidad,Descuento,Subtotal,Id_Usuario,Id_Contrato,Estado,Concepto from Det_FacturaCxC_temp  ft with(nolock) WHERE ft.Id = '" + id_orden + "'", con.conexion);
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

        public string Obtener_Concepto_Orden(string id_orden)
        {
            try
            {
                DataTable dt = new DataTable();
                string concepto = "";
                con = new DConexion();

                if (con.conectar())
                {
                   SqlDataAdapter da = new SqlDataAdapter("SELECT  (select STUFF((SELECT ', ' + +'('+cast(count(ser.Id)as varchar)+') '+ser.Servicio+' ('+cast(cast(ser.Costo as decimal(8,2)) as varchar)+')' from dbo.Orden_Servicio so with(nolock)  inner join dbo.Det_Orden_Servicio dso with(nolock) on  so.Id = dso.Id_Orden  inner join dbo.Servicios ser with(nolock) on dso.Id_Servicio = ser.Id  where   so.Id =  '" + id_orden + "' group by ser.Servicio,ser.Costo FOR XML PATH('')) ,1,1,'') AS Composicion) SERVICIOS ", con.conexion);
                    da.Fill(dt);
                    if (dt.Rows.Count>0)
                    {
                        concepto = dt.Rows[0]["SERVICIOS"].ToString();
                    }
                    con.desconectar();
                } 
                return concepto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }

        public string Obtener_Concepto_contrato(string id_contrato)
        {
            try
            {
                DataTable dt = new DataTable();
                string concepto = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT [Observacion]  FROM [dbo].[Contrato_Servicio] with(nolock) where Id = '" + id_contrato +"'", con.conexion);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        concepto = dt.Rows[0]["Observacion"].ToString();
                    }
                    con.desconectar();
                }

                return concepto;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }

        public DataTable Obtener_contrato_tem(string id_contrato, string id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    if (id_contrato == "0")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  [Id_Contrato] [NUM CONTRATO] , ft.Concepto SERVICIOS, FT.Subtotal [SUBTOTAL] FROM [dbo].[Det_FacturaCxC_temp] ft  with(nolock) WHERE ft.Id_Venta = '" + id_contrato + "' and ft.Id_Usuario = '" + id_usuario + "'", con.conexion);
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  [Id_Contrato] [NUM CONTRATO] , ft.Concepto  SERVICIOS, FT.Subtotal [SUBTOTAL] FROM [dbo].[Det_FacturaCxC_temp] ft with(nolock)  WHERE ft.Id_Venta  = '" + id_contrato + "'", con.conexion);
                        da.Fill(dt);
                    }

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }

        public decimal  Obtener_subt_total_servicio(string id_orden)
        {
            try
            {
                decimal total = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                   
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Costo) Costo from [dbo].[Det_Orden_Servicio] do with(nolock)  inner join dbo.Servicios ser with(nolock)  on do.Id_Servicio = ser.Id  WHERE do.Id_Orden = '" + id_orden + "'", con.conexion);
                    da.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        total =  decimal.Parse(dt.Rows[0]["Costo"].ToString());
                    }
                    con.desconectar();
                }

                return total;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }

        public decimal Obtener_subt_total_contrato(string id_contrato)
        {
            try
            {
                decimal total = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM([MONTO_TOTAL_CONTRATO]) Costo FROM [dbo].[Contrato_Servicio]  with(nolock)  WHERE Id = '" + id_contrato + "'", con.conexion);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        total = decimal.Parse(dt.Rows[0]["Costo"].ToString());
                    }
                    con.desconectar();
                }

                return total;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }
        public void actualizar_cliente(long id_venta, int id_cliente)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE FacturaCxC SET Id_Cliente = " + id_cliente + " WHERE Id_Venta = " + id_venta + "", con.conexion);
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
        public bool verificar_siexiste_venta(long num_venta)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM FacturaCxC with(nolock)  WHERE Id_Venta = " + num_venta + "", con.conexion);
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
    }
}
