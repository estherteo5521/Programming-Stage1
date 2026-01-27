using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruberooapp
{
    public class FoodItem
    {
        public string Name { get; set; }         // Make sure property is Name
        public string Description { get; set; }
        public double Price { get; set; }        // Make sure property is double
        public string Customise { get; set; }

        // Constructor without Customise
        public FoodItem(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
            Customise = "";
        }

        // Constructor with Customise
        public FoodItem(string name, string description, double price, string customise)
        {
            Name = name;
            Description = description;
            Price = price;
            Customise = customise;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Customise))
                return $"{Name} - {Description} (${Price:F2})";
            else
                return $"{Name} - {Description} (${Price:F2}) Customise: {Customise}";
        }
    }
}

