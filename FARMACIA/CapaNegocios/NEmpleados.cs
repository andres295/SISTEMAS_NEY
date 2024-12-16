using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NEmpleados
    {
        public static int verificar_ced(string ced, string cedulaActual = "")
        {
            if (ced != cedulaActual)
            {
                return new DEmpleados().verificar_ced(ced);
            }else { return 0; }
           
        }

        public static bool eliminar(int id)
        {
            return new DEmpleados().eliminar(id);
        }

        public static bool modificar(int id, string ced, string empleado, string genero, DateTime nacim, string prof, string direc, string telef)
        {
            return new DEmpleados().modificar(id, ced, empleado, genero, nacim, prof, direc, telef);
        }

        public static DataTable obtener_datos(int id)
        {
            return new DEmpleados().obtener_datos(id);
        }

        public static bool guardar(string ced, string empleado, string genero, DateTime nacim, string profes, string direc, string telef)
        {
            return new DEmpleados().guardar(ced, empleado, genero, nacim, profes, direc, telef);
        }

        public static DataTable buscar(string dato)
        {
            return new DEmpleados().buscar(dato);
        }

        public static int num_reg()
        {
            return new DEmpleados().num_reg();
        }
    }
}
