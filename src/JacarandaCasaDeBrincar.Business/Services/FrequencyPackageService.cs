using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class FrequencyPackageService : BaseService, IFrequencyPackageService
    {
        private readonly IFrequencyPackageRepository _frequencyPackageRepository;

        public FrequencyPackageService(IFrequencyPackageRepository frequencyPackageRepository,
                                       INotificator notificator) : base(notificator)
        {
            _frequencyPackageRepository = frequencyPackageRepository;
        }

        public async Task<bool> Add(FrequencyPackage frequencyPackage)
        {
            if (!ExecuteValidation(new FrequencyPackageValidation(), frequencyPackage)) return false;

            await _frequencyPackageRepository.Add(frequencyPackage);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _frequencyPackageRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(FrequencyPackage frequencyPackage)
        {
            if (!ExecuteValidation(new FrequencyPackageValidation(), frequencyPackage)) return false;

            await _frequencyPackageRepository.Update(frequencyPackage);
            return true;
        }

        public void Dispose()
        {
            _frequencyPackageRepository?.Dispose();
        }
    }
}
