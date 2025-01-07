using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NServicio
    {
        public static DataTable lista_combo(string tipo)
        {
            return new DServicio().lista_combo(tipo);
        }
        public static DataTable lista_combo_2()
        {
            return new DServicio().lista_combo_2();
        }
        public static int servicio_by_name(string name)
        {
            return new DServicio().servicio_by_name(name);
        }
        public static DataTable lista_tiempo_servicio(string id_servicio)
        {
            return new DServicio().lista_tiempo_servicio(id_servicio);
        }
        public static DataTable cargar_cmb()
        {
            return new DServicio().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DServicio().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DServicio().eliminar(id);
        }

        public static bool modificar(int id, string servicio, decimal costo, bool estado, string descripcion,string tiempo_ejecucion)
        {
            return new DServicio().modificar(id, servicio, costo, estado, descripcion,tiempo_ejecucion);
        }

        public static bool verificar_si_existe(string servicio)
        {
            return new DServicio().verificar_si_existe(servicio);
        }

        public static DataTable buscar(string dato)
        {
            return new DServicio().buscar(dato);
        }
        public static DataTable buscar_by_estado(string dato,bool estado)
        {
            return new DServicio().buscar_by_estado(dato, estado);
        }
        public static int num_reg()
        {
            return new DServicio().num_reg();
        }

        public static bool guardar(string servicio, decimal costo, string descripcion,string tiempo_ejecucion)
        {
            return new DServicio().guardar(servicio, costo, descripcion, tiempo_ejecucion);
        }
    }
}
