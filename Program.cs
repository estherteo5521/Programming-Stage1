// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using Gruberooapp;

//namespace Gruberooapp
//{
//    public class Program
//    {
//        static List<Restaurant> restaurants = new List<Restaurant>();
//        static List<Customer> customers = new List<Customer>();
//        static int nextOrderId = 1004; // Starting Order ID for new orders

//        static void Main(string[] args)
//        {
//            // -------------------------------
//            // 1) Sample Restaurants & Menus
//            // -------------------------------
//            InitializeSampleRestaurants();

//            // -------------------------------
//            // 2) Sample Customers & Orders
//            // -------------------------------
//            InitializeSampleCustomersAndOrders();

//            // -------------------------------
//            // 3) Display all restaurants and menus
//            // -------------------------------
//            DisplayRestaurantsAndMenus();

//            // -------------------------------
//            // 4) Display all orders
//            // -------------------------------
//            DisplayAllOrders();

//            // -------------------------------
//            // 5) Create new order interactively
//            // -------------------------------
//            CreateNewOrder();

//            // -------------------------------
//            // 6) Display updated orders
//            // -------------------------------
//            DisplayAllOrders();
//        }

//        static void InitializeSampleRestaurants()
//        {
//            var grillHouse = new Restaurant("R001", "Grill House", "grillhouse@example.com");
//            var grillMenu = new Menu("M001", "Main Menu");
//            grillMenu.AddFoodItem(new FoodItem("Chicken Rice", "Steamed chicken with fragrant rice", 5.50, ""));
//            grillMenu.AddFoodItem(new FoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, ""));
//            grillMenu.AddFoodItem(new FoodItem("Caesar Salad", "Romaine lettuce with house dressing", 7.00, ""));
//            grillHouse.AddMenu(grillMenu);
//            restaurants.Add(grillHouse);

//            var noodlePalace = new Restaurant("R002", "Noodle Palace", "noodlepalace@example.com");
//            var noodleMenu = new Menu("M002", "Main Menu");
//            noodleMenu.AddFoodItem(new FoodItem("Spicy Ramen", "House-special broth with chilli oil", 11.20, ""));
//            noodlePalace.AddMenu(noodleMenu);
//            restaurants.Add(noodlePalace);
//        }

//        static void InitializeSampleCustomersAndOrders()
//        {
//            var alice = new Customer("alice@example.com", "Alice Tan");
//            var joseph = new Customer("joseph@example.com", "Joseph Lim");
//            var wendy = new Customer("wendy@example.com", "Wendy Ong");
//            customers.Add(alice);
//            customers.Add(joseph);
//            customers.Add(wendy);

//            // Sample orders (same as before)
//            var order1 = new Order(1001)
//            {
//                OrderStatus = "Delivered",
//                DeliveryDateTime = DateTime.Parse("12/02/2026 12:00"),
//                OrderPaid = true
//            };
//            order1.AddOrderedFoodItem(new OrderedFoodItem("Chicken Rice", "Steamed chicken with fragrant rice", 5.50, "", 2));
//            order1.AddOrderedFoodItem(new OrderedFoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, "", 2));
//            alice.AddOrder(order1);
//            restaurants[0].AddOrder(order1); // Grill House

//            var order2 = new Order(1002)
//            {
//                OrderStatus = "Cancelled",
//                DeliveryDateTime = DateTime.Parse("13/02/2026 18:30"),
//                OrderPaid = false
//            };
//            order2.AddOrderedFoodItem(new OrderedFoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, "", 1));
//            order2.AddOrderedFoodItem(new OrderedFoodItem("Caesar Salad", "Romaine lettuce with house dressing", 7.00, "", 2));
//            joseph.AddOrder(order2);
//            restaurants[0].AddOrder(order2); // Grill House

//            var order3 = new Order(1003)
//            {
//                OrderStatus = "Preparing",
//                DeliveryDateTime = DateTime.Parse("14/02/2026 19:00"),
//                OrderPaid = false
//            };
//            order3.AddOrderedFoodItem(new OrderedFoodItem("Spicy Ramen", "House-special broth with chilli oil", 11.20, "", 1));
//            wendy.AddOrder(order3);
//            restaurants[1].AddOrder(order3); // Noodle Palace
//        }

//        static void DisplayRestaurantsAndMenus()
//        {
//            Console.WriteLine("All Restaurants and Menu Items");
//            Console.WriteLine("==============================");
//            foreach (var restaurant in restaurants)
//            {
//                Console.WriteLine($"Restaurant: {restaurant.RestaurantName} ({restaurant.RestaurantId})");
//                foreach (var menu in restaurant.GetMenus())
//                {
//                    foreach (var item in menu.GetFoodItems())
//                    {
//                        Console.WriteLine($"  - {item.ItemName}: {item.ItemDesc} - ${item.ItemPrice:F2}");
//                    }
//                }
//            }
//            Console.WriteLine();
//        }

//        static void DisplayAllOrders()
//        {
//            Console.WriteLine("All Orders");
//            Console.WriteLine("==========");
//            Console.WriteLine($"{"Order ID",-10}{"Customer",-15}{"Restaurant",-15}{"Delivery Date/Time",-20}{"Amount",-10}{"Status",-12}");

//            foreach (var customer in customers)
//            {
//                foreach (var order in customer.GetOrders())
//                {
//                    // Find restaurant
//                    Restaurant restaurantForOrder = null;
//                    foreach (var resto in restaurants)
//                        if (resto.HasOrder(order))
//                        {
//                            restaurantForOrder = resto;
//                            break;
//                        }

//                    Console.WriteLine(
//                        $"{order.OrderId,-10}" +
//                        $"{customer.CustomerName,-15}" +
//                        $"{restaurantForOrder?.RestaurantName,-15}" +
//                        $"{order.DeliveryDateTime:dd/MM/yyyy HH:mm,-20}" +
//                        $"${order.OrderTotal:F2,-10}" +
//                        $"{order.OrderStatus,-12}"
//                    );
//                }
//            }
//            Console.WriteLine();
//        }

//        static void CreateNewOrder()
//        {
//            Console.WriteLine("Create New Order");
//            Console.WriteLine("================");

//            // 1) Customer Email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine();
//            Customer customer = customers.Find(c => c.EmailAddress == custEmail);
//            if (customer == null)
//            {
//                Console.WriteLine("Customer not found!");
//                return;
//            }

//            // 2) Restaurant ID
//            Console.Write("Enter Restaurant ID: ");
//            string restId = Console.ReadLine();
//            Restaurant restaurant = restaurants.Find(r => r.RestaurantId == restId);
//            if (restaurant == null)
//            {
//                Console.WriteLine("Restaurant not found!");
//                return;
//            }

//            // 3) Delivery Date/Time
//            Console.Write("Enter Delivery Date (dd/mm/yyyy): ");
//            string dateStr = Console.ReadLine();
//            Console.Write("Enter Delivery Time (hh:mm): ");
//            string timeStr = Console.ReadLine();
//            if (!DateTime.TryParseExact(dateStr + " " + timeStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDT))
//            {
//                Console.WriteLine("Invalid date/time format!");
//                return;
//            }

//            // 4) Delivery Address
//            Console.Write("Enter Delivery Address: ");
//            string address = Console.ReadLine();

//            // 5) Create new order
//            Order newOrder = new Order(nextOrderId++)
//            {
//                DeliveryDateTime = deliveryDT,
//                DeliveryAddress = address,
//                OrderStatus = "Pending"
//            };

//            // 6) Display available food items
//            Console.WriteLine("Available Food Items:");
//            List<FoodItem> foodItems = new List<FoodItem>();
//            int idx = 1;
//            foreach (var menu in restaurant.GetMenus())
//                foreach (var item in menu.GetFoodItems())
//                {
//                    Console.WriteLine($"{idx}. {item.ItemName} - ${item.ItemPrice:F2}");
//                    foodItems.Add(item);
//                    idx++;
//                }

