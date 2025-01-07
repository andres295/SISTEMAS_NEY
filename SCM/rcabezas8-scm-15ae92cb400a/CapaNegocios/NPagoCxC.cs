using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NPagoCxC
    {

        public static DataTable cargar_cmb()
        {
            return new DPagoCxC().cargar_cmb();
        }
        public static DataTable Obtener_pago_factura(string id_factura)
        {
            return new DPagoCxC().Obtener_pago_factura(id_factura);
        }
        public static DataTable Obtener_by_cliente(string id_cliente)
        {
            return new DPagoCxC().Obtener_by_cliente(id_cliente);
        }
        public static DataTable obtener_datos(int id)
        {
            return new DPagoCxC().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DPagoCxC().eliminar(id);
        }

        public static bool modificar(int id, string Observacion, decimal Monto_Pago, bool estado)
        {
            return new DPagoCxC().modificar( id,  Observacion,  Monto_Pago,  estado);
        }

        public static bool verificar_si_existe(string servicio)
        {
            return new DPagoCxC().verificar_si_existe(servicio);
        }

        public static DataTable buscar(string dato,DateTime dtInicio,DateTime dtFin)
        {
            return new DPagoCxC().buscar(dato,dtInicio,dtFin);
        }
        public static DataTable buscar_saldo(string id_cliente)
        {
            return new DPagoCxC().buscar_saldo(id_cliente);
        }
        public static int num_reg()
        {
            return new DPagoCxC().num_reg();
        }

        public static string guardar(string Id_Usuario, string id_cliente, DateTime fecha, decimal monto_pago, string tipo_pago, string num_ref, string Observacion, DataTable dtDetFactura,string moneda, decimal tipocambio)
        {
            return new DPagoCxC().guardar( Id_Usuario,  id_cliente,  fecha,  monto_pago,  tipo_pago,  num_ref,  Observacion,  dtDetFactura, moneda, tipocambio);
        }
        //public static bool guardar_servicio_tem(string id_usuario, string observacion, decimal subtotal, decimal descuento, decimal total)
        //{
        //    return new DFactura().guardar(id_usuario, observacion, subtotal, descuento, total);
        //}
        public static DataTable Obtener_servicio_tem(string id_orden, string maquina )
        {
            return new DPagoCxC().Obtener_servicio_tem(id_orden,maquina);
        }
        public static DataTable Obtener_contrato_tem(string id_contrato, string maquina)
        {
            return new DPagoCxC().Obtener_contrato_tem(id_contrato, maquina);
        }
        public static bool quitar_servicio_tem(string id_factura, string id_orden, string id_usuario)
        {
            return new DPagoCxC().quitar_servicio_tem(id_factura, id_orden, id_usuario);
        }
        public static bool quitar_contrato_tem(string id_factura, string id_contrato, string id_usuario)
        {
            return new DPagoCxC().quitar_contrato_tem(id_factura, id_contrato, id_usuario);
        }
        public static bool quitar_todo_servicio_tem(string Id_Factura, string id_usuario)
        {
            return new DPagoCxC().quitar_todo_servicio_tem(Id_Factura, id_usuario);
        }
        public static bool guardar_factura_tem(string id_factura, string id_orden,string id_contrato, decimal Subtotal, string id_usuario)
        {
            return new DPagoCxC().guardar_factura_tem(id_factura, id_orden, id_contrato, Subtotal,id_usuario);
        }
        public static decimal Obtener_subt_total_servicio(string Id_Orden)
        {
            return new DPagoCxC().Obtener_subt_total_servicio(Id_Orden);
        }
        public static decimal Obtener_subt_total_contrato(string Id_Contrato)
        {
            return new DPagoCxC().Obtener_subt_total_contrato(Id_Contrato);
        }
    }
}
