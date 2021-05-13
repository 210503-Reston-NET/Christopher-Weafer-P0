using System;
using System.Collections.Generic;
namespace SModel
{
    public class Location
    {
        public Location()
        {

        }
        public Location(string name, string city, string state)
        {
            Bakery = name;
            City = city;
            State = state;

        }

        public string Bakery{ get; set; }
        public string City { get; set; }
        public string State { get; set; }

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