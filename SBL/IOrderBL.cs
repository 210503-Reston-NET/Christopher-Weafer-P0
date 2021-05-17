using System;
using System.Collections.Generic;
using SModel;
namespace SBL
{
    public interface IOrderBL
    {
        Orders AddOrder(Customer customer, Orders order);
        //Tuple<List<Orders>, int> GetReviews(Customer customer);
    }
}