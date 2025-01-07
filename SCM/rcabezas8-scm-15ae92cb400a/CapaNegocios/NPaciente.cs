using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NPaciente
    {
        public static DataTable lista_combo()
        {
            return new DPaciente().lista_combo();
        }
        public static int verificar_ced(string ced, string cedulaActual = "")
        {
            if (ced != cedulaActual)
            {
                return new DPaciente().verificar_ced(ced);
            }
            else { return 0; }

        }
        public static int verificar_ruc(string ruc, string rucaActual = "")
        {
            if (ruc != rucaActual)
            {
                return new DPaciente().verificar_ruc(ruc);
            }
            else { return 0; }

        }
        public static bool eliminar(int id)
        {
            return new DPaciente().eliminar(id);
        }

        public static bool validar_guardar_default(string cliente)
        {
            return new DPaciente().validar_guardar_default(cliente);
        }

        public static void guardar_default(string cliente)
        {
            new DPaciente().guardar_default(cliente);
        }

        public static bool modificar(int id, string ced, string ruc, string cliente, string genero, DateTime nacim,string edad, string telef, string direc, string correo,string padre, int tiposangre, int estadocivl, int nacionalidad,string convencional, int instruccion)
        {
            return new DPaciente().modificar(id, ced, ruc, cliente,genero,nacim,edad, telef, direc, correo,padre,  tiposangre,  estadocivl,  nacionalidad,convencional, instruccion);
        }

        public static DataTable obtener_datos(int id)
        {
            return new DPaciente().obtener_datos(id);
        }

        public static DataTable buscar(string dato)
        {
            return new DPaciente().buscar(dato);
        }
        public static DataTable citas_por_vencer()
        {
            return new DPaciente().citas_por_vencer();
        }
        public static DataTable citas_paciente()
        {
            return new DPaciente().citas_paciente();
        }
        public static DataTable citas_by_paciente( string idcliente, DateTime dinicio, DateTime dfin)
        {
            return new DPaciente().citas_by_paciente(idcliente, dinicio, dfin);
        }
        public static DataTable examenes_generales_by_paciente(string idcliente, DateTime dinicio, DateTime dfin)
        {
            return new DPaciente().examenes_generales_by_paciente(idcliente, dinicio, dfin);
        }
        public static DataTable examenes_generales_by_especialista(string idEspecialista, DateTime dinicio, DateTime dfin,decimal porc_comision)
        {
            return new DPaciente().examenes_generales_by_especialista(idEspecialista, dinicio, dfin, porc_comision);
        }
        public static DataTable examenes_generales_by_especialista_grafico(string idEspecialista, DateTime dinicio, DateTime dfin, decimal porc_comision)
        {
            return new DPaciente().examenes_generales_by_especialista_grafico(idEspecialista, dinicio, dfin, porc_comision);
        }
        public static DataTable Obtener_Cliente_by_cedula(string cedula)
        {
            return new DPaciente().Obtener_Cliente_by_cedula(cedula);
        }

        public static int num_reg()
        {
            return new DPaciente().num_reg();
        }

        public static bool guardar(string ced, string ruc, string cliente, string genero, DateTime nacim,string edad ,string telef, string direc, string correo,string padre, int tiposangre, int estadocivl, int nacionalidad,string convencional, int instruccion,string foto)
        {
            return new DPaciente().guardar(ced, ruc, cliente,genero,nacim,edad, telef, direc, correo,padre, tiposangre, estadocivl, nacionalidad,convencional, instruccion,foto);
        }
        public static int paciente_by_name(string name)
        {
            return new DPaciente().paciente_by_name(name);
        }
        public static int paciente_by_cedula(string cedula)
        {
            return new DPaciente().paciente_by_cedula(cedula);
        }
        public static String get_genero_paciente(string idPaciente)
        {
            return new DPaciente().get_genero_paciente(idPaciente);
        }
        public static void actualizar_foto(string id, string foto)
        {
            new DPaciente().actualizar_foto(id, foto);
        }
        public static string obtener_img_prod(string id)
        {
            return new DPaciente().obtener_img_prod(id);
        }
    }
}
