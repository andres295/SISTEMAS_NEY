using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NPermiso
    {
        public static DataTable cargar_cmb()
        {
            return new DPermiso().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DPermiso().obtener_datos(id);
        }

        public static bool modificar(int id, string nombre, string ventana)
        {
            return new DPermiso().modificar(id, nombre, ventana);
        }

        public static bool verificar_si_existe(string id)
        {
            return new DPermiso().verificar_si_existe(id);
        }

        public static DataTable buscar(string dato)
        {
            return new DPermiso().buscar(dato);
        }

        public static bool asignar(string id_usuario, string id_permiso, int herencia)
        {
            return new DPermiso().asignar(id_usuario, id_permiso, herencia);
        }
        public static bool quitar(string id_usuario, string id_permiso)
        {
            return new DPermiso().quitar(id_usuario, id_permiso);
        }
        public static DataTable getPermisoByUsuario(string id_Usuario)
        {
            return new DPermiso().getPermisoByUsuario(id_Usuario);
        }
        public static DataTable getPermisoByUsuarioAsignado(string id_Usuario, string id_usuario_herencia, string tipo_usuario, string herencia, string para_heredar)
        {
            return new DPermiso().getPermisoByUsuarioAsignado(id_Usuario, id_usuario_herencia, tipo_usuario, herencia, para_heredar);
        }
    }
}
