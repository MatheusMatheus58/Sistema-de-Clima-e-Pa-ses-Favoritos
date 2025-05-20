using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboClima.Api.Modelo
{
    public class Favorito
    {
        public string Id { get; set; } // Pode ser um GUID
        public string UsuarioId { get; set; }
        public string Tipo { get; set; } // "cidade" ou "pais"
        public string Nome { get; set; } // Nome da cidade ou país
        public DateTime CriadoEm { get; set; }
    }
}
