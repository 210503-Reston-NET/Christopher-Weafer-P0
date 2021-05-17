using System.Collections.Generic;
using SModel;
namespace SDL
{
    public interface ICustStorage
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(Customer customer);

        Orders AddOrder(Customer customer, Orders order);
        
        List<Customer> GetAllCustomers();
    }
}