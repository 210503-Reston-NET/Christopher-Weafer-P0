using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class BakeryInventory
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public int? Stock { get; set; }

        public virtual Bread Product { get; set; }
        public virtual Bakery Store { get; set; }
    }
}
