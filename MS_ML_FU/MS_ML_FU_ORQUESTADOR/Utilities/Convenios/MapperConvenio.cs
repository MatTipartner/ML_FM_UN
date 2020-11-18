using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Utilities.Convenios
{
    public class MapperConvenio
    {
        public static ConvenioDto TransformarConvenioDtoMapperEnDTO(IEnumerable<OtrosConvenioDto> listaOtrosConvenio, IEnumerable<FarmaciaDto> listaFarmacia, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            ConvenioDto conv = new ConvenioDto();
            conv.ListaOtrosConvenios = MapperEstructuraConvenio.CrearListaOtrosConvenios(listaOtrosConvenio, (int)AtributoPestanaParametrica.OTROS_CONVENIOS, listaMensajes);
            conv.ListFarmacia = MapperEstructuraConvenio.CrearListaFarmacia(listaFarmacia, (int)AtributoPestanaParametrica.FARMACIA, listaMensajes);
            return conv;
        }

        public static IEnumerable<OtrosConvenioDto> TransformarOtrosConvenioDTOEnDtoVista(ConvenioDto Convenio)
        {
            IEnumerable<OtrosConvenioDto> otosConvenios = MapperEstructuraConvenio.ExtraerListaOtrosConvenios(Convenio);
            return otosConvenios;
        }

        public static IEnumerable<FarmaciaDto> TransformarFarmaciaDTOEnDtoVista(ConvenioDto Convenio)
        {
            IEnumerable<FarmaciaDto> farmacia = MapperEstructuraConvenio.ExtraerListaFarmacia(Convenio);
            return farmacia;
        }
    }
}