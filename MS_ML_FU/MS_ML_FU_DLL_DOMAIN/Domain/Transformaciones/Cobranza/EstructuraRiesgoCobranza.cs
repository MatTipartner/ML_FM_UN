using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Cobranza
{
    public class EstructuraRiesgoCobranza: EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<CobranzaRiesgoDtoMapper> Valor { get; set; }

        public EstructuraRiesgoCobranza()
        {
            this.Valor = new List<CobranzaRiesgoDtoMapper>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA;
        }
    }
}
