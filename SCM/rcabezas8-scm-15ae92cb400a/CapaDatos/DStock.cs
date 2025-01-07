using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DStock
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DStock";

        public DataTable cmb()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Tablas.Id, Tablas.Proveedor FROM (SELECT Proveedores.Id, Proveedores.Proveedor FROM CargoCompra_Productos INNER JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos.Id_Proveedor UNION ALL SELECT Proveedores.Id, Proveedores.Proveedor FROM Productos INNER JOIN CargoAjuste_Productos ON CargoAjuste_Productos.Id_Producto = IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR, Productos.Id), Productos.CodigoBarra) INNER JOIN Proveedores ON Proveedores.Id = Productos.Id_Proveedor) AS Tablas GROUP BY Tablas.Id, Tablas.Proveedor ORDER BY Tablas.Proveedor", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'cmb'. " + ex.Message);
            }
        }

        public DataTable obtener_datos()
        {
            DataTable dt = new DataTable();
            con = new DConexion();

            if (con.conectar())
            {
                string sql = "SELECT Id, Producto FROM Productos";
                SqlDataAdapter da = new SqlDataAdapter(sql, con.conexion);
                da.SelectCommand.CommandType = CommandType.Text;

                da.Fill(dt);
                con.desconectar();
            }

            return dt;
        }
    }
}
