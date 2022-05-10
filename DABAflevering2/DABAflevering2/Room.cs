﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAflevering2
{
    public partial class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }
        public int? Roomlimit { get; set; }
        public DateTime? TimespanStart { get; set; }
        public DateTime? TimespanEnd { get; set; }
        //public string MunicipalityId { get; set; }
        public string? RoomAddress { get; set; }
        public int? AccessCode { get; set; }
        public virtual Key key { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual Property Property { get; set; }
    }
}
