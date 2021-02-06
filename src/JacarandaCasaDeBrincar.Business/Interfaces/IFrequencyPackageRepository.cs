using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IFrequencyPackageRepository : IRepository<FrequencyPackage>
    {
        Task<List<FrequencyPackage>> GetByName(string name);
    }
}
