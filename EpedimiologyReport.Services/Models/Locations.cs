using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologyReport.Services.Models
{
    [Serializable]
    public class Locations
    {
        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ExactAddress { get; set; }

        public string PatientId { get; set; }
        public Locations(string city, DateTime startDate, DateTime endDate, string location, string patientId)
        {
            this.City = city;
            this.StartDate = startDate; 
            this.EndDate = endDate; 
            this.ExactAddress = location;  
            this.PatientId = patientId;
        }

        public Locations()
        {

        }
    }
}
