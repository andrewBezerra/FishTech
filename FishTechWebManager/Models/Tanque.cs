using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager.Models
{
    public class Tanque
    {
        public int Id { get; set; }
        public Dispositivo Dispositivo { get; set; }
        public Atividade Atividade { get; set; }
        public Produtor Produtor { get; set; }
        public Medicao Medicao { get; set; }
        public Informacoes Informacoes { get; set; }
    }
}
