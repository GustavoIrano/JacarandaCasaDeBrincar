using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly JacarandaDbContext _context;

        public SaleRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Sale>> GetPaginated(PaginationFilter paginationFilter)
        {
            return _context.Sales
                .Where(a => (paginationFilter.Name != null ? a.CustomerName.Contains(paginationFilter.Name) : a.CustomerName != null) ||
                            (paginationFilter.Name != null ? a.CustomerCpf.Contains(paginationFilter.Name) : a.CustomerCpf != null) ||
                            (paginationFilter.Name != null ? a.CustomerRg.Contains(paginationFilter.Name) : a.CustomerRg != null))
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
