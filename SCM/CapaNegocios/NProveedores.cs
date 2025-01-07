using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NProveedores
    {
        public static DataTable lista_combo()
        {
            return new DProveedores().lista_combo();
        }
        public static int buscar_by_id(String id)
        {
            return new DProveedores().buscar_by_id(id);
        }
        public static bool eliminar(int id)
        {
            return new DProveedores().eliminar(id);
        }

        public static bool modificar(int id, string prov, string matr, string dir, string telef, string ruc, string geren, string autor, string datos, int TipoIdentifiacion , string Correo  , string NombreComercial , string Tipocontribuyente , string AgenteRetencion  )
        {
            return new DProveedores().modificar(id, prov, matr, dir, telef, ruc, geren, autor, datos,  TipoIdentifiacion,  Correo,  NombreComercial,  Tipocontribuyente,  AgenteRetencion);
        }

        public static DataTable obtener_datos(int id)
        {
            return new DProveedores().obtener_datos(id);
        }
        public static DataTable obtener_id_factura(string id_factura)
        {
            return new DProveedores().obtener_id_factura(id_factura);
        }
        public static bool guardar(string prov, string matr, string direc, string telef, string ruc, string geren, string autoriz, string datos, int TipoIdentifiacion, string Correo, string NombreComercial, string Tipocontribuyente, string AgenteRetencion)
        {
            return new DProveedores().guardar(prov, matr, direc, telef, ruc, geren, autoriz, datos,  TipoIdentifiacion,  Correo,  NombreComercial,  Tipocontribuyente,  AgenteRetencion);
        }

        public static int num_reg()
        {
            return new DProveedores().num_reg();
        }
        public static int validar_relacion(int id)
        {
            return new DProveedores().validar_relacion( id);
        }
        public static DataTable buscar(string dato)
        {
            return new DProveedores().buscar(dato);
        }
    }
}
