
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_CONDICIONES.Persistence;
using MS_ML_FU_P_CONDICIONES.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_CONDICIONES.Services.Impl
{
    public class MsCondicionesEspServices:IMsCondicionesEspServices
    {
        private IMsCondicionesEspPersistence persistenceCondicionesEspeciales;
        private IMsCondicionesEspClient clientCondicionesEspeciales;
        public List<ParametricasBdEstandar> getListaEjemCondicionesEspeciales()
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
        public void SetClientCondicionesEspeciales(IMsCondicionesEspClient clientCondicionesEspeciales)
        {
            this.clientCondicionesEspeciales = clientCondicionesEspeciales;
        }

        [Inject]
        public void SetPersistenceCondicionesEspeciales(IMsCondicionesEspPersistence persistenceCondicionesEspeciales)
        {
            this.persistenceCondicionesEspeciales = persistenceCondicionesEspeciales;
        }
    }
}