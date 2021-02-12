using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Task<List<Sale>> GetPaginated(PaginationFilter paginationFilter);
    }
}
