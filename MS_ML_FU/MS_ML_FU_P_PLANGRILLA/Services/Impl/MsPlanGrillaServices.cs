using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_PLANGRILLA.Persistence;
using MS_ML_FU_P_PLANGRILLA.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_PLANGRILLA.Services.Impl
{
    public class MsPlanGrillaServices:IMsPlanGrillaServices
    {
        private IMsPlanGrillaPersistence persistencePlanGrilla;
        private IMsPlanGrillaClient      clientPlanGrilla;
        public List<ParametricasBdEstandar> getListaPlanGrilla()
        {
            List<ParametricasBdEstandar> listAlgo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar lE1 = new ParametricasBdEstandar();
            lE1.Id = 1;
            lE1.Descripcion = "Condiciín Especial 1";
            listAlgo.Add(lE1);
            ParametricasBdEstandar lE2 = new ParametricasBdEstandar();
            lE2.Id = 2;
            lE2.Descripcion = "Condiciín Especial 2";
            listAlgo.Add(lE2);
            return listAlgo;
        }

       

        [Inject]
        public void SetClientConvenio(IMsPlanGrillaClient clientPlanGrilla)
        {
            this.clientPlanGrilla = clientPlanGrilla;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsPlanGrillaPersistence persistencePlanGrilla)
        {
            this.persistencePlanGrilla = persistencePlanGrilla;
        }


    }
}