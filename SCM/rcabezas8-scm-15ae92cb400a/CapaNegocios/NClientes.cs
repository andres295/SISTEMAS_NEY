using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NClientes
    {
        public static DataTable lista_combo()
        {
            return new DClientes().lista_combo();
        }
        public static DataTable lista_combo_ciudad()
        {
            return new DClientes().lista_combo_ciudad();
        }
        public static int verificar_ced(string ced, string cedulaActual = "")
        {
            if (ced != cedulaActual)
            {
                return new DClientes().verificar_ced(ced);
            }
            else { return 0; }

        }
        public static int verificar_ruc(string ruc, string rucaActual = "")
        {
            if (ruc != rucaActual)
            {
                return new DClientes().verificar_ruc(ruc);
            }
            else { return 0; }

        }
        public static bool eliminar(int id)
        {
            return new DClientes().eliminar(id);
        }

        public static bool validar_guardar_default(string cliente)
        {
            return new DClientes().validar_guardar_default(cliente);
        }

        public static void guardar_default(string cliente)
        {
            new DClientes().guardar_default(cliente);
        }

        public static bool modificar(int id, string ced, string ruc, string cliente, string telef, string direc, string correo, string ciudad, int tipodocumento)
        {
            return new DClientes().modificar(id, ced, ruc, cliente, telef, direc, correo,  ciudad,  tipodocumento);
        }

        public static DataTable obtener_datos(int id)
        {
            return new DClientes().obtener_datos(id);
        }

        public static DataTable buscar(string dato)
        {
            return new DClientes().buscar(dato);
        }
        public static DataTable buscar_Cat()
        {
            return new DClientes().buscar_Cat();
        }
        public static DataTable Obtener_Cliente_by_cedula(string cedula)
        {
            return new DClientes().Obtener_Cliente_by_cedula(cedula);
        }

        public static int num_reg()
        {
            return new DClientes().num_reg();
        }

        public static bool guardar(string ced, string ruc, string cliente, string telef, string direc, string correo,string ciudad,int tipodocumento)
        {
            return new DClientes().guardar(ced, ruc, cliente, telef, direc, correo,  ciudad,  tipodocumento);
        }
        public static DataTable obtener_id_venta(string id_factura)
        {
            return new DClientes().obtener_id_venta(id_factura);
        }
        public static bool ValidaClienteEnvioSRI(string IdCliente)
        {
            return new DClientes().ValidaClienteEnvioSRI(IdCliente);
        }
    }
}
