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

        public List<FoodItem> Menu { get; set; } = new List<FoodItem>(); // Use FoodItem directly
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
            orders.Add(order);            // add to internal list
            OrderQueue.Enqueue(order);    // add to queue
        }


        // Add food item to menu
        public void AddMenuItem(FoodItem item)
        {
            Menu.Add(item);
        }

        // Remove food item
        public bool RemoveMenuItem(FoodItem item)
        {
            return Menu.Remove(item);
        }

        // Display menu
        public void DisplayMenu()
        {
            foreach (var item in Menu)
            {
                Console.WriteLine(item); // make sure FoodItem has ToString()
            }
        }

        // Display special offers
        public void DisplaySpecialOffers()
        {
            foreach (var offer in specialOffers)
            {
                Console.WriteLine(offer);
            }
        }

        // Display orders
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



