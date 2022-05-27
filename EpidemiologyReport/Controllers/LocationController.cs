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
        public LocationController(ILocationRepository locationRepository)
        {
            
            this._locationRepository = locationRepository;
        }
        
        [HttpGet]
     
        public async Task<List<Locations>> Get([FromQuery]  LocationSearch search=null)
        {
          
           return await this._locationRepository.Get(search);
        }

       


    }
}
