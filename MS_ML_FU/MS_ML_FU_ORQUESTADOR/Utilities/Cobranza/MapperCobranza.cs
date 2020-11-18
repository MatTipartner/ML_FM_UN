using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.Utilities.Cobranza
{
    public class MapperCobranza
    {
        public static CobranzaDto TransformarCobranzaDtoMapperEnDTO(CobranzaDtoMapper cobranza, CobranzaGrupoDtoMapper cobranzaGrupo, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            CobranzaDto cobranzaPes = new CobranzaDto();
            cobranzaPes.IdCobranza = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_COBRANZA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            cobranzaPes.TipoFacturacion = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_TIPOFACTURACION, (int)AtributoPestanaParametrica.TIPO_FACTURACION, listaMensajes);
            cobranzaPes.Periodicidad = MapperEstructurasUtilidades.CrearCadenaDTO(cobranza.SIGLA_COBROPRIMA, (int)AtributoPestanaParametrica.PERIODICIDAD, listaMensajes);
            cobranzaPes.DestinatarioCobranza = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_DESTINATARIOCOBRANZA, (int)AtributoPestanaParametrica.DESTINATARIO, listaMensajes);
            cobranzaPes.CalculoPrima = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_CALCULOPRIMA, (int)AtributoPestanaParametrica.CALCULO_PRIMA, listaMensajes);
            cobranzaPes.TipoProceso = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_TIPOPROCESOCOBRANZA, (int)AtributoPestanaParametrica.TIPO_PROCESO, listaMensajes);
            cobranzaPes.DiaFrontera = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.DIAFRONTERA, (int)AtributoPestanaParametrica.DIA_FRONTEA, listaMensajes);
            cobranzaPes.HES = MapperEstructurasUtilidades.CrearCadenaDTO(cobranza.HES, (int)AtributoPestanaParametrica.HES, listaMensajes);
            cobranzaPes.ContraPago = MapperEstructurasUtilidades.CrearCadenaDTO(cobranza.CONTRAPAGO, (int)AtributoPestanaParametrica.CONTRA_PAGO, listaMensajes);
            cobranzaPes.Precobranza = MapperEstructurasUtilidades.CrearCadenaDTO(cobranza.PRECOBRANZA, (int)AtributoPestanaParametrica.PRECOBRANZA, listaMensajes);
            cobranzaPes.AutoCobranza = MapperEstructurasUtilidades.CrearCadenaDTO(cobranza.AUTOCOBRANZA, (int)AtributoPestanaParametrica.AUTO_COBRANZA, listaMensajes);
            cobranzaPes.ReportaFacturacion = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_REPORTEFACTUACION, (int)AtributoPestanaParametrica.REPORTE_FACTURACION, listaMensajes);
            cobranzaPes.Contabilizacion = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_CONTABILIZACION, (int)AtributoPestanaParametrica.CONTABILIZACION, listaMensajes);
            cobranzaPes.TipoCobro = MapperEstructurasUtilidades.CrearEnteroDTO(cobranza.ID_TIPOCOBRO, (int)AtributoPestanaParametrica.TIPO_COBRO, listaMensajes);

            cobranzaPes.IdCobranzaGrupo = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.ID_COBRANZAGRUPO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            cobranzaPes.IdAgrupacion = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.ID_AGRUPACION, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            cobranzaPes.Contributoriedad = MapperEstructurasUtilidades.CrearCadenaDTO(cobranzaGrupo.CONTRIBUTORIEDAD, (int)AtributoPestanaParametrica.CONTRIBUTORIEDAD, listaMensajes);
            cobranzaPes.TipoContributoriedad = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.ID_CONTRIBUTORIEDAD, (int)AtributoPestanaParametrica.TIPO_CONTRIBUTORIEDAD, listaMensajes);
            cobranzaPes.EspecialContributoriedad = MapperEstructurasUtilidades.CrearCadenaDTO(cobranzaGrupo.ESPECIALCONTRIBUTORIEDAD, (int)AtributoPestanaParametrica.TEXTO_CONTRIBUTORIEDAD, listaMensajes);
            cobranzaPes.PorcentajeContratante = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.PORCENTAJECONTRATANTE, (int)AtributoPestanaParametrica.CONTRATANTE, listaMensajes);
            cobranzaPes.PorcentajeAsegurado = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.PORCENTAJEASEGURADO, (int)AtributoPestanaParametrica.ASEGURADO, listaMensajes);
            cobranzaPes.AQuienCobranza = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.ID_AQUIENCOBRANZA, (int)AtributoPestanaParametrica.A_QUIEN, listaMensajes);
            cobranzaPes.TipoFactura = MapperEstructurasUtilidades.CrearCadenaDTO(cobranzaGrupo.SIGLA_TIPOFACTURA, (int)AtributoPestanaParametrica.TIPO_FACTURA, listaMensajes);
            cobranzaPes.DvFacturacion = MapperEstructurasUtilidades.CrearCadenaDTO(cobranzaGrupo.DV_FACTURACION, (int)AtributoPestanaParametrica.DV, listaMensajes);
            cobranzaPes.RutFactutacion = MapperEstructurasUtilidades.CrearEnteroDTO(cobranzaGrupo.RUT_FACTURACION, (int)AtributoPestanaParametrica.RUT, listaMensajes);
            cobranzaPes.Riesgo = MapperEstructuraRiesgoCobranza.CrearListaRiesgo(cobranzaGrupo.FUWEB_COBRANZARIESGO, (int)AtributoPestanaParametrica.RIESGO_COBRANZA, listaMensajes);
            return cobranzaPes;
        }


        public static CobranzaDtoMapper TransformarCobranzaDTOEnDtoMapper(CobranzaDto cobranzaDto, int nroFormulario)
        {
            CobranzaDtoMapper cobranzaMapper = new CobranzaDtoMapper();
            cobranzaMapper.AUTOCOBRANZA = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.AutoCobranza);
            cobranzaMapper.CONTRAPAGO = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.ContraPago);
            cobranzaMapper.DIACOBRO = 10; // falta logica
            cobranzaMapper.DIACONVERSION = 10;
            cobranzaMapper.DIAFRONTERA = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.DiaFrontera);
            cobranzaMapper.ID_CALCULOPRIMA = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.CalculoPrima);
            cobranzaMapper.ID_COBRANZA = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.IdCobranza) ?? 0;
            cobranzaMapper.ID_CONTABILIZACION = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.Contabilizacion);
            cobranzaMapper.ID_DESTINATARIOCOBRANZA = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.DestinatarioCobranza);
            cobranzaMapper.ID_REPORTEFACTUACION = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.ReportaFacturacion);
            cobranzaMapper.ID_TIPOCOBRO = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.TipoCobro);
            cobranzaMapper.ID_TIPOFACTURACION = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.TipoFacturacion);
            cobranzaMapper.ID_TIPOPROCESOCOBRANZA = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.TipoProceso);
            cobranzaMapper.MESCOBRO = 0;
            cobranzaMapper.MESCONVERSION = 0;
            cobranzaMapper.NRO_POLIZA = nroFormulario;
            cobranzaMapper.PRECOBRANZA = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.Precobranza);
            //cobranzaMapper.SIGLA_COBROPRIMA = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.p);
            return cobranzaMapper;
        }


        public static CobranzaGrupoDtoMapper TransformarCobranzGaDTOEnDtoMapper(CobranzaDto cobranzaDto, int grupoFormaulario)
        {
            CobranzaGrupoDtoMapper cobranzagrupoMapper = new CobranzaGrupoDtoMapper();
            cobranzagrupoMapper.CONTRIBUTORIEDAD = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.Contributoriedad);
            cobranzagrupoMapper.DV_FACTURACION = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.DvFacturacion);
            cobranzagrupoMapper.ESPECIALCONTRIBUTORIEDAD = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.EspecialContributoriedad);
            cobranzagrupoMapper.ID_AGRUPACION = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.IdAgrupacion)?? 0;
            cobranzagrupoMapper.ID_AQUIENCOBRANZA = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.AQuienCobranza);
            cobranzagrupoMapper.ID_COBRANZAGRUPO = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.IdCobranzaGrupo)?? 0;
            cobranzagrupoMapper.ID_CONTRIBUTORIEDAD = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.TipoContributoriedad);
            cobranzagrupoMapper.PORCENTAJEASEGURADO = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.PorcentajeAsegurado);
            cobranzagrupoMapper.PORCENTAJECONTRATANTE = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.PorcentajeContratante);
            cobranzagrupoMapper.RUT_FACTURACION = MapperEstructurasUtilidades.ExtraerEntero(cobranzaDto.RutFactutacion);
            cobranzagrupoMapper.SIGLA_TIPOFACTURA = MapperEstructurasUtilidades.ExtraerCadena(cobranzaDto.TipoFactura);
            cobranzagrupoMapper.FUWEB_COBRANZARIESGO = IngresarGrupoPoliza(MapperEstructuraRiesgoCobranza.ExtraerCobranzaRiesgo(cobranzaDto), grupoFormaulario);
            return cobranzagrupoMapper;
        }

        public static IEnumerable<CobranzaRiesgoDtoMapper> IngresarGrupoPoliza(IEnumerable<CobranzaRiesgoDtoMapper> listaRiesgo, int grupoFormaulario)
        {
            List<CobranzaRiesgoDtoMapper> listaCobranzaRiego = new List<CobranzaRiesgoDtoMapper>();
            CobranzaRiesgoDtoMapper riesgo = null;
            foreach (var lista in listaRiesgo) {
                riesgo = new CobranzaRiesgoDtoMapper();
                riesgo.ID_COBRANZAGRUPO = grupoFormaulario;
                riesgo.ID_TIPORIESGO = lista.ID_TIPORIESGO;
                riesgo.TEXTO = lista.TEXTO;
                listaCobranzaRiego.Add(riesgo);
            }
            return listaCobranzaRiego;
        }
    }
}
