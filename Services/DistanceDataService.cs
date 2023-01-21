using IoTBackend.Common;
using IoTBackend.Interfaces;
using IoTBackend.Mode;
using IoTBackend.Models;

namespace IoTBackend.Services
{
    public class DistanceDataService : IDistanceDataService
    {
        private readonly IMongoDbRepository _mongoDbRepository;

        public DistanceDataService(IMongoDbRepository mongoDbRepository)
        {
            _mongoDbRepository = mongoDbRepository;
        }

        public async Task<ResponseModel> GetDistanceDetails()
        {
            var result = (await _mongoDbRepository.GetAllAsync<DistanceDataFetchModel>("DistanceData")).ToList();

            if (result.Count < 0)
            {
                return new ResponseModel()
                {
                    StatusCode = 200,
                    StatusMessage = "No Records To Fetch",
                    Data = null
                };
            }

            return new ResponseModel()
            {
                StatusCode = 200,
                StatusMessage = "OK",
                Data = new DistanceDataReturnModel()
                {
                    Id= result.Last().Id,
                    LatestDistance = result.Last().DistancValue,
                    DistanceDataFetchModelList = result
                }
            };
        }

        public async Task<ResponseModel> SaveDistanceDetails(DistanceDataSaveRequestModel distanceDataSaveRequestModel)
        {
            var distanceData = new DistanceDataSaveModel()
            {
                //Id = distanceDataSaveRequestModel.Id,
                DistancValue = distanceDataSaveRequestModel.DistancValue,
                CreatedDate = DateTime.Now,
            };

            await _mongoDbRepository.CreateAsync<DistanceDataSaveModel>("DistanceData", distanceData);
            return new ResponseModel()
            {
                StatusCode = 200,
                StatusMessage= "OK",
                Data= distanceData
            };
        }
    }
}
