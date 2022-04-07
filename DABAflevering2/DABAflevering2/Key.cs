using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DABAflevering2
{
    public partial class Key
    {
        [Key]
        public int keyID { get; set; }

        public string? keyLocation { get; set; }

        public int RoomID { get; set; }

        public virtual Room RoomIdRoom { get; set; } = null!;
    }
}