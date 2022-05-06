using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Chairman
    {
        public string? HomeAddress { get; set; }
        public string? ChairmanName { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Cpr { get; set; }
        public int Cvr { get; set; }

    }
}
