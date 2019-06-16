using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager.Models
{
    public class Medicao
    {
        public int Id { get; set; }
        public float Medida { get; set; }
        public Indicador Indicador { get; set; }
       
    }
}
