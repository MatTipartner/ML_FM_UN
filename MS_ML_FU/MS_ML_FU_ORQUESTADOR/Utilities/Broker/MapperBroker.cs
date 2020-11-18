using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Utilities.Broker
{
    public class MapperBroker
    {
        public static BrokerDto TransformarBrokerDtoMapperEnDTO(IEnumerable<BrokerCcteDtoMapper> ccte, BrokerCorradorDtoMapper corredor, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            BrokerDto brokerPes = new BrokerDto();
            brokerPes.IdCorredor = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.ID_CORREDOR, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.RutCorredor = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.RUT_CORREDOR, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.DvCorredor = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.DV_CORREDOR, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.NombreCorredor = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.NOMBRE_CORREDOR, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            //brokerPes.Telefono = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.TELEFONO , (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.Giro = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.GIRO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.Direccion = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.DIRECCION, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.Ciudad = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.CIUDAD, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.Comuna = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.COMUNA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.PolizaGarantiaVigente = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.POLIZA_GARANTIA_VIGENTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.NombreContacto = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.NOMBRE_CONTACTO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.Email = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.EMAIL, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.FormaPago = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.FORMA_PAGO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.TipoCuenta = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.TIPO_CUENTA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.NroCuenta = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.NRO_CUENTA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.Banco = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.BANCO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.IdHolding = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.ID_HOLDING, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.IdAdministrador = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.ID_ADMINISTRADOR, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.IdEjecutivoCobranza = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.ID_EJECUTIVO_COBRANZA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.IdEjecutivoComercial = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.ID_EJECUTIVO_COMERCIAL, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.IdEjecutivoMovimiento = MapperEstructurasUtilidades.CrearCadenaDTO(corredor.ID_EJECUTIVO_MOVIMIENTO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
            brokerPes.IdAgrupacion = MapperEstructurasUtilidades.CrearEnteroDTO(corredor.ID_AGRUPACION, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);

            if (ccte != null && ccte.Count() >0) 
            {
                foreach (var lista in ccte)
                {
                    if (lista.ID_TIPOCCTE == (int)TipoCcte.CONTRATANTE)
                    {
                        brokerPes.IdContratante = MapperEstructurasUtilidades.CrearEnteroDTO(lista.ID_CCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.RutContratante = MapperEstructurasUtilidades.CrearEnteroDTO(lista.RUTCCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.DvContratante = MapperEstructurasUtilidades.CrearCadenaDTO(lista.DVCCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.NombreContratante = MapperEstructurasUtilidades.CrearCadenaDTO(lista.NOMBRECCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.GrupoEmpresaCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.GRUPOEMPRESAS, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.TelefonCont = MapperEstructurasUtilidades.CrearEnteroDTO(lista.TELEFONO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.DireccionCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.DIRECCION, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.ComunaCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.COMUNA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.CiudadCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.CIUDAD, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.GiroCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.GIRO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.NombreContactoCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.NOMBRE_CONTACTO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.EmailCont = MapperEstructurasUtilidades.CrearCadenaDTO(lista.EMAIL, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.nombreMandante = MapperEstructurasUtilidades.CrearCadenaDTO(lista.NOMBRE_MANDANTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.RutMandante = MapperEstructurasUtilidades.CrearCadenaDTO(lista.RUT_MANDANTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                       }
                    if (lista.ID_TIPOCCTE == (int)TipoCcte.FILIAL)
                    {
                        brokerPes.IdFilial = MapperEstructurasUtilidades.CrearEnteroDTO(lista.ID_CCTE, (int)AtributoPestanaParametrica.TIPO_FACTURA, listaMensajes);
                        brokerPes.RutFilial = MapperEstructurasUtilidades.CrearEnteroDTO(lista.RUTCCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.DvFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.DVCCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.NombreFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.NOMBRECCTE, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.GrupoEmpresaFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.GRUPOEMPRESAS, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.TelefonFilial = MapperEstructurasUtilidades.CrearEnteroDTO(lista.TELEFONO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.DireccionFilialt = MapperEstructurasUtilidades.CrearCadenaDTO(lista.DIRECCION, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.ComunaFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.COMUNA, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.CiudadFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.CIUDAD, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.GiroFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.GIRO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.NombreContactoFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.NOMBRE_CONTACTO, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                        brokerPes.EmailFilial = MapperEstructurasUtilidades.CrearCadenaDTO(lista.EMAIL, (int)AtributoPestanaParametrica.NO_APLICA, listaMensajes);
                    }
                }
            }
           
            return brokerPes;
        }

        public static BrokerCorradorDtoMapper TransformarCorredorDTOEnDtoMapper(BrokerDto brokerDto)
        {
            BrokerCorradorDtoMapper cobranzaMapper = new BrokerCorradorDtoMapper();
            cobranzaMapper.ID_CORREDOR = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.IdCorredor) ?? 0;
            cobranzaMapper.RUT_CORREDOR = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.RutCorredor) ?? 0;
            cobranzaMapper.DV_CORREDOR = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.DvCorredor);
            cobranzaMapper.NOMBRE_CORREDOR = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.NombreCorredor);
            //cobranzaMapper.TELEFONO = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.Telefono)??0;
            cobranzaMapper.GIRO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.Giro);
            cobranzaMapper.DIRECCION = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.Direccion);
            cobranzaMapper.CIUDAD = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.Ciudad);
            cobranzaMapper.COMUNA = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.Comuna);
            cobranzaMapper.POLIZA_GARANTIA_VIGENTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.PolizaGarantiaVigente);
            cobranzaMapper.NOMBRE_CONTACTO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.NombreContacto);
            cobranzaMapper.EMAIL = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.Email);
            cobranzaMapper.FORMA_PAGO = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.FormaPago);
            cobranzaMapper.TIPO_CUENTA = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.TipoCuenta);
            cobranzaMapper.NRO_CUENTA = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.NroCuenta);
            cobranzaMapper.BANCO = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.Banco);
            cobranzaMapper.ID_HOLDING = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.IdHolding) ?? 0;
            cobranzaMapper.ID_ADMINISTRADOR = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.IdAdministrador);
            cobranzaMapper.ID_EJECUTIVO_COBRANZA = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.IdEjecutivoCobranza);
            cobranzaMapper.ID_EJECUTIVO_COMERCIAL = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.IdEjecutivoComercial);
            cobranzaMapper.ID_EJECUTIVO_MOVIMIENTO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.IdEjecutivoMovimiento);
            cobranzaMapper.ID_AGRUPACION = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.IdAgrupacion) ?? 0;
            return cobranzaMapper;
        }

        public static IEnumerable<BrokerCcteDtoMapper> TransformarCcteDTOEnDtoMapper(BrokerDto brokerDto, int grupoFormulario)
        {
            List<BrokerCcteDtoMapper> listaCcte = new List<BrokerCcteDtoMapper>();
            BrokerCcteDtoMapper filial = new BrokerCcteDtoMapper();
            filial.ID_CCTE = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.IdFilial) ?? 0;
            filial.RUTCCTE = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.RutFilial) ?? 0;
            filial.DVCCTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.DvFilial);
            filial.NOMBRECCTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.NombreFilial);
            filial.GRUPOEMPRESAS = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.GrupoEmpresaFilial);
            filial.TELEFONO = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.TelefonFilial);
            filial.DIRECCION = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.DireccionFilialt);
            filial.COMUNA = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.ComunaFilial);
            filial.CIUDAD = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.CiudadFilial);
            filial.GIRO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.GiroFilial);
            filial.NOMBRE_CONTACTO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.NombreContactoFilial);
            filial.EMAIL = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.EmailFilial);
            filial.ID_TIPOCCTE = (int)TipoCcte.FILIAL;
            filial.ID_AGRUPACION = grupoFormulario;
            listaCcte.Add(filial);
            BrokerCcteDtoMapper Contratante = new BrokerCcteDtoMapper();
            Contratante.ID_CCTE = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.IdContratante) ?? 0;
            Contratante.RUTCCTE = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.RutContratante) ?? 0;
            Contratante.DVCCTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.DvContratante);
            Contratante.NOMBRECCTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.NombreContratante);
            Contratante.GRUPOEMPRESAS = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.GrupoEmpresaCont);
            Contratante.TELEFONO = MapperEstructurasUtilidades.ExtraerEntero(brokerDto.TelefonCont);
            Contratante.DIRECCION = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.DireccionCont);
            Contratante.COMUNA = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.ComunaCont);
            Contratante.CIUDAD = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.CiudadCont);
            Contratante.GIRO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.GiroCont);
            Contratante.NOMBRE_CONTACTO = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.NombreContactoCont);
            Contratante.EMAIL = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.EmailCont);
            Contratante.NOMBRE_MANDANTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.nombreMandante);
            Contratante.RUT_MANDANTE = MapperEstructurasUtilidades.ExtraerCadena(brokerDto.Direccion);
            Contratante.ID_AGRUPACION = grupoFormulario;
            Contratante.ID_TIPOCCTE = (int)TipoCcte.CONTRATANTE;
            listaCcte.Add(Contratante);
            return listaCcte;
        }
    }
}