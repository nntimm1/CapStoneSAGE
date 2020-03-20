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
        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public string LocationHours { get; set; }

        public string LocationMap { get; set; }

    }
}
