using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Society
    {
        public Society()
        {
            Bookingoverviews = new HashSet<Bookingoverview>();
            Chairmen = new HashSet<Chairman>();
        }

        public int? NumberOfMembers { get; set; }
        public string? Activity { get; set; }
        public int Cvr { get; set; }
        public int MunicipalityId { get; set; }

        public string? SocAddress { get; set; }
        public List<Member> Memberships { get; set; }

        public virtual Municipality Municipality { get; set; } = null!;
        public virtual ICollection<Bookingoverview> Bookingoverviews { get; set; }
        public virtual ICollection<Chairman> Chairmen { get; set; }
    }
}
