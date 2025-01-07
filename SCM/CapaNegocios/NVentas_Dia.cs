using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NVentas_Dia
    {
        public static int tamaño(DateTime desde, DateTime hasta, int registro_por_pagina)
        {
            return new DVentas_Dia().tamaño(desde, hasta, registro_por_pagina);
        }
        public static DataTable Buscar_Ventas_Dia(DateTime desde, DateTime hasta, int registro_por_pagina)
        {
            return new DVentas_Dia().Buscar_Ventas_Dia(desde, hasta, registro_por_pagina);
        }
    }
}
