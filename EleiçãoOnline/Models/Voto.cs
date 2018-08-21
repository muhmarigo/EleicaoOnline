using EleicaoOnline.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleicaoOnline.Models
{
    public class Voto
    {
        public int Id { get; set; }
        public string CPFEleitor { get; set; }
        public int? PoliticoId { get; set; }
        public int EleicaoId { get; set; }
        public TipoVoto Tipo { get; set; }
    }
}
