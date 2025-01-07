using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NBancos
    {
        public static DataTable cargar_cmb()
        {
            return new DBancos().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DBancos().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DBancos().eliminar(id);
        }

        public static bool modificar(int id, string banco, string telef, string correo, string direc)
        {
            return new DBancos().modificar(id, banco, telef, correo, direc);
        }

        public static bool verificar_si_existe(string banco)
        {
            return new DBancos().verificar_si_existe(banco);
        }

        public static DataTable buscar(string dato)
        {
            return new DBancos().buscar(dato);
        }

        public static int num_reg()
        {
            return new DBancos().num_reg();
        }

        public static bool guardar(string banco, string telef, string correo, string direcc)
        {
            return new DBancos().guardar(banco, telef, correo, direcc);
        }
    }
}
