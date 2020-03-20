using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGEWebsite.Models
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }

        public string StyleType { get; set; }
        public string HomeType { get; set; }
        public string LifeType { get; set; }

    }
}
