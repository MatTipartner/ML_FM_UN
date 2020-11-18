using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_P_BROKER.Models;
using MS_ML_FU_P_BROKER.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BROKER.Persistence.Impl
{
    public class MsBrokerPersistence:IMsBrokerPersistence
    {
        public Boolean SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> listaBrokerCcte)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaBrokerCcte) {
                        db.FUWEB_BROKERCCTE.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_BROKERCCTE>(lista));
                        db.SaveChanges();
                    }                   
                    return true;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetBrokerCorredor(BrokerCorradorDtoMapper brokerCorredor)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.FUWEB_BROKERCORREDOR.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_BROKERCORREDOR>(brokerCorredor));
                    db.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public BrokerCorradorDtoMapper GetFormularioCorredor(int grupoFormulario)
        {
            BrokerCorradorDtoMapper corredor = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from poliza in db.FUWEB_BROKERCORREDOR
                                 where poliza.ID_AGRUPACION == grupoFormulario
                                 select poliza);
                    if (datos.Count() > 0)
                    {
                        corredor = MapperWrapper.Mapper.Map<BrokerCorradorDtoMapper>(datos.FirstOrDefault());
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return corredor;
        }

        public IEnumerable<BrokerCcteDtoMapper> GetFormularioCcte(int grupoFormulario)
        {
            List<BrokerCcteDtoMapper> lCcte = new List<BrokerCcteDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from far in db.FUWEB_BROKERCCTE
                                 where far.ID_AGRUPACION == grupoFormulario
                                 select far);
                    if (datos.Count() > 0)
                    {
                        foreach (var listCcte in datos)
                        {
                            lCcte.Add(MapperWrapper.Mapper.Map<BrokerCcteDtoMapper>(listCcte));
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lCcte;
        }
    }
}