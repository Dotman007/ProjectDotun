using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Agencies.Models
{
    public class AGENCYDB: DbContext
    {
        public AGENCYDB()
            : base("DefaultConnection")
        {
        }
    public DbSet<Agency> Agencys { get; set; }
     
        public DbSet<AgencyType> AgencyTypes { get; set; }
        public DbSet<Guest> Guests { get; set; }
    
    }
}
    