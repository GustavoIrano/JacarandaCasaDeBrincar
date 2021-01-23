using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface ICampaignService : IDisposable
    {
        Task<bool> Add(Campaign campaign);
        Task<bool> Update(Campaign campaign);
        Task<bool> Remove(Guid id);

    }
}
