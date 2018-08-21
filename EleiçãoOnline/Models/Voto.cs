using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleiçãoOnline.Models
{
    public class Voto
    {
        public int Id { get; set; }
        public string CPFEleitor { get; set; }
        public int? PoliticoId { get; set; }
        public int EleiçãoId { get; set; }
        public Eleição Eleição { get; set; }
        public Enums.TipoVoto Tipo { get; set; }
    }
}
