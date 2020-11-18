using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.Utilities.Broker;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class BrokerService: IBrokerService
    {
        private IBrokerClient clientBroker;
        private IMensajeClient clientMensaje;

        public BrokerPestanaDto GetBroker(CabeceraJsonDto cabeceraDto)
        {
            BrokerPestanaDto brokerPestana = new BrokerPestanaDto();
            brokerPestana.Cabecera = cabeceraDto;
            brokerPestana.Parametrica = this.GetParametricasBroker();
            brokerPestana.DatosCarga = this.GetPestanaCobranza(cabeceraDto);
            return brokerPestana;
        }

        public BrokerDto GetPestanaCobranza(CabeceraJsonDto cabecera)
        {
            BrokerDto cobranza = new BrokerDto();
            cobranza = MapperBroker.TransformarBrokerDtoMapperEnDTO(this.clientBroker.GetFormularioCcte(cabecera.IdGrupoFormulario),
                                                                        this.clientBroker.GetFormularioCorredor(cabecera.IdGrupoFormulario),
                                                                        this.clientMensaje.GetBdMensaje(cabecera.IdGrupoFormulario, cabecera.IdPestana));
            return cobranza;
        }


        public ParametricasBrokerDetalle GetParametricasBroker()
        {
            int corredor = 99571420;
            ParametricasBrokerDetalle BrokerParam = new ParametricasBrokerDetalle();
            BrokerParam.Holding = this.clientBroker.GetSettingServercioEst (ServiciosParametrica.Holding, corredor);
            IEnumerable<ParametricaServicioReferencia> listaEjecutivos = clientBroker.GetSettingServercioRef(corredor);
            if (listaEjecutivos != null && listaEjecutivos.Count() >0) {
                BrokerParam.EjecutivoMovimiento = listaEjecutivos.Where(x => x.IdReferencia.Trim() == ((int)TipoEjecutivo.MOVIMIENTO).ToString()).ToList(); 
                BrokerParam.Administrador = listaEjecutivos.Where(x => x.IdReferencia.Trim() == ((int)TipoEjecutivo.ADMINISTRADOR).ToString()).ToList();
                BrokerParam.EjecutivoComercial = listaEjecutivos.Where(x => x.IdReferencia.Trim() == ((int)TipoEjecutivo.COMERCIAL).ToString()).ToList();
                BrokerParam.EjecutivoCobranza = listaEjecutivos.Where(x => x.IdReferencia.Trim() == ((int)TipoEjecutivo.COBRANZA).ToString()).ToList();
            }
            
            return BrokerParam;
        }

        public Boolean SetGuardarPestanaCobranza(BrokerPestanaDto datosBroker)
        {
            int grupoFormulario = datosBroker.Cabecera.IdGrupoFormulario;
            Boolean guardar = this.SetGuardarCorredor(datosBroker);
            if (guardar)
            {
                guardar = this.SetGuardarCcte(datosBroker, grupoFormulario);
            }
            return guardar;
        }

        public Boolean SetGuardarCorredor(BrokerPestanaDto datosBroker)
        {
            ;
            return this.clientBroker.SetBrokerCorredor(MapperBroker.TransformarCorredorDTOEnDtoMapper(datosBroker.DatosCarga));
        }

        public Boolean SetGuardarCcte(BrokerPestanaDto datosBroker, int grupoFormulario)
        {
            return this.clientBroker.SetBrokerCcte(MapperBroker.TransformarCcteDTOEnDtoMapper(datosBroker.DatosCarga, grupoFormulario));
        }

        /***************************************************************/
        [Inject]
        public void SetApiCobranza(IBrokerClient clientBroker)
        {
            this.clientBroker = clientBroker;
        }
        [Inject]
        public void SetApiMensaje(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }
    }
}