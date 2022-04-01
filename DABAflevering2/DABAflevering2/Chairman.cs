using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Chairman
    {
        public string? HomeAddress { get; set; }
        public string? ChairmanName { get; set; }
        public int Cpr { get; set; }
        public int Cvr { get; set; }

        public virtual Society CvrNavigation { get; set; } = null!;
    }
}
