using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DU1
{
    public class Product
    {
        public required string Name { get; set;}
        public required double Price { get; set;}
        public int? Quantity { get; set;}
        public Weight ProductWeight { get; set; }
        public struct Weight
        {
            public double Value { get; set; }
            public Unit Unit { get; set; }
        }

        public string Write()
        {
            string quantityText = string.Empty;
            if (Quantity.HasValue) {
                quantityText = Quantity.Value.ToString() + " ks";
            }
            else
            {
                quantityText = "neznámé množství";
            }

            string weightText = $"{ProductWeight.Value} {ProductWeight.Unit}";

            return string.Format("{0} {1}; {2} Kč", Name, quantityText, Price);
        }


    }
}



