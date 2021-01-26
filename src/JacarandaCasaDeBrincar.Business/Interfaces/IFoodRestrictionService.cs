using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IFoodRestrictionService : IDisposable
    {
        Task<bool> Add(FoodRestriction foodRestriction);
        Task<bool> Update(FoodRestriction foodRestriction);
        Task<bool> Remove(Guid id);
    }
}
