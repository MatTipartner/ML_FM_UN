using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Utilities.Tarifa
{
    public class FiltrarTarifa
    {
        public static IEnumerable<TarifaGrupoDto> FiltrarTarifaCobertura (IEnumerable<ParametricasBdReferencia> CoberturaGrupo,
                                                                          IEnumerable<TarifaGrupoDto> tarifaGrupo ,int grupoFormulario)
        {
            List<TarifaGrupoDto> listaTarifaGrupo = new List<TarifaGrupoDto>();
            foreach ( var lista  in CoberturaGrupo) {
                TarifaGrupoDto tarifaGrupoFiltro = tarifaGrupo.Where(x => x.ID_COBERTURA == lista.Id).FirstOrDefault();
                
                if (tarifaGrupoFiltro == null) {
                    tarifaGrupoFiltro = new TarifaGrupoDto();
                    tarifaGrupoFiltro.ID_COBERTURA = lista.Id;
                    tarifaGrupoFiltro.GRUPOFAMILIAR = "N";
                    tarifaGrupoFiltro.ID_TARIFAGRUPO = 0;
                    tarifaGrupoFiltro.ID_TIPOPRODUCTO = lista.IdReferencia;
                    tarifaGrupoFiltro.ID_AGRUPACION = grupoFormulario;
                    tarifaGrupoFiltro.ID_DEFINICIONTRIBUTARIA = 1;
                    IEnumerable<TasaPrimaDtoMapper> listaPrima1 = new List<TasaPrimaDtoMapper>();
                    IEnumerable<TasaEspecialDtoMapper> listaEspecial1 = new List<TasaEspecialDtoMapper>();
                    tarifaGrupoFiltro.ListaEspecial = listaEspecial1;
                    tarifaGrupoFiltro.ListaPrima = listaPrima1;
                }
                listaTarifaGrupo.Add(tarifaGrupoFiltro);
            }            
            return listaTarifaGrupo;
        }
    }
}