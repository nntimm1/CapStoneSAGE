using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Location
    {
        [Key]
        public int LocationId {get;set;}
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        [Display(Name = "Address")]

        public string LocationAddress { get; set; }
        [Display(Name = "Hours")]
        public string LocationHours { get; set; }
        [Display(Name = "Location Map")]
        public string LocationMap { get; set; }

    }
}
