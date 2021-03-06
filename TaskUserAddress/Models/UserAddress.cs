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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int AddressId { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual  User User { get; set; }
    }
}