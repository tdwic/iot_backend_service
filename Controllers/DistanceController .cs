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
        public async Task<IActionResult> GetDistanceDetails()
        {
            return await distanceDataService.GetDistanceDetails();
        }

        [HttpPost]
        [Route("SaveDistanceDetails")]
        public async Task<IActionResult> SaveDistanceDetails([FromBody] DistanceDataSaveModel distanceDataSaveModel)
        {
            return await distanceDataService.SaveDistanceDetails(distanceDataSaveModel);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
        //{
        //    return null;
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    return null;
        //}

    }
}
