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
        public string bookingId { get; set; }
        public string SocietyCvr { get; set; }
        public string SocietyName { get; set; }
        public string ChairmanName { get; set; }

        public virtual Room Room { get; set; } = null!;
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
    }
}
