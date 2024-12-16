using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using wfaFarmacia_Ney.Globales;
using wfaFarmacia_Ney.WsSRIComprobanteElectronico;

namespace wfaFarmacia_Ney.SRI.Model
{
    class SriServices
    {
        WsSRIComprobanteElectronico.SRI wsSRI = new WsSRIComprobanteElectronico.SRI();
        DataTable dt = NParametrosSRI.buscar();
        DataTable dtParametros = NParametros.buscar("");
        public CRespuestaRecepcion AutorizacionComprobante(string fechaEmision,string tipoIdentificacionComprador,string NumeroComprobante,string razonSocialComprador,string identificacionComprador,string direccionComprador,decimal totalSinImpuestos,decimal totalDescuento, decimal propina, decimal importeTotal, decimal valorRetIva, decimal valorRetRenta, totalImpuesto[] vTotalImpuesto,  Pagos[] vPagos, ItemPorProducto[] vItemPorProducto, DetalleImpuestosItem[] vDetalleImpuestosItem, ref string vrefnofactura , ref  string vrefvambiente, ref string vreftipoRemision,ref string vrefimpresora)
        {
            CRespuestaRecepcion responseSRI = new CRespuestaRecepcion(); 
            try
            { 
                if (dt.Rows.Count > 0 && dtParametros.Rows.Count > 0)
                {
                    InfoClaveAcceso infoKey = new InfoClaveAcceso();
                    infoTributaria infoTributaria = new infoTributaria();
                    infoFactura infoFact = new infoFactura(); 
                    if (bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString()))
                    {
                        DateTime dtFinicioLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaDesde"].ToString());
                        DateTime dtFFinLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaHasta"].ToString());

                        if (dtFinicioLicencia <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && dtFFinLicencia >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
                        {
                            var NumRuc = dtParametros.Rows[0]["Ruc"].ToString();
                            var TipoAmbiente = dt.Rows[0]["Ambiente"].ToString();
                            var tipoEmision = int.Parse(dt.Rows[0]["TipoEmision"].ToString());
                            var TipoComprobante = dt.Rows[0]["TipoDocumentoFactura"].ToString();
                            var RazonSocial = dt.Rows[0]["RazonSocial"].ToString();
                            var NombreComercial = dt.Rows[0]["NombreComercial"].ToString();
                            var Codestablecimiento = dt.Rows[0]["Codestablecimiento"].ToString();
                            var Codpuntoemision = dt.Rows[0]["Codpuntoemision"].ToString();
                            var dirMatriz = dt.Rows[0]["DirMatri"].ToString();
                            var DirEstablecimiento = dt.Rows[0]["DirEstablecimiento"].ToString();
                            var ObligadoContabilidad = dt.Rows[0]["ObligadoContabilidad"].ToString();
                            var CodNumerico = dt.Rows[0]["CodigoNumerico"].ToString();
                            var Moneda = dt.Rows[0]["Moneda"].ToString(); 
                            var guiaRemision = Codestablecimiento + "-" + Codpuntoemision + "-" + NumeroComprobante;
                            var serie = Codestablecimiento + "" + Codpuntoemision;

                            /*Se asignan valores de salida de referecias*/
                            vrefimpresora = dt.Rows[0]["ImpresoraTickets"].ToString();
                            vrefnofactura = guiaRemision;
                            vrefvambiente = TipoAmbiente == "1"?"PRUEBAS": TipoAmbiente == "2"?"PRODUCCION":"N/A";
                            vreftipoRemision = tipoEmision == 1 ? "NORMAL":"N/A";

                            /*Info de Acces Key*/
                            infoKey.FechaEmision = fechaEmision;
                            infoKey.TipoComprobante = TipoComprobante;
                            infoKey.NumRuc = NumRuc;
                            infoKey.TipoAmbiente = TipoAmbiente;
                            infoKey.Serie = serie;
                            infoKey.NumeroComprobante = NumeroComprobante;
                            infoKey.CodNumerico = CodNumerico;
                            infoKey.TipoEmision = tipoEmision.ToString();

                            /*Información tributario*/
                            infoTributaria.razonSocial = RazonSocial;
                            infoTributaria.nombreComercial = NombreComercial;
                            infoTributaria.estab = Codestablecimiento;
                            infoTributaria.ptoEmi = Codpuntoemision;
                            infoTributaria.dirMatriz = dirMatriz;

                            /*Información factura*/
                            infoFact.dirEstablecimiento = DirEstablecimiento;
                            infoFact.obligadoContabilidad = ObligadoContabilidad;
                            infoFact.tipoIdentificacionComprador = tipoIdentificacionComprador;
                            infoFact.guiaRemision = guiaRemision;
                            infoFact.razonSocialComprador = razonSocialComprador;
                            infoFact.identificacionComprador = identificacionComprador;
                            infoFact.direccionComprador = direccionComprador;
                            infoFact.totalSinImpuestos = totalSinImpuestos;
                            infoFact.totalDescuento = totalDescuento;
                            infoFact.propina = propina;
                            infoFact.importeTotal = importeTotal;
                            infoFact.moneda = Moneda;
                            infoFact.valorRetIva = valorRetIva;
                            infoFact.valorRetRenta = valorRetRenta;

                            /*Se consume el servicio para enviar el comprobante al SRI*/
                            responseSRI = wsSRI.AutorizacionComprobanteFactura(infoKey, infoTributaria, infoFact, vTotalImpuesto, vPagos, vItemPorProducto, vDetalleImpuestosItem);

                        }
                        else
                        {
                            responseSRI.ErrorInterno = true;
                            responseSRI.MensajeErrorInterno = "Licencia de servicio SRI en " + cGeneral.name_system + " no esta VIGENTE. Contactar con el administrador para su renovación.";

                        }
                    }
                    else
                    {
                        responseSRI.ErrorInterno = true;
                        responseSRI.MensajeErrorInterno = "Servicio del SRI a nivel de " + cGeneral.name_system +" esta INACTIVO. Contactar con el administrador para verificar la vigencia de la LICENCIA.";
                    }
                }
            }
            catch (Exception ex)
            {
                responseSRI.ErrorInterno = true;
                responseSRI.MensajeErrorInterno = ex.Message.ToString();
            }
           
            return responseSRI;
        }
        public CRespuestaRecepcion AutorizacionRetencion(string fechaEmision, string tipoIdentificacionRetenedor, string NumeroComprobante, string razonSocialRetenidor, string identificacionRetenedor, string direccionRetenedor,string periodoFiscal, DetalleImpuestosRetencion[] vDetalleImpuestosRetencion, DetalleInfoAdicional[] vDetalleInfoAdicional,ref string vrefnofactura, ref string vrefvambiente, ref string vreftipoRemision, ref string vrefimpresora)
        {
            CRespuestaRecepcion responseSRI = new CRespuestaRecepcion();
            try
            {
                if (dt.Rows.Count > 0 && dtParametros.Rows.Count > 0)
                {
                    InfoClaveAcceso infoKey = new InfoClaveAcceso();
                    infoTributaria infoTributaria = new infoTributaria();
                    infoFactura infoFact = new infoFactura();
                    infoCompRetencion infoCompRetencion = new infoCompRetencion();
                    if (bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString()))
                    {
                        DateTime dtFinicioLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaDesde"].ToString());
                        DateTime dtFFinLicencia = DateTime.Parse(dt.Rows[0]["VigenciaLicenciaHasta"].ToString());

                        if (dtFinicioLicencia <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && dtFFinLicencia >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
                        {
                            var NumRuc = dtParametros.Rows[0]["Ruc"].ToString();
                            var TipoAmbiente = dt.Rows[0]["Ambiente"].ToString();
                            var tipoEmision = int.Parse(dt.Rows[0]["TipoEmision"].ToString());
                            var TipoComprobante = dt.Rows[0]["TipoDocumentoRetencion"].ToString();
                            var RazonSocial = dt.Rows[0]["RazonSocial"].ToString();
                            var NombreComercial = dt.Rows[0]["NombreComercial"].ToString();
                            var Codestablecimiento = dt.Rows[0]["Codestablecimiento"].ToString();
                            var Codpuntoemision = dt.Rows[0]["Codpuntoemision"].ToString();
                            var dirMatriz = dt.Rows[0]["DirMatri"].ToString();
                            var DirEstablecimiento = dt.Rows[0]["DirEstablecimiento"].ToString();
                            var ObligadoContabilidad = dt.Rows[0]["ObligadoContabilidad"].ToString();
                            var CodNumerico = dt.Rows[0]["CodigoNumerico"].ToString();
                            var Moneda = dt.Rows[0]["Moneda"].ToString();
                            var guiaRemision = Codestablecimiento + "-" + Codpuntoemision + "-" + NumeroComprobante;
                            var serie = Codestablecimiento + "" + Codpuntoemision;

                            /*Se asignan valores de salida de referecias*/
                            vrefimpresora = dt.Rows[0]["ImpresoraTickets"].ToString();
                            vrefnofactura = guiaRemision;
                            vrefvambiente = TipoAmbiente == "1" ? "PRUEBAS" : TipoAmbiente == "2" ? "PRODUCCION" : "N/A";
                            vreftipoRemision = tipoEmision == 1 ? "NORMAL" : "N/A";

                            /*1. Info de Acces Key*/
                            infoKey.FechaEmision = fechaEmision;
                            infoKey.TipoComprobante = TipoComprobante;
                            infoKey.NumRuc = NumRuc;
                            infoKey.TipoAmbiente = TipoAmbiente;
                            infoKey.Serie = serie;
                            infoKey.NumeroComprobante = NumeroComprobante;
                            infoKey.CodNumerico = CodNumerico;
                            infoKey.TipoEmision = tipoEmision.ToString();

                            /*2. Información tributario*/
                            infoTributaria.razonSocial = RazonSocial;
                            infoTributaria.nombreComercial = NombreComercial;
                            infoTributaria.estab = Codestablecimiento;
                            infoTributaria.ptoEmi = Codpuntoemision;
                            infoTributaria.dirMatriz = dirMatriz;

                            /*3. Información Comprobante Retencion*/
                            infoCompRetencion.dirEstablecimiento = DirEstablecimiento;
                            infoCompRetencion.obligadoContabilidad = ObligadoContabilidad;
                            infoCompRetencion.tipoIdentificacionSujetoRetenido = tipoIdentificacionRetenedor; 
                            infoCompRetencion.razonSocialSujetoRetenido = razonSocialRetenidor;
                            infoCompRetencion.identificacionSujetoRetenido = identificacionRetenedor; 
                            infoCompRetencion.periodoFiscal = periodoFiscal;
                            

                            /*Se consume el servicio para enviar el comprobante al SRI*/
                            responseSRI = wsSRI.AutorizacionComprobanteRetencion(infoKey, infoTributaria, infoCompRetencion, vDetalleImpuestosRetencion, vDetalleInfoAdicional);

                        }
                        else
                        {
                            responseSRI.ErrorInterno = true;
                            responseSRI.MensajeErrorInterno = "Licencia de servicio SRI en " + cGeneral.name_system + " no esta VIGENTE. Contactar con el administrador para su renovación.";

                        }
                    }
                    else
                    {
                        responseSRI.ErrorInterno = true;
                        responseSRI.MensajeErrorInterno = "Servicio del SRI a nivel de " + cGeneral.name_system + " esta INACTIVO. Contactar con el administrador para verificar la vigencia de la LICENCIA.";
                    }
                }
            }
            catch (Exception ex)
            {
                responseSRI.ErrorInterno = true;
                responseSRI.MensajeErrorInterno = ex.Message.ToString();
            }

            return responseSRI;
        }
        public CRespuestaAutorizacion RecepcionComprobante(string key)
        {
            CRespuestaAutorizacion responeRecepcion = new CRespuestaAutorizacion();
            try
            {
                if (dt.Rows.Count > 0 && dtParametros.Rows.Count > 0)
                {
                    if (bool.Parse(dt.Rows[0]["ServicioSRActivo"].ToString()))
                    {
                        responeRecepcion = wsSRI.RecepcionComprobante(dt.Rows[0]["Ambiente"].ToString(),key);
                    }
                }
                else
                {
                    responeRecepcion.MensajeError = "Servicio del SRI a nivel de " + cGeneral.name_system + " esta Inactivo. Contactar con el administrador para verificar.";
                }
            }
            catch (Exception ex)
            {
                responeRecepcion.MensajeError =ex.Message.ToString();
            }
            
            return responeRecepcion;
        }
    }
    #region("Estructrua Response Recepcion"  
    #endregion
} 