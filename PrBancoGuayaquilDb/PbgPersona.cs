﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PrBancoGuayaquilDb;

public partial class PbgPersona
{
    public int Identificador { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string TipoIdentificacion { get; set; }

    public string NumeroIdentificacion { get; set; }

    public string Email { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string ConcatenaNombresApellidos { get; set; }

    public string ConcatenaIdentificacionTipo { get; set; }
}