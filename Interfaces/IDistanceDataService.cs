using IoTBackend.Common;
using IoTBackend.Mode;
using IoTBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTBackend.Interfaces
{
    public interface IDistanceDataService
    {
        Task<ResponseModel> GetDistanceDetails();
        Task<ResponseModel> SaveDistanceDetails(DistanceDataSaveRequestModel distanceDataSaveRequestModel);
    }
}
