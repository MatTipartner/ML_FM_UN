using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_MENU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_MENU.Persistence.Impl
{
    public class MsMenuPersistence: IMsMenuPersistence
    {
        public List<ParametricasBdEstandar> GetListaTipoFormulario()
        {
            List<ParametricasBdEstandar> ltipo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar pEstandar;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from formulario in db.FUWEB_P_TIPOFORMULARIO
                               where formulario.VIGENTE == "S"
                               select formulario;

                    foreach (var form in list)
                    {
                        pEstandar = new ParametricasBdEstandar();
                        pEstandar.Id = form.ID_TIPOFORMULARIO;
                        pEstandar.Descripcion = form.NOMBRE;
                        ltipo.Add(pEstandar);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipo;
        }

        public List<ParametricasBdReferencia> GetListaTipoFormularioDetalle()
        {
            List<ParametricasBdReferencia> ltipo = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia pReferencia;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from formDetalle in db.FUWEB_P_TIPOFORMULARIODETALLE
                               where formDetalle.VIGENTE == "S"
                               select formDetalle;

                    foreach (var fDetalle in list)
                    {
                        pReferencia = new ParametricasBdReferencia();
                        pReferencia.Id = fDetalle.ID_TIPOFORMUALRIODETALLE;
                        pReferencia.Descripcion = fDetalle.NOMBRE;
                        pReferencia.IdReferencia = fDetalle.ID_TIPOFORMULARIO;
                        ltipo.Add(pReferencia);
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipo;
        }
    }
}