using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Producto
{
    public class EstructuraListaProductoVidaAp : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<ProductoVidaApDetalleDtoMapper> Valor { get; set; }

        public EstructuraListaProductoVidaAp()
        {
            this.Valor = new List<ProductoVidaApDetalleDtoMapper>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA_REFERENCIA;
        }
    }
}
