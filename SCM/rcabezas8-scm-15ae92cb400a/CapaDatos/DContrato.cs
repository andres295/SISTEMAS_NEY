using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DContrato
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DContrato";

        public DataTable cargar_cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Id_Cliente FROM Contrato_Servicio ORDER BY Id_Cliente", con.conexion);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Contrato_Servicio WHERE Id = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("UPDATE Contrato_Servicio SET Activa = 0 WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string id_cliente, string id_doctor, string Observacion, decimal monto_prima, decimal monto_cuota_mensual, int num_cuota, decimal monto_total_contrato, bool facturada, bool activa,string moneda)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Contrato_Servicio SET Id_Cliente = '" + id_cliente + "', Id_Doctor = '" + id_doctor + "', Observacion = '" + Observacion + "', MONTO_PRIMA = '" + monto_prima + "', MONTO_CUOTA_MENSUAL = '" + monto_cuota_mensual + "', NUM_CUOTA = '" + num_cuota + "', MONTO_TOTAL_CONTRATO = '" + monto_total_contrato + "', Facturada = '" + facturada + "', Activa = '" + activa + "', Moneda = '" + moneda + "' WHERE Id = " + id + "", con.conexion);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Contrato_Servicio WHERE Id = '" + id + "'", con.conexion);
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
                        da = new SqlDataAdapter("SELECT TOP(0) ser.[Id]  [NUM CONTRATO],  cli.Nombres_Apellidos CLIENTE, emp.Nombres_Apellidos as DOCTOR, ser.MONTO_PRIMA [PRIMA $], ser.MONTO_CUOTA_MENSUAL [CUOTA MENSUAL$], ser.NUM_CUOTA [NUM CUOTA], ser.MONTO_TOTAL_CONTRATO [MONTO TOTAL CONTRATO $],[Observacion] AS OBSERVACION, [Facturada] FACTURADA,[Activa] ACTIVO,[FechaHora_Registro] AS [FECHA CONTRATO] , Moneda MONEDA  FROM[dbo].[Contrato_Servicio] ser inner join dbo.Clientes cli  on ser.Id_Cliente = cli.Id inner join dbo.Empleados emp on ser.Id_Doctor = emp.Id", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT ser.[Id]  [NUM CONTRATO],  cli.Nombres_Apellidos CLIENTE, emp.Nombres_Apellidos as DOCTOR, ser.MONTO_PRIMA [PRIMA $], ser.MONTO_CUOTA_MENSUAL [CUOTA MENSUAL$], ser.NUM_CUOTA [NUM CUOTA], ser.MONTO_TOTAL_CONTRATO [MONTO TOTAL CONTRATO $],[Observacion] AS OBSERVACION, [Facturada] FACTURADA,[Activa] ACTIVO,[FechaHora_Registro] AS [FECHA CONTRATO], Moneda MONEDA   FROM[dbo].[Contrato_Servicio] ser inner join dbo.Clientes cli  on ser.Id_Cliente = cli.Id inner join dbo.Empleados emp on ser.Id_Doctor = emp.Id WHERE cast(FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date)", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT ser.[Id]  [NUM CONTRATO],  cli.Nombres_Apellidos CLIENTE, emp.Nombres_Apellidos as DOCTOR, ser.MONTO_PRIMA [PRIMA $], ser.MONTO_CUOTA_MENSUAL [CUOTA MENSUAL$], ser.NUM_CUOTA [NUM CUOTA], ser.MONTO_TOTAL_CONTRATO [MONTO TOTAL CONTRATO $],[Observacion] AS OBSERVACION, [Facturada] FACTURADA,[Activa] ACTIVO,[FechaHora_Registro] AS [FECHA CONTRATO] , Moneda MONEDA  FROM[dbo].[Contrato_Servicio] ser inner join dbo.Clientes cli  on ser.Id_Cliente = cli.Id inner join dbo.Empleados emp on ser.Id_Doctor = emp.Id  WHERE  (emp.Nombres_Apellidos LIKE '%" + dato + "%' OR  cli.Nombres_Apellidos LIKE '%" + dato + "%' ) AND cast(FechaHora_Registro as Date) Between cast('" + dInicio.ToString("yyyy-MM-dd") + "'as date) AND cast('" + dFin.ToString("yyyy-MM-dd") + "' as date)", con.conexion);

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
                    da = new SqlDataAdapter("SELECT ser.[Id]  [NUM CONTRATO],  emp.Nombres_Apellidos as DOCTOR, ser.MONTO_PRIMA [PRIMA $], ser.MONTO_CUOTA_MENSUAL [CUOTA MENSUAL$], ser.NUM_CUOTA [NUM CUOTA], ser.MONTO_TOTAL_CONTRATO [MONTO TOTAL CONTRATO $],[Observacion] AS OBSERVACION, [Facturada] FACTURADA,[Activa] ACTIVO,[FechaHora_Registro] AS [FECHA CONTRATO]  FROM[dbo].[Contrato_Servicio] ser inner join dbo.Clientes cli  on ser.Id_Cliente = cli.Id inner join dbo.Empleados emp on ser.Id_Doctor = emp.Id  WHERE ser.Activa = 1 and  cli.Id = '" + dato + "' ORDER BY ser.Id desc", con.conexion);

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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Contrato_Servicio", con.conexion);
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

        public bool guardar(string Maquina, string Id_Cliente, string Id_Usuario, string Id_Doctor, string Observacion,decimal monto_prima, decimal monto_cuota_mensual, int num_cuota, decimal monto_total_contrato,string moneda)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Contrato_Servicio (Maquina,Id_Cliente,Id_Usuario,Id_Doctor,Observacion,MONTO_PRIMA,MONTO_CUOTA_MENSUAL,NUM_CUOTA,MONTO_TOTAL_CONTRATO, Moneda) VALUES('" + Maquina + "', '" + Id_Cliente + "', '" + Id_Usuario + "', '" + Id_Doctor + "', '" + Observacion + "', '" + monto_prima + "', '" + monto_cuota_mensual + "', '" + num_cuota + "', '" + monto_total_contrato + "', '" + moneda + "') SELECT @@IDENTITY", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    var id_servicio_orden = cmd.ExecuteScalar();

                    //if (id_servicio_orden != null)
                    //{
                    //    SqlCommand cmd2 = new SqlCommand("INSERT INTO Det_Orden_Servicio SELECT " + id_servicio_orden + " AS Id_Orden, Id_Servicio FROM [dbo].[Det_Orden_Servicio_Tem] WHERE Id_Orden = 0 and Id_Usuario = '" + Id_Usuario + "'", con.conexion);
                    //    cmd2.CommandType = CommandType.Text;
                    //    cmd2.ExecuteNonQuery();

                    //    SqlCommand cmd3 = new SqlCommand("DELETE  Det_Orden_Servicio_Tem WHERE  Id_Orden = 0 AND  Id_Usuario = '" + Id_Usuario + "'", con.conexion);
                    //    cmd3.CommandType = CommandType.Text;
                    //    cmd3.ExecuteNonQuery();
                    //}

                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }
        public bool guardar_servicio_tem(string id_orden, string id_servicio, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    //if (id_orden == "0")
                    //{
                    //    SqlCommand cmd = new SqlCommand("INSERT INTO Det_Orden_Servicio_Tem (Id_Orden,Id_Servicio,Id_Usuario) VALUES('" + id_orden + "', '" + id_servicio + "', '" + id_usuario + "')", con.conexion);
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.ExecuteNonQuery();
                    //}
                    //else
                    //{
                    //    SqlCommand cmd = new SqlCommand("INSERT INTO Det_Orden_Servicio (Id_Orden,Id_Servicio) VALUES('" + id_orden + "', '" + id_servicio + "')", con.conexion);
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.ExecuteNonQuery();
                    //}

                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar_servicio_tem'. " + ex.Message);
            }
        }
        public bool quitar_todo_servicio_tem(string id_orden, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    //if (id_orden == "0")
                    //{
                    //    SqlCommand cmd = new SqlCommand("DELETE  Det_Orden_Servicio_Tem WHERE  Id_Orden = '" + id_orden + "' AND  Id_Usuario = '" + id_usuario + "'", con.conexion);
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.ExecuteNonQuery();
                    //}

                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_servicio_tem'. " + ex.Message);
            }
        }
        public bool quitar_servicio_tem(string id_orden, string id_servicio, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    //if (id_orden == "0")
                    //{
                    //    SqlCommand cmd = new SqlCommand("DELETE  Det_Orden_Servicio_Tem WHERE  Id_Orden = '" + id_orden + "' AND  Id_Servicio = '" + id_servicio + "' AND Id_Usuario = '" + id_usuario + "'", con.conexion);
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.ExecuteNonQuery();
                    //}
                    //else
                    //{
                    //    SqlCommand cmd = new SqlCommand("DELETE  Det_Orden_Servicio WHERE  Id_Orden = '" + id_orden + "' AND  Id_Servicio = '" + id_servicio + "'", con.conexion);
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.ExecuteNonQuery();
                    //}


                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'quitar_servicio_tem'. " + ex.Message);
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
                    //if (id_orden == "0")
                    //{
                    //    SqlDataAdapter da = new SqlDataAdapter("SELECT [Id_Servicio] [ID SERVICIO]  ,ser.Servicio As SERVICIO, ser.Costo COSTO FROM [dbo].[Det_Orden_Servicio_Tem] st INNER JOIN dbo.[Servicios] ser on st.Id_Servicio = ser.Id WHERE st.Id_Orden = '" + id_orden + "' and st.Id_Usuario = '" + id_usuario + "'", con.conexion);
                    //    da.Fill(dt);
                    //}
                    //else
                    //{
                    //    SqlDataAdapter da = new SqlDataAdapter("SELECT [Id_Servicio] [ID SERVICIO]  ,ser.Servicio As SERVICIO, ser.Costo COSTO FROM [dbo].[Det_Orden_Servicio] st INNER JOIN dbo.[Servicios] ser on st.Id_Servicio = ser.Id WHERE st.Id_Orden = '" + id_orden + "'", con.conexion);
                    //    da.Fill(dt);
                    //}

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos'. " + ex.Message);
            }
        }
        public DataTable lista_combo(string id_factura, string id_usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    //SqlDataAdapter da = new SqlDataAdapter("SELECT  ser.[Id], CLI.Nombres_Apellidos + ' : ' ++ 'Total a Pagar: ' + cast(dco.Total as varchar)  AS Cliente FROM [dbo].[Contrato_Servicio] ser INNER JOIN dbo.Clientes cli on  ser.Id_Cliente = cli.Id INNER JOIN ( select sum(Costo) Total, so.Id from dbo.Orden_Servicio so inner join dbo.Det_Orden_Servicio dso on  so.Id = dso.Id_Orden inner join dbo.Servicios ser on dso.Id_Servicio = ser.Id where Atendida = 1 and Facturada = 0 group  by so.Id ) dco on ser.Id = dco.Id Where Atendida = 1 and Facturada = 0 and ser.Id  not in (select Id_Orden from [dbo].[Det_Factura_temp]  UNION ALL select Id_Orden from [dbo].[Det_Factura])", con.conexion);
                    //da.SelectCommand.CommandType = CommandType.Text;

                    //da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
            }
        }

    }
}
