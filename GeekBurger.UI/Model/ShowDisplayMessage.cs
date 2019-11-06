using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Model
{
    public class ShowDisplayMessage
    {
        public string Label { get; set; }
        public object Body { get; set; }

        public IDictionary<string, object> Properties { get; set; }
    }
}
