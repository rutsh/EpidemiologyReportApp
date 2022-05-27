using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
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
        private const string _fileUrl = "C:\\Users\\user1\\Documents\\Projects\\EpidemiologyReport\\DAL\\Data\\data.json";
        List<Patient> patients = new List<Patient>();
        public PatientRepository()
        {
            using (StreamReader reader = System.IO.File.OpenText(_fileUrl))
            {
                patients = JsonConvert.DeserializeObject<List<Patient>>(reader.ReadToEnd());

            }
        }
        public async Task<Patient> Get(string id)
        {
            Patient p = patients.FirstOrDefault(p => p.PatientId.Equals(id));           
            return p;
        }

        public async Task Save(Patient patient)
        {
            patients.Add(patient);
            string json = JsonConvert.SerializeObject(patients);
            System.IO.File.WriteAllText(_fileUrl, json);
        }
    }
}
