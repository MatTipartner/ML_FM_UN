using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
	public interface IBrokerClient
	{
		IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio, int runCorredor);

		IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(int runCorredor);

		IEnumerable<BrokerCcteDtoMapper> GetFormularioCcte(int grupoFormulario);


		BrokerCorradorDtoMapper GetFormularioCorredor(int grupoFormulario);

		Boolean SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> ccte);

		Boolean SetBrokerCorredor(BrokerCorradorDtoMapper corredor);

		IEnumerable<ParametricasInfoFacturacion> GetInfofacturacion(int grupoFormulario);
	}
}