using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NTipoPago
    {
        public static DataTable cargar_cmb(bool permiso_credito)
        {
            return new DTipoPago().cargar_cmb(permiso_credito);
        }
        public static DataTable cargar_cmb_by_efectivo(bool permiso_credito)
        {
            return new DTipoPago().cargar_cmb_by_efectivo(permiso_credito);
        }
        public static DataTable lista_combo()
        {
            return new DTipoPago().lista_combo();
        }
        public static DataTable obtener_datos(int id)
        {
            return new DTipoPago().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DTipoPago().eliminar(id);
        }

        public static bool modificar(int id, string tipo,string codSRI, bool estado)
        {
            return new DTipoPago().modificar(id, tipo, codSRI, estado);
        }

        public static bool verificar_si_existe(string banco)
        {
            return new DTipoPago().verificar_si_existe(banco);
        }

        public static DataTable buscar(string dato)
        {
            return new DTipoPago().buscar(dato);
        }
        public static DataTable buscarSinCredito(string dato)
        {
            return new DTipoPago().buscarSinCredito(dato);
        }
        public static int num_reg()
        {
            return new DTipoPago().num_reg();
        }

        public static bool guardar(string tipo,string codSRI)
        {
            return new DTipoPago().guardar(tipo, codSRI);
        }
    }
}
