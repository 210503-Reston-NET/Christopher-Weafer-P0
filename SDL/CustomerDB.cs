using Model = SModel;
using Entity = SDL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SDL
{   
    public class CustomerDB : ICustStorage{
        //used to reference 
        private Entity.OnlineBakeryContext _OBContext;

        public CustomerDB(Entities.OnlineBakeryContext context)
        {
            _OBContext = context;
        }
        
        //Customer Logic
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
            else return new Model.Customer(get.Id, get.FirstName, get.LastName);
        }
        
        
        public List<Model.Customer> GetAllCustomers()
        {
            return _OBContext.Customers
            .Select(
                customer => new Model.Customer(customer.FirstName, customer.LastName)
            ).ToList();
        }

        //Order Logic
        public Model.Orders AddOrder(Model.Customer customer, Model.Orders order, int location)
        {
            Entity.OnlineBakeryContext _OBContext1 = new Entity.OnlineBakeryContext();
            Entity.Order t =  new Entity.Order
                {
                    CustomerId = GetCustomer(customer).Id,
                    OrderTotal = order.Loaf.Price*order.BreadCount,
                    BakeryId = location
                };
            _OBContext1.Orders.Add(t);
            _OBContext1.SaveChanges();
            int tempID = t.OrderNumber;
            Console.WriteLine(tempID);

            _OBContext.BreadBatches.Add(
                new Entity.BreadBatch
                {
                    OrderId = tempID,
                    ProductId = order.Loaf.BreadID,
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
        public List<Model.Orders> GetOrders(Model.Customer customer)
        {
            return _OBContext.Orders.Where(
                order => order.CustomerId == GetCustomer(customer).Id
                ).Select(
                    order => new Model.Orders
                    {
                        OrderNumber = order.OrderNumber,
                        BreadCount = Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).BreadQuantity),
                        Loaf = new Model.Bread(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).ProductId)),
                        //Loaf = GetBreadName(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).ProductId)),
                        bakery = new Model.Bakery(Convert.ToInt32(order.BakeryId), _OBContext.Bakeries.FirstOrDefault(bake => bake.BakeId == order.BakeryId).BakeryName),
                        OrderTotal = Convert.ToDouble(order.OrderTotal)
                    }
                ).ToList();

        }
        /// <summary>
        /// Returns a list of orders that correspond with the given location
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        public List<Model.Orders> GetBakeryOrders(int locationID){
            return _OBContext.Orders.Where(
                order => order.BakeryId == locationID
                ).Select(
                    order => new Model.Orders
                    {
                        OrderNumber = order.OrderNumber,
                        BreadCount = Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).BreadQuantity),
                        Loaf = new Model.Bread(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).ProductId)),
                        //Loaf = GetBreadName(Convert.ToInt32(_OBContext.BreadBatches.FirstOrDefault(ord => ord.OrderId == order.OrderNumber).ProductId)),
                        bakery = new Model.Bakery(Convert.ToInt32(order.BakeryId), _OBContext.Bakeries.FirstOrDefault(bake => bake.BakeId == order.BakeryId).BakeryName),
                        OrderTotal = Convert.ToDouble(order.OrderTotal)
                    }
                ).ToList();

        }

        public List<Model.Bread> GetBakeryInventory(int locationID)
        {
            return _OBContext.BakeryInventories.Where(
                BInv => BInv.StoreId == locationID
                ).Select(
                    BInv => new Model.Bread
                    {
                        BreadID = Convert.ToInt32(BInv.ProductId),
                        Breadtype = _OBContext.Breads.FirstOrDefault(bread => bread.BreadCode == BInv.ProductId).BreadType,
                        Price = Convert.ToDouble(_OBContext.Breads.FirstOrDefault(bread => bread.BreadCode == BInv.ProductId).Price),
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

        public Model.Bread GetBreadName(int itemID)
        {
            Entity.Bread get = _OBContext.Breads.FirstOrDefault(bread => bread.BreadCode == itemID);
            if(get == null) return null;
            else return new Model.Bread(get.BreadCode, get.BreadType, get.Price.Value);
        }
        public Model.Bread GetBread(string breadBrand)
        {
            Entity.Bread get = _OBContext.Breads.FirstOrDefault(bread => bread.BreadType == breadBrand);
            if(get == null) return null;
            else return new Model.Bread(get.BreadCode, get.BreadType, get.Price.Value);
        }
    }
}