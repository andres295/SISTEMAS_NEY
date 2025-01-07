using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NCargoTransferencia
    {
        public static int num_reg()
        {
            return new DCargoTransferencia().num_reg();
        }

        public static void guardar_CJ(int pc, string alm, string mov, int id_prov, string prov, DateTime fecha_doc, string obs, int id_resp)
        {
            new DCargoTransferencia().guardar_CJ(pc, alm, mov, id_prov, prov, fecha_doc, obs, id_resp);
        }

        public static int verificar_cant_prod(string id_fact)
        {
            return new DCargoTransferencia().verificar_cant_prod(id_fact);
        }

        public static DataTable cargar_prod(int pc, string id_fact)
        {
            return new DCargoTransferencia().cargar_prod(pc, id_fact);
        }

        public static int verificar_prod_temp(int id_fact, string id_prod)
        {
            return new DCargoTransferencia().verificar_prod_temp(id_fact, id_prod);
        }

        public static decimal obtener_subtotal(int id_fact, string id_prod)
        {
            return new DCargoTransferencia().obtener_subtotal(id_fact, id_prod);
        }

        public static void modificar_CJ(int id, int id_prov, string prov, DateTime fecha_doc, string observ)
        {
            new DCargoTransferencia().modificar_CJ(id, id_prov, prov, fecha_doc, observ);
        }

        public static DataTable obtener_datos(int pc, int id_fact)
        {
            return new DCargoTransferencia().obtener_datos(pc, id_fact);
        }

        public static void guardar(int pc, int id_fact)
        {
            new DCargoTransferencia().guardar(pc, id_fact);
        }

        public static void modificar_cantidad(int id_fact, string id_prod, long cant, DateTime vencimiento, string lote, string idItemPro)
        {
            new DCargoTransferencia().modificar_cantidad(id_fact, id_prod, cant,  vencimiento,  lote,  idItemPro);
        }

        public static DataTable buscar_prod(string dato)
        {
            return new DCargoTransferencia().buscar_prod(dato);
        }

        public static DataTable obtener_enteros_fracciones(int id_fact, string id_prod)
        {
            return new DCargoTransferencia().obtener_enteros_fracciones(id_fact, id_prod);
        }

        public static void guardar_prod_temp(int pc, int id_fact, string id_prod, string prod, string pres, int cant,DateTime fvencimiento, string lote)
        {
            new DCargoTransferencia().guardar_prod_temp(pc, id_fact, id_prod, prod, pres, cant, fvencimiento, lote);
        }

        public static string actualizar_nombre_prov(int pc, int id_fact)
        {
            return new DCargoTransferencia().actualizar_nombre_prov(pc, id_fact);
        }

        public static void eliminar_prod(int id_fact, string id_prod)
        {
            new DCargoTransferencia().eliminar_prod(id_fact, id_prod);
        }

        public static DataTable obtener_totales(string fact)
        {
            return new DCargoTransferencia().obtener_totales(fact);
        }

        public static void eliminar_CJ(int id)
        {
            new DCargoTransferencia().eliminar_CJ(id);
        }

        public static DataTable buscar_fact(int pc, string dato,DateTime dInicio,DateTime dFin)
        {
            return new DCargoTransferencia().buscar_fact(pc, dato, dInicio, dFin);
        }
    }
}
