using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NCita
    {
        public static DataTable lista_combo()
        {
            return new DCita().lista_combo();
        }
        public static int buscar_by_id(String id)
        {
            return new DCita().buscar_by_id(id);
        }
        public static DataTable buscar_by_paciente(String id_paciente)
        {
            return new DCita().buscar_by_paciente(id_paciente);
        }
        public static bool eliminar(string id)
        {
            return new DCita().eliminar(id);
        }

        public static bool modificar(string id,string id_doctor,string id_servicio, string observacion, DateTime fecha, DateTime hora, DateTime hora_fin,bool atendida)
        {
            return new DCita().modificar( id, id_doctor, id_servicio,  observacion,  fecha,  hora,hora_fin,atendida);
        }
        public static bool modificar_cita_atendida(string id, bool atendida)
        {
            return new DCita().modificar_cita_atendida(id, atendida);
        }
        public static DataTable obtener_datos(int id)
        {
            return new DCita().obtener_datos(id);
        }
        public static int guardar(string id_cliente,string id_doctor,string id_servicio, DateTime fecha, DateTime hora, DateTime hora_fin, string observacion,bool atendida)
        {
            return new DCita().guardar( id_cliente, id_doctor, id_servicio, fecha,  hora,hora_fin,  observacion, atendida);
        }
        public static DataTable valida_cita(DateTime fechan, DateTime hora_inicio, DateTime hora_fin,string id_doctor)
        {
            return new DCita().valida_cita( fechan,  hora_inicio,  hora_fin,id_doctor);
        }
        public static int num_reg()
        {
            return new DCita().num_reg();
        }

        public static DataTable buscar(string dato)
        {
            return new DCita().buscar(dato);
        }
    }
}
