using System;
using System.Collections.Generic;
using SModel;
using SDL;
namespace SBL
{
    public class OrderBL : IOrderBL
    {
        private ICustStorage _storage;
        public OrderBL(ICustStorage storage)
        {
            _storage = storage;
        }
        public Orders AddOrder(Customer customer, Orders orders)
        {
            _storage.AddOrder(customer, orders);
            return orders;
        }
        
        //public Tuple<List<Orders>, int> GetReviews(Customer customer)
        //{
        //    
        //}
        
    }
}