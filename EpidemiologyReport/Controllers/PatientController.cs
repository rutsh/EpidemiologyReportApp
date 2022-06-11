
using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc;


namespace EpidemiologyReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
       private readonly IPatientRepository _patientRepository;
        private readonly ILogger _logger;
        public PatientController(IPatientRepository patientRepository, ILogger<PatientController> logger)
        {
            this._patientRepository = patientRepository;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public async  Task<Patient> Get(string id)
        {
            _logger.LogInformation("enter to Get Function id:" + id);
            return await _patientRepository.Get(id);
        }

       
        [HttpPost]
        public async Task Save([FromBody] Patient p)
        {           
                _logger.LogInformation("enter to Post Function id:" + p);
                await _patientRepository.Save(p);                        
        }


       


    }
}
