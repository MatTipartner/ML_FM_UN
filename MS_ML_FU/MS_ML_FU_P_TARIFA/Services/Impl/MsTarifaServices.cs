using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_TARIFA.Persistence;
using MS_ML_FU_P_TARIFA.RestClients;
using MS_ML_FU_P_TARIFA.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

namespace MS_ML_FU_P_TARIFA.Services.Impl
{
    public class MsTarifaServices: IMsTarifaServices
    {
        private IMsTarifaClient clientTarifa;
        private IMsTarifaPersistence persistenceTarifa;
        
        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientTarifa.RespuestaCliente(soliRest);
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
                case BaseDatosParametrica.DefinicionTributaria:
                    listaRespuesta = this.persistenceTarifa.GetListaDefinicionTributaria();
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }

        public TarifaDtoMapper GetTarifa(int nroFormulario)
        {
            return this.persistenceTarifa.GetTarifaPoliza(nroFormulario); 
        }

        public IEnumerable<TarifaGrupoDto> GetTarifaCoberturaGrupoDto(int grupoFormulario)
        {
            IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupoMapper = this.GetTarifaCoberturaGrupo(grupoFormulario);
            List<TarifaGrupoDto> listaOtrosConvenio = new List<TarifaGrupoDto>();
            TarifaGrupoDto tarifaGrupo = null;
            foreach (var lGrupTarifa in listaTarifaGrupoMapper)
            {
                tarifaGrupo = new TarifaGrupoDto();
                tarifaGrupo.ID_AGRUPACION = lGrupTarifa.ID_AGRUPACION;
                tarifaGrupo.ID_COBERTURA = lGrupTarifa.ID_COBERTURA;
                tarifaGrupo.ID_DEFINICIONTRIBUTARIA = lGrupTarifa.ID_DEFINICIONTRIBUTARIA;
                tarifaGrupo.ID_TARIFAGRUPO = lGrupTarifa.ID_TARIFAGRUPO;
                tarifaGrupo.ID_TIPOPRODUCTO = lGrupTarifa.ID_TIPOPRODUCTO;
                tarifaGrupo.GRUPOFAMILIAR = lGrupTarifa.GRUPOFAMILIAR;
                tarifaGrupo.ListaEspecial = lGrupTarifa.FUWEB_TARIFAGRUPOLISTAESPECIAL;
                tarifaGrupo.ListaPrima = lGrupTarifa.FUWEB_TARIFAGRUPOLISTAPRIMA;
                listaOtrosConvenio.Add(tarifaGrupo);
            }
            return listaOtrosConvenio;
        }
        
        public IEnumerable<TasaPrimaDtoMapper> GetTasaPrima(int grupoFormulario)
        {
            return this.persistenceTarifa.GetTasaPrima(grupoFormulario);
        }

        public IEnumerable<TasaEspecialDtoMapper> GetListaEspecial(int grupoFormulario)
        {
            return this.persistenceTarifa.GetListaEspecial(grupoFormulario);
        }

        public IEnumerable<TarifaGrupoDtoMapper> GetTarifaCoberturaGrupo(int grupoFormulario)
        {
            return this.persistenceTarifa.GetTarifaCoberturaGrupo(grupoFormulario);
        }

        public Boolean SetTarifa(TarifaDtoMapper Tarifa)
        {            
            return this.persistenceTarifa.SetTarifa(Tarifa);                     
        }

        public Boolean DeleteTarifa(TarifaDtoMapper tarifa) 
        {
            return this.persistenceTarifa.DeleteTarifa(tarifa);
        }

