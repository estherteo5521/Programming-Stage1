using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruberooapp
{
    public class OrderItem
    {
        public FoodItem Item { get; set; }
        public int Quantity { get; set; }

        public OrderItem(FoodItem item, int quantity)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Item = item;
            Quantity = quantity;
        }

        // Safe Subtotal calculation
        public double Subtotal()
        {
            return Item.Price * Quantity; // guaranteed to exist
        }

        public override string ToString()
        {
            return $"{Item.Name} x {Quantity} = ${Subtotal():F2}";
        }
    }




}






