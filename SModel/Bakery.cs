using System;
using System.Collections.Generic;
namespace SModel
{
    public class Bakery
    {
        public Bakery()
        {

        }
        public Bakery(string name, string city, string state)
        {
            BakeryName = name;
            City = city;
            State = state;

        }

        public string BakeryName{ get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int StoreID { get; set; }

        /// <summary>
        /// List that holds the current stock for that particular store
        /// </summary>
        /// <value></value>
        public List<Bread> Stock {get; set; }

        /// <summary>
        /// Holds an order history for that location
        /// </summary>
        /// <value></value>
        public List<Orders> LocationOrders { get; set; }
    }
}