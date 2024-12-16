using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
   public class NParametrosSRI
    {
        public static DataTable cargar_cmb()
        {
            return new DParametrosSRI().cargar_cmb();
        }

        public static DataTable obtener_datos(int id)
        {
            return new DParametrosSRI().obtener_datos(id);
        }

        public static bool modificar(int id, bool ServicioSRActivo, string Ambiente, string TipoEmision, string TipoDocumentoFactura, string RazonSocial, string NombreComercial, string Codestablecimiento, string Codpuntoemision, string DirMatri, string DirEstablecimiento, string ObligadoContabilidad, string CodigoNumerico, string Moneda,DateTime licenciadesde, DateTime licenciahasta,string regimen,string correoSMTP,string passwordSMTP,string rutaxml,string impresora,string urlSRI, string TipoDocumentoRetencion,bool EsAgenteRetencion, string CodigoAgenteRetencion, string NumContribuyente, decimal montominimo,string codDocSustento)
        {
            return new DParametrosSRI().modificar(id, ServicioSRActivo, Ambiente, TipoEmision, TipoDocumentoFactura, RazonSocial, NombreComercial, Codestablecimiento, Codpuntoemision, DirMatri, DirEstablecimiento, ObligadoContabilidad, CodigoNumerico, Moneda,licenciadesde,licenciahasta, regimen, correoSMTP,passwordSMTP,rutaxml,impresora, urlSRI,TipoDocumentoRetencion,EsAgenteRetencion,CodigoAgenteRetencion,NumContribuyente, montominimo, codDocSustento);
        }

        public static bool verificar_si_existe(string id)
        {
            return new DParametrosSRI().verificar_si_existe(id);
        }

        public static DataTable buscar()
        {
            return new DParametrosSRI().buscar();
        } 
        public static bool guardar(bool ServicioSRActivo, string Ambiente, string TipoEmision, string TipoDocumentoFactura, string RazonSocial, string NombreComercial, string Codestablecimiento, string Codpuntoemision, string DirMatri, string DirEstablecimiento, string ObligadoContabilidad, string CodigoNumerico, string Moneda,DateTime licenciadesde,DateTime licenciahasta,string regimen,string correoSMTP,string passwordSMTP, string rutaxml,string impresora,string urlSRI,string TipoDocumentoRetencion, bool EsAgenteRetencion, string CodigoAgenteRetencion, string NumContribuyente, decimal montominimo,string  codDocSustento )
        {
            return new DParametrosSRI().guardar(ServicioSRActivo, Ambiente, TipoEmision, TipoDocumentoFactura, RazonSocial, NombreComercial, Codestablecimiento, Codpuntoemision, DirMatri, DirEstablecimiento, ObligadoContabilidad, CodigoNumerico, Moneda,licenciadesde,licenciahasta,regimen,correoSMTP,passwordSMTP,rutaxml, impresora, urlSRI, TipoDocumentoRetencion,EsAgenteRetencion,CodigoAgenteRetencion,NumContribuyente,  montominimo, codDocSustento);
        }
        public static string getParametro(string parametro)
        {
            return new DParametrosSRI().getParametro(parametro);
        }
        public static bool backup_bd(string name_bd,bool automatico)
        {
            return new DParametrosSRI().backup_bd(name_bd, automatico);
        }
    }
}
