using System.Collections.Generic;
using SModel;
using SDL;
namespace BreadBL
{
    public class Class1
    {
        ICustStorage storage;
        public Customer AddCustomer(Customer customer)
        {
            return storage.AddCustomer(customer);
        }

        List<Customer> GetAllCustomers()
        {
            return storage.GetAllCustomers();
        }
    }
}
