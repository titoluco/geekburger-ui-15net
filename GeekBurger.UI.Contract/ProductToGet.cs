﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
   public class ProductToGet
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<ItemToGet> Items { get; set; }
        public decimal Price { get; set; }
    }
}