        public Boolean DeleteTarifaCoberturaFull(IEnumerable<TarifaGrupoDtoMapper> tarifaCobertura)
        {
            Boolean guardar = true;
            foreach (var lista in tarifaCobertura)
            {
                guardar = this.DeleteDirectoTasaPrima(lista.FUWEB_TARIFAGRUPOLISTAPRIMA);
                if (guardar) {
                    guardar = this.DeleteDirectoTasaEspecial(lista.FUWEB_TARIFAGRUPOLISTAESPECIAL);
                }
            }
            if (guardar) {
                guardar = this.persistenceTarifa.DeleteTarifaGrupo(tarifaCobertura);
            }            
            return guardar;
        }

        public Boolean DeleteTarifaCobertura(IEnumerable<TarifaGrupoDtoMapper> tarifaCobertura)
        {
            Boolean guardar = true;
            foreach (var lista in tarifaCobertura)
            {
                guardar = this.DeleteDirectoTasaPrima(lista.FUWEB_TARIFAGRUPOLISTAPRIMA);
                if (guardar)
                {
                    guardar = this.DeleteDirectoTasaEspecial(lista.FUWEB_TARIFAGRUPOLISTAESPECIAL);
                }
            }
            return guardar;
        }

        public Boolean SetTarifaCoberturaFull(IEnumerable<TarifaGrupoDtoMapper> tarifaCobertura, int grupoFormulario)
        {
            IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupoBd = this.GetTarifaCoberturaGrupo(grupoFormulario);
            Boolean cambioTarifaGrupo = true;
            try
            {
                Boolean guardar = true;
                if (listaTarifaGrupoBd!= null && listaTarifaGrupoBd.Count()> 0) {
                    guardar = DeleteTarifaCoberturaFull(listaTarifaGrupoBd);
                }
                if (guardar)
                {
                    this.persistenceTarifa.SetTarifaGrupo(tarifaCobertura);
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return cambioTarifaGrupo;
        }

        public Boolean SetTarifaCobertura(IEnumerable<TarifaGrupoDtoMapper> tarifaCobertura, int grupoFormulario)
        {
            IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupoBd = this.GetTarifaCoberturaGrupo(grupoFormulario);
            Boolean cambioTarifaGrupo = true;
            try
            {
                Boolean guardar = true;
                if (listaTarifaGrupoBd != null && listaTarifaGrupoBd.Count() > 0)
                {
                    guardar = DeleteTarifaCobertura(listaTarifaGrupoBd);
                }
                if (guardar)
                {
                    foreach (var lista in tarifaCobertura)
                    {
                        guardar = SetDirectoTasaEspecial(lista.FUWEB_TARIFAGRUPOLISTAESPECIAL);
                        guardar = SetDirectoTasaPrima(lista.FUWEB_TARIFAGRUPOLISTAPRIMA);
                    }
                    if (guardar) {
                        guardar = this.persistenceTarifa.SetTarifaGrupo(tarifaCobertura);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return cambioTarifaGrupo;
        }



        public Boolean DeleteDirectoTasaPrima(IEnumerable<TasaPrimaDtoMapper> tasaPrima)
        {
            return   this.persistenceTarifa.DeleteTasaPrima(tasaPrima);
            
        }

       
        public Boolean DeleteDirectoTasaEspecial(IEnumerable<TasaEspecialDtoMapper> tasaEspecial)
        {
            return this.persistenceTarifa.DeleteTasaEspecial(tasaEspecial);
        }

        public Boolean SetDirectoTasaEspecial(IEnumerable<TasaEspecialDtoMapper> tasaEspecial)
        {           
            return this.persistenceTarifa.SetTasaEspecial(tasaEspecial);
        }

        public Boolean SetDirectoTasaPrima(IEnumerable<TasaPrimaDtoMapper> tasaPrima)
        {
            return this.persistenceTarifa.SetTasaPrima(tasaPrima);
        }

        /*****************************************************************/
        [Inject]
        public void SetClientConvenio(IMsTarifaClient clientTarifa)
        {
            this.clientTarifa = clientTarifa;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsTarifaPersistence persistenceTarifa)
        {
            this.persistenceTarifa = persistenceTarifa;
        }

 
    }

    
}