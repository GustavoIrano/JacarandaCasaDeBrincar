using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IHowDidYouknowRepository : IRepository<HowDidYouknow> 
    {
        Task<List<HowDidYouknow>> GetByName(string name);
        Task<List<HowDidYouknow>> GetPaginated(PaginationFilter paginationFilter);
    }
}