//            // 7) Select items
//            while (true)
//            {
//                Console.Write("Enter item number (0 to finish): ");
//                if (!int.TryParse(Console.ReadLine(), out int itemNum) || itemNum < 0 || itemNum > foodItems.Count)
//                {
//                    Console.WriteLine("Invalid number!");
//                    continue;
//                }
//                if (itemNum == 0) break;

//                Console.Write("Enter quantity: ");
//                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
//                {
//                    Console.WriteLine("Invalid quantity!");
//                    continue;
//                }

//                FoodItem selectedItem = foodItems[itemNum - 1];
//                newOrder.AddOrderedFoodItem(new OrderedFoodItem(selectedItem.ItemName, selectedItem.ItemDesc, selectedItem.ItemPrice, selectedItem.Customise, qty));
//            }

//            // 8) Special request
//            Console.Write("Add special request? [Y/N]: ");
//            string specialReqAnswer = Console.ReadLine().Trim().ToUpper();
//            if (specialReqAnswer == "Y")
//            {
//                Console.Write("Enter special request: ");
//                string specialReq = Console.ReadLine();
//                foreach (var item in newOrder.GetOrderedItems())
//                {
//                    item.Customise = specialReq;
//                }
//            }

//            // 9) Calculate order total (+$5 delivery)
//            double deliveryFee = 5.00;
//            double orderTotal = newOrder.CalculateOrderTotal() + deliveryFee;
//            Console.WriteLine($"Order Total: ${newOrder.OrderTotal:F2} + ${deliveryFee:F2} (delivery) = ${orderTotal:F2}");

//            // 10) Payment
//            Console.Write("Proceed to payment? [Y/N]: ");
//            string payAnswer = Console.ReadLine().Trim().ToUpper();
//            if (payAnswer == "Y")
//            {
//                Console.WriteLine("Payment method:");
//                Console.Write("[CC] Credit Card / [PP] PayPal / [CD] Cash on Delivery: ");
//                string paymentMethod = Console.ReadLine().Trim().ToUpper();
//                newOrder.OrderPaymentMethod = paymentMethod;
//                newOrder.OrderPaid = true;
//            }

//            // 11) Add to customer & restaurant
//            customer.AddOrder(newOrder);
//            restaurant.AddOrder(newOrder);

//            // 12) Save to orders.csv
//            string csvLine = $"{newOrder.OrderId},{customer.EmailAddress},{restaurant.RestaurantId},{newOrder.DeliveryDateTime:dd/MM/yyyy HH:mm},{newOrder.OrderPaid},{newOrder.OrderStatus}";
//            File.AppendAllText("orders.csv", csvLine + Environment.NewLine);

//            // 13) Confirmation
//            Console.WriteLine($"Order {newOrder.OrderId} created successfully! Status: {newOrder.OrderStatus}");
//        }



//    }
//}
// Next 

//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using Gruberooapp;
//using System.Linq;


//namespace Gruberooapp
//{
//    public class Program
//    {


//        static List<Restaurant> restaurants = new List<Restaurant>();
//        static List<Customer> customers = new List<Customer>();
//        static List<Order> orders = new List<Order>();
//        static int nextOrderId = 1004; // next order ID
//        static Stack<Order> refundStack = new Stack<Order>();


//        static void Main(string[] args)
//        {
//            // Initialize sample data
//            InitializeSampleRestaurants();
//            InitializeSampleCustomersAndOrders();

//            // Display restaurants & menu items
//            DisplayRestaurantsAndMenus();

//            // Display all orders
//            DisplayAllOrders();

//            // Create a new order interactively
//            CreateNewOrder();

//            // Display updated orders
//            DisplayAllOrders();

//            // Process orders for a restaurant
//            ProcessOrders();
//        }

//        // -------------------------
//        // Initialization
//        // -------------------------
//        static void InitializeSampleRestaurants()
//        {
//            var grillHouse = new Restaurant("R001", "Grill House", "grillhouse@example.com");
//            var grillMenu = new Menu("M001", "Main Menu");
//            grillMenu.AddFoodItem(new FoodItem("Chicken Rice", "Steamed chicken with fragrant rice", 5.50, ""));
//            grillMenu.AddFoodItem(new FoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, ""));
//            grillMenu.AddFoodItem(new FoodItem("Caesar Salad", "Romaine lettuce with house dressing", 7.00, ""));
//            grillHouse.AddMenu(grillMenu);
//            restaurants.Add(grillHouse);

//            var noodlePalace = new Restaurant("R002", "Noodle Palace", "noodlepalace@example.com");
//            var noodleMenu = new Menu("M002", "Main Menu");
//            noodleMenu.AddFoodItem(new FoodItem("Spicy Ramen", "House-special broth with chilli oil", 11.20, ""));
//            noodlePalace.AddMenu(noodleMenu);
//            restaurants.Add(noodlePalace);
//        }

//        static void InitializeSampleCustomersAndOrders()
//        {
//            var alice = new Customer("alice.tan@email.com", "Alice Tan");
//            var joseph = new Customer("joseph.lim@email.com", "Joseph Lim");
//            var wendy = new Customer("wendy.ong@email.com", "Wendy Ong");
//            customers.Add(alice);
//            customers.Add(joseph);
//            customers.Add(wendy);

//            // Sample orders
//            var order1 = new Order(1001)
//            {
//                OrderStatus = "Delivered",
//                DeliveryDateTime = DateTime.Parse("12/02/2026 12:00"),
//                OrderPaid = true
//            };
//            order1.AddOrderedFoodItem(new OrderedFoodItem("Chicken Rice", "Steamed chicken with fragrant rice", 5.50, "", 2));
//            order1.AddOrderedFoodItem(new OrderedFoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, "", 2));
//            alice.AddOrder(order1);
//            restaurants[0].AddOrder(order1);

//            var order2 = new Order(1002)
//            {
//                OrderStatus = "Cancelled",
//                DeliveryDateTime = DateTime.Parse("13/02/2026 18:30"),
//                OrderPaid = false
//            };
//            order2.AddOrderedFoodItem(new OrderedFoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, "", 1));
//            order2.AddOrderedFoodItem(new OrderedFoodItem("Caesar Salad", "Romaine lettuce with house dressing", 7.00, "", 2));
//            joseph.AddOrder(order2);
//            restaurants[0].AddOrder(order2);

//            var order3 = new Order(1003)
//            {
//                OrderStatus = "Preparing",
//                DeliveryDateTime = DateTime.Parse("14/02/2026 19:00"),
//                OrderPaid = false
//            };
//            order3.AddOrderedFoodItem(new OrderedFoodItem("Spicy Ramen", "House-special broth with chilli oil", 11.20, "", 1));
//            wendy.AddOrder(order3);
//            restaurants[1].AddOrder(order3);
//        }

//        // -------------------------
//        // Display restaurants
//        // -------------------------
//        static void DisplayRestaurantsAndMenus()
//        {
//            Console.WriteLine("All Restaurants and Menu Items");
//            Console.WriteLine("==============================");
//            foreach (var restaurant in restaurants)
//            {
//                Console.WriteLine($"Restaurant: {restaurant.RestaurantName} ({restaurant.RestaurantId})");
//                foreach (var menu in restaurant.GetMenus())
//                    foreach (var item in menu.GetFoodItems())
//                        Console.WriteLine($"  - {item.ItemName}: {item.ItemDesc} - ${item.ItemPrice:F2}");
//            }
//            Console.WriteLine();
//        }

//        // -------------------------
//        // Display all orders
//        // -------------------------
//        static void DisplayAllOrders()
//        {
//            Console.WriteLine("All Orders");
//            Console.WriteLine("==========");
//            Console.WriteLine($"{"Order ID",-10}{"Customer",-15}{"Restaurant",-15}{"Delivery Date/Time",-20}{"Amount",-10}{"Status",-12}");

