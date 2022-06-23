using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologyReport.Services.Models
{
    public class Patient
    {
        public string PatientId { get; set; }

        public Patient()
        {

        }

        public Patient(string patientId)
        {
            this.PatientId = patientId;          
        }
    }
}
