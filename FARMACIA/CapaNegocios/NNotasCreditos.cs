using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NNotasCreditos
    {
        public static void guardar(string nc, string fact)
        {
            new DNotasCreditos().guardar(nc, fact);
        }

        public static DataTable obtener_datos_nc(string nc)
        {
            return new DNotasCreditos().obtener_datos_nc(nc);
        }

        public static void actualizar_stock(string nc, string fact, string id, bool accion)
        {
            new DNotasCreditos().actualizar_stock(nc, fact, id, accion);
        }

        public static string actualizar_nombre(string nc)
        {
            return new DNotasCreditos().actualizar_nombre(nc);
        }

        public static void deducir_nc(string nc, string fact)
        {
            new DNotasCreditos().deducir_nc(nc, fact);
        }

        public static void eliminar_nc(string nc)
        {
            new DNotasCreditos().eliminar_nc(nc);
        }

        public static void eliminar_prod(string nc, string id)
        {
            new DNotasCreditos().eliminar_prod(nc, id);
        }

        public static DataTable obtener_datos_fila(string nc, string fact, string id)
        {
            return new DNotasCreditos().obtener_datos_fila(nc, fact, id);
        }

        public static void actualizar_cantidad(string nc, string fact, string id, int cant, int bonif)
        {
            new DNotasCreditos().actualizar_cantidad(nc, fact, id, cant, bonif);
        }

        public static int verificar_temp(string nc)
        {
            return new DNotasCreditos().verificar_temp(nc);
        }

        public static int existe_prod(string nc, string fact, string id)
        {
            return new DNotasCreditos().existe_prod(nc, fact, id);
        }

        public static DataTable obtener_totales(string nc)
        {
            return new DNotasCreditos().obtener_totales(nc);
        }

        public static int verificar(string nc)
        {
            return new DNotasCreditos().verificar(nc);
        }

        public static DataTable buscar_prod(string fact, string dato)
        {
            return new DNotasCreditos().buscar_prod(fact, dato);
        }

        public static void guardar_prod_temp(string nc, string fact, string id, int cant, int bonif)
        {
            new DNotasCreditos().guardar_prod_temp(nc, fact, id, cant, bonif);
        }

        public static DataTable cargar_prod(string nc)
        {
            return new DNotasCreditos().cargar_prod(nc);
        }

        public static int num_reg()
        {
            return new DNotasCreditos().num_reg();
        }

        public static void guardar_nc(string nc, string fact, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser)
        {
            new DNotasCreditos().guardar_nc(nc, fact, id_prov, prov, fecha_emision, matriz, ruc, dir, tel, obser);
        }
        public static void actualizar_nc(string nc_actual,string nc, string fact, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser)
        {
            new DNotasCreditos().actualizar_nc(nc_actual, nc, fact, id_prov, prov, fecha_emision, matriz, ruc, dir, tel, obser);
        }
        public static int validar_nc(string nc)
        {
            return new DNotasCreditos().validar_nc(nc);
        }
        public static DataTable obtener_datos_fact_sel(string num_factura)
        {
            return new DNotasCreditos().obtener_datos_fact_sel(num_factura);
        }

        public static DataTable cargar_fact_sel(string dato)
        {
            return new DNotasCreditos().cargar_fact_sel(dato);
        }

        public static DataTable buscar(string dato)
        {
            return new DNotasCreditos().buscar(dato);
        }
        public static void guardar_nc(string nc, string fact, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser, string tipoNC, decimal monto)
        {
            new DNotasCreditos().guardar_nc(nc, fact, id_prov, prov, fecha_emision, matriz, ruc, dir, tel, obser, tipoNC, monto);
        }
    }
}
