using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agencies.Models
{
    public class AgencyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgencyTypeId { get; set; }

        [Display(Name = "Agency Type")]
        public string AgencyTypeName { get; set; }
        [Display(Name = "Level")]
        public string Level { get; set; }
        [Display(Name = "Required Qualification/Competency")]
        public string QualificationRequired { get; set; }
        [Display(Name = "Field")]
        public string AreaOfSpecialization { get; set; }
        [Display(Name = "Available Job")]
        public string AvailableJob { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "MobileNo ")]
        public string MobileNo { get; set; }
        public string Website { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; }

    }
}