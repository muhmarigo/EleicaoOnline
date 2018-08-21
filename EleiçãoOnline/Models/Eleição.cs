using EleiçãoOnline.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleiçãoOnline.Models
{
    public class Eleição
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Pais { get; set; }
        public Cargo Cargo { get; set; }
        public ICollection<Candidato> Candidatos { get; set; }
        public ICollection<Voto> Votos { get; set; }
    }

}
