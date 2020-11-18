using EJEMPLO.Services;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Varios;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Transform;
using Ninject;
using System;
using System.Web.Http;

using EJEMPLO.Utilities;

using System.Collections.Generic;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Dto;

namespace EJEMPLO.Controllers
{
    [RoutePrefix("api/ejemplo")]
    public class EjemploController : ApiController
    {
        private IGitHubService serviceGitHub;
        private IWikimediaService serviceWikimedia;
        private IMsEjemplo serviceEjemplo;

        [Route("github")]
        [HttpGet]
        public IHttpActionResult GetGitHubRepos()
        {
            return Ok(this.serviceGitHub.GetGithubRepositories());
        }

        [Route("wiki/{id}")]
        [HttpGet]
        public IHttpActionResult GetWikimedia(int id)
        {
            return Ok(this.serviceWikimedia.GetWikimediaAvailability());
        }

        [Route("object/{id}")]
        [HttpPost]
        public IHttpActionResult GetJson(int id, TestObjectJson test)
        {
            System.Diagnostics.Debug.WriteLine("A " +  test.ValorA);
            System.Diagnostics.Debug.WriteLine("B " + test.ValorB);
            return Ok(test.ValorA);
        }

        [Route("object/{id}/grupo/{value}")]
        [HttpPost]
        public IHttpActionResult GetJson2(int id, string value, TestObjectJson test)
        {
            System.Diagnostics.Debug.WriteLine("A " + test.ValorA);
            System.Diagnostics.Debug.WriteLine("B " + test.ValorB);
            return Ok(test.ValorA);
        }

        [Route("transformDTO")]
        [HttpPost]
        public IHttpActionResult CaptureDTOToEntity(ObjetoDTO test)
        {
            ObjetoEntity entity = MapperUtilidades.TransformarDTOEnEntity(test);
            return Ok(entity);
        }

        [Route("transformEntity")]
        [HttpPost]
        public IHttpActionResult CaptureEntityToDTO(ObjetoEntity test)
        {
            ObjetoDTO dto = MapperUtilidades.TransformarEntityEnDTO(test,0);
            return Ok(dto);
        }

        [Route("listado")]
        [HttpGet]
        public IHttpActionResult Listado()
        {
            List<TipoGlosaDto> lis = this.serviceEjemplo.listaTipoGlosaBd();
            return Ok(lis);
        }

        [Route("insert")]
        [HttpGet]
        public IHttpActionResult InsercionBd()
        {
            return Ok(this.serviceEjemplo.SetDatosPoliza());
        }

        [Route("update")]
        [HttpGet]
        public IHttpActionResult UpdateBd()
        {
            return Ok(this.serviceEjemplo.PruebaUpdate());
        }

        [Route("delete")]
        [HttpGet]
        public IHttpActionResult DeleteBd()
        {
            return Ok(this.serviceEjemplo.PruebaDelete());
        }


        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult getSettingData(ServiciosParametrica servicio)
        {
            return Ok(this.serviceEjemplo.respuestaGetSettingData(servicio));
        }

        /*  
         * INYECCION DE DEPENDENCIAS
         */

        [Inject]
        public void SetServiceGitHub(IGitHubService serviceGitHub)
        {
            this.serviceGitHub = serviceGitHub;
        }

        [Inject]
        public void SetServiceWikimedia(IWikimediaService serviceWikimedia)
        {
            this.serviceWikimedia = serviceWikimedia;
        }

        [Inject]
        public void SetServiceEjemplo(IMsEjemplo serviceEjemplo)
        {
            this.serviceEjemplo = serviceEjemplo;
        }

    }
}
