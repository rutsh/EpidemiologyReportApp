
using EpedimiologyReport.Services.Models;

namespace EpedimiologyReport.Services
{
    public interface ILocationRepository
    {
        Task<List<Locations>> Get(LocationSearch locationSearch);
    }
}