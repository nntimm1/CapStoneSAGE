using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class SurveyItems
    {
        public Survey Survey { get; set; }
        public Item Item { get; set; }
        public Customer Customer { get; set; }
    }
}
