using IoTBackend.Common;
using IoTBackend.Interfaces;
using IoTBackend.Mode;
using Microsoft.AspNetCore.Mvc;

namespace IoTBackend.Services
{
    public class DistanceDataService : IDistanceDataService
    {
        private readonly IMongoDbRepository _mongoDbRepository;

        public DistanceDataService(IMongoDbRepository mongoDbRepository)
        {
            _mongoDbRepository = mongoDbRepository;
        }

        public async Task<IActionResult> GetDistanceDetails()
        {
            var result = await _mongoDbRepository.GetAllAsync<DistanceDataSaveModel>("mytest");
            return null;
        }

        public async Task<IActionResult> SaveDistanceDetails(DistanceDataSaveModel distanceDataSaveModel)
        {
            await _mongoDbRepository.CreateAsync<DistanceDataSaveModel>("mytest", distanceDataSaveModel);
            return null;
        }
    }
}
