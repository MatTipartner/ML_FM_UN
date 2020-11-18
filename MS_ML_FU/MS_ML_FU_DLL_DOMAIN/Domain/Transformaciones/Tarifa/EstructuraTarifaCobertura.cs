using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa
{
    public class EstructuraTarifaCobertura :EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<TarifaGrupoDto> Valor { get; set; }

        public EstructuraTarifaCobertura()
        {
            this.Valor = new List<TarifaGrupoDto>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA;
        }
    }
}
