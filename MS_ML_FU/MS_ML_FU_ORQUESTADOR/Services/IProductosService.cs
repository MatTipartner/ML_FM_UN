using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos.Parametricas;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IProductosService
    {
        ProductoPestanaDto GetProducto(CabeceraJsonDto cabeceraDto);

        Boolean SetGuardarPestanaProducto(ProductoPestanaDto datosProducto);

        IEnumerable<ParametricasBdReferencia> listaCobertura(int grupoFormulario);
    }
}
