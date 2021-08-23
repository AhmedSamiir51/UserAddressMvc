using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskUserAddress.Models
{
    public class UserModel
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string[] Address { get; set; }
        public string[] City { get; set; }
        public string[] Country { get; set; }

        public int[] AddressId { get; set; }


    }
}