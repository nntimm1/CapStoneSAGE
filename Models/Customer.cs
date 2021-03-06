﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress{ get; set; }
        [Display(Name = "Marketing Opt In/Out")]
        public bool EmailOptIn { get; set; }

        [Display(Name = "Payment Method")]
        [ForeignKey("Payment")]

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public IEnumerable<Payment> Payments { get; set; }

        [Display(Name = "Plant Survey")]
        [ForeignKey("Survey")]

        public int? SurveyId { get; set; }
        public Survey Survey { get; set; }

        public IEnumerable<Survey> Surveys { get; set; }

        [Display(Name = "Shipping Address")]
        [ForeignKey("ShippingAddress")]
        
        public int? ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }
        public IEnumerable<Address> Addresses { get; set; }

        [Display(Name = "Billing Address")]
        [ForeignKey("BillingAddress")]
        public int? BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
