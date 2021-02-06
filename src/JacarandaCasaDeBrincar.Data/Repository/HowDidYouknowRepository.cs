using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class HowDidYouknowRepository : Repository<HowDidYouknow>, IHowDidYouknowRepository
    {
        private readonly JacarandaDbContext _context;

        public HowDidYouknowRepository(JacarandaDbContext context) : base(context) 
        {
            _context = context;
        }

        public Task<List<HowDidYouknow>> GetByName(string name)
        {
            return _context.HowDidYouknows
                .Where(a => a.Name.Contains(name))
                .ToListAsync();
        }
    }
}
