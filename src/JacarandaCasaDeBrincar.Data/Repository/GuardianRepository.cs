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
    public class GuardianRepository : Repository<Guardian>, IGuardianRepository
    {
        private readonly JacarandaDbContext _context;

        public GuardianRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Guardian>> GetAllWithStudents(PaginationFilter paginationFilter)
        {
            return _context.Guardians
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .Include(g => g.Students)
                .ToListAsync();
        }
    }
}
