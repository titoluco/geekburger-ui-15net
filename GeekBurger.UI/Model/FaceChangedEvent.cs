using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Model
{
    public class FaceChangedEvent
    {
        [Key]
        public Guid EventId { get; set; }

        public State State { get; set; }

        [ForeignKey("ProductId")]
        public FaceModel Face { get; set; }

        public bool MessageSent { get; set; }
    }
}