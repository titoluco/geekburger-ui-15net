using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class FoodRestrictionsMessage
    {
        public Guid UserId { get; set; }
        public Guid RequesterId { get; set; }
    }
}
