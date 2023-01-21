using IoTBackend.Common;
using IoTBackend.Interfaces;
using IoTBackend.Mode;
using IoTBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController  : ControllerBase
    {
        private readonly IDistanceDataService distanceDataService;

        public DistanceController(IDistanceDataService _distanceDataService)
        {
            distanceDataService = _distanceDataService;
        }

        [HttpGet]
        [Route("GetDistanceDetails")]
        public async Task<ResponseModel> GetDistanceDetails()
        {
            return await distanceDataService.GetDistanceDetails();
        }

        [HttpPost]
        [Route("SaveDistanceDetails")]
        public async Task<ResponseModel> SaveDistanceDetails([FromBody] DistanceDataSaveRequestModel distanceDataSaveRequestModel)
        {
            return await distanceDataService.SaveDistanceDetails(distanceDataSaveRequestModel);
        }
    }
}
