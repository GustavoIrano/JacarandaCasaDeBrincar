using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class CampaignService : BaseService, ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository,
                               INotificator notificator) : base(notificator)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<bool> Add(Campaign campaign)
        {
            if (!ExecuteValidation(new CampaignValidation(), campaign)) return false;

            await _campaignRepository.Add(campaign);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _campaignRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Campaign campaign)
        {
            if (!ExecuteValidation(new CampaignValidation(), campaign)) return false;

            await _campaignRepository.Update(campaign);
            return true;
        }

        public void Dispose()
        {
            _campaignRepository?.Dispose();
        }
    }
}
