using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using System;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IFormularioUnicoService
    {

        AccesoPerfilDto GetPerfilAcceso(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow);

        object GetCargaInicial(int idRedireccion, int nroBizFlow);

        Respuesta GuardarDatosPestana(object objectPestana);

        PestanaParametrica IdentificarPestana(PestanaPadre pestanaPadre);

        object GetDatosFormulario(CabeceraJsonDto cabeceraDto);

        Boolean ControlAcceso(CabeceraJsonDto cabecera);
    }
}
