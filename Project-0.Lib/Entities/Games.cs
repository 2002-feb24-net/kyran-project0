using System;
using System.Collections.Generic;

namespace Project_0.Lib.Entities
{
    public partial class Games
    {
        public Games()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime? Release { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
