using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Cpr { get; set; }

        public string? Name { get; set; }

    }
}
