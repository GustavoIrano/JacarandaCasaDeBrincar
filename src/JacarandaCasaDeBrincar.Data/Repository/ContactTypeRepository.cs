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
    public class ContactTypeRepository : Repository<ContactType>, IContactTypeRepository
    {
        private readonly JacarandaDbContext _context;

        public ContactTypeRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<ContactType>> GetByName(string name)
        {
            return _context.ContactTypes
                .Where(a => a.Name.Contains(name))
                .ToListAsync();
        }

        public Task<List<ContactType>> GetPaginated(PaginationFilter paginationFilter)
        {
            return _context.ContactTypes
                .Where(a => paginationFilter.Name != null ? a.Name.Contains(paginationFilter.Name) : a.Name != null)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
