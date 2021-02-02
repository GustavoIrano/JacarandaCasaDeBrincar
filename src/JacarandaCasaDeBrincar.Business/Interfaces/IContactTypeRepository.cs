using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IContactTypeRepository : IRepository<ContactType>
    {
        Task<List<ContactType>> GetAllPaginated(PaginationFilter paginationFilter);
    }
}
