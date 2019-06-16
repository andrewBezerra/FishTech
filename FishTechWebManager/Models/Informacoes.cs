using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager.Models
{
    public class Informacoes
    {
        public int Id { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Termino { get; set; }

        public double Area { get; set; }

        public int NumeroPeixes { get; set; }

        public string FaseDesenvolvimento { get; set; }

        public string TipoDeRacao { get; set; }

        public double GranulometriaRacao { get; set; }

        public double? Biomassa { get; set; }

    }

}
