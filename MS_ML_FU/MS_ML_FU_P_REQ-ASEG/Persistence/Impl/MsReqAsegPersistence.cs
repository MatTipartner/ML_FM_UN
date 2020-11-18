using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_REQ_ASEG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_REQ_ASEG.Persistence.Impl
{
    public class MsReqAsegPersistence : IMsReqAsegPersistence
    {
        public List<ParametricasBdEstandar> GetExclusionAsegurabilidad()
        {
            List<ParametricasBdEstandar> lexclusionasegurabilidad = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar exclusionAsegurabilidad;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from ExclusionAsegurabilidad in db.FUWEB_P_EXLUSIONASEGURABILIDAD
                               where ExclusionAsegurabilidad.VIGENCIA == "S"
                               select ExclusionAsegurabilidad;

                    foreach (var DatoexclusionAsegurabilidad in list)
                    {
                        exclusionAsegurabilidad = new ParametricasBdEstandar();
                        exclusionAsegurabilidad.Id = DatoexclusionAsegurabilidad.ID_EXLUSIONASEGURABILIDAD;
                        exclusionAsegurabilidad.Descripcion = DatoexclusionAsegurabilidad.NOMBRE;
                        lexclusionasegurabilidad.Add(exclusionAsegurabilidad);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lexclusionasegurabilidad;
        }


    }
}