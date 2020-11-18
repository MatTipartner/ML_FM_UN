using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas
{
    public class TarifaDto
    {
        [JsonProperty(PropertyName = "idTarifa")]
        public EstructuraEntera IdTarifa { get; set; }
        
        [JsonProperty(PropertyName = "cobroPrima")]
        public EstructuraCadena CobroPrima { get; set; }

        [JsonProperty(PropertyName = "additionTarifa")]
        public EstructuraCadena AdditionTarifa { get; set; }

        [JsonProperty(PropertyName = "primaProporcial")]
        public EstructuraCadena PrimaProporcial { get; set; }

        [JsonProperty(PropertyName = "edadesFijas")]
        public EstructuraCadena EdadesFijas { get; set; }

        [JsonProperty(PropertyName = "tarifaVigencia")]
        public EstructuraCadena TarifaVigencia { get; set; }

        [JsonProperty(PropertyName = "tarifaSalud")]
        public EstructuraTarifaCobertura TarifaSalud { get; set; }
        
        [JsonProperty(PropertyName = "tarifaVidaAp")]
        public EstructuraTarifaCobertura TarifaVidaAp { get; set; }

    }
}
