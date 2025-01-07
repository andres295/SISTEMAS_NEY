using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NContrato
    {
        public static DataTable lista_combo(string id_factura, string id_usuario)
        {
            return new DContrato().lista_combo(id_factura, id_usuario);
        }
        public static DataTable cargar_cmb()
        {
            return new DContrato().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DContrato().obtener_datos(id);
        }

        public static bool eliminar(int id)
        {
            return new DContrato().eliminar(id);
        }

        public static bool modificar(int id, string id_cliente, string id_doctor, string Observacion, decimal monto_prima, decimal monto_cuota_mensual, int num_cuota, decimal monto_total_contrato, bool facturada, bool activa,string moneda)
        {
            return new DContrato().modificar(id, id_cliente, id_doctor, Observacion, monto_prima, monto_cuota_mensual, num_cuota, monto_total_contrato, facturada, activa,moneda);
        }

        public static bool verificar_si_existe(string servicio)
        {
            return new DContrato().verificar_si_existe(servicio);
        }

        public static DataTable buscar(string dato, DateTime dtInicio, DateTime dtFin)
        {
            return new DContrato().buscar(dato, dtInicio, dtFin);
        }
        public static DataTable buscar_by_cliente(string dato)
        {
            return new DContrato().buscar_by_cliente(dato);
        }
        public static int num_reg()
        {
            return new DContrato().num_reg();
        }

        public static bool guardar(string Maquina, string Id_Cliente, string Id_Usuario, string Id_Doctor, string Observacion, decimal monto_prima, decimal monto_cuota_mensual, int num_cuota, decimal monto_total_contrato,string  moneda)
        {
            return new DContrato().guardar(Maquina, Id_Cliente, Id_Usuario, Id_Doctor, Observacion, monto_prima, monto_cuota_mensual, num_cuota, monto_total_contrato,moneda);
        }
        public static bool guardar_servicio_tem(string Maquina, string Id_Cliente, string Id_Usuario, string Id_Doctor, string Observacion, decimal monto_prima, decimal monto_cuota_mensual, int num_cuota, decimal monto_total_contrato, string moneda)
        {
            return new DContrato().guardar(Maquina, Id_Cliente, Id_Usuario, Id_Doctor, Observacion, monto_prima, monto_cuota_mensual, num_cuota, monto_total_contrato,moneda);
        }
        public static DataTable Obtener_servicio_tem(string id_orden, string maquina)
        {
            return new DContrato().Obtener_servicio_tem(id_orden, maquina);
        }
        public static bool quitar_servicio_tem(string id_orden, string id_servicio, string id_usuario)
        {
            return new DContrato().quitar_servicio_tem(id_orden, id_servicio, id_usuario);
        }
        public static bool quitar_todo_servicio_tem(string id_orden, string id_usuario)
        {
            return new DContrato().quitar_todo_servicio_tem(id_orden, id_usuario);
        }
        public static bool guardar_servicio_tem(string id_orden, string id_servicio, string id_usuario)
        {
            return new DContrato().guardar_servicio_tem(id_orden, id_servicio, id_usuario);
        }
    }
}
