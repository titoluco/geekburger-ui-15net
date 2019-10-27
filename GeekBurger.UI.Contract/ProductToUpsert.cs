using System;

namespace GeekBurger.UI.Contract
{
    public class ProductToUpsert
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
    }
}