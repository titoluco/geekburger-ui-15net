using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class FaceToUpsert
    {
        public string Face { get; set; }
        public Guid RequesterId { get; set; }
    }
}
