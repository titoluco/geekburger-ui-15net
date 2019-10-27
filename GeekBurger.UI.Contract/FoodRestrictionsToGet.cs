using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class FoodRestrictionsToGet
    {
        public bool Processing { get; set; }
        public Guid UserId { get; set; }
    }
}
