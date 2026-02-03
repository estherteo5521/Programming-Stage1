//========================================================== 
// Student Number : S10272963E
// Student Name : Yap Jia Xuan 
// Partner Name : Esther Teo Hui Min
//==========================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10272963_PRG2ASG
{
    internal class Customer
    {
        public string emailAddress { get; set; }
        public string customerName { get; set; }

        public Customer(string custemail, string custname)
        {
            emailAddress = custemail;
            customerName = custname;
        }
        public List<Order> orderlist { get; set; } = new List<Order>();
        public void AddOrder(Order order)
        {
            orderlist.Add(order);
        }
        public void DisplayAllOrders()
        {
            return orderlist;
        }

        public bool RemoveOrder(Order order)
        {
            orderlist.Remove(order);
        }
        public override string ToString()
        {
            return "Customer:" + customerName + emailAddress;
        }
    }
}
