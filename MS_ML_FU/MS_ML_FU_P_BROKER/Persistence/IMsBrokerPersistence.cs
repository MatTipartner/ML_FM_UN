using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BROKER.Persistence
{
    public interface IMsBrokerPersistence
    {
        Boolean SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> listaBrokerCcte);

        Boolean SetBrokerCorredor(BrokerCorradorDtoMapper brokerCorredor);

        BrokerCorradorDtoMapper GetFormularioCorredor(int grupoFormulario);

        IEnumerable<BrokerCcteDtoMapper> GetFormularioCcte(int grupoFormulario);
    }
}