using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruberooapp
{
    public class Menu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }

        private List<FoodItem> foodItems = new List<FoodItem>();

        public Menu(string id, string name)
        {
            MenuId = id;
            MenuName = name;
        }

        public int FoodItemCount
        {
            get { return foodItems.Count; }
        }

        public void AddFoodItem(FoodItem item)
        {
            foodItems.Add(item);
        }

        public bool RemoveFoodItem(FoodItem item)
        {
            return foodItems.Remove(item);
        }

        public void DisplayFoodItems()
        {
            foreach (var item in foodItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override string ToString()
        {
            return $"Menu: {MenuName} ({MenuId})";
        }
    }
}

