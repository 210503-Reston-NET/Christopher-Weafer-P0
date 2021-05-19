using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class BreadBatch
    {
        public int BatchId { get; set; }
        public int? BreadQuantity { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Bread Product { get; set; }
    }
}
