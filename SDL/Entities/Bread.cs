using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Bread
    {
        public string BreadType { get; set; }
        public double? Price { get; set; }
        public int? BreadCollection { get; set; }

        public virtual Order BreadCollectionNavigation { get; set; }
    }
}
