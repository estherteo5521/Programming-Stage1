using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruberooapp
{
    public class FoodItem
    {
        public string ItemName { get; set; }         
        public string ItemDesc { get; set; }
        public double ItemPrice { get; set; }       
        public string Customise { get; set; }

        
        public FoodItem(string itemname, string itemdesc, double itemprice, string cust)
        {
            Name = name;
            Description = description;
            Price = price;
            Customise = "";
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

