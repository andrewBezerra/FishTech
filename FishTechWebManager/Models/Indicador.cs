using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager.Models
{
    public class Indicador
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public double FaixaDe { get; set; }
        public double FaixaAte { get; set; }
        public double PontoOtimo { get; set; }
        public Especie Especie { get; set; }
    }
}
