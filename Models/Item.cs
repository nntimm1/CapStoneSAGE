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
        public string ItemName { get; set; }
        public double UnitPrice { get; set; }

        public string StyleType { get; set; }
        public string HomeType { get; set; }
        public string LifeType { get; set; }
        public string ProductType { get; set; }
        public bool AutoReorder { get; set; }
    }
}
