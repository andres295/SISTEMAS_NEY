using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCotizaciones
    {
        public static void modificar_cot(long id_cot, int id_cliente)
        {
            new DCotizaciones().modificar_cot(id_cot, id_cliente);
        }
        public static DataTable buscar_cotizacion_tem(string dato, int id_usuario)
        {
            return new DCotizaciones().buscar_cotizacion_tem(dato, id_usuario);
        }
        public static void modificar_cantidad(int id_cot, string id_prod, long cant, decimal ganan, decimal parc)
        {
            new DCotizaciones().modificar_cantidad(id_cot, id_prod, cant, ganan, parc);
        }

        public static int obtener_cont(int id_cot, string id_prod)
        {
            return new DCotizaciones().obtener_cont(id_cot, id_prod);
        }

        public static DataTable obtener_cant_fracciones(int id_cot, string id_prod)
        {
            return new DCotizaciones().obtener_cant_fracciones(id_cot, id_prod);
        }

        public static void guardar_prod(int id_cot)
        {
            new DCotizaciones().guardar_prod(id_cot);
        }

        public static DataTable obtener_montos_fila(int id_cot, string id_prod)
        {
            return new DCotizaciones().obtener_montos_fila(id_cot, id_prod);
        }

        public static int obtener_cant_enteros(int id_cot, string id_prod)
        {
            return new DCotizaciones().obtener_cant_enteros(id_cot, id_prod);
        }

        public static void eliminar_prod(int id_cot, string id_prod)
        {
            new DCotizaciones().eliminar_prod(id_cot, id_prod);
        }

        public static DataTable cargar_prod(int id_cot)
        {
            return new DCotizaciones().cargar_prod(id_cot);
        }

        public static DataTable obtener_montos(int id_cot)
        {
            return new DCotizaciones().obtener_montos(id_cot);
        }

        public static void guardar_prod_temp(int id_cot, string id_prod, int cant, decimal parcial, decimal ganan)
        {
            new DCotizaciones().guardar_prod_temp(id_cot, id_prod, cant, parcial, ganan);
        }

        public static decimal calcular_parcial(string id_prod)
        {
            return new DCotizaciones().calcular_parcial(id_prod);
        }

        public static decimal calcular_ganan(string id_prod, long cant)
        {
            return new DCotizaciones().calcular_ganan(id_prod, cant);
        }

        public static int num_reg()
        {
            return new DCotizaciones().num_reg();
        }

        public static string actualizar_nombre_prov(int id_cot)
        {
            return new DCotizaciones().actualizar_nombre_prov(id_cot);
        }

        public static int verificar_prod_temp(int id_cot, string id_prod)
        {
            return new DCotizaciones().verificar_prod_temp(id_cot, id_prod);
        }

        public static long guardar(int pc, int id_cliente, int id_user)
        {
            return new DCotizaciones().guardar(pc, id_cliente, id_user);
        }

        public static void pagar(int id_cot, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf)
        {
            new DCotizaciones().pagar(id_cot, monto_efect, cheque, fecha_cobro, id_banco, cheque_monto, img_cheque, tranf, monto_tranf, img_tranf);
        }

        public static void eliminar_cot(int id_cot)
        {
            new DCotizaciones().eliminar_cot(id_cot);
        }

        public static int num_reg_temp(int id_cot)
        {
            return new DCotizaciones().num_reg_temp(id_cot);
        }

        public static int num_reg_save(int id_cot)
        {
            return new DCotizaciones().num_reg_save(id_cot);
        }

        public static DataTable buscar(int pc, string dato)
        {
            return new DCotizaciones().buscar(pc, dato);
        }
        public static DataTable buscar_by_id(int idCotizacion)
        {
            return new DCotizaciones().buscar_by_id(idCotizacion);
        }
        public static void actualizar_cliente(long id_cotizacion, int id_cliente, string name_temp)
        {
            new DCotizaciones().actualizar_cliente(id_cotizacion, id_cliente, name_temp);
        }
    }
}
