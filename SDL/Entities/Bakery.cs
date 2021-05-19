using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Bakery
    {
        public Bakery()
        {
            BakeryInventories = new HashSet<BakeryInventory>();
            Orders = new HashSet<Order>();
        }

        public int BakeId { get; set; }
        public string BakeryName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<BakeryInventory> BakeryInventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
