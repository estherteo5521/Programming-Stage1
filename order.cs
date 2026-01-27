using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruberooapp
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public string RestaurantId { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItem> Items { get; set; }   // initialize in constructor
        public string SpecialRequest { get; set; }
        public double Total { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        // Constructor
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(int id, string status) : this()
        {
            Id = id;
            Status = status;
        }

        // Calculate total including delivery fee ($5)
        public void CalculateTotal()
        {
            Total = Items.Sum(i => i.Subtotal()) + 5.0;
        }

        // Display basic info
        public string BasicInfo() => $"{Id,-6} {Total,-8:C} {Status}";

        // Display detailed info
        public string Detail()
        {
            string itemsDetail = string.Join(", ", Items.Select(i => $"{i.Item.Name} x{i.Quantity}"));
            return $"Order {Id} | Status: {Status} | Total: ${Total:F2} | Items: {itemsDetail}";
        }

        // Export order to CSV
        public string ToCsv()
        {
            string itemsCsv = string.Join(";", Items.Select(i => $"{i.Item.Name}x{i.Quantity}"));
            return $"{Id},{CustomerEmail},{RestaurantId},{DeliveryDate},{DeliveryTime},{DeliveryAddress},{itemsCsv},{SpecialRequest},{Total},{PaymentMethod},{Status}";
        }
    }
}
