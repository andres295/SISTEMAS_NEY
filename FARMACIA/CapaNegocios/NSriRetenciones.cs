using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NSriRetenciones
    {
        public static DataTable Cargar_PorcentajeIva(int ID)
        {
            return new DSriRetenciones().Cargar_PorcentajeIva(ID);
        }
        public static DataTable Cargar_PorcentajeRENTA(int ID)
        {
            return new DSriRetenciones().Cargar_PorcentajeRenta(ID);
        }
        public static int Agregar_det_tmp_retencion(string impuestoRetener, int idValorImpuesto, decimal porcRetencion, decimal baseimponible, decimal valorretenido, int idUsuario)
        {
            return new DSriRetenciones().Agregar_det_tmp_retencion(impuestoRetener,idValorImpuesto,porcRetencion,baseimponible,valorretenido, idUsuario);
        }
        public static bool UpdateClaveAccesoRetencion(int id, string claveAcceso)
        {
            return new DSriRetenciones().UpdateClaveAccesoRetencion(id, claveAcceso);
        }
        public static bool DeleteRetencion(int id)
        {
            return new DSriRetenciones().DeleteRetencion(id);
        }
        public static DataTable Obtener_Det_TMP_Retenciones(int idUsuario)
        {
            return new DSriRetenciones().Obtener_Det_TMP_Retenciones(idUsuario);
        }
        public static DataTable Obtener_Det_Retenciones(int idRetencion)
        {
            return new DSriRetenciones().Obtener_Det_Retenciones(idRetencion);
        } 
        public static bool Delete_Det_TMP_Retenciones(int idUsuario)
        {
            return new DSriRetenciones().Delete_Det_TMP_Retenciones(idUsuario);
        }
        public static bool Delete_Det_TMP_Retenciones_by_id(int id)
        {
            return new DSriRetenciones().Delete_Det_TMP_Retenciones_by_id(id);
        }
        public static DataTable Agregar_Retencion(DateTime Fecha, int IdProveedor, DateTime FechaEmision, string TipoDocumento, string NumDocumento, DateTime PeriodoFiscal, int IdUsuarioRegistro)
        {
            return new DSriRetenciones().Agregar_Retencion(Fecha,IdProveedor, FechaEmision, TipoDocumento,NumDocumento,PeriodoFiscal,IdUsuarioRegistro);
        }
    }
}
