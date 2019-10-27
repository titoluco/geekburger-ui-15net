using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.UI.Contract
{
    public class UserRetrievedMessage
    {
        public Guid UserId { get; set; }
        public bool AreRestrictionsSet { get; set; }
    }
}
