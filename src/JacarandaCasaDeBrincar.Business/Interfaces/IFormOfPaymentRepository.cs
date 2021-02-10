using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IFormOfPaymentRepository : IRepository<FormOfPayment>
    {
        Task<List<FormOfPayment>> GetByName(string name);
        Task<List<FormOfPayment>> GetPaginated(PaginationFilter paginationFilter);
    }
}
