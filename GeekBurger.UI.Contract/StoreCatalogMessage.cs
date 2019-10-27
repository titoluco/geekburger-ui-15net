using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class StoreCatalogMessage
    {
        public Guid StoreId { get; set; }
        public bool Ready { get; set; }
    }
}
