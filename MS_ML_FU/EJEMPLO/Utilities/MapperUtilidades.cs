using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJEMPLO.Utilities
{
    public class MapperUtilidades
    {

        public static ObjetoEntity TransformarDTOEnEntity(ObjetoDTO dto)
        {
            ObjetoEntity entity = new ObjetoEntity();
            entity.Nombres = MapperEstructurasUtilidades.ExtraerCadena(dto.Nombres);
            entity.Apellidos = MapperEstructurasUtilidades.ExtraerCadena(dto.Apellidos);
            entity.Rut = MapperEstructurasUtilidades.ExtraerEntero(dto.Rut);
            entity.FechaNacimiento = MapperEstructurasUtilidades.ExtraerFecha(dto.FechaNacimiento);
            return entity;
        }

        public static ObjetoDTO TransformarEntityEnDTO(ObjetoEntity entity, int atribPes)
        {
            ObjetoDTO dto = new ObjetoDTO();
            dto.Nombres = MapperEstructurasUtilidades.CrearCadenaDTO(entity.Nombres, atribPes,null);
            dto.Apellidos = MapperEstructurasUtilidades.CrearCadenaDTO(entity.Apellidos, atribPes, null);
            dto.Rut = MapperEstructurasUtilidades.CrearEnteroDTO(entity.Rut, atribPes, null);
            dto.FechaNacimiento = MapperEstructurasUtilidades.CrearFechaDTO(entity.FechaNacimiento, atribPes, null);
            return dto;
        }

    }
}