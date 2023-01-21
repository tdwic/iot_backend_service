using IoTBackend.Mode;
using Microsoft.AspNetCore.Mvc;

namespace IoTBackend.Interfaces
{
    public interface IDistanceDataService
    {
        Task<IActionResult> GetDistanceDetails();
        Task<IActionResult> SaveDistanceDetails(DistanceDataSaveModel distanceDataSaveModel);
    }
}
