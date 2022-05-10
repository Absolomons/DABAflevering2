using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Chairman
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ChairmanId { get; set; }
        public string? HomeAddress { get; set; }
        public string? ChairmanName { get; set; }
        public string Cpr { get; set; }
    }
}
