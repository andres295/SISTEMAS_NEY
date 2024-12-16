using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
   public class NParametros
    {
        public static DataTable cargar_cmb()
        {
            return new DParametros().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DParametros().obtener_datos(id);
        }

        public static bool modificar(int id, string nombre, string telef, string correo, string direc,string ruc,string alias,string ruta_imagen, string ruta_backup,int numItem,string alto_factura,bool automatico, DateTime dtInicio, DateTime dtFin,int stock_producto,int Dia_Vencimiento,string num_ventana, DateTime finicio, DateTime ffin)
        {
            return new DParametros().modificar(id, nombre, telef, correo, direc,ruc,alias,ruta_imagen,  ruta_backup, numItem, alto_factura,automatico,dtInicio,dtFin,stock_producto, Dia_Vencimiento,num_ventana,  finicio,  ffin);
        }

        public static bool verificar_si_existe(string id)
        {
            return new DParametros().verificar_si_existe(id);
        }

        public static DataTable buscar(string dato)
        {
            return new DParametros().buscar(dato);
        }

        public static bool guardar(string nombre, string telef, string correo, string direcc, string ruc, string alias, string ruta_imagen, string ruta_backup, int numItem, string alto_factura,bool automatico, DateTime dtInicio, DateTime dtFin,int stock_producto,int Dia_Vencimiento,string numventana, DateTime finicio, DateTime ffin)
        {
            return new DParametros().guardar(nombre, telef, correo, direcc,ruc,alias,ruta_imagen,  ruta_backup, numItem, alto_factura, automatico, dtInicio, dtFin,stock_producto, Dia_Vencimiento,numventana,  finicio,  ffin);
        }
        public static string getParametro(string parametro)
        {
            return new DParametros().getParametro(parametro);
        }
        public static bool backup_bd(string name_bd,bool automatico)
        {
            return new DParametros().backup_bd(name_bd, automatico);
        }
    }
}
