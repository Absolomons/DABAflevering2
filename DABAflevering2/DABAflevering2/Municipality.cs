using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Municipality
    {
        public Municipality()
        {
            Rooms = new HashSet<Room>();
            Societies = new HashSet<Society>();
        }

        public int MunicipalityId {get; set;}

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Society> Societies { get; set; }
        public virtual ICollection<KeyResponsible> KeyResponsibles { get; set; }
    }
}
