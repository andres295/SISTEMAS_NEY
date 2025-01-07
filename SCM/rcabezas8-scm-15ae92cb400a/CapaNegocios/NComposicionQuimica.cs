using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NComposicionQuimica
    {
        public static DataTable cargar_cmb()
        {
            return new DComposicionQuimica().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DComposicionQuimica().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DComposicionQuimica().eliminar(id);
        }

        public static bool modificar(int id, string nombre, string composicion)
        {
            return new DComposicionQuimica().modificar(id, nombre, composicion);
        }

        public static bool verificar_si_existe(string banco)
        {
            return new DComposicionQuimica().verificar_si_existe(banco);
        }

        public static DataTable buscar(string dato)
        {
            return new DComposicionQuimica().buscar(dato);
        }

        public static int num_reg()
        {
            return new DComposicionQuimica().num_reg();
        }

        public static bool guardar(string nombre, string composicion)
        {
            return new DComposicionQuimica().guardar(nombre, composicion);
        }
        public static int valida_nombre(string nombre)
        {
            return new DComposicionQuimica().valida_nombre(nombre);
        }
    }
}
