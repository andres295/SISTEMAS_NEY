using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NTipoIdentificacion
    { 
        public static DataTable obtener_datos()
        {
            return new DTipoIdentificacion().Obtener_Tipo_Identificacion();
        }
        public static DataTable Obtener_Tipo_Identificacion_by_id(int id)
        {
            return new DTipoIdentificacion().Obtener_Tipo_Identificacion_by_id(id);
        }
    }
}
