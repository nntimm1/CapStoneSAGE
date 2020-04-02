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
        public int Id { get; set; }
        [Display(Name = "Credit Card Number")]
        public decimal CreditCardNumber { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Expiration Date")]
        public string ExpirationDate { get; set; }
        [Display(Name = "CVV Code")]
        public int CVVSecurityCode { get; set; }

    }
}
