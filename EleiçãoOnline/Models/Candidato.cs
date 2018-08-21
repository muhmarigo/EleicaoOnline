using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleiçãoOnline.Models
{
    public class Candidato
    {
        public int PoliticoId { get; set; }
        public Politico Politico { get; set; }
        public int EleiçãoId { get; set; }
        public Eleição Eleição { get; set; }
    }
}
