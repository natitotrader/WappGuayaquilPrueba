﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrBancoGuayaquilDb
{
    public partial class sp_consulta_personaResult
    {
        public int Identificador { get; set; }
        [StringLength(120)]
        public string Nombre { get; set; }
        [StringLength(120)]
        public string Apellido { get; set; }
        [StringLength(3)]
        public string TipoIdentificacion { get; set; }
        [StringLength(13)]
        public string NumeroIdentificacion { get; set; }
        [StringLength(120)]
        public string Email { get; set; }
        public DateTime? FechaCreacion { get; set; }
        [StringLength(241)]
        public string ConcatenaNombresApellidos { get; set; }
        [StringLength(17)]
        public string ConcatenaIdentificacionTipo { get; set; }
    }
}
