using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; }
        public string RoomId { get; set; }
        public bool? WiFi { get; set; }
        public bool? Whiteboard { get; set; }
        public bool? SoccerGoals { get; set; }
        public bool? Coffee { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
