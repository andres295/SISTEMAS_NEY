using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NCuentasPorPagar
    {
        public static void quitar_fact_todos(int maq)
        {
            new DCuentasPorPagar().quitar_fact_todos(maq);
        }

        public static void abonar(int id_usuario, string id_factura, decimal monto_efect, string num_documento, DateTime fecha_cobro, int id_banco, decimal monto_multipago, string img_doc, string Adquiriente, decimal Interes_MultiPago, string id_tipo_pago,string est)
        {
            new DCuentasPorPagar().abonar( id_usuario,  id_factura,  monto_efect,  num_documento,  fecha_cobro,  id_banco,  monto_multipago,  img_doc,  Adquiriente,  Interes_MultiPago,  id_tipo_pago,est);
        }
        public static  int abonar_factura_multipago(int id_user, string fact)
        {
            return new DCuentasPorPagar().abonar_factura_multipago(id_user, fact);
        }
        public static DataTable buscar(int id_prov, DateTime desde, DateTime hasta, string est)
        {
            return new DCuentasPorPagar().buscar(id_prov, desde, hasta, est);
        }

        public static bool validar_fact_sel(int maq, string fact)
        {
            return new DCuentasPorPagar().validar_fact_sel(maq, fact);
        }

        public static DataTable actualizar_fila_fact(string fact)
        {
            return new DCuentasPorPagar().actualizar_fila_fact(fact);
        }

        public static void quitar_fact_sel(int maq, string fact)
        {
            new DCuentasPorPagar().quitar_fact_sel(maq, fact);
        }

        public static DataTable cargar_fact_sel(int maquina)
        {
            return new DCuentasPorPagar().cargar_fact_sel(maquina);
        }

        public static DataTable cargar_fact(int id_prov, DateTime desde, DateTime hasta)
        {
            return new DCuentasPorPagar().cargar_fact(id_prov, desde, hasta);
        }

        public static void seleccionar_fact(int maquina, string fact, decimal monto)
        {
            new DCuentasPorPagar().seleccionar_fact(maquina, fact, monto);
        }

        public static DataTable listar_prov()
        {
            return new DCuentasPorPagar().listar_prov();
        }

        public static void guardar_prod(string id_fact)
        {
            new DCuentasPorPagar().guardar_prod(id_fact);
        }

        public static DataTable obtener_totales(string fact)
        {
            return new DCuentasPorPagar().obtener_totales(fact);
        }

        public static void guardar_fact(string fact)
        {
            new DCuentasPorPagar().guardar_fact(fact);
        }

        public static DataTable cargar_prod(string fact)
        {
            return new DCuentasPorPagar().cargar_prod(fact);
        }

        public static DataTable cargar_vacio_fact()
        {
            return new DCuentasPorPagar().cargar_vacio_fact();
        }
        public static int cargar_id_proveedor(string id_factura)
        {
            return new DCuentasPorPagar().cargar_id_proveedor(id_factura);
        }
        public static void AgregarFormaPago(int id_usuario, string id_factura, decimal monto_efect, string num_documento, DateTime fecha_cobro, int id_banco, decimal monto_multipago, string img_doc, string Adquiriente, decimal Interes_MultiPago, string id_tipo_pago)
        {
            new DCuentasPorPagar().AgregarFormaPago(id_usuario, id_factura, monto_efect, num_documento, fecha_cobro, id_banco, monto_multipago, img_doc, Adquiriente, Interes_MultiPago, id_tipo_pago);
        }
        public static DataTable Obtener_Forma_Pago_Venta_Temp(string Id_factura)
        {
            return new DCuentasPorPagar().Obtener_Forma_Pago_Venta_Temp(Id_factura);
        }
        public static bool eliminar_detalle_multi_pago(int id_detalle_pago)
        {
            return new DCuentasPorPagar().eliminar_detalle_multi_pago(id_detalle_pago);
        }
    }
}
