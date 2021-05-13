using System.Collections.Generic;
using SModel;
namespace SBL
{
    public interface BreadBL
    {
        Customer addCustomer(Customer customer);

        List<Customer> GetAllCustomers();

    }
}