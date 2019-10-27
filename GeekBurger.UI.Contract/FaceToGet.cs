using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class FaceToGet
    {
        public bool Processing { get; set; }
        public Guid UserId { get; set; }
    }
}
