using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DABAflevering2
{
    public partial class Member
    {
        [Key]
        public int Cpr { get; set; }

        public string? Name { get; set; }

        public int CvrNavigationCvr { get; set; }

        public virtual Society CvrNavigation { get; set; } = null!;
    }
}
