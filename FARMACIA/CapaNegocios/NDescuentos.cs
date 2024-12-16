using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NDescuentos
    {
        public static bool guardar_todos(int id_prov, DateTime desde, DateTime hasta, string desc)
        {
            return new DDescuentos().guardar_todos(id_prov, desde, hasta, desc);
        }

        public static bool verificar_descuento(int id_prov)
        {
            return new DDescuentos().verificar_descuento(id_prov);
        }

        public static bool guardar_selec(string id, DateTime desde, DateTime hasta, string desc)
        {
            return new DDescuentos().guardar_selec(id, desde, hasta, desc);
        }

        public static DataTable buscar_prod(int id_prov,string datos)
        {
            return new DDescuentos().buscar_prod(id_prov, datos);
        }

        public static DataTable buscar_prov(string dato)
        {
            return new DDescuentos().buscar_prov(dato);
        }

        public static DataTable buscar_descuento_by_producto(string id_prov)
        {
            return new DDescuentos().buscar_descuento_by_producto(id_prov);
        }

        public static bool guardar_descuento_categoria(string accion, int id_descuento, string id_producto, string cant_min, string cant_max, string descuento, DateTime desde, DateTime hasta)
        {
            return new DDescuentos().guardar_descuento_categoria(accion, id_descuento, id_producto, cant_min, cant_max, descuento, desde, hasta);
        }
        public static int valida_descuento_categoria(string accion, string id_producto, string cant_min, string cant_max, string descuento, DateTime desde, DateTime hasta)
        {
            return new DDescuentos().valida_descuento_categoria(accion, id_producto, cant_min, cant_max, descuento, desde, hasta);
        }
        public static DataTable Obtener_Descuento_Linea()
        {
            return new DDescuentos().Obtener_Descuento_Linea();
        }
        public static int agregar_descuento_linea(string descripcion, decimal porcentaje, DateTime dtInicio, DateTime dtFin, bool estado, int usuario)
        {
            return new DDescuentos().agregar_descuento_linea(descripcion, porcentaje, dtInicio, dtFin, estado, usuario);
        }
        public static int modificar_descuento_linea(int id_descuento, string descripcion, decimal porcentaje, DateTime dtInicio, DateTime dtFin, bool estado)
        {
            return new DDescuentos().modificar_descuento_linea(id_descuento, descripcion, porcentaje, dtInicio, dtFin, estado);
        }
        public static int eliminar_descuento_linea(int id_descuento)
        {
            return new DDescuentos().eliminar_descuento_linea(id_descuento);
        }
        public static DataTable Obtener_lineas_descuento(string id_descuento)
        {
            return new DDescuentos().Obtener_lineas_descuento(id_descuento);
        } 
        public static bool asignar_linea_descuento(string id_descuento, string id_linea)
        {
            return new DDescuentos().asignar_linea_descuento(id_descuento, id_linea);
        }
        public static int is_existe_linea_descuento(string id_descuento, string id_linea)
        {
            return new DDescuentos().is_existe_linea_descuento(id_descuento, id_linea);
        }
        public static bool quitar_linea_descuento(string id_descuento, string id_linea)
        {
            return new DDescuentos().quitar_linea_descuento(id_descuento, id_linea);
        }
        public static DataTable buscar_combo(string dato, DateTime dInicio, DateTime dFin)
        {
            return new DDescuentos().buscar_combo(dato, dInicio, dFin);
        }
        public static int num_reg_decuento_combo()
        {
            return new DDescuentos().num_reg_decuento_combo();
        }
        public static int modificar_descuento_combo(string id, string Descripcion, decimal Precio_Combo, int Cant_Min, int Cant_Max, DateTime Vence_Desde, DateTime Vence_Hasta, bool estado)
        {
            return new DDescuentos().modificar_descuento_combo(id, Descripcion, Precio_Combo, Cant_Min, Cant_Max, Vence_Desde, Vence_Hasta, estado);
        }
        public static int guardar_descuento_combo(string Descripcion, decimal Precio_Combo, int Cant_Min, int Cant_Max, DateTime Vence_Desde, DateTime Vence_Hasta, string CreateUser)
        {
            return new DDescuentos().guardar_descuento_combo(Descripcion, Precio_Combo, Cant_Min, Cant_Max, Vence_Desde, Vence_Hasta, CreateUser);
        }
        public static void eliminar_prod_combo(string id_combo, string id_prod)
        {
            new DDescuentos().eliminar_prod_combo(id_combo, id_prod);
        }
        public static int eliminar_descuento_combo(string id)
        {
            return new DDescuentos().eliminar_descuento_combo(id);
        }
        public static int agregar_prod_combo(string id_combo, string id_producto)
        {
            return new DDescuentos().agregar_prod_combo(id_combo, id_producto);
        }
        public static DataTable buscar_producto_by_combo(string id_combo)
        {
            return new DDescuentos().buscar_producto_by_combo(id_combo);
        }
        public static int verificar_prod_temp(int id_combo, string id_prod)
        {
            return new DDescuentos().verificar_prod_combo(id_combo, id_prod);
        }
    }
}
