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
        public int Cpr { get; set; }

        public string? Name { get; set; }

        public int CvrNavigationCvr { get; set; }

        public virtual Society CvrNavigation { get; set; } = null!;
    }
}
