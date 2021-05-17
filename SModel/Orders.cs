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
        }

        public Bread Loaf{ get; set; } 
        //public Customer Name{ get; set; }

        //Dictionary stores a bread object as a unique key
        //Value is the count of that particular loaf.
        List<Bread> items{ get; set; }
    
    }
}