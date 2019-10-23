using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geekburger_ui.Model
{
    public class FoodRestrictions
    {
        List<Restrictions> Restrictions { get; set; }
        string Others { get; set; }
        string UserId { get; set; }
        int RequesterId { get; set; }
    }
}
