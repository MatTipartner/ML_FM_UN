using MS_ML_FU_DLL_DOMAIN.Domain;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.Utilities.Convenios;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class ConveniosService : IConveniosService
    {
        private IConvenioClient clientConvenio; 
        private IMensajeClient clientMensaje;

        public ConvenioPestanaDto GetConvenio(CabeceraJsonDto cabeceraDto)
        {
            ConvenioPestanaDto convenioPestana = new ConvenioPestanaDto {
                Parametrica = this.GetParametricasConvenio(),
                Cabecera = cabeceraDto,
                DatosCarga = this.GetPestanaConvenio(cabeceraDto.IdGrupoFormulario, cabeceraDto.IdPestana)
            };
            return convenioPestana;
        }

        public ConvenioDto GetPestanaConvenio(int grupoFormulario, PestanaParametrica pestana)
        {
            Task<IEnumerable<OtrosConvenioDto>> convenioWait = Task.Run(() =>
            {
                return this.clientConvenio.GetOtrosConvenios(grupoFormulario);
            });
            Task<IEnumerable<FarmaciaDto>> farmaciaWait = Task.Run(() =>
            {
                return this.clientConvenio.GetFarmacia(grupoFormulario);
            });
            Task<IEnumerable<MensajeDtoMapper>> mensajeWait = Task.Run(() =>
            {
                return this.clientMensaje.GetBdMensaje(grupoFormulario, pestana);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(convenioWait, farmaciaWait, mensajeWait);
            // Rescate de datos
            return MapperConvenio.TransformarConvenioDtoMapperEnDTO(convenioWait.Result, farmaciaWait.Result, mensajeWait.Result);
        }

        public ParametricaConvenioDetalle GetParametricasConvenio()
        {
            Task<IEnumerable<ParametricasBdReferencia>> convenioWait = Task.Run(() =>
            {
                return this.clientConvenio.GetSettingBaseDatosRef(BaseDatosParametrica.Convenio);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> monedaWait = Task.Run(() =>
            {
                return this.clientConvenio.GetSettingServercioEst(ServiciosParametrica.Moneda);
            });
            Task<IEnumerable<ParametricasBdEstandar>> tipoFacturacionWait = Task.Run(() =>
            {
                return this.clientConvenio.GetSettingBaseDatosEst(BaseDatosParametrica.TipoFacturacion);
            });
            Task<IEnumerable<ParametricasBdEstandar>> vademecumWait = Task.Run(() =>
            {
                return this.clientConvenio.GetSettingBaseDatosEst(BaseDatosParametrica.Vademecum);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(convenioWait, monedaWait, tipoFacturacionWait, vademecumWait);
            // Rescate de datos
            ParametricaConvenioDetalle convenio = new ParametricaConvenioDetalle();
            IEnumerable<ParametricasBdReferencia> listaConvenio = convenioWait.Result;
            convenio.Farmacia = listaConvenio.Where(x => x.IdReferencia == (int)ConvenioParametrica.FARMACIA).ToList();
            convenio.OtrosConvenios = listaConvenio.Where(x => x.IdReferencia == (int)ConvenioParametrica.OTROS_CONVENIOS).ToList();
            convenio.CarataResguardo = listaConvenio.Where(x => x.IdReferencia == (int)ConvenioParametrica.CARTA_RESGUARDO).ToList();
            convenio.VentanillaRegiones = listaConvenio.Where(x => x.IdReferencia == (int)ConvenioParametrica.VENANILLA_REGIONES).ToList();
            convenio.VentanillaSantiago = listaConvenio.Where(x => x.IdReferencia == (int)ConvenioParametrica.VENTANILLA_SANTIAGO).ToList();
            convenio.Moneda = monedaWait.Result;
            convenio.TipoFacuracion = tipoFacturacionWait.Result;
            convenio.Vademecum = vademecumWait.Result;
            return convenio;
        }

        public Boolean SetGuardarPestanaConvenio(ConvenioPestanaDto datosConenio)
        {          
            Task<Boolean> guardarOtrosConvenios = Task.Run(() =>
            {
                return this.SetGuardarOtrosConvenios(datosConenio);
            });
            Task<Boolean> guardarFarmacia = Task.Run(() =>
            {
                return this.SetGuardarFarmacia(datosConenio);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(guardarOtrosConvenios, guardarFarmacia);
            // Rescate de datos
            Boolean guardar = false;
            if (guardarOtrosConvenios.Result && guardarFarmacia.Result)
            {
                guardar = true;
            }
            return guardar;


        }

        public Boolean SetGuardarOtrosConvenios(ConvenioPestanaDto datosOtrosConenio)
        {
            return clientConvenio.SetOtrosConvenios(MapperConvenio.TransformarOtrosConvenioDTOEnDtoVista(datosOtrosConenio.DatosCarga) , datosOtrosConenio.Cabecera.IdGrupoFormulario); ;
        }
        public Boolean SetGuardarFarmacia(ConvenioPestanaDto datosFarmacia)
        {
            return clientConvenio.SetFarmacia(MapperConvenio.TransformarFarmaciaDTOEnDtoVista(datosFarmacia.DatosCarga),  datosFarmacia.Cabecera.IdGrupoFormulario); ;
        }


        [Inject]
        public void SetApiConvenio(IConvenioClient clientConvenio)
        {
            this.clientConvenio = clientConvenio;
        }

        [Inject]
        public void SetApiMensaje(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }
    }
}