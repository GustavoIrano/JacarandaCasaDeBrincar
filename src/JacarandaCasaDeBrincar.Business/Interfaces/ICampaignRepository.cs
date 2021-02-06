using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
        Task<List<Campaign>> GetByName(string name);
    }
}
