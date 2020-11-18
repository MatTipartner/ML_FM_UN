using MS_ML_FU_CREDENCIALES.Models.Environment;
using MS_ML_FU_CREDENCIALES.Persistence;
using MS_ML_FU_CREDENCIALES.Persistence.Impl;
using MS_ML_FU_CREDENCIALES.RestClients;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_CREDENCIALES.Services.Impl
{
    public class MsCredencialesService : IMsCredencialesService
    {
        private IMsCredencialesPersistence credencialesPersistence;
        private IMsCredencialesClient credencialesRestClient;
        private readonly EnvironmentValues values = new EnvironmentValues();

        public MsCredencialesService() { }

        public MsCredencialesService(IMsCredencialesPersistence credencialesPersistence, IMsCredencialesClient credencialesRestClient)
        {
            this.credencialesPersistence = credencialesPersistence;
            this.credencialesRestClient = credencialesRestClient;
        }

        public Boolean ValidarCredencialUsuario(CredencialDto credencial)
        {
            Boolean validacion = false;
            // TOKEN_ACCESO es el password del sistema a esta altura
            if(values.BizflowUserGeneralKey.Equals(credencial.TokenAcceso))
            {
                // Obtiene usuario desde servicio PERFILES
                UsuarioDto usuarioPerfil = this.credencialesRestClient.GetUsuario(credencial.Usuario);
                if (null != usuarioPerfil)
                {
                    validacion = usuarioPerfil.SIGLA_USUARIO.Equals(credencial.Usuario);
                    // Busca la existencia del USUARIO en la DB local Entity
                    // Si lo encuentra, actualiza; si no, inserta
                    // No hay informacion de tokens en esta etapa. Datos seran actualizados en proceso posterior
                    CredencialDto credendialBase = this.credencialesPersistence.GetCredencialPorUsuario(credencial.Usuario);
                    if(null != credendialBase)
                    {
                        this.credencialesPersistence.ActualizarCredencial(credencial);
                    }
                    else
                    {
                        this.credencialesPersistence.CrearCredencial(credencial);
                    }
                }
            }
            return validacion;
        }

        public Boolean ActualizarCredencial(CredencialDto credencial)
        {
            // Actualizacion con datos de tokens
            credencial.TiempoExpiracionAcceso = values.ExpiracionTokenAcceso;
            credencial.TiempoExpiracionRefresco = values.ExpiracionTokenRefresco;
            return this.credencialesPersistence.ActualizarCredencial(credencial);
        }

        public void ActualizacionModoAcceso(CredencialDto credencial)
        {
            // Se inicia considerando que es modo edicion
            // Si hay algun inicio anterior valido con el mismo nivel de permiso, se le cambia a modo visualizacion
            credencial.ModoAcceso = Convert.ToDecimal(ModoAccesoUsuario.MODO_EDICION);
            List<CredencialDto> credenciales = this.credencialesPersistence.GetCredencialesPorBizflow(credencial.NroBizflow);
            if(credenciales.Count() > 0)
            {
                // Hay mas de un acceso por el numero de Bizflow
                foreach(var credencialTmp in credenciales)
                {
                    /*
                     * Buscar accesos con:
                     *  A) Usuarios diferentes
                     *  B) Modo de Edicion
                     */
                    if(!credencialTmp.Usuario.Equals(credencial.Usuario) && Convert.ToInt32(ModoAccesoUsuario.MODO_EDICION) == Convert.ToInt32(credencialTmp.ModoAcceso))
                    {
                        if(DateTime.Now.CompareTo(credencialTmp.FechaMovimiento.Value.AddSeconds(Convert.ToDouble(credencialTmp.TiempoExpiracionRefresco))) < 0)
                        {
                            // Si el token es valido, entonces el nuevo acceso sera en modo Visualizacion
                            credencial.ModoAcceso = Convert.ToDecimal(ModoAccesoUsuario.MODO_VISUALIZACION);
                            break;
                        }
                        else
                        {
                            // Si el token de refresco expiro, entonces el nuevo acceso se queda con modo Edicion y se elimina registro del acceso expirado
                            this.credencialesPersistence.EliminarCredencialUsuario(credencialTmp.Usuario);
                        }
                    } 
                }
            }
        }

        [Inject]
        public void SetCredencialesPersistence(IMsCredencialesPersistence credencialesPersistence)
        {
            this.credencialesPersistence = credencialesPersistence;
        }

        [Inject]
        public void SetCredencialesRestClient(IMsCredencialesClient credencialesRestClient)
        {
            this.credencialesRestClient = credencialesRestClient;
        }
    }
}