using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones
{
    public class EstructuraListaReferencia : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public List<ParametricasBdReferencia> Valor { get; set; }

       /* [JsonProperty(PropertyName = "valorEspejo")]
        public List<ParametricasBdReferencia> ValorEspejo { get; set; }*/
        
        public EstructuraListaReferencia()
        {
            this.Valor = new List<ParametricasBdReferencia>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA_REFERENCIA;
        }
    }
}
