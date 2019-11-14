using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Model
{
    public class ShowDisplayEvent
    {
        public Guid EventId { get; set; }

        public State State { get; set; }
 
        public string MessageType { get; set; }

        public bool MessageSent { get; set; }
    }
}