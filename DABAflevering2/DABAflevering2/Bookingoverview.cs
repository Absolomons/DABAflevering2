using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Bookingoverview
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public int SocietyCvr { get; set; }
        public int SocietyName { get; set; }
        public string ChairmanName { get; set; }

        [BsonElement("Room")]
        public virtual Room Room { get; set; } = null!;

        public int RoomId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
    }
}
