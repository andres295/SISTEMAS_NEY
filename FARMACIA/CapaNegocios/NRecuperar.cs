using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NRecuperar
    {
        public static void eliminar_fact(long id_venta)
        {
            new DRecuperar().eliminar_fact(id_venta);
        }
        public static void actualizar_stock(string nc, string id, bool accion)
        {
            new DRecuperar().actualizar_stock(nc, id, accion);
        }
        public static void modificar_pagar(long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf)
        {
            new DRecuperar().modificar_pagar(id_venta, monto_efect, cheque, fecha_cobro, id_banco, cheque_monto, img_cheque, tranf, monto_tranf, img_tranf);
        }

        public static DataTable obtener_datos_pago(long id_venta)
        {
            return new DRecuperar().obtener_datos_pago(id_venta);
        }

        public static int obtener_cont(long id_venta, string id_prod)
        {
            return new DRecuperar().obtener_cont(id_venta, id_prod);
        }

        public static long obtener_vendido(string id_prod)
        {
            return new DRecuperar().obtener_vendido(id_prod);
        }

        public static int verificar_ventas_temp(long id_venta)
        {
            return new DRecuperar().verificar_ventas_temp(id_venta);
        }

        public static void eliminar_prod(long id_venta, string id_prod)
        {
            new DRecuperar().eliminar_prod(id_venta, id_prod);
        }

        public static void modificar_cantidad(long id_venta, string id_prod, long cant_new, decimal ganan, decimal parc)
        {
            new DRecuperar().modificar_cantidad(id_venta, id_prod, cant_new, ganan, parc);
        }

        public static int verificar_siexiste_idprod_ventas(long id_venta, string id_prod)
        {
            return new DRecuperar().verificar_siexiste_idprod_ventas(id_venta, id_prod);
        }

        public static DataTable buscar_ventas(string dato)
        {
            return new DRecuperar().buscar_ventas(dato);
        }
        public static DataTable buscar_venta_lista(string dato, DateTime dInicio, DateTime dFin)
        {
            return new DRecuperar().buscar_ventas_lista(dato, dInicio, dFin);
        }
    }
}
