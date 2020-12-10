using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Nyous.Api.NoSql.Domains
{
    public class BaseDomain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
