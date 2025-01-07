using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{ 
    public class DAdministracion
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DAdministracion";

        /*****************************CATALOGOS GASTOS*********************************************/
        public DataTable Cargar_Cat_Gastos()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT gt.ID, gt.DESCRIPCION,gt.CREATEDATE [CREADO EL], gt.ESTADO, gt.CREATEUSER [CREADO POR] FROM Cat_Gastos gt", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Cargar_Cat_Gastos'. " + ex.Message);
            }
        }
        public DataTable Lista_Cat_Gastos()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT gt.ID, gt.DESCRIPCION FROM Cat_Gastos gt where gt.Estado = 1", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Lista_Cat_Gastos'. " + ex.Message);
            }
        }
        public bool Agregar_Cat_Gastos(string descripcion, string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Cat_Gastos (DESCRIPCION,CREATEUSER) VALUES('" + descripcion + "', '" + id_usuario + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Agregar_Cat_Gastos'. " + ex.Message);
            }
        }
        public bool Actualizar_Cat_Gastos(string id_cat_gasto,string descripcion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cat_Gastos SET DESCRIPCION = '" + descripcion + "' WHERE Id = '" + id_cat_gasto + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Agregar_Cat_Gastos'. " + ex.Message);
            }
        }
        public bool Eliminar_Activar_Cat_Gastos(string id_cat_gasto,bool estado)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cat_Gastos SET Estado = '"+ estado + "' WHERE Id = '" + id_cat_gasto + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Eliminar_Cat_Gastos'. " + ex.Message);
            }
        }
        public int buscar_tipo_gasto(string id)

        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Cat_Gastos WHERE Id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar_tipo_gasto'. " + ex.Message);
            }

        }

        /*****************************REGISTROS GASTOS*********************************************/

        public DataTable Cargar_Registro_Gastos()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT rgt.ID, gt.DESCRIPCION,rgt.Monto [MONTO$], rgt.Fecha FECHA, rgt.CREATEDATE [CREADO EL], rgt.ESTADO, rgt.CreateUser [CREADO POR], rgt.Fecha_Elimina [ELIMINADO EL], rgt.User_Elimina [ELIMINADO POR] FROM Admin_Registro_Gastos rgt INNER JOIN Cat_Gastos gt ON rgt.Id_Gasto = gt.Id ", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Cargar_Registro_Gastos'. " + ex.Message);
            }
        }

        public bool Agregar_Registro_Gastos(int Id_Gasto, decimal monto,DateTime dtFecha,string id_usuario)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Admin_Registro_Gastos (Id_Gasto,Monto,Fecha,CreateUser) VALUES('" + Id_Gasto + "', '" + monto.ToString().Replace(",", ".") + "', '" + dtFecha.ToShortDateString() + "', '" + id_usuario + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Agregar_Registro_Gastos'. " + ex.Message);
            }
        }

        public bool Eliminar_Registro_Gastos(string id_registro, bool estado, string usuario_elimina)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Admin_Registro_Gastos SET Estado = '" + estado + "', User_Elimina = '" + usuario_elimina + "',Fecha_Elimina = getdate()  WHERE Id = '" + id_registro + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Eliminar_Registro_Gastos'. " + ex.Message);
            }
        }


        /********************************REPORTES DE GASTOS*******************************************/
        public DataTable cargar_historico_gastos(DateTime dtInicio, DateTime dtFin,int tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("EXEC sp_Obtener_Historial_Gasto '" + dtInicio.ToShortDateString() + "','" + dtFin.ToShortDateString() + "','" + tipo + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                } 
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cargar_historico_gastos'. " + ex.Message);
            }
        }
    }
}
