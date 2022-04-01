using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Property
    {
        public int RoomId { get; set; }
        public int PropertyId { get; set; }
        public bool? WiFi { get; set; }
        public bool? Whiteboard { get; set; }
        public bool? SoccerGoals { get; set; }
        public bool? Coffee { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
