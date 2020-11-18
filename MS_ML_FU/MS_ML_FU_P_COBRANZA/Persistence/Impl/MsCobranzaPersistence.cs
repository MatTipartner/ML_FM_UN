using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_COBRANZA.Models;
using MS_ML_FU_P_COBRANZA.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;


namespace MS_ML_FU_P_COBRANZA.Persistence.Impl
{
    public class MsCobranzaPersistence : IMsCobranzaPersistence
    {
        public IEnumerable<ParametricasBdEstandar> GetListaAquienCobranza()
        {
            List<ParametricasBdEstandar> laquiencobranza = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar aquiencobranza;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from aquien in db.FUWEB_P_AQUIENCOBRANZA
                               where aquien.VIGENTE == "S"
                               orderby aquien.NOMBRE
                               select aquien;

                    foreach (var aquien in list)
                    {
                        aquiencobranza = new ParametricasBdEstandar();
                        aquiencobranza.Id = aquien.ID_AQUIENCOBRANZA;
                        aquiencobranza.Descripcion = aquien.NOMBRE;
                        laquiencobranza.Add(aquiencobranza);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return laquiencobranza;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaTipoCobro()
        {
            List<ParametricasBdEstandar> ltipoCobro = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoCobro;
            try
            {
                using (Entities db = new Entities())
                 {                
                    var list = from tCobro in db.FUWEB_P_TIPOCOBRO
                               where tCobro.VIGENTE == "S"
                               orderby tCobro.NOMBRE
                               select tCobro;

                    foreach (var DatoTipoCobro in list)
                    {
                        tipoCobro = new ParametricasBdEstandar();
                        tipoCobro.Id = DatoTipoCobro.ID_TIPOCOBRO;
                        tipoCobro.Descripcion = DatoTipoCobro.NOMBRE;
                        ltipoCobro.Add(tipoCobro);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoCobro;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaCalculoPrima()
        {
            List<ParametricasBdEstandar> lcalculoPrima = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar calculoPrima;
            try
            {
                using (Entities db = new Entities())
                {               
                    var list = from cPrima in db.FUWEB_P_CALCULOPRIMA
                               where cPrima.VIGENTE == "S"
                               orderby cPrima.NOMBRE
                               select cPrima;

                    foreach (var DatoCalculoPrima in list)
                    {
                        calculoPrima = new ParametricasBdEstandar();
                        calculoPrima.Id = DatoCalculoPrima.ID_CALCULOPRIMA;
                        calculoPrima.Descripcion = DatoCalculoPrima.NOMBRE;
                        lcalculoPrima.Add(calculoPrima);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lcalculoPrima;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaDestintarioCobranza()
        {
            List<ParametricasBdEstandar> ldestinatarioCobranza = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar destinatarioCobranza;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from dCobranza in db.FUWEB_P_DESTINATARIOCOBRANZA
                               where dCobranza.VIGENTE == "S"
                               orderby dCobranza.NOMBRE
                               select dCobranza;

                    foreach (var DatoDestinatarioCoranza in list)
                    {
                        destinatarioCobranza = new ParametricasBdEstandar();
                        destinatarioCobranza.Id = DatoDestinatarioCoranza.ID_DESTINATARIOCOBRANZA;
                        destinatarioCobranza.Descripcion = DatoDestinatarioCoranza.NOMBRE;
                        ldestinatarioCobranza.Add(destinatarioCobranza);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ldestinatarioCobranza;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaTipoFacturacionCobranza()
        {
            List<ParametricasBdEstandar> ltipoFacturacion = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoFacturacion;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from tFacturacion in db.FUWEB_P_TIPOFACTURACIONCOBR
                               where tFacturacion.VIGENTE == "S"
                               orderby tFacturacion.NOMBRE
                               select tFacturacion;

                    foreach (var DatoTipoFacturacion in list)
                    {
                        tipoFacturacion = new ParametricasBdEstandar();
                        tipoFacturacion.Id = DatoTipoFacturacion.ID_TIPOFACTURACION;
                        tipoFacturacion.Descripcion = DatoTipoFacturacion.NOMBRE;
                        ltipoFacturacion.Add(tipoFacturacion);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoFacturacion;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaRiegoFacturacion()
        {
            List<ParametricasBdEstandar> lriesgoFacturacion = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar riesgoFacturacion;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from rFacturacion in db.FUWEB_P_RIESGOFACTURACION
                               where rFacturacion.VIGENTE == "S"
                               orderby rFacturacion.NOMBRE
                               select rFacturacion;

                    foreach (var DatoRiesgoFacturacion in list)
                    {
                        riesgoFacturacion = new ParametricasBdEstandar();
                        riesgoFacturacion.Id = DatoRiesgoFacturacion.ID_RIESGOFACTURACION;
                        riesgoFacturacion.Descripcion = DatoRiesgoFacturacion.NOMBRE;
                        lriesgoFacturacion.Add(riesgoFacturacion);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lriesgoFacturacion;
        }

        public IEnumerable<ParametricasBdEstandar> GetListaTipoContributoriedad()
        {
            List<ParametricasBdEstandar> lContributoriedad = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar contributoriedad;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from contr in db.FUWEB_P_CONTRIBUTORIEDAD
                               where contr.VIGENTE == "S" && contr.VISIBLE == "S"
                               orderby  contr.NOMBRE
                               select contr;

                    foreach (var listaContributoriedad in list)
                    {
                        contributoriedad = new ParametricasBdEstandar();
                        contributoriedad.Id = listaContributoriedad.ID_CONTRIBUTORIEDAD;
                        contributoriedad.Descripcion = listaContributoriedad.NOMBRE;

                        lContributoriedad.Add(contributoriedad);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lContributoriedad;
        }
        
        public CobranzaDtoMapper GetCobranza(int nroFormulario)
        {           
            CobranzaDtoMapper cobranza = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = from cob in db.FUWEB_COBRANZA
                               where cob.NRO_POLIZA == nroFormulario
                                   select cob;
                    if (datos.Count() > 0)
                    {
                        cobranza = MapperWrapper.Mapper.Map<CobranzaDtoMapper>(datos.FirstOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return cobranza;
        }

        public CobranzaGrupoDtoMapper GetCobranzaGrupo(int grupoFormulario)
        {
            CobranzaGrupoDtoMapper cobranzaGrupo = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = from cobrGrupo in db.FUWEB_COBRANZAGRUPO
                               where cobrGrupo.ID_AGRUPACION == grupoFormulario
                               select cobrGrupo;
                    if (datos.Count() > 0)
                    {
                        cobranzaGrupo = MapperWrapper.Mapper.Map<CobranzaGrupoDtoMapper>(datos.FirstOrDefault());
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return cobranzaGrupo;
        }

        public Boolean SetDeleteCobranza(CobranzaDtoMapper listaCobranzaMapper)
        {
            try
            {
                using (Entities db = new Entities())
                {
                        var registro = db.FUWEB_COBRANZA.Where(list => list.ID_COBRANZA == listaCobranzaMapper.ID_COBRANZA).FirstOrDefault();
                        db.FUWEB_COBRANZA.Remove(registro);
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

        public Boolean SetCobranza(CobranzaDtoMapper listaCobranzaMapper)
        {
            try
            {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_COBRANZA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_COBRANZA>(listaCobranzaMapper));
                        db.SaveChanges();
                    }
                return true;
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetDeleteCobranzaGrupo(CobranzaGrupoDtoMapper listaCobranzaGrupoMapper)
        {
            try
            {
                using (Entities db = new Entities())
                {
                        var registro = db.FUWEB_COBRANZAGRUPO.Where(list => list.ID_COBRANZAGRUPO == listaCobranzaGrupoMapper.ID_COBRANZAGRUPO).FirstOrDefault();
                        db.FUWEB_COBRANZAGRUPO.Remove(registro);
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

        public Boolean SetCobranzaGrupo(CobranzaGrupoDtoMapper listaCobranzaGrupoMapper)
        {
            try
            {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_COBRANZAGRUPO.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_COBRANZAGRUPO>(listaCobranzaGrupoMapper));
                        db.SaveChanges();
                    }
                return true;

            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetDeleteCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranzaRiesgoMapper)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaCobranzaRiesgoMapper)
                    {
                        var registro = db.FUWEB_COBRANZARIESGO.Where(list => list.ID_TIPORIESGO == lista.ID_TIPORIESGO 
                                                                        && list.ID_COBRANZAGRUPO == lista.ID_COBRANZAGRUPO).FirstOrDefault();
                        db.FUWEB_COBRANZARIESGO.Remove(registro);
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

        public Boolean SetCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranzaRiesgoMapper)
        {
            try
            { 
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaCobranzaRiesgoMapper)
                    {
                        db.FUWEB_COBRANZARIESGO.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_COBRANZARIESGO>(lista));
                        db.SaveChanges();
                    }
                }
                return true;

            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                return false;
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetPeriodicidad(string periodicidad, int nroFormulario)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    
                    var registro = db.FUWEB_COBRANZA.Where(list => list.NRO_POLIZA == nroFormulario).FirstOrDefault();
                    if (registro != null) {
                        registro.SIGLA_COBROPRIMA = periodicidad;
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
    }
}