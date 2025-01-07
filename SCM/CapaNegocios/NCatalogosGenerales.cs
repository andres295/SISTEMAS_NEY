using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCatalogosGenerales
    {
        public static DataTable cargar_cmb(int tipoCatalogo)
        {
            return new DCatalogosGenerales().cargar_cmb(tipoCatalogo);
        }
        public static DataTable cargar_cmb_by_id(int id)
        {
            return new DCatalogosGenerales().cargar_cmb_by_id(id);
        }
        public static bool eliminar(int id)
        {
            return new DCatalogosGenerales().eliminar(id);
        }

        public static bool modificar(int id, string descripcion, decimal porcretencion, string codanexo, bool estado)
        {
            return new DCatalogosGenerales().modificar( id,  descripcion,  porcretencion,  codanexo,  estado);
        }

        public static bool verificar_si_existe(string id)
        {
            return new DCatalogosGenerales().verificar_si_existe(id);
        }

        public static DataTable buscar(int tipocatalogo, string Descripcion)
        {
            return new DCatalogosGenerales().buscar(tipocatalogo,Descripcion);
        }

        public static int num_reg( int tipocatalogo)
        {
            return new DCatalogosGenerales().num_reg(tipocatalogo);
        }

        public static bool guardar(int tipocatalogo, string descripcion, decimal porcretencion, string codanexo)
        {
            return new DCatalogosGenerales().guardar( tipocatalogo,  descripcion,  porcretencion,  codanexo);
        }
    }
}
