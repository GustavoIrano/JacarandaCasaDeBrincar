using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class ContactTypeRepository : Repository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(JacarandaDbContext context) : base(context) { }
    }
}
