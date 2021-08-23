using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskUserAddress.Models
{
    public class AddressModel
    {

        public int AddressId { get; set; }
        public int IdUser { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }



    }
}