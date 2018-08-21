using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleicaoOnline.Models
{
    public class Candidato
    {
        public int PoliticoId { get; set; }
        public Politico Politico { get; set; }
        public int EleicaoId { get; set; }
    }
}
