
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
        public PatientController(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }


        [HttpGet("{id}")]
        public async  Task<Patient> Get(string id)
        {
            return await _patientRepository.Get(id);
        }

       
        [HttpPost]
        public async Task Save([FromBody] Patient p)
        {
            await _patientRepository.Save(p);
        }


       


    }
}
