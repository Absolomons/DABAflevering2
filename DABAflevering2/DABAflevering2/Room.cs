using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Room
    {
        public Room()
        {
            //Bookingoverviews = new HashSet<Bookingoverview>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int RoomId { get; set; }
        public int? Roomlimit { get; set; }
        public DateTime? TimespanStart { get; set; }
        public DateTime? TimespanEnd { get; set; }
        public int MunicipalityId { get; set; }
        public string? RoomAddress { get; set; }
        public int? AccessCode { get; set; }
        [BsonElement("KeyResponsible")]
        public virtual Key key { get; set; }
        [BsonElement("Municipality")]
        public virtual Municipality Municipality { get; set; } = null!;
        [BsonElement("Property")]
        public virtual Property Property { get; set; } = null!;

        //public virtual ICollection<Bookingoverview> Bookingoverviews { get; set; }
    }
}
