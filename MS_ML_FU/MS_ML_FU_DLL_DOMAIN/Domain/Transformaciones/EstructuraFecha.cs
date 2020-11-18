using System;
using Newtonsoft.Json;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones
{
    public class EstructuraFecha : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public Nullable<DateTime> Valor { get; set; }

       /* [JsonProperty(PropertyName = "valorEspejo")]
        public Nullable<DateTime> ValorEspejo { get; set; }*/

        public EstructuraFecha()
        {
            this.TipoDato = TiposDeDatos.TIPO_DATO_FECHA;
        }
    }
}
