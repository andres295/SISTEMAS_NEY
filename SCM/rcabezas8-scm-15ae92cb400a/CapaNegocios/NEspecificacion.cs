using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NEspecificacion
    {
        public static DataTable lista_combo()
        {
            return new DEspecificacion().lista_combo();
        }

        public static int num_reg()
        {
            return new DEspecificacion().num_reg();
        }
        public static int validar_relacion(int id)
        {
            return new DEspecificacion().validar_relacion(id);
        }
        public static int buscar_by_id(String id)
        {
            return new DEspecificacion().buscar_by_id(id);
        }
        public static DataTable buscar(string dato)
        {
            return new DEspecificacion().buscar(dato);
        }

        public static bool eliminar(int id)
        {
            return new DEspecificacion().eliminar(id);
        }

        public static int verificar_si_existe(string especif)
        {
            return new DEspecificacion().verificar_si_existe(especif);
        }

        public static bool modificar(int id, string especif)
        {
            return new DEspecificacion().modificar(id, especif);
        }

        public static bool guardar(string especif)
        {
            return new DEspecificacion().guardar(especif);
        }
    }
}
