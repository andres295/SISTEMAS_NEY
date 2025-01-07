using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVentas_Dia
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DVentas_Dia";

        public int tamaño(DateTime desde, DateTime hasta, int registro_por_pagina)
        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("Tamaño_Ventas_Dia", con.conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@RegistrosPorPagina", registro_por_pagina);

                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@TotalPaginas";
                    par.SqlDbType = SqlDbType.Int;
                    par.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(par);

                    cmd.ExecuteNonQuery();

                    cant = Convert.ToInt32(cmd.Parameters["@TotalPaginas"].Value);
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'tamaño'. " + ex.Message);
            }
        }
        public DataTable Buscar_Ventas_Dia(DateTime fecha_inicio, DateTime fecha_fin, int page)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("exec Buscar_Ventas_Dia '" + fecha_inicio + "','" + fecha_fin + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'Buscar_Ventas_Dia'. " + ex.Message);
            }
        }
    }
}
