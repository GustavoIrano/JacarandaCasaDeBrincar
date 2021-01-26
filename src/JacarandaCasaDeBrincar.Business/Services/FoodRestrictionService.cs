using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class FoodRestrictionService : BaseService, IFoodRestrictionService
    {
        private readonly IFoodRestrictionRepository _foodRestrictionRepository;

        public FoodRestrictionService(IFoodRestrictionRepository foodRestrictionRepository,
                                      INotificator notificator) : base (notificator)
        {
            _foodRestrictionRepository = foodRestrictionRepository;
        }

        public async Task<bool> Add(FoodRestriction foodRestriction)
        {
            if (!ExecuteValidation(new FoodRestrictionValidation(), foodRestriction)) return false;

            await _foodRestrictionRepository.Add(foodRestriction);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _foodRestrictionRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(FoodRestriction foodRestriction)
        {
            if (!ExecuteValidation(new FoodRestrictionValidation(), foodRestriction)) return false;

            await _foodRestrictionRepository.Update(foodRestriction);
            return true;
        }

        public void Dispose()
        {
            _foodRestrictionRepository?.Dispose();
        }
    }
}
