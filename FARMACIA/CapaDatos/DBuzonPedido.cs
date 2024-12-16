﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DBuzonPedido
    {
        DConexion con;
        string texto = "Hubo un problema en la capa DBuzonPedido";

        public void actualizar_precios(string id, decimal pvf, decimal pvp, DateTime venc, string lote)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Productos SET PVF = " + pvf.ToString().Replace(",", ".") + ", PVP = " + pvp.ToString().Replace(",", ".") + ", Vencimiento = '" + venc.ToShortDateString() + "', Lote = '" + lote + "' WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_precios'. " + ex.Message);
            }
        }

        public decimal calcular_pur(decimal subtotal, int cant, int bonif, int cont)
        {
            decimal monto = cant + bonif;

            if (monto > 0)
            {
                monto = subtotal / monto;
                return monto;
            }
            else return 0;
         

            //if (cont == 0)
            //    monto = subtotal / monto;
            //else
            //    monto = (subtotal / monto) * cont;

            //return monto;
        }

        public decimal calcular_utilidad(decimal pvp, decimal pur, int cont)
        {
            decimal monto = 0;

            if (cont == 0)
                monto = pvp - pur;
            else
                monto = pvp - (pur / cont);

            monto *= 100; monto /= pvp;

            return monto;
        }

        public string actualizar_nombre_prov(string fact)
        {
            try
            {
                string nombre = "";
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        cmd = new SqlCommand("SELECT CONCAT('[', (SELECT COUNT(*) AS Registros FROM CargoCompra_Productos WHERE Id_Factura = CargoCompra.Factura), '] ', Proveedores.Proveedor) AS Proveedor FROM CargoCompra INNER JOIN Proveedores ON Proveedores.Id = CargoCompra.Id_Proveedor WHERE CargoCompra.Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        nombre = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT CONCAT('* [', (SELECT COUNT(*) AS Registros FROM CargoCompra_Productos_Temp WHERE Id_Factura = CargoCompra.Factura), '] ', Proveedores.Proveedor) AS Proveedor FROM CargoCompra INNER JOIN Proveedores ON Proveedores.Id = CargoCompra.Id_Proveedor WHERE CargoCompra.Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        nombre = cmd.ExecuteScalar().ToString();
                    }

                    con.desconectar();
                }

                return nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_nombre_prov'. " + ex.Message);
            }
        }

        public DataTable buscar(string dato  , string proveedor)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da; 
                    da = new SqlDataAdapter("SELECT * FROM BuzonPedidos where  (Producto like '%" + dato + "%' or  Presentacion like '%" + dato + "%') and  Laboratorio like '%" + proveedor + "%' ", con.conexion);
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
        public bool siFacturaExiste(string id__factura)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                try
                {
                    if (con.conectar())
                    {
                        SqlDataAdapter da;

                        da = new SqlDataAdapter("select count(1) factura from  CargoCompra  WITH (NOLOCK) where Factura = '" + id__factura + "'", con.conexion);

                        da.SelectCommand.CommandType = CommandType.Text;

                        da.Fill(dt);
                        con.desconectar();
                    }
                    if (int.Parse(dt.Rows[0]["factura"].ToString()) > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch (Exception)  {  return true;  }
               
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'buscar'. " + ex.Message);
            }
        }
        public void actualizar_cantidades(string fact, string id_prod, int cant, int bonif,decimal porc_descuento)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    decimal captar_iva_porc, captar_desc_porc, captar_subtotal;

                    cmd = new SqlCommand("SELECT IVA, Desc_Porc FROM CargoCompra WHERE Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr1;
                    dr1 = cmd.ExecuteReader();
                    dr1.Read();
                    captar_iva_porc = Convert.ToDecimal(dr1[0].ToString());
                    captar_desc_porc = porc_descuento;
                    dr1.Close();

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Cantidad = " + cant + ", Bonificacion = " + bonif + " WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Subtotal = Cantidad * PVF WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT Subtotal FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr2;
                    dr2 = cmd.ExecuteReader();
                    dr2.Read();
                    captar_subtotal = Convert.ToDecimal(dr2[0].ToString());
                    dr2.Close();

                    decimal calcular_iva, calcular_desc, calcular_total;
                    calcular_iva = (captar_subtotal * captar_iva_porc) / 100;
                    calcular_desc = (captar_subtotal * captar_desc_porc) / 100;
                    calcular_total = (captar_subtotal + calcular_iva) - calcular_desc;

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Subtotal = " + captar_subtotal.ToString().Replace(",", ".") + ", IVA = " + calcular_iva.ToString().Replace(",", ".") + ", Descuento = " + calcular_desc.ToString().Replace(",", ".") + ", TotalPagar = " + calcular_total.ToString().Replace(",", ".") + " WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'actualizar_cantidades'. " + ex.Message);
            }
        }

        public DataTable obtener_cantidades(string fact, string id_prod)
        {
            try
            {
                DataTable dt = new DataTable();
                con = new DConexion();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Cantidad, Bonificacion FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_cantidades'. " + ex.Message);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Subtotal) AS Subtotal, SUM(IVA) AS IVA, SUM(Descuento) AS Descuento, SUM(TotalPagar) AS Total FROM (SELECT Id_Factura, Subtotal, IVA, Descuento, TotalPagar FROM Cargocompra_productos_temp UNION ALL SELECT Id_Factura, Subtotal, IVA, Descuento, TotalPagar FROM Cargocompra_productos) AS Tablas WHERE Tablas.Id_Factura = '" + fact + "'", con.conexion);
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

        public bool verificar_prod(string fact, string id_prod)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_prod'. " + ex.Message);
            }
        }

        public int verificar_cant_prod(string id_fact)
        {
            try
            {
                con = new DConexion();
                int opcion = 0; //1 = CargoCompra_Productos_Temp, 2 = CargoCompra_Productos

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + id_fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        opcion = 1;
                    else
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CargoCompra_Productos WHERE Id_Factura = '" + id_fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            opcion = 2;
                    }

                    con.desconectar();
                }

                return opcion;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'verificar_cant_prod'. " + ex.Message);
            }
        }

        public void agregar_prod_temp(string id_fact, string id_prod, int cant, int bonif, int id_user)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    SqlDataReader dr;
                    int captar_cont, captar_idpres, captar_idprov;
                    decimal captar_pvf, captar_pvp, captar_subtotal, captar_iva, captar_desc, captar_total, calc_pur, calc_utilidad;
                    string captar_prod, Lote;
                    DateTime Vencimiento;

                    cmd = new SqlCommand("SELECT Contiene, PVF, PVP, Id_Presentacion, Id_Proveedor, Producto,Vencimiento,Lote FROM Productos WHERE IIF(CodigoBarra = '', CONVERT(NVARCHAR(MAX), Id), CodigoBarra) = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    captar_cont = Convert.ToInt32(dr[0].ToString()); captar_pvf = Convert.ToDecimal(dr[1].ToString());
                    captar_pvp = Convert.ToDecimal(dr[2].ToString()); captar_idpres = Convert.ToInt32(dr[3].ToString());
                    captar_idprov = Convert.ToInt32(dr[4].ToString()); captar_prod = dr[5].ToString();
                    Vencimiento = Convert.ToDateTime(dr[6].ToString());
                    Lote = dr[7].ToString();

                    dr.Close();

                    captar_subtotal = cant * captar_pvf;

                    calc_pur = calcular_pur(captar_subtotal, cant, bonif, captar_cont);
                    calc_utilidad = calcular_utilidad(captar_pvp, calc_pur, captar_cont);

                    cmd = new SqlCommand("SELECT IVA, Desc_Porc FROM CargoCompra WHERE Factura = '" + id_fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    captar_iva = (captar_subtotal * Convert.ToDecimal(dr[0].ToString())) / 100;
                    captar_desc = 0; /////(captar_subtotal * Convert.ToDecimal(dr[1].ToString())) / 100;
                    dr.Close();

                    captar_total = (captar_subtotal + captar_iva) - captar_desc;

                    cmd = new SqlCommand("INSERT INTO CargoCompra_Productos_Temp VALUES('" + id_fact + "', '" + id_prod + "', '" + captar_prod + "', " + captar_idpres + ", " + captar_idprov + ", " + captar_cont + ", " + captar_pvf.ToString().Replace(",", ".") + ", " + cant + ", " + bonif + ", " + captar_subtotal.ToString().Replace(",", ".") + ", " + captar_iva.ToString().Replace(",", ".") + ", " + captar_desc.ToString().Replace(",", ".") + ", " + captar_total.ToString().Replace(",", ".") + ", " + id_user + ", " + calc_pur.ToString().Replace(",", ".") + ", " + calc_utilidad.ToString().Replace(",", ".") + ", '" + Vencimiento.ToShortDateString() + "', '" + Lote.ToString().Replace(",", ".") + "')", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'agregar_prod'. " + ex.Message);
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Tablas.Id_Producto [ID/CODIGO BARRA], IIF(Tablas.IVA = 0, Tablas.Producto, CONCAT('* ', Tablas.Producto)) PRODUCTO, Tablas.Presentacion [PRESENTACION], Tablas.Proveedor [PROVEEDOR], Tablas.PVF [P/COMPRA], Tablas.Cantidad [CANTIDAD], Tablas.Bonificacion [BONIF.], Tablas.Subtotal [SUBTOTAL], Tablas.PUR [P/UNIT. REAL], Tablas.Descuento [DESC.], Tablas.IVA, Tablas.TotalPagar [TOTAL A PAGAR],Tablas.Vencimiento [VENCIMIENTO] ,Tablas.Lote [LOTE]  FROM (SELECT Id_Factura, Id_Producto, IIF(CargoCompra_Productos.IVA = 0, Producto, CONCAT('* ', CargoCompra_Productos.Producto)) AS Producto, Presentaciones.Presentacion, Proveedores.Proveedor, CargoCompra_Productos.PVF, CargoCompra_Productos.Cantidad, CargoCompra_Productos.Bonificacion, CargoCompra_Productos.Subtotal, CargoCompra_Productos.IVA, CargoCompra_Productos.Descuento, CargoCompra_Productos.TotalPagar, CargoCompra_Productos.Contiene, CargoCompra_Productos.PUR,CargoCompra_Productos.Vencimiento ,CargoCompra_Productos.Lote  FROM CargoCompra_Productos INNER JOIN Presentaciones ON Presentaciones.Id = CargoCompra_Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos.Id_Proveedor UNION ALL SELECT Id_Factura, Id_Producto, IIF(CargoCompra_Productos_Temp.IVA = 0, Producto, CONCAT('* ', CargoCompra_Productos_Temp.Producto)) AS Producto, Presentaciones.Presentacion, Proveedores.Proveedor, CargoCompra_Productos_Temp.PVF, CargoCompra_Productos_Temp.Cantidad, CargoCompra_Productos_Temp.Bonificacion, CargoCompra_Productos_Temp.Subtotal, CargoCompra_Productos_Temp.IVA, CargoCompra_Productos_Temp.Descuento, CargoCompra_Productos_Temp.TotalPagar, CargoCompra_Productos_Temp.Contiene, CargoCompra_Productos_Temp.PUR,CargoCompra_Productos_Temp.Vencimiento ,CargoCompra_Productos_Temp.Lote FROM CargoCompra_Productos_Temp INNER JOIN Presentaciones ON Presentaciones.Id = CargoCompra_Productos_Temp.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos_Temp.Id_Proveedor) AS Tablas WHERE Tablas.Id_Factura = '" + fact + "'", con.conexion);
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

        public void eliminar_prod(string id_fact, string id_prod)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE CargoCompra_Productos_Temp WHERE Id_Factura = '" + id_fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar_prod'. " + ex.Message);
            }
        }

        public bool activacion(string fact)
        {
            try
            {
                bool resp = false;
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        resp = true;

                    con.desconectar();
                }

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'activacion'. " + ex.Message);
            }
        }

        public void eliminar_buzon(string id_buzon)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    cmd = new SqlCommand("DELETE BuzonPedidos ", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
 
                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'eliminar'. " + ex.Message);
            }
        }

        public void modificar(string fact_old, string fact_new, int id_prov, DateTime fecha_doc, int dias, DateTime fecha_pago, string observ, string est, decimal iva,decimal desc)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    ///Actualiza Datos en CargoCompra
                    SqlCommand cmd = new SqlCommand("UPDATE CargoCompra SET Factura = '" + fact_new + "', Id_Proveedor = " + id_prov + ", Fecha_Documento = '" + fecha_doc.ToShortDateString() + "', Dias_Pago = " + dias + ", Fecha_Pago = '" + fecha_pago.ToShortDateString() + "', Observacion = '" + observ + "', Estado = '" + est + "', IVA = " + iva.ToString().Replace(",", ".") + ", Desc_Porc = " + desc.ToString().Replace(",", ".") + " WHERE Factura = '" + fact_old + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    ///Actualiza Datos en CargoCompra
                    SqlCommand cmdfa_sald = new SqlCommand("UPDATE FacturasPorPagar SET Factura = '" + fact_new + "', Id_Proveedor = " + id_prov + ", Fecha_Emision = '" + fecha_doc.ToShortDateString() + "', Fecha_Vencimiento = '" + fecha_pago.ToShortDateString() + "', DiasPago = " + dias + " WHERE Factura = '" + fact_old + "'", con.conexion);
                    cmdfa_sald.CommandType = CommandType.Text;
                    cmdfa_sald.ExecuteNonQuery();

                    ///Actualiza Datos en Productos
                    SqlCommand cmd1 = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET  Id_Factura = '" + fact_new + "'  WHERE Id_Factura = '" + fact_old + "'", con.conexion);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();
            

                    ///Actualiza Datos en Productos
                    SqlCommand cmd2 = new SqlCommand("UPDATE CargoCompra_Productos SET   Id_Factura = '" + fact_new + "'  WHERE Id_Factura = '" + fact_old + "'", con.conexion);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();


                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'modificar'. " + ex.Message);
            }
        }

        public DataTable obtener_totales_fila(string fact, string id_prod)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Subtotal, IVA, Descuento, TotalPagar, PUR FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
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

        public DataTable obtener_datos(DateTime dtInicio,DateTime dtFin)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id,	Producto,	Presentacion,	Laboratorio Proveedor	,Cantidad	,PVF,	Subtotal,	Fraccion,	Contiene,	Fecha_Registro,	Hora_Registro from BuzonPedidos", con.conexion);
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

        public DataTable obtener_datos_prod(string fact, string id)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Factura, Id_Producto, Producto, Presentaciones.Presentacion, Proveedores.Proveedor, Contiene, PVF, Cantidad, Bonificacion, Subtotal, IVA, Descuento, TotalPagar, Id_Usuario FROM CargoCompra_Productos INNER JOIN Presentaciones ON Presentaciones.Id = CargoCompra_Productos.Id_Presentacion INNER JOIN Proveedores ON Proveedores.Id = CargoCompra_Productos.Id_Proveedor WHERE CargoCompra_Productos.Id_Factura = '" + fact + "' AND CargoCompra_Productos.Id_Producto = '" + id + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_datos_prod'. " + ex.Message);
            }
        }

        public int num_reg()
        {
            try
            {
                con = new DConexion();
                int cant = 0;

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Registros FROM CargoCompra", con.conexion);
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

        public void aplicar_quitar_desc_sel(string fact, string id_prod, bool aplicar_quitar, decimal por_descuento)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    SqlDataReader dr;
                    decimal captar_desc;

                    if (aplicar_quitar)
                    {
                        //APLICAR.

                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Descuento = ((Subtotal * " + Convert.ToString(por_descuento).Replace(",", ".") + ") / 100) WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //QUITAR.
                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Descuento = 0 WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        
                    }

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET TotalPagar = ((Subtotal + IVA) - Descuento) WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'aplicar_quitar_desc_sel'. " + ex.Message);
            }
        }

        public void aplicar_quitar_desc_todos(string fact, bool aplicar_quitar, decimal por_descuento )
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    SqlDataReader dr;
                    decimal captar_desc;

                    if (aplicar_quitar)
                    {

                        //APLICAR.

                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Descuento = ((Subtotal * " + Convert.ToString(por_descuento).Replace(",", ".") + ") / 100) WHERE Id_Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //QUITAR.
                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET Descuento = 0 WHERE Id_Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        
                    }

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET TotalPagar = ((Subtotal + IVA) - Descuento) WHERE Id_Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'aplicar_quitar_desc_todos'. " + ex.Message);
            }
        }

        public void aplicar_quitar_iva_sel(string fact, string id_prod, bool aplicar_quitar)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    SqlDataReader dr;
                    decimal captar_iva;

                    if (aplicar_quitar)
                    {
                        //APLICAR.
                        cmd = new SqlCommand("SELECT IVA FROM CargoCompra WHERE Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        dr = cmd.ExecuteReader(); dr.Read();
                        captar_iva = Convert.ToDecimal(dr[0].ToString());
                        dr.Close();

                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET IVA = (((Subtotal - Descuento) * " + Convert.ToString(captar_iva).Replace(",", ".") + ") / 100) WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //QUITAR.
                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET IVA = 0 WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET TotalPagar = ((Subtotal - Descuento) + IVA) WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + id_prod + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'aplicar_quitar_iva_sel'. " + ex.Message);
            }
        }

        public void aplicar_quitar_iva_todos(string fact, bool aplicar_quitar)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;
                    SqlDataReader dr;
                    decimal captar_iva;

                    if (aplicar_quitar)
                    {
                        //APLICAR.
                        cmd = new SqlCommand("SELECT IVA FROM CargoCompra WHERE Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        dr = cmd.ExecuteReader(); dr.Read();
                        captar_iva = Convert.ToDecimal(dr[0].ToString());
                        dr.Close();

                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET IVA = (((Subtotal - Descuento) * " + Convert.ToString(captar_iva).Replace(",", ".") + ") / 100) WHERE Id_Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //QUITAR.
                        cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET IVA = 0 WHERE Id_Factura = '" + fact + "'", con.conexion);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("UPDATE CargoCompra_Productos_Temp SET TotalPagar = ((Subtotal - Descuento) + IVA) WHERE Id_Factura = '" + fact + "'", con.conexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    con.desconectar();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(texto + " 'aplicar_quitar_iva_todos'. " + ex.Message);
            }
        }

        public void guardar_prod(string fact)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd;

                    SqlDataAdapter da = new SqlDataAdapter("SELECT Id_Producto FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        cmd = new SqlCommand("UPDATE Productos SET Disponible = Disponible + Tablas.Cantidades, PUR = Tablas.PUR, Utilidad = Tablas.Utilidad FROM Productos, (SELECT Id_Producto, IIF(Contiene = 0, (Cantidad + Bonificacion), (Cantidad * Contiene) + (Bonificacion * Contiene)) AS Cantidades, PUR, Utilidad FROM CargoCompra_Productos_Temp WHERE Id_Factura = '" + fact + "' AND Id_Producto = '" + item["Id_Producto"].ToString() + "') AS Tablas WHERE IIF(Productos.CodigoBarra = '', CONVERT(NVARCHAR(MAX), Productos.Id), Productos.CodigoBarra) = Tablas.Id_Producto", con.conexion);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand("INSERT INTO CargoCompra_Productos SELECT * FROM CargoCompra_Productos_Temp WHERE CargoCompra_Productos_Temp.Id_Factura = '" + fact + "' DELETE CargoCompra_Productos_Temp WHERE CargoCompra_Productos_Temp.Id_Factura = '" + fact + "'", con.conexion);
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

        public void guardar_buzon(  DateTime fecha_inicio, DateTime fecha_fin)
        {
            try
            {
                con = new DConexion();

                if (con.conectar())
                {
                    SqlCommand cmd = new SqlCommand("exec sp_obtener_buzon_pedido '" + fecha_inicio.ToShortDateString() + "','" + fecha_fin.ToShortDateString() + "'", con.conexion);
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
        public DataTable obtener_Vencimiento(DateTime dInicio, DateTime dFin)
        {
            try
            {
                con = new DConexion();
                DataTable dt = new DataTable();

                if (con.conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.rpt_Vencimiento_Buscar '" + dInicio.ToShortDateString() + "','" + dFin.ToShortDateString() + "'", con.conexion);
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(dt);
                    con.desconectar();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'obtener_Vencimiento'. " + ex.Message);
            }
        }
    }
}