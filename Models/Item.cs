using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        [Display(Name = "Price")]
        public double UnitPrice { get; set; }
        [Display(Name = "Home Decor Type")]
        public string StyleType { get; set; }
        [Display(Name = "Home Lighting")]
        public string HomeType { get; set; }
        [Display(Name = "Life Style Type")]
        public string LifeType { get; set; }
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }
        [Display(Name = "Reorder Monthly")]
        public bool AutoReorder { get; set; }
        
    }
}
