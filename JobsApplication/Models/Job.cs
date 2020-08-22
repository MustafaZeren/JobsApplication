using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace JobsApplication.Models
{
    public class Job
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("JobName")]
        [Required]
        public string JobName { get; set; }

        [BsonElement("Time")]
        [Required]
        public DateTime Time { get; set; }

    }
}