//            foreach (var customer in customers)
//            {
//                foreach (var order in customer.GetOrders())
//                {
//                    Restaurant restaurantForOrder = null;
//                    foreach (var resto in restaurants)
//                        if (resto.HasOrder(order))
//                        {
//                            restaurantForOrder = resto;
//                            break;
//                        }

//                    Console.WriteLine(
//                        $"{order.OrderId,-10}" +
//                        $"{customer.CustomerName,-15}" +
//                        $"{restaurantForOrder?.RestaurantName,-15}" +
//                        $"{order.DeliveryDateTime:dd/MM/yyyy HH:mm,-20}" +
//                        $"${order.OrderTotal:F2,-10}" +
//                        $"{order.OrderStatus,-12}"
//                    );
//                }
//            }
//            Console.WriteLine();
//        }

//        // -------------------------
//        // Create new order
//        // -------------------------
//        static void CreateNewOrder()
//        {
//            Console.WriteLine("Create New Order");
//            Console.WriteLine("================");

//            // 1) Enter Customer Email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine().Trim().ToLower();

//            Customer customer = customers.Find(c => c.EmailAddress.ToLower() == custEmail);

//            if (customer == null)
//            {
//                Console.WriteLine("Customer not found. Please register customer first.");
//                return;
//            }

//            // 2) Enter Restaurant ID
//            Console.Write("Enter Restaurant ID: ");
//            string restoId = Console.ReadLine().Trim();
//            Restaurant restaurant = restaurants.Find(r => r.RestaurantId == restoId);
//            if (restaurant == null)
//            {
//                Console.WriteLine("Restaurant not found.");
//                return;
//            }

//            // 3) Delivery Date
//            Console.Write("Enter Delivery Date (dd/MM/yyyy): ");
//            string dateInput = Console.ReadLine();
//            if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDate))
//            {
//                Console.WriteLine("Invalid date format.");
//                return;
//            }

//            // 4) Delivery Time
//            Console.Write("Enter Delivery Time (hh:mm): ");
//            string timeInput = Console.ReadLine();
//            if (!DateTime.TryParseExact(dateInput + " " + timeInput, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDateTime))
//            {
//                Console.WriteLine("Invalid time format.");
//                return;
//            }

//            // 5) Delivery Address
//            Console.Write("Enter Delivery Address: ");
//            string deliveryAddress = Console.ReadLine();

//            // 6) Display available food items
//            List<FoodItem> foodItems = new List<FoodItem>();
//            foreach (var menu in restaurant.GetMenus())
//                foodItems.AddRange(menu.GetFoodItems());

//            Console.WriteLine("Available Food Items:");
//            int idx = 1;
//            foreach (var item in foodItems)
//                Console.WriteLine($"{idx}. {item.ItemName} - ${item.ItemPrice:F2}");

//            // 7) Select food items
//            List<OrderedFoodItem> orderedItems = new List<OrderedFoodItem>();
//            while (true)
//            {
//                Console.Write("Enter item number (0 to finish): ");
//                if (!int.TryParse(Console.ReadLine(), out int itemNo) || itemNo < 0 || itemNo > foodItems.Count) continue;
//                if (itemNo == 0) break;

//                FoodItem selectedItem = foodItems[itemNo - 1];

//                Console.Write("Enter quantity: ");
//                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0) continue;

//                orderedItems.Add(new OrderedFoodItem(selectedItem.ItemName, selectedItem.ItemDesc, selectedItem.ItemPrice, selectedItem.Customise, qty));
//            }

//            // 8) Special request
//            Console.Write("Add special request? [Y/N]: ");
//            string special = Console.ReadLine().Trim().ToUpper();
//            string specialRequest = "";
//            if (special == "Y")
//            {
//                Console.Write("Enter special request: ");
//                specialRequest = Console.ReadLine();
//            }

//            // 9) Create new Order
//            int newOrderId = orders.Any() ? orders.Max(o => o.OrderId) + 1 : 1001;
//            Order newOrder = new Order(newOrderId)
//            {
//                DeliveryAddress = deliveryAddress,
//                DeliveryDateTime = deliveryDateTime,
//                OrderStatus = "Pending"
//            };

//            // Add items
//            foreach (var oItem in orderedItems)
//                newOrder.AddOrderedFoodItem(oItem);

//            // Optional: add special request as one FoodItem
//            if (!string.IsNullOrEmpty(specialRequest))
//                newOrder.AddOrderedFoodItem(new OrderedFoodItem("Special Request", specialRequest, 0, "", 1));

//            // 10) Calculate total + delivery
//            double deliveryFee = 5.0;
//            double totalAmount = newOrder.CalculateOrderTotal() + deliveryFee;
//            Console.WriteLine($"Order Total: ${newOrder.OrderTotal:F2} + ${deliveryFee:F2} (delivery) = ${totalAmount:F2}");

//            // 11) Payment
//            Console.Write("Proceed to payment? [Y/N]: ");
//            string payChoice = Console.ReadLine().Trim().ToUpper();
//            if (payChoice == "Y")
//            {
//                Console.WriteLine("Payment method:");
//                Console.Write("[CC] Credit Card / [PP] PayPal / [CD] Cash on Delivery: ");
//                string method = Console.ReadLine().Trim().ToUpper();
//                newOrder.OrderPaymentMethod = method;
//                newOrder.OrderPaid = true;
//            }
//            else
//            {
//                Console.WriteLine("Order not paid. Exiting.");
//                return;
//            }

//            // 12) Add to Restaurant and Customer
//            restaurant.AddOrder(newOrder);
//            customer.AddOrder(newOrder);
//            orders.Add(newOrder);

//            // 13) Confirmation
//            Console.WriteLine($"Order {newOrder.OrderId} created successfully! Status: {newOrder.OrderStatus}");
//        }


//        // -------------------------
//        // Process Orders
//        // -------------------------
//        static void ProcessOrders()
//        {
//            Console.WriteLine("Process Order");
//            Console.WriteLine("=============");

//            // 1) Prompt for Restaurant ID
//            Console.Write("Enter Restaurant ID: ");
//            string restoId = Console.ReadLine().Trim();

//            // 2) Find restaurant
//            Restaurant restaurant = restaurants.Find(r => r.RestaurantId == restoId);
//            if (restaurant == null)
//            {
//                Console.WriteLine("Restaurant not found!");
//                return;
//            }

//            // 3) Get orders for this restaurant
//            var restaurantOrders = restaurant.GetOrders().Where(o => o.OrderStatus != "Delivered").ToList();
//            if (restaurantOrders.Count == 0)
//            {
//                Console.WriteLine("No pending or preparing orders for this restaurant.");
//                return;
//            }

//            foreach (var order in restaurantOrders)
//            {
//                // Find the customer
//                Customer customer = customers.Find(c => c.GetOrders().Contains(order));

//                // Display order info
//                Console.WriteLine($"Order {order.OrderId}:  ");
//                Console.WriteLine($"Customer: {customer.CustomerName}");
//                Console.WriteLine("Ordered Items:");
//                int i = 1;
//                foreach (var item in order.GetOrderedItems())
//                    Console.WriteLine($"{i++}. {item.ItemName} - {item.QtyOrdered}");
//                Console.WriteLine($"Delivery date/time: {order.DeliveryDateTime:dd/MM/yyyy  HH:mm}");
//                Console.WriteLine($"Total Amount:  ${order.OrderTotal + 5:F2}"); // include delivery fee
//                Console.WriteLine($"Order Status: {order.OrderStatus}");

//                // Prompt for action
//                Console.Write("[C]onfirm / [R]eject / [S]kip / [D]eliver: ");
//                string action = Console.ReadLine().Trim().ToUpper();

