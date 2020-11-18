using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Producto
{
    public class EstructuraCascada : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<CascadaDtoMapper> Valor { get; set; }

        public EstructuraCascada()
        {
            this.Valor = new List<CascadaDtoMapper>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA;
        }
    }
}
