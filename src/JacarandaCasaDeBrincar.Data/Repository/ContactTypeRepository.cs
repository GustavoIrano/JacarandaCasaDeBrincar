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
    }
}