//                switch (action)
//                {
//                    case "C":
//                        if (order.OrderStatus == "Pending")
//                        {
//                            order.OrderStatus = "Preparing";
//                            Console.WriteLine($"Order {order.OrderId} confirmed. Status: Preparing");
//                        }
//                        else
//                            Console.WriteLine("Cannot confirm this order.");
//                        break;

//                    case "R":
//                        if (order.OrderStatus == "Pending")
//                        {
//                            order.OrderStatus = "Rejected";
//                            refundStack.Push(order);
//                            Console.WriteLine($"Order {order.OrderId} rejected. Refund initiated.");
//                        }
//                        else
//                            Console.WriteLine("Cannot reject this order.");
//                        break;

//                    case "S":
//                        Console.WriteLine("Order skipped.");
//                        break;

//                    case "D":
//                        if (order.OrderStatus == "Preparing")
//                        {
//                            order.OrderStatus = "Delivered";
//                            Console.WriteLine($"Order {order.OrderId} delivered. Status: Delivered");
//                        }
//                        else
//                            Console.WriteLine("Cannot deliver this order.");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid option.");
//                        break;
//                }

//                Console.WriteLine(); // blank line between orders
//            }
//        }

//        static void ModifyOrder()
//        {
//            Console.WriteLine("Modify Order");
//            Console.WriteLine("============");

//            // Enter customer email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine();
//            Customer customer = customers.Find(c => c.EmailAddress == custEmail);

//            // Display pending orders
//            var pendingOrders = customer?.GetOrders().FindAll(o => o.OrderStatus == "Pending") ?? new List<Order>();

//            if (pendingOrders.Count == 0)
//            {
//                Console.WriteLine("Pending Orders:  ");
//                return; // nothing to modify
//            }

//            Console.WriteLine("Pending Orders:  ");
//            foreach (var o in pendingOrders)
//                Console.WriteLine(o.OrderId);

//            // Select Order ID
//            Console.Write("Enter Order ID: ");
//            if (!int.TryParse(Console.ReadLine(), out int orderId))
//                return;

//            Order order = pendingOrders.Find(o => o.OrderId == orderId);
//            if (order == null) return;

//            // Find restaurant
//            Restaurant restaurant = restaurants.Find(r => r.HasOrder(order));

//            // Display order details
//            Console.WriteLine("Order Items: ");
//            int i = 1;
//            foreach (var item in order.GetOrderedItems())
//                Console.WriteLine($"{i++}. {item.ItemName} - {item.QtyOrdered}");

//            Console.WriteLine("Address: ");
//            Console.WriteLine(order.DeliveryAddress);
//            Console.WriteLine("Delivery Date/Time: ");
//            Console.WriteLine(order.DeliveryDateTime.ToString("d/M/yyyy, HH:mm"));

//            // Prompt modification options
//            Console.Write("Modify: [1] Items [2] Address [3] Delivery Time: ");
//            string choice = Console.ReadLine().Trim();

//            switch (choice)
//            {
//                case "1":
//                    // Modify items
//                    Console.WriteLine("Enter new quantities (0 to remove item):");
//                    i = 1;
//                    var itemsCopy = new List<OrderedFoodItem>(order.GetOrderedItems()); // avoid collection modified error
//                    foreach (var item in itemsCopy)
//                    {
//                        Console.Write($"{i}. {item.ItemName} - current qty {item.QtyOrdered}, new qty: ");
//                        if (!int.TryParse(Console.ReadLine(), out int newQty)) continue;
//                        if (newQty == 0)
//                            order.RemoveOrderedFoodItem(item);
//                        else
//                            item.QtyOrdered = newQty;
//                        i++;
//                    }
//                    order.CalculateOrderTotal();
//                    Console.WriteLine($"Order {order.OrderId} updated. Items updated.");
//                    break;

//                case "2":
//                    // Modify address
//                    Console.Write("Enter new delivery address: ");
//                    order.DeliveryAddress = Console.ReadLine();
//                    Console.WriteLine($"Order {order.OrderId} updated. New Address: {order.DeliveryAddress}");
//                    break;

//                case "3":
//                    // Modify delivery time
//                    Console.Write("Enter new Delivery Time (hh:mm): ");
//                    string newTime = Console.ReadLine();
//                    string datePart = order.DeliveryDateTime.ToString("dd/MM/yyyy");
//                    if (DateTime.TryParseExact(datePart + " " + newTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDT))
//                        order.DeliveryDateTime = newDT;
//                    Console.WriteLine($"Order {order.OrderId} updated. New Delivery Time: {order.DeliveryDateTime:HH:mm}");
//                    break;

//                default:
//                    return;
//            }
//        }
//        static void DeleteOrder()
//        {
//            Console.WriteLine("Delete Order");
//            Console.WriteLine("============");

//            // Prompt for Customer Email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine();
//            Customer customer = customers.Find(c => c.EmailAddress == custEmail);

//            if (customer == null)
//            {
//                Console.WriteLine("No such customer found.");
//                return;
//            }

//            // List pending orders
//            var pendingOrders = customer.GetOrders().FindAll(o => o.OrderStatus == "Pending");
//            if (pendingOrders.Count == 0)
//            {
//                Console.WriteLine("Pending Orders:  ");
//                return;
//            }

//            Console.WriteLine("Pending Orders:  ");
//            foreach (var order in pendingOrders)
//                Console.WriteLine(order.OrderId);

//            // Prompt for Order ID
//            Console.Write("Enter Order ID: ");
//            if (!int.TryParse(Console.ReadLine(), out int orderId))
//            {
//                Console.WriteLine("Invalid Order ID.");
//                return;
//            }

//            Order orderToDelete = pendingOrders.Find(o => o.OrderId == orderId);
//            if (orderToDelete == null)
//            {
//                Console.WriteLine("Order not found.");
//                return;
//            }

//            // Find restaurant for this order
//            Restaurant restaurant = restaurants.Find(r => r.HasOrder(orderToDelete));

//            // Display order details
//            Console.WriteLine($"Customer: {customer.CustomerName}");
//            Console.WriteLine("Ordered Items:");
//            int idx = 1;
//            foreach (var item in orderToDelete.GetOrderedItems())
//                Console.WriteLine($"{idx++}. {item.ItemName} - {item.QtyOrdered}");
//            Console.WriteLine($"Delivery date/time: {orderToDelete.DeliveryDateTime:dd/MM/yyyy  HH:mm}");
//            Console.WriteLine($"Total Amount:  ${orderToDelete.OrderTotal + 5:F2}");
//            Console.WriteLine($"Order Status: {orderToDelete.OrderStatus}");

//            // Confirm deletion
//            Console.Write("Confirm deletion? [Y/N]: ");
//            string confirm = Console.ReadLine().Trim().ToUpper();
//            if (confirm == "Y")
//            {
//                orderToDelete.OrderStatus = "Cancelled";
//                refundStack.Push(orderToDelete);
//                Console.WriteLine($"Order {orderToDelete.OrderId} cancelled. Refund of ${orderToDelete.OrderTotal + 5:F2} processed.");
//            }
//            else
//            {
//                Console.WriteLine("Deletion cancelled.");
//            }
//        }



//    }
//}



// Next


//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using Gruberooapp;
//using System.Linq;


//namespace Gruberooapp
//{
//    public class Program
//    {
//        static void LoadRestaurantsFromCsv(string restaurantFile, string menuFile)
//        {
//            // Load restaurants
//            if (File.Exists(restaurantFile))
//            {
//                var lines = File.ReadAllLines(restaurantFile).Skip(1); // skip header
//                foreach (var line in lines)
//                {
//                    var parts = line.Split(',');
//                    if (parts.Length >= 3)
//                    {
//                        restaurants.Add(new Restaurant(parts[0], parts[1], parts[2]));
//                    }
//                }
//            }

