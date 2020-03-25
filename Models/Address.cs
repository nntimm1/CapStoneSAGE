using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Display(Name = "Street Address")]
        public string Address1 { get; set; }
        [Display(Name = "Street Address 2")]
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

    }
}
