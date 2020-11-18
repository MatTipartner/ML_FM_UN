using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_TARIFA.Models;
using MS_ML_FU_P_TARIFA.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_TARIFA.Persistence.Impl
{
    public class MsTarifaPersistence : IMsTarifaPersistence
    {
        public IEnumerable<ParametricasBdEstandar> GetListaDefinicionTributaria()
        {
            List<ParametricasBdEstandar> ldefinicionTributaria = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar definicionTributaria;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from DefinicionTarifa in db.FUWEB_P_DEFINICIONTRIBUTARIA
                               where DefinicionTarifa.VIGENTE == "S"
                               select DefinicionTarifa;

                    foreach (var Datocobertura in list)
                    {
                        definicionTributaria = new ParametricasBdEstandar();
                        definicionTributaria.Id = Datocobertura.ID_DEFINICIONTRIBUTARIA;
                        definicionTributaria.Descripcion = Datocobertura.NOMBRE;
                        ldefinicionTributaria.Add(definicionTributaria);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ldefinicionTributaria;
        }

        public TarifaDtoMapper GetTarifaPoliza(int nroFormulario)
        {
            TarifaDtoMapper tarifa = new TarifaDtoMapper();
            try
            {
                using (Entities db = new Entities())
                {
                    var tariPoliza = from tPoliza in db.FUWEB_TARIFA
                               where tPoliza.NRO_POLIZA == nroFormulario
                               select tPoliza;
                    if (tariPoliza.Count() > 0)
                    {
                        tarifa = MapperWrapper.Mapper.Map<TarifaDtoMapper>(tariPoliza.FirstOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tarifa;
        }
        /**/
        public IEnumerable<TasaPrimaDtoMapper> GetTasaPrima(int TarifaGrupo)
        {
            List<TasaPrimaDtoMapper> lTasaPrima = new List<TasaPrimaDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from Tasa in db.FUWEB_TARIFAGRUPOLISTAPRIMA
                                 where Tasa.ID_TARIFAGRUPO == TarifaGrupo
                                 select Tasa);
                    if (datos.Count()>0)
                    {
                        foreach (var listaTarifaGrupo in datos)
                        {
                            lTasaPrima.Add(MapperWrapper.Mapper.Map<TasaPrimaDtoMapper>(listaTarifaGrupo));
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lTasaPrima;
        }

        public IEnumerable<TasaEspecialDtoMapper> GetListaEspecial(int TarifaGrupo)
        {
            List<TasaEspecialDtoMapper> lTasaEspecial = new List<TasaEspecialDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from Tasa in db.FUWEB_TARIFAGRUPOLISTAESPECIAL
                                 where Tasa.ID_TARIFAGRUPO == TarifaGrupo
                                 select Tasa);
                    if (datos.Count() > 0)
                    {
                        foreach (var listaTarifaGrupo in datos)
                        {
                            lTasaEspecial.Add(MapperWrapper.Mapper.Map<TasaEspecialDtoMapper>(listaTarifaGrupo));
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lTasaEspecial;
        }

        public IEnumerable<TarifaGrupoDtoMapper> GetTarifaCoberturaGrupo(int grupoFormulario)
        {
            List<TarifaGrupoDtoMapper> tarifaGrupo = new List<TarifaGrupoDtoMapper> ();
            try
            {
                using (Entities db = new Entities())
                {
                    var tGrupo = from tGrup in db.FUWEB_TARIFAGRUPO
                                     where tGrup.ID_AGRUPACION == grupoFormulario
                                 select tGrup;
                    if (tGrupo.Count() > 0)
                    {
                        foreach (var tCoberGrupo in tGrupo)
                        {
                            tarifaGrupo.Add(MapperWrapper.Mapper.Map<TarifaGrupoDtoMapper>(tCoberGrupo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tarifaGrupo;
        }

        public IEnumerable<TarifaGrupoDtoMapper> GetTarifaCoberturaGrupoPorEliminar(int grupoFormulario)
        {
            List<TarifaGrupoDtoMapper> tarifaGrupo = new List<TarifaGrupoDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var tGrupo = from tGrup in db.FUWEB_TARIFAGRUPO
                                 where tGrup.ID_AGRUPACION == grupoFormulario
                                 select tGrup;
                    if (tGrupo.Count() > 0)
                    {
                        foreach (var tCoberGrupo in tGrupo)
                        {
                            tarifaGrupo.Add(MapperWrapper.Mapper.Map<TarifaGrupoDtoMapper>(tCoberGrupo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tarifaGrupo;
        }

       
        public Boolean DeleteTarifa(TarifaDtoMapper tarifa) {
            try
            {
                using (Entities db = new Entities())
                {
                    //obtengo el rgistro como tal
                    var Registro = db.FUWEB_TARIFA.Where(valor => valor.ID_TARIFA == tarifa.ID_TARIFA).FirstOrDefault();
                    db.FUWEB_TARIFA.Remove(Registro);
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

        public Boolean DeleteTarifaGrupo(IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupo) 
        {
            try
            {                
                foreach (var lista in listaTarifaGrupo)
                {
                    using (Entities db = new Entities())
                    {
                        var Registro = db.FUWEB_TARIFAGRUPO.Where(Valor => Valor.ID_TARIFAGRUPO== lista.ID_TARIFAGRUPO).FirstOrDefault();
                        db.FUWEB_TARIFAGRUPO.Remove(Registro);
                        db.SaveChanges();
                    }
                }
                return true;
                
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
       
        public Boolean DeleteTasaPrima(IEnumerable<TasaPrimaDtoMapper> listaTasaPrima)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaTasaPrima)
                    {
                        var Registro = db.FUWEB_TARIFAGRUPOLISTAPRIMA.Where(Valor => Valor.ID_GRUPOLISTAPRIMA == lista.ID_GRUPOLISTAPRIMA).FirstOrDefault();
                        db.FUWEB_TARIFAGRUPOLISTAPRIMA.Remove(Registro);
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

        public Boolean DeleteTasaEspecial(IEnumerable<TasaEspecialDtoMapper> listaTasaEspecial)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaTasaEspecial)
                    {
                        var Registro = db.FUWEB_TARIFAGRUPOLISTAESPECIAL.Where(Valor => Valor.ID_GRUPOLISTAESPECIAL == lista.ID_GRUPOLISTAESPECIAL).FirstOrDefault();
                        db.FUWEB_TARIFAGRUPOLISTAESPECIAL.Remove(Registro);
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

        public Boolean SetTarifa(TarifaDtoMapper tarifa)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.FUWEB_TARIFA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_TARIFA>(tarifa));
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
        
        public Boolean SetTarifaGrupo(IEnumerable<TarifaGrupoDtoMapper> otrasTarifasGrupoMapper)
        {
            try
            {
                foreach (var lista in otrasTarifasGrupoMapper)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_TARIFAGRUPO.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_TARIFAGRUPO>(lista));
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
               // throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                return false;
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        
        public Boolean SetTasaPrima(IEnumerable<TasaPrimaDtoMapper> otrasTasaPrimaMapper)
        {
            try
            {
                foreach (var lista in otrasTasaPrimaMapper)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_TARIFAGRUPOLISTAPRIMA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_TARIFAGRUPOLISTAPRIMA>(lista));
                        db.SaveChanges();
                    }
                }
                return true;

            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        
        public Boolean SetTasaEspecial(IEnumerable<TasaEspecialDtoMapper> otrasTasaEspecialMapper)
        {
            try
            {
                foreach (var lista in otrasTasaEspecialMapper)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_TARIFAGRUPOLISTAESPECIAL.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_TARIFAGRUPOLISTAESPECIAL>(lista));
                        db.SaveChanges();
                    }
                }
                return true;

            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}