using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleiçãoOnline.Models
{
    public class Politico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int PartidoId { get; set; }
        public Partido Partido { get; set; }
    }
}
