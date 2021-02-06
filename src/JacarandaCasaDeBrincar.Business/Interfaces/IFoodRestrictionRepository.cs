using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IFoodRestrictionRepository : IRepository<FoodRestriction>
    {
        Task<List<FoodRestriction>> GetByName(string name);
    }
}
