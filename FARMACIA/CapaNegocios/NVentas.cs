using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NVentas
    {
        public static void eliminar_fact(long id_venta)
        {
            new DVentas().eliminar_fact(id_venta);
        }
        public static void eliminar_venta_tem(long id_venta)
        {
            new DVentas().eliminar_venta_tem(id_venta);
        }

        public static void guardar_prod_temp(long num_venta, string id_prod, long cant, decimal parcial, decimal ganan)
        {
            new DVentas().guardar_prod_temp(num_venta, id_prod, cant, ganan, parcial);
        }

        public static void eliminar_prod(long id_venta, string id_prod)
        {
            new DVentas().eliminar_prod(id_venta, id_prod);
        }

        public static string actualizar_nombre_cliente(long id_venta)
        {
            return new DVentas().actualizar_nombre_cliente(id_venta);
        }
        public static DataTable pagar(string idCliente,long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf, decimal monto_TC, decimal monto_TD, string adquirente, decimal tc_interes,string id_tipo_venta)
        {
           return new DVentas().pagar( idCliente,id_venta, monto_efect, cheque, fecha_cobro, id_banco, cheque_monto, img_cheque, tranf, monto_tranf, img_tranf, monto_TC, monto_TD, adquirente, tc_interes,id_tipo_venta);
        }
        public static void ActualizaVenta(long id_venta, string id_cliente, string id_tipo_venta, string numDocumento)
        {
            new DVentas().ActualizaVenta(id_venta, id_cliente, id_tipo_venta, numDocumento);
        }
        public static void ActualizaClienteVenta(long id_venta, string id_cliente )
        {
            new DVentas().ActualizaClienteVenta(id_venta, id_cliente );
        }
        public static int credito(long id_venta, string num_factura, string id_cliente, string fecha_emision, int dia_pago, string fecha_vencimiento, decimal monto_factura, bool retencion_renta, bool retencion_iva, int tipo_venta, string origen_factura)
        {
            return new DVentas().credito(id_venta, num_factura, id_cliente, fecha_emision, dia_pago, fecha_vencimiento, monto_factura, retencion_renta, retencion_iva, tipo_venta, origen_factura);
        }
        public static string obtener_vendio_texto(long id_venta, string id_prod)
        {
            return new DVentas().obtener_vendio_texto(id_venta, id_prod);
        }

        public static DataTable obtener_montos(long id_venta)
        {
            return new DVentas().obtener_montos(id_venta);
        }

        public static void actualizar_cliente(long id_venta, int id_cliente)
        {
            new DVentas().actualizar_cliente(id_venta, id_cliente);
        }
        public static void actualizar_cliente(long id_venta, int id_cliente,string name_temp)
        {
            new DVentas().actualizar_cliente(id_venta, id_cliente,name_temp);
        }
        public static bool verificar_siexiste_venta(long num_venta)
        {
            return new DVentas().verificar_siexiste_venta(num_venta);
        }

        public static int obtener_cant_enteros(long id_venta, string id_prod)
        {
            return new DVentas().obtener_cant_enteros(id_venta, id_prod);
        }

        public static DataTable obtener_cant_fracciones(long id_venta, string id_prod)
        {
            return new DVentas().obtener_cant_fracciones(id_venta, id_prod);
        }

        public static DataTable obtener_montos_fila(long id_venta, string id_prod)
        {
            return new DVentas().obtener_montos_fila(id_venta, id_prod);
        }

        public static void modificar_cantidad(long id_venta, string id_prod, long cant, decimal ganan, decimal parc)
        {
            new DVentas().modificar_cantidad(id_venta, id_prod, cant, ganan, parc);
        }

        public static bool verificar_siexiste_prod(long id_venta, string id_prod)
        {
            return new DVentas().verificar_siexiste_prod(id_venta, id_prod);
        }

        public static DataTable cargar_prod(long id_venta)
        {
            return new DVentas().cargar_prod(id_venta);
        }
        public static void limpia_tem(string id_usuario)
        {
             new DVentas().limpia_tem(id_usuario);
        }
        public static void limpia_tem(string id_usuario,int id_venta)
        {
            new DVentas().limpia_tem(id_usuario,id_venta);
        }
        public static DataTable cargar_count_productos_by_venta(long id_venta)
        {
            return new DVentas().cargar_count_productos_by_venta(id_venta);
        }

        public static DataTable buscar_ventas(string dato)
        {
            return new DVentas().buscar_ventas(dato);
        }
        public static DataTable buscar_ventas_tem(string dato,int id_usuario)
        {
            return new DVentas().buscar_ventas_tem(dato,id_usuario);
        }
        public static DataTable buscar_ventas_historico(string dato, int id_usuario,DateTime dInicio, DateTime dFin)
        {
            return new DVentas().buscar_ventas_historico(dato, id_usuario, dInicio, dFin);
        }
        
        public static void agregar_venta(long num_venta, int pc, int id_cliente, int id_user)
        {
            new DVentas().agregar_venta(num_venta, pc, id_cliente, id_user);
        }

        public static DataTable buscar_prod_rapido(string cb)
        {
            return new DVentas().buscar_prod_rapido(cb);
        }

        public static DataTable buscar_prod(string dato)
        {
            return new DVentas().buscar_prod(dato);
        }

        public static long obtener_num_venta()
        {
            return new DVentas().obtener_num_venta();
        }
        public static DataTable rpt_venta(DateTime dtInicio , DateTime dtFin)
        {
            return new DVentas().rpt_venta(dtInicio, dtFin);
        }
        public static decimal obtener_monto_venta_cierre(int id_usuario)
        {
            return new DVentas().obtener_monto_venta_cierre(id_usuario);
        }
        public static bool siFacturaCreditoExiste(string fact)
        {
            return new DVentas().siFacturaCreditoExiste(fact);
        }
        public static int SolicitaPrecioEspecial(int Id_Venta, int Id_Det_Venta, string Id_Producto, decimal Precio_Especial, decimal Cantidad, string Usuario_Solicita)
        {
            return new DVentas().SolicitaPrecioEspecial(Id_Venta, Id_Det_Venta, Id_Producto, Precio_Especial, Cantidad, Usuario_Solicita);
        }
        public static string ObtenerNumeroConsecutivoSR(int IdVenta)
        {
            return new DVentas().ObtenerNumeroConsecutivoSR(IdVenta);
        } 
        public static DataTable Obtener_Solicitud_Precio_Especial(string estado, DateTime dInicio, DateTime dFin)
        {
            return new DVentas().Obtener_Solicitud_Precio_Especial(estado, dInicio, dFin);
        }
        public static int Cantidad_Solicitud_Precio_Especial(int Id_Venta)
        {
            return new DVentas().Cantidad_Solicitud_Precio_Especial(Id_Venta);
        }
        public static void ApruebaRechazaPrecioEspecial(int id_venta, int id_precio_especial, decimal precio_especial, decimal cantidad, string id_producto, string estado, string usuario)
        {
            new DVentas().ApruebaRechazaPrecioEspecial(id_venta, id_precio_especial, precio_especial, cantidad, id_producto, estado, usuario);
        }
        public static DataTable obtener_cantidad(long id_venta, string id_prod,string id_Item)
        {
            return new DVentas().obtener_cantidad(id_venta, id_prod);
        }
        public static void AgregarFormaPago(long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf, decimal monto_TC, decimal monto_TD, string adquirente, decimal tc_interes, string id_tipo_venta)
        {
            new DVentas().AgregarFormaPago(id_venta, monto_efect, cheque, fecha_cobro, id_banco, cheque_monto, img_cheque, tranf, monto_tranf, img_tranf, monto_TC, monto_TD, adquirente, tc_interes, id_tipo_venta);
        }
        public static DataTable Obtener_Forma_Pago_Venta_Temp(long id_venta)
        {
            return new DVentas().Obtener_Forma_Pago_Venta_Temp(id_venta);
        }
        public static bool eliminar_detalle_multi_pago(int id_detalle_pago)
        {
            return new DVentas().eliminar_detalle_multi_pago(id_detalle_pago);
        }
        public static bool eliminar_detalle_multi_pago_by_usuario(int id_usuario)
        {
            return new DVentas().eliminar_detalle_multi_pago_by_usuario(id_usuario);
        }
        public static DataTable pagar_multi_pago(string idCliente,long id_venta, decimal monto_efect, string cheque, DateTime fecha_cobro, int id_banco, decimal cheque_monto, string img_cheque, string tranf, decimal monto_tranf, string img_tranf, decimal monto_TC, decimal monto_TD, string adquirente, decimal tc_interes, string id_tipo_venta)
        {
            return new DVentas().pagar_multi_pago(idCliente,id_venta, monto_efect, cheque, fecha_cobro, id_banco, cheque_monto, img_cheque, tranf, monto_tranf, img_tranf, monto_TC, monto_TD, adquirente, tc_interes, id_tipo_venta);
        }
        public static DataTable Obtener_Producto_Venta(long id_venta)
        {
            return new DVentas().Obtener_Producto_Venta(id_venta);
        }
        public static DataTable Obtener_Producto_Venta_by_TipoPago(long id_venta)
        {
            return new DVentas().Obtener_Producto_Venta_by_TipoPago(id_venta);
        } 
        public static bool ValidaVentaEnviadaSRI(string idVenta)
        {
            return new DVentas().ValidaVentaEnviadaSRI(idVenta);
        } 
    }
}
