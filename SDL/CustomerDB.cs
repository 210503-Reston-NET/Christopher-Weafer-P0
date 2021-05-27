using SModel;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SDL
{   
    public class CustomerDB : ICustStorage{
        //used to reference 
        private BakeryDBContext _OBContext;

        public CustomerDB(BakeryDBContext context)
        {
            _OBContext = context;
        }
        
        //Customer Logic
        public Customer AddCustomer(Customer customer)
        {
            // This creates something to sent to DB
            _OBContext.Customers.Add(new Customer{
                FirstName = customer.FirstName,
                LastName = customer.LastName
            });
            //Persists change to db
            _OBContext.SaveChanges();
            return customer;
        }
        public Customer GetCustomer(Customer customer)
        {
            Customer get = _OBContext.Customers.FirstOrDefault(cust=> cust.FirstName == customer.FirstName && cust.LastName == customer.LastName);
            if(get == null) return null;
            else return new Customer(get.Id, get.FirstName, get.LastName);
        }
        
        
        public List<Customer> GetAllCustomers()
        {
            return _OBContext.Customers
            .Select(
                customer => new Customer(customer.FirstName, customer.LastName)
            ).ToList();
        }

        //Order Logic
        public Orders AddOrder(Customer customer, Orders order, int location)
        {
            BakeryDBContext _OBContext1 = new BakeryDBContext();
            Orders t =  new Orders
                {
                    CustomerId = GetCustomer(customer).Id,
                    OrderTotal = order.Loaf.Price*order.BreadCount,
                    BakeryId = location
                };
            _OBContext1.Orders.Add(t);
            _OBContext1.SaveChanges();
            int tempID = t.Id;
            Console.WriteLine(tempID);

            _OBContext.BreadBatches.Add(
                new BreadBatch
                {
                    OrderId = tempID,
                    ProductId = order.Loaf.BreadId,
                    BreadQuantity = order.BreadCount
                }
            );
            _OBContext.SaveChanges();
            return order;
        }
        /// <summary>
        /// Returns a list of all odders contained within a customer object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<Orders> GetOrders(Customer customer)
        {
            return _OBContext.Orders.Where(
                order => order.CustomerId == GetCustomer(customer).Id
                ).Select(
                    order => new Orders
                    {
                        Id = order.Id,
                        BreadCount = Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.Id).BreadQuantity),
                        Loaf = new Bread(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.Id).ProductId)),
                        //Loaf = GetBreadName(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).ProductId)),
                        bakery = new Bakery(Convert.ToInt32(order.BakeryId), _OBContext.Bakeries.FirstOrDefault(bake => bake.BakeryId == order.BakeryId).BakeryName),
                        OrderTotal = Convert.ToDouble(order.OrderTotal)
                    }
                ).ToList();

        }
        /// <summary>
        /// Returns a list of orders that correspond with the given location
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        public List<Orders> GetBakeryOrders(int locationID){
            return _OBContext.Orders.Where(
                order => order.bakery.BakeryId == locationID
                ).Select(
                    order => new Orders
                    {
                        Id = order.Id,
                        BreadCount = Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.Id).BreadQuantity),
                        Loaf = new Bread(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.Id).ProductId)),
                        //Loaf = GetBreadName(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).ProductId)),
                        bakery = new Bakery(Convert.ToInt32(order.bakery.BakeryId), _OBContext.Bakeries.FirstOrDefault(bake => bake.BakeryId == order.bakery.BakeryId).BakeryName),
                        OrderTotal = Convert.ToDouble(order.OrderTotal)
                    }
                ).ToList();

        }

        public List<Bread> GetBakeryInventory(int locationID)
        {
            return _OBContext.BakeryInventories.Where(
                BInv => BInv.StoreId == locationID
                ).Select(
                    BInv => new Bread
                    {
                        BreadId = Convert.ToInt32(BInv.ProductId),
                        Breadtype = _OBContext.Breads.FirstOrDefault(bread => bread.BreadId == BInv.ProductId).Breadtype,
                        Price = Convert.ToDouble(_OBContext.Breads.FirstOrDefault(bread => bread.BreadId== BInv.ProductId).Price),
                        Stock = Convert.ToInt32(BInv.Stock)
                    }
                ).ToList();
        }

        public void UpdateInventory(int locationID, int BreadType, int moreBread)
        {
            _OBContext.BakeryInventories.AsEnumerable().Where(inv => inv.StoreId==locationID).Where(inv => BreadType == inv.ProductId)
            .Select(inventory => inventory.Stock += moreBread)
            .ToList();
            _OBContext.SaveChanges();
        }

        //Bread Logic

        public Bread GetBreadName(int itemID)
        {
            Bread get = _OBContext.Breads.FirstOrDefault(bread => bread.BreadId == itemID);
            if(get == null) return null;
            else return new Bread(get.BreadId, get.Breadtype, get.Price);
        }
        public Bread GetBread(string breadBrand)
        {
            Bread get = _OBContext.Breads.FirstOrDefault(bread => bread.Breadtype == breadBrand);
            if(get == null) return null;
            else return new Bread(get.BreadId, get.Breadtype, get.Price);
        }
    }
}