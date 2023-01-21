using MongoDB.Driver;

namespace IoTBackend.Common
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
    }
}
