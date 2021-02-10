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
    public class FrequencyPackageRepository : Repository<FrequencyPackage>, IFrequencyPackageRepository
    {
        private readonly JacarandaDbContext _context;

        public FrequencyPackageRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<FrequencyPackage>> GetByName(string name)
        {
            return _context.FrequencyPackages
                .Where(a => a.Name.Contains(name))
                .ToListAsync();
        }

        public Task<List<FrequencyPackage>> GetPaginated(PaginationFilter paginationFilter)
        {
            return _context.FrequencyPackages
                .Where(a => paginationFilter.Name != null ? a.Name.Contains(paginationFilter.Name) : a.Name != null)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
