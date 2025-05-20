using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboClima.Api.Modelo
{
    public class Clima
    {
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Descricao { get; set; } // Ex: "nublado"
        public double Temperatura { get; set; } // Em Celsius
        public int Umidade { get; set; } // Em porcentagem
        public double VelocidadeVento { get; set; } // Em m/s
    }
}