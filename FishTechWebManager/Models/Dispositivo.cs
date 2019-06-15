using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string Ph { get; set; }
        public string Oxigenio { get; set; }
        public string Turbidez { get; set; }
    }
}
