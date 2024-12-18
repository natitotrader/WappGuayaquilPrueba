using System.ComponentModel.DataAnnotations;

namespace PrBancoGuayaquilDto
{
    public class PbgPersonaEDto
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string Email { get; set; }


    }

    public class sp_consulta_personaResultDto
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


    public class PbgPersonaConsultaEDto
    {
        public string CondicionBusqueda { get; set; }

        public string DatoBusqueda { get; set; }


    }
}
