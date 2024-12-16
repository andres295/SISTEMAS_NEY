using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedores
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DProveedores";

        public DataTable lista_combo()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Proveedor FROM Proveedores ORDER BY Proveedor", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'lista_combo'. " + ex.Message);
            }
        }
        public int buscar_by_id(string id)

        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Proveedores WHERE Id = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM Proveedores", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'num_reg'. " + ex.Message);
            }
        }

        public bool guardar(string prov, string matr, string direc, string telef, string ruc, string geren, string autoriz, string datos, int TipoIdentifiacion, string Correo, string NombreComercial, string Tipocontribuyente, string AgenteRetencion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores VALUES('" + prov + "', '" + matr + "', '" + direc + "', '" + telef + "', '" + ruc + "', '" + geren + "', '" + autoriz + "', '" + datos + "', '" + TipoIdentifiacion + "', '" + Correo + "', '" + NombreComercial + "', '" + Tipocontribuyente + "', '" + AgenteRetencion + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'guardar'. " + ex.Message);
            }
        }
        public int validar_relacion(int id)

        {
            try
            {
                int cant = 0;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Productos WHERE Id_Proveedor = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cant = (int)cmd.ExecuteScalar();
                    con.desconectar();
                }

                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'validar_relacion'. " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("DELETE Proveedores WHERE Id = " + id + "", con.conexion);
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

        public bool modificar(int id, string prov, string matr, string dir, string telef, string ruc, string geren, string autor, string datos, int TipoIdentifiacion, string Correo, string NombreComercial, string Tipocontribuyente, string AgenteRetencion)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Proveedores SET Proveedor = '" + prov + "', Matriz = '" + matr + "', Direccion = '" + dir + "', Telefono = '" + telef + "', RUC = '" + ruc + "', Gerente = '" + geren + "', Autorizacion = '" + autor + "', Datos = '" + datos + "', TipoIdentifiacion = '" + TipoIdentifiacion + "', Correo = '" + Correo + "', NombreComercial = '" + NombreComercial + "', Tipocontribuyente = '" + Tipocontribuyente + "', AgenteRetencion = '" + AgenteRetencion + "' WHERE Id = " + id + "", con.conexion);
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

        public DataTable obtener_datos(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Proveedores WHERE Id = " + id + "", con.conexion);
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
        public DataTable obtener_id_factura(string id_factura)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Proveedor FROM FacturasPorPagar WHERE Factura = '" + id_factura + "'", con.conexion);
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
        public DataTable buscar(string dato)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da;

                    if (dato == "")
                        da = new SqlDataAdapter("SELECT TOP(0) Id AS ID, RUC, Proveedor AS PROVEEDOR, NombreComercial [NOMBRE COMERCIAL],TipoContribuyente [TIPO CONTRIBUYENTE], AgenteRetencion [AGENTE RETENCION],Correo [CORREO], Telefono AS TELÉFONO FROM Proveedores", con.conexion);
                    else if (dato == "*")
                        da = new SqlDataAdapter("SELECT Id AS ID, RUC, Proveedor AS PROVEEDOR, NombreComercial [NOMBRE COMERCIAL],TipoContribuyente [TIPO CONTRIBUYENTE], AgenteRetencion [AGENTE RETENCION],Correo [CORREO], Telefono AS TELÉFONO FROM Proveedores", con.conexion);
                    else
                        da = new SqlDataAdapter("SELECT Id AS ID, RUC, Proveedor AS PROVEEDOR, NombreComercial [NOMBRE COMERCIAL],TipoContribuyente [TIPO CONTRIBUYENTE], AgenteRetencion [AGENTE RETENCION],Correo [CORREO], Telefono AS TELÉFONO FROM Proveedores WHERE Proveedor LIKE '%" + dato + "%' OR RUC LIKE '%" + dato + "%' OR Matriz LIKE '%" + dato + "%' OR Autorizacion LIKE '%" + dato + "%' OR Gerente LIKE '%" + dato + "%' ORDER BY Proveedor", con.conexion);

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
    }
}
