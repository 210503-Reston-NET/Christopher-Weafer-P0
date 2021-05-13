using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using SModel;
namespace SDL
{
    public class CustStorage : ICustStorage
    {
        private const string filePath = "../SDL/Customers.json";
        private string jsonCustomer;

        //Currently Factored to format in Json
        //TO DO refactor for xml storage
        public Customer AddCustomer(Customer customer)
        {
            List<Customer> customerFromFile = GetAllCustomers();
            customerFromFile.Add(customer);
            jsonCustomer = JsonSerializer.Serialize(customerFromFile);
            File.WriteAllText(filePath, jsonCustomer);
            return customer;
        }

        public Customer GetCustomer(Customer customer)
        {
            return GetAllCustomers().FirstOrDefault(resto => resto.Equals(customer));
        }
        public List<Customer> GetAllCustomers()
        {
            jsonCustomer = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Customer>>(jsonCustomer);
    
        }
    }
}