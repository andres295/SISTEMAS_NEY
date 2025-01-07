using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NPresentaciones
    {
        public static DataTable lista_combo()
        {
            return new DPresentaciones().lista_combo();
        }

        public static DataTable cargar()
        {
            return new DPresentaciones().cargar();
        }
        public static int buscar(String id)
        {
            return new DPresentaciones().buscar(id);
        }
        public static int num_reg()
        {
            return new DPresentaciones().num_reg();
        }
        public static int validar_relacion(int id)
        {
            return new DPresentaciones().validar_relacion(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DPresentaciones().eliminar(id);
        }

        public static int verificar_si_existe(string present)
        {
            return new DPresentaciones().verificar_si_existe(present);
        }

        public static bool modificar(int id, string present)
        {
            return new DPresentaciones().modificar(id, present);
        }

        public static bool guardar(string present)
        {
            return new DPresentaciones().guardar(present);
        }
    }
}
