﻿using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General
{
    public class Respuesta 
    {
        public Boolean AlmacenadoCorrecto { get; set; }

        [JsonProperty(PropertyName = "cabecera")] 
        public CabeceraJsonDto Cabecera { get; set; }
    }
}
