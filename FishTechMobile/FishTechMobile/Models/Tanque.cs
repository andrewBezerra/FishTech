using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        public String DescricaoEspecie { get => EspeciePeixe.Descricao; }

        public string OD { get; set; }
        public float Temp { get; set; }
        public float Ph { get; set; }
        public float Turbidez { get; set; }

        public Tanque()
        {
            
            OD = RandomNumber.Between(10, 30).ToString() + "mg/l";
           
            Temp = RandomNumber.Between(27, 39);
          
            Ph = RandomNumber.Between(5, 14);
          
            Turbidez = RandomNumber.Between(1, 5);
        }
    }

    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int Between(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }
    }
}
