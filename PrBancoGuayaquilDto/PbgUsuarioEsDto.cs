using Microsoft.EntityFrameworkCore;
using PrBancoGuayaquilDb;

namespace PrBancoGuayaquilDto
{
    public class PbgUsuarioEDto
    {

        public string Usuario { get; set; }

        public string Pass { get; set; }

    }

    public class PbgUsuarioSDto
    {
        public int Identificador { get; set; }

        public string Usuario { get; set; }

        public DateTime? FechaCreacion { get; set; }


    }
   
}
