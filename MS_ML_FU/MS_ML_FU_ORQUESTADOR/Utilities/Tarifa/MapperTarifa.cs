using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using System.Collections.Generic;
using System.Linq;

namespace MS_ML_FU_ORQUESTADOR.Utilities.Tarifa
{
    public class MapperTarifa
    {
        public static TarifaDto TransformarTarifaDtoMapperEnDTO(TarifaDtoMapper pTarifa,
                                                                IEnumerable<TarifaGrupoDto> tarifaGrupoSalud, 
                                                                IEnumerable<TarifaGrupoDto> tarifaGrupoVidaAp, 
                                                                IEnumerable<MensajeDtoMapper> listaMensajes)
        { 
            TarifaDto tarifaPes = new TarifaDto();
            tarifaPes.CobroPrima = MapperEstructurasUtilidades.CrearCadenaDTO(pTarifa.SIGLA_COBRO, (int)AtributoPestanaParametrica.COBRO_PRIMA, listaMensajes);
            tarifaPes.AdditionTarifa = MapperEstructurasUtilidades.CrearCadenaDTO(pTarifa.ADICION_TARIFA, (int)AtributoPestanaParametrica.ADDITION_PRIMA, listaMensajes);
            tarifaPes.PrimaProporcial = MapperEstructurasUtilidades.CrearCadenaDTO(pTarifa.PRIMA_PROPORCIONAL, (int)AtributoPestanaParametrica.PRIMA_PROPORCIONAL, listaMensajes);
            tarifaPes.EdadesFijas = MapperEstructurasUtilidades.CrearCadenaDTO(pTarifa.EDAD_FIJA, (int)AtributoPestanaParametrica.EDADES_FIJAS, listaMensajes);
            tarifaPes.TarifaVigencia = MapperEstructurasUtilidades.CrearCadenaDTO(pTarifa.TARIFA_VIGENCIA, (int)AtributoPestanaParametrica.TARIFA_VIGENCIA, listaMensajes);
            tarifaPes.IdTarifa = MapperEstructurasUtilidades.CrearEnteroDTO(pTarifa.ID_TARIFA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            tarifaPes.TarifaVidaAp = MapperEstructurasTarifa.CrearTarifaCobertura((List<TarifaGrupoDto>)tarifaGrupoVidaAp, (int)AtributoPestanaParametrica.TARIFA_VIDAAP, listaMensajes);
            tarifaPes.TarifaSalud = MapperEstructurasTarifa.CrearTarifaCobertura((List<TarifaGrupoDto>)tarifaGrupoSalud, (int)AtributoPestanaParametrica.TARIFA_SALUD, listaMensajes);
            return tarifaPes;
        }

        public static IEnumerable<TarifaGrupoDtoMapper> TransformarTarifaCoberturaDTOEnDtoMapper(TarifaPestanaDto datosTarifaCobertura)
        {
            List<TarifaGrupoDto> listaTarifaCobertura = new List<TarifaGrupoDto>();
            List<TarifaGrupoDtoMapper> listaMapper = new List<TarifaGrupoDtoMapper>();
            TarifaGrupoDtoMapper tarifaMapper = null;
            IEnumerable<TarifaGrupoDto> uno = MapperEstructurasTarifa.ExtraerTariaCobertura(datosTarifaCobertura.DatosCarga.TarifaSalud);
            IEnumerable<TarifaGrupoDto> dos = MapperEstructurasTarifa.ExtraerTariaCobertura(datosTarifaCobertura.DatosCarga.TarifaVidaAp);
            listaTarifaCobertura.AddRange(uno.ToList());
            listaTarifaCobertura.AddRange(dos.ToList());


            foreach (var lista in listaTarifaCobertura) {
                tarifaMapper = new TarifaGrupoDtoMapper();
                tarifaMapper.GRUPOFAMILIAR = lista.GRUPOFAMILIAR;
                tarifaMapper.ID_AGRUPACION = lista.ID_AGRUPACION;
                tarifaMapper.ID_COBERTURA = lista.ID_COBERTURA;
                tarifaMapper.ID_DEFINICIONTRIBUTARIA = lista.ID_DEFINICIONTRIBUTARIA;
                tarifaMapper.ID_TARIFAGRUPO = lista.ID_TARIFAGRUPO;
                tarifaMapper.ID_TIPOPRODUCTO = lista.ID_TIPOPRODUCTO;
                tarifaMapper.FUWEB_TARIFAGRUPOLISTAPRIMA = lista.ListaPrima;
                tarifaMapper.FUWEB_TARIFAGRUPOLISTAESPECIAL = lista.ListaEspecial;
                listaMapper.Add(tarifaMapper);
            }
            return listaMapper;
        }            

        public static TarifaDtoMapper TransformarTarifaDTOEnDtoMapper(TarifaDto tarifaDto, int nroFormulario)
        {
            TarifaDtoMapper tarifa = new TarifaDtoMapper ();
            tarifa.ADICION_TARIFA = MapperEstructurasUtilidades.ExtraerCadena(tarifaDto.AdditionTarifa);
            tarifa.EDAD_FIJA = MapperEstructurasUtilidades.ExtraerCadena(tarifaDto.EdadesFijas);
            tarifa.ID_TARIFA = MapperEstructurasUtilidades.ExtraerEntero(tarifaDto.IdTarifa)??0;
            tarifa.NRO_POLIZA = nroFormulario;
            tarifa.PRIMA_PROPORCIONAL = MapperEstructurasUtilidades.ExtraerCadena(tarifaDto.PrimaProporcial);
            tarifa.SIGLA_COBRO = MapperEstructurasUtilidades.ExtraerCadena(tarifaDto.CobroPrima);
            tarifa.TARIFA_VIGENCIA = MapperEstructurasUtilidades.ExtraerCadena(tarifaDto.TarifaVigencia);
            return tarifa;
        }

        public static List<TarifaGrupoDtoMapper> TransformarListaTarifaDTOEnDtoMapper(IEnumerable<TarifaGrupoDto> listaTarifaCobertura)
        {
            List<TarifaGrupoDtoMapper> listaMapper = new List<TarifaGrupoDtoMapper>();
            TarifaGrupoDtoMapper mapper = new TarifaGrupoDtoMapper();
            foreach (var lista in listaTarifaCobertura)
            {
                mapper = new TarifaGrupoDtoMapper();
                mapper.GRUPOFAMILIAR = lista.GRUPOFAMILIAR;
                mapper.ID_AGRUPACION = lista.ID_AGRUPACION;
                mapper.ID_COBERTURA = lista.ID_COBERTURA;
                mapper.ID_DEFINICIONTRIBUTARIA = lista.ID_DEFINICIONTRIBUTARIA;
                mapper.ID_TARIFAGRUPO = lista.ID_TARIFAGRUPO;
                mapper.ID_TIPOPRODUCTO = lista.ID_TIPOPRODUCTO;
                mapper.FUWEB_TARIFAGRUPOLISTAESPECIAL = lista.ListaEspecial;
                mapper.FUWEB_TARIFAGRUPOLISTAPRIMA = lista.ListaPrima;
                listaMapper.Add(mapper);
            }
            return listaMapper;
        }
    }
}