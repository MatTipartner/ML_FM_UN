using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.Services {

    public interface IEjemploService
    {
        List<Repository> GetGithubRepositories();

        List<WikimediaAvailability> GetWikimediaAvailabilities();

        void SendTestObject();

    }

}