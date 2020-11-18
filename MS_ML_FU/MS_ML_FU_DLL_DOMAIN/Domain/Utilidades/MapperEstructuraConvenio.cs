using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades
{
    public class MapperEstructuraConvenio
    {
        public static EstructuraOtrosConvenios CrearListaOtrosConvenios(IEnumerable<OtrosConvenioDto> listaOtrosConvenios, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraOtrosConvenios ec = new EstructuraOtrosConvenios();
            ec.IdCampo = id;
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            if (null != listaOtrosConvenios)
            {
                ec.Valor = listaOtrosConvenios.ToList();
            }
            return ec;
        }

        public static EstructuraFarmacia CrearListaFarmacia(IEnumerable<FarmaciaDto> listaFarmacia, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraFarmacia ec = new EstructuraFarmacia();
            ec.IdCampo = id;
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            if (null != listaFarmacia)
            {
                ec.Valor = listaFarmacia.ToList();
            }
            return ec;
        }

        public static IEnumerable<OtrosConvenioDto> ExtraerListaOtrosConvenios(ConvenioDto convenioDto)
        {
           IEnumerable<OtrosConvenioDto> valor = new List<OtrosConvenioDto>();
            if (null != convenioDto)
            {
                valor = convenioDto.ListaOtrosConvenios.Valor;
            }
            return valor;

            
        }

        public static IEnumerable<FarmaciaDto> ExtraerListaFarmacia(ConvenioDto convenioDto)
        {
            IEnumerable<FarmaciaDto> valor = new List<FarmaciaDto>();
            if (null != convenioDto)
            {
                valor = convenioDto.ListFarmacia.Valor;
            }
            return valor;
        }
    }
}
