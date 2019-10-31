using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class FoodRestrictionsResponse
    {
        public Guid RequesterId { get; set; }
    }

    public class FoodRestrictionMessage
    {
        public guid UserId { get; set; }
    }
