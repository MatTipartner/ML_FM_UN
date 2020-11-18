using EJEMPLO.Models;
using EJEMPLO.Utilities;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EJEMPLO.Persistence.Impl
{
    public class MsEjemploPersistence: IMsEjemploPersistence
    {
        
        public List<TipoGlosaDto> setListaGlosa()
        {
            List<TipoGlosaDto> ltipo = new List<TipoGlosaDto>();
            TipoGlosaDto tipoGl;
            using (Entities db = new Entities())
            {
                var list = db.IFW_AGL_TIPOGLOSA;
                                
                foreach (var estructBasica in list)
                {
                    tipoGl = new TipoGlosaDto();
                    tipoGl.AGLDESCRIPCIONTIPO = estructBasica.AGLDESCRIPCIONTIPO;
                    tipoGl.AGLTIPO = estructBasica.AGLTIPO;
                    ltipo.Add(tipoGl);
                    Console.WriteLine(estructBasica.AGLDESCRIPCIONTIPO);
                }
            }
            return ltipo;
        }

        public Boolean SetDatosPoliza(DatosPolizaDtoMapper datoMapperDatosPoliza)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.FUWEB_POLIZA.Add(MapperWrapper.Mapper.Map<FUWEB_POLIZA>(datoMapperDatosPoliza));
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


        public Boolean PruebaUpdate(DatosPolizaDtoMapper datoMapperDatosPoliza)
        {
           // var FUWEB_POLIZA_var = MapperWrapper.Mapper.Map<FUWEB_POLIZA>(datoMapperDatosPoliza);
            try
            {
                using (Entities db = new Entities())
                {

                    db.FUWEB_POLIZA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_POLIZA>(datoMapperDatosPoliza));
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

        public Boolean PruebaDelete(DatosPolizaDtoMapper datoMapperDatosPoliza)
        {
            var FUWEB_POLIZA_var = MapperWrapper.Mapper.Map<FUWEB_POLIZA>(datoMapperDatosPoliza);
            try
            {
                using (Entities db = new Entities())
                {
                    var registro = db.FUWEB_POLIZA.Where(list => list.NRO_POLIZA == FUWEB_POLIZA_var.NRO_POLIZA).FirstOrDefault();
                    db.FUWEB_POLIZA.Remove(registro);
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
    }

}
