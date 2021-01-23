using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class HowDidYouknowService : BaseService, IHowDidYouKnowService
    {
        private readonly IHowDidYouknowRepository _howDidYouknowRepository;

        public HowDidYouknowService(IHowDidYouknowRepository howDidYouknowRepository,
                                    INotificator notificator) : base(notificator)
        {
            _howDidYouknowRepository = howDidYouknowRepository;
        }

        public async Task<bool> Add(HowDidYouknow howDidYouKnow)
        {
            if (!ExecuteValidation(new HowDidYouknowValidation(), howDidYouKnow)) return false;

            await _howDidYouknowRepository.Add(howDidYouKnow);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _howDidYouknowRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(HowDidYouknow howDidYouKnow)
        {
            if (!ExecuteValidation(new HowDidYouknowValidation(), howDidYouKnow)) return false;

            await _howDidYouknowRepository.Update(howDidYouKnow);
            return true;
        }

        public void Dispose()
        {
            _howDidYouknowRepository?.Dispose();
        }
    }
}
