using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NModulo
    {
        public static DataTable cargar_cmb()
        {
            return new DModulo().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DModulo().obtener_datos(id);
        }

        public static bool eliminar(int id)
        {
            return new DModulo().eliminar(id);
        }

        public static bool modificar(int id, string num_ventana, string ventana,bool estado)
        {
            return new DModulo().modificar(id, num_ventana, ventana,estado);
        }

        public static bool verificar_si_existe(string modulo)
        {
            return new DModulo().verificar_si_existe(modulo);
        }

        public static DataTable buscar(string dato)
        {
            return new DModulo().buscar(dato);
        }

        public static int num_reg()
        {
            return new DModulo().num_reg();
        }

        public static bool guardar(string num_ventana, string ventana)
        {
            return new DModulo().guardar(num_ventana, ventana);
        }
    }
}
