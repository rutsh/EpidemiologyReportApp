using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpidemiologyReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase 
    {

       private readonly ILocationRepository _locationRepository;
        private readonly ILogger _logger;
        public LocationController(ILocationRepository locationRepository, ILogger<LocationController> logger)
        {

            this._locationRepository = locationRepository;
            _logger = logger;
        }

        [HttpGet]
     
        public async Task<List<Locations>> Get([FromQuery]  LocationSearch search)
        {
            _logger.LogInformation("enter to Get Location Function city:" + search.City);
           return await this._locationRepository.Get(search);
        }

       


    }
}
