using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
   public class NComprobantesSRI
    {
        public static DataTable cargar_cmb()
        {
            return new DComprobantesSRI().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DComprobantesSRI().obtener_datos(id);
        }

        public static bool modificar(string ClaveAcceso, string FechaEmision, string FechaAutorizacion, string FechaDevolucion, string FechaRechazo, string UsuarioEnviaSRI, string EstadoEnvioSRI, string MensajeRecepcionSRI)
        {
            return new DComprobantesSRI().modificar( ClaveAcceso,  FechaEmision,  FechaAutorizacion,  FechaDevolucion,  FechaRechazo,  UsuarioEnviaSRI,  EstadoEnvioSRI,  MensajeRecepcionSRI);
        }

        public static bool verificar_si_existe(string id)
        {
            return new DComprobantesSRI().verificar_si_existe(id);
        }

        public static DataTable buscar()
        {
            return new DComprobantesSRI().buscar();
        }
        public static DataTable buscar_comprobantes_no_enviados_a_sri(string dato, DateTime finicio, DateTime ffin)
        {
            return new DComprobantesSRI().buscar_comprobantes_no_enviados_a_sri(dato, finicio,ffin);
        }
        public static DataTable buscar_comprobantes_enviados_a_sri(string dato, DateTime finicio, DateTime ffin)
        {
            return new DComprobantesSRI().buscar_comprobantes_enviados_a_sri(dato, finicio, ffin);
        }
        public static DataTable buscar_comprobantes_retencion_enviados_a_sri( DateTime finicio, DateTime ffin)
        {
            return new DComprobantesSRI().buscar_comprobantes_retencion_enviados_a_sri( finicio, ffin);
        }
        public static bool guardar(string ClaveAcceso, string TipoDocumento, string NumeroComprobante, string FechaDocumento, string FechaEmision, DateTime FechaAutorizacion, string FechaDevolucion, string FechaRechazo, string UsuarioEnviaSRI, string UsuarioGeneraDocumento, string EstadoEnvioSRI, string IdGestor, string TotalSinImpuestos, string ImporteTotal, string MensajeRecepcionSRI, string numFactura, string ambiente, string tipoEmision)
        {
            return new DComprobantesSRI().guardar( ClaveAcceso,  TipoDocumento,  NumeroComprobante,  FechaDocumento,  FechaEmision,  FechaAutorizacion,  FechaDevolucion,  FechaRechazo,  UsuarioEnviaSRI,  UsuarioGeneraDocumento,  EstadoEnvioSRI,  IdGestor,  TotalSinImpuestos,  ImporteTotal,  MensajeRecepcionSRI,  numFactura,  ambiente,  tipoEmision);
        }
        public static string getParametro(string parametro)
        {
            return new DComprobantesSRI().getParametro(parametro);
        }
        public static bool backup_bd(string name_bd,bool automatico)
        {
            return new DComprobantesSRI().backup_bd(name_bd, automatico);
        }
    }
}
