using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskUserAddress.Models
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Address { get; set; }

        public virtual  User User { get; set; }
    }
}