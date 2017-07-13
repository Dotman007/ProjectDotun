using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agencies.Models
{
    public class Agency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }
        public int AgencyNumber { get; set; }
        public string AgencyWebsite { get; set; }
        public string CompanyWebsite { get; set; }
        public string Level { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string MobileNo { get; set; }
        public string Field { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public string EmployerName { get; set; }
        public string CompanyDescription { get; set; }
        public string Skill { get; set; }
        public int AgencyTypeId { get; set; }

        //public virtual ICollection<RoomReservation> RoomReservations { get; set; }
        public virtual AgencyType AgencyType { get; set; }

        public virtual Guest Guest { get; set; }



    }
}