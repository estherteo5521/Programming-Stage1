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
    internal class Order
    {
        public int orderId {  get; set; }
        public DateTime orderDateTime { get; set; }
        public double orderTotal { get; set; }
        public string orderStatus { get; set; }
        public DateTime deliveryDateTime { get; set; }
        public string deliveryAddress { get; set; }
        public string orderPaymentMethod { get; set; }
        public bool orderPaid { get; set; }
        public Order (int orderid,DateTime orderdatetime,double ordertotal,string orderstatus,DateTime deliverydatetime,string deliveryaddress,string orderpaymentmethod,bool orderpaid)
        {
            orderId = orderid;
            orderDateTime = orderdatetime;
            orderTotal = ordertotal;
            orderStatus = orderstatus;
            deliveryDateTime = deliverydatetime;
            deliveryAddress = deliveryaddress;
            orderPaymentMethod = orderpaymentmethod;
            orderPaid = orderpaid;
        }
         public double CalculateOrderTotal()
        {
            double total = 0;
            orderTotal = total + 5.00;
            return orderTotal;
        }
        public void AddOrderedFoodItems(Order order)
        {
            return 0;
        }
        public void DisplayOrderedFoodItems()
        {
            return 0;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
