using Model = SModel;
using Entity = SDL.Entities;
using System.Collections.Generic;
using System.Linq;
namespace SDL

{
   public class CustomerDB : ICustStorage
   {
        //used to reference 
        private Entity.OnlineBakeryContext _OBContext;

        public CustomerDB(Entities.OnlineBakeryContext context)
        {
            _OBContext = context;
        }
        
        public Model.Customer AddCustomer(Model.Customer customer)
        {
            // This creates something to sent to DB
            _OBContext.Customers.Add(new Entity.Customer{
                FirstName = customer.FirstName,
                LastName = customer.LastName
            });
            //Persists change to db
            _OBContext.SaveChanges();
            return customer;
        }
        public Model.Customer GetCustomer(Model.Customer customer)
        {
            Entity.Customer get = _OBContext.Customers.FirstOrDefault(cust=> cust.FirstName == customer.FirstName && cust.LastName == customer.LastName);
            if(get == null) return null;
            else return new Model.Customer(get.FirstName, get.LastName);
        }
        
        public List<Model.Customer> GetAllCustomers()
        {
            return _OBContext.Customers
            .Select(
                customer => new Model.Customer(customer.FirstName, customer.LastName)
            ).ToList();
        }

        //Reviews Data Logic
        public Model.Orders AddOrder(Model.Customer customer, Model.Orders order)
        {

            return order;
        }
   }
}