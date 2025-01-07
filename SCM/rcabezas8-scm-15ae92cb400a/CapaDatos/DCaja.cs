using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DCaja
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DCaja";
 
    
        public decimal verificar_si_existe(int id_usuario)
        {
            try
            {
                decimal monto_apertura_caja = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT sum(Monto_Apertura) Monto_Apertura FROM Apertura_Caja WHERE Id_Usuario = '" + id_usuario + "' and  cast(Fecha_Apertura as date) = cast(getdate() as date)", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    try
                    {
                        monto_apertura_caja = Convert.ToDecimal(dr[0].ToString());
                    }
                    catch (Exception)  { monto_apertura_caja = 0;  } 
                    dr.Close();
                }

                return monto_apertura_caja;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_si_existe'. " + ex.Message);
            }
        }
        public int obtener_id_caja(int id_usuario)
        {
            try
            {
                int id_caja = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT top 1 Id FROM Apertura_Caja WHERE Id_Usuario = '" + id_usuario + "' and  cast(Fecha_Apertura as date) = cast(getdate() as date)", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    try
                    {
                        id_caja = int.Parse(dr[0].ToString());
                    }
                    catch (Exception) { id_caja = 0; }
                    dr.Close();
                }

                return id_caja;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_id_caja'. " + ex.Message);
            }
        }
        public DataTable obtener_cierre_caja(int id_usuario)
        {
            try
            {
                
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * from [dbo].[Cierre_Caja] where Id_Usuario =  '" + id_usuario + "' and cast(FechaHora_Registro as date) = cast(getdate() as date)", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                } 
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cierre_caja'. " + ex.Message);
            }
        }
        public DataTable obtener_cierre_caja(int id_usuario, DateTime fecha)
        {
            try
            {

                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * from [dbo].[Cierre_Caja] where Id_Usuario =  '" + id_usuario + "' and cast(FechaHora_Registro as date) = '" + fecha.ToShortDateString() + "'", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cierre_caja'. " + ex.Message);
            }
        }
        public Decimal obtener_monto_egresos(int id_apartura_caja,int id_usuario)
        {
            try
            {

                decimal egresos = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd; 
                    cmd = new SqlCommand("SELECT isnull(sum(Monto_Egreso), 0) Monto_Egreso FROM Egresos_Caja EG where eg.Id_Apertura_Caja = '" + id_apartura_caja + "' and eg.Id_Usuario = '" + id_usuario + "'", con.conexion);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    try
                    {
                        egresos = decimal.Parse(dr[0].ToString());
                    }
                    catch (Exception) { egresos = 0; }
                    dr.Close();
                }
                return egresos; 
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_monto_egresos'. " + ex.Message);
            }
        }
        public bool abrir_caja(decimal monto,int id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Apertura_Caja VALUES(getdate(), '" + monto.ToString().Replace(",", ".") + "', '" + id_usuario + "', getdate())", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'abrir_caja'. " + ex.Message);
            }
        }
        public bool cierre_caja(int id_usuario, int Id_Apertura_Caja,decimal MontoApertura,decimal MontoSistema,decimal MontoIngresos,decimal MontoEgresos,decimal MontoTotalCierre,decimal MontoFaltante,int CantidadEfectivoMoneda1,int CantidadEfectivoMoneda2,int CantidadEfectivoMoneda3,int CantidadEfectivoMoneda4,int CantidadEfectivoMoneda5,int CantidadEfectivoMoneda6,int CantidadEfectivoBillete1,int CantidadEfectivoBillete2,int CantidadEfectivoBillete3,int CantidadEfectivoBillete4,int CantidadEfectivoBillete5,int CantidadEfectivoBillete6,int CantidadEfectivoBillete7,decimal MontoTotalEfectivoMoneda,decimal MontoTotalEfectivoBillete,decimal MontoTotalUsuario,decimal sobrante)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Cierre_Caja VALUES ('"+ Id_Apertura_Caja+ "','" + MontoApertura.ToString().Replace(",", ".") + "','" + MontoSistema.ToString().Replace(",", ".") + "','" + MontoIngresos.ToString().Replace(",", ".") + "','" + MontoEgresos.ToString().Replace(",", ".") + "','" + MontoTotalCierre.ToString().Replace(",", ".") + "','" + MontoFaltante.ToString().Replace(",", ".") + "','" + CantidadEfectivoMoneda1.ToString() + "','" + CantidadEfectivoMoneda2.ToString() + "','" + CantidadEfectivoMoneda3.ToString() + "','" + CantidadEfectivoMoneda4.ToString() + "','" + CantidadEfectivoMoneda5.ToString() + "','" + CantidadEfectivoMoneda6.ToString() + "','" + CantidadEfectivoBillete1.ToString() + "','" + CantidadEfectivoBillete2.ToString() + "','" + CantidadEfectivoBillete3.ToString() + "','" + CantidadEfectivoBillete4.ToString() + "','" + CantidadEfectivoBillete5.ToString() + "','" + CantidadEfectivoBillete6.ToString() + "','" + CantidadEfectivoBillete7.ToString() + "','" + MontoTotalEfectivoMoneda.ToString().Replace(",", ".") + "','" + MontoTotalEfectivoBillete.ToString().Replace(",", ".") + "','" + MontoTotalUsuario.ToString().Replace(",", ".") + "','" + id_usuario.ToString() + "',getdate(),'" + sobrante.ToString().Replace(",", ".") + "')", con.conexion);
                    cmd.CommandType = CommandType.Text; 
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO CierreCajaMultiPago  (IdMultipago,TipoPago,Monto,Id_Apertura) exec SP_Obtener_VentaMultiPagoDiaByUsuario '" + System.DateTime.Now.ToString("yyyy-MM-dd")  + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + id_usuario + "','" + Id_Apertura_Caja + "',0", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();


                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'abrir_caja'. " + ex.Message);
            }
        }
        public bool incluir_egreso(int Id_Usuario, int id_apertura_caja, string descripcion, decimal monto, DateTime fecha)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Egresos_Caja(Id_Usuario,Id_Apertura_Caja,Descripcion,Monto_Egreso, FechaHora_Registro) VALUES('" + Id_Usuario.ToString() + "','" + id_apertura_caja.ToString() + "', '" + descripcion + "','" + monto.ToString().Replace(",", ".") + "','"+ fecha.ToShortDateString() + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'abrir_caja'. " + ex.Message);
            }
        }
        public bool update_egreso(int id_egreso, string descripcion, decimal monto)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Egresos_Caja SET  Descripcion = '" + descripcion + "', Monto_Egreso = '" + monto.ToString().Replace(",", ".") + "' WHERE Id = '" + id_egreso + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'update_egreso'. " + ex.Message);
            }
        }
        public bool update_egreso_By_Fecha(int id_egreso, string descripcion, decimal monto, DateTime fecha)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Egresos_Caja SET  Descripcion = '" + descripcion + "', Monto_Egreso = '" + monto.ToString().Replace(",", ".") + "', FechaHora_Registro = '" + fecha.ToShortDateString() + "' WHERE Id = '" + id_egreso + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'update_egreso'. " + ex.Message);
            }
        }
        public bool eliminar_egreso(int id_egreso)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE Egresos_Caja WHERE Id = '" + id_egreso + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'update_egreso'. " + ex.Message);
            }
        }
        public DataTable obtener_egreso_caja(int id_apertura_caja)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Descripcion,Monto_Egreso Total$,FechaHora_Registro Fecha FROM Egresos_Caja WHERE Id_Apertura_Caja = '" + id_apertura_caja + "' ORDER BY Id asc", con.conexion);
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

        public DataTable VentasMultiPagoByUsuario(DateTime fecha_inicio, DateTime fecha_fin, int id_usuario,int idAperturaCaja,int select)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec SP_Obtener_VentaMultiPagoDiaByUsuario '" + fecha_inicio.ToString("yyyy-MM-dd") + "','" + fecha_fin.ToString("yyyy-MM-dd") + "','" + id_usuario + "','" + idAperturaCaja + "','" + select + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'VentasMultiPagoByUsuario'. " + ex.Message);
            }
        }
    }
}
