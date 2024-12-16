using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NFactura
    {

        public static DataTable cargar_cmb()
        {
            return new DFactura().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DFactura().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DFactura().eliminar(id);
        }
        public static void eliminar_fact(long id_venta)
        {
            new DFactura().eliminar_fact(id_venta);
        }
        public static bool modificar(int id, string observacion,decimal subtotal, decimal descuento,decimal total,bool estado)
        {
            return new DFactura().modificar(id, observacion, subtotal, descuento,total, estado);
        }

        public static bool verificar_si_existe(string servicio)
        {
            return new DFactura().verificar_si_existe(servicio);
        }

        public static DataTable buscar(string dato,DateTime dtInicio,DateTime dtFin, bool estado)
        {
            return new DFactura().buscar(dato,dtInicio,dtFin, estado);
        }
        public static DataTable buscar_by_cliente(string dato)
        {
            return new DFactura().buscar_by_cliente(dato);
        }
        public static DataTable buscar_pendiente_pago(string dato, DateTime dtInicio, DateTime dtFin)
        {
            return new DFactura().buscar_pendiente_pago(dato, dtInicio, dtFin);
        }
        public static DataTable buscar_saldo(string id_cliente, string moneda)
        {
            return new DFactura().buscar_saldo(id_cliente, moneda);
        }
        public static DataTable buscar_saldo_by_name(string name,string moneda)
        {
            return new DFactura().buscar_saldo_by_name(name, moneda);
        }
        public static int num_reg()
        {
            return new DFactura().num_reg();
        }

        public static string guardar(string numventa, string id_cliente, string id_especialista,string id_usuario, string observacion, decimal subtotal,decimal descuento, decimal total, string moneda, decimal tipoCambio, string TipoVenta)
        {
            return new DFactura().guardar(numventa,id_cliente, id_especialista, id_usuario, observacion,subtotal,descuento,total, moneda, tipoCambio, TipoVenta);
        }
        //public static bool guardar_servicio_tem(string id_usuario, string observacion, decimal subtotal, decimal descuento, decimal total)
        //{
        //    return new DFactura().guardar(id_usuario, observacion, subtotal, descuento, total);
        //}
        public static DataTable Obtener_servicio_tem(string id_orden, string maquina )
        {
            return new DFactura().Obtener_servicio_tem(id_orden,maquina);
        }
        public static DataTable Obtener_servicio_tem_by_id(string id_orden)
        {
            return new DFactura().Obtener_servicio_tem_by_id(id_orden);
        }
        public static string Obtener_Concepto_Orden(string id_orden)
        {
            return new DFactura().Obtener_Concepto_Orden(id_orden);
        }
        public static string Obtener_Concepto_contrato(string id_contrato)
        {
            return new DFactura().Obtener_Concepto_contrato(id_contrato);
        }
        public static DataTable Obtener_contrato_tem(string id_contrato, string maquina)
        {
            return new DFactura().Obtener_contrato_tem(id_contrato, maquina);
        }
        public static bool quitar_servicio_tem(string id_factura, string id_orden, string id_usuario)
        {
            return new DFactura().quitar_servicio_tem(id_factura, id_orden, id_usuario);
        }
        public static bool quitar_contrato_tem(string id_factura, string id_contrato, string id_usuario)
        {
            return new DFactura().quitar_contrato_tem(id_factura, id_contrato, id_usuario);
        }
        public static bool quitar_todo_servicio_tem(string Id_Factura, string id_usuario)
        {
            return new DFactura().quitar_todo_servicio_tem(Id_Factura, id_usuario);
        }
        public static bool guardar_factura_tem(string id_venta, string id_orden,string id_contrato,int cantidad, decimal Subtotal, string id_usuario,string concepto)
        {
            return new DFactura().guardar_factura_tem(id_venta, id_orden, id_contrato, cantidad,Subtotal, id_usuario,concepto);
        }
        public static bool valida_servicio_factura_tem(string id_venta, string id_servicio)
        {
            return new DFactura().valida_servicio_factura_tem(id_venta, id_servicio);
        }
        public static bool update_factura_tem(string idRow,string id_servicio_orden, int cantidad, decimal descuento, decimal precio_servicio)
        {
            return new DFactura().update_factura_tem( idRow, id_servicio_orden, cantidad, descuento, precio_servicio);
        } 
        public static decimal Obtener_subt_total_servicio(string Id_Orden)
        {
            return new DFactura().Obtener_subt_total_servicio(Id_Orden);
        }
        public static decimal Obtener_subt_total_contrato(string Id_Contrato)
        {
            return new DFactura().Obtener_subt_total_contrato(Id_Contrato);
        }
        public static void actualizar_cliente(long id_venta, int id_cliente)
        {
            new DFactura().actualizar_cliente(id_venta, id_cliente);
        }
        public static bool verificar_siexiste_venta(long num_venta)
        {
            return new DFactura().verificar_siexiste_venta(num_venta);
        }
    }
}
