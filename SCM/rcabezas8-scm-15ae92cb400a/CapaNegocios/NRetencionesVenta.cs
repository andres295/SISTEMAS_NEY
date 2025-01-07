using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NRetencionesVenta
    {
        public static DataTable Cargar_PorcentajeIva(int ID)
        {
            return new DRetencionesVenta().Cargar_PorcentajeIva(ID);
        }
        public static DataTable Cargar_PorcentajeRENTA(int ID)
        {
            return new DRetencionesVenta().Cargar_PorcentajeRenta(ID);
        }
        public static int Agregar_det_tmp_retencion(string impuestoRetener, int idValorImpuesto, decimal porcRetencion, decimal baseimponible, decimal valorretenido, int idUsuario)
        {
            return new DRetencionesVenta().Agregar_det_tmp_retencion(impuestoRetener,idValorImpuesto,porcRetencion,baseimponible,valorretenido, idUsuario);
        }
        public static bool UpdateClaveAccesoRetencion(int id, string claveAcceso)
        {
            return new DRetencionesVenta().UpdateClaveAccesoRetencion(id, claveAcceso);
        }
        public static bool DeleteRetencion(int id)
        {
            return new DRetencionesVenta().DeleteRetencion(id);
        }
        public static DataTable Obtener_Det_TMP_Retenciones(int idUsuario)
        {
            return new DRetencionesVenta().Obtener_Det_TMP_Retenciones(idUsuario);
        }
        public static DataTable Obtener_Det_Retenciones(int idRetencion)
        {
            return new DRetencionesVenta().Obtener_Det_Retenciones(idRetencion);
        } 
        public static bool Delete_Det_TMP_Retenciones(int idUsuario)
        {
            return new DRetencionesVenta().Delete_Det_TMP_Retenciones(idUsuario);
        }
        public static bool Delete_Det_TMP_Retenciones_by_id(int id)
        {
            return new DRetencionesVenta().Delete_Det_TMP_Retenciones_by_id(id);
        }
        public static DataTable Agregar_Retencion(DateTime Fecha, int IdCliente, DateTime FechaEmision, string TipoDocumento, string NumDocumento, DateTime PeriodoFiscal, int IdUsuarioRegistro)
        {
            return new DRetencionesVenta().Agregar_Retencion(Fecha, IdCliente, FechaEmision, TipoDocumento,NumDocumento,PeriodoFiscal,IdUsuarioRegistro);
        }
    }
}
