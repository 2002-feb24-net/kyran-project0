﻿using System;
using System.Collections.Generic;

namespace Project_0.Lib.Entities
{
    public partial class OrderItems
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Games Product { get; set; }
    }
}