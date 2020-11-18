using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Varios;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IEjemploClient
    {
        List<Repository> GetGithubRepositories();

        List<WikimediaAvailability> GetWikimediaAvailabilities();

        List<ParametricaServicioEstandar> GetSetting(ServiciosParametrica servicio);

        void SendTestObject(TestObjectJson toj);

    }
}
