using EpedimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologyReport.Services
{
    public interface IPatientRepository
    {
        Task<List<Locations>> Get(string id);

        Task Save(Patient patient);
    }
}
