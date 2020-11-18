using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_COBRANZA.Persistence;
using MS_ML_FU_P_COBRANZA.RestClients;
using MS_ML_FU_P_COBRANZA.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_COBRANZA.Services.Impl
{
    public class MsCobranzaServices : IMsCobranzaServices
    {
        private IMsCobranzaClient clientCobranza;
        private IMsCobranzaPersistence persistenceCobranza;
        
        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest;
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientCobranza.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }
            return listaParamEstandar;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.AQuienCobranza:
                    listaRespuesta = this.persistenceCobranza.GetListaAquienCobranza();
                    break;
                case BaseDatosParametrica.TipoCobro:
                    listaRespuesta = this.persistenceCobranza.GetListaTipoCobro();
                    break;
                case BaseDatosParametrica.CalculoPrima:
                    listaRespuesta = this.persistenceCobranza.GetListaCalculoPrima();
                    break;
                case BaseDatosParametrica.DestinatarioCobranza:
                    listaRespuesta = this.persistenceCobranza.GetListaDestintarioCobranza();
                    break;
                case BaseDatosParametrica.TipoFacturacionCobranza:
                    listaRespuesta = this.persistenceCobranza.GetListaTipoFacturacionCobranza();
                    break;
                case BaseDatosParametrica.RiesgoFacturacion:
                    listaRespuesta = this.persistenceCobranza.GetListaRiegoFacturacion();
                    break;
                case BaseDatosParametrica.TipoContrubutoriedad:
                    listaRespuesta = this.persistenceCobranza.GetListaTipoContributoriedad();
                    break;

                default:
                    break;
            }
            return listaRespuesta;
        }

        public CobranzaDtoMapper GetCobranza(int nroFormulario)
        {
            return this.persistenceCobranza.GetCobranza(nroFormulario);
        }

        public CobranzaGrupoDtoMapper GetCobranzaGrupo(int grupoFormulario)
        {
            return this.persistenceCobranza.GetCobranzaGrupo(grupoFormulario);
        }

        public Boolean SetCobranza(CobranzaDtoMapper listaCobranzaMapper)
        {
            Boolean cambiosCobranza = this.persistenceCobranza.SetCobranza(listaCobranzaMapper);
            return cambiosCobranza;
        }

        public Boolean SetPeriodicidad(string periodicidad, int nroFormulario)
        {
            return this.persistenceCobranza.SetPeriodicidad(periodicidad, nroFormulario);
        }

        public Boolean SetCobranzaGrupo(CobranzaGrupoDtoMapper cobranzaGrupo, int nroFormulario)
        {
            Boolean cambiosCobranza = this.persistenceCobranza.SetCobranzaGrupo(cobranzaGrupo);
            if (cambiosCobranza) {
                cambiosCobranza = this.SetCobranzaRiesgo(cobranzaGrupo.FUWEB_COBRANZARIESGO, nroFormulario);
            }
            return cambiosCobranza;
        }

        public Boolean SetCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranzaRiesgoMapper, int grupoFormulario)
        {
            Boolean cambio = true;
            try
            {
                IEnumerable<CobranzaRiesgoDtoMapper> listaRiesgoBd = (this.GetCobranzaGrupo(grupoFormulario)).FUWEB_COBRANZARIESGO;

                if (listaRiesgoBd != null)
                {
                    var insertUpdateLista = (from t in listaCobranzaRiesgoMapper
                                             where !listaRiesgoBd.Any(x => x.ID_COBRANZAGRUPO == t.ID_COBRANZAGRUPO
                                                                             && x.ID_TIPORIESGO == t.ID_TIPORIESGO)
                                             select t).ToList();

                    var deleteLista = (from t in listaRiesgoBd
                                       where !listaCobranzaRiesgoMapper.Any(x => x.ID_COBRANZAGRUPO == t.ID_COBRANZAGRUPO
                                                                             && x.ID_TIPORIESGO == t.ID_TIPORIESGO)
                                       select t).ToList();

                    if (insertUpdateLista != null && insertUpdateLista.Count() > 0)
                    {
                        cambio = this.persistenceCobranza.SetCobranzaRiesgo(insertUpdateLista);
                    }
                    Boolean cambio1 = true;
                    if (deleteLista != null && deleteLista.Count() > 0)
                    {
                        cambio1 = this.persistenceCobranza.SetDeleteCobranzaRiesgo(deleteLista);
                    }
                    if (cambio && cambio1)
                    {
                        cambio = true;
                    }
                }
                else if (listaRiesgoBd == null && listaCobranzaRiesgoMapper != null & listaCobranzaRiesgoMapper.Count() > 0) {
                    cambio = this.persistenceCobranza.SetCobranzaRiesgo(listaCobranzaRiesgoMapper);
                }
            }
            catch (EntityException ex )
            {
                Console.WriteLine("Error: " + ex.Message); 
                cambio = false;
            }
            return cambio;
        }

        /***********************************************************************************/
        [Inject]
        public void SetClientCobranza(IMsCobranzaClient clienteCobranza)
        {
            this.clientCobranza = clienteCobranza;
        }

        [Inject]
        public void SetPersistenceCobranza(IMsCobranzaPersistence persistenceCobranza)
        {
            this.persistenceCobranza = persistenceCobranza;
        }
    }
}