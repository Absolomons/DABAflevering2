using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class KeyResponsible
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CPR { get; set; }
        public string MunicipalityID { get; set; }
        public string HomeAddress { get; set; }
        public int PhoneNumber { get; set; }
        public int Passport { get; set; }

        public virtual Municipality Municipality { get; set; } = null!;

        public virtual Chairman Chairman { get; set; } = null!;
    }
}