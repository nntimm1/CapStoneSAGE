using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Payment
    {
        [Key]
        public ulong? CreditCardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExpirationDate { get; set; }
        public int CVVSecurityCode { get; set; }

    }
}
