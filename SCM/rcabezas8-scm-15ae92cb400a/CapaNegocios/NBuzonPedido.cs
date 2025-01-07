using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NBuzonPedido
    {
        public static void actualizar_precios(string id, decimal pvf, decimal pvp, DateTime venc, string lote)
        {
            new DBuzonPedido().actualizar_precios(id, pvf, pvp, venc, lote);
        }

        public static string actualizar_nombre_prov(string fact)
        {
            return new DBuzonPedido().actualizar_nombre_prov(fact);
        }

        public static DataTable obtener_datos_prod(string fact, string id)
        {
            return new DBuzonPedido().obtener_datos_prod(fact, id);
        }

        public static void aplicar_quitar_iva_sel(string fact, string id_prod, bool aplicar_quitar)
        {
            new DBuzonPedido().aplicar_quitar_iva_sel(fact, id_prod, aplicar_quitar);
        }

        public static void aplicar_quitar_desc_sel(string fact, string id_prod, bool aplicar_quitar, decimal por_descuento)
        {
            new DBuzonPedido().aplicar_quitar_desc_sel(fact, id_prod, aplicar_quitar, por_descuento);
        }

        public static void aplicar_quitar_desc_todos(string fact, bool aplicar_quitar, decimal por_descuento)
        {
            new DBuzonPedido().aplicar_quitar_desc_todos(fact, aplicar_quitar, por_descuento);
        }

        public static void aplicar_quitar_iva_todos(string fact, bool aplicar_quitar)
        {
            new DBuzonPedido().aplicar_quitar_iva_todos(fact, aplicar_quitar);
        }

        public static void guardar_prod(string fact)
        {
            new DBuzonPedido().guardar_prod(fact);
        }

        public static void eliminar_prod(string id_fact, string id_prod)
        {
            new DBuzonPedido().eliminar_prod(id_fact, id_prod);
        }

        public static void actualizar_cantidades(string fact, string id_prod, int cant, int bonif, decimal porc_descuento)
        {
            new DBuzonPedido().actualizar_cantidades(fact, id_prod, cant, bonif, porc_descuento);
        }

        public static DataTable obtener_totales_fila(string fact, string id_prod)
        {
            return new DBuzonPedido().obtener_totales_fila(fact, id_prod);
        }

        public static DataTable obtener_cantidades(string fact, string id_prod)
        {
            return new DBuzonPedido().obtener_cantidades(fact, id_prod);
        }

        public static DataTable obtener_totales(string fact)
        {
            return new DBuzonPedido().obtener_totales(fact);
        }

        public static bool verificar_prod(string fact, string id_prod)
        {
            return new DBuzonPedido().verificar_prod(fact, id_prod);
        }

        public static int verificar_cant_prod(string id_fact)
        {
            return new DBuzonPedido().verificar_cant_prod(id_fact);
        }

        public static void agregar_prod_temp(string id_fact, string id_prod, int cant, int bonif, int id_user)
        {
            new DBuzonPedido().agregar_prod_temp(id_fact, id_prod, cant, bonif, id_user);
        }

        public static DataTable cargar_prod(string fact)
        {
            return new DBuzonPedido().cargar_prod(fact);
        }

        public static bool activacion(string fact)
        {
            return new DBuzonPedido().activacion(fact);
        }

        public static void eliminar_buzon(string id_buzon)
        {
            new DBuzonPedido().eliminar_buzon(id_buzon);
        }

        public static void modificar(string fact_old, string fact_new, int id_prov, DateTime fecha_doc, int dias, DateTime fecha_pago, string observ, string est, decimal iva,  decimal desc)
        {
            new DBuzonPedido().modificar(fact_old, fact_new, id_prov, fecha_doc, dias, fecha_pago, observ, est, iva,desc);
        }

        public static DataTable buscar(string dato,string proveedor )
        {
            return new DBuzonPedido().buscar(dato,proveedor);
        }
        public static DataTable obtener_Vencimiento( DateTime dInicio, DateTime dFin)
        {
            return new DBuzonPedido().obtener_Vencimiento( dInicio, dFin);
        }
        public static DataTable obtener_datos(DateTime dtInicio, DateTime dtFin )
        {
            return new DBuzonPedido().obtener_datos(dtInicio,dtFin);
        }

        public static int num_reg()
        {
            return new DBuzonPedido().num_reg();
        }

        public static void guardar_buzon(DateTime fecha_inicio, DateTime fecha_fin)
        {
            new DBuzonPedido().guardar_buzon(fecha_inicio,fecha_fin);
        }
        public static bool siFacturaExiste(string fact)
        {
          return  new DBuzonPedido().siFacturaExiste(fact);
        }
    }
}
