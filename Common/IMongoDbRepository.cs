namespace IoTBackend.Common
{
    public interface IMongoDbRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string collectionName);
        Task<T> GetByIdAsync<T>(string collectionName, string id);
        Task CreateAsync<T>(string collectionName, T document);
        Task UpdateAsync<T>(string collectionName, string id, T document);
        Task DeleteAsync<T>(string collectionName, string id);
    }
}
