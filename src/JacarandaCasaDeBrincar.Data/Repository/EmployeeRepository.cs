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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly JacarandaDbContext _context;

        public EmployeeRepository(JacarandaDbContext context) : base(context) 
        {
            _context = context;
        }

        public Task<List<Employee>> GetPaginated(PaginationFilter paginationFilter)
        {
            return _context.Employees
                .Where(a => paginationFilter.Name != null ? a.Name.Contains(paginationFilter.Name) : a.Name != null)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
