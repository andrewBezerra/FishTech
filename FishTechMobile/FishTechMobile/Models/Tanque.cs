using System;
using System.Collections.Generic;
using System.Text;

namespace FishTechMobile.Models
{
    public class Tanque
    {
        public int ID { get; set; }
        public String Descricao { get; set; }
        public Especie EspeciePeixe { get; set; }
        public DateTime DataEntrada { get; set; }
        public Produtor Produtor { get; set; }
        public Double Biomassa { get; set; }

    }
}
