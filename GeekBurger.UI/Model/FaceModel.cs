using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Model
{
    public class FaceModel
    {
        [Key]
        public Guid RequesterId { get; set; }
        //public Guid UserId { get; set; }

        
        public byte[] Face { get; set; }
        //public bool Processing { get; set; }
    }
}
