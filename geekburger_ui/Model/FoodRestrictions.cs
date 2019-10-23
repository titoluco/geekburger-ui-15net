using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geekburger_ui.Model
{
    public class FoodRestrictions
    {
        public string[] Restrictions { get; set; }
        public string Others { get; set; }
        public int UserId { get; set; }
        public int RequesterId { get; set; }
    }
}
