using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class KeyResponsible
    {
        public int CPR { get; set; }
        public int MunicipalityID { get; set; }
        public string HomeAddress { get; set; }
        public int PhoneNumber { get; set; }
        public int Passport { get; set; }

        public virtual Municipality Municipality { get; set; } = null!;

        public virtual Chairman Chairman { get; set; } = null!;
    }
}