using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_IMED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_IMED.Persistence.Impl
{
    public class MsImedPersistence : IMsImedPersistence
    {

        public IEnumerable<ParametricasBdEstandar> GetListaTipoImed()
        {
            List<ParametricasBdEstandar> ltipoimed = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoImed;
            try
            {
                using (Entities db = new Entities())
                {
                
                    var list = from tImed in db.FUWEB_P_TIPOIMED
                               where tImed.VIGENTE == "S"
                               select tImed;

                    foreach (var tipoimed in list)
                    {
                        tipoImed = new ParametricasBdEstandar();
                        tipoImed.Id = tipoimed.ID_TIPOIMED;
                        tipoImed.Descripcion = tipoimed.NOMBRE;
                        ltipoimed.Add(tipoImed);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoimed;
        }
        public IEnumerable<ParametricasBdEstandar> GetListaGrupoPrestador()
        {
            List<ParametricasBdEstandar> lsubgrupo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar subGrupo;
            try
            {
                using (Entities db = new Entities())
            {
                   var list = from subgrupo in db.FUWEB_P_PRESTADORGRUPO
                               where subgrupo.VIGENTE == "S"
                               select subgrupo;

                    foreach (var tipoimed in list)
                    {
                        subGrupo = new ParametricasBdEstandar();
                        subGrupo.Id = tipoimed.ID_PRESTADORGRUPO;
                        subGrupo.Descripcion = tipoimed.NOMBRE;
                        lsubgrupo.Add(subGrupo);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lsubgrupo;
        }

        public IEnumerable<ParametricasBdReferencia> GetListaGrupoPrestadorSacs()
        {
            List<ParametricasBdReferencia> lprestacionSacs = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia prestadorsSacs;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from p in db.FUWEB_P_PRESTADORGRUPOSACS
                               where p.VIGENTE == "S"
                               select p;

                    foreach (var tipoimed in list)
                    {
                        prestadorsSacs = new ParametricasBdReferencia();
                        prestadorsSacs.Id = tipoimed.ID_PRESTADORGRUPOSACS;
                        prestadorsSacs.Descripcion = tipoimed.NOMBRE;
                        prestadorsSacs.IdReferencia = tipoimed.ID_PRESTADORGRUPO;
                        lprestacionSacs.Add(prestadorsSacs);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lprestacionSacs;
        }


        public IEnumerable<ParametricasBdEstandar> GetListaFrecuencia()
        {
            List<ParametricasBdEstandar> lFrecuencia = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar frecuencia;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from subgrupo in db.FUWEB_P_TIPOFRECUENCIA
                               where subgrupo.VIGENTE == "S"
                               select subgrupo;

                    foreach (var tipoimed in list)
                    {
                        frecuencia = new ParametricasBdEstandar();
                        frecuencia.Id = tipoimed.ID_TIPOFRECUENCIA;
                        frecuencia.Descripcion = tipoimed.NOMBRE;
                        lFrecuencia.Add(frecuencia);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lFrecuencia;
        }

    }
}