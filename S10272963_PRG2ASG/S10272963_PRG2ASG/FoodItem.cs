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
    abstract class FoodItem
    {
        public string itemName {  get; set; }
        public string itemDesc { get; set; }
        public string itemPrice { get; set; }
        public string customise { get; set; }
        public FoodItem (string itemname, string itemdesc, string itemprice,string Customise)
        {
            itemName = itemname;
            itemDesc = itemdesc;
            itemPrice = itemprice;
            customise = Customise;
        }
        public override string ToString()
        {
            return "Food item" + itemName + itemDesc + itemPrice + customise;
        }
    }
}
