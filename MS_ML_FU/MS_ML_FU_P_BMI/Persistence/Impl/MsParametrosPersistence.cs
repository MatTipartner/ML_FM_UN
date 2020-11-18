using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_BMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BMI.Persistence.Impl
{
    public class MsParametrosPersistence : IMsParametrosPersistence
    {

        public List<ParametricasBdEstandar> GetListaAquienParametros()
        {
            List<ParametricasBdEstandar> lAquienParametros = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar aquienparametros;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from AquienParametros in db.FUWEB_P_AQUIENPARAMETROS
                               where AquienParametros.VIGENTE == "S"
                               select AquienParametros;

                    foreach (var aquienParametros in list)
                    {
                        aquienparametros = new ParametricasBdEstandar();
                        aquienparametros.Id = aquienParametros.ID_AQUIENPARAMETROS;
                        aquienparametros.Descripcion = aquienParametros.NOMBRE;
                        lAquienParametros.Add(aquienparametros);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lAquienParametros;
        }

        public List<ParametricasBdEstandar> GetListaGrupoIsapre()
        {
            List<ParametricasBdEstandar> lgrupoIsapre = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar grupoisapre;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from GrupoIsapre in db.FUWEB_P_GRUPOISAPRE
                               where GrupoIsapre.VIGENTE == "S"
                               select GrupoIsapre;

                    foreach (var grupoIsapre in list)
                    {
                        grupoisapre = new ParametricasBdEstandar();
                        grupoisapre.Id = grupoIsapre.ID_P_GRUPOISAPRE;
                        grupoisapre.Descripcion = grupoIsapre.NOMBRE;
                        lgrupoIsapre.Add(grupoisapre);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lgrupoIsapre;
        }
        public List<ParametricasBdEstandar> GetListaPrestacionBasica()
        {
            List<ParametricasBdEstandar> lprestacionBasica = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar prestacionbasica;
            try
            {
                using (Entities db = new Entities())
                {
                  var list = from PrestacionBasica in db.FUWEB_P_PRESTACIONBASICA
                               where PrestacionBasica.VIGENTE == "S"
                               select PrestacionBasica;

                    foreach (var prestacionBasica in list)
                    {
                        prestacionbasica = new ParametricasBdEstandar();
                        prestacionbasica.Id = prestacionBasica.ID_PRESTACIONBASICA;
                        prestacionbasica.Descripcion = prestacionBasica.NOMBRE;
                        lprestacionBasica.Add(prestacionbasica);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lprestacionBasica;
        }

    }
}