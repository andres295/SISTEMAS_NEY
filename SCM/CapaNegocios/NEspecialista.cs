using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NEspecialista
    {
        public static DataTable lista_combo()
        {
            return new DEspecialista().lista_combo();
        }
        public static DataTable lista_combo_by_estado(bool estado)
        {
            return new DEspecialista().lista_combo_by_estado(estado);
        }
        public static int verificar_ced(string ced, string cedulaActual = "")
        {
            if (ced != cedulaActual)
            {
                return new DEspecialista().verificar_ced(ced);
            }else { return 0; }
           
        }

        public static bool eliminar(int id)
        {
            return new DEspecialista().eliminar(id);
        }

        public static bool modificar(int id, string ced, string empleado, string genero, DateTime nacim, string prof, string direc, string telef,bool estado)
        {
            return new DEspecialista().modificar(id, ced, empleado, genero, nacim, prof, direc, telef,estado);
        }

        public static DataTable obtener_datos(int id)
        {
            return new DEspecialista().obtener_datos(id);
        }

        public static int guardar(string ced, string empleado, string genero, DateTime nacim, string profes, string direc, string telef)
        {
            return new DEspecialista().guardar(ced, empleado, genero, nacim, profes, direc, telef);
        }

        public static DataTable buscar(string dato)
        {
            return new DEspecialista().buscar(dato);
        }

        public static int num_reg()
        {
            return new DEspecialista().num_reg();
        }
        public static int emp_by_name(string name)
        {
            return new DEspecialista().emp_by_name(name);
        }
    }
}
