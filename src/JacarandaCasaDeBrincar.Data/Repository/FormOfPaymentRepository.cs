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
    public class FormOfPaymentRepository : Repository<FormOfPayment>, IFormOfPaymentRepository
    {
        private readonly JacarandaDbContext _context;

        public FormOfPaymentRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<FormOfPayment>> GetByName(string name)
        {
            return _context.FormOfPayments
                .Where(a => a.Name.Contains(name))
                .ToListAsync();
        }

        public Task<List<FormOfPayment>> GetPaginated(PaginationFilter paginationFilter)
        {
            return _context.FormOfPayments
                .Where(a => paginationFilter.Name != null ? a.Name.Contains(paginationFilter.Name) : a.Name != null)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
