using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
   public class NAjusteTecla
    {
        public static DataTable cargar_cmb()
        {
            return new DAjusteTecla().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DAjusteTecla().obtener_datos(id);
        }

        public static bool modificar(int id_usuario, string f1, string f2, string f3, string f4, string f5, string f6, string f7, string f8, string f9, string f10, string f11, string f12)
        {
            return new DAjusteTecla().modificar( id_usuario,  f1,  f2,  f3,  f4,  f5,  f6,  f7,  f8,  f9,  f10,  f11,  f12);
        }

        public static bool verificar_si_existe(int id)
        {
            return new DAjusteTecla().verificar_si_existe(id);
        }

        public static DataTable buscar(int id_usuario)
        {
            return new DAjusteTecla().buscar(id_usuario);
        }

        public static bool guardar(int id_usuario, string f1, string f2, string f3, string f4, string f5, string f6, string f7, string f8, string f9, string f10, string f11, string f12)
        {
            return new DAjusteTecla().guardar(id_usuario, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12);
        } 
    }
}
