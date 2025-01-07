using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NEspecialidad
    {
        public static DataTable cargar_cmb()
        {
            return new DEspecialidad().cargar_cmb();
        }
        public static DataTable lista_combo()
        {
            return new DEspecialidad().lista_combo();
        }
        public static DataTable obtener_datos(int id)
        {
            return new DEspecialidad().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DEspecialidad().eliminar(id);
        }

        public static bool modificar(int id, string tipo, bool estado)
        {
            return new DEspecialidad().modificar(id, tipo, estado);
        }

        public static bool verificar_si_existe(string banco)
        {
            return new DEspecialidad().verificar_si_existe(banco);
        }

        public static DataTable buscar(string dato)
        {
            return new DEspecialidad().buscar(dato);
        }

        public static int num_reg()
        {
            return new DEspecialidad().num_reg();
        }

        public static bool guardar(string tipo)
        {
            return new DEspecialidad().guardar(tipo);
        }
        public static DataTable obtener_especialidad_by_medico(string id, string filtro)
        {
            return new DEspecialidad().obtener_especialidad_by_medico(id, filtro);
        }
        public static string obtener_especialidad_by_medico_by_id(string id, bool tipo)
        {
            return new DEspecialidad().obtener_especialidad_by_medico_by_id(id, tipo);
        }
        public static bool asignar_composicion(string id_medico, string id_especialidad,string accion)
        {
            return new DEspecialidad().asignar_quitar_especialidad_medico(id_medico, id_especialidad, accion);
        }
    }
}
