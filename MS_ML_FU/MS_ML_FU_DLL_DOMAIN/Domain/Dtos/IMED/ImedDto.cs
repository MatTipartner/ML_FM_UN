using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED
{
    public class ImedDto
    {
        [JsonProperty(PropertyName = "imed")]
        public EstructuraCadena Imed { get; set; }

        [JsonProperty(PropertyName = "tipoImed")]
        public EstructuraEntera TipoImed { get; set; }

        [JsonProperty(PropertyName = "grupoPrestador")]
        public EstructuraEntera GrupoPrestador { get; set; }

        [JsonProperty(PropertyName = "excepcionGrupoPrestador")]
        public EstructuraEntera ExcepcionGrupoPrestador { get; set; }

        [JsonProperty(PropertyName = "excepcionDetalle")]
        public EstructuraEntera ExcepcionDetalle { get; set; }

        [JsonProperty(PropertyName = "topeMonto")]
        public IEnumerable<TopeMontoDtoMapper> TopeMonto { get; set; }
    }
}
