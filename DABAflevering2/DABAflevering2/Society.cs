using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DABAflevering2
{
    public partial class Society
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SocId { get; set; }
        public int? NumberOfMembers { get; set; }
        public string Name { get; set; }
        public string? Activity { get; set; }
        public string Cvr { get; set; }
        public string? SocAddress { get; set; }
        [BsonElement("Members")]
        public List<Member> Memberships { get; set; }
        [BsonElement("Municipality")]
        public Municipality Municipality { get; set; } = null!;
        [BsonElement("Chairmen")]
        public Chairman? Chairmen { get; set; }
        public KeyResponsible keyResponsible { get; set; }
    }
}
