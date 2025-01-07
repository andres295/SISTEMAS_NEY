using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NUsuarios
    {
        public static bool validar_login(int id_user, string pass)
        {
            return new DUsuarios().validar_login(id_user, pass);
        }

        public static DataTable listar()
        {
            return new DUsuarios().listar();
        }

        public static bool modificar(int id, string user, string pass, string tipo, string est,string usuariosql)
        {
            return new DUsuarios().modificar(id, user, pass, tipo, est,usuariosql);
        }

        public static bool guardar(string user, string pass, string tipo, string est,string usuariosql)
        {
            return new DUsuarios().guardar(user, pass, tipo, est, usuariosql);
        }
        public static void create_login_sql(string user, string pass)
        {
             new DUsuarios().create_login_sql(user, pass);
        }
        public static DataTable obtener_datos(int id)
        {
            return new DUsuarios().obtener_datos(id);
        }
        public static DataTable buscarLimitados(string dato, int id_usuario_actual)
        {
            return new DUsuarios().buscarUsuarioLimitado(dato, id_usuario_actual);
        }
        public static void eliminar(int id)
        {
            new DUsuarios().eliminar(id);
        }

        public static DataTable buscar(string dato)
        {
            return new DUsuarios().buscar(dato);
        }

        public static int num_reg()
        {
            return new DUsuarios().num_reg();
        }
        public static int es_administrador( int id_usuario)
        {
            return new DUsuarios().es_administrador(id_usuario);
        }
    }
}
