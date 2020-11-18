using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BROKER.Services
{
    public interface IMsBrokerServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio, int runCorredor);
        
        IEnumerable<ParametricaServicioReferencia> GetListaEjecutivosPorCorredor(int runCorredor);
        
        Boolean SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> listaBrokerCcte);
        
        Boolean SetBrokerCorredor(BrokerCorradorDtoMapper brokerCorredor);

        BrokerCorradorDtoMapper GetFormularioCorredor(int grupoFormulario);

        IEnumerable<BrokerCcteDtoMapper> GetFormularioCcte(int grupoFormulario);

        IEnumerable<ParametricasInfoFacturacion> GetInforFacturacion(int grupoFormulario);
    }
}