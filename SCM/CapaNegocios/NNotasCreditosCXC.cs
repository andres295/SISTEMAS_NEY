using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NNotasCreditosCXC
    {
        public static void guardar(string nc, string fact)
        {
            new DNotasCreditosCXC().guardar(nc, fact);
        }

        public static DataTable obtener_datos_nc(string nc)
        {
            return new DNotasCreditosCXC().obtener_datos_nc(nc);
        }

        public static void actualizar_stock(string nc, string fact, string id, bool accion)
        {
            new DNotasCreditosCXC().actualizar_stock(nc, fact, id, accion);
        }

        public static string actualizar_nombre(string nc)
        {
            return new DNotasCreditosCXC().actualizar_nombre(nc);
        }

        public static void deducir_nc(string nc, string fact)
        {
            new DNotasCreditosCXC().deducir_nc(nc, fact);
        }

        public static void eliminar_nc(string nc)
        {
            new DNotasCreditosCXC().eliminar_nc(nc);
        }

        public static void eliminar_prod(string nc, string id)
        {
            new DNotasCreditosCXC().eliminar_prod(nc, id);
        }

        public static DataTable obtener_datos_fila(string nc, string fact, string id)
        {
            return new DNotasCreditosCXC().obtener_datos_fila(nc, fact, id);
        }

        public static void actualizar_cantidad(string nc, string fact, string id, int cant, int bonif)
        {
            new DNotasCreditosCXC().actualizar_cantidad(nc, fact, id, cant, bonif);
        }

        public static int verificar_temp(string nc)
        {
            return new DNotasCreditosCXC().verificar_temp(nc);
        }

        public static int existe_prod(string nc, string fact, string id)
        {
            return new DNotasCreditosCXC().existe_prod(nc, fact, id);
        }

        public static DataTable obtener_totales(string nc)
        {
            return new DNotasCreditosCXC().obtener_totales(nc);
        }

        public static int verificar(string nc)
        {
            return new DNotasCreditosCXC().verificar(nc);
        }

        public static DataTable buscar_prod(string num_venta, string dato)
        {
            return new DNotasCreditosCXC().buscar_prod(num_venta, dato);
        }

        public static void guardar_prod_temp(string nc, string fact, string id, int cant, int bonif)
        {
            new DNotasCreditosCXC().guardar_prod_temp(nc, fact, id, cant, bonif);
        }

        public static DataTable cargar_prod(string nc)
        {
            return new DNotasCreditosCXC().cargar_prod(nc);
        }

        public static int num_reg()
        {
            return new DNotasCreditosCXC().num_reg();
        }

        public static void guardar_nc(string nc, int num_venta, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser,string tipoNC,decimal monto)
        {
            new DNotasCreditosCXC().guardar_nc(nc, num_venta, id_prov, prov, fecha_emision, matriz, ruc, dir, tel, obser, tipoNC, monto);
        }
        public static void actualizar_nc(string nc_actual,string nc, string fact, int id_prov, string prov, DateTime fecha_emision, string matriz, string ruc, string dir, string tel, string obser)
        {
            new DNotasCreditosCXC().actualizar_nc(nc_actual, nc, fact, id_prov, prov, fecha_emision, matriz, ruc, dir, tel, obser);
        }
        public static int validar_nc(string nc)
        {
            return new DNotasCreditosCXC().validar_nc(nc);
        }
        public static DataTable obtener_datos_fact_sel(string num_venta)
        {
            return new DNotasCreditosCXC().obtener_datos_fact_sel(num_venta);
        }

        public static DataTable cargar_fact_sel(string dato)
        {
            return new DNotasCreditosCXC().cargar_fact_sel(dato);
        }

        public static DataTable buscar(string dato)
        {
            return new DNotasCreditosCXC().buscar(dato);
        }
        public static DataTable buscar_rpt_nc(int IdCliente, DateTime desde, DateTime hasta)
        {
            return new DNotasCreditosCXC().buscar_rpt_nc(IdCliente,  desde,  hasta);
        }
        public static DataTable buscar_rpt_ck(int IdCliente, DateTime desde, DateTime hasta)
        {
            return new DNotasCreditosCXC().buscar_rpt_ck(IdCliente, desde, hasta);
        }
        public static DataTable buscar_rpt_pagos(int IdCliente, DateTime desde, DateTime hasta)
        {
            return new DNotasCreditosCXC().buscar_rpt_pagos(IdCliente, desde, hasta);
        }
    }
}
