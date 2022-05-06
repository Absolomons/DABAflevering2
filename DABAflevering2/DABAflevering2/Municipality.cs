using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public class Municipality
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int? MunicipalityId { get; set; }
    }
}