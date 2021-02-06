using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class FoodRestrictionRepository : Repository<FoodRestriction>, IFoodRestrictionRepository
    {
        private readonly JacarandaDbContext _context;

        public FoodRestrictionRepository(JacarandaDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<FoodRestriction>> GetByName(string name)
        {
            return _context.FoodRestrictions
                .Where(a => a.Name.Contains(name))
                .ToListAsync();
        }
    }
}