//            LoadRestaurantsFromCsv("Restaurants.csv", "MenuItems.csv");
//            LoadCustomersFromCsv("Customers.csv");


//            // Load menu items
//            if (File.Exists(menuFile))
//            {
//                var lines = File.ReadAllLines(menuFile).Skip(1);
//                foreach (var line in lines)
//                {
//                    var parts = line.Split(',');
//                    if (parts.Length >= 5)
//                    {
//                        string restoId = parts[0];
//                        string menuName = parts[1];
//                        string itemName = parts[2];
//                        string itemDesc = parts[3];
//                        double price = double.Parse(parts[4]);

//                        var restaurant = restaurants.Find(r => r.RestaurantId == restoId);
//                        if (restaurant != null)
//                        {
//                            // Add menu if not exists
//                            var menu = restaurant.GetMenus().Find(m => m.MenuName == menuName);
//                            if (menu == null)
//                            {
//                                menu = new Menu("M" + (restaurant.GetMenus().Count + 1).ToString("D3"), menuName);
//                                restaurant.AddMenu(menu);
//                            }
//                            menu.AddFoodItem(new FoodItem(itemName, itemDesc, price, ""));
//                        }
//                    }
//                }
//            }
//        }

//        static void LoadCustomersFromCsv(string customerFile)
//        {
//            if (!File.Exists(customerFile)) return;

//            var lines = File.ReadAllLines(customerFile).Skip(1);
//            foreach (var line in lines)
//            {
//                var parts = line.Split(',');
//                if (parts.Length >= 2)
//                {
//                    customers.Add(new Customer(parts[0], parts[1]));
//                }
//            }
//        }


//        static List<Restaurant> restaurants = new List<Restaurant>();
//        static List<Customer> customers = new List<Customer>();
//        static List<Order> orders = new List<Order>();
//        static int nextOrderId = 1004; // next order ID
//        static Stack<Order> refundStack = new Stack<Order>();


//        static void Main(string[] args)
//        {
//            // Initialize sample data
//            InitializeSampleRestaurants();
//            InitializeSampleCustomersAndOrders();

//            // Display restaurants & menu items
//            DisplayRestaurantsAndMenus();

//            // Display all orders
//            DisplayAllOrders();

//            // Create a new order interactively
//            CreateNewOrder();

//            // Display updated orders
//            DisplayAllOrders();

//            // Process orders for a restaurant
//            ProcessOrders();
//        }

//        // -------------------------
//        // Initialization
//        // -------------------------
//        static void InitializeSampleRestaurants()
//        {
//            var grillHouse = new Restaurant("R001", "Grill House", "grillhouse@example.com");
//            var grillMenu = new Menu("M001", "Main Menu");
//            grillMenu.AddFoodItem(new FoodItem("Chicken Rice", "Steamed chicken with fragrant rice", 5.50, ""));
//            grillMenu.AddFoodItem(new FoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, ""));
//            grillMenu.AddFoodItem(new FoodItem("Caesar Salad", "Romaine lettuce with house dressing", 7.00, ""));
//            grillHouse.AddMenu(grillMenu);
//            restaurants.Add(grillHouse);

//            var noodlePalace = new Restaurant("R002", "Noodle Palace", "noodlepalace@example.com");
//            var noodleMenu = new Menu("M002", "Main Menu");
//            noodleMenu.AddFoodItem(new FoodItem("Spicy Ramen", "House-special broth with chilli oil", 11.20, ""));
//            noodlePalace.AddMenu(noodleMenu);
//            restaurants.Add(noodlePalace);
//        }

//        static void InitializeSampleCustomersAndOrders()
//        {
//            var alice = new Customer("alice.tan@email.com", "Alice Tan");
//            var joseph = new Customer("joseph.lim@email.com", "Joseph Lim");
//            var wendy = new Customer("wendy.ong@email.com", "Wendy Ong");
//            customers.Add(alice);
//            customers.Add(joseph);
//            customers.Add(wendy);

//            // Sample orders
//            var order1 = new Order(1001)
//            {
//                OrderStatus = "Delivered",
//                DeliveryDateTime = DateTime.Parse("12/02/2026 12:00"),
//                OrderPaid = true
//            };
//            order1.AddOrderedFoodItem(new OrderedFoodItem("Chicken Rice", "Steamed chicken with fragrant rice", 5.50, "", 2));
//            order1.AddOrderedFoodItem(new OrderedFoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, "", 2));
//            alice.AddOrder(order1);
//            restaurants[0].AddOrder(order1);

//            var order2 = new Order(1002)
//            {
//                OrderStatus = "Cancelled",
//                DeliveryDateTime = DateTime.Parse("13/02/2026 18:30"),
//                OrderPaid = false
//            };
//            order2.AddOrderedFoodItem(new OrderedFoodItem("Beef Burger", "Grilled beef patty with fries", 9.80, "", 1));
//            order2.AddOrderedFoodItem(new OrderedFoodItem("Caesar Salad", "Romaine lettuce with house dressing", 7.00, "", 2));
//            joseph.AddOrder(order2);
//            restaurants[0].AddOrder(order2);

//            var order3 = new Order(1003)
//            {
//                OrderStatus = "Preparing",
//                DeliveryDateTime = DateTime.Parse("14/02/2026 19:00"),
//                OrderPaid = false
//            };
//            order3.AddOrderedFoodItem(new OrderedFoodItem("Spicy Ramen", "House-special broth with chilli oil", 11.20, "", 1));
//            wendy.AddOrder(order3);
//            restaurants[1].AddOrder(order3);
//        }

//        // -------------------------
//        // Display restaurants
//        // -------------------------
//        static void DisplayRestaurantsAndMenus()
//        {
//            Console.WriteLine("All Restaurants and Menu Items");
//            Console.WriteLine("==============================");
//            foreach (var restaurant in restaurants)
//            {
//                Console.WriteLine($"Restaurant: {restaurant.RestaurantName} ({restaurant.RestaurantId})");
//                foreach (var menu in restaurant.GetMenus())
//                    foreach (var item in menu.GetFoodItems())
//                        Console.WriteLine($"  - {item.ItemName}: {item.ItemDesc} - ${item.ItemPrice:F2}");
//            }
//            Console.WriteLine();
//        }

//        // -------------------------
//        // Display all orders
//        // -------------------------
//        static void DisplayAllOrders()
//        {
//            Console.WriteLine("All Orders");
//            Console.WriteLine("==========");
//            Console.WriteLine($"{"Order ID",-10}{"Customer",-15}{"Restaurant",-15}{"Delivery Date/Time",-20}{"Amount",-10}{"Status",-12}");

//            foreach (var customer in customers)
//            {
//                foreach (var order in customer.GetOrders())
//                {
//                    Restaurant restaurantForOrder = null;
//                    foreach (var resto in restaurants)
//                        if (resto.HasOrder(order))
//                        {
//                            restaurantForOrder = resto;
//                            break;
//                        }

//                    Console.WriteLine(
//                        $"{order.OrderId,-10}" +
//                        $"{customer.CustomerName,-15}" +
//                        $"{restaurantForOrder?.RestaurantName,-15}" +
//                        $"{order.DeliveryDateTime:dd/MM/yyyy HH:mm,-20}" +
//                        $"${order.OrderTotal:F2,-10}" +
//                        $"{order.OrderStatus,-12}"
//                    );
//                }
//            }
//            Console.WriteLine();
//        }

//        // -------------------------
//        // Create new order
//        // -------------------------
//        static void CreateNewOrder()
//        {
//            Console.WriteLine("Create New Order");
//            Console.WriteLine("================");

//            // 1) Enter Customer Email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine().Trim().ToLower();

//            Customer customer = customers.Find(c => c.EmailAddress.ToLower() == custEmail);

