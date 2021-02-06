using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IAllergieRepository : IRepository<Allergie>
    {
        Task<List<Allergie>> GetByName(string name);
    }
}
