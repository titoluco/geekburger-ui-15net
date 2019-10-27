using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class ProductsListMessage
    {
        public Guid StoreId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<ItemMessage> Items { get; set; }
        public decimal Price { get; set; }
        public Guid RequesterId { get; set; }
    }
}
