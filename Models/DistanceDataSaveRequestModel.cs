using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IoTBackend.Models
{
    public class DistanceDataSaveRequestModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string? Id { get; set; }
        public float DistancValue { get; set; }
    }
}
