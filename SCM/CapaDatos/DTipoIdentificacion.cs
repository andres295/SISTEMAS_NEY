using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoIdentificacion
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DTipoIdentificacion"; 
        public DataTable Obtener_Tipo_Identificacion()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tipo_Identificacion", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + "Obtener_Tipo_Identificacion" + ex.Message);
            }
        }
        public DataTable Obtener_Tipo_Identificacion_by_id(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tipo_Identificacion where id = '"+ id +"'", con.conexion);
                    da.Fill(dt);

                    con.desconectar();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(texto + "Obtener_Tipo_Identificacion_by_id" + ex.Message);
            }
        }
    }
}
