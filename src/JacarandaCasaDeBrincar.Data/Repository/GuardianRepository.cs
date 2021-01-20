using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public Task<List<Guardian>> GetAllWithStudents()
        {
            return _context.Guardians.Include(g => g.Students).ToListAsync();
        }
    }
}
