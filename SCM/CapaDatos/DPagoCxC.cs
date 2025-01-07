using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DPagoCxC
    {
        DConexion con;
        string texto = "Hubo un problema en la capa pago";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Id_Usuario FROM Pago_Factura_CxC ORDER BY Id", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Pago_Factura_CxC WHERE Id = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("UPDATE Pago_Factura_CxC SET Estado = 0 WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string Observacion, decimal Monto_Pago ,bool estado)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Pago_Factura_CxC SET Observacion = '" + Observacion + "', Monto_Pago = '" + Monto_Pago.ToString() + "', Estado = '" + estado + "' WHERE Id = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Pago_Factura_CxC WHERE Id = '" + id + "'", con.conexion);
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

        public DataTable buscar(string dato, DateTime dInicio, DateTime dFin)

        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    if (dato == "")
                        da = new SqlDataAdapter("SELECT  TOP(0) FROM Pago_Factura_CxC", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT * FROM Pago_Factura_CxC f  WHERE cast(f.FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date)", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT * FROM Pago_Factura_CxC f  WHERE cast(f.FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date)", con.conexion);

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
        public DataTable buscar_saldo(string id_cliente)

        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                SqlDataAdapter da;

                if (con.conectar())
                {
                    da = new SqlDataAdapter("SELECT  F. [Id] as [NUM FACTURA] , [Total] TOTAL, F.Saldo SALDO, ISNULL(F.Abono,0) ABONO, f.Observacion OBSERVACION FROM [dbo].[Factura] f   INNER JOIN  dbo.Clientes cl on f.Id_Cliente = cl.Id WHERE f.Estado = 1 and f.Saldo > 0 AND F.Id_Cliente = '" + id_cliente + "'", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Pago_Factura_CxC", con.conexion);
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

        public string guardar(string Id_Usuario,string id_cliente, DateTime fecha,  decimal monto_pago ,string tipo_pago,string num_ref, string Observacion,DataTable dtDetFactura,string moneda, decimal tipocambio)
        {
            string num_pago = "";
            try
            {
                bool resp = false;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                      
                        SqlCommand cmd = new SqlCommand("INSERT INTO Pago_Factura_CxC (Id_Usuario,Fecha_Cobro,Monto_Pago,Tipo_Pago,Num_ref_pago,Observacion,Id_Cliente,Moneda,TipoCambio) VALUES('" + Id_Usuario + "', '" + fecha.ToString("yyyy-MM-dd") + "', '" + monto_pago + "', '" + tipo_pago + "', '" + num_ref + "','" + Observacion + "', '" + id_cliente + "', '" + moneda + "', '" + tipocambio.ToString() + "') SELECT @@IDENTITY", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        var id_pago = cmd.ExecuteScalar();

                        if (id_pago != null)
                        {
                           ///Se asigna el id del pago
                           num_pago = id_pago.ToString();

                          if (dtDetFactura.Rows.Count>0)
                            {
                                for (int i = 0; i < dtDetFactura.Rows.Count; i++)
                                {
                                    string num_factura = dtDetFactura.Rows[i]["num_factura"].ToString();
                                    string monto = dtDetFactura.Rows[i]["monto"].ToString();

                                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Pago_Det_Factura_CxC (Id_Pago,Factura,Monto,Estado) VALUES('" + id_pago + "', '" + num_factura + "', '" + monto + "',1) SELECT @@IDENTITY", con.conexion);
                                    cmd2.CommandType = CommandType.Text;
                                    cmd2.ExecuteScalar();
                                }
                           }

                        ///Actualizamos el saldo del cliente
                        SqlCommand cmd3 = new SqlCommand("EXEC dbo.sp_calcular_saldo '"+  id_cliente +"'", con.conexion);
                        cmd3.CommandType = CommandType.Text;
                        cmd3.ExecuteScalar();
                        
                    }
                    resp = true;
                }

                return num_pago;
            }
            catch (Exception ex)
            {
                ///Realizamos rollback
                SqlCommand cmd = new SqlCommand("DELETE Pago_Factura_CxC WHERE Id = '"+ num_pago + "'; DELETE Pago_Det_Factura_CxC WHERE Id_Pago = '" + num_pago + "'; EXEC dbo.sp_calcular_saldo '"+ id_cliente  +"'", con.conexion);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteScalar();

                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }
        public bool guardar_factura_tem(string id_factura, string Id_Orden, string Id_Contrato, decimal Subtotal, string Id_Usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    if (id_factura == "0")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Det_Factura_temp (Id_Factura,Id_Orden,Id_Contrato,Subtotal,Id_Usuario) VALUES('" + id_factura + "', '" + Id_Orden + "', '" + Id_Contrato + "', '" + Subtotal.ToString() + "', '" + Id_Usuario + "')", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Det_Factura (Id_Factura,Id_Orden,Id_Contrato,Subtotal) VALUES('" + id_factura + "', '" + Id_Orden + "', '" + Id_Orden + "', '" + Subtotal.ToString() + "')", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
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
        public bool quitar_todo_servicio_tem(string Id_Factura, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("DELETE  Det_Factura_temp WHERE  Id_Factura = '" + Id_Factura + "' AND  Id_Usuario = '" + id_usuario + "'", con.conexion);
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
        public bool quitar_servicio_tem(string id_factura, string Id_Orden, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    if (id_factura == "0")
                    {
                        SqlCommand cmd = new SqlCommand("DELETE  Det_Factura_temp WHERE  Id_Factura = '" + id_factura + "' AND  Id_Orden = '" + Id_Orden + "' AND Id_Usuario = '" + id_usuario + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("DELETE  Det_Factura WHERE  Id_Factura = '" + id_factura + "' AND  Id_Orden = '" + Id_Orden + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
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
        public bool quitar_contrato_tem(string id_factura, string id_contrato, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    if (id_factura == "0")
                    {
                        SqlCommand cmd = new SqlCommand("DELETE  Det_Factura_temp WHERE  Id_Factura = '" + id_factura + "' AND  Id_Contrato = '" + id_contrato + "' AND Id_Usuario = '" + id_usuario + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("DELETE  Det_Factura WHERE  Id_Factura = '" + id_factura + "' AND  Id_Contrato = '" + id_contrato + "'", con.conexion);
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
                    if (id_orden == "0")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  ft.[Id_Orden] [NUM ORDEN] ,  (select STUFF((SELECT ',' + ser.Servicio from dbo.Orden_Servicio so  inner join dbo.Det_Orden_Servicio dso on  so.Id = dso.Id_Orden  inner join dbo.Servicios ser on dso.Id_Servicio = ser.Id  where  dso.Id_Orden = ft.Id_Orden FOR XML PATH('')) ,1,1,'') AS Composicion) SERVICIOS,[Subtotal] [SUBTOTAL] FROM [SGP].[dbo].[Det_Factura_temp] ft WHERE ft.Id_Factura = '" + id_orden + "' and ft.Id_Usuario = '" + id_usuario + "'", con.conexion);
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  ft.[Id_Orden] [NUM ORDEN] ,  (select STUFF((SELECT ',' + ser.Servicio from dbo.Orden_Servicio so  inner join dbo.Det_Orden_Servicio dso on  so.Id = dso.Id_Orden  inner join dbo.Servicios ser on dso.Id_Servicio = ser.Id  where  dso.Id_Orden = ft.Id_Orden FOR XML PATH('')) ,1,1,'') AS Composicion) SERVICIOS,[Subtotal] [SUBTOTAL] FROM [SGP].[dbo].[Det_Factura] ft WHERE ft.Id_Factura = '" + id_orden + "'", con.conexion);
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

        public DataTable Obtener_pago_factura(string id_factura)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                      SqlDataAdapter da = new SqlDataAdapter("SELECT p.Id,p.Estado,usr.Usuario, Fecha_Cobro [Fecha], tp.Tipo,Num_ref_pago [Num Referencia],dp.Monto,p.FechaHora_Reg [Fecha Sistema] FROM [dbo].[Pago_Factura_CxC] p inner join [dbo].[Pago_Det_Factura_CxC] dp on p.Id = dp.Id_Pago inner join [dbo].[Tipo_Pago] tp on Tipo_Pago = tp.Id INNER JOIN dbo.Usuarios usr on p.Id_Usuario = usr.Id where  dp.Factura = '" + id_factura + "' ORDER BY p.Id DESC", con.conexion);
                      da.Fill(dt);

                     con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_pago_factura'. " + ex.Message);
            }
        }
        public DataTable Obtener_by_cliente(string id_cliente)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Id,p.Estado,Moneda,TipoCambio, usr.Usuario, Fecha_Cobro [Fecha],p.Monto_Pago [Monto Pago], tp.Tipo,Num_ref_pago [Num Referencia],p.FechaHora_Reg [Fecha Sistema] FROM [dbo].[Pago_Factura_CxC] p  inner join [dbo].[Tipo_Pago] tp on Tipo_Pago = tp.Id INNER JOIN dbo.Usuarios usr on p.Id_Usuario = usr.Id where p.Estado = 1 and  p.Id_Cliente = '" + id_cliente + "' ORDER BY p.Id DESC", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Obtener_pago_factura'. " + ex.Message);
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
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  [Id_Contrato] [NUM CONTRATO] , 'CONTRATO DE SERVICIOS' SERVICIOS, FT.Subtotal [SUBTOTAL] FROM [SGP].[dbo].[Det_Factura_temp] ft  WHERE ft.Id_Factura = '" + id_contrato + "' and ft.Id_Usuario = '" + id_usuario + "'", con.conexion);
                        da.Fill(dt);
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT  [Id_Contrato] [NUM CONTRATO] , 'CONTRATO DE SERVICIOS' SERVICIOS, FT.Subtotal [SUBTOTAL] FROM [SGP].[dbo].[Det_Factura_temp] ft  = '" + id_contrato + "'", con.conexion);
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
        public decimal Obtener_subt_total_servicio(string id_orden)
        {
            try
            {
                decimal total = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Costo) Costo from [dbo].[Det_Orden_Servicio] do inner join dbo.Servicios ser on do.Id_Servicio = ser.Id  WHERE do.Id_Orden = '" + id_orden + "'", con.conexion);
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
        public decimal Obtener_subt_total_contrato(string id_contrato)
        {
            try
            {
                decimal total = 0;
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {

                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM([MONTO_TOTAL_CONTRATO]) Costo FROM [SGP].[dbo].[Contrato_Servicio] WHERE Id = '" + id_contrato + "'", con.conexion);
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
    }
}
