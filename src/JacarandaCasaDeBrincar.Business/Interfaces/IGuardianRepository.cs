using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IGuardianRepository : IRepository<Guardian>
    {
        Task<List<Guardian>> GetAllWithStudents(PaginationFilter paginationFilter);
    }
}
