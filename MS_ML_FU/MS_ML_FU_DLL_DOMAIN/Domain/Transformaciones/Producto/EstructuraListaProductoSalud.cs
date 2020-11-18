using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Producto
{
    public class EstructuraListaProductoSalud : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<ProductoSaludDetalleDtoMapper> Valor { get; set; }

        public EstructuraListaProductoSalud()
        {
            this.Valor = new List<ProductoSaludDetalleDtoMapper>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA;
        }
    }
}
