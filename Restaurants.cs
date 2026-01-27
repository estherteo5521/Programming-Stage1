using Gruberooapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruberooapp
{
    public class Restaurant
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantEmail { get; set; }

        public List<FoodItem> Menu { get; set; } = new List<FoodItem>(); 
        private List<SpecialOffer> specialOffers = new List<SpecialOffer>();
        private List<Order> orders = new List<Order>();
        public Queue<Order> OrderQueue { get; set; } = new Queue<Order>();

        public Restaurant(string restid, string restname, string restemail)
        {
            RestaurantId = id;
            RestaurantName = name;
            RestaurantEmail = email;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);            
            OrderQueue.Enqueue(order);    
        }


        
        public void AddMenuItem(FoodItem item)
        {
            Menu.Add(item);
        }

      
        public bool RemoveMenuItem(FoodItem item)
        {
            return Menu.Remove(item);
        }

   
        public void DisplayMenu()
        {
            foreach (var item in Menu)
            {
                Console.WriteLine(item); 
            }
        }

        
        public void DisplaySpecialOffers()
        {
            foreach (var offer in specialOffers)
            {
                Console.WriteLine(offer);
            }
        }

        
        public void DisplayOrders()
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        public override string ToString()
        {
            return $"{RestaurantName} ({RestaurantEmail})";
        }
    }

}



