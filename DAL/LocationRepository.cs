
using AutoMapper;
using DAL.Models;
using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
using Newtonsoft.Json;

namespace DAL
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ReportContext _context;
        
        List<Models.Location> locations = new List<Models.Location>();
        IMapper mapper;

        public LocationRepository(ReportContext context)
        {
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
            _context = context;
            locations = _context.Locations.ToList();
        }
       
        public async Task<List<Locations>> Get(LocationSearch locationSearch)
        {
           if(locationSearch!=null)
                return mapper.Map<List<Location>,List<Locations>>(  locations.FindAll(l => l.City.Equals(locationSearch.City)).ToList());
            return mapper.Map<List<Location>, List<Locations>>(locations);
        }
    }
}