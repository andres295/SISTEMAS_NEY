using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NCaja
    {
        public static decimal verificar_si_existe(int id_usuario)
        {
            return new DCaja().verificar_si_existe(id_usuario);
        }
        public static int obtener_id_caja(int id_usuario)
        {
            return new DCaja().obtener_id_caja(id_usuario);
        }
        public static bool abrir_caja(decimal monto, int id_usuario)
        {
            return new DCaja().abrir_caja(monto, id_usuario);
        }
        public static DataTable obtener_egreso_caja(int id_apertura_caja)
        {
            return new DCaja().obtener_egreso_caja(id_apertura_caja);
        }
        public static bool incluir_egreso(int id_usuario,int id_apertura_caja,string descripcion,decimal monto, DateTime fecha)
        {
            return new DCaja().incluir_egreso(id_usuario,id_apertura_caja, descripcion, monto, fecha);
        }
        public static bool update_egreso(int id_egreso, string descripcion, decimal monto)
        {
            return new DCaja().update_egreso(id_egreso, descripcion, monto);
        }
        public static bool update_egreso_By_Fecha(int id_egreso, string descripcion, decimal monto, DateTime fecha)
        {
            return new DCaja().update_egreso_By_Fecha(id_egreso, descripcion, monto, fecha);
        }
        public static bool eliminar_egreso(int id_egreso)
        {
            return new DCaja().eliminar_egreso(id_egreso);
        }
        public static bool cierre_caja(int id_usuario, int Id_Apertura_Caja, decimal MontoApertura, decimal MontoSistema, decimal MontoIngresos, decimal MontoEgresos, decimal MontoTotalCierre, decimal MontoFaltante, int CantidadEfectivoMoneda1, int CantidadEfectivoMoneda2, int CantidadEfectivoMoneda3, int CantidadEfectivoMoneda4, int CantidadEfectivoMoneda5, int CantidadEfectivoMoneda6, int CantidadEfectivoBillete1, int CantidadEfectivoBillete2, int CantidadEfectivoBillete3, int CantidadEfectivoBillete4, int CantidadEfectivoBillete5, int CantidadEfectivoBillete6, int CantidadEfectivoBillete7, decimal MontoTotalEfectivoMoneda, decimal MontoTotalEfectivoBillete, decimal MontoTotalUsuario,decimal sobrante)
        {
            return new DCaja().cierre_caja( id_usuario,  Id_Apertura_Caja,  MontoApertura,  MontoSistema,  MontoIngresos,  MontoEgresos,  MontoTotalCierre,  MontoFaltante,  CantidadEfectivoMoneda1,  CantidadEfectivoMoneda2,  CantidadEfectivoMoneda3,  CantidadEfectivoMoneda4,  CantidadEfectivoMoneda5,  CantidadEfectivoMoneda6,  CantidadEfectivoBillete1,  CantidadEfectivoBillete2,  CantidadEfectivoBillete3,  CantidadEfectivoBillete4,  CantidadEfectivoBillete5,  CantidadEfectivoBillete6,  CantidadEfectivoBillete7,  MontoTotalEfectivoMoneda,  MontoTotalEfectivoBillete,  MontoTotalUsuario, sobrante);
        }
        public static DataTable obtener_cierre_caja(int id_usuario)
        {
            return new DCaja().obtener_cierre_caja(id_usuario);
        }
        public static DataTable obtener_cierre_caja(int id_usuario,DateTime fecha)
        {
            return new DCaja().obtener_cierre_caja(id_usuario, fecha);
        }
        public static Decimal obtener_monto_egresos(int id_apertura_caja,int id_usuario)
        {
            return new DCaja().obtener_monto_egresos(id_apertura_caja, id_usuario);
        }
        public static DataTable VentasMultiPagoByUsuario(DateTime fecha_inicio, DateTime fecha_fin, int id_usuario,int idAperturaCaja,int select)
        {
            return new DCaja().VentasMultiPagoByUsuario(fecha_inicio, fecha_fin, id_usuario, idAperturaCaja, select);
        }
    }
}
