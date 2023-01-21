using MongoDB.Bson;
using MongoDB.Driver;

namespace IoTBackend.Common
{
    public class MongoDbRepository : IMongoDbRepository
    {
        private readonly IMongoDbContext _context;
        public MongoDbRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string collectionName)
        {
            var collection = _context.Database.GetCollection<T>(collectionName);
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(string collectionName, string id)
        {
            var collection = _context.Database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync<T>(string collectionName, T document)
        {
            var collection = _context.Database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(document);
        }

        public async Task UpdateAsync<T>(string collectionName, string id, T document)
        {
            var collection = _context.Database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await collection.ReplaceOneAsync(filter, document);
        }

        public async Task DeleteAsync<T>(string collectionName, string id)
        {
            var collection = _context.Database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }
    }
}