//            if (customer == null)
//            {
//                Console.WriteLine("Customer not found. Please register customer first.");
//                return;
//            }

//            // 2) Enter Restaurant ID
//            Console.Write("Enter Restaurant ID: ");
//            string restoId = Console.ReadLine().Trim();
//            Restaurant restaurant = restaurants.Find(r => r.RestaurantId == restoId);
//            if (restaurant == null)
//            {
//                Console.WriteLine("Restaurant not found.");
//                return;
//            }

//            // 3) Delivery Date
//            Console.Write("Enter Delivery Date (dd/MM/yyyy): ");
//            string dateInput = Console.ReadLine();
//            if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDate))
//            {
//                Console.WriteLine("Invalid date format.");
//                return;
//            }

//            // 4) Delivery Time
//            Console.Write("Enter Delivery Time (hh:mm): ");
//            string timeInput = Console.ReadLine();
//            if (!DateTime.TryParseExact(dateInput + " " + timeInput, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDateTime))
//            {
//                Console.WriteLine("Invalid time format.");
//                return;
//            }

//            // 5) Delivery Address
//            Console.Write("Enter Delivery Address: ");
//            string deliveryAddress = Console.ReadLine();

//            // 6) Display available food items
//            List<FoodItem> foodItems = new List<FoodItem>();
//            foreach (var menu in restaurant.GetMenus())
//                foodItems.AddRange(menu.GetFoodItems());

//            Console.WriteLine("Available Food Items:");
//            int idx = 1;
//            foreach (var item in foodItems)
//                Console.WriteLine($"{idx}. {item.ItemName} - ${item.ItemPrice:F2}");

//            // 7) Select food items
//            List<OrderedFoodItem> orderedItems = new List<OrderedFoodItem>();
//            while (true)
//            {
//                Console.Write("Enter item number (0 to finish): ");
//                if (!int.TryParse(Console.ReadLine(), out int itemNo) || itemNo < 0 || itemNo > foodItems.Count) continue;
//                if (itemNo == 0) break;

//                FoodItem selectedItem = foodItems[itemNo - 1];

//                Console.Write("Enter quantity: ");
//                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0) continue;

//                orderedItems.Add(new OrderedFoodItem(selectedItem.ItemName, selectedItem.ItemDesc, selectedItem.ItemPrice, selectedItem.Customise, qty));
//            }

//            // 8) Special request
//            Console.Write("Add special request? [Y/N]: ");
//            string special = Console.ReadLine().Trim().ToUpper();
//            string specialRequest = "";
//            if (special == "Y")
//            {
//                Console.Write("Enter special request: ");
//                specialRequest = Console.ReadLine();
//            }

//            // 9) Create new Order
//            int newOrderId = orders.Any() ? orders.Max(o => o.OrderId) + 1 : 1001;
//            Order newOrder = new Order(newOrderId)
//            {
//                DeliveryAddress = deliveryAddress,
//                DeliveryDateTime = deliveryDateTime,
//                OrderStatus = "Pending"
//            };

//            // Add items
//            foreach (var oItem in orderedItems)
//                newOrder.AddOrderedFoodItem(oItem);

//            // Optional: add special request as one FoodItem
//            if (!string.IsNullOrEmpty(specialRequest))
//                newOrder.AddOrderedFoodItem(new OrderedFoodItem("Special Request", specialRequest, 0, "", 1));

//            // 10) Calculate total + delivery
//            double deliveryFee = 5.0;
//            double totalAmount = newOrder.CalculateOrderTotal() + deliveryFee;
//            Console.WriteLine($"Order Total: ${newOrder.OrderTotal:F2} + ${deliveryFee:F2} (delivery) = ${totalAmount:F2}");

//            // 11) Payment
//            Console.Write("Proceed to payment? [Y/N]: ");
//            string payChoice = Console.ReadLine().Trim().ToUpper();
//            if (payChoice == "Y")
//            {
//                Console.WriteLine("Payment method:");
//                Console.Write("[CC] Credit Card / [PP] PayPal / [CD] Cash on Delivery: ");
//                string method = Console.ReadLine().Trim().ToUpper();
//                newOrder.OrderPaymentMethod = method;
//                newOrder.OrderPaid = true;
//            }
//            else
//            {
//                Console.WriteLine("Order not paid. Exiting.");
//                return;
//            }

//            // 12) Add to Restaurant and Customer
//            restaurant.AddOrder(newOrder);
//            customer.AddOrder(newOrder);
//            orders.Add(newOrder);

//            // 13) Confirmation
//            Console.WriteLine($"Order {newOrder.OrderId} created successfully! Status: {newOrder.OrderStatus}");
//        }


//        // -------------------------
//        // Process Orders
//        // -------------------------
//        static void ProcessOrders()
//        {
//            Console.WriteLine("Process Order");
//            Console.WriteLine("=============");

//            // 1) Prompt for Restaurant ID
//            Console.Write("Enter Restaurant ID: ");
//            string restoId = Console.ReadLine().Trim();

//            // 2) Find restaurant
//            Restaurant restaurant = restaurants.Find(r => r.RestaurantId == restoId);
//            if (restaurant == null)
//            {
//                Console.WriteLine("Restaurant not found!");
//                return;
//            }

//            // 3) Get orders for this restaurant
//            var restaurantOrders = restaurant.GetOrders().Where(o => o.OrderStatus != "Delivered").ToList();
//            if (restaurantOrders.Count == 0)
//            {
//                Console.WriteLine("No pending or preparing orders for this restaurant.");
//                return;
//            }

//            foreach (var order in restaurantOrders)
//            {
//                // Find the customer
//                Customer customer = customers.Find(c => c.GetOrders().Contains(order));

//                // Display order info
//                Console.WriteLine($"Order {order.OrderId}:  ");
//                Console.WriteLine($"Customer: {customer.CustomerName}");
//                Console.WriteLine("Ordered Items:");
//                int i = 1;
//                foreach (var item in order.GetOrderedItems())
//                    Console.WriteLine($"{i++}. {item.ItemName} - {item.QtyOrdered}");
//                Console.WriteLine($"Delivery date/time: {order.DeliveryDateTime:dd/MM/yyyy  HH:mm}");
//                Console.WriteLine($"Total Amount:  ${order.OrderTotal + 5:F2}"); // include delivery fee
//                Console.WriteLine($"Order Status: {order.OrderStatus}");

//                // Prompt for action
//                Console.Write("[C]onfirm / [R]eject / [S]kip / [D]eliver: ");
//                string action = Console.ReadLine().Trim().ToUpper();

//                switch (action)
//                {
//                    case "C":
//                        if (order.OrderStatus == "Pending")
//                        {
//                            order.OrderStatus = "Preparing";
//                            Console.WriteLine($"Order {order.OrderId} confirmed. Status: Preparing");
//                        }
//                        else
//                            Console.WriteLine("Cannot confirm this order.");
//                        break;

//                    case "R":
//                        if (order.OrderStatus == "Pending")
//                        {
//                            order.OrderStatus = "Rejected";
//                            refundStack.Push(order);
//                            Console.WriteLine($"Order {order.OrderId} rejected. Refund initiated.");
//                        }
//                        else
//                            Console.WriteLine("Cannot reject this order.");
//                        break;

//                    case "S":
//                        Console.WriteLine("Order skipped.");
//                        break;

//                    case "D":
//                        if (order.OrderStatus == "Preparing")
//                        {
//                            order.OrderStatus = "Delivered";
//                            Console.WriteLine($"Order {order.OrderId} delivered. Status: Delivered");
//                        }
//                        else
//                            Console.WriteLine("Cannot deliver this order.");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid option.");
//                        break;
//                }

//                Console.WriteLine(); // blank line between orders
//            }
//        }

//        static void ModifyOrder()
//        {
//            Console.WriteLine("Modify Order");
//            Console.WriteLine("============");

