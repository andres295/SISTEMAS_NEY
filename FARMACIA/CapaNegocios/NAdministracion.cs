using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NAdministracion
    {
        /*****************************CATALOGOS GASTOS*********************************************/
        public static DataTable Cargar_Cat_Gastos()
        {
            return new DAdministracion().Cargar_Cat_Gastos();
        }
        public static DataTable Lista_Cat_Gastos()
        {
            return new DAdministracion().Lista_Cat_Gastos();
        }
        public static bool Agregar_Cat_Gastos(string descripcion, string usuario)
        {
            return new DAdministracion().Agregar_Cat_Gastos(descripcion, usuario);
        }
        public static bool Actualizar_Cat_Gastos(string id_cat_gasto, string descripcion)
        {
            return new DAdministracion().Actualizar_Cat_Gastos( id_cat_gasto,  descripcion);
        }
        public static bool Eliminar_Activar_Cat_Gastos(string id_cat_gasto,bool estado)
        {
            return new DAdministracion().Eliminar_Activar_Cat_Gastos(id_cat_gasto, estado);
        }
        public static int buscar_tipo_gasto(string id)
        {
            return new DAdministracion().buscar_tipo_gasto(id);
        }

        /*****************************REGISTROS GASTOS*********************************************/

        public static DataTable Cargar_Registro_Gastos()
        {
            return new DAdministracion().Cargar_Registro_Gastos();
        }
        public static bool Agregar_Registro_Gastos(int Id_Gasto, decimal monto, DateTime dtFecha, string id_usuario)
        {
            return new DAdministracion().Agregar_Registro_Gastos( Id_Gasto,  monto,  dtFecha,  id_usuario);
        }
        public static bool Eliminar_Cat_Gastos(string id_cat_gasto, bool estado,string usuario_elimina)
        {
            return new DAdministracion().Eliminar_Registro_Gastos(id_cat_gasto, estado, usuario_elimina);
        }

        /********************************REPORTES DE GASTOS*******************************************/
        public static DataTable cargar_historico_gastos(DateTime dtInico, DateTime dtFin,int tipo)
        {
            return new DAdministracion().cargar_historico_gastos(dtInico, dtFin, tipo);
        }

    }
}
