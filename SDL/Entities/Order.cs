using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            BreadBatches = new HashSet<BreadBatch>();
        }

        public int OrderNumber { get; set; }
        public double? OrderTotal { get; set; }
        public int? CustomerId { get; set; }
        public int? BakeryId { get; set; }

        public virtual Bakery Bakery { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<BreadBatch> BreadBatches { get; set; }
    }
}
