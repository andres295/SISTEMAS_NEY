using System; 
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NCuentasPorCobrar
    {
        public static void quitar_fact_todos(int maq)
        {
            new DCuentasPorCobrar().quitar_fact_todos(maq);
        }

        public static void abonar(int id_usuario, string num_venta, decimal monto_efect, string num_documento, DateTime fecha_cobro, int id_banco, decimal monto_multipago, string img_doc, string Adquiriente, decimal Interes_MultiPago, string id_tipo_pago,string est)
        {
            new DCuentasPorCobrar().abonar( id_usuario,  num_venta,  monto_efect,  num_documento,  fecha_cobro,  id_banco,  monto_multipago,  img_doc,  Adquiriente,  Interes_MultiPago,  id_tipo_pago,est);
        }
        public static  int abonar_venta_multipago(int id_user, string num_venta)
        {
            return new DCuentasPorCobrar().abonar_venta_multipago(id_user, num_venta);
        }
        public static DataTable buscar(int id_cliente,string ciudad, DateTime desde, DateTime hasta, string est)
        {
            return new DCuentasPorCobrar().buscar(id_cliente, ciudad, desde, hasta, est);
        }

        public static bool validar_fact_sel(int maq, string fact)
        {
            return new DCuentasPorCobrar().validar_fact_sel(maq, fact);
        }

        public static DataTable actualizar_fila_fact(string fact)
        {
            return new DCuentasPorCobrar().actualizar_fila_fact(fact);
        }

        public static void quitar_fact_sel(int maq, string fact)
        {
            new DCuentasPorCobrar().quitar_fact_sel(maq, fact);
        }

        public static DataTable cargar_fact_sel(int maquina)
        {
            return new DCuentasPorCobrar().cargar_fact_sel(maquina);
        }

        public static DataTable cargar_fact(int id_prov, DateTime desde, DateTime hasta)
        {
            return new DCuentasPorCobrar().cargar_fact(id_prov, desde, hasta);
        }

        public static void seleccionar_fact(int maquina, string fact, decimal monto)
        {
            new DCuentasPorCobrar().seleccionar_fact(maquina, fact, monto);
        }

        public static DataTable listar_prov()
        {
            return new DCuentasPorCobrar().listar_prov();
        }

        public static void guardar_prod(string id_fact)
        {
            new DCuentasPorCobrar().guardar_prod(id_fact);
        }

        public static DataTable obtener_totales(string num_venta)
        {
            return new DCuentasPorCobrar().obtener_totales(num_venta);
        }

        public static void guardar_fact(string fact)
        {
            new DCuentasPorCobrar().guardar_fact(fact);
        }

        public static DataTable cargar_prod(string fact)
        {
            return new DCuentasPorCobrar().cargar_prod(fact);
        }

        public static DataTable cargar_vacio_fact()
        {
            return new DCuentasPorCobrar().cargar_vacio_fact();
        }
        public static int cargar_id_cliente(string id_venta)
        {
            return new DCuentasPorCobrar().cargar_id_cliente(id_venta);
        }
        public static void AgregarFormaPago(int id_usuario, string id_factura, decimal monto_efect, string num_documento, DateTime fecha_cobro, int id_banco, decimal monto_multipago, string img_doc, string Adquiriente, decimal Interes_MultiPago, string id_tipo_pago)
        {
            new DCuentasPorCobrar().AgregarFormaPago(id_usuario, id_factura, monto_efect, num_documento, fecha_cobro, id_banco, monto_multipago, img_doc, Adquiriente, Interes_MultiPago, id_tipo_pago);
        }
        public static DataTable Obtener_Forma_Pago_Venta_Temp(string Id_factura)
        {
            return new DCuentasPorCobrar().Obtener_Forma_Pago_Venta_Temp(Id_factura);
        }
        public static bool eliminar_detalle_multi_pago(int id_detalle_pago)
        {
            return new DCuentasPorCobrar().eliminar_detalle_multi_pago(id_detalle_pago);
        }
        public static bool eliminar_detalle_multi_pago_by_usuario(int id_usuario)
        {
            return new DCuentasPorCobrar().eliminar_detalle_multi_pago_by_usuario(id_usuario);
        }
    }
}
