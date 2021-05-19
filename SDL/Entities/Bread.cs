using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Bread
    {
        public Bread()
        {
            BakeryInventories = new HashSet<BakeryInventory>();
            BreadBatches = new HashSet<BreadBatch>();
        }


        public int BreadCode { get; set; }
        public string BreadType { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<BakeryInventory> BakeryInventories { get; set; }
        public virtual ICollection<BreadBatch> BreadBatches { get; set; }
    }
}
