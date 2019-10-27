using System;

namespace GeekBurger.UI.Contract
{
    public class ItemMessage
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
    }
}