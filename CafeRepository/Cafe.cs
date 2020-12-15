using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class Cafe

    {
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<string> listOfIngredients { get; set; }
        public decimal Price { get; set; }

        public Cafe() { }
        public Cafe(int itemNumber, string name, string description, List<string> listofingredients, decimal price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = description;
            listOfIngredients = listofingredients;
            Price = price;
        }
    }
}

