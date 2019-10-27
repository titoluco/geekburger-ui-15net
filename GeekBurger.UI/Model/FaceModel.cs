using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Model
{
    public class FaceModel
    {        
        public Guid RequesterId { get; set; }        
        public Guid UserId { get; set; }
        public string Face { get; set; }
        public bool Processing { get; set; }
    }
}