//            // Enter customer email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine();
//            Customer customer = customers.Find(c => c.EmailAddress == custEmail);

//            // Display pending orders
//            var pendingOrders = customer?.GetOrders().FindAll(o => o.OrderStatus == "Pending") ?? new List<Order>();

//            if (pendingOrders.Count == 0)
//            {
//                Console.WriteLine("Pending Orders:  ");
//                return; // nothing to modify
//            }

//            Console.WriteLine("Pending Orders:  ");
//            foreach (var o in pendingOrders)
//                Console.WriteLine(o.OrderId);

//            // Select Order ID
//            Console.Write("Enter Order ID: ");
//            if (!int.TryParse(Console.ReadLine(), out int orderId))
//                return;

//            Order order = pendingOrders.Find(o => o.OrderId == orderId);
//            if (order == null) return;

//            // Find restaurant
//            Restaurant restaurant = restaurants.Find(r => r.HasOrder(order));

//            // Display order details
//            Console.WriteLine("Order Items: ");
//            int i = 1;
//            foreach (var item in order.GetOrderedItems())
//                Console.WriteLine($"{i++}. {item.ItemName} - {item.QtyOrdered}");

//            Console.WriteLine("Address: ");
//            Console.WriteLine(order.DeliveryAddress);
//            Console.WriteLine("Delivery Date/Time: ");
//            Console.WriteLine(order.DeliveryDateTime.ToString("d/M/yyyy, HH:mm"));

//            // Prompt modification options
//            Console.Write("Modify: [1] Items [2] Address [3] Delivery Time: ");
//            string choice = Console.ReadLine().Trim();

//            switch (choice)
//            {
//                case "1":
//                    // Modify items
//                    Console.WriteLine("Enter new quantities (0 to remove item):");
//                    i = 1;
//                    var itemsCopy = new List<OrderedFoodItem>(order.GetOrderedItems()); // avoid collection modified error
//                    foreach (var item in itemsCopy)
//                    {
//                        Console.Write($"{i}. {item.ItemName} - current qty {item.QtyOrdered}, new qty: ");
//                        if (!int.TryParse(Console.ReadLine(), out int newQty)) continue;
//                        if (newQty == 0)
//                            order.RemoveOrderedFoodItem(item);
//                        else
//                            item.QtyOrdered = newQty;
//                        i++;
//                    }
//                    order.CalculateOrderTotal();
//                    Console.WriteLine($"Order {order.OrderId} updated. Items updated.");
//                    break;

//                case "2":
//                    // Modify address
//                    Console.Write("Enter new delivery address: ");
//                    order.DeliveryAddress = Console.ReadLine();
//                    Console.WriteLine($"Order {order.OrderId} updated. New Address: {order.DeliveryAddress}");
//                    break;

//                case "3":
//                    // Modify delivery time
//                    Console.Write("Enter new Delivery Time (hh:mm): ");
//                    string newTime = Console.ReadLine();
//                    string datePart = order.DeliveryDateTime.ToString("dd/MM/yyyy");
//                    if (DateTime.TryParseExact(datePart + " " + newTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDT))
//                        order.DeliveryDateTime = newDT;
//                    Console.WriteLine($"Order {order.OrderId} updated. New Delivery Time: {order.DeliveryDateTime:HH:mm}");
//                    break;

//                default:
//                    return;
//            }
//        }
//        static void DeleteOrder()
//        {
//            Console.WriteLine("Delete Order");
//            Console.WriteLine("============");

//            // Prompt for Customer Email
//            Console.Write("Enter Customer Email: ");
//            string custEmail = Console.ReadLine();
//            Customer customer = customers.Find(c => c.EmailAddress == custEmail);

//            if (customer == null)
//            {
//                Console.WriteLine("No such customer found.");
//                return;
//            }

//            // List pending orders
//            var pendingOrders = customer.GetOrders().FindAll(o => o.OrderStatus == "Pending");
//            if (pendingOrders.Count == 0)
//            {
//                Console.WriteLine("Pending Orders:  ");
//                return;
//            }

//            Console.WriteLine("Pending Orders:  ");
//            foreach (var order in pendingOrders)
//                Console.WriteLine(order.OrderId);

//            // Prompt for Order ID
//            Console.Write("Enter Order ID: ");
//            if (!int.TryParse(Console.ReadLine(), out int orderId))
//            {
//                Console.WriteLine("Invalid Order ID.");
//                return;
//            }

//            Order orderToDelete = pendingOrders.Find(o => o.OrderId == orderId);
//            if (orderToDelete == null)
//            {
//                Console.WriteLine("Order not found.");
//                return;
//            }

//            // Find restaurant for this order
//            Restaurant restaurant = restaurants.Find(r => r.HasOrder(orderToDelete));

//            // Display order details
//            Console.WriteLine($"Customer: {customer.CustomerName}");
//            Console.WriteLine("Ordered Items:");
//            int idx = 1;
//            foreach (var item in orderToDelete.GetOrderedItems())
//                Console.WriteLine($"{idx++}. {item.ItemName} - {item.QtyOrdered}");
//            Console.WriteLine($"Delivery date/time: {orderToDelete.DeliveryDateTime:dd/MM/yyyy  HH:mm}");
//            Console.WriteLine($"Total Amount:  ${orderToDelete.OrderTotal + 5:F2}");
//            Console.WriteLine($"Order Status: {orderToDelete.OrderStatus}");

//            // Confirm deletion
//            Console.Write("Confirm deletion? [Y/N]: ");
//            string confirm = Console.ReadLine().Trim().ToUpper();
//            if (confirm == "Y")
//            {
//                orderToDelete.OrderStatus = "Cancelled";
//                refundStack.Push(orderToDelete);
//                Console.WriteLine($"Order {orderToDelete.OrderId} cancelled. Refund of ${orderToDelete.OrderTotal + 5:F2} processed.");
//            }
//            else
//            {
//                Console.WriteLine("Deletion cancelled.");
//            }
//        }



//    }
//}



// Next 

