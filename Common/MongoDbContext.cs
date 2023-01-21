using IoTBackend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IoTBackend.Common
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly MongoClient _client;
        private readonly IOptions<MongoDBSettings> mongoDBSettingss;
        public MongoDbContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            //_client = new MongoClient("mongodb+srv://abc:Abcd%4012345@cluster0.zeg68da.mongodb.net/?retryWrites=true&w=majority");
            mongoDBSettingss = mongoDBSettings;
            _client = new MongoClient(mongoDBSettingss.Value.ConnectionURI);
        }

        public IMongoDatabase Database => _client.GetDatabase(mongoDBSettingss.Value.DatabaseName);
    }
}
