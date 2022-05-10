﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public class Municipality
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MunicipalityId { get; set; }
        public string Name{ get; set; }
    }
}