using Gruberooapp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Gruberoo
{
    class Program
    {
        static List<Restaurant> restaurants = new();
        static List<Customer> customers = new();
        static List<Order> orders = new();

        static void Main()
        {
            LoadRestaurantsAndFoodItems();
            LoadCustomersAndOrders();

            Console.WriteLine("Welcome to the Gruberoo Food Delivery System");
            Console.WriteLine($"{restaurants.Count} restaurants loaded!");

            // OPTION 3 — NO LINQ (SAFE)
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
            foreach (var line in File.ReadAllLines("fooditems.csv").Skip(1))
            {
                var p = line.Split(',');

                if (p.Length < 4) continue; // must have at least 4 columns

                Restaurant r = restaurants.FirstOrDefault(x => x.RestaurantId == p[0].Trim());
                if (r == null) continue;

                if (!double.TryParse(p[3].Trim(), out double price)) continue;

                FoodItem f;

                if (p.Length >= 5) // if Customise column exists
                    f = new FoodItem(p[1].Trim(), p[2].Trim(), price, p[4].Trim());
                else // only 3 columns: Name, Description, Price
                    f = new FoodItem(p[1].Trim(), p[2].Trim(), price); // <- no p[4] here

                r.AddMenuItem(f);
            }


        }

        // ================= LOAD PART 2 =================
        // Customers + Orders

        static void LoadCustomersAndOrders()
        {
            foreach (var line in File.ReadAllLines("customers.csv").Skip(1))
            {
                var p = line.Split(',');
                customers.Add(new Customer(p[0], p[1]));
            }

            foreach (var line in File.ReadAllLines("orders.csv").Skip(1))
            {
                var p = line.Split(',');

                int orderId = int.Parse(p[0]);
                string email = p[1];
                string restId = p[2];
                string status = p[5];

                Customer c = customers.FirstOrDefault(x => x.EmailAddress == email);
                Restaurant r = restaurants.FirstOrDefault(x => x.RestaurantId == restId);

                if (c == null || r == null) continue;

                Order o = new Order(orderId, status);

                orders.Add(o);
                c.Orders.Add(o);
                r.OrderQueue.Enqueue(o);
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
                        ListAllOrders();
                        break;
                    case "3":
                        CreateNewOrder();
                        break;
                    case "4":
                        ProcessOrders();
                        break;
                    case "5":
                        ModifyOrder();
                        break;
                    case "6":
                        // Delete order
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
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

                Console.WriteLine(); // extra line between restaurants
            }
        }

        // ================= OPTION 2 =================
        static void ListAllOrders()
        {
            Console.WriteLine("All Orders");
            Console.WriteLine("==========");

            // Header
            Console.WriteLine("Order ID Customer        Restaurant       Delivery Date/Time     Amount   Status");
            Console.WriteLine("-------- --------------- --------------- -------------------- ------- ---------");

            foreach (var o in orders)
            {
                // Find the customer and restaurant for this order
                Customer c = customers.FirstOrDefault(cus => cus.Orders.Contains(o));
                Restaurant r = restaurants.FirstOrDefault(rest => rest.OrderQueue.Contains(o));

                // Get names or default to "Unknown"
                string customerName = c != null ? c.CustomerName : "Unknown";
                string restaurantName = r != null ? r.RestaurantName : "Unknown";

                // Delivery time or N/A if empty
                string deliveryTime = string.IsNullOrEmpty(o.DeliveryTime) ? "N/A" : o.DeliveryTime;

                // Amount with $ and 2 decimal places
                string amount = $"${o.Total:F2}";

                // Status
                string status = o.Status;

                // Align columns to match your example output
                Console.WriteLine($"{o.Id,-8} {customerName,-15} {restaurantName,-15} {deliveryTime,-20} {amount,-7} {status,-9}");
            }

            Console.WriteLine(); // extra line
        }

        // ================= OPTION 3 =================
        static void CreateNewOrder()
        {
            Console.WriteLine("Option 3: Create New Order");
            Console.WriteLine("================");

            // 1. Get basic info
            Console.Write("Enter Customer Email: ");
            string customerEmail = Console.ReadLine();

            Console.Write("Enter Restaurant ID: ");
            string restaurantId = Console.ReadLine();

            // You can use restaurantId directly
            Console.WriteLine($"Restaurant ID entered: {restaurantId}");

            Console.Write("Enter Delivery Date (dd/mm/yyyy): ");
            string deliveryDate = Console.ReadLine();

            Console.Write("Enter Delivery Time (hh:mm): ");
            string deliveryTime = Console.ReadLine();

            Console.Write("Enter Delivery Address: ");
            string deliveryAddress = Console.ReadLine();


            // 2. Select food items
            List<OrderItem> orderItems = new List<OrderItem>();
            int itemNumber;

            // For demonstration, let's assume we have a menu
            List<FoodItem> menu = new List<FoodItem>
    {
        new FoodItem("Chicken Rice", "Delicious chicken rice", 5.50),
        new FoodItem("Beef Burger", "Juicy beef burger", 9.80),
        new FoodItem("Caesar Salad", "Fresh salad", 7.00)
    };

            do
            {
                Console.WriteLine("\nAvailable Food Items:");
                for (int i = 0; i < menu.Count; i++)
                    Console.WriteLine($"{i + 1}. {menu[i].Name} - ${menu[i].Price:F2}");

                Console.Write("Enter item number (0 to finish): ");
                int.TryParse(Console.ReadLine(), out itemNumber);

                if (itemNumber > 0 && itemNumber <= menu.Count)
                {
                    Console.Write("Enter quantity: ");
                    int.TryParse(Console.ReadLine(), out int quantity);

                    if (quantity > 0)
                        orderItems.Add(new OrderItem(menu[itemNumber - 1], quantity));
                }

            } while (itemNumber != 0);

            // 3. Special request
            Console.Write("Add special request? [Y/N]: ");
            string specialRequest = Console.ReadLine().ToUpper() == "Y" ? "Requested" : "";

            // 4. Create order
            int nextOrderId = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1001;
            Order newOrder = new Order
            {
                Id = nextOrderId,
                CustomerEmail = customerEmail,
                RestaurantId = restaurantId,
                DeliveryDate = deliveryDate,
                DeliveryTime = deliveryTime,
                DeliveryAddress = deliveryAddress,
                Items = orderItems,
                SpecialRequest = specialRequest,
                Status = "Pending"
            };
            newOrder.CalculateTotal();

            // 7. Show total including $5 delivery
            double subtotal = newOrder.Total - 5; // actual food total
            Console.WriteLine($"Order Total: ${subtotal:F2} + $5.00 (delivery) = ${newOrder.Total:F2}");

            // 8. Payment
            Console.Write("Proceed to payment? [Y/N]: ");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                Console.WriteLine("Order cancelled.");
                return;
            }

            Console.Write("Payment method:\n[CC] Credit Card / [PP] PayPal / [CD] Cash on Delivery: ");
            newOrder.PaymentMethod = Console.ReadLine().ToUpper();

            // 9. Add order to system
            //orders.Add(newOrder);
            //Customer customer = customers.First(c => c.EmailAddress == customerEmail);
            //customer.Orders.Add(newOrder);

            // Final confirmation
            Console.WriteLine($"Order {newOrder.Id} created successfully! Status: {newOrder.Status}");
        }

        // ================= OPTION 4 =================
        static Stack<Order> refundStack = new Stack<Order>(); // Refund stack
        static void ProcessOrders()
        {
            Console.WriteLine("Process Order");
            Console.WriteLine("=============");

            // Prompt for Restaurant ID (just input, no lookup)
            Console.Write("Enter Restaurant ID: ");
            string restaurantId = Console.ReadLine();

            // Loop through all orders (or filter by RestaurantId if you want)
            foreach (var order in orders)
            {
                if (order.RestaurantId != restaurantId)
                    continue; // skip orders not for this restaurant

                // Display basic order info
                Console.WriteLine($"\nOrder {order.Id}:");
                Console.WriteLine($"Customer: {order.CustomerEmail}"); // or CustomerName
                Console.WriteLine("Ordered Items:");
                for (int i = 0; i < order.Items.Count; i++)
                    Console.WriteLine($"{i + 1}. {order.Items[i].Item.Name} - {order.Items[i].Quantity}");
                Console.WriteLine($"Delivery date/time: {order.DeliveryDate} {order.DeliveryTime}");
                Console.WriteLine($"Total Amount: ${order.Total:F2}");
                Console.WriteLine($"Order Status: {order.Status}");

                // Prompt for action
                Console.Write("[C]onfirm / [R]eject / [S]kip / [D]eliver: ");
                string action = Console.ReadLine().ToUpper();

                // Apply action
                if (action == "C" && order.Status == "Pending")
                {
                    order.Status = "Preparing";
                    Console.WriteLine($"Order {order.Id} confirmed. Status: Preparing");
                }
                else if (action == "R" && order.Status == "Pending")
                {
                    order.Status = "Rejected";
                    refundStack.Push(order);
                    Console.WriteLine($"Order {order.Id} rejected. Refund processed.");
                }
                else if (action == "S" && order.Status == "Cancelled")
                {
                    Console.WriteLine($"Order {order.Id} skipped.");
                }
                else if (action == "D" && order.Status == "Preparing")
                {
                    order.Status = "Delivered";
                    Console.WriteLine($"Order {order.Id} delivered. Status: Delivered");
                }
                else
                {
                    Console.WriteLine("Action cannot be applied to current order status.");
                }
            }
         // ================= OPTION 5 =================
            
              

        }






        
    }
    }

