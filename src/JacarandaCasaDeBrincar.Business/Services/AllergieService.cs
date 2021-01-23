using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class AllergieService : BaseService, IAllergieService
    {
        private readonly IAllergieRepository _allergieRepository;

        public AllergieService(INotificator notificator,
                               IAllergieRepository allergieRepository) : base(notificator)
        {
            _allergieRepository = allergieRepository;
        }

        public async Task<bool> Add(Allergie allergie)
        {
            if (!ExecuteValidation(new AllergieValidation(), allergie)) return false;

            await _allergieRepository.Add(allergie);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _allergieRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Allergie allergie)
        {
            if (!ExecuteValidation(new AllergieValidation(), allergie)) return false;

            await _allergieRepository.Update(allergie);
            return true;
        }

        public void Dispose()
        {
            _allergieRepository?.Dispose();
        }
    }
}
