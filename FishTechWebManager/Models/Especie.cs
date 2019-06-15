using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager.Models
{
    public class Especie
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Tanque Tanque { get; set; }
    }
}
