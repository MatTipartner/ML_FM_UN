using AutoMapper;
using MS_ML_FU_ACCESO_PERFIL.Models;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net.Sockets;

namespace MS_ML_FU_ACCESO_PERFIL.Persistence.Impl
{
    public class MsAccesoPerfilPersistence:IMsAccesoPerfilPersistence
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public int GetExistePoliza(int nroBizFlow) {
            var existePoliza = 0;
            try
            {
                using (Entities db = new Entities())
                {
                    existePoliza = db.FUWEB_POLIZA.AsEnumerable().Count(row => row.NRO_BIZFLOW == nroBizFlow);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return existePoliza;
        }
        public RedireccionPerfil GetRedireccion(String existeBizFlow) {
            RedireccionPerfil redireccionPerfil= new RedireccionPerfil();
            try
            {
                using (Entities db = new Entities())
                {
                    var direccion = (from r in db.FUWEB_REDIRECCION where r.EXISTEBIZFOR == existeBizFlow && r.VIGENTE == "S" select r);
                    foreach (var dir in direccion)
                    {
                        redireccionPerfil.IdDireccion = dir.ID_REDIRECCION;
                        redireccionPerfil.NombreDireccion = dir.NOMBRE;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return redireccionPerfil;
        }

        public int GetAreaAsociadaNroBizFlow(int estadoBizFlow) {
            var areaAsocBizFlow   = 0;
            try
            {
                using (Entities db = new Entities())
                {
                    var respuesta = from permisoEstado in db.FUWEB_PERMISOESTADO
                                    where permisoEstado.ID_ESTADOBISFLOW == estadoBizFlow
                                    select permisoEstado.FUWEB_P_AREA;
                    foreach (var reg in respuesta)
                    {
                        areaAsocBizFlow = reg.ID_AREA;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return areaAsocBizFlow;
        }

        public UsuarioDto GetUsuario(String siglaUsuario)
        {
            UsuarioDto usuarioDto = null;
            FUWEB_USUARIO usuarioEntity;
            try {
                using (Entities db = new Entities())
                {
                    var datos = (from areaUsuario in db.FUWEB_USUARIO
                                 where areaUsuario.SIGLA_USUARIO == siglaUsuario
                                 select areaUsuario);
                    if (datos.Count() > 0)
                    {
                        usuarioEntity = datos.First();
                        var config = new MapperConfiguration(cfg => cfg.CreateMap<FUWEB_USUARIO, UsuarioDto>());
                        IMapper mapper = config.CreateMapper();
                        usuarioDto = mapper.Map<FUWEB_USUARIO, UsuarioDto>(usuarioEntity);
                    }
                }
            } 
            catch(EntityException ex)
            {
                logger.Error(ex.Message);
            }
            return usuarioDto;
        }
        public PerfilUsuario getPerfilUsuario(String siglaUsuario) {
            return null;
        }

        public int GetEstadoFomulario(int nroBizFlow) {
            var estadoFormulario = 0;
            try
            {
                using (Entities db = new Entities())
                {
                    var eForm = (from pol in db.FUWEB_POLIZA
                                 where pol.NRO_BIZFLOW == nroBizFlow
                                 select pol).First();
                    estadoFormulario = (int)eForm.ID_ESTADOFORMULARIO;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return estadoFormulario;
        }
       
        public List<Permisos> GetPermisoFormulario(int estadoFormulario, String siglaUsuario) {
            Permisos permiso;
            List<Permisos> listaPermiso = new List<Permisos>();
            try
            {
                using (Entities db = new Entities())
                {
                    var permisoPestana = from perArea in db.FUWEB_PERMISOAREA
                                         join tipoPermiso in db.FUWEB_P_TIPOPERMISO on perArea.ID_TIPOPERMISO equals tipoPermiso.ID_TIPOPERMISO
                                         join pestana in db.FUWEB_P_PESTANA on perArea.ID_PESTANA equals pestana.ID_PESTANA
                                         join area in db.FUWEB_P_AREA on perArea.ID_AREA equals area.ID_AREA
                                         join usuario in db.FUWEB_USUARIO on perArea.ID_AREA equals usuario.ID_AREA
                                         where perArea.ID_ESTADOFORMULARIO == estadoFormulario &&
                                         area.VIGENTE == "S" &&
                                         usuario.SIGLA_USUARIO == siglaUsuario
                                         select new
                                         {
                                             idPestana = perArea.ID_PESTANA,
                                             nombrePestana = pestana.NOMBRE,
                                             idPermiso = perArea.ID_TIPOPERMISO,
                                             nombrePermiso = tipoPermiso.NOMBRE
                                         };

                    foreach (var pPestana in permisoPestana)
                    {
                        permiso = new Permisos();
                        permiso.IdPestana = pPestana.idPestana;
                        permiso.NombrePestana = pPestana.nombrePestana;
                        permiso.IdPermiso = pPestana.idPermiso;
                        permiso.NombrePermiso = pPestana.nombrePermiso;
                        listaPermiso.Add(permiso);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return listaPermiso;
        }

       
    }
}