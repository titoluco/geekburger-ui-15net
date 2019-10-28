﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Model
{
    public class FoodRestrictionsModel
    {
        public string[] Restrictions { get; set; }
        public string Others { get; set; }
        public Guid UserId { get; set; }
        public int RequesterId { get; set; }
    }
}
