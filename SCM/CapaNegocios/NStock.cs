using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NStock
    {
        public static DataTable cmb()
        {
            return new DStock().cmb();
        }

        public static DataTable obtener_datos()
        {
            return new DStock().obtener_datos();
        }
    }
}
