using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        [Display(Name = "Shiping Method")]
        public string ShippingOption { get; set; }

        [Display(Name = "Order Line")]
        [ForeignKey("Item")]

        public int? ItemId { get; set; }
        public Item Item { get; set; }
        public IEnumerable<Item> Items { get; set; }

        [Display(Name = "Customer Id")]
        [ForeignKey("Customer")]

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Customer> Customers { get; set; }



    }
}
