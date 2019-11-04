using System.Collections.Generic;

namespace GeekBurger.UI.Contract
{
    public class FaceChangedMessage
    {
        public State State { get; set; }
        public FaceToGet Face { get; set; }
    }
}
