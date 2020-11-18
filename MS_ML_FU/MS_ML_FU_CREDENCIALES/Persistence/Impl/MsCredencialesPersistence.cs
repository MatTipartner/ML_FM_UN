using AutoMapper;
using Microsoft.Ajax.Utilities;
using MS_ML_FU_CREDENCIALES.Models;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_CREDENCIALES.Persistence.Impl
{
    public class MsCredencialesPersistence : IMsCredencialesPersistence
    {
        private IMapper mapper;

        public MsCredencialesPersistence()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CREDENCIAL, CredencialDto>();
                cfg.CreateMap<CredencialDto, CREDENCIAL>();
            });
            this.mapper = config.CreateMapper();
        }

        public CredencialDto GetCredencialPorUsuario(String usuario)
        {
            CredencialDto credencial = null;
            CREDENCIAL credencialEntity;
            using (CredencialesEntities db = new CredencialesEntities())
            {
                var datos = (from CREDENCIAL in db.CREDENCIAL
                             where CREDENCIAL.Usuario.Equals(usuario)
                             select CREDENCIAL);
                if(datos.Count() > 0)
                {
                    credencialEntity = datos.First();
                    credencial = this.mapper.Map<CREDENCIAL, CredencialDto>(credencialEntity);
                }
            }
            return credencial;
        }

        public List<CredencialDto> GetCredencialesPorBizflow(Nullable<decimal> numeroBizflow)
        {
            List<CredencialDto> credenciales = new List<CredencialDto>();
            using (CredencialesEntities db = new CredencialesEntities())
            {
                var datos = (from CREDENCIAL in db.CREDENCIAL
                             where CREDENCIAL.NroBizflow == numeroBizflow
                             select CREDENCIAL);
                if (datos.Count() > 0)
                {
                    foreach (var credencialDb in datos)
                    {
                        credenciales.Add(this.mapper.Map<CREDENCIAL, CredencialDto>(credencialDb));
                    }
                }
            }
            return credenciales;
        }

        public Boolean CrearCredencial(CredencialDto credencial)
        {
            CredencialesEntities db = new CredencialesEntities();
            CREDENCIAL credencialEntity = this.mapper.Map<CredencialDto, CREDENCIAL>(credencial);
            db.CREDENCIAL.Add(credencialEntity);
            db.SaveChanges();
            return true;
        }

        public Boolean ActualizarCredencial(CredencialDto credencial)
        {
            credencial.FechaMovimiento = DateTime.Now;
            CredencialesEntities db = new CredencialesEntities();
            var credenciales = db.CREDENCIAL.Where(CREDENCIAL => CREDENCIAL.Usuario.Equals(credencial.Usuario));
            // PK USUARIO
            Boolean actualizado = credenciales.Count() > 0;
            if (actualizado)
            {
                foreach (var credencialDb in credenciales)
                {
                    credencialDb.NroBizflow = credencial.NroBizflow;
                    credencialDb.ModoAcceso = credencial.ModoAcceso;
                    credencialDb.FechaMovimiento = credencial.FechaMovimiento;
                    credencialDb.TokenAcceso = credencial.TokenAcceso;
                    credencialDb.TokenRefresco = credencial.TokenRefresco;
                    credencialDb.TiempoExpiracionAcceso = credencial.TiempoExpiracionAcceso;
                    credencialDb.TiempoExpiracionRefresco = credencial.TiempoExpiracionRefresco;
                }
                db.SaveChanges();
            }
            return actualizado;
        }

        public Boolean EliminarCredencialUsuario(String usuario)
        {
            CredencialesEntities db = new CredencialesEntities();
            var crecencialDb = db.CREDENCIAL.Where(CREDENCIAL => CREDENCIAL.Usuario.Equals(usuario));
            Boolean eliminado = crecencialDb.Count() > 0;
            if(eliminado)
            {
                db.CREDENCIAL.Remove(crecencialDb.FirstOrDefault());
                db.SaveChanges();
            }
            return eliminado;
        }
    }
}