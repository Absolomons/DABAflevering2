using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Society
    {
        public Society()
        {
        }

        public int? NumberOfMembers { get; set; }
        public string Name { get; set; }
        public string? Activity { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Cvr { get; set; }
        public string? SocAddress { get; set; }
        [BsonElement("Members")]
        public List<Member> Memberships { get; set; }
        [BsonElement("Municipality")]
        public virtual Municipality Municipality { get; set; } = null!;
        [BsonElement("Chairmen")]
        public virtual Chairman Chairmen { get; set; }
    }
}
