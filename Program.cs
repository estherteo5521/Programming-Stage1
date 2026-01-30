// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using Gruberooapp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Gruberoo
{
    class Program
    {
        //static List<Restaurant> restaurants = new();
        //static List<Customer> customers = new();
        //static List<Order> orders = new();

        static void Main()
        {
            LoadRestaurantsAndFoodItems();
            LoadCustomersAndOrders();

            Console.WriteLine("Welcome to the Gruberoo Food Delivery System");
            Console.WriteLine($"{restaurants.Count} restaurants loaded!");

           
            int foodItemCount = 0;
            foreach (var r in restaurants)
            {
                foodItemCount += r.Menu.Count;
            }
            Console.WriteLine($"{foodItemCount} food items loaded!");

            Console.WriteLine($"{customers.Count} customers loaded!");
            Console.WriteLine($"{orders.Count} orders loaded!");

            ShowMenu();
        }


        // ================= LOAD PART 1 =================
        // Restaurants + Food Items

        static void LoadRestaurantsAndFoodItems()
        {
            // ===== Load Restaurants =====
            foreach (var line in File.ReadAllLines("restaurants.csv").Skip(1))
            {
                var p = line.Split(',');

                // Make sure there are enough columns (Id, Name, Email)
                if (p.Length < 3)
                {
                    Console.WriteLine("Skipping invalid restaurant line: " + line);
                    continue;
                }

                restaurants.Add(new Restaurant(p[0], p[1], p[2]));
            }

            // ===== Load Food Items =====
            foreach (var line in File.ReadAllLines("fooditems-copy.csv").Skip(1))
            {
                var p = line.Split(',');

                if (p.Length < 4) continue; 

                Restaurant r = restaurants.FirstOrDefault(x => x.RestaurantId == p[0].Trim());
                if (r == null) continue;

                if (!double.TryParse(p[3].Trim(), out double price)) continue;

                FoodItem f;

                if (p.Length >= 5) 
                    f = new FoodItem(p[1].Trim(), p[2].Trim(), price, p[4].Trim());
                else 
                    f = new FoodItem(p[1].Trim(), p[2].Trim(), price); 

                r.AddMenuItem(f);
            }


        }


        

        // ================= MENU =================

        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Gruberoo Food Delivery System =====");
                Console.WriteLine("1. List all restaurants and menu items");
                Console.WriteLine("2. List all orders");
                Console.WriteLine("3. Create a new order");
                Console.WriteLine("4. Process an order");
                Console.WriteLine("5. Modify an existing order");
                Console.WriteLine("6. Delete an existing order");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ListAllRestaurantsAndMenu();
                        break;
                    case "2":
                        //ListAllOrders();
                        break;
                    case "3":
                       // CreateNewOrder();
                        break;
                    case "4":
                       // ProcessOrders();
                        break;
                    case "5":
                        //ModifyOrder();
                        break;
                    case "6":
                        // Delete order
                        break;
                    case "0":
                        //Console.WriteLine("Exiting...");
                        return;
                    default:
                        //Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        // ================= OPTION 1 =================
        static void ListAllRestaurantsAndMenu()
        {
            Console.WriteLine("All Restaurants and Menu Items");
            Console.WriteLine("==============================");

            foreach (var r in restaurants)
            {
                Console.WriteLine($"Restaurant: {r.RestaurantName} ({r.RestaurantId})");

                if (r.Menu.Count == 0)
                {
                    Console.WriteLine("- No menu items available");
                    continue;
                }

                foreach (var item in r.Menu)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description} - ${item.Price:F2}");
                }

                Console.WriteLine(); 
            }
        }
    





        
    }
    }

