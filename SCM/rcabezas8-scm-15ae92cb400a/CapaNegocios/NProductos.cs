using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NProductos
    {
        public static DataTable buscar1(string dato)
        {
            return new DProductos().buscar1(dato);
        }
        public static DataTable buscobtener_stockar(string producto,string proveedor, string filtroNuevo)
        {
            return new DProductos().obtener_stock(producto, proveedor, filtroNuevo);
        }
        public static DataTable buscar_kardex(DateTime dInicio, DateTime dFin, string id_producto,string mov)
        {
            return new DProductos().obtener_kardex(dInicio, dFin, id_producto, mov);
        }
        public static DataTable obtener_historico_compra_producto(DateTime dInicio, DateTime dFin, string producto, string tipo)
        {
            return new DProductos().obtener_historico_compra_producto(dInicio, dFin, producto, tipo);
        }
        public static long obtener_disponible(string id_prod)
        {
            return new DProductos().obtener_disponible(id_prod);
        }
        public static long obtener_disponible_vs_venta(string idventa,string id_prod)
        {
            return new DProductos().obtener_disponible_vs_venta(idventa,id_prod);
        }
        public static string obtener_disponible_texto(string id_prod)
        {
            return new DProductos().obtener_disponible_texto(id_prod);
        }

        public static void actualizar_desc(string id_prod)
        {
            new DProductos().actualizar_desc(id_prod);
        }

        public static int obtener_cont(string id)
        {
            return new DProductos().obtener_cont(id);
        }
        public static int obtener_cant_fracciones_restante(string id)
        {
            return new DProductos().obtener_cant_fracciones_restante(id);
        }
        public static string obtener_img_prod(string id)
        {
            return new DProductos().obtener_img_prod(id);
        }
        public static int  obtener_contiene(string id)
        {
            return new DProductos().obtener_contiene(id);
        }
        public static decimal obtener_precio_compra(string id)
        {
            return new DProductos().obtener_precio_compra(id);
        }
        public static int obtener_dia_vencimiento(string id)
        {
            return new DProductos().obtener_dia_vencimiento(id);
        }
        public static int tamaño(string dato, int registro_por_pagina)
        {
            return new DProductos().tamaño(dato, registro_por_pagina);
        }

        public static DataTable buscar(string dato, int pagina_actual, int tamaño)
        {
            return new DProductos().buscar(dato, pagina_actual, tamaño);
        }
        public static DataTable buscar2()
        {
            return new DProductos().buscar2();
        }
        public static DataTable cargarProductoFiltro1()
        {
            return new DProductos().cargarProductoFiltro1();
        }
        public static DataTable cargarProductoFiltro2(string filtro)
        {
            return new DProductos().cargarProductoFiltro2(filtro);
        }
        public static void actualizar_foto(string id, string foto)
        {
            new DProductos().actualizar_foto(id, foto);
        }

        public static bool guardar(string cb, string prod, int id_pres, int id_prov, string pvf, string pvp, int cont, DateTime venc, string est, string lote, string foto, int id_especif,int Id_Composicion,bool pvp_iva,string name_usuario,string registro_sanitario)
        {
            return new DProductos().guardar(cb, prod, id_pres, id_prov, pvf, pvp, cont, venc, est, lote, foto, id_especif, Id_Composicion, pvp_iva,name_usuario, registro_sanitario);
        }

        public static void eliminar(string id,string name_usuario)
        {
            new DProductos().eliminar(id, name_usuario);
        }

        public static bool modificar(string id, string cb, string prod, int id_pres, int id_prov, string pvf, string pvp, int cont, DateTime venc, string est, string lote, int id_especif,int Id_Composicion,bool pvp_iva,string name_usuario,string registro_sanitario)
        {
            return new DProductos().modificar(id, cb, prod, id_pres, id_prov, pvf, pvp, cont, venc, est, lote, id_especif, Id_Composicion,pvp_iva,name_usuario, registro_sanitario);
        }

        public static int num_reg()
        {
            return new DProductos().num_reg();
        }
        public static int valida_mov_cardex_codigo_barra(string codigo_barra)
        {
            return new DProductos().valida_mov_cardex_codigo_barra(codigo_barra);
        }
        public static DataTable obtener_datos(string id)
        {
            return new DProductos().obtener_datos(id);
        }
        public static DataTable obtener_producto_by_composicion(string id)
        {
            return new DProductos().obtener_producto_by_composicion(id);
        }
        public static DataTable obtener_producto_by_especificacion(string especificacion)
        {
            return new DProductos().obtener_producto_by_especificacion(especificacion);
        }
        public static DataTable obtener_producto_by_composicion_filter(string id_composicion)
        {
            return new DProductos().obtener_producto_by_composicion_filter(id_composicion);
        }
        public static DataTable obtener_composicion(string id,string filtro)
        {
            return new DProductos().obtener_composicion(id,filtro);
        }
        public static DataTable obtener_composicion_by_filter( string filtro)
        {
            return new DProductos().obtener_composicion_by_filter(filtro);
        }
        public static string obtener_composicion_by_producto(string id,bool tipo)
        {
            return new DProductos().obtener_composicion_by_producto(id,tipo);
        }
        public static DataTable obtener_composicion_by_producto(string id)
        {
            return new DProductos().obtener_composicion_by_producto(id);
        }
        public static bool asignar_composicion(string id_producto, string id_composicion)
        {
            return new DProductos().asignar_composicion(id_producto, id_composicion);
        }
        public static bool quitar_composicion(string id_usuario, string id_permiso)
        {
            return new DProductos().quitar_composicion(id_usuario, id_permiso);
        }
        public static DataTable obtener_productos(string datos)
        {
            return new DProductos().obtener_productos(datos);
        }
        public static DataTable obtener_productos_venta(string datos,int stocK_producto)
        {
            return new DProductos().obtener_productos_venta(datos, stocK_producto);
        }
        public static DataTable obtener_productos_venta_por_composicion(string datos, int stocK_producto)
        {
            return new DProductos().obtener_productos_venta_por_composicion(datos, stocK_producto);
        }
        public static DataTable obtener_productos_cat(string datos,bool eliminado)
        {
            return new DProductos().obtener_productos_cat(datos,eliminado);
        }
        public static DataTable bitacora_producto(string id,bool eliminado)
        {
            return new DProductos().bitacora_producto(id, eliminado);
        }
        public static DataTable Obtener_Solicitud_by_usuario(int id_usuario, DateTime dtinicio, DateTime dtFin)
        {
            return new DProductos().Obtener_Solicitud_by_usuario(id_usuario, dtinicio, dtFin);
        }
        public static bool Agregar_Registro_Solicitud_Producto(string producto, decimal cantidad, decimal monto, int id_usuario)
        {
            return new DProductos().Agregar_Registro_Solicitud_Producto(producto, cantidad, monto, id_usuario);
        }
        public static bool eliminar_solicitud_producto(int id_solicitud)
        {
            return new DProductos().eliminar_solicitud_producto(id_solicitud);
        }
        public static DataTable cargarCatProducto()
        {
            return new DProductos().cargarCatProducto();
        }
        public static DataTable obtener_datos_pro(string id)
        {
            return new DProductos().obtener_datos_pro(id);
        }
    }
}
