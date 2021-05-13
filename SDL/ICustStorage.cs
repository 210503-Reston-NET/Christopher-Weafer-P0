using System.Collections.Generic;
using SModel;
namespace SDL
{
    public interface ICustStorage
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(Customer customer);
        
        List<Customer> GetAllCustomers();
    }
}