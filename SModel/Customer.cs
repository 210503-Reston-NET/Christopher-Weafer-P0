using System.Collections.Generic;
namespace SModel
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string name)
        {

        }

        public string Name{ get; set; }
        public List<Orders> OrderList { get; set; }
    }
}