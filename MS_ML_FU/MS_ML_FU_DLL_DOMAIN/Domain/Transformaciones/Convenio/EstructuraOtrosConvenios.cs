using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio
{
    public class EstructuraOtrosConvenios : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<OtrosConvenioDto> Valor { get; set; }

        public EstructuraOtrosConvenios()
        {
            this.Valor = new List<OtrosConvenioDto>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA;
        }
    }
}
