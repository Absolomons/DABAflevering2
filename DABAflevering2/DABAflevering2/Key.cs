using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Key
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string keyID { get; set; }

        public string? keyLocation { get; set; }
    }
}