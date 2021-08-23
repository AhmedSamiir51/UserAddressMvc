using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskUserAddress.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]

        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual List<UserAddress> UserAddresses { get; set; }
    }
}