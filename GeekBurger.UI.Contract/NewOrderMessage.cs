using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class NewOrderMessage
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public List<ProductMessage> Products { get; set; }
        public Guid[] ProductionIds { get; set; }
    }
}
