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

        [Display(Name = "Decor Style")]
        public string StyleType { get; set; }

        [Display(Name = "Home Lighting")]
        public string HomeType { get; set; }

        [Display(Name = "Life Style")]
        public string LifeType { get; set; }


    }
}
