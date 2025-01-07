using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCatalogo
    {
        public static DataTable cargar_cmb()
        {
            return new DCatalogo().cargar_cmb();
        }
        public static DataTable cargar_cmb_by_tipo(int idTipo)
        {
            return new DCatalogo().cargar_cmb_by_tipo(idTipo);
        }
        public static DataTable cargar_tipo_catalogo()
        {
            return new DCatalogo().cargar_tipo_catalogo();
        }
        public static DataTable lista_combo()
        {
            return new DCatalogo().lista_combo();
        }
        public static DataTable obtener_datos(int id)
        {
            return new DCatalogo().obtener_datos(id);
        }
        public static DataTable obtener_datos_by_tipe(int id)
        {
            return new DCatalogo().obtener_datos_by_tipe(id);
        }
        public static bool eliminar(int id)
        {
            return new DCatalogo().eliminar(id);
        }

        public static bool modificar(int id, string descripcion, int idTipoCatalogo, bool estado, string codigo)
        {
            return new DCatalogo().modificar(id, descripcion, idTipoCatalogo, estado, codigo);
        }

        public static bool verificar_si_existe(string descripcion)
        {
            return new DCatalogo().verificar_si_existe(descripcion);
        }
        public static bool verificar_si_existe_tipo_catalogo(string descripcion)
        {
            return new DCatalogo().verificar_si_existe_tipo_catalogo(descripcion);
        }
        public static DataTable buscar(string dato)
        {
            return new DCatalogo().buscar(dato);
        }

        public static int num_reg()
        {
            return new DCatalogo().num_reg();
        }

        public static bool guardar(string tipo, int idtipocatalogo, string codigo)
        {
            return new DCatalogo().guardar(tipo, idtipocatalogo, codigo);
        }
    }
}
