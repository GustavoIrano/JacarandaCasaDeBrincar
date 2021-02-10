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
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        private readonly JacarandaDbContext _context;

        public PaymentMethodRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<PaymentMethod>> GetByName(string name)
        {
            return _context.PaymentMethods
                .Where(a => a.Name.Contains(name))
                .ToListAsync();
        }

        public Task<List<PaymentMethod>> GetPaginated(PaginationFilter paginationFilter)
        {
            return _context.PaymentMethods
                .Where(a => paginationFilter.Name != null ? a.Name.Contains(paginationFilter.Name) : a.Name != null)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
