using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NOrdenServicio
    {
        public static DataTable lista_combo(string tipo)
        {
            return new DOrdenServicio().lista_combo(tipo);
        }
        public static DataTable lista_combo_by_moneda(string tipo,string moneda)
        {
            return new DOrdenServicio().lista_combo_by_moneda(tipo,moneda);
        }
        public static DataTable lista_combo_by_name(string tipo, string name)
        {
            return new DOrdenServicio().lista_combo_by_name(tipo, name);
        }
        public static DataTable cargar_cmb()
        {
            return new DOrdenServicio().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DOrdenServicio().obtener_datos(id);
        }
        
        public static bool eliminar(int id)
        {
            return new DOrdenServicio().eliminar(id);
        }

        public static bool modificar(int id, string id_cliente,string id_doctor, string observacion,bool atendida,bool facturada,bool activa,string moneda)
        {
            return new DOrdenServicio().modificar(id, id_cliente, id_doctor, observacion,atendida,facturada,activa,moneda);
        }

        public static bool verificar_si_existe(string servicio)
        {
            return new DOrdenServicio().verificar_si_existe(servicio);
        }

        public static DataTable buscar(string dato,DateTime dtInicio,DateTime dtFin)
        {
            return new DOrdenServicio().buscar(dato,dtInicio,dtFin);
        }
        public static DataTable buscar_by_cliente(string dato)
        {
            return new DOrdenServicio().buscar_by_cliente(dato);
        }
        public static int num_reg()
        {
            return new DOrdenServicio().num_reg();
        }

        public static bool guardar(string maquina, string id_cliente, string id_usuario,string id_doctor, string observacion,string moneda)
        {
            return new DOrdenServicio().guardar(maquina,id_cliente,id_usuario,id_doctor,observacion,moneda);
        }
        public static bool guardar_servicio_tem(string maquina, string id_cliente, string id_usuario, string id_doctor, string observacion,string moneda)
        {
            return new DOrdenServicio().guardar(maquina, id_cliente, id_usuario, id_doctor, observacion,moneda);
        }
        public static DataTable Obtener_servicio_tem(string id_orden, string maquina )
        {
            return new DOrdenServicio().Obtener_servicio_tem(id_orden,maquina);
        }
        public static bool quitar_servicio_tem(string id_orden, string id_servicio, string id_usuario)
        {
            return new DOrdenServicio().quitar_servicio_tem(id_orden, id_servicio, id_usuario);
        }
        public static bool quitar_todo_servicio_tem(string id_orden, string id_usuario)
        {
            return new DOrdenServicio().quitar_todo_servicio_tem(id_orden, id_usuario);
        }
        public static bool guardar_servicio_tem(string id_orden, string id_servicio, string id_usuario)
        {
            return new DOrdenServicio().guardar_servicio_tem(id_orden, id_servicio, id_usuario);
        }
    }
}
