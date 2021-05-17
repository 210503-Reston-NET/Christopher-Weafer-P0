using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Trainer
    {
        public int Id { get; set; }
        public string TrainerName { get; set; }
        public string Campus { get; set; }
        public int CaffeineLevel { get; set; }
    }
}
