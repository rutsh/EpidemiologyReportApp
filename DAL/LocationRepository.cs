
using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
using Newtonsoft.Json;

namespace DAL
{
    public class LocationRepository : ILocationRepository
    {
        private const string _fileUrl = "C:\\Users\\user1\\Documents\\Projects\\EpidemiologyReport\\DAL\\Data\\data.json";
        List<Patient> patients = new List<Patient>();
        public LocationRepository()
        {
            using (StreamReader reader = System.IO.File.OpenText(_fileUrl))
            {
                patients = JsonConvert.DeserializeObject<List<Patient>>(reader.ReadToEnd());

            }
        }
       
        public async Task<List<Locations>> Get(LocationSearch locationSearch)
        {
            List<Locations> locations = new List<Locations>();
            foreach (Patient p in patients)
            {
               locations.AddRange(p.locations.ToList());
            }
           if(locationSearch!=null)
                return locations.FindAll(l => l.City.Equals(locationSearch.City)).ToList();
            return locations;
        }
    }
}