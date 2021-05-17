using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            Breads = new HashSet<Bread>();
        }

        public int OrderNumber { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Bread> Breads { get; set; }
    }
}
