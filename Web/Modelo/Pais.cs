using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboClima.Api.Modelo
{
    public class Pais
    {
        public string Nome { get; set; }
        public string Codigo { get; set; } // ISO code (ex: "BR")
        public long Populacao { get; set; }
        public string Capital { get; set; }
        public List<string> Idiomas { get; set; }
        public List<string> Moedas { get; set; }
        public string BandeiraUrl { get; set; }
    }
}
