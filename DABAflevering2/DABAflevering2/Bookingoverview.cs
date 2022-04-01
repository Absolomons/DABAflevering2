using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Bookingoverview
    {
        public int Cvr { get; set; }

        //public int ID { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }

        public virtual Society CvrNavigation { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
