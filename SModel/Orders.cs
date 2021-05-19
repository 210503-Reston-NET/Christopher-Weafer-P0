using System.Collections.Generic;
namespace SModel
{
    public class Orders
    {
        public Orders()
        {

        }
        public Orders(Bread type, int count)
        {
            Loaf = type;
            BreadCount = count;
        }
        /// <summary>
        /// Cnstruct when location and ordertotal is not needed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public Orders(int id, Bread type, int count)
        {
            OrderNumber = id;
            Loaf = type;
            BreadCount = count;
        }

        /// <summary>
        /// Constructor to initialize Orders in the get order method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <param name="location"></param>
        /// <param name="orderTot"></param>
        public Orders(int id, Bread type, int count, Bakery location, double orderTot)
        {
            OrderNumber = id;
            Loaf = type;
            BreadCount = count;
            bakery = location;
            OrderTotal = orderTot;
        }

        public int OrderNumber;
        public int BreadCount{ get; set; }
        
        public double OrderTotal{ get; set;}
        public Bread Loaf{ get; set; } 
        public Bakery bakery{ get; set; } 



        public override string ToString()
        {
            string orderDisplay;
            orderDisplay = $"\tOrder Number: {OrderNumber} \n\tBread ID:{Loaf.BreadID} \n\tQuantity {BreadCount} \n\tOrder Cost: {OrderTotal}";
            if(bakery != null)
            {
                orderDisplay += $"\n\tBakery: {bakery.BakeryName}\n";
            }
            return orderDisplay;
        }
    
    }
}