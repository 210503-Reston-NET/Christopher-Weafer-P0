using System;
using System.Collections.Generic;
using SModel;
namespace SBL
{
    public interface IOrderBL
    {
        /// <summary>
        /// passes data to the database to add an order
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="order"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        Orders AddOrder(Customer customer, Orders order, int location);
        List<Orders> GetOrders(Customer customer);
        List<Orders> GetBakeryOrders(int location);
        List<Bread> GetBakeryInvertory(int location);
        void UpdateInventory(int locationID, int BreadType, int moreBread);
        Bread GetBread(string breadType);
    }
}