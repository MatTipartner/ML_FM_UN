using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Varios;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class EjemploService : IEjemploService
    {
        private IEjemploClient apiEjemplo;

        public List<Repository> GetGithubRepositories()
        {
            List<Repository> list = this.apiEjemplo.GetGithubRepositories();
            if(null != list && list.Any())
            {
                foreach (var repo in list)
                {
                    repo.orquestadorMarca = "ORQUESTADOR Git";
                }
            }
            return list;
        }

        public List<WikimediaAvailability> GetWikimediaAvailabilities()
        {
            List<WikimediaAvailability> list = this.apiEjemplo.GetWikimediaAvailabilities();
            if (null != list && list.Any())
            {
                foreach (var repo in list)
                {
                    repo.orquestadorMarca = "ORQUESTADOR Wiki";
                }
            }
            return list;
        }

        public void SendTestObject()
        {
            TestObjectJson toj = new TestObjectJson();
            toj.ValorA = "IKKK";
            toj.ValorB = 88888;
            toj.list = new List<TestObjectJsonItem>();
            TestObjectJsonItem item = new TestObjectJsonItem();
            item.Item2 = "otro item";
            toj.list.Add(item);
            this.apiEjemplo.SendTestObject(toj);
        }



        /*
         * INJECCCION DE DEPENDENCIAS
         */
        [Inject]
        public void SetApiEjemplo(IEjemploClient apiEjemplo)
        {
            this.apiEjemplo = apiEjemplo;
        }
    }
}