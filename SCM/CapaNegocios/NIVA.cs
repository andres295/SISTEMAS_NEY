using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NIVA
    {
        public static void aplicar_quitar_general(string iva)
        {
            new DIVA().aplicar_quitar_general(iva);
        }

        public static void aplicar_quitar_todos(int id_prov, string iva)
        {
            new DIVA().aplicar_quitar_todos(id_prov, iva);
        }
        public static void aplicar_quitar_pvp_todos(int id_prov, bool aplicar)
        {
            new DIVA().aplicar_quitar_pvp_todos(id_prov, aplicar);
        }
        public static void aplicar_quitar_sel(string id, string iva)
        {
            new DIVA().aplicar_quitar_sel(id, iva);
        }
        public static void aplicar_quitar_pvp_sel(string id, bool aplicar)
        {
            new DIVA().aplicar_quitar_pvp_sel(id, aplicar);
        }

        public static DataTable buscar_prod(int id_prov,string datos)
        {
            return new DIVA().buscar_prod(id_prov,datos);
        }

        public static decimal obtener_iva()
        {
            return new DIVA().obtener_iva();
        }
        public static string obtener_iva_cod_sri()
        {
            return new DIVA().obtener_iva_cod_sri();
        }
        public static bool guardar(string monto, string codigoseri, string codporcsri)
        {
            return new DIVA().guardar(monto, codigoseri, codporcsri);
        }
        public static string obtener_iva_porc_sri()
        {
            return new DIVA().obtener_iva_porc_sri();
        }
    }
}
