using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJEMPLO.Persistence
{
    public interface IMsEjemploPersistence
    {
        List<TipoGlosaDto> setListaGlosa();

        Boolean SetDatosPoliza(DatosPolizaDtoMapper datoMapperDatosPoliza);

        Boolean PruebaUpdate(DatosPolizaDtoMapper datoMapperDatosPoliza);

        Boolean PruebaDelete(DatosPolizaDtoMapper datoMapperDatosPoliza);
    }
}