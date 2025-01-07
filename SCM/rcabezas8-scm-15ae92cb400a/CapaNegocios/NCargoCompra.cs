using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCargoCompra
    {
        public static void actualizar_precios(string id, decimal pvf, decimal pvp, DateTime venc, string lote)
        {
            new DCargoCompra().actualizar_precios(id, pvf, pvp, venc, lote);
        }

        public static string actualizar_nombre_prov(string fact)
        {
            return new DCargoCompra().actualizar_nombre_prov(fact);
        }

        public static DataTable obtener_datos_prod(string fact, string id)
        {
            return new DCargoCompra().obtener_datos_prod(fact, id);
        }

        public static void aplicar_quitar_iva_sel(string fact, string id_prod, bool aplicar_quitar,decimal iva)
        {
            new DCargoCompra().aplicar_quitar_iva_sel(fact, id_prod, aplicar_quitar,iva);
        }
        public static void actualizar_iva(string fact,decimal iva)
        {
            new DCargoCompra().actualizar_iva(fact,iva);
        }
        public static void aplicar_quitar_desc_sel(string fact, string id_prod, bool aplicar_quitar, decimal por_descuento)
        {
            new DCargoCompra().aplicar_quitar_desc_sel(fact, id_prod, aplicar_quitar, por_descuento);
        }

        public static void aplicar_quitar_desc_todos(string fact, bool aplicar_quitar, decimal por_descuento)
        {
            new DCargoCompra().aplicar_quitar_desc_todos(fact, aplicar_quitar, por_descuento);
        }

        public static void aplicar_quitar_iva_todos(string fact, bool aplicar_quitar,decimal iva)
        {
            new DCargoCompra().aplicar_quitar_iva_todos(fact, aplicar_quitar,iva);
        }

        public static void guardar_prod(string fact)
        {
            new DCargoCompra().guardar_prod(fact);
        }

        public static void eliminar_prod(string idItem)
        {
            new DCargoCompra().eliminar_prod(idItem);
        }

        public static void actualizar_cantidades(string fact, string id_prod, int cant, int bonif, decimal porc_descuento,DateTime vencimiento, string lote,string idItemPro)
        {
            new DCargoCompra().actualizar_cantidades(fact, id_prod, cant, bonif, porc_descuento,vencimiento,lote, idItemPro);
        }

        public static DataTable obtener_totales_fila(string fact, string id_prod, string idItemProducto )
        {
            return new DCargoCompra().obtener_totales_fila(fact, id_prod,idItemProducto);
        }

        public static DataTable obtener_cantidades(string fact, string id_prod, string idItem)
        {
            return new DCargoCompra().obtener_cantidades(fact, id_prod, idItem);
        }

        public static DataTable obtener_totales(string fact)
        {
            return new DCargoCompra().obtener_totales(fact);
        }

        public static bool verificar_prod(string fact, string id_prod)
        {
            return new DCargoCompra().verificar_prod(fact, id_prod);
        }

        public static int verificar_cant_prod(string id_fact)
        {
            return new DCargoCompra().verificar_cant_prod(id_fact);
        }

        public static void agregar_prod_temp(string id_fact, string id_prod, int cant, int bonif, int id_user,DateTime fechaVence, string lote)
        {
            new DCargoCompra().agregar_prod_temp(id_fact, id_prod, cant, bonif, id_user, fechaVence,lote);
        }

        public static DataTable cargar_prod(string fact)
        {
            return new DCargoCompra().cargar_prod(fact);
        }

        public static bool activacion(string fact)
        {
            return new DCargoCompra().activacion(fact);
        }

        public static void eliminar_fact(string fact)
        {
            new DCargoCompra().eliminar_fact(fact);
        }

        public static void modificar(string fact_old, string fact_new, int id_prov, DateTime fecha_doc, int dias, DateTime fecha_pago, string observ, string est, decimal iva,  decimal desc)
        {
            new DCargoCompra().modificar(fact_old, fact_new, id_prov, fecha_doc, dias, fecha_pago, observ, est, iva,desc);
        }

        public static DataTable buscar(string dato, DateTime dInicio, DateTime dFin)
        {
            return new DCargoCompra().buscar(dato, dInicio, dFin);
        }
        public static DataTable obtener_Vencimiento( DateTime dInicio, DateTime dFin,string filtroNuevo)
        {
            return new DCargoCompra().obtener_Vencimiento( dInicio, dFin, filtroNuevo);
        }
        public static DataTable obtener_datos(string fact)
        {
            return new DCargoCompra().obtener_datos(fact);
        }

        public static int num_reg()
        {
            return new DCargoCompra().num_reg();
        }

        public static void guardar_fact(string fact, int id_prov, DateTime fecha_doc, int num_dias, DateTime fecha_pago, string iva, decimal desc, string observ, string est)
        {
            new DCargoCompra().guardar_fact(fact, id_prov, fecha_doc, num_dias, fecha_pago, iva, desc, observ, est);
        }
        public static bool siFacturaExiste(string fact)
        {
          return  new DCargoCompra().siFacturaExiste(fact);
        }
        public static DataTable valida_disponiblidad_producto(string tipoMov, string documento)
        {
            return new DCargoCompra().valida_disponiblidad_producto(tipoMov, documento);
        }
    }
}
