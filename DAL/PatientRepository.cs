using AutoMapper;
using DAL.Models;
using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PatientRepository : IPatientRepository
    {

        private readonly ReportContext _context;
        List<Models.Patient> patients = new List<Models.Patient>();
        List<Models.Location> locations = new List<Models.Location>();
        IMapper mapper;
        public PatientRepository(ReportContext context)
        {
            _context = context;
            patients = _context.Patients.ToList();
            locations = _context.Locations.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        public async Task<List<Locations>> Get(string id)
        {
            return mapper.Map<List<Location>,List<Locations>>(locations.FindAll(l => l.PatientId.Equals(id)));           
        }

        public async Task Save(EpedimiologyReport.Services.Models.Patient patient)
        {
            _context.Patients.Add(mapper.Map< EpedimiologyReport.Services.Models.Patient, Models.Patient>(patient));
            _context.SaveChangesAsync();
        }
    }
}